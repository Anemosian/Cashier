using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier
{
    public partial class AddProductType : Form
    {
        private CashierDBEntities cdbe = new CashierDBEntities();

        public AddProductType()
        {
            InitializeComponent();
            dataGridView1.DataSource = cdbe.TblProductTypes.ToArray();
            dataGridView1.Columns["ProductType"].Visible = false;
            dataGridView1.Columns["TblProducts"].Visible = false;
            dataGridView1.Columns["Description"].HeaderText = "Product Type";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TblProductType productType = new TblProductType();

            productType.Description = txtDescription.Text;

            cdbe.TblProductTypes.Add(productType);

            cdbe.SaveChanges();

            dataGridView1.Update();

            dataGridView1.Refresh();

            dataGridView1.DataSource = cdbe.TblProductTypes.ToArray(); 
        }
    }
}
