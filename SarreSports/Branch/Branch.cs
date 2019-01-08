//Project Name: SarreSports | File Name: Branch.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/12/2018 | 17:26
//Last Updated On:  7/1/2019 | 22:41
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
        private string branchName;
        private List<SystemUser> mUsers = new List<SystemUser>();
        private List<Customer> mCustomers = new List<Customer>();
        private List<Supplier> mSuppliers  = new List<Supplier>();

        private static List<bool> UsedCounter = new List<bool>();
        private static object Lock = new object();
        
        public int ID { get; private set; }

        //Instance Constructor /w System Users being passed
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

        //Product General Methods
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

        //public Item purchaseProduct

        //Product Form Methods
        public (bool success, int valueReturn) newViewItemForm(int productID, Item.Type type, Accessory.accessoryType? accessoryType, viewItem.viewItemState state = viewItem.viewItemState.View)
        {
            if (type == Item.Type.Accessory && accessoryType != null)
            {
                if (accessoryType == Accessory.accessoryType.Bag)
                {
                    return newViewBagForm(productID, this, state);
                } else if (accessoryType == Accessory.accessoryType.Nutrition)
                {
                    return (false, -1);
                } else if (accessoryType == Accessory.accessoryType.Watch)
                {
                    return (false, -1);
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
                    return (false, -1);
                } else if (type == Item.Type.Shoe)
                {
                    return (false, -1);
                }
                else
                {
                    //Failed to Select Type
                    return (false, -1);
                }
            }
        }

        private (bool success, int valueReturn) newViewBagForm(int productID, Branch currentBranch, viewItem.viewItemState state)
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
