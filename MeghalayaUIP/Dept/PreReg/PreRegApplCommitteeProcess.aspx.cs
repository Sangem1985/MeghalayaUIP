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
using System.Web.Services.Description;

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegApplCommitteeProcess : System.Web.UI.Page
    {
        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
        DropDownList ddldepartment;
        DataTable dt = new DataTable();
        List<PreRegDtls> lstPreRegDtlsVo = new List<PreRegDtls>();
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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

                if (Session["UNITID"] != null && Session["INVESTERID"] != null && Session["stage"] != null)
                {
                    prd.Unitid = Session["UNITID"].ToString();
                    prd.Investerid = Session["INVESTERID"].ToString();
                    prd.UserID = ObjUserInfo.UserID;
                    prd.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                    prd.Stage = Convert.ToInt32(Session["stage"]);
                    DataSet ds = new DataSet();
                    ds = PreBAL.GetPreRegNodelOfficer(prd);

                    if (ds.Tables.Count > 0)
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

                        lbl_Name1.Text = Convert.ToString(row["REP_NAME"]);
                        lblunitname1.Text = Convert.ToString(row["REP_NAME"]);
                        lblApplNo.Text = Convert.ToString(row["PREREGUIDNO"]);
                        lblapplDate.Text = Convert.ToString(row["REP_MOBILE"]);
                        lblapplDate.Text = Convert.ToString(row["CREATEDDATE"]);

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
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            int c = ds.Tables[3].Rows.Count;
                            string Filedesc = "";
                            int i = 0;

                            while (i < c)
                            {
                                Filedesc = ds.Tables[3].Rows[i]["FILEDESCRIPTION"].ToString();
                                if (Filedesc.Contains("CompanyRegistration"))
                                {
                                    lnkCmpnyRegcertificate.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILENAME"]);
                                    HyCmpnyRegcertificate.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILELOCATION"]);
                                }
                                if (Filedesc.Contains("UdyamRegistration"))
                                {
                                    lnkUdyam.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILENAME"]);
                                    HyUdyam.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILELOCATION"]);
                                }
                                if (Filedesc.Contains("PAN"))
                                {
                                    lnkPAN.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILENAME"]);
                                    HyPAN.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILELOCATION"]);
                                }
                                if (Filedesc.Contains("GSTIN"))
                                {
                                    lnkGST.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILENAME"]);
                                    HyGST.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILELOCATION"]);
                                }
                                if (Filedesc.Contains("CIN"))
                                {
                                    lnkCIN.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILENAME"]);
                                    HyCIN.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILELOCATION"]);
                                }
                                if (Filedesc.Contains("DPR"))
                                {
                                    linkViewDPR.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILENAME"]);
                                    hplViewDPR.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILELOCATION"]);
                                }
                                if (Filedesc.Contains("BankAppraisal"))
                                {
                                    lnkBankAppraisal.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILENAME"]);
                                    HyBankAppraisal.Text = Convert.ToString(ds.Tables[3].Rows[i]["FILELOCATION"]);
                                }
                                i++;
                            }
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
                        if (Convert.ToString(ds.Tables[0].Rows[0]["STATUS"]) == "8" ||
                            Convert.ToString(ds.Tables[0].Rows[0]["STATUS"]) == "12")
                        {
                            verifypanel.Visible = true;
                        }
                        else
                        {
                            verifypanel.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                string ErrorMsg = "", message = "";
                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {

                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                }
                if (ddlStatus.SelectedValue == "10")
                {
                    if (string.IsNullOrWhiteSpace(txtRequest.Text) || txtRequest.Text == "" || txtRequest.Text == null)
                    {
                        ErrorMsg = ErrorMsg + "Please Enter Remarks";
                    }
                    if (string.IsNullOrWhiteSpace(txtDeptLandArea.Text) || txtDeptLandArea.Text == "" || txtDeptLandArea.Text == null)
                    {
                        ErrorMsg = ErrorMsg + "Please Enter Land Area";
                    }
                    if (string.IsNullOrWhiteSpace(txtDeptPower.Text) || txtDeptPower.Text == "" || txtDeptPower.Text == null)
                    {
                        ErrorMsg = ErrorMsg + "Please Enter Power Required";
                    }
                    if (string.IsNullOrWhiteSpace(txtDeptWater.Text) || txtDeptWater.Text == "" || txtDeptWater.Text == null)
                    {
                        ErrorMsg = ErrorMsg + "Please Enter Water Required";
                    }
                    if (string.IsNullOrWhiteSpace(txtDeptWastedtls.Text) || txtDeptWastedtls.Text == "" || txtDeptWastedtls.Text == null)
                    {
                        ErrorMsg = ErrorMsg + "Please Enter Waste and Hazardous waste details";
                    }
                    if (string.IsNullOrWhiteSpace(txtHazWaste.Text) || txtHazWaste.Text == "" || txtHazWaste.Text == null)
                    {
                        ErrorMsg = ErrorMsg + "Please Enter Waste and Hazardous waste details";
                    }
                }
                else if (ddlStatus.SelectedValue == "11")
                {
                    if (string.IsNullOrWhiteSpace(txtRequest.Text) || txtRequest.Text == "" || txtRequest.Text == null)
                    {
                        ErrorMsg = ErrorMsg + "Please Enter Rejection Remarks";
                    }
                }
                else if (ddlStatus.SelectedValue == "9")
                {
                    if (string.IsNullOrWhiteSpace(txtQuery.Text) || txtQuery.Text == "" || txtQuery.Text == null)
                    {
                        ErrorMsg = ErrorMsg + "Please Enter Query Description";
                    }
                }
                if (ErrorMsg == "")
                {
                    prd.Unitid = Session["UNITID"].ToString();
                    prd.Investerid = Session["INVESTERID"].ToString();
                    prd.status = Convert.ToInt32(ddlStatus.SelectedValue);
                    prd.UserID = ObjUserInfo.UserID;
                    if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                    {
                        prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    }
                    prd.Remarks = txtRequest.Text;

                    prd.LandArea = txtDeptLandArea.Text.Trim();

                    prd.Power = txtDeptPower.Text.Trim();

                    prd.Water = txtDeptWater.Text;

                    prd.WasteDetails = txtDeptWastedtls.Text;

                    prd.HazDetails = txtHazWaste.Text;

                    prd.IPAddress = getclientIP();
                    prd.QuerytoDept = txtQuery.Text;
                    string valid = PreBAL.PreRegApprovals(prd);

                    if (ddlStatus.SelectedValue == "10" || ddlStatus.SelectedValue == "11")
                    {
                        verifypanel.Visible = false;
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        //BindaApplicatinDetails();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Submitted Successfully!');  window.location.href='PreRegApplCommitteeDashBoard.aspx'", true);
                        //return;
                    }
                    else if (ddlStatus.SelectedValue == "9")
                    {
                        verifypanel.Visible = false;
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        //BindaApplicatinDetails();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Query Raised Successfully!');  window.location.href='PreRegApplCommitteeDashBoard.aspx'", true);
                        //return;
                    }
                }
                else
                {
                    message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlStatus.SelectedValue == "10") //--approve
                {
                    tblaction.Visible = true;
                    trcommvalues.Visible = true;
                    txtQuery.Visible = false;
                    lblaction.Text = "Remarks if any: ";

                    lblApplLandArea.Text = lbllandArea.Text;

                    lblApplPowerReq.Text = lblPowerReq.Text;

                    lblApplWaterReq.Text = lblWaterReq.Text;

                    lblApplHazWaste.Text = lblhazdtls.Text;

                    lblApplWastedtls.Text = lblwastedtls.Text;

                }
                else if (ddlStatus.SelectedValue == "9") //query
                {
                    tblaction.Visible = true;
                    trcommvalues.Visible = false;
                    txtRequest.Visible = false;
                    txtQuery.Visible = true;
                    lblaction.Text = "Enter Query Description ";

                }
                else if (ddlStatus.SelectedValue == "11") //reject
                {
                    tblaction.Visible = true;
                    txtQuery.Visible = false;
                    trcommvalues.Visible = false;
                    lblaction.Text = "Enter Rejection Remarks ";

                }
                else
                { tblaction.Visible = false; }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }


        }

        public void AddSelect(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.CssClass = "errormsg";
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
        protected void lnkCmpnyRegcertificate_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(HyCmpnyRegcertificate.Text);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void lnkUdyam_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(HyUdyam.Text);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void lnkPAN_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(HyPAN.Text);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void lnkGST_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(HyGST.Text);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void lnkCIN_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(HyCIN.Text);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }     

        protected void lnkBankAppraisal_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(HyBankAppraisal.Text);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        //protected void btnQuery_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var ObjUserInfo = new DeptUserInfo();
        //        if (Session["DeptUserInfo"] != null)
        //        {

        //            if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
        //            {
        //                ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
        //            }
        //            // username = ObjUserInfo.UserName;
        //        }
        //        PreRegDtls PreRegDtlsVo = new PreRegDtls();
        //        //foreach (GridViewRow gvrow in gvdeptquery.Rows)
        //        //{
        //        //    DropDownList ddldepartment = (DropDownList)gvrow.FindControl("ddldepartment");
        //        //    TextBox txtquery = (TextBox)gvrow.FindControl("txtquery");
        //        //    PreRegDtlsVo.QuerytoDeptID = ddldepartment.SelectedValue;
        //        //    // PreRegDtlsVo.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
        //        //    PreRegDtlsVo.DeptDesc = ddldepartment.SelectedItem.Text.Trim();
        //        //    PreRegDtlsVo.Remarks = txtquery.Text.Trim();
        //        //    PreRegDtlsVo.Unitid = Session["UNITID"].ToString();
        //        //    PreRegDtlsVo.Investerid = Session["INVESTERID"].ToString();
        //        //    if (ddlStatus != null)
        //        //        PreRegDtlsVo.status = Convert.ToInt32(ddlStatus.SelectedValue);
        //        //    PreRegDtlsVo.UserID = ObjUserInfo.UserID;
        //        //    //lstPreRegDtlsVo.Add(PreRegDtlsVo);
        //        //    var Hostname = Dns.GetHostName();
        //        //    PreRegDtlsVo.IPAddress = Dns.GetHostByName(Hostname).AddressList[0].ToString();
        //        //    string valid = PreBAL.PreRegUpdateQuery(PreRegDtlsVo);
        //        //}
        //        btnQuery.Enabled = false;
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Query Raised Successfully!');  window.location.href='PreRegApplCommitteeDashBoard.aspx'", true);
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblmsg0.Text = "Oops, You have encountered an error!! please contact administrator.";
        //        Failure.Visible = true;
        //        string User_id = "0";
        //        var ObjUserInfo = new DeptUserInfo();
        //        if (Session["DeptUserInfo"] != null)
        //        {
        //            if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
        //            {
        //                ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
        //            }
        //            User_id = ((DeptUserInfo)Session["DeptUserInfo"]).UserID;
        //        }
        //        MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, User_id);
        //    }
        //}

        //protected void btnReject_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        btnSubmit_Click(sender, e);
        //    }
        //    catch (Exception ex)
        //    {
        //        lblmsg0.Text = "Oops, You have encountered an error!! please contact administrator.";
        //        Failure.Visible = true;
        //        string User_id = "0";
        //        var ObjUserInfo = new DeptUserInfo();
        //        if (Session["DeptUserInfo"] != null)
        //        {
        //            if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
        //            {
        //                ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
        //            }
        //            User_id = ((DeptUserInfo)Session["DeptUserInfo"]).UserID;
        //        }
        //        MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, User_id);
        //    }
        //}
    }
}