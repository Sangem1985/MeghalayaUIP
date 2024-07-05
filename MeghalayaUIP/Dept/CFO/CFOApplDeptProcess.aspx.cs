using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.CFO
{
    public partial class CFOApplDeptProcess : System.Web.UI.Page
    {

        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
        CFEBAL objcfebal = new CFEBAL();
        CFEDtls objcfeDtls = new CFEDtls();

        CFOBAL objcfobal = new CFOBAL();
        CFODtls objcfoDtls = new CFODtls();
        string userid, result;
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

                    BindCFOApplicatinDetails();
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        public void BindCFOApplicatinDetails()
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
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["status"].ToString() == "PRESCRUTINYPENDING" || Request.QueryString["status"].ToString() == "APPROVALPENDING")
                    {
                        verifypanel.Visible = true;
                        if (Request.QueryString["status"].ToString() == "PRESCRUTINYPENDING")
                        {
                            scrutiny.Visible = true;
                            Approval.Visible = false;
                        }
                        else
                        {
                            scrutiny.Visible = false;
                            Approval.Visible = true;
                        }
                    }
                    else
                    {
                        verifypanel.Visible = false;
                    }
                }
                else
                {
                    verifypanel.Visible = false;
                }

                //Session["Questionnaireid"] = CFEQDID;
                // Session["INVESTERID"] = InvesterID;
                //Session["stage"] = stage;
                // Session["UNITID"] = UnitID;
                if (Session["UNITID"] != null && Session["INVESTERID"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = objcfobal.GetCFOApplicationDetails(Session["UNITID"].ToString(), Session["INVESTERID"].ToString());

                    DataRow row = ds.Tables[0].Rows[0];
                    lblnameUnit.Text = Convert.ToString(row["CFOQD_COMPANYNAME"]);
                    lblunitname1.Text = Convert.ToString(row["CFOQD_COMPANYNAME"]);
                    lblApplNo.Text = Convert.ToString(row["CFOQD_CFEUIDNO"]);
                    lblapplDate.Text = Convert.ToString(row["CFOQD_CREATEDDATE"]);
                    lbl_Name1.Text = Convert.ToString(row["CFOQD_COMPANYNAME"]);
                    lblunitname1Approval.Text = Convert.ToString(row["CFOQD_COMPANYNAME"]);
                    lblApplNoApproval.Text = Convert.ToString(row["CFOQD_CFEUIDNO"]);
                    lblapplDateApproval.Text = Convert.ToString(row["CFOQD_CREATEDDATE"]);
                    lblconstitution.Text = Convert.ToString(row["CONST_TYPE"]);
                    lblProposal.Text = Convert.ToString(row["CFOQD_PROPOSALFOR"]);
                    lblLocation.Text = Convert.ToString(row["DistrictName"]);
                    lblMandal.Text = Convert.ToString(row["Mandalname"]);
                    lblVillage.Text = Convert.ToString(row["VillageName"]);
                    lblExtentland.Text = Convert.ToString(row["CFOQD_TOTALEXTENTLAND"]);
                    lblBuilt.Text = Convert.ToString(row["CFOQD_BUILTUPAREA"]);
                    lblSectors.Text = Convert.ToString(row["CFOQD_SECTOR"]);
                    lblActivity.Text = Convert.ToString(row["LineofActivity_Name"]);
                    lblPollution.Text = Convert.ToString(row["CFOQD_PCBCATEGORY"]);
                    lblIndustry.Text = Convert.ToString(row["INDUSTRYTYPE"]);

                    lblUnitLocation.Text = Convert.ToString(row["CFOQD_UNTLOCATION"]);
                    lblMIDCL.Text = Convert.ToString(row["CFOQD_MIDCLLAND"]);
                    lblproposeEMP.Text = Convert.ToString(row["CFOQD_PROPEMP"]);
                    lblLANDINR.Text = Convert.ToString(row["CFOQD_LANDVALUE"]);
                    lblBuildingINR.Text = Convert.ToString(row["CFOQD_BUILDINGVALUE"]);
                    lblMachineryINR.Text = Convert.ToString(row["CFOQD_PMCOST"]);
                    lblExpectTurnINR.Text = Convert.ToString(row["CFOQD_EXPECTEDTURNOVER"]);
                    lblTPCost.Text = Convert.ToString(row["CFOQD_TOTALPROJCOST"]);
                    lblEnterpriseCat.Text = Convert.ToString(row["CFOQD_ENTERPRISETYPE"]);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                    {
                        lblBNameCompany.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_COMPANYNAME"]);
                        lblTypecompany.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_COMPANYTYPE"]);
                        lblCompanyProposal.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_PROPOSALFOR"]);
                        lblCategory.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REGTYPE"]);
                        lblRegistration.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REGNO"]);
                        lblDate.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REGDATE"]);
                        lblFactory.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_FACTORYTYPE"]);
                        lblName.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REPNAME"]);
                        lblso.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REPSoWoDo"]);
                        lblEmail.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REPEMAIL"]);
                        lblMobile.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REPMOBILE"]);
                        lblAlternative.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REPALTMOBILE"]);
                        lbllandline.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REPTELPHNO"]);
                        lblDoor.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REPDOORNO"]);
                        lblLocality.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REPLOCALITY"]);
                        lblDistrict.Text = Convert.ToString(ds.Tables[1].Rows[0]["DistrictName"]);
                        lblMandals.Text = Convert.ToString(ds.Tables[1].Rows[0]["Mandalname"]);
                        lblVillages.Text = Convert.ToString(ds.Tables[1].Rows[0]["VillageName"]);
                        lblPincode.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REPPINCODE"]);

                        lblAbled.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REPISDIFFABLED"]);
                        lblWomen.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_REPISWOMANENTR"]);

                        lblDevelopment.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_DEVELOPAREA"]);
                        lblARCLIC.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_ARCHTCTLICNO"]);
                        lblARCNAME.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_ARCHTCTNAME"]);
                        lblARCMOBILE.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_ARCHTCTMOBILE"]);
                        lblStrEng.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_SRTCTENGNRNAME"]);
                        lblStrMobile.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_SRTCTENGNRMOBILE"]);
                        lblStrLICNO.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_SRTCTENGNRLICNO"]);
                        lblApproacheRoad.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_APPROACHROADTYPE"]);

                        lblWidening.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_AFFECTEDRDWDNG"]);
                        lblAffectedArea.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_AFFECTEDRDAREA"]);
                        lblDirectMale.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_DIRECTMALE"]);
                        lblDirectFemale.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_DIRECTFEMALE"]);
                        lblEmployees.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_TOTALEMP"]);
                        InMale.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_INDIRECTMALE"]);
                        InFemale.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_INDIRECTFEMALE"]);
                        lblother.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_INDIRECTOTHERS"]);
                        lblroadlength.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_RDCUTLENGTH"]);
                        lblNumber.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOID_RDCUTLOCATIONS"]);
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[2].Rows.Count > 0)
                    {
                        lbllineActivity.Text = Convert.ToString(ds.Tables[2].Rows[0]["LineofActivity_Name"]);
                        lblitem.Text = Convert.ToString(ds.Tables[2].Rows[0]["CFOLM_ITEMNAME"]);
                        lblQuantityper.Text = Convert.ToString(ds.Tables[2].Rows[0]["CFOLM_ITEMANNUALCAPACITY"]);
                        lblQuantity.Text = Convert.ToString(ds.Tables[2].Rows[0]["CFOLM_ITEMVALUE"]);
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
                    {
                        /*lblEstablish.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_CATEGORY_ESTABLISHMENT"]);
                        lblNames.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_NAME"]);
                        lblFather.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_FATHERNAME"]);
                        lblAge.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_AGE"]);
                        lblDesignation.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_DESIGNATION"]);
                        lblMobiles.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_MOBILENO"]);
                        lblMail.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_EMAILID"]);
                        lbldist.Text = Convert.ToString(ds.Tables[3].Rows[0]["DISTRIC"]);
                        lblMandalsmandal.Text = Convert.ToString(ds.Tables[3].Rows[0]["MANDAL"]);
                        lblVILLAS.Text = Convert.ToString(ds.Tables[3].Rows[0]["VILLAGE"]);
                        lblDoors.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_DOOR"]);
                        lblLocalitys.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_LOCALITY"]);
                        lblPins.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_PINCODE"]);
                        lblcontractor.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_NAMECONTRACTOR"]);
                        lblfafname.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_FATHER"]);
                        lblages.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_AGES"]);
                        lblMobileno.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_MOBILE"]);
                        lblEmailId.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_EMAIL"]);
                        lblDistr.Text = Convert.ToString(ds.Tables[3].Rows[0]["DISTRIC"]);
                        lbltaluka.Text = Convert.ToString(ds.Tables[3].Rows[0]["MANDAL"]);
                        lblVillvillage.Text = Convert.ToString(ds.Tables[3].Rows[0]["VILLAGE"]);
                        lblDoorno.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_DOORNO"]);
                        lbllocals.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_LOCALITYNAME"]);
                        lblPincodeno.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFOLD_PIN"]);*/
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[4].Rows.Count > 0)
                    {
                        lblHP.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFOPD_CONNECTEDLOAD"]);
                        lblMaxDemand.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFOPD_MAXIMUMDEMAND"]);
                        lblVoltageLevel.Text = Convert.ToString(ds.Tables[4].Rows[0]["VOLTAGERANGE"]);
                        lblPermise.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFOPD_WRKNGHRSPERDAY"]);
                        lblMonth.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFOPD_WRKNGHRSPERMONTH"]);
                        lblYear.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFOPD_PRODUCTIONDTAE"]);
                        lblPowersupply.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFOPD_POWERDATE"]);
                        lblQuantum.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFOPD_REQLOAD"]);
                        lblEngeryLaod.Text = Convert.ToString(ds.Tables[4].Rows[0]["ENERGYLOAD_NAME"]);
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[5].Rows.Count > 0)
                    {
                        lblDistrics.Text = Convert.ToString(ds.Tables[5].Rows[0]["DistrictName"]);
                        lblMan.Text = Convert.ToString(ds.Tables[5].Rows[0]["Mandalname"]);
                        lblVill.Text = Convert.ToString(ds.Tables[5].Rows[0]["VillageName"]);
                        lbllocal.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_Locality"]);
                        lbNear.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_Landmark"]);
                        lblPincodes.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_Pincode"]);
                        lblheight.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_BUILDINGHT"]);
                        lblEachfloor.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_FLOORHT"]);
                        lblArea.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_PLOTAREA"]);
                        lblbuild.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_BUILDINGAREA"]);
                        lbldriveway.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_DRIVEPROPSED"]);
                        lblcategoryBuild.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_CATEGORYBUILD"]);
                        feeamount.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_FEEAMOUNT"]);
                        lblEast.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_East"]);
                        lblDistanceprop.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_DISTANCEEAST"]);
                        lblwest.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_West"]);
                        lblbUILDDIST.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_DISTANCEWEST"]);
                        lblNorth.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_North"]);
                        lblDistBuild.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_DISTANCENORTH"]);
                        lblSouth.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_South"]);
                        lblbuildProp.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_DISTANCESOUTH"]);
                        lblFireStation.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFOFD_FIRESTATION"]);
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[6].Rows.Count > 0)
                    {
                        lblspice.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_SPECIES"]);
                        lblLength.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_TIMBERLENGTH"]);
                        lblvolume.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_TIMBERVOLUME"]);
                        lblGirth.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_GIRTH"]);
                        lblFirewood.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_ESTIMATED"]);
                        lblpole.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_POLES"]);
                        lblNorths.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_NORTH"]);
                        lblEasts.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_EAST"]);
                        lblWests.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_WEST"]);
                        lblSouths.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_SOUTH"]);
                        lblAddress.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_ADDRESS"]);
                        lbllatitude.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_LATTITUDE"]);
                        lblDegreess.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_DEGREES"]);
                        lblMinte.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_MINUTES"]);
                        lblseconds.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_SECONDS"]);
                        lbllongitude.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_LONGITUDE"]);
                        lblDegrees.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_DEGREE"]);
                        lblMinutes.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_MINUTE"]);
                        lblsecond.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_SECOND"]);
                        lblCoordinates.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_GPSCOORDINATES"]);
                        lblApplication.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_PURPOSEAPPLICATION"]);
                        lblDivision.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_FORESTDIVISION"]);
                        lblinformation.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFOFD_INFORMATION"]);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
                if (ddlStatus.SelectedValue == "6" || ddlStatus.SelectedValue == "17" || ddlStatus.SelectedValue == "11")
                {
                    if (ddlStatus.SelectedValue == "6")
                    {
                        tdquryorrej.Visible = true;
                        tdquryorrejTxtbx.Visible = true;
                        txtRequest.Visible = true;
                        lblremarks.Text = "Please Enter Query Details";
                        //Payment.Visible = false;
                        txtAdditionalAmount.Visible = false;
                    }
                    else if (ddlStatus.SelectedValue == "17")
                    {
                        tdquryorrej.Visible = true;
                        tdquryorrejTxtbx.Visible = true;
                        txtRequest.Visible = true;
                        lblremarks.Text = "Please Enter Rejection Reason";
                        //Payment.Visible = false;
                        txtAdditionalAmount.Visible = false;
                    }
                    else if (ddlStatus.SelectedValue == "11")
                    {
                        //ayment.Visible = true;
                        txtAdditionalAmount.Visible = true;
                        lblremarks.Text = "Please Enter Additional Amount";
                        tdquryorrej.Visible = true;
                        tdquryorrejTxtbx.Visible = true;
                        txtRequest.Visible = false;
                    }
                }
                else if (ddlStatus.SelectedValue == "12")
                {
                    //tblaction.Visible = true;
                    //lblaction.Text = "Please Enter Query Description";

                }
                else
                {
                    //tblaction.Visible = false;
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
                if (ddlStatus.SelectedValue != "")
                {
                    if (ddlStatus.SelectedValue == "6" && (string.IsNullOrWhiteSpace(txtRequest.Text) || txtRequest.Text == "" || txtRequest.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Query Description";
                        Failure.Visible = true;
                        return;
                    }
                    else if (ddlStatus.SelectedValue == "17" && (string.IsNullOrWhiteSpace(txtRequest.Text) || txtRequest.Text == "" || txtRequest.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Rejection Reason";
                        Failure.Visible = true;
                        return;
                    }
                    else if (ddlStatus.SelectedValue == "11" && (string.IsNullOrWhiteSpace(txtAdditionalAmount.Text) || txtAdditionalAmount.Text == "" || txtAdditionalAmount.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Additional Amount";
                        Failure.Visible = true;
                        return;
                    }
                    else if (ddlStatus.SelectedValue == "11" && txtAdditionalAmount.Text.Trim() == "0")
                    {
                        lblmsg0.Text = "Additional Amount should not be Zero";
                        Failure.Visible = true;
                        return;
                    }
                    else
                    {
                        objcfoDtls.Unitid = Session["UNITID"].ToString();
                        objcfoDtls.Investerid = Session["INVESTERID"].ToString();
                        if (ddlStatus != null)
                            objcfoDtls.status = Convert.ToInt32(ddlStatus.SelectedValue);
                        objcfoDtls.UserID = ObjUserInfo.UserID;
                        objcfoDtls.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                        objcfoDtls.ApprovalId = Convert.ToInt32(Session["ApprovalID"].ToString());
                        objcfoDtls.Questionnaireid = Session["Questionnaireid"].ToString();
                        objcfoDtls.Remarks = txtRequest.Text;
                        if (Request.QueryString["status"].ToString() == "PRESCRUTINYPENDING")
                        {
                            if (ddlStatus.SelectedValue == "17")
                            {
                                objcfoDtls.PrescrutinyRejectionFlag = "Y";
                            }
                            else
                            {
                                objcfoDtls.PrescrutinyRejectionFlag = "N";
                            }
                        }
                        objcfoDtls.IPAddress = getclientIP();

                        string valid = objcfobal.UpdateCFODepartmentProcess(objcfoDtls);
                        btnSubmit.Enabled = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Submitted Successfully!');  window.location.href='CFOApplDeptProcess.aspx'", true);
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
        protected void ddlapproval_SelectedIndexChanged(object sender, EventArgs e)
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
                if (ddlapproval.SelectedValue == "16")
                {
                    trapproval.Visible = false;
                    trapprovalupload.Visible = false;
                    trrejection.Visible = true;
                    txtRejection.Visible = true;
                    tdapproverejection.Visible = true;
                    lblremarks.Text = "Please Enter Rejection Reason";
                    tdapprovalAction.Visible = true;
                    btnreject.Visible = true;
                    btnApprove.Visible = false;
                }
                else
                {
                    trapproval.Visible = true;
                    trapprovalupload.Visible = true;
                    trrejection.Visible = false;
                    txtRejection.Visible = false;
                    tdapproverejection.Visible = false;
                    tdapprovalAction.Visible = false;
                    btnreject.Visible = false;
                    btnApprove.Visible = true;
                }

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        protected void btnUpldapproval_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fuApproval.HasFile)
                {
                    Error = validations(fuApproval);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + Session["INVESTERID"].ToString() + "\\"
                         + Session["Questionnaireid"].ToString() + "\\" + "ApprovalDocuments" + "\\" + "31" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        fuApproval.PostedFile.SaveAs(serverpath + "\\" + fuApproval.PostedFile.FileName);

                        CFOAttachments objBldngPlan = new CFOAttachments();
                        objBldngPlan.UNITID = Convert.ToString(Session["UNITID"]);
                        objBldngPlan.Questionnareid = Session["Questionnaireid"].ToString();
                        objBldngPlan.ApprovalID = "31";
                        objBldngPlan.DeptID = "0";
                        objBldngPlan.FilePath = serverpath + fuApproval.PostedFile.FileName;
                        objBldngPlan.FileName = fuApproval.PostedFile.FileName;
                        objBldngPlan.FileType = fuApproval.PostedFile.ContentType;
                        objBldngPlan.FileDescription = "ApprovalDocuments";
                        objBldngPlan.CreatedBy = Session["INVESTERID"].ToString();
                        objBldngPlan.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objBldngPlan);
                        if (result != "")
                        {
                            hplApproval.Text = fuApproval.PostedFile.FileName;
                            hplApproval.NavigateUrl = serverpath;
                            hplApproval.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                btnSubmit_Click(sender, e);
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
        protected void btnApprove_Click(object sender, EventArgs e)
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
                if (ddlapproval.SelectedValue != "")
                {
                    if (ddlapproval.SelectedValue == "16")
                    {
                        if ((ddlapproval.SelectedValue == "16") && (string.IsNullOrWhiteSpace(txtRejection.Text) || txtRejection.Text == "" || txtRejection.Text == null))
                        {
                            if (ddlapproval.SelectedValue == "16")
                            {
                                lblmsg0.Text = "Please Enter Rejection Reason";
                                Failure.Visible = true;
                                return;
                            }

                        }
                    }

                    else
                    {
                        objcfoDtls.Unitid = Session["UNITID"].ToString();
                        objcfoDtls.Investerid = Session["INVESTERID"].ToString();
                        if (ddlStatus != null)
                            objcfoDtls.status = Convert.ToInt32(ddlapproval.SelectedValue);
                        objcfoDtls.UserID = ObjUserInfo.UserID;
                        objcfoDtls.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                        objcfoDtls.ApprovalId = Convert.ToInt32(Session["ApprovalID"].ToString());
                        objcfoDtls.Questionnaireid = Session["Questionnaireid"].ToString();
                        if (ddlapproval.SelectedValue == "16")
                        { objcfoDtls.Remarks = txtRejection.Text; }
                        if (ddlapproval.SelectedValue == "13")
                        { objcfoDtls.ReferenceNumber = txtreferenceno.Text; }
                        objcfoDtls.PrescrutinyRejectionFlag = "N";
                        objcfoDtls.IPAddress = getclientIP();

                        string valid = objcfobal.UpdateCFODepartmentProcess(objcfoDtls);
                        btnSubmit.Enabled = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Submitted Successfully!');  window.location.href='CFEApplDeptProcess.aspx'", true);
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
        public string validations(FileUpload Attachment)
        {
            try
            {
                int slno = 1; string Error = "";
                if (Attachment.PostedFile.ContentType != "application/pdf"
                     || !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                {

                    if (Attachment.PostedFile.ContentType != "application/pdf")
                    {
                        Error = Error + slno + ". Please Upload PDF Documents only \\n";
                        slno = slno + 1;
                    }
                    if (!ValidateFileName(Attachment.PostedFile.FileName))
                    {
                        Error = Error + slno + ". Document name should not contain symbols like  <, >, %, $, @, &,=, / \\n";
                        slno = slno + 1;
                    }
                    else if (!ValidateFileExtension(Attachment))
                    {
                        Error = Error + slno + ". Document should not contain double extension (double . ) \\n";
                        slno = slno + 1;
                    }
                }
                return Error;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static bool ValidateFileName(string fileName)
        {
            try
            {
                string pattern = @"[<>%$@&=!:*?|]";

                if (Regex.IsMatch(fileName, pattern))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            { throw ex; }
        }
        protected void btnreject_Click(object sender, EventArgs e)
        {
            try
            {
                btnApprove_Click(sender, e);
            }
            catch (Exception ex)
            { }
        }
        public static bool ValidateFileExtension(FileUpload Attachment)
        {
            try
            {
                string Attachmentname = Attachment.PostedFile.FileName;
                string[] fileType = Attachmentname.Split('.');
                int i = fileType.Length;

                if (i == 2)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            { throw ex; }
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
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/CFO/CFOApplDeptView.aspx?status=" + Request.QueryString["status"].ToString());
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                //throw ex;
            }
        }
    }
}