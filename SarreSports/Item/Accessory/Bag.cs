//Project Name: SarreSports | File Name: Bag.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 3/1/2019 | 14:11
//Last Updated On:  4/1/2019 | 14:22
namespace SarreSports
{
    public class Bag : Accessory
    {
        private int capacity;

        public Bag(string name, Type itemType, decimal cost, int stockLevel, int restockLevel, int capacity, accessoryType accessoryType) :
            base(name, itemType, cost, stockLevel, restockLevel, accessoryType)
        {
            this.capacity = capacity;
        }
    }
}