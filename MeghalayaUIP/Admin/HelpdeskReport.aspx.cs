﻿using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Admin
{
    public partial class HelpdeskReport : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        MGCommonBAL objcommon = new MGCommonBAL();
        int NumberTotal;        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFormDate.Text = "14-08-2024";
                txtToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                FillGrid();
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
        public void FillGrid()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objcommon.GETHelpDeskReport(txtFormDate.Text, txtToDate.Text);

                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();

                    grdDetails2.DataSource = ds.Tables[1];
                    grdDetails2.DataBind();

                    //grdDetails1.DataSource = ds.Tables[2];
                    //grdDetails1.DataBind();
                }
                else
                {
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();

                    grdDetails2.DataSource = null;
                    grdDetails2.DataBind();
                }

            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int NumberTotal1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SCOUNT"));
                NumberTotal = NumberTotal1 + NumberTotal;

                Label lblUIDNo = (Label)e.Row.FindControl("lbluid");
                LinkButton lblPending = (LinkButton)e.Row.FindControl("lblPending");

              //  UID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "HD_UIDNO"));

                Label lblHelpDesk = (Label)e.Row.FindControl("lblHelpDesk");

                //  string HelpDesk = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "HD_HELPDESKTYPE")).Trim();

                //LinkButton helpdesk = (LinkButton)e.Row.Cells[2].Controls[0];
                if (lblPending.Text !="0")
                {
                    lblPending.PostBackUrl = "HelpdeskDrilldown.aspx?HDType=" + lblHelpDesk.Text + "&Status=1&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                // e.Row.Cells[1].Text = "Grand Total";
                Label lblHelpDesk = (Label)e.Row.FindControl("lblHelpDesk");

                e.Row.Cells[1].Text = "Grand Total";
                e.Row.Cells[2].Text = NumberTotal.ToString();
                LinkButton Total = new LinkButton();
                //UID = "%";

                if (Total.Text != "0")
                {
                    Total.PostBackUrl = "HelpdeskDrilldown.aspx?HDType=" + lblHelpDesk + "&Status=1&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text;
                    e.Row.Cells[2].Controls.Add(Total);
                }
                Total.ForeColor = System.Drawing.Color.White;

            }
        }
    }
}