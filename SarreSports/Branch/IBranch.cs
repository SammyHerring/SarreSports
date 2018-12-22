//Project Name: SarreSports | File Name: IBranch.cs
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
    public interface IBranch
    {
        string BranchName();
        List<SystemUser> MUsers();
    }
}
