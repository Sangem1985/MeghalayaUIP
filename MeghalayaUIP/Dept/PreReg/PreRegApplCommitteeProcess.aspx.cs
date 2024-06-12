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
    public partial class PreRegApplCommitteeProcess : System.Web.UI.Page
    {
        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
        DropDownList ddldepartment;
        DataTable dt = new DataTable();
        List<PreRegDtls> lstPreRegDtlsVo = new List<PreRegDtls>();
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
                    hdnUserID.Value = ObjUserInfo.UserID;

                    if (!IsPostBack)
                    {
                        BindaApplicatinDetails();                       
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
                }

                if (Session["UNITID"] != null && Session["INVESTERID"] != null && Session["stage"] != null)
                {
                    prd.Unitid = Session["UNITID"].ToString();
                    prd.Investerid = Session["INVESTERID"].ToString();
                    prd.UserID = ObjUserInfo.UserID;
                    prd.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                    prd.Stage = Convert.ToInt32(Session["stage"]);
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

                    grdRevenueProj.DataSource = ds.Tables[1];
                    grdRevenueProj.DataBind();

                    grdDirectors.DataSource = ds.Tables[2];
                    grdDirectors.DataBind();

                    grdApplStatus.DataSource = ds.Tables[3];
                    grdApplStatus.DataBind();

                    //grdQueries.DataSource = null;
                    grdQueries.DataBind();

                    //grdQryAttachments.DataSource = null;
                    grdQryAttachments.DataBind();
                    if (Request.QueryString["status"].ToString() == "COMMTOBEPROCESSED" || Request.QueryString["status"].ToString() == "COMMQUERYREPLIED")
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
                }
                if (ddlStatus.SelectedValue == "10" )
                {
                    string ErrorMsg = "";
                    if ( string.IsNullOrWhiteSpace(txtRequest.Text) || txtRequest.Text == "" || txtRequest.Text == null)
                    {
                        ErrorMsg = ErrorMsg + "Please Enter Remarks";
                        lblmsg0.Text = "Please Enter Remarks";
                        Failure.Visible = true;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtDeptLandArea.Text) || txtDeptLandArea.Text == "" || txtDeptLandArea.Text == null)
                    {
                        lblmsg0.Text = "Please Enter Land Area";
                        txtDeptLandArea.Focus();
                        Failure.Visible = true;
                        return;
                    }
                   if (string.IsNullOrWhiteSpace(txtDeptPower.Text) || txtDeptPower.Text == "" || txtDeptPower.Text == null)
                    {
                        lblmsg0.Text = "Please Enter Power Required";
                        txtDeptLandArea.Focus();
                        Failure.Visible = true;
                        return;
                    }
                     if (string.IsNullOrWhiteSpace(txtDeptWater.Text) || txtDeptWater.Text == "" || txtDeptWater.Text == null)
                    {
                        lblmsg0.Text = "Please Enter Water Required";
                        txtDeptWater.Focus();
                        Failure.Visible = true;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtDeptWastedtls.Text) || txtDeptWastedtls.Text == "" || txtDeptWastedtls.Text == null)                         
                    {
                        lblmsg0.Text = "Please Enter Waste and Hazardous waste details";
                        txtDeptLandArea.Focus();
                        Failure.Visible = true;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtHazWaste.Text) || txtHazWaste.Text == "" || txtHazWaste.Text == null)
                    {
                        lblmsg0.Text = "Please Enter Waste and Hazardous waste details";
                        txtDeptLandArea.Focus();
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
                        prd.Remarks = txtRequest.Text;
                        if (txtDeptLandArea.Text.Trim() != "" && txtDeptLandArea.Text.Trim() != "")
                        {
                            prd.LandArea = txtDeptLandArea.Text.Trim();
                        }
                        if (txtDeptPower.Text.Trim() != "" && txtDeptPower.Text.Trim() != "")
                        {
                            prd.Power = txtDeptPower.Text.Trim();
                        }
                        if (txtDeptWater.Text.Trim() != "" && txtDeptWater.Text.Trim() != "")
                        {
                            prd.Water = txtDeptWater.Text;
                        }
                        if (txtDeptWastedtls.Text.Trim() != "" && txtDeptWastedtls.Text.Trim() != "")
                        {
                            prd.WasteDetails = txtDeptWastedtls.Text;
                        }
                        if (txtHazWaste.Text.Trim() != "" && txtHazWaste.Text.Trim() != "")
                        {
                            prd.HazDetails = txtHazWaste.Text;
                        }

                        prd.IPAddress = getclientIP();
                        if (ddlStatus.SelectedValue == "13" || ddlStatus.SelectedValue == "14")
                        {
                            string valid = PreBAL.PreRegApprovals(prd);
                            btnSubmit.Enabled = false;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Submitted Successfully!');  window.location.href='PreRegApplCommitteeDashBoard.aspx'", true);
                            return;
                        }
                        else if (ddlStatus.SelectedValue == "12")
                        {
                            string valid = PreBAL.PreRegUpdateQuery(prd);
                            btnSubmit.Enabled = false;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Query Raised Successfully!');  window.location.href='PreRegApplCommitteeDashBoard.aspx'", true);
                            return;
                        }

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
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlStatus.SelectedValue == "10") //--approve
                {
                    tblaction.Visible = true;
                    trcommvalues.Visible = true;                                                  
                    lblaction.Text = "Remarks if any: ";
                  
                    lblApplLandArea.Text = lbllandArea.Text;                   
                  
                    lblApplPowerReq.Text = lblPowerReq.Text;
                 
                    lblApplWaterReq.Text = lblWaterReq.Text;
                   
                    lblApplHazWaste.Text = lblhazdtls.Text; 

                    lblApplWastedtls.Text = lblwastedtls.Text;                  

                }
                else if (ddlStatus.SelectedValue == "9") //query
                {
                    tblaction.Visible = true;
                    trcommvalues.Visible = false;
                    lblaction.Text = "Enter Query Description ";

                }
                else if (ddlStatus.SelectedValue == "11") //reject
                {
                    tblaction.Visible = true;
                    trcommvalues.Visible = false;
                    lblaction.Text = "Enter Rejection Remarks ";

                }
                else
                { tblaction.Visible = false; }
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
        //protected void btnQuery_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var ObjUserInfo = new DeptUserInfo();
        //        if (Session["DeptUserInfo"] != null)
        //        {

        //            if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
        //            {
        //                ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
        //            }
        //            // username = ObjUserInfo.UserName;
        //        }
        //        PreRegDtls PreRegDtlsVo = new PreRegDtls();
        //        //foreach (GridViewRow gvrow in gvdeptquery.Rows)
        //        //{
        //        //    DropDownList ddldepartment = (DropDownList)gvrow.FindControl("ddldepartment");
        //        //    TextBox txtquery = (TextBox)gvrow.FindControl("txtquery");
        //        //    PreRegDtlsVo.QuerytoDeptID = ddldepartment.SelectedValue;
        //        //    // PreRegDtlsVo.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
        //        //    PreRegDtlsVo.DeptDesc = ddldepartment.SelectedItem.Text.Trim();
        //        //    PreRegDtlsVo.Remarks = txtquery.Text.Trim();
        //        //    PreRegDtlsVo.Unitid = Session["UNITID"].ToString();
        //        //    PreRegDtlsVo.Investerid = Session["INVESTERID"].ToString();
        //        //    if (ddlStatus != null)
        //        //        PreRegDtlsVo.status = Convert.ToInt32(ddlStatus.SelectedValue);
        //        //    PreRegDtlsVo.UserID = ObjUserInfo.UserID;
        //        //    //lstPreRegDtlsVo.Add(PreRegDtlsVo);
        //        //    var Hostname = Dns.GetHostName();
        //        //    PreRegDtlsVo.IPAddress = Dns.GetHostByName(Hostname).AddressList[0].ToString();
        //        //    string valid = PreBAL.PreRegUpdateQuery(PreRegDtlsVo);
        //        //}
        //        btnQuery.Enabled = false;
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Query Raised Successfully!');  window.location.href='PreRegApplCommitteeDashBoard.aspx'", true);
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblmsg0.Text = "Oops, You have encountered an error!! please contact administrator.";
        //        Failure.Visible = true;
        //        string User_id = "0";
        //        var ObjUserInfo = new DeptUserInfo();
        //        if (Session["DeptUserInfo"] != null)
        //        {
        //            if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
        //            {
        //                ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
        //            }
        //            User_id = ((DeptUserInfo)Session["DeptUserInfo"]).UserID;
        //        }
        //        MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, User_id);
        //    }
        //}

        //protected void btnReject_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        btnSubmit_Click(sender, e);
        //    }
        //    catch (Exception ex)
        //    {
        //        lblmsg0.Text = "Oops, You have encountered an error!! please contact administrator.";
        //        Failure.Visible = true;
        //        string User_id = "0";
        //        var ObjUserInfo = new DeptUserInfo();
        //        if (Session["DeptUserInfo"] != null)
        //        {
        //            if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
        //            {
        //                ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
        //            }
        //            User_id = ((DeptUserInfo)Session["DeptUserInfo"]).UserID;
        //        }
        //        MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, User_id);
        //    }
        //}
    }
}