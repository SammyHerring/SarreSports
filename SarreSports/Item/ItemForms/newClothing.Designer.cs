//Project Name: SarreSports | File Name: newClothing.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 5/1/2019 | 02:35
//Last Updated On:  5/1/2019 | 02:35
namespace SarreSports
{
    partial class newClothing
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
            this.uiClothingTypeComboBox = new System.Windows.Forms.ComboBox();
            this.uiClothingTypeLabel = new System.Windows.Forms.Label();
            this.uiClothingSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiClothingSizeLabel = new System.Windows.Forms.Label();
            this.uiClothingColourLabel = new System.Windows.Forms.Label();
            this.uiClothingColourTextBox = new System.Windows.Forms.TextBox();
            this.uiSpecificItemAttributesErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiSpecificItemAttributesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiClothingSizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpecificItemAttributesErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // uiSpecificItemAttributesGroupBox
            // 
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiClothingColourTextBox);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiClothingColourLabel);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiClothingTypeComboBox);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiClothingTypeLabel);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiClothingSizeUpDown);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiClothingSizeLabel);
            this.uiSpecificItemAttributesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSpecificItemAttributesGroupBox.Location = new System.Drawing.Point(24, 484);
            this.uiSpecificItemAttributesGroupBox.Name = "uiSpecificItemAttributesGroupBox";
            this.uiSpecificItemAttributesGroupBox.Size = new System.Drawing.Size(888, 270);
            this.uiSpecificItemAttributesGroupBox.TabIndex = 7;
            this.uiSpecificItemAttributesGroupBox.TabStop = false;
            this.uiSpecificItemAttributesGroupBox.Text = "Specific Item Attributes";
            // 
            // uiClothingTypeComboBox
            // 
            this.uiClothingTypeComboBox.FormattingEnabled = true;
            this.uiClothingTypeComboBox.Location = new System.Drawing.Point(226, 200);
            this.uiClothingTypeComboBox.Name = "uiClothingTypeComboBox";
            this.uiClothingTypeComboBox.Size = new System.Drawing.Size(586, 45);
            this.uiClothingTypeComboBox.TabIndex = 5;
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
            // uiClothingSizeUpDown
            // 
            this.uiClothingSizeUpDown.Location = new System.Drawing.Point(226, 52);
            this.uiClothingSizeUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.uiClothingSizeUpDown.Name = "uiClothingSizeUpDown";
            this.uiClothingSizeUpDown.Size = new System.Drawing.Size(586, 44);
            this.uiClothingSizeUpDown.TabIndex = 3;
            // 
            // uiClothingSizeLabel
            // 
            this.uiClothingSizeLabel.AutoSize = true;
            this.uiClothingSizeLabel.Location = new System.Drawing.Point(6, 54);
            this.uiClothingSizeLabel.Name = "uiClothingSizeLabel";
            this.uiClothingSizeLabel.Size = new System.Drawing.Size(205, 37);
            this.uiClothingSizeLabel.TabIndex = 0;
            this.uiClothingSizeLabel.Text = "Clothing Size";
            // 
            // uiClothingColourLabel
            // 
            this.uiClothingColourLabel.AutoSize = true;
            this.uiClothingColourLabel.Location = new System.Drawing.Point(6, 131);
            this.uiClothingColourLabel.Name = "uiClothingColourLabel";
            this.uiClothingColourLabel.Size = new System.Drawing.Size(112, 37);
            this.uiClothingColourLabel.TabIndex = 6;
            this.uiClothingColourLabel.Text = "Colour";
            // 
            // uiClothingColourTextBox
            // 
            this.uiClothingColourTextBox.Location = new System.Drawing.Point(226, 128);
            this.uiClothingColourTextBox.Name = "uiClothingColourTextBox";
            this.uiClothingColourTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiClothingColourTextBox.TabIndex = 7;
            // 
            // uiSpecificItemAttributesErrorProvider
            // 
            this.uiSpecificItemAttributesErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.uiSpecificItemAttributesErrorProvider.ContainerControl = this;
            // 
            // newClothing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 870);
            this.Controls.Add(this.uiSpecificItemAttributesGroupBox);
            this.Name = "newClothing";
            this.Text = "PoS System | New Clothing";
            this.Controls.SetChildIndex(this.uiAddItemButton, 0);
            this.Controls.SetChildIndex(this.uiSpecificItemAttributesGroupBox, 0);
            this.uiSpecificItemAttributesGroupBox.ResumeLayout(false);
            this.uiSpecificItemAttributesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiClothingSizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpecificItemAttributesErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox uiSpecificItemAttributesGroupBox;
        private System.Windows.Forms.TextBox uiClothingColourTextBox;
        private System.Windows.Forms.Label uiClothingColourLabel;
        private System.Windows.Forms.ComboBox uiClothingTypeComboBox;
        private System.Windows.Forms.Label uiClothingTypeLabel;
        private System.Windows.Forms.NumericUpDown uiClothingSizeUpDown;
        private System.Windows.Forms.Label uiClothingSizeLabel;
        private System.Windows.Forms.ErrorProvider uiSpecificItemAttributesErrorProvider;
    }
}