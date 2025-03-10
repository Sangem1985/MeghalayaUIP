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
    public partial class BMWCertificate : System.Web.UI.Page
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
                ds = objSrvcbal.GetSRVCApplicationDetails(Request.QueryString[0].ToString(), hdnUserID.Value, "83");
                lblFileNo.Text = "MPCB/BMW-414/2020/2022-2023/83";
                lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                lblPollutionBoard.Text = "Meghalaya";
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count >= 3 && ds.Tables[3].Rows.Count > 0)
                    {       
                        lblBMW.Text = ds.Tables[3].Rows[0]["BMW_CAPACITYCBMWTF"].ToString();

                        //lblPollutionBoard.Text = "Atharva Primary Health Centre, East Jaintia Hills District ";

                    }
                }
                DateTime specificDate = new DateTime(2021, 1, 31);
                lblwaste.Text = specificDate.AddYears(5).AddDays(-1).ToString("dd-MM-yyyy");
                lblAutheration.Text = "The Authorised person / institution shall submit an Annual Report in prescribed Form-IV on or before 30th June every year for the period from January to December of the preceding year, and shall report any accident in Form - I immediately.";
                lblrenewal.Text = " The Authorised person / institution shall apply for renewal of the Authorisation in prescribed Form-II three months before its expiry date.";
                }
            catch (Exception ex)
            {
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
    }
}