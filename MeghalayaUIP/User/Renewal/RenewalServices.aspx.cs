using MeghalayaUIP.BAL.CommonBAL;
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
    public partial class RenewalServices : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
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
                    
                    if (!IsPostBack)
                    {
                        Binddata();
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet dsnew = new DataSet();
                string UserId = "1";
                dsnew = objRenbal.GetRenApprovals(UserId);
                if (dsnew.Tables.Count > 0)
                {
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {
                        gvRenewals.DataSource = dsnew.Tables[0];
                        gvRenewals.DataBind();
                    }
                }
                else
                {
                    gvRenewals.DataSource = null;
                    gvRenewals.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                string ApprovalIds = "";
                foreach (GridViewRow row in gvRenewals.Rows)
                {
                    //CheckBox chk = row.Cells[1].Controls[1] as CheckBox;
                    CheckBox chkApproval = (CheckBox)row.FindControl("chkApproval");
                    if (chkApproval != null && chkApproval.Checked)
                    {
                        Label lblApprovalId = (Label)row.FindControl("lblApprovalId");
                        ApprovalIds = ApprovalIds + "," + lblApprovalId.Text.ToString();
                    }
                }
                if (ApprovalIds == "") 
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select atleast one Approval')", true);
                    return;
                }
                ApprovalIds = ApprovalIds.Trim().TrimStart(',');
                string newurl = "RENQuestionnaire.aspx?ApprId=" + ApprovalIds;
                Response.Redirect(newurl);
            }
            catch (Exception ex)
            {
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void gvRenewals_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

    }
}