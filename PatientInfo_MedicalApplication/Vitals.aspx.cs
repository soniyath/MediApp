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
    public partial class Vitals : System.Web.UI.Page
    {
        //global declarations

        //global declarations
        string connetionString = null;
        SqlConnection cnn;
        SqlCommand command;
        private int mrn;
        VitalsObj vitals;


        protected void Page_Load(object sender, EventArgs e)
        {
            mrn = (int)(Session["MRN"]);    //  our session mrn
            lblMRN.Text = $"{mrn}"; //  assign the label the MRN

            //  create a new vitals object
            vitals = new VitalsObj();

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
            //  Back to dashboard
            Response.Redirect("Dashboard.aspx");
        }
        protected void cmdSubmit_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                // initializing variables from form to sent them to table 
                vitals.Systolic = int.Parse(Systolic.Text);
                vitals.Diastolic = int.Parse(Diastolic.Text);
                vitals.O2_Levels = int.Parse(o2_Levels.Text);
                vitals.Pulse = int.Parse(Pulse.Text);
                vitals.Respiratory_Rate = int.Parse(Respiratory_Rate.Text);
                vitals.DateTime = DateTime.Now.ToString();

                try
                {
                    //  Insert command to input data into the DataBase
                    cnn.Open();
                    command = new SqlCommand("Insert into dbo.Vitals values" +
                                             "(@mrn,@systolic,@diastolic,@o2_Levels,@pulse,@respiratory_rate,@DateTime)", cnn);
                    command.Parameters.AddWithValue("@mrn", mrn);
                    command.Parameters.AddWithValue("@systolic", vitals.Systolic);
                    command.Parameters.AddWithValue("@diastolic", vitals.Diastolic);
                    command.Parameters.AddWithValue("@o2_Levels", vitals.O2_Levels);
                    command.Parameters.AddWithValue("@pulse", vitals.Pulse);
                    command.Parameters.AddWithValue("@respiratory_rate", vitals.Respiratory_Rate);
                    command.Parameters.AddWithValue("@DateTime", vitals.DateTime);

                    command.ExecuteNonQuery();
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