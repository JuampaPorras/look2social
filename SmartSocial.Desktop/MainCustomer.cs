using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using NLog;
using SmartSocial.Data;
using SmartSocial.Desktop.Messaging.Request;
using SmartSocial.Desktop.Messaging.Response;
using SmartSocial.Desktop.Services;
using SmartSocial.Desktop.Templates;
using SmartSocial.Desktop.Utils;

namespace SmartSocial.Desktop
{
    public partial class MainCustomer : Form
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private Extensions _extensions = new Extensions();
        public List<ReportTemplate> _reportTemplates = new List<ReportTemplate>();
        private ReportService _reportService;

        public MainCustomer()
        {
            InitializeComponent();
            _reportService = new ReportService();


        }

        public List<ReportTemplate> GetReportElements(int idSmartRerport)
        {
            var response = new List<ReportTemplate>();
            try
            {
                
                using (var smartsocialDb = new SmartSocialdbDataContext())
                {
                    
                    var allCharts = smartsocialDb.SmartChart.Where(x => x.IdSmartReport == idSmartRerport).ToList();
                    foreach (var chart in allCharts)
                    {
                        var reportTemplate = new ReportTemplate();
                        var chartType = smartsocialDb.DataProviderXChartType.SingleOrDefault(x => x.IdDataProvider == chart.IdDataProvider && x.IdChartType == chart.IdChartType);
                        reportTemplate.SmartChartId = chart.IdSmartChart;
                        reportTemplate.ReportTypeId = Convert.ToInt32(chart.IdChartType);
                        reportTemplate.CustomButton.ForeColor = Color.Black;
                        reportTemplate.CustomButton.Text = "Select";
                        reportTemplate.SmartReportId = idSmartRerport;
                        reportTemplate.FileLoadFunctionName = chartType.FileLoadFunctionName;
                        reportTemplate.CustomButton.Click += (sender, e) => OpenObjectFileDialog(sender, e, reportTemplate);
                        reportTemplate.Extension = chart.FileName.Split('.')[1];
                        if (!chart.ChartName.Contains("Stream"))
                        {
                            reportTemplate.Keywords.Visible = false;
                        }
                        else {
                            reportTemplate.KeywordsLabel.Text = "Product Name: ";
                            reportTemplate.KeywordsLabel.Margin = new Padding(1);
                            reportTemplate.KeywordsLabel.TextAlign = ContentAlignment.MiddleCenter;
                            reportTemplate.KeywordsLabel.AutoSize = true;
                        }
                        reportTemplate.ChartName = chart.ChartName;
                        reportTemplate.TitleLabel.Text = chart.ChartName;
                        reportTemplate.TitleLabel.Margin = new Padding(1);
                        reportTemplate.TitleLabel.TextAlign = ContentAlignment.MiddleCenter;
                        reportTemplate.TitleLabel.AutoSize = true;
                        reportTemplate.ErrorLabel.AutoSize = true;
                        reportTemplate.ErrorLabel.Margin = new Padding(1);
                        reportTemplate.ErrorLabel.TextAlign = ContentAlignment.MiddleCenter;
                        response.Add(reportTemplate);
                        _reportTemplates.Add(reportTemplate);
                    }

                }

            }
            catch (Exception ex)
            {
                _logger.ErrorException(ex.Message, ex);
            }
            return response;
        }




