//Project Name: SarreSports | File Name: newShoe.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 5/1/2019 | 01:02
//Last Updated On:  5/1/2019 | 01:02
namespace SarreSports
{
    partial class newShoe
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
            this.uiSpecificItemAttributesErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiSpecificItemAttributesGroupBox = new System.Windows.Forms.GroupBox();
            this.uiShoeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.uiShoeTypeLabel = new System.Windows.Forms.Label();
            this.uiShoeSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiShoeSizeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpecificItemAttributesErrorProvider)).BeginInit();
            this.uiSpecificItemAttributesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiShoeSizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // uiAddItemButton
            // 
            this.uiAddItemButton.Location = new System.Drawing.Point(637, 694);
            // 
            // uiSpecificItemAttributesErrorProvider
            // 
            this.uiSpecificItemAttributesErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.uiSpecificItemAttributesErrorProvider.ContainerControl = this;
            // 
            // uiSpecificItemAttributesGroupBox
            // 
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiShoeTypeComboBox);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiShoeTypeLabel);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiShoeSizeUpDown);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiShoeSizeLabel);
            this.uiSpecificItemAttributesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSpecificItemAttributesGroupBox.Location = new System.Drawing.Point(24, 490);
            this.uiSpecificItemAttributesGroupBox.Name = "uiSpecificItemAttributesGroupBox";
            this.uiSpecificItemAttributesGroupBox.Size = new System.Drawing.Size(888, 178);
            this.uiSpecificItemAttributesGroupBox.TabIndex = 6;
            this.uiSpecificItemAttributesGroupBox.TabStop = false;
            this.uiSpecificItemAttributesGroupBox.Text = "Specific Item Attributes";
            // 
            // uiShoeTypeComboBox
            // 
            this.uiShoeTypeComboBox.FormattingEnabled = true;
            this.uiShoeTypeComboBox.Location = new System.Drawing.Point(226, 113);
            this.uiShoeTypeComboBox.Name = "uiShoeTypeComboBox";
            this.uiShoeTypeComboBox.Size = new System.Drawing.Size(586, 45);
            this.uiShoeTypeComboBox.TabIndex = 5;
            // 
            // uiShoeTypeLabel
            // 
            this.uiShoeTypeLabel.AutoSize = true;
            this.uiShoeTypeLabel.Location = new System.Drawing.Point(6, 116);
            this.uiShoeTypeLabel.Name = "uiShoeTypeLabel";
            this.uiShoeTypeLabel.Size = new System.Drawing.Size(170, 37);
            this.uiShoeTypeLabel.TabIndex = 4;
            this.uiShoeTypeLabel.Text = "Shoe Type";
            // 
            // uiShoeSizeUpDown
            // 
            this.uiShoeSizeUpDown.DecimalPlaces = 1;
            this.uiShoeSizeUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.uiShoeSizeUpDown.Location = new System.Drawing.Point(226, 52);
            this.uiShoeSizeUpDown.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.uiShoeSizeUpDown.Name = "uiShoeSizeUpDown";
            this.uiShoeSizeUpDown.Size = new System.Drawing.Size(586, 44);
            this.uiShoeSizeUpDown.TabIndex = 3;
            // 
            // uiShoeSizeLabel
            // 
            this.uiShoeSizeLabel.AutoSize = true;
            this.uiShoeSizeLabel.Location = new System.Drawing.Point(6, 54);
            this.uiShoeSizeLabel.Name = "uiShoeSizeLabel";
            this.uiShoeSizeLabel.Size = new System.Drawing.Size(161, 37);
            this.uiShoeSizeLabel.TabIndex = 0;
            this.uiShoeSizeLabel.Text = "Shoe Size";
            // 
            // newShoe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 776);
            this.Controls.Add(this.uiSpecificItemAttributesGroupBox);
            this.Name = "newShoe";
            this.Text = "PoS System | New Shoe";
            this.Controls.SetChildIndex(this.uiAddItemButton, 0);
            this.Controls.SetChildIndex(this.uiSpecificItemAttributesGroupBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.uiSpecificItemAttributesErrorProvider)).EndInit();
            this.uiSpecificItemAttributesGroupBox.ResumeLayout(false);
            this.uiSpecificItemAttributesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiShoeSizeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider uiSpecificItemAttributesErrorProvider;
        private System.Windows.Forms.GroupBox uiSpecificItemAttributesGroupBox;
        private System.Windows.Forms.NumericUpDown uiShoeSizeUpDown;
        private System.Windows.Forms.Label uiShoeSizeLabel;
        private System.Windows.Forms.ComboBox uiShoeTypeComboBox;
        private System.Windows.Forms.Label uiShoeTypeLabel;
    }
}