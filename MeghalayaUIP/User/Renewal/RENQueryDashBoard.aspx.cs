using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Renewal
{
    public partial class RENQueryDashBoard : System.Web.UI.Page
    {
        RenewalBAL objrenbal = new RenewalBAL();
        string RENQID;
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

                    if (Request.QueryString.Count > 0)
                    {
                        RENQID = Convert.ToString(Request.QueryString["RENQID"]);

                        if (!IsPostBack)
                        {
                            if (Request.QueryString["RENQID"] != null && Request.QueryString["RENQID"] != "0")
                            {
                                BindData(Request.QueryString["RENQID"].ToString());
                            }
                            //BindData(Unitid);

                        }
                    }
                    else
                    {
                        Response.Redirect("~/User/Dashboard/Dashboardstatus.aspx");
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
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void gvQuery_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RENQID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RENID_RENQDID"));
                LinkButton lb = ((LinkButton)e.Row.FindControl("lnkQueryCount"));
                Label qryid = ((Label)e.Row.FindControl("lblQueryID"));
                string QUERYRESPONSEBY = e.Row.Cells[2].Text.ToString();
                lb.PostBackUrl = "~/User/Renewal/RENQueryResponse.aspx?RENID_RENQDID=" + RENQID + "&Queryid=" + qryid.Text;
            }
        }
        public void BindData(string RENQID)
        {
            try
            {

                DataSet ds = new DataSet();
                ds = objrenbal.GetRENQueryDashBoard(RENQID, "");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvQuery.DataSource = ds;
                    gvQuery.DataBind();
                }

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