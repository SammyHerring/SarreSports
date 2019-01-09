//Project Name: SarreSports | File Name: Item.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 12/12/2018 | 17:04
//Last Updated On:  8/1/2019 | 19:01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SarreSports
{
    public abstract class Item : IItem
    {
        private string name;
        private static int nextID;
        private readonly int id;

        public enum Type
        {
            Clothing = 0,
            Shoe = 1,
            Accessory = 2
        }
        private Type itemType;

        private decimal cost;
        private int stockLevel;
        private int restockLevel;
        //Avaliable For Sale - AutoProperty 

        public Item(string name, Type itemType, decimal cost, int stockLevel, int restockLevel)
        {
            this.name = name;
            this.id = Interlocked.Increment(ref nextID);
            this.itemType = itemType;
            this.cost = cost;
            this.stockLevel = stockLevel;
            this.restockLevel = restockLevel;
            this.availableForSale = true;
        }

        public string Name => name;
        public int ID => id;
        public Type ItemType => itemType;
        public decimal Cost => cost;
        public int StockLevel => stockLevel;
        public int RestockLevel => restockLevel;
        public bool Restock() => (restockLevel >= stockLevel);
        public bool availableForSale { get; set; }

        public bool sell(int quantity)
        {
            if (quantity <= stockLevel && quantity > 0)
            {
                stockLevel -= quantity;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
