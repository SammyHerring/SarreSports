//Project Name: SarreSports | File Name: genericSearch.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 26/12/2018 | 22:35
//Last Updated On:  26/12/2018 | 23:26
namespace SarreSports
{
    partial class genericSearch
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
            this.uiSearchTitle = new System.Windows.Forms.Label();
            this.uiSearchQueryTextBox = new System.Windows.Forms.TextBox();
            this.uiSearchButton = new System.Windows.Forms.Button();
            this.uiSearchQueryListView = new System.Windows.Forms.ListView();
            this.uiSelectButton = new System.Windows.Forms.Button();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uiSearchTitle
            // 
            this.uiSearchTitle.AutoSize = true;
            this.uiSearchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSearchTitle.Location = new System.Drawing.Point(13, 9);
            this.uiSearchTitle.Name = "uiSearchTitle";
            this.uiSearchTitle.Size = new System.Drawing.Size(140, 67);
            this.uiSearchTitle.TabIndex = 0;
            this.uiSearchTitle.Text = "Title";
            // 
            // uiSearchQueryTextBox
            // 
            this.uiSearchQueryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSearchQueryTextBox.Location = new System.Drawing.Point(25, 95);
            this.uiSearchQueryTextBox.Name = "uiSearchQueryTextBox";
            this.uiSearchQueryTextBox.Size = new System.Drawing.Size(486, 44);
            this.uiSearchQueryTextBox.TabIndex = 1;
            this.uiSearchQueryTextBox.Enter += new System.EventHandler(this.uiSearchQueryTextBox_Enter);
            this.uiSearchQueryTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiSearchQueryTextBox_KeyDown);
            this.uiSearchQueryTextBox.Leave += new System.EventHandler(this.uiSearchQueryTextBox_Leave);
            // 
            // uiSearchButton
            // 
            this.uiSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSearchButton.Location = new System.Drawing.Point(527, 89);
            this.uiSearchButton.Name = "uiSearchButton";
            this.uiSearchButton.Size = new System.Drawing.Size(319, 55);
            this.uiSearchButton.TabIndex = 2;
            this.uiSearchButton.Text = "Search";
            this.uiSearchButton.UseVisualStyleBackColor = true;
            this.uiSearchButton.Click += new System.EventHandler(this.uiSearchButton_Click);
            // 
            // uiSearchQueryListView
            // 
            this.uiSearchQueryListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSearchQueryListView.Location = new System.Drawing.Point(25, 172);
            this.uiSearchQueryListView.MultiSelect = false;
            this.uiSearchQueryListView.Name = "uiSearchQueryListView";
            this.uiSearchQueryListView.Size = new System.Drawing.Size(821, 653);
            this.uiSearchQueryListView.TabIndex = 3;
            this.uiSearchQueryListView.UseCompatibleStateImageBehavior = false;
            this.uiSearchQueryListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.uiSearchQueryListView_MouseDoubleClick);
            // 
            // uiSelectButton
            // 
            this.uiSelectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSelectButton.Location = new System.Drawing.Point(527, 841);
            this.uiSelectButton.Name = "uiSelectButton";
            this.uiSelectButton.Size = new System.Drawing.Size(319, 55);
            this.uiSelectButton.TabIndex = 4;
            this.uiSelectButton.Text = "Select";
            this.uiSelectButton.UseVisualStyleBackColor = true;
            this.uiSelectButton.Click += new System.EventHandler(this.uiSelectButton_Click);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCancelButton.Location = new System.Drawing.Point(192, 841);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(319, 55);
            this.uiCancelButton.TabIndex = 5;
            this.uiCancelButton.Text = "Cancel";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            this.uiCancelButton.Click += new System.EventHandler(this.uiCancelButton_Click);
            // 
            // genericSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 908);
            this.Controls.Add(this.uiCancelButton);
            this.Controls.Add(this.uiSelectButton);
            this.Controls.Add(this.uiSearchQueryListView);
            this.Controls.Add(this.uiSearchButton);
            this.Controls.Add(this.uiSearchQueryTextBox);
            this.Controls.Add(this.uiSearchTitle);
            this.Name = "genericSearch";
            this.Text = "PoS System | Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uiSearchTitle;
        private System.Windows.Forms.TextBox uiSearchQueryTextBox;
        private System.Windows.Forms.Button uiSearchButton;
        private System.Windows.Forms.ListView uiSearchQueryListView;
        private System.Windows.Forms.Button uiSelectButton;
        private System.Windows.Forms.Button uiCancelButton;
    }
}