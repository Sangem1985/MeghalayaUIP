using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MeghalayaUIP.User.Services
{
    public partial class OtherServices : System.Web.UI.Page
    {
        SVRCBAL objSrvcbal = new SVRCBAL();
        string UnitID;
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
                    if (Convert.ToString(Session["SRVCUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["SRVCUNITID"]);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet dsnew = new DataSet();
                string UserId = "1";
                string UnitId = Session["SRVCUNITID"].ToString();
                dsnew = objSrvcbal.GetSRVCApprovals(UserId, UnitId);
                if (dsnew != null && dsnew.Tables.Count > 0)
                {
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {
                        GvServices.DataSource = dsnew.Tables[0];
                        GvServices.DataBind();
                    }
                }
                else
                {
                    GvServices.DataSource = null;
                    GvServices.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                string ApprovalIds = "";

                foreach (GridViewRow row in GvServices.Rows)
                {
                    CheckBox chkApproval = (CheckBox)row.FindControl("chkApproval");
                    if (chkApproval != null && chkApproval.Checked)
                    {
                        Label lblApprovalId = (Label)row.FindControl("lblApprovalId");
                        Label lblDeptId = (Label)row.FindControl("lblDeptId");
                        Label lblApprovalFee = (Label)row.FindControl("lblApprovalFee");
                        ApprovalIds = ApprovalIds + "," + lblApprovalId.Text.ToString();
                        ApprovalIds = ApprovalIds.Trim().TrimStart(',');



                    }
                }
                if (ApprovalIds == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select atleast one Approval')", true);
                    return;
                }
                else
                {
                    SRVCOtherServices ObjApplicationDetails = new SRVCOtherServices();
                    int count = 0;
                    List<SRVCApprovals> lstsrvcApprovals = new List<SRVCApprovals>();
                    foreach (GridViewRow row in GvServices.Rows)
                    {
                        CheckBox chkApproval = (CheckBox)row.FindControl("chkApproval");
                        if (chkApproval != null && chkApproval.Checked)
                        {
                            Label lblApprovalId = (Label)row.FindControl("lblApprovalId");
                            Label lblDeptId = (Label)row.FindControl("lblDeptId");
                            Label lblApprovalFee = (Label)row.FindControl("lblApprovalFee");

                            lstsrvcApprovals.Add(new SRVCApprovals
                            {
                                SRVCQDID = Session["SRVCQID"].ToString(),
                                UnitId = Session["SRVCUNITID"].ToString(),
                                ApprovalId = lblApprovalId.Text.ToString(),
                                DeptId = lblDeptId.Text.ToString(),
                                ApprovalFee = lblApprovalFee.Text.ToString(),
                                UidNo = "",
                                CreatedBy = hdnUserID.Value,
                                IPAddress = getclientIP()
                            });
                        }
                    }
                    XElement xmlSRVCApproval = new XElement("xmlSRVCApproval_xml",
                        from Approval in lstsrvcApprovals
                        select new XElement("SRVCApprovalTable",
                        new XElement("SRVCQDID", Approval.SRVCQDID),
                        new XElement("UnitId", Approval.UnitId),
                        new XElement("ApprovalId", Approval.ApprovalId),
                        new XElement("DeptId", Approval.DeptId),
                        new XElement("ApprovalFee", Approval.ApprovalFee),
                        new XElement("UidNo", Approval.UidNo),
                        new XElement("CreatedBy", Approval.CreatedBy),
                        new XElement("IPAddress", Approval.IPAddress)
                        ));
                    ObjApplicationDetails.SRVCApprovalsXml = xmlSRVCApproval.ToString();
                    ObjApplicationDetails.ApprovalID = ApprovalIds;
                    ObjApplicationDetails.UnitId = Session["SRVCUNITID"].ToString();
                    ObjApplicationDetails.Questionnariid = Session["SRVCQID"].ToString();
                   int result = Convert.ToInt32(objSrvcbal.InsertSRVCDeptApprovals(ObjApplicationDetails));
                    if (result > 0)
                    {                        
                        string newurl = "~/User/Services/SWMDetails.aspx?Next=" + "N";
                        Response.Redirect(newurl);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to Apply Other Services Approvals')", true);
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public static string getclientIP()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return result;
        }
    }
}