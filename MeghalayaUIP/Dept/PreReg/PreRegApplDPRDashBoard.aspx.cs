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
    public partial class PreRegApplDPRDashBoard : System.Web.UI.Page
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
                   // Bind();
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

                dt = PreBAL.PreRegDPRDashBoard(prd);
                
            }
            catch(Exception ex)
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
                if(lblTotalApp.Text != "0")
                {
                    Response.Redirect("PreRegApplDPRView.aspx?status=DPRTOTAL");
                }
            }
            catch(Exception ex)
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
                if(lblDPRTOBEPROCESSED.Text != "0")
                {
                    Response.Redirect("PreRegApplDPRView.aspx?status=DPRTOBEPROCESSED");
                }
            }
            catch(Exception ex)
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
                    Response.Redirect("PreRegApplDPRView.aspx?status=DPRPROCESSED");
                }
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