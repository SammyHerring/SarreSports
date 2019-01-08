//Project Name: SarreSports | File Name: Clothing.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 12/12/2018 | 17:04
//Last Updated On:  7/1/2019 | 15:24
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarreSports
{
    public class Clothing : Item
    {
        private int size;
        private string colour;

        public enum clothingType
        {
            Shorts = 0,
            Capris = 1,
            Leggings = 2,
            Vests = 3,
            Tops = 4,
            Jackets = 5,
        }
        private clothingType style;

        public Clothing(string name, Type itemType, decimal cost, int stockLevel, int restockLevel, int size, string colour, clothingType style) :
            base(name, itemType, cost, stockLevel, restockLevel)
        {
            this.size = size;
            this.colour = colour;
            this.style = style;
        }

        public int Size => size;
        public string Colour => colour;
        public clothingType Style => style;
    }
}
