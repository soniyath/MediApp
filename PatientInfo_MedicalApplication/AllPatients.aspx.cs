using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using System.Text;
using PatientInfo_MedicalApplication.AllPatientsService;

namespace PatientInfo_MedicalApplication
{
    public partial class AllPatients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Generating the Service Client

            AllPatientsService.Service1Client client = new AllPatientsService.Service1Client();
            string connetionString = null;
            SqlConnection cnn;
            SqlCommand command;

            //Connection String to the Database
            connetionString = "Data Source=YAS;" +
                "" +
                "Initial Catalog=MedicalAppDB;" +
                "Integrated Security=SSPI;Persist Security Info=false";
            cnn = new SqlConnection(connetionString);
            
            try
            {

                //Getting the Query from the service
                cnn.Open();
                string qry = client.GetQuery();
                //string qry = "Select * from dbo.Patient";
                command = new SqlCommand(qry, cnn);
                
                SqlDataReader reader = command.ExecuteReader();

                //Clearing all the existing text fields
                txtAllPatients.Text = " ";

                while (reader.Read())
                {

                    //filling up the text Box
                    txtAllPatients.Text += $"MRN: " +
                        $"{reader["MRN"].ToString()}\r\n\n" +
                        $"Patient Name: " +
                        $"{reader["First_Name"].ToString()} " +
                        $"{reader["Last_Name"].ToString()}\r\n\n" +
                        $"City : " +
                        $"{reader["City"].ToString()}\r\n\n" +
                        "-------------------------------------\r\n";

                }
            }
            catch (SqlException ex)
            {
                //Catching Errors
                patientErr.Text = "Error in SQL!";
                patientErr.Text = $"{ex.Message}";
                Response.Write("Error in SQL : " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }
            protected void loginPage_Click(object sender, EventArgs e)
        {
            //Redirecting to the Main Page(Login Page)
            Response.Redirect("Default.aspx");
        }
    }
}