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
                        hdnUserID.Value = ObjUserInfo.Userid;
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
                string InvesterID = hdnUserID.Value;
                if (UnitID != null && InvesterID != null)
                {
                    DataSet ds = new DataSet();
                    ds = preBAL.GetIndRegUserApplDetails(UnitID, InvesterID);

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow row = ds.Tables[0].Rows[0];
                            lblCompanyName.Text = Convert.ToString(row["COMPANYNAME"]);
                            lblCompanyPAN.Text = Convert.ToString(row["COMPANYPANNO"]);
                            lblCompanyProposal.Text = Convert.ToString(row["COMPANYPRAPOSAL"]);
                            lblregdate.Text = Convert.ToString(row["REGISTRATIONDATE"]);
                            lblUdyam.Text = Convert.ToString(row["UDYAMNO"]);
                            lblGSTIN.Text = Convert.ToString(row["GSTNNO"]);

                            lblcomptype.Text = Convert.ToString(row["CONST_TYPE"]);
                            lblcatreg.Text = Convert.ToString(row["REGISTRATIONTYPENAME"]);
                            lbldoorno_authrep.Text = Convert.ToString(row["REP_DOORNO"]);
                            lblisland.Text = Convert.ToString(row["UNIT_LANDTYPE"]);
                            if (lblisland.Text == "Own")
                            { divDrNo1.Visible = true; divDrNo2.Visible = true; }

                            lblpromotndcont.Text = Convert.ToString(row["FRD_PROMOTEREQUITY"]);
                            lblequityamount.Text = Convert.ToString(row["FRD_EQUITY"]);
                            lbltermloanworking.Text = Convert.ToString(row["FRD_LOAN"]);

                            lblunsecuredloan.Text = Convert.ToString(row["FRD_UNSECUREDLOAN"]);
                            lblinternalresources.Text = Convert.ToString(row["FRD_INTERNALRESOURCE"]);
                            lblstatescheme.Text = Convert.ToString(row["FRD_STATE"]);

                            lblcapitalsubsidy.Text = Convert.ToString(row["FRD_CAPITALSUBSIDY"]);
                            lblunnati.Text = Convert.ToString(row["FRD_UNNATI"]);
                            lblcentralscheme.Text = Convert.ToString(row["FRD_CENTRAL"]);
                            if (Convert.ToString(row["ELIGIBLE_FLAG"]).Trim() == "N")
                            {
                                lblnote.Visible = true;
                            }
                            else
                            {
                                lblnote.Visible = false;
                            }


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
                            {
                                divManf1.Visible = true;
                                divManf2.Visible = true;
                            }
                            else { divService.Visible = true; }
                            lblMainmanuf.Text = Convert.ToString(row["PROJECT_MANFACTIVITY"]);

                            lblmanufProdct.Text = Convert.ToString(row["PROJECT_MANFPRODUCT"]);
                            lblProdNo.Text = Convert.ToString(row["PROJECT_MANFPRODNO"]);
                            lblmainRM.Text = Convert.ToString(row["PROJECT_MAINRM"]);
                            lblAnnualCap.Text = Convert.ToString(row["PROJECT_ANNUALCAPACITY"]);
                            lblunitofmeasure.Text = Convert.ToString(row["PROJECT_UNITOFMEASURE"]);

                            lblMainSrvc.Text = Convert.ToString(row["PROJECT_SRVCACTIVITY"]);
                            lblSrvcProvdng.Text = Convert.ToString(row["PROJECT_SRVCNAME"]);
                            lblSrvcNo.Text = Convert.ToString(row["PROJECT_SRVCNO"]);


                            lblSector.Text = Convert.ToString(row["PROJECT_SECTORNAME"]);
                            lblLOA.Text = Convert.ToString(row["LineofActivity_Name"]);
                            lblPCBcatogry.Text = Convert.ToString(row["PROJECT_PCBCATEGORY"]);


                            lblwastedtls.Text = Convert.ToString(row["PROJECT_WASTEDETAILS"]);
                            lblhazdtls.Text = Convert.ToString(row["PROJECT_HAZWASTEDETAILS"]);
                            lblcivilConstr.Text = Convert.ToString(row["PROJECT_CIVILCONSTR"]);
                            lbllandArea.Text = Convert.ToString(row["PROJECT_LANDAREA"]);
                            lblBuildingArea.Text = Convert.ToString(row["PROJECT_BUILDINGAREA"]);

                            lblWaterReq.Text = Convert.ToString(row["PROJECT_WATERREQ"]);
                            lblPowerReq.Text = Convert.ToString(row["PROJECT_POWERRREQ"]);


                            lblEstProjcost.Text = Convert.ToString(row["PROJECT_EPCOST"]);
                            lblPMCost.Text = Convert.ToString(row["PROJECT_PMCOST"]);
                            lblIFC.Text = Convert.ToString(row["PROJECT_IFC"]);
                            lblDFA.Text = Convert.ToString(row["PROJECT_DFA"]);
                            lblBuldingValue.Text = Convert.ToString(row["PROJECT_BUILDINGVALUE"]);
                            lblLandValue.Text = Convert.ToString(row["PROJECT_LANDVALUE"]);
                            lblWaterValue.Text = Convert.ToString(row["PROJECT_WATERVALUE"]);
                            lblElectricityValue.Text = Convert.ToString(row["PROJECT_ELECTRICITYVALUE"]);
                            lblWorkingCapital.Text = Convert.ToString(row["PROJECT_WORKINGCAPITAL"]);

                            //lblCapitalSubsidy.Text = Convert.ToString(row["FRD_CAPITALSUBSIDY"]);
                            //lblPromoterEquity.Text = Convert.ToString(row["FRD_PROMOTEREQUITY"]);
                            //lblLoan.Text = Convert.ToString(row["FRD_LOAN"]);
                            //Convert.ToDateTime(lblDateofcomm.Text).ToString("dd -MM-yyyy");
                        }
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            grdRevenueProj.DataSource = ds.Tables[1];
                            grdRevenueProj.DataBind();
                        }
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            grdDirectors.DataSource = ds.Tables[2];
                            grdDirectors.DataBind();
                        }
                        if (ds.Tables[5].Rows.Count > 0)
                        {
                            grdAttachments.DataSource = ds.Tables[5];
                            grdAttachments.DataBind();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect("~/User/PreReg/IndustryRegistration.aspx");

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;

            }
        }

        protected void linkAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton link = (LinkButton)sender;
                GridViewRow row = (GridViewRow)link.NamingContainer;
                Label lblfilepath = (Label)row.FindControl("lblFilePath");
                if (lblfilepath != null || lblfilepath.Text != "")
                    Response.Redirect("~/User/Dashboard/ServePdfFile.ashx?filePath=" + lblfilepath.Text);
            }
            catch (Exception ex) { }
        }
    }
}