//Project Name: SarreSports | File Name: newWatch.Designer.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 5/1/2019 | 16:08
//Last Updated On:  5/1/2019 | 16:08
namespace SarreSports
{
    partial class newWatch
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
            this.components = new System.ComponentModel.Container();
            this.uiSpecificItemAttributesGroupBox = new System.Windows.Forms.GroupBox();
            this.uiWatchTypeComboBox = new System.Windows.Forms.ComboBox();
            this.uiWatchTypeLabel = new System.Windows.Forms.Label();
            this.uiSpecificItemAttributesErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiSpecificItemAttributesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpecificItemAttributesErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // uiAddItemButton
            // 
            this.uiAddItemButton.Location = new System.Drawing.Point(637, 634);
            // 
            // uiSpecificItemAttributesGroupBox
            // 
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiWatchTypeComboBox);
            this.uiSpecificItemAttributesGroupBox.Controls.Add(this.uiWatchTypeLabel);
            this.uiSpecificItemAttributesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSpecificItemAttributesGroupBox.Location = new System.Drawing.Point(24, 482);
            this.uiSpecificItemAttributesGroupBox.Name = "uiSpecificItemAttributesGroupBox";
            this.uiSpecificItemAttributesGroupBox.Size = new System.Drawing.Size(888, 130);
            this.uiSpecificItemAttributesGroupBox.TabIndex = 9;
            this.uiSpecificItemAttributesGroupBox.TabStop = false;
            this.uiSpecificItemAttributesGroupBox.Text = "Specific Item Attributes";
            // 
            // uiWatchTypeComboBox
            // 
            this.uiWatchTypeComboBox.FormattingEnabled = true;
            this.uiWatchTypeComboBox.Location = new System.Drawing.Point(226, 56);
            this.uiWatchTypeComboBox.Name = "uiWatchTypeComboBox";
            this.uiWatchTypeComboBox.Size = new System.Drawing.Size(586, 45);
            this.uiWatchTypeComboBox.TabIndex = 5;
            // 
            // uiWatchTypeLabel
            // 
            this.uiWatchTypeLabel.AutoSize = true;
            this.uiWatchTypeLabel.Location = new System.Drawing.Point(6, 59);
            this.uiWatchTypeLabel.Name = "uiWatchTypeLabel";
            this.uiWatchTypeLabel.Size = new System.Drawing.Size(188, 37);
            this.uiWatchTypeLabel.TabIndex = 4;
            this.uiWatchTypeLabel.Text = "Watch Type";
            // 
            // uiSpecificItemAttributesErrorProvider
            // 
            this.uiSpecificItemAttributesErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.uiSpecificItemAttributesErrorProvider.ContainerControl = this;
            // 
            // newWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 710);
            this.Controls.Add(this.uiSpecificItemAttributesGroupBox);
            this.Name = "newWatch";
            this.Text = "PoS System | New Watch";
            this.Controls.SetChildIndex(this.uiAddItemButton, 0);
            this.Controls.SetChildIndex(this.uiSpecificItemAttributesGroupBox, 0);
            this.uiSpecificItemAttributesGroupBox.ResumeLayout(false);
            this.uiSpecificItemAttributesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpecificItemAttributesErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox uiSpecificItemAttributesGroupBox;
        private System.Windows.Forms.ComboBox uiWatchTypeComboBox;
        private System.Windows.Forms.Label uiWatchTypeLabel;
        private System.Windows.Forms.ErrorProvider uiSpecificItemAttributesErrorProvider;
    }
}