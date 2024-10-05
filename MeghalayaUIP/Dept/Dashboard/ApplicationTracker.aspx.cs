using MeghalayaUIP.BAL.CommonBAL;
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
            BindGrids();
        }
        public void BindGrids()
        {
            DataSet ds = new DataSet();
            ds = objcomBal.GetApplicationTracker(ddlApplication.SelectedValue, txtName.Text, txtuid.Text);

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
            if (ddlApplication.SelectedValue.ToString() == "LA")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GVIndustry.Visible = false;
                    GVIndustry.DataSource = ds.Tables[0];
                    GVIndustry.DataBind();
                    GVLnad.Visible = true;
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
            if (ddlApplication.SelectedValue.ToString() == "CFE")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GVIndustry.Visible = false;
                    GVIndustry.DataSource = ds.Tables[0];
                    GVIndustry.DataBind();
                    GVLnad.Visible = false;
                    GVLnad.DataSource = null;
                    GVLnad.DataBind();
                    GVCFE.Visible = true;
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
            if (ddlApplication.SelectedValue.ToString() == "CFO")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GVIndustry.Visible = false;
                    GVIndustry.DataSource = ds.Tables[0];
                    GVIndustry.DataBind();
                    GVLnad.Visible = false;
                    GVLnad.DataSource = null;
                    GVLnad.DataBind();
                    GVCFE.Visible = false;
                    GVCFE.DataSource = null;
                    GVCFE.DataBind();
                    GVCFO.Visible = true;
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
            if (ddlApplication.SelectedValue.ToString() == "    REN")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GVIndustry.Visible = false;
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
                    GVREN.Visible = true;
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
        }

        protected void GVIndustry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton LNK = (LinkButton)e.Row.FindControl("lnkIndustry");
                    if (LNK.Text != "0")
                    {
                        LNK.PostBackUrl = "";
                        LNK.Text = "Click Here";
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        protected void GVLnad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton LNK = (LinkButton)e.Row.FindControl("lnkIndustry");
                    if (LNK.Text != "0")
                    {
                        LNK.PostBackUrl = "";
                        LNK.Text = "Click Here";
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void GVCFE_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton LNK = (LinkButton)e.Row.FindControl("lnkIndustry");
                    if (LNK.Text != "0")
                    {
                        LNK.PostBackUrl = "";
                        LNK.Text = "Click Here";
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GVCFO_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton LNK = (LinkButton)e.Row.FindControl("lnkIndustry");
                    if (LNK.Text != "0")
                    {
                        LNK.PostBackUrl = "";
                        LNK.Text = "Click Here";
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GVREN_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton LNK = (LinkButton)e.Row.FindControl("lnkIndustry");
                    if (LNK.Text != "0")
                    {
                        LNK.PostBackUrl = "";
                        LNK.Text = "Click Here";
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}