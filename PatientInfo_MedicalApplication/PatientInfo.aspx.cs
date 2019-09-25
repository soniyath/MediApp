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
    public partial class PatientInfo : System.Web.UI.Page
    {
        //global declarations
        string connetionString = null;
        SqlConnection cnn;
        SqlCommand command;
        private int mrn;
        Patient patient;
        Allergies allergy;
        Medications medication;
        ExistingConditions existingConditions;

        protected void Page_Load(object sender, EventArgs e)
        {
            mrn = (int)(Session["MRN"]);    //  our session mrn
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

                //  get the patients allergy information from the Allergy table from the MRN stored in the session
                //  and add to Allergies ListBox
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Select * from dbo.Allergies where mrn = @MRN", cnn);
                    command.Parameters.AddWithValue("@MRN", mrn);

                    SqlDataReader reader = command.ExecuteReader();

                    lstAllergyItems.Items.Add("--------------------------------------");

                    while (reader.Read())
                    {
                        lstAllergyItems.Items.Add($"Allergy Name: {reader["Allergy_Name"].ToString()}");
                        lstAllergyItems.Items.Add($"Date Began: {reader["DateTime"].ToString()}");
                        lstAllergyItems.Items.Add("--------------------------------------");
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

                //  get the patients Existing Conditions from the ExistingConditions 
                //  table from the MRN stored in the session and add to Existing Conditions ListBox
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Select * from dbo.ExistingConditions where mrn = @MRN", cnn);
                    command.Parameters.AddWithValue("@MRN", mrn);

                    SqlDataReader reader = command.ExecuteReader();

                    lstConditions.Items.Add("--------------------------------------");

                    while (reader.Read())
                    {
                        lstConditions.Items.Add($"Condition Name: {reader["Condition_Name"].ToString()}");
                        lstConditions.Items.Add($"Date Began: {reader["DateTime"].ToString()}");
                        lstConditions.Items.Add("--------------------------------------");
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

                //  get the patients medication information from the Allergy table from the
                //  MRN stored in the session and add to Medications ListBox
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Select * from dbo.Medications where mrn = @MRN", cnn);
                    command.Parameters.AddWithValue("@MRN", mrn);

                    SqlDataReader reader = command.ExecuteReader();

                    lstMedItems.Items.Add("--------------------------------------");

                    while (reader.Read())
                    {
                        lstMedItems.Items.Add($"Allergy Name: {reader["Medication_Name"].ToString()}");
                        lstMedItems.Items.Add($"Dose: {reader["Dose"].ToString()}");
                        lstMedItems.Items.Add($"Date Began: {reader["DateTime"].ToString()}");
                        lstMedItems.Items.Add("--------------------------------------");
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

        protected void cmdUpdatePatient_Click(object sender, EventArgs e)
        {
            //  redirect to the update patient info page
            Response.Redirect("UpdatePatientInfo.aspx");
        }

        protected void cmdAddCondition_Click(object sender, EventArgs e)
        {
            //  if validation is successful
            if (Page.IsValid)
            {
                //  create an existing conditions object to store in the databasee
                existingConditions = new ExistingConditions();

                existingConditions.ConditionName = txtConditionName.Text;
                existingConditions.DateTime = txtConDate.Text;

                //  clear the conditions listbox
                this.lstConditions.Items.Clear();

                //  insert the new existing condition object into the existing conditions database
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Insert into dbo.ExistingConditions values" +
                        "(@mrn, @conditionName,@dateTime)", cnn);
                    command.Parameters.AddWithValue("@mrn", mrn);
                    command.Parameters.AddWithValue("@conditionName", existingConditions.ConditionName);
                    command.Parameters.AddWithValue("@dateTime", existingConditions.DateTime); ;

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

                //  clear the textbox fields after inserting
                this.txtConditionName.Text = "";
                this.txtConDate.Text = "";

                //  after inserting, now lets add our data to our condition listbox

                //  get the patients Existing Conditions from the ExistingConditions 
                //  table from the MRN stored in the session and add to Existing Conditions ListBox

                try
                {
                    cnn.Open();
                    command = new SqlCommand("Select * from dbo.ExistingConditions where mrn = @MRN", cnn);
                    command.Parameters.AddWithValue("@MRN", mrn);

                    SqlDataReader reader = command.ExecuteReader();

                    lstConditions.Items.Add("--------------------------------------");

                    while (reader.Read())
                    {
                        lstConditions.Items.Add($"Condition Name: {reader["Condition_Name"].ToString()}");
                        lstConditions.Items.Add($"Date Began: {reader["DateTime"].ToString()}");
                        lstConditions.Items.Add("--------------------------------------");
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

        protected void cmdAddMeds_Click(object sender, EventArgs e)
        {
            //  if validation is successful
            if (Page.IsValid)
            {
                //  create a new Medication object
                medication = new Medications();
                medication.MedicationName = txtMedName.Text;
                medication.Dose = txtDose.Text;
                medication.DateTime = txtMedDate.Text;

                //  clear the medications list box
                this.lstMedItems.Items.Clear();

                //  insert the new medication object into the medications
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Insert into dbo.Medications values" +
                        "(@mrn, @medicationName,@dose,@dateTime)", cnn);
                    command.Parameters.AddWithValue("@mrn", mrn);
                    command.Parameters.AddWithValue("@medicationName", medication.MedicationName);
                    command.Parameters.AddWithValue("@dose", medication.Dose);
                    command.Parameters.AddWithValue("@dateTime", medication.DateTime);

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

                //  clear the textbox fields after inserting
                this.txtMedName.Text = "";
                this.txtDose.Text = "";
                this.txtMedDate.Text = "";

                //  after inserting, now lets add our data to our medications listbox

                //  get the patients Medications from the Medications 
                //  table from the MRN stored in the session and add to Medications ListBox

                try
                {
                    cnn.Open();
                    command = new SqlCommand("Select * from dbo.Medications where mrn = @MRN", cnn);
                    command.Parameters.AddWithValue("@MRN", mrn);

                    SqlDataReader reader = command.ExecuteReader();

                    lstMedItems.Items.Add("--------------------------------------");

                    while (reader.Read())
                    {
                        lstMedItems.Items.Add($"Medication Name: {reader["Medication_Name"].ToString()}");
                        lstMedItems.Items.Add($"Dose: {reader["Dose"].ToString()}");
                        lstMedItems.Items.Add($"Date Began: {reader["DateTime"].ToString()}");
                        lstMedItems.Items.Add("--------------------------------------");
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

        protected void cmdAddAllergy_Click(object sender, EventArgs e)
        {
            //  if validation is successful
            if (Page.IsValid)
            {
                //  create a new allergy object
                allergy = new Allergies();
                allergy.AllergyName = txtAllergyName.Text;
                allergy.DateTime = txtAllerDate.Text;

                //  clear the allergy list box
                this.lstAllergyItems.Items.Clear();

                //  insert the new allergy object into the Allergies table
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Insert into dbo.Allergies values" +
                        "(@mrn, @allergyName,@dateTime)", cnn);
                    command.Parameters.AddWithValue("@mrn", mrn);
                    command.Parameters.AddWithValue("@allergyName", allergy.AllergyName);
                    command.Parameters.AddWithValue("@dateTime", allergy.DateTime);

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

                //  clear the textbox fields after inserting
                this.txtAllergyName.Text = "";
                this.txtAllerDate.Text = "";

                //  after inserting, now lets add our data to our Allergies listbox

                //  get the patients Allergies from the Allergies 
                //  table from the MRN stored in the session and add to Allergies ListBox

                try
                {
                    cnn.Open();
                    command = new SqlCommand("Select * from dbo.Allergies where mrn = @MRN", cnn);
                    command.Parameters.AddWithValue("@MRN", mrn);

                    SqlDataReader reader = command.ExecuteReader();

                    lstMedItems.Items.Add("--------------------------------------");

                    while (reader.Read())
                    {
                        lstAllergyItems.Items.Add($"Allergy Name: {reader["Allergy_Name"].ToString()}");
                        lstAllergyItems.Items.Add($"Date Began: {reader["DateTime"].ToString()}");
                        lstAllergyItems.Items.Add("--------------------------------------");
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

        protected void logout_Click(object sender, EventArgs e)
        {
            //  Kill the session and go back to the main page
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        protected void cmdEnterAnalysis_Click(object sender, EventArgs e)
        {
            Response.Redirect("Analysis.aspx");
        }
    }
}