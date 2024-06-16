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
using System.Diagnostics;
using MeghalayaUIP.CommonClass;

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegApplIMADashBoard : System.Web.UI.Page
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
                prd.UserID = ObjUserInfo.UserID;
                prd.UserName = ObjUserInfo.UserName;
                prd.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                {
                    prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                }

                dt = PreBAL.GetPreRegDashBoard(prd);


                //--------------------Commented for new dept flow-----------------------------------//
                //lblIMATotal.Text = dt.Rows[0]["IMATOTAL"].ToString();
                //lblIMATOBEPROCESSED.Text = dt.Rows[0]["IMATOBEPROCESSED"].ToString();
                ////lblIMAPROCESSED.Text = dt.Rows[0]["IMAPROCESSED"].ToString();
                //lblIMAPPROVED.Text = dt.Rows[0]["IMAPPROVED"].ToString();
                //lblIMAQUERY.Text = dt.Rows[0]["IMAQUERY"].ToString();
                //lblIMAQUERYREPLIED.Text = dt.Rows[0]["IMAQUERYREPLIED"].ToString(); 
                //--------------------Commented for new dept flow-----------------------------------//



                lblTotalApp.Text = dt.Rows[0]["TOTAL"].ToString();
                lblIMATOBEPROCESSED.Text = dt.Rows[0]["TOBEPROCESSED"].ToString();
                lblIMAPPROVED.Text = dt.Rows[0]["APPROVED"].ToString();
                lblQueryRaised.Text= dt.Rows[0]["IMAQUERYRAISED"].ToString();
                lblQueryResponded.Text = dt.Rows[0]["IMAQUERYREPLIED"].ToString();
                lblIMATOAPPLICANTTQUERY.Text = dt.Rows[0]["IMAQUERYTOAPPLCNT"].ToString();
                lblIMAQUERYREPLIEDBYAPPLICANT.Text = dt.Rows[0]["APPLCNTREPLIEDTOIMA"].ToString();
                lblIMATODEPTQUERY.Text = dt.Rows[0]["IMATODEPTQUERY"].ToString();
                lblIMAQUERYREPLIEDBYDEPT.Text = dt.Rows[0]["DEPTREPLIEDTOIMA"].ToString();



                lblCommitteeQuery.Text = dt.Rows[0]["COMMQUERYTOIMA"].ToString();
                lblIMARepltoCommittee.Text = dt.Rows[0]["IMAREPLIEDTOCOMM"].ToString();
                lblComquryfwdtoapplcnt.Text = dt.Rows[0]["IMAFWDCOMMQRYTOAPPLCNT"].ToString();
                lblComquryrepliedbyapplcnt.Text = dt.Rows[0]["APPLCNTREPLIEDTOCOMMQRY"].ToString();
                lblComquryfwdtoDept.Text = dt.Rows[0]["IMAFWDCOMMQRYTODEPT"].ToString();
                lblDeptrepliedtoCommittee.Text = dt.Rows[0]["DEPTREPLIEDTOCOMMQRY"].ToString();
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
                    Response.Redirect("PreRegApplIMAView.aspx?status=IMATOTAL");
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
                    Response.Redirect("PreRegApplIMAView.aspx?status=IMATOBEPROCESSED");
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
                    Response.Redirect("PreRegApplIMAView.aspx?status=IMAPPROVED");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }

        }

        protected void linkQuerytoDept_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblIMATODEPTQUERY.Text != "0")
                    Response.Redirect("PreRegApplIMAView.aspx?status=IMATODEPTQUERY");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }

        }
        protected void linkDeptReplyToIMA_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblIMAQUERYREPLIEDBYDEPT.Text != "0")
                    Response.Redirect("PreRegApplIMAView.aspx?status=DEPTREPLIEDTOIMA");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }
        protected void linkQuerytoApplc_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblIMATOAPPLICANTTQUERY.Text != "0")
                    Response.Redirect("PreRegApplIMAView.aspx?status=IMAQUERYTOAPPLCNT");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }

        }

        protected void linkApplcReplyToIMA_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblIMAQUERYREPLIEDBYAPPLICANT.Text != "0")
                    Response.Redirect("PreRegApplIMAView.aspx?status=APPLCNTREPLIEDTOIMA");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }


        protected void linkCommQrytoIMA_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCommitteeQuery.Text != "0")
                    Response.Redirect("PreRegApplIMAView.aspx?status=COMMQUERYTOIMA");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }
        protected void linkIMAReplyToComm_Click(object sender, EventArgs e)
        {

            try
            {
                if (lblIMARepltoCommittee.Text != "0")
                    Response.Redirect("PreRegApplIMAView.aspx?status=IMAREPLIEDTOCOMM");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }

        protected void linkComQryToAppl_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblComquryfwdtoapplcnt.Text != "0")
                    Response.Redirect("PreRegApplIMAView.aspx?status=IMAFWDCOMMQRYTOAPPLCNT");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }
        protected void linkApplcReplyToComm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblComquryrepliedbyapplcnt.Text != "0")
                    Response.Redirect("PreRegApplIMAView.aspx?status=APPLCNTREPLIEDTOCOMMQRY");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }
        protected void linkComQryToDept_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblComquryfwdtoDept.Text != "0")
                    Response.Redirect("PreRegApplIMAView.aspx?status=IMAFWDCOMMQRYTODEPT");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }

        protected void linkDeptReplyToComm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblDeptrepliedtoCommittee.Text != "0")
                    Response.Redirect("PreRegApplIMAView.aspx?status=DEPTREPLIEDTOCOMMQRY");
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