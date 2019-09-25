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
    public partial class UpdatePatientInfo : System.Web.UI.Page
    {
        //global declarations
        string connetionString = null;
        SqlConnection cnn;
        SqlCommand command;
        private int mrn;
        Patient patient;
        protected void Page_Load(object sender, EventArgs e)
        {
            mrn = (int)(Session["MRN"]);    //  get our session variable

            // create a new patient object
            patient = new Patient();

            //  our connection string
            connetionString = "Data Source=YAS;" +
            "" +
            "Initial Catalog=MedicalAppDB;" +
            "Integrated Security=SSPI;Persist Security Info=false";
            cnn = new SqlConnection(connetionString);
            
            if (!IsPostBack)
            {
                //  fill in the information stored in the database for easier updating of the records
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Select * from dbo.Patient where mrn = @MRN", cnn);
                    command.Parameters.AddWithValue("@MRN", mrn);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        lblMRN.Text = $"{mrn}";
                        txtFirstName.Text = $"{reader["First_Name"].ToString()}";
                        txtLastName.Text = $"{reader["Last_Name"].ToString()}";
                        txtAddress.Text = $"{reader["Address"].ToString()}";
                        txtCity.Text = $"{reader["City"].ToString()}";
                        selectProvince.Text = $"{reader["Province"].ToString()}";
                        txtPostal.Text = $"{reader["PostalCode"].ToString()}";
                        txtPhone.Text = $"{reader["PhoneNumber"].ToString()}";
                        ageNum.Text = $"{reader["Age"].ToString()}";
                        selectBloodType.Text = $"{reader["Blood_Type"].ToString()}";
                    }
                }
                catch (SqlException ex)
                {
                    lblMessage.Text = "Error in SQL!";
                    lblMessage.Text = $"{ex.Message}";
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

        protected void cmdBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientInfo.aspx");
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            //  if validation is successful
            if (Page.IsValid)
            {

                //  assign the patient object parameters
                patient.FirstName = txtFirstName.Text;
                patient.LastName = txtLastName.Text;
                patient.Address = txtAddress.Text;
                patient.City = txtCity.Text;
                patient.Province = selectProvince.Text;
                patient.PostalCode = txtPostal.Text;
                patient.PhoneNumber = txtPhone.Text;
                patient.Age = int.Parse(ageNum.Text);
                patient.BloodType = selectBloodType.Text;

                //  update information into the patient table
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Update dbo.Patient set " +
                        "First_Name = @firstName, Last_Name = @lastName,Address = @address," +
                        "City = @city, Province = @province, PostalCode = @postal," +
                        "PhoneNumber = @phone, Age = @age, Blood_Type = @bloodType", cnn);
                    command.Parameters.AddWithValue("@firstName", patient.FirstName);
                    command.Parameters.AddWithValue("@lastName",patient.LastName);
                    command.Parameters.AddWithValue("@address", patient.Address);
                    command.Parameters.AddWithValue("@city", patient.City);
                    command.Parameters.AddWithValue("@province", patient.Province);
                    command.Parameters.AddWithValue("@postal", patient.PostalCode);
                    command.Parameters.AddWithValue("@phone", patient.PhoneNumber);
                    command.Parameters.AddWithValue("@age", patient.Age);
                    command.Parameters.AddWithValue("@bloodType", patient.BloodType);

                    command.ExecuteNonQuery();

                    lblMessage.Text = "Information Updated.";

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
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            //  Kill the session and go back to the main page
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}