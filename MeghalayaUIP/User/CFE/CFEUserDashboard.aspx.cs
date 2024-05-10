using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEUserDashboard : System.Web.UI.Page
    {
        CFEBAL objcfebal = new CFEBAL();
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
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                throw ex;
            }

        }
        public void BindApproved()
        {
            DataSet dsApproved = new DataSet();
            dsApproved = objcfebal.GetPREREGandCFEapplications(hdnUserID.Value);
            if (dsApproved.Tables.Count > 0)
            {
                if (dsApproved.Tables[0].Rows.Count > 0)
                {
                    gvPreRegApproved.DataSource = dsApproved.Tables[0];
                    gvPreRegApproved.DataBind();
                }
                else
                {
                    gvPreRegApproved.DataSource = null;
                    gvPreRegApproved.DataBind();
                }
                if (dsApproved.Tables[1].Rows.Count > 0)
                {
                    gvCFEApplied.DataSource = dsApproved.Tables[1];
                    gvCFEApplied.DataBind();
                }
                else
                {
                    gvCFEApplied.DataSource = null;
                    gvCFEApplied.DataBind();
                }

            }
        }

        protected void gvPreRegApproved_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int gvrcnt = gvPreRegApproved.Rows.Count;
                Button btnApply;
                Label lblCFEQuesnrID = (Label)e.Row.FindControl("lblCFEQID");
                for (int i = 0; i <= gvrcnt; i++)
                {
                    if (lblCFEQuesnrID.Text == "" || lblCFEQuesnrID.Text == null)
                    {
                        btnApply = (Button)e.Row.FindControl("btnApplyCFE");
                        btnApply.Enabled = true;
                    }
                    else
                    {
                        btnApply = (Button)e.Row.FindControl("btnApplyCFE");
                        btnApply.Enabled = false;
                        btnApply.BackColor = System.Drawing.Color.LightGray;
                    }
                }
            }

        }
        protected void btnApplyCFE_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            Label lblunitId = (Label)row.FindControl("lblUNITID");
            Session["UNITID"] = lblunitId.Text;
            string newurl = "CFEQuestionnaire.aspx";
            Response.Redirect(newurl);
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            Label lbluniid = (Label)row.FindControl("lblUNITID");
            Label lblQuestId = (Label)row.FindControl("lblCFEQID");
            Session["UNITID"] = lbluniid.Text;
            string newurl = "CFEQuestionnaire.aspx";
            Response.Redirect(newurl);
        }

        protected void btnCombndAppl_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            Label lbluniid = (Label)row.FindControl("lblUNITID");
            Label lblQuestId = (Label)row.FindControl("lblCFEQID");
            Session["UNITID"] = lbluniid.Text;
            string newurl = "CFECommonApplication.aspx";
            Response.Redirect(newurl);
        }

        protected void btnApplStatus_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            Label lbluniid = (Label)row.FindControl("lblUNITID");
            Label lblQuestId = (Label)row.FindControl("lblCFEQID");
            Session["UNITID"] = lbluniid.Text;
            string newurl = "CFEUserApplStatus.aspx";
            Response.Redirect(newurl);
        }
    }
}