﻿using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Renewal
{
    public partial class RENUserDashboard : System.Web.UI.Page
    {
        RenewalBAL objrenbal=new RenewalBAL();
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
        public void BindApproved()
        {
            try
            {
                DataSet dsApproved = new DataSet();
                if (Request.QueryString != null)
                {
                    if (Request.QueryString.Count > 0)
                    {
                        UnitID = Request.QueryString[0];
                    }
                }
                else 
                {
                    UnitID = "%";
                }
                if (UnitID == "%")
                    lblHdng.Text = " Status of Application for All Units";
                else lblHdng.Text = "";

                dsApproved = objrenbal.GetRENapplications(hdnUserID.Value, UnitID);
                if (dsApproved.Tables.Count > 0)
                {
                    if (dsApproved.Tables[0].Rows.Count > 0)
                    {
                        gvRenewals.DataSource = dsApproved.Tables[0];
                        gvRenewals.DataBind();
                    }
                    else
                    {
                        gvRenewals.DataSource = null;
                        gvRenewals.DataBind();
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
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnApplyRenewal_Click(object sender, EventArgs e)
        {
           
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblunitId = (Label)row.FindControl("lblUNITID");
                Label lblRENQDID = (Label)row.FindControl("lblRENQDID");
                Session["RENUNITID"] = lblunitId.Text;
                Session["RENQID"] = lblRENQDID.Text;
                string newurl = "RENIndustryDetails.aspx";
                Response.Redirect(newurl);
            
        }

        protected void btnCombndAppl_Click(object sender, EventArgs e)
        {

        }

        protected void btnApplStatus_Click(object sender, EventArgs e)
        {

        }

        protected void gvRenewals_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int gvrcnt = gvRenewals.Rows.Count;
                    Button btnApply;
                    Button btnApprvlsReq;
                    Button btnApplstatus;
                    Label lblRENQuesnrID = (Label)e.Row.FindControl("lblRENQDID");
                    Label lblunitId = (Label)e.Row.FindControl("lblUNITID");
                    Label APPLSTATUS = (Label)e.Row.FindControl("lblRENAPPLSTATUS");
                    HyperLink hplAppld = (HyperLink)e.Row.FindControl("hplApplied");
                    HyperLink hplApprvd = (HyperLink)e.Row.FindControl("hplApproved");
                    HyperLink hplUndrPrc = (HyperLink)e.Row.FindControl("hplundrProcess");
                    HyperLink hplRejctd = (HyperLink)e.Row.FindControl("hplRejected");
                    HyperLink hplQryRaised = (HyperLink)e.Row.FindControl("hplQueryRaised");
                    /*if (hplAppld.Text != "0")
                        hplAppld.NavigateUrl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + lblunitId.Text + "&Type=Applied";
                    if (hplApprvd.Text != "0")
                        hplApprvd.NavigateUrl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + lblunitId.Text + "&Type=Approved";
                    if (hplUndrPrc.Text != "0")
                        hplUndrPrc.NavigateUrl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + lblunitId.Text + "&Type=UnderProcess";
                    if (hplRejctd.Text != "0")
                        hplRejctd.NavigateUrl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + lblunitId.Text + "&Type=Rejected";
                    if (hplQryRaised.Text != "0")
                        hplQryRaised.NavigateUrl = "~/User/CFE/CFEQueryDashBoard.aspx?UnitID=" + lblunitId.Text + "&Type=QueryRaised";*/

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
                    string Applstatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RENAPPLSTATUS"));

                    if (Applstatus == "" || Applstatus == null || Applstatus == "2")
                    {
                        btnApply = (Button)e.Row.FindControl("btnApplyRenewal");
                        btnApprvlsReq = (Button)e.Row.FindControl("btnCombndAppl");
                        btnApplstatus = (Button)e.Row.FindControl("btnApplStatus");
                        btnApply.Enabled = true;
                        btnApprvlsReq.Enabled = false; 
                        btnApplstatus.Enabled = false; 
                        btnApplstatus.Style.Add("border", "none");
                        btnApplstatus.Style.Add("color", "black");
                    }
                    else
                    {
                        btnApply = (Button)e.Row.FindControl("btnApplyRenewal");
                        btnApply.Enabled = false;
                        btnApply.BackColor = System.Drawing.Color.LightGray;
                        btnApply.Style.Add("border", "none");
                        btnApply.Style.Add("color", "black");
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
    }
}