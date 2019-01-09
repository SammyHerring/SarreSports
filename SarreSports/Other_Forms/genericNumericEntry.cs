//Project Name: SarreSports | File Name: genericNumericEntry.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 6/1/2019 | 19:25
//Last Updated On:  8/1/2019 | 14:37
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
    public partial class genericNumericEntry : Form
    {
        public int valueReturn { get; set; }

        public genericNumericEntry(string Title = "Enter Value", 
                                   string valueQuery = "Value", 
                                   string buttonText = "Submit",
                                   int minimumValue = 1, 
                                   int maximumValue = 1000)
        {
            InitializeComponent();
            uiTitle.Text = Generic.Truncate(Title, 25);
            uiValueQueryLabel.Text = Generic.Truncate(valueQuery, 50);
            uiSubmitButton.Text = Generic.Truncate(buttonText, 10);
            uiNumericValueUpDown.Minimum = minimumValue;
            uiNumericValueUpDown.Maximum = maximumValue;

        }

        private void uiSubmitButton_Click(object sender, EventArgs e)
        {
            returnValue();
        }

        private void returnValue()
        {
            this.valueReturn = (int)uiNumericValueUpDown.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void uiSubmitButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                returnValue();
            }
        }

        private void uiNumericValueUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                returnValue();
            }
        }
    }
}
