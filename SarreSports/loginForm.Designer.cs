//Project Name: SarreSports | File Name: loginForm.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 3/12/2018 | 21:01
//Last Updated On:  20/12/2018 | 14:44
namespace SarreSports
{
    partial class loginForm
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
            this.uiLoginTitleLabel = new System.Windows.Forms.Label();
            this.uiBranchSelectionGroupBox = new System.Windows.Forms.GroupBox();
            this.uiBranchSelectorComboBox = new System.Windows.Forms.ComboBox();
            this.uiBranchSelectionLabel = new System.Windows.Forms.Label();
            this.uiAuthenticationGroupBox = new System.Windows.Forms.GroupBox();
            this.uiPasswordLabel = new System.Windows.Forms.Label();
            this.uiUsernameTextBox = new System.Windows.Forms.TextBox();
            this.uiUsernameLabel = new System.Windows.Forms.Label();
            this.uiPasswordTextBox = new System.Windows.Forms.TextBox();
            this.uiLoginButton = new System.Windows.Forms.Button();
            this.uiHelpButton = new System.Windows.Forms.Button();
            this.uiBranchSelectionGroupBox.SuspendLayout();
            this.uiAuthenticationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLoginTitleLabel
            // 
            this.uiLoginTitleLabel.AutoSize = true;
            this.uiLoginTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLoginTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.uiLoginTitleLabel.Name = "uiLoginTitleLabel";
            this.uiLoginTitleLabel.Size = new System.Drawing.Size(514, 67);
            this.uiLoginTitleLabel.TabIndex = 0;
            this.uiLoginTitleLabel.Text = "PoS System Login";
            // 
            // uiBranchSelectionGroupBox
            // 
            this.uiBranchSelectionGroupBox.Controls.Add(this.uiBranchSelectorComboBox);
            this.uiBranchSelectionGroupBox.Controls.Add(this.uiBranchSelectionLabel);
            this.uiBranchSelectionGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiBranchSelectionGroupBox.Location = new System.Drawing.Point(13, 95);
            this.uiBranchSelectionGroupBox.Name = "uiBranchSelectionGroupBox";
            this.uiBranchSelectionGroupBox.Size = new System.Drawing.Size(769, 136);
            this.uiBranchSelectionGroupBox.TabIndex = 1;
            this.uiBranchSelectionGroupBox.TabStop = false;
            this.uiBranchSelectionGroupBox.Text = "Branch Selection";
            // 
            // uiBranchSelectorComboBox
            // 
            this.uiBranchSelectorComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiBranchSelectorComboBox.FormattingEnabled = true;
            this.uiBranchSelectorComboBox.Location = new System.Drawing.Point(217, 63);
            this.uiBranchSelectorComboBox.Name = "uiBranchSelectorComboBox";
            this.uiBranchSelectorComboBox.Size = new System.Drawing.Size(527, 45);
            this.uiBranchSelectorComboBox.TabIndex = 0;
            // 
            // uiBranchSelectionLabel
            // 
            this.uiBranchSelectionLabel.AutoSize = true;
            this.uiBranchSelectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiBranchSelectionLabel.Location = new System.Drawing.Point(8, 66);
            this.uiBranchSelectionLabel.Name = "uiBranchSelectionLabel";
            this.uiBranchSelectionLabel.Size = new System.Drawing.Size(119, 37);
            this.uiBranchSelectionLabel.TabIndex = 0;
            this.uiBranchSelectionLabel.Text = "Branch";
            // 
            // uiAuthenticationGroupBox
            // 
            this.uiAuthenticationGroupBox.Controls.Add(this.uiPasswordLabel);
            this.uiAuthenticationGroupBox.Controls.Add(this.uiUsernameTextBox);
            this.uiAuthenticationGroupBox.Controls.Add(this.uiUsernameLabel);
            this.uiAuthenticationGroupBox.Controls.Add(this.uiPasswordTextBox);
            this.uiAuthenticationGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiAuthenticationGroupBox.Location = new System.Drawing.Point(13, 246);
            this.uiAuthenticationGroupBox.Name = "uiAuthenticationGroupBox";
            this.uiAuthenticationGroupBox.Size = new System.Drawing.Size(769, 230);
            this.uiAuthenticationGroupBox.TabIndex = 2;
            this.uiAuthenticationGroupBox.TabStop = false;
            this.uiAuthenticationGroupBox.Text = "Authenticate User";
            // 
            // uiPasswordLabel
            // 
            this.uiPasswordLabel.AutoSize = true;
            this.uiPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPasswordLabel.Location = new System.Drawing.Point(34, 151);
            this.uiPasswordLabel.Name = "uiPasswordLabel";
            this.uiPasswordLabel.Size = new System.Drawing.Size(158, 37);
            this.uiPasswordLabel.TabIndex = 8;
            this.uiPasswordLabel.Text = "Password";
            // 
            // uiUsernameTextBox
            // 
            this.uiUsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiUsernameTextBox.Location = new System.Drawing.Point(217, 63);
            this.uiUsernameTextBox.Name = "uiUsernameTextBox";
            this.uiUsernameTextBox.Size = new System.Drawing.Size(527, 44);
            this.uiUsernameTextBox.TabIndex = 1;
            // 
            // uiUsernameLabel
            // 
            this.uiUsernameLabel.AutoSize = true;
            this.uiUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiUsernameLabel.Location = new System.Drawing.Point(28, 66);
            this.uiUsernameLabel.Name = "uiUsernameLabel";
            this.uiUsernameLabel.Size = new System.Drawing.Size(164, 37);
            this.uiUsernameLabel.TabIndex = 7;
            this.uiUsernameLabel.Text = "Username";
            // 
            // uiPasswordTextBox
            // 
            this.uiPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPasswordTextBox.Location = new System.Drawing.Point(217, 148);
            this.uiPasswordTextBox.Name = "uiPasswordTextBox";
            this.uiPasswordTextBox.Size = new System.Drawing.Size(527, 44);
            this.uiPasswordTextBox.TabIndex = 2;
            this.uiPasswordTextBox.UseSystemPasswordChar = true;
            this.uiPasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiPasswordTextBox_KeyDown);
            // 
            // uiLoginButton
            // 
            this.uiLoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLoginButton.Location = new System.Drawing.Point(421, 506);
            this.uiLoginButton.Name = "uiLoginButton";
            this.uiLoginButton.Size = new System.Drawing.Size(336, 120);
            this.uiLoginButton.TabIndex = 3;
            this.uiLoginButton.Text = "Login";
            this.uiLoginButton.UseVisualStyleBackColor = true;
            this.uiLoginButton.Click += new System.EventHandler(this.uiLoginButton_Click);
            // 
            // uiHelpButton
            // 
            this.uiHelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiHelpButton.Location = new System.Drawing.Point(41, 506);
            this.uiHelpButton.Name = "uiHelpButton";
            this.uiHelpButton.Size = new System.Drawing.Size(356, 120);
            this.uiHelpButton.TabIndex = 4;
            this.uiHelpButton.Text = "Help";
            this.uiHelpButton.UseVisualStyleBackColor = true;
            this.uiHelpButton.Click += new System.EventHandler(this.uiHelpButton_Click);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 658);
            this.Controls.Add(this.uiHelpButton);
            this.Controls.Add(this.uiLoginButton);
            this.Controls.Add(this.uiAuthenticationGroupBox);
            this.Controls.Add(this.uiBranchSelectionGroupBox);
            this.Controls.Add(this.uiLoginTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "loginForm";
            this.Text = "PoS System | Login View";
            this.Load += new System.EventHandler(this.loginForm_Load);
            this.uiBranchSelectionGroupBox.ResumeLayout(false);
            this.uiBranchSelectionGroupBox.PerformLayout();
            this.uiAuthenticationGroupBox.ResumeLayout(false);
            this.uiAuthenticationGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uiLoginTitleLabel;
        private System.Windows.Forms.GroupBox uiBranchSelectionGroupBox;
        private System.Windows.Forms.ComboBox uiBranchSelectorComboBox;
        private System.Windows.Forms.Label uiBranchSelectionLabel;
        private System.Windows.Forms.GroupBox uiAuthenticationGroupBox;
        private System.Windows.Forms.Button uiLoginButton;
        private System.Windows.Forms.Button uiHelpButton;
        private System.Windows.Forms.TextBox uiPasswordTextBox;
        private System.Windows.Forms.TextBox uiUsernameTextBox;
        private System.Windows.Forms.Label uiPasswordLabel;
        private System.Windows.Forms.Label uiUsernameLabel;
    }
}

