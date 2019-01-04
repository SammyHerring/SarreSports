//Project Name: SarreSports | File Name: newSupplier.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 2/1/2019 | 00:22
//Last Updated On:  3/1/2019 | 23:51
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
    public partial class newSupplier : Form
    {
        //Pulic Return Variable
        public string supplierName { get; set; }

        public newSupplier()
        {
            InitializeComponent();
        }

        //New Supplier Methods
        private void returnSupplier()
        {
            if (!string.IsNullOrWhiteSpace(uiSupplierNameTextBox.Text))
            {
                this.supplierName = uiSupplierNameTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //Supplier Name Not Provided
                MessageBox.Show("Supplier Name Not Provided", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //New Supplier Events
        private void uiCreateSupplierButton_Click(object sender, EventArgs e)
        {
            returnSupplier();
        }

        private void uiSupplierNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && (!string.IsNullOrEmpty(uiSupplierNameTextBox.Text)))
            {
                returnSupplier();
            }
        }
    }
}
