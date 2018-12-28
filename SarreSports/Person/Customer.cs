//Project Name: SarreSports | File Name: Customer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/12/2018 | 18:18
//Last Updated On:  28/12/2018 | 15:01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SarreSports
{
    public class Customer : Person
    {
        //GDPR - Auto Property Method below
        private static int nextID;
        private readonly int id;
        private string postCode;
        private string mobileNo;
        private string email;
        private List<Purchase> mPurchases = new List<Purchase>();

        public Customer(string firstName, string lastName, bool GDPR, string postCode, string mobileNo, string email) :
            base(firstName, lastName)
        {
            this.id = Interlocked.Increment(ref nextID);
            this.GDPR = GDPR;
            this.postCode = postCode;
            this.mobileNo = mobileNo;
            this.email = email;
        }

        public bool GDPR { get; set; }

        public int ID()
        {
            return id;
    }

        public string PostCode
        {
            get => postCode;

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (ValidateValue.postCode(value)) //change to try mechanism - not if!!!
                    {
                        this.postCode = value;
                    }
                    else
                    {
                        throw new InvalidPostCodeException(value);
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public string MobileNo
        {
            get => mobileNo;

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (ValidateValue.mobileNo(value))
                    {
                        this.mobileNo = value;
                    }
                    else
                    {
                        throw new InvalidMobileNoExeption(value);
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public string Email
        {
            get => email;

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (ValidateValue.emailAddress(value))
                    {
                        this.email = value;
                    }
                    else
                    {
                        throw new InvalidEmailAddressException(value);
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public bool SendCustomerDetails(Branch b)
        {
            return MailClient.SendCustomerDetailsToCustomer(this, b);
        }
    }
}
