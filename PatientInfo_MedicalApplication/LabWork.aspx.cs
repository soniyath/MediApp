using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatientInfo_MedicalApplication
{
    public partial class LabWork : System.Web.UI.Page
    {
        // global declarations
        string connetionString = null;
        SqlConnection cnn;
        SqlCommand command;
        private int mrn;
        LabWorkObj labWork;
        protected void Page_Load(object sender, EventArgs e)
        {
            mrn = (int)(Session["MRN"]);    //  our session mrn
            lblMRN.Text = $"{mrn}";
            labWork = new LabWorkObj();

            connetionString = "Data Source=YAS;" +
                "" +
                "Initial Catalog=MedicalAppDB;" +
                "Integrated Security=SSPI;Persist Security Info=false";
            cnn = new SqlConnection(connetionString);
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            //  Kill the session and go back to the main page
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        protected void cmdDashboard_Click(object sender, EventArgs e)
        {
            //  go back to dashboard
            Response.Redirect("Dashboard.aspx");
        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //  assign the values to the labwork object parameters
                labWork.DateTime = DateTime.Now.ToString();
                labWork.Creatinine = double.Parse(numCreatinine.Text);
                labWork.Hemoglobin = int.Parse(numHemoglobin.Text);
                labWork.WBC = double.Parse(numWBC.Text);
                labWork.Sodium = int.Parse(numSodium.Text);
                labWork.Potassium = double.Parse(numPotassium.Text);
                labWork.Fluoride = double.Parse(numFluoride.Text);

                //  if page is valid, try inserting into the databasee
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Insert into dbo.Lab_Work values" +
                                             "(@mrn,@DateTime,@Creatinine,@Hemoglobin,@WBC,@Sodium,@Potassium,@Fluoride)", cnn);
                    command.Parameters.AddWithValue("@mrn", mrn);
                    command.Parameters.AddWithValue("@DateTime", labWork.DateTime);
                    command.Parameters.AddWithValue("@Creatinine", labWork.Creatinine);
                    command.Parameters.AddWithValue("@Hemoglobin", labWork.Hemoglobin);
                    command.Parameters.AddWithValue("@WBC", labWork.WBC);
                    command.Parameters.AddWithValue("@Sodium", labWork.Sodium);
                    command.Parameters.AddWithValue("@Potassium", labWork.Potassium);
                    command.Parameters.AddWithValue("@Fluoride", labWork.Fluoride);

                    command.ExecuteNonQuery();

                    //  now redirect back to dashboard
                    Response.Redirect("Dashboard.aspx");
                }
                catch (SqlException ex)
                {
                    Response.Write("Error in SQL! " + ex.Message);
                }
                finally
                {
                    if (cnn.State == ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }
            }
        }
    }
}