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
    public partial class HAZWMCertificate : System.Web.UI.Page
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
       
        //        lblGMInfo.Text = "South west Garo Hills";
       

        public void BindData()
        {
            DataSet ds = new DataSet();
            ds = objSrvcbal.GetSRVCApplicationDetails(Request.QueryString[0].ToString(), hdnUserID.Value, "82");
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblRecipientAddress.Text = ds.Tables[0].Rows[0]["REP_DOORNO"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["REP_LOCALITY"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["REP_VILLAGE"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["REP_MANDAL"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["REP_DIST"].ToString();
                }
                if (ds.Tables[13].Rows.Count > 0)
                {
                    lblApplicationNumber.Text = "IMA1001273197320241001";
                    lblApplicationDate.Text = DateTime.Now.ToString("dd-MM-yyyy");

                    lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    lblRecipientName.Text = ds.Tables[13].Rows[0]["SRVCHZD_OCCUPIERNAME"].ToString();
                    lblCompanyName.Text = ds.Tables[13].Rows[0]["SRVCHZD_FIRMNAME"].ToString();
                    lblValidityYears.Text = "1";
                    lblStartDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    lblEndDate.Text = DateTime.Now.AddYears(1).AddDays(-1).ToString("dd/MM/yyyy");
                }
            }

            //lblDirector.Text = "Director desgn";
            //lblFrstPrsn.Text = "First Person";
            //lblScndPrsn.Text = "Second Person";
        }
    }
    
}