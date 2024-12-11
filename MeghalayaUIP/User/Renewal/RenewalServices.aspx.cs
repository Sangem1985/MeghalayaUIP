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
using System.Xml.Linq;

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
                string UnitId = Session["RENUNITID"].ToString();
                dsnew = objRenbal.GetRenApprovals(UserId,UnitId);
                if (dsnew !=null && dsnew.Tables.Count > 0)
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

                foreach (GridViewRow row in gvRenewals.Rows)
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

                    RenApplicationDetails ObjApplicationDetails = new RenApplicationDetails();
                    int count = 0;
                    List<RenApprovals> lstRenApprovals = new List<RenApprovals>();
                    foreach (GridViewRow row in gvRenewals.Rows)
                    {
                        //CheckBox chk = row.Cells[1].Controls[1] as CheckBox;
                        CheckBox chkApproval = (CheckBox)row.FindControl("chkApproval");
                        if (chkApproval != null && chkApproval.Checked)
                        {
                            Label lblApprovalId = (Label)row.FindControl("lblApprovalId");
                            Label lblDeptId = (Label)row.FindControl("lblDeptId");
                            Label lblApprovalFee = (Label)row.FindControl("lblApprovalFee");

                            lstRenApprovals.Add(new RenApprovals
                            {
                                RENQDID = Session["RENQID"].ToString(),
                                UnitId = Session["RENUNITID"].ToString(),
                                ApprovalId = lblApprovalId.Text.ToString(),
                                DeptId = lblDeptId.Text.ToString(),
                                ApprovalFee = lblApprovalFee.Text.ToString(),
                                UidNo = "",
                                CreatedBy = hdnUserID.Value,
                                IPAddress = getclientIP()
                            });
                        }
                    }
                    XElement xmlRenApproval = new XElement("xmlRenApproval_xml",
                          from Approval in lstRenApprovals
                          select new XElement("RenApprovalTable",
                          new XElement("RENQDID", Approval.RENQDID),
                          new XElement("UnitId", Approval.UnitId),
                          new XElement("ApprovalId", Approval.ApprovalId),
                          new XElement("DeptId", Approval.DeptId),
                          new XElement("ApprovalFee", Approval.ApprovalFee),
                          new XElement("UidNo", Approval.UidNo),
                          new XElement("CreatedBy", Approval.CreatedBy),
                          new XElement("IPAddress", Approval.IPAddress)
                          ));
                    ObjApplicationDetails.RenApprovalsXml = xmlRenApproval.ToString();
                    ObjApplicationDetails.ApprovalID = ApprovalIds;
                    ObjApplicationDetails.UnitId = Session["RENUNITID"].ToString();
                    ObjApplicationDetails.Questionnariid = Session["RENQID"].ToString();
                    int result = Convert.ToInt32(objRenbal.InsertRenDeptApprovals(ObjApplicationDetails));
                    if (result > 0)
                    {
                        // string newurl = "RENQuestionnaire.aspx?ApprId=" + ApprovalIds;
                        string newurl = "~/User/Renewal/RENDrugsLicenseDetails.aspx?Next=" + "N";
                        Response.Redirect(newurl);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to Apply Renewal Approvals')", true);
                        return;
                    }

                  //  string A;
                  //  if(A != "")
                   // { count = count + 1; }

                    if (gvRenewals.Rows.Count == count)
                    {
                        DataSet dsOffline = new DataSet();

                    }



                }
            }
            catch (Exception ex)
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

        protected void gvRenewals_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
      

    }
}