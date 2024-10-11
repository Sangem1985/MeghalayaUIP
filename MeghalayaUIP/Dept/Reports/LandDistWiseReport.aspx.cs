using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.ReportBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Reports
{
    public partial class LandDistWiseReport : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        MasterBAL mstrBAL = new MasterBAL();
        ReportBAL reportsBAL = new ReportBAL();
        int TotalAppl, ImaPending, ImaQuery, CommPending, CommApproved, CommRejected, CommQuery;

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
                        BindDistricts();

                        btnsubmit_Click(sender, e);
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

        protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void BindDistricts()
        {
            try
            {

                ddldistrict.Items.Clear();
                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                strmode = "";
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddldistrict.DataSource = objDistrictModel;
                    ddldistrict.DataValueField = "DistrictId";
                    ddldistrict.DataTextField = "DistrictName";
                    ddldistrict.DataBind();

                }
                else
                {
                    ddldistrict.DataSource = null;
                    ddldistrict.DataBind();


                }
                AddSelect(ddldistrict);


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = "--ALL--";
                li.Value = "%";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void FillGridData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = reportsBAL.LandDistrictWiseReports(ddldistrict.SelectedValue, txtFormDate.Text, txtToDate.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GVLADistrictWise.DataSource = ds.Tables[0];
                    GVLADistrictWise.DataBind();

                }
                else
                {
                    GVLADistrictWise.DataSource = null;
                    GVLADistrictWise.DataBind();

                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                FillGridData();
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GVLADistrictWise_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int Application = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTALAPPL"));
                TotalAppl = Application + TotalAppl;

                int Pending = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IMAPENDING"));
                ImaPending = Pending + ImaPending;

                int Query = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IMAQUERYRAISED"));
                ImaQuery = Query + ImaQuery;

                int CommPendings = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COMMPENDING"));
                CommPending = CommPendings + CommPending;

                int Approved = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COMMAPPROVED"));
                CommApproved = Approved + CommApproved;

                int Rejected = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COMMREJECTED"));
                CommRejected = Rejected + CommRejected;

                int CommonQuery = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COMMQUERY"));
                CommQuery = CommonQuery + CommQuery;



                Label lblDist = (Label)e.Row.FindControl("lblDistrictid");
                LinkButton lnkTotal = (LinkButton)e.Row.FindControl("lblTotal");
                LinkButton lnkPending = (LinkButton)e.Row.FindControl("lblPending");
                LinkButton lnkQuery = (LinkButton)e.Row.FindControl("lblQueryRaised");
                LinkButton lnkcommpending = (LinkButton)e.Row.FindControl("lblCommPending");
                LinkButton lnkApproved = (LinkButton)e.Row.FindControl("lblCommApproved");
                LinkButton lnkRejected = (LinkButton)e.Row.FindControl("lblCommRejected");
                LinkButton lnkCommQuery = (LinkButton)e.Row.FindControl("lblCommQuery");

                // string districtname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTNAME")).Trim();

                if (lnkTotal.Text != "0")
                    lnkTotal.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=TOTAL" + "&District=" + ddldistrict.SelectedItem.Text;

                if (lnkPending.Text != "0")
                    lnkPending.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=Pending" + "&District=" + ddldistrict.SelectedItem.Text;

                if (lnkQuery.Text != "0")
                    lnkQuery.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=Query" + "&District=" + ddldistrict.SelectedItem.Text;

                if (lnkcommpending.Text != "0")
                    lnkcommpending.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=commpending" + "&District=" + ddldistrict.SelectedItem.Text;

                if (lnkApproved.Text != "0")
                    lnkApproved.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=Approved" + "&District=" + ddldistrict.SelectedItem.Text;

                if (lnkRejected.Text != "0")
                    lnkRejected.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=Rejected" + "&District=" + ddldistrict.SelectedItem.Text;

                if (lnkCommQuery.Text != "0")
                    lnkCommQuery.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=CommQuery" + "&District=" + ddldistrict.SelectedItem.Text;

                lnkTotal.ForeColor = System.Drawing.Color.Black;
                lnkPending.ForeColor = System.Drawing.Color.Black;
                lnkQuery.ForeColor = System.Drawing.Color.Black;
                lnkcommpending.ForeColor = System.Drawing.Color.Black;
                lnkApproved.ForeColor = System.Drawing.Color.Black;
                lnkRejected.ForeColor = System.Drawing.Color.Black;
                lnkCommQuery.ForeColor = System.Drawing.Color.Black;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                string districtname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTNAME")).Trim();
                string Districtid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICID")).Trim();

                if (ddldistrict.SelectedItem.Text == "" || ddldistrict.SelectedItem.Text == null || ddldistrict.SelectedItem.Text == "--ALL--" || ddldistrict.SelectedValue == "0")
                {
                    districtname = "%";
                    Districtid = "%";
                }
                else
                {
                    districtname = ddldistrict.SelectedItem.Text;
                    Districtid = ddldistrict.SelectedValue;
                }

                e.Row.Font.Bold = true;
                e.Row.Cells[2].Text = "Total";

                LinkButton Total = new LinkButton();
                Total.ForeColor = System.Drawing.Color.Blue;
                if (Total.Text != "0")
                {
                    Total.PostBackUrl = ".aspx?Distid=" + Districtid + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=TOTAL" + "&District=" + districtname;
                }
                Total.Text = TotalAppl.ToString();
                e.Row.Cells[3].Text = TotalAppl.ToString();
                e.Row.Cells[3].Controls.Add(Total);

                e.Row.Cells[4].Text = ImaPending.ToString();
                e.Row.Cells[5].Text = ImaQuery.ToString();
                e.Row.Cells[6].Text = CommPending.ToString();
                e.Row.Cells[7].Text = CommApproved.ToString();
                e.Row.Cells[8].Text = CommRejected.ToString();
                e.Row.Cells[9].Text = CommQuery.ToString();
            }
        }
    }
}