//Project Name: SarreSports | File Name: Purchase.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 12/12/2018 | 17:02
//Last Updated On:  9/1/2019 | 02:25
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SarreSports
{
    public class Purchase
    {
        private static int nextID;
        private readonly int id;
        private DateTime purchaseDate;
        private decimal orderTotalCost;

        List<Item> mItems;

        public Purchase(DateTime purchaseDate, List<Item> mItems, decimal orderTotalCost)
        {
            this.id = Interlocked.Increment(ref nextID);
            this.purchaseDate = purchaseDate;
            this.mItems = new List<Item>(mItems);
            this.orderTotalCost = orderTotalCost;
        }

        public int ID => id;
        public DateTime PurchaseDate => purchaseDate;
        public List<Item> MItems => mItems;
        public decimal OrderTotalCost => orderTotalCost;
    }
}
