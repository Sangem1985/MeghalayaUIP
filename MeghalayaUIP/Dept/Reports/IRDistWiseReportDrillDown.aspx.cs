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
    public partial class IRDistWiseReportDrillDown : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        ReportBAL Objreport = new ReportBAL();
        string Distid, FromDate, ToDate, ViewType, DIstrictname;

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
                        BindDistrictWiseReport();
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
        protected void BindDistrictWiseReport()
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {
                    Distid = Convert.ToString(Request.QueryString[0]);
                    FromDate = Convert.ToString(Request.QueryString[1]);
                    ToDate = Convert.ToString(Request.QueryString[2]);
                    ViewType = Convert.ToString(Request.QueryString[3]);
                    DIstrictname = Convert.ToString(Request.QueryString[4]);

                    DataSet ds = new DataSet();

                    ds = Objreport.DistrictReport(Distid, FromDate, ToDate, ViewType);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        GVDistWise.DataSource = ds.Tables[0];
                        GVDistWise.DataBind();
                        lblStatus.Visible = true;
                        lblStatus.InnerText = DIstrictname + " " + " " + "&" + " " + " " + FromDate + " " + " " + "In" + " " + " " + ToDate;
                        if (DIstrictname == "%")
                        {
                            lblStatus.InnerText = "All Districts";
                        }
                    }
                    else
                    {
                        GVDistWise.DataSource = null;
                        GVDistWise.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Reports/IRDistWiseReport.aspx");
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