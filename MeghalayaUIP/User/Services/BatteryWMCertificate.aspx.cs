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
    public partial class BatteryWMCertificate : System.Web.UI.Page
    {
        SVRCBAL objSrvcbal = new SVRCBAL();

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

                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        if (Request.QueryString.Count > 0)
                        {
                            BindData();
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            
        }
        public void BindData()
        {
            DataSet ds = new DataSet();
            ds = objSrvcbal.GetSRVCApplicationDetails(Request.QueryString[0].ToString(), hdnUserID.Value, "92");
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblNo.Text = "2025/102/0903202583";
                    lblIssuePlace.Text = "Shilong";
                    lblIssueDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
                    lblCompanyName.Text = "Atharva Automobiles";
                    lblLocation.Text = "DEMTHRING, SHILLONG";
                    lblGSTNo.Text = "17BAOPS4205A1ZW";
                    lblStartDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
                    lblEndDate.Text = DateTime.Now.AddYears(5).AddDays(-1).ToString("dd MMMM yyyy");

                }
            }
        }

    }
}