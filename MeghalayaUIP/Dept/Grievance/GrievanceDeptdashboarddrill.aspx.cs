﻿using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Grievance
{
    public partial class GrievanceDeptdashboarddrill : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        MGCommonBAL objcomBal = new MGCommonBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["DeptUserInfo"] != null)
                {
                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.UserID;
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        if(Request.QueryString["status"] != null)
                        {
                            ddlStatus.SelectedValue = Request.QueryString["status"].ToString();
                        }

                        BindData(ObjUserInfo.Deptid);

                    }
                }
                else
                {
                    Response.Redirect("~/DeptLogin.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;               
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        public void BindData(string DeptID)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objcomBal.GetDepGrievanceDashboard(DeptID, hdnUserID.Value);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Request.QueryString.Count > 0)
                    {
                        ddlStatus.SelectedValue= Request.QueryString[0].ToString();
                        ddlStatus_SelectedIndexChanged(null, EventArgs.Empty);
                    }
                    else
                    {
                        divPending.Visible = true;
                        divRedressed.Visible = true;
                        divRejected.Visible = true;
                    }

                    lblPendingTotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["PENDINGTOTAL"]);
                    lblPendingWithin.Text = Convert.ToString(ds.Tables[0].Rows[0]["PENDINGWITHIN"]);
                    lblPendingBeyond.Text = Convert.ToString(ds.Tables[0].Rows[0]["PENDINGBEYOND"]);
                    lblRedressedTotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["REDRESSEDTOTAL"]);
                    lblRedressedWithin.Text = Convert.ToString(ds.Tables[0].Rows[0]["REDRESSEDWITHIN"]);
                    lblRedressedBeyond.Text = Convert.ToString(ds.Tables[0].Rows[0]["REDRESSEDBEYOND"]);
                    lblRejectedTotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["REJECTEDTOTAL"]);
                    lblRejectedWithin.Text = Convert.ToString(ds.Tables[0].Rows[0]["REJECTEDWITHIN"]);
                    lblRejectedBeyond.Text = Convert.ToString(ds.Tables[0].Rows[0]["REJECTEDBEYOND"]);
                    if (lblPendingTotal.Text == "0")
                        anchrPendingTotal.HRef = "#";
                    if (lblPendingWithin.Text == "0")
                        anchrPendingWithin.HRef = "#";
                    if (lblPendingBeyond.Text == "0")
                        anchrPendingBeyond.HRef = "#";
                    if (lblRedressedTotal.Text == "0")
                        anchrRedressedTotal.HRef = "#";
                    if (lblRedressedWithin.Text == "0")
                        anchrRedressedWithin.HRef = "#";
                    if (lblRedressedBeyond.Text == "0")
                        anchrRedressedBeyond.HRef = "#";
                    if (lblRejectedTotal.Text == "0")
                        anchrRejectedTotal.HRef = "#";
                    if (lblRejectedWithin.Text == "0")
                        anchrRejectedWithin.HRef = "#";
                    if (lblRejectedBeyond.Text == "0")
                        anchrRejectedBeyond.HRef = "#";

                }
                else
                {
                    lblmsg0.Text = "Some Internal Error Occured please try again";
                    Failure.Visible = true;
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
                Response.Redirect("~/Dept/Grievance/GrievanceDeptDashbord.aspx");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatus.SelectedValue == "Total" || ddlStatus.SelectedValue == "0")
                {
                    divPending.Visible = true;
                    divRedressed.Visible = true;
                    divRejected.Visible = true;
                }
                else if (ddlStatus.SelectedValue == "Pending")
                {
                    divPending.Visible = true;
                    divRedressed.Visible = false;
                    divRejected.Visible = false;
                }
                else if (ddlStatus.SelectedValue == "Redressed")
                {
                    divPending.Visible = false;
                    divRedressed.Visible = true;
                    divRejected.Visible = false;
                }
                else if (ddlStatus.SelectedValue == "Rejected")
                {
                    divPending.Visible = false;
                    divRedressed.Visible = false;
                    divRejected.Visible = true;
                }
            }
            catch(Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }         


        }
    }
}