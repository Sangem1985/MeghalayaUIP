using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegDITDashBoard : System.Web.UI.Page
    {
        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        DataTable dt = new DataTable();
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
                    Bindata();
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
                {
                    Response.Redirect("PreRegDITView.aspx?status=TOTAL");
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
                if (lblDPRTOBEPROCESSED.Text != "0")
                {
                    Response.Redirect("PreRegDITView.aspx?status=TOBEPROCESSED");
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void linkProcessed_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblDPRPROCESSED.Text != "0")
                {
                    Response.Redirect("PreRegDITView.aspx?status=PROCESSED");
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void Bindata()
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

                //dt = PreBAL.PreRegDPRDashBoard(prd);
                dt = PreBAL.GetPreRegDashBoard(prd);

                lblTotalApp.Text = dt.Rows[0]["TOTAL"].ToString();
                lblDPRTOBEPROCESSED.Text = dt.Rows[0]["TOBEPROCESSED"].ToString();
                lblDPRPROCESSED.Text = dt.Rows[0]["PROCESSED"].ToString();
                lblForwardedDEPTQUERY.Text = dt.Rows[0]["DCSENTBACK"].ToString();
                lblReceivedDEPT.Text = dt.Rows[0]["DCRECEIVED"].ToString();

                //string[] allowedUserIDs = { "1073", "1074", "1075", "1076", "1077", "1078", "1079", "1080", "1081", "1082", "1083", "1084" };
                //if (ObjUserInfo.Roleid == "4" || allowedUserIDs.Contains(ObjUserInfo.UserID))
                //{
                //    Received.Visible = true;
                //    Sent.Visible = true;
                //}
                if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                {
                    ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                }
                if (Convert.ToString(ObjUserInfo.DistrictId) != "")
                {
                    Received.Visible = true;
                    Sent.Visible = true;

                }


            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void linkForQuerytoDept_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblForwardedDEPTQUERY.Text != "0")
                {
                    Response.Redirect("PreRegDITView.aspx?status=DCSENTBACK");
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void linkDeptRecived_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblReceivedDEPT.Text != "0")
                {
                    Response.Redirect("PreRegDITView.aspx?status=DCRECEIVED");
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Dashboard/DeptDashBoard.aspx");


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