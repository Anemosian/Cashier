﻿using System;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            btnSalesSummary.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
        }

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            ViewProducts viewProducts = new ViewProducts();
            viewProducts.Show();
        }



        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            AddProductType prodTypes = new AddProductType();
            prodTypes.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            Cashier cashier = new Cashier();

            this.Hide();

            cashier.ShowDialog();

            this.Close();
        }

        private void btnSalesSummary_Click(object sender, EventArgs e)
        {
            SalesSummary sales = new SalesSummary();
            sales.Show();
        }
    }
}
