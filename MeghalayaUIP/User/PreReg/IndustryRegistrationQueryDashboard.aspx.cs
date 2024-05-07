using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;

namespace MeghalayaUIP.User.PreReg
{
    public partial class IndustryRegistrationQueryDashboard : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL indstregBAL = new PreRegBAL();


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

                    if (!IsPostBack)
                    {
                        if (Request.QueryString["UNITID"].ToString() != null && Request.QueryString["UNITID"].ToString() != "")
                        {
                            BindData(Request.QueryString["UNITID"].ToString(), ObjUserInfo.Userid, null);
                        }
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
        protected void gvAttachmentsQuery_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            String Service_id = "";
            string Investid = "";
            string Deptid = "";
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Service_id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UNITID"));
                Investid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "INVESTERID"));
                Deptid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QUERYRAISEDBYDEPTID"));
                LinkButton lb = ((LinkButton)e.Row.FindControl("lnkQueryCount"));
                Label lbl = ((Label)e.Row.FindControl("lblirqid"));
                string QUERYRESPONSEBY = e.Row.Cells[2].Text.ToString();
                lb.PostBackUrl = "~/User/PreReg/IndustryRegistrationQueryDetails.aspx?UNITID=" + Service_id + "&INVESTERID=" + Investid + "&QUERYRAISEDBYDEPTID=" + Deptid + "&IRQID=" + lbl.Text.ToString() + "";
                // lb.PostBackUrl = "~/User/PreReg/IRQueryReason.aspx?UNITID="+Service_id + lbl.Text + "&IRQID=" + lbl.Text;

            }
        }
        public void BindData(string Unitid, string InvesterID, string Queryid)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = indstregBAL.GetIndustryRegistrationQueryDetails(Unitid,InvesterID,Queryid);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvAttachmentsQuery.DataSource = ds;
                    gvAttachmentsQuery.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
