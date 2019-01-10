//Project Name: SarreSports | File Name: newSystemUser.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 9/1/2019 | 22:44
//Last Updated On:  9/1/2019 | 23:02
namespace SarreSports
{
    partial class newSystemUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.uiUsernameLabel = new System.Windows.Forms.Label();
            this.uiPasswordLabel = new System.Windows.Forms.Label();
            this.uiUsernameTextBox = new System.Windows.Forms.TextBox();
            this.uiPasswordTextBox = new System.Windows.Forms.TextBox();
            this.uiUserTypeComboBox = new System.Windows.Forms.ComboBox();
            this.uiSystemUserSetupGroupBox = new System.Windows.Forms.GroupBox();
            this.uiUserTypeLabel = new System.Windows.Forms.Label();
            this.uiPersonalDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.uiFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.uiFirstNameLabel = new System.Windows.Forms.Label();
            this.uiLastNameLabel = new System.Windows.Forms.Label();
            this.uiLastNameTextBox = new System.Windows.Forms.TextBox();
            this.uiCreateUserButton = new System.Windows.Forms.Button();
            this.uiNewSystemUserErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiSystemUserSetupGroupBox.SuspendLayout();
            this.uiPersonalDetailsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiNewSystemUserErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "New System User";
            // 
            // uiUsernameLabel
            // 
            this.uiUsernameLabel.AutoSize = true;
            this.uiUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiUsernameLabel.Location = new System.Drawing.Point(12, 50);
            this.uiUsernameLabel.Name = "uiUsernameLabel";
            this.uiUsernameLabel.Size = new System.Drawing.Size(164, 37);
            this.uiUsernameLabel.TabIndex = 0;
            this.uiUsernameLabel.Text = "Username";
            // 
            // uiPasswordLabel
            // 
            this.uiPasswordLabel.AutoSize = true;
            this.uiPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPasswordLabel.Location = new System.Drawing.Point(12, 119);
            this.uiPasswordLabel.Name = "uiPasswordLabel";
            this.uiPasswordLabel.Size = new System.Drawing.Size(158, 37);
            this.uiPasswordLabel.TabIndex = 2;
            this.uiPasswordLabel.Text = "Password";
            // 
            // uiUsernameTextBox
            // 
            this.uiUsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiUsernameTextBox.Location = new System.Drawing.Point(200, 47);
            this.uiUsernameTextBox.Name = "uiUsernameTextBox";
            this.uiUsernameTextBox.Size = new System.Drawing.Size(538, 44);
            this.uiUsernameTextBox.TabIndex = 1;
            // 
            // uiPasswordTextBox
            // 
            this.uiPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPasswordTextBox.Location = new System.Drawing.Point(200, 116);
            this.uiPasswordTextBox.Name = "uiPasswordTextBox";
            this.uiPasswordTextBox.Size = new System.Drawing.Size(538, 44);
            this.uiPasswordTextBox.TabIndex = 3;
            this.uiPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // uiUserTypeComboBox
            // 
            this.uiUserTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiUserTypeComboBox.FormattingEnabled = true;
            this.uiUserTypeComboBox.Location = new System.Drawing.Point(200, 184);
            this.uiUserTypeComboBox.Name = "uiUserTypeComboBox";
            this.uiUserTypeComboBox.Size = new System.Drawing.Size(538, 45);
            this.uiUserTypeComboBox.TabIndex = 5;
            // 
            // uiSystemUserSetupGroupBox
            // 
            this.uiSystemUserSetupGroupBox.Controls.Add(this.uiUserTypeLabel);
            this.uiSystemUserSetupGroupBox.Controls.Add(this.uiUsernameTextBox);
            this.uiSystemUserSetupGroupBox.Controls.Add(this.uiUserTypeComboBox);
            this.uiSystemUserSetupGroupBox.Controls.Add(this.uiUsernameLabel);
            this.uiSystemUserSetupGroupBox.Controls.Add(this.uiPasswordLabel);
            this.uiSystemUserSetupGroupBox.Controls.Add(this.uiPasswordTextBox);
            this.uiSystemUserSetupGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSystemUserSetupGroupBox.Location = new System.Drawing.Point(24, 94);
            this.uiSystemUserSetupGroupBox.Name = "uiSystemUserSetupGroupBox";
            this.uiSystemUserSetupGroupBox.Size = new System.Drawing.Size(808, 255);
            this.uiSystemUserSetupGroupBox.TabIndex = 1;
            this.uiSystemUserSetupGroupBox.TabStop = false;
            this.uiSystemUserSetupGroupBox.Text = "System User Setup";
            // 
            // uiUserTypeLabel
            // 
            this.uiUserTypeLabel.AutoSize = true;
            this.uiUserTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiUserTypeLabel.Location = new System.Drawing.Point(12, 187);
            this.uiUserTypeLabel.Name = "uiUserTypeLabel";
            this.uiUserTypeLabel.Size = new System.Drawing.Size(163, 37);
            this.uiUserTypeLabel.TabIndex = 4;
            this.uiUserTypeLabel.Text = "User Type";
            // 
            // uiPersonalDetailsGroupBox
            // 
            this.uiPersonalDetailsGroupBox.Controls.Add(this.uiFirstNameTextBox);
            this.uiPersonalDetailsGroupBox.Controls.Add(this.uiFirstNameLabel);
            this.uiPersonalDetailsGroupBox.Controls.Add(this.uiLastNameLabel);
            this.uiPersonalDetailsGroupBox.Controls.Add(this.uiLastNameTextBox);
            this.uiPersonalDetailsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPersonalDetailsGroupBox.Location = new System.Drawing.Point(24, 355);
            this.uiPersonalDetailsGroupBox.Name = "uiPersonalDetailsGroupBox";
            this.uiPersonalDetailsGroupBox.Size = new System.Drawing.Size(808, 189);
            this.uiPersonalDetailsGroupBox.TabIndex = 2;
            this.uiPersonalDetailsGroupBox.TabStop = false;
            this.uiPersonalDetailsGroupBox.Text = "Personal Details";
            // 
            // uiFirstNameTextBox
            // 
            this.uiFirstNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFirstNameTextBox.Location = new System.Drawing.Point(200, 47);
            this.uiFirstNameTextBox.Name = "uiFirstNameTextBox";
            this.uiFirstNameTextBox.Size = new System.Drawing.Size(538, 44);
            this.uiFirstNameTextBox.TabIndex = 1;
            // 
            // uiFirstNameLabel
            // 
            this.uiFirstNameLabel.AutoSize = true;
            this.uiFirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFirstNameLabel.Location = new System.Drawing.Point(12, 50);
            this.uiFirstNameLabel.Name = "uiFirstNameLabel";
            this.uiFirstNameLabel.Size = new System.Drawing.Size(175, 37);
            this.uiFirstNameLabel.TabIndex = 0;
            this.uiFirstNameLabel.Text = "First Name";
            // 
            // uiLastNameLabel
            // 
            this.uiLastNameLabel.AutoSize = true;
            this.uiLastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLastNameLabel.Location = new System.Drawing.Point(12, 119);
            this.uiLastNameLabel.Name = "uiLastNameLabel";
            this.uiLastNameLabel.Size = new System.Drawing.Size(173, 37);
            this.uiLastNameLabel.TabIndex = 2;
            this.uiLastNameLabel.Text = "Last Name";
            // 
            // uiLastNameTextBox
            // 
            this.uiLastNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLastNameTextBox.Location = new System.Drawing.Point(200, 116);
            this.uiLastNameTextBox.Name = "uiLastNameTextBox";
            this.uiLastNameTextBox.Size = new System.Drawing.Size(538, 44);
            this.uiLastNameTextBox.TabIndex = 3;
            // 
            // uiCreateUserButton
            // 
            this.uiCreateUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCreateUserButton.Location = new System.Drawing.Point(601, 560);
            this.uiCreateUserButton.Name = "uiCreateUserButton";
            this.uiCreateUserButton.Size = new System.Drawing.Size(231, 63);
            this.uiCreateUserButton.TabIndex = 3;
            this.uiCreateUserButton.Text = "Create User";
            this.uiCreateUserButton.UseVisualStyleBackColor = true;
            this.uiCreateUserButton.Click += new System.EventHandler(this.uiCreateUserButton_Click);
            // 
            // uiNewSystemUserErrorProvider
            // 
            this.uiNewSystemUserErrorProvider.ContainerControl = this;
            // 
            // newSystemUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 644);
            this.Controls.Add(this.uiCreateUserButton);
            this.Controls.Add(this.uiPersonalDetailsGroupBox);
            this.Controls.Add(this.uiSystemUserSetupGroupBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newSystemUser";
            this.Text = "PoS Core | New System User";
            this.uiSystemUserSetupGroupBox.ResumeLayout(false);
            this.uiSystemUserSetupGroupBox.PerformLayout();
            this.uiPersonalDetailsGroupBox.ResumeLayout(false);
            this.uiPersonalDetailsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiNewSystemUserErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uiUsernameLabel;
        private System.Windows.Forms.Label uiPasswordLabel;
        private System.Windows.Forms.TextBox uiUsernameTextBox;
        private System.Windows.Forms.TextBox uiPasswordTextBox;
        private System.Windows.Forms.ComboBox uiUserTypeComboBox;
        private System.Windows.Forms.GroupBox uiSystemUserSetupGroupBox;
        private System.Windows.Forms.Label uiUserTypeLabel;
        private System.Windows.Forms.GroupBox uiPersonalDetailsGroupBox;
        private System.Windows.Forms.TextBox uiFirstNameTextBox;
        private System.Windows.Forms.Label uiFirstNameLabel;
        private System.Windows.Forms.Label uiLastNameLabel;
        private System.Windows.Forms.TextBox uiLastNameTextBox;
        private System.Windows.Forms.Button uiCreateUserButton;
        private System.Windows.Forms.ErrorProvider uiNewSystemUserErrorProvider;
    }
}