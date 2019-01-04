//Project Name: SarreSports | File Name: newItem.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 3/1/2019 | 14:07
//Last Updated On:  4/1/2019 | 02:12
namespace SarreSports
{
    partial class newItem
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
            this.uiNewItemTitle = new System.Windows.Forms.Label();
            this.uiSupplierLabel = new System.Windows.Forms.Label();
            this.uiSupplierNameLabel = new System.Windows.Forms.Label();
            this.uiGeneralItemAttributesGroupBox = new System.Windows.Forms.GroupBox();
            this.uiRestockLevelUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiRestockLevelLabel = new System.Windows.Forms.Label();
            this.uiStockLevelUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiStockLevelLabel = new System.Windows.Forms.Label();
            this.uiItemCostUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiItemCostLabel = new System.Windows.Forms.Label();
            this.uiItemNameTextBox = new System.Windows.Forms.TextBox();
            this.uiItemNameLabel = new System.Windows.Forms.Label();
            this.uiAddItemButton = new System.Windows.Forms.Button();
            this.uiGeneralItemAttributesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiRestockLevelUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiStockLevelUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiItemCostUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // uiNewItemTitle
            // 
            this.uiNewItemTitle.AutoSize = true;
            this.uiNewItemTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiNewItemTitle.Location = new System.Drawing.Point(12, 9);
            this.uiNewItemTitle.Name = "uiNewItemTitle";
            this.uiNewItemTitle.Size = new System.Drawing.Size(278, 67);
            this.uiNewItemTitle.TabIndex = 0;
            this.uiNewItemTitle.Text = "New Item";
            // 
            // uiSupplierLabel
            // 
            this.uiSupplierLabel.AutoSize = true;
            this.uiSupplierLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSupplierLabel.Location = new System.Drawing.Point(17, 86);
            this.uiSupplierLabel.Name = "uiSupplierLabel";
            this.uiSupplierLabel.Size = new System.Drawing.Size(175, 42);
            this.uiSupplierLabel.TabIndex = 1;
            this.uiSupplierLabel.Text = "Supplier: ";
            // 
            // uiSupplierNameLabel
            // 
            this.uiSupplierNameLabel.AutoSize = true;
            this.uiSupplierNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiSupplierNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSupplierNameLabel.Location = new System.Drawing.Point(184, 86);
            this.uiSupplierNameLabel.Name = "uiSupplierNameLabel";
            this.uiSupplierNameLabel.Size = new System.Drawing.Size(213, 42);
            this.uiSupplierNameLabel.TabIndex = 2;
            this.uiSupplierNameLabel.Text = "No Supplier";
            // 
            // uiGeneralItemAttributesGroupBox
            // 
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiRestockLevelUpDown);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiRestockLevelLabel);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiStockLevelUpDown);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiStockLevelLabel);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiItemCostUpDown);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiItemCostLabel);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiItemNameTextBox);
            this.uiGeneralItemAttributesGroupBox.Controls.Add(this.uiItemNameLabel);
            this.uiGeneralItemAttributesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGeneralItemAttributesGroupBox.Location = new System.Drawing.Point(24, 146);
            this.uiGeneralItemAttributesGroupBox.Name = "uiGeneralItemAttributesGroupBox";
            this.uiGeneralItemAttributesGroupBox.Size = new System.Drawing.Size(836, 318);
            this.uiGeneralItemAttributesGroupBox.TabIndex = 3;
            this.uiGeneralItemAttributesGroupBox.TabStop = false;
            this.uiGeneralItemAttributesGroupBox.Text = "General Item Attributes";
            // 
            // uiRestockLevelUpDown
            // 
            this.uiRestockLevelUpDown.Location = new System.Drawing.Point(226, 257);
            this.uiRestockLevelUpDown.Name = "uiRestockLevelUpDown";
            this.uiRestockLevelUpDown.Size = new System.Drawing.Size(586, 44);
            this.uiRestockLevelUpDown.TabIndex = 7;
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
            // uiStockLevelUpDown
            // 
            this.uiStockLevelUpDown.Location = new System.Drawing.Point(226, 191);
            this.uiStockLevelUpDown.Name = "uiStockLevelUpDown";
            this.uiStockLevelUpDown.Size = new System.Drawing.Size(586, 44);
            this.uiStockLevelUpDown.TabIndex = 5;
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
            // uiItemCostUpDown
            // 
            this.uiItemCostUpDown.DecimalPlaces = 2;
            this.uiItemCostUpDown.Location = new System.Drawing.Point(226, 120);
            this.uiItemCostUpDown.Name = "uiItemCostUpDown";
            this.uiItemCostUpDown.Size = new System.Drawing.Size(586, 44);
            this.uiItemCostUpDown.TabIndex = 3;
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
            // uiAddItemButton
            // 
            this.uiAddItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiAddItemButton.Location = new System.Drawing.Point(585, 784);
            this.uiAddItemButton.Name = "uiAddItemButton";
            this.uiAddItemButton.Size = new System.Drawing.Size(275, 59);
            this.uiAddItemButton.TabIndex = 5;
            this.uiAddItemButton.Text = "Add Item";
            this.uiAddItemButton.UseVisualStyleBackColor = true;
            this.uiAddItemButton.Click += new System.EventHandler(this.uiAddItemButton_Click);
            // 
            // newItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 870);
            this.Controls.Add(this.uiAddItemButton);
            this.Controls.Add(this.uiGeneralItemAttributesGroupBox);
            this.Controls.Add(this.uiSupplierNameLabel);
            this.Controls.Add(this.uiSupplierLabel);
            this.Controls.Add(this.uiNewItemTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newItem";
            this.Text = "PoS Systems | New Item";
            this.uiGeneralItemAttributesGroupBox.ResumeLayout(false);
            this.uiGeneralItemAttributesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiRestockLevelUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiStockLevelUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiItemCostUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uiNewItemTitle;
        private System.Windows.Forms.Label uiSupplierLabel;
        private System.Windows.Forms.Label uiSupplierNameLabel;
        private System.Windows.Forms.GroupBox uiGeneralItemAttributesGroupBox;
        private System.Windows.Forms.Label uiItemNameLabel;
        private System.Windows.Forms.TextBox uiItemNameTextBox;
        private System.Windows.Forms.NumericUpDown uiItemCostUpDown;
        private System.Windows.Forms.Label uiItemCostLabel;
        private System.Windows.Forms.NumericUpDown uiRestockLevelUpDown;
        private System.Windows.Forms.Label uiRestockLevelLabel;
        private System.Windows.Forms.NumericUpDown uiStockLevelUpDown;
        private System.Windows.Forms.Label uiStockLevelLabel;
        protected System.Windows.Forms.Button uiAddItemButton;
    }
}