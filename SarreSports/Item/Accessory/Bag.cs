//Project Name: SarreSports | File Name: Bag.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/1/2019 | 15:12
//Last Updated On:  11/1/2019 | 01:18
namespace SarreSports
{
    public class Bag : Accessory
    {
        //Bag Attribute
        private int capacity;

        //Bag Constructor
        public Bag(string name, Type itemType, decimal cost, int stockLevel, int restockLevel, accessoryType accessoryType, int capacity) :
            base(name, itemType, cost, stockLevel, restockLevel, accessoryType)
        {
            this.capacity = capacity;
        }

        //Bag Accessor
        public int Capacity => capacity;
    }
}