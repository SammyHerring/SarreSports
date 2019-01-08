//Project Name: SarreSports | File Name: viewBag.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 6/1/2019 | 12:51
//Last Updated On:  6/1/2019 | 18:59
namespace SarreSports
{
    partial class viewBag
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
            this.uiBagCapacityLabel = new System.Windows.Forms.Label();
            this.uiBagCapacityTextBox = new System.Windows.Forms.TextBox();
            this.uiSpecificItemAttributesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiBuyItemButton
            // 
            this.uiBuyItemButton.Location = new System.Drawing.Point(626, 726);
            // 
            // uiRestockItemButton
            // 
            this.uiRestockItemButton.Location = new System.Drawing.Point(32, 726);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Location = new System.Drawing.Point(326, 726);
            // 
            // uiSpecificItemAttributesGroupBox
            // 
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiBagCapacityTextBox);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiBagCapacityLabel);
            this.uiSpecificItemAttributesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSpecificItemAttributesGroupBox.Location = new System.Drawing.Point(32, 586);
            this.uiSpecificItemAttributesGroupBox.Name = "uiSpecificItemAttributesGroupBox";
            this.uiSpecificItemAttributesGroupBox.Size = new System.Drawing.Size(838, 120);
            this.uiSpecificItemAttributesGroupBox.TabIndex = 15;
            this.uiSpecificItemAttributesGroupBox.TabStop = false;
            this.uiSpecificItemAttributesGroupBox.Text = "Specific Item Attributes";
            // 
            // uiBagCapacityLabel
            // 
            this.uiBagCapacityLabel.AutoSize = true;
            this.uiBagCapacityLabel.Location = new System.Drawing.Point(6, 54);
            this.uiBagCapacityLabel.Name = "uiBagCapacityLabel";
            this.uiBagCapacityLabel.Size = new System.Drawing.Size(207, 37);
            this.uiBagCapacityLabel.TabIndex = 0;
            this.uiBagCapacityLabel.Text = "Bag Capacity";
            // 
            // uiBagCapacityTextBox
            // 
            this.uiBagCapacityTextBox.Enabled = false;
            this.uiBagCapacityTextBox.Location = new System.Drawing.Point(225, 51);
            this.uiBagCapacityTextBox.Name = "uiBagCapacityTextBox";
            this.uiBagCapacityTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiBagCapacityTextBox.TabIndex = 1;
            // 
            // viewBag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 810);
            this.Controls.Add(this.uiSpecificItemAttributesGroupBox);
            this.Name = "viewBag";
            this.Text = "PoS System | View Bag";
            this.Controls.SetChildIndex(this.uiCancelButton, 0);
            this.Controls.SetChildIndex(this.uiBuyItemButton, 0);
            this.Controls.SetChildIndex(this.uiRestockItemButton, 0);
            this.Controls.SetChildIndex(this.uiSpecificItemAttributesGroupBox, 0);
            this.uiSpecificItemAttributesGroupBox.ResumeLayout(false);
            this.uiSpecificItemAttributesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox uiSpecificItemAttributesGroupBox;
        private System.Windows.Forms.Label uiBagCapacityLabel;
        private System.Windows.Forms.TextBox uiBagCapacityTextBox;
    }
}