using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class IntenttoInvestPrint : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
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

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindData();
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                throw ex;
            }
        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                string ID = Request.QueryString[0].ToString();
                ds = objcfebal.getIntentInvestPrint(ID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //  ddlCategory.SelectedValue = ds.Tables[0].Rows[0][""].ToString();
                    lblNameCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["COMPANYNAME"]);
                    lblPan.Text = Convert.ToString(ds.Tables[0].Rows[0]["PANNO"]);
                    lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["REGOFCADDRESS"]);
                    lblCountry.Text = Convert.ToString(ds.Tables[0].Rows[0]["COUNTRY"]);
                    lblPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["REGOFCMOBILE"]);
                    lblPin.Text = Convert.ToString(ds.Tables[0].Rows[0]["REGOFCPINCODE"]);
                    lblEmailId.Text = Convert.ToString(ds.Tables[0].Rows[0]["REGOFCEMAIL"]);
                    lblFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["REGOFCFAXNO"]);
                    lblWebsit.Text = Convert.ToString(ds.Tables[0].Rows[0]["REGOFCWEBSITE"]);
                    lblNames.Text = Convert.ToString(ds.Tables[0].Rows[0]["NAME"]);
                    lblDesignation.Text = Convert.ToString(ds.Tables[0].Rows[0]["DESIGNATION"]);
                    lblEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["EMAIL"]);
                    lblMobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["MOBILE"]);
                    lblProjectProposal.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECTPROPOSAL"]);
                    lblInvestment.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISMOUSIGNED"]);
                    lblPCB.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJCATEGORY"]);
                    lblSectors.Text = Convert.ToString(ds.Tables[0].Rows[0]["SECTORNAME"]);
                    lblProposedInvest.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECTINVESTMENT"]);
                    lblEmployment.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECTEMPLOYMENT"]);
                    lblProjectLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECTLOCATION"]);
                    lblExtendYear.Text = Convert.ToString(ds.Tables[0].Rows[0]["YEAROFCOMMENCEMENT"]);
                    lblExpectation.Text = Convert.ToString(ds.Tables[0].Rows[0]["GOVTSUPPORT"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}