﻿//Project Name: SarreSports | File Name: NullBranch.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/12/2018 | 17:26
//Last Updated On:  8/1/2019 | 01:04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarreSports
{
    class NullBranch : IBranch
    {
        //Disable Null Reference Instance Warning which occurs as the instance only occurs in null call instances not allowed in runtime
        #pragma warning disable 649
        private static NullBranch _instance;
        #pragma warning restore 649

        private NullBranch()
        {
        }

        public static NullBranch Instance  
        {  
            get {  
                if (_instance == null)  
                    return new NullBranch();  
                return _instance;  
            }  
        }

        public string BranchName()
        {
            return "Null Branch";
        }

        public List<SystemUser> MUsers()
        {
            return new List<SystemUser>();
        }
    }
}
