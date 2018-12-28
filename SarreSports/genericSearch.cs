//Project Name: SarreSports | File Name: genericSearch.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 26/12/2018 | 22:35
//Last Updated On:  28/12/2018 | 21:00
using System;
using System.Collections;
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
    public partial class genericSearch : Form
    {
        public int returnedID { get; set; }

        private string searchQueryWatermark = "Enter Search Term";
        public genericSearch(ListViewItem[] queryListSource, string searchName = "")
        {
            InitializeComponent();

            uiSearchTitle.Text = String.Format("{0} Search", searchName);
            this.Text = String.Format("PoS System | {0} Search", searchName);

            uiSearchQueryTextBox.Text = searchQueryWatermark;
            uiSearchQueryTextBox.ForeColor = Color.Silver;

            //Initialise Search Listing List View
            uiSearchQueryListView.View = View.Details;
            uiSearchQueryListView.FullRowSelect = true;
            uiSearchQueryListView.LabelEdit = false;
            //Initialise Search Listing List View Column Values
            uiSearchQueryListView.Columns.Add("ID", 70, HorizontalAlignment.Left);
            uiSearchQueryListView.Columns.Add(String.Format("{0} Name", searchName), -2, HorizontalAlignment.Left);

            loadList(queryListSource);
        }

        //Search Functions
        private void search()
        {
            uiSearchQueryListView.SelectedItems.Clear();

            List<ListViewItem> foundItems = new List<ListViewItem>();

            for (int listIndex = 0; listIndex < uiSearchQueryListView.Items.Count; listIndex++)
            {
                if (IsInteger(uiSearchQueryTextBox.Text))
                {
                    if (uiSearchQueryListView.Items[listIndex].ToString().ToLower()
                        .Contains(uiSearchQueryTextBox.Text.ToLower()))
                    {
                        uiSearchQueryListView.Items[listIndex].Selected = true;
                        uiSearchQueryListView.Select();
                    }
                }
                else
                {
                    if (uiSearchQueryListView.Items[listIndex].SubItems[1].ToString().ToLower()
                        .Contains(uiSearchQueryTextBox.Text.ToLower()))
                    {
                        uiSearchQueryListView.Items[listIndex].Selected = true;
                        uiSearchQueryListView.Select();
                    }
                }
            }
        }

        private void searchItemsIterator()
        {

        }

        private void returnValue(int ID)
        {

            if (ID != -1)
            {
                this.returnedID = ID;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.returnedID = ID;
                this.DialogResult = DialogResult.Abort;
            }
            this.Close();
        }

        //List View Functions
        private void loadList(ListViewItem[] queryListSource)
        {
            uiSearchQueryListView.Items.AddRange(queryListSource);
        }

        //Control Events
        private void uiSearchButton_Click(object sender, EventArgs e)
        {
            search();
        }

        private void uiSearchQueryListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void uiSelectButton_Click(object sender, EventArgs e)
        {
            
        }

        private void uiCancelButton_Click(object sender, EventArgs e)
        {
            returnValue(-1);
        }

        private void uiSearchQueryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && string.IsNullOrEmpty(uiSearchQueryTextBox.Text))
            {
                search();
            }
        }

        private void uiSearchQueryTextBox_Enter(object sender, EventArgs e)
        {
            if (uiSearchQueryTextBox.Text == searchQueryWatermark)
            {
                uiSearchQueryTextBox.Text = "";
                uiSearchQueryTextBox.ForeColor = Color.Black;
            }
        }

        private void uiSearchQueryTextBox_Leave(object sender, EventArgs e)
        {
            if (uiSearchQueryTextBox.Text == "")
            {
                uiSearchQueryTextBox.Text = searchQueryWatermark;
                uiSearchQueryTextBox.ForeColor = Color.Silver;
            }
        }

        //General Functions
        private bool IsInteger(string value) => value.All(c => c >= '0' && c <= '9');
    }
}
