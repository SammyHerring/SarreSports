//Project Name: SarreSports | File Name: itemSelector.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/1/2019 | 02:21
//Last Updated On:  4/1/2019 | 02:40
namespace SarreSports
{
    partial class itemSelector
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
            this.uiItemTypeComboBox = new System.Windows.Forms.ComboBox();
            this.uiCreateItem = new System.Windows.Forms.Button();
            this.uiItemTypeLabel = new System.Windows.Forms.Label();
            this.uiAccessoryTypeLabel = new System.Windows.Forms.Label();
            this.uiAccessoryTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // uiNewItemTitle
            // 
            this.uiNewItemTitle.AutoSize = true;
            this.uiNewItemTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiNewItemTitle.Location = new System.Drawing.Point(12, 9);
            this.uiNewItemTitle.Name = "uiNewItemTitle";
            this.uiNewItemTitle.Size = new System.Drawing.Size(376, 67);
            this.uiNewItemTitle.TabIndex = 1;
            this.uiNewItemTitle.Text = "Item Selector";
            // 
            // uiItemTypeComboBox
            // 
            this.uiItemTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiItemTypeComboBox.FormattingEnabled = true;
            this.uiItemTypeComboBox.Location = new System.Drawing.Point(31, 148);
            this.uiItemTypeComboBox.Name = "uiItemTypeComboBox";
            this.uiItemTypeComboBox.Size = new System.Drawing.Size(673, 45);
            this.uiItemTypeComboBox.TabIndex = 2;
            this.uiItemTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.uiItemTypeComboBox_SelectionChangeCommitted);
            this.uiItemTypeComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiItemTypeComboBox_KeyDown);
            // 
            // uiCreateItem
            // 
            this.uiCreateItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCreateItem.Location = new System.Drawing.Point(453, 360);
            this.uiCreateItem.Name = "uiCreateItem";
            this.uiCreateItem.Size = new System.Drawing.Size(251, 67);
            this.uiCreateItem.TabIndex = 3;
            this.uiCreateItem.Text = "Create Item";
            this.uiCreateItem.UseVisualStyleBackColor = true;
            this.uiCreateItem.Click += new System.EventHandler(this.uiCreateItem_Click);
            // 
            // uiItemTypeLabel
            // 
            this.uiItemTypeLabel.AutoSize = true;
            this.uiItemTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiItemTypeLabel.Location = new System.Drawing.Point(24, 94);
            this.uiItemTypeLabel.Name = "uiItemTypeLabel";
            this.uiItemTypeLabel.Size = new System.Drawing.Size(157, 37);
            this.uiItemTypeLabel.TabIndex = 4;
            this.uiItemTypeLabel.Text = "Item Type";
            // 
            // uiAccessoryTypeLabel
            // 
            this.uiAccessoryTypeLabel.AutoSize = true;
            this.uiAccessoryTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiAccessoryTypeLabel.Location = new System.Drawing.Point(24, 218);
            this.uiAccessoryTypeLabel.Name = "uiAccessoryTypeLabel";
            this.uiAccessoryTypeLabel.Size = new System.Drawing.Size(243, 37);
            this.uiAccessoryTypeLabel.TabIndex = 6;
            this.uiAccessoryTypeLabel.Text = "Accessory Type";
            // 
            // uiAccessoryTypeComboBox
            // 
            this.uiAccessoryTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiAccessoryTypeComboBox.FormattingEnabled = true;
            this.uiAccessoryTypeComboBox.Location = new System.Drawing.Point(31, 272);
            this.uiAccessoryTypeComboBox.Name = "uiAccessoryTypeComboBox";
            this.uiAccessoryTypeComboBox.Size = new System.Drawing.Size(673, 45);
            this.uiAccessoryTypeComboBox.TabIndex = 5;
            this.uiAccessoryTypeComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiAccessoryTypeComboBox_KeyDown);
            // 
            // itemSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 462);
            this.Controls.Add(this.uiAccessoryTypeLabel);
            this.Controls.Add(this.uiAccessoryTypeComboBox);
            this.Controls.Add(this.uiItemTypeLabel);
            this.Controls.Add(this.uiCreateItem);
            this.Controls.Add(this.uiItemTypeComboBox);
            this.Controls.Add(this.uiNewItemTitle);
            this.Name = "itemSelector";
            this.Text = "PoS System | Item Selector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.itemSelector_FormClosing);
            this.Load += new System.EventHandler(this.itemSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uiNewItemTitle;
        private System.Windows.Forms.ComboBox uiItemTypeComboBox;
        private System.Windows.Forms.Button uiCreateItem;
        private System.Windows.Forms.Label uiItemTypeLabel;
        private System.Windows.Forms.Label uiAccessoryTypeLabel;
        private System.Windows.Forms.ComboBox uiAccessoryTypeComboBox;
    }
}