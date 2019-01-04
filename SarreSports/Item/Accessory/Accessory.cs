//Project Name: SarreSports | File Name: Accessory.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/1/2019 | 02:35
//Last Updated On:  4/1/2019 | 14:49
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarreSports
{
    public abstract class Accessory : Item
    {
        public enum accessoryType
        {
            Bag = 0,
            Nutrition = 1,
            Watch = 2
        }

        public accessoryType AccessoryType { get; }

        public Accessory(string name, Type itemType, decimal cost, int stockLevel, int restockLevel, accessoryType AccessoryType) 
            : base(name, itemType, cost, stockLevel, restockLevel)
        {
        }
    }
}
