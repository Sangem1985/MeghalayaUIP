using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.CommonClass;

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegApplDeptProcess : System.Web.UI.Page
    {
        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                success.Visible = false;
                Failure.Visible = false;

                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {
                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    hdnUserID.Value = ObjUserInfo.UserID;

                    if (!IsPostBack)
                    {
                        BindaApplicatinDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindaApplicatinDetails()
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

                if (Session["UNITID"] != null && Session["INVESTERID"] != null )
                {

                    prd.Unitid = Session["UNITID"].ToString();
                    prd.Investerid = Session["INVESTERID"].ToString();
                    prd.UserID = ObjUserInfo.UserID;
                    prd.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                    //prd.Stage = Convert.ToInt32(Session["stage"]);
                    if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                    {
                        prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    }
                    DataSet ds = new DataSet();
                    ds = PreBAL.GetPreRegNodelOfficer(prd);
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
                            lblmanufProdct.Text = Convert.ToString(row["PROJECT_MANFPRODUCT"]);
                            lblProdNo.Text = Convert.ToString(row["PROJECT_MANFPRODNO"]);

                            lblMainSrvc.Text = Convert.ToString(row["PROJECT_SRVCACTIVITY"]);
                            lblSrvcProvdng.Text = Convert.ToString(row["PROJECT_SRVCNAME"]);
                            lblSrvcNo.Text = Convert.ToString(row["PROJECT_SRVCNO"]);

                            lblSector.Text = Convert.ToString(row["PROJECT_SECTORNAME"]);
                            lblLOA.Text = Convert.ToString(row["LineofActivity_Name"]);
                            lblPCBcatogry.Text = Convert.ToString(row["PROJECT_PCBCATEGORY"]);

                            lblmainRM.Text = Convert.ToString(row["PROJECT_MAINRM"]);
                            lblwastedtls.Text = Convert.ToString(row["PROJECT_WASTEDETAILS"]);
                            lblhazdtls.Text = Convert.ToString(row["PROJECT_HAZWASTEDETAILS"]);
                            lblcivilConstr.Text = Convert.ToString(row["PROJECT_CIVILCONSTR"]);
                            lbllandArea.Text = Convert.ToString(row["PROJECT_LANDAREA"]);
                            lblBuildingArea.Text = Convert.ToString(row["PROJECT_BUILDINGAREA"]);

                            lblWaterReq.Text = Convert.ToString(row["PROJECT_WATERREQ"]);
                            lblPowerReq.Text = Convert.ToString(row["PROJECT_POWERRREQ"]);
                            lblunitofmeasure.Text = Convert.ToString(row["PROJECT_UNITOFMEASURE"]);
                            lblAnnualCap.Text = Convert.ToString(row["PROJECT_ANNUALCAPACITY"]);
                            lblEstProjcost.Text = Convert.ToString(row["PROJECT_EPCOST"]);
                            lblPMCost.Text = Convert.ToString(row["PROJECT_PMCOST"]);
                            lblIFC.Text = Convert.ToString(row["PROJECT_IFC"]);
                            lblDFA.Text = Convert.ToString(row["PROJECT_DFA"]);
                            lblBuldingValue.Text = Convert.ToString(row["PROJECT_BUILDINGVALUE"]);
                            lblLandValue.Text = Convert.ToString(row["PROJECT_LANDVALUE"]);
                            lblWaterValue.Text = Convert.ToString(row["PROJECT_WATERVALUE"]);
                            lblElectricityValue.Text = Convert.ToString(row["PROJECT_ELECTRICITYVALUE"]);
                            lblWorkingCapital.Text = Convert.ToString(row["PROJECT_WORKINGCAPITAL"]);

                            lbl_Name1.Text = Convert.ToString(row["REP_NAME"]);
                            lblunitname1.Text = Convert.ToString(row["REP_NAME"]);
                            lblApplNo.Text = Convert.ToString(row["PREREGUIDNO"]);
                            lblapplDate.Text = Convert.ToString(row["REP_MOBILE"]);
                            lblapplDate.Text = Convert.ToString(row["CREATEDDATE"]);
                        }

                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                        {
                            grdRevenueProj.DataSource = ds.Tables[1];
                            grdRevenueProj.DataBind();
                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[2].Rows.Count > 0)
                        {
                            grdDirectors.DataSource = ds.Tables[2];
                            grdDirectors.DataBind();
                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
                        {
                            linkViewDPR.Text = Convert.ToString(ds.Tables[3].Rows[0]["FILENAME"]);
                            hplViewDPR.Text = Convert.ToString(ds.Tables[3].Rows[0]["FILELOCATION"]);
                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[4].Rows.Count > 0)
                        {
                            grdQueries.DataSource = ds.Tables[4];
                            grdQueries.DataBind();

                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[5].Rows.Count > 0)
                        {
                            grdQryAttachments.DataSource = ds.Tables[5];
                            grdQryAttachments.DataBind();
                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[6].Rows.Count > 0)
                        {
                            grdApplStatus.DataSource = ds.Tables[6];
                            grdApplStatus.DataBind();
                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[7].Rows.Count > 0)
                        {
                            grdQueryRaised.DataSource = ds.Tables[7];
                            grdQueryRaised.DataBind();
                        }


                        //if (Request.QueryString["status"].ToString() == "C" || Request.QueryString["status"].ToString() == "F")
                        //{
                        //    verifypanel.Visible = true;
                        //    QueryResondpanel.Visible = false;
                        //}
                        if (Request.QueryString["status"].ToString() == "IMATODEPTQUERY" && Convert.ToString(ds.Tables[6].Rows[0]["PRDA_STAGEID"]) == "6")
                        {
                            QueryResondpanel.Visible = true;

                        }
                        else
                        {
                            verifypanel.Visible = false;
                            QueryResondpanel.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void linkViewDPR_Click(object sender, EventArgs e)
        {
            Response.Redirect(hplViewDPR.Text);

        }
        protected void linkViewQueryAttachment_Click(object sender, EventArgs e)
        {
            LinkButton lnkview = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkview.NamingContainer;
            HyperLink hplview = (HyperLink)row.FindControl("hplViewQueryAttachment");

            Response.Redirect(hplview.Text);
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
                if (ddlStatus.SelectedValue == "4" || ddlStatus.SelectedValue == "5")
                {
                    if ((ddlStatus.SelectedValue == "4" || ddlStatus.SelectedValue == "5") && (string.IsNullOrWhiteSpace(txtRequest.Text) || txtRequest.Text == "" || txtRequest.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Query Description";
                        Failure.Visible = true;
                        return;
                    }
                    else if (ddlStatus.SelectedValue == "5" && ObjUserInfo.Deptid == "1001" && (string.IsNullOrWhiteSpace(txtDeptLandArea.Text) || txtDeptLandArea.Text == "" || txtDeptLandArea.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Land Area";
                        txtDeptLandArea.Focus();
                        Failure.Visible = true;
                        return;
                    }
                    else if (ddlStatus.SelectedValue == "5" && ObjUserInfo.Deptid == "1009" && (string.IsNullOrWhiteSpace(txtDeptPower.Text) || txtDeptPower.Text == "" || txtDeptPower.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Power Required";
                        txtDeptLandArea.Focus();
                        Failure.Visible = true;
                        return;
                    }
                    else if (ddlStatus.SelectedValue == "5" && ObjUserInfo.Deptid == "1008" && (string.IsNullOrWhiteSpace(txtDeptWater.Text) || txtDeptWater.Text == "" || txtDeptWater.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Water Required";
                        txtDeptWater.Focus();
                        Failure.Visible = true;
                        return;
                    }
                    else if (ddlStatus.SelectedValue == "5" && (ObjUserInfo.Deptid == "1005")// || DeptID == "Env")
                        && (string.IsNullOrWhiteSpace(txtDeptWastedtls.Text) || txtDeptWastedtls.Text == "" || txtDeptWastedtls.Text == null)
                         && (string.IsNullOrWhiteSpace(txtHazWaste.Text) || txtHazWaste.Text == "" || txtHazWaste.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Waste and Hazardous waste details";
                        txtDeptLandArea.Focus();
                        Failure.Visible = true;
                        return;
                    }
                    else
                    {
                        prd.Unitid = Session["UNITID"].ToString();
                        prd.Investerid = Session["INVESTERID"].ToString();
                        if (ddlStatus != null)
                            prd.status = Convert.ToInt32(ddlStatus.SelectedValue);
                        prd.UserID = ObjUserInfo.UserID;
                        prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                        prd.Remarks = txtRequest.Text;
                        if (txtDeptLandArea.Text.Trim() != "" && txtDeptLandArea.Text.Trim() != "")
                        {
                            prd.LandArea = txtDeptLandArea.Text.Trim();
                        }
                        if (txtDeptPower.Text.Trim() != "" && txtDeptPower.Text.Trim() != "")
                        {
                            prd.Power = txtDeptPower.Text.Trim();
                        }
                        if (txtDeptWater.Text.Trim() != "" && txtDeptWater.Text.Trim() != "")
                        {
                            prd.Water = txtDeptWater.Text;
                        }
                        if (txtDeptWastedtls.Text.Trim() != "" && txtDeptWastedtls.Text.Trim() != "")
                        {
                            prd.WasteDetails = txtDeptWastedtls.Text;
                        }
                        if (txtHazWaste.Text.Trim() != "" && txtHazWaste.Text.Trim() != "")
                        {
                            prd.HazDetails = txtHazWaste.Text;
                        }
                        var Hostname = Dns.GetHostName();
                        prd.IPAddress = Dns.GetHostByName(Hostname).AddressList[0].ToString();
                        if (ddlStatus.SelectedValue == "5")
                        {
                            string valid = PreBAL.PreRegApprovals(prd);
                            btnSubmit.Enabled = false;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Submitted Successfully!');  window.location.href='PreRegApplDeptDashBoard.aspx'", true);
                            return;
                        }
                        else
                        {
                            string valid = PreBAL.PreRegUpdateQuery(prd);
                            btnSubmit.Enabled = false;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Query Raised Successfully!');  window.location.href='PreRegApplDeptDashBoard.aspx'", true);
                            return;
                        }

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
                if (ddlStatus.SelectedValue == "5")
                {
                    trheading.Visible = true;
                    tblaction.Visible = true;
                    lblaction.Text = "Remarks if any: ";
                    if (ObjUserInfo.Deptid == "1001") // Industries det For Land Vlaue
                    {
                        trIndsDept.Visible = true;
                        lblApplLandArea.Text = lbllandArea.Text;
                    }
                    else if (ObjUserInfo.Deptid == "1009") // Power det For Power Vlaue
                    {
                        trPowerDept.Visible = true;
                        lblApplPowerReq.Text = lblPowerReq.Text;
                    }
                    else if (ObjUserInfo.Deptid == "1008") //water dept
                    {
                        trWaterDept.Visible = true;
                        lblApplWaterReq.Text = lblWaterReq.Text;
                    }
                    else if (ObjUserInfo.Deptid == "1005")// || DeptID == "Env") //Forest or ENV for Waste
                    {
                        trForestDept1.Visible = true;
                        trForestDept2.Visible = true;
                        lblApplHazWaste.Text = "";
                        lblApplWastedtls.Text = "";
                    }

                }
                else if (ddlStatus.SelectedValue == "4")
                {
                    trheading.Visible = false;
                    tblaction.Visible = true;
                    lblaction.Text = "Please Enter Query Description";

                    trIndsDept.Visible = false;
                    trPowerDept.Visible = false;
                    trWaterDept.Visible = false;
                    trForestDept1.Visible = false;
                    trForestDept2.Visible = false;
                }
                else
                {
                    tblaction.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }


        }
        protected void btnsendresponsetoIMA_Click(object sender, EventArgs e)
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
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                TextBox txtReply = (TextBox)row.FindControl("txtIMAQueryReply");
                if (string.IsNullOrEmpty(txtReply.Text) || txtReply.Text == "" || txtReply.Text == null)
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Enter Query Response";
                    return;
                }
                else
                {
                    Label UnitID = (Label)row.FindControl("lblUNITID");
                    Label DeptID = (Label)row.FindControl("lblDeptID");
                    Label QID = (Label)row.FindControl("lblDQID");
                    prd.Investerid = Session["INVESTERID"].ToString();
                    prd.UserID = ObjUserInfo.UserID.Trim();
                    prd.Unitid = UnitID.Text.Trim();
                    prd.QuerytoDeptID = DeptID.Text.Trim();
                    prd.QueryID = QID.Text.Trim();
                    prd.QueryResponse = txtReply.Text.Trim();
                    prd.IPAddress = getclientIP();
                    prd.status = 7;  ////  DEPARTMENT REPLY TO IMA QUERY
                    prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    string valid = PreBAL.PreRegUpdateQuery(prd);
                    btn.Enabled = false;
                    BindaApplicatinDetails();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Replied to IMA Query Successfully!');  window.location.href='PreRegApplDeptDashBoard.aspx'", true);
                    return;
                }

            }

            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void btnsendIMAQuerytoApplicant_Click(object sender, EventArgs e)
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
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                TextBox txtReply = (TextBox)row.FindControl("txtIMAQueryReply");
                Label QID = (Label)row.FindControl("lblDQID");

                if (string.IsNullOrEmpty(txtReply.Text) || txtReply.Text == "" || txtReply.Text == null)
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Enter Query Response";
                    return;
                }
                prd.Unitid = Session["UNITID"].ToString();
                prd.Investerid = Session["INVESTERID"].ToString();
                prd.QueryID = QID.Text.Trim();
                prd.status = 9;
                prd.UserID = ObjUserInfo.UserID;
                prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                prd.Remarks = txtReply.Text;
                var Hostname = Dns.GetHostName();
                prd.IPAddress = Dns.GetHostByName(Hostname).AddressList[0].ToString();

                string valid = PreBAL.PreRegUpdateQuery(prd);
                btnSubmit.Enabled = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Query Raised Successfully!');  window.location.href='PreRegApplDeptDashBoard.aspx'", true);
                return;

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                btnSubmit_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
    }
}