//Project Name: SarreSports | File Name: viewItem.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 5/1/2019 | 21:56
//Last Updated On:  8/1/2019 | 00:43
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SarreSports
{
    public partial class viewItem : Form
    {
        public enum viewItemState
        {
            View = 0,
            Restock = 1,
            Buy = 2
        }

        public viewItem()
        {
            InitializeComponent();
            uiBuyItemButton.Hide();
            uiRestockItemButton.Hide();
        }

        //Form Events
        private void uiSaveBarcodeButton_Click(object sender, EventArgs e)
        {
            saveBarcode();
        }

        private void uiPrintBarcodeButton_Click(object sender, EventArgs e)
        {
            printBarode();
        }

        //Form Methods
        protected virtual void buyItem()
        {
            Console.WriteLine("Form: New View Item. Error: Form not implemented.");
            MessageBox.Show("Form Aborting. Called improperly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        protected virtual void restockItem()
        {
            Console.WriteLine("Form: New View Item. Error: Form not implemented.");
            MessageBox.Show("Form Aborting. Called improperly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
        //Form Value Update Methods
        public void updateProductAvailability(bool available)
        {
            if (available)
            {
                uiAvaliableForSaleValueLabel.Text = "✓";
                uiAvaliableForSaleValueLabel.ForeColor = Color.Green;
            }
            else
            {
                uiAvaliableForSaleValueLabel.Text = "X";
                uiAvaliableForSaleValueLabel.ForeColor = Color.Red;
                uiBuyItemButton.Enabled = false;
            }
        }
        
        public void updateSupplierName(string supplier)
        {
            uiSupplierNameLabel.Text = Generic.Truncate(supplier, 20);
        }
        
        public void updateProductID(string productID)
        {
            uiItemIDValueLabel.Text = productID;
            Zen.Barcode.Code128BarcodeDraw itemBarcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            uiItemBarcodePictureBox.Image = itemBarcode.Draw(productID.ToString(), uiItemBarcodePictureBox.Height);
        }
        
        public void updateProductName(string productName)
        {
            uiItemNameTitle.Text = Generic.Truncate(productName, 20);
            uiItemNameTextBox.Text = Generic.Truncate(productName, 50);
        }
       
        public void updateProductCost(string productCost)
        {
            uiItemCostTextBox.Text = productCost;
        }
        
        public void updateProductStockLevel(string stockLevel)
        {
            uiItemStockLevelTextBox.Text = stockLevel;
            if (Int32.Parse(stockLevel) <= 0)
            {
                uiBuyItemButton.Enabled = false;
            }
        }
        
        public void updateProductRestockLevel(string restockLevel)
        {
            uiItemRestockLevelTextBox.Text = restockLevel;
        }

        //Form State Update Methods
        public bool updateViewItemState(viewItemState state)
        {
            if (state == viewItemState.Buy)
            {
                uiBuyItemButton.Show();
                return true;
            } else if (state == viewItemState.Restock)
            {
                uiRestockItemButton.Show();
                return true;
            } else if (state == viewItemState.View)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Form Event Methods
        private void saveBarcode()
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";  
            dialog.Title = "Save QR Code";
            dialog.FileName = String.Format("Barcode_{0}.jpg", uiItemIDValueLabel.Text);

            if ((dialog.ShowDialog() == DialogResult.OK) && (dialog.FileName != ""))
            {
                using (var bitmap = new Bitmap(uiItemBarcodePictureBox.Width, uiItemBarcodePictureBox.Height))
                {
                    uiItemBarcodePictureBox.DrawToBitmap(bitmap, uiItemBarcodePictureBox.ClientRectangle);
                    bitmap.Save(dialog.FileName, ImageFormat.Bmp);
                }
            }
        }

        private void printBarode()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printBarcode_PrintPage);

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            previewDialog.ShowDialog();

            PrintDialog dialog = new PrintDialog();

            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ToString());
            }
        }

        private void printBarcode_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (var bitmap = new Bitmap(uiItemBarcodePictureBox.Width, uiItemBarcodePictureBox.Height))
            {
                uiItemBarcodePictureBox.DrawToBitmap(bitmap, uiItemBarcodePictureBox.ClientRectangle);
                Image img = (Image)bitmap;
                Point loc = new Point(100, 100);
                e.Graphics.DrawImage(img, loc); 
            }
        }

        private void uiBuyItemButton_Click(object sender, EventArgs e)
        {
            buyItem();
        }

        private void uiRestockItemButton_Click(object sender, EventArgs e)
        {
            restockItem();
        }

        private void uiCancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
