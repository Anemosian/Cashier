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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Cashier
{
    public partial class AddProduct : Form
    {

        private CashierDBEntities cdbe = new CashierDBEntities();

        private Byte[] bytePicData;
        private Byte[] productIcon;

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

                Image rawIcon = Image.FromStream(stmPicData);

                pbIcon.Image = rawIcon;

                Image resizedIcon = ResizeImage(rawIcon, 100, 100);

                productIcon = ImageToByte(resizedIcon);
            }
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                TblProduct product = new TblProduct();

                product.Description = txtDescription.Text;

                product.Price = decimal.Parse(txtPrice.Text);

                product.Image = productIcon;

                product.ProductType = (int)cboCategory.SelectedValue;

                product.Availability = 1;

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

