//Project Name: SarreSports | File Name: newBag.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/1/2019 | 15:12
//Last Updated On:  8/1/2019 | 15:06
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
    public partial class newBag : newItem, IItemForm
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
            if (validateSpecificItemAttributes(out object[] elements) && base.validateGeneralItemAttributes())
            {
                this.capacityReturn = (int)elements[0];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public bool validateSpecificItemAttributes(out object[] elements)
        {
            bool valid = true;
            uiSpecificItemAttributesErrorProvider.Clear();

            elements = new object[1];
            int bagCapacity = -1;

            if (string.IsNullOrWhiteSpace(uiBagCapacityUpDown.Text) || !(int.TryParse(uiBagCapacityUpDown.Text, out bagCapacity)) 
                                                                    || bagCapacity <= 0)
            {
                uiSpecificItemAttributesErrorProvider.SetError(uiBagCapacityUpDown, "Please enter valid bag capacity");
                uiSpecificItemAttributesErrorProvider.SetIconPadding(uiBagCapacityUpDown, 10);
                valid = false;
            }

            elements[0] = bagCapacity;
            return valid;
        }
    }
}
