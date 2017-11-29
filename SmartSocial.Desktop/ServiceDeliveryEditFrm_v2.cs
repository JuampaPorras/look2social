using System;
using System.Linq;
using System.Windows.Forms;
using SmartSocial.Data;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Services;

namespace SmartSocial.Desktop
{
    public partial class ServiceDeliveryEditFrm_v2 : Form
    {
        ServiceDeliveryService _deliveryService = new ServiceDeliveryService();

        public ServiceDeliveryEditFrm_v2()
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
            //declare SQL DB context var
            SmartSocialdbDataContext smartsocialDB = new SmartSocialdbDataContext();
            ServiceDelivery newServiceDeliveryRow = new ServiceDelivery();

            try
            {
                //update selected record in ServiceSubscription table
                var deliveryRow = smartsocialDB.ServiceDelivery.GetByKey(int.Parse(txtID.Text));
                deliveryRow.DateDelivered = startDate.Value;
                deliveryRow.IdServiceSubscription = int.Parse(cmb_subscription.SelectedValue.ToString());
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

        void loadServiceSubscriptors()
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
        public void loadInitialData(int deliveryID)
        {
            //call function that will load Service Subscriptions
            loadServiceSubscriptors();

            //declare SQL DB context var
            SmartSocialdbDataContext smartsocialDB = new SmartSocialdbDataContext();
            ServiceDelivery newServiceDeliveryRow = new ServiceDelivery();

            try
            {
                ServiceDeliveryResponse response = _deliveryService.GetServiceSDeliveryById(deliveryID);
                if (response.Acknowledgment)
                {
                    txtID.Text = response.ServiceDelivery.idServiceDelivery.ToString();
                    startDate.Value = (DateTime) response.ServiceDelivery.DateDelivered;
                    dtpTo.Value = (DateTime)response.ServiceDelivery.DeliveryDateTo;
                    cmb_subscription.SelectedValue = response.ServiceDelivery.IdServiceSubscription;
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

    }
}
