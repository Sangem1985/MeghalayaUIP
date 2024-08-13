using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.CommonClass;
using MeghalayaUIP.BAL.CFEBLL;
using System.Text.RegularExpressions;

namespace MeghalayaUIP.Dept.CFE
{
    public partial class CFEApplDeptProcess : System.Web.UI.Page
    {
        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
        CFEBAL objcfebal = new CFEBAL();
        CFEDtls objcfeDtls = new CFEDtls();
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
                    BindCFEApplicatinDetails();
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        public void BindCFEApplicatinDetails()
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
                    string status = Convert.ToString(Request.QueryString["status"]);
                    if (status.Contains("PRESCRUTINYPENDING") || status.Contains("APPROVALPENDING"))
                    {
                        verifypanel.Visible = true;
                        if (status.Contains("PRESCRUTINYPENDING"))
                        {
                            lblVerf.Text = "Scrutiny Verification of Application";
                            scrutiny.Visible = true;
                            Approval.Visible = false;
                        }
                        else
                        {
                            lblVerf.Text = "Approval Process";
                            scrutiny.Visible = false;
                            Approval.Visible = true;
                        }
                    }
                    else
                    {
                        verifypanel.Visible = false;
                    }
                    if (Request.QueryString["status"].ToString().ToLower().Contains("offline"))
                    {
                        headingThree.Visible = false;
                        headingFour.Visible = false;
                        if (Request.QueryString["status"].ToString() == "OFFLINEPENDING" || Request.QueryString["status"].ToString() == "OFFLINEPENDINGWITHIN" || Request.QueryString["status"].ToString() == "OFFLINEPENDINGBEYOND")
                        {

                            Offlineverifypanel.Visible = true;
                        }
                    }
                }
                else
                {
                    verifypanel.Visible = false;
                    Offlineverifypanel.Visible = false;
                }

                //Session["Questionnaireid"] = CFEQDID;
                // Session["INVESTERID"] = InvesterID;
                //Session["stage"] = stage;
                // Session["UNITID"] = UnitID;
                if (Session["UNITID"] != null && Session["INVESTERID"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = objcfebal.GetCFEApplicationDetails(Session["UNITID"].ToString(), Session["INVESTERID"].ToString());

                    if (ObjUserInfo.Deptid == "10") //Labour Details
                    {
                        LabourDet.Visible = true;
                    }
                    else { LabourDet.Visible = false; }

                    if (ObjUserInfo.Deptid == "14") //POWER DETAILS
                    {
                        PowerDetails.Visible = true;
                    }
                    else { PowerDetails.Visible = false; }

                    if (ObjUserInfo.Deptid == "9") //FIRE DETAILS
                    {
                        Fires.Visible = true;
                    }
                    else { Fires.Visible = false; }

                    if (ObjUserInfo.Deptid == "4") //FOREST DETAILS
                    {
                        ForestDet.Visible = true;
                    }
                    else { ForestDet.Visible = false; }

                    if (ObjUserInfo.Deptid == "12") //HAZARADOUS DETAILS
                    {
                        HazradousWaterDetails.Visible = true;
                    }
                    else { HazradousWaterDetails.Visible = false; }

                    if (ObjUserInfo.Deptid == "13") //EXPLOSIVE DETAILS
                    {
                        Explosive.Visible = true;
                    }
                    else { Explosive.Visible = false; }

                    if (ObjUserInfo.Deptid == "13") //FUEL DETAILS
                    {
                        FuelDet.Visible = true;
                    }
                    else { FuelDet.Visible = false; }

                    if (ObjUserInfo.Deptid == "14") //DGSET DETAILS
                    {
                        DGSETDET.Visible = true;
                    }
                    else { DGSETDET.Visible = false; }

                    if (ObjUserInfo.Deptid == "18") //CEIG DETAILS
                    {
                        CEIGDET.Visible = true;
                    }
                    else { CEIGDET.Visible = false; }

                    if (ObjUserInfo.Deptid == "6") //TAX PROFESSIONAL DETAILS
                    {
                        TaxDet.Visible = true;
                    }
                    else { TaxDet.Visible = false; }

                    if (ObjUserInfo.Deptid == "5") //WATER DETAILS
                    {
                        waterConn.Visible = true;
                    }
                    else { waterConn.Visible = false; }


                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        lblnameUnit.Text = lblunitname1.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_COMPANYNAME"]);
                        lblApplNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_CFEUIDNO"]);
                        lblapplDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_CREATEDDATE"]);

                        lblconstitution.Text = Convert.ToString(ds.Tables[0].Rows[0]["CONST_TYPE"]);
                        lblProposal.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PROPOSALFOR"]);
                        lblLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
                        lblMandal.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mandalname"]);
                        lblVillage.Text = Convert.ToString(ds.Tables[0].Rows[0]["VillageName"]);
                        lblExtentland.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_TOTALEXTENTLAND"]);
                        lblBuilt.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_BUILTUPAREA"]);
                        lblSectors.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_SECTOR"]);
                        lblActivity.Text = Convert.ToString(ds.Tables[0].Rows[0]["LineofActivity_Name"]);
                        lblPollution.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PCBCATEGORY"]);
                        lblIndustry.Text = Convert.ToString(ds.Tables[0].Rows[0]["INDUSTRYTYPE"]);

                        lblUnitLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_UNTLOCATION"]);
                        lblMIDCL.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_MIDCLLAND"]);
                        lblproposeEMP.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PROPEMP"]);
                        lblLANDINR.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_LANDVALUE"]);
                        lblBuildingINR.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_BUILDINGVALUE"]);
                        lblMachineryINR.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PMCOST"]);
                        lblExpectTurnINR.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_EXPECTEDTURNOVER"]);
                        lblTPCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_TOTALPROJCOST"]);
                        lblEnterpriseCat.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_ENTERPRISETYPE"]);
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                    {
                        lblBNameCompany.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_COMPANYNAME"]);
                        lblTypecompany.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_COMPANYTYPE"]);
                        lblCompanyProposal.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_PROPOSALFOR"]);
                        lblCategory.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REGTYPE"]);
                        lblRegistration.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REGNO"]);
                        lblDate.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REGDATE"]);
                        lblFactory.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_FACTORYTYPE"]);
                        lblName.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REPNAME"]);
                        lblso.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REPSoWoDo"]);
                        lblEmail.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REPEMAIL"]);
                        lblMobile.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REPMOBILE"]);
                        lblAlternative.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REPALTMOBILE"]);
                        lbllandline.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REPTELPHNO"]);
                        lblDoor.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REPDOORNO"]);
                        lblLocality.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REPLOCALITY"]);
                        lblDistrict.Text = Convert.ToString(ds.Tables[1].Rows[0]["DistrictName"]);
                        lblMandals.Text = Convert.ToString(ds.Tables[1].Rows[0]["Mandalname"]);
                        lblVillages.Text = Convert.ToString(ds.Tables[1].Rows[0]["VillageName"]);
                        lblPincode.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REPPINCODE"]);
                        lblAbled.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REPISDIFFABLED"]);
                        lblWomen.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_REPISWOMANENTR"]);
                        lblDevelopment.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_DEVELOPAREA"]);
                        lblARCLIC.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_ARCHTCTLICNO"]);
                        lblARCNAME.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_ARCHTCTNAME"]);
                        lblARCMOBILE.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_ARCHTCTMOBILE"]);
                        lblStrEng.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_SRTCTENGNRNAME"]);
                        lblStrMobile.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_SRTCTENGNRMOBILE"]);
                        lblStrLICNO.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_SRTCTENGNRLICNO"]);
                        lblApproacheRoad.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_APPROACHROADTYPE"]);

                        lblWidening.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_AFFECTEDRDWDNG"]);
                        if (lblWidening.Text == "Yes")
                        {
                            Extend.Visible = true;
                            lblAffectedArea.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_AFFECTEDRDAREA"]);
                        }
                        else
                        {
                            Extend.Visible = true;
                        }
                        lblDirectMale.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_DIRECTMALE"]);
                        lblDirectFemale.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_DIRECTFEMALE"]);
                        lblEmployees.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_TOTALEMP"]);
                        InMale.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_INDIRECTMALE"]);
                        InFemale.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_INDIRECTFEMALE"]);
                        lblother.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_INDIRECTOTHERS"]);
                        lblroadlength.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_RDCUTLENGTH"]);
                        lblNumber.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_RDCUTLOCATIONS"]);
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[2].Rows.Count > 0)
                    {
                        //lbllineActivity.Text = Convert.ToString(ds.Tables[2].Rows[0]["LineofActivity_Name"]);

                        divManf.Visible = true;
                        if (divManf.Visible == true)
                        {
                            gvManufacture.DataSource = ds.Tables[2];
                            gvManufacture.DataBind();
                        }
                        else { divManf.Visible = true; }

                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
                    {
                        // lbllineActivity.Text = Convert.ToString(ds.Tables[3].Rows[0]["LineofActivity_Name"]);
                        gvRwaMaterial.DataSource = ds.Tables[3];
                        gvRwaMaterial.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[4].Rows.Count > 0)
                    {
                        LabourDet.Visible = true;
                        if (LabourDet.Visible == true)
                        {
                            lblEstablish.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CATEGORY_ESTABLISHMENT"]);
                            lblNames.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_NAME"]);
                            lblFather.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_FATHERNAME"]);
                            lblAge.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_AGE"]);
                            lblDesignation.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_DESIGNATION"]);
                            lblMobiles.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MOBILENO"]);
                            lblMail.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_EMAILID"]);
                            lbldist.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_DISTRICSID"]);
                            lblMandalsmandal.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MANDALSID"]);
                            lblVILLAS.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_VILLAGESID"]);
                            lblDoors.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_DOOR"]);
                            lblLocalitys.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_LOCALITY"]);
                            lblPins.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_PINCODE"]);

                            divsupervision.Visible = true;
                            if (divsupervision.Visible == true)
                            {
                                lblMangerName.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MANAGERNAME"]);
                                lblManagerMobile.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MANAGERMOBILENO"]);
                                //  ManagerAge.Text = Convert.ToString(ds.Tables[4].Rows[0][""]);
                                ManagerDesignation.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MANAGEREMAILID"]);
                                ManagerFather.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MANAGERFATHERNAME"]);
                                lblManagerEmail.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MANAGERDOOR"]);
                                lblManagerDistrict.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MANAGERLOCALITY"]);
                                lblManagerMandal.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MANAGERDISTRICSID"]);
                                lblManagerVillage.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MANAGERMANDALSID"]);
                                lblManagerDoor.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MANAGERVILLAGESID"]);
                                lblManagerLocality.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MANAGERPINCODE"]);
                                lblManagerPincode.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MANAGERDESIGNATION"]);

                            }
                            else { divsupervision.Visible = false; }


                            div4questions.Visible = true;
                            if (div4questions.Visible == true)
                            {
                                lblNatureOfEmp.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_NATUREOFWORKLABOUREMP"]);
                                lblEstDateBuild.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_ESTDATEBUILDING"]);
                                lblContractEmp.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MAXNUMBEROFCONTRACTEMP"]);
                                lblBuildingWork.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_ESTDATEOFCONSTRUCTIONWORK"]);
                            }
                            else { div4questions.Visible = false; }

                            div5questions.Visible = true;
                            if (div5questions.Visible == true)
                            {
                                lblMigrantWorkmen.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MAXNUMBERMIGRANTESTDATE"]);
                                lblPreceding5Years.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CONTRACTORCONVICTED5YEARS"]);
                                lblRevokingLic.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_REVOKINGSUSPENDINGLIC"]);
                                lblEstPast5Years.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_ESTPAST5YEARSNATUREOFWORK"]);
                                lblBusiness.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_INDUSTRYMANUOCCUPATIONEST"]);

                            }
                            else { div5questions.Visible = false; }

                            divContractorDtls.Visible = true;
                            if (divContractorDtls.Visible == true)
                            {
                                lblcontractor.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CONTRACTORNAMECONTRACTOR"]);
                                lblfafname.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CONTRACTORFATHER"]);
                                lblages.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CONTRACTORAGES"]);
                                lblMobileno.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CONTRACTORMOBILE"]);
                                lblEmailId.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CONTRACTOREMAIL"]);
                                lblDistr.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CONTRACTORDISTID"]);
                                lbltaluka.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CONTRACTORMANDALID"]);
                                lblVillvillage.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CONTRACTORVILLAGEID"]);
                                lblDoorno.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CONTRACTORDOORNO"]);
                                lbllocals.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CONTRACTORLOCALITYNAME"]);
                                lblPincodeno.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CONTRACTORPIN"]);

                            }
                            else { divContractorDtls.Visible = false; }

                            divAgentDtls.Visible = true;
                            if (divAgentDtls.Visible == true)
                            {

                                lblAgentName.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_AGENTNAME"]);
                                lblAgentDoor.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_AGENTDOORNO"]);
                                lblAgentLocality.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_AGENTLOCALITY"]);
                                lblAgentDistrict.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_AGENTDISTRICT"]);
                                lblAgentMandal.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_AGENTMANDAL"]);
                                AgetVillage.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_AGENTVILLAGE"]);
                                lblAgentPincode.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_AGENTPINCODE"]);
                            }
                            else { divAgentDtls.Visible = false; }

                        }
                        else { LabourDet.Visible = false; }

                    }

                    if (LabourDet.Visible == true)
                    {
                        divContrLabr.Visible = true;
                        if (divContrLabr.Visible == true)
                        {
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[5].Rows.Count > 0)
                            {
                                GVLabour.DataSource = ds.Tables[5];
                                GVLabour.DataBind();
                            }
                        }
                        else { divContrLabr.Visible = false; }

                        divMigrLabr.Visible = true;
                        if (divMigrLabr.Visible == true)
                        {
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[6].Rows.Count > 0)
                            {
                                GVMigrant.DataSource = ds.Tables[6];
                                GVMigrant.DataBind();
                            }
                        }
                        else { divMigrLabr.Visible = false; }
                    }
                    else { LabourDet.Visible = false; }

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[7].Rows.Count > 0)
                    {
                        // PowerDetails.Visible = true;
                        if (PowerDetails.Visible == true)
                        {
                            lblHP.Text = Convert.ToString(ds.Tables[7].Rows[0]["CFEPD_CONNECTEDLOAD"]);
                            lblMaxDemand.Text = Convert.ToString(ds.Tables[7].Rows[0]["CFEPD_MAXIMUMDEMAND"]);
                            lblVoltageLevel.Text = Convert.ToString(ds.Tables[7].Rows[0]["VOLTAGERANGE"]);
                            if (lblPermise.Text != "")
                            {
                                services.Visible = false;
                                lblPermise.Text = Convert.ToString(ds.Tables[7].Rows[0]["CFEPD_WRKNGHRSPERDAY"]);
                            }
                            else { services.Visible = false; }

                            //lblDay.Text= Convert.ToString(ds.Tables[7].Rows[0]["CFEPD_WRKNGHRSPERDAY"]);
                            lblMonth.Text = Convert.ToString(ds.Tables[7].Rows[0]["CFEPD_WRKNGHRSPERMONTH"]);
                            lblYear.Text = Convert.ToString(ds.Tables[7].Rows[0]["CFEPD_PRODUCTIONDTAE"]);
                            lblPowersupply.Text = Convert.ToString(ds.Tables[7].Rows[0]["CFEPD_POWERDATE"]);
                            lblQuantum.Text = Convert.ToString(ds.Tables[7].Rows[0]["CFEPD_REQLOAD"]);
                            //   lblEngeryLaod.Text = Convert.ToString(ds.Tables[7].Rows[0]["ENERGYLOAD_NAME"]);
                        }
                        else { PowerDetails.Visible = false; }

                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[8].Rows.Count > 0)
                    {
                        //  Fires.Visible = true;
                        if (Fires.Visible == true)
                        {
                            lblDistrics.Text = Convert.ToString(ds.Tables[8].Rows[0]["DistrictName"]);
                            lblMan.Text = Convert.ToString(ds.Tables[8].Rows[0]["Mandalname"]);
                            lblVill.Text = Convert.ToString(ds.Tables[8].Rows[0]["VillageName"]);
                            lbllocal.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_Locality"]);
                            lbNear.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_Landmark"]);
                            lblPincodes.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_Pincode"]);
                            lblheight.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_BUILDINGHT"]);
                            lblEachfloor.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_FLOORHT"]);
                            lblArea.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_PLOTAREA"]);
                            lblbuild.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_BUILDINGAREA"]);
                            lbldriveway.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_DRIVEPROPSED"]);
                            lblcategoryBuild.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_CATEGORYBUILD"]);
                            feeamount.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_FEEAMOUNT"]);
                            lblEast.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_East"]);
                            lblDistanceprop.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_DISTANCEEAST"]);
                            lblwest.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_West"]);
                            lblbUILDDIST.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_DISTANCEWEST"]);
                            lblNorth.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_North"]);
                            lblDistBuild.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_DISTANCENORTH"]);
                            lblSouth.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_South"]);
                            lblbuildProp.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_DISTANCESOUTH"]);
                            lblFireStation.Text = Convert.ToString(ds.Tables[8].Rows[0]["CFEFD_FIRESTATION"]);

                        }
                        else { Fires.Visible = false; }



                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[9].Rows.Count > 0)
                    {
                        // ForestDet.Visible = true;
                        if (ForestDet.Visible == true)
                        {
                            lblspice.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_SPECIES"]);
                            lblLength.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_TIMBERLENGTH"]);
                            lblvolume.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_TIMBERVOLUME"]);
                            lblGirth.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_GIRTH"]);
                            lblFirewood.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_ESTIMATED"]);
                            lblpole.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_POLES"]);
                            lblNorths.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_NORTH"]);
                            lblEasts.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_EAST"]);
                            lblWests.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_WEST"]);
                            lblSouths.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_SOUTH"]);
                            lblAddress.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_ADDRESS"]);
                            lbllatitude.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_LATTITUDE"]);
                            lblDegreess.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_DEGREES"]);
                            lblMinte.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_MINUTES"]);
                            lblseconds.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_SECONDS"]);
                            lbllongitude.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_LONGITUDE"]);
                            lblDegrees.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_DEGREE"]);
                            lblMinutes.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_MINUTE"]);
                            lblsecond.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_SECOND"]);
                            lblCoordinates.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_GPSCOORDINATES"]);
                            lblApplication.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_PURPOSEAPPLICATION"]);
                            lblDivision.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_FORESTDIVISION"]);
                            lblinformation.Text = Convert.ToString(ds.Tables[9].Rows[0]["CFEFD_INFORMATION"]);
                        }
                        else { ForestDet.Visible = false; }



                        // 

                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[10].Rows.Count > 0)
                    {
                        //  HazradousWaterDetails.Visible = true;
                        if (HazradousWaterDetails.Visible == true)
                        {
                            lblReqtrick.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_AUTHORIZATIONREQ"]);
                            lblQuantitywaste.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_WASTEHANDLEANNUM"]);
                            lblMetrictons.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_WASTESTOREDTIME"]);
                            lblhandleannum.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_QUANTITYWASTEANNUM"]);
                            lblWastestored.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_QUANTITYSTOREDTIME"]);
                            lblYearProduct.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_YEAROFPRODUCTION"]);
                            lblindustrywork.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_INDUSTRYWORK"]);

                        }
                        else { HazradousWaterDetails.Visible = false; }

                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[11].Rows.Count > 0)
                    {
                        // Explosive.Visible = true;
                        if (Explosive.Visible == true)
                        {
                            lblExplosive.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_EXPLOSIVESITE"]);
                            lblRoadvan.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_EXPLOSIVEROADVAN"]);
                            lblCriminal.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_CRIMINAL1973"]);
                            if (lblCriminal.Text == "Yes")
                            {
                                Details.Visible = true;
                                lblChapterDetails.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_DETAIL"]);
                            }
                            lblLicPossess.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_EXPLOSIVE1884"]);
                            if (lblLicPossess.Text == "Yes")
                            {
                                LicDetails.Visible = true;
                                lblDetails.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_DETAILS"]);
                            }
                            lblApprovals.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_APPROVAL101"]);

                            if (lblApprovals.Text == "Yes")
                            {
                                approvaldet.Visible = true;
                                lblapprovalDet.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_APPROVALDETAILS"]);
                            }
                            lblRelevant.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_ANYINFORMATION"]);
                        }
                        else { Explosive.Visible = false; }

                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[12].Rows.Count > 0)
                    {
                        //  Explosive.Visible = true;
                        if (Explosive.Visible == true)
                        {
                            GVEXPLOSIVE.DataSource = ds.Tables[12];
                            GVEXPLOSIVE.DataBind();
                        }
                        else { Explosive.Visible = false; }

                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[13].Rows.Count > 0)
                    {
                        // FuelDet.Visible = true;

                        if (FuelDet.Visible == true)
                        {
                            lblPetrolNoc.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_NOCPETROLPUMP"]);
                            lblFuelNoc.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_NOCREQ"]);
                            lblFuelDistrict.Text = Convert.ToString(ds.Tables[13].Rows[0]["DistrictName"]);
                            lblFuelMandal.Text = Convert.ToString(ds.Tables[13].Rows[0]["Mandalname"]);
                            lblFuelVillage.Text = Convert.ToString(ds.Tables[13].Rows[0]["VillageName"]);
                            lblRoad.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_LOCATEDROAD"]);
                            lblNameESt.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_NAMEEST"]);
                            lblHoldingCert.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_LANDHOLDINGNO"]);
                            lblUnderLease.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_LANDLEASER"]);
                            lblDeedRegNo.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_REGNO"]);
                            lblLandHolding.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_AREALANDHOLDINGNO"]);
                            lblFuelNorth.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_NORTH"]);
                            lblFuelEast.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_EAST"]);
                            lblFuelSouth.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_SOUTH"]);
                            lblFuelwest.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_WEST"]);
                            lblFrontage.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_FRONTAGE"]);
                            lblDepth.Text = Convert.ToString(ds.Tables[13].Rows[0]["CFEPD_DEPTH"]);
                        }
                        else { FuelDet.Visible = false; }

                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[14].Rows.Count > 0)
                    {
                        // DGSETDET.Visible = true;
                        if (DGSETDET.Visible == true)
                        {
                            lblDGSurveyNo.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_LOCDOORNO"]);
                            lblDGLocality.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_LOCALITY"]);
                            lblDGLandmark.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_LANDMARK"]);
                            lblDGDistrict.Text = Convert.ToString(ds.Tables[14].Rows[0]["DistrictName"]);
                            lblDGMandal.Text = Convert.ToString(ds.Tables[14].Rows[0]["Mandalname"]);
                            lblDGVillage.Text = Convert.ToString(ds.Tables[14].Rows[0]["VillageName"]);
                            lblDGPincode.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_LOCPINCODE"]);
                            lblDGNameSupply.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_SUPPLIERNAME"]);
                            lblLoadConnect.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_TOTLCONNECTEDLOAD"]);
                            lblTotalLoad.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_TOTLPROPDGSETLOAD"]);
                            lblInterlock.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_INTERLOCKPROVIDED"]);
                            LBLdgMotor.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_MOTORLOAD"]);
                            lblDGLight.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_LIGHTSFANSLOAD"]);
                            lblDGOther.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_OTHERLOAD"]);
                            lblGenRunMode.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_GENRUNNINGMODE"]);
                            lblExpectedCompletion.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_WRKCOMPLETIONDATE"]);
                            lblDateInstall.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_INSTLATIONSTARTDATE"]);
                            lblExpectedDate.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_COMMISSIONINGDATE"]);
                            lblDGNameSup.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_SUPERVISORNAME"]);
                            lblSupLicNo.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_SUPERVISORLICNO"]);
                            lblinternalName.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_CONTRACTORNAME"]);
                            lblConLicNo.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_CONTRACTORLICNO"]);
                            lblDGSETName.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_DGSETOPERATORNAME"]);
                            lblDGCapacity.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_DGSETCAPACITY"]);
                            lblCapcity.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_DGSETCAPACITYIN"]);
                            lblPowerFactor.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_DGSETPOWERFACTOR"]);
                            lblRatedvtg.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_DGSETRATEDVOLTAGE"]);
                            lblEngineSerial.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_DGSETENGINEDTLS"]);
                            lblMakeserial.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_DGSETALTERNATORDTLS"]);
                            lblEquipment.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_EQUIPMENTTYPE"]);
                            lblEarthing.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_EARTHCONDCTRDTLS"]);
                            lblIndependent.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_CONDUCTORPATHS"]);
                            lblelectrode.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_ELECTRODEDTLS"]);
                            lblSystemohm.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_IMPEDANCE"]);
                            lblImpedance.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_TOTALIMPEDANCE"]);
                            lblLighting.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_LIGHTINGTYPE"]);
                            lblAlternator.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_ALTERNATORTESTDTLS"]);
                            lblEarhtTester.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_EARTHTESTERNO"]);
                            lblMakeEarth.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_EARTHTESTERMAKE"]);
                            lblRangeEarth.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_EARTHTESTERRANGE"]);
                            lblMeggerNo.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_MEGGERNO"]);
                            lblMake.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_MEGGERMAKE"]);
                            lblRange.Text = Convert.ToString(ds.Tables[14].Rows[0]["CFEDG_MEGGERRANGE"]);
                        }
                        else { DGSETDET.Visible = false; }




                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[15].Rows.Count > 0)
                    {
                        //  CEIGDET.Visible = true;
                        if (CEIGDET.Visible == true)
                        {
                            lblAlreadyInstall.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_ALREADYINSTALLED"]);
                            lblCEIGProposed.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_PROPOSED"]);
                            lblCEIGTotal.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_TOTAL"]);
                            lblTypeLoad.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_CONNECTEDLOAD"]);
                            lblAlredy.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_ALREADTINSTALL"]);
                            lblProposed.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_PROPSE"]);
                            lblTotal.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_TOTALS"]);
                            lblRegulation.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_REGULATION"]);
                            if (lblTypeLoad.Text == "Yes")
                            {
                                divvoltages.Visible = true;
                                lblCEIGVoltage.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_VOLTAGE"]);
                                divpowerplants1.Visible = true;
                                lblPlant.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_PLANT"]);
                            }
                            else
                            {
                                divpowerplants2.Visible = true;
                                lblATC.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_CAPACITY"]);
                            }


                            lblLocatFactory.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_FACTORYLOCATION"]);
                            lblSurveyNo.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_SURVEYNO"]);
                            lblExtent.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_EXTENT"]);
                            lblCEIGDistrict.Text = Convert.ToString(ds.Tables[15].Rows[0]["DistrictName"]);
                            lblCEIGMandal.Text = Convert.ToString(ds.Tables[15].Rows[0]["Mandalname"]);
                            lblCEIGVillage.Text = Convert.ToString(ds.Tables[15].Rows[0]["VillageName"]);
                            lblStreetName.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_STREETNAME"]);
                            lblCEIGPin.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_PINCODE"]);
                            lblTelephone.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_TELEPHONE"]);
                            lblNaerest.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_NEARTELEPHONENO"]);
                            lblDateCommence.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_DATE"]);

                        }
                        else { CEIGDET.Visible = false; }



                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[16].Rows.Count > 0)
                    {
                        //  TaxDet.Visible = true;
                        if (TaxDet.Visible == true)
                        {
                            lblTaxApplyAs.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_APPLYAS"]);
                            lblTaxNameEst.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_NAMEEST"]);
                            lblTaxAddress.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_ADDRESSEST"]);
                            lblTaxDistrict.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_DISTRICEST"]);
                            lblTaxPincode.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_PINCODEEST"]);
                            lblTaxTotalEst.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_TOTALNOEMPEST"]);
                            lblTaxDateCommence.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_DATE"]);
                            lblTaxEst.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_CONSTITUTIONEST"]);
                            lblTaxGoodsService.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_GOODSSUPPLIESEST"]);
                            lblTaxPlace.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_ADDITIONPLACEBUSINESS"]);
                            lblTaxDesignation.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_DESIGNATION"]);
                            lblTaxRegAct.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_REGUNDERACT"]);
                            if (lblTaxRegAct.Text == "Yes")
                            {
                                RegistrationType.Visible = true;
                                lbltaxRegType.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_REGTYPE"]);
                                RegNo.Visible = true;
                                lblTaxReNo.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_REGNO"]);
                            }
                        }
                        else { TaxDet.Visible = false; }

                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[17].Rows.Count > 0)
                    {
                        //  TaxDet.Visible = true;

                        if (TaxDet.Visible == true)
                        {
                            GVState.DataSource = ds.Tables[17];
                            GVState.DataBind();
                        }
                        else { TaxDet.Visible = false; }

                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[18].Rows.Count > 0)
                    {
                        // waterConn.Visible = true;
                        if (waterConn.Visible == true)
                        {
                            lblDrink.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_WATERDRINK"]);
                            lblWaterIndu.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_WATERPROCESS"]);
                            lblReqWater.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_CONSUMPTIVEWATER"]);
                            lblNonConsumptive.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_NONCONSUMPTIVEWATER"]);
                            lblConnection.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_WATERCONN"]);

                            if (lblConnection.Text == "3")
                            {
                                holdno.Visible = false;
                            }
                            else
                            {
                                holdno.Visible = true;
                                lblHold.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_HOLDINGNO"]);
                            }

                            lblWardNo.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_WARDNO"]);

                            CommercialWater.Visible = true;
                            if (CommercialWater.Visible == true)
                            {
                                lblSubDivision.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_DIVISIONAL"]);
                                lblPremise.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_NOOFPREMISE"]);
                                lblReqDemand.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_DEMANDPERDAY"]);
                                lblInformations.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_INFORMATION"]);
                                lblDistrictWater.Text = Convert.ToString(ds.Tables[18].Rows[0]["DistrictName"]);
                                MandalWater.Text = Convert.ToString(ds.Tables[18].Rows[0]["Mandalname"]);
                                lblVillageWater.Text = Convert.ToString(ds.Tables[18].Rows[0]["VillageName"]);
                                lblLocalitywater.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_LOCALITY"]);
                                lblNear.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_LANDMARK"]);
                                lblPinNumber.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_PINCODE"]);
                                lblReqConn.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_PURPOSECON"]);
                                lblTypeCon.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_TYPECONN"]);
                                if (lblTypeCon.Text == "Yes")
                                {
                                    NominalDN.Visible = true;
                                    lbldomestic.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_DOMESTIC"]);
                                    DiameterDN.Visible = false;
                                }
                                else
                                {
                                    DiameterDN.Visible = true;
                                    lblDiameter.Text = Convert.ToString(ds.Tables[18].Rows[0]["CFEWD_BULK"]);
                                    NominalDN.Visible = false;
                                }


                            }
                            else { CommercialWater.Visible = false; }

                        }
                    }
                    DataTable dt = new DataTable();

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[19].Rows.Count > 0)
                    {
                        dt.Merge(ds.Tables[19]);
                    }

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[20].Rows.Count > 0)
                    {
                        dt.Merge(ds.Tables[20]);
                    }
                    grdcfeattachment.DataSource = dt;
                    grdcfeattachment.DataBind();

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[21].Rows.Count > 0)
                    {
                        grdApplStatus.DataSource = ds.Tables[21];
                        grdApplStatus.DataBind();
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
                }
                if (ddlStatus.SelectedValue == "6" || ddlStatus.SelectedValue == "17" || ddlStatus.SelectedValue == "11")
                {
                    if (ddlStatus.SelectedValue == "6") //Raise Query
                    {
                        tdquryorrej.Visible = true;
                        tdquryorrejTxtbx.Visible = true;
                        txtRequest.Visible = true;
                        lblremarks.Text = "Please Enter Query Details";

                        txtAdditionalAmount.Visible = false;
                        tdInspReport.Visible = false;
                        tdInspReport1.Visible = false;
                    }
                    else if (ddlStatus.SelectedValue == "17") //Rejected
                    {
                        tdquryorrej.Visible = true;
                        tdquryorrejTxtbx.Visible = true;
                        txtRequest.Visible = true;
                        lblremarks.Text = "Please Enter Rejection Reason";

                        txtAdditionalAmount.Visible = false;
                        tdInspReport.Visible = false;
                        tdInspReport1.Visible = false;
                    }
                    else if (ddlStatus.SelectedValue == "11") //Completed with Payment Request
                    {
                        tdquryorrej.Visible = true; //header label
                        tdquryorrejTxtbx.Visible = true; //td
                        txtAdditionalAmount.Visible = true;
                        lblremarks.Text = "Please Enter Additional Amount";
                        tdInspReport.Visible = true;
                        tdInspReport1.Visible = true;

                        txtRequest.Visible = false;
                    }
                }
                else if (ddlStatus.SelectedValue == "12") //Completed
                {
                    tdquryorrej.Visible = false; //header label
                    tdquryorrejTxtbx.Visible = false; //td
                    tdInspReport.Visible = true;
                    tdInspReport1.Visible = true;

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
                    //else if (ddlStatus.SelectedValue == "12" && (string.IsNullOrWhiteSpace(hplInspReport.Text) || hplInspReport.Text == "" || hplInspReport.Text == null))
                    //{
                    //    lblmsg0.Text = "Please upload Inspection report";
                    //    Failure.Visible = true;
                    //    return;
                    //}
                    else
                    {
                        objcfeDtls.Unitid = Session["UNITID"].ToString();
                        objcfeDtls.Investerid = Session["INVESTERID"].ToString();
                        if (ddlStatus != null)
                            objcfeDtls.status = Convert.ToInt32(ddlStatus.SelectedValue);
                        objcfeDtls.UserID = ObjUserInfo.UserID;
                        objcfeDtls.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                        objcfeDtls.ApprovalId = Convert.ToInt32(Session["ApprovalID"].ToString());
                        objcfeDtls.Questionnaireid = Session["Questionnaireid"].ToString();
                        objcfeDtls.Remarks = txtRequest.Text;
                        if (Request.QueryString["status"].ToString() == "PRESCRUTINYPENDING")
                        {
                            if (ddlStatus.SelectedValue == "17")
                            {
                                objcfeDtls.PrescrutinyRejectionFlag = "Y";
                            }
                            else
                            {
                                objcfeDtls.PrescrutinyRejectionFlag = "N";
                            }
                        }
                        objcfeDtls.IPAddress = getclientIP();

                        string valid = objcfebal.UpdateCFEDepartmentProcess(objcfeDtls);
                        btnSubmit.Enabled = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Submitted Successfully!');  window.location.href='CFEApplDeptProcess.aspx? '", true);
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
                    tdbtnreject.Visible = true;
                    tdapprovalAction.Visible = true;
                    trapproval.Visible = false;
                    trrejection.Visible = true;
                    txtRejection.Visible = true;
                    tdapproverejection.Visible = true;
                    lblremarks.Text = "Please Enter Rejection Reason";
                    tdapprovalAction.Visible = true;
                    btnreject.Visible = true;
                    btnApprove.Visible = false;
                    TRAPPROVE.Visible = false;
                }
                else
                {
                    trapproval.Visible = true;
                    trrejection.Visible = false;
                    txtRejection.Visible = false;
                    tdapproverejection.Visible = false;
                    tdapprovalAction.Visible = false;
                    btnreject.Visible = false;
                    btnApprove.Visible = true;
                    TRAPPROVE.Visible = true;
                    tdbtnreject.Visible = false;
                }

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                        objcfeDtls.Unitid = Session["UNITID"].ToString();
                        objcfeDtls.Investerid = Session["INVESTERID"].ToString();
                        if (ddlStatus != null)
                            objcfeDtls.status = Convert.ToInt32(ddlapproval.SelectedValue);
                        objcfeDtls.UserID = ObjUserInfo.UserID;
                        objcfeDtls.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                        objcfeDtls.ApprovalId = Convert.ToInt32(Session["ApprovalID"].ToString());
                        objcfeDtls.Questionnaireid = Session["Questionnaireid"].ToString();
                        if (ddlapproval.SelectedValue == "16")
                        { objcfeDtls.Remarks = txtRejection.Text; }
                        if (ddlapproval.SelectedValue == "13")
                        { objcfeDtls.ReferenceNumber = txtreferenceno.Text; }
                        objcfeDtls.PrescrutinyRejectionFlag = "N";
                        //if (Request.QueryString["status"].ToString() == "APPROVALPENDING")
                        //{
                        //    if (ddlStatus.SelectedValue == "16")
                        //    {
                        //        objcfeDtls.PrescrutinyRejectionFlag = "N";
                        //    }                             
                        //}
                        var Hostname = Dns.GetHostName();
                        objcfeDtls.IPAddress = getclientIP();

                        string valid = objcfebal.UpdateCFEDepartmentProcess(objcfeDtls);
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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + Session["INVESTERID"].ToString() + "\\"
                         + Session["Questionnaireid"].ToString() + "\\" + "ApprovalDocuments" + "\\" + Session["ApprovalID"] + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        fuApproval.PostedFile.SaveAs(serverpath + "\\" + fuApproval.PostedFile.FileName);

                        CFEAttachments objBldngPlan = new CFEAttachments();
                        objBldngPlan.UNITID = Convert.ToString(Session["UNITID"]);
                        objBldngPlan.Questionnareid = Session["Questionnaireid"].ToString();
                        objBldngPlan.ApprovalID = Session["ApprovalID"].ToString();
                        objBldngPlan.DeptID = Session["DEPTID"].ToString();
                        objBldngPlan.FilePath = serverpath + fuApproval.PostedFile.FileName;
                        objBldngPlan.FileName = fuApproval.PostedFile.FileName;
                        objBldngPlan.FileType = fuApproval.PostedFile.ContentType;
                        objBldngPlan.FileDescription = "ApprovalDocuments";
                        objBldngPlan.CreatedBy = Session["INVESTERID"].ToString();
                        objBldngPlan.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objBldngPlan);
                        if (result != "")
                        {
                            tdhyperlink.Visible = true;
                            hplApproval.Text = fuApproval.PostedFile.FileName;
                            hplApproval.NavigateUrl = objBldngPlan.FilePath;
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
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/CFE/CFEApplDeptView.aspx?status=" + Request.QueryString["status"].ToString());
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                //throw ex;
            }
        }

        protected void btnInspReport_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupInspReport.HasFile)
                {
                    Error = validations(fupInspReport);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + Session["INVESTERID"].ToString() + "\\"
                         + Session["Questionnaireid"].ToString() + "\\" + "InspectionReports" + "\\" + Session["ApprovalID"] + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupInspReport.PostedFile.SaveAs(serverpath + "\\" + fupInspReport.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupInspReport.PostedFile.SaveAs(serverpath + "\\" + fupInspReport.PostedFile.FileName);
                            }
                        }

                        CFEAttachments objBldngPlan = new CFEAttachments();
                        objBldngPlan.UNITID = Convert.ToString(Session["UNITID"]);
                        objBldngPlan.Questionnareid = Session["Questionnaireid"].ToString();
                        objBldngPlan.ApprovalID = Session["ApprovalID"].ToString();
                        objBldngPlan.DeptID = Session["DEPTID"].ToString();
                        objBldngPlan.FilePath = serverpath + fupInspReport.PostedFile.FileName;
                        objBldngPlan.FileName = fupInspReport.PostedFile.FileName;
                        objBldngPlan.FileType = fupInspReport.PostedFile.ContentType;
                        objBldngPlan.FileDescription = "Inspection Report";
                        objBldngPlan.CreatedBy = Session["INVESTERID"].ToString();
                        objBldngPlan.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objBldngPlan);
                        if (result != "")
                        {
                            hplInspReport.Visible = true;
                            hplInspReport.Text = fupInspReport.PostedFile.FileName;
                            hplInspReport.NavigateUrl = objBldngPlan.FilePath;
                            hplInspReport.Target = "blank";
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