using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.HelpDesk
{
    public partial class HelpDeskUserView : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();
        MGCommonBAL objcomBal = new MGCommonBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Failure.Visible = false;
                success.Visible = false;

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
                    if (!IsPostBack)
                    {
                        BindHelpDesk();
                    }
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!!";
                Failure.Visible = true;
                throw ex;
            }
        }
        protected void BindHelpDesk()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objcomBal.GetUserHelpDeskList(hdnUserID.Value);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GVHelpTotal.DataSource = ds.Tables[0];
                        GVHelpTotal.DataBind();
                    }
                    else
                    {
                        GVHelpTotal.DataSource = null;
                        GVHelpTotal.DataBind();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GVHelpPending.DataSource = ds.Tables[1];
                        GVHelpPending.DataBind();
                    }
                    else
                    {
                        GVHelpPending.DataSource = null;
                        GVHelpPending.DataBind();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        GvHelpRedressed.DataSource = ds.Tables[2];
                        GvHelpRedressed.DataBind();
                    }
                    else
                    {
                        GvHelpRedressed.DataSource = null;
                        GvHelpRedressed.DataBind();
                    }
                 
                }
                else
                {
                    lblmsg0.Text = "No Records Found";
                    Failure.Visible = true;
                    Response.Redirect("~/User/HelpDesk/RegisterHelpDesk.aspx");

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lblInspection_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkview = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkview.NamingContainer;

                Label lblfilepath = (Label)row.FindControl("lblFilePath");
                if (lblfilepath != null || lblfilepath.Text != "")
                    Response.Redirect("~/User/Dashboard/ServePdfFile.ashx?filePath=" + lblfilepath.Text);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void lblUpload_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkview = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkview.NamingContainer;

                Label lblfilepath = (Label)row.FindControl("lblFilePath");
                if (lblfilepath != null || lblfilepath.Text != "")
                    Response.Redirect("~/User/Dashboard/ServePdfFile.ashx?filePath=" + lblfilepath.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lblUploaded_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkview = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkview.NamingContainer;

                Label lblfilepath = (Label)row.FindControl("lblFilePath");
                if (lblfilepath != null || lblfilepath.Text != "")
                    Response.Redirect("~/User/Dashboard/ServePdfFile.ashx?filePath=" + lblfilepath.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}