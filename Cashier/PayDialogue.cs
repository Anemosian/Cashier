﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier
{
    public partial class PayDialogue : Form
    {
        public delegate void PaymentMadeEvent(object sender, PaymentMadeEventArgs e);

        public event PaymentMadeEvent PaymentMade;

        private decimal paymentAmount;

        public decimal PaymentAmount
        {
            get
            {
                return paymentAmount;
            }

            set
            {
                paymentAmount = value;
                txtAmountDue.Text = String.Format(new CultureInfo("en-PH"), "{0:c}", paymentAmount);
            }
        }

        public PayDialogue()
        {
            InitializeComponent();
        }

        private void PaymentGiven(object sender, EventArgs e)
        {
            decimal total = 0;

            try {
                total = decimal.Parse(txtAmountDue.Text.Trim('₱')) - decimal.Parse(txtPaymentAmount.Text);
            }
            catch
            {
                MessageBox.Show("An error has occured. Please enter a valid amount.");
                return;
            }


            if (total > 0) {
                MessageBox.Show("Payment lacks " + String.Format(new CultureInfo("en-PH"), "{0:c}", total));
                PaymentMade(this, new PaymentMadeEventArgs() { PaymentSuccess = false });
            }
            else
            {
                MessageBox.Show("Please give " + String.Format(new CultureInfo("en-PH"), "{0:c}", (-1*total)) + " as change.");
                PaymentMade(this, new PaymentMadeEventArgs() { PaymentSuccess = true });
                this.Hide();

            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            
        }
    }

    public class PaymentMadeEventArgs : EventArgs
    {
        private bool paymentSuccess;

        public bool PaymentSuccess
        {
            get
            {
                return paymentSuccess;
            }

            set
            {
                paymentSuccess = value;
            }
        }
    }
}
