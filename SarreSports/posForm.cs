//Project Name: SarreSports | File Name: posForm.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 10/12/2018 | 16:59
//Last Updated On:  22/12/2018 | 23:29
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Programming Structure and Development Notes
 * System Requires C# 7.0 or greater to compile and run due to syntax utilised.
 * Zen.Barcode.Rendering.Framework required to compile from NuGet Packages for Barcode Generation.
 * System uses custom naming convention for Tabulated Form Layout.
 * Each control or function has a prefix ('Sale', 'Customers', 'Inventory', 'Admin'), typically after 'ui' relating a given function to a tab
 * Unless the given control of function is to be used form-wide - see comments for guidance.
 * Default branch and default users setup for testing - see help button upon first run. Help button to be removed in production environment.
 */

namespace SarreSports
{
    public partial class posForm : Form
    {
        private Branch currentBranch;
        private SystemUser currentUser;
        private bool customersCustomerEditStateValue;
        private bool salePurchaseEditStateValue;

        public posForm(IBranch b, SystemUser u)
        {
            InitializeComponent();
            switch (b)
            {
                case NullBranch _:
                    MessageBox.Show("Branch Improperly Loaded", "PoS View Branch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
                case Branch _:
                    currentBranch = (Branch) b;
                    currentUser = u;
                    uiBranchTitleLabel.Text = b.BranchName();
                    break;
            }
        }

        private void posForm_Load(object sender, EventArgs e)
        {
            //Allow relevant form tab access to given users
            if (currentUser.Type() == SystemUser.UserType.Clerk)
            {
                uiPosViewTabControl.TabPages.Remove(uiInventoryTab);
                uiPosViewTabControl.TabPages.Remove(uiAdminTab);
            } else if (currentUser.Type() == SystemUser.UserType.Manager)
            {
                uiPosViewTabControl.TabPages.Remove(uiAdminTab);
            }
            //Initialise Form List View
            //Initialise Basket Listing List View
            uiSaleBasketListView.View = View.Details;
            uiSaleBasketListView.LabelEdit = true;
            //Initialise Basket Listing List View Column Values
            uiSaleBasketListView.Columns.Add("Product ID", 200, HorizontalAlignment.Left);
            uiSaleBasketListView.Columns.Add("Product Name", 400, HorizontalAlignment.Left);
            uiSaleBasketListView.Columns.Add("Quantity", 125, HorizontalAlignment.Left);
            uiSaleBasketListView.Columns.Add("Item Cost", 125, HorizontalAlignment.Left);
            uiSaleBasketListView.Columns.Add("Total Cost", -2, HorizontalAlignment.Left);
            //Initialise Basket Listing List View
            uiCustomersPurchasesListView.View = View.Details;
            uiCustomersPurchasesListView.LabelEdit = true;
            //Initialise Basket Listing List View Column Values
            uiCustomersPurchasesListView.Columns.Add("Purchase ID", 200, HorizontalAlignment.Left);
            uiCustomersPurchasesListView.Columns.Add("Purchase Date", 400, HorizontalAlignment.Left);
            uiCustomersPurchasesListView.Columns.Add("Total Cost", -2, HorizontalAlignment.Left);
            //Set Tab Edit States
            setDefaultFormState();
        }

        private void posForm_FormClosing(object sender, FormClosingEventArgs e)
        {
                if (MessageBox.Show("Are you sure you want to logout?", "Logging Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                } 
        }

        //Sale Tab Functions
        //Sale Events
        private void uiSaleSearchButton_Click(object sender, EventArgs e)
        {

        }

        //Sale General Functions

        //Sale Control Management Functions
        private bool salePurchaseEditState
        {
            get => salePurchaseEditState;

            set
            {
                salePurchaseEditStateValue = value;
                uiSalePurchaseGroupBox.Enabled = value;
            }
        }

        //Customers Tab Functions
        //Customer Events
        private void uiCustomersNewCustomerButton_Click(object sender, EventArgs e)
        {
            customersNewCustomer();
        }

        private void uiCustomersSearchCustomersButton_Click(object sender, EventArgs e)
        {
            customersSearchCustomer();
        }

        private void uiCustomersCustomerEditSaveButton_Click(object sender, EventArgs e)
        {
            customersEditCustomer();
        }

        private void uiCustomersCreateCustomerButton_Click(object sender, EventArgs e)
        {
            customersCreateCustomer();
        }

        private void uiCustomersCancelCustomerCreateButton_Click(object sender, EventArgs e)
        {
            changeTabState("Customers", "Default");
        }

        private void uiCustomersQRCodeSaveButton_Click(object sender, EventArgs e)
        {
            customersSaveQRCode();
        }

        private void uiCustomersQRCodePrintButton_Click(object sender, EventArgs e)
        {
            customersPrintQRCode();
        }

        private void uiCustomersEmailCustomerDetailsButton_Click(object sender, EventArgs e)
        {
            customersEmailDetails();
        }

        //Customer General Functions
        private void customersNewCustomer()
        {
            changeTabState("Customers", "NewCustomer");
        }

        private void customersSearchCustomer()
        {

        }

        private void customersCreateCustomer()
        {
            if (customersValidateCustomerDetails())
            {
                var currentCustomer = currentBranch.createCustomer(new Customer(
                    uiCustomersFirstNameTextBox.Text,
                    uiCustomersLastNameTextBox.Text,
                    uiCustomersPoliciesGDPRCheckBox.Checked,
                    uiCustomersPostCodeTextBox.Text,
                    uiCustomersMobileNoTextBox.Text,
                    uiCustomersEmailAddressTextBox.Text));
                if (currentCustomer.Success)
                {
                    //Customer Creation Success
                    //Query user if user should be emailed their registration details
                    DialogResult emailCustomerQuery = MessageBox.Show("Do you want to email the customer with their details?", "Customer Registration Email", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(emailCustomerQuery == DialogResult.Yes)
                    {
                        currentBranch.emailCustomer(currentCustomer.customerID);
                    }
                    customersResetTab(); //Reset Customers Tab Contents
                    customersLoadCustomer(currentCustomer.customerID); //Load newly created customer
                }
                else
                {
                    //Customer Creation Error
                    MessageBox.Show("Customer Creation Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //Customer Details Validation Failed
                MessageBox.Show("Invalid values entered. See Error Prompts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customersEditCustomer()
        {

        }

        private void customersLoadCustomer(int customerID)
        {
            if (!string.IsNullOrEmpty(customerID.ToString()))
            {
                changeTabState("Customers", "LoadCustomer");

                uiCustomersCustomerIDUpDown.Value = customerID;
                Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                uiCustomersQRCodePictureBox.Image = qrcode.Draw(customerID.ToString(), uiCustomersQRCodePictureBox.Height);

                uiCustomersFirstNameTextBox.Text = currentBranch.getFirstName(customerID) ?? "Not Found";
                uiCustomersLastNameTextBox.Text = currentBranch.getLastName(customerID) ?? "Not Found";
                uiCustomersEmailAddressTextBox.Text = currentBranch.getEmailAddress(customerID) ?? "Not Found";
                uiCustomersMobileNoTextBox.Text = currentBranch.getMobileNo(customerID) ?? "Not Found";
                uiCustomersPostCodeTextBox.Text = currentBranch.getPostCode(customerID) ?? "Not Found";
                uiCustomersPoliciesGDPRCheckBox.Checked = currentBranch.getGDPR(customerID) ?? false;
            }
        }

        private void customersSaveQRCode()
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";  
            dialog.Title = "Save QR Code";
            dialog.FileName = "QR.jpg";

            if ((dialog.ShowDialog() == DialogResult.OK) && (dialog.FileName != ""))
            {
                using (var bitmap = new Bitmap(uiCustomersQRCodePictureBox.Width, uiCustomersQRCodePictureBox.Height))
                {
                    uiCustomersQRCodePictureBox.DrawToBitmap(bitmap, uiCustomersQRCodePictureBox.ClientRectangle);
                    bitmap.Save(dialog.FileName, ImageFormat.Bmp);
                }
            }
        }

        private void customersPrintQRCode()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printQR_PrintPage);

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            previewDialog.ShowDialog();

            PrintDialog dialog = new PrintDialog();

            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ToString());
            }
        }

        private void printQR_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (var bitmap = new Bitmap(uiCustomersQRCodePictureBox.Width, uiCustomersQRCodePictureBox.Height))
            {
                uiCustomersQRCodePictureBox.DrawToBitmap(bitmap, uiCustomersQRCodePictureBox.ClientRectangle);
                Image img = (Image)bitmap;
                Point loc = new Point(100, 100);
                e.Graphics.DrawImage(img, loc); 
            }
        }

        private void customersEmailDetails()
        {
            //currentBranch.emailCustomer(int customerID);
        }

        //Customer Control Management Functions
        private bool customersValidateCustomerDetails()
        {
            bool valid = true;
            uiCustomersErrorProvider.Clear();
            try
            {
                if (string.IsNullOrEmpty(uiCustomersFirstNameTextBox.Text) || !ValidateValue.name(uiCustomersFirstNameTextBox.Text))
                {
                    uiCustomersErrorProvider.SetError(uiCustomersFirstNameTextBox, "Please enter valid first name");
                    uiCustomersErrorProvider.SetIconPadding(uiCustomersFirstNameTextBox, 10);
                    valid = false;
                }

                if (string.IsNullOrEmpty(uiCustomersLastNameTextBox.Text) || !ValidateValue.fullName(uiCustomersLastNameTextBox.Text))
                {
                    uiCustomersErrorProvider.SetError(uiCustomersLastNameTextBox, "Please enter valid last name");
                    uiCustomersErrorProvider.SetIconPadding(uiCustomersLastNameTextBox, 10);
                    valid = false;
                }

                if (string.IsNullOrEmpty(uiCustomersEmailAddressTextBox.Text) || !ValidateValue.emailAddress(uiCustomersEmailAddressTextBox.Text))
                {
                    uiCustomersErrorProvider.SetError(uiCustomersEmailAddressTextBox, "Please enter valid email address");
                    uiCustomersErrorProvider.SetIconPadding(uiCustomersEmailAddressTextBox, 10);
                    valid = false;
                }

                if (string.IsNullOrEmpty(uiCustomersMobileNoTextBox.Text) || !ValidateValue.mobileNo(uiCustomersMobileNoTextBox.Text))
                {
                    uiCustomersErrorProvider.SetError(uiCustomersMobileNoTextBox, "Please enter valid mobile number");
                    uiCustomersErrorProvider.SetIconPadding(uiCustomersMobileNoTextBox, 10);
                    valid = false;
                }

                if (string.IsNullOrEmpty(uiCustomersPostCodeTextBox.Text) || !ValidateValue.postCode(uiCustomersPostCodeTextBox.Text))
                {
                    uiCustomersErrorProvider.SetError(uiCustomersPostCodeTextBox, "Please enter valid post code");
                    uiCustomersErrorProvider.SetIconPadding(uiCustomersPostCodeTextBox, 10);
                    valid = false;
                }
                else
                {
                    uiCustomersPostCodeTextBox.Text = uiCustomersPostCodeTextBox.Text.ToUpper();
                }

                if (!uiCustomersPoliciesGDPRCheckBox.Checked)
                {
                    uiCustomersErrorProvider.SetError(uiCustomersPoliciesGDPRCheckBox, "Customer must accept GDPR Policy");
                    uiCustomersErrorProvider.SetIconPadding(uiCustomersPoliciesGDPRCheckBox, 10);
                    valid = false;
                }
            }
            finally
            {
                uiCustomersFirstNameTextBox.Text = uiCustomersFirstNameTextBox.Text.Trim();
                uiCustomersLastNameTextBox.Text = uiCustomersLastNameTextBox.Text.Trim();
                uiCustomersEmailAddressTextBox.Text = uiCustomersEmailAddressTextBox.Text.Trim();
                uiCustomersMobileNoTextBox.Text = uiCustomersMobileNoTextBox.Text.Trim();
                uiCustomersPostCodeTextBox.Text = uiCustomersPostCodeTextBox.Text.Trim();
            }

            return valid;
        }

        private void customersResetTab()
        {
            uiCustomersCustomerIDUpDown.Focus();

            uiCustomersNewCustomerButton.Enabled = true;
            uiCustomersSearchCustomersButton.Enabled = true;

            uiCustomersCustomerIDUpDown.ResetText();
            uiCustomersCustomerIDUpDown.Enabled = true;

            uiCustomersCustomerNameTextBox.Clear();
            uiCustomersCustomerNameTextBox.Enabled = true;

            resetGroupBoxControls(uiCustomersCustomerDetailsGroupBox);
            customersCustomerEditState = false;

            uiCustomersCancelCustomerCreateButton.Hide();
            uiCustomersCreateCustomerButton.Hide();
            uiCustomersCustomerEditSaveButton.Hide();

            uiCustomersErrorProvider.Clear();

        }

        private bool customersCustomerEditState
        {
            get => customersCustomerEditStateValue;

            set
            {
                customersCustomerEditStateValue = value;
                uiCustomersCustomerDetailsGroupBox.Enabled = value;
                uiCustomersCustomerActionsGroupBox.Enabled = value;
                uiCustomersQRCodePictureBox.Enabled = value;
                uiCustomersPurchasesTitleLabel.Enabled = value;
                uiCustomersPurchasesListView.Enabled = value;
            }
        }

        //Form-wide Functions
        private void uiLogoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private (string, string, string)  customerNameFormattingHelper(string fullName)
        {
            string firstName = "";
            string lastName = "";

            if (!(string.IsNullOrEmpty(fullName)) && ValidateValue.fullName(fullName))
            {
                try
                {
                    if (fullName.Contains(" "))
                    {
                        var names = fullName.Split(' ');
                        if (names.Length == 2)
                        {
                            firstName = names[0].ToLower().FirstCharToUpper() ?? "";
                            lastName = names[1].ToLower().FirstCharToUpper() ?? "";
                        }
                        else
                        {
                            firstName = names[0].ToLower().FirstCharToUpper() ?? "";
                            if (!(string.IsNullOrWhiteSpace(firstName)))
                            {
                                string resultLastName = "";
                                foreach (var nameElement in names)
                                {
                                    if (!(string.IsNullOrWhiteSpace(nameElement)))
                                    {
                                        if (nameElement != names[0])
                                        {
                                            if (nameElement != names[1])
                                            {
                                                resultLastName += " " + nameElement.ToLower().FirstCharToUpper();
                                            }
                                            else
                                            {
                                                resultLastName = nameElement.ToLower().FirstCharToUpper();
                                            }
                                        }
                                    }
                                }

                                lastName = resultLastName;
                            }
                        }
                    }
                    else
                    {

                        firstName = fullName.ToLower().FirstCharToUpper();
                    }
                }
                finally
                {
                    fullName =
                        (firstName.Trim() + " " + lastName.Trim());
                    firstName = firstName.Trim();
                    lastName = lastName.Trim();
                }
            }
            else
            {
                fullName = "";
            }
            return (fullName, firstName, lastName);
        }

        private void setDefaultFormState()
        {
            customersResetTab();
            salePurchaseEditState = salePurchaseEditStateValue;
        }

        private void resetGroupBoxControls(GroupBox box)
        {
            foreach (Control ctr in box.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
                else if (ctr is CheckedListBox)
                {
                    CheckedListBox clb = (CheckedListBox)ctr;
                    foreach (int checkedItemIndex in clb.CheckedIndices)
                    {
                        clb.SetItemChecked(checkedItemIndex, false);
                    }
                }
                else if (ctr is CheckBox)
                {
                    ((CheckBox)ctr).Checked = false;
                }
                else if (ctr is ComboBox)
                {
                    ((ComboBox)ctr).SelectedIndex = 0;
                }
            }
        }

        private void groupBoxControlsEnabled(GroupBox box, bool state)
        {
            foreach (Control ctr in box.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Enabled = state;
                }
                else if (ctr is CheckedListBox)
                {
                    ctr.Enabled = state;
                }
                else if (ctr is CheckBox)
                {
                    ctr.Enabled = state;
                }
                else if (ctr is ComboBox)
                {
                    ctr.Enabled = state;
                }
            }
        }

        private void changeTabState(string tab, string state)
        {
            switch (tab)
            {
                case "Sale":
                    break;
                case "Customers":
                    switch (state)
                    {
                        case "Default":
                            customersResetTab();
                            break;
                        case "NewCustomer":
                            uiCustomersNewCustomerButton.Enabled = false;
                            uiCustomersSearchCustomersButton.Enabled = false;

                            uiCustomersCustomerIDUpDown.ResetText();
                            uiCustomersCustomerIDUpDown.Enabled = false;

                            (uiCustomersCustomerNameTextBox.Text, uiCustomersFirstNameTextBox.Text, uiCustomersLastNameTextBox.Text) =
                                customerNameFormattingHelper(uiCustomersCustomerNameTextBox.Text);
                            uiCustomersCustomerNameTextBox.Enabled = false;

                            uiCustomersCustomerDetailsGroupBox.Enabled = true;
                            uiCustomersCreateCustomerButton.Show();
                            uiCustomersCancelCustomerCreateButton.Show();
                            break;
                        case "LoadCustomer":
                            customersCustomerEditState = true;
                            groupBoxControlsEnabled(uiCustomersCustomerDetailsGroupBox, false);
                            uiCustomersQRCodePictureBox.Enabled = true;

                            uiCustomersCancelCustomerCreateButton.Show();

                            uiCustomersCustomerIDUpDown.Enabled = false;
                            uiCustomersCustomerNameTextBox.Enabled = false;

                            uiCustomersNewCustomerButton.Enabled = false;
                            uiCustomersSearchCustomersButton.Enabled = false;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Inventory":
                    break;
                case "Admin":
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Extension to String Class to allow  new string specific functions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Capitalises first character of a string and returns the new string
        /// </summary>
        /// <param name="input">Input String</param>
        /// <returns>Capitalised Input String</returns>
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": return null; //throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)) IsUdtRet;
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
