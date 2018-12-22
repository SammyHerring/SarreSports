//Project Name: SarreSports | File Name: Branch.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/12/2018 | 17:26
//Last Updated On:  20/12/2018 | 20:57
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

        public (bool Success, int customerID) createCustomer(Customer c)
        {
            if (!(c is null))
            {
                try
                {
                    mCustomers.Add(c);
                    return (true, c.ID());
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

        public List<SystemUser> MUsers()
        {
            return mUsers;
        }

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
