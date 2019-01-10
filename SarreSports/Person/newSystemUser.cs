//Project Name: SarreSports | File Name: newSystemUser.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 9/1/2019 | 23:32
//Last Updated On:  10/1/2019 | 00:59
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SarreSports
{
    public partial class newSystemUser : Form
    {
        public string username { get; set; }
        public string password { get; set; }
        public SystemUser.UserType userType { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public newSystemUser()
        {
            InitializeComponent();
            uiUserTypeComboBox.DataSource = Enum.GetValues(typeof(SystemUser.UserType));
        }

        private void uiCreateUserButton_Click(object sender, EventArgs e)
        {
            createUser();
        }

        private void createUser()
        {
            if (validateData())
            {
                this.username = uiUsernameTextBox.Text;
                this.password = uiPasswordTextBox.Text;
                this.userType = (SystemUser.UserType)uiUserTypeComboBox.SelectedItem;
                this.firstName = uiFirstNameTextBox.Text;
                this.lastName = uiLastNameTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool validateData()
        {
            bool valid = true;
            uiNewSystemUserErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(uiUsernameTextBox.Text))
            {
                uiNewSystemUserErrorProvider.SetError(uiUsernameTextBox, "Please enter valid username");
                uiNewSystemUserErrorProvider.SetIconPadding(uiUsernameTextBox, 10);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(uiPasswordTextBox.Text))
            {
                uiNewSystemUserErrorProvider.SetError(uiPasswordTextBox, "Please enter valid password");
                uiNewSystemUserErrorProvider.SetIconPadding(uiPasswordTextBox, 10);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(uiFirstNameTextBox.Text) && ValidateValue.name(uiFirstNameTextBox.Text))
            {
                uiNewSystemUserErrorProvider.SetError(uiFirstNameTextBox, "Please enter valid first name");
                uiNewSystemUserErrorProvider.SetIconPadding(uiFirstNameTextBox, 10);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(uiLastNameTextBox.Text) && ValidateValue.name(uiLastNameTextBox.Text))
            {
                uiNewSystemUserErrorProvider.SetError(uiLastNameTextBox, "Please enter valid last name");
                uiNewSystemUserErrorProvider.SetIconPadding(uiLastNameTextBox, 10);
                valid = false;
            }

            if (uiUserTypeComboBox.SelectedIndex < 0)
            {
                uiNewSystemUserErrorProvider.SetError(uiUserTypeComboBox, "Please select user type");
                uiNewSystemUserErrorProvider.SetIconPadding(uiUserTypeComboBox, 10);
                valid = false;
            }

            return valid;
        }
    }
}
