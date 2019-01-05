//Project Name: SarreSports | File Name: newBag.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/1/2019 | 15:12
//Last Updated On:  5/1/2019 | 00:54
namespace SarreSports
{
    partial class newBag
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
            this.components = new System.ComponentModel.Container();
            this.uiSpecificItemAttributesGroupBox = new System.Windows.Forms.GroupBox();
            this.uiBagCapacityUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiBagCapacityLabel = new System.Windows.Forms.Label();
            this.uiSpecificItemAttributesErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiSpecificItemAttributesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiBagCapacityUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpecificItemAttributesErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // uiAddItemButton
            // 
            this.uiAddItemButton.Location = new System.Drawing.Point(585, 630);
            // 
            // uiSpecificItemAttributesGroupBox
            // 
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiBagCapacityUpDown);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiBagCapacityLabel);
            this.uiSpecificItemAttributesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSpecificItemAttributesGroupBox.Location = new System.Drawing.Point(24, 492);
            this.uiSpecificItemAttributesGroupBox.Name = "uiSpecificItemAttributesGroupBox";
            this.uiSpecificItemAttributesGroupBox.Size = new System.Drawing.Size(888, 120);
            this.uiSpecificItemAttributesGroupBox.TabIndex = 4;
            this.uiSpecificItemAttributesGroupBox.TabStop = false;
            this.uiSpecificItemAttributesGroupBox.Text = "Specific Item Attributes";
            // 
            // uiBagCapacityUpDown
            // 
            this.uiBagCapacityUpDown.Location = new System.Drawing.Point(226, 52);
            this.uiBagCapacityUpDown.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.uiBagCapacityUpDown.Name = "uiBagCapacityUpDown";
            this.uiBagCapacityUpDown.Size = new System.Drawing.Size(586, 44);
            this.uiBagCapacityUpDown.TabIndex = 3;
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
            // uiSpecificItemAttributesErrorProvider
            // 
            this.uiSpecificItemAttributesErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.uiSpecificItemAttributesErrorProvider.ContainerControl = this;
            // 
            // newBag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 710);
            this.Controls.Add(this.uiSpecificItemAttributesGroupBox);
            this.Name = "newBag";
            this.Text = "PoS System | New Bag";
            this.Controls.SetChildIndex(this.uiAddItemButton, 0);
            this.Controls.SetChildIndex(this.uiSpecificItemAttributesGroupBox, 0);
            this.uiSpecificItemAttributesGroupBox.ResumeLayout(false);
            this.uiSpecificItemAttributesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiBagCapacityUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpecificItemAttributesErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox uiSpecificItemAttributesGroupBox;
        private System.Windows.Forms.Label uiBagCapacityLabel;
        private System.Windows.Forms.NumericUpDown uiBagCapacityUpDown;
        private System.Windows.Forms.ErrorProvider uiSpecificItemAttributesErrorProvider;
    }
}