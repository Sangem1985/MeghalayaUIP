﻿using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using MeghalayaUIP.DAL.CommonDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Dashboard
{
    public partial class Dashboardstatus : System.Web.UI.Page
    {
        MGCommonBAL objcommonBAL = new MGCommonBAL();
        MasterBAL mstrBAL = new MasterBAL();
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

                    if (Request.QueryString.Count > 0)
                    {
                        UnitID = Convert.ToString(Request.QueryString[0]);
                        lblType.Text = " " + Request.QueryString[1].ToString() + ":";
                        if (Request.QueryString[1].ToString() == "UnderProcess")
                        { lblType.Text = " Under Process:"; }
                        if (Request.QueryString[1].ToString() == "ScrutinyCompleted")
                        { lblType.Text = " Scrutiny Completed:"; }
                        if (Request.QueryString[1].ToString() == "ScrutinyPending")
                        { lblType.Text = " Scrutiny Pending:"; }

                    }
                    else
                    {
                        string newurl = "~/User/MainDashboard.aspx";
                        Response.Redirect(newurl);
                    }

                    Page.MaintainScrollPositionOnPostBack = true;

                    if (!IsPostBack)
                    {
                        BindApplStatus();
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
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
                UnitID = Convert.ToString(Request.QueryString[0]);

                dsApprovals = objcommonBAL.GetCFEUserDashboardStatus(hdnUserID.Value, UnitID, Request.QueryString[1].ToString());
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

        protected void grdTrackerDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblUnitID = (Label)e.Row.FindControl("lblUnitID");
                    Label lblQuesnrId = (Label)e.Row.FindControl("lblQuesnrId");
                    Label lblDeptId = (Label)e.Row.FindControl("lblDeptId");
                    Label lblApprovalId = (Label)e.Row.FindControl("lblApprovalId");
                    Label lblStageId = (Label)e.Row.FindControl("lblStageId");
                    Label lblScrutinyDoc = (Label)e.Row.FindControl("lblScrutinyDoc");
                    Label lblApprovalDoc = (Label)e.Row.FindControl("lblApprovalDoc");

                    HyperLink hplScrutiny = (HyperLink)e.Row.FindControl("lblScrutiny");
                    HyperLink hplApprvd = (HyperLink)e.Row.FindControl("lblStatus");

                    if (lblStageId.Text == "13" || lblStageId.Text == "15")
                    {
                        if (lblApprovalId.Text == "2")
                            hplApprvd.NavigateUrl = "~/User/Services/HAZWMCertificate.aspx";
                        else
                            hplApprvd.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(lblApprovalDoc.Text);


                    }
                    else
                        hplScrutiny.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(lblScrutinyDoc.Text);


                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
    }
}