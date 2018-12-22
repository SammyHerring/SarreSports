//Project Name: SarreSports | File Name: PoS.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 3/12/2018 | 23:46
//Last Updated On:  20/12/2018 | 14:44
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarreSports
{
    class PoS
    {
        private List<Branch> mBranches = new List<Branch>();
        private List<SystemUser> defaultUsers = new List<SystemUser>(); //Default List of Users for Testing

        public PoS()
        {
            defaultUsers.Add(new SystemUser("clerk", "123", SystemUser.UserType.Clerk, "Sarre", "Clerk"));
            defaultUsers.Add(new SystemUser("manager", "abc", SystemUser.UserType.Manager, "Sarre", "Manager"));
            defaultUsers.Add(new SystemUser("admin", "admin", SystemUser.UserType.Admin, "System", "Administrator"));
            mBranches.Add(new Branch("Sarre Running Sport UK", defaultUsers));
            //Additional Branches May be Implemented for Testing
            //mBranches.Add(new Branch("Sarre Running Sport US", defaultUsers));
            //mBranches.Add(new Branch("Sarre Running Sport Canada", defaultUsers));
        }

        public List<Branch> MBranches()
        {
            return mBranches;
        }

        public List<SystemUser> MUsers(IBranch branch)
        {
            if (!(findBranchReference(branch) is NullBranch))
            {
                return branch.MUsers();
            }
            return null;
        }

        private IBranch findBranchReference(IBranch branchRef)
        {
            IBranch branchReturn = NullBranch.Instance;
            foreach (var branch in MBranches())
            {
                if (branch == branchRef)
                {
                    branchReturn = branch;
                }
            }
            return branchReturn;
        }
    }
}
