using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class PWMCertificate : System.Web.UI.Page
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
            try
            {
                DataSet ds = new DataSet();
                ds = objSrvcbal.GetSRVCApplicationDetails(Request.QueryString[0].ToString(), hdnUserID.Value, "82");
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblCertificateNo.Text = "2025/102/0903202583";
                        lblDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
                        lblRecipientName.Text = ds.Tables[0].Rows[0]["REP_DOORNO"].ToString();
                        lblRecipientAddress1.Text = ds.Tables[0].Rows[0]["REP_LOCALITY"].ToString();
                        lblRecipientAddress2.Text = ds.Tables[0].Rows[0]["REP_VILLAGE"].ToString();
                        lblRecipientAddress3.Text = ds.Tables[0].Rows[0]["REP_MANDAL"].ToString() + ", " +
                            ds.Tables[0].Rows[0]["REP_DIST"].ToString();

                        lblReference.Text = ds.Tables[0].Rows[0]["REP_DIST"].ToString();
                        lblCompanyName.Text = ds.Tables[0].Rows[0]["SRVCED_NAMEOFUNIT"].ToString();
                        lblCompanyAddress.Text = ds.Tables[0].Rows[0]["SRVCED_SURVEYDOOR"].ToString() + ", " +
                            ds.Tables[0].Rows[0]["SRVCED_LOCALITY"].ToString() + ", " +
                             ds.Tables[0].Rows[0]["SRVCED_LANDMARK"].ToString() + ", " +
                            ds.Tables[0].Rows[0]["VillageName"].ToString() + ", " +
                            ds.Tables[0].Rows[0]["Mandalname"].ToString() + ", " +
                            ds.Tables[0].Rows[0]["DistrictName"].ToString();


                        lblManufacturedProduct.Text = ds.Tables[0].Rows[0]["SRVCPWD_NAMEOFPROD"].ToString();
                        lblValidityYears.Text = "5 ";
                        //lblDeputyCommissionerDistrict.Text = "Deputy Commissoner District";
                        //lblGeneralInfo.Text = "General Information";







                    }
                }
            }
            catch (Exception ex)
            {
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
    }
}