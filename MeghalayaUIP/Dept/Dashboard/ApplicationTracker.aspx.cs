using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Dashboard
{
    public partial class ApplicationTracker : System.Web.UI.Page
    {
        MGCommonBAL objcomBal = new MGCommonBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrids();
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        public void BindGrids()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcomBal.GetApplicationTracker(ddlApplication.SelectedValue, txtName.Text, txtuid.Text);
                if (string.IsNullOrEmpty(ddlApplication.SelectedValue) || string.IsNullOrEmpty(txtName.Text))
                {
                    lblmsg0.Text = "Please Enter Application Type And Unit Name ...!";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                    Failure.Visible = true;
                    success.Visible = false;
                }

                if (ddlApplication.SelectedValue.ToString() == "IR")
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GVIndustry.Visible = true;
                        GVIndustry.DataSource = ds.Tables[0];
                        GVIndustry.DataBind();
                        GVLnad.Visible = false;
                        GVLnad.DataSource = null;
                        GVLnad.DataBind();
                        GVCFE.Visible = false;
                        GVCFE.DataSource = null;
                        GVCFE.DataBind();
                        GVCFO.Visible = false;
                        GVCFO.DataSource = null;
                        GVCFO.DataBind();
                        GVREN.Visible = false;
                        GVREN.DataSource = null;
                        GVREN.DataBind();

                    }
                    else
                    {
                        lblmsg.Text = "NO RECORD TO DISPLAY";
                        GVIndustry.DataSource = null;
                        GVIndustry.DataBind();
                    }
                }
                else if (ddlApplication.SelectedValue.ToString() == "LA")
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GVIndustry.Visible = false;
                        GVIndustry.DataSource = null;
                        GVIndustry.DataBind();
                        GVLnad.Visible = true;
                        GVLnad.DataSource = ds.Tables[0];
                        GVLnad.DataBind();
                        GVCFE.Visible = false;
                        GVCFE.DataSource = null;
                        GVCFE.DataBind();
                        GVCFO.Visible = false;
                        GVCFO.DataSource = null;
                        GVCFO.DataBind();
                        GVREN.Visible = false;
                        GVREN.DataSource = null;
                        GVREN.DataBind();

                    }
                    else
                    {
                        lblmsg.Text = "NO RECORD TO DISPLAY";
                        GVIndustry.DataSource = null;
                        GVIndustry.DataBind();
                    }
                }
                else if (ddlApplication.SelectedValue.ToString() == "CFE")
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GVIndustry.Visible = false;
                        GVIndustry.DataSource = null;
                        GVIndustry.DataBind();
                        GVLnad.Visible = false;
                        GVLnad.DataSource = null;
                        GVLnad.DataBind();
                        GVCFE.Visible = true;
                        GVCFE.DataSource = ds.Tables[0];
                        GVCFE.DataBind();
                        GVCFO.Visible = false;
                        GVCFO.DataSource = null;
                        GVCFO.DataBind();
                        GVREN.Visible = false;
                        GVREN.DataSource = null;
                        GVREN.DataBind();

                    }
                    else
                    {
                        lblmsg.Text = "NO RECORD TO DISPLAY";
                        GVIndustry.DataSource = null;
                        GVIndustry.DataBind();
                    }
                }
                else if (ddlApplication.SelectedValue.ToString() == "CFO")
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GVIndustry.Visible = false;
                        GVIndustry.DataSource = null;
                        GVIndustry.DataBind();
                        GVLnad.Visible = false;
                        GVLnad.DataSource = null;
                        GVLnad.DataBind();
                        GVCFE.Visible = false;
                        GVCFE.DataSource = null;
                        GVCFE.DataBind();
                        GVCFO.Visible = true;
                        GVCFO.DataSource = ds.Tables[0];
                        GVCFO.DataBind();
                        GVREN.Visible = false;
                        GVREN.DataSource = null;
                        GVREN.DataBind();

                    }
                    else
                    {
                        lblmsg.Text = "NO RECORD TO DISPLAY";
                        GVIndustry.DataSource = null;
                        GVIndustry.DataBind();
                    }
                }
                else if (ddlApplication.SelectedValue.ToString() == "REN")
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GVIndustry.Visible = false;
                        GVIndustry.DataSource = null;
                        GVIndustry.DataBind();
                        GVLnad.Visible = false;
                        GVLnad.DataSource = null;
                        GVLnad.DataBind();
                        GVCFE.Visible = false;
                        GVCFE.DataSource = null;
                        GVCFE.DataBind();
                        GVCFO.Visible = false;
                        GVCFO.DataSource = null;
                        GVCFO.DataBind();
                        GVREN.Visible = true;
                        GVREN.DataSource = ds.Tables[0];
                        GVREN.DataBind();

                    }
                    else
                    {
                        lblmsg.Text = "NO RECORD TO DISPLAY";
                        GVIndustry.DataSource = null;
                        GVIndustry.DataBind();
                    }
                }
            }
            catch(Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GVIndustry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton linkIR = (LinkButton)e.Row.FindControl("lnkIndustry");
                    if (linkIR.Text != null)
                    {
                        Label lblUnitId = (Label)e.Row.FindControl("lblUnitId");
                        Label lblInvesterId = (Label)e.Row.FindControl("lblInvesterId");
                        Label lblStageID = (Label)e.Row.FindControl("lblStageID");
                        if (lblUnitId.Text != "" && lblInvesterId.Text != "" && lblStageID.Text != "")
                        {
                            Session["UNITID"] = lblUnitId.Text; Session["INVESTERID"] = lblInvesterId.Text;
                            Session["stage"] = lblStageID.Text;
                        }
                        //string status = "ApplicationTracker";

                        linkIR.PostBackUrl = "~/Dept/PreReg/PreRegApplIMAProcess.aspx?status=ApplicationTracker";

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

        protected void GVLnad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton LNK = (LinkButton)e.Row.FindControl("lnkLand");
                    if (LNK.Text != "0")
                    {
                        LNK.PostBackUrl = "";
                        LNK.Text = "Click Here";
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

        protected void GVCFE_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton LNK = (LinkButton)e.Row.FindControl("lnkCFE");
                    if (LNK.Text != "0")
                    {
                        LNK.PostBackUrl = "";
                        LNK.Text = "Click Here";
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

        protected void GVCFO_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton LNK = (LinkButton)e.Row.FindControl("lnkCFO");
                    if (LNK.Text != "0")
                    {
                        LNK.PostBackUrl = "";
                        LNK.Text = "Click Here";
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

        protected void GVREN_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton LNK = (LinkButton)e.Row.FindControl("lnkRenewal");
                    if (LNK.Text != "0")
                    {
                        LNK.PostBackUrl = "";
                        LNK.Text = "Click Here";
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
            try
            {
                Response.Redirect("~/Dept/Dashboard/DeptDashboard.aspx");
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