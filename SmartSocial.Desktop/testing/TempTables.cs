using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SmartSocial.Data;

namespace SmartSocial.Desktop.testing
{
    public partial class TempTables : Form
    {
        public TempTables()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SmartSocialdbDataContext myDB = new SmartSocialdbDataContext())
            {
        

                using (SqlConnection sqlconnection = new SqlConnection(@"Data Source=208.43.238.109, 780;Initial Catalog=espriella_SmartSocial;Persist Security Info=True;User ID=espri_admin;Password=SmartSocial00!"))
                {
                    sqlconnection.Open();
                    SqlCommand MyCommand1 = new SqlCommand("SELECT * INTO ##ItemBack1 FROM AspNetUsers", sqlconnection);
                    SqlCommand MyCommand2 = new SqlCommand("SELECT count(*) from ##ItemBack1", sqlconnection);
                    MessageBox.Show(MyCommand2.ExecuteScalar().ToString());
                    sqlconnection.Close();
                }

                

                
            }
        }
    }
}
