using System;
using System.Windows.Forms;
using SmartSocial.Data;

namespace SmartSocial.Desktop
{
    public partial class ServiceSubscriptionsFrm_v2 : Form
    {
        public ServiceSubscriptionsFrm_v2()
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
                //insert new record in ServiceSubscription table
                newServiceSubscriptionsRow.SubscriptionName = txtName.Text;
                newServiceSubscriptionsRow.StartDate = startDate.Value;
                newServiceSubscriptionsRow.EndDate = endDate.Value;
                newServiceSubscriptionsRow.IsActive = isActive.Checked;
                smartsocialDB.ServiceSubscription.InsertOnSubmit(newServiceSubscriptionsRow);
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

    }
}
