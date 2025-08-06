using MeghalayaUIP.BAL.CFEBLL;
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

namespace MeghalayaUIP.User.CFE
{
    public partial class CFETrackerDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
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

                    if (!IsPostBack)
                    {
                        string UnitID = "1089"; //Request.QueryString[0].ToString();
                        string Deptid = "10"; //Request.QueryString[1].ToString();
                        string APPROVALID = "29"; //Request.QueryString[2].ToString();
                        string Status = "2"; //Request.QueryString[3].ToString();
                        if (UnitID != "" && Deptid != "" && APPROVALID != "" && Status != "")
                        {
                            BindData(UnitID, Deptid, APPROVALID, Status);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindData(string Unitid, string Deptid, string APPROVALID, string Status)
        {
            try
            {
                DataSet ds = new DataSet();
              //  string Dept = Request.QueryString[0].ToString();
                ds = objcfebal.GetCFETrackerDetails(Unitid, Deptid, APPROVALID, Status);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (Status =="1")
                    {
                        divPayemtDet.Visible = true;
                        lblDeptName.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblPayApproval.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblQueryPaymentDate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblQueryPayment.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblQueryPaymentRespnse.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblDayTaken.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblQueryResponsePay.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    }
                    else if (Status == "2")
                    {
                        divQueryDetails.Visible = true;
                        lblDept.Text = Convert.ToString(ds.Tables[0].Rows[0]["TMD_DEPTNAME"]);
                        lblApprovalName.Text = Convert.ToString(ds.Tables[0].Rows[0]["APPROVALNAME"]);
                        lblQueryDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQ_QUERYDATE"]);
                        lblQuery.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQ_QUERYRAISEDESC"]);
                        lblQueryResponseDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQ_QUERYRESPONSEDATE"]);
                        lblDaysTaken.Text = "7"; //Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblQueryResponse.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQ_QUERYRESPONSEDESC"]);

                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                        {
                            GVQueryDet.DataSource = ds.Tables[1];
                            GVQueryDet.DataBind();
                        }

                    }
                    else if (Status == "3")
                    {
                        divAdditional.Visible = true;

                        lblAddlDept.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblAddlApproval.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblAddlDate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblAddlRemark.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblAddlAppeal.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblAddlAppealDate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblAddlLetter.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);

                    }
                    else if (Status == "4")
                    {
                        divReject.Visible = true;
                        lblDeptNameReject.Text = Convert.ToString(ds.Tables[0].Rows[0]["TMD_DeptName"]);
                        lblRejApprovalName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApprovalName"]);
                        lblRejDate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblRejRemark.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblRejAppealRemark.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblRejAppealDate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblRejQueryReason.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFDA_SCRUTINYREJECTIONREASON"]);
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

        protected void GVQueryDet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HyperLink hplAttachment = (HyperLink)e.Row.FindControl("linkAttachment");
                    Label lblfilepath = (Label)e.Row.FindControl("lblFilePath");

                    if (hplAttachment != null && hplAttachment.Text != "" && lblfilepath != null && lblfilepath.Text != "")
                    {
                        hplAttachment.NavigateUrl = "~/Dept/Dashboard/DeptServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(lblfilepath.Text);
                        hplAttachment.Target = "blank";
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
    }
}