//Project Name: SarreSports | File Name: Shoe.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 12/12/2018 | 17:04
//Last Updated On:  3/1/2019 | 14:04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarreSports
{
    public class Shoe : Item
    {
        private int size;

        public enum shoeType
        {
            Racer = 0,
            Stability = 1, 
            Neutral = 2,
            Trail  = 3,
            Track = 4
        }
        private shoeType type;

        public Shoe(string name, Type itemType, decimal cost, int stockLevel, int restockLevel, int size, shoeType type) :
            base(name, itemType, cost, stockLevel, restockLevel)
        {
            this.size = size;
            this.type = type;
        }
    }
}