        public void OpenObjectFileDialog(object sender, EventArgs e, ReportTemplate reportTemplate)
        {
            reportTemplate.openDialgog.Filter = _extensions.GetAllowedExtension(reportTemplate.Extension);
            reportTemplate.openDialgog.FilterIndex = 2;
            reportTemplate.openDialgog.RestoreDirectory = true;

            if (reportTemplate.openDialgog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //check if the file selected has the right extension
                    if (Path.GetExtension(reportTemplate.openDialgog.FileName) == "." + reportTemplate.Extension)
                    {
                        reportTemplate.ErrorLabel.Text = reportTemplate.openDialgog.SafeFileName;
                        reportTemplate.Validated = true;
                    }
                    else
                    {
                        //error message in case the selected file is not the right extension
                        reportTemplate.Validated = false;
                        reportTemplate.ErrorLabel.Text = "";
                        MessageBox.Show("Error: Please Select a file with extension:" + reportTemplate.Extension + ".");
                    }

                }
                catch (Exception ex)
                {
                    //error message for general IO error operations
                    reportTemplate.ErrorLabel.Text = "";
                    reportTemplate.Validated = false;
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }



        private void Main_Load(object sender, EventArgs e)
        {
            //setting default values on the form

            lbl_progress.Text = "Processing file: ";

            

            //connect to DB context
            using (SmartSocialdbDataContext smartsocialDb = new SmartSocialdbDataContext())
            {


                //load all service subscriptors that are active
                var query = smartsocialDb.ServiceSubscription.ByIsActive(true).ToList();

                if (query.Count > 0)
                {
                    //fill the service subscriptors combo with values from the DB
                    cmb_subscription.DataSource = query;
                    cmb_subscription.DisplayMember = "SubscriptionName";
                    cmb_subscription.ValueMember = "IdServiceSubscription";

                    cmb_subscription.DataSource = query;
                    cmb_subscription.DisplayMember = "SubscriptionName";
                    cmb_subscription.ValueMember = "IdServiceSubscription";

                }
                else
                {
                    //no info of service subscriptors available in the DB
                    cmb_subscription.Items.Clear();
                    cmb_subscription.Items.Add("no info available");
                    cmb_subscription.SelectedIndex = 0;
                }

                //load all service delivery order by date created desc
                var query2 = smartsocialDb.ServiceDelivery.OrderByDescending(m => m.DateDelivered).ToList();
                //var query2 = smartsocialDB.ServiceDelivery.ToList();

                if (query2.Count > 0)
                {
                    //fill the service delivery combo with values from the DB
                    cmd_delivery.DataSource = query2;
                    cmd_delivery.DisplayMember = "datedelivered";
                    cmd_delivery.ValueMember = "IdServiceDelivery";
                }
                else
                {
                    //no info of service delivery available in the DB
                    cmd_delivery.Items.Clear();
                    cmd_delivery.Items.Add("no info available");
                    cmd_delivery.SelectedIndex = 0;
                }



                //load all reports
                var templateReports = smartsocialDb.SmartReport.Where(x => x.IsTemplate == true).OrderBy(m => m.ReportName).ToList();

                if (templateReports.Count > 0)
                {
                    //fill the service delivery combo with values from the DB
                    cmb_report.DataSource = templateReports;
                    cmb_report.DisplayMember = "ReportName";
                    cmb_report.ValueMember = "IdSmartReport";

                }
                else
                {
                    //no info of service delivery available in the DB
                    cmb_report.Items.Clear();
                    cmb_report.Items.Add("no info available");
                    cmb_report.SelectedIndex = 0;
                }

                cmb_report.SelectedIndexChanged += new EventHandler(ReDisplay);

            }

            //refresh all drop downs base on selections(cascade)
            RefreshCascadeDropDowns();

        }

        public void ReDisplay(object sender, EventArgs e)
        {
            var templates = GetReportElements(Convert.ToInt32(cmb_report.SelectedValue));
            _reportTemplates.Clear();
            _reportTemplates = templates;

            if (templates.Count > 0)
            {
                tableContainer.Controls.Clear();
                int counter = 0;
                foreach (var template in templates)
                {
                    tableContainer.Controls.Add(template.TitleLabel, 0 /* Column Index */, counter /* Row index */);
                    tableContainer.Controls.Add(template.CustomButton, 1 /* Column Index */, counter /* Row index */);
                    tableContainer.Controls.Add(template.ErrorLabel, 2 /* Column Index */, counter /* Row index */);
                    if (template.Keywords.Visible)
                    {
                        counter++;
                        tableContainer.Controls.Add(template.Keywords, 1 /* Column Index */, counter /* Row index */);
                        tableContainer.Controls.Add(template.KeywordsLabel, 0 /* Column Index */, counter /* Row index */);
                    }
                   
                    counter++;
                }
            }
        }

        private void btn_datafile_Click(object sender, EventArgs e)
        {
            

            

        }

        private void btn_conversation_stream_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //setting default values for openDialog control
            openFileDialog2.Filter = "zip files (*.zip)|*.zip|All files (*.*)|*.*";
            openFileDialog2.FilterIndex = 2;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //check if the file selected is .zip type
                    if (Path.GetExtension(openFileDialog2.FileName) == ".zip")
                    {
                        if ((myStream = openFileDialog2.OpenFile()) != null)
                        {
                            using (myStream)
                            {
                                //check for all the Excel files inside the selected .zip file
                                //this logic is just for testing, will be remove soon...
                                string msg = "";
                                using (var zipFile = new ZipFile(openFileDialog2.FileName))
                                {
                                    //TODO:REMOVE
                                    //foreach (ZipEntry entry in zipFile)
                                    //{
                                    //    msg = msg + entry.Name + Environment.NewLine;
                                    //}

                                    //check for the amount of files inside the zip file
                                    if (zipFile.Count != 1)
                                    {
                                        //lbl_selectedConversationStream.Text = "";
                                        MessageBox.Show("Stream zip file need to have only 1 Excel file inside");
                                    }
                                    else
                                    {
                                        //lbl_selectedConversationStream.Text = openFileDialog2.SafeFileName;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //error message in case the selected file is not .zip type
                        // lbl_selectedConversationStream.Text = "";
                        MessageBox.Show("Error: Need to select .zip files, please try again.");
                    }

                }
                catch (Exception ex)
                {
                    //error message for general IO error operations
                    // lbl_selectedConversationStream.Text = "";
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

            if (chkAppend.Checked)
            {

            }
            else
            {

            }

        }

        private void btn_process_Click(object sender, EventArgs e)
        {
            if (cmb_report.SelectedValue == null)
            {
                MessageBox.Show("You need to select a valid Report, please try again!");
            }
            else
            {
                progressBar1.Value = 0;
                //disable main buttons
                chkAppend.Enabled = false;
                btn_process.Enabled = false;
                btn_cancel.Enabled = false;


                var smartReportId = 0;
                if (!chkAppend.Checked)
                {
                    smartReportId = _reportService.AddReportBaseOnTemplate((int)cmb_report.SelectedValue, (int)cmd_delivery.SelectedValue);
                    if (_reportTemplates.Any(report => !report.Validated))
                    {
                        MessageBox.Show("Please review that you have all the fields!");
                        btn_process.Enabled = true;
                        return;
                    }
                }

                var progressSize = Convert.ToInt32(100/_reportTemplates.Count());

                var processResult = new StringBuilder();
                processResult.AppendLine("Import process start at: " + DateTime.Now);
                foreach (var chart in _reportTemplates)
                {
                    if (!chart.openDialgog.FileName.Equals(""))
                    {
                        ReportDataImportResponse reportDataImport = null;
                        if (!chkAppend.Checked)
                        {
                            chart.SmartReportId = smartReportId;
                            chart.SmartChartId = _reportService.AddChartBaseOnTemplate(chart.SmartChartId, smartReportId);
                        }
                        switch (chart.FileLoadFunctionName)
                        {

                            case "fnProcessColumns":
                                processResult.AppendLine("********************************************");
                                processResult.AppendLine("Chart Name: " + chart.ChartName);
                                processResult.AppendLine("File name: " + chart.openDialgog.FileName.Split('\\')[chart.openDialgog.FileName.Split('\\').Length - 1]);
                                processResult.AppendLine("Start: " + DateTime.Now);
                                reportDataImport = _reportService.FnProcessColumns(new ReportDataImportRequest()
                                {
                                    ReportTemplateObject = chart
                                });
                                processResult.AppendLine("End: " + DateTime.Now);
                                if (reportDataImport.Acknowledgment)
                                {
                                    processResult.AppendLine("Message: " + reportDataImport.Message);
                                }
                                else
                                {
                                    processResult.AppendLine("Error Message: " + reportDataImport.Message);
                                }
                                progressBar1.Value = progressBar1.Value + progressSize;
                                break;
                            case "fnProcessLinear":
                                processResult.AppendLine("********************************************");
                                processResult.AppendLine("Chart Name: " + chart.ChartName);
                                processResult.AppendLine("File name: " + chart.openDialgog.FileName.Split('\\')[chart.openDialgog.FileName.Split('\\').Length - 1]);
                                processResult.AppendLine("Start: " + DateTime.Now);
                                reportDataImport = _reportService.FnProcessLinear(new ReportDataImportRequest()
                                {
                                    ReportTemplateObject = chart
                                });
                                processResult.AppendLine("End: " + DateTime.Now);
                                if (reportDataImport.Acknowledgment)
                                {
                                    processResult.AppendLine("Message: " + reportDataImport.Message);
                                }
                                else
                                {
                                    processResult.AppendLine("Error Message: " + reportDataImport.Message);
                                }

                                progressBar1.Value = progressBar1.Value + progressSize;
                                break;
                            case "fnProcessStackedColumns":
                                processResult.AppendLine("********************************************");
                                processResult.AppendLine("Chart Name: " + chart.ChartName);
                                processResult.AppendLine("File name: " + chart.openDialgog.FileName.Split('\\')[chart.openDialgog.FileName.Split('\\').Length - 1]);
                                processResult.AppendLine("Start: " + DateTime.Now);
                                reportDataImport = _reportService.FnProcessStackedColumns(new ReportDataImportRequest()
                                {
                                    ReportTemplateObject = chart
                                });
                                processResult.AppendLine("End: " + DateTime.Now);
                                if (reportDataImport.Acknowledgment)
                                {
                                    processResult.AppendLine("Message: " + reportDataImport.Message);
                                }
                                else
                                {
                                    processResult.AppendLine("Error Message: " + reportDataImport.Message);
                                }
                                progressBar1.Value = progressBar1.Value + progressSize;
                                break;
                            case "fnProcessTreeMap":
                                processResult.AppendLine("********************************************");
                                processResult.AppendLine("Chart Name: " + chart.ChartName);
                                processResult.AppendLine("File name: " + chart.openDialgog.FileName.Split('\\')[chart.openDialgog.FileName.Split('\\').Length - 1]);
                                processResult.AppendLine("Start: " + DateTime.Now);
                                reportDataImport = _reportService.FnProcessTreeMap(new ReportDataImportRequest()
                                {
                                    ReportTemplateObject = chart
                                });
                                processResult.AppendLine("End: " + DateTime.Now);
                                if (reportDataImport.Acknowledgment)
                                {
                                    processResult.AppendLine("Message: " + reportDataImport.Message);
                                }
                                else
                                {
                                    processResult.AppendLine("Error Message: " + reportDataImport.Message);
                                }
                                progressBar1.Value = progressBar1.Value + progressSize;
                                break;
                            case "fnProcessWorldCloud":
                                processResult.AppendLine("********************************************");
                                processResult.AppendLine("Chart Name: " + chart.ChartName);
                                processResult.AppendLine("File name: " + chart.openDialgog.FileName.Split('\\')[chart.openDialgog.FileName.Split('\\').Length - 1]);
                                processResult.AppendLine("Start: " + DateTime.Now);
                                reportDataImport = _reportService.FnProcessWorldCloud(new ReportDataImportRequest()
                                {
                                    ReportTemplateObject = chart
                                });
                                processResult.AppendLine("End: " + DateTime.Now);
                                if (reportDataImport.Acknowledgment)
                                {
                                    processResult.AppendLine("Message: " + reportDataImport.Message);
                                }
                                else
                                {
                                    processResult.AppendLine("Error Message: " + reportDataImport.Message);
                                }
                                progressBar1.Value = progressBar1.Value + progressSize;
                                break;
                            case "fnProcessPie":
                                processResult.AppendLine("********************************************");
                                processResult.AppendLine("Chart Name: " + chart.ChartName);
                                processResult.AppendLine("File name: " + chart.openDialgog.FileName.Split('\\')[chart.openDialgog.FileName.Split('\\').Length - 1]);
                                processResult.AppendLine("Start: " + DateTime.Now);
                                reportDataImport = _reportService.FnProcessPie(new ReportDataImportRequest()
                                {
                                    ReportTemplateObject = chart
                                });
                                processResult.AppendLine("End: " + DateTime.Now);
                                if (reportDataImport.Acknowledgment)
                                {
                                    processResult.AppendLine("Message: " + reportDataImport.Message);
                                }
                                else
                                {
                                    processResult.AppendLine("Error Message: " + reportDataImport.Message);
                                }
                                progressBar1.Value = progressBar1.Value + progressSize;
                                break;
                            case "fnProcessMostProfilicUsers":
                                processResult.AppendLine("********************************************");
                                processResult.AppendLine("Chart Name: " + chart.ChartName);
                                processResult.AppendLine("File name: " + chart.openDialgog.FileName.Split('\\')[chart.openDialgog.FileName.Split('\\').Length - 1]);
                                processResult.AppendLine("Start: " + DateTime.Now);
                                reportDataImport = _reportService.FnProcessMostProfilicUsers(new ReportDataImportRequest()
                                {
                                    ReportTemplateObject = chart
                                });
                                processResult.AppendLine("End: " + DateTime.Now);
                                if (reportDataImport.Acknowledgment)
                                {
                                    processResult.AppendLine("Message: " + reportDataImport.Message);
                                }
                                else
                                {
                                    processResult.AppendLine("Error Message: " + reportDataImport.Message);
                                }
                                progressBar1.Value = progressBar1.Value + progressSize;
                                break;
                            case "fnProcessLocationAnalysis":
                                processResult.AppendLine("********************************************");
                                processResult.AppendLine("Chart Name: " + chart.ChartName);
                                processResult.AppendLine("File name: " + chart.openDialgog.FileName.Split('\\')[chart.openDialgog.FileName.Split('\\').Length - 1]);
                                processResult.AppendLine("Start: " + DateTime.Now);
                                reportDataImport = _reportService.FnProcessLocationAnalysis(new ReportDataImportRequest()
                                {
                                    ReportTemplateObject = chart
                                });
                                processResult.AppendLine("End: " + DateTime.Now);
                                if (reportDataImport.Acknowledgment)
                                {
                                    processResult.AppendLine("Message: " + reportDataImport.Message);
                                }
                                else
                                {
                                    processResult.AppendLine("Error Message: " + reportDataImport.Message);
                                }
                                progressBar1.Value = progressBar1.Value + progressSize;
                                break;
                            case "fnProcessConversationStream":
                                processResult.AppendLine("********************************************");
                                processResult.AppendLine("Chart Name: " + chart.ChartName);
                                processResult.AppendLine("File name: " + chart.openDialgog.FileName.Split('\\')[chart.openDialgog.FileName.Split('\\').Length - 1]);
                                processResult.AppendLine("Start: " + DateTime.Now);
                                reportDataImport = _reportService.FnProcessConversationStream(new ReportDataImportRequest()
                                {
                                    ReportTemplateObject = chart
                                });
                                processResult.AppendLine("End: " + DateTime.Now);
                                if (reportDataImport.Acknowledgment)
                                {
                                    processResult.AppendLine("Message: " + reportDataImport.Message);
                                }
                                else
                                {
                                    processResult.AppendLine("Error Message: " + reportDataImport.Message);
                                }
                                progressBar1.Value = progressBar1.Value + progressSize;
                                break;                         
                            case "fnProcessTopUserSummary":
                                processResult.AppendLine("********************************************");
                                processResult.AppendLine("Chart Name: " + chart.ChartName);
                                processResult.AppendLine("File name: " + chart.openDialgog.FileName.Split('\\')[chart.openDialgog.FileName.Split('\\').Length - 1]);
                                processResult.AppendLine("Start: " + DateTime.Now);
                                reportDataImport = _reportService.FnProcessTopUser(new ReportDataImportRequest()
                                {
                                    ReportTemplateObject = chart
                                });
                                processResult.AppendLine("End: " + DateTime.Now);
                                if (reportDataImport.Acknowledgment)
                                {
                                    processResult.AppendLine("Message: " + reportDataImport.Message);
                                }
                                else
                                {
                                    processResult.AppendLine("Error Message: " + reportDataImport.Message);
                                }
                                progressBar1.Value = progressBar1.Value + progressSize;
                                break;
                            case "fnProcessBestDaySummary":
                                processResult.AppendLine("********************************************");
                                processResult.AppendLine("Chart Name: " + chart.ChartName);
                                processResult.AppendLine("File name: " + chart.openDialgog.FileName.Split('\\')[chart.openDialgog.FileName.Split('\\').Length - 1]);
                                processResult.AppendLine("Start: " + DateTime.Now);
                                reportDataImport = _reportService.FnProcessBestDay(new ReportDataImportRequest()
                                {
                                    ReportTemplateObject = chart
                                });
                                processResult.AppendLine("End: " + DateTime.Now);
                                if (reportDataImport.Acknowledgment)
                                {
                                    processResult.AppendLine("Message: " + reportDataImport.Message);
                                }
                                else
                                {
                                    processResult.AppendLine("Error Message: " + reportDataImport.Message);
                                }
                                progressBar1.Value = progressBar1.Value + progressSize;
                                break;

                        }
                    }
                    

                }

                progressBar1.Value = 100;
                chkAppend.Enabled = true;
                btn_process.Enabled = true;
                btn_cancel.Enabled = true;

                var operationLog = new frmOperationLog();
                operationLog.txtResultArea.Text = processResult.ToString();
                operationLog.Show();
            }

        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            //reset form values

            btn_process.Enabled = false;
            cmb_subscription.SelectedIndex = 0;

            lbl_progress.Text = "Processing file: ";
            //lbl_progress.Visible = false;
            //progressBar1.Visible = false;
            progressBar1.Maximum = 100;

            chkAppend.Enabled = true;
            chkAppend.Checked = false;


        }



        private void btnAddSubscription_Click(object sender, EventArgs e)
        {
            //call the add new subscription form
            ServiceSubscriptionsFrm_v2 ssFrm = new ServiceSubscriptionsFrm_v2();
            ssFrm.ShowDialog();

        }

        public void refreshDropDowns()
        {
            using (SmartSocialdbDataContext smartsocialDB = new SmartSocialdbDataContext())
            {
                //load all service subscriptors that are active
                var query = smartsocialDB.ServiceSubscription.ByIsActive(true).ToList();

                if (query.Count > 0)
                {
                    //fill the service subscriptors combo with values from the DB
                    cmb_subscription.DataSource = query;
                    cmb_subscription.DisplayMember = "SubscriptionName";
                    cmb_subscription.ValueMember = "IdServiceSubscription";
                }
                else
                {
                    //no info of service subscriptors available in the DB
                    cmb_subscription.Items.Clear();
                    cmb_subscription.Items.Add("no info available");
                    cmb_subscription.SelectedIndex = 0;
                }

            }
        }

        public void refreshDropDowns2()
        {
            using (SmartSocialdbDataContext smartsocialDB = new SmartSocialdbDataContext())
            {

                //load all service delivery order by date created desc
                var query2 = smartsocialDB.ServiceDelivery.ByIdServiceSubscription(int.Parse(cmb_subscription.SelectedValue.ToString())).OrderByDescending(m => m.DateDelivered).ToList();
                //var query2 = smartsocialDB.ServiceDelivery.ToList();

                if (query2.Count > 0)
                {
                    //fill the service delivery combo with values from the DB
                    cmd_delivery.DataSource = query2;
                    cmd_delivery.DisplayMember = "datedelivered";
                    cmd_delivery.ValueMember = "IdServiceDelivery";
                }
                else
                {
                    //no info of service delivery available in the DB
                    cmd_delivery.Items.Clear();
                    cmd_delivery.Items.Add("no info available");
                    cmd_delivery.SelectedIndex = 0;
                }
            }

        }

        private void btnDeleteSubscription_Click(object sender, EventArgs e)
        {
            //declare SQL DB context var
            SmartSocialdbDataContext smartsocialDB = new SmartSocialdbDataContext();
            ServiceSubscription newServiceSubscriptionsRow = new ServiceSubscription();

            try
            {
                DialogResult result = MessageBox.Show("Do you want to delete record >> " + cmb_subscription.Text + " ?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //delete selected reocrd in ServiceSubscription table
                    smartsocialDB.ServiceSubscription.Delete(int.Parse(cmb_subscription.SelectedValue.ToString()));
                    smartsocialDB.SubmitChanges();
                    smartsocialDB.Connection.Close();
                    //refresh dropdowns
                    refreshDropDowns();
                }

            }

            catch (Exception ex)
            {
                //show any error message returned by the database
                MessageBox.Show(ex.Message);

            }

        }

        private void btnEditSubscription_Click(object sender, EventArgs e)
        {
            //call the edit subscription form
            ServiceSubscriptionsEditFrm_v2 ssFrm = new ServiceSubscriptionsEditFrm_v2();
            ssFrm.loadInitialData(int.Parse(cmb_subscription.SelectedValue.ToString()));
            ssFrm.ShowDialog();

        }

        private void btnAddDelivery_Click(object sender, EventArgs e)
        {
            //call the add new delivery form
            ServiceDeliveryFrm_v2 sdFrm = new ServiceDeliveryFrm_v2();
            sdFrm.loadInitialData(cmb_subscription.SelectedIndex);
            sdFrm.ShowDialog();

        }

        private void btnDeleteDelivery_Click(object sender, EventArgs e)
        {
            //declare SQL DB context var
            SmartSocialdbDataContext smartsocialDB = new SmartSocialdbDataContext();
            ServiceDelivery newServiceDeliveryRow = new ServiceDelivery();

            try
            {
                DialogResult result = MessageBox.Show("Do you want to delete record >> " + cmd_delivery.Text + " ?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //delete selected reocrd in ServiceDelivery table
                    smartsocialDB.ServiceDelivery.Delete(int.Parse(cmd_delivery.SelectedValue.ToString()));
                    smartsocialDB.SubmitChanges();
                    smartsocialDB.Connection.Close();
                    //refresh dropdowns
                    refreshDropDowns2();
                }

            }

            catch (Exception ex)
            {
                //show any error message returned by the database
                MessageBox.Show(ex.Message);

            }

        }

        private void btnEditDelivery_Click(object sender, EventArgs e)
        {
            //call the edit delivery form
            ServiceDeliveryEditFrm_v2 ssFrm = new ServiceDeliveryEditFrm_v2();
            ssFrm.loadInitialData(int.Parse(cmd_delivery.SelectedValue.ToString()));
            ssFrm.ShowDialog();

        }


        private void RefreshCascadeDropDowns()
        {
            cmb_report.Text = "";

            try
            {
                //connect to DB context
                using (SmartSocialdbDataContext smartsocialDB = new SmartSocialdbDataContext())
                {

                    //load all service delivery order by date created desc and filter by Service Subscription selected
                    if (cmb_subscription.SelectedValue == null)
                    {
                        var query2 = smartsocialDB.ServiceDelivery.ByIdServiceSubscription(-1).OrderByDescending(m => m.DateDelivered).ToList();
                        if (query2.Count > 0)
                        {
                            //fill the service delivery combo with values from the DB
                            cmd_delivery.DataSource = query2;
                            cmd_delivery.DisplayMember = "datedelivered";
                            cmd_delivery.ValueMember = "IdServiceDelivery";
                        }
                        else
                        {
                            //no info of service delivery available in the DB
                            cmd_delivery.DataSource = query2;
                            cmd_delivery.DisplayMember = "datedelivered";
                            cmd_delivery.ValueMember = "IdServiceDelivery";
                        }

                    }
                    else
                    {
                        var query2 = smartsocialDB.ServiceDelivery.ByIdServiceSubscription(int.Parse(cmb_subscription.SelectedValue.ToString())).OrderByDescending(m => m.DateDelivered).ToList();
                        if (query2.Count > 0)
                        {
                            //fill the service delivery combo with values from the DB
                            cmd_delivery.DataSource = query2;
                            cmd_delivery.DisplayMember = "datedelivered";
                            cmd_delivery.ValueMember = "IdServiceDelivery";
                        }
                        else
                        {
                            //no info of service delivery available in the DB
                            cmd_delivery.DataSource = query2;
                            cmd_delivery.DisplayMember = "datedelivered";
                            cmd_delivery.ValueMember = "IdServiceDelivery";
                        }

                    }

                    if (chkAppend.Checked)
                    {
                        //load all reports filter by Service Delivery
                        if (cmd_delivery.SelectedValue == null)
                        {
                            var query3 = smartsocialDB.SmartReport.ByIdServiceDelivery(-1).OrderBy(m => m.ReportName).ToList();
                            if (query3.Count > 0)
                            {
                                //fill the service delivery combo with values from the DB
                                cmb_report.DataSource = query3;
                                cmb_report.DisplayMember = "ReportName";
                                cmb_report.ValueMember = "IdSmartReport";
                            }
                            else
                            {
                                //no info of service delivery available in the DB
                                cmb_report.DataSource = query3;
                                cmb_report.DisplayMember = "ReportName";
                                cmb_report.ValueMember = "IdSmartReport";
                            }
                        }
                        else
                        {
                            //var query3 = smartsocialDB.SmartReport.ByIdServiceDelivery(int.Parse(cmd_delivery.SelectedValue.ToString())).OrderBy(m => m.ReportName).ToList();

                            var query3 = from c in smartsocialDB.SmartReport.ByIdServiceDelivery(int.Parse(cmd_delivery.SelectedValue.ToString())).OrderBy(m => m.ReportName)
                                         join p in smartsocialDB.ServiceDelivery on c.IdServiceDelivery equals p.IdServiceDelivery
                                         select new
                                         {
                                             ReportName = c.IdSmartReport + " - " + c.ReportName,
                                             c.IdSmartReport
                                         };

                            if (query3.ToList().Count > 0)
                            {
                                //fill the service delivery combo with values from the DB
                                cmb_report.DataSource = query3;
                                cmb_report.DisplayMember = "ReportName";
                                cmb_report.ValueMember = "IdSmartReport";
                            }
                            else
                            {
                                //no info of service delivery available in the DB
                                cmb_report.DataSource = query3;
                                cmb_report.DisplayMember = "ReportName";
                                cmb_report.ValueMember = "IdSmartReport";
                            }
                        }
                    }
                    else
                    {
                        //var query3 = smartsocialDB.SmartReport.ByIdServiceDelivery(int.Parse(cmd_delivery.SelectedValue.ToString())).OrderBy(m => m.ReportName).ToList();

                        var query3 = from c in smartsocialDB.SmartReport.ByIsTemplate(true).OrderBy(m => m.ReportName)
                                     join p in smartsocialDB.ServiceDelivery on c.IdServiceDelivery equals p.IdServiceDelivery
                                     select new
                                     {
                                         ReportName = c.IdSmartReport + " - " + c.ReportName,
                                         c.IdSmartReport
                                     };

                        if (query3.ToList().Count > 0)
                        {
                            //fill the service delivery combo with values from the DB
                            cmb_report.DataSource = query3;
                            cmb_report.DisplayMember = "ReportName";
                            cmb_report.ValueMember = "IdSmartReport";
                        }
                        else
                        {
                            //no info of service delivery available in the DB
                            cmb_report.DataSource = query3;
                            cmb_report.DisplayMember = "ReportName";
                            cmb_report.ValueMember = "IdSmartReport";
                        }
                    }
                }

            }

            catch (Exception ex)
            {
            }

        }

        private void chkAppend_CheckedChanged(object sender, EventArgs e)
        {
            cmb_report.Text = "";

            //if check box for Append Data is checked then deactivate several buttons
            if (chkAppend.Checked)
            {
                label1.Text = "Existing Report";





                //connect to DB context
                using (SmartSocialdbDataContext smartsocialDB = new SmartSocialdbDataContext())
                {
                    //load all reports filter by Service Delivery
                    if (cmd_delivery.SelectedValue == null)
                    {
                        var query3 = smartsocialDB.SmartReport.ByIdServiceDelivery(-1).OrderBy(m => m.ReportName).ToList();
                        if (query3.Count > 0)
                        {
                            //fill the service delivery combo with values from the DB
                            cmb_report.DataSource = query3;
                            cmb_report.DisplayMember = "ReportName";
                            cmb_report.ValueMember = "IdSmartReport";
                        }
                        else
                        {
                            //no info of service delivery available in the DB
                            cmb_report.DataSource = query3;
                            cmb_report.DisplayMember = "ReportName";
                            cmb_report.ValueMember = "IdSmartReport";
                        }
                    }
                    else
                    {
                        //var query3 = smartsocialDB.SmartReport.ByIdServiceDelivery(int.Parse(cmd_delivery.SelectedValue.ToString())).OrderBy(m => m.ReportName).ToList();

                        var query3 = from c in smartsocialDB.SmartReport.ByIdServiceDelivery(int.Parse(cmd_delivery.SelectedValue.ToString())).OrderBy(m => m.ReportName)
                                     join p in smartsocialDB.ServiceDelivery on c.IdServiceDelivery equals p.IdServiceDelivery
                                     select new
                                     {
                                         ReportName = c.IdSmartReport + " - " + c.ReportName,
                                         c.IdSmartReport
                                     };

                        if (query3.ToList().Count > 0)
                        {
                            //fill the service delivery combo with values from the DB
                            cmb_report.DataSource = query3;
                            cmb_report.DisplayMember = "ReportName";
                            cmb_report.ValueMember = "IdSmartReport";
                            //query3.FirstOrDefault().IdSmartReport
                        }
                        else
                        {
                            //no info of service delivery available in the DB
                            cmb_report.DataSource = query3;
                            cmb_report.DisplayMember = "ReportName";
                            cmb_report.ValueMember = "IdSmartReport";
                        }
                    }

                }

            }
            //if check box for Append Data is not checked then activate several buttons
            else
            {
                label1.Text = "Template Report";



                //connect to DB context
                using (SmartSocialdbDataContext smartsocialDB = new SmartSocialdbDataContext())
                {
                    //load all reports filter by Service Delivery
                    if (cmd_delivery.SelectedValue == null)
                    {
                        var query3 = smartsocialDB.SmartReport.ByIdServiceDelivery(-1).OrderBy(m => m.ReportName).ToList();
                        if (query3.Count > 0)
                        {
                            //fill the service delivery combo with values from the DB
                            cmb_report.DataSource = query3;
                            cmb_report.DisplayMember = "ReportName";
                            cmb_report.ValueMember = "IdSmartReport";
                        }
                        else
                        {
                            //no info of service delivery available in the DB
                            cmb_report.DataSource = query3;
                            cmb_report.DisplayMember = "ReportName";
                            cmb_report.ValueMember = "IdSmartReport";
                        }
                    }
                    else
                    {
                        //var query3 = smartsocialDB.SmartReport.ByIdServiceDelivery(int.Parse(cmd_delivery.SelectedValue.ToString())).OrderBy(m => m.ReportName).ToList();

                        var query3 = from c in smartsocialDB.SmartReport.ByIsTemplate(true).OrderBy(m => m.ReportName)
                                     join p in smartsocialDB.ServiceDelivery on c.IdServiceDelivery equals p.IdServiceDelivery
                                     select new
                                     {
                                         ReportName = c.IdSmartReport + " - " + c.ReportName,
                                         c.IdSmartReport
                                     };

                        if (query3.ToList().Count > 0)
                        {
                            //fill the service delivery combo with values from the DB
                            cmb_report.DataSource = query3;
                            cmb_report.DisplayMember = "ReportName";
                            cmb_report.ValueMember = "IdSmartReport";
                        }
                        else
                        {
                            //no info of service delivery available in the DB
                            cmb_report.DataSource = query3;
                            cmb_report.DisplayMember = "ReportName";
                            cmb_report.ValueMember = "IdSmartReport";
                        }
                    }

                }

            }

            //reset form values

        }

        private void cmb_subscriptionV2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //connect to DB context
                using (SmartSocialdbDataContext smartsocialDB = new SmartSocialdbDataContext())
                {
                    //load all service delivery order by date created desc and filter by Service Subscription selected
                    var query2 = smartsocialDB.ServiceDelivery.ByIdServiceSubscription(int.Parse(cmb_subscription.SelectedValue.ToString())).OrderByDescending(m => m.DateDelivered).ToList();
                    //var query2 = smartsocialDB.ServiceDelivery.ToList();

                    if (query2.Count > 0)
                    {
                        //fill the service delivery combo with values from the DB
                        cmd_delivery.DataSource = query2;
                        cmd_delivery.DisplayMember = "datedelivered";
                        cmd_delivery.ValueMember = "IdServiceDelivery";
                    }
                    else
                    {
                        //no info of service delivery available in the DB
                        cmd_delivery.DataSource = query2;
                        cmd_delivery.DisplayMember = "datedelivered";
                        cmd_delivery.ValueMember = "IdServiceDelivery";
                        cmd_delivery.Text = "";
                    }

                }

            }

            catch (Exception ex)
            {
            }

        }

        private void cmd_deliveryV2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_report.Text = "";
            try
            {
                //connect to DB context
                using (SmartSocialdbDataContext smartsocialDB = new SmartSocialdbDataContext())
                {
                    if (chkAppend.Checked)
                    {
                        //load all reports filter by Service Delivery
                        if (cmd_delivery.SelectedValue == null)
                        {
                            var query3 = smartsocialDB.SmartReport.ByIdServiceDelivery(-1).OrderBy(m => m.ReportName).ToList();
                            if (query3.Count > 0)
                            {
                                //fill the service delivery combo with values from the DB
                                cmb_report.DataSource = query3;
                                cmb_report.DisplayMember = "ReportName";
                                cmb_report.ValueMember = "IdSmartReport";
                            }
                            else
                            {
                                //no info of service delivery available in the DB
                                cmb_report.DataSource = query3;
                                cmb_report.DisplayMember = "ReportName";
                                cmb_report.ValueMember = "IdSmartReport";
                            }
                        }
                        else
                        {
                            //var query3 = smartsocialDB.SmartReport.ByIdServiceDelivery(int.Parse(cmd_delivery.SelectedValue.ToString())).OrderBy(m => m.ReportName).ToList();

                            var query3 = from c in smartsocialDB.SmartReport.ByIdServiceDelivery(int.Parse(cmd_delivery.SelectedValue.ToString())).OrderBy(m => m.ReportName)
                                         join p in smartsocialDB.ServiceDelivery on c.IdServiceDelivery equals p.IdServiceDelivery
                                         select new
                                         {
                                             ReportName = c.IdSmartReport + " - " + c.ReportName,
                                             c.IdSmartReport
                                         };

                            if (query3.ToList().Count > 0)
                            {
                                //fill the service delivery combo with values from the DB
                                cmb_report.DataSource = query3;
                                cmb_report.DisplayMember = "ReportName";
                                cmb_report.ValueMember = "IdSmartReport";
                                cmb_report.SelectedIndexChanged += new EventHandler(ReDisplay);
                            }
                            else
                            {
                                //no info of service delivery available in the DB
                                cmb_report.DataSource = query3;
                                cmb_report.DisplayMember = "ReportName";
                                cmb_report.ValueMember = "IdSmartReport";
                            }

                        }
                    }
                    else
                    {
                        //var query3 = smartsocialDB.SmartReport.ByIdServiceDelivery(int.Parse(cmd_delivery.SelectedValue.ToString())).OrderBy(m => m.ReportName).ToList();

                        var query3 = from c in smartsocialDB.SmartReport.ByIsTemplate(true).OrderBy(m => m.ReportName)
                                     join p in smartsocialDB.ServiceDelivery on c.IdServiceDelivery equals p.IdServiceDelivery
                                     select new
                                     {
                                         ReportName = c.IdSmartReport + " - " + c.ReportName,
                                         c.IdSmartReport
                                     };

                        if (query3.ToList().Count > 0)
                        {
                            //fill the service delivery combo with values from the DB
                            cmb_report.DataSource = query3;
                            cmb_report.DisplayMember = "ReportName";
                            cmb_report.ValueMember = "IdSmartReport";
                        }
                        else
                        {
                            //no info of service delivery available in the DB
                            cmb_report.DataSource = query3;
                            cmb_report.DisplayMember = "ReportName";
                            cmb_report.ValueMember = "IdSmartReport";
                        }
                    }

                }
            }

            catch (Exception ex)
            {
            }

        }












    }
}
