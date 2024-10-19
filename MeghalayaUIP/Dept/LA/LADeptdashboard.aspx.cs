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
                    lblQueryRaised.Text = dt.Rows[0]["LANDQUERYRAISED"].ToString();
                    //lblQueryResponded.Text = dt.Rows[0]["IMAQUERYREPLIED"].ToString();
                    //lblIMATOAPPLICANTTQUERY.Text = dt.Rows[0]["IMAQUERYTOAPPLCNT"].ToString();
                    //lblIMAQUERYREPLIEDBYAPPLICANT.Text = dt.Rows[0]["APPLCNTREPLIEDTOIMA"].ToString();
                    //lblIMATODEPTQUERY.Text = dt.Rows[0]["IMATODEPTQUERY"].ToString();
                    //lblIMAQUERYREPLIEDBYDEPT.Text = dt.Rows[0]["DEPTREPLIEDTOIMA"].ToString();



                    //lblCommitteeQuery.Text = dt.Rows[0]["COMMQUERYTOIMA"].ToString();
                    //lblIMARepltoCommittee.Text = dt.Rows[0]["IMAREPLIEDTOCOMM"].ToString();
                    //lblComquryfwdtoapplcnt.Text = dt.Rows[0]["IMAFWDCOMMQRYTOAPPLCNT"].ToString();
                    //lblComquryrepliedbyapplcnt.Text = dt.Rows[0]["APPLCNTREPLIEDTOCOMMQRY"].ToString();
                    //lblComquryfwdtoDept.Text = dt.Rows[0]["IMAFWDCOMMQRYTODEPT"].ToString();
                    //lblDeptrepliedtoCommittee.Text = dt.Rows[0]["DEPTREPLIEDTOCOMMQRY"].ToString();
                }
                else
                {
                    lblTotalApp.Text = "0";
                    lblIMATOBEPROCESSED.Text = "0";
                    lblIMAPPROVED.Text = "0";
                    lblQueryRaised.Text = "0";
                }
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
                    Response.Redirect("LAApplView.aspx?status=LANDAPPROVED");
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
    }
}