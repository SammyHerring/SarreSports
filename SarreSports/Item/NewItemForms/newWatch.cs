//Project Name: SarreSports | File Name: newWatch.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 5/1/2019 | 21:53
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
    public partial class newWatch : newItem, IItemForm
    {
        public Watch.watchType watchType { get; set; }

        public newWatch(string mainTitle, string supplierName)
        {
            InitializeComponent();
            base.updateMainTitle(mainTitle);
            base.updateSupplierName(supplierName);
            uiWatchTypeComboBox.DataSource = Enum.GetValues(typeof(Watch.watchType));
        }

        protected override void addItem()
        {
            if (validateSpecificItemAttributes(out object[] elements) && base.validateGeneralItemAttributes())
            {
                this.watchType = (Watch.watchType)elements[0];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public bool validateSpecificItemAttributes(out object[] elements)
        {
            bool valid = true;
            uiSpecificItemAttributesErrorProvider.Clear();

            elements = new object[1];
            Watch.watchType? watchType = null;

            if (uiWatchTypeComboBox.SelectedIndex < 0)
            {
                uiSpecificItemAttributesErrorProvider.SetError(uiWatchTypeComboBox, "Please select watch type");
                uiSpecificItemAttributesErrorProvider.SetIconPadding(uiWatchTypeComboBox, 10);
                valid = false;
            }
            else
            {
                watchType = (Watch.watchType)uiWatchTypeComboBox.SelectedItem;
            }

            elements[0] = watchType;
            return valid;
        }
    }
}
