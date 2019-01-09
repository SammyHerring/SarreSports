//Project Name: SarreSports | File Name: viewPurchaseOrder.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 8/1/2019 | 22:53
//Last Updated On:  9/1/2019 | 02:38
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
    public partial class viewPurchaseOrder : Form
    {
        public viewPurchaseOrder(string purchaseID,
                                 string customerName,
                                 DateTime purchaseDate,
                                 decimal orderTotalCost,
                                 ListViewItem[] purchaseListViewItems)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(2196, 1248);

            uiPurchaseListView.View = View.Details;
            uiPurchaseListView.LabelEdit = false;
            uiPurchaseListView.FullRowSelect = true;
            uiPurchaseListView.Columns.Add("Product ID", 200, HorizontalAlignment.Left);
            uiPurchaseListView.Columns.Add("Product Name", 400, HorizontalAlignment.Left);
            uiPurchaseListView.Columns.Add("Quantity", 125, HorizontalAlignment.Left);
            uiPurchaseListView.Columns.Add("Item Cost", 125, HorizontalAlignment.Left);
            uiPurchaseListView.Columns.Add("Total Cost", -2, HorizontalAlignment.Left);

            uiPurchaseOrderTitleLabel.Text = String.Format("Purchase Order #{0}", purchaseID);
            uiCustomerNameValueLabel.Text = customerName;
            uiOrderDateValueLabel.Text = purchaseDate.ToString("dd/MM/yyyy hh:mm tt");
            uiOrderTotalValueLabel.Text = orderTotalCost.ToString("C2");
            loadForm(purchaseListViewItems);
        }

        private void uiCloseFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadForm(ListViewItem[] purchaseListViewItems)
        {
            uiPurchaseListView.Items.AddRange(purchaseListViewItems);
        }


    }
}
