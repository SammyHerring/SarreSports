//Project Name: SarreSports | File Name: viewPurchaseOrder.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 8/1/2019 | 22:53
//Last Updated On:  9/1/2019 | 02:37
namespace SarreSports
{
    partial class viewPurchaseOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiPurchaseListView = new System.Windows.Forms.ListView();
            this.uiPurchaseOrderTitleLabel = new System.Windows.Forms.Label();
            this.uiCustomerNameLabel = new System.Windows.Forms.Label();
            this.uiCustomerNameValueLabel = new System.Windows.Forms.Label();
            this.uiOrderDateValueLabel = new System.Windows.Forms.Label();
            this.uiOrderDateLabel = new System.Windows.Forms.Label();
            this.uiOrderTotalValueLabel = new System.Windows.Forms.Label();
            this.uiOrderTotalLabel = new System.Windows.Forms.Label();
            this.uiCloseFormButton = new System.Windows.Forms.Button();
            this.uiPurchasesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiPurchaseListView
            // 
            this.uiPurchaseListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPurchaseListView.GridLines = true;
            this.uiPurchaseListView.Location = new System.Drawing.Point(28, 199);
            this.uiPurchaseListView.Name = "uiPurchaseListView";
            this.uiPurchaseListView.Size = new System.Drawing.Size(2114, 886);
            this.uiPurchaseListView.TabIndex = 14;
            this.uiPurchaseListView.UseCompatibleStateImageBehavior = false;
            // 
            // uiPurchaseOrderTitleLabel
            // 
            this.uiPurchaseOrderTitleLabel.AutoSize = true;
            this.uiPurchaseOrderTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPurchaseOrderTitleLabel.Location = new System.Drawing.Point(28, 22);
            this.uiPurchaseOrderTitleLabel.Name = "uiPurchaseOrderTitleLabel";
            this.uiPurchaseOrderTitleLabel.Size = new System.Drawing.Size(596, 67);
            this.uiPurchaseOrderTitleLabel.TabIndex = 15;
            this.uiPurchaseOrderTitleLabel.Text = "Purchase Order #001";
            // 
            // uiCustomerNameLabel
            // 
            this.uiCustomerNameLabel.AutoSize = true;
            this.uiCustomerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCustomerNameLabel.Location = new System.Drawing.Point(33, 89);
            this.uiCustomerNameLabel.Name = "uiCustomerNameLabel";
            this.uiCustomerNameLabel.Size = new System.Drawing.Size(308, 42);
            this.uiCustomerNameLabel.TabIndex = 16;
            this.uiCustomerNameLabel.Text = "Customer Name: ";
            // 
            // uiCustomerNameValueLabel
            // 
            this.uiCustomerNameValueLabel.AutoSize = true;
            this.uiCustomerNameValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCustomerNameValueLabel.Location = new System.Drawing.Point(347, 89);
            this.uiCustomerNameValueLabel.Name = "uiCustomerNameValueLabel";
            this.uiCustomerNameValueLabel.Size = new System.Drawing.Size(204, 42);
            this.uiCustomerNameValueLabel.TabIndex = 17;
            this.uiCustomerNameValueLabel.Text = "Joe Bloggs";
            // 
            // uiOrderDateValueLabel
            // 
            this.uiOrderDateValueLabel.AutoSize = true;
            this.uiOrderDateValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiOrderDateValueLabel.Location = new System.Drawing.Point(1766, 98);
            this.uiOrderDateValueLabel.Name = "uiOrderDateValueLabel";
            this.uiOrderDateValueLabel.Size = new System.Drawing.Size(376, 42);
            this.uiOrderDateValueLabel.TabIndex = 19;
            this.uiOrderDateValueLabel.Text = "01/01/2019 01:01 AM";
            // 
            // uiOrderDateLabel
            // 
            this.uiOrderDateLabel.AutoSize = true;
            this.uiOrderDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiOrderDateLabel.Location = new System.Drawing.Point(1482, 98);
            this.uiOrderDateLabel.Name = "uiOrderDateLabel";
            this.uiOrderDateLabel.Size = new System.Drawing.Size(278, 42);
            this.uiOrderDateLabel.TabIndex = 18;
            this.uiOrderDateLabel.Text = "Order made on:";
            // 
            // uiOrderTotalValueLabel
            // 
            this.uiOrderTotalValueLabel.AutoSize = true;
            this.uiOrderTotalValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiOrderTotalValueLabel.Location = new System.Drawing.Point(255, 1104);
            this.uiOrderTotalValueLabel.Name = "uiOrderTotalValueLabel";
            this.uiOrderTotalValueLabel.Size = new System.Drawing.Size(175, 42);
            this.uiOrderTotalValueLabel.TabIndex = 21;
            this.uiOrderTotalValueLabel.Text = "£1000.00";
            // 
            // uiOrderTotalLabel
            // 
            this.uiOrderTotalLabel.AutoSize = true;
            this.uiOrderTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiOrderTotalLabel.Location = new System.Drawing.Point(33, 1104);
            this.uiOrderTotalLabel.Name = "uiOrderTotalLabel";
            this.uiOrderTotalLabel.Size = new System.Drawing.Size(216, 42);
            this.uiOrderTotalLabel.TabIndex = 20;
            this.uiOrderTotalLabel.Text = "Order Total:";
            // 
            // uiCloseFormButton
            // 
            this.uiCloseFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCloseFormButton.Location = new System.Drawing.Point(1977, 1097);
            this.uiCloseFormButton.Name = "uiCloseFormButton";
            this.uiCloseFormButton.Size = new System.Drawing.Size(165, 57);
            this.uiCloseFormButton.TabIndex = 22;
            this.uiCloseFormButton.Text = "Close";
            this.uiCloseFormButton.UseVisualStyleBackColor = true;
            this.uiCloseFormButton.Click += new System.EventHandler(this.uiCloseFormButton_Click);
            // 
            // uiPurchasesLabel
            // 
            this.uiPurchasesLabel.AutoSize = true;
            this.uiPurchasesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPurchasesLabel.Location = new System.Drawing.Point(33, 142);
            this.uiPurchasesLabel.Name = "uiPurchasesLabel";
            this.uiPurchasesLabel.Size = new System.Drawing.Size(196, 42);
            this.uiPurchasesLabel.TabIndex = 23;
            this.uiPurchasesLabel.Text = "Purchases";
            // 
            // viewPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2196, 1248);
            this.Controls.Add(this.uiPurchasesLabel);
            this.Controls.Add(this.uiCloseFormButton);
            this.Controls.Add(this.uiOrderTotalValueLabel);
            this.Controls.Add(this.uiOrderTotalLabel);
            this.Controls.Add(this.uiOrderDateValueLabel);
            this.Controls.Add(this.uiOrderDateLabel);
            this.Controls.Add(this.uiCustomerNameValueLabel);
            this.Controls.Add(this.uiCustomerNameLabel);
            this.Controls.Add(this.uiPurchaseOrderTitleLabel);
            this.Controls.Add(this.uiPurchaseListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "viewPurchaseOrder";
            this.Text = "PoS System | View Purchase Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView uiPurchaseListView;
        private System.Windows.Forms.Label uiPurchaseOrderTitleLabel;
        private System.Windows.Forms.Label uiCustomerNameLabel;
        private System.Windows.Forms.Label uiCustomerNameValueLabel;
        private System.Windows.Forms.Label uiOrderDateValueLabel;
        private System.Windows.Forms.Label uiOrderDateLabel;
        private System.Windows.Forms.Label uiOrderTotalValueLabel;
        private System.Windows.Forms.Label uiOrderTotalLabel;
        private System.Windows.Forms.Button uiCloseFormButton;
        private System.Windows.Forms.Label uiPurchasesLabel;
    }
}