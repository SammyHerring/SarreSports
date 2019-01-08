//Project Name: SarreSports | File Name: viewClothing.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 7/1/2019 | 14:54
//Last Updated On:  7/1/2019 | 14:54
namespace SarreSports
{
    partial class viewClothing
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
            this.uiSpecificItemAttributesGroupBox = new System.Windows.Forms.GroupBox();
            this.uiClothingSizeTextBox = new System.Windows.Forms.TextBox();
            this.uiClothingSizeLabel = new System.Windows.Forms.Label();
            this.uiClothingColourLabel = new System.Windows.Forms.Label();
            this.uiClothingColourTextBox = new System.Windows.Forms.TextBox();
            this.uiClothingTypeLabel = new System.Windows.Forms.Label();
            this.uiClothingTypeTextBox = new System.Windows.Forms.TextBox();
            this.uiSpecificItemAttributesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiBuyItemButton
            // 
            this.uiBuyItemButton.Location = new System.Drawing.Point(626, 890);
            this.uiBuyItemButton.TabIndex = 11;
            // 
            // uiRestockItemButton
            // 
            this.uiRestockItemButton.Location = new System.Drawing.Point(34, 890);
            this.uiRestockItemButton.TabIndex = 12;
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Location = new System.Drawing.Point(330, 890);
            this.uiCancelButton.TabIndex = 13;
            // 
            // uiSpecificItemAttributesGroupBox
            // 
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiClothingTypeLabel);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiClothingTypeTextBox);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiClothingColourLabel);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiClothingColourTextBox);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiClothingSizeLabel);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiClothingSizeTextBox);
            this.uiSpecificItemAttributesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSpecificItemAttributesGroupBox.Location = new System.Drawing.Point(31, 602);
            this.uiSpecificItemAttributesGroupBox.Name = "uiSpecificItemAttributesGroupBox";
            this.uiSpecificItemAttributesGroupBox.Size = new System.Drawing.Size(839, 268);
            this.uiSpecificItemAttributesGroupBox.TabIndex = 10;
            this.uiSpecificItemAttributesGroupBox.TabStop = false;
            this.uiSpecificItemAttributesGroupBox.Text = "Specific Item Attributes";
            // 
            // uiClothingSizeTextBox
            // 
            this.uiClothingSizeTextBox.Enabled = false;
            this.uiClothingSizeTextBox.Location = new System.Drawing.Point(226, 58);
            this.uiClothingSizeTextBox.Name = "uiClothingSizeTextBox";
            this.uiClothingSizeTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiClothingSizeTextBox.TabIndex = 1;
            // 
            // uiClothingSizeLabel
            // 
            this.uiClothingSizeLabel.AutoSize = true;
            this.uiClothingSizeLabel.Location = new System.Drawing.Point(6, 61);
            this.uiClothingSizeLabel.Name = "uiClothingSizeLabel";
            this.uiClothingSizeLabel.Size = new System.Drawing.Size(205, 37);
            this.uiClothingSizeLabel.TabIndex = 0;
            this.uiClothingSizeLabel.Text = "Clothing Size";
            // 
            // uiClothingColourLabel
            // 
            this.uiClothingColourLabel.AutoSize = true;
            this.uiClothingColourLabel.Location = new System.Drawing.Point(6, 129);
            this.uiClothingColourLabel.Name = "uiClothingColourLabel";
            this.uiClothingColourLabel.Size = new System.Drawing.Size(112, 37);
            this.uiClothingColourLabel.TabIndex = 2;
            this.uiClothingColourLabel.Text = "Colour";
            // 
            // uiClothingColourTextBox
            // 
            this.uiClothingColourTextBox.Enabled = false;
            this.uiClothingColourTextBox.Location = new System.Drawing.Point(226, 126);
            this.uiClothingColourTextBox.Name = "uiClothingColourTextBox";
            this.uiClothingColourTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiClothingColourTextBox.TabIndex = 3;
            // 
            // uiClothingTypeLabel
            // 
            this.uiClothingTypeLabel.AutoSize = true;
            this.uiClothingTypeLabel.Location = new System.Drawing.Point(6, 203);
            this.uiClothingTypeLabel.Name = "uiClothingTypeLabel";
            this.uiClothingTypeLabel.Size = new System.Drawing.Size(214, 37);
            this.uiClothingTypeLabel.TabIndex = 4;
            this.uiClothingTypeLabel.Text = "Clothing Type";
            // 
            // uiClothingTypeTextBox
            // 
            this.uiClothingTypeTextBox.Enabled = false;
            this.uiClothingTypeTextBox.Location = new System.Drawing.Point(226, 200);
            this.uiClothingTypeTextBox.Name = "uiClothingTypeTextBox";
            this.uiClothingTypeTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiClothingTypeTextBox.TabIndex = 5;
            // 
            // viewClothing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 980);
            this.Controls.Add(this.uiSpecificItemAttributesGroupBox);
            this.Name = "viewClothing";
            this.Text = "PoS System | View Clothing";
            this.Controls.SetChildIndex(this.uiBuyItemButton, 0);
            this.Controls.SetChildIndex(this.uiRestockItemButton, 0);
            this.Controls.SetChildIndex(this.uiCancelButton, 0);
            this.Controls.SetChildIndex(this.uiSpecificItemAttributesGroupBox, 0);
            this.uiSpecificItemAttributesGroupBox.ResumeLayout(false);
            this.uiSpecificItemAttributesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox uiSpecificItemAttributesGroupBox;
        private System.Windows.Forms.Label uiClothingTypeLabel;
        private System.Windows.Forms.TextBox uiClothingTypeTextBox;
        private System.Windows.Forms.Label uiClothingColourLabel;
        private System.Windows.Forms.TextBox uiClothingColourTextBox;
        private System.Windows.Forms.Label uiClothingSizeLabel;
        private System.Windows.Forms.TextBox uiClothingSizeTextBox;
    }
}