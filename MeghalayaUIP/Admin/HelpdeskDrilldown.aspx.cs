using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Admin
{
    public partial class HelpdeskDrilldown : System.Web.UI.Page
    {
        MGCommonBAL objcommon = new MGCommonBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {             
                if (!IsPostBack)
                {
                    HelpDeskGrid();
                }

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void HelpDeskGrid()
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {                  
                    string HDType = Request.QueryString[0].ToString().Trim();
                    string status = Request.QueryString[1].ToString().Trim();
                    txtFormDate.Text = Request.QueryString[2].ToString().Trim();
                    txtToDate.Text = Request.QueryString[3].ToString().Trim();
                    DataSet ds = new DataSet();
                    ds = objcommon.GetHelpDeskReportDrilldown(HDType, status, txtFormDate.Text, txtToDate.Text);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GVHelpdesk.DataSource = ds.Tables[0];
                        GVHelpdesk.DataBind();
                        label.Text = "Report from " + txtFormDate.Text.Trim() + " To " + txtToDate.Text.Trim();

                    }
                    if (status=="1")
                    {

                    }
                    else if (status == "2")
                    {
                        GVHelpdesk.Columns[9].Visible = false;
                        GVHelpdesk.Columns[11].Visible = false;
                    }
                }


            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Admin/HelpdeskReport.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserInfo"] != null)
                {
                    var ObjUserInfo = new UserInfo();
                    if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (UserInfo)Session["UserInfo"];
                    }
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.Userid;
                    }

                }
                Button Button = (Button)sender;
                GridViewRow row = (GridViewRow)Button.NamingContainer;

                DropDownList ddlchStatus = (DropDownList)row.FindControl("ddlchStatus");
                TextBox txtremarks = (TextBox)row.FindControl("txtremarks");
                Label lblHelpDeskID = (Label)row.FindControl("lblHelpDeskID");

                HelpDeskDrilldown Helpdesk = new HelpDeskDrilldown();

                Helpdesk.HelpDeskID= Convert.ToInt32(lblHelpDeskID.Text);
                Helpdesk.REDRESSEDREMARKES = txtremarks.Text;
                Helpdesk.Update= "1";
                Helpdesk.Investid = hdnUserID.Value;
                Helpdesk.REDRESSEDBYIP = getclientIP();


                DropDownList ddltypeprob = (DropDownList)row.FindControl("ddltypeprob");
                if (txtremarks.Text == "")
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please enter the Remarks";
                    return;
                }
                HelpDeskGrid();
                DataSet ds = new DataSet();
                ds = objcommon.HelpdeskDrilldown(Helpdesk);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string newhdCode = ds.Tables[0].Rows[0]["HelpDeskID"].ToString();
                    string txtemail = ds.Tables[0].Rows[0]["HD_EMAILID"].ToString();                 
                   
                    string Label58 = ds.Tables[0].Rows[0]["HD_UNITNAME"].ToString();
                    string ddlfeedback = ds.Tables[0].Rows[0]["HD_HELPDESKTYPE"].ToString();
                    string txtsubjet = ds.Tables[0].Rows[0]["HD_HELPDESKDESCRIPTION"].ToString();
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["HD_REDRESSEDREMARKES"].ToString()))
                    {
                        string Remarksdet = ds.Tables[0].Rows[0]["HD_REDRESSEDREMARKES"].ToString();
                    }
                    else
                    {
                        string Remarksdet = ds.Tables[0].Rows[0]["HD_REDRESSEDREMARKES"].ToString();
                    }
                    string statusdet = ddlchStatus.SelectedItem.Text;
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GVHelpdesk_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hypUIDNO = (HyperLink)e.Row.FindControl("hypUIDNO");
                if (hypUIDNO.NavigateUrl == "")
                {
                    hypUIDNO.Visible = false;
                }
                else
                {
                    hypUIDNO.Visible = true;
                }
            }
        }
        public static string getclientIP()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return result;
        }
    }
}