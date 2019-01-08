//Project Name: SarreSports | File Name: newNutrition.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 5/1/2019 | 15:29
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
    public partial class newNutrition : newItem, IItemForm
    {
        public int nutritionQuantity { get; set; }
        public Nutrition.nutritionType nutritionType { get; set; }

        public newNutrition(string mainTitle, string supplierName)
        {
            InitializeComponent();
            base.updateMainTitle(mainTitle);
            base.updateSupplierName(supplierName);
            uiNutritionTypeComboBox.DataSource = Enum.GetValues(typeof(Nutrition.nutritionType));
        }

        protected override void addItem()
        {
            if (validateSpecificItemAttributes(out object[] elements) && base.validateGeneralItemAttributes())
            {
                this.nutritionQuantity = (int)elements[0];
                this.nutritionType = (Nutrition.nutritionType)elements[1];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public bool validateSpecificItemAttributes(out object[] elements)
        {
            bool valid = true;
            uiSpecificItemAttributesErrorProvider.Clear();

            elements = new object[2];
            int nutritionQuantity = -1;
            Nutrition.nutritionType? nutritionType = null;

            if (string.IsNullOrWhiteSpace(uiNutritionQuantityUpDown.Text) || !(int.TryParse(uiNutritionQuantityUpDown.Text, out nutritionQuantity)) 
                                                                          || nutritionQuantity <= 0)
            {
                uiSpecificItemAttributesErrorProvider.SetError(uiNutritionQuantityUpDown, "Please enter valid nutrition quantity");
                uiSpecificItemAttributesErrorProvider.SetIconPadding(uiNutritionQuantityUpDown, 10);
                valid = false;
            }

            if (uiNutritionTypeComboBox.SelectedIndex < 0)
            {
                uiSpecificItemAttributesErrorProvider.SetError(uiNutritionTypeComboBox, "Please select nutrition type");
                uiSpecificItemAttributesErrorProvider.SetIconPadding(uiNutritionTypeComboBox, 10);
                valid = false;
            }
            else
            {
                nutritionType = (Nutrition.nutritionType)uiNutritionTypeComboBox.SelectedItem;
            }

            elements[0] = nutritionQuantity;
            elements[1] = nutritionType;
            return valid;
        }
    }
}
