using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept
{
    public partial class DeptWiseServices : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        string deptId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["DeptUserInfo"] != null)
                {

                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                        deptId = ObjUserInfo.Deptid;
                    }
                    if (!IsPostBack)
                    {
                        BindDEPTPAGE();
                    }
                }
                else
                { Response.Redirect("~/DeptLogin.aspx"); }
            }
            catch (Exception ex)
            { }
        }
        protected void BindDEPTPAGE()
        {
            try
            {
                string Module = "%";

                DataSet dsInfo = new DataSet();
                dsInfo = mstrBAL.GetInformationWizard(Module, deptId, "%");
                if (dsInfo != null && dsInfo.Tables.Count > 0 && dsInfo.Tables[0].Rows.Count > 0)
                {
                    gvDptpg.DataSource = dsInfo.Tables[0];
                    gvDptpg.DataBind();
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
            catch (Exception ex)
            {

            }
        }

        protected void gvDptpg_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;

                // SOP
                HyperLink hlSOP = (HyperLink)e.Row.FindControl("hplViewSOP");
                string sopPath = Convert.ToString(drv["IW_SOP"]);
                SetDocumentLink(hlSOP, sopPath);

                // Rules and Regulations
                HyperLink hlRules = (HyperLink)e.Row.FindControl("hplRulesandReg");
                string rulesPath = Convert.ToString(drv["IW_RULESANDREGL"]);
                SetDocumentLink(hlRules, rulesPath);

                // Prerequisites
                HyperLink hlPreReq = (HyperLink)e.Row.FindControl("hplPrerequisites");
                string preReqPath = Convert.ToString(drv["IW_PREREQUISITES"]);
                SetDocumentLink(hlPreReq, preReqPath);

                // Application Form Format
                HyperLink hlAppForm = (HyperLink)e.Row.FindControl("hplApplForm");
                string appFormPath = Convert.ToString(drv["IW_APPLFORMAT"]);
                SetDocumentLink(hlAppForm, appFormPath);
            }
        }
        private void SetDocumentLink(HyperLink link, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                link.Text = "Not Available";
                link.NavigateUrl = "";
                link.Style["color"] = "gray";
                link.Enabled = false;
            }
            else
            {
                string cleanPath = path.StartsWith("Dept/") ? path.Substring(5) : path;

                string fullPath = Server.MapPath("~/" + cleanPath);
                if (System.IO.File.Exists(fullPath))
                {
                    link.NavigateUrl = "~/" + cleanPath;
                }
                else
                {
                    link.Text = "Not Available";
                    link.NavigateUrl = "";
                    link.Style["color"] = "gray";
                    link.Enabled = false;
                }
            }
        }

    }
}