using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.CommonDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class Feedback : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        MGCommonBAL mGCommonBAL = new MGCommonBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFeedbackQuestions();
            }
        }
        private void LoadFeedbackQuestions()
        {
            DataSet ds = mGCommonBAL.GetFeedBackQuestions();
            if (ds != null && ds.Tables.Count >= 2)
            {
                // Bind the first table to rptFeedback1
                rptFeedback1.DataSource = ds.Tables[0];
                rptFeedback1.DataBind();

                // Bind the second table to rptFeedback2
                rptFeedback2.DataSource = ds.Tables[1];
                rptFeedback2.DataBind();
            }
        }

      
        // Save to Database
        private void SaveFeedback(List<FeedbackResponse> feedbackResponses)
        {
            string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();
            using (SqlConnection con = new SqlConnection(connstr))
            {
                con.Open();
                foreach (var feedback in feedbackResponses)
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO TBL_FEEDBACK (QuestionID, Rating) VALUES (@QuestionID, @Rating)", con))
                    {
                        cmd.Parameters.AddWithValue("@QuestionID", feedback.QuestionID);
                        cmd.Parameters.AddWithValue("@Rating", feedback.Rating);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

       

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            string result = "";
            List<FeedbackResponse> responses = new List<FeedbackResponse>();

            foreach (RepeaterItem item in rptFeedback1.Items)
            {
                RadioButtonList rbl = (RadioButtonList)item.FindControl("rblFeedback1");
                if (rbl.SelectedItem != null)
                {
                    responses.Add(new FeedbackResponse
                    {
                        QuestionID = Convert.ToInt32(rbl.Attributes["QuestionID"]),
                        Rating = Convert.ToInt32(rbl.SelectedValue)
                    });
                }
            }

            foreach (RepeaterItem item in rptFeedback2.Items)
            {
                RadioButtonList rbl = (RadioButtonList)item.FindControl("rblFeedback2");
                if (rbl.SelectedItem != null)
                {
                    responses.Add(new FeedbackResponse
                    {
                        QuestionID = Convert.ToInt32(rbl.Attributes["QuestionID"]),
                        Rating = Convert.ToInt32(rbl.SelectedValue)
                    });
                }
            }
            
            //SaveFeedback(responses);
        }
        // Model for saving feedback
        public class FeedbackResponse
        {
            public int QuestionID { get; set; }
            public int Rating { get; set; }
        }

        public class QuestionModel
        {
            public int QuestionID { get; set; }
            public string Question { get; set; }
        }
    }
}