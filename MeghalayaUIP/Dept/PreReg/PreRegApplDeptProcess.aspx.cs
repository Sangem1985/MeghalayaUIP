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
                    DataSet ds = new DataSet();
                    ds = PreBAL.GetPreRegNodelOfficer(prd);


                    DataRow row = ds.Tables[0].Rows[0];
                    lbl_regdate.Text = row["Udyamno"].ToString();
                    lbl_Udyam.Text = row["GSTNNO"].ToString();
                    if (!row.IsNull("Udyamno"))
                        lbl_GSTIN.Text = row["Udyamno"].ToString();
                    if (!row.IsNull("REP_NAME"))
                        lbl_Name.Text = lbl_Name1.Text = lblunitname1.Text = row["REP_NAME"].ToString();
                    if (!row.IsNull("REP_MOBILE"))
                        lbl_Mobile.Text = lbl_Mobile1.Text = row["REP_MOBILE"].ToString();
                    if (!row.IsNull("REP_EMAIL"))
                        Lbl_Email.Text = row["REP_EMAIL"].ToString();
                    if (!row.IsNull("REP_LOCALITY"))
                        Lbl_Locality.Text = row["REP_LOCALITY"].ToString();
                    if (!row.IsNull("REP_DISTRICT"))
                        lbl_Distict.Text = row["REP_DISTRICT"].ToString();
                    if (!row.IsNull("REP_MANDAL"))
                        lbl_Mandal.Text = row["REP_MANDAL"].ToString();
                    if (!row.IsNull("REP_VILLAGE"))
                        lbl_Village.Text = row["REP_VILLAGE"].ToString();
                    if (!row.IsNull("REP_PINCODE"))
                        lbl_Pincode.Text = row["REP_PINCODE"].ToString();
                    if (!row.IsNull("REP_PINCODE"))
                        lbl_Pincode.Text = row["REP_PINCODE"].ToString();

                    if (!row.IsNull("UNIT_DOORNO"))
                        lbl_drno.Text = row["UNIT_DOORNO"].ToString();
                    if (!row.IsNull("UNIT_LOCALITY"))
                        lbl_Pro_loc.Text = row["UNIT_LOCALITY"].ToString();
                    if (!row.IsNull("UNIT_DISTRICT"))
                        lbl_pro_dis.Text = row["UNIT_DISTRICT"].ToString();
                    if (!row.IsNull("UNIT_MANDAL"))
                        lbl_Pro_Man.Text = row["UNIT_MANDAL"].ToString();
                    if (!row.IsNull("UNIT_VILLAGE"))
                        lbl_Pro_vill.Text = row["UNIT_VILLAGE"].ToString();
                    if (!row.IsNull("UNIT_PICODE"))
                        lbl_Pro_Pin.Text = row["UNIT_PICODE"].ToString();
                    if (!row.IsNull("PROJECT_NOA"))
                        lbl_NatureofAct.Text = row["PROJECT_NOA"].ToString();
                    if (!row.IsNull("PROJECT_MMSA"))
                        lbl_Mainmanu.Text = row["PROJECT_MMSA"].ToString();
                    if (!row.IsNull("PROJECT_PMSP"))
                        lbl_pro_manu.Text = row["PROJECT_PMSP"].ToString();
                    if (!row.IsNull("PROJECT_DCP"))
                        lbl_Dateofcomm.Text = row["PROJECT_DCP"].ToString();

                    if (!row.IsNull("PROJECT_PROD_NO"))
                        lbl_existing.Text = row["PROJECT_PROD_NO"].ToString();
                    if (!row.IsNull("PROJECT_AC"))
                        lbl_annual.Text = row["PROJECT_AC"].ToString();
                    if (!row.IsNull("PROJECT_EPC"))
                        lbl_estimatedcost.Text = row["PROJECT_EPC"].ToString();
                    //if (!row.IsNull("PROJECT_LAND"))
                    //    lbl_estimatedcost.Text = row["PROJECT_EPC"].ToString();
                    if (!row.IsNull("PROJECT_LAND"))
                        lbl_land.Text = row["PROJECT_LAND"].ToString();
                    if (!row.IsNull("PROJECT_CIVIL_CONSTRCTION"))
                        lbl_civil.Text = row["PROJECT_CIVIL_CONSTRCTION"].ToString();
                    if (!row.IsNull("PROJECT_PM"))
                        lbl_plant.Text = row["PROJECT_PM"].ToString();
                    if (!row.IsNull("PROJECT_MMPP"))
                        lbl_main_raw.Text = row["PROJECT_MMPP"].ToString();
                    if (!row.IsNull("PROJECT_BUILDING"))
                        lbl_building.Text = row["PROJECT_BUILDING"].ToString();
                    //if (!row.IsNull("lbl_water"))
                    //    lbl_water.Text = row["lbl_water"].ToString();
                    //if (!row.IsNull("PROJECT_BUILDING"))
                    //    lbl_power.Text = row["PROJECT_BUILDING"].ToString();
                    //if (!row.IsNull("PROJECT_BUILDING"))
                    //    lbl_det_waste.Text = row["PROJECT_BUILDING"].ToString();
                    if (!row.IsNull("PROJECT_hazardous"))
                        lbl_det_hazar.Text = row["PROJECT_hazardous"].ToString();
                    if (!row.IsNull("PROJECT_IFC"))
                        lbl_investment.Text = row["PROJECT_IFC"].ToString();
                    if (!row.IsNull("PROJECT_DFA"))
                        lbl_durable.Text = row["PROJECT_DFA"].ToString();
                    if (!row.IsNull("PROJECT_UM"))
                        lbl_unitofmeasure.Text = row["PROJECT_UM"].ToString();
                    if (!row.IsNull("PROJECT_BS"))
                        lbl_buildingshed.Text = row["PROJECT_BS"].ToString();
                    if (!row.IsNull("PROJECT_WATER"))
                        lbl_waterinr.Text = row["PROJECT_WATER"].ToString();
                    if (!row.IsNull("PROJECT_ELECTRIC"))
                        lbl_electricity.Text = row["PROJECT_ELECTRIC"].ToString();
                    if (!row.IsNull("PROJECT_WC"))
                        lbl_working.Text = row["PROJECT_WC"].ToString();
                    if (!row.IsNull("FRD_CS"))
                        lbl_capital.Text = row["FRD_CS"].ToString();
                    if (!row.IsNull("FRD_PE"))
                        lbl_promoter.Text = row["FRD_PE"].ToString();
                    if (!row.IsNull("FRD_LOAN"))
                        lbl_loan.Text = row["FRD_LOAN"].ToString();
                    lbl_Dateofcomm.Text = lblapplDate.Text = Convert.ToDateTime(lbl_Dateofcomm.Text).ToString("dd-MM-yyyy"); ;


                    DataTable dtpRrodSales = new DataTable();
                    gvPreRegDtls.DataSource = ds.Tables[2];
                    gvPreRegDtls.DataBind();

                    grd_Statusofapp.DataSource = ds.Tables[1];
                    grd_Statusofapp.DataBind();

                    //grdQueries.DataSource = null;
                    grdQueries.DataBind();

                    //grdQryAttachments.DataSource = null;
                    grdQryAttachments.DataBind();

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
                    if ((ddlStatus.SelectedValue == "4") && (string.IsNullOrWhiteSpace(txtRequest.Text) || txtRequest.Text == "" || txtRequest.Text == null))
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
                        string valid = PreBAL.PreRegApprovals(prd);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Submitted Successfully!');  window.location.href='PreRegApplDeptDashBoard.aspx'", true);
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
                    tblaction.Visible = true;
                    lblaction.Text = "Remarks if any: ";
                    if (ObjUserInfo.Deptid == "1001") // Industries det For Land Vlaue
                    {
                        trIndsDept.Visible = true;
                        lblApplLandArea.Text = lbl_land.Text;
                    }
                    else if (ObjUserInfo.Deptid == "1009") // Power det For Power Vlaue
                    {
                        trPowerDept.Visible = true;
                        lblApplPowerReq.Text = lbl_power.Text;
                    }
                    else if (ObjUserInfo.Deptid == "1008") //water dept
                    {
                        trWaterDept.Visible = true;
                        lblApplWaterReq.Text = lbl_water.Text;
                    }
                    else if (ObjUserInfo.Deptid == "1005")// || DeptID == "Env") //Forest or ENV for Waste
                    {
                        trForestDept1.Visible = true;
                        trForestDept2.Visible = true;
                        lblApplHazWaste.Text = "";
                        lblApplWastedtls.Text = "";
                    }

                }
                else if (ddlStatus.SelectedValue == "5")
                {
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