using System.ComponentModel;
using System.Windows.Forms;

namespace SmartSocial.Desktop
{
    partial class frmOperationLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.txtResultArea = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtResultArea
            // 
            this.txtResultArea.Location = new System.Drawing.Point(13, 13);
            this.txtResultArea.Multiline = true;
            this.txtResultArea.Name = "txtResultArea";
            this.txtResultArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultArea.Size = new System.Drawing.Size(485, 315);
            this.txtResultArea.TabIndex = 0;
            // 
            // frmOperationLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(510, 340);
            this.Controls.Add(this.txtResultArea);
            this.Name = "frmOperationLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Result";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public TextBox txtResultArea;
    }
}