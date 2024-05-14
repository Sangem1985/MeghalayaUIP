using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept
{
    public partial class IntenttoInvestDashboard : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL indstregBAL = new PreRegBAL();
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
                        BindData();
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                throw ex;
            }


        }
        public void BindData()
        {

            try
            {
                DataTable dt = new DataTable();

                dt = indstregBAL.GetIntentInvestDashBoard();
                if (dt.Rows.Count > 0)
                {
                    gvPreRegDtls.DataSource = dt;
                    gvPreRegDtls.DataBind();
                }
                else
                {
                    gvPreRegDtls.DataSource = null;
                    gvPreRegDtls.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            Label lblID = (Label)row.FindControl("lblID");
            if (lblID != null)
            {
                string ID = lblID.Text;
                //Session["ID"] = lblID.Text;
                string newurl = "~/IntenttoInvestPrint.aspx?ID=" + ID;
                Response.Redirect(newurl);
            }


        }

        protected void gvPreRegDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //}
        }
    }
}