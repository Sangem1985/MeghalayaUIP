﻿using MeghalayaUIP.BAL.LABAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.LA
{
    public partial class LAUserDashBoard : System.Web.UI.Page
    {
        LABAL Objland = new LABAL();
        string UnitID;
        int Tostatus, TotQueryRaised;
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

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindApproved();
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
                //throw ex;
            }
        }
        public void BindApproved()
        {
            try
            {
                DataSet dsApproved = new DataSet();
                if (Request.QueryString.Count > 0)
                {
                    UnitID = Request.QueryString[0];
                }
                else UnitID = "%";
                dsApproved = Objland.GetLandUserDashboard(hdnUserID.Value);
                if (dsApproved.Tables.Count > 0)
                {
                    if (dsApproved.Tables[0].Rows.Count > 0)
                    {
                        gvPreRegApproved.DataSource = dsApproved.Tables[0];
                        gvPreRegApproved.DataBind();
                    }
                    else
                    {
                        lblmsg0.Text = "Approval for Registration Under MIIPP is under Process ";
                        Failure.Visible = true;
                        gvPreRegApproved.DataSource = null;
                        gvPreRegApproved.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                //throw ex;
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString.Count > 0)
                    UnitID = Request.QueryString[0];
                else
                    UnitID = "%";
                Response.Redirect("~/User/Dashboard/.aspx?UnitID=" + UnitID);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnApplyLand_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblunitId = (Label)row.FindControl("lblUNITID");
                Label lblcfeqid = (Label)row.FindControl("lblCFEQID");
                Session["ISD_UNITID"] = lblunitId.Text;
                Session["ISD_QDID"] = lblcfeqid.Text;
                string newurl = "~/User/Prereg/INDLANDINDUSTRIALSHED.aspx";
                Response.Redirect(newurl);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            Label lblunitId = (Label)row.FindControl("lblUNITID");
            Label lblcfeqid = (Label)row.FindControl("lblCFEQID");
            Session["ISD_UNITID"] = lblunitId.Text;
            Session["ISD_QDID"] = lblcfeqid.Text;
            string newurl = "INDLANDINDUSTRIALSHED.aspx";
            Response.Redirect(newurl);
        }

        protected void gvPreRegApproved_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridView HeaderGrid = (GridView)sender;
                    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                    TableHeaderCell HeaderCell = new TableHeaderCell();
                    HeaderCell.ColumnSpan = 5;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Text = "";
                    HeaderCell.Font.Bold = true;
                    HeaderGridRow.Cells.Add(HeaderCell);


                    HeaderCell = new TableHeaderCell();
                    HeaderCell.ColumnSpan = 5;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.Font.Bold = true;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Text = "Land Approvals";
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableHeaderCell();
                    HeaderCell.ColumnSpan = 3;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.Font.Bold = true;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Text = "";
                    HeaderGridRow.Cells.Add(HeaderCell);

                    gvPreRegApproved.Controls[0].Controls.AddAt(0, HeaderGridRow);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvPreRegApproved_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int gvrcnt = gvPreRegApproved.Rows.Count;
                    Button btnApply;
                    Button btnApprvlsReq;
                    //  Button btnApplstatus;
                    Label lblCFEQuesnrID = (Label)e.Row.FindControl("lblCFEQID");
                    Label lblunitId = (Label)e.Row.FindControl("lblUNITID");
                    Label APPLSTATUS = (Label)e.Row.FindControl("lblCFEAPPLSTATUS");

                    HyperLink hplStatus = (HyperLink)e.Row.FindControl("hplStatus");
                    HyperLink hplQryRaised = (HyperLink)e.Row.FindControl("hplQueryRaised");

                    if (hplQryRaised.Text != "0")
                        hplQryRaised.NavigateUrl = "~/User/Dashboard/.aspx?UnitID=" + lblunitId.Text + "&Type=QueryRaised";

                    if (hplQryRaised.Text != "0")
                        hplQryRaised.NavigateUrl = "~/User/Dashboard/.aspx?UnitID=" + lblunitId.Text + "&Type=QueryRaised";

                    int TotalStatus = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "STATUS"));
                    Tostatus = Tostatus + TotalStatus;

                    int TotalQuery = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QUERYCOUNT"));
                    TotQueryRaised = TotQueryRaised + TotalQuery;
                    string Applstatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "STATUS"));


                    if (Applstatus == "" || Applstatus == null || Applstatus == "3")
                    {
                        btnApply = (Button)e.Row.FindControl("btnApplyLand");
                        btnApprvlsReq = (Button)e.Row.FindControl("btnCombndAppl");
                        //btnApplstatus = (Button)e.Row.FindControl("lblCFEAPPLSTATUS");
                        btnApply.Enabled = true;
                        btnApprvlsReq.Enabled = false; //btnApprvlsReq.BackColor = System.Drawing.Color.LightGray; // btnApprvlsReq.ForeColor = System.Drawing.Color.Red;
                                                       // btnApplstatus.Enabled = false; //btnApplstatus.BackColor = System.Drawing.Color.LightGray; //btnApplstatus.ForeColor = System.Drawing.Color.Red;
                                                       //  btnApplstatus.Style.Add("border", "none");
                                                       //  btnApplstatus.Style.Add("color", "black");
                    }
                    else
                    {
                        btnApply = (Button)e.Row.FindControl("btnApplyLand");
                        btnApply.Enabled = false;
                        btnApply.BackColor = System.Drawing.Color.LightGray;// btnApply.ForeColor = System.Drawing.Color.Red;
                        btnApply.Style.Add("border", "none");
                        btnApply.Style.Add("color", "black");
                    }
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[6].Text = "Total";
                    e.Row.Cells[7].Text = Tostatus.ToString();
                    e.Row.Cells[8].Text = TotQueryRaised.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}