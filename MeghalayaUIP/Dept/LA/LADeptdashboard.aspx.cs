using MeghalayaUIP.BAL.LABAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.LA
{
    public partial class LADeptdashboard : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        LABAL Objland = new LABAL();
        LADeptDtls objDtls = new LADeptDtls();
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
                }
                Page.MaintainScrollPositionOnPostBack = true;
                Failure.Visible = false;
                success.Visible = false;
                if (!IsPostBack)
                {
                    Bind();
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }
        protected void Bind()
        {
            try
            {
                objDtls.UserID = ObjUserInfo.UserID;
                objDtls.UserName = ObjUserInfo.UserName;
                objDtls.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                {
                    objDtls.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                }

                dt = Objland.GetLADeptDashBoard(objDtls);

                if (dt.Rows.Count > 0)
                {
                   

                    lblTotalApp.Text = dt.Rows[0]["TOTAL"].ToString();
                    lblIMATOBEPROCESSED.Text = dt.Rows[0]["TOBEPROCESSED"].ToString();
                    lblIMAPPROVED.Text = dt.Rows[0]["APPROVED"].ToString();
                    //lblQueryRaised.Text = dt.Rows[0]["QUERYRAISED"].ToString();
                    lblRejected.Text = dt.Rows[0]["REJECTED"].ToString();
                }
                else
                {
                    lblTotalApp.Text = "0";
                    lblIMATOBEPROCESSED.Text = "0";
                    lblIMAPPROVED.Text = "0";
                    //lblQueryRaised.Text = "0";
                    lblRejected.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }

        }

        

        protected void linkTotal_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblTotalApp.Text != "0")
                    Response.Redirect("LAApplView.aspx?status=TOTAL");
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
                if (lblIMATOBEPROCESSED.Text != "0")
                    Response.Redirect("LAApplView.aspx?status=TOBEPROCESSED");
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
                if (lblIMAPPROVED.Text != "0")
                    Response.Redirect("LAApplView.aspx?status=APPROVED");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }

        //protected void linkQueryRaised_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (lblQueryRaised.Text != "0")
        //            Response.Redirect("LAApplView.aspx?status=QUERYRAISED");
        //    }
        //    catch (Exception ex)
        //    {
        //        Failure.Visible = true;
        //        lblmsg0.Text = ex.Message;
        //        MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

        //    }
        //}

        protected void linkRejected_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblRejected.Text != "0")
                    Response.Redirect("LAApplView.aspx?status=REJECTED");
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