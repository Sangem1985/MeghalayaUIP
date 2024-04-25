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

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegApplDeptProcess : System.Web.UI.Page
    {
        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
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
                        // username = ObjUserInfo.UserName;
                    }
                    BindaApplicatinDetails();
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                    lblCompanyType.Text = Convert.ToString(row["COMPANYTYPE"]);
                    lblregdate.Text = Convert.ToString(row["REGISTRATIONDATE"]);
                    lblUdyam.Text = Convert.ToString(row["UDYAMNO"]);
                    lblGSTIN.Text = Convert.ToString(row["GSTNNO"]);
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

                    lblCapitalSubsidy.Text = Convert.ToString(row["FRD_CAPITALSUBSIDY"]);
                    lblPromoterEquity.Text = Convert.ToString(row["FRD_PROMOTEREQUITY"]);
                    lblLoan.Text = Convert.ToString(row["FRD_LOAN"]);
                    lbl_Name1.Text= Convert.ToString(row["REP_NAME"]);
                    lblunitname1.Text= Convert.ToString(row["REP_NAME"]);
                    lblApplNo.Text= Convert.ToString(row["PREREGUIDNO"]);
                    lblapplDate.Text= Convert.ToString(row["REP_MOBILE"]);
                    lblapplDate.Text = Convert.ToString(row["CREATEDDATE"]) ;

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
                if (ddlStatus.SelectedValue == "4" || ddlStatus.SelectedValue == "5")
                {
                    if ((ddlStatus.SelectedValue == "4" || ddlStatus.SelectedValue == "5") && (string.IsNullOrWhiteSpace(txtRequest.Text) || txtRequest.Text == "" || txtRequest.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Query Description";
                        Failure.Visible = true;
                        return;
                    }
                    else if (ddlStatus.SelectedValue == "5" && ObjUserInfo.Deptid == "1001" && (string.IsNullOrWhiteSpace(txtDeptLandArea.Text) || txtDeptLandArea.Text == "" || txtDeptLandArea.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Land Area";
                        txtDeptLandArea.Focus();
                        Failure.Visible = true;
                        return;
                    }
                    else if (ddlStatus.SelectedValue == "5" && ObjUserInfo.Deptid == "1009" && (string.IsNullOrWhiteSpace(txtDeptPower.Text) || txtDeptPower.Text == "" || txtDeptPower.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Power Required";
                        txtDeptLandArea.Focus();
                        Failure.Visible = true;
                        return;
                    }
                    else if (ddlStatus.SelectedValue == "5" && ObjUserInfo.Deptid == "1008" && (string.IsNullOrWhiteSpace(txtDeptWater.Text) || txtDeptWater.Text == "" || txtDeptWater.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Water Required";
                        txtDeptWater.Focus();
                        Failure.Visible = true;
                        return;
                    }
                    else if (ddlStatus.SelectedValue == "5" && (ObjUserInfo.Deptid == "1005")// || DeptID == "Env")
                        && (string.IsNullOrWhiteSpace(txtDeptWastedtls.Text) || txtDeptWastedtls.Text == "" || txtDeptWastedtls.Text == null)
                         && (string.IsNullOrWhiteSpace(txtHazWaste.Text) || txtHazWaste.Text == "" || txtHazWaste.Text == null))
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
                        prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
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
                        var Hostname = Dns.GetHostName();
                        prd.IPAddress = Dns.GetHostByName(Hostname).AddressList[0].ToString();
                        if(ddlStatus.SelectedValue =="5")
                        {
                            string valid = PreBAL.PreRegApprovals(prd);
                            btnSubmit.Enabled = false;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Submitted Successfully!');  window.location.href='PreRegApplDeptDashBoard.aspx'", true);
                            return;
                        }
                        else
                        {
                            string valid = PreBAL.PreRegUpdateQuery(prd);
                            btnSubmit.Enabled = false;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Query Raised Successfully!');  window.location.href='PreRegApplDeptDashBoard.aspx'", true);
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ddlStatus.SelectedValue == "4" || ddlStatus.SelectedValue == "5" )
        //        {
        //            if ((string.IsNullOrWhiteSpace(txtRequest.Text) || txtRequest.Text == "" || txtRequest.Text == null))
        //            {
        //                lblmsg0.Text = "Please Enter Remarks";
        //                Failure.Visible = true;
        //                return;
        //            }
        //            else
        //            {
        //                var ObjUserInfo = new DeptUserInfo();
        //                if (Session["DeptUserInfo"] != null)
        //                {
        //                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
        //                    {
        //                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
        //                    }
        //                    // username = ObjUserInfo.UserName;
        //                }
        //                prd.Unitid = Session["UNITID"].ToString();
        //                prd.Investerid = Session["INVESTERID"].ToString();
        //                if (ddlStatus != null)
        //                    prd.status = Convert.ToInt32(ddlStatus.SelectedValue);
        //                prd.UserID = ObjUserInfo.UserID;
        //                prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
        //                var Hostname = Dns.GetHostName();
        //                prd.IPAddress = Dns.GetHostByName(Hostname).AddressList[0].ToString();
        //                prd.Remarks = txtRequest.Text;
        //                string valid = PreBAL.PreRegApprovals(prd);
        //                if (valid != "")
        //                {
        //                    verifypanel.Visible = false;
        //                    success.Visible = true;
        //                    lblmsg.Text = "Application Processed Successfully";
        //                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Application Processed Successfully!'); '", true);
        //                    return;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            lblmsg0.Text = "Please Select Action";
        //            Failure.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Failure.Visible = true;
        //        lblmsg0.Text = ex.Message;
        //    }
        //}

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
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
                if (ddlStatus.SelectedValue == "5")
                {
                    trheading.Visible = true;
                    tblaction.Visible = true;
                    lblaction.Text = "Remarks if any: ";
                    if (ObjUserInfo.Deptid == "1001") // Industries det For Land Vlaue
                    {
                        trIndsDept.Visible = true;
                        lblApplLandArea.Text = lbllandArea.Text;
                    }
                    else if (ObjUserInfo.Deptid == "1009") // Power det For Power Vlaue
                    {
                        trPowerDept.Visible = true;
                        lblApplPowerReq.Text = lblPowerReq.Text;
                    }
                    else if (ObjUserInfo.Deptid == "1008") //water dept
                    {
                        trWaterDept.Visible = true;
                        lblApplWaterReq.Text = lblWaterReq.Text;
                    }
                    else if (ObjUserInfo.Deptid == "1005")// || DeptID == "Env") //Forest or ENV for Waste
                    {
                        trForestDept1.Visible = true;
                        trForestDept2.Visible = true;
                        lblApplHazWaste.Text = "";
                        lblApplWastedtls.Text = "";
                    }

                }
                else if (ddlStatus.SelectedValue == "4")
                {
                    trheading.Visible = false;
                    tblaction.Visible = true;
                    lblaction.Text = "Please Enter Query Description";

                    trIndsDept.Visible = false;
                    trPowerDept.Visible = false;
                    trWaterDept.Visible = false;
                    trForestDept1.Visible = false;
                    trForestDept2.Visible = false;
                }
                else
                {
                    tblaction.Visible = false;
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