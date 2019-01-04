//Project Name: SarreSports | File Name: newBag.cs
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
    public partial class newBag : newItem
    {
        public int capacityReturn { get; set; }

        public newBag(string mainTitle, string supplierName)
        {
            InitializeComponent();
            base.updateMainTitle(mainTitle);
            base.updateSupplierName(supplierName);
        }

        protected override void addItem()
        {
            Console.WriteLine("New Item Form Aborting. No Item Type Passed.");
            MessageBox.Show("New Item Form Aborting. No Item Type Passed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private bool validateSpecificItemAttributes()
        {
            //if ()
            return true;
        }
    }
}
