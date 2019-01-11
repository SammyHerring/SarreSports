//Project Name: SarreSports | File Name: PoS.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 3/12/2018 | 23:46
//Last Updated On:  11/1/2019 | 01:10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarreSports
{
    public class PoS
    {
        //PoS Core Attributes
        private List<Branch> mBranches = new List<Branch>();
        private List<SystemUser> defaultUsers = new List<SystemUser>(); //Default List of Users for Testing

        //PoS Core Constructor
        public PoS()
        {
            defaultUsers.Add(new SystemUser("clerk", "123", SystemUser.UserType.Clerk, "Sarre", "Clerk"));
            defaultUsers.Add(new SystemUser("manager", "abc", SystemUser.UserType.Manager, "Sarre", "Manager"));
            defaultUsers.Add(new SystemUser("admin", "admin", SystemUser.UserType.Admin, "System", "Administrator"));
            mBranches.Add(new Branch("Sarre Running Sport UK", defaultUsers));

            //Additional Branches May be Implemented Manually for Testing -- uncomment two lines below
            //mBranches.Add(new Branch("Sarre Running Sport US", defaultUsers));
            //mBranches.Add(new Branch("Sarre Running Sport Canada", defaultUsers));
        }

        //PoS Core Accessors
        public List<Branch> MBranches => mBranches;

        public List<SystemUser> MUsers(IBranch branch)
        {
            if (!(findBranchReference(branch) is NullBranch))
            {
                return branch.MUsers();
            }
            return null;
        }

        public List<SystemUser> MUsers(int branchID)
        {
            foreach (var branch in mBranches)
            {
                if (branch.ID == branchID)
                {
                    return branch.MUsers();
                }
            }
            return null;
        }

        //PoS Core Methods
        public (bool Success, int branchID) createBranch(string branchName)
        {
            if (!(String.IsNullOrWhiteSpace(branchName)))
            {
                try
                {
                    mBranches.Add(new Branch(branchName, new List<SystemUser>()));
                    return (true, mBranches.Last().ID);
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

        public bool removeBranch(int branchID)
        {
            foreach (var branch in mBranches)
            {
                if (branch.ID == branchID)
                {
                    mBranches.Remove(branch);
                    return true;
                }
            }
            return false;
        }

        public (bool Success, int systemUID) createSystemUser(int branchID, SystemUser user)
        {
            if (!(user is null))
            {
                try
                {
                    foreach (var branch in MBranches)
                    {
                        if (branch.ID == branchID)
                        {
                            return (true, branch.addSystemUser(user));
                        }
                    }

                    return (false, -1);
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

        public bool removeUser(int branchID, int systemUID)
        {
            foreach (var branch in mBranches)
            {
                if (branch.ID == branchID)
                {
                    foreach (var user in branch.MUsers())
                    {
                        if (user.SystemUID == systemUID)
                        {
                            branch.MUsers().Remove(user);
                            return true;
                        }

                    }

                }
            }
            return false;
        }

        private IBranch findBranchReference(IBranch branchRef)
        {
            IBranch branchReturn = NullBranch.Instance;
            foreach (var branch in MBranches)
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
