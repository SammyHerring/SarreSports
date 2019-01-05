//Project Name: SarreSports | File Name: Supplier.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 12/12/2018 | 17:02
//Last Updated On:  4/1/2019 | 23:38
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SarreSports
{
    public class Supplier
    {
        private string name;
        private static int nextID;
        private readonly int id;
        private List<Item> mProducts = new List<Item>();

        public Supplier(string name)
        {
            this.name = name;
            this.id = Interlocked.Increment(ref nextID);
            mProducts.Add(new Clothing("Goals", Item.Type.Clothing, 79.99m, 12, 10, 5, "Blue", Clothing.clothingType.Jackets));
            mProducts.Add(new Shoe("Goals", Item.Type.Shoe, 79.99m, 5, 10, 10, Shoe.shoeType.Track));
        }

        public string Name()
        {
            return name;
        }

        public int ID()
        {
            return id;
        }

        public (bool Success, int productID) newProduct(Item product)
        {
            if (!(product is null))
            {
                try
                {
                    mProducts.Add(product);
                    return (true, product.ID);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(String.Format("Error: {0}",ex.Message));
                    return (false, -1);
                }
            }
            else
            {
                return (false, -1);
            }
        }

        public List<Item> MProducts()
        {
            return mProducts;
        }
    }
}
