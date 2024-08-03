using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Renewal
{
    public partial class RENApplDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string UnitID;
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
                    Session["RENUNITID"] = "1001";
                    UnitID = Convert.ToString(Session["RENUNITID"]);

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {

                        BindRENApplicatinDetails();
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
        public void BindRENApplicatinDetails()
        {
            try
            {
                if (Session["RENUNITID"] != null && hdnUserID.Value != null)
                {
                    DataSet ds = new DataSet();
                    ds = objRenbal.GetRENApplicationDetails(Convert.ToString(Session["RENUNITID"]), hdnUserID.Value);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblnameUnit.Text = ds.Tables[0].Rows[0]["RENID_NAMEOFUNIT"].ToString();
                        lblCompanyType.Text = ds.Tables[0].Rows[0]["NSWS_ENTITYTYPENAME"].ToString();
                        lblNatureIndustry.Text = ds.Tables[0].Rows[0]["RENID_SECTORENTERPRISE"].ToString();
                        lblRegCat.Text = ds.Tables[0].Rows[0]["RENID_CATEGORYREG"].ToString();
                        lblProvSSI.Text = ds.Tables[0].Rows[0]["RENID_REGNUMBER"].ToString();
                        lblRegDate.Text = ds.Tables[0].Rows[0]["RENID_REGDATE"].ToString();
                        lblSector.Text = ds.Tables[0].Rows[0]["RENID_SECTOR"].ToString();
                        lblActivity.Text = ds.Tables[0].Rows[0]["LineofActivity_Name"].ToString();
                        lblPCB.Text = ds.Tables[0].Rows[0]["RENID_POLLUTIONCATG"].ToString();
                        lblSurvey.Text = ds.Tables[0].Rows[0]["RENID_SURVEYDOOR"].ToString();
                        lblLocalit.Text = ds.Tables[0].Rows[0]["RENID_LOCALITY"].ToString();
                        lblLandmark.Text = ds.Tables[0].Rows[0]["RENID_LANDMARK"].ToString();
                        lblDistrict.Text = ds.Tables[0].Rows[0]["DistrictName"].ToString();
                        lblMandal.Text = ds.Tables[0].Rows[0]["Mandalname"].ToString();
                        lblVillage.Text = ds.Tables[0].Rows[0]["VillageName"].ToString();
                        lblEmailId.Text = ds.Tables[0].Rows[0]["RENID_EMAILID"].ToString();
                        lblMobileNum.Text = ds.Tables[0].Rows[0]["RENID_MOBILENO"].ToString();
                        lblPincode.Text = ds.Tables[0].Rows[0]["RENID_PINCODE"].ToString();
                        lblTotalExtent.Text = ds.Tables[0].Rows[0]["RENID_TOTALEXTENTLAND"].ToString();
                        lblBuiltAreaSQM.Text = ds.Tables[0].Rows[0]["RENID_BUILTUPAREA"].ToString();
                        lblName.Text = ds.Tables[0].Rows[0]["RENID_NAME"].ToString();
                        lblSonof.Text = ds.Tables[0].Rows[0]["RENID_SONOF"].ToString();
                        lblMailid.Text = ds.Tables[0].Rows[0]["RENID_EMAIL"].ToString();
                        lblMobileNo.Text = ds.Tables[0].Rows[0]["RENID_MOBILENUMBER"].ToString();
                        lblAlternative.Text = ds.Tables[0].Rows[0]["RENID_ALTERNUMBER"].ToString();
                        lblLandlines.Text = ds.Tables[0].Rows[0]["RENID_LANDLINENUMBER"].ToString();
                        lblDoors.Text = ds.Tables[0].Rows[0]["RENID_DOOR"].ToString();
                        lblLocalitys.Text = ds.Tables[0].Rows[0]["RENID_LOCALITYADD"].ToString();
                        lblStates.Text = ds.Tables[0].Rows[0]["MS_NAME"].ToString();
                        lblDistricts.Text = ds.Tables[0].Rows[0]["RENID_DISTRICS"].ToString();
                        lblMandals.Text = ds.Tables[0].Rows[0]["RENID_MANDALS"].ToString();
                        lblVillages.Text = ds.Tables[0].Rows[0]["RENID_VILLAGES"].ToString();
                        lblPincodeIndustry.Text = ds.Tables[0].Rows[0]["RENID_PIN"].ToString();
                        lblAge.Text = ds.Tables[0].Rows[0]["RENID_AGE"].ToString();
                        lblDesignation.Text = ds.Tables[0].Rows[0]["RENID_DESIGNATION"].ToString();
                        lblWomenEntre.Text = ds.Tables[0].Rows[0]["RENID_WOMENENTREPRENEUR"].ToString();
                        lblAbled.Text = ds.Tables[0].Rows[0]["RENID_ABLED"].ToString();
                        lblDirectMale.Text = ds.Tables[0].Rows[0]["RENID_DIRECTMALE"].ToString();
                        lblDirectFemale.Text = ds.Tables[0].Rows[0]["RENID_DIRECTFEMALE"].ToString();
                        lblirectEmp.Text = ds.Tables[0].Rows[0]["RENID_DIRECTEMP"].ToString();
                        lblIndirectMale.Text = ds.Tables[0].Rows[0]["RENID_INDIRECTFEMALE"].ToString();
                        lblIndirectFemale.Text = ds.Tables[0].Rows[0]["RENID_INDIRECTEMP"].ToString();
                        lblTotalEmp.Text = ds.Tables[0].Rows[0]["RENID_TOTALEMP"].ToString();
                        lblLandSaledeed.Text = ds.Tables[0].Rows[0]["RENID_LANDSALEDEED"].ToString();
                        lblBuilding.Text = ds.Tables[0].Rows[0]["RENID_BUILDING"].ToString();
                        lblPMINR.Text = ds.Tables[0].Rows[0]["RENID_PLANTMACHINERY"].ToString();
                        lblTotalCost.Text = ds.Tables[0].Rows[0]["RENID_PROJECTCOST"].ToString();
                        lblAnnualTurn.Text = ds.Tables[0].Rows[0]["RENID_ANNUALTURNOVER"].ToString();
                        lblEnterCat.Text = ds.Tables[0].Rows[0]["RENID_ENTERPRISECATEG"].ToString();

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        BoilerDet.Visible = true;
                        if (BoilerDet.Visible == true)
                        {
                            lblLineOfActivity.Text = ds.Tables[1].Rows[0]["RENBD_LICNO"].ToString();
                            lblBoilerLicIssue.Text = ds.Tables[1].Rows[0]["RENBD_LICISSUEDATE"].ToString();
                            lblLcValidupto.Text = ds.Tables[1].Rows[0]["RENBD_LICVALIDDATE"].ToString();
                            lblBoilerSituatedPlant.Text = ds.Tables[1].Rows[0]["RENBD_BOILERPLANT"].ToString();
                            lblFactoryEstName.Text = ds.Tables[1].Rows[0]["RENBD_FACTORYNAME"].ToString();
                            lblFactoryAddress.Text = ds.Tables[1].Rows[0]["RENBD_FACTORYADDRESS"].ToString();
                            lblDirectorate.Text = ds.Tables[1].Rows[0]["DistrictName"].ToString();
                            lblApplied.Text = ds.Tables[1].Rows[0]["Mandalname"].ToString();
                            lblYearEst.Text = ds.Tables[1].Rows[0]["VillageName"].ToString();
                            lblDocumenteryEvidence.Text = ds.Tables[1].Rows[0]["RENBD_LOCALITY"].ToString();
                            lblPincodes.Text = ds.Tables[1].Rows[0]["RENBD_PINCODE"].ToString();
                            lblPersonnelDesig.Text = ds.Tables[1].Rows[0]["RENBD_NAMEMANU"].ToString();
                            lblSite.Text = ds.Tables[1].Rows[0]["RENBD_YEARMANU"].ToString();
                            lblStrictly81.Text = ds.Tables[1].Rows[0]["RENBD_PLACEMANU"].ToString();
                            lblHighStanded.Text = ds.Tables[1].Rows[0]["RENBD_BOILERMAKERNO"].ToString();
                            lblFirmMaterial.Text = ds.Tables[1].Rows[0]["RENBD_INTENDEDPRESSURE"].ToString();
                            lblInternalOwn.Text = ds.Tables[1].Rows[0]["RENBD_FULE"].ToString();
                            lblBoiler1950.Text = ds.Tables[1].Rows[0]["RENBD_SUPERHEATER"].ToString();
                            lblProvide.Text = ds.Tables[1].Rows[0]["RENBD_ECONOMISERRATING"].ToString();
                            lblEvaporationMax.Text = ds.Tables[1].Rows[0]["RENBD_MAXIMUMEVAPORATION"].ToString();
                            lblReheater.Text = ds.Tables[1].Rows[0]["RENBD_REHEATERRATING"].ToString();
                            lblWorkingSeason.Text = ds.Tables[1].Rows[0]["RENBD_WORKINGSEASON"].ToString();
                            lblPSI.Text = ds.Tables[1].Rows[0]["RENBD_WORKINGPRESSURE"].ToString();
                            lblTypeBoiler.Text = ds.Tables[1].Rows[0]["RENBD_TYPEBOILER"].ToString();
                            lblBoilerDesc.Text = ds.Tables[1].Rows[0]["RENBD_DESCBOILER"].ToString();
                            lblBoilerRating.Text = ds.Tables[1].Rows[0]["RENBD_BOILERRATE"].ToString();
                            lblOwnership.Text = ds.Tables[1].Rows[0]["RENBD_BOILEROWNERSHIP"].ToString();
                            if (lblOwnership.Text == "Yes")
                            {
                                RemarkTransfer.Visible = true;
                                lblRemark.Text = ds.Tables[1].Rows[0]["RENBD_REMARKSTRANS"].ToString();
                            }
                            else { RemarkTransfer.Visible = false; }

                            lblRegNos.Text = ds.Tables[1].Rows[0]["RENBD_REGNO"].ToString();
                            lblBoilerType.Text = ds.Tables[1].Rows[0]["RENBD_BOILERTY"].ToString();
                            lblBoilerRateManu.Text = ds.Tables[1].Rows[0]["RENBD_BOILERRATING"].ToString();
                            lblBoilerSituated.Text = ds.Tables[1].Rows[0]["RENBD_WORKPLANTBOILER"].ToString();
                            lblPlaceManu.Text = ds.Tables[1].Rows[0]["RENBD_PLACEMANUFACTURE"].ToString();
                            lblYearManu.Text = ds.Tables[1].Rows[0]["RENBD_YEARMANUFACTURE"].ToString();
                            lblOwners.Text = ds.Tables[1].Rows[0]["RENBD_NAMEMANUFACTURE"].ToString();
                            lblEvaporation.Text = ds.Tables[1].Rows[0]["RENBD_MAXCOUNT"].ToString();
                            lblPressure.Text = ds.Tables[1].Rows[0]["RENBD_MAXIMUMPRESSURE"].ToString();
                            lblRepairs.Text = ds.Tables[1].Rows[0]["RENBD_REPAIRS"].ToString();
                            lblHydraulically.Text = ds.Tables[1].Rows[0]["RENBD_HYDRAULICALLY"].ToString();
                            lblUptoH.Text = ds.Tables[1].Rows[0]["RENBD_UPTO"].ToString();
                            lblLoading.Text = ds.Tables[1].Rows[0]["RENBD_LOADING"].ToString();
                            lblSafetyExceed.Text = ds.Tables[1].Rows[0]["RENBD_SAFTEY"].ToString();
                            lblPeriodDate.Text = ds.Tables[1].Rows[0]["RENBD_PERIODDATE"].ToString();
                            lblToDateH.Text = ds.Tables[1].Rows[0]["RENBD_TODATE"].ToString();
                            lblRemarks.Text = ds.Tables[1].Rows[0]["RENBD_REMARK"].ToString();
                            lblRegFees.Text = ds.Tables[1].Rows[0]["RENBD_REGFEES"].ToString();
                            lblTotalAmount.Text = ds.Tables[1].Rows[0]["RENBD_TOTALAMOUNT"].ToString();
                        }
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        Pollution.Visible = true;
                        if (Pollution.Visible == true)
                        {
                            lblLicNo.Text = ds.Tables[2].Rows[0]["RENBD_LICNUMBER"].ToString();
                            lblLICIssue.Text = ds.Tables[2].Rows[0]["RENBD_LICISSUEDT"].ToString();
                            lblLICShopValidUpto.Text = ds.Tables[2].Rows[0]["RENBD_LICVALID"].ToString();
                            lblNameEst.Text = ds.Tables[2].Rows[0]["RENBD_NAMEOFBUSINESS"].ToString();
                            lblOwnEST.Text = ds.Tables[2].Rows[0]["RENBD_ESTOWNED"].ToString();
                            lblIndividual.Text = ds.Tables[2].Rows[0]["RENBD_NAMEREPRESENTATIVE"].ToString();
                            lblMobile.Text = ds.Tables[2].Rows[0]["RENBD_MOBILENO"].ToString();
                            lblEmail.Text = ds.Tables[2].Rows[0]["RENBD_EMAILID"].ToString();
                            lblAddressEST.Text = ds.Tables[2].Rows[0]["RENBD_ADDRESS"].ToString();
                            lblNatureBusiness.Text = ds.Tables[2].Rows[0]["RENBD_NATUREBUSINESS"].ToString();
                            lblTypeEst.Text = ds.Tables[2].Rows[0]["RENBD_TYPEOFEST"].ToString();


                        }
                        else { Pollution.Visible = false; }
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        CinemaLicense.Visible = true;
                        if (CinemaLicense.Visible == true)
                        {
                            lblApplType.Text = ds.Tables[3].Rows[0]["RENCD_OLDREGNO"].ToString();
                            lblTNTDATE.Text = ds.Tables[3].Rows[0]["RENCD_REGDATE"].ToString();
                            lblColdStorage.Text = ds.Tables[3].Rows[0]["RENCD_NAMEESTCINEMA"].ToString();
                            lblNocIssued.Text = ds.Tables[3].Rows[0]["RENCD_NOCISSUEDATE"].ToString();
                            lblNumberSeats.Text = ds.Tables[3].Rows[0]["RENCD_NUMBERSEAT"].ToString();
                            lblCineMatography.Text = ds.Tables[3].Rows[0]["RENCD_CINEMATOGRAPHY"].ToString();
                            lblBusiness.Text = ds.Tables[3].Rows[0]["RENCD_BUSINESSTYPE"].ToString();
                            lblManaging.Text = ds.Tables[3].Rows[0]["RENCD_NAMEPARTNER"].ToString();
                            lblGSTINEST.Text = ds.Tables[3].Rows[0]["RENCD_GSTNO"].ToString();
                            lblOwnerships.Text = ds.Tables[3].Rows[0]["RENCD_OWNERSHIP"].ToString();
                            lblDistrictses.Text = ds.Tables[3].Rows[0]["DistrictName"].ToString();
                            lblMandeles.Text = ds.Tables[3].Rows[0]["Mandalname"].ToString();
                            lblVilla.Text = ds.Tables[3].Rows[0]["VillageName"].ToString();
                            lblLocalityes.Text = ds.Tables[3].Rows[0]["RENCD_LOCALITY"].ToString();
                            lblLandMarkEST.Text = ds.Tables[3].Rows[0]["RENCD_LANDMARK"].ToString();
                            lblPincod.Text = ds.Tables[3].Rows[0]["RENCD_PINCODE"].ToString();

                        }
                        else { CinemaLicense.Visible = false; }
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        if (LabourDet.Visible == true)
                        {
                            if (Contract.Visible == true)
                            {
                                GVDETAILS.DataSource = ds.Tables[4];
                                GVDETAILS.DataBind();
                            }
                            else { Contract.Visible = false; }
                        }
                    }
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        LabourDet.Visible = true;
                        if (LabourDet.Visible == true)
                        {
                            lblEstName.Text = ds.Tables[5].Rows[0]["RENCLD_LICRENEWAL"].ToString();
                            lblAddressEstShop.Text = ds.Tables[5].Rows[0]["RENCLD_LICISSUEDATE"].ToString();
                            lblDistrictEST.Text = ds.Tables[5].Rows[0]["RENCLD_LICRENEWALDATE"].ToString();
                            lblpinest.Text = ds.Tables[5].Rows[0]["RENCLD_TITLE"].ToString();
                            lblTotalEst.Text = ds.Tables[5].Rows[0]["RENCLD_NAME"].ToString();
                            lblGoodEst.Text = ds.Tables[5].Rows[0]["RENCLD_EMAILID"].ToString();
                            lblDateCommence.Text = ds.Tables[5].Rows[0]["RENCLD_MOBILENO"].ToString();
                            lblGross.Text = ds.Tables[5].Rows[0]["RENCLD_FATHERNAME"].ToString();
                            lblbusinessindia.Text = ds.Tables[5].Rows[0]["RENCLD_ESTNAME"].ToString();
                            lblForeign.Text = ds.Tables[5].Rows[0]["DistrictName"].ToString();
                            lblMadaled.Text = ds.Tables[5].Rows[0]["Mandalname"].ToString();
                            lblVillaged.Text = ds.Tables[5].Rows[0]["VillageName"].ToString();
                            lblLocalityLabour.Text = ds.Tables[5].Rows[0]["RENCLD_LOCALITY"].ToString();
                            lblNearestLabour.Text = ds.Tables[5].Rows[0]["RENCLD_LANDMARK"].ToString();
                            lblPincodeLabour.Text = ds.Tables[5].Rows[0]["RENCLD_PINCODE"].ToString();
                            lblRegIsterNumber.Text = ds.Tables[5].Rows[0]["RENCLD_REGNUMBER"].ToString();
                            lblRegisterDates.Text = ds.Tables[5].Rows[0]["RENCLD_REGDATE"].ToString();
                            lblManuOccupation.Text = ds.Tables[5].Rows[0]["RENCLD_TYPEOFBUSINESS"].ToString();
                            lblTitled.Text = ds.Tables[5].Rows[0]["RENCLD_TITLES"].ToString();
                            lblPrincipal.Text = ds.Tables[5].Rows[0]["RENCLD_EMPNAME"].ToString();
                            lblNameLabour.Text = ds.Tables[5].Rows[0]["RENCLD_NAMES"].ToString();
                            lblAddress.Text = ds.Tables[5].Rows[0]["RENCLD_ADDRESS"].ToString();
                            lblNameEmpLabour.Text = ds.Tables[5].Rows[0]["RENCLD_LABOUREMPEST"].ToString();
                            lblContractLabour.Text = ds.Tables[5].Rows[0]["RENCLD_NOOFDAYS"].ToString();
                            lblApprovedLic.Text = ds.Tables[5].Rows[0]["RENCLD_LABOURAPPROVED"].ToString();
                            lblEmpLabour.Text = ds.Tables[5].Rows[0]["RENCLD_MAXNOLABOUREMP"].ToString();
                            lblProceed5Years.Text = ds.Tables[5].Rows[0]["RENCLD_WITHIN5YEARS"].ToString();
                            if (lblProceed5Years.Text == "Yes")
                            {
                                if (FiveYears.Visible == true)
                                {
                                    lblConvicteddetails.Text = ds.Tables[5].Rows[0]["RENCLD_DETAILS"].ToString();
                                }
                                else { FiveYears.Visible = false; }
                            }

                            lblLicDeposit.Text = ds.Tables[5].Rows[0]["RENCLD_REVOKINGLIC"].ToString();
                            if (lblLicDeposit.Text == "Yes")
                            {
                                Div1.Visible = true;
                                lblOrderDate.Text = ds.Tables[5].Rows[0]["RENCLD_ORDERDATE"].ToString();
                            }
                            else { Div1.Visible = false; }

                            lblContractor5.Text = ds.Tables[5].Rows[0]["RENCLD_ESTWITHIN5YEAR"].ToString();
                            lblEstDetails.Text = ds.Tables[5].Rows[0]["RENCLD_ESTDETAILS"].ToString();
                            lblEmpDetails.Text = ds.Tables[5].Rows[0]["RENCLD_EMPDETAILS"].ToString();
                            lblNaturework.Text = ds.Tables[5].Rows[0]["RENCLD_NATUREOFWORK"].ToString();


                        }
                        else { LabourDet.Visible = false; }
                    }
                    if (ds.Tables[6].Rows.Count > 0)
                    {
                        ContractorMigrant.Visible = true;
                        if (ContractorMigrant.Visible == true)
                        {
                            if (div2.Visible == true)
                            {
                                GVDETAILS.DataSource = ds.Tables[4];
                                GVDETAILS.DataBind();
                            }
                            else { div2.Visible = false; }

                        }
                    }
                    if (ds.Tables[7].Rows.Count > 0)
                    {
                        ContractorMigrant.Visible = true;
                        if (ContractorMigrant.Visible == true)
                        {
                            lblRenewalLic.Text = ds.Tables[7].Rows[0]["RENCM_LICRENO"].ToString();
                            lblIssuedDate.Text = ds.Tables[7].Rows[0]["RENCM_LICISSUEDDATE"].ToString();
                            lblFees.Text = ds.Tables[7].Rows[0]["RENCM_LICRENVALIDDATE"].ToString();
                            lblDistrics.Text = ds.Tables[7].Rows[0]["RENCM_TITLE"].ToString();
                            lblMand.Text = ds.Tables[7].Rows[0]["RENCM_NAME"].ToString();
                            lblTown.Text = ds.Tables[7].Rows[0]["RENCM_EMAILID"].ToString();
                            lblLocality.Text = ds.Tables[7].Rows[0]["RENCM_MOBILENO"].ToString();
                            lblNearstLand.Text = ds.Tables[7].Rows[0]["RENCM_FATHERNAME"].ToString();
                            lblPlotArea.Text = ds.Tables[7].Rows[0]["StateName"].ToString();
                            lblDistricted.Text = ds.Tables[7].Rows[0]["DistrictName"].ToString();
                            lblMaded.Text = ds.Tables[7].Rows[0]["MandalName"].ToString();
                            lblVillaed.Text = ds.Tables[7].Rows[0]["VillageName"].ToString();
                            lblMIGRANTlOCALITY.Text = ds.Tables[7].Rows[0]["RENCM_LOCALITY"].ToString();
                            lblLandMigrant.Text = ds.Tables[7].Rows[0]["RENCM_NEARLAND"].ToString();
                            lblMigrantPincode.Text = ds.Tables[7].Rows[0]["RENCM_PINCODE"].ToString();
                            lblBirthage.Text = ds.Tables[7].Rows[0]["RENCM_BIRTHAGE"].ToString();
                            if (lblBirthage.Text == "D")
                            {
                                Birth.Visible = true;
                                lblDate.Text = ds.Tables[7].Rows[0]["RENCM_DATEOFBIRTH"].ToString();
                                Ages.Visible = false;
                            }
                            else
                            {
                                Ages.Visible = true;
                                lblAges.Text = ds.Tables[7].Rows[0]["RENCM_AGE"].ToString();
                                Birth.Visible = false;
                            }


                            lblStateMigrant.Text = ds.Tables[7].Rows[0]["StateNameS"].ToString();
                            lblDistrictMigrant.Text = ds.Tables[7].Rows[0]["DistrictNameS"].ToString();
                            lblMandalMigrant.Text = ds.Tables[7].Rows[0]["MandalNameS"].ToString();
                            lblVillageMigrant.Text = ds.Tables[7].Rows[0]["VillageNameS"].ToString();
                            lblReMigrantLocal.Text = ds.Tables[7].Rows[0]["RENCM_LOCALITYS"].ToString();
                            lblReMigrantLand.Text = ds.Tables[7].Rows[0]["RENCM_LANDMARKS"].ToString();
                            lblReMigrantPincode.Text = ds.Tables[7].Rows[0]["RENCM_PINCODES"].ToString();
                            lblArtical5.Text = ds.Tables[7].Rows[0]["RENCM_ARTICLE5"].ToString();
                            lblCriminal.Text = ds.Tables[7].Rows[0]["RENCM_CRIMINALCASEAPP"].ToString();
                            lbl3Financial.Text = ds.Tables[7].Rows[0]["RENCM_CONVICTED5APPLICATION"].ToString();
                            lblDateContract.Text = ds.Tables[7].Rows[0]["RENCM_DISTRICCOUNCIL"].ToString();
                            lblLicensed.Text = ds.Tables[7].Rows[0]["RENCM_LICENSE"].ToString();
                            lblLicensedNo.Text = ds.Tables[7].Rows[0]["RENCM_LICNOS"].ToString();
                            lblDateOfLicense.Text = ds.Tables[7].Rows[0]["RENCM_DATEOFLICENSE"].ToString();
                            lblValidDateLic.Text = ds.Tables[7].Rows[0]["RENCM_VALIDDATE"].ToString();

                            lblNameOfEstablish.Text = ds.Tables[7].Rows[0]["RENCM_TRIBAL"].ToString();
                            lblMarket.Text = ds.Tables[7].Rows[0]["RENCM_REMARK"].ToString();
                            lblDistrictEstablish.Text = ds.Tables[7].Rows[0]["RENCM_NAMEEST"].ToString();
                            lblStallNo.Text = ds.Tables[7].Rows[0]["StateNameT"].ToString();
                            lblShillong5Years.Text = ds.Tables[7].Rows[0]["DistrictNameT"].ToString();
                            lblDetailsYes.Text = ds.Tables[7].Rows[0]["MandalNameT"].ToString();
                            lblGrossTurn.Text = ds.Tables[7].Rows[0]["VillageNameT"].ToString();
                            lblAmount.Text = ds.Tables[7].Rows[0]["RENCM_LOCAL"].ToString();
                            lblRegUnderAct.Text = ds.Tables[7].Rows[0]["RENCM_NEARESTLANDMAEK"].ToString();
                            lblRegCertificate.Text = ds.Tables[7].Rows[0]["RENCM_PIN"].ToString();
                            lblPrincipalEmpDet.Text = ds.Tables[7].Rows[0]["RENCM_TYPEOFBUSINESS"].ToString();
                            lblPrincipalEmpName.Text = ds.Tables[7].Rows[0]["RENCM_REGNO"].ToString();
                            lblMigrantWorkMen.Text = ds.Tables[7].Rows[0]["RENCM_DATEOFREG"].ToString();
                            lblContract179.Text = ds.Tables[7].Rows[0]["RENCM_TITLES"].ToString();
                            lblCommencing.Text = ds.Tables[7].Rows[0]["RENCM_DATECOMMENCING"].ToString();
                            lblEndingDates.Text = ds.Tables[7].Rows[0]["RENCM_ENDINGDATE"].ToString();
                            lblMaanagingSite.Text = ds.Tables[7].Rows[0]["RENCM_CONTRACTWORK"].ToString();
                            lblMigrantEmp.Text = ds.Tables[7].Rows[0]["RENCM_NAMEOFEMP"].ToString();
                            lblMigrantagent.Text = ds.Tables[7].Rows[0]["RENCM_MIGRANTNAMEEMP"].ToString();
                            lblContractFiveYears.Text = ds.Tables[7].Rows[0]["RENCM_AGENTNAME"].ToString();
                            if (lblContractFiveYears.Text == "Yes")
                            {
                                Migrant.Visible = true;
                                lblContractDetails.Text = ds.Tables[7].Rows[0]["RENCM_MAXIMUMNOMIGRANT"].ToString();
                            }

                            lblForfeiting.Text = ds.Tables[7].Rows[0]["RENCM_AGENTNAMEADDRESS"].ToString();
                            if (lblForfeiting.Text == "Yes")
                            {
                                Div3.Visible = true;
                                lblMigrantOrderNo.Text = ds.Tables[7].Rows[0]["RENCM_ORDERNO"].ToString();
                                lblMigrantOrderDate.Text = ds.Tables[7].Rows[0]["RENCM_ORDERDATE"].ToString();
                            }

                            lblEstPastFiveYears.Text = ds.Tables[7].Rows[0]["RENCM_WORKESTPAST5YEARS"].ToString();
                            if (lblEstPastFiveYears.Text == "Yes")
                            {
                                Div4.Visible = true;
                                lblESTABDetails.Text = ds.Tables[7].Rows[0]["RENCM_ESTDETAILS"].ToString();
                                lblPrinciplEstDetails.Text = ds.Tables[7].Rows[0]["RENCM_PRINCIPLEEMPDETAILS"].ToString();
                                Div5.Visible = true;
                                lblMigrantNatureWork.Text = ds.Tables[7].Rows[0]["RENCM_NATUREWORK"].ToString();
                            }
                            lblEMPEnclosed.Text = ds.Tables[7].Rows[0]["RENCM_EMPENCLOSED"].ToString();
                        }
                        else { ContractorMigrant.Visible = false; }
                    }
                    if (ds.Tables[8].Rows.Count > 0)
                    {
                        Drug.Visible = true;
                        if (Drug.Visible == true)
                        {
                            div_47_BLR.Visible = true;
                            GVDrugName.DataSource = ds.Tables[8];
                            GVDrugName.DataBind();
                        }
                        else { Drug.Visible = false; }
                    }
                    if (ds.Tables[9].Rows.Count > 0)
                    {
                        Drug.Visible = true;
                        if (Drug.Visible == true)
                        {
                            div6.Visible = true;
                            GVTEST.DataSource = ds.Tables[9];
                            GVTEST.DataBind();
                        }
                        else { Drug.Visible = false; }
                    }
                    if (ds.Tables[10].Rows.Count > 0)
                    {
                        Drug.Visible = true;
                        if (Drug.Visible == true)
                        {
                            div7.Visible = true;
                            GVMANU.DataSource = ds.Tables[10];
                            GVMANU.DataBind();
                        }
                        else { Drug.Visible = false; }
                    }
                    if (ds.Tables[11].Rows.Count > 0)
                    {
                        Drug.Visible = true;
                        if (Drug.Visible == true)
                        {
                            div8.Visible = true;
                            GVADDED.DataSource = ds.Tables[11];
                            GVADDED.DataBind();
                        }
                        else { Drug.Visible = false; }
                    }
                    if (ds.Tables[12].Rows.Count > 0)
                    {
                        Drug.Visible = true;
                        if (Drug.Visible == true)
                        {
                            lblArticle5.Text = ds.Tables[12].Rows[0]["RENDL_LICNO"].ToString();
                            lblShopindividual.Text = ds.Tables[12].Rows[0]["RENDL_EXPIRYDATE"].ToString();
                            lblMultiple.Text = ds.Tables[12].Rows[0]["RENDL_LICCANCEL"].ToString();
                            if (lblMultiple.Text == "Yes")
                            {
                                LicNos.Visible = true;
                                lblTaxPayer.Text = ds.Tables[12].Rows[0]["RENDL_LICNOSPECIFY"].ToString();
                            }

                            lblExise.Text = ds.Tables[12].Rows[0]["RENDL_PREMISEINSPECTION"].ToString();
                            if (lblExise.Text == "Yes")
                            {
                                Inspection.Visible = true;
                                lblProvideDet.Text = ds.Tables[12].Rows[0]["RENDL_INSPECTIONDATE"].ToString();
                            }

                            lblPunished.Text = ds.Tables[12].Rows[0]["RENDL_TOTALAMOUNT"].ToString();
                            lbllawRule.Text = ds.Tables[12].Rows[0]["RENDL_ADDITIONALFEES"].ToString();
                            lblapplicant.Text = ds.Tables[12].Rows[0]["RENDL_LATEFEES"].ToString();
                            lblbailable.Text = ds.Tables[12].Rows[0]["RENDL_REGFEES"].ToString();
                            lblTotalAmountPaid.Text = ds.Tables[12].Rows[0]["RENDL_TOTALPAIDAMOUNT"].ToString();

                        }
                        else { Drug.Visible = false; }
                    }
                    if (ds.Tables[13].Rows.Count > 0)
                    {
                        Factories.Visible = true;
                        if (Factories.Visible == true)
                        {
                            lblDateEstablishments.Text = ds.Tables[13].Rows[0]["RENFL_FULLNAME"].ToString();
                            lblRegNoFactory.Text = ds.Tables[13].Rows[0]["RENFL_LICNO"].ToString();
                            lblDateOfReg.Text = ds.Tables[13].Rows[0]["RENFL_LICISSUEDDATE"].ToString();
                            lblCurrentRegNo.Text = ds.Tables[13].Rows[0]["RENFL_RENEWALNO"].ToString();
                            lblRegADC.Text = ds.Tables[13].Rows[0]["RENFL_RENEWALDATE"].ToString();
                            lblDateRegistration.Text = ds.Tables[13].Rows[0]["RENFL_LICVALIDYEAR"].ToString();
                            lblNumberRegCurrent.Text = ds.Tables[13].Rows[0]["RENFL_FACTORIESL12MONTHS"].ToString();
                            lblPartnership.Text = ds.Tables[13].Rows[0]["RENFL_NEXT12MONTHS"].ToString();
                            lblCompany.Text = ds.Tables[13].Rows[0]["RENFL_MANUPRODUCT"].ToString();

                            lblNames.Text = ds.Tables[13].Rows[0]["RENFL_PRINCIPALPRODUCT"].ToString();
                            lblManuDetails.Text = ds.Tables[13].Rows[0]["RENFL_MAXNOEMP"].ToString();
                            lblManumeasure.Text = ds.Tables[13].Rows[0]["RENFL_MAXNOWORK"].ToString();
                            lblWeighting.Text = ds.Tables[13].Rows[0]["RENFL_NOORDINARIYEMP"].ToString();
                            lblRegNumberTax.Text = ds.Tables[13].Rows[0]["RENFL_UNITELECTRICPOWER"].ToString();
                            if (lblRegNumberTax.Text == "Yes")
                            {
                                Yesclick.Visible = true;
                                lblGST.Text = ds.Tables[13].Rows[0]["RENFL_TOTALCAPGENERATING"].ToString();
                            }
                            else
                            {
                                Noclick.Visible = true;
                                Nos.Visible = true;
                                lblITNumber.Text = ds.Tables[13].Rows[0]["RENFL_TOTALDGSET"].ToString();
                                lblStateimport.Text = ds.Tables[13].Rows[0]["RENFL_MAXPOWER"].ToString();
                            }


                            lblLICNumbers.Text = ds.Tables[13].Rows[0]["RENFL_FULLNAMEMANAGER"].ToString();
                            lblRegImportMeasure.Text = ds.Tables[13].Rows[0]["RENFL_RESIDENTIALADDRESS"].ToString();
                            lblManusold.Text = ds.Tables[13].Rows[0]["RENFL_FULLNAMEOWNER"].ToString();
                            lblDealerLic.Text = ds.Tables[13].Rows[0]["RENFL_OWNERADDRESSBUILD"].ToString();
                            lblManufactureDetails.Text = ds.Tables[13].Rows[0]["RENFL_NAMEOCCUPIER"].ToString();
                            lblSkilled.Text = ds.Tables[13].Rows[0]["RENFL_ADDRESSOCCUPIER"].ToString();
                            lblsemiSkill.Text = ds.Tables[13].Rows[0]["RENFL_PRIVATEFIRM"].ToString();
                            if (lblsemiSkill.Text == "Yes")
                            {
                                Factory.Visible = true;
                                lblUnskill.Text = ds.Tables[13].Rows[0]["RENFL_NAMEPROPRIETOR"].ToString();
                            }

                            lblSpecialist.Text = ds.Tables[13].Rows[0]["RENFL_PUBLICFIRM"].ToString();
                            if (lblSpecialist.Text == "Yes")
                            {
                                Proprietor.Visible = true;
                                lblManufactureWeight.Text = ds.Tables[13].Rows[0]["RENFL_NAMECHIEFHEAD"].ToString();
                            }

                            lbllongtermlease.Text = ds.Tables[13].Rows[0]["RENFL_GOVTLOCALFACTORY"].ToString();
                            if (lbllongtermlease.Text == "Yes")
                            {
                                Administrative.Visible = true;
                                lblvitaothermeans.Text = ds.Tables[13].Rows[0]["RENFL_NAMEDIRECTORS"].ToString();
                            }

                            lblElectricEnergy.Text = ds.Tables[13].Rows[0]["RENFL_MANAGINGAPPOINTEDAGENT"].ToString();
                            if (lblElectricEnergy.Text == "Yes")
                            {
                                Managing.Visible = true;
                                lblManuLic.Text = ds.Tables[13].Rows[0]["RENFL_NAMEOFAGENT"].ToString();
                            }

                            lblManuGiveDetails.Text = ds.Tables[13].Rows[0]["RENFL_FACTORYEXTENDED"].ToString();
                            if (lblManuGiveDetails.Text == "Yes")
                            {
                                Approvals.Visible = true;
                                lblFinancialloan.Text = ds.Tables[13].Rows[0]["RENFL_REFNOAPPROVALSITE"].ToString();
                                lblManuBank.Text = ds.Tables[13].Rows[0]["RENFL_DATEOFAPPROVAL"].ToString();
                                ApprovalArrange.Visible = true;
                                lblLabourgiveDetails.Text = ds.Tables[13].Rows[0]["RENFL_REFAPPROVALAUTHORITY"].ToString();
                                lblLoanWeight.Text = ds.Tables[13].Rows[0]["RENFL_DATEOFAPPROVALAUTHORITY"].ToString();
                            }


                            lblFinalFees.Text = ds.Tables[13].Rows[0]["RENFL_FINALFEES"].ToString();
                            lblPenalty.Text = ds.Tables[13].Rows[0]["RENFL_PENALTY"].ToString();
                            lblLicValidupto.Text = ds.Tables[13].Rows[0]["RENFL_LICVALIDUPTO"].ToString();
                            lblTotalAmountbePaid.Text = ds.Tables[13].Rows[0]["RENFL_TOTALAMOUNTPAID"].ToString();
                        }
                        else { Factories.Visible = false; }
                    }
                    if (ds.Tables[14].Rows.Count > 0)
                    {
                        Saftey.Visible = true;
                        if (Saftey.Visible == true)
                        {
                            lblMigrantWorkReg.Text = ds.Tables[14].Rows[0]["RENSD_MIGRANTREGNO"].ToString();
                            lblMigrantIssued.Text = ds.Tables[14].Rows[0]["RENSD_DISTRICREGISSUED"].ToString();
                            lblKinhomeState.Text = ds.Tables[14].Rows[0]["RENSD_NAMEKIN"].ToString();
                            lblMigrantAddress.Text = ds.Tables[14].Rows[0]["RENSD_ADDRESS"].ToString();
                            lblForceIndia.Text = ds.Tables[14].Rows[0]["RENSD_FORCEININDIA"].ToString();
                            lblCriminalAgainst.Text = ds.Tables[14].Rows[0]["RENSD_CRIMINALCASE"].ToString();
                            lblunsoundMind.Text = ds.Tables[14].Rows[0]["RENSD_UNSOUNDMIND"].ToString();
                            lblNatureEmployment.Text = ds.Tables[14].Rows[0]["RENSD_NATUREOFEMP"].ToString();
                            lblExpectedEmp.Text = ds.Tables[14].Rows[0]["RENSD_EMPEXPECTEDDATE"].ToString();
                            lblExpectedDuration.Text = ds.Tables[14].Rows[0]["RENSD_EXPECTEDDURATIONSTAY"].ToString();
                            lblDetailsMention.Text = ds.Tables[14].Rows[0]["RENSD_WORKDETAILS"].ToString();
                            lblDistrictArea.Text = ds.Tables[14].Rows[0]["RENSD_DISTRICAREA"].ToString();
                            lblAreaOfworkAddress.Text = ds.Tables[14].Rows[0]["RENSD_AREAOFWORK"].ToString();
                            lblExistingRegValid.Text = ds.Tables[14].Rows[0]["RENSD_EXSTINGREGVALIDDATE"].ToString();
                            lblworkMentionSkill.Text = ds.Tables[14].Rows[0]["RENSD_DETAILSOFSPECIFICSKILL"].ToString();
                            lblDistrictAreaofwork.Text = ds.Tables[14].Rows[0]["RENSD_DISTRICAREAOFWORKER"].ToString();
                            lblAreaaddresswork.Text = ds.Tables[14].Rows[0]["RENSD_WORKADDRESSAREA"].ToString();
                            lblRegRenewedDate.Text = ds.Tables[14].Rows[0]["RENSD_REGRENEWEDDATE"].ToString();
                            lblNameEstEmp.Text = ds.Tables[14].Rows[0]["RENSD_NAMEESTEMP"].ToString();
                            lblAdressEstMigrant.Text = ds.Tables[14].Rows[0]["RENSD_ADDRESSEST"].ToString();
                            lblContactEstEmp.Text = ds.Tables[14].Rows[0]["RENSD_CONTACTNO"].ToString();

                        }
                        else { Saftey.Visible = false; }
                    }
                    if (ds.Tables[15].Rows.Count > 0)
                    {
                        ShopEst.Visible = true;
                        if (ShopEst.Visible == true)
                        {
                            PostalAddress.Visible = true;
                            GVPROPERTIE.DataSource = ds.Tables[15];
                            GVPROPERTIE.DataBind();
                        }
                        else { ShopEst.Visible = false; }
                    }
                    if (ds.Tables[16].Rows.Count > 0)
                    {
                        ShopEst.Visible = true;
                        if (ShopEst.Visible == true)
                        {
                            dependentEmp.Visible = true;
                            GVPATNER.DataSource = ds.Tables[16];
                            GVPATNER.DataBind();
                        }
                        else { ShopEst.Visible = false; }
                    }
                    if (ds.Tables[17].Rows.Count > 0)
                    {
                        ShopEst.Visible = true;
                        if (ShopEst.Visible == true)
                        {
                            Div9.Visible = true;
                            GVLIMITED.DataSource = ds.Tables[11];
                            GVLIMITED.DataBind();
                        }
                        else { ShopEst.Visible = false; }
                    }
                    if (ds.Tables[18].Rows.Count > 0)
                    {
                        ShopEst.Visible = true;
                        if (ShopEst.Visible == true)
                        {
                            if (lblgodownEst.Text == "Yes")
                            {
                                Div10.Visible = true;
                                GVDETAIL.DataSource = ds.Tables[18];
                                GVDETAIL.DataBind();
                            }
                            else { Div10.Visible = false; }

                        }
                        else { ShopEst.Visible = false; }
                    }
                    if (ds.Tables[19].Rows.Count > 0)
                    {
                        ShopEst.Visible = true;
                        if (ShopEst.Visible == true)
                        {
                            if (lblFamilyEstDept.Text == "Yes")
                            {
                                Div11.Visible = true;
                                GVTESTED.DataSource = ds.Tables[19];
                                GVTESTED.DataBind();
                            }
                            else { Div11.Visible = false; }

                        }
                        else { ShopEst.Visible = false; }
                    }
                    if (ds.Tables[20].Rows.Count > 0)
                    {
                        ShopEst.Visible = true;

                        if (ShopEst.Visible == true)
                        {
                            lblLicNoRenewal.Text = ds.Tables[20].Rows[0]["RENSE_LICNO"].ToString();
                            lblLicIssuedDates.Text = ds.Tables[20].Rows[0]["RENSE_LICISSUEDATE"].ToString();
                            lblLicRenewalvalidupto.Text = ds.Tables[20].Rows[0]["RENSE_LICVALIDUP"].ToString();
                            lblNameEstablish.Text = ds.Tables[20].Rows[0]["RENSE_NAMEEST"].ToString();
                            lblBusinessConstitute.Text = ds.Tables[20].Rows[0]["RENSE_CONSTITUTION"].ToString();
                            lblApplicantNames.Text = ds.Tables[20].Rows[0]["RENSE_APPLICANTNAME"].ToString();
                            lblMobileNumbers.Text = ds.Tables[20].Rows[0]["RENSE_MOBILENO"].ToString();
                            lblEmailIdes.Text = ds.Tables[20].Rows[0]["RENSE_EMAILID"].ToString();
                            lblNameManagement.Text = ds.Tables[20].Rows[0]["RENSE_NAMEOFMANAGER"].ToString();
                            lblAddressAgent.Text = ds.Tables[20].Rows[0]["RENSE_ADDRESS"].ToString();
                            lblCategoryEst.Text = ds.Tables[20].Rows[0]["RENSE_CATEGORYEST"].ToString();
                            lblShopBusiness.Text = ds.Tables[20].Rows[0]["RENSE_NATUREBUSINESS"].ToString();
                            lblFamilyEstDept.Text = ds.Tables[20].Rows[0]["RENSE_YOURFAMILY"].ToString();
                            lblEmpEstablish.Text = ds.Tables[20].Rows[0]["RENSE_EMPLOYEESEST"].ToString();
                            if (lblEmpEstablish.Text == "Yes")
                            {
                                NumberEmp.Visible = true;
                                lblNumberEmp.Text = ds.Tables[20].Rows[0]["RENSE_NOOFEMPLOYEE"].ToString();
                            }

                            lblshopdistrict.Text = ds.Tables[20].Rows[0]["DistrictName"].ToString();
                            lblshopmandal.Text = ds.Tables[20].Rows[0]["Mandalname"].ToString();
                            lblshopvillage.Text = ds.Tables[20].Rows[0]["VillageName"].ToString();
                            lblshoplocality.Text = ds.Tables[20].Rows[0]["RENSE_LOCALITY"].ToString();
                            lblshoppincode.Text = ds.Tables[20].Rows[0]["RENSE_PINCODE"].ToString();
                            lblshoplandmark.Text = ds.Tables[20].Rows[0]["RENSE_LANDMARK"].ToString();
                            lblgodownEst.Text = ds.Tables[20].Rows[0]["RENSE_GODOWN"].ToString();
                            lblRegRenewed.Text = ds.Tables[20].Rows[0]["RENSE_REGRENEWEDDATE"].ToString();
                            lblRegValidupto.Text = ds.Tables[20].Rows[0]["RENSE_REGVALIDDATE"].ToString();
                            lblNoYeraRenewed.Text = ds.Tables[20].Rows[0]["RENSE_YEARRENEWED"].ToString();
                            lblFeesRenewal.Text = ds.Tables[20].Rows[0]["RENSE_FEES"].ToString();
                            lblChangeNotice.Text = ds.Tables[20].Rows[0]["RENSE_FEESNOTICE"].ToString();
                            lblFineMigrant.Text = ds.Tables[20].Rows[0]["RENSE_FINE"].ToString();
                            lblPenaltyes.Text = ds.Tables[20].Rows[0]["RENSE_PENALTY"].ToString();
                            lblAmountpaid.Text = ds.Tables[20].Rows[0]["RENSE_TOTALPAIDAMOUNT"].ToString();
                        }
                        else { ShopEst.Visible = false; }


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