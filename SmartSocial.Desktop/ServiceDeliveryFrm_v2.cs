using System;
using System.Linq;
using System.Windows.Forms;
using SmartSocial.Data;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Services;

namespace SmartSocial.Desktop
{
    public partial class ServiceDeliveryFrm_v2 : Form
    {
        ServiceDeliveryService _deliveryService = new ServiceDeliveryService();
        public ServiceDeliveryFrm_v2()
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
                mainFrm.refreshDropDowns2();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //close this window
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BaseResponse response = _deliveryService.AddServiceDelivery(startDate.Value, dtpTo.Value,
                    int.Parse(cmb_subscription.SelectedValue.ToString()));
                if (response.Acknowledgment)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response.Message);
                }

            }

            catch (Exception ex)
            {
                //show any error message returned by the database
                MessageBox.Show(ex.Message);
            }
        }

        public void loadInitialData(int comboIndex)
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
                    cmb_subscription.SelectedIndex = comboIndex;
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


    }
}
