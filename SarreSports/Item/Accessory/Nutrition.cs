//Project Name: SarreSports | File Name: Nutrition.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/1/2019 | 15:12
//Last Updated On:  7/1/2019 | 15:29
namespace SarreSports
{
    public class Nutrition : Accessory
    {
        private int quantity;

        public enum nutritionType
        {
            Carbs = 0,
            Protein = 1,
        }
        private nutritionType type;

        public Nutrition(string name, Type itemType, decimal cost, int stockLevel, int restockLevel, int quantity, 
            accessoryType accessoryType, nutritionType type) :
            base(name, itemType, cost, stockLevel, restockLevel, accessoryType)
        {
            this.quantity = quantity;
            this.type = type;
        }

        public int Quantity => quantity;
        public nutritionType NutritionType => type;
    }
}