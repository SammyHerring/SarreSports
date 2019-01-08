//Project Name: SarreSports | File Name: genericNumericEntry.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 6/1/2019 | 19:25
//Last Updated On:  6/1/2019 | 19:25
namespace SarreSports
{
    partial class genericNumericEntry
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
            this.uiTitle = new System.Windows.Forms.Label();
            this.uiValueQueryLabel = new System.Windows.Forms.Label();
            this.uiNumericValueUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiSubmitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiNumericValueUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTitle
            // 
            this.uiTitle.AutoSize = true;
            this.uiTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTitle.Location = new System.Drawing.Point(22, 9);
            this.uiTitle.Name = "uiTitle";
            this.uiTitle.Size = new System.Drawing.Size(337, 67);
            this.uiTitle.TabIndex = 1;
            this.uiTitle.Text = "Enter Value";
            // 
            // uiValueQueryLabel
            // 
            this.uiValueQueryLabel.AutoSize = true;
            this.uiValueQueryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiValueQueryLabel.Location = new System.Drawing.Point(27, 94);
            this.uiValueQueryLabel.Name = "uiValueQueryLabel";
            this.uiValueQueryLabel.Size = new System.Drawing.Size(194, 37);
            this.uiValueQueryLabel.TabIndex = 2;
            this.uiValueQueryLabel.Text = "Value Query";
            // 
            // uiNumericValueUpDown
            // 
            this.uiNumericValueUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiNumericValueUpDown.Location = new System.Drawing.Point(34, 144);
            this.uiNumericValueUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uiNumericValueUpDown.Name = "uiNumericValueUpDown";
            this.uiNumericValueUpDown.Size = new System.Drawing.Size(716, 44);
            this.uiNumericValueUpDown.TabIndex = 3;
            // 
            // uiSubmitButton
            // 
            this.uiSubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSubmitButton.Location = new System.Drawing.Point(531, 209);
            this.uiSubmitButton.Name = "uiSubmitButton";
            this.uiSubmitButton.Size = new System.Drawing.Size(219, 53);
            this.uiSubmitButton.TabIndex = 4;
            this.uiSubmitButton.Text = "Submit";
            this.uiSubmitButton.UseVisualStyleBackColor = true;
            this.uiSubmitButton.Click += new System.EventHandler(this.uiSubmitButton_Click);
            this.uiSubmitButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiSubmitButton_KeyDown);
            // 
            // genericNumericEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 298);
            this.Controls.Add(this.uiSubmitButton);
            this.Controls.Add(this.uiNumericValueUpDown);
            this.Controls.Add(this.uiValueQueryLabel);
            this.Controls.Add(this.uiTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "genericNumericEntry";
            this.Text = "PoS System | Enter Value";
            ((System.ComponentModel.ISupportInitialize)(this.uiNumericValueUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uiTitle;
        private System.Windows.Forms.Label uiValueQueryLabel;
        private System.Windows.Forms.NumericUpDown uiNumericValueUpDown;
        private System.Windows.Forms.Button uiSubmitButton;
    }
}