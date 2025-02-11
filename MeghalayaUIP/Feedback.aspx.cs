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


        protected void rptFeedback1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RadioButtonList rblFeedback = (RadioButtonList)e.Item.FindControl("rblFeedback1");
                if (rblFeedback != null)
                {
                    rblFeedback.ClearSelection();  // Ensure no previous selection
                }
            }
        }

        protected void rptFeedback2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RadioButtonList rblFeedback = (RadioButtonList)e.Item.FindControl("rblFeedback2");
                if (rblFeedback != null)
                {
                    rblFeedback.ClearSelection();
                }
            }
        }




        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            try
            {
                int trackerId;
                FeedbackTracker tracker = new FeedbackTracker
                {
                    FBQ_SUGGESTIONS = sugstn.Text,
                    FBQ_ISSUES = diffculties.Text,
                    FBQ_CATEGORY = "A"
                };
                trackerId = mGCommonBAL.InsertFeedbackTracker(tracker);
                if (trackerId > 0)
                {
                    List<FeedbackData> feedbackList = new List<FeedbackData>();

                    // Process First Repeater (Category 'A')
                    foreach (RepeaterItem item in rptFeedback1.Items)
                    {
                        HiddenField hfQuestionID = (HiddenField)item.FindControl("hfQuestionID1");
                        RadioButtonList rblFeedback = (RadioButtonList)item.FindControl("rblFeedback1");

                        if (hfQuestionID != null && rblFeedback != null && rblFeedback.SelectedItem != null)
                        {
                            FeedbackData feedback = new FeedbackData
                            {
                                FBQ_QUESTIONID = Convert.ToInt32(hfQuestionID.Value),
                                FBQ_FEEDBACKVALUE = rblFeedback.SelectedValue,
                                FBQ_FEEDBACKTEXT = rblFeedback.SelectedItem.Text != null ? rblFeedback.SelectedItem.Text.Trim() : "",
                                FBQ_CATEGORY = "A"
                            };
                            feedbackList.Add(feedback);
                        }
                    }

                    // Process Second Repeater (Category 'O')
                    foreach (RepeaterItem item in rptFeedback2.Items)
                    {
                        HiddenField hfQuestionID = (HiddenField)item.FindControl("hfQuestionID2");
                        RadioButtonList rblFeedback = (RadioButtonList)item.FindControl("rblFeedback2");

                        if (hfQuestionID != null && rblFeedback != null && rblFeedback.SelectedItem != null)
                        {
                            FeedbackData feedback = new FeedbackData
                            {
                                FBQ_QUESTIONID = Convert.ToInt32(hfQuestionID.Value),
                                FBQ_FEEDBACKVALUE = rblFeedback.SelectedValue,
                                FBQ_FEEDBACKTEXT = rblFeedback.SelectedItem.Text != null ? rblFeedback.SelectedItem.Text.Trim() : "",
                                FBQ_CATEGORY = "O"
                            };
                            feedbackList.Add(feedback);
                        }
                    }

                    // Insert Feedback Data
                    string result = mGCommonBAL.InsertFeedback(trackerId, feedbackList);

                    // Show Success Message
                    success.Visible = true;
                    Label1.Text = "Feedback submitted successfully!";
                    Label1.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Error inserting feedback tracker.";
                    lblmsg0.ForeColor = System.Drawing.Color.Red;
                }
            
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = "Error inserting feedback tracker.";
                lblmsg0.ForeColor = System.Drawing.Color.Red;
            }


        }
        
    }
}