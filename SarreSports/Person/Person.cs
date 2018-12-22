//Project Name: SarreSports | File Name: Person.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/12/2018 | 18:18
//Last Updated On:  20/12/2018 | 14:44
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarreSports
{
    public abstract class Person
    {
        //Instance Attributes
        private string firstName;
        private string lastName;

        //Instance Constructor
        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get => firstName;

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (ValidateValue.name(value))
                    {
                        this.firstName = value;
                    }
                    else
                    {
                        throw new InvalidNameException(value);
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public string LastName
        {
            get => lastName;

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (ValidateValue.name(value))
                    {
                        this.lastName = value;
                    }
                    else
                    {
                        throw new InvalidNameException(value);
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }

            }

        }

        public string FullName()
        {
            return String.Format("{0} {1}", firstName, lastName);
        }
    }
}
