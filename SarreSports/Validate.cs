//Project Name: SarreSports | File Name: Validate.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 18/12/2018 | 17:10
//Last Updated On:  11/1/2019 | 01:08
using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SarreSports
{
    //Internal Validation Classes may be utilised by other methods
    internal class ValidateValue
    {
        /// <summary>
        /// Name Validation | Ensure every character of the string is a letter
        /// </summary>
        /// <param name="name">Name String</param>
        /// <returns>Valid String Boolean</returns>
        public static bool name(string name)
        {
             return (name.All(char.IsLetter));
        }

        /// <summary>
        /// Full Name Validation | Ensure every character of a string is a letter or space
        /// Full Name Validation also appropriate for multiple last names
        /// </summary>
        /// <param name="fullName">Full Name String</param>
        /// <returns>Valid String Boolean</returns>
        public static bool fullName(string fullName)
        {
            return (Regex.IsMatch(fullName, @"^[A-Za-z\s]*$"));
        }

        /// <summary>
        /// Post Code Validation | Ensure the string is a UK PostCode
        /// </summary>
        /// <param name="postCode">PostCode String</param>
        /// <returns>Valid String Boolean</returns>
        public static bool postCode(string postCode)
        {
            var postcodePattern = "^([A-Z]{1,2})([0-9][0-9A-Z]?) ([0-9])([ABDEFGHJLNPQRSTUWXYZ]{2})$";
            var postcodeRegex = new Regex(postcodePattern, RegexOptions.IgnoreCase);
            foreach (var i in postCode)
            {
                if (!postcodeRegex.IsMatch(postCode)) return false;
            }
            return true;
        }

        /// <summary>
        /// Mobile No Validation | Ensure the string is an 11 Character Integer
        /// </summary>
        /// <param name="mobileNo">Mobile No String</param>
        /// <returns>Valid String Boolean</returns>
        public static bool mobileNo(string mobileNo)
        {
            return (Regex.Match(mobileNo, @"^[0-9]{11}$").Success);
        }

        /// <summary>
        /// Email Address Validation | Validate email addresses by trying to create a MailAddress object
        /// </summary>
        /// <param name="emailAddress">Email Address string</param>
        /// <returns>Valid String Boolean</returns>
        public static bool emailAddress(string emailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    //Custom Validation Exception Handler Classes
    [Serializable]
    class InvalidPostCodeException : Exception
    {
        public InvalidPostCodeException()
        {

        }

        public InvalidPostCodeException(string postCode)
            : base(String.Format("Invalid PostCode Format: {0}", postCode))
        {

        }
  
    }

    [Serializable]
    class InvalidMobileNoExeption : Exception
    {
        public InvalidMobileNoExeption()
        {

        }

        public InvalidMobileNoExeption(string mobileNo)
            : base(String.Format("Invalid Mobile No Format: {0}", mobileNo))
        {

        }
    }

    [Serializable]
    class InvalidEmailAddressException : Exception
    {
        public InvalidEmailAddressException()
        {

        }

        public InvalidEmailAddressException(string emailAddress)
            : base(String.Format("Invalid Email Address Format: {0}", emailAddress))
        {

        }
    }

    [Serializable]
    class InvalidNameException : Exception
    {
        public InvalidNameException()
        {

        }

        public InvalidNameException(string name)
            : base(String.Format("Invalid Name: {0}", name))
        {

        }
    }
}