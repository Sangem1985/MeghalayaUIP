﻿using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOApplDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
        string Unitid;
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
                    //Session["CFOUNITID"] = "1001";
                    //Unitid = Convert.ToString(Session["CFOUNITID"]);

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindCFOApplicatinDetails();
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
        public void BindCFOApplicatinDetails()
        {
            try
            {
                if (Session["CFOUNITID"] != null && hdnUserID.Value != null)
                {
                    DataSet ds = new DataSet();
                    ds = objcfobal.GetCFOApplicationDetails(Convert.ToString(Session["CFOUNITID"]), hdnUserID.Value);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        lblnameUnit.Text = ds.Tables[0].Rows[0]["CFOQD_PREREGUIDNO"].ToString();
                        lblCompanyType.Text = ds.Tables[0].Rows[0]["CFOQD_COMPANYNAME"].ToString();
                        lblProposal.Text = ds.Tables[0].Rows[0]["CFOQD_PROPOSALFOR"].ToString();
                        lblNatureIndustry.Text = ds.Tables[0].Rows[0]["CFOQD_COMPANYTYPE"].ToString();
                        lblDistric.Text = ds.Tables[0].Rows[0]["DistrictName"].ToString();
                        lblMandals.Text = ds.Tables[0].Rows[0]["Mandalname"].ToString();
                        lblVilla.Text = ds.Tables[0].Rows[0]["VillageName"].ToString();
                        lblExtentLand.Text = ds.Tables[0].Rows[0]["CFOQD_TOTALEXTENTLAND"].ToString();
                        lblBuiltArea.Text = ds.Tables[0].Rows[0]["CFOQD_BUILTUPAREA"].ToString();
                        lblSectors.Text = ds.Tables[0].Rows[0]["CFOQD_SECTOR"].ToString();
                        lblActivity.Text = ds.Tables[0].Rows[0]["LineofActivity_Name"].ToString();
                        lblPcb.Text = ds.Tables[0].Rows[0]["CFOQD_PCBCATEGORY"].ToString();
                        lblMIDCL.Text = ds.Tables[0].Rows[0]["CFOQD_MIDCLLAND"].ToString();
                        lblLocationUnit.Text = ds.Tables[0].Rows[0]["CFOQD_UNTLOCATION"].ToString();
                        lblproposeEMP.Text = ds.Tables[0].Rows[0]["CFOQD_PROPEMP"].ToString();
                        lblLANDINR.Text = ds.Tables[0].Rows[0]["CFOQD_LANDVALUE"].ToString();
                        lblBuildingINR.Text = ds.Tables[0].Rows[0]["CFOQD_BUILDINGVALUE"].ToString();
                        lblMachineryINR.Text = ds.Tables[0].Rows[0]["CFOQD_PMCOST"].ToString();
                        lblExpectTurnINR.Text = ds.Tables[0].Rows[0]["CFOQD_EXPECTEDTURNOVER"].ToString();
                        lblTPCost.Text = ds.Tables[0].Rows[0]["CFOQD_TOTALPROJCOST"].ToString();
                        lblEnterpriseCat.Text = ds.Tables[0].Rows[0]["CFOQD_ENTERPRISETYPE"].ToString();

                    }
                    if (ds != null && ds.Tables.Count > 1 &&  ds.Tables[1].Rows.Count > 0)
                    {
                        lblBNameCompany.Text = ds.Tables[1].Rows[0]["CFOID_COMPANYNAME"].ToString();
                        lblTypecompany.Text = ds.Tables[1].Rows[0]["CFOID_COMPANYTYPE"].ToString();
                        lblCompanyProposal.Text = ds.Tables[1].Rows[0]["CFOID_PROPOSALFOR"].ToString();
                        lblCategory.Text = ds.Tables[1].Rows[0]["REGISTRATIONTYPENAME"].ToString();
                        lblRegistration.Text = ds.Tables[1].Rows[0]["CFOID_REGNO"].ToString();
                        lblDate.Text = ds.Tables[1].Rows[0]["CFOID_REGDATE"].ToString();
                        lblFactory.Text = ds.Tables[1].Rows[0]["CFOID_FACTORYTYPE"].ToString();
                        lblDetName.Text = ds.Tables[1].Rows[0]["CFOID_REPNAME"].ToString();
                        lblDetSon.Text = ds.Tables[1].Rows[0]["CFOID_REPSoWoDo"].ToString();
                        lblDetEmail.Text = ds.Tables[1].Rows[0]["CFOID_REPEMAIL"].ToString();
                        lblDetMobile.Text = ds.Tables[1].Rows[0]["CFOID_REPMOBILE"].ToString();
                        lblDetAlter.Text = ds.Tables[1].Rows[0]["CFOID_REPALTMOBILE"].ToString();
                        lblDetLand.Text = ds.Tables[1].Rows[0]["CFOID_REPTELPHNO"].ToString();
                        lblDetDoor.Text = ds.Tables[1].Rows[0]["CFOID_REPDOORNO"].ToString();
                        lblDetLocality.Text = ds.Tables[1].Rows[0]["CFOID_REPLOCALITY"].ToString();
                        lblDetDistrict.Text = ds.Tables[1].Rows[0]["DistrictName"].ToString();
                        lblDetMandal.Text = ds.Tables[1].Rows[0]["Mandalname"].ToString();
                        lblDetVillage.Text = ds.Tables[1].Rows[0]["VillageName"].ToString();
                        lblDetPincode.Text = ds.Tables[1].Rows[0]["CFOID_REPPINCODE"].ToString();
                        lblDetWomen.Text = ds.Tables[1].Rows[0]["CFOID_REPISWOMANENTR"].ToString();
                        lblDetAbled.Text = ds.Tables[1].Rows[0]["CFOID_REPISDIFFABLED"].ToString();
                        lblArcName.Text = ds.Tables[1].Rows[0]["CFOID_ARCHTCTNAME"].ToString();
                        lblArcLicNo.Text = ds.Tables[1].Rows[0]["CFOID_ARCHTCTLICNO"].ToString();
                        lblArcMobileNo.Text = ds.Tables[1].Rows[0]["CFOID_ARCHTCTMOBILE"].ToString();
                        lblStrName.Text = ds.Tables[1].Rows[0]["CFOID_SRTCTENGNRNAME"].ToString();
                        lblStrLicNo.Text = ds.Tables[1].Rows[0]["CFOID_SRTCTENGNRLICNO"].ToString();
                        lblStrMobileno.Text = ds.Tables[1].Rows[0]["CFOID_SRTCTENGNRMOBILE"].ToString();
                        // lblAreaDevelop.Text = ds.Tables[1].Rows[0][""].ToString();
                        lblRoad.Text = ds.Tables[1].Rows[0]["CFOID_APPROACHROADTYPE"].ToString();
                        lblwidthRoad.Text = ds.Tables[1].Rows[0]["CFOID_APPROACHROADWIDTH"].ToString();
                        lblAffected.Text = ds.Tables[1].Rows[0]["CFOID_AFFECTEDRDWDNG"].ToString();
                        if (lblAffected.Text == "Yes")
                        {
                            divAffectArea.Visible = true;
                            lblExtend.Text = ds.Tables[1].Rows[0]["CFOID_AFFECTEDRDAREA"].ToString();
                        }

                        lblTotal.Text = ds.Tables[1].Rows[0]["CFOID_TOTALEMP"].ToString();
                        lblDirectMale.Text = ds.Tables[1].Rows[0]["CFOID_DIRECTMALE"].ToString();
                        lblDirectFemale.Text = ds.Tables[1].Rows[0]["CFOID_DIRECTFEMALE"].ToString();
                        lblOtherEmp.Text = ds.Tables[1].Rows[0]["CFOID_DIRECTOTHERS"].ToString();
                        lblIndMale.Text = ds.Tables[1].Rows[0]["CFOID_INDIRECTMALE"].ToString();
                        lblIndFemale.Text = ds.Tables[1].Rows[0]["CFOID_INDIRECTFEMALE"].ToString();
                        lblIndEmp.Text = ds.Tables[1].Rows[0]["CFOID_INDIRECTOTHERS"].ToString();


                    }
                    if (ds != null && ds.Tables.Count > 2 &&  ds.Tables[2].Rows.Count > 0)
                    {
                        //  lbllineActivity.Text = Convert.ToString(ds.Tables[3].Rows[0]["LineofActivity_Name"]);
                        gvManufacture.DataSource = ds.Tables[2];
                        gvManufacture.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 3 &&  ds.Tables[3].Rows.Count > 0)
                    {
                        gvRwaMaterial.DataSource = ds.Tables[3];
                        gvRwaMaterial.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 4 &&  ds.Tables[4].Rows.Count > 0)
                    {
                        DrugLic.Visible = true;

                        lblApplType.Text = ds.Tables[4].Rows[0]["CFODL_APPLTYPE"].ToString();
                        lblTNTDATE.Text = ds.Tables[4].Rows[0]["CFODL_TRADELICVALDTYDATE"].ToString();
                        lblMunicipality.Text = ds.Tables[4].Rows[0]["CFODL_MUNCPERMVALDTYDATE"].ToString();
                        lblColdStorage.Text = ds.Tables[4].Rows[0]["CFODL_COLDSTORGDETAILS"].ToString();

                        div_license.Visible = true;

                        lblcancel.Text = ds.Tables[4].Rows[0]["CFODL_ANYPREVLIC"].ToString();
                        if (lblcancel.Text == "Yes")
                        {
                            CanceledLIC.Visible = true;
                            lbllicno.Text = ds.Tables[4].Rows[0]["CFODL_PREVLICDETAILS"].ToString();
                        }
                        if (div_52.Visible == true)
                        {
                            lblpremiseplan.Text = ds.Tables[4].Rows[0]["CFODL_PREMISERDYFORINSP"].ToString();
                        }
                        if (Inception.Visible == true)
                        {
                            lblDateInspe.Text = ds.Tables[4].Rows[0]["CFODL_DATEOFINSP"].ToString();
                        }


                    }
                    if (ds != null && ds.Tables.Count > 5 &&  ds.Tables[5].Rows.Count > 0)
                    {
                        DrugLic.Visible = true;

                        div_Staff_Manf.Visible = true;
                        GVHealthy.DataSource = ds.Tables[5];
                        GVHealthy.DataBind();


                    }
                    if (ds != null && ds.Tables.Count > 6 &&  ds.Tables[6].Rows.Count > 0)
                    {
                        DrugLic.Visible = true;

                        div_Staff_Test.Visible = true;
                        GVTESTING.DataSource = ds.Tables[6];
                        GVTESTING.DataBind();

                    }
                    if (ds != null && ds.Tables.Count > 7 &&  ds.Tables[7].Rows.Count > 0)
                    {
                        DrugLic.Visible = true;

                        div_48.Visible = true;
                        GVDrug.DataSource = ds.Tables[7];
                        GVDrug.DataBind();

                    }
                    if (ds != null && ds.Tables.Count > 8 &&  ds.Tables[8].Rows.Count > 0)
                    {
                        ProffessionalTax.Visible = true;

                        lblEstName.Text = ds.Tables[8].Rows[0]["CFOPT_ESTBLSHNAME"].ToString();
                        lblAddressEst.Text = ds.Tables[8].Rows[0]["CFOPT_ESTBLSHADDRESS"].ToString();
                        lblDistrictEST.Text = ds.Tables[8].Rows[0]["CFOPT_ESTBLSHDISTID"].ToString();
                        lblpinest.Text = ds.Tables[8].Rows[0]["CFOPT_ESTBLSHPINCODE"].ToString();
                        lblTotalEst.Text = ds.Tables[8].Rows[0]["CFOPT_ESTBLSHEMP"].ToString();
                        lblGoodEst.Text = ds.Tables[8].Rows[0]["CFOPT_ESTBLSHGOODS"].ToString();
                        lblDateCommence.Text = ds.Tables[8].Rows[0]["CFOPT_COMMENCEDDATE"].ToString();
                        lblGross.Text = ds.Tables[8].Rows[0]["CFOPT_ANNUALINCOME"].ToString();
                        lblMeghalaya.Text = ds.Tables[8].Rows[0]["CFOPT_ADDLBSNESTATE"].ToString();
                        lblbusinessindia.Text = ds.Tables[8].Rows[0]["CFOPT_ADDLBSNECOUNTRY"].ToString();
                        lblForeign.Text = ds.Tables[8].Rows[0]["CFOPT_ADDLBSNEFOREIGN"].ToString();
                        lblRegUnder.Text = ds.Tables[8].Rows[0]["CFOPT_HADANYREG"].ToString();

                        if (lblRegUnder.Text == "Yes")
                        {
                            RegistrationType.Visible = true;
                            lblRegType.Text = ds.Tables[8].Rows[0]["CFOPT_REGTYPE"].ToString();

                            RegNo.Visible = true;
                            lblRegNo.Text = ds.Tables[8].Rows[0]["CFOPT_REGNO"].ToString();
                        }





                    }
                    if (ds != null && ds.Tables.Count > 9 &&  ds.Tables[9].Rows.Count > 0)
                    {
                        if (lblMeghalaya.Text == "Yes")
                        {
                            AdditionDetails.Visible = true;
                            GVState.DataSource = ds.Tables[9];
                            GVState.DataBind();
                        }

                    }
                    if (ds != null && ds.Tables.Count > 10 &&  ds.Tables[10].Rows.Count > 0)
                    {
                        if (lblbusinessindia.Text == "Yes")
                        {
                            Added.Visible = true;
                            GVCOUNTRY.DataSource = ds.Tables[10];
                            GVCOUNTRY.DataBind();
                        }

                    }
                    if (ds != null && ds.Tables.Count >11 &&  ds.Tables[11].Rows.Count > 0)
                    {
                        if (lblForeign.Text == "Yes")
                        {
                            foreign.Visible = true;
                            GVFOREIGN.DataSource = ds.Tables[11];
                            GVFOREIGN.DataBind();
                        }

                    }
                    if (ds != null && ds.Tables.Count > 12 &&  ds.Tables[12].Rows.Count > 0)
                    {
                        FireDet.Visible = true;

                        lblNameofDet.Text = ds.Tables[12].Rows[0]["CFOFD_BUILDNAME"].ToString();
                        lblBuildingFire.Text = ds.Tables[12].Rows[0]["CFOFD_CATEGORYBUILD"].ToString();
                        lblFees.Text = ds.Tables[12].Rows[0]["CFOFD_FEEAMOUNT"].ToString();
                        lblDistrics.Text = ds.Tables[12].Rows[0]["CFOFD_DISTRICID"].ToString();
                        lblMand.Text = ds.Tables[12].Rows[0]["CFOFD_MANDALID"].ToString();
                        lblTown.Text = ds.Tables[12].Rows[0]["CFOFD_VILLAGEID"].ToString();
                        lblLocality.Text = ds.Tables[12].Rows[0]["CFOFD_Locality"].ToString();
                        lblNearstLand.Text = ds.Tables[12].Rows[0]["CFOFD_Landmark"].ToString();
                        lblPin.Text = ds.Tables[12].Rows[0]["CFOFD_Pincode"].ToString();
                        lblPlotArea.Text = ds.Tables[12].Rows[0]["CFOFD_PLOTAREA"].ToString();
                        lblBreadth.Text = ds.Tables[12].Rows[0]["CFOFD_DRIVEPROPSED"].ToString();
                        lblBuildArea.Text = ds.Tables[12].Rows[0]["CFOFD_BUILDUPAREA"].ToString();
                        lblApproachRoad.Text = ds.Tables[12].Rows[0]["CFOFD_EXISTINGROAD"].ToString();
                        lblEast.Text = ds.Tables[12].Rows[0]["CFOFD_East"].ToString();
                        lblDistanceprop.Text = ds.Tables[12].Rows[0]["CFOFD_West"].ToString();
                        lblwest.Text = ds.Tables[12].Rows[0]["CFOFD_North"].ToString();
                        lblbUILDDIST.Text = ds.Tables[12].Rows[0]["CFOFD_South"].ToString();
                        lblNorth.Text = ds.Tables[12].Rows[0]["CFOFD_DISTANCEEAST"].ToString();
                        lblDistBuild.Text = ds.Tables[12].Rows[0]["CFOFD_DISTANCEWEST"].ToString();
                        lblSouth.Text = ds.Tables[12].Rows[0]["CFOFD_DISTANCENORTH"].ToString();
                        lblbuildProp.Text = ds.Tables[12].Rows[0]["CFOFD_DISTANCESOUTH"].ToString();
                        lblFireStation.Text = ds.Tables[12].Rows[0]["CFOFD_FIRESTATION"].ToString();


                    }
                    if (ds != null && ds.Tables.Count > 13 &&  ds.Tables[13].Rows.Count > 0)
                    {
                        ContractorReg.Visible = true;

                        lblApplication.Text = ds.Tables[13].Rows[0]["CFOWC_APPLPURPOSE"].ToString();
                        lblRegContractor.Text = ds.Tables[13].Rows[0]["CFOWC_CONTRREGCLASS"].ToString();
                        if (lblRegContractor.Text == "1")
                        {
                            director.Visible = true;
                            lblManuDirectorate.Text = ds.Tables[13].Rows[0]["CFOWC_DIRECTORATE"].ToString();
                        }
                        else if (lblRegContractor.Text == "2")
                        {
                            circle.Visible = true;
                            lblCircle.Text = ds.Tables[13].Rows[0]["CFOWC_CIRCLE"].ToString();
                        }
                        else if (lblRegContractor.Text == "3")
                        {
                            division.Visible = true;
                            lblDivision.Text = ds.Tables[13].Rows[0]["CFOWC_DIVISION"].ToString();
                        }

                        // lbldirector.Text = ds.Tables[13].Rows[0][""].ToString();
                        lblBankName.Text = ds.Tables[13].Rows[0]["CFOWC_CONTRBANKNAME"].ToString();
                        lblTurnOver.Text = ds.Tables[13].Rows[0]["CFOWC_CONTRTURNOVER"].ToString();
                        lbl3Financial.Text = ds.Tables[13].Rows[0]["CFOWC_CONTR3YRSTURNOVER"].ToString();
                        lblDateContract.Text = ds.Tables[13].Rows[0]["CFOWC_CONTRSTARTDATE"].ToString();


                    }
                    if (ds != null && ds.Tables.Count > 14 &&  ds.Tables[14].Rows.Count > 0)
                    {
                        ExciseDep.Visible = true;

                        lblArticle5.Text = ds.Tables[14].Rows[0]["Artical5Selection"].ToString();
                        lblindividual.Text = ds.Tables[14].Rows[0]["ApplicantSelection"].ToString();
                        lblMultiple.Text = ds.Tables[14].Rows[0]["MemberSelection"].ToString();
                        lblTaxPayer.Text = ds.Tables[14].Rows[0]["TaxSelection"].ToString();
                        lblSalesTax.Text = ds.Tables[14].Rows[0]["SaleTaxSelection"].ToString();
                        lblProfessionalTax.Text = ds.Tables[14].Rows[0]["ProfessionSelection"].ToString();
                        lblExise.Text = ds.Tables[14].Rows[0]["GovernmentSelection"].ToString();
                        if (lblExise.Text == "Yes")
                        {
                            Excisedept.Visible = true;
                            lblProvideDet.Text = ds.Tables[14].Rows[0]["GovernmentDetails"].ToString();
                        }


                        lblPunished.Text = ds.Tables[14].Rows[0]["ViolationSelection"].ToString();
                        if (lblPunished.Text == "Yes")
                        {
                            RulesOrder.Visible = true;
                            lbllawRule.Text = ds.Tables[14].Rows[0]["ViolationDetails"].ToString();
                        }


                        lblapplicant.Text = ds.Tables[14].Rows[0]["ConvictedSelection"].ToString();
                        if (lblapplicant.Text == "Yes")
                        {
                            convictedlaw.Visible = true;
                            lblbailable.Text = ds.Tables[14].Rows[0]["ConvictedDetails"].ToString();
                        }

                        //lblLiquor.Text = ds.Tables[14].Rows[0][""].ToString();
                        //lblMRP.Text = ds.Tables[14].Rows[0][""].ToString();
                        lblRenewalBIO.Text = ds.Tables[14].Rows[0]["RenewBrand"].ToString();
                        if (lblRenewalBIO.Text == "Yes")
                        {
                            Brands.Visible = true;
                            lblRegFromDate.Text = ds.Tables[14].Rows[0]["RegFromDate"].ToString();
                            TodateReg.Visible = true;
                            lblToDate.Text = ds.Tables[14].Rows[0]["RegToDate"].ToString();
                        }


                        lblNameAddress.Text = ds.Tables[14].Rows[0]["FirmAddress"].ToString();


                    }
                    if (ds != null && ds.Tables.Count > 15 &&  ds.Tables[15].Rows.Count > 0)
                    {
                        ExciseDep.Visible = true;

                        div_47_BLR.Visible = true;
                        gvBrandDetails.DataSource = ds.Tables[15];
                        gvBrandDetails.DataBind();

                    }
                    if (ds != null && ds.Tables.Count > 16 &&  ds.Tables[16].Rows.Count > 0)
                    {
                        ExciseDep.Visible = true;
                        GvLiquor.DataSource = ds.Tables[16];
                        GvLiquor.DataBind();

                    }
                    if (ds != null && ds.Tables.Count > 17 &&  ds.Tables[17].Rows.Count > 0)
                    {
                        Pollutioncontrol.Visible = true;

                        lblDateEstablish.Text = ds.Tables[17].Rows[0]["CFOB_ESTBDATE"].ToString();
                        lblLocationStall.Text = ds.Tables[17].Rows[0]["CFOB_STALLLOCATION"].ToString();
                        if (lblLocationStall.Text == "Yes")
                        {
                            stall.Visible = true;
                            lblHoldingNo.Text = ds.Tables[17].Rows[0]["CFOB_HOLDINGNO"].ToString();
                            MarketName.Visible = true;
                            lblMarket.Text = ds.Tables[17].Rows[0]["CFOB_MARKETNAME"].ToString();
                            District.Visible = true;
                            lblDistrictEstablish.Text = ds.Tables[17].Rows[0]["CFOB_ESTBDISTRICT"].ToString();
                            Districmaster.Visible = true;
                            lblStallNo.Text = ds.Tables[17].Rows[0]["CFOB_STALLNO"].ToString();
                        }

                        lblShillong5Years.Text = ds.Tables[17].Rows[0]["CFOB_ANYBUSINESS"].ToString();
                        if (lblShillong5Years.Text == "Yes")
                        {
                            Municipality.Visible = true;
                            lblDetailsYes.Text = ds.Tables[17].Rows[0]["CFOB_BUSINESSDETAILS"].ToString();
                        }

                        lblGrossTurn.Text = ds.Tables[17].Rows[0]["CFOB_ANNUALGROSSTURNOVER"].ToString();
                        lblAmount.Text = ds.Tables[17].Rows[0]["CFOB_TOTALFEE"].ToString();

                    }
                    if (ds != null && ds.Tables.Count > 18 &&  ds.Tables[18].Rows.Count > 0)
                    {
                        Pollutioncontrol.Visible = true;

                        GVPollution.DataSource = ds.Tables[18];
                        GVPollution.DataBind();

                    }
                    if (ds != null && ds.Tables.Count > 19 && ds.Tables[19].Rows.Count > 0)
                    {
                        Labourdet.Visible = true;

                        lblDirectorate.Text = ds.Tables[19].Rows[0]["CFOLD_DIRECTINDIRECT"].ToString();
                        lblApplied.Text = ds.Tables[19].Rows[0]["CFOLD_APPLIED"].ToString();
                        lblYearEst.Text = ds.Tables[19].Rows[0]["CFOLD_YEAR"].ToString();
                        lblDocumenteryEvidence.Text = ds.Tables[19].Rows[0]["CFOLD_TEMPMATERIAL"].ToString();
                        lblRegulation1950.Text = ds.Tables[19].Rows[0]["CFOLD_REGULATION1950"].ToString();
                        lblRegulation392.Text = ds.Tables[19].Rows[0]["CFOLD_GENGRINDE"].ToString();
                        lblPersonnelDesig.Text = ds.Tables[19].Rows[0]["CFOLD_DESIGNATION"].ToString();
                        lblSite.Text = ds.Tables[19].Rows[0]["CFOLD_SITES"].ToString();
                        lblStrictly81.Text = ds.Tables[19].Rows[0]["CFOLD_REGULATION81"].ToString();
                        lblHighStanded.Text = ds.Tables[19].Rows[0]["CFOLD_CONTROVERSIAL"].ToString();
                        lblFirmMaterial.Text = ds.Tables[19].Rows[0]["CFOLD_MATERIAL"].ToString();
                        lblInternalOwn.Text = ds.Tables[19].Rows[0]["CFOLD_OWNSYSTEM"].ToString();
                        lblBoiler1950.Text = ds.Tables[19].Rows[0]["CFOLD_UPLOADDOCUMENT"].ToString();
                        if (lblDirectorate.Text == "Yes")
                        {
                            Approved.Visible = true;
                            lblProvide.Text = ds.Tables[19].Rows[0]["CFOLD_PROVIDEDETAILS"].ToString();

                        }

                        lblNameManufacture.Text = ds.Tables[19].Rows[0]["CFOLD_MANUFACTURENAME"].ToString();
                        lblYearManufactures.Text = ds.Tables[19].Rows[0]["CFOLD_MANUYEAR"].ToString();
                        lblManufactures.Text = ds.Tables[19].Rows[0]["CFOLD_MANUPLACE"].ToString();
                        lblBoilerMaker.Text = ds.Tables[19].Rows[0]["CFOLD_BOILERNUMBER"].ToString();
                        lblIntendedWork.Text = ds.Tables[19].Rows[0]["CFOLD_INTENDED"].ToString();
                        lblPlacemodule.Text = ds.Tables[19].Rows[0]["CFOLD_MANUFACTUREPLACE"].ToString();
                        lblSuperHeater.Text = ds.Tables[19].Rows[0]["CFOLD_HEATERRATING"].ToString();
                        lblEcoRating.Text = ds.Tables[19].Rows[0]["CFOLD_ECONOMISERRATING"].ToString();
                        lblMaxTonnes.Text = ds.Tables[19].Rows[0]["CFOLD_EVAPORATION"].ToString();
                        lblReheater.Text = ds.Tables[19].Rows[0]["CFOLD_REHEATERRATING"].ToString();
                        lblWorkingSeason.Text = ds.Tables[19].Rows[0]["CFOLD_SEASON"].ToString();
                        lblPSI.Text = ds.Tables[19].Rows[0]["CFOLD_PRESSURE"].ToString();
                        lblOwner.Text = ds.Tables[19].Rows[0]["CFOLD_OWNERNAME"].ToString();
                        lblTypeBoiler.Text = ds.Tables[19].Rows[0]["CFOLD_TYPEBOILER"].ToString();
                        lblBoilerDesc.Text = ds.Tables[19].Rows[0]["CFOLD_DESCBOILER"].ToString();
                        lblBoilerRating.Text = ds.Tables[19].Rows[0]["CFOLD_BOILERRATING"].ToString();
                        lblOwnership.Text = ds.Tables[19].Rows[0]["CFOLD_BOILEROWNERTRANSF"].ToString();
                        if (lblOwnership.Text == "Yes")
                        {
                            RemarkTransfer.Visible = true;
                            lblRemark.Text = ds.Tables[19].Rows[0]["CFOLD_REMARK"].ToString();
                        }

                        lblNameManu.Text = ds.Tables[19].Rows[0]["CFOLD_MANUNAME"].ToString();
                        lblYearManu.Text = ds.Tables[19].Rows[0]["CFOLD_MANUFACTUREYEAR"].ToString();
                        lblPlaceManu.Text = ds.Tables[19].Rows[0]["CFOLD_MANUFACTPLACE"].ToString();
                        lblNameManger.Text = ds.Tables[19].Rows[0]["CFOLD_NAMEAGENT"].ToString();
                        lblAddressAgent.Text = ds.Tables[19].Rows[0]["CFOLD_ADDRESSAGENT"].ToString();
                        lblEmpLabour.Text = ds.Tables[19].Rows[0]["CFOLD_WORKETAILS"].ToString();
                        lbllabourDays.Text = ds.Tables[19].Rows[0]["CFOLD_DAYSLABOUR"].ToString();
                        lblEstDateComm.Text = ds.Tables[19].Rows[0]["CFOLD_ESTDATE"].ToString();
                        lblEndingDate.Text = ds.Tables[19].Rows[0]["CFOLD_ENDDATE"].ToString();
                        lbllabourEmp.Text = ds.Tables[19].Rows[0]["CFOLD_CONTRACTEMP"].ToString();
                        lblContractor5.Text = ds.Tables[19].Rows[0]["CFOLD_FIVEYEARCONVICTED"].ToString();
                        if (lblContractor5.Text == "Yes")
                        {
                            contractor.Visible = true;
                            lblDetails5.Text = ds.Tables[19].Rows[0]["CFOLD_DETAILS"].ToString();
                        }

                        lblRevokingLic.Text = ds.Tables[19].Rows[0]["CFOLD_REVORKING"].ToString();
                        if (lblRevokingLic.Text == "Yes")
                        {
                            OrderDate.Visible = true;
                            lblOrderDate.Text = ds.Tables[19].Rows[0]["CFOLD_ORDERDAET"].ToString();
                        }

                        lblPast5.Text = ds.Tables[19].Rows[0]["CFOLD_ESTCONTRACTOR"].ToString();
                        if (lblPast5.Text == "Yes")
                        {
                            Principle.Visible = true;
                            lblEmpDetails.Text = ds.Tables[19].Rows[0]["CFOLD_PRINCIPLEEMP"].ToString();
                            nature.Visible = true;
                            lblEstablishDetails.Text = ds.Tables[19].Rows[0]["CFOLD_ESTDETAILS"].ToString();
                            WorkNature.Visible = true;
                            lblNature.Text = ds.Tables[19].Rows[0]["CFOLD_NATUREWORK"].ToString();
                        }

                        lblGeneralAct.Text = ds.Tables[19].Rows[0]["CFOLD_MANAGERNAME"].ToString();
                        lblManagerAgent.Text = ds.Tables[19].Rows[0]["CFOLD_ADDRESSMANAGER"].ToString();
                        lblCategoryEst.Text = ds.Tables[19].Rows[0]["CFOLD_CATEGORYEST"].ToString();
                        lblNatureBusiness.Text = ds.Tables[19].Rows[0]["CFOLD_NATUREBUSINESS"].ToString();
                        lblfamilyestablish.Text = ds.Tables[19].Rows[0]["CFOLD_FAMILYEMP"].ToString();
                        lblEmpEstablish.Text = ds.Tables[19].Rows[0]["CFOLD_EMPEST"].ToString();



                    }
                    if (ds != null && ds.Tables.Count > 20 && ds.Tables[20].Rows.Count > 0)
                    {
                        Labourdet.Visible = true;

                        GVCFOLabour.DataSource = ds.Tables[20];
                        GVCFOLabour.DataBind();

                    }
                    if (ds != null && ds.Tables.Count > 21 &&  ds.Tables[21].Rows.Count > 0)
                    {
                        LegalMetrology.Visible = true;

                        GVLegalDept.DataSource = ds.Tables[21];
                        GVLegalDept.DataBind();

                    }
                    if (ds != null && ds.Tables.Count > 22 &&  ds.Tables[22].Rows.Count > 0)
                    {
                        LegalMetrology.Visible = true;

                        lblDateEstablishments.Text = ds.Tables[22].Rows[0]["CFOLGM_ESTBLSHDATE"].ToString();
                        lblRegNoFactory.Text = ds.Tables[22].Rows[0]["CFOLGM_HADESTBLSHREG"].ToString();
                        if (lblRegNoFactory.Text == "Yes")
                        {
                            Registration.Visible = true;
                            lblDateOfReg.Text = ds.Tables[22].Rows[0]["CFOLGM_ESTBLSHREGDATE"].ToString();
                            RegNumber.Visible = true;
                            lblCurrentRegNo.Text = ds.Tables[22].Rows[0]["CFOLGM_ESTBLSHREGNO"].ToString();
                        }

                        lblRegADC.Text = ds.Tables[22].Rows[0]["CFOLGM_HADMTLREG"].ToString();
                        if (lblRegADC.Text == "Yes")
                        {
                            ADCLicense.Visible = true;
                            lblDateRegistration.Text = ds.Tables[22].Rows[0]["CFOLGM_MTLREGDATE"].ToString();
                            DateReg.Visible = true;
                            lblNumberRegCurrent.Text = ds.Tables[22].Rows[0]["CFOLGM_MTLREGNO"].ToString();
                        }

                        //lblPartnership.Text = ds.Tables[22].Rows[0][""].ToString();
                        //lblCompany.Text = ds.Tables[22].Rows[0][""].ToString();
                        //lblNames.Text = ds.Tables[22].Rows[0][""].ToString();
                        //lblAddressed.Text = ds.Tables[22].Rows[0][""].ToString();
                        lblManuDetails.Text = ds.Tables[22].Rows[0]["CFOLGM_WEIGHS"].ToString();
                        lblManumeasure.Text = ds.Tables[22].Rows[0]["CFOLGM_MEASURES"].ToString();
                        lblWeighting.Text = ds.Tables[22].Rows[0]["CFOLGM_WEIGHINGINSTR"].ToString();
                        lblRegNumberTax.Text = ds.Tables[22].Rows[0]["CFOLGM_PROFTAXREGNO"].ToString();
                        lblGST.Text = ds.Tables[22].Rows[0]["CFOLGM_GSTREGNO"].ToString();
                        lblITNumber.Text = ds.Tables[22].Rows[0]["CFOLGM_ITNO"].ToString();
                        lblStateimport.Text = ds.Tables[22].Rows[0]["CFOLGM_ISIMPORTING"].ToString();
                        if (lblStateimport.Text == "Yes")
                        {
                            State.Visible = true;
                            lblLICNumbers.Text = ds.Tables[22].Rows[0]["CFOLGM_IMPORTLICNO"].ToString();
                            Country.Visible = true;
                            lblRegImportMeasure.Text = ds.Tables[22].Rows[0]["CFOLGM_REGOFIMPORTER"].ToString();
                        }


                        lblManusold.Text = ds.Tables[22].Rows[0]["CFOLGM_SELLINGPLACE"].ToString();
                        lblDealerLic.Text = ds.Tables[22].Rows[0]["CFOLGM_DEALERLICAPPLIED"].ToString();
                        if (lblDealerLic.Text == "Yes")
                        {
                            DealerLic.Visible = true;
                            lblManufactureDetails.Text = ds.Tables[22].Rows[0]["CFOLGM_DEALERLICDETAILS"].ToString();
                        }

                        lblSkilled.Text = ds.Tables[22].Rows[0]["CFOLGM_SKILLEDEMP"].ToString();
                        lblsemiSkill.Text = ds.Tables[22].Rows[0]["CFOLGM_SEMISKILLEDEMP"].ToString();
                        lblUnskill.Text = ds.Tables[22].Rows[0]["CFOLGM_UNSKILLEDEMP"].ToString();
                        lblSpecialist.Text = ds.Tables[22].Rows[0]["CFOLGM_TRAINEDEMP"].ToString();
                        lblManufactureWeight.Text = ds.Tables[22].Rows[0]["CFOLGM_MACHINERYDETAILS"].ToString();
                        lbllongtermlease.Text = ds.Tables[22].Rows[0]["CFOLGM_WORKSHOPDETAILS"].ToString();
                        lblvitaothermeans.Text = ds.Tables[22].Rows[0]["CFOLGM_TESTFACILITIES"].ToString();
                        lblElectricEnergy.Text = ds.Tables[22].Rows[0]["CFOLGM_ELCENRGYAVLBL"].ToString();
                        lblManuLic.Text = ds.Tables[22].Rows[0]["CFOLGM_MANFLICAPPLIED"].ToString();
                        if (lblManuLic.Text == "Yes")
                        {
                            applieddealer.Visible = true;
                            lblManuGiveDetails.Text = ds.Tables[22].Rows[0]["CFOLGM_MANFLICDETAILS"].ToString();
                        }

                        lblFinancialloan.Text = ds.Tables[22].Rows[0]["CFOLGM_LOANAVAILED"].ToString();
                        if (lblFinancialloan.Text == "Yes")
                        {
                            NameBanker.Visible = true;
                            lblManuBank.Text = ds.Tables[22].Rows[0]["CFOLGM_LOANBANKERS"].ToString();
                            DetailsGet.Visible = true;
                            lblLabourgiveDetails.Text = ds.Tables[22].Rows[0]["CFOLGM_LOANDETAILS"].ToString();
                        }


                        lblLoanWeight.Text = ds.Tables[22].Rows[0]["CFOLGM_HADSUFFSTOCK"].ToString();
                        if (lblLoanWeight.Text == "Yes")
                        {
                            weightloan.Visible = true;
                            lblGiveDet.Text = ds.Tables[22].Rows[0]["CFOLGM_HADSUFFSTOCK"].ToString();
                        }

                        lblRepairerLic.Text = ds.Tables[22].Rows[0]["CFOLGM_REPAIRERLICAPPLIED"].ToString();
                        if (lblRepairerLic.Text == "Yes")
                        {
                            License.Visible = true;
                            lblResults.Text = ds.Tables[22].Rows[0]["CFOLGM_REPAIRERLICDETAILS"].ToString();
                        }

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