//Project Name: SarreSports | File Name: loginForm.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 3/12/2018 | 21:01
//Last Updated On:  20/12/2018 | 21:43
using System;
using System.Windows.Forms;

namespace SarreSports
{
    public partial class loginForm : Form
    {
        PoS posSystem = new PoS();

        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            resetFormValues();
            foreach (var branch in posSystem.MBranches()) {
                uiBranchSelectorComboBox.Items.Add(branch.BranchName());
            }
            //uiBranchSelectorComboBox.Items.Add("Test Null Branch"); //For Testing Only - Tests Null Branch Instance Handling
            uiBranchSelectorComboBox.SelectedIndex = uiBranchSelectorComboBox.Items.Count - 1;
        }

        private bool validateInputs()
        {
            bool valid = (uiBranchSelectorComboBox.SelectedIndex > -1);
            if (string.IsNullOrEmpty(uiUsernameTextBox.Text) && string.IsNullOrEmpty(uiPasswordTextBox.Text)) valid = false;
            return valid;
        }

        private void branchLogin()
        {
            if (validateInputs()) 
            {
                IBranch currentBranch = findBranchReference(uiBranchSelectorComboBox.SelectedIndex);
                if (!(currentBranch is NullBranch))
                {
                    if (currentBranch is Branch)
                    {
                        SystemUser currentUser = findBranchUserReference((Branch) currentBranch, uiUsernameTextBox.Text,
                            uiPasswordTextBox.Text);
                        if (!(string.IsNullOrEmpty(currentUser.ToString())) && authenticateUser(currentUser))
                        {
                            //LoggedIn
                            posForm posF = new posForm(currentBranch, currentUser);
                            this.Hide();
                            posF.ShowDialog();
                            this.Show();
                            resetFormValues();
                            posF.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Login Credentials", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Enter Login Credentials", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IBranch findBranchReference(int branchID)
        {
            IBranch branchReturn = NullBranch.Instance;
            foreach (var branch in posSystem.MBranches())
            {
                if (branch.ID == branchID)
                {
                    branchReturn = branch;
                }
            }
            return branchReturn;
        }

        private SystemUser findBranchUserReference(Branch branch, string username, string password)
        {
            foreach (var user in posSystem.MUsers(branch))
            {
                if (user is SystemUser && !string.IsNullOrEmpty(uiUsernameTextBox.Text))
                {
                    if (user.Username() == uiUsernameTextBox.Text)
                    {
                        return user;
                    }
                }
            }
            return null;
        }

        private bool authenticateUser(SystemUser user)
        {
            if (!(string.IsNullOrEmpty(uiUsernameTextBox.Text)) && !(string.IsNullOrEmpty(uiPasswordTextBox.Text)))
            {
                if (user.CheckPassword(uiPasswordTextBox.Text))
                {
                    Console.WriteLine("Authentication Success");
                    return true;
                }
                else
                {
                    Console.WriteLine("Authentication Failure");
                }
            }
            else
            {
                MessageBox.Show("Enter Login Credentials", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void resetFormValues()
        {
            uiBranchSelectorComboBox.Focus();
            uiBranchSelectorComboBox.SelectedIndex = uiBranchSelectorComboBox.Items.Count - 1;
            uiUsernameTextBox.Text = "";
            uiPasswordTextBox.Text = "";
        }

        private void uiLoginButton_Click(object sender, EventArgs e)
        {
            branchLogin();
        }

        private void uiHelpButton_Click(object sender, EventArgs e)
        {
            //Message Box not to be implemented in production environmemnt
            MessageBox.Show("Example Login Credentials:\n\n" +
                            "User Type\t|\tusername / password\n" +
                            "Store Clerk\t|\tclerk / 123\n" +
                            "Store Manager\t|\tmanager / abc\n" +
                            "Administrator\t|\tadmin / admin\n\n" +
                            "NB: Not Implemented in Production System\n\n" +
                            "Default Branch \"Sarre Running Sport\" Implemented with default users shown above.\n" +
                            "Additional branches may be added from Administrator login."
                , "Login Authentication Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void uiPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && validateInputs())
            {
                branchLogin();
            }
        }
    }
}
