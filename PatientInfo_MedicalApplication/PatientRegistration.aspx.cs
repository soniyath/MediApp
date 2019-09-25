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
    public partial class PatientRegistration : System.Web.UI.Page
    {
        //global declarations
        string connetionString = null;
        SqlConnection cnn;
        SqlCommand command;
        Patient patient;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                lblMessage.Text = "";
            connetionString = "Data Source=YAS;" +
                "" +
                "Initial Catalog=MedicalAppDB;" +
                "Integrated Security=SSPI;Persist Security Info=false";
            cnn = new SqlConnection(connetionString);

            //  new patient object
             patient = new Patient();
        }

        protected void cmdBack_Click(object sender, EventArgs e)
        {
            //  redirect to the default page if back button is pressed
            Response.Redirect("Default.aspx");
        }

        protected void cmdRegister_Click(object sender, EventArgs e)
        {
            //  if validation passes
            if (Page.IsValid)
            {
                //  put in patient information from the values inserted by the user
                patient.FirstName = txtFirstName.Text;
                patient.LastName = txtLastName.Text;
                patient.Address = txtAddress.Text;
                patient.City = txtCity.Text;
                patient.Province = selectProvince.Text;
                patient.PostalCode = txtPostal.Text;
                patient.PhoneNumber = txtPhone.Text;
                patient.Age = int.Parse(ageNum.Text);
                patient.BloodType = selectBloodType.Text;

                bool patientExists = true;
                //  check to see if patient exists or not
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Select MRN from dbo.Patient where First_Name = @firstName and " +
                        "Last_name = @lastName and Blood_Type = @bloodType and Age = @age", cnn);
                    command.Parameters.AddWithValue("@firstName", patient.FirstName);
                    command.Parameters.AddWithValue("@lastName", patient.LastName);
                    command.Parameters.AddWithValue("@bloodType", patient.BloodType);
                    command.Parameters.AddWithValue("@age", patient.Age);

                    //  execute the sql command
                    SqlDataReader reader = command.ExecuteReader();

                    //  if patient record exists, don't let the user register with this info
                    if (reader.Read())
                    {
                        patient.MRN = int.Parse(reader["MRN"].ToString());
                        lblMessage.Attributes.CssStyle.Add("color", "red");
                        lblMessage.Text = $"* Patient already exists with MRN " +
                            $"<strong>{patient.MRN}</strong>.";
                    }
                    //  otherwise set patientExists to false to allow registration with this patient
                    else
                    {
                        lblMessage.Text = "";
                        patientExists = false;
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
                //  if email does not already exist, insert the record into the customer database
                if (!patientExists)
                {
                    try
                    {
                        cnn.Open();
                        command = new SqlCommand("Insert into dbo.Patient values" +
                            "(@firstName,@lastName,@address,@city,@province,@postal,@phone,@age,@bloodType)", cnn);
                        command.Parameters.AddWithValue("@firstName", patient.FirstName);
                        command.Parameters.AddWithValue("@lastName", patient.LastName);
                        command.Parameters.AddWithValue("@address", patient.Address);
                        command.Parameters.AddWithValue("@city", patient.City);
                        command.Parameters.AddWithValue("@province", patient.Province);
                        command.Parameters.AddWithValue("@postal", patient.PostalCode);
                        command.Parameters.AddWithValue("@phone", patient.PhoneNumber);
                        command.Parameters.AddWithValue("@age", patient.Age);
                        command.Parameters.AddWithValue("@bloodType", patient.BloodType);

                        command.ExecuteNonQuery();

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
                    //  now get the mrn from the newly created record so it can be stored in session
                    try
                    {
                        cnn.Open();
                        command = new SqlCommand("Select MRN from dbo.Patient where First_Name = @firstName and " +
                        "Last_name = @lastName and Blood_Type = @bloodType and Age = @age", cnn);
                        command.Parameters.AddWithValue("@firstName", patient.FirstName);
                        command.Parameters.AddWithValue("@lastName", patient.LastName);
                        command.Parameters.AddWithValue("@bloodType", patient.BloodType);
                        command.Parameters.AddWithValue("@age", patient.Age);
                        SqlDataReader reader = command.ExecuteReader();

                        //  select the mrn based on the first name, last name, blood type and age
                        //  we just stored and store in session
                        //  then redirect to the patientInfo page
                        if (reader.Read())
                        {
                            patient.MRN = int.Parse(reader["MRN"].ToString());
                            Session["MRN"] = patient.MRN;
                            Session["patient"] = patient;
                            Response.Redirect("PatientInfo.aspx");
                        }
                        else
                        {
                            lblMessage.Text = "Can't find MRN";
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
            }
        }
    }
}