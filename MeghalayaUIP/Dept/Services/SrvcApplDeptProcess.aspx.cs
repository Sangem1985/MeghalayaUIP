using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Services
{
    public partial class SrvcApplDeptProcess : System.Web.UI.Page
    {
        SVRCBAL objSrvcbal = new SVRCBAL();
        string UnitID;
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
                        if (hdnUserID.Value == "")
                        {
                            hdnUserID.Value = ObjUserInfo.UserID;
                        }

                    }

                    BindSRVCApplicatinDetails();
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindSRVCApplicatinDetails()
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

                //if (Session["UNITID"] != null && Session["INVESTERID"] != null)
                //{
                DataSet ds = new DataSet();
                ds = objSrvcbal.GetSRVCApplicationDetails(Session["UNITID"].ToString(), Session["INVESTERID"].ToString(), "");
                //ds = objSrvcbal.GetSRVCApplicationDetails("1001", "1001");


                   /*if (ObjUserInfo.Deptid == "12") //SolidWaste Management
                   {
                       Solidwaste.Visible = true;
                   }

                   if (ObjUserInfo.Deptid == "12")//BioMedical
                   {
                       BioMedical.Visible = true;
                   } */

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblUnitName.Text = ds.Tables[0].Rows[0]["SRVCED_NAMEOFUNIT"].ToString();
                        lblCompanyType.Text = ds.Tables[0].Rows[0]["CompanyType"].ToString();
                        lblNatureIndustry.Text = ds.Tables[0].Rows[0]["SRVCED_SECTORENTERPRISE"].ToString();
                        lblRegCategory.Text = ds.Tables[0].Rows[0]["SRVCED_CATEGORYREG"].ToString();
                        lblRegNo.Text = ds.Tables[0].Rows[0]["SRVCED_REGNUMBER"].ToString();
                        lblRegDate.Text = ds.Tables[0].Rows[0]["SRVCED_REGDATE"].ToString();
                        lblSector.Text = ds.Tables[0].Rows[0]["SRVCED_SECTOR"].ToString();
                        lblLineActivity.Text = ds.Tables[0].Rows[0]["LineofActivity"].ToString();
                        lblPollutionCategory.Text = ds.Tables[0].Rows[0]["SRVCED_POLLUTIONCATG"].ToString();
                        lblSurveyDoor.Text = ds.Tables[0].Rows[0]["SRVCED_SURVEYDOOR"].ToString();
                        lblBuiltArea.Text = ds.Tables[0].Rows[0]["SRVCED_BUILTUPAREA"].ToString();
                        lblLandArea.Text = ds.Tables[0].Rows[0]["SRVCED_TOTALEXTENTLAND"].ToString();
                        lblLocalitys.Text = ds.Tables[0].Rows[0]["SRVCED_LOCALITY"].ToString();
                        lblLandmark.Text = ds.Tables[0].Rows[0]["SRVCED_LANDMARK"].ToString();
                        lblDistrict.Text = ds.Tables[0].Rows[0]["DistrictName"].ToString();
                        lblMandal1.Text = ds.Tables[0].Rows[0]["Mandalname"].ToString();
                        lblVillage1.Text = ds.Tables[0].Rows[0]["VillageName"].ToString();
                        lblEmailId.Text = ds.Tables[0].Rows[0]["SRVCED_EMAILID"].ToString();
                        lblMobileNo.Text = ds.Tables[0].Rows[0]["SRVCED_MOBILENO"].ToString();
                        lblpincode1.Text = ds.Tables[0].Rows[0]["SRVCED_PINCODE"].ToString();
                        lblName.Text = ds.Tables[0].Rows[0]["SRVCED_NAME"].ToString();
                        lblSoWoDo.Text = ds.Tables[0].Rows[0]["SRVCED_SONOF"].ToString();
                        lblEmail.Text = ds.Tables[0].Rows[0]["SRVCED_EMAIL"].ToString();
                        lblnumber.Text = ds.Tables[0].Rows[0]["SRVCED_MOBILENUMBER"].ToString();
                        lblAltMobile.Text = ds.Tables[0].Rows[0]["SRVCED_ALTERNUMBER"].ToString();
                        lblLandlineNo.Text = ds.Tables[0].Rows[0]["SRVCED_LANDLINENUMBER"].ToString();
                        lblDoorNo.Text = ds.Tables[0].Rows[0]["SRVCED_DOOR"].ToString();
                        lblLocal.Text = ds.Tables[0].Rows[0]["SRVCED_LOCALITYADD"].ToString();
                        lblState.Text = ds.Tables[0].Rows[0]["MS_NAME"].ToString();
                        lblApplDist.Text = ds.Tables[0].Rows[0]["DistrictName"].ToString();
                        lblApplTaluka.Text = ds.Tables[0].Rows[0]["Mandalname"].ToString();
                        lblApplVillage.Text = ds.Tables[0].Rows[0]["VillageName"].ToString();
                        lblPincode.Text = ds.Tables[0].Rows[0]["SRVCED_PIN"].ToString();
                        lblAge.Text = ds.Tables[0].Rows[0]["SRVCED_AGE"].ToString();
                        lblDesignation1.Text = ds.Tables[0].Rows[0]["SRVCED_DESIGNATION"].ToString();
                        lblWomenEntrepreneur.Text = ds.Tables[0].Rows[0]["SRVCED_WOMENENTREPRENEUR"].ToString();
                        lblDifferentlyAbled.Text = ds.Tables[0].Rows[0]["SRVCED_ABLED"].ToString();
                        lblDirectMale.Text = ds.Tables[0].Rows[0]["SRVCED_DIRECTMALE"].ToString();
                        lblDirectFemale.Text = ds.Tables[0].Rows[0]["SRVCED_DIRECTFEMALE"].ToString();
                        lblDirectOther.Text = ds.Tables[0].Rows[0]["SRVCED_DIRECTEMP"].ToString();
                        lblIndirectMale.Text = ds.Tables[0].Rows[0]["SRVCED_INDIRECTMALE"].ToString();
                        lblIndirectFemale.Text = ds.Tables[0].Rows[0]["SRVCED_INDIRECTFEMALE"].ToString();
                        lblIndirectOther.Text = ds.Tables[0].Rows[0]["SRVCED_INDIRECTEMP"].ToString();
                        lblTotalEmployment.Text = ds.Tables[0].Rows[0]["SRVCED_TOTALEMP"].ToString();
                        lblLandValue.Text = ds.Tables[0].Rows[0]["SRVCED_LANDSALEDEED"].ToString();
                        lblBuildingValue.Text = ds.Tables[0].Rows[0]["SRVCED_BUILDING"].ToString();
                        lblPMCost.Text = ds.Tables[0].Rows[0]["SRVCED_PLANTMACHINERY"].ToString();
                        lblTotProjCost.Text = ds.Tables[0].Rows[0]["SRVCED_PROJECTCOST"].ToString();
                        lblAnnualTurnOver.Text = ds.Tables[0].Rows[0]["SRVCED_ANNUALTURNOVER"].ToString();
                        lblEntCategory.Text = ds.Tables[0].Rows[0]["SRVCED_ENTERPRISECATEG"].ToString();

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        lblNameLocalBody.Text = ds.Tables[1].Rows[0]["SRVCSWD_NAMELOCALOPERATOR"].ToString();
                        lblDesignation.Text = ds.Tables[1].Rows[0]["SRVCSWD_NODALAUTHORISEDAGENCY"].ToString();
                        lblAuthorization.Text = ds.Tables[1].Rows[0]["SRVCSWD_AUTHORIZATIONOPEARTION"].ToString();
                        lblWasteProduced.Text = ds.Tables[1].Rows[0]["SRVCSWD_TOTALQUANTITYWASTE"].ToString();
                        lblWasteRecycled.Text = ds.Tables[1].Rows[0]["SRVCSWD_QUANTITYWASTERECYCLE"].ToString();
                        lblWasteTreated.Text = ds.Tables[1].Rows[0]["SRVCSWD_QUANTITYWASTETREATED"].ToString();
                        lblWasteDisposed.Text = ds.Tables[1].Rows[0]["SRVCSWD_QUANTITYWASTEDISPOSED"].ToString();
                        lblUtilisation.Text = ds.Tables[1].Rows[0]["SRVCSWD_QUANTITYLEACHATE"].ToString();
                        lblQuanLeachate.Text = ds.Tables[1].Rows[0]["SRVCSWD_TREATMENTTECHLEACHATE"].ToString();
                        lblTreatmentLeachate.Text = ds.Tables[1].Rows[0]["SRVCSWD_MEASURESCEP"].ToString();
                        lblMeasuresForPrevention.Text = ds.Tables[1].Rows[0]["SRVCSWD_MEASURESSAFTEYPLANT"].ToString();
                        lblMeasuresForSafety.Text = ds.Tables[1].Rows[0]["SRVCSWD_NOSITES"].ToString();
                        lblSiteIdentified.Text = ds.Tables[1].Rows[0]["SRVCSWD_QUANTITYWASTEPERDAY"].ToString();
                        lblQuantityWasteDisposed.Text = ds.Tables[1].Rows[0]["SRVCSWD_DETAILSEXISTINGSITE"].ToString();
                        lblExistingSiteUnderOperation.Text = ds.Tables[1].Rows[0]["SRVCSWD_METHODOLOGYDETAILS"].ToString();
                        lblLandfillingDetails.Text = ds.Tables[1].Rows[0]["SRVCSWD_CHECKENVIRONMENTPOLLUTION"].ToString();
                        // lblMeasureToChkEnvPoltn.Text = ds.Tables[1].Rows[0][""].ToString();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {

                        lblNameApplicant.Text = ds.Tables[2].Rows[0]["BMW_NAME"].ToString();
                        lblMedical.Text = ds.Tables[2].Rows[0]["BMW_NAMEHCF_CBWTF"].ToString();
                        Labelemail.Text = ds.Tables[2].Rows[0]["BMW_EMAILID"].ToString();
                        Labelmobile.Text = ds.Tables[2].Rows[0]["BMW_MOBILENO"].ToString();
                        lblWebsite.Text = ds.Tables[2].Rows[0]["BMW_WEBSITE"].ToString();
                        LabelAuthreqfor.Text = ds.Tables[2].Rows[0]["BMW_AUTHORIZATION"].ToString();
                        LabelCtoCte.Text = ds.Tables[2].Rows[0]["BMW_APPLIEDCTO_CTE"].ToString();
                        LabelRenno.Text = ds.Tables[2].Rows[0]["BMW_RENAUTHORIZATIONNO"].ToString();
                        Labelrenprvsdate.Text = ds.Tables[2].Rows[0]["BMW_RENAUTHORIZATIONDATE"].ToString();
                        Labelpcb.Text = ds.Tables[2].Rows[0]["BMW_PCB1974"].ToString();
                        Labelpcb1981.Text = ds.Tables[2].Rows[0]["BMW_PCB1981"].ToString();
                        LabelrblHealth.Text = ds.Tables[2].Rows[0]["BMW_BIOHCF_CBWTF"].ToString();
                        LabelrblGPS.Text = ds.Tables[2].Rows[0]["BMW_GPSCOORDINATE"].ToString();
                        LabelNoHCF.Text = ds.Tables[2].Rows[0]["BMW_NOBEDHCF"].ToString();
                        LabelHCFNO.Text = ds.Tables[2].Rows[0]["BMW_NOPATIENTSMONTHHCF"].ToString();
                        LabelHealthCBMWFT.Text = ds.Tables[2].Rows[0]["BMW_NOHELTHCBMWTF"].ToString();
                        LabelNobedcbmwtf.Text = ds.Tables[2].Rows[0]["BMW_NOBEDCBMWTF"].ToString();
                        LabelCapacityTreat.Text = ds.Tables[2].Rows[0]["BMW_CAPACITYCBMWTF"].ToString();
                        LabelDistance.Text = ds.Tables[2].Rows[0]["BMW_AREADISTANCECBMWTF"].ToString();
                        LabelWasteTreat.Text = ds.Tables[2].Rows[0]["BMW_BIOMEDICALDISPOSED"].ToString();
                        Labelcategory.Text = ds.Tables[2].Rows[0]["BMW_MODETRANSPORTATION"].ToString();
                        // Labeltypwaste.Text = ds.Tables[2].Rows[0][""].ToString();                      
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        GVWaste.DataSource = ds.Tables[3];
                        GVWaste.DataBind();
                    }
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        lblStatus.Text = ds.Tables[5].Rows[0]["SRVCPDC_STATUSRELATION"].ToString();
                        lblPSAddress.Text = ds.Tables[5].Rows[0]["SRVCPDC_POLICESATION"].ToString();
                        lblLTSupply.Text = ds.Tables[5].Rows[0]["SRVCPDC_LTSUPPLY"].ToString();
                    }
                }
                // }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
    }
}