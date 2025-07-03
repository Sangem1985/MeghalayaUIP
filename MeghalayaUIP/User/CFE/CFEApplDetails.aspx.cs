using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEApplDetails : System.Web.UI.Page
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
                if (Session["UserInfo"] != null)
                {
                    var ObjUserInfo = new UserInfo();
                    if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (UserInfo)Session["UserInfo"];
                    }
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.Userid;
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindCFEApplicatinDetails();
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindCFEApplicatinDetails()
        {
            try
            {

                if (Session["CFEUNITID"] != null && hdnUserID.Value != null)
                {
                    DataSet ds = new DataSet();
                    ds = objcfebal.GetCFEApplicationDetails(Convert.ToString(Session["CFEUNITID"]), hdnUserID.Value, "");
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables[0].Rows[0];
                        lblnameUnit.Text = Convert.ToString(row["CFEQD_COMPANYNAME"]);

                        lblconstitution.Text = Convert.ToString(row["CONST_TYPE"]);
                        lblProposal.Text = Convert.ToString(row["CFEQD_PROPOSALFOR"]);
                        lblLocation.Text = Convert.ToString(row["DistrictName"]);
                        lblMandal.Text = Convert.ToString(row["Mandalname"]);
                        lblVillage.Text = Convert.ToString(row["VillageName"]);
                        lblExtentland.Text = Convert.ToString(row["CFEQD_TOTALEXTENTLAND"]);
                        lblBuilt.Text = Convert.ToString(row["CFEQD_BUILTUPAREA"]);
                        lblSectors.Text = Convert.ToString(row["CFEQD_SECTOR"]);
                        lblActivity.Text = Convert.ToString(row["LineofActivity_Name"]);
                        lblPollution.Text = Convert.ToString(row["CFEQD_PCBCATEGORY"]);
                        lblIndustry.Text = Convert.ToString(row["INDUSTRYTYPE"]);

                        lblUnitLocation.Text = Convert.ToString(row["CFEQD_UNTLOCATION"]);
                        lblMIDCL.Text = Convert.ToString(row["CFEQD_MIDCLLAND"]);
                        lblproposeEMP.Text = Convert.ToString(row["CFEQD_PROPEMP"]);
                        lblLANDINR.Text = Convert.ToString(row["CFEQD_LANDVALUE"]);
                        lblBuildingINR.Text = Convert.ToString(row["CFEQD_BUILDINGVALUE"]);
                        lblMachineryINR.Text = Convert.ToString(row["CFEQD_PMCOST"]);
                        lblExpectTurnINR.Text = Convert.ToString(row["CFEQD_EXPECTEDTURNOVER"]);
                        lblTPCost.Text = Convert.ToString(row["CFEQD_TOTALPROJCOST"]);
                        lblEnterpriseCat.Text = Convert.ToString(row["CFEQD_ENTERPRISETYPE"]);
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
                        lblAffectedArea.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEID_AFFECTEDRDAREA"]);
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
                        lbllineActivity.Text = Convert.ToString(ds.Tables[2].Rows[0]["LineofActivity_Name"]);
                        gvManufacture.DataSource = ds.Tables[2];
                        gvManufacture.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
                    {
                        lbllineActivity.Text = Convert.ToString(ds.Tables[3].Rows[0]["LineofActivity_Name"]);
                        gvRwaMaterial.DataSource = ds.Tables[3];
                        gvRwaMaterial.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[4].Rows.Count > 0)
                    {
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

                            if (div4questions.Visible == true)
                            {
                                lblNatureOfEmp.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_NATUREOFWORKLABOUREMP"]);
                                lblEstDateBuild.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_ESTDATEBUILDING"]);
                                lblContractEmp.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MAXNUMBEROFCONTRACTEMP"]);
                                lblBuildingWork.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_ESTDATEOFCONSTRUCTIONWORK"]);
                            }
                            else { div4questions.Visible = false; }

                            if (div5questions.Visible == true)
                            {
                                lblMigrantWorkmen.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_MAXNUMBERMIGRANTESTDATE"]);
                                lblPreceding5Years.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_CONTRACTORCONVICTED5YEARS"]);
                                lblRevokingLic.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_REVOKINGSUSPENDINGLIC"]);
                                lblEstPast5Years.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_ESTPAST5YEARSNATUREOFWORK"]);
                                lblBusiness.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFELD_INDUSTRYMANUOCCUPATIONEST"]);
                            }
                            else { div5questions.Visible = false; }

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
                        }
                        else { LabourDet.Visible = false; }

                    }
                    if (LabourDet.Visible == true)
                    {
                        if (divContrLabr.Visible == true)
                        {
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[5].Rows.Count > 0)
                            {
                                GVLabour.DataSource = ds.Tables[5];
                                GVLabour.DataBind();
                            }
                        }
                        else { divContrLabr.Visible = false; }

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
                            lblEngeryLaod.Text = Convert.ToString(ds.Tables[7].Rows[0]["ENERGYLOAD_NAME"]);
                        }
                        else { PowerDetails.Visible = false; }

                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[8].Rows.Count > 0)
                    {
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

                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[10].Rows.Count > 0)
                    {
                        if (Pollutioncontrol.Visible == true)
                        {
                            lblReqtrick.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_AUTHORIZATIONREQ"]);
                            lblQuantitywaste.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_WASTEHANDLEANNUM"]);
                            lblMetrictons.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_WASTESTOREDTIME"]);
                            lblhandleannum.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_QUANTITYWASTEANNUM"]);
                            lblWastestored.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_QUANTITYSTOREDTIME"]);
                            lblYearProduct.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_YEAROFPRODUCTION"]);
                            lblindustrywork.Text = Convert.ToString(ds.Tables[10].Rows[0]["CFEHWD_INDUSTRYWORK"]);
                        }
                        else { Pollutioncontrol.Visible = false; }
                    }

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[11].Rows.Count > 0)
                    {
                        if (Explosive.Visible == true)
                        {
                            lblExplosive.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_EXPLOSIVESITE"]);
                            lblRoadvan.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_EXPLOSIVEROADVAN"]);
                            lblCriminal.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_CRIMINAL1973"]);
                            if (lblCriminal.Text == "Y")
                            {
                                Details.Visible = true;
                                lblChapterDetails.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_DETAIL"]);
                            }
                            lblLicPossess.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_EXPLOSIVE1884"]);
                            if (lblLicPossess.Text == "Y")
                            {
                                LicDetails.Visible = true;
                                lblDetails.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_DETAILS"]);
                            }
                            lblApprovals.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_APPROVAL101"]);

                            if (lblApprovals.Text == "Y")
                            {
                                approvaldet.Visible = true;
                                lblapprovalDet.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_APPROVALDETAILS"]);
                            }
                            lblRelevant.Text = Convert.ToString(ds.Tables[11].Rows[0]["CFEED_ANYINFORMATION"]);
                        }
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[12].Rows.Count > 0)
                    {
                        if (Explosive.Visible == true)
                        {
                            GVEXPLOSIVE.DataSource = ds.Tables[12];
                            GVEXPLOSIVE.DataBind();

                        }
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[13].Rows.Count > 0)
                    {
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
                    }





                    if (ds.Tables.Count > 0 && ds.Tables[14].Rows.Count > 0)
                    {
                        DGSETDET.Visible = true;
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
                    if (ds.Tables.Count > 0 && ds.Tables[15].Rows.Count > 0)
                    {
                        CEIGDET.Visible = true;
                        lblAlreadyInstall.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_ALREADYINSTALLED"]);
                        lblCEIGProposed.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_PROPOSED"]);
                        lblCEIGTotal.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_TOTAL"]);
                        lblTypeLoad.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_CONNECTEDLOAD"]);
                        lblAlredy.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_ALREADTINSTALL"]);
                        lblProposed.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_PROPSE"]);
                        lblTotal.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_TOTALS"]);
                        lblRegulation.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_REGULATION"]);
                        lblCEIGVoltage.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_VOLTAGE"]);
                        lblATC.Text = Convert.ToString(ds.Tables[15].Rows[0]["CFECD_CAPACITY"]);
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

                    if (ds.Tables.Count > 0 && ds.Tables[16].Rows.Count > 0)
                    {
                      //  TaxDet.Visible = true;
                        lblPTApplyAs.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_APPLYAS"]);
                        lblPTEstbAddress.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_ADDRESSEST"]);
                        lbPTEstbName.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_NAMEEST"]);
                        // lblPTDistrict.Text = Convert.ToString(ds.Tables[17].Rows[0][""]);
                        //lblPTpincodeel13.Text = Convert.ToString(ds.Tables[17].Rows[0][""]);
                        //lblPTEmp.Text = Convert.ToString(ds.Tables[17].Rows[0][""]);
                        lblPTDateofComm.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_DATE"]);
                        lblPTConst.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_CONSTITUTIONEST"]);
                        lblPTGoodsnServc.Text = Convert.ToString(ds.Tables[16].Rows[0]["CFEPT_GOODSSUPPLIESEST"]);
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[17].Rows.Count > 0)
                    {
                        GVState.DataSource = ds.Tables[17];
                        GVState.DataBind();
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
    }
}