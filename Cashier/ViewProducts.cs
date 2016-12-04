using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
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

            dataGridView1.DataSource = cdbe.TblProducts.ToArray();

            dataGridView1.Columns["ProductType"].Visible = false;
            dataGridView1.Columns["TblProductType"].Visible = false;
            dataGridView1.Columns["TblTransactionItems"].Visible = false;
            dataGridView1.Columns["ProductId"].HeaderText = "Product ID Number";
            dataGridView1.Columns["ProductId"].DisplayIndex = 0;
            dataGridView1.Columns["Description"].HeaderText = "Product Name";
            dataGridView1.Columns["Description"].DisplayIndex = 1;
            dataGridView1.Columns["Price"].DisplayIndex = 2;
            dataGridView1.Columns["Image"].DisplayIndex = 3;

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

     
    }
}
