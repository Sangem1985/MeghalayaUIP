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
    public partial class GrievanceDeptView : System.Web.UI.Page
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
                DataSet ds = new DataSet(); string status = "";
                if (Request.QueryString.Count > 0)
                    status = Convert.ToString(Request.QueryString["status"]);
                else
                    status = "%";
                ds = objcomBal.GetDepGrievanceList(DeptID, null, status);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvGrievanceDtls.DataSource = ds.Tables[0];
                    gvGrievanceDtls.DataBind();
                    for (int i = 0; i < gvGrievanceDtls.Rows.Count; i++)
                    {
                        Button BtnProcess = (Button)gvGrievanceDtls.Rows[i].FindControl("BtnProcess");
                        if (gvGrievanceDtls.Rows[i].Cells[11].Text == "Pending")
                        {
                            BtnProcess.Enabled = true;
                        }
                        else
                            BtnProcess.Enabled = false; ;
                    }
                    //gvGrievanceDtls.Columns[11].

                }
                else
                {
                    gvGrievanceDtls.DataSource = null;
                    gvGrievanceDtls.DataBind();
                }

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void BtnProcess_Click(object sender, EventArgs e)
        {
            try
            {

                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblID = (Label)row.FindControl("lblGrvID");
                if (lblID != null)
                {

                    string newurl = "~/Dept/Grievance/GrievanceDeptProcess.aspx?ID=" + lblID.Text+"&status="+ Convert.ToString(Request.QueryString["status"]);
                    Response.Redirect(newurl);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Grievance/GrievanceDeptdashboarddrill.aspx");
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