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
    public partial class Analysis : System.Web.UI.Page
    {
        //global declarations
        string connetionString = null;
        SqlConnection cnn;
        SqlCommand command;
        AnalysisObj analysis;
        private int mrn;

        protected void Page_Load(object sender, EventArgs e)
        {
            mrn = (int)(Session["MRN"]);    //  our session mrn
            lblMRN.Text = $"{mrn}"; //  assign the label the MRN
            //  create a new analysis object
            analysis = new AnalysisObj();

            connetionString = "Data Source=YAS;" +
                "" +
                "Initial Catalog=MedicalAppDB;" +
                "Integrated Security=SSPI;Persist Security Info=false";
            cnn = new SqlConnection(connetionString);

            //  get the Analysis information from the Analysis table from the MRN stored in the session 
            //  store to our object and show the patients entire analysis history
            try
            {
                cnn.Open();
                command = new SqlCommand("Select * from dbo.Analysis where mrn = @MRN ORDER BY Id DESC", cnn);
                command.Parameters.AddWithValue("@MRN", mrn);

                SqlDataReader reader = command.ExecuteReader();

                txtAnalHist.Text = "-------------------------------------\r\n";

                while (reader.Read())
                {
                    txtAnalHist.Text += $"Date/Time: " +
                        $"{reader["DateTime"].ToString()}\r\n\n" +
                        $"Reason For Visit: " +
                        $"{reader["Reason_For_Visit"].ToString()}\r\n\n" +
                        $"Objective Analysis: " +
                        $"{reader["Objective_Analysis"].ToString()}\r\n\n" +
                        $"Subjective Analysis: " +
                        $"{reader["Subjective_Analysis"].ToString()}\r\n\n" +
                        $"Checked In: " +
                        $"{reader["Check_In"].ToString()}\r\n\n" +
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
                //  put in patient information from the values inserted by the user
                analysis.MRN = mrn;
                analysis.DateTime = DateTime.Now.ToString();
                analysis.ReasonForVisit = txtVisitReason.Text;
                analysis.SubjectiveAnalysis = txtSubAnal.Text;
                analysis.ObjectiveAnalysis = txtObjAnal.Text;
                analysis.CheckedIn = chkCheckIn.Checked;

                try
                {
                    //  insert values into our analysis table

                    cnn.Open();
                    command = new SqlCommand("Insert into dbo.Analysis values" +
                        "(@mrn,@dateTime,@reasonForVisit,@subAnal,@objAnal,@checkIn)", cnn);
                    command.Parameters.AddWithValue("@mrn", mrn);
                    command.Parameters.AddWithValue("@dateTime", analysis.DateTime);
                    command.Parameters.AddWithValue("@reasonForVisit", analysis.ReasonForVisit);
                    command.Parameters.AddWithValue("@subAnal", analysis.SubjectiveAnalysis);
                    command.Parameters.AddWithValue("@objAnal", analysis.ObjectiveAnalysis);
                    command.Parameters.AddWithValue("@checkIn", analysis.CheckedIn);

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