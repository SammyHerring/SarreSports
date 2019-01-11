//Project Name: SarreSports.UnitTests | File Name: ItemTests.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 10/1/2019 | 14:44
//Last Updated On:  10/1/2019 | 15:05
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SarreSports.UnitTests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void Sell_NegativeQuantity_ReturnsFalse()
        {
            var item = new Clothing("Test Clothing", Item.Type.Clothing, 10.0m, 10, 5, 20, "Black", Clothing.clothingType.Jackets);

            var result = item.sell(-1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Sell_QuantityMoreThanStockLevel_ReturnsFalse()
        {
            var item = new Clothing("Test Clothing", Item.Type.Clothing, 10.0m, 10, 5, 20, "Black", Clothing.clothingType.Jackets);

            var result = item.sell(11);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Sell_QuantityLessThanStockLevel_ReturnsTrue()
        {
            var item = new Clothing("Test Clothing", Item.Type.Clothing, 10.0m, 10, 5, 20, "Black", Clothing.clothingType.Jackets);

            var result = item.sell(5);

            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void Sell_QuantityEqualToStockLevel_ReturnsTrue()
        {
            var item = new Clothing("Test Clothing", Item.Type.Clothing, 10.0m, 10, 5, 20, "Black", Clothing.clothingType.Jackets);

            var result = item.sell(10);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Sell_MultipleSalesLessThanStockLevel_ReturnsTrue()
        {
            var item = new Clothing("Test Clothing", Item.Type.Clothing, 10.0m, 10, 5, 20, "Black", Clothing.clothingType.Jackets);

            var result1 = item.sell(4);
            var result2 = item.sell(4);

            Assert.IsTrue(result1 && result2);
        }

        [TestMethod]
        public void Sell_MultipleSalesEqualToStockLevel_ReturnsTrue()
        {
            var item = new Clothing("Test Clothing", Item.Type.Clothing, 10.0m, 10, 5, 20, "Black", Clothing.clothingType.Jackets);

            var result1 = item.sell(5);
            var result2 = item.sell(5);

            Assert.IsTrue(result1 && result2);
        }

        [TestMethod]
        public void Sell_MultipleSalesMoreThanStockLevel_ReturnsFalse()
        {
            var item = new Clothing("Test Clothing", Item.Type.Clothing, 10.0m, 10, 5, 20, "Black", Clothing.clothingType.Jackets);

            var result1 = item.sell(6);
            var result2 = item.sell(6);

            Assert.IsTrue(result1 && !result2);
        }

        [TestMethod]
        public void Restock_StockLevelEqualToRestockLevel_ReturnsTrue()
        {
            var item = new Clothing("Test Clothing", Item.Type.Clothing, 10.0m, 10, 10, 20, "Black", Clothing.clothingType.Jackets);

            var result = item.Restock();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Restock_StockLevelGreaterThanRestockLevel_ReturnsFalse()
        {
            var item = new Clothing("Test Clothing", Item.Type.Clothing, 10.0m, 10, 5, 20, "Black", Clothing.clothingType.Jackets);

            var result = item.Restock();

            Assert.IsFalse(result);
        }
    }
}
