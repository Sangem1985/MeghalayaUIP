using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Grievance
{
    public partial class GrievanceUserView : System.Web.UI.Page
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
                        BindGrievance();
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!!";
                Failure.Visible = true;
            }
        }

        protected void BindGrievance()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objcomBal.GetUserGrievanceList(hdnUserID.Value);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvGrvncTotal.DataSource = ds.Tables[0];
                        gvGrvncTotal.DataBind();
                    }
                    else
                    {
                        gvGrvncTotal.DataSource = null;
                        gvGrvncTotal.DataBind();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        gvGrvncPending.DataSource = ds.Tables[1];
                        gvGrvncPending.DataBind();
                    }
                    else
                    {
                        gvGrvncPending.DataSource = null;
                        gvGrvncPending.DataBind();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        gvGrvncRedressed.DataSource = ds.Tables[2];
                        gvGrvncRedressed.DataBind();
                    }
                    else
                    {
                        gvGrvncRedressed.DataSource = null;
                        gvGrvncRedressed.DataBind();
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        gvGrvncRejected.DataSource = ds.Tables[3];
                        gvGrvncRejected.DataBind();
                    }
                    else
                    {
                        gvGrvncRejected.DataSource = null;
                        gvGrvncRejected.DataBind();
                    }
                }
                else
                {
                    lblmsg0.Text = "No Records Found";
                    Failure.Visible = true;
                    Response.Redirect("~/User/Grievance/Grievance.aspx");

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}