using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.PreReg
{
    public partial class IndustryRegistrationUserDashboard : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL indstregBAL = new PreRegBAL();
        string UnitID, Status;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserInfo"] != null)
                {
                    var ObjUserInfo = new UserInfo();
                    if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (UserInfo)Session["UserInfo"];
                        hdnUserID.Value = ObjUserInfo.Userid;
                    }

                    if (!IsPostBack)
                    {
                        BindData(ObjUserInfo.Userid);
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        public void BindData(string userid)
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {
                    UnitID = Request.QueryString[0];
                }
                else UnitID = "%";
                if (Request.QueryString.Count > 1)
                {
                    Status = Request.QueryString[1];
                }
                else Status = "TOTAL";

                DataSet ds = new DataSet();
                ds = indstregBAL.GetIndustryRegUserDashboard(userid, UnitID, Status);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvPreRegUserDashboard.DataSource = ds;
                    gvPreRegUserDashboard.DataBind();
                }
                //if (lnkbtn.Text != "0")
                //{
                //    LinkButton lnkbtn = (LinkButton)sender;
                //    lnkbtn.Style["text-decoration"] = "none";
                //}
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string Viewstatus = "";
                if (Request.QueryString.Count > 0)
                {
                    if (Convert.ToString(Request.QueryString[0]) == "%")
                        Viewstatus = "Total";
                    else
                        Viewstatus = "OneUnit";

                }
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;

                Label lblUNITD = (Label)row.FindControl("lblUnitID");
                string UNITID = lblUNITD.Text;
                string newurl = "IndustryRegistrationViewDetails.aspx?AppId=" + UNITID + "&ViewStatus=" + Viewstatus;

                Response.Redirect(newurl);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void lnkQueryCount_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkbtn.NamingContainer;
                Label lblUNITD = (Label)row.FindControl("lblUnitID");

                string UNITID = lblUNITD.Text;
                if (lnkbtn.Text != "0")
                {
                    string newurl = "IndustryRegistrationQueryDashboard.aspx?UNITID=" + UNITID;

                    Response.Redirect(newurl);
                }
                else
                {
                    lnkbtn.Style["text-decoration"] = "none";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString.Count > 0)
                    UnitID = Request.QueryString[0];
                else
                    UnitID = "%";
                Response.Redirect("~/User/Dashboard/DashboardDrill.aspx?UnitID=" + UnitID);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;

            }
        }
    }
}