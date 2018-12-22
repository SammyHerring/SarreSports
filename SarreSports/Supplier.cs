//Project Name: SarreSports | File Name: Supplier.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 12/12/2018 | 17:02
//Last Updated On:  20/12/2018 | 14:45
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarreSports
{
    class Supplier
    {
        private string name;
        private List<Item> mItems = new List<Item>();

        public Supplier(string name)
        {
            this.name = name;
        }
    }
}
