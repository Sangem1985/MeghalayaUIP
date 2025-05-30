using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.LABAL;
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

namespace MeghalayaUIP.Dept.LA
{
    public partial class LAApplDeptProcess : System.Web.UI.Page
    {
        LABAL Objland = new LABAL();
        LADeptDtls objDtls = new LADeptDtls();
        MasterBAL mstrBAL = new MasterBAL();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();

        string UNITID;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                success.Visible = false;
                Failure.Visible = false;

                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {
                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    //   hdnUserID.Value = ObjUserInfo.UserID;
                    ViewState["DEPTID"] = ObjUserInfo.Deptid;
                    if (!IsPostBack)
                    {
                        BindLandApplicationDetails();
                    }

                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindLandApplicationDetails()
        {
            // hdnUserID.Value = "1001";
            try
            {

                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {

                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    // username = ObjUserInfo.UserName;
                }

                if (Session["UNITID"] != null && Session["INVESTERID"] != null)
                {

                    //objDtls.Unitid = Session["UNITID"].ToString();
                    //objDtls.Investerid = Session["INVESTERID"].ToString();
                    //objDtls.UserID = ObjUserInfo.UserID;
                    //objDtls.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                    //objDtls.Stage = Convert.ToInt32(Session["stage"]);
                    //if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                    //{
                    //    objDtls.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    //}

                    DataSet ds = new DataSet();
                    ds = Objland.GetLandApplicationDetails(Session["UNITID"].ToString(), Session["INVESTERID"].ToString());
                    // ds = Objland.GetLandApplicationDetails(Convert.ToString(Session["UNITID"]),(Session["INVESTERID"]));

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        lblName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISD_NAMEOFCOMPANY"]);
                        lblDistric.Text = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
                        lblMandal.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mandalname"]);
                        lblVillage.Text = Convert.ToString(ds.Tables[0].Rows[0]["VillageName"]);
                        lblEquity.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISD_EQUITY"]);
                        lblBank.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISD_LOANBANK"]);
                        lblUnsecured.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISD_UNSECUREDLOAN"]);
                        lblInternal.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISD_INTERNALRESOURCES"]);
                        lblSource.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISD_OTHERSOURCE"]);
                        lblTotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISD_TOTAL"]);
                        lblCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISD_CATEGORYENTERPRISE"]);
                        lblPMLakh.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISD_PMLAKH"]);
                        lblCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISD_PROJECTCOSTLAKH"]);
                        lblDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISD_WASTEGENERATED"]);

                        //lblAppNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISD_LAUIDNO"]);

                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                    {
                        GVIndustrialArea.DataSource = ds.Tables[1];
                        GVIndustrialArea.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[2].Rows.Count > 0)
                    {
                        GVManu.DataSource = ds.Tables[2];
                        GVManu.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
                    {
                        GVRawMaterial.DataSource = ds.Tables[3];
                        GVRawMaterial.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[4].Rows.Count > 0)
                    {
                        GVPOWER.DataSource = ds.Tables[4];
                        GVPOWER.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[5].Rows.Count > 0)
                    {
                        GVWATER.DataSource = ds.Tables[5];
                        GVWATER.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[6].Rows.Count > 0)
                    {
                        grdAttachments.DataSource = ds.Tables[6];
                        grdAttachments.DataBind();
                    }
                    if (Convert.ToString(ds.Tables[7].Rows[0]["STAGEID"]) == "4")
                    {
                        Indverifypanel.Visible = true;
                    }
                    else
                    {
                        Indverifypanel.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void grdcfeattachment_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void btnIndSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {

                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                }
                if (ddlStatus.SelectedValue == "7")
                {
                    if (string.IsNullOrWhiteSpace(txtRemarks.Text) || txtRemarks.Text == "" || txtRemarks.Text == null)
                    {
                        lblmsg0.Text = "Please Enter Remarks";
                        Failure.Visible = true;
                        return;
                    }
                    //if ((ddlStatus.SelectedValue == "4") && (string.IsNullOrWhiteSpace(txtApplQuery.Text) || txtApplQuery.Text == "" || txtApplQuery.Text == null))
                    //{
                    //    lblmsg0.Text = "Please Enter Query Description";
                    //    Failure.Visible = true;
                    //    return;
                    //}
                    else
                    {
                        //Unitid = unitid
                        //Investerid = investerid

                        //status = Convert.ToInt32(ddlStatus.SelectedValue);
                        //UserID = ObjUserInfo.UserID;

                        //prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);

                        //Remarks = txtRemarks.Text;
                        //IPAddress = getclientIP();

                        string valid = PreBAL.LADeptProcess(prd);
                        btnIndSubmit.Enabled = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Submitted Successfully!');  window.location.href='PreRegApplIMADashBoard.aspx'", true);
                        return;
                    }
                }
                else
                {
                    lblmsg0.Text = "Please Select Action";
                    Failure.Visible = true;
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                string User_id = "0";
                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {
                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    User_id = ((DeptUserInfo)Session["DeptUserInfo"]).UserID;
                }
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, User_id);
            }
        }
        public static string getclientIP()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return result;
        }
    }
}