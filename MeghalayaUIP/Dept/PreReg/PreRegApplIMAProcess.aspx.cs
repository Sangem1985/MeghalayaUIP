using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.CommonClass;

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegApplIMAProcess : System.Web.UI.Page
    {
        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
        DataTable dt = new DataTable();
        List<PreRegDtls> lstPreRegDtlsVo = new List<PreRegDtls>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                success.Visible = false;
                Failure.Visible = false;
                if (!IsPostBack)
                {
                    var ObjUserInfo = new DeptUserInfo();
                    if (Session["DeptUserInfo"] != null)
                    {
                        if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                        {
                            ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                        }
                        hdnUserID.Value = ObjUserInfo.UserID;
                    }
                    BindaApplicatinDetails();
                    BindDepartments();
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindaApplicatinDetails()
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
                    // username = ObjUserInfo.UserName;
                }

                if (Session["UNITID"] != null && Session["INVESTERID"] != null && Session["stage"] != null)
                {
                    prd.Unitid = Session["UNITID"].ToString();
                    prd.Investerid = Session["INVESTERID"].ToString();
                    prd.UserID = ObjUserInfo.UserID;
                    prd.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                    prd.Stage = Convert.ToInt32(Session["stage"]);
                    if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                    {
                        prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    }
                    DataSet ds = new DataSet();
                    ds = PreBAL.GetPreRegNodelOfficer(prd);



                    DataRow row = ds.Tables[0].Rows[0];
                    lblCompanyName.Text = Convert.ToString(row["COMPANYNAME"]);
                    lblCompanyPAN.Text = Convert.ToString(row["COMPANYPANNO"]);
                    lblCompanyProposal.Text = Convert.ToString(row["COMPANYPRAPOSAL"]);
                    lblregdate.Text = Convert.ToString(row["REGISTRATIONDATE"]);
                    lblUdyam.Text = Convert.ToString(row["UDYAMNO"]);
                    lblGSTIN.Text = Convert.ToString(row["GSTNNO"]);

                    lblcomptype.Text = Convert.ToString(row["CONST_TYPE"]);
                    lblcatreg.Text = Convert.ToString(row["REGISTRATIONTYPENAME"]);
                    lbldoorno_authrep.Text = Convert.ToString(row["REP_DOORNO"]);
                    lblisland.Text = Convert.ToString(row["UNIT_LANDTYPE"]);

                    lblpromotndcont.Text = Convert.ToString(row["FRD_PROMOTEREQUITY"]);
                    lblequityamount.Text = Convert.ToString(row["FRD_EQUITY"]);
                    lbltermloanworking.Text = Convert.ToString(row["FRD_LOAN"]);

                    lblunsecuredloan.Text = Convert.ToString(row["FRD_UNSECUREDLOAN"]);
                    lblinternalresources.Text = Convert.ToString(row["FRD_INTERNALRESOURCE"]);
                    lblstatescheme.Text = Convert.ToString(row["FRD_STATE"]);

                    lblcapitalsubsidy.Text = Convert.ToString(row["FRD_CAPITALSUBSIDY"]);
                    lblunnati.Text = Convert.ToString(row["FRD_UNNATI"]);
                    lblcentralscheme.Text = Convert.ToString(row["FRD_CENTRAL"]);
                    if (Convert.ToString(row["ELIGIBLE_FLAG"]).Trim() == "N")
                    {
                        lblnote.Visible = true;
                    }
                    else
                    {
                        lblnote.Visible = false;
                    }


                    lblName.Text = Convert.ToString(row["REP_NAME"]);
                    lblMobile.Text = Convert.ToString(row["REP_MOBILE"]);
                    lblEmail.Text = Convert.ToString(row["REP_EMAIL"]);
                    lblLocality.Text = Convert.ToString(row["REP_LOCALITY"]);
                    lblDistict.Text = Convert.ToString(row["REP_DISTRICT"]);
                    lblMandal.Text = Convert.ToString(row["REP_MANDAL"]);
                    lblVillage.Text = Convert.ToString(row["REP_VILLAGE"]);
                    lblPincode.Text = Convert.ToString(row["REP_PINCODE"]);
                    lblPincode.Text = Convert.ToString(row["REP_PINCODE"]);
                    //lblLandtype.Text= Convert.ToString(row["UNIT_LANDTYPE"]);
                    lbldrno.Text = Convert.ToString(row["UNIT_DOORNO"]);
                    lblPro_loc.Text = Convert.ToString(row["UNIT_LOCALITY"]);
                    lblpro_dis.Text = Convert.ToString(row["UNIT_DISTRICT"]);
                    lblPro_Man.Text = Convert.ToString(row["UNIT_MANDAL"]);
                    lblPro_vill.Text = Convert.ToString(row["UNIT_VILLAGE"]);
                    lblPro_Pin.Text = Convert.ToString(row["UNIT_PINCODE"]);

                    lblDateofcomm.Text = Convert.ToString(row["PROJECT_DCP"]);
                    lblNatureofAct.Text = Convert.ToString(row["PROJECT_NOA"]);
                    if (lblNatureofAct.Text == "Manufacturing")
                        divManf.Visible = true;
                    else divServc.Visible = true;
                    lblMainmanuf.Text = Convert.ToString(row["PROJECT_MANFACTIVITY"]);
                    lblmanufProdct.Text = Convert.ToString(row["PROJECT_MANFPRODUCT"]);
                    lblProdNo.Text = Convert.ToString(row["PROJECT_MANFPRODNO"]);

                    lblMainSrvc.Text = Convert.ToString(row["PROJECT_SRVCACTIVITY"]);
                    lblSrvcProvdng.Text = Convert.ToString(row["PROJECT_SRVCNAME"]);
                    lblSrvcNo.Text = Convert.ToString(row["PROJECT_SRVCNO"]);

                    lblSector.Text = Convert.ToString(row["PROJECT_SECTORNAME"]);
                    lblLOA.Text = Convert.ToString(row["LineofActivity_Name"]);
                    lblPCBcatogry.Text = Convert.ToString(row["PROJECT_PCBCATEGORY"]);

                    lblmainRM.Text = Convert.ToString(row["PROJECT_MAINRM"]);
                    lblwastedtls.Text = Convert.ToString(row["PROJECT_WASTEDETAILS"]);
                    lblhazdtls.Text = Convert.ToString(row["PROJECT_HAZWASTEDETAILS"]);
                    lblcivilConstr.Text = Convert.ToString(row["PROJECT_CIVILCONSTR"]);
                    lbllandArea.Text = Convert.ToString(row["PROJECT_LANDAREA"]);
                    lblBuildingArea.Text = Convert.ToString(row["PROJECT_BUILDINGAREA"]);

                    lblWaterReq.Text = Convert.ToString(row["PROJECT_WATERREQ"]);
                    lblPowerReq.Text = Convert.ToString(row["PROJECT_POWERRREQ"]);
                    lblunitofmeasure.Text = Convert.ToString(row["PROJECT_UNITOFMEASURE"]);
                    lblAnnualCap.Text = Convert.ToString(row["PROJECT_ANNUALCAPACITY"]);
                    lblEstProjcost.Text = Convert.ToString(row["PROJECT_EPCOST"]);
                    lblPMCost.Text = Convert.ToString(row["PROJECT_PMCOST"]);
                    lblIFC.Text = Convert.ToString(row["PROJECT_IFC"]);
                    lblDFA.Text = Convert.ToString(row["PROJECT_DFA"]);
                    lblBuldingValue.Text = Convert.ToString(row["PROJECT_BUILDINGVALUE"]);
                    lblLandValue.Text = Convert.ToString(row["PROJECT_LANDVALUE"]);
                    lblWaterValue.Text = Convert.ToString(row["PROJECT_WATERVALUE"]);
                    lblElectricityValue.Text = Convert.ToString(row["PROJECT_ELECTRICITYVALUE"]);
                    lblWorkingCapital.Text = Convert.ToString(row["PROJECT_WORKINGCAPITAL"]);

                    lbl_Name1.Text = Convert.ToString(row["REP_NAME"]);
                    lblunitname1.Text = Convert.ToString(row["REP_NAME"]);
                    lblApplNo.Text = Convert.ToString(row["PREREGUIDNO"]);
                    lblapplDate.Text = Convert.ToString(row["REP_MOBILE"]);
                    lblapplDate.Text = Convert.ToString(row["CREATEDDATE"]);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                    {
                        grdRevenueProj.DataSource = ds.Tables[1];
                        grdRevenueProj.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[2].Rows.Count > 0)
                    {
                        grdDirectors.DataSource = ds.Tables[2];
                        grdDirectors.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
                    {
                        grdApplStatus.DataSource = ds.Tables[3];
                        grdApplStatus.DataBind();
                    }

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[4].Rows.Count > 0)
                    {
                        grdQueries.DataSource = ds.Tables[4];
                        grdQueries.DataBind();

                    }

                    grdQryAttachments.DataSource = null;
                    grdQryAttachments.DataBind();
                    if (Request.QueryString["status"].ToString() == "IMATOBEPROCESSED" || Request.QueryString["status"].ToString() == "IMAQUERYREPLIED")
                    {
                        verifypanel.Visible = true;
                    }
                    else
                    {
                        verifypanel.Visible = false;
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
        public void BindDepartments()
        {
            try
            {
                DataSet dsdepartments = new DataSet();
                dsdepartments = PreBAL.GetDeptMst(Session["UNITID"].ToString(), hdnUserID.Value);
                if (dsdepartments != null && dsdepartments.Tables.Count > 0 && dsdepartments.Tables[0].Rows.Count > 0)
                {
                    ddldepartment.DataSource = dsdepartments;
                    ddldepartment.DataTextField = "MD_DEPT_NAME";
                    ddldepartment.DataValueField = "MD_DEPTID";
                    ddldepartment.DataBind();
                    AddSelect(ddldepartment);
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
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
                    // username = ObjUserInfo.UserName;
                }
                if (ddlStatus.SelectedValue == "8" || ddlStatus.SelectedValue == "4")
                {
                    if ((ddlStatus.SelectedValue == "8") && (string.IsNullOrWhiteSpace(txtRemarks.Text) || txtRemarks.Text == "" || txtRemarks.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Remarks";
                        Failure.Visible = true;
                        return;
                    }
                    if ((ddlStatus.SelectedValue == "4") && (string.IsNullOrWhiteSpace(txtApplQuery.Text) || txtApplQuery.Text == "" || txtApplQuery.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Query Description";
                        Failure.Visible = true;
                        return;
                    }

                    else
                    {
                        prd.Unitid = Session["UNITID"].ToString();
                        prd.Investerid = Session["INVESTERID"].ToString();
                        if (ddlStatus != null)
                            prd.status = Convert.ToInt32(ddlStatus.SelectedValue);
                        prd.UserID = ObjUserInfo.UserID;
                        if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                        {
                            prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                        }
                        prd.Remarks = txtRemarks.Text;

                        prd.IPAddress = getclientIP();

                        string valid = PreBAL.PreRegApprovals(prd);
                        btnSubmit.Enabled = false;
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
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatus.SelectedValue == "8")
                {
                    tdRemarks.Visible = true;
                    tdRemarksTxtbx.Visible = true;
                    txtRemarks.Focus();
                    btnSubmit.Visible = true;
                    tdaction.Visible = true;

                    tdApplQuery.Visible = false;
                    tdApplQueryTxtbx.Visible = false;
                    tdDeptQuery.Visible = false;
                    btnQuery.Visible = false;

                }
                else if (ddlStatus.SelectedValue == "4")
                {
                    tdApplQuery.Visible = true;
                    tdApplQueryTxtbx.Visible = true;
                    txtApplQuery.Focus();
                    btnSubmit.Visible = true;
                    tdaction.Visible = true;

                    tdRemarks.Visible = false;
                    tdRemarksTxtbx.Visible = false;
                    tdDeptQuery.Visible = false;
                    btnQuery.Visible = false;
                }
                else if (ddlStatus.SelectedValue == "6")
                {
                    tdDeptQuery.Visible = true;
                    btnQuery.Visible = true;

                    tdApplQuery.Visible = false;
                    tdApplQueryTxtbx.Visible = false;
                    btnSubmit.Visible = false;
                    tdaction.Visible = false;
                    tdRemarks.Visible = false;
                    tdRemarksTxtbx.Visible = false;

                }



            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }


        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.CssClass = "errormsg";
            }
        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                PreRegDtls PreRegDtlsVo = new PreRegDtls();
                foreach (GridViewRow gvrow in grdDeptQueries.Rows)
                {
                    DropDownList ddldepartment = (DropDownList)gvrow.FindControl("ddldepartment");
                    TextBox txtquery = (TextBox)gvrow.FindControl("txtquery");
                    PreRegDtlsVo.QuerytoDeptID = ddldepartment.SelectedValue;
                    // PreRegDtlsVo.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    PreRegDtlsVo.DeptDesc = ddldepartment.SelectedItem.Text.Trim();
                    PreRegDtlsVo.Remarks = txtquery.Text.Trim();
                    PreRegDtlsVo.Unitid = Session["UNITID"].ToString();
                    PreRegDtlsVo.Investerid = Session["INVESTERID"].ToString();
                    if (ddlStatus != null)
                        PreRegDtlsVo.status = Convert.ToInt32(ddlStatus.SelectedValue);
                    PreRegDtlsVo.UserID = hdnUserID.Value;
                    //lstPreRegDtlsVo.Add(PreRegDtlsVo);

                    PreRegDtlsVo.IPAddress = getclientIP();
                    string valid = PreBAL.PreRegUpdateQuery(PreRegDtlsVo);
                }
                btnQuery.Enabled = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Query Raised Successfully!');  window.location.href='PreRegApplIMADashBoard.aspx'", true);
                return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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

        protected void btnAddDeptQry_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddldepartment.SelectedItem.Text == "--Select--" || (txtDeptQuery.Text == "" || string.IsNullOrEmpty(txtDeptQuery.Text) || txtDeptQuery.Text == null))
                {
                    Failure.Visible = true; string Error = "";
                    if (ddldepartment.SelectedItem.Text == "--Select--")
                    {
                        lblmsg0.Text = "Please Select Department";
                        Error= "Please Select Department";
                    }
                    if (txtDeptQuery.Text == "" || string.IsNullOrEmpty(txtDeptQuery.Text) || txtDeptQuery.Text == null)
                    {
                        lblmsg0.Text = lblmsg0.Text + "\n Please Enter Query Description";
                        Error = "\n Please Enter Query Description";

                    }
                    string message = "alert('" + Error + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
                else
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("DEPTNAME", typeof(string));
                    dt.Columns.Add("DEPTID", typeof(string));
                    dt.Columns.Add("QUERYDESC", typeof(string));
                    dt.Columns.Add("UNITID", typeof(string));
                    dt.Columns.Add("INVESTERID", typeof(string));

                    if (ViewState["QueryTable"] != null)
                    {
                        dt = (DataTable)ViewState["QueryTable"];
                    }
                    DataRow dr = dt.NewRow();

                    dr["DEPTNAME"] = ddldepartment.SelectedItem.Text;
                    dr["DEPTID"] = ddldepartment.SelectedValue;
                    dr["QUERYDESC"] = txtDeptQuery.Text;
                    dr["UNITID"] = Session["UNITID"].ToString();
                    dr["INVESTERID"] = Session["INVESTERID"].ToString();

                    dt.Rows.Add(dr);
                    grdDeptQueries.Visible = true;
                    grdDeptQueries.DataSource = dt;
                    grdDeptQueries.DataBind();
                    ViewState["QueryTable"] = dt;
                    txtDeptQuery.Text = "";
                    if (ddldepartment.SelectedIndex != 0)
                    {
                        ddldepartment.Items.RemoveAt(ddldepartment.SelectedIndex);
                    }
                    if (grdDeptQueries.Rows.Count > 0)
                        btnQuery.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void grdDeptQueries_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                if (grdDeptQueries.Rows.Count > 0)
                {
                    ((DataTable)ViewState["QueryTable"]).Rows.RemoveAt(e.RowIndex);
                    this.grdDeptQueries.DataSource = ((DataTable)ViewState["QueryTable"]).DefaultView;
                    this.grdDeptQueries.DataBind();
                    grdDeptQueries.Visible = true;
                    grdDeptQueries.Focus();

                }

            }
            catch (Exception ex)
            {

                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
    }
}