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
    public partial class Dashboard : System.Web.UI.Page
    {
        //global declarations
        string connetionString = null;
        SqlConnection cnn;
        SqlCommand command;
        private int mrn;

        protected void Page_Load(object sender, EventArgs e)
        {
            mrn = (int)(Session["MRN"]);    //  our session mrn
            lblMRN.Text = (mrn).ToString();
            //  connection string to the database
            connetionString = "Data Source=YAS;" +
            "" +
            "Initial Catalog=MedicalAppDB;" +
            "Integrated Security=SSPI;Persist Security Info=false";
            cnn = new SqlConnection(connetionString);

            if (!IsPostBack)
            {
                //  get the Analysis information from the Analysis table from the MRN stored in the session
                //  this will be loaded into the first label (we are only selecting one value to display 
                //  -   it displays the latest record
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Select TOP 1 * from dbo.Analysis where mrn = @MRN ORDER BY Id DESC", cnn);
                    command.Parameters.AddWithValue("@MRN", mrn);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        lblMRN.Text = $"{mrn}";
                        lblReason.Text = $"{reader["Reason_For_Visit"].ToString()}";
                        lblObj.Text = $"{reader["Objective_Analysis"].ToString()}";
                        lblSub.Text = $"{reader["Subjective_Analysis"].ToString()}";
                        lblAnalysisDate.Text = $"{reader["DateTime"].ToString()}";
                        lblCheckIn.Text = $"{reader["Check_In"].ToString()}";
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write("Error in SQL!");
                    Response.Write($"{ex.Message}");
                }
                finally
                {
                    if (cnn.State == ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }

                //  get the Lab Work information from the Lab_Work table from the MRN stored in the session 
                //  and show the patients entire lab work history
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Select * from dbo.Lab_Work where mrn = @MRN ORDER BY Id DESC", cnn);
                    command.Parameters.AddWithValue("@MRN", mrn);

                    SqlDataReader reader = command.ExecuteReader();

                    txtLabHist.Text = "-------------------------------------\r\n";

                    while (reader.Read())
                    {
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write("Error in SQL!");
                    Response.Write($"{ex.Message}");
                }
                finally
                {
                    if (cnn.State == ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }

                //  get the Vitals information from the Vitals table from the MRN stored in the session 
                //  and show the patients entire Vitals history
                try
                {
                    cnn.Open();
                    command = new SqlCommand("Select * from dbo.Vitals where mrn = @MRN ORDER BY Id DESC", cnn);
                    command.Parameters.AddWithValue("@MRN", mrn);

                    SqlDataReader reader = command.ExecuteReader();

                    txtVitalsHist.Text = "-------------------------------------\r\n";

                    while (reader.Read())
                    {
                        txtVitalsHist.Text += $"Date/Time: " +
                            $"{reader["DateTime"].ToString()}\r\n\n" +
                            $"Systolic (mmHg): " +
                            $"{reader["Systolic"].ToString()}\r\n\n" +
                            $"Diastolic (mmHg): " +
                            $"{reader["Diastolic"].ToString()}\r\n\n" +
                            $"O2 Levels (mmHg): " +
                            $"{reader["O2_Levels"].ToString()}\r\n\n" +
                            $"Pulse Rate Average (bpm): " +
                            $"{reader["Pulse"].ToString()}\r\n\n" +
                            $"Respiratory Rate (breaths per minute): " +
                            $"{reader["Respiratory_Rate"].ToString()}\r\n\n" +
                            "-------------------------------------\r\n";
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write("Error in SQL!");
                    Response.Write($"{ex.Message}");
                }
                finally
                {
                    if (cnn.State == ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                }
            }
            try
            {
                cnn.Open();
                command = new SqlCommand("Select * from dbo.Checkout where mrn = @MRN", cnn);
                command.Parameters.AddWithValue("@MRN", mrn);
                Response.Write(Session["MRN"]);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                
                    txtCheckoutHist.Text += $"Discharge Instructions: " +
                           $"{reader["Discharge_Instructions"].ToString()}\r\n\n" +
                           $"Required Follow Up Date: " +
                           $"{reader["Required_Follow_Up_Date"].ToString()}\r\n\n" +
                           $"Conclusions: " +
                           $"{reader["Conclusions"].ToString()}\r\n\n" +
                           "-------------------------------------\r\n";


                }
            }
            catch (SqlException ex)
            {
                //lblMessage.Text = "Error in SQL!";
                //lblMessage.Text = $"{ex.Message}";
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

        protected void logout_Click(object sender, EventArgs e)
        {
            //  Kill the session and go back to the main page
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        protected void cmdVitals_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vitals.aspx");
        }

        protected void cmdLabWork_Click(object sender, EventArgs e)
        {
            Response.Redirect("LabWork.aspx");
        }

        protected void cmdAnalysis_Click(object sender, EventArgs e)
        {
            Response.Redirect("Analysis.aspx");
        }

        protected void cmdCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }

        protected void cmdPatientInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientInfo.aspx");
        }
    }
}