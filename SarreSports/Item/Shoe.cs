//Project Name: SarreSports | File Name: Shoe.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 12/12/2018 | 17:04
//Last Updated On:  11/1/2019 | 01:18
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarreSports
{
    public class Shoe : Item
    {
        //Shoe Attributes
        private decimal size;

        public enum shoeType
        {
            Racer = 0,
            Stability = 1, 
            Neutral = 2,
            Trail  = 3,
            Track = 4,
        }
        private shoeType type;

        //Shoe Constructor
        public Shoe(string name, Type itemType, decimal cost, int stockLevel, int restockLevel, decimal size, shoeType type) :
            base(name, itemType, cost, stockLevel, restockLevel)
        {
            this.size = size;
            this.type = type;
        }

        //Shoe Accessors
        public decimal Size => size;
        public shoeType ShoeType => type;
    }
}
