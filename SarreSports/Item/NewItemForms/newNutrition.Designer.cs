//Project Name: SarreSports | File Name: newNutrition.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 5/1/2019 | 15:29
//Last Updated On:  5/1/2019 | 15:29
namespace SarreSports
{
    partial class newNutrition
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
            this.uiNutritionTypeComboBox = new System.Windows.Forms.ComboBox();
            this.uiNutritionTypeLabel = new System.Windows.Forms.Label();
            this.uiNutritionQuantityUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiNutritionQuantityLabel = new System.Windows.Forms.Label();
            this.uiSpecificItemAttributesErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiSpecificItemAttributesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiNutritionQuantityUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpecificItemAttributesErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // uiAddItemButton
            // 
            this.uiAddItemButton.Location = new System.Drawing.Point(637, 686);
            // 
            // uiSpecificItemAttributesGroupBox
            // 
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiNutritionTypeComboBox);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiNutritionTypeLabel);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiNutritionQuantityUpDown);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiNutritionQuantityLabel);
            this.uiSpecificItemAttributesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSpecificItemAttributesGroupBox.Location = new System.Drawing.Point(24, 480);
            this.uiSpecificItemAttributesGroupBox.Name = "uiSpecificItemAttributesGroupBox";
            this.uiSpecificItemAttributesGroupBox.Size = new System.Drawing.Size(888, 186);
            this.uiSpecificItemAttributesGroupBox.TabIndex = 8;
            this.uiSpecificItemAttributesGroupBox.TabStop = false;
            this.uiSpecificItemAttributesGroupBox.Text = "Specific Item Attributes";
            // 
            // uiNutritionTypeComboBox
            // 
            this.uiNutritionTypeComboBox.FormattingEnabled = true;
            this.uiNutritionTypeComboBox.Location = new System.Drawing.Point(226, 116);
            this.uiNutritionTypeComboBox.Name = "uiNutritionTypeComboBox";
            this.uiNutritionTypeComboBox.Size = new System.Drawing.Size(586, 45);
            this.uiNutritionTypeComboBox.TabIndex = 5;
            // 
            // uiNutritionTypeLabel
            // 
            this.uiNutritionTypeLabel.AutoSize = true;
            this.uiNutritionTypeLabel.Location = new System.Drawing.Point(6, 119);
            this.uiNutritionTypeLabel.Name = "uiNutritionTypeLabel";
            this.uiNutritionTypeLabel.Size = new System.Drawing.Size(217, 37);
            this.uiNutritionTypeLabel.TabIndex = 4;
            this.uiNutritionTypeLabel.Text = "Nutrition Type";
            // 
            // uiNutritionQuantityUpDown
            // 
            this.uiNutritionQuantityUpDown.Location = new System.Drawing.Point(226, 52);
            this.uiNutritionQuantityUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.uiNutritionQuantityUpDown.Name = "uiNutritionQuantityUpDown";
            this.uiNutritionQuantityUpDown.Size = new System.Drawing.Size(586, 44);
            this.uiNutritionQuantityUpDown.TabIndex = 3;
            // 
            // uiNutritionQuantityLabel
            // 
            this.uiNutritionQuantityLabel.AutoSize = true;
            this.uiNutritionQuantityLabel.Location = new System.Drawing.Point(6, 54);
            this.uiNutritionQuantityLabel.Name = "uiNutritionQuantityLabel";
            this.uiNutritionQuantityLabel.Size = new System.Drawing.Size(136, 37);
            this.uiNutritionQuantityLabel.TabIndex = 0;
            this.uiNutritionQuantityLabel.Text = "Quantity";
            // 
            // uiSpecificItemAttributesErrorProvider
            // 
            this.uiSpecificItemAttributesErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.uiSpecificItemAttributesErrorProvider.ContainerControl = this;
            // 
            // newNutrition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 766);
            this.Controls.Add(this.uiSpecificItemAttributesGroupBox);
            this.Name = "newNutrition";
            this.Text = "PoS System | New Nutrition";
            this.Controls.SetChildIndex(this.uiAddItemButton, 0);
            this.Controls.SetChildIndex(this.uiSpecificItemAttributesGroupBox, 0);
            this.uiSpecificItemAttributesGroupBox.ResumeLayout(false);
            this.uiSpecificItemAttributesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiNutritionQuantityUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpecificItemAttributesErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox uiSpecificItemAttributesGroupBox;
        private System.Windows.Forms.ComboBox uiNutritionTypeComboBox;
        private System.Windows.Forms.Label uiNutritionTypeLabel;
        private System.Windows.Forms.NumericUpDown uiNutritionQuantityUpDown;
        private System.Windows.Forms.Label uiNutritionQuantityLabel;
        private System.Windows.Forms.ErrorProvider uiSpecificItemAttributesErrorProvider;
    }
}