using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
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
    public partial class SearchUser : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL indstregBAL = new PreRegBAL();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave3_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet ds = new DataSet();
                ds = mstrBAL.UserSearch(ddlInput.SelectedValue, txtInput.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GVSearch.DataSource = ds.Tables[0];
                    GVSearch.DataBind();
                    trusercomments.Visible = true;
                }
                else
                {
                    GVSearch.DataSource = null;
                    GVSearch.DataBind();
                    trusercomments.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void BTNcLEAR_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("SearchUser.aspx");
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
                Response.Redirect("~/Dept/Dashboard/DeptDashboard.aspx");
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
    }
}