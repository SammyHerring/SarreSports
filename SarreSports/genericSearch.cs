//Project Name: SarreSports | File Name: genericSearch.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 26/12/2018 | 22:35
//Last Updated On:  1/1/2019 | 20:37
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
        //Public Return Variables
        public int returnedID { get; set; }

        //Private Global Variables
        private bool itemsFound = false;
        private List<int> foundItems = new List<int>();
        private int foundItemIndex = 0;

        private string searchQueryWatermark = "Enter Search Term";
        public genericSearch(ListViewItem[] queryListSource, string searchName = "", string initialSearch = "")
        {
            InitializeComponent();

            uiSearchTitle.Text = String.Format("{0} Search", searchName);
            this.Text = String.Format("PoS System | {0} Search", searchName);

            uiSearchQueryTextBox.Focus();
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

            if (initialSearch != "")
            {
                uiSearchQueryTextBox.Text = initialSearch;
                uiSearchQueryTextBox.ForeColor = Color.Black;
                search();
            }
        }

        //Search Functions
        private void search()
        {
            if (!(string.IsNullOrEmpty(uiSearchQueryTextBox.Text)) && uiSearchQueryTextBox.Text != searchQueryWatermark)
            {
                uiSearchQueryListView.SelectedItems.Clear();

                if (!itemsFound)
                {
                    for (int listIndex = uiSearchQueryListView.Items.Count - 1; listIndex >= 0; listIndex--)
                    {
                        if (IsInteger(uiSearchQueryTextBox.Text))
                        {
                            if (uiSearchQueryListView.Items[listIndex].ToString().ToLower()
                                .Contains(uiSearchQueryTextBox.Text.ToLower()))
                            {
                                foundItems.Add(listIndex);
                            }
                        }
                        else
                        {
                            if (uiSearchQueryListView.Items[listIndex].SubItems[1].ToString().ToLower()
                                .Contains(uiSearchQueryTextBox.Text.ToLower()))
                            {
                                foundItems.Add(listIndex);
                            }
                        }
                    }
                    foundItems.Reverse();
                }

                searchItemsIterator();
                itemsFound = true;
            }
        }

        private void searchItemsIterator()
        {
            uiSearchQueryListView.SelectedItems.Clear();
            if (foundItemIndex < foundItems.Count && foundItems.Count > 0)
            {
                uiSearchQueryListView.Items[foundItems[foundItemIndex]].Selected = true;
                uiSearchQueryListView.Select();
                foundItemIndex++;
            }

            if (foundItemIndex == foundItems.Count) foundItemIndex = 0;
        }

        private void resetSearch()
        {
            itemsFound = false;
            foundItems.Clear();
            foundItemIndex = 0;
        }

        private void selectEntity()
        {
            if (uiSearchQueryListView.SelectedItems.Count > 0)
            {
                if (int.TryParse(uiSearchQueryListView.SelectedItems[0].Text, out int entityID))
                {
                    returnValue(entityID);
                } else
                {
                    //Entity Not Found
                    MessageBox.Show("Entity Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            selectEntity();
        }

        private void uiSearchQueryListView_KeyDown(object sender, KeyEventArgs e)
        {
            selectEntity();
        }

        private void uiSelectButton_Click(object sender, EventArgs e)
        {
            selectEntity();
        }

        private void uiCancelButton_Click(object sender, EventArgs e)
        {
            returnValue(-1);
        }

        private void uiSearchQueryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && (!string.IsNullOrEmpty(uiSearchQueryTextBox.Text)))
            {
                search();
                uiSearchQueryTextBox.Focus();
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

        private void uiSearchQueryTextBox_TextChanged(object sender, EventArgs e)
        {
            resetSearch();
        }

        //General Functions
        private bool IsInteger(string value) => value.All(c => c >= '0' && c <= '9');
    }
}
