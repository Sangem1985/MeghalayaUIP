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
    public partial class EWMManfctrRefCertificate : System.Web.UI.Page
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
                    lblAuthorizationNo.Text = "SRVC/2025/102";
                    lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    lblCompanyName.Text = ds.Tables[0].Rows[0]["SRVCED_NAMEOFUNIT"].ToString();

                    lblPremisesAddress.Text = ds.Tables[0].Rows[0]["REP_DOORNO"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["REP_LOCALITY"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["REP_VILLAGE"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["REP_MANDAL"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["REP_DIST"].ToString();

                    lblCompanyLocation.Text = ds.Tables[0].Rows[0]["SRVCED_SURVEYDOOR"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["SRVCED_LOCALITY"].ToString() + ", " +
                         ds.Tables[0].Rows[0]["SRVCED_LANDMARK"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["VillageName"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["Mandalname"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["DistrictName"].ToString();

                }
                if(ds.Tables.Count >= 10 && ds.Tables[10].Rows.Count > 0)
                { 
                    lblEwasteQuantity.Text = ds.Tables[10].Rows[0]["EWD_EWASTEGENQUANTITY"].ToString();
                    lblEwasteNature.Text = ds.Tables[10].Rows[0]["EWD_EWASTEREFURBISHED"].ToString();
                    lblValidFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lblValidTo.Text = DateTime.Now.AddYears(1).AddDays(-1).ToString("dd-MM-yyyy");
                    lblDisposalLocation.Text = ds.Tables[10].Rows[0]["EWD_EWASTEDISPOSAL"].ToString();

                    lblSingature.Text = "This is an electronically generated report, hence does not require signature";
                    //lblDesignation.Text = "";
                    lblSignatureDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                }
            }
        }
    }

}