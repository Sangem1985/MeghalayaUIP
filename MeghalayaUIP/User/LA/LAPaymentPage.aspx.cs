using MeghalayaUIP.BAL.LABAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.LA
{
    public partial class LAPaymentPage : System.Web.UI.Page
    {
        LABAL Objland = new LABAL();
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

                    UnitID = Convert.ToString(Session["LANDUNITID"]);

                    Page.MaintainScrollPositionOnPostBack = true;
                    if (!IsPostBack)
                    {                       
                        BindData();
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = Objland.GetLANDPaymentAmounttoPay(hdnUserID.Value, UnitID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {                            
                            hdnQuesID.Value = Convert.ToString(Session["ISD_QDID"]);
                            hdnUIDNo.Value = Convert.ToString(ds.Tables[0].Rows[0]["ISD_LAUIDNO"]);
                            hdnPaymentAmount.Value= Convert.ToString(ds.Tables[0].Rows[0]["ISD_PROCESSINGFEE"]);
                            lblPaymentAmount.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["ISD_PROCESSINGFEE"]);
                            grdApprovals.DataSource = ds.Tables[0];
                            grdApprovals.DataBind();
                            grdApprovals.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(hdnPaymentAmount.Value) > 0)
                {
                    string receipt = "MIP_" + DateTime.Now.Year + DateTime.Now.Month +
                    DateTime.Now.Day + DateTime.Now.Minute + DateTime.Now.Year + DateTime.Now.Second + DateTime.Now.Millisecond;
                    Session["OrderNo"] = receipt;

                    Session["PaymentAmount"] = Convert.ToDecimal(hdnPaymentAmount.Value);
                    Response.Redirect("~/User/Payments/RazorPaymentPage.aspx?receipt=" + receipt + "&Amount=" + hdnPaymentAmount.Value);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select atleast one Approval')", true);
                    return;
                }
            }
            catch(Exception ex) { }
        }
    }
}