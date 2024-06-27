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

namespace MeghalayaUIP.User.Dashboard
{
    public partial class DashboardDrill : System.Web.UI.Page
    {
        MGCommonBAL objcommonBAL = new MGCommonBAL();
        string UnitID; string url;
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

                Page.MaintainScrollPositionOnPostBack = true;

                if (!IsPostBack)
                {
                    BindUnits();
                    if (Request.QueryString.Count > 0)
                    { ddlUnitNames.SelectedValue = Request.QueryString[0]; }
                    BindApplStatus(ddlUnitNames.SelectedValue);
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }


        }
        protected void BindUnits()
        {
            try
            {
                DataSet dsUnits = new DataSet();
                dsUnits = objcommonBAL.GetApplByModuleName(hdnUserID.Value, "1");
                ddlUnitNames.DataSource = dsUnits.Tables[0];
                ddlUnitNames.DataTextField = "COMPANYNAME";
                ddlUnitNames.DataValueField = "UNITID";
                ddlUnitNames.DataBind();
                AddSelect(ddlUnitNames);
                if (Request.QueryString.Count > 0)
                { ddlUnitNames.SelectedValue = Request.QueryString[0]; }
                UnitID = ddlUnitNames.SelectedValue;
                ddlUnitNames_SelectedIndexChanged(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void BindApplStatus(string UnitID)
        {
            try
            {
                DataSet dsStatus = new DataSet();

                UnitID = ddlUnitNames.SelectedValue;

                dsStatus = objcommonBAL.GetUserDashboardStatusByModule(hdnUserID.Value, UnitID);
                if (dsStatus.Tables.Count > 0)
                {
                    if (ddlUnitNames.SelectedValue != "%")
                    {
                        if (dsStatus.Tables[0].Rows.Count > 0)
                        {
                            lblUnitAdress.Text = Convert.ToString(dsStatus.Tables[0].Rows[0]["UNITADDRESS"]);
                        }
                    }
                    if (dsStatus.Tables[1].Rows.Count > 0)
                    {
                        btnPreRegTotal.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["PRTOTAL"]);
                        btnPreRegApproved.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["PRAPPROVED"]);
                        btnPreRegRejected.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["PRREJECTED"]);
                        btnPreRegUnderProcess.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["PRUNDERPROCESS"]);
                        btnPreRegQuery.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["PRQUERYRAISED"]);

                        btnCFETotal.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["CFETOTAL"]);
                        btnCFEApproved.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["CFEAPPROVED"]);
                        btnCFERejected.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["CFEREJECTED"]);
                        btnCFEUnderProcess.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["CFEUNDERPROCESS"]);
                        btnCFEQuery.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["CFEQUERYRAISED"]);

                        btnCFOTotal.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["CFOTOTAL"]);
                        btnCFOApproved.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["CFOAPPROVED"]);
                        btnCFORejected.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["CFOREJECTED"]);
                        btnCFOUnderProcess.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["CFOUNDERPROCESS"]);
                        btnCFOQuery.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["CFOQUERYRAISED"]);

                        btnINCTotal.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["INCTOTAL"]);
                        btnINCApproved.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["INCAPPROVED"]);
                        btnINCRejected.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["INCREJECTED"]);
                        btnINCUnderProcess.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["INCUNDERPROCESS"]);
                        btnINCQuery.Text = Convert.ToString(dsStatus.Tables[1].Rows[0]["INCQUERYRAISED"]);

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
                li.Text = "--All--";
                li.Value = "%";
                ddl.Items.Insert(0, li);
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
                if (ddlUnitNames.SelectedValue != "%")
                {
                    lblHdng.Text = "Status Of Application";
                    divUnit.Visible = true;
                    lblUnitID.Text = ddlUnitNames.SelectedValue;
                    lblUnitName.Text = Convert.ToString(ddlUnitNames.SelectedItem.Text);
                }
                else
                {
                    divUnit.Visible = false;
                    lblHdng.Text = "Status of Application for All Units";
                }
                BindApplStatus(ddlUnitNames.SelectedValue);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void btnPreRegTotal_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnPreRegTotal.Text != "0")
                {
                    url = "~/User/PreReg/IndustryRegistrationUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue+"&Status=TOTAL";
                    Response.Redirect(url);
                }
                else
                {
                    url = "~/User/PreReg/IndustryRegistration.aspx";
                    Response.Redirect(url);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnPreRegApproved_Click(object sender, EventArgs e)
        {
            try
            {
                url = "~/User/PreReg/IndustryRegistrationUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue + "&Status=APPROVED";
                Response.Redirect(url);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnPreRegUnderProcess_Click(object sender, EventArgs e)
        {
            try
            {
                url = "~/User/PreReg/IndustryRegistrationUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue + "&Status=UNDERPROCESS";
                Response.Redirect(url);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnPreRegRejected_Click(object sender, EventArgs e)
        {
            try
            {
                url = "~/User/PreReg/IndustryRegistrationUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue + "&Status=REJECTED";
                Response.Redirect(url);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnPreRegQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnPreRegQuery.Text != "0")
                {
                    url = "~/User/PreReg/IndustryRegistrationUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue + "&Status=QUERY";
                    Response.Redirect(url);
                }
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
                url = "~/User/CFE/CFEUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue;
                Response.Redirect(url);
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
                url = "~/User/CFE/CFEUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue;
                Response.Redirect(url);
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
                url = "~/User/CFE/CFEUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue;
                Response.Redirect(url);
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
                url = "~/User/CFE/CFEUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue;
                Response.Redirect(url);
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
                url = "~/User/CFE/CFEUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue;
                Response.Redirect(url);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }


        protected void btnCFOTotal_Click(object sender, EventArgs e)
        {
            try
            {
                url = "~/User/CFO/CFOUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue;
                Response.Redirect(url);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnCFOApproved_Click(object sender, EventArgs e)
        {
            try
            {
                url = "~/User/CFO/CFOUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue;
                Response.Redirect(url);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnCFOUnderProcess_Click(object sender, EventArgs e)
        {
            try
            {
                url = "~/User/CFO/CFOUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue;
                Response.Redirect(url);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnCFORejected_Click(object sender, EventArgs e)
        {
            try
            {
                url = "~/User/CFO/CFOUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue;
                Response.Redirect(url);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnCFOQuery_Click(object sender, EventArgs e)
        {
            try
            {
                url = "~/User/CFO/CFOUserDashboard.aspx?UnitID=" + ddlUnitNames.SelectedValue;
                Response.Redirect(url);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
                //throw ex;
            }
        }
    }
}