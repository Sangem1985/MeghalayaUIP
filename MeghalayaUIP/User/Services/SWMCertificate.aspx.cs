using MeghalayaUIP.BAL.SVRCBAL;
using System;
using MeghalayaUIP.DAL.SVRCDAL;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System.Xml;

namespace MeghalayaUIP.User.Services
{

    public partial class SWMCertificate : System.Web.UI.Page
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
            ds = objSrvcbal.GetSRVCApplicationDetails(Request.QueryString[0].ToString(), hdnUserID.Value, "82");
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    lblFileNo.Text = "2025/102/0903202583";
                    lblAuthorizationNo.Text = "SRVC/2025/102";
                    lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lblApplicationNo.Text = ds.Tables[0].Rows[0]["SRVCED_UIDNO"].ToString();
                    lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    lblPollutionCommittee.Text =lblPollutionBoard.Text = "Meghalaya";
                    lblApplicantName.Text = ds.Tables[0].Rows[0]["REP_NAME"].ToString();
                    lblOfficeAddress.Text = ds.Tables[0].Rows[0]["REP_DOORNO"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["REP_LOCALITY"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["REP_VILLAGE"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["REP_MANDAL"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["REP_DIST"].ToString() ;
                            
                    lblFacilityAddress.Text = ds.Tables[0].Rows[0]["SRVCED_SURVEYDOOR"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["SRVCED_LOCALITY"].ToString() + ", " +
                         ds.Tables[0].Rows[0]["SRVCED_LANDMARK"].ToString() + ", " +                        
                        ds.Tables[0].Rows[0]["VillageName"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["Mandalname"].ToString() + ", " +
                        ds.Tables[0].Rows[0]["DistrictName"].ToString() ;

                  
                    
                    lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lblIssuePlace.Text = "Meghalaya";


                }
            }
        }
    }
}