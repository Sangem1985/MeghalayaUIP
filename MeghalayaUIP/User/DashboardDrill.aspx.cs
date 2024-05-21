using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User
{
    public partial class DashboardDrill : System.Web.UI.Page
    {
        MGCommonBAL objcommonBAL = new MGCommonBAL();
        string UnitID;
        protected void Page_Load(object sender, EventArgs e)
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
                //UnitID = "1007";
                if (Request.QueryString.Count > 0)
                {
                    UnitID = Convert.ToString(Request.QueryString[0]);
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
        protected void BindApplStatus()
        {
            try
            {
                int ModuleID = 0;
                DataSet dsStatus = new DataSet();
                UnitID = Convert.ToString(Request.QueryString[0]);
                ddlUnitNames.SelectedValue = UnitID;
                string module = Convert.ToString(Request.QueryString[1]);
                if (module == "PreEstablishment")
                {
                    ModuleID = 1; trCFE.Visible = true; trCFO.Visible = false; trINC.Visible = false;
                    lblmodule.Text = "Pre - Establishment";
                }
                else if (module == "PreOperational")
                {
                    ModuleID = 2; trCFE.Visible = false; trCFO.Visible = true; trINC.Visible = false;
                }
                else if (module == "Incentives")
                {
                    ModuleID = 3; trCFE.Visible = false; trCFO.Visible = false; trINC.Visible = true;
                }

                dsStatus = objcommonBAL.GetUserDashboardStatusByModule(ModuleID, UnitID);
                if (dsStatus.Tables.Count > 0)
                {
                    if (dsStatus.Tables[0].Rows.Count > 0)
                    {
                        lblUnitID.Text = Convert.ToString(dsStatus.Tables[0].Rows[0]["UNITID"]);
                        lblUnitName.Text = Convert.ToString(dsStatus.Tables[0].Rows[0]["COMPANYNAME"]);
                    }
                    if (dsStatus.Tables[1].Rows.Count > 0)
                    {
                        ddlUnitNames.DataSource = dsStatus.Tables[1];
                        ddlUnitNames.DataTextField = "COMPANYNAME";
                        ddlUnitNames.DataValueField = "UNITID";
                        ddlUnitNames.DataBind();
                        AddSelect(ddlUnitNames);
                    }

                    if (dsStatus.Tables[2].Rows.Count > 0)
                    {
                        btnCFETotal.Text = Convert.ToString(dsStatus.Tables[2].Rows[0]["TotalApplications"]);
                        btnCFEApproved.Text = Convert.ToString(dsStatus.Tables[2].Rows[0]["ApprovedApplications"]);
                        btnCFERejected.Text = Convert.ToString(dsStatus.Tables[2].Rows[0]["RejectedApplications"]);
                        btnCFEUnderProcess.Text = Convert.ToString(dsStatus.Tables[2].Rows[0]["UnderProcessApplications"]);
                        btnCFEQuery.Text = Convert.ToString(dsStatus.Tables[2].Rows[0]["Query"]);

                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void btnCFETotal_Click(object sender, EventArgs e)
        {
            try
            {
                string url;
                if (btnCFETotal.Text != "0")
                {
                    if (ddlUnitNames.SelectedItem.Text == "--Select--")
                    {
                        url = "Dashboardstatus.aspx?UnitID=" + Convert.ToString(Request.QueryString[0]) + "&Module=Pre - Establishment";
                        Response.Redirect(url);
                    }
                    else
                    {
                        url = "Dashboardstatus.aspx?UnitID=" + ddlUnitNames.SelectedValue;
                        Response.Redirect(url);
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnCFEApproved_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCFEApproved.Text != "0")
                {
                    if (ddlUnitNames.SelectedItem.Text == "--Select--")
                    {
                        string url = "Dashboardstatus.aspx?UnitID=" + Convert.ToString(Request.QueryString[0]);
                        Response.Redirect(url);
                    }
                    else
                    {
                        string url = "Dashboardstatus.aspx?UnitID=" + ddlUnitNames.SelectedValue;
                        Response.Redirect(url);
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnCFEUnderProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCFEUnderProcess.Text != "0")
                {
                    string url = "Dashboardstatus.aspx?UnitID=" + Convert.ToString(Request.QueryString[0]);
                    Response.Redirect(url);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnCFERejected_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCFERejected.Text != "0")
                {
                    string url = "Dashboardstatus.aspx?UnitID=" + Convert.ToString(Request.QueryString[0]);
                    Response.Redirect(url);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnCFEQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCFEQuery.Text != "0")
                {
                    string url = "Dashboardstatus.aspx?UnitID=" + Convert.ToString(Request.QueryString[0]);
                    Response.Redirect(url);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void ddlUnitNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitNames.SelectedItem.Text != "--Select--")
                {

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
}