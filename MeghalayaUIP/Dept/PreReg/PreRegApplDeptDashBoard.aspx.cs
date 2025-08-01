﻿using System;
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
    public partial class PreRegApplDeptDashBoard : System.Web.UI.Page
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


                    if (!IsPostBack)
                    {
                        prd.UserID = ObjUserInfo.UserID;
                        prd.UserName = ObjUserInfo.UserName;
                        prd.Role = Convert.ToInt32(ObjUserInfo.PreRegRoleid == "" ? ObjUserInfo.Roleid : ObjUserInfo.PreRegRoleid);
                        //Convert.ToInt32(ObjUserInfo.Roleid);
                        prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                        dt = PreBAL.GetPreRegDashBoard(prd);

                        lblTotalApp.Text = dt.Rows[0]["TOTAL"].ToString();
                        //lblToBeProcessed.Text = dt.Rows[0]["TOBEPROCESSED"].ToString();
                       // lblprocessed.Text = dt.Rows[0]["PROCESSED"].ToString();
                        //lblApproved.Text = dt.Rows[0]["Approved"].ToString(); 
                        //lblQuery.Text = dt.Rows[0]["QUERYRIASED"].ToString(); 
                        //lblQueryReplied.Text = dt.Rows[0]["QUERYREPLIED"].ToString(); 

                        lblIMAQuery.Text = dt.Rows[0]["TOBEPROCESSED"].ToString();
                        lblDeptrepliedtoIMA.Text = dt.Rows[0]["PROCESSED"].ToString();
                        lblReceivedDEPTQUERY.Text = dt.Rows[0]["DICFORWARDED"].ToString(); 
                        lblSentDEPT.Text = dt.Rows[0]["DICRECEIVED"].ToString();
                        lblTotal.Text = dt.Rows[0]["DISTRICTAPPLI"].ToString();
                        //lblIMAQueryforwardedtoAppl.Text = dt.Rows[0]["DEPTFWDIMAQUERYTOAPPL"].ToString();
                        //lblAPPLREPLIEDTOIMAQUERY.Text = dt.Rows[0]["APPLREPLIEDTOIMAQUERY"].ToString();
                        //if (prd.UserID == "1030")
                        //{
                        //    linkQryRcvd.Text = "To be Processed";
                        //    linkQryRepld.Text = "Processed";
                        //}
                        int[] GMDICs = { 1016,1017,1018,1019,1020,1021,1022,1023,1024,1025,1026,1027 };
                        if (GMDICs.Contains(Convert.ToInt32(ObjUserInfo.UserID)))
                        {
                            linkDeptSent.Visible = true;
                            linkDeptReceived.Visible = true;
                            divDistrict.Visible = true;
                        }
                        else
                        {
                            linkQryRcvd.Visible = true;
                            linkQryRepld.Visible = true;
                        }
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
                    Response.Redirect("PreRegApplDeptView.aspx?status=TOTAL");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }
        protected void linkQryRcvd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblIMAQuery.Text != "0")
                    Response.Redirect("PreRegApplDeptView.aspx?status=TOBEPROCESSED");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }

        }

        protected void linkQryRepld_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblDeptrepliedtoIMA.Text != "0")
                    Response.Redirect("PreRegApplDeptView.aspx?status=PROCESSED");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }

        }

        protected void linkDeptReceived_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblReceivedDEPTQUERY.Text != "0")
                {
                    Response.Redirect("PreRegApplDeptView.aspx?status=DICFORWARDED");
                }

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void linkDeptSent_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblSentDEPT.Text != "0")
                {
                    Response.Redirect("PreRegApplDeptView.aspx?status=DICRECEIVED");
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void lnkAppliaction_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblTotal.Text != "0")
                {                   
                    Response.Redirect("PreRegApplDeptView.aspx?status=DISTRICTAPPLI");
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