//Project Name: SarreSports | File Name: posForm.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 10/12/2018 | 16:59
//Last Updated On:  26/12/2018 | 22:11
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

/*
 * Programming Structure and Development Notes
 *
 * System Requires C# 7.0 or greater to compile and run due to syntax utilised, incl. tuple function return values.
 * Zen.Barcode.Rendering.Framework required to compile from NuGet Packages for Barcode Generation.
 *
 * System uses custom naming convention for Tabulated Form Layout.
 * Each control or function has a prefix ('Sale', 'Customers', 'Inventory', 'Admin'), typically after 'ui' relating a given function to a tab
 * Unless the given control of function is to be used form-wide - see comments for guidance.
 *
 * As a form-wide function, some controls may have protected values and as such GroupBox handlers abide by control tags -
 * specifically searching for 'protected' tag. Requires implementation by parent to override optional argument value.
 *
 * Default branch and default users setup for testing - see help button upon first run. Help button to be removed in production environment.
 */

namespace SarreSports
{
    public partial class posForm : Form
    {
        private Branch currentBranch;
        private SystemUser currentUser;

        private enum Tabs
        {
            Sale = 0,
            Customers = 1,
            Inventory = 2,
            Admin = 3
        };
        private enum TabStates
        {
            Default = 0,
            New_Customer = 1,
            Loaded_Customer = 2,
            Edit_Customer = 3

        }

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
            //Set Default Tab Edit States
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
            changeTabState(Tabs.Customers, TabStates.Default);
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
            changeTabState(Tabs.Customers, TabStates.New_Customer, true);
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
            if (uiCustomersCustomerEditSaveButton.Text == "Edit")
            {
                changeTabState(Tabs.Customers, TabStates.Edit_Customer);
            }
            else
            {
                //Validate All Customer Details
                if (customersValidateCustomerDetails())
                {
                    //Get Loaded Customer value and if loaded check form values
                    //If value has changed, push new value to given attribute in customer object
                    if (int.TryParse(uiCustomersCustomerIDUpDown.Text, out int customerID))
                    {
                        if (uiCustomersFirstNameTextBox.Text != (currentBranch.getFirstName(customerID) ?? "Error"))
                        {
                            currentBranch.setFirstName(customerID, uiCustomersFirstNameTextBox.Text);
                        }

                        if (uiCustomersLastNameTextBox.Text != (currentBranch.getLastName(customerID) ?? "Error"))
                        {
                            currentBranch.setLastName(customerID, uiCustomersLastNameTextBox.Text);
                        }

                        if (uiCustomersEmailAddressTextBox.Text != (currentBranch.getEmailAddress(customerID) ?? "Error"))
                        {
                            currentBranch.setEmailAddress(customerID, uiCustomersEmailAddressTextBox.Text);
                        }

                        if (uiCustomersMobileNoTextBox.Text != (currentBranch.getMobileNo(customerID) ?? "Error"))
                        {
                            currentBranch.setMobileNo(customerID, uiCustomersMobileNoTextBox.Text);
                        }

                        if (uiCustomersPostCodeTextBox.Text != (currentBranch.getPostCode(customerID) ?? "Error"))
                        {
                            currentBranch.setPostCode(customerID, uiCustomersPostCodeTextBox.Text);
                        }

                        if (uiCustomersPoliciesGDPRCheckBox.Checked != (currentBranch.getGDPR(customerID) ?? false))
                        {
                            currentBranch.setGDPR(customerID, uiCustomersPoliciesGDPRCheckBox.Checked);
                        }
                        customersLoadCustomer(customerID); //Once edit completed reload customer
                    }
                    else
                    {
                        //Customer Edit Loading Failed
                        MessageBox.Show("Customer Details Edit Error. Customer ID related error.\n" +
                                        "Cancel edit query and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //Customer Details Validation Failed
                    MessageBox.Show("Invalid values entered. See Error Prompts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void customersLoadCustomer(int customerID)
        {
            if (!string.IsNullOrEmpty(customerID.ToString()))
            {
                changeTabState(Tabs.Customers, TabStates.Loaded_Customer);
                Console.WriteLine(String.Format("Customer ID: {0}. Loaded.", customerID));

                uiCustomersCustomerIDUpDown.Text = customerID.ToString();
                uiCustomersCustomerNameTextBox.Text = currentBranch.getFullName(customerID) ?? "Not Found";

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
            if (int.TryParse(uiCustomersCustomerIDUpDown.Text, out int customerID))
            {
                currentBranch.emailCustomer(customerID);
            } else
            {
                //Customer Loading Failed
                MessageBox.Show("Customer Details Loading Error. Customer ID related error.\n" +
                                "Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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
            changeTabState(Tabs.Admin, TabStates.Default);
            changeTabState(Tabs.Inventory, TabStates.Default);
            changeTabState(Tabs.Customers, TabStates.Default);
            changeTabState(Tabs.Sale, TabStates.Default);
        }

        private void resetGroupBoxControls(GroupBox box, bool protectedText = false)
        {
            foreach (Control ctr in box.Controls)
            {
                if (ctr is TextBox)
                {
                    if (ctr.Tag is null)
                    {
                        ctr.Text = "";
                    } else if ((ctr.Tag.ToString() ?? "") == "protected" && protectedText)
                    {
                        ctr.Text = ctr.Text;
                    }
                    else
                    {
                        ctr.Text = "";
                    }
                }
                else if (ctr is NumericUpDown)
                {
                    ((NumericUpDown)ctr).ResetText();
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
                else if (ctr is ListView)
                {
                    ((ListView)ctr).Items.Clear();
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
                else if (ctr is Button)
                {
                    ctr.Enabled = state;
                }
                else if (ctr is NumericUpDown)
                {
                    ctr.Enabled = state;
                }
                else if (ctr is ListView)
                {
                    ctr.Enabled = state;
                }
            }
        }

        private void changeTabState(Tabs tab, TabStates state, bool nameHelper = false)
        {
            Console.WriteLine(string.Format("Tab State Change Request. Tab: {0}. New Tab State: {1}", tab, state));
            switch (tab)
            {
                //Each Tab follows UI Breakdown orders.
                case Tabs.Sale:
                    switch (state)
                    {
                        case TabStates.Default:
                            uiSaleCustomerIDUpDown.Focus();
                            resetGroupBoxControls(uiSalePurchaseGroupBox);
                            groupBoxControlsEnabled(uiSalePurchaseGroupBox, false);
                            break;
                        case TabStates.Loaded_Customer:
                            uiSaleProductIDUpDown.Focus();
                            resetGroupBoxControls(uiSalePurchaseGroupBox);
                            groupBoxControlsEnabled(uiSalePurchaseGroupBox, true);
                            break;
                        default:
                            Console.WriteLine("Tab State Changed Failed.");
                            break;
                    }
                    break;
                case Tabs.Customers:
                    switch (state)
                    {
                        case TabStates.Default:
                            //Element 1
                            uiCustomersCustomerIDUpDown.ResetText();
                            uiCustomersCustomerIDUpDown.Enabled = true;
                            uiCustomersCustomerIDUpDown.Focus();

                            //Element 2
                            uiCustomersCustomerNameTextBox.Clear();
                            uiCustomersCustomerNameTextBox.Enabled = true;

                            
                            uiCustomersNewCustomerButton.Enabled = true;        //Element 3
                            uiCustomersSearchCustomersButton.Enabled = true;    //Element 4

                            //Element 5
                            resetGroupBoxControls(uiCustomersCustomerDetailsGroupBox);
                            groupBoxControlsEnabled(uiCustomersCustomerDetailsGroupBox, false);

                            //Element 6
                            uiCustomersCustomerEditSaveButton.Text = "Edit";
                            uiCustomersCustomerEditSaveButton.Hide();

                            uiCustomersCancelButton.Hide();       //Element 7
                            uiCustomersCreateCustomerButton.Hide();             //Element 8

                            //Element 9
                            uiCustomersQRCodePictureBox.Image = uiCustomersQRCodePictureBox.InitialImage;
                            uiCustomersQRCodePictureBox.Enabled = false;

                            //Element 10
                            groupBoxControlsEnabled(uiCustomersCustomerActionsGroupBox, false);

                            //Element 11
                            uiCustomersPurchasesListView.Items.Clear();
                            uiCustomersPurchasesListView.Enabled = false;
                            break;
                        case TabStates.New_Customer:
                            //Element 1
                            uiCustomersCustomerIDUpDown.ResetText();
                            uiCustomersCustomerIDUpDown.Enabled = false;

                            //Element 2 + 5
                            if (nameHelper)
                            {
                                //New Customer Click
                                (uiCustomersCustomerNameTextBox.Text, uiCustomersFirstNameTextBox.Text, uiCustomersLastNameTextBox.Text) =
                                    customerNameFormattingHelper(uiCustomersCustomerNameTextBox.Text);
                                uiCustomersCustomerNameTextBox.Enabled = false;
                                resetGroupBoxControls(uiCustomersCustomerDetailsGroupBox, true); //Element 5 - protected reset
                                groupBoxControlsEnabled(uiCustomersCustomerDetailsGroupBox, true);
                            }
                            else
                            {
                                uiCustomersCustomerNameTextBox.Clear();
                                uiCustomersCustomerNameTextBox.Enabled = false;
                                resetGroupBoxControls(uiCustomersCustomerDetailsGroupBox); //Element 5 - reset
                                groupBoxControlsEnabled(uiCustomersCustomerDetailsGroupBox, true);

                            }
                            
                            uiCustomersNewCustomerButton.Enabled = false;        //Element 3
                            uiCustomersSearchCustomersButton.Enabled = false;    //Element 4

                            //Element 6
                            uiCustomersCustomerEditSaveButton.Text = "Edit";
                            uiCustomersCustomerEditSaveButton.Hide();

                            uiCustomersCancelButton.Show();       //Element 7
                            uiCustomersCreateCustomerButton.Show();             //Element 8

                            //Element 9
                            uiCustomersQRCodePictureBox.Image = uiCustomersQRCodePictureBox.InitialImage;
                            uiCustomersQRCodePictureBox.Enabled = false;

                            //Element 10
                            groupBoxControlsEnabled(uiCustomersCustomerActionsGroupBox, false);

                            //Element 11
                            uiCustomersPurchasesListView.Items.Clear();
                            uiCustomersPurchasesListView.Enabled = false;
                            break;
                        case TabStates.Loaded_Customer:
                            //Element 1
                            uiCustomersCustomerIDUpDown.ResetText();
                            uiCustomersCustomerIDUpDown.Enabled = false;

                            //Element 2
                            uiCustomersCustomerNameTextBox.Clear();
                            uiCustomersCustomerNameTextBox.Enabled = false;

                            uiCustomersNewCustomerButton.Enabled = false;        //Element 3
                            uiCustomersSearchCustomersButton.Enabled = false;    //Element 4

                            //Element 5
                            resetGroupBoxControls(uiCustomersCustomerDetailsGroupBox);
                            groupBoxControlsEnabled(uiCustomersCustomerDetailsGroupBox, false);

                            //Element 6
                            uiCustomersCustomerEditSaveButton.Text = "Edit";
                            uiCustomersCustomerEditSaveButton.Show();

                            uiCustomersCancelButton.Show();       //Element 7
                            uiCustomersCreateCustomerButton.Hide();             //Element 8

                            //Element 9
                            uiCustomersQRCodePictureBox.Image = uiCustomersQRCodePictureBox.InitialImage;
                            uiCustomersQRCodePictureBox.Enabled = true;

                            //Element 10
                            groupBoxControlsEnabled(uiCustomersCustomerActionsGroupBox, true);

                            //Element 11
                            uiCustomersPurchasesListView.Items.Clear();
                            uiCustomersPurchasesListView.Enabled = true;
                            break;
                        case TabStates.Edit_Customer:
                            //Element 1
                            uiCustomersCustomerIDUpDown.Enabled = false;

                            //Element 2
                            uiCustomersCustomerNameTextBox.Enabled = false;

                            uiCustomersNewCustomerButton.Enabled = false;        //Element 3
                            uiCustomersSearchCustomersButton.Enabled = false;    //Element 4

                            //Element 5
                            groupBoxControlsEnabled(uiCustomersCustomerDetailsGroupBox, true);

                            //Element 6
                            uiCustomersCustomerEditSaveButton.Text = "Save";
                            uiCustomersCustomerEditSaveButton.Show();

                            uiCustomersCancelButton.Show();                     //Element 7
                            uiCustomersCreateCustomerButton.Hide();             //Element 8

                            //Element 9
                            uiCustomersQRCodePictureBox.Enabled = true;

                            //Element 10
                            groupBoxControlsEnabled(uiCustomersCustomerActionsGroupBox, false);

                            //Element 11
                            uiCustomersPurchasesListView.Items.Clear();
                            uiCustomersPurchasesListView.Enabled = false;
                            break;
                        default:
                            Console.WriteLine("Tab State Changed Failed.");
                            break;
                    }
                    break;
                case Tabs.Inventory:
                    break;
                case Tabs.Admin:
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
