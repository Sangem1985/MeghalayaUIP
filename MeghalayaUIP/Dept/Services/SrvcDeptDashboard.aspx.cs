﻿using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using MeghalayaUIP.DAL.SVRCDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Services
{
    public partial class SrvcDeptDashboard : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        SVRCBAL SrvcBAL = new SVRCBAL();
       // SVRCDAL objSrvc = new SVRCDAL();
        CFEDtls objSrvc = new CFEDtls();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack == false)
                {
                    if (Session["DeptUserInfo"] != null)
                    {

                        if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                        {
                            ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                            if (ObjUserInfo.Roleid == "8")
                            {
                                divScrutiny.Visible = true;
                                divApproval.Visible = false;
                                divOffline.Visible = false;
                            }
                            else if (ObjUserInfo.Roleid == "9")
                            {
                                divScrutiny.Visible = false;
                                divApproval.Visible = true;
                                divOffline.Visible = true;
                            }
                        }
                    }
                    objSrvc.UserID = ObjUserInfo.UserID;
                   // objSrvc.UserName = ObjUserInfo.UserName;
                    objSrvc.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                    objSrvc.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    dt = SrvcBAL.GetSrvcDashBoard(objSrvc);

                    lblTOTALAPPLICATIONS.Text = dt.Rows[0]["TOTALAPPLICATIONS"].ToString();
                    lblPRESCRUTINYCOMPLETED.Text = dt.Rows[0]["PRESCRUTINYCOMPLETED"].ToString();
                    lblPRESCRUTINYPENDING.Text = dt.Rows[0]["PRESCRUTINYPENDING"].ToString();
                    lblPREREJECTED.Text = dt.Rows[0]["PRESCRUTINYREJECTED"].ToString();
                    lblADDITIONALPAYMENTRAISED.Text = dt.Rows[0]["ADDITIONALPAYMENTRAISED"].ToString();
                    lblQUERYPENDING.Text = dt.Rows[0]["QUERYPENDING"].ToString();


                    lblTOTALAPPROVALISSUED.Text = dt.Rows[0]["TOTALAPPROVALISSUED"].ToString();
                    lblAPPROVALPENDING.Text = dt.Rows[0]["APPROVALPENDING"].ToString();
                    lblREJECTED.Text = dt.Rows[0]["REJECTED"].ToString();

                    lblOFFLINETOTAL.Text = dt.Rows[0]["TOTALOFFILINEAPPLICATIONS"].ToString();
                    lblOFFLINEAPPROVED.Text = dt.Rows[0]["OFFLINEAPPROVED"].ToString();
                    lblOFFLINEPENDING.Text = dt.Rows[0]["OFFLINEPENDING"].ToString();
                    lblOFFLINEREJECTED.Text = dt.Rows[0]["OFFLINEREJECTED"].ToString();

                    if (lblTOTALAPPLICATIONS.Text == "0")
                        anchrTotal.HRef = "#";
                    if (lblPRESCRUTINYCOMPLETED.Text == "0")
                        anchrScrtnyCmpld.HRef = "#";
                    if (lblPRESCRUTINYPENDING.Text == "0")
                        anchrScrtnyPndng.HRef = "#";
                    if (lblPREREJECTED.Text == "0")
                        anchrScrtnyRjctd.HRef = "#";
                    if (lblADDITIONALPAYMENTRAISED.Text == "0")
                        anchrAddlPaymnt.HRef = "#";
                    if (lblQUERYPENDING.Text == "0")
                        anchrQryRaised.HRef = "#";
                    if (lblTOTALAPPROVALISSUED.Text == "0")
                        anchrApproved.HRef = "#";
                    if (lblAPPROVALPENDING.Text == "0")
                        anchrAprvlPndng.HRef = "#";
                    if (lblREJECTED.Text == "0")
                        anchrAprvlRjctd.HRef = "#";

                    if (lblOFFLINETOTAL.Text == "0")
                        anchrOffilineTotal.HRef = "#";
                    if (lblOFFLINEAPPROVED.Text == "0")
                        anchrOfflineApproved.HRef = "#";
                    if (lblOFFLINEREJECTED.Text == "0")
                        ancheOfflineRejcted.HRef = "#";
                    if (lblOFFLINEPENDING.Text == "0")
                        anchrOfflinePending.HRef = "#";

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