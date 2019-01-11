//Project Name: SarreSports | File Name: Supplier.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 12/12/2018 | 17:02
//Last Updated On:  11/1/2019 | 01:09
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
        //Supplier Attributes
        private string name;
        private static int nextID;
        private readonly int id;
        private List<Item> mProducts = new List<Item>();

        //Supplier Constructor
        public Supplier(string name)
        {
            this.name = name;
            this.id = Interlocked.Increment(ref nextID);
        }

        //Supplier Accessors
        public string Name()
        {
            return name;
        }

        public int ID()
        {
            return id;
        }

        public List<Item> MProducts()
        {
            return mProducts;
        }

        //Supplier Methods
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
    }
}
