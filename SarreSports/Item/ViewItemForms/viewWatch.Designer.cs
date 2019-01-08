//Project Name: SarreSports | File Name: viewWatch.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 7/1/2019 | 15:59
//Last Updated On:  7/1/2019 | 15:59
namespace SarreSports
{
    partial class viewWatch
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
            this.uiWatchTypeLabel = new System.Windows.Forms.Label();
            this.uiWatchTypeTextBox = new System.Windows.Forms.TextBox();
            this.uiSpecificItemAttributesGroupBox = new System.Windows.Forms.GroupBox();
            this.uiSpecificItemAttributesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiWatchTypeLabel
            // 
            this.uiWatchTypeLabel.AutoSize = true;
            this.uiWatchTypeLabel.Location = new System.Drawing.Point(5, 61);
            this.uiWatchTypeLabel.Name = "uiWatchTypeLabel";
            this.uiWatchTypeLabel.Size = new System.Drawing.Size(188, 37);
            this.uiWatchTypeLabel.TabIndex = 1;
            this.uiWatchTypeLabel.Text = "Watch Type";
            // 
            // uiWatchTypeTextBox
            // 
            this.uiWatchTypeTextBox.Enabled = false;
            this.uiWatchTypeTextBox.Location = new System.Drawing.Point(225, 58);
            this.uiWatchTypeTextBox.Name = "uiWatchTypeTextBox";
            this.uiWatchTypeTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiWatchTypeTextBox.TabIndex = 0;
            // 
            // uiSpecificItemAttributesGroupBox
            // 
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiWatchTypeLabel);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiWatchTypeTextBox);
            this.uiSpecificItemAttributesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSpecificItemAttributesGroupBox.Location = new System.Drawing.Point(33, 602);
            this.uiSpecificItemAttributesGroupBox.Name = "uiSpecificItemAttributesGroupBox";
            this.uiSpecificItemAttributesGroupBox.Size = new System.Drawing.Size(837, 126);
            this.uiSpecificItemAttributesGroupBox.TabIndex = 14;
            this.uiSpecificItemAttributesGroupBox.TabStop = false;
            this.uiSpecificItemAttributesGroupBox.Text = "Specific Item Attributes";
            // 
            // viewWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 860);
            this.Controls.Add(this.uiSpecificItemAttributesGroupBox);
            this.Name = "viewWatch";
            this.Text = "PoS System | View Watch";
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

        private System.Windows.Forms.Label uiWatchTypeLabel;
        private System.Windows.Forms.TextBox uiWatchTypeTextBox;
        private System.Windows.Forms.GroupBox uiSpecificItemAttributesGroupBox;
    }
}