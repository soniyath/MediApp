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
    public partial class Default : System.Web.UI.Page
    {
        //global declarations
        string connetionString = null;
        SqlConnection cnn;
        SqlCommand command;
        Patient patient;
        protected void Page_Load(object sender, EventArgs e)
        {
            connetionString = "Data Source=YAS;" +
                "" +
                "Initial Catalog=MedicalAppDB;" +
                "Integrated Security=SSPI;Persist Security Info=false";
            cnn = new SqlConnection(connetionString);
            patient = new Patient();
        }

        protected void cmdGetPatient_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //  login
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Select MRN from dbo.Patient where MRN = @mrn", cnn);
                    command.Parameters.AddWithValue("@mrn", mrnNum.Text);
                    SqlDataReader reader = command.ExecuteReader();

                    //  if login info is correct
                    if (reader.Read())
                    {



                        // assign the MRN to the patient object and pass this in through the session
                        patient.MRN = int.Parse(reader["MRN"].ToString());
                        Session["MRN"] = patient.MRN;

                          //redirect to the PatientInfo page
                        Response.Redirect("PatientInfo.aspx");
                    }
                    //  otherwise display invalid credentials
                    else
                    {
                        lblMessage.Attributes.CssStyle.Add("color", "red");
                        lblMessage.Text = "No existing patient containst this Medical Record Number";

                    }

                }

                catch (SqlException ex)
                {
                    lblMessage.Text = "Error in SQL! " + ex.Message;
                }

                finally
                {
                    if (cnn.State == ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }
            }
            else
            {
                lblMessage.Text = "";
            }
        }

        protected void cmdNewPatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientRegistration.aspx");
        }

        protected void cmdAllPatients_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllPatients.aspx");
        }

        protected void loginPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}