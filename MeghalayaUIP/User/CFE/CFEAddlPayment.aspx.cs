using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEAddlPayment : System.Web.UI.Page
    {
        MGCommonBAL objcommonBAL = new MGCommonBAL();
        MasterBAL mstrBAL = new MasterBAL();
        string UnitID;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                //if (Session["UserInfo"] != null)
                //{
                //    var ObjUserInfo = new UserInfo();
                //    if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                //    {
                //        ObjUserInfo = (UserInfo)Session["UserInfo"];
                //    }
                //    if (hdnUserID.Value == "")
                //    {
                //        hdnUserID.Value = ObjUserInfo.Userid;

                //    }

                //    if (Request.QueryString.Count > 0)
                //    {
                //        UnitID = Convert.ToString(Request.QueryString[0]);
                //        lblType.Text = " " + Request.QueryString[1].ToString() + ":";
                //        if (Request.QueryString[1].ToString() == "UnderProcess")
                //        { lblType.Text = " Under Process:"; }
                //        if (Request.QueryString[1].ToString() == "ScrutinyCompleted")
                //        { lblType.Text = " Scrutiny Completed:"; }
                //        if (Request.QueryString[1].ToString() == "ScrutinyPending")
                //        { lblType.Text = " Scrutiny Pending:"; }

                //    }
                //    else
                //    {
                //        string newurl = "~/User/MainDashboard.aspx";
                //        Response.Redirect(newurl);
                //    }

                //    Page.MaintainScrollPositionOnPostBack = true;

                  
                //}
                //else
                //{
                //    Response.Redirect("~/Login.aspx");
                //}
                if (!IsPostBack)
                {
                    BindApplStatus();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindApplStatus()
        {
            try
            {
                DataSet dsApprovals = new DataSet();
               // UnitID = Convert.ToString(Request.QueryString[0]);

                dsApprovals = objcommonBAL.GetCFEUserDashboardStatus("1054", "1089", "AddlPayment");
                if (dsApprovals.Tables.Count > 0)
                {
                    if (dsApprovals.Tables[0].Rows.Count > 0)
                    {
                        grdTrackerDetails.DataSource = dsApprovals.Tables[0];
                        grdTrackerDetails.DataBind();
                        lblDOA.Text = Convert.ToString(dsApprovals.Tables[0].Rows[0]["DATEOFAPPLICATION"]);
                    }
                    if (dsApprovals.Tables[1].Rows.Count > 0)
                    {
                        lblUnitID.Text = Convert.ToString(dsApprovals.Tables[1].Rows[0]["CFEQD_CFEUIDNO"]);
                        lblUnitNmae.Text = Convert.ToString(dsApprovals.Tables[1].Rows[0]["CFEQD_COMPANYNAME"]);

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

        protected void chkSel_CheckedChanged(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
            CheckBox cb = (CheckBox)grdTrackerDetails.Rows[selRowIndex].FindControl("chkSel");
            Label lblAmount = (Label)grdTrackerDetails.Rows[selRowIndex].FindControl("lblAmount");
            if (ViewState["Amount"] == null)
            {
                ViewState["Amount"] = 0;
            }
            decimal PrvAmount = Convert.ToDecimal(ViewState["Amount"].ToString());
            decimal TotalPaymentAmount;

            if (cb.Checked)
            {
                TotalPaymentAmount = PrvAmount + Convert.ToDecimal(lblAmount.Text);

            }
            else
            {
                TotalPaymentAmount = PrvAmount - Convert.ToDecimal(lblAmount.Text);
            }
            lblPaymentAmount.InnerText = TotalPaymentAmount.ToString();
            ViewState["Amount"] = TotalPaymentAmount.ToString();
        }
    }
}