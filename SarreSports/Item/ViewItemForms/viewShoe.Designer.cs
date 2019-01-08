//Project Name: SarreSports | File Name: viewShoe.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 7/1/2019 | 15:44
//Last Updated On:  7/1/2019 | 15:57
namespace SarreSports
{
    partial class viewShoe
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiShoeSizeTextBox = new System.Windows.Forms.TextBox();
            this.uiShoeTypeTextBox = new System.Windows.Forms.TextBox();
            this.uiShoeSizeLabel = new System.Windows.Forms.Label();
            this.uiShoeTypeLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiBuyItemButton
            // 
            this.uiBuyItemButton.Location = new System.Drawing.Point(626, 834);
            // 
            // uiRestockItemButton
            // 
            this.uiRestockItemButton.Location = new System.Drawing.Point(34, 834);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Location = new System.Drawing.Point(330, 834);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiShoeTypeLabel);
            this.groupBox1.Controls.Add(this.uiShoeSizeLabel);
            this.groupBox1.Controls.Add(this.uiShoeTypeTextBox);
            this.groupBox1.Controls.Add(this.uiShoeSizeTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(31, 616);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(838, 194);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Specific Item Attributes";
            // 
            // uiShoeSizeTextBox
            // 
            this.uiShoeSizeTextBox.Enabled = false;
            this.uiShoeSizeTextBox.Location = new System.Drawing.Point(226, 60);
            this.uiShoeSizeTextBox.Name = "uiShoeSizeTextBox";
            this.uiShoeSizeTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiShoeSizeTextBox.TabIndex = 0;
            // 
            // uiShoeTypeTextBox
            // 
            this.uiShoeTypeTextBox.Enabled = false;
            this.uiShoeTypeTextBox.Location = new System.Drawing.Point(226, 128);
            this.uiShoeTypeTextBox.Name = "uiShoeTypeTextBox";
            this.uiShoeTypeTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiShoeTypeTextBox.TabIndex = 1;
            // 
            // uiShoeSizeLabel
            // 
            this.uiShoeSizeLabel.AutoSize = true;
            this.uiShoeSizeLabel.Location = new System.Drawing.Point(6, 63);
            this.uiShoeSizeLabel.Name = "uiShoeSizeLabel";
            this.uiShoeSizeLabel.Size = new System.Drawing.Size(161, 37);
            this.uiShoeSizeLabel.TabIndex = 2;
            this.uiShoeSizeLabel.Text = "Shoe Size";
            // 
            // uiShoeTypeLabel
            // 
            this.uiShoeTypeLabel.AutoSize = true;
            this.uiShoeTypeLabel.Location = new System.Drawing.Point(6, 131);
            this.uiShoeTypeLabel.Name = "uiShoeTypeLabel";
            this.uiShoeTypeLabel.Size = new System.Drawing.Size(170, 37);
            this.uiShoeTypeLabel.TabIndex = 3;
            this.uiShoeTypeLabel.Text = "Shoe Type";
            // 
            // viewShoe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 932);
            this.Controls.Add(this.groupBox1);
            this.Name = "viewShoe";
            this.Text = "PoS System | View Shoe";
            this.Controls.SetChildIndex(this.uiBuyItemButton, 0);
            this.Controls.SetChildIndex(this.uiRestockItemButton, 0);
            this.Controls.SetChildIndex(this.uiCancelButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label uiShoeTypeLabel;
        private System.Windows.Forms.Label uiShoeSizeLabel;
        private System.Windows.Forms.TextBox uiShoeTypeTextBox;
        private System.Windows.Forms.TextBox uiShoeSizeTextBox;
    }
}