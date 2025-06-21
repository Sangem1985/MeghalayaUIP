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
    }
}