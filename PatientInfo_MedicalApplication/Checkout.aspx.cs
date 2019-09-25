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
    public partial class Checkout : System.Web.UI.Page
    {
        //global declarations
        string connetionString = null;
        SqlConnection cnn;
        SqlCommand command;
        //Patient class
        Patient patient;
        //Check out Class
        Checkout1 checkout;
        private int mrn;
        protected void Page_Load(object sender, EventArgs e)
        {

            //MRN Session
            mrn = (int)(Session["MRN"]);  
            lblMRN.Text = $"{mrn}";

            //patient instance initialization with the help of Session
            patient = (Patient)(Session["patient"]);

            //  connection string to the database
            connetionString = "Data Source=YAS;" +
            "" +
            "Initial Catalog=MedicalAppDB;" +
            "Integrated Security=SSPI;Persist Security Info=false";
            cnn = new SqlConnection(connetionString);

            if (!IsPostBack)
            {
                //  get the patient information from the Patient table from the MRN stored in the session 
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Select * from dbo.Patient where mrn = @MRN", cnn);
                    command.Parameters.AddWithValue("@MRN", mrn);

                    SqlDataReader reader = command.ExecuteReader();
                    
                    //Wrtitng the Patient information for reference during checkout
                    while (reader.Read())
                    {
                        lblMRN.Text = $"{mrn}";
                        lblName.Text = $"{reader["First_Name"].ToString()} {reader["Last_Name"].ToString()}";
                        lblAddress.Text = $"{reader["Address"].ToString()}";
                        lblCity.Text = $"{reader["City"].ToString()}";
                        lblProvince.Text = $"{reader["Province"].ToString()}";
                        lblPostal.Text = $"{reader["PostalCode"].ToString()}";
                        lblPhoneNumber.Text = $"{reader["PhoneNumber"].ToString()}";
                        lblAge.Text = $"{reader["Age"].ToString()}";
                        lblBloodType.Text = $"{reader["Blood_Type"].ToString()}";
                    }
                }
                catch (SqlException ex)
                {
                    //Catching and printing the Exception
                    lblMessage.Text = "Error in SQL!";
                    lblMessage.Text = $"{ex.Message}";
                }
                finally
                {
                    if (cnn.State == System.Data.ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }


            }
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            //  Kill the session and go back to the main page
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        //Redirection to Dashboard
        protected void cmdDashboard_Click(object sender, EventArgs e)
        {
            //  go back to dashboard
            Response.Redirect("Dashboard.aspx");
        }


        protected void cmdUpdatePatient_Click(object sender, EventArgs e)
        {
            //  redirect to the update patient info page
            Response.Redirect("UpdatePatientInfo.aspx");
        }

        protected void addConclusions_Click(object sender, EventArgs e)
        {
            //  if validation is successful
            if (Page.IsValid)
            {
                //  create an existing conditions object to store in the databasee
                checkout = new Checkout1();

                checkout.Discharge_Instructions = txtDischargeInstr.Text;
                checkout.Required_follow_Up_Date = txtFollowUps.Text;
                checkout.Conclusions = txtConclusions.Text;
                checkout.DateTime = DateTime.Today.ToLongDateString();

                //  clear the conditions listbox
                //this.addCheckoutList.Items.Clear();

                mrn = (int)(Session["MRN"]);    //  our session mrn

                Response.Write("Check 1");
                //  insert the new existing condition object into the existing conditions database
                try
                {
                    //initiating the SQL Connection...
                    cnn.Open();
                    command = new SqlCommand("Insert into dbo.Checkout values" +
                        "(@MRN, @DateTime, @Discharge_Instructions ,@Required_Follow_Up_Date, @Conclusions)", cnn);

                    //Inserting the parameters with the help of instance checkout
                    command.Parameters.AddWithValue("@MRN", mrn);
                    command.Parameters.AddWithValue("@DateTime", checkout.DateTime);
                    command.Parameters.AddWithValue("@Discharge_Instructions", checkout.Discharge_Instructions); ;
                    command.Parameters.AddWithValue("@Required_Follow_Up_Date", checkout.Required_follow_Up_Date); ;
                    command.Parameters.AddWithValue("@Conclusions", checkout.Conclusions); ;

                    command.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    lblMessage.Text = "Error in SQL! " + ex.Message;
                    Response.Write("Error in SQL : "+ex.Message);

                }
                finally
                {
                    if (cnn.State == ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }
                    
                //Clearing up all the fields
                this.txtConclusions.Text = "";
                this.txtDischargeInstr.Text = "";
                this.txtFollowUps.Text = "";
                Response.Redirect("Dashboard.aspx");
            }
        }
    }
}  