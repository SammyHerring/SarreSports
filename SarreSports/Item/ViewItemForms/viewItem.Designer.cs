//Project Name: SarreSports | File Name: viewItem.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 5/1/2019 | 21:56
//Last Updated On:  6/1/2019 | 12:51
namespace SarreSports
{
    partial class viewItem
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
            this.uiItemNameTitle = new System.Windows.Forms.Label();
            this.uiSupplierNameLabel = new System.Windows.Forms.Label();
            this.uiSupplierLabel = new System.Windows.Forms.Label();
            this.uiGeneralItemAttributesGroupBox = new System.Windows.Forms.GroupBox();
            this.uiItemRestockLevelTextBox = new System.Windows.Forms.TextBox();
            this.uiItemStockLevelTextBox = new System.Windows.Forms.TextBox();
            this.uiItemCostTextBox = new System.Windows.Forms.TextBox();
            this.uiRestockLevelLabel = new System.Windows.Forms.Label();
            this.uiStockLevelLabel = new System.Windows.Forms.Label();
            this.uiItemCostLabel = new System.Windows.Forms.Label();
            this.uiItemNameTextBox = new System.Windows.Forms.TextBox();
            this.uiItemNameLabel = new System.Windows.Forms.Label();
            this.uiItemBarcodePictureBox = new System.Windows.Forms.PictureBox();
            this.uiAvaliableForSaleLabel = new System.Windows.Forms.Label();
            this.uiAvaliableForSaleValueLabel = new System.Windows.Forms.Label();
            this.uiItemIDLabel = new System.Windows.Forms.Label();
            this.uiSaveBarcodeButton = new System.Windows.Forms.Button();
            this.uiPrintBarcodeButton = new System.Windows.Forms.Button();
            this.uiItemIDValueLabel = new System.Windows.Forms.Label();
            this.uiBuyItemButton = new System.Windows.Forms.Button();
            this.uiRestockItemButton = new System.Windows.Forms.Button();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiGeneralItemAttributesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiItemBarcodePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uiItemNameTitle
            // 
            this.uiItemNameTitle.AutoSize = true;
            this.uiItemNameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiItemNameTitle.Location = new System.Drawing.Point(12, 9);
            this.uiItemNameTitle.Name = "uiItemNameTitle";
            this.uiItemNameTitle.Size = new System.Drawing.Size(317, 67);
            this.uiItemNameTitle.TabIndex = 0;
            this.uiItemNameTitle.Text = "Item Name";
            // 
            // uiSupplierNameLabel
            // 
            this.uiSupplierNameLabel.AutoSize = true;
            this.uiSupplierNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiSupplierNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSupplierNameLabel.Location = new System.Drawing.Point(255, 76);
            this.uiSupplierNameLabel.Name = "uiSupplierNameLabel";
            this.uiSupplierNameLabel.Size = new System.Drawing.Size(213, 42);
            this.uiSupplierNameLabel.TabIndex = 2;
            this.uiSupplierNameLabel.Text = "No Supplier";
            // 
            // uiSupplierLabel
            // 
            this.uiSupplierLabel.AutoSize = true;
            this.uiSupplierLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSupplierLabel.Location = new System.Drawing.Point(25, 76);
            this.uiSupplierLabel.Name = "uiSupplierLabel";
            this.uiSupplierLabel.Size = new System.Drawing.Size(224, 42);
            this.uiSupplierLabel.TabIndex = 1;
            this.uiSupplierLabel.Text = "Supplied by:";
            // 
            // uiGeneralItemAttributesGroupBox
            // 
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiItemRestockLevelTextBox);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiItemStockLevelTextBox);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiItemCostTextBox);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiRestockLevelLabel);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiStockLevelLabel);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiItemCostLabel);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiItemNameTextBox);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiItemNameLabel);
            this.uiGeneralItemAttributesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGeneralItemAttributesGroupBox.Location = new System.Drawing.Point(31, 268);
            this.uiGeneralItemAttributesGroupBox.Name = "uiGeneralItemAttributesGroupBox";
            this.uiGeneralItemAttributesGroupBox.Size = new System.Drawing.Size(838, 318);
            this.uiGeneralItemAttributesGroupBox.TabIndex = 9;
            this.uiGeneralItemAttributesGroupBox.TabStop = false;
            this.uiGeneralItemAttributesGroupBox.Text = "General Item Attributes";
            // 
            // uiItemRestockLevelTextBox
            // 
            this.uiItemRestockLevelTextBox.Enabled = false;
            this.uiItemRestockLevelTextBox.Location = new System.Drawing.Point(226, 254);
            this.uiItemRestockLevelTextBox.Name = "uiItemRestockLevelTextBox";
            this.uiItemRestockLevelTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiItemRestockLevelTextBox.TabIndex = 7;
            // 
            // uiItemStockLevelTextBox
            // 
            this.uiItemStockLevelTextBox.Enabled = false;
            this.uiItemStockLevelTextBox.Location = new System.Drawing.Point(226, 188);
            this.uiItemStockLevelTextBox.Name = "uiItemStockLevelTextBox";
            this.uiItemStockLevelTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiItemStockLevelTextBox.TabIndex = 5;
            // 
            // uiItemCostTextBox
            // 
            this.uiItemCostTextBox.Enabled = false;
            this.uiItemCostTextBox.Location = new System.Drawing.Point(226, 117);
            this.uiItemCostTextBox.Name = "uiItemCostTextBox";
            this.uiItemCostTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiItemCostTextBox.TabIndex = 3;
            // 
            // uiRestockLevelLabel
            // 
            this.uiRestockLevelLabel.AutoSize = true;
            this.uiRestockLevelLabel.Location = new System.Drawing.Point(6, 257);
            this.uiRestockLevelLabel.Name = "uiRestockLevelLabel";
            this.uiRestockLevelLabel.Size = new System.Drawing.Size(214, 37);
            this.uiRestockLevelLabel.TabIndex = 6;
            this.uiRestockLevelLabel.Text = "Restock Level";
            // 
            // uiStockLevelLabel
            // 
            this.uiStockLevelLabel.AutoSize = true;
            this.uiStockLevelLabel.Location = new System.Drawing.Point(6, 191);
            this.uiStockLevelLabel.Name = "uiStockLevelLabel";
            this.uiStockLevelLabel.Size = new System.Drawing.Size(180, 37);
            this.uiStockLevelLabel.TabIndex = 4;
            this.uiStockLevelLabel.Text = "Stock Level";
            // 
            // uiItemCostLabel
            // 
            this.uiItemCostLabel.AutoSize = true;
            this.uiItemCostLabel.Location = new System.Drawing.Point(6, 120);
            this.uiItemCostLabel.Name = "uiItemCostLabel";
            this.uiItemCostLabel.Size = new System.Drawing.Size(153, 37);
            this.uiItemCostLabel.TabIndex = 2;
            this.uiItemCostLabel.Text = "Item Cost";
            // 
            // uiItemNameTextBox
            // 
            this.uiItemNameTextBox.Enabled = false;
            this.uiItemNameTextBox.Location = new System.Drawing.Point(226, 53);
            this.uiItemNameTextBox.Name = "uiItemNameTextBox";
            this.uiItemNameTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiItemNameTextBox.TabIndex = 1;
            // 
            // uiItemNameLabel
            // 
            this.uiItemNameLabel.AutoSize = true;
            this.uiItemNameLabel.Location = new System.Drawing.Point(6, 54);
            this.uiItemNameLabel.Name = "uiItemNameLabel";
            this.uiItemNameLabel.Size = new System.Drawing.Size(173, 37);
            this.uiItemNameLabel.TabIndex = 0;
            this.uiItemNameLabel.Text = "Item Name";
            // 
            // uiItemBarcodePictureBox
            // 
            this.uiItemBarcodePictureBox.Location = new System.Drawing.Point(341, 130);
            this.uiItemBarcodePictureBox.Name = "uiItemBarcodePictureBox";
            this.uiItemBarcodePictureBox.Size = new System.Drawing.Size(254, 110);
            this.uiItemBarcodePictureBox.TabIndex = 6;
            this.uiItemBarcodePictureBox.TabStop = false;
            // 
            // uiAvaliableForSaleLabel
            // 
            this.uiAvaliableForSaleLabel.AutoSize = true;
            this.uiAvaliableForSaleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiAvaliableForSaleLabel.Location = new System.Drawing.Point(555, 34);
            this.uiAvaliableForSaleLabel.Name = "uiAvaliableForSaleLabel";
            this.uiAvaliableForSaleLabel.Size = new System.Drawing.Size(274, 37);
            this.uiAvaliableForSaleLabel.TabIndex = 7;
            this.uiAvaliableForSaleLabel.Text = "Avaliable for Sale:";
            // 
            // uiAvaliableForSaleValueLabel
            // 
            this.uiAvaliableForSaleValueLabel.AutoSize = true;
            this.uiAvaliableForSaleValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiAvaliableForSaleValueLabel.Location = new System.Drawing.Point(835, 34);
            this.uiAvaliableForSaleValueLabel.Name = "uiAvaliableForSaleValueLabel";
            this.uiAvaliableForSaleValueLabel.Size = new System.Drawing.Size(27, 37);
            this.uiAvaliableForSaleValueLabel.TabIndex = 8;
            this.uiAvaliableForSaleValueLabel.Text = "-";
            // 
            // uiItemIDLabel
            // 
            this.uiItemIDLabel.AutoSize = true;
            this.uiItemIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiItemIDLabel.Location = new System.Drawing.Point(25, 138);
            this.uiItemIDLabel.Name = "uiItemIDLabel";
            this.uiItemIDLabel.Size = new System.Drawing.Size(135, 37);
            this.uiItemIDLabel.TabIndex = 3;
            this.uiItemIDLabel.Text = "Item ID:";
            // 
            // uiSaveBarcodeButton
            // 
            this.uiSaveBarcodeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSaveBarcodeButton.Location = new System.Drawing.Point(601, 130);
            this.uiSaveBarcodeButton.Name = "uiSaveBarcodeButton";
            this.uiSaveBarcodeButton.Size = new System.Drawing.Size(269, 52);
            this.uiSaveBarcodeButton.TabIndex = 5;
            this.uiSaveBarcodeButton.Text = "Save Barcode";
            this.uiSaveBarcodeButton.UseVisualStyleBackColor = true;
            this.uiSaveBarcodeButton.Click += new System.EventHandler(this.uiSaveBarcodeButton_Click);
            // 
            // uiPrintBarcodeButton
            // 
            this.uiPrintBarcodeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPrintBarcodeButton.Location = new System.Drawing.Point(601, 188);
            this.uiPrintBarcodeButton.Name = "uiPrintBarcodeButton";
            this.uiPrintBarcodeButton.Size = new System.Drawing.Size(269, 52);
            this.uiPrintBarcodeButton.TabIndex = 6;
            this.uiPrintBarcodeButton.Text = "Print Barcode";
            this.uiPrintBarcodeButton.UseVisualStyleBackColor = true;
            this.uiPrintBarcodeButton.Click += new System.EventHandler(this.uiPrintBarcodeButton_Click);
            // 
            // uiItemIDValueLabel
            // 
            this.uiItemIDValueLabel.AutoSize = true;
            this.uiItemIDValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiItemIDValueLabel.Location = new System.Drawing.Point(166, 138);
            this.uiItemIDValueLabel.Name = "uiItemIDValueLabel";
            this.uiItemIDValueLabel.Size = new System.Drawing.Size(87, 37);
            this.uiItemIDValueLabel.TabIndex = 4;
            this.uiItemIDValueLabel.Text = "0001";
            // 
            // uiBuyItemButton
            // 
            this.uiBuyItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiBuyItemButton.Location = new System.Drawing.Point(624, 784);
            this.uiBuyItemButton.Name = "uiBuyItemButton";
            this.uiBuyItemButton.Size = new System.Drawing.Size(244, 59);
            this.uiBuyItemButton.TabIndex = 10;
            this.uiBuyItemButton.Text = "Buy Item";
            this.uiBuyItemButton.UseVisualStyleBackColor = true;
            this.uiBuyItemButton.Click += new System.EventHandler(this.uiBuyItemButton_Click);
            // 
            // uiRestockItemButton
            // 
            this.uiRestockItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiRestockItemButton.Location = new System.Drawing.Point(32, 784);
            this.uiRestockItemButton.Name = "uiRestockItemButton";
            this.uiRestockItemButton.Size = new System.Drawing.Size(244, 59);
            this.uiRestockItemButton.TabIndex = 11;
            this.uiRestockItemButton.Text = "Restock Item";
            this.uiRestockItemButton.UseVisualStyleBackColor = true;
            this.uiRestockItemButton.Click += new System.EventHandler(this.uiRestockItemButton_Click);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCancelButton.Location = new System.Drawing.Point(328, 784);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(244, 59);
            this.uiCancelButton.TabIndex = 12;
            this.uiCancelButton.Text = "Cancel";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            this.uiCancelButton.Click += new System.EventHandler(this.uiCancelButton_Click);
            // 
            // viewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 870);
            this.Controls.Add(this.uiCancelButton);
            this.Controls.Add(this.uiRestockItemButton);
            this.Controls.Add(this.uiBuyItemButton);
            this.Controls.Add(this.uiItemIDValueLabel);
            this.Controls.Add(this.uiPrintBarcodeButton);
            this.Controls.Add(this.uiSaveBarcodeButton);
            this.Controls.Add(this.uiItemIDLabel);
            this.Controls.Add(this.uiAvaliableForSaleValueLabel);
            this.Controls.Add(this.uiAvaliableForSaleLabel);
            this.Controls.Add(this.uiItemBarcodePictureBox);
            this.Controls.Add(this.uiGeneralItemAttributesGroupBox);
            this.Controls.Add(this.uiSupplierNameLabel);
            this.Controls.Add(this.uiSupplierLabel);
            this.Controls.Add(this.uiItemNameTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "viewItem";
            this.Text = "PoS System | View Item";
            this.uiGeneralItemAttributesGroupBox.ResumeLayout(false);
            this.uiGeneralItemAttributesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiItemBarcodePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uiItemNameTitle;
        private System.Windows.Forms.Label uiSupplierNameLabel;
        private System.Windows.Forms.Label uiSupplierLabel;
        private System.Windows.Forms.GroupBox uiGeneralItemAttributesGroupBox;
        private System.Windows.Forms.TextBox uiItemRestockLevelTextBox;
        private System.Windows.Forms.TextBox uiItemStockLevelTextBox;
        private System.Windows.Forms.TextBox uiItemCostTextBox;
        private System.Windows.Forms.Label uiRestockLevelLabel;
        private System.Windows.Forms.Label uiStockLevelLabel;
        private System.Windows.Forms.Label uiItemCostLabel;
        private System.Windows.Forms.TextBox uiItemNameTextBox;
        private System.Windows.Forms.Label uiItemNameLabel;
        private System.Windows.Forms.PictureBox uiItemBarcodePictureBox;
        private System.Windows.Forms.Label uiAvaliableForSaleLabel;
        private System.Windows.Forms.Label uiAvaliableForSaleValueLabel;
        private System.Windows.Forms.Label uiItemIDLabel;
        private System.Windows.Forms.Button uiSaveBarcodeButton;
        private System.Windows.Forms.Button uiPrintBarcodeButton;
        private System.Windows.Forms.Label uiItemIDValueLabel;
        protected System.Windows.Forms.Button uiBuyItemButton;
        protected System.Windows.Forms.Button uiRestockItemButton;
        protected System.Windows.Forms.Button uiCancelButton;
    }
}