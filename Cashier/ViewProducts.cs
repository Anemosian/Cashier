﻿using System;
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

            //dataGridView1.DataSource = cdbe.TblProducts;

            //dataGridView1.Columns["ProductType"].Visible = false;
            //dataGridView1.Columns["TblProductType"].Visible = false;
            //dataGridView1.Columns["TblTransactionItems"].Visible = false;

            //cboFilter.DataSource = cdbe.TblProductTypes.ToList();
            //cboFilter.DisplayMember = "Description";
            //cboFilter.ValueMember = "ProductType";
        }

        private void FilterList(object sender, EventArgs e)
        {
            string sqlString = "SELECT VALUE st FROM CoffeeShopDBEntities.tblProduct AS st WHERE st.ProductType == '" + cboFilter.SelectedValue + "'";
            var objctx = (cdbe as IObjectContextAdapter).ObjectContext;

            ObjectQuery<TblProduct> filteredProducts = objctx.CreateQuery<TblProduct>(sqlString);

            dataGridView1.DataSource = filteredProducts;
        }

     
    }
}