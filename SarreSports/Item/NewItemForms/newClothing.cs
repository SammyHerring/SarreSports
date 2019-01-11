//Project Name: SarreSports | File Name: newClothing.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 5/1/2019 | 15:10
//Last Updated On:  10/1/2019 | 14:31
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
    public partial class newClothing : newItem, IItemForm
    {
        public int clothingSize { get; set; }
        public string clothingColour { get; set; }
        public Clothing.clothingType clothingType { get; set; }

        public newClothing(string mainTitle, string supplierName)
        {
            InitializeComponent();
            base.updateMainTitle(mainTitle);
            base.updateSupplierName(supplierName);
            uiClothingTypeComboBox.DataSource = Enum.GetValues(typeof(Clothing.clothingType));
        }

        protected override void addItem()
        {
            if (validateSpecificItemAttributes(out object[] elements) && base.validateGeneralItemAttributes())
            {
                this.clothingSize = (int)elements[0];
                this.clothingColour = (string)elements[1];
                this.clothingType = (Clothing.clothingType)elements[2];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public bool validateSpecificItemAttributes(out object[] elements)
        {
            bool valid = true;
            uiSpecificItemAttributesErrorProvider.Clear();

            elements = new object[3];
            int clothingSize = -1;
            string clothingColour = "";
            Clothing.clothingType? clothingType = null;

            if (string.IsNullOrWhiteSpace(uiClothingSizeUpDown.Text) || !(int.TryParse(uiClothingSizeUpDown.Text, out clothingSize)) 
                                                                     || clothingSize <= 0)
            {
                uiSpecificItemAttributesErrorProvider.SetError(uiClothingSizeUpDown, "Please enter valid clothing size");
                uiSpecificItemAttributesErrorProvider.SetIconPadding(uiClothingSizeUpDown, 10);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(uiClothingColourTextBox.Text))
            {
                uiSpecificItemAttributesErrorProvider.SetError(uiClothingColourTextBox, "Please enter valid clothing colour");
                uiSpecificItemAttributesErrorProvider.SetIconPadding(uiClothingColourTextBox, 10);
                valid = false;
            }
            else
            {
                clothingColour = uiClothingColourTextBox.Text;
            }

            if (uiClothingTypeComboBox.SelectedIndex < 0)
            {
                uiSpecificItemAttributesErrorProvider.SetError(uiClothingTypeComboBox, "Please select clothing type");
                uiSpecificItemAttributesErrorProvider.SetIconPadding(uiClothingTypeComboBox, 10);
                valid = false;
            }
            else
            {
                clothingType = (Clothing.clothingType)uiClothingTypeComboBox.SelectedItem;
            }

            elements[0] = clothingSize;
            elements[1] = clothingColour;
            elements[2] = clothingType;
            return valid;
        }

        private void newClothing_Load(object sender, EventArgs e)
        {

        }
    }
}
