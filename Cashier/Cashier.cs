using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cashier
{
    public partial class Cashier : Form
    {
        private BindingList<TblProduct> productsChosen = new BindingList<TblProduct>();
        private CashierDBEntities cdbe = new CashierDBEntities();
        private decimal transactionTotal;

        public decimal TransactionTotal
        {
            get { return transactionTotal; }
            set
            {
                transactionTotal = value;
                txtTotal.Text = String.Format(new CultureInfo("en-PH"),"{0:c}",transactionTotal);
            }
        }

        public Cashier()
        {
            InitializeComponent();
            CreateTabbedPanel();
            populateTabs();
            listProductsChosen.DataSource = productsChosen;

        }

        private void Cashier_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void CreateTabbedPanel()
        {
            foreach (TblProductType pt in cdbe.TblProductTypes)
            {
                tabControl1.TabPages.Add(pt.ProductType.ToString(), pt.Description);
            }
        }

        private void populateTabs()
        {
            int i = 1;

            foreach (TabPage tp in tabControl1.TabPages)
            {
                FlowLayoutPanel flp = new FlowLayoutPanel();

                flp.Dock = DockStyle.Fill;

                foreach (TblProduct tproduct in cdbe.TblProducts)
                {
                    if (tproduct.ProductType == i && tproduct.Availability == 1)
                    {
                        Button btn = new Button();
                        if (tproduct.Image != null)
                        {
                            btn.BackgroundImage = (Bitmap)((new ImageConverter()).ConvertFrom(tproduct.Image));
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        btn.Size = new Size(100, 100);
                        btn.Text = tproduct.Description;
                        btn.Tag = tproduct;

                        btn.Click += new EventHandler(UpdateProductList);

                        flp.Controls.Add(btn);
                    }
                }
                tp.Controls.Add(flp);
                i++;
            }

        }

        private void UpdateProductList(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TblProduct p = (TblProduct)btn.Tag;

            productsChosen.Add(p);

            UpdateInfoPanel(p);

            TransactionTotal = TransactionTotal + (decimal)p.Price;

            listProductsChosen.SelectedIndex = listProductsChosen.Items.Count - 1;

        }

        private void UpdateInfoPanel(TblProduct tblp)
        {
            TblProduct selectedProduct = (TblProduct)listProductsChosen.SelectedItem;
            if (selectedProduct != null)
            {

                string currentDescriptionPadded = tblp.Description.PadRight(30);
                string currentPrice = String.Format(new CultureInfo("en-PH"), "{0:c}", tblp.Price);
                string output = currentDescriptionPadded + currentPrice;

                txtInfoPanel.Text = output;
            }

        }

        private void FormatListItem(object sender, ListControlConvertEventArgs e)
        {
            string currentDescription = ((TblProduct)e.ListItem).Description;
            string currentPrice = String.Format(new CultureInfo("en-PH"),"{0:c}",((TblProduct)e.ListItem).Price);
            string currentDescriptionPadded = currentDescription.PadRight(22);
            //string currentDescriptionPadded = currentDescription;

            e.Value = currentDescriptionPadded + currentPrice;
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            TblProduct selectedProduct = (TblProduct)listProductsChosen.SelectedItem;
            if (selectedProduct != null)
            {
                productsChosen.Remove(selectedProduct);
                TransactionTotal -= (decimal)selectedProduct.Price;
                UpdateInfoPanel((TblProduct)listProductsChosen.SelectedItem);
            }
            
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            PayDialogue payDialogue = new PayDialogue();

            payDialogue.PaymentMade += new PayDialogue.PaymentMadeEvent(PaymentSuccess);
            payDialogue.PaymentAmount = TransactionTotal;

            payDialogue.ShowDialog();
        }

        private void PrintReceipt()
        {
            PrintDialog printdialog = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();

            printdialog.Document = printDoc;

            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            DialogResult result = printdialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12);

            SolidBrush brush = new SolidBrush(Color.Black);
            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;
            graphic.DrawString("ITEMS PURCHASED", new Font("Courier New", 18), brush,startX, startY);
            //receipt number
            //date and time
            
            foreach(TblProduct p in productsChosen)
            {
                string productDescription = p.Description.PadRight(30);
                string total = String.Format(new CultureInfo("en-PH"),"{0:c}", p.Price);
                string productLine = productDescription + total;

                graphic.DrawString(productLine, font, brush, startX, startY + offset);

                offset = offset + (int)fontHeight + 5;
            }
            graphic.DrawString("Total:".PadRight(30) + String.Format(new CultureInfo("en-PH"), "{0:c}",TransactionTotal), font, brush, startX, startY + offset);
        }

        void PaymentSuccess(object sender, PaymentMadeEventArgs e)
        {
            TblTransaction transaction = new TblTransaction();
            transaction.TransactionDate = DateTime.Now;

            if (e.PaymentSuccess == true) {
                
                foreach (TblProduct product in productsChosen)
                {
                    transaction.TblTransactionItems.Add(new TblTransactionItem() { ProductId = product.ProductId});
                }
                cdbe.TblTransactions.Add(transaction);
                cdbe.SaveChanges();

                PrintReceipt();

                txtInfoPanel.Text = " Next Customer";
                productsChosen.Clear();
                TransactionTotal = 0;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            
            this.Hide();

            home.ShowDialog();

            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clock.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        private void listProductsChosen_SelectedIndexChanged(object sender, EventArgs e)
        {
            TblProduct selectedProduct = (TblProduct)listProductsChosen.SelectedItem;
            if (selectedProduct != null)
            {

                string currentDescriptionPadded = selectedProduct.Description.PadRight(30);
                string currentPrice = String.Format(new CultureInfo("en-PH"), "{0:c}", selectedProduct.Price);
                string output = currentDescriptionPadded + currentPrice;

                txtInfoPanel.Text = output;
            }
        }
    }
}
