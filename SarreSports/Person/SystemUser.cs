﻿//Project Name: SarreSports | File Name: SystemUser.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/12/2018 | 18:18
//Last Updated On:  9/1/2019 | 22:26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SarreSports
{
    public class SystemUser : Person
    {
        public enum UserType {Clerk, Manager, Admin};

        private static int nextUID;
        private readonly int systemUID;
        private string username;
        private string password;
        private UserType userType;

        public SystemUser(string username, string password, UserType userType, string firstName, string lastName) : 
            base(firstName, lastName)
        {
            this.systemUID = Interlocked.Increment(ref nextUID);
            this.username = username;
            this.password = password;
            this.userType = userType;
        }

        public int SystemUID => systemUID;

        public string Username()
        {
            return username;
        }

        public bool CheckPassword(string password) => (this.password == password);

        public UserType Type()
        {
            return userType;
        }
    }
}
