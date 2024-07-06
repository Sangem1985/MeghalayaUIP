using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOQueryDashBoard : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
        string Unitid;
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();
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
                        Unitid = Convert.ToString(Request.QueryString["UnitID"]);

                        if (!IsPostBack)
                        {
                            if (Request.QueryString["UnitID"] != null && Request.QueryString["UnitID"] != "0")
                            {
                                BindData(Request.QueryString["UnitID"].ToString());
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
                throw ex;
            }

        }
        protected void gvQuery_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Unitid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CFOQ_CFOUNITID"));
                LinkButton lb = ((LinkButton)e.Row.FindControl("lnkQueryCount"));
                Label qryid = ((Label)e.Row.FindControl("lblQueryID"));
                string QUERYRESPONSEBY = e.Row.Cells[2].Text.ToString();
                lb.PostBackUrl = "~/User/CFO/CFOQueryResponse.aspx?CFOUNITID=" + Unitid + "&Queryid=" + qryid.Text;
            }
        }
        public void BindData(string Unitid)
        {
            try
            {

                DataSet ds = new DataSet();
                ds = objcfobal.GetCFOQueryDashBoard(Unitid, "");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvQuery.DataSource = ds;
                    gvQuery.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}