﻿using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegApplDPRView : System.Web.UI.Page
    {
        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
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
                    hdnUserID.Value = ObjUserInfo.UserID;

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindData();
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GVDPRDET_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button button = e.Row.FindControl("View_id") as Button;
                if (button != null)
                {
                    if (
                       Request.QueryString["status"].ToString() == "TOTAL" ||
                       Request.QueryString["status"].ToString() == "TOBEPROCESSED" ||
                       Request.QueryString["status"].ToString() == "PROCESSED")
                        button.Text = "Process";
                    else
                        button.Text = "View";
                }
            }
        }

        protected void GVDPRDET_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "VIEW")
                {
                    string[] Arguents = e.CommandArgument.ToString().Split('$');
                    string UNITID = Arguents[0];
                    string INVESTERID = Arguents[1];

                    int stage = 3;

                    prd.Unitid = UNITID;
                    prd.Investerid = INVESTERID;
                    prd.Stage = stage;
                    Session["UNITID"] = UNITID;
                    Session["INVESTERID"] = INVESTERID;
                    Session["stage"] = stage;
                    Response.Redirect("PreRegApplDPRProcess.aspx?status=" + Request.QueryString["status"].ToString());
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindData()
        {
            try
            {
                DataTable dt = new DataTable();
                lblHdng.Text = "";

                if (Request.QueryString.Count > 0)
                {
                    prd.ViewStatus = Request.QueryString["status"].ToString();

                    if (Request.QueryString["status"].ToString() == "TOTAL")
                    { lblHdng.Text = "DPR- Total Applications"; }
                    else if (Request.QueryString["status"].ToString() == "TOBEPROCESSED")
                    { lblHdng.Text = "DPR Applications - To be Processed"; }
                    else if (Request.QueryString["status"].ToString() == "PROCESSED")
                    {
                        lblHdng.Text = "DPR Applications - Processed";
                    }
                }
                else
                {
                    prd.ViewStatus = "TOTAL";
                    lblHdng.Text = "DPR Total Applications";
                }
                if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                {
                    prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                }
                prd.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                prd.UserID = ObjUserInfo.UserID;
                dt = PreBAL.GetPreRegDPRDashBoardView(prd);
                GVDPRDET.DataSource = dt;
                GVDPRDET.DataBind();

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
                Response.Redirect("~/Dept/PreReg/PreRegApplDPRDashBoard.aspx");
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