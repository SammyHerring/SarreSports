//Project Name: SarreSports | File Name: viewNutrition.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 7/1/2019 | 15:15
//Last Updated On:  8/1/2019 | 14:35
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SarreSports
{
    public partial class viewNutrition : viewItem
    {
        private Nutrition product;
        public int valueReturn { get; set; }

        public viewNutrition(int productID, Branch currentBranch, viewItemState state)
        {
            InitializeComponent();

            if (!base.updateViewItemState(state) || !(currentBranch.findProduct(productID) is Nutrition))
            {
                Console.WriteLine("Form: New View Item. Error: Form not implemented.");
                MessageBox.Show("Form Aborting. Called improperly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            else
            {
                product = (Nutrition)currentBranch.findProduct(productID);
                base.updateProductAvailability(product.availableForSale);
                base.updateSupplierName(currentBranch.findProductSupplier(productID).Name() ?? "Not Found");
                base.updateProductID(productID.ToString() ?? "Not Found");
                base.updateProductName(product.Name ?? "Not Found");
                base.updateProductCost(product.Cost.ToString("C2") ?? "Not Found");
                base.updateProductStockLevel(product.StockLevel.ToString() ?? "Not Found");
                base.updateProductRestockLevel(product.RestockLevel.ToString() ?? "Not Found");
                this.updateSpecificAttributes(product);
            }
        }
        private void updateSpecificAttributes(dynamic product)
        {
            if (product is Nutrition)
            {
                uiNutritionQuantityTextBox.Text = product.Quantity.ToString() ?? "Not Found";
                uiNutritionTypeTextBox.Text = product.NutritionType.ToString() ?? "Not Found";
            }
        }

        protected override void buyItem()
        {
            using (genericNumericEntry numberEntry = new genericNumericEntry(String.Format("Purchase {0}", product.ItemType), String.Format("Enter required number of {0}: ",product.Name), "Buy"))
            {
                var result = numberEntry.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.valueReturn = numberEntry.valueReturn;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    numberEntry.Dispose();
                }
            };
        }

        protected override void restockItem()
        {
            using (genericNumericEntry numberEntry = new genericNumericEntry(String.Format("Restock {0}", product.ItemType), String.Format("Enter amount of new stock for {0}: ",product.Name, "Restock")))
            {
                var result = numberEntry.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.valueReturn = numberEntry.valueReturn;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    numberEntry.Dispose();
                }
            };
        }
    }
}
