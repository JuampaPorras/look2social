using System.ComponentModel;
using System.Windows.Forms;


namespace SmartSocial.Desktop
{
    partial class MainCustomer
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
            this.lbl_subscription = new System.Windows.Forms.Label();
            this.btn_process = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_progress = new System.Windows.Forms.Label();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog4 = new System.Windows.Forms.OpenFileDialog();
            this.btnAddSubscription = new System.Windows.Forms.Button();
            this.btnEditSubscription = new System.Windows.Forms.Button();
            this.btnDeleteSubscription = new System.Windows.Forms.Button();
            this.btnDeleteDelivery = new System.Windows.Forms.Button();
            this.btnEditDelivery = new System.Windows.Forms.Button();
            this.btnAddDelivery = new System.Windows.Forms.Button();
            this.lbl_delivery = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAppend = new System.Windows.Forms.CheckBox();
            this.cmb_subscription = new System.Windows.Forms.ComboBox();
            this.cmd_delivery = new System.Windows.Forms.ComboBox();
            this.cmb_report = new System.Windows.Forms.ComboBox();
            this.openFileDialog5 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog6 = new System.Windows.Forms.OpenFileDialog();
            this.tableContainer = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // lbl_subscription
            // 
            this.lbl_subscription.AutoSize = true;
            this.lbl_subscription.Location = new System.Drawing.Point(31, 27);
            this.lbl_subscription.Name = "lbl_subscription";
            this.lbl_subscription.Size = new System.Drawing.Size(104, 13);
            this.lbl_subscription.TabIndex = 0;
            this.lbl_subscription.Text = "Service Subscription";
            // 
            // btn_process
            // 
            this.btn_process.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_process.Location = new System.Drawing.Point(201, 538);
            this.btn_process.Name = "btn_process";
            this.btn_process.Size = new System.Drawing.Size(134, 23);
            this.btn_process.TabIndex = 12;
            this.btn_process.Text = "PROCESS DATA";
            this.btn_process.UseVisualStyleBackColor = true;
            this.btn_process.Click += new System.EventHandler(this.btn_process_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(431, 538);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(134, 23);
            this.btn_cancel.TabIndex = 13;
            this.btn_cancel.Text = "CANCEL";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(201, 509);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(364, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // lbl_progress
            // 
            this.lbl_progress.AutoSize = true;
            this.lbl_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_progress.Location = new System.Drawing.Point(198, 493);
            this.lbl_progress.Name = "lbl_progress";
            this.lbl_progress.Size = new System.Drawing.Size(98, 13);
            this.lbl_progress.TabIndex = 15;
            this.lbl_progress.Text = "Processing file: ";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog1";
            // 
            // openFileDialog4
            // 
            this.openFileDialog4.FileName = "openFileDialog1";
            // 
            // btnAddSubscription
            // 
            this.btnAddSubscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSubscription.Location = new System.Drawing.Point(447, 17);
            this.btnAddSubscription.Name = "btnAddSubscription";
            this.btnAddSubscription.Size = new System.Drawing.Size(75, 23);
            this.btnAddSubscription.TabIndex = 22;
            this.btnAddSubscription.Text = "Add New";
            this.btnAddSubscription.UseVisualStyleBackColor = true;
            this.btnAddSubscription.Click += new System.EventHandler(this.btnAddSubscription_Click);
            // 
            // btnEditSubscription
            // 
            this.btnEditSubscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditSubscription.Location = new System.Drawing.Point(527, 17);
            this.btnEditSubscription.Name = "btnEditSubscription";
            this.btnEditSubscription.Size = new System.Drawing.Size(75, 23);
            this.btnEditSubscription.TabIndex = 23;
            this.btnEditSubscription.Text = "Update";
            this.btnEditSubscription.UseVisualStyleBackColor = true;
            this.btnEditSubscription.Click += new System.EventHandler(this.btnEditSubscription_Click);
            // 
            // btnDeleteSubscription
            // 
            this.btnDeleteSubscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSubscription.Location = new System.Drawing.Point(607, 17);
            this.btnDeleteSubscription.Name = "btnDeleteSubscription";
            this.btnDeleteSubscription.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSubscription.TabIndex = 24;
            this.btnDeleteSubscription.Text = "Delete";
            this.btnDeleteSubscription.UseVisualStyleBackColor = true;
            this.btnDeleteSubscription.Click += new System.EventHandler(this.btnDeleteSubscription_Click);
            // 
            // btnDeleteDelivery
            // 
            this.btnDeleteDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDelivery.Location = new System.Drawing.Point(607, 44);
            this.btnDeleteDelivery.Name = "btnDeleteDelivery";
            this.btnDeleteDelivery.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDelivery.TabIndex = 29;
            this.btnDeleteDelivery.Text = "Delete";
            this.btnDeleteDelivery.UseVisualStyleBackColor = true;
            this.btnDeleteDelivery.Click += new System.EventHandler(this.btnDeleteDelivery_Click);
            // 
            // btnEditDelivery
            // 
            this.btnEditDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDelivery.Location = new System.Drawing.Point(527, 44);
            this.btnEditDelivery.Name = "btnEditDelivery";
            this.btnEditDelivery.Size = new System.Drawing.Size(75, 23);
            this.btnEditDelivery.TabIndex = 28;
            this.btnEditDelivery.Text = "Update";
            this.btnEditDelivery.UseVisualStyleBackColor = true;
            this.btnEditDelivery.Click += new System.EventHandler(this.btnEditDelivery_Click);
            // 
            // btnAddDelivery
            // 
            this.btnAddDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDelivery.Location = new System.Drawing.Point(447, 44);
            this.btnAddDelivery.Name = "btnAddDelivery";
            this.btnAddDelivery.Size = new System.Drawing.Size(75, 23);
            this.btnAddDelivery.TabIndex = 27;
            this.btnAddDelivery.Text = "Add New";
            this.btnAddDelivery.UseVisualStyleBackColor = true;
            this.btnAddDelivery.Click += new System.EventHandler(this.btnAddDelivery_Click);
            // 
            // lbl_delivery
            // 
            this.lbl_delivery.AutoSize = true;
            this.lbl_delivery.Location = new System.Drawing.Point(31, 54);
            this.lbl_delivery.Name = "lbl_delivery";
            this.lbl_delivery.Size = new System.Drawing.Size(84, 13);
            this.lbl_delivery.TabIndex = 25;
            this.lbl_delivery.Text = "Service Delivery";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Template Report";
            // 
            // chkAppend
            // 
            this.chkAppend.AutoSize = true;
            this.chkAppend.ForeColor = System.Drawing.Color.Red;
            this.chkAppend.Location = new System.Drawing.Point(342, 539);
            this.chkAppend.Name = "chkAppend";
            this.chkAppend.Size = new System.Drawing.Size(89, 17);
            this.chkAppend.TabIndex = 32;
            this.chkAppend.Text = "Append Data";
            this.chkAppend.UseVisualStyleBackColor = true;
            this.chkAppend.CheckedChanged += new System.EventHandler(this.chkAppend_CheckedChanged);
            // 
            // cmb_subscription
            // 
            this.cmb_subscription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_subscription.Location = new System.Drawing.Point(239, 20);
            this.cmb_subscription.Name = "cmb_subscription";
            this.cmb_subscription.Size = new System.Drawing.Size(194, 21);
            this.cmb_subscription.TabIndex = 33;
            this.cmb_subscription.Text = "Service Subscription";
            this.cmb_subscription.SelectedIndexChanged += new System.EventHandler(this.cmb_subscriptionV2_SelectedIndexChanged);
            // 
            // cmd_delivery
            // 
            this.cmd_delivery.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmd_delivery.Location = new System.Drawing.Point(239, 46);
            this.cmd_delivery.Name = "cmd_delivery";
            this.cmd_delivery.Size = new System.Drawing.Size(194, 21);
            this.cmd_delivery.TabIndex = 34;
            this.cmd_delivery.Text = "Service Delivery";
            this.cmd_delivery.SelectedIndexChanged += new System.EventHandler(this.cmd_deliveryV2_SelectedIndexChanged);
            // 
            // cmb_report
            // 
            this.cmb_report.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_report.Location = new System.Drawing.Point(239, 72);
            this.cmb_report.Name = "cmb_report";
            this.cmb_report.Size = new System.Drawing.Size(306, 21);
            this.cmb_report.TabIndex = 35;
            this.cmb_report.Text = "Template Report";
            // 
            // openFileDialog5
            // 
            this.openFileDialog5.FileName = "openFileDialog1";
            // 
            // openFileDialog6
            // 
            this.openFileDialog6.FileName = "openFileDialog1";
            // 
            // tableContainer
            // 
            this.tableContainer.AutoScroll = true;
            this.tableContainer.ColumnCount = 3;
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableContainer.Location = new System.Drawing.Point(34, 119);
            this.tableContainer.Name = "tableContainer";
            this.tableContainer.RowCount = 14;
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableContainer.Size = new System.Drawing.Size(706, 327);
            this.tableContainer.TabIndex = 43;
            // 
            // MainCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 591);
            this.Controls.Add(this.tableContainer);
            this.Controls.Add(this.cmb_report);
            this.Controls.Add(this.cmd_delivery);
            this.Controls.Add(this.cmb_subscription);
            this.Controls.Add(this.chkAppend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteDelivery);
            this.Controls.Add(this.btnEditDelivery);
            this.Controls.Add(this.btnAddDelivery);
            this.Controls.Add(this.lbl_delivery);
            this.Controls.Add(this.btnDeleteSubscription);
            this.Controls.Add(this.btnEditSubscription);
            this.Controls.Add(this.btnAddSubscription);
            this.Controls.Add(this.lbl_progress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_process);
            this.Controls.Add(this.lbl_subscription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CUSTOMER Import Data Tool";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_subscription;
        private Button btn_process;
        private Button btn_cancel;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private ProgressBar progressBar1;
        private Label lbl_progress;
        private OpenFileDialog openFileDialog3;
        private OpenFileDialog openFileDialog4;
        private Button btnAddSubscription;
        private Button btnEditSubscription;
        private Button btnDeleteSubscription;
        private Button btnDeleteDelivery;
        private Button btnEditDelivery;
        private Button btnAddDelivery;
        private Label lbl_delivery;
        private Label label1;
        public CheckBox chkAppend;
        private ComboBox cmb_subscription;
        public ComboBox cmd_delivery;
        public ComboBox cmb_report;
        private OpenFileDialog openFileDialog5;
        private OpenFileDialog openFileDialog6;
        private TableLayoutPanel tableContainer;
    }
}

