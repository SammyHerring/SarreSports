//Project Name: SarreSports | File Name: itemSelector.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/1/2019 | 15:38
//Last Updated On:  11/1/2019 | 01:14
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
    public partial class itemSelector : Form
    {
        //Public Form Return Values
        public Item.Type itemTypeReturn { get; set; }
        public Accessory.accessoryType? accessoryTypeReturn { get; set; }
        
        private bool formComplete = false; //Form Completion Boolean Check

        public itemSelector()
        {
            InitializeComponent();
        }

        //Form Control Events
        private void itemSelector_Load(object sender, EventArgs e)
        {
            uiAccessoryTypeComboBox.Enabled = false;
            loadFormControls();
        }

        private void uiCreateItem_Click(object sender, EventArgs e)
        {
            createItem();
        }

        private void uiItemTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            uiAccessoryTypeComboBox.Enabled = (uiItemTypeComboBox.SelectedItem.ToString() == Item.Type.Accessory.ToString());
            if (!uiAccessoryTypeComboBox.Enabled) uiAccessoryTypeComboBox.SelectionLength = 0;
        }

        private void uiItemTypeComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter &&
                (uiItemTypeComboBox.SelectedItem.ToString() == Item.Type.Accessory.ToString()))
            {
                uiAccessoryTypeComboBox.Focus();
            }
            else if (uiItemTypeComboBox.SelectedIndex > -1)
            {
                createItem();
            }
        }

        private void uiAccessoryTypeComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter &&
                (uiItemTypeComboBox.SelectedItem.ToString() == Item.Type.Accessory.ToString()) &&
                uiAccessoryTypeComboBox.SelectedIndex > -1)
            {
                createItem();
            }
        }

        //Form Methods
        public void createItem()
        {
            if (uiItemTypeComboBox.SelectedIndex > -1)
            {
                if (uiAccessoryTypeComboBox.SelectedIndex > -1 && uiAccessoryTypeComboBox.Enabled)
                {
                    //Accessory Type and Item Selected
                    this.DialogResult = DialogResult.OK;
                    this.itemTypeReturn = (Item.Type)uiItemTypeComboBox.SelectedItem;
                    this.accessoryTypeReturn = (Accessory.accessoryType)uiAccessoryTypeComboBox.SelectedItem;
                    formComplete = true;
                    this.Close();
                }
                else if (uiAccessoryTypeComboBox.Enabled)
                {
                    //Accessory Type Selection Error
                    //Accessory Type Selected without Item Selection
                    MessageBox.Show("Select Accessory Item Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    uiAccessoryTypeComboBox.Focus();
                }
                else
                {
                    //Standard Item Selected
                    this.DialogResult = DialogResult.OK;
                    this.itemTypeReturn = (Item.Type)uiItemTypeComboBox.SelectedItem;
                    this.accessoryTypeReturn = null;
                    formComplete = true;
                    this.Close();
                }
            }
            else
            {
                //No Item Selected Error
                MessageBox.Show("Select Item Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadFormControls()
        {
            uiItemTypeComboBox.DataSource = Enum.GetValues(typeof(Item.Type));
            uiAccessoryTypeComboBox.DataSource = Enum.GetValues(typeof(Accessory.accessoryType));
        }

        //Form Events
        private void itemSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!formComplete)
            {
                if (MessageBox.Show("Are you sure you leave this form?", "Cancel Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                } 
            }
        }
    }
}
