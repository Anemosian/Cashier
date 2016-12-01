using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Drawing;
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
                txtTotal.Text = String.Format("{0:c}",transactionTotal);
            }
        }

        public Cashier()
        {
            InitializeComponent();
            CreateTabbedPanel();
            populateTabs();
        }

        private void Cashier_Load(object sender, EventArgs e)
        {
           
        }

        private void CreateTabbedPanel()
        {
            using (CashierDBEntities cdbe = new CashierDBEntities())
            {
                foreach (TblProductType pt in cdbe.TblProductTypes)
                {
                    tabControl1.TabPages.Add(pt.ProductType.ToString(), pt.Description);
                }
            }

        }
        
        private void populateTabs()
        {
            int i = 1;

            foreach (TabPage tp in tabControl1.TabPages)
            {
                var objctx = (cdbe as IObjectContextAdapter).ObjectContext;
                ObjectQuery<TblProduct> filteredProduct = objctx.CreateQuery<TblProduct>("SELECT p FROM TblProducts AS p WHERE p.ProductType = " + i);

                FlowLayoutPanel flp = new FlowLayoutPanel();

                flp.Dock = DockStyle.Fill;

                foreach (TblProduct tproduct in filteredProduct)
                {
                    Button btn = new Button();

                    btn.Size = new Size(100, 100);
                    btn.Text = tproduct.Description;
                    btn.Tag = tproduct;

                    btn.Click += new EventHandler(UpdateProductList);

                    flp.Controls.Add(btn);
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

            string currentDescriptionPadded = tblp.Description.PadRight(30);
            string currentPrice = String.Format(new CultureInfo("en-PH"), "{0:c}", tblp.Price);
            string output = currentDescriptionPadded + currentPrice;

            txtInfoPanel.Text = output;

        }

        private void FormatListItem(object sender, ListControlConvertEventArgs e)
        {
            string currentDescription = ((TblProduct)e.ListItem).Description;
            string currentPrice = String.Format("{0:c}",((TblProduct)e.ListItem).Price);
            //string currentDescriptionPadded = currentDescription.PadRight(30);
            string currentDescriptionPadded = currentDescription;

            e.Value = currentDescriptionPadded + currentPrice;
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            TblProduct selectedProduct = (TblProduct)listProductsChosen.SelectedItem;
            productsChosen.Remove(selectedProduct);
            TransactionTotal -= (decimal)selectedProduct.Price;

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            PayDialogue payDialogue = new PayDialogue();
            
            payDialogue.PaymentAmount = TransactionTotal;
            payDialogue.ShowDialog();
            payDialogue.PaymentMade += new PayDialogue.PaymentMadeEvent(PaymentSuccess);
        }

        private void PaymentSuccess(object sender, PaymentMadeEventArgs e)
        {
            TblTransaction transaction = new TblTransaction();
            transaction.TransactionDate = DateTime.Now;
            if (e.PaymentSuccess == true) {

            }
            
        }
    }
}
