﻿using MeghalayaUIP.BAL.SVRCBAL;
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
    public partial class SRVCApplStatus : System.Web.UI.Page
    {       
        SVRCBAL objSrvcbal = new SVRCBAL();
        string SRVCQID, Status;
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
                    if (Convert.ToString(Session["SRVCQID"]) != "")
                    {
                        SRVCQID = Convert.ToString(Session["SRVCQID"]);
                        if (Request.QueryString.Count > 0)
                        {                            
                            lblType.Text = " " + Request.QueryString[1].ToString() + ":";
                            if (Request.QueryString[1].ToString() == "UnderProcess")
                            { lblType.Text = " Under Process:"; }
                            if (Request.QueryString[1].ToString() == "ScrutinyCompleted")
                            { lblType.Text = " Scrutiny Completed:"; }
                            if (Request.QueryString[1].ToString() == "ScrutinyPending")
                            { lblType.Text = " Scrutiny Pending:"; }
                            if (!IsPostBack)
                            {
                                BindApplStatus();
                            }
                        }
                    }                    
                    else
                    {
                        string newurl = "~/User/Services/SRVCUserDashboard.aspx";
                        Response.Redirect(newurl);
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

        protected void grdTrackerDetails_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridView HeaderGrid = (GridView)sender;
                    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


                    TableCell HeaderCell = new TableCell();
                    HeaderCell.ColumnSpan = 4;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Text = "";
                    HeaderCell.Font.Bold = true;
                    HeaderGridRow.Cells.Add(HeaderCell);


                    HeaderCell = new TableCell();
                    HeaderCell.ColumnSpan = 3;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.Font.Bold = true;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Text = "Prescrutiny Status";
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.ColumnSpan = 1;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Font.Bold = true;
                    HeaderCell.Text = "";
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.ColumnSpan = 2;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.Font.Bold = true;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Text = "Approval Stage";
                    HeaderCell.Visible = true;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.ColumnSpan = 1;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Font.Bold = true;
                    HeaderCell.Text = "";
                    HeaderGridRow.Cells.Add(HeaderCell);

                    grdTrackerDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }

        protected void grdTrackerDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblQuesnrId = (Label)e.Row.FindControl("lblQuesnrId");
                    Label lblDeptId = (Label)e.Row.FindControl("lblDeptId");
                    Label lblApprovalId = (Label)e.Row.FindControl("lblApprovalId");
                    Label lblStageId = (Label)e.Row.FindControl("lblStageId");

                    HyperLink hplApprvd = (HyperLink)e.Row.FindControl("lblStatus");
                    if (lblApprovalId.Text == "82" && (lblStageId.Text == "13" || lblStageId.Text == "15"))
                        hplApprvd.NavigateUrl = "~/User/Services/SWMCertificate.aspx?QDID="+ lblQuesnrId.Text;
                    else if (lblApprovalId.Text == "83" && (lblStageId.Text == "13" || lblStageId.Text == "15"))
                        hplApprvd.NavigateUrl = "~/User/Services/BMWCertificate.aspx?QDID=" + lblQuesnrId.Text;
                    else if (lblApprovalId.Text == "92" && (lblStageId.Text == "13" || lblStageId.Text == "15"))
                        hplApprvd.NavigateUrl = "~/User/Services/EWMManfctrRefCertificate.aspx?QDID=" + lblQuesnrId.Text;
                    else if (lblApprovalId.Text == "93" && (lblStageId.Text == "13" || lblStageId.Text == "15"))
                        hplApprvd.NavigateUrl = "~/User/Services/BatteryWMCertificate.aspx?QDID=" + lblQuesnrId.Text;
                    else if (lblApprovalId.Text == "105" && (lblStageId.Text == "13" || lblStageId.Text == "15"))
                        hplApprvd.NavigateUrl = "~/User/Services/PWMCertificate.aspx?QDID=" + lblQuesnrId.Text;
                    else if(lblApprovalId.Text == "106" && (lblStageId.Text == "13" || lblStageId.Text == "15"))
                        hplApprvd.NavigateUrl = "~/User/Services/CDWMCertificate.aspx?QDID=" + lblQuesnrId.Text;

                }
                
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        /*  public void BindData(string userid)
 {
     try
     {
         UnitID = "%";
         Status = "UNDERPROCESS";

         DataSet ds = new DataSet();
         ds = objSrvcbal.GetApplicationStatus(hdnUserID.Value, UnitID, Status);
         if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
         {
             GVApplictionStatus.DataSource = ds;
             GVApplictionStatus.DataBind();
         }

     }
     catch (Exception ex)
     {
         Failure.Visible = true;
         lblmsg0.Text = ex.Message;
         MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
     }
 }*/
        /*   protected void lbtnBack_Click(object sender, EventArgs e)
           {
               try
               {
                   Response.Redirect("~/User/Services/SRVCUserDashboard.aspx");
               }
               catch (Exception ex)
               {
                   lblmsg0.Text = ex.Message;
                   Failure.Visible = true;
                   MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
               }


           } */
        protected void BindApplStatus()
        {
            try
            {
                DataSet dsApprovals = new DataSet();
                SRVCQID = Convert.ToString(Convert.ToString(Session["SRVCQID"]));

                dsApprovals = objSrvcbal.GetApplicationStatus(hdnUserID.Value, SRVCQID, Request.QueryString[1].ToString());
                if (dsApprovals.Tables.Count > 0)
                {
                    if (dsApprovals.Tables[0].Rows.Count > 0)
                    {
                        grdTrackerDetails.DataSource = dsApprovals.Tables[0];
                        grdTrackerDetails.DataBind();
                       // lblDOA.Text = Convert.ToString(dsApprovals.Tables[0].Rows[0]["DATEOFAPPLICATION"]);
                    }
                    if (dsApprovals.Tables[1].Rows.Count > 0)
                    {
                        lblUnitID.Text = Convert.ToString(dsApprovals.Tables[1].Rows[0]["SRVCED_UIDNO"]);
                        lblUnitNmae.Text = Convert.ToString(dsApprovals.Tables[1].Rows[0]["SRVCED_NAMEOFUNIT"]);

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
    }
}