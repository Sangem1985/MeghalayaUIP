using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFeedbackQuestions();
            }
        }
        private void LoadFeedbackQuestions()
        {
            List<QuestionModel> section1 = new List<QuestionModel>
            {
                new QuestionModel { QuestionID = 1, Question = "The service I applied for was easy to find on the portal." },
                new QuestionModel { QuestionID = 2, Question = "The information provided about the service was clear and sufficient." },
                new QuestionModel { QuestionID = 3, Question = "The application process was simple and user-friendly." },
                new QuestionModel { QuestionID = 4, Question = "The required documentation for the service was clearly outlined." },
                new QuestionModel { QuestionID = 5, Question = "The time taken for service approval was reasonable." },
                new QuestionModel { QuestionID = 6, Question = "I received timely updates on the status of my application." },
                new QuestionModel { QuestionID = 7, Question = "Customer support/helpdesk assistance was prompt and helpful." },
                new QuestionModel { QuestionID = 8, Question = "The service was processed efficiently without unnecessary delays." },
                new QuestionModel { QuestionID = 9, Question = "The grievance redressal mechanism was effective in resolving my concerns." },
                new QuestionModel { QuestionID = 10, Question = "Overall, I am satisfied with the service provided through Invest Meghalaya Portal." }
            };

            List<QuestionModel> section2 = new List<QuestionModel>
            {
                new QuestionModel { QuestionID = 11, Question = "The Invest Meghalaya Portal is easy to navigate and use." },
                new QuestionModel { QuestionID = 12, Question = "The design and layout of the portal are visually appealing and intuitive." },
                new QuestionModel { QuestionID = 13, Question = "The portal loads quickly and functions smoothly." },
                new QuestionModel { QuestionID = 14, Question = "The information available on the portal is accurate and up-to-date." },
                new QuestionModel { QuestionID = 15, Question = "The portal provides all necessary resources and guidelines for investors." },
                new QuestionModel { QuestionID = 16, Question = "The search function helps in finding relevant information easily." },
                new QuestionModel { QuestionID = 17, Question = "The online payment and transaction system (if applicable) is secure and reliable." },
                new QuestionModel { QuestionID = 18, Question = "The portal is accessible on both desktop and mobile devices without issues." },
                new QuestionModel { QuestionID = 19, Question = "I feel that the portal enhances the ease of doing business in Meghalaya." },
                new QuestionModel { QuestionID = 20, Question = "Overall, I am satisfied with my experience using the Invest Meghalaya Portal." }
            };

            rptFeedback1.DataSource = section1;
            rptFeedback1.DataBind();

            rptFeedback2.DataSource = section2;
            rptFeedback2.DataBind();
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

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
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
    }
}