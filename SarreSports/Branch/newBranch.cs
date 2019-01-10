//Project Name: SarreSports | File Name: newBranch.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 10/1/2019 | 01:03
//Last Updated On:  10/1/2019 | 01:10
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
    public partial class newBranch : Form
    {
        public string branchName { get; set; }

        public newBranch()
        {
            InitializeComponent();
        }

        //New Branch Methods
        private void returnBranch()
        {
            if (!string.IsNullOrWhiteSpace(uiBranchNameTextBox.Text))
            {
                this.branchName = uiBranchNameTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //Supplier Name Not Provided
                MessageBox.Show("Supplier Name Not Provided", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //New Branch Events
        private void uiCreateBranchButton_Click(object sender, EventArgs e)
        {
            returnBranch();
        }

        private void uiBranchNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && (!string.IsNullOrWhiteSpace(uiBranchNameTextBox.Text)))
            {
                returnBranch();
            }
        }
    }
}
