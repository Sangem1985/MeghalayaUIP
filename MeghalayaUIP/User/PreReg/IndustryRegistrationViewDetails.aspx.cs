using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.PreReg
{
    public partial class IndustryRegistrationViewDetails : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();
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
                        if (Request.QueryString.Count > 0)
                        {
                            BindaApplicatinDetails(Request.QueryString[0], ObjUserInfo.Userid);
                        }

                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
            }

        }

        public void BindaApplicatinDetails(string UnitID, string InvesterID)
        {
            try
            {

                if (UnitID != null && InvesterID != null)
                {

                    DataSet ds = new DataSet();
                    ds = preBAL.GetIndRegUserApplDetails(UnitID, InvesterID);


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
                        divManf.Visible = true;
                    else divServc.Visible = true;
                    lblMainmanuf.Text = Convert.ToString(row["PROJECT_MANFACTIVITY"]);
                    if (lblMainmanuf.Text == "MANFACTURE")
                    {
                        Manufacture.Visible = true;
                        Annual.Visible = true;
                        capacity.Visible = true;
                        Unit.Visible = true;
                        Measurment.Visible = true;
                        Main.Visible = false;
                        Activity.Visible = false;
                        divServc.Visible = false;
                        lblmanufProdct.Text = Convert.ToString(row["PROJECT_MANFPRODUCT"]);
                        lblProdNo.Text = Convert.ToString(row["PROJECT_MANFPRODNO"]);
                        lblmainRM.Text = Convert.ToString(row["PROJECT_MAINRM"]);
                        lblAnnualCap.Text = Convert.ToString(row["PROJECT_ANNUALCAPACITY"]);
                        lblunitofmeasure.Text = Convert.ToString(row["PROJECT_UNITOFMEASURE"]);
                    }
                    else
                    {
                        Main.Visible = true;
                        Activity.Visible = true;
                        divServc.Visible = true;
                        Manufacture.Visible = false;
                        Annual.Visible = false;
                        capacity.Visible = false;
                        Unit.Visible = false;
                        Measurment.Visible = false;
                        lblMainSrvc.Text = Convert.ToString(row["PROJECT_SRVCACTIVITY"]);
                        lblSrvcProvdng.Text = Convert.ToString(row["PROJECT_SRVCNAME"]);
                        lblSrvcNo.Text = Convert.ToString(row["PROJECT_SRVCNO"]);
                    }
                 
                  

                  
                 

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

                    grdRevenueProj.DataSource = ds.Tables[1];
                    grdRevenueProj.DataBind();

                    grdDirectors.DataSource = ds.Tables[2];
                    grdDirectors.DataBind();

                    grdApplStatus.DataSource = ds.Tables[3];
                    grdApplStatus.DataBind();
                    grdApplStatus.Visible = false;

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        grdQueries.DataSource = ds.Tables[4];
                        grdQueries.DataBind();
                    }
                    if(ds.Tables[5].Rows.Count > 0)
                    {
                        linkViewDPR.Text = Convert.ToString(ds.Tables[5].Rows[0]["FILENAME"]);
                        hplViewDPR.Text= Convert.ToString(ds.Tables[5].Rows[0]["FILELOCATION"]);
                    }
                    if (ds.Tables[6].Rows.Count > 0)
                    {
                        
                        grdQryAttachments.DataSource = ds.Tables[6];
                        grdQryAttachments.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                string UnitID="";
                if (Request.QueryString.Count > 0)
                {
                    if (Convert.ToString(Request.QueryString["ViewStatus"]) == "Total")
                        UnitID = "%";
                    else
                        UnitID = Convert.ToString(Request.QueryString[0]);
                }
                
                Response.Redirect("~/User/PreReg/IndustryRegistrationUserDashboard.aspx?UnitID="+ UnitID);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;

            }
        }

        protected void linkViewDPR_Click(object sender, EventArgs e)
        {
            Response.Redirect(hplViewDPR.Text);

        }

        protected void linkViewQueryAttachment_Click(object sender, EventArgs e)
        {
            LinkButton lnkview = (LinkButton) sender;
            GridViewRow row = (GridViewRow)lnkview.NamingContainer;
            HyperLink hplview = (HyperLink)row.FindControl("hplViewQueryAttachment");

            Response.Redirect(hplview.Text);
        }
    }
}