using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.Common;
using MeghalayaUIP.BAL.PreRegBAL;

namespace MeghalayaUIP.User.PreReg
{
    public partial class IndustryPrintPage : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL preBAL = new PreRegBAL();
        string userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserInfo"] != null)
                {
                    var ObjUserInfo = new UserInfo();
                    if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (UserInfo)Session["UserInfo"];
                        userid = ObjUserInfo.Userid;
                    }

                    if (!IsPostBack)
                    {
                        //if (Request.QueryString.Count > 0)
                        //{
                        //    BindaApplicatinDetails(Request.QueryString[0], ObjUserInfo.Userid);
                        //}
                        BindaApplicatinDetails();
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BindaApplicatinDetails()
        {
            // UnitID = "1002";
            try
            {

                string UnitID = Request.QueryString[0].ToString();
                string InvesterID = Request.QueryString[1].ToString();
                if (UnitID != null && InvesterID != null)
                {
                    DataSet ds = new DataSet();
                    ds = preBAL.GetIndRegUserApplDetails(UnitID, InvesterID);


                    lblPANNo.Text = ds.Tables[0].Rows[0]["COMPANYPANNO"].ToString();
                    lblproposal.Text = ds.Tables[0].Rows[0]["COMPANYTYPE"].ToString();
                    lblRegistration.Text = ds.Tables[0].Rows[0]["REGISTRATIONDATE"].ToString();
                    lblUdyam.Text = ds.Tables[0].Rows[0]["UDYAMNO"].ToString();
                    lblGSTNumber.Text = ds.Tables[0].Rows[0]["GSTNNO"].ToString();
                    lblName.Text = ds.Tables[0].Rows[0]["REP_NAME"].ToString();
                    lblEmail.Text = ds.Tables[0].Rows[0]["REP_EMAIL"].ToString();
                    lbllocality.Text = ds.Tables[0].Rows[0]["REP_LOCALITY"].ToString();
                    lbldistic.Text = ds.Tables[0].Rows[0]["REP_DISTRICT"].ToString();
                    lblMandal.Text = ds.Tables[0].Rows[0]["REP_MANDAL"].ToString();
                    lblVillage.Text = ds.Tables[0].Rows[0]["REP_VILLAGE"].ToString();
                    lblPincode.Text = ds.Tables[0].Rows[0]["REP_PINCODE"].ToString();
                    lblLand.Text = ds.Tables[0].Rows[0]["UNIT_LANDTYPE"].ToString();
                    lblDoor.Text = ds.Tables[0].Rows[0]["UNIT_DOORNO"].ToString();
                    lblLocal.Text = ds.Tables[0].Rows[0]["UNIT_LOCALITY"].ToString();
                    lbldist.Text = ds.Tables[0].Rows[0]["UNIT_DISTRICT"].ToString();
                    lbltaluka.Text = ds.Tables[0].Rows[0]["UNIT_MANDAL"].ToString();
                    lblvilla.Text = ds.Tables[0].Rows[0]["UNIT_VILLAGE"].ToString();
                    lblPIN.Text = ds.Tables[0].Rows[0]["UNIT_PINCODE"].ToString();
                    lblDate.Text = ds.Tables[0].Rows[0]["PROJECT_DCP"].ToString();
                    lblActivity.Text = ds.Tables[0].Rows[0]["PROJECT_NOA"].ToString();
                    lblManufacture.Text = ds.Tables[0].Rows[0]["PROJECT_MANFACTIVITY"].ToString();
                    lbProductManf.Text = ds.Tables[0].Rows[0]["PROJECT_MANFPRODUCT"].ToString();
                    lblMainActivity.Text = ds.Tables[0].Rows[0]["PROJECT_MANFPRODNO"].ToString();
                    lblProvided.Text = ds.Tables[0].Rows[0]["PROJECT_SRVCACTIVITY"].ToString();
                    lblExisting.Text = ds.Tables[0].Rows[0]["PROJECT_SRVCNO"].ToString();
                    lblSector.Text = ds.Tables[0].Rows[0]["PROJECT_SECTORNAME"].ToString();
                    lblLineActivity.Text = ds.Tables[0].Rows[0]["LineofActivity_Name"].ToString();
                    lblPCB.Text = ds.Tables[0].Rows[0]["PROJECT_PCBCATEGORY"].ToString();
                    lblRawMaterial.Text = ds.Tables[0].Rows[0]["PROJECT_MAINRM"].ToString();
                    lblgenerated.Text = ds.Tables[0].Rows[0]["PROJECT_WASTEDETAILS"].ToString();
                    lblHazardous.Text = ds.Tables[0].Rows[0]["PROJECT_HAZWASTEDETAILS"].ToString();
                    lblCivil.Text = ds.Tables[0].Rows[0]["PROJECT_CIVILCONSTR"].ToString();
                    lblLandarea.Text = ds.Tables[0].Rows[0]["PROJECT_LANDAREA"].ToString();
                    lblBuilding.Text = ds.Tables[0].Rows[0]["PROJECT_BUILDINGAREA"].ToString();
                    lblWater.Text = ds.Tables[0].Rows[0]["PROJECT_WATERREQ"].ToString();
                    lblPower.Text = ds.Tables[0].Rows[0]["PROJECT_POWERRREQ"].ToString();
                    lblMeasurement.Text = ds.Tables[0].Rows[0]["PROJECT_UNITOFMEASURE"].ToString();
                    lblCapacity.Text = ds.Tables[0].Rows[0]["PROJECT_ANNUALCAPACITY"].ToString();
                    lblProjectCost.Text = ds.Tables[0].Rows[0]["PROJECT_EPCOST"].ToString();
                    lblPlantMach.Text = ds.Tables[0].Rows[0]["PROJECT_PMCOST"].ToString();
                    lblInvestment.Text = ds.Tables[0].Rows[0]["PROJECT_IFC"].ToString();
                    lblFixedassets.Text = ds.Tables[0].Rows[0]["PROJECT_DFA"].ToString();
                    lblValueLand.Text = ds.Tables[0].Rows[0]["PROJECT_LANDVALUE"].ToString();
                    lblBuildingshed.Text = ds.Tables[0].Rows[0]["PROJECT_BUILDINGVALUE"].ToString();
                    lblvaluewater.Text = ds.Tables[0].Rows[0]["PROJECT_WATERVALUE"].ToString();
                    lblElectricity.Text = ds.Tables[0].Rows[0]["PROJECT_ELECTRICITYVALUE"].ToString();
                    lblworkingCapital.Text = ds.Tables[0].Rows[0]["PROJECT_WORKINGCAPITAL"].ToString();
                    lblCapitalsub.Text = ds.Tables[0].Rows[0]["FRD_CAPITALSUBSIDY"].ToString();
                    lblPromoters.Text = ds.Tables[0].Rows[0]["FRD_PROMOTEREQUITY"].ToString();
                    lblLoanAmount.Text = ds.Tables[0].Rows[0]["FRD_LOAN"].ToString();

                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {

                        GrdYear.DataSource = ds.Tables[1];
                        GrdYear.DataBind();

                    }
                    //lbllabel.Text = ds.Tables[0].Rows[0]["YEAR1"].ToString();
                    //lblturnover.Text = ds.Tables[0].Rows[0]["YEAR2"].ToString();
                    //lblover.Text = ds.Tables[0].Rows[0]["YEAR3"].ToString();
                    //lblturn.Text = ds.Tables[0].Rows[0]["YEAR4"].ToString();
                    //labellbl.Text = ds.Tables[0].Rows[0]["YEAR5"].ToString();

                    //lblCost.Text = ds.Tables[0].Rows[0]["YEAR1"].ToString();
                    //lblOperation.Text = ds.Tables[0].Rows[0]["YEAR2"].ToString();
                    //lblCostoper.Text = ds.Tables[0].Rows[0]["YEAR3"].ToString();
                    //lblcostamount.Text = ds.Tables[0].Rows[0]["YEAR4"].ToString();
                    //lbloper.Text = ds.Tables[0].Rows[0]["YEAR5"].ToString();

                    //lblEarn.Text = ds.Tables[0].Rows[0]["YEAR1"].ToString();
                    //lblIntrest.Text = ds.Tables[0].Rows[0]["YEAR2"].ToString();
                    //lblTax.Text = ds.Tables[0].Rows[0]["YEAR3"].ToString();
                    //lblDepreciation.Text = ds.Tables[0].Rows[0]["YEAR4"].ToString();
                    //lblAmortization.Text = ds.Tables[0].Rows[0]["YEAR5"].ToString();

                    //lblProfit.Text = ds.Tables[0].Rows[0]["YEAR1"].ToString();
                    //lblBefore.Text = ds.Tables[0].Rows[0]["YEAR2"].ToString();
                    //lblTaxation.Text = ds.Tables[0].Rows[0]["YEAR3"].ToString();
                    //lblProf.Text = ds.Tables[0].Rows[0]["YEAR4"].ToString();
                    //lblBeforetax.Text = ds.Tables[0].Rows[0]["YEAR5"].ToString();
                    //lblaftprof.Text = ds.Tables[0].Rows[0]["YEAR1"].ToString();
                    //lblprofits.Text = ds.Tables[0].Rows[0]["YEAR2"].ToString();
                    //lbltaxations.Text = ds.Tables[0].Rows[0]["YEAR3"].ToString();
                    //lbllabeltax.Text = ds.Tables[0].Rows[0]["YEAR4"].ToString();
                    //lblaftertax.Text = ds.Tables[0].Rows[0]["YEAR5"].ToString();
                    //lblreturn.Text = ds.Tables[0].Rows[0]["YEAR1"].ToString();

                    //lblInternal.Text = ds.Tables[0].Rows[0]["YEAR2"].ToString();
                    //lblsubsidy.Text = ds.Tables[0].Rows[0]["YEAR3"].ToString();
                    //lblRate.Text = ds.Tables[0].Rows[0]["YEAR4"].ToString();
                    //lblgrant.Text = ds.Tables[0].Rows[0]["YEAR5"].ToString();
                    //lblavg.Text = ds.Tables[0].Rows[0]["YEAR1"].ToString();
                    //lblService.Text = ds.Tables[0].Rows[0]["YEAR2"].ToString();
                    //lblRatio.Text = ds.Tables[0].Rows[0]["YEAR3"].ToString();

                    //lblDSCR.Text = ds.Tables[0].Rows[0]["YEAR4"].ToString();
                    //lblcoverage.Text = ds.Tables[0].Rows[0]["YEAR5"].ToString();
                    //lblBreak.Text = ds.Tables[0].Rows[0]["YEAR1"].ToString();
                    //lblEven.Text = ds.Tables[0].Rows[0]["YEAR2"].ToString();
                    //lblPoint.Text = ds.Tables[0].Rows[0]["YEAR3"].ToString();
                    //lblBEP.Text = ds.Tables[0].Rows[0]["YEAR4"].ToString();
                    //lblEvenPoint.Text = ds.Tables[0].Rows[0]["YEAR5"].ToString();
                    //lblDebt.Text = ds.Tables[0].Rows[0]["YEAR1"].ToString();
                    //lblEquity.Text = ds.Tables[0].Rows[0]["YEAR2"].ToString();
                    //lblRatios.Text = ds.Tables[0].Rows[0]["YEAR3"].ToString();
                    //lblTTL.Text = ds.Tables[0].Rows[0]["YEAR4"].ToString();
                    //lblTNW.Text = ds.Tables[0].Rows[0]["YEAR5"].ToString();
                    //lblFixed.Text = ds.Tables[0].Rows[0]["YEAR1"].ToString();
                    //lblAssets.Text = ds.Tables[0].Rows[0]["YEAR2"].ToString();
                    //lblCovers.Text = ds.Tables[0].Rows[0]["YEAR3"].ToString();
                    //lblRatioAssests.Text = ds.Tables[0].Rows[0]["YEAR4"].ToString();
                    //lblFixedRatio.Text = ds.Tables[0].Rows[0]["YEAR5"].ToString();

                    //lblDirect.Text = ds.Tables[0].Rows[0]["YEAR1"].ToString();
                    //lblEmployee.Text = ds.Tables[0].Rows[0]["YEAR2"].ToString();
                    //lblSkilled.Text = ds.Tables[0].Rows[0]["YEAR3"].ToString();
                    //lblSemi.Text = ds.Tables[0].Rows[0]["YEAR4"].ToString();
                    //lblDirectsemi.Text = ds.Tables[0].Rows[0]["YEAR5"].ToString();
                    //lblContract.Text = ds.Tables[0].Rows[0]["YEAR1"].ToString();
                    //lblEmployment.Text = ds.Tables[0].Rows[0]["YEAR2"].ToString();
                    //lblWithdays.Text = ds.Tables[0].Rows[0]["YEAR3"].ToString();
                    //lblContractual.Text = ds.Tables[0].Rows[0]["YEAR4"].ToString();
                    //lblemployments.Text = ds.Tables[0].Rows[0]["YEAR5"].ToString();
                    //lblIndirect.Text = ds.Tables[0].Rows[0]["YEAR1"].ToString();
                    //lblINEmployee.Text = ds.Tables[0].Rows[0]["YEAR2"].ToString();
                    //lblspecify.Text = ds.Tables[0].Rows[0]["YEAR3"].ToString();
                    //lblEmploymedierc.Text = ds.Tables[0].Rows[0]["YEAR4"].ToString();
                    //lbldiectiveemploy.Text = ds.Tables[0].Rows[0]["YEAR5"].ToString();


                    if (ds.Tables.Count > 6 && ds.Tables[6].Rows.Count > 0)
                    {


                        Gridviewname.DataSource = ds.Tables[6];
                        Gridviewname.DataBind();

                    }
                    //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    //{

                    //    lblFirst.Text = ds.Tables[0].Rows[0]["NAME"].ToString();
                    //    lblAadhar.Text = ds.Tables[0].Rows[0]["IDD_ADNO"].ToString();
                    //    lblpan.Text = ds.Tables[0].Rows[0]["IDD_PAN"].ToString();
                    //    lblDIN.Text = ds.Tables[0].Rows[0]["IDD_DINNO"].ToString();
                    //    lblNationality.Text = ds.Tables[0].Rows[0]["IDD_NATIONALITY"].ToString();
                    //    lblAddress.Text = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
                    //    lblEmailsid.Text = ds.Tables[0].Rows[0]["IDD_EMAIL"].ToString();
                    //    lblPHONENOS.Text = ds.Tables[0].Rows[0]["IDD_PHONE"].ToString();

                    //}




                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}