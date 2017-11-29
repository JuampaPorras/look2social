using System;
using System.Windows.Forms;
using SmartSocial.Data;

namespace SmartSocial.Desktop
{
    public partial class ServiceSubscriptionsEditFrm_v2 : Form
    {
        public ServiceSubscriptionsEditFrm_v2()
        {
            InitializeComponent();
        }

        private void ServiceSubscriptions_Load(object sender, EventArgs e)
        {

        }

        private void ServiceSubscriptions_Closing(object sender, FormClosingEventArgs e)
        {
            //get a reference of Main form in order to execute necessary code that will refresh the controls
            MainCustomer mainFrm = (MainCustomer)Application.OpenForms["MainCustomer"];
            if (mainFrm != null)
            {
                mainFrm.refreshDropDowns();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //close this window
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //declare SQL DB context var
            SmartSocialdbDataContext smartsocialDB = new SmartSocialdbDataContext();
            ServiceSubscription newServiceSubscriptionsRow = new ServiceSubscription();

            try
            {
                //update selected record in ServiceSubscription table
                var subscriptionRow = smartsocialDB.ServiceSubscription.GetByKey(int.Parse(txtID.Text));
                subscriptionRow.SubscriptionName = txtName.Text;
                subscriptionRow.StartDate = startDate.Value;
                subscriptionRow.EndDate = endDate.Value;
                subscriptionRow.IsActive = isActive.Checked;
                smartsocialDB.SubmitChanges();
                smartsocialDB.Connection.Close();
                //close this window
                this.Close();

            }

            catch (Exception ex)
            {
                //show any error message returned by the database
                MessageBox.Show(ex.Message);
            }
        }

        public void loadInitialData(int subscriptionID)
        {
            //declare SQL DB context var
            SmartSocialdbDataContext smartsocialDB = new SmartSocialdbDataContext();
            ServiceSubscription newServiceSubscriptionsRow = new ServiceSubscription();

            try
            {
                //load data base on ID passed from main form
                txtID.Text = smartsocialDB.ServiceSubscription.GetByKey(subscriptionID).IdServiceSubscription.ToString();
                txtName.Text= smartsocialDB.ServiceSubscription.GetByKey(subscriptionID).SubscriptionName;
                startDate.Value = (DateTime)smartsocialDB.ServiceSubscription.GetByKey(subscriptionID).StartDate;
                endDate.Value = (DateTime)smartsocialDB.ServiceSubscription.GetByKey(subscriptionID).EndDate;
                isActive.Checked = (bool)smartsocialDB.ServiceSubscription.GetByKey(subscriptionID).IsActive;
                smartsocialDB.Connection.Close();

            }

            catch (Exception ex)
            {
                //show any error message returned by the database
                MessageBox.Show(ex.Message);
            }
        }
    }
}
