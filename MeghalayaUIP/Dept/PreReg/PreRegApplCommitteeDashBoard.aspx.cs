using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegApplCommitteeDashBoard : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["DeptUserInfo"] != null)
                {

                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    hdnUserID.Value = ObjUserInfo.UserID;

                    if (IsPostBack == false)
                    {
                        prd.UserID = ObjUserInfo.UserID;
                        prd.UserName = ObjUserInfo.UserName;
                        prd.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                        if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                        {
                            prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                        }
                        dt = PreBAL.GetPreRegDashBoard(prd);

                        lblTotalApp.Text = dt.Rows[0]["TOTAL"].ToString();
                        lblToBeProcessed.Text = dt.Rows[0]["TOBEPROCESSED"].ToString();
                        //lblprocessed.Text = dt.Rows[0]["PROCESSED"].ToString();
                        lblApproved.Text = dt.Rows[0]["APPROVED"].ToString();
                        lblRejected.Text = dt.Rows[0]["REJECTED"].ToString();
                        lblQuery.Text = dt.Rows[0]["COMMQUERYTOIMA"].ToString();
                        lblQueryReplied.Text = dt.Rows[0]["IMAREPLIEDTOCOMM"].ToString();
                        //lblQueryNotRepld.Text = dt.Rows[0]["COMMQUERYREPLIED"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void linkTotal_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblTotalApp.Text != "0")
                    Response.Redirect("PreRegApplCommitteeView.aspx?status=COMMTOTAL");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }

        protected void linktobeProc_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblToBeProcessed.Text != "0")
                    Response.Redirect("PreRegApplCommitteeView.aspx?status=COMMTOBEPROCESSED");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }

        }

        protected void linkApproved_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblApproved.Text != "0")
                    Response.Redirect("PreRegApplCommitteeView.aspx?status=COMMAPPROVED");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }

        }
        protected void linkRejected_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblRejected.Text != "0")
                    Response.Redirect("PreRegApplCommitteeView.aspx?status=COMMREJECTED");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }

        }

        protected void linkQueryRaised_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblQuery.Text != "0")
                    Response.Redirect("PreRegApplCommitteeView.aspx?status=COMMQUERY");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }

        protected void linkQueryReplied_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblQueryReplied.Text != "0")
                    Response.Redirect("PreRegApplCommitteeView.aspx?status=COMMQUERYREPLIED");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }

        }
    }
}