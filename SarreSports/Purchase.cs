//Project Name: SarreSports | File Name: Purchase.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 12/12/2018 | 17:02
//Last Updated On:  20/12/2018 | 18:40
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SarreSports
{
    class Purchase
    {
        private static int nextID;
        private readonly int id;
        List<Item> mItems = new List<Item>();

        public Purchase(List<Item> mItems)
        {
            this.id = Interlocked.Increment(ref nextID);
            this.mItems = mItems;
        }
    }
}
