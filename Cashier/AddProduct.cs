using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Cashier
{
    public partial class AddProduct : Form
    {

        private CashierDBEntities cdbe = new CashierDBEntities();

        private Byte[] bytePicData;

        public AddProduct()
        {
            InitializeComponent();

            cboCategory.DataSource = cdbe.TblProductTypes.ToList();
            cboCategory.DisplayMember = "Description";
            cboCategory.ValueMember = "ProductType";
            cboCategory.SelectedIndex = -1;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                FileStream fsPicFile = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                bytePicData = new Byte[fsPicFile.Length];

                fsPicFile.Read(bytePicData, 0, bytePicData.Length);

                fsPicFile.Close();

                MemoryStream stmPicData = new MemoryStream(bytePicData);

                pbIcon.Image = Image.FromStream(stmPicData);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                TblProduct product = new TblProduct();

                product.Description = txtDescription.Text;

                product.Price = decimal.Parse(txtPrice.Text);

                product.Image = bytePicData;

                product.ProductType = (int)cboCategory.SelectedValue;

                cdbe.TblProducts.Add(product);

                cdbe.SaveChanges();

                MessageBox.Show("Item Saved!");

                this.Close();
            }
            catch
            {
                MessageBox.Show("Please fill all fields with the proper information.");
            }



        }
    }
}

