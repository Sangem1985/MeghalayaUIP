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
    public partial class CDWMCertificate : System.Web.UI.Page
    {
        SVRCBAL objSrvcbal = new SVRCBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try { 
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
                ds = objSrvcbal.GetSRVCApplicationDetails(Request.QueryString[0].ToString(), hdnUserID.Value, "106");
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblApplicationNumber.Text = ds.Tables[0].Rows[0]["SRVCED_UIDNO"].ToString();

                        lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        lblFacilityLocation.Text = ds.Tables[0].Rows[0]["REP_DOORNO"].ToString() + ", " +
                            ds.Tables[0].Rows[0]["REP_LOCALITY"].ToString() + ", " +
                            ds.Tables[0].Rows[0]["REP_VILLAGE"].ToString() + ", " +
                            ds.Tables[0].Rows[0]["REP_MANDAL"].ToString() + ", " +
                            ds.Tables[0].Rows[0]["REP_DIST"].ToString();

                        lblOfficeAddress.Text = ds.Tables[0].Rows[0]["SRVCED_SURVEYDOOR"].ToString() + ", " +
                            ds.Tables[0].Rows[0]["SRVCED_LOCALITY"].ToString() + ", " +
                             ds.Tables[0].Rows[0]["SRVCED_LANDMARK"].ToString() + ", " +
                            ds.Tables[0].Rows[0]["VillageName"].ToString() + ", " +
                            ds.Tables[0].Rows[0]["Mandalname"].ToString() + ", " +
                            ds.Tables[0].Rows[0]["DistrictName"].ToString();

                    }
                    if (ds.Tables.Count > 11 && ds.Tables[11].Rows.Count > 0)
                    {

                        lblStatePolutnBoard.Text = "Meghalaya";
                        lblAuthorizedPerson.Text = ds.Tables[11].Rows[0]["CDWM_NAME_OF_NODAL_OFFICER"].ToString();
                        lblValidityDate.Text = DateTime.Now.AddYears(1).AddDays(-1).ToString("dd/MM/yyyy");
                        lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    }
                    lblStatePolutn2.Text = "Meghalaya";
                    lblIssuePlace.Text = "Meghalaya";
                }
            }
            catch (Exception ex)
            {
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }


        }
    }
}