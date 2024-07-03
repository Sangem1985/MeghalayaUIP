using MeghalayaUIP.BAL.CFEBLL;
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

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEUserApplStatusView : System.Web.UI.Page
    {
        string UnitID,Status;

        CFEBAL objcfebal = new CFEBAL();
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
                    }
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.Userid;
                    }
                    if (Request.QueryString[0].ToString() != "")
                    { UnitID = Request.QueryString[0].ToString(); }
                    else
                    {
                        string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }
                    Page.MaintainScrollPositionOnPostBack = true;
                    if (!IsPostBack)
                    {
                        if (Request.QueryString[1].ToString() != "")
                        {
                            Status = Request.QueryString[1].ToString();

                            BindApplStatus(hdnUserID.Value, UnitID, Status);

                            if(Status== "QueryRaised"|| Status == "QRYRESPOND")
                            {
                                gvCFEApplStatus.Columns[4].Visible = true;
                                gvCFEApplStatus.Columns[5].Visible = true;
                            }
                            else
                            {
                                gvCFEApplStatus.Columns[4].Visible = false;
                                gvCFEApplStatus.Columns[5].Visible = false;
                            }
                        }
                            
                    }
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("User/CFE/CFEUserDashboard.aspx");
        }

        public void BindApplStatus(string Userid, string Unitid, string Status)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetUserCFEApplStatusView(hdnUserID.Value, UnitID,Status);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvCFEApplStatus.DataSource = ds.Tables[0];
                    gvCFEApplStatus.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
}