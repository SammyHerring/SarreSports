//Project Name: SarreSports | File Name: Branch.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/12/2018 | 17:26
//Last Updated On:  11/1/2019 | 01:22
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SarreSports
{
    public class Branch : IBranch, IDisposable
    {
        //Branch Attributes
        private string branchName;
        private List<SystemUser> mUsers = new List<SystemUser>();
        private List<Customer> mCustomers = new List<Customer>();
        private List<Supplier> mSuppliers  = new List<Supplier>();

        private static List<bool> UsedCounter = new List<bool>();
        private static object Lock = new object();
        
        public int ID { get; private set; }

        //Branch Constructor /w System Users being passed
        public Branch(string branchName, List<SystemUser> mUsers)
        {
            this.branchName = branchName; //Set Branch Name Attribute
            this.mUsers = mUsers; //Set System Users List
            lock (Lock)
            {
                int nextIndex = GetAvailableIndex();
                if (nextIndex == -1)
                {
                    nextIndex = UsedCounter.Count;
                    UsedCounter.Add(true);
                }
                else
                {
                    UsedCounter[nextIndex] = true;
                }
                ID = nextIndex;
            }
        }

        public string BranchName()
        {
            return branchName;
        }

        /// <summary>
        /// Customer
        /// </summary>
        /// <returns></returns>
        //Customer General Methods
        public (bool Success, int customerID) createCustomer(Customer customer)
        {
            if (!(customer is null))
            {
                try
                {
                    mCustomers.Add(customer);
                    return (true, customer.ID());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(String.Format("Error: {0}",ex.Message));
                    return (false, -1);
                }
            }
            else
            {
                return (false, -1);
            }
        }

        public Customer findCustomer(int customerID)
        {
            foreach (var customer in mCustomers)
            {
                if (customer.ID() == customerID) return customer;
            }

            return null;
        }

        public bool emailCustomer(int customerID)
        {
            try
            {
                return findCustomer(customerID).SendCustomerDetails(this);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found. Email failed.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        public (bool success, int purchaseID, decimal purchaseCost) purchaseCustomer(int customerID, List<Item> currentBasket)
        {
            var currentCustomer = findCustomer(customerID);
            if (currentCustomer != null)
            {
                decimal orderTotalCost = 0.0m;

                foreach (var item in currentBasket)
                {
                    if (!item.sell(1))
                    {
                        return (false, -1, -1.0m);
                    }
                    else
                    {
                        orderTotalCost += item.Cost;
                    }
                }

                var customerPurchaseOrder = currentCustomer.newPurchase(DateTime.Now, currentBasket, orderTotalCost);

                if (customerPurchaseOrder.success)
                {
                    return (true, customerPurchaseOrder.purchaseID, orderTotalCost);
                }
                else
                {
                    return (false, -1, -1.0m);
                }
            }
            else
            {
                return (false, -1, -1.0m);
            }
        }

        public bool newPurchaseView(int purchaseID, int customerID)
        {
            try
            {
                Customer customer = findCustomer(customerID);
                Purchase purchase = customer.findPurchase(purchaseID);
                if (customer != null && purchase != null)
                {
                    using (viewPurchaseOrder purchasesOrderView = new viewPurchaseOrder(purchaseID.ToString(),
                        customer.FullName(),
                        purchase.PurchaseDate,
                        purchase.OrderTotalCost,
                        getPurchaseViewListItems(purchase.MItems)))
                    {
                        var result = purchasesOrderView.ShowDialog();
                        purchasesOrderView.Dispose();
                    };
                    return true;
                }
                else
                {
                    Console.WriteLine("New Purchase View Loading Error.");
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }

        private ListViewItem[] getPurchaseViewListItems(List<Item> items)
        {
            var productListingListViewItems = new List<ListViewItem>();
            var itemsAdded = new List<Item>();

            var currentBasketDuplicates = items
                .GroupBy(i => i)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            foreach (Item item in items)
            {
                if ((currentBasketDuplicates.Contains(item) && !itemsAdded.Contains(item)) ||
                    !currentBasketDuplicates.Contains(item))
                {
                    var itemQuantity = 0;

                    //If Multiple of Item Count Instances otherwise assume one item selected
                    if (currentBasketDuplicates.Contains(item))
                    {
                        itemQuantity = items.Count(Item => currentBasketDuplicates.Contains(item) && Item == item);
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

        //Customer Attribute Accessor Methods
        public string getFullName(int customerID)
        {
            try
            {
                return findCustomer(customerID).FullName();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return null;
            }
        }

        public string getFirstName(int customerID)
        {
            try
            {
                return findCustomer(customerID).FirstName;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return null;
            }
        }

        public bool setFirstName(int customerID, string firstName)
        {
            try
            {
                findCustomer(customerID).FirstName = firstName;
                return true;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        public string getLastName(int customerID)
        {
            try
            {
                return findCustomer(customerID).LastName;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return null;
            }
        }

        public bool setLastName(int customerID, string lastName)
        {
            try
            {
                findCustomer(customerID).LastName = lastName;
                return true;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        public string getEmailAddress(int customerID)
        {
            try
            {
                return findCustomer(customerID).Email;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return null;

            }
        }

        public bool setEmailAddress(int customerID, string emailAddress)
        {
            try
            {
                findCustomer(customerID).Email = emailAddress;
                return true;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        public string getMobileNo(int customerID)
        {
            try
            {
                return findCustomer(customerID).MobileNo;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return null;
            }
        }
    
        public bool setMobileNo(int customerID, string mobileNo)
        {
            try
            {
                findCustomer(customerID).MobileNo = mobileNo;
                return true;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        public string getPostCode(int customerID)
        {
            try
            {
                return findCustomer(customerID).PostCode;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return null;
            }
        }

        public bool setPostCode(int customerID, string postCode)
        {
            try
            {
                findCustomer(customerID).PostCode = postCode;
                return true;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        public bool? getGDPR(int customerID)
        {
            try
            {
                return findCustomer(customerID).GDPR;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return null;
            }
        }

        public bool setGDPR(int customerID, bool GDPR)
        {
            try
            {
                findCustomer(customerID).GDPR = GDPR;
                return true;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer Not Found.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        /// <summary>
        /// Supplier
        /// </summary>
        //Supplier General Methods
        public (bool Success, int supplierID) createSupplier(Supplier supplier)
        {
            if (!(supplier is null))
            {
                try
                {
                    mSuppliers.Add(supplier);
                    return (true, supplier.ID());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(String.Format("Error: {0}",ex.Message));
                    return (false, -1);
                }
            }
            else
            {
                return (false, -1);
            }
        }

        public Supplier findSupplier(int supplierID)
        {
            foreach (var supplier in mSuppliers)
            {
                if (supplier.ID() == supplierID) return supplier;
            }

            return null;
        }

        /// <summary>
        /// Product
        /// </summary>
        //Product General Method
        public Item findProduct(int productID)
        {
            foreach (Supplier supplier in mSuppliers)
            {
                foreach (var product in supplier.MProducts())
                {
                    if (product.ID == productID) return product;
                }
            }

            return null;
        }

        public Predicate<Item> predicateProduct(int productID)
        {
            return Item => Item.ID == productID;
        }

        public bool removeProduct(int productID)
        {
            foreach (Supplier supplier in mSuppliers)
            {
                foreach (var product in supplier.MProducts())
                {
                    if (product.ID == productID)
                    {
                        supplier.MProducts().Remove(product);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool productCheckStockAndAvaliability(Item product, int quantity) => (product.availableForSale && quantity <= product.StockLevel);

        public Supplier findProductSupplier(int productID)
        {
            foreach (Supplier supplier in mSuppliers)
            {
                foreach (var product in supplier.MProducts())
                {
                    if (product.ID == productID) return supplier;
                }
            }

            return null;
        }

        public bool checkIfProductSold(int productID)
        {
            foreach (Customer customer in mCustomers)
            {
                foreach (Purchase purchase in customer.MPurchases)
                {
                    foreach (Item item in purchase.MItems)
                    {
                        if (item.ID == productID) return true;
                    }
                }
            }

            return false;
        }

        //Product Form Methods
        public (bool success, int valueReturn) newViewItemForm(int productID, viewItem.viewItemState state = viewItem.viewItemState.View)
        {
            Item.Type? type = findProductType(productID);
            Accessory.accessoryType? accessoryType = null;

            if (type == null)
            {
                return (false, -1);
            }
            
            if (type == Item.Type.Accessory)
            {
                accessoryType = findAccessoryType(productID);
                if (accessoryType == null)
                {
                    return (false, -1);
                }
            }

            if (type == Item.Type.Accessory && accessoryType != null)
            {
                if (accessoryType == Accessory.accessoryType.Bag)
                {
                    return newViewBagForm(productID, state);
                } else if (accessoryType == Accessory.accessoryType.Nutrition)
                {
                    return newViewNutritionForm(productID, state);
                } else if (accessoryType == Accessory.accessoryType.Watch)
                {
                    return newViewWatchForm(productID, state);
                }
                else
                {
                    //Failure to Select Type
                    return (false, -1);
                }
            }
            else
            {
                if (type == Item.Type.Clothing)
                {
                    return newViewClothingForm(productID, state);
                } else if (type == Item.Type.Shoe)
                {
                    return newViewShoeForm(productID, state);
                }
                else
                {
                    //Failed to Select Type
                    return (false, -1);
                }
            }
        }

        private (bool success, int valueReturn) newViewBagForm(int productID, viewItem.viewItemState state)
        {
            using (viewBag itemCreator = new viewBag(productID, this, state))
            {
                var result = itemCreator.ShowDialog();

                if (result == DialogResult.OK)
                {
                    itemCreator.Dispose();
                    return (true, itemCreator.valueReturn);
                }
                else
                {
                    itemCreator.Dispose();
                    return (false, -1);
                }
            };
        }

        private (bool success, int valueReturn) newViewClothingForm(int productID, viewItem.viewItemState state)
        {
            using (viewClothing itemCreator = new viewClothing(productID, this, state))
            {
                var result = itemCreator.ShowDialog();

                if (result == DialogResult.OK)
                {
                    itemCreator.Dispose();
                    return (true, itemCreator.valueReturn);
                }
                else
                {
                    itemCreator.Dispose();
                    return (false, -1);
                }
            };
        }

        private (bool success, int valueReturn) newViewNutritionForm(int productID, viewItem.viewItemState state)
        {
            using (viewNutrition itemCreator = new viewNutrition(productID, this, state))
            {
                var result = itemCreator.ShowDialog();

                if (result == DialogResult.OK)
                {
                    itemCreator.Dispose();
                    return (true, itemCreator.valueReturn);
                }
                else
                {
                    itemCreator.Dispose();
                    return (false, -1);
                }
            };
        }

        private (bool success, int valueReturn) newViewShoeForm(int productID, viewItem.viewItemState state)
        {
            using (viewShoe itemCreator = new viewShoe(productID, this, state))
            {
                var result = itemCreator.ShowDialog();

                if (result == DialogResult.OK)
                {
                    itemCreator.Dispose();
                    return (true, itemCreator.valueReturn);
                }
                else
                {
                    itemCreator.Dispose();
                    return (false, -1);
                }
            };
        }
       
        private (bool success, int valueReturn) newViewWatchForm(int productID, viewItem.viewItemState state)
        {
            using (viewWatch itemCreator = new viewWatch(productID, this, state))
            {
                var result = itemCreator.ShowDialog();

                if (result == DialogResult.OK)
                {
                    itemCreator.Dispose();
                    return (true, itemCreator.valueReturn);
                }
                else
                {
                    itemCreator.Dispose();
                    return (false, -1);
                }
            };
        }

        private Item.Type? findProductType(int productID)
        {
            try
            {
                return findProduct(productID).ItemType;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Accessory.accessoryType? findAccessoryType(int productID)
        {
            try
            {
                var product = (Accessory) findProduct(productID);
                return product.AccessoryType;
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// Branch
        /// </summary>
        /// <returns></returns>

        public int addSystemUser(SystemUser user)
        {
            mUsers.Add(user);
            return mUsers.Last().SystemUID;
        }

        //Branch List Accessors
        public List<SystemUser> MUsers()
        {
            return mUsers;
        }

        public List<Customer> MCustomers()
        {
            return mCustomers;
        }

        public List<Supplier> MSuppliers()
        {
            return mSuppliers;
        }

        //Branch Identifer Methods
        public void Dispose()
        {
            lock (Lock)
            {
                UsedCounter[ID] = false;
            }
        }

        private int GetAvailableIndex()
        {
            for (int i = 0; i < UsedCounter.Count; i++)
            {
                if (UsedCounter[i] == false)
                {
                    return i;
                }
            }

            return -1; //No IDs avaliable
        }
    }
}
