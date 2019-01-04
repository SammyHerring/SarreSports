//Project Name: SarreSports | File Name: newItem.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/1/2019 | 15:12
//Last Updated On:  4/1/2019 | 17:15
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
    public partial class newItem : Form
    {
        public string itemNameReturn { get; set; }
        public decimal itemCostReturn { get; set; }
        public int stockLevelReturn { get; set; }
        public int restockLevelReturn { get; set; }

        public newItem()
        {
            string mainTitle = "Item";
            string supplierName = "No Supplier";
            InitializeComponent();
            uiNewItemTitle.Text = String.Format("New {0}", mainTitle);
            uiSupplierNameLabel.Text = supplierName;

        }

        private void uiAddItemButton_Click(object sender, EventArgs e)
        {
            addItem();
        }

        protected virtual void addItem()
        {
            Console.WriteLine("New Item Form Aborting. No Item Type Passed.");
            MessageBox.Show("New Item Form Aborting. No Item Type Passed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        public void updateMainTitle(string mainTitle)
        {
            uiNewItemTitle.Text = String.Format("New {0}", mainTitle);
        }

        public void updateSupplierName(string supplierName)
        {
            uiSupplierNameLabel.Text = supplierName;
        }

        public bool validateGeneralItemAttributes()
        {
            bool valid = true;
            uiGeneralItemAttributesErrorProvider.Clear();
            
            if (string.IsNullOrWhiteSpace(uiItemNameTextBox.Text))
            {
                uiGeneralItemAttributesErrorProvider.SetError(uiItemNameTextBox, "Please enter item name");
                uiGeneralItemAttributesErrorProvider.SetIconPadding(uiItemNameTextBox, 10);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(uiItemCostUpDown.Text) && decimal.TryParse(uiItemCostUpDown.Text, out decimal itemCost))
            {
                uiGeneralItemAttributesErrorProvider.SetError(uiItemCostUpDown, "Please enter valid item cost");
                uiGeneralItemAttributesErrorProvider.SetIconPadding(uiItemCostUpDown, 10);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(uiStockLevelUpDown.Text) && int.TryParse(uiStockLevelUpDown.Text, out int stockLevel))
            {
                uiGeneralItemAttributesErrorProvider.SetError(uiStockLevelUpDown, "Please enter valid initial stock level");
                uiGeneralItemAttributesErrorProvider.SetIconPadding(uiStockLevelUpDown, 10);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(uiRestockLevelUpDown.Text) && int.TryParse(uiRestockLevelUpDown.Text, out int restockLevel))
            {
                uiGeneralItemAttributesErrorProvider.SetError(uiRestockLevelUpDown, "Please enter valid restock level");
                uiGeneralItemAttributesErrorProvider.SetIconPadding(uiRestockLevelUpDown, 10);
                valid = false;
            }

            return valid;
        }
    }
}
