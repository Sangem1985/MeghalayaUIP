using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCUserDashboard : System.Web.UI.Page
    {
        SVRCBAL objSrvcbal = new SVRCBAL();
        string UnitID;
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

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindApproved();
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindApproved()
        {
            try
            {
                DataSet dsApproved = new DataSet();
                if (Request.QueryString != null)
                {
                    if (Request.QueryString.Count > 0)
                    {
                        UnitID = Request.QueryString[0];
                    }
                }
                else
                {
                    UnitID = "%";
                }
                if (UnitID == "%")
                    lblHdng.Text = " Status of Application for All Units";
                else lblHdng.Text = "";

                dsApproved = objSrvcbal.GetSRVCapplications(hdnUserID.Value, UnitID);
                if (dsApproved.Tables.Count > 0)
                {
                    if (dsApproved != null && dsApproved.Tables[0].Rows.Count > 0)
                    {
                        GvServices.DataSource = dsApproved.Tables[0];
                        GvServices.DataBind();
                    }
                    else
                    {
                        GvServices.DataSource = null;
                        GvServices.DataBind();
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
    }
}