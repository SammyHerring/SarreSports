//Project Name: SarreSports | File Name: newItem.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/1/2019 | 15:12
//Last Updated On:  4/1/2019 | 16:13
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
        public int stockLevel { get; set; }
        public int restockLevel { get; set; }

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

        public void updateAddItemButtonLocation(Point location)
        {
            uiAddItemButton.Location = location;
        }

        private bool validateGeneralItemAttributes()
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(uiItemNameTextBox.Text)) valid = false;

            return valid;
        }
    }
}
