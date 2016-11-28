﻿namespace Cashier
{
    partial class Cashier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listProductsChosen = new System.Windows.Forms.ListBox();
            this.cashierDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.txtInfoPanel = new System.Windows.Forms.TextBox();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cashierDBDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listProductsChosen
            // 
            this.listProductsChosen.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listProductsChosen.FormattingEnabled = true;
            this.listProductsChosen.ItemHeight = 14;
            this.listProductsChosen.Location = new System.Drawing.Point(685, 52);
            this.listProductsChosen.Name = "listProductsChosen";
            this.listProductsChosen.Size = new System.Drawing.Size(325, 354);
            this.listProductsChosen.TabIndex = 0;
            this.listProductsChosen.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatListItem);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(18, 84);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(642, 350);
            this.tabControl1.TabIndex = 1;
            // 
            // txtInfoPanel
            // 
            this.txtInfoPanel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfoPanel.Location = new System.Drawing.Point(18, 52);
            this.txtInfoPanel.Name = "txtInfoPanel";
            this.txtInfoPanel.Size = new System.Drawing.Size(640, 26);
            this.txtInfoPanel.TabIndex = 2;
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackColor = System.Drawing.Color.Tomato;
            this.btnDeleteItem.Location = new System.Drawing.Point(685, 448);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(129, 40);
            this.btnDeleteItem.TabIndex = 3;
            this.btnDeleteItem.Text = "&Delete";
            this.btnDeleteItem.UseVisualStyleBackColor = false;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.GreenYellow;
            this.btnPay.Location = new System.Drawing.Point(152, 448);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(369, 40);
            this.btnPay.TabIndex = 4;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(685, 405);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(325, 29);
            this.txtTotal.TabIndex = 5;
            // 
            // Cashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 577);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.txtInfoPanel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listProductsChosen);
            this.Name = "Cashier";
            this.Text = "Cashier";
            this.Load += new System.EventHandler(this.Cashier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cashierDBDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listProductsChosen;
        private System.Windows.Forms.BindingSource cashierDBDataSetBindingSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox txtInfoPanel;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.TextBox txtTotal;
    }
}