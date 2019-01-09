//Project Name: SarreSports | File Name: newSupplier.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 2/1/2019 | 00:22
//Last Updated On:  2/1/2019 | 00:22
namespace SarreSports
{
    partial class newSupplier
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
            this.uiNewSupplierTitle = new System.Windows.Forms.Label();
            this.uiSupplierNameLabel = new System.Windows.Forms.Label();
            this.uiSupplierNameTextBox = new System.Windows.Forms.TextBox();
            this.uiCreateSupplierButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uiNewSupplierTitle
            // 
            this.uiNewSupplierTitle.AutoSize = true;
            this.uiNewSupplierTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiNewSupplierTitle.Location = new System.Drawing.Point(12, 9);
            this.uiNewSupplierTitle.Name = "uiNewSupplierTitle";
            this.uiNewSupplierTitle.Size = new System.Drawing.Size(381, 67);
            this.uiNewSupplierTitle.TabIndex = 1;
            this.uiNewSupplierTitle.Text = "New Supplier";
            // 
            // uiSupplierNameLabel
            // 
            this.uiSupplierNameLabel.AutoSize = true;
            this.uiSupplierNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSupplierNameLabel.Location = new System.Drawing.Point(17, 120);
            this.uiSupplierNameLabel.Name = "uiSupplierNameLabel";
            this.uiSupplierNameLabel.Size = new System.Drawing.Size(229, 37);
            this.uiSupplierNameLabel.TabIndex = 2;
            this.uiSupplierNameLabel.Text = "Supplier Name";
            // 
            // uiSupplierNameTextBox
            // 
            this.uiSupplierNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSupplierNameTextBox.Location = new System.Drawing.Point(24, 170);
            this.uiSupplierNameTextBox.Name = "uiSupplierNameTextBox";
            this.uiSupplierNameTextBox.Size = new System.Drawing.Size(607, 44);
            this.uiSupplierNameTextBox.TabIndex = 3;
            this.uiSupplierNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiSupplierNameTextBox_KeyDown);
            // 
            // uiCreateSupplierButton
            // 
            this.uiCreateSupplierButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCreateSupplierButton.Location = new System.Drawing.Point(312, 238);
            this.uiCreateSupplierButton.Name = "uiCreateSupplierButton";
            this.uiCreateSupplierButton.Size = new System.Drawing.Size(319, 55);
            this.uiCreateSupplierButton.TabIndex = 4;
            this.uiCreateSupplierButton.Text = "Create Supplier";
            this.uiCreateSupplierButton.UseVisualStyleBackColor = true;
            this.uiCreateSupplierButton.Click += new System.EventHandler(this.uiCreateSupplierButton_Click);
            // 
            // newSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 322);
            this.Controls.Add(this.uiCreateSupplierButton);
            this.Controls.Add(this.uiSupplierNameTextBox);
            this.Controls.Add(this.uiSupplierNameLabel);
            this.Controls.Add(this.uiNewSupplierTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newSupplier";
            this.Text = "PoS System | New Supplier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uiNewSupplierTitle;
        private System.Windows.Forms.Label uiSupplierNameLabel;
        private System.Windows.Forms.TextBox uiSupplierNameTextBox;
        private System.Windows.Forms.Button uiCreateSupplierButton;
    }
}