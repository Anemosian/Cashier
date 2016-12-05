using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier
{
    public partial class ViewProducts : Form
    {
        private CashierDBEntities cdbe = new CashierDBEntities();

        public ViewProducts()
        {
            InitializeComponent();
            dataGridView1.DataSource = cdbe.TblProducts.ToList();
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);

            dataGridView1.Columns["ProductType"].Visible = false;
            dataGridView1.Columns["TblProductType"].Visible = false;
            dataGridView1.Columns["TblTransactionItems"].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.Columns["ProductId"].HeaderText = "Product ID";
            dataGridView1.Columns["ProductId"].DisplayIndex = 0;
            //dataGridView1.Columns["ProductId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView1.Columns["Description"].HeaderText = "Product Name";
            dataGridView1.Columns["Description"].DisplayIndex = 1;
            dataGridView1.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Price"].DisplayIndex = 2;
            dataGridView1.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Availability"].DisplayIndex = 3;
            dataGridView1.Columns["Availability"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Image"].DisplayIndex = 4;
            //dataGridView1.Columns["Image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView1.Columns["Image"].D = DataGridViewAutoSizeRowMode.AllCells;

            cboFilter.DataSource = cdbe.TblProductTypes.ToList();
  
            cboFilter.DisplayMember = "Description";
            cboFilter.ValueMember = "ProductType";
            cboFilter.SelectedIndex = -1;
        }

        private void FilterList(object sender, EventArgs e)
        {
            string sqlString = "SELECT VALUE st FROM CashierDBEntities.TblProducts AS st WHERE st.ProductType == " + cboFilter.SelectedValue;
            var objctx = (cdbe as IObjectContextAdapter).ObjectContext;

            ObjectQuery<TblProduct> filteredProducts = objctx.CreateQuery<TblProduct>(sqlString);

            dataGridView1.DataSource = filteredProducts;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow product in dataGridView1.SelectedRows)
            {
                var a = product.DataBoundItem as TblProduct;

                
                if(a.Availability == 1)
                {
                    a.Availability = 0;
                    cdbe.SaveChanges();
                    dataGridView1.DataSource = cdbe.TblProducts.ToArray();
                }
                else
                {
                    a.Availability = 1;
                    cdbe.SaveChanges();
                    dataGridView1.DataSource = cdbe.TblProducts.ToArray();
                }
            }
  
        }
       

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Availability")
            {
                if (e.Value != null)
                {
                    string stringValue =  e.Value.ToString();
                    stringValue = stringValue.ToLower();

                    if ((stringValue.IndexOf("1") > -1))
                    {
                        e.Value = "Available";
                        e.FormattingApplied = true;
                    }
                    else if ((stringValue.IndexOf("0") > -1))
                    {
                        e.Value = "Not Available";
                        e.FormattingApplied = true;
                    }

                }
            }
        }
    }
}
