//Project Name: SarreSports | File Name: newBranch.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 10/1/2019 | 01:02
//Last Updated On:  10/1/2019 | 01:02
namespace SarreSports
{
    partial class newBranch
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
            this.uiCreateBranchButton = new System.Windows.Forms.Button();
            this.uiBranchNameTextBox = new System.Windows.Forms.TextBox();
            this.uiBranchNameLabel = new System.Windows.Forms.Label();
            this.uiNewBranchTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiCreateBranchButton
            // 
            this.uiCreateBranchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCreateBranchButton.Location = new System.Drawing.Point(312, 238);
            this.uiCreateBranchButton.Name = "uiCreateBranchButton";
            this.uiCreateBranchButton.Size = new System.Drawing.Size(319, 55);
            this.uiCreateBranchButton.TabIndex = 8;
            this.uiCreateBranchButton.Text = "Create Branch";
            this.uiCreateBranchButton.UseVisualStyleBackColor = true;
            this.uiCreateBranchButton.Click += new System.EventHandler(this.uiCreateBranchButton_Click);
            // 
            // uiBranchNameTextBox
            // 
            this.uiBranchNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiBranchNameTextBox.Location = new System.Drawing.Point(24, 170);
            this.uiBranchNameTextBox.Name = "uiBranchNameTextBox";
            this.uiBranchNameTextBox.Size = new System.Drawing.Size(607, 44);
            this.uiBranchNameTextBox.TabIndex = 7;
            this.uiBranchNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiBranchNameTextBox_KeyDown);
            // 
            // uiBranchNameLabel
            // 
            this.uiBranchNameLabel.AutoSize = true;
            this.uiBranchNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiBranchNameLabel.Location = new System.Drawing.Point(17, 120);
            this.uiBranchNameLabel.Name = "uiBranchNameLabel";
            this.uiBranchNameLabel.Size = new System.Drawing.Size(214, 37);
            this.uiBranchNameLabel.TabIndex = 6;
            this.uiBranchNameLabel.Text = "Branch Name";
            // 
            // uiNewBranchTitle
            // 
            this.uiNewBranchTitle.AutoSize = true;
            this.uiNewBranchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiNewBranchTitle.Location = new System.Drawing.Point(12, 9);
            this.uiNewBranchTitle.Name = "uiNewBranchTitle";
            this.uiNewBranchTitle.Size = new System.Drawing.Size(352, 67);
            this.uiNewBranchTitle.TabIndex = 5;
            this.uiNewBranchTitle.Text = "New Branch";
            // 
            // newBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 314);
            this.Controls.Add(this.uiCreateBranchButton);
            this.Controls.Add(this.uiBranchNameTextBox);
            this.Controls.Add(this.uiBranchNameLabel);
            this.Controls.Add(this.uiNewBranchTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newBranch";
            this.Text = "PoS Core | New Branch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uiCreateBranchButton;
        private System.Windows.Forms.TextBox uiBranchNameTextBox;
        private System.Windows.Forms.Label uiBranchNameLabel;
        private System.Windows.Forms.Label uiNewBranchTitle;
    }
}