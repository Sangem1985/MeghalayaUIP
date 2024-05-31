using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        public void BindCFEApplicatinDetails()
        {
            try
            {
               
                if (Session["CFEUNITID"] != null && hdnUserID.Value != null)
                {
                    DataSet ds = new DataSet();
                    ds = objcfebal.GetCFEApplicationDetails(Convert.ToString(Session["CFEUNITID"]), hdnUserID.Value);

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
                        lblitem.Text = Convert.ToString(ds.Tables[2].Rows[0]["CFELM_ITEMNAME"]);
                        lblQuantityper.Text = Convert.ToString(ds.Tables[2].Rows[0]["CFELM_ITEMANNUALCAPACITY"]);
                        lblQuantity.Text = Convert.ToString(ds.Tables[2].Rows[0]["CFELM_ITEMVALUE"]);
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
                    {
                        lblEstablish.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_CATEGORY_ESTABLISHMENT"]);
                        lblNames.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_NAME"]);
                        lblFather.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_FATHERNAME"]);
                        lblAge.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_AGE"]);
                        lblDesignation.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_DESIGNATION"]);
                        lblMobiles.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_MOBILENO"]);
                        lblMail.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_EMAILID"]);
                        lbldist.Text = Convert.ToString(ds.Tables[3].Rows[0]["DISTRIC"]);
                        lblMandalsmandal.Text = Convert.ToString(ds.Tables[3].Rows[0]["MANDAL"]);
                        lblVILLAS.Text = Convert.ToString(ds.Tables[3].Rows[0]["VILLAGE"]);
                        lblDoors.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_DOOR"]);
                        lblLocalitys.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_LOCALITY"]);
                        lblPins.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_PINCODE"]);
                        lblcontractor.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_NAMECONTRACTOR"]);
                        lblfafname.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_FATHER"]);
                        lblages.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_AGES"]);
                        lblMobileno.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_MOBILE"]);
                        lblEmailId.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_EMAIL"]);
                        lblDistr.Text = Convert.ToString(ds.Tables[3].Rows[0]["DISTRIC"]);
                        lbltaluka.Text = Convert.ToString(ds.Tables[3].Rows[0]["MANDAL"]);
                        lblVillvillage.Text = Convert.ToString(ds.Tables[3].Rows[0]["VILLAGE"]);
                        lblDoorno.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_DOORNO"]);
                        lbllocals.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_LOCALITYNAME"]);
                        lblPincodeno.Text = Convert.ToString(ds.Tables[3].Rows[0]["CFELD_PIN"]);
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[4].Rows.Count > 0)
                    {
                        lblHP.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFEPD_CONNECTEDLOAD"]);
                        lblMaxDemand.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFEPD_MAXIMUMDEMAND"]);
                        lblVoltageLevel.Text = Convert.ToString(ds.Tables[4].Rows[0]["VOLTAGERANGE"]);
                        lblPermise.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFEPD_WRKNGHRSPERDAY"]);
                        lblMonth.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFEPD_WRKNGHRSPERMONTH"]);
                        lblYear.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFEPD_PRODUCTIONDTAE"]);
                        lblPowersupply.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFEPD_POWERDATE"]);
                        lblQuantum.Text = Convert.ToString(ds.Tables[4].Rows[0]["CFEPD_REQLOAD"]);
                        lblEngeryLaod.Text = Convert.ToString(ds.Tables[4].Rows[0]["ENERGYLOAD_NAME"]);
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[5].Rows.Count > 0)
                    {
                        lblDistrics.Text = Convert.ToString(ds.Tables[5].Rows[0]["DistrictName"]);
                        lblMan.Text = Convert.ToString(ds.Tables[5].Rows[0]["Mandalname"]);
                        lblVill.Text = Convert.ToString(ds.Tables[5].Rows[0]["VillageName"]);
                        lbllocal.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_Locality"]);
                        lbNear.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_Landmark"]);
                        lblPincodes.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_Pincode"]);
                        lblheight.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_BUILDINGHT"]);
                        lblEachfloor.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_FLOORHT"]);
                        lblArea.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_PLOTAREA"]);
                        lblbuild.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_BUILDINGAREA"]);
                        lbldriveway.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_DRIVEPROPSED"]);
                        lblcategoryBuild.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_CATEGORYBUILD"]);
                        feeamount.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_FEEAMOUNT"]);
                        lblEast.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_East"]);
                        lblDistanceprop.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_DISTANCEEAST"]);
                        lblwest.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_West"]);
                        lblbUILDDIST.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_DISTANCEWEST"]);
                        lblNorth.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_North"]);
                        lblDistBuild.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_DISTANCENORTH"]);
                        lblSouth.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_South"]);
                        lblbuildProp.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_DISTANCESOUTH"]);
                        lblFireStation.Text = Convert.ToString(ds.Tables[5].Rows[0]["CFEFD_FIRESTATION"]);
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[6].Rows.Count > 0)
                    {
                        lblspice.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_SPECIES"]);
                        lblLength.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_TIMBERLENGTH"]);
                        lblvolume.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_TIMBERVOLUME"]);
                        lblGirth.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_GIRTH"]);
                        lblFirewood.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_ESTIMATED"]);
                        lblpole.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_POLES"]);
                        lblNorths.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_NORTH"]);
                        lblEasts.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_EAST"]);
                        lblWests.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_WEST"]);
                        lblSouths.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_SOUTH"]);
                        lblAddress.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_ADDRESS"]);
                        lbllatitude.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_LATTITUDE"]);
                        lblDegreess.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_DEGREES"]);
                        lblMinte.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_MINUTES"]);
                        lblseconds.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_SECONDS"]);
                        lbllongitude.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_LONGITUDE"]);
                        lblDegrees.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_DEGREE"]);
                        lblMinutes.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_MINUTE"]);
                        lblsecond.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_SECOND"]);
                        lblCoordinates.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_GPSCOORDINATES"]);
                        lblApplication.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_PURPOSEAPPLICATION"]);
                        lblDivision.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_FORESTDIVISION"]);
                        lblinformation.Text = Convert.ToString(ds.Tables[6].Rows[0]["CFEFD_INFORMATION"]);
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[7].Rows.Count > 0)
                    {
                        grdcfeattachment.DataSource = ds.Tables[7];
                        grdcfeattachment.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[8].Rows.Count > 0)
                    {
                        grdApplStatus.DataSource = ds.Tables[8];
                        grdApplStatus.DataBind();
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}