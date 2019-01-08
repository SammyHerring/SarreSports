//Project Name: SarreSports | File Name: viewNutrition.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 7/1/2019 | 15:13
//Last Updated On:  7/1/2019 | 15:13
namespace SarreSports
{
    partial class viewNutrition
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
            this.uiNutritionQuantityTextBox = new System.Windows.Forms.TextBox();
            this.uiNutritionTypeTextBox = new System.Windows.Forms.TextBox();
            this.uiNutritionQuantityLabel = new System.Windows.Forms.Label();
            this.uiNutritionTypeLabel = new System.Windows.Forms.Label();
            this.uiSpecificItemAttributesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiBuyItemButton
            // 
            this.uiBuyItemButton.Location = new System.Drawing.Point(626, 812);
            // 
            // uiRestockItemButton
            // 
            this.uiRestockItemButton.Location = new System.Drawing.Point(34, 812);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Location = new System.Drawing.Point(330, 812);
            // 
            // uiSpecificItemAttributesGroupBox
            // 
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiNutritionTypeLabel);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiNutritionQuantityLabel);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiNutritionTypeTextBox);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiNutritionQuantityTextBox);
            this.uiSpecificItemAttributesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSpecificItemAttributesGroupBox.Location = new System.Drawing.Point(31, 602);
            this.uiSpecificItemAttributesGroupBox.Name = "uiSpecificItemAttributesGroupBox";
            this.uiSpecificItemAttributesGroupBox.Size = new System.Drawing.Size(839, 190);
            this.uiSpecificItemAttributesGroupBox.TabIndex = 13;
            this.uiSpecificItemAttributesGroupBox.TabStop = false;
            this.uiSpecificItemAttributesGroupBox.Text = "Specific Item Attributes";
            // 
            // uiNutritionQuantityTextBox
            // 
            this.uiNutritionQuantityTextBox.Enabled = false;
            this.uiNutritionQuantityTextBox.Location = new System.Drawing.Point(226, 47);
            this.uiNutritionQuantityTextBox.Name = "uiNutritionQuantityTextBox";
            this.uiNutritionQuantityTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiNutritionQuantityTextBox.TabIndex = 0;
            // 
            // uiNutritionTypeTextBox
            // 
            this.uiNutritionTypeTextBox.Location = new System.Drawing.Point(226, 118);
            this.uiNutritionTypeTextBox.Name = "uiNutritionTypeTextBox";
            this.uiNutritionTypeTextBox.Size = new System.Drawing.Size(586, 44);
            this.uiNutritionTypeTextBox.TabIndex = 1;
            // 
            // uiNutritionQuantityLabel
            // 
            this.uiNutritionQuantityLabel.AutoSize = true;
            this.uiNutritionQuantityLabel.Location = new System.Drawing.Point(6, 50);
            this.uiNutritionQuantityLabel.Name = "uiNutritionQuantityLabel";
            this.uiNutritionQuantityLabel.Size = new System.Drawing.Size(136, 37);
            this.uiNutritionQuantityLabel.TabIndex = 2;
            this.uiNutritionQuantityLabel.Text = "Quantity";
            // 
            // uiNutritionTypeLabel
            // 
            this.uiNutritionTypeLabel.AutoSize = true;
            this.uiNutritionTypeLabel.Location = new System.Drawing.Point(6, 121);
            this.uiNutritionTypeLabel.Name = "uiNutritionTypeLabel";
            this.uiNutritionTypeLabel.Size = new System.Drawing.Size(217, 37);
            this.uiNutritionTypeLabel.TabIndex = 3;
            this.uiNutritionTypeLabel.Text = "Nutrition Type";
            // 
            // viewNutrition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 896);
            this.Controls.Add(this.uiSpecificItemAttributesGroupBox);
            this.Name = "viewNutrition";
            this.Text = "PoS System | View Nutrition";
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
        private System.Windows.Forms.Label uiNutritionTypeLabel;
        private System.Windows.Forms.Label uiNutritionQuantityLabel;
        private System.Windows.Forms.TextBox uiNutritionTypeTextBox;
        private System.Windows.Forms.TextBox uiNutritionQuantityTextBox;
    }
}