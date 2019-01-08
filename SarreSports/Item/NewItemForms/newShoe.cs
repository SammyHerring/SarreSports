//Project Name: SarreSports | File Name: newShoe.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 5/1/2019 | 01:42
//Last Updated On:  5/1/2019 | 21:24
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
    public partial class newShoe : newItem, IItemForm
    {
        public decimal shoeSize { get; set; }
        public Shoe.shoeType shoeType { get; set; }

        public newShoe(string mainTitle, string supplierName)
        {
            InitializeComponent();
            base.updateMainTitle(mainTitle);
            base.updateSupplierName(supplierName);
            uiShoeTypeComboBox.DataSource = Enum.GetValues(typeof(Shoe.shoeType));
        }

        protected override void addItem()
        {
            if (validateSpecificItemAttributes(out object[] elements) && base.validateGeneralItemAttributes())
            {
                this.shoeSize = (decimal)elements[0];
                this.shoeType = (Shoe.shoeType) elements[1];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public bool validateSpecificItemAttributes(out object[] elements)
        {
            bool valid = true;
            uiSpecificItemAttributesErrorProvider.Clear();

            elements = new object[2];
            decimal shoeSize = -1;
            Shoe.shoeType? shoeType = null;

            if (string.IsNullOrWhiteSpace(uiShoeSizeUpDown.Text) || !(decimal.TryParse(uiShoeSizeUpDown.Text, out shoeSize)) 
                                                                 || shoeSize <= 0)
            {
                uiSpecificItemAttributesErrorProvider.SetError(uiShoeSizeUpDown, "Please enter valid shoe size");
                uiSpecificItemAttributesErrorProvider.SetIconPadding(uiShoeSizeUpDown, 10);
                valid = false;
            }

            if (uiShoeTypeComboBox.SelectedIndex < 0)
            {
                uiSpecificItemAttributesErrorProvider.SetError(uiShoeSizeUpDown, "Please select shoe type");
                uiSpecificItemAttributesErrorProvider.SetIconPadding(uiShoeSizeUpDown, 10);
                valid = false;
            }
            else
            {
                shoeType = (Shoe.shoeType)uiShoeTypeComboBox.SelectedItem;
            }

            elements[0] = shoeSize;
            elements[1] = (Shoe.shoeType)shoeType;
            return valid;
        }
    }
}
