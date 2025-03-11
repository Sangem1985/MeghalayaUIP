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
    public partial class SRVCUserDashboard : System.Web.UI.Page
    {
        SVRCBAL objSrvcbal = new SVRCBAL();
        string UnitID;
        int TotApplied, TotApproved, TotRejected, TotQueryRaised, TotUnderProcess;
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
                        BindApproved();
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/Dashboard/MainDashboard.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnApplyAgain_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("EnterpriseDetails.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindApproved()
        {
            try
            {
                DataSet dsApproved = new DataSet();
               
                dsApproved = objSrvcbal.GetSRVCapplications(hdnUserID.Value, "%");
                if (dsApproved.Tables.Count > 0)
                {
                    if (dsApproved != null && dsApproved.Tables[0].Rows.Count > 0)
                    {
                        GvServices.DataSource = dsApproved.Tables[0];
                        GvServices.DataBind();
                    }
                    else
                    {
                        GvServices.DataSource = null;
                        GvServices.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GvServices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                   
                    Label lblSRVCQuesnrID = (Label)e.Row.FindControl("lblSRVCQDID");
                    Label lblunitId = (Label)e.Row.FindControl("lblUNITID");
                    Label APPLSTATUS = (Label)e.Row.FindControl("lblSRVCAPPLSTATUS");
                    Label lblSRVCQDID = (e.Row.FindControl("lblSRVCQDID") as Label);
                    Button btnApplySRVC = (Button)e.Row.FindControl("btnApplySRVC");
                    Button btnCombndAppl = (Button)e.Row.FindControl("btnCombndAppl");
                    Button btnApplStatus = (Button)e.Row.FindControl("btnApplStatus");
                    HyperLink hplAppld = (HyperLink)e.Row.FindControl("hplApplied");
                    HyperLink hplApprvd = (HyperLink)e.Row.FindControl("hplApproved");
                    HyperLink hplUndrPrc = (HyperLink)e.Row.FindControl("hplundrProcess");
                    HyperLink hplRejctd = (HyperLink)e.Row.FindControl("hplRejected");
                    HyperLink hplQryRaised = (HyperLink)e.Row.FindControl("hplQueryRaised");
                    HyperLink anchortaglinkStatus = (e.Row.FindControl("anchortaglinkStatus") as HyperLink);

                    int TotalAppl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "APPLIEDCOUNT"));
                    TotApplied = TotApplied + TotalAppl;

                    int TotalAppr = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "APPROVEDDCOUNT"));
                    TotApproved = TotApproved + TotalAppr;

                    int TotalUndrPrcs = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UNDERPROCESSCOUNT"));
                    TotUnderProcess = TotUnderProcess + TotalUndrPrcs;

                    int TotalRej = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "REJECTEDDCOUNT"));
                    TotRejected = TotRejected + TotalRej;

                    int TotalQuery = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QUERYCOUNT"));
                    TotQueryRaised = TotQueryRaised + TotalQuery;
                    string Applstatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SRVCAPPLSTATUS"));

                    if (Applstatus == "3")
                    {                       
                        btnApplyAgain.Visible = true;
                        btnApplySRVC.Enabled = false;
                        btnCombndAppl.Enabled = true;
                        btnApplStatus.Enabled = true;
                    }
                    else if (Applstatus == "2")
                    {
                        btnApplySRVC.Text = "Incomplete";
                        Session["SRVCQID"] = lblSRVCQDID.Text.ToString();
                        anchortaglinkStatus.NavigateUrl = "EnterpriseDetails.aspx";
                        anchortaglinkStatus.Text = "Incomplete Application";
                        btnApplyAgain.Visible = false;
                        anchortaglinkStatus.Visible = true;
                    }
                   

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[6].Text = "Total";
                    e.Row.Cells[7].Text = TotApplied.ToString();
                    e.Row.Cells[8].Text = TotApproved.ToString();
                    e.Row.Cells[9].Text = TotUnderProcess.ToString();
                    e.Row.Cells[10].Text = TotRejected.ToString();
                    e.Row.Cells[11].Text = TotQueryRaised.ToString();
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnApplySRVC_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblSRVCQDID = (Label)row.FindControl("lblSRVCQDID");
                Session["SRVCQID"] = lblSRVCQDID.Text;
                string newurl = "EnterpriseDetails.aspx";
                Response.Redirect(newurl);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnApplStatus_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;

                Label lblSRVCQDID = (Label)row.FindControl("lblSRVCQDID");
                Session["SRVCQID"] = lblSRVCQDID.Text;
                string newurl = "SRVCDashBoardStatus.aspx";
                Response.Redirect(newurl);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

    }
}