//Project Name: SarreSports | File Name: posForm.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 10/12/2018 | 16:59
//Last Updated On:  9/1/2019 | 12:29
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

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
        private List<Item> currentBasket = new List<Item>();

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
            Edit_Customer = 3,
            Loaded_Product = 4
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
            uiSaleBasketListView.LabelEdit = false;
            uiSaleBasketListView.FullRowSelect = true;
            //Initialise Basket Listing List View Column Values
            uiSaleBasketListView.Columns.Add("Product ID", 200, HorizontalAlignment.Left);
            uiSaleBasketListView.Columns.Add("Product Name", 400, HorizontalAlignment.Left);
            uiSaleBasketListView.Columns.Add("Quantity", 125, HorizontalAlignment.Left);
            uiSaleBasketListView.Columns.Add("Item Cost", 125, HorizontalAlignment.Left);
            uiSaleBasketListView.Columns.Add("Total Cost", -2, HorizontalAlignment.Left);
            //Initialise Basket Listing List View
            uiCustomersPurchasesListView.View = View.Details;
            uiCustomersPurchasesListView.LabelEdit = false;
            uiCustomersPurchasesListView.FullRowSelect = true;
            //Initialise Basket Listing List View Column Values
            uiCustomersPurchasesListView.Columns.Add("Purchase ID", 200, HorizontalAlignment.Left);
            uiCustomersPurchasesListView.Columns.Add("Purchase Date", 400, HorizontalAlignment.Left);
            uiCustomersPurchasesListView.Columns.Add("Total Cost", -2, HorizontalAlignment.Left);
            //Initialise Basket Listing List View
            uiInventorySupplierItemsListView.View = View.Details;
            uiInventorySupplierItemsListView.LabelEdit = false;
            uiInventorySupplierItemsListView.FullRowSelect = true;
            //Initialise Basket Listing List View Column Values
            uiInventorySupplierItemsListView.Columns.Add("Item ID", 100, HorizontalAlignment.Left);
            uiInventorySupplierItemsListView.Columns.Add("Item Name", 250, HorizontalAlignment.Left);
            uiInventorySupplierItemsListView.Columns.Add("Item Type", 125, HorizontalAlignment.Left);
            uiInventorySupplierItemsListView.Columns.Add("Item Cost", 125, HorizontalAlignment.Left);
            uiInventorySupplierItemsListView.Columns.Add("Available", 100, HorizontalAlignment.Left);
            uiInventorySupplierItemsListView.Columns.Add("Stock Level", 125, HorizontalAlignment.Left);
            uiInventorySupplierItemsListView.Columns.Add("Restock Level", 125, HorizontalAlignment.Left);
            uiInventorySupplierItemsListView.Columns.Add("Restock?", -2, HorizontalAlignment.Left);
            //Set Default Tab Edit States
            setDefaultFormState();
        }

        /// <summary>
        /// Sale Tab Functions
        /// </summary>
        //Sale Button Events
        private void uiSaleNewCustomerButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(uiSaleCustomerNameTextBox.Text)) uiCustomersCustomerNameTextBox.Text = uiSaleCustomerNameTextBox.Text;
            uiSaleCustomerNameTextBox.Clear();
            uiPosViewTabControl.SelectedTab = uiCustomersTab;
            customersNewCustomer();
        }

        private void uiSaleSearchButton_Click(object sender, EventArgs e)
        {
            saleSearchCustomers();
        }

        private void uiSaleProductSearchButton_Click(object sender, EventArgs e)
        {
            saleSearchProducts();
        }

        private void uiSaleViewItemButton_Click(object sender, EventArgs e)
        {
            saleLoadProduct(Int32.Parse(uiSaleProductIDUpDown.Text));
        }

        private void uiSaleCancelProductSelectionButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(uiSaleCustomerIDUpDown.Text, out int customerID))
            {
                changeTabState(Tabs.Sale, TabStates.Loaded_Customer);
                saleLoadCustomers(customerID);
            } else
            {
                //Customer Loading Failed
                MessageBox.Show("Customer Details Loading Error. Customer ID related error.\n" +
                                "Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                changeTabState(Tabs.Sale, TabStates.Default);
            }
            
        }

        private void uiSaleSaleButton_Click(object sender, EventArgs e)
        {
            salePurchaseBasket();
        }

        private void uiSaleRemoveItemButton_Click(object sender, EventArgs e)
        {
            saleRemoveItem();
        }

        private void uiSaleCancelButton_Click(object sender, EventArgs e)
        {
            changeTabState(Tabs.Sale, TabStates.Default);
        }

        //Sale General Functions
        private void saleSearchCustomers()
        {
            string initialSearch = "";

            if (!string.IsNullOrEmpty(uiSaleCustomerIDUpDown.Text) && Generic.IsInteger(uiSaleCustomerIDUpDown.Text))
            {
                initialSearch = uiSaleCustomerIDUpDown.Text;
            } else if (!string.IsNullOrEmpty(uiSaleCustomerNameTextBox.Text))
            {
                initialSearch = uiSaleCustomerNameTextBox.Text;
            }

            using (genericSearch customerSearch = new genericSearch(getCustomerListViewItems(), "Customer", initialSearch))
            {
                var result = customerSearch.ShowDialog();

                if (result == DialogResult.OK)
                {
                    saleLoadCustomers(customerSearch.returnedID); //Load Customer IF Selected
                }
                else
                {
                    changeTabState(Tabs.Sale, TabStates.Default);
                }

                customerSearch.Dispose();
            };
        }

        private void saleLoadCustomers(int customerID)
        {
            if (!string.IsNullOrEmpty(customerID.ToString()))
            {
                if (currentBranch.findCustomer(customerID) != null)
                {
                    changeTabState(Tabs.Sale, TabStates.Loaded_Customer);
                    Console.WriteLine(String.Format("Tab: Sale. Customer ID: {0}. Loaded.", customerID));

                    uiSaleCustomerIDUpDown.Text = customerID.ToString();
                    uiSaleCustomerNameTextBox.Text = currentBranch.getFullName(customerID) ?? "Not Found";
                }
                else
                {
                    changeTabState(Tabs.Sale, TabStates.Default);
                    //Customer Creation Error
                    MessageBox.Show("Customer Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saleSearchProducts()
        {
            string initialSearch = "";

            if (!string.IsNullOrEmpty(uiSaleProductIDUpDown.Text) && Generic.IsInteger(uiSaleProductIDUpDown.Text))
            {
                initialSearch = uiSaleProductIDUpDown.Text;
            } else if (!string.IsNullOrEmpty(uiSaleProductNameTextBox.Text))
            {
                initialSearch = uiSaleProductNameTextBox.Text;
            }

            using (genericSearch productSearch = new genericSearch(getProductListViewItems(), "Product", initialSearch))
            {
                var result = productSearch.ShowDialog();

                if (result == DialogResult.OK)
                {
                    saleLoadProduct(productSearch.returnedID); //Load Product IF Selected
                }

                productSearch.Dispose();
            };
        }

        private void saleLoadProduct(int productID)
        {
            changeTabState(Tabs.Sale, TabStates.Loaded_Product);
            Console.WriteLine(String.Format("Tab: Sale. Product ID: {0}. Loaded.", productID));

            uiSaleProductIDUpDown.Text = productID.ToString();
            Item currentProduct = currentBranch.findProduct(productID);
            if (currentProduct != null)
            {
                uiSaleProductNameTextBox.Text = currentProduct.Name;
                saleLoadItemViewer(productID);
                
                changeTabState(Tabs.Sale, TabStates.Loaded_Product);
                uiSaleProductIDUpDown.Text = productID.ToString();
                uiSaleProductNameTextBox.Text = currentProduct.Name;
            }
            else
            {
                MessageBox.Show("Product Not Found\n" +
                                "Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                changeTabState(Tabs.Sale, TabStates.Loaded_Customer);
            }
            
        }

        private void saleLoadItemViewer(int productID)
        {
            var newItem = currentBranch.newViewItemForm(productID, viewItem.viewItemState.Buy);
            var product = currentBranch.findProduct(productID);

            if (newItem.success)
            {
                if (newItem.valueReturn > 0)
                {
                    if (product.availableForSale && product.StockLevel >= newItem.valueReturn && saleCheckOrderedQuantity(product, newItem.valueReturn))
                    {
                        for (int itemCount = 0; itemCount < newItem.valueReturn; itemCount++)
                            {
                                currentBasket.Add(product);
                            }
                    } else
                    {
                        MessageBox.Show("Product Not Available.\n" +
                                        "Due to quantity required or seller availability.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void saleLoadBasket()
        {
            uiSaleBasketListView.Items.Clear();
            uiSaleBasketListView.Items.AddRange(getBasketListViewItems());
        }

        private bool saleCheckOrderedQuantity(Item product, int newOrderQuantity)
        {
            var currentBasketDuplicates = currentBasket
                .GroupBy(i => i)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            var itemQuantity = currentBasket.Count(Item => currentBasketDuplicates.Contains(product));

            return (itemQuantity + newOrderQuantity <= product.StockLevel);
        }

        private (bool avaliable, IItem product) saleCurrentBasketCheck()
        {
            foreach (var item in currentBasket)
            {
                var itemQuantity = currentBasket.Count(Item => currentBasket.Contains(item) && Item == item);

                if (!currentBranch.productCheckStockAndAvaliability(item, itemQuantity)) return (false, (Item)item);
            }

            return (true, new NullItem());
        }

        private void salePurchaseBasket()
        {
            if (uiSaleBasketListView.Items.Count > 0 && currentBasket.Count > 0)
            {
                var basketCheck = saleCurrentBasketCheck();
                if (basketCheck.avaliable)
                {
                    var purchase = currentBranch.purchaseCustomer(int.Parse(uiSaleCustomerIDUpDown.Text), currentBasket);
                    if (!purchase.success)
                    {
                        MessageBox.Show("Customer Purchase Failed.", 
                            "Purchase Error", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        changeTabState(Tabs.Sale, TabStates.Default);
                    }
                    else
                    {
                        MessageBox.Show(String.Format("Customer Purchase Success.\n" +
                                        "Order Total Value: {0:C2}", purchase.purchaseCost), 
                            String.Format("Purchase: #{0}", purchase.purchaseID), 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        changeTabState(Tabs.Sale, TabStates.Default);
                        changeTabState(Tabs.Customers, TabStates.Default);
                        changeTabState(Tabs.Inventory, TabStates.Default);
                    }
                }
                else
                {
                    Item item = (Item)basketCheck.product;
                    MessageBox.Show(String.Format("Product {0} in your basket is not available.\n" +
                                    "Due to quantity required or seller availability.", item.Name), 
                                    "Basket Error", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("No Items Selected.",
                    "Basket Error",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void saleRemoveItem()
        {
            if (uiSaleBasketListView.SelectedItems.Count > 0)
            {
                if (Int32.Parse(uiSaleBasketListView.SelectedItems[0].SubItems[2].Text) > 1)
                {
                    DialogResult removeItemDialog = MessageBox.Show(String.Format("Would you like to remove all {0} of this item?", 
                                                                                    uiSaleBasketListView.SelectedItems[0].SubItems[2].Text),
                        String.Format("Remove {0} from Basket", uiSaleBasketListView.SelectedItems[0].SubItems[1].Text),
                        MessageBoxButtons.YesNoCancel, 
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (removeItemDialog == DialogResult.Yes)
                    {
                        // Remove All Item of Selected Type
                        currentBasket.RemoveAll(currentBranch.predicateProduct(int.Parse(uiSaleBasketListView.SelectedItems[0].SubItems[0].Text)));
                        saleLoadCustomers(Int32.Parse(uiSaleCustomerIDUpDown.Text));
                    } else if (removeItemDialog == DialogResult.No)
                    {
                        //Remove One Item of Selected Type
                        currentBasket.Remove(currentBranch.findProduct(int.Parse(uiSaleBasketListView.SelectedItems[0].SubItems[0].Text)));
                        saleLoadCustomers(Int32.Parse(uiSaleCustomerIDUpDown.Text));
                    }
                }
                else
                {
                    //Remove One Item of Selected Type
                    currentBasket.Remove(currentBranch.findProduct(int.Parse(uiSaleBasketListView.SelectedItems[0].SubItems[0].Text)));
                    saleLoadCustomers(Int32.Parse(uiSaleCustomerIDUpDown.Text));
                }
            }
            else
            {
                MessageBox.Show("No Item Selected.",
                    "Basket Error",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        //Sale General Events
        private void uiSaleCustomerIDUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && !string.IsNullOrEmpty(uiSaleCustomerIDUpDown.Text) && Generic.IsInteger(uiSaleCustomerIDUpDown.Text))
            {
                saleSearchCustomers();
            }
        }

        private void uiSaleCustomerNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(uiSaleCustomerNameTextBox.Text))
            {
                DialogResult searchCustomerDialog = MessageBox.Show("Do you wish to search for this customer?",
                    "Search Customers",
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (searchCustomerDialog == DialogResult.Yes)
                {
                    saleSearchCustomers();
                }
            }
        }

        private void uiSaleProductIDUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && !string.IsNullOrEmpty(uiSaleProductIDUpDown.Text) && Generic.IsInteger(uiSaleProductIDUpDown.Text))
            {
                saleSearchProducts();
            }
        }

        private void uiSaleProductNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(uiSaleProductNameTextBox.Text))
            {
                    saleSearchProducts();
            }
        }

        private void uiSaleBasketListView_DoubleClick(object sender, EventArgs e)
        {
            if (uiSaleBasketListView.SelectedItems.Count > 0)
            {
                var newItem = currentBranch.newViewItemForm(Int32.Parse(uiSaleBasketListView.SelectedItems[0].Text));
            }
        }

        /// <summary>
        /// Customers Tab Functions
        /// </summary>
        //Customers Button Events
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
            string initialSearch = "";

            if (!string.IsNullOrEmpty(uiCustomersCustomerIDUpDown.Text) && Generic.IsInteger(uiCustomersCustomerIDUpDown.Text))
            {
                initialSearch = uiCustomersCustomerIDUpDown.Text;
            } else if (!string.IsNullOrEmpty(uiCustomersCustomerNameTextBox.Text))
            {
                initialSearch = uiCustomersCustomerNameTextBox.Text;
            }

            using (genericSearch customerSearch = new genericSearch(getCustomerListViewItems(), "Customer", initialSearch))
            {
                var result = customerSearch.ShowDialog();

                if (result == DialogResult.OK)
                {
                    customersLoadCustomer(customerSearch.returnedID); //Load Customer IF Selected
                }
                else
                {
                    changeTabState(Tabs.Customers, TabStates.Default);
                }

                customerSearch.Dispose();
            };
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
                    DialogResult emailCustomerQuery = MessageBox.Show("Do you want to email the customer with their details?", 
                        "Customer Registration Email", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                if (currentBranch.findCustomer(customerID) != null)
                {
                    changeTabState(Tabs.Customers, TabStates.Loaded_Customer);
                    Console.WriteLine(String.Format("Tab: Customers. Customer ID: {0}. Loaded.", customerID));

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

                    uiCustomersPurchasesListView.Items.AddRange(getPurchasesListViewItem(customerID));
                }
                else
                {
                    changeTabState(Tabs.Customers, TabStates.Default);
                    //Customer Creation Error
                    MessageBox.Show("Customer Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                uiCustomersFirstNameTextBox.Text = uiCustomersFirstNameTextBox.Text.Trim().ToLower().FirstCharToUpper();
                uiCustomersLastNameTextBox.Text = uiCustomersLastNameTextBox.Text.Trim().ToLower().FirstCharToUpper();
                uiCustomersEmailAddressTextBox.Text = uiCustomersEmailAddressTextBox.Text.Trim();
                uiCustomersMobileNoTextBox.Text = uiCustomersMobileNoTextBox.Text.Trim();
                uiCustomersPostCodeTextBox.Text = uiCustomersPostCodeTextBox.Text.Trim();
            }

            return valid;
        }

        //Customer General Events
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

        private void uiCustomersCustomerIDUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(uiCustomersCustomerIDUpDown.Text) && Generic.IsInteger(uiCustomersCustomerIDUpDown.Text))
            {
                customersSearchCustomer();
            }
        }

        private void uiCustomersCustomerNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(uiCustomersCustomerNameTextBox.Text))
            {
                DialogResult createCustomerDialog = MessageBox.Show("Do you wish to create this customer?",
                                                                    "New Customer",
                                                                     MessageBoxButtons.YesNo, 
                                                                     MessageBoxIcon.Question,
                                                                     MessageBoxDefaultButton.Button1);
                if (createCustomerDialog == DialogResult.Yes)
                {
                    customersNewCustomer();
                }
            }
        }

        private void uiCustomersPurchasesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (uiCustomersPurchasesListView.SelectedItems.Count > 0)
            {
                if (!currentBranch.newPurchaseView(int.Parse(uiCustomersPurchasesListView.SelectedItems[0].Text), 
                                                    int.Parse(uiCustomersCustomerIDUpDown.Text) 
                                                    ))
                {
                    MessageBox.Show("Purchase view failed to load.",
                        "Error",
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
            }
        }

        /// <summary>
        /// Inventory Tab Functions
        /// </summary>
        //Inventory Button Events
        private void uiInventoryFindSupplierButton_Click(object sender, EventArgs e)
        {
            inventorySearchSupplier();
        }

        private void uiInventoryNewSupplierButton_Click(object sender, EventArgs e)
        {
            inventoryCreateSupplier();
        }

        private void uiInventoryNewItem_Click(object sender, EventArgs e)
        {
            inventoryCreateItem();
        }

        private void uiInventoryRemoveItem_Click(object sender, EventArgs e)
        {
            inventoryRemoveItem();
        }

        //Inventory General Functions
        private void inventorySearchSupplier()
        {
            string initialSearch = "";

            if (!string.IsNullOrEmpty(uiInventorySupplierIDUpDown.Text))
            {
                initialSearch = uiInventorySupplierIDUpDown.Text;
            }

            using (genericSearch supplierSearch = new genericSearch(getSupplierListViewItems(), "Supplier", initialSearch))
            {
                var result = supplierSearch.ShowDialog();

                if (result == DialogResult.OK)
                {
                    changeTabState(Tabs.Inventory, TabStates.Default);
                    inventoryLoadSupplier(supplierSearch.returnedID); //Load Customer IF Selected
                }
                else
                {
                    changeTabState(Tabs.Customers, TabStates.Default);
                }

                supplierSearch.Dispose();
            };
        }

        private void inventoryCreateSupplier()
        {
            using (newSupplier suppliersSearch = new newSupplier())
            {
                var result = suppliersSearch.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var currentSuppplier = currentBranch.createSupplier(new Supplier(suppliersSearch.supplierName));
                    if (currentSuppplier.Success)
                    {
                        changeTabState(Tabs.Inventory, TabStates.Default);
                        inventoryLoadSupplier(currentSuppplier.supplierID); //Load newly created customer
                    }
                    else
                    {
                        //Supplier Creation Error
                        MessageBox.Show("Supplier Creation Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        changeTabState(Tabs.Inventory, TabStates.Default);
                    }
                }
                else
                {
                    changeTabState(Tabs.Inventory, TabStates.Default);
                }
                suppliersSearch.Dispose();
            };
        }

        private void inventoryLoadSupplier(int supplierID)
        {
            changeTabState(Tabs.Inventory, TabStates.Default);
            groupBoxControlsEnabled(uiInventorySupplierItemsGroupBox, true);
            Console.WriteLine(String.Format("Tab: Inventory. Supplier ID: {0}. Loaded.", supplierID));

            uiInventorySupplierIDUpDown.Text = supplierID.ToString();
            uiInventorySuppliersComboBox.SelectedIndex = supplierID-1;

            uiInventorySupplierItemsListView.Items.AddRange(getSupplierItemsListViewItems(supplierID));
        }

        private void inventoryCreateItem()
        {
            using (itemSelector itemSelector = new itemSelector())
            {
                var result = itemSelector.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (itemSelector.accessoryTypeReturn == null)
                    {
                        //Standard Item Selected
                        if (!inventoryNewStandardItem(itemSelector.itemTypeReturn))
                        {
                            Console.WriteLine("Item Type Selection Error Occurred.");
                            MessageBox.Show("Item Type Selection Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        //Accessory Type Selected
                        if (!inventoryNewAccessoryItem(itemSelector.accessoryTypeReturn))
                        {
                            Console.WriteLine("Accessory Item Type Selection Error Occurred.");
                            MessageBox.Show("Accessory Item Type Selection Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                itemSelector.Dispose();
            };
        }

        private bool inventoryNewStandardItem(Item.Type type)
        {
            if (type == Item.Type.Clothing)
            {
                if (!newClothing(uiInventorySupplierIDUpDown.Text, uiInventorySuppliersComboBox.Text))
                {
                    return false;
                }
                return true;
            } else if (type == Item.Type.Shoe)
            {   
                if (!newShoe(uiInventorySupplierIDUpDown.Text, uiInventorySuppliersComboBox.Text))
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool inventoryNewAccessoryItem(Accessory.accessoryType? type)
        {
            if (type != null)
            {
                if (type == Accessory.accessoryType.Bag)
                {
                    if (!newBag(uiInventorySupplierIDUpDown.Text, uiInventorySuppliersComboBox.Text))
                    {
                        return false;
                    }
                    return true;
                } else if (type == Accessory.accessoryType.Nutrition)
                {
                    if (!newNutrition(uiInventorySupplierIDUpDown.Text, uiInventorySuppliersComboBox.Text))
                    {
                        return false;
                    }
                    return true;
                } else if (type == Accessory.accessoryType.Watch)
                {
                    if (!newWatch(uiInventorySupplierIDUpDown.Text, uiInventorySuppliersComboBox.Text))
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void inventoryRemoveItem()
        {
            if (uiInventorySupplierItemsListView.SelectedItems.Count > 0)
            {
                int productID = int.Parse(uiInventorySupplierItemsListView.SelectedItems[0].Text);

                if (!currentBranch.checkIfProductSold(productID))
                {
                    //If Not Sold to any Customer - Remove Item from List
                    if (!currentBranch.removeProduct(productID))
                    {
                        MessageBox.Show("Product Removal Failure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Product Removed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        changeTabState(Tabs.Inventory, TabStates.Default);
                    }
                }
                else
                {
                    //If Sold to any Customer - Remove Item From Product Availability
                    currentBranch.findProduct(productID).availableForSale = false;
                    MessageBox.Show("Product Removed from Sale", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    changeTabState(Tabs.Inventory, TabStates.Default);
                }
            }
        }

        //Inventory General Events
        private void uiInventorySuppliersComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (uiInventorySuppliersComboBox.SelectedIndex > -1)
            {
                inventoryLoadSupplier(uiInventorySuppliersComboBox.SelectedIndex+1);
            }
        }

        private void uiInventorySupplierIDUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(uiInventorySupplierIDUpDown.Text) && Generic.IsInteger(uiInventorySupplierIDUpDown.Text))
            {
                inventorySearchSupplier();
            }
        }

        private void uiInventorySupplierItemsListView_DoubleClick(object sender, EventArgs e)
        {
            if (uiInventorySupplierItemsListView.SelectedItems.Count > 0)
            {
                currentBranch.newViewItemForm(int.Parse(uiInventorySupplierItemsListView.SelectedItems[0].Text));
            }
        }

        /// <summary>
        /// Admin Tab Functions
        /// </summary>
        //Admin Button Events

        //Admin General Functions

        //Admin General Events

        //Form-wide
        //Form-wide Functions
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

        public ListViewItem[] getCustomerListViewItems()
        {
            var customerListingListViewItems = new List<ListViewItem>();

            foreach (var customer in currentBranch.MCustomers())
            {
                ListViewItem customerItem = new ListViewItem(customer.ID().ToString());
                customerItem.SubItems.Add(customer.FullName());
                customerListingListViewItems.Add(customerItem);
            }

            return customerListingListViewItems.ToArray();
        }

        public ListViewItem[] getBasketListViewItems()
        {

        var productListingListViewItems = new List<ListViewItem>();
        var itemsAdded = new List<Item>();

            var currentBasketDuplicates = currentBasket
                .GroupBy(i => i)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            foreach (Item item in currentBasket)
            {
                if ((currentBasketDuplicates.Contains(item) && !itemsAdded.Contains(item)) ||
                    !currentBasketDuplicates.Contains(item))
                {
                    var itemQuantity = 0;

                    //If Multiple of Item Count Instances otherwise assume one item selected
                    if (currentBasketDuplicates.Contains(item))
                    {
                        itemQuantity = currentBasket.Count(Item => currentBasketDuplicates.Contains(item) && Item == item);
                    }
                    else
                    {
                        itemQuantity = 1;
                    }

                    ListViewItem productItem = new ListViewItem(item.ID.ToString());
                    productItem.SubItems.Add(item.Name);
                    productItem.SubItems.Add(itemQuantity.ToString());
                    productItem.SubItems.Add(item.Cost.ToString("C2"));
                    productItem.SubItems.Add((itemQuantity * item.Cost).ToString("C2"));

                    itemsAdded.Add(item);
                    productListingListViewItems.Add(productItem);
                }
            }

            return productListingListViewItems.ToArray();
        }

        public ListViewItem[] getPurchasesListViewItem(int customerID)
        {
            var customerListingListViewItems = new List<ListViewItem>();

            foreach (var customer in currentBranch.MCustomers())
            {
                if (customer.ID() == customerID)
                {
                    foreach (var purchase in customer.MPurchases)
                    {
                        ListViewItem purchaseItem = new ListViewItem(purchase.ID.ToString());
                        purchaseItem.SubItems.Add(purchase.PurchaseDate.ToString("dd/MM/yyyy hh:mm tt"));
                        purchaseItem.SubItems.Add(purchase.OrderTotalCost.ToString("C2"));
                        customerListingListViewItems.Add(purchaseItem);
                    }
                }
            }

            return customerListingListViewItems.ToArray();
        }

        public ListViewItem[] getProductListViewItems()
        {
            var productListingListViewItems = new List<ListViewItem>();

            foreach (Supplier supplier in currentBranch.MSuppliers())
            {
                foreach (var product in supplier.MProducts())
                {
                    ListViewItem productItem = new ListViewItem(product.ID.ToString());
                    productItem.SubItems.Add(product.Name);
                    productListingListViewItems.Add(productItem);
                }
            }

            return productListingListViewItems.ToArray();
        }

        public ListViewItem[] getSupplierListViewItems()
        {
            var supplierListingListViewItems = new List<ListViewItem>();

            foreach (var supplier in currentBranch.MSuppliers())
            {
                ListViewItem supplierItem = new ListViewItem(supplier.ID().ToString());
                supplierItem.SubItems.Add(supplier.Name());
                supplierListingListViewItems.Add(supplierItem);
            }

            return supplierListingListViewItems.ToArray();
        }

        public ListViewItem[] getSupplierItemsListViewItems(int supplierID)
        {
            var itemsListingListViewItems = new List<ListViewItem>();

            foreach (var supplier in currentBranch.MSuppliers())
            {
                if (supplier.ID() == supplierID)
                {
                    foreach (Item item in supplier.MProducts())
                    {
                        ListViewItem supplierItem = new ListViewItem(item.ID.ToString() ?? "Not Found");
                        
                        supplierItem.UseItemStyleForSubItems = false;

                        supplierItem.SubItems.Add(item.Name ?? "Not Found");
                        supplierItem.SubItems.Add(item.ItemType.ToString() ?? "Not Found");
                        supplierItem.SubItems.Add(item.Cost.ToString("C2") ?? "Not Found");

                        if (item.availableForSale)
                        {
                            supplierItem.SubItems.Add("✓");
                            supplierItem.SubItems[supplierItem.SubItems.Count-1].ForeColor = Color.Green;
                        }
                        else
                        {
                            supplierItem.SubItems.Add("X");
                            supplierItem.SubItems[supplierItem.SubItems.Count-1].ForeColor = Color.Red;
                        }

                        supplierItem.SubItems.Add(item.StockLevel.ToString() ?? "Not Found");
                        supplierItem.SubItems.Add(item.RestockLevel.ToString() ?? "Not Found");
                        
                        if (item.Restock())
                        {
                            supplierItem.SubItems.Add("✓");
                            supplierItem.SubItems[supplierItem.SubItems.Count-1].ForeColor = Color.Green;
                        }
                        else
                        {
                            supplierItem.SubItems.Add("X");
                            supplierItem.SubItems[supplierItem.SubItems.Count-1].ForeColor = Color.Red;
                        }

                        itemsListingListViewItems.Add(supplierItem);
                    }
                }

            }
            return itemsListingListViewItems.ToArray();
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
                            //Element 1
                            uiSaleCustomerIDUpDown.ResetText();
                            uiSaleCustomerIDUpDown.Enabled = true;
                            uiSaleCustomerIDUpDown.Focus();

                            //Element 2
                            uiSaleCustomerNameTextBox.Clear();
                            uiSaleCustomerNameTextBox.Enabled = true;

                            //Element 3
                            uiSaleNewCustomerButton.Enabled = true;
                            uiSaleCustomerSearchButton.Enabled = true;

                            //Element 4 (inside GroupBox Controls)
                            uiSaleViewItemButton.Enabled = false;
                            uiSaleCancelProductSelectionButton.Hide();

                            resetGroupBoxControls(uiSalePurchaseGroupBox);
                            groupBoxControlsEnabled(uiSalePurchaseGroupBox, false);

                            //Data Control
                            currentBasket.Clear();
                            break;
                        case TabStates.Loaded_Customer:
                            //Element 1
                            uiSaleCustomerIDUpDown.ResetText();
                            uiSaleCustomerIDUpDown.Enabled = false;

                            //Element 2
                            uiSaleCustomerNameTextBox.Clear();
                            uiSaleCustomerNameTextBox.Enabled = false;

                            //Element 3
                            uiSaleNewCustomerButton.Enabled = false;
                            uiSaleCustomerSearchButton.Enabled = false;

                            //Element 4
                            uiSaleCancelProductSelectionButton.Hide(); 

                            uiSaleProductIDUpDown.Focus();
                            resetGroupBoxControls(uiSalePurchaseGroupBox);
                            groupBoxControlsEnabled(uiSalePurchaseGroupBox, true);
                            uiSaleViewItemButton.Enabled = false;

                            saleLoadBasket();
                            break;
                        case TabStates.Loaded_Product:
                            //Element 3
                            uiSaleNewCustomerButton.Enabled = false;
                            uiSaleCustomerSearchButton.Enabled = false;

                            //Element 4
                            uiSaleProductIDUpDown.ResetText();
                            uiSaleProductIDUpDown.Enabled = false;

                            uiSaleProductNameTextBox.Clear();
                            uiSaleProductNameTextBox.Enabled = false;

                            uiSaleProductSearchButton.Enabled = false;
                            uiSaleViewItemButton.Enabled = true;

                            uiSaleCancelProductSelectionButton.Show();

                            saleLoadBasket();
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
                    switch (state)
                    {
                        case TabStates.Default:
                            //Element 1
                            uiInventorySuppliersComboBox.Items.Clear();
                            foreach (var supplier in currentBranch.MSuppliers()) {
                                uiInventorySuppliersComboBox.Items.Add(supplier.Name());
                            }
                            uiInventorySuppliersComboBox.Enabled = true;

                            //Element 2
                            uiInventorySupplierIDUpDown.ResetText();
                            uiInventorySupplierIDUpDown.Enabled = true;

                            //Element 5 - GroupBox
                            resetGroupBoxControls(uiInventorySupplierItemsGroupBox);
                            groupBoxControlsEnabled(uiInventorySupplierItemsGroupBox, false);
                            break;
                        default:
                            Console.WriteLine("Tab State Changed Failed.");
                            break;
                    }
                    break;
                case Tabs.Admin:
                    break;
                default:
                    break;
            }
        }

        //Form-wide New Form Instances
        private bool newClothing(string supplierIDString, string supplierNameString)
        {
            using (newClothing itemCreator = new newClothing(Item.Type.Clothing.ToString(), supplierNameString))
            {
                var result = itemCreator.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (int.TryParse(supplierIDString, out int supplierID))
                    {
                        var item = currentBranch.findSupplier(supplierID).newProduct(
                            new Clothing(itemCreator.itemNameReturn,
                                Item.Type.Clothing,
                                itemCreator.itemCostReturn,
                                itemCreator.stockLevelReturn,
                                itemCreator.restockLevelReturn,
                                itemCreator.clothingSize,
                                itemCreator.clothingColour,
                                itemCreator.clothingType));
                        if (item.Success)
                        {
                            inventoryLoadSupplier(supplierID);
                            itemCreator.Dispose();
                            return true;
                        }
                        else
                        {
                            itemCreator.Dispose();
                            return false;
                        }
                    } else
                    {
                        {
                            itemCreator.Dispose();
                            return false;
                        }
                    }
                }
                else
                {
                    itemCreator.Dispose();
                    return true;
                }
            };
        }

        private bool newShoe(string supplierIDString, string supplierNameString)
        {
            using (newShoe itemCreator = new newShoe(Item.Type.Shoe.ToString(), supplierNameString))
            {
                var result = itemCreator.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (int.TryParse(supplierIDString, out int supplierID))
                    {
                        var item = currentBranch.findSupplier(supplierID).newProduct(
                            new Shoe(itemCreator.itemNameReturn,
                                Item.Type.Shoe,
                                itemCreator.itemCostReturn,
                                itemCreator.stockLevelReturn,
                                itemCreator.restockLevelReturn,
                                itemCreator.shoeSize,
                                itemCreator.shoeType));
                        if (item.Success)
                        {
                            inventoryLoadSupplier(supplierID);
                            itemCreator.Dispose();
                            return true;
                        }
                        else
                        {
                            itemCreator.Dispose();
                            return false;
                        }
                    } else
                    {
                        {
                            itemCreator.Dispose();
                            return false;
                        }
                    }
                }
                else
                {
                    itemCreator.Dispose();
                    return true;
                }
            };
        }

        private bool newBag(string supplierIDString, string supplierNameString)
        {
            using (newBag itemCreator = new newBag(Accessory.accessoryType.Bag.ToString(), supplierNameString))
            {
                var result = itemCreator.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (int.TryParse(supplierIDString, out int supplierID))
                    {
                        var item = currentBranch.findSupplier(supplierID).newProduct(
                            new Bag(itemCreator.itemNameReturn,
                                Item.Type.Accessory,
                                itemCreator.itemCostReturn,
                                itemCreator.stockLevelReturn,
                                itemCreator.restockLevelReturn,
                                Accessory.accessoryType.Bag,
                                itemCreator.capacityReturn));
                        if (item.Success)
                        {
                            inventoryLoadSupplier(supplierID);
                            itemCreator.Dispose();
                            return true;
                        }
                        else
                        {
                            itemCreator.Dispose();
                            return false;
                        }
                    } else
                    {
                        {
                            itemCreator.Dispose();
                            return false;
                        }
                    }
                }
                else
                {
                    itemCreator.Dispose();
                    return true;
                }
            };
        }

        private bool newNutrition(string supplierIDString, string supplierNameString)
        {
            using (newNutrition itemCreator = new newNutrition(Accessory.accessoryType.Nutrition.ToString(), supplierNameString))
            {
                var result = itemCreator.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (int.TryParse(supplierIDString, out int supplierID))
                    {
                        var item = currentBranch.findSupplier(supplierID).newProduct(
                            new Nutrition(itemCreator.itemNameReturn,
                                Item.Type.Accessory,
                                itemCreator.itemCostReturn,
                                itemCreator.stockLevelReturn,
                                itemCreator.restockLevelReturn,
                                itemCreator.nutritionQuantity,
                                Accessory.accessoryType.Nutrition,
                                itemCreator.nutritionType));
                        if (item.Success)
                        {
                            inventoryLoadSupplier(supplierID);
                            itemCreator.Dispose();
                            return true;
                        }
                        else
                        {
                            itemCreator.Dispose();
                            return false;
                        }
                    } else
                    {
                        {
                            itemCreator.Dispose();
                            return false;
                        }
                    }
                }
                else
                {
                    itemCreator.Dispose();
                    return true;
                }
            };
        }

        private bool newWatch(string supplierIDString, string supplierNameString)
        {
            using (newWatch itemCreator = new newWatch(Accessory.accessoryType.Nutrition.ToString(), supplierNameString))
            {
                var result = itemCreator.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (int.TryParse(supplierIDString, out int supplierID))
                    {
                        var item = currentBranch.findSupplier(supplierID).newProduct(
                            new Watch(itemCreator.itemNameReturn,
                                Item.Type.Accessory,
                                itemCreator.itemCostReturn,
                                itemCreator.stockLevelReturn,
                                itemCreator.restockLevelReturn,
                                Accessory.accessoryType.Watch,
                                itemCreator.watchType));
                        if (item.Success)
                        {
                            inventoryLoadSupplier(supplierID);
                            itemCreator.Dispose();
                            return true;
                        }
                        else
                        {
                            itemCreator.Dispose();
                            return false;
                        }
                    } else
                    {
                        {
                            itemCreator.Dispose();
                            return false;
                        }
                    }
                }
                else
                {
                    itemCreator.Dispose();
                    return true;
                }
            };
        }

        //Form-wide Events
        private void uiLogoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void posForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logging Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            } 
        }
    }
}
