﻿using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Grievance
{
    public partial class GrievanceDeptdashboarddrill : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        MGCommonBAL objcomBal = new MGCommonBAL();
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
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.UserID;
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindData(ObjUserInfo.Deptid);

                    }
                }
                else
                {
                    Response.Redirect("~/DeptLogin.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                throw ex;
            }

        }
        public void BindData(string DeptID)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objcomBal.GetDepGrievanceDashboard(DeptID, hdnUserID.Value);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                  
                    lblPendingTotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["PENDINGTOATL"]);
                    lblPendingWithin.Text = Convert.ToString(ds.Tables[0].Rows[0]["PENDINGWITHIN"]);
                    lblPendingBeyond.Text = Convert.ToString(ds.Tables[0].Rows[0]["PENDINGBEYOND"]);
                    lblRedressedTotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["REDRESSEDTOATL"]);
                    lblRedressedWithin.Text = Convert.ToString(ds.Tables[0].Rows[0]["REDRESSEDWITHIN"]);
                    lblRedressedBeyond.Text = Convert.ToString(ds.Tables[0].Rows[0]["REDRESSEDBEYOND"]);
                    lblRejectedTotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["REJECTEDTOATL"]);
                    lblRejectedWithin.Text = Convert.ToString(ds.Tables[0].Rows[0]["REJECTEDWITHIN"]);
                    lblRejectedBeyond.Text = Convert.ToString(ds.Tables[0].Rows[0]["REJECTEDBEYOND"]);

                }
                else
                {
                    lblmsg0.Text = "Some Internal Error Occured please try again";
                    Failure.Visible = true;
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }
    }
}