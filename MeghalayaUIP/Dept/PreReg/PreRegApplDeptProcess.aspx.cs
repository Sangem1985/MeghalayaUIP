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
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using MeghalayaUIP.BAL.CommonBAL;

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegApplDeptProcess : System.Web.UI.Page
    {
        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
        MasterBAL mstrBAL = new MasterBAL();
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

                if (Session["UNITID"] != null && Session["INVESTERID"] != null)
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
                          
                            lblGSTIN.Text = Convert.ToString(row["GSTNNO"]);

                            lblcomptype.Text = Convert.ToString(row["CONST_TYPE"]);
                            lblcatreg.Text = Convert.ToString(row["REGISTRATIONTYPENAME"]);
                            lblregcategory.Text = "7. " + lblcatreg.Text + " No.";
                            lblUdyam.Text = Convert.ToString(row["UDYAMNO"]);
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
                            grdAttachments.DataSource = ds.Tables[3];
                            grdAttachments.DataBind();
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
                        if (Request.QueryString["status"].ToString() == "IMATODEPTQUERY" && (Convert.ToString(ds.Tables[6].Rows[0]["PRDA_STAGEID"]) == "6" || Convert.ToString(ds.Tables[6].Rows[0]["PRDA_STAGEID"]) == "13"))
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
        protected void linkAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton link = (LinkButton)sender;
                GridViewRow row = (GridViewRow)link.NamingContainer;
                Label lblfilepath = (Label)row.FindControl("lblFilePath");
                if (lblfilepath != null || lblfilepath.Text != "")
                    Response.Redirect("~/Dept/Dashboard/DeptServePdfFile.ashx?filePath=" + lblfilepath.Text);
            }
            catch (Exception ex) { }
        }
        protected void linkViewQueryAttachment_Click(object sender, EventArgs e)
        {
            LinkButton lnkview = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkview.NamingContainer;

            Label lblfilepath = (Label)row.FindControl("lblFilePath");
            if (lblfilepath != null || lblfilepath.Text != "")
                Response.Redirect("~/Dept/Dashboard/DeptServePdfFile.ashx?filePath=" + lblfilepath.Text);

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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                    txtReply.Focus();
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", lblmsg0.Text, true);
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

        protected void btnUpldAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                string newPath = "", Error = "", message = "";
                string sFileDir = ConfigurationManager.AppSettings["PreRegAttachments"];
              //  string shortFileDir = "~\\PreRegAttachments";
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                FileUpload FileUploadquery = (FileUpload)row.FindControl("FileUploadquery");
                Label lblDQID = (Label)row.FindControl("lblDQID");
                Label lblDeptID = (Label)row.FindControl("lblDeptID");
                Label lblUNITID = (Label)row.FindControl("lblUNITID");
                HyperLink hplAttachment = (HyperLink)row.FindControl("hplAttachment");
                if (FileUploadquery.HasFile)
                {
                    Error = validations(FileUploadquery);
                    if (Error == "")
                    {
                        if ((FileUploadquery.PostedFile != null) && (FileUploadquery.PostedFile.ContentLength > 0))
                        {
                            string sFileName = System.IO.Path.GetFileName(FileUploadquery.PostedFile.FileName);
                            try
                            {

                                newPath = System.IO.Path.Combine(sFileDir, Session["INVESTERID"].ToString(), lblUNITID.Text + "\\RESPONSEATTACHMENTS");

                                if (!Directory.Exists(newPath))
                                    System.IO.Directory.CreateDirectory(newPath);

                                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                FileUploadquery.PostedFile.SaveAs(newPath + "\\" + sFileName);

                                //int count = dir.GetFiles().Length;
                                //if (count == 0)
                                //    FileUploadquery.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                //else
                                //{
                                //    if (count == 1)
                                //    {
                                //        string[] Files = Directory.GetFiles(newPath);

                                //        foreach (string file in Files)
                                //        {
                                //            File.Delete(file);
                                //        }
                                //        FileUploadquery.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                //    }
                                //}
                                IndustryDetails objattachments = new IndustryDetails();

                                objattachments.QueryID = lblDQID.Text;
                                objattachments.UnitID = lblUNITID.Text;
                                objattachments.InvestorId = Session["INVESTERID"].ToString();
                                objattachments.UserID = hdnUserID.Value.ToString();
                                objattachments.FileType = FileUploadquery.PostedFile.ContentType;
                                objattachments.FileName = sFileName.ToString();
                                objattachments.Filepath = newPath.ToString() + "\\" + sFileName.ToString();
                                objattachments.FileDescription = "RESPONSE ATTACHMENT";
                                objattachments.Deptid = lblDeptID.Text;
                                objattachments.ApprovalId = "0";
                                objattachments.ResponseFileBy = "DEPARTMENT";

                                int result = 0;
                                result = PreBAL.InsertAttachments_PREREG_RESPONSE(objattachments);

                                if (result > 0)
                                {
                                    lblmsg.Text = "<font color='green'>Attachment Successfully Uploaded..!</font>";
                                    hplAttachment.Text = FileUploadquery.FileName;
                                    hplAttachment.NavigateUrl = "~/Dept/Dashboard/DeptServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objattachments.Filepath);
                                    //hplAttachment.NavigateUrl = shortFileDir + "/" + Session["INVESTERID"].ToString() + "/" + lblUNITID.Text + "/" + "RESPONSEATTACHMENTS" + "/" + sFileName;
                                    hplAttachment.Visible = true;
                                    success.Visible = true;
                                    Failure.Visible = false;
                                }
                                else
                                {
                                    lblmsg0.Text = "<font color='red'>Attachment Upload Failed..!</font>";
                                    success.Visible = false;
                                    Failure.Visible = true;
                                }


                            }
                            catch (Exception)//in case of an error
                            {

                                DeleteFile(newPath + "\\" + sFileName);
                            }
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
                    lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string validations(FileUpload Attachment)
        {
            try
            {
                string filesize = Convert.ToString(ConfigurationManager.AppSettings["FileSize"].ToString());
                int slno = 1; string Error = "";
                //if (Attachment.PostedFile.ContentType != "application/pdf"
                //     || !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                //{

                    if (Attachment.PostedFile.ContentType != "application/pdf")
                    {
                        Error = Error + slno + ". Please Upload PDF Documents only \\n";
                        slno = slno + 1;
                    }
                    if (Attachment.PostedFile.ContentLength >= Convert.ToInt32(filesize))
                    {
                        Error = Error + slno + ". Please Upload file size less than " + Convert.ToInt32(filesize) / 1000000 + "MB \\n";
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
               // }
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
        public static bool ValidateFileExtension(FileUpload Attachment)
        {
            try
            {
                string Attachmentname = Attachment.PostedFile.FileName;
                string[] fileType = Attachmentname.Split('.');
                int i = fileType.Length;

                if (i == 2 && fileType[i - 1].ToUpper().Trim() == "PDF")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void DeleteFile(string strFileName)
        {
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)
                {
                    fi.Delete();
                }
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/PreReg/PreRegApplDeptView.aspx?status=" + Convert.ToString(Request.QueryString["status"]));
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