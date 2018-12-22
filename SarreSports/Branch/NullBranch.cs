//Project Name: SarreSports | File Name: NullBranch.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/12/2018 | 17:26
//Last Updated On:  20/12/2018 | 14:44
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarreSports
{
    class NullBranch : IBranch
    {
        private static NullBranch _instance;

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
