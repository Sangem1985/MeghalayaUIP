using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOCombinedApplication : System.Web.UI.Page
    {
        CFOBAL objcfobal = new CFOBAL();
        CFOQuestionnaireDet cfoqs = new CFOQuestionnaireDet();
        decimal TotalFee, TotalFeeAmount;
        decimal amounts1;
        decimal amounts22 = 0;
        string result, ErrorMsg = "";
        MasterBAL mstrBAL = new MasterBAL();
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
                    }
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.Userid;
                    }
                    if (Convert.ToString(Session["CFOUNITID"]) != "")
                    {

                    }
                    else
                    {
                        string newurl = "~/User/CFO/CFOUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }
                    Page.MaintainScrollPositionOnPostBack = true;
                    if (!IsPostBack)
                    {
                        if (Convert.ToString(Session["CFOUNITID"]) != "")
                        {
                            BindData();
                            GetCFOofflineapprovals();
                        }
                        else
                        {
                            string newurl = "~/User/CFO/CFOUserDashboard.aspx";
                            Response.Redirect(newurl);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void grdApprovalsCFO_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if ((e.Row.RowType == DataControlRowType.DataRow))
                {
                    decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFOQA_APPROVALFEE"));
                    TotalFee = TotalFee + TotalFee1;

                    HiddenField HdfAmount = (HiddenField)e.Row.FindControl("HdfAmount");
                    HiddenField HdfDeptid = (HiddenField)e.Row.FindControl("HdfDeptid");
                    HiddenField HdfQueid = (HiddenField)e.Row.FindControl("HdfQueid");
                    HiddenField HdfApprovalid = (HiddenField)e.Row.FindControl("HdfApprovalid");
                    CheckBox ChkApproval = (CheckBox)e.Row.FindControl("ChkApproval");
                    RadioButtonList rblObtained = (RadioButtonList)e.Row.FindControl("rblAlrdyObtained");
                    //rblObtained.SelectedIndexChanged += new EventHandler(rblAlrdyObtained_SelectedIndexChanged);

                    HdfAmount.Value = DataBinder.Eval(e.Row.DataItem, "CFOQA_APPROVALFEE").ToString().Trim();
                    HdfDeptid.Value = DataBinder.Eval(e.Row.DataItem, "CFOQA_DEPTID").ToString().Trim();
                    //HdfQueid.Value = DataBinder.Eval(e.Row.DataItem, "intQuessionaireid").ToString().Trim();
                    HdfApprovalid.Value = DataBinder.Eval(e.Row.DataItem, "CFOQA_APPROVALID").ToString().Trim();

                    string approvalName = DataBinder.Eval(e.Row.DataItem, "ApprovalName").ToString().Trim();

                    ChkApproval.Checked = true;

                    Label lblAmount = (Label)e.Row.FindControl("lblAmounts");
                    lblAmount.Text = HdfAmount.Value.ToString();

                    lblAmount.Text = string.Format("{0:N0}", lblAmount.Text.ToString());
                    decimal amounts = Convert.ToDecimal(lblAmount.Text.ToString());
                    int textCheck = grdApprovalsCFO.Columns.Count;
                    if (rblObtained.SelectedValue == "Y")
                    {
                        rblObtained.Enabled = false;
                        ChkApproval.Checked = false; ChkApproval.Enabled = false;
                        lblAmount.Text = "0";
                        amounts = 0;
                        e.Row.Cells[6].Text = "0";
                    }
                    if (ChkApproval.Checked == true && amounts != 0)
                    {
                        e.Row.Cells[6].Text = e.Row.Cells[3].Text;
                    }

                    if (e.Row.Cells[6].Text != "" && amounts != 0)
                    {
                        decimal TotalFeeAmount1 = Convert.ToDecimal(e.Row.Cells[6].Text);
                        TotalFeeAmount = TotalFeeAmount + TotalFeeAmount1;
                        if (e.Row.Cells[6].Text != "")
                            e.Row.Cells[6].Text = Convert.ToDecimal(e.Row.Cells[6].Text).ToString("#,##0");
                    }

                    if (e.Row.RowIndex >= 0)
                    {
                        amounts1 = amounts;
                        amounts22 = amounts1 + amounts22;
                    }

                }

                if ((e.Row.RowType == DataControlRowType.Footer))
                {
                    e.Row.Cells[5].Text = "Total Fee";

                    e.Row.Cells[6].Text = amounts22.ToString("#,##0");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int cnt = 0;
                int selectedcount = 0;
                int selectedcount1 = 0;
                foreach (GridViewRow row in grdApprovalsCFO.Rows)
                {
                    RadioButtonList rblobtained = (RadioButtonList)row.FindControl("rblAlrdyObtained");
                    if (rblobtained.SelectedValue == "N")
                    {
                        selectedcount = selectedcount + 1;
                        if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                        {
                            selectedcount1 = selectedcount1 + 1;
                        }
                    }
                    if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                    {
                        cnt = cnt + 1;
                    }
                    SetGridLabelValue();
                }
                if (cnt <= 1)
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Select Atleaset one Department for Approval";
                    lblmsg0.Visible = true;
                    return;
                }
                CFOQuestionnaireDet objCFOQsnaire = new CFOQuestionnaireDet();
                int count = 0;
                foreach (GridViewRow row in grdApprovalsCFO.Rows)
                {
                    //if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                    //{
                    Label ApprovalID = (Label)row.FindControl("lblApprID");
                    Label DeptID = (Label)row.FindControl("lblDeptID") as Label;
                    Label lblFEE = (Label)row.FindControl("lblAmounts") as Label;
                    RadioButtonList rbloffline = (RadioButtonList)row.FindControl("rblAlrdyObtained");

                    objCFOQsnaire.UNITID = Convert.ToString(Session["CFOUNITID"]);
                    objCFOQsnaire.CFEQDID = Convert.ToString(Session["CFOQID"]);
                    objCFOQsnaire.DeptID = DeptID.Text;
                    objCFOQsnaire.ApprovalID = ApprovalID.Text;
                    objCFOQsnaire.ApprovalFee = row.Cells[3].Text;
                    objCFOQsnaire.IsOffline = rbloffline.SelectedValue;
                    objCFOQsnaire.CreatedBy = hdnUserID.Value;
                    objCFOQsnaire.IPAddress = getclientIP();

                    string A = objcfobal.InsertCFODepartmentApprovals(objCFOQsnaire);
                    if (A != "")
                    { count = count + 1; }
                    //}

                }
                if (grdApprovalsCFO.Rows.Count == count)
                {
                    GetCFOofflineapprovals();
                    success.Visible = true;
                    lblmsg.Text = "Details Submitted Successfully";
                    string message = "alert('" + lblmsg.Text + "')";

                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void GetCFOofflineapprovals()
        {
            try
            {
                DataSet dsOffline = new DataSet();
                dsOffline = objcfobal.GetCFOAlreadyObtainedApprovals(hdnUserID.Value, Convert.ToString(Session["CFOUNITID"]), Session["CFOQID"].ToString(), "Y");
                divOffline.Visible = false; btnNext.Enabled = true; btnNext2.Visible = false;
                if (dsOffline.Tables.Count > 0)
                {
                    if (dsOffline.Tables[0].Rows.Count > 0)
                    {
                        btnNext.Enabled = false; btnNext2.Visible = true;
                        divOffline.Visible = true; div2.Visible = true;

                        divMigrantReg2020.Visible = false; divManufactureReg.Visible = false; divRenewalReg.Visible = false;
                        divBoilerReg.Visible = false; divLICFactory.Visible = false; divLICMIGRANTWORKMEN1979.Visible = false;
                        divLICLabourContractor1970.Visible = false; divLicRetailDrug.Visible = false; divLicManuMeasure.Visible = false;
                        div42LicDealerWeight.Visible = false; divIVSMeasure.Visible = false; divFireSafeCert.Visible = false;
                        divExiseRetail.Visible = false; divLicWholeDrug.Visible = false; divBrandReg.Visible = false;
                        divLicGrantRenew.Visible = false; divLicManuDrug.Visible = false; divLicManuDrugSpecifie.Visible = false;
                        divLicGrantRenewSch.Visible = false; divLicManuVolumesera.Visible = false; divProffessTax.Visible = false;
                        divPCB.Visible = false; divOccupancyCert.Visible = false; divBoilerDept.Visible = false;
                        divRegPipelineSteam.Visible = false; divRegShopEst.Visible = false; divLicGrantBusiness.Visible = false;
                        divLicIMFL.Visible = false; divSatateExcise.Visible = false;


                        for (int i = 0; i < dsOffline.Tables[0].Rows.Count; i++)
                        {
                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "32")
                                divMigrantReg2020.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "33")
                                divManufactureReg.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "34")
                                divRenewalReg.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "35")
                                divBoilerReg.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "36")
                                divLICFactory.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "37")
                                divLICMIGRANTWORKMEN1979.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "38")
                                divLICLabourContractor1970.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "39")
                                divLicRetailDrug.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "40")
                                divLicRepairWeight.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "41")
                                divLicManuMeasure.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "42")
                                div42LicDealerWeight.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "43")
                                divIVSMeasure.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "44")
                                divFireSafeCert.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "45")
                                divExiseRetail.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "46")
                                divLicWholeDrug.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "47")
                                divBrandReg.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "48")
                                divLicGrantRenew.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "49")
                                divLicManuDrug.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "50")
                                divLicManuDrugSpecifie.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "51")
                                divLicGrantRenewSch.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "52")
                                divLicManuVolumesera.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "53")
                                divProffessTax.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "54")
                                divPCB.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "55")
                                divOccupancyCert.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "56")
                                divBoilerDept.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "57")
                                divRegPipelineSteam.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "58")
                                divRegShopEst.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "59")
                                divLicGrantBusiness.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "60")
                                divLicIMFL.Visible = true;

                            if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "61")
                                divSatateExcise.Visible = true;

                        }
                        if (dsOffline.Tables[1].Rows.Count > 0)
                        {
                            divOffline.Visible = true; btnNext.Visible = true; btnNext.Enabled = false; div2.Visible = true;
                            btnNext2.Visible = true;
                            for (int i = 0; i < dsOffline.Tables[1].Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 32)//Migrant Work
                                {
                                    divMigrantReg2020.Visible = true;
                                    hpl32MigrantReg.Visible = true;
                                    hpl32MigrantReg.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl32MigrantReg.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 33)//ManuFacture Repaire
                                {
                                    divManufactureReg.Visible = true;
                                    hpl33ManufactureReg.Visible = true;
                                    hpl33ManufactureReg.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl33ManufactureReg.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 34)//PCB HAZ NOC
                                {
                                    divRenewalReg.Visible = true;
                                    hpl34RenewalReg.Visible = true;
                                    hpl34RenewalReg.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl34RenewalReg.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 35)
                                {
                                    divBoilerReg.Visible = true;
                                    hpl35BoilerReg.Visible = true;
                                    hpl35BoilerReg.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl35BoilerReg.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 36)
                                {
                                    divLICFactory.Visible = true;
                                    hpl36LICFactory.Visible = true;
                                    hpl36LICFactory.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl36LICFactory.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 37)
                                {
                                    divLICMIGRANTWORKMEN1979.Visible = true;
                                    hpl37LICMIGRANTWORKMEN.Visible = true;
                                    hpl37LICMIGRANTWORKMEN.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl37LICMIGRANTWORKMEN.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 38)
                                {
                                    divLICLabourContractor1970.Visible = true;
                                    hpl38LICLabourContractor.Visible = true;
                                    hpl38LICLabourContractor.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl38LICLabourContractor.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 39)
                                {
                                    divLicRetailDrug.Visible = true;
                                    hpl39LicRetailDrug.Visible = true;
                                    hpl39LicRetailDrug.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl39LicRetailDrug.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 40)
                                {
                                    divLicRepairWeight.Visible = true;
                                    hpl40LicRepairWeight.Visible = true;
                                    hpl40LicRepairWeight.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl40LicRepairWeight.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 41)
                                {
                                    divLicManuMeasure.Visible = true;
                                    hpl41LicManuMeasure.Visible = true;
                                    hpl41LicManuMeasure.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl41LicManuMeasure.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 42)
                                {
                                    div42LicDealerWeight.Visible = true;
                                    hpl42LicDealerWeight.Visible = true;
                                    hpl42LicDealerWeight.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl42LicDealerWeight.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 43)
                                {
                                    divIVSMeasure.Visible = true;
                                    hpl43IVSMeasure.Visible = true;
                                    hpl43IVSMeasure.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl43IVSMeasure.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 44)
                                {
                                    divFireSafeCert.Visible = true;
                                    hpl44FireSafeCert.Visible = true;
                                    hpl44FireSafeCert.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl44FireSafeCert.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 45)
                                {
                                    divExiseRetail.Visible = true;
                                    hpl45ExiseRetail.Visible = true;
                                    hpl45ExiseRetail.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl45ExiseRetail.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 46)
                                {
                                    divLicWholeDrug.Visible = true;
                                    hpl46LicWholeDrug.Visible = true;
                                    hpl46LicWholeDrug.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl46LicWholeDrug.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 47)
                                {
                                    divBrandReg.Visible = true;
                                    hpl47BrandReg.Visible = true;
                                    hpl47BrandReg.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl47BrandReg.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 48)
                                {
                                    divLicGrantRenew.Visible = true;
                                    hpl48LicGrantRenew.Visible = true;
                                    hpl48LicGrantRenew.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl48LicGrantRenew.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 49)
                                {
                                    divLicManuDrug.Visible = true;
                                    hpl49LicManuDrug.Visible = true;
                                    hpl49LicManuDrug.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl49LicManuDrug.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 50)
                                {
                                    divLicManuDrugSpecifie.Visible = true;
                                    hpl50LicManuDrugSpecifie.Visible = true;
                                    hpl50LicManuDrugSpecifie.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl50LicManuDrugSpecifie.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 51)
                                {
                                    divLicGrantRenewSch.Visible = true;
                                    hpl51LicGrantRenewSch.Visible = true;
                                    hpl51LicGrantRenewSch.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl51LicGrantRenewSch.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 52)
                                {
                                    divLicManuVolumesera.Visible = true;
                                    hpl52LicManuVolumesera.Visible = true;
                                    hpl52LicManuVolumesera.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl52LicManuVolumesera.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 53)
                                {
                                    divProffessTax.Visible = true;
                                    hpl53ProffessTax.Visible = true;
                                    hpl53ProffessTax.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl53ProffessTax.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 54)
                                {
                                    divPCB.Visible = true;
                                    hpl54PCB.Visible = true;
                                    hpl54PCB.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl54PCB.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 55)
                                {
                                    divOccupancyCert.Visible = true;
                                    hpl55OccupancyCert.Visible = true;
                                    hpl55OccupancyCert.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl55OccupancyCert.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 56)
                                {
                                    divBoilerDept.Visible = true;
                                    hpl56BoilerDept.Visible = true;
                                    hpl56BoilerDept.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl56BoilerDept.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 57)
                                {
                                    divRegPipelineSteam.Visible = true;
                                    hpl57RegPipelineSteam.Visible = true;
                                    hpl57RegPipelineSteam.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl57RegPipelineSteam.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 58)
                                {
                                    divRegShopEst.Visible = true;
                                    hpl58RegShopEst.Visible = true;
                                    hpl58RegShopEst.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl58RegShopEst.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 59)
                                {
                                    divLicGrantBusiness.Visible = true;
                                    hpl59LicGrantBusiness.Visible = true;
                                    hpl59LicGrantBusiness.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl59LicGrantBusiness.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 60)
                                {
                                    divLicIMFL.Visible = true;
                                    hpl60LicIMFL.Visible = true;
                                    hpl60LicIMFL.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl60LicIMFL.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }
                                if (Convert.ToInt32(dsOffline.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 61)
                                {
                                    divSatateExcise.Visible = true;
                                    hpl61SatateExcise.Visible = true;
                                    hpl61SatateExcise.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILEPATH"]));
                                    hpl61SatateExcise.Text = Convert.ToString(dsOffline.Tables[1].Rows[i]["CFOA_FILENAME"]);
                                }


                            }
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
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFO/CFOIndustryDetails.aspx?next=N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void rblAlrdyObtained_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButtonList rblobtained = (RadioButtonList)sender;
                GridViewRow row = (GridViewRow)rblobtained.NamingContainer;
                int Rowindex = row.RowIndex;
                if (Rowindex >= 0)
                {
                    RadioButtonList rdbCheck = (RadioButtonList)grdApprovalsCFO.Rows[Rowindex].FindControl("rblAlrdyObtained");
                    HiddenField hdAmountCheck = (HiddenField)grdApprovalsCFO.Rows[Rowindex].FindControl("HdfAmount");
                    CheckBox chkCheck = (CheckBox)grdApprovalsCFO.Rows[Rowindex].FindControl("ChkApproval");
                    decimal amounts3 = 0;
                    Label lblAmount = (Label)row.FindControl("lblAmounts");
                    decimal amount = Convert.ToDecimal("0.00");

                    foreach (GridViewRow row1 in grdApprovalsCFO.Rows)
                    {
                        if (((RadioButtonList)row1.FindControl("rblAlrdyObtained")).SelectedItem.Value == "N")
                        {
                            ((CheckBox)row1.FindControl("ChkApproval")).Checked = true;

                            if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                            {
                                row1.Cells[6].Text = row1.Cells[3].Text;
                                amount = amount + Convert.ToDecimal(row1.Cells[6].Text);
                            }
                            else
                            { /*if (row1.Cells[6].Text != "")*/
                                row1.Cells[6].Text = Convert.ToDecimal(0).ToString("#,##0");
                                chkCheck.Enabled = true;
                            }
                        }
                        else if (((RadioButtonList)row1.FindControl("rblAlrdyObtained")).SelectedItem.Value == "Y")
                        {
                            row1.Cells[6].Text = Convert.ToDecimal(0).ToString("#,##0");
                            chkCheck.Enabled = false;
                            chkCheck.Checked = false;
                        }
                    }
                    grdApprovalsCFO.FooterRow.Cells[6].Text = amount.ToString();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
        {
            decimal amount = Convert.ToDecimal("0.00");
            CheckBox ChkApproval = (CheckBox)sender;
            GridViewRow row = (GridViewRow)ChkApproval.NamingContainer;

            foreach (GridViewRow row1 in grdApprovalsCFO.Rows)
            {
                if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                {
                    row1.Cells[6].Text = row1.Cells[3].Text;

                    amount = amount + Convert.ToDecimal(row1.Cells[6].Text);

                }
                else /*if (row1.Cells[6].Text != "")*/
                    row1.Cells[6].Text = Convert.ToDecimal(0).ToString("#,##0");
            }
            int Rowindex = row.RowIndex;
            int totalRowindex = grdApprovalsCFO.Rows.Count;

            if ((row.RowType == DataControlRowType.Footer))
            {
                row.Cells[5].Text = "Total Fee";
                row.Cells[6].Text = amount.ToString("#,##0");
            }

            grdApprovalsCFO.FooterRow.Cells[6].Text = Convert.ToDecimal(amount).ToString("#,##0");
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
        protected void BindData()
        {

            try
            {
                DataSet dsApprovals = new DataSet();
                cfoqs.UNITID = Convert.ToString(Session["CFOUNITID"]);
                cfoqs.CreatedBy = hdnUserID.Value;
                cfoqs.CFOQDID = Session["CFOQID"].ToString();
                dsApprovals = objcfobal.GetApprovalsReqFromTable(cfoqs);
                if (dsApprovals.Tables.Count > 0)
                {
                    if (dsApprovals.Tables[0].Rows.Count > 0)
                    {
                        grdApprovalsCFO.DataSource = dsApprovals.Tables[0];
                        grdApprovalsCFO.DataBind();
                        hdnQuesid.Value = Convert.ToString(Session["CFOQID"]);
                    }
                    if (dsApprovals.Tables[0].Rows.Count > 0 && dsApprovals.Tables[1].Rows.Count > 0)
                    {
                        divOffline.Visible = true; //btnNext.Enabled = false;
                        for (int i = 0; i < dsApprovals.Tables[1].Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 32)//PCB NOC
                            {
                                divMigrantReg2020.Visible = true;
                                hpl32MigrantReg.Visible = true;
                                hpl32MigrantReg.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl32MigrantReg.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 33)//PCB HAZ NOC
                            {
                                divManufactureReg.Visible = true;
                                hpl33ManufactureReg.Visible = true;
                                hpl33ManufactureReg.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl33ManufactureReg.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 34)
                            {
                                divRenewalReg.Visible = true;
                                hpl34RenewalReg.Visible = true;
                                hpl34RenewalReg.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl34RenewalReg.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 35)
                            {
                                divBoilerReg.Visible = true;
                                hpl35BoilerReg.Visible = true;
                                hpl35BoilerReg.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl35BoilerReg.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 36)
                            {
                                divLICFactory.Visible = true;
                                hpl36LICFactory.Visible = true;
                                hpl36LICFactory.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl36LICFactory.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 37)
                            {
                                divLICMIGRANTWORKMEN1979.Visible = true;
                                hpl37LICMIGRANTWORKMEN.Visible = true;
                                hpl37LICMIGRANTWORKMEN.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl37LICMIGRANTWORKMEN.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 38)
                            {
                                divLICLabourContractor1970.Visible = true;
                                hpl38LICLabourContractor.Visible = true;
                                hpl38LICLabourContractor.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl38LICLabourContractor.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 39)
                            {
                                divLicRetailDrug.Visible = true;
                                hpl39LicRetailDrug.Visible = true;
                                hpl39LicRetailDrug.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl39LicRetailDrug.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 40)
                            {
                                divLicRepairWeight.Visible = true;
                                hpl40LicRepairWeight.Visible = true;
                                hpl40LicRepairWeight.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl40LicRepairWeight.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 41)
                            {
                                divLicManuMeasure.Visible = true;
                                hpl41LicManuMeasure.Visible = true;
                                hpl41LicManuMeasure.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl41LicManuMeasure.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 42)
                            {
                                div42LicDealerWeight.Visible = true;
                                hpl42LicDealerWeight.Visible = true;
                                hpl42LicDealerWeight.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl42LicDealerWeight.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 43)
                            {
                                divIVSMeasure.Visible = true;
                                hpl43IVSMeasure.Visible = true;
                                hpl43IVSMeasure.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl43IVSMeasure.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 44)
                            {
                                divFireSafeCert.Visible = true;
                                hpl44FireSafeCert.Visible = true;
                                hpl44FireSafeCert.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl44FireSafeCert.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 45)
                            {
                                divExiseRetail.Visible = true;
                                hpl45ExiseRetail.Visible = true;
                                hpl45ExiseRetail.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl45ExiseRetail.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 46)
                            {
                                divLicWholeDrug.Visible = true;
                                hpl46LicWholeDrug.Visible = true;
                                hpl46LicWholeDrug.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl46LicWholeDrug.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 47)
                            {
                                divBrandReg.Visible = true;
                                hpl47BrandReg.Visible = true;
                                hpl47BrandReg.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl47BrandReg.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 48)
                            {
                                divLicGrantRenew.Visible = true;
                                hpl48LicGrantRenew.Visible = true;
                                hpl48LicGrantRenew.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl48LicGrantRenew.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 49)
                            {
                                divLicManuDrug.Visible = true;
                                hpl49LicManuDrug.Visible = true;
                                hpl49LicManuDrug.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl49LicManuDrug.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 50)
                            {
                                divLicManuDrugSpecifie.Visible = true;
                                hpl50LicManuDrugSpecifie.Visible = true;
                                hpl50LicManuDrugSpecifie.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl50LicManuDrugSpecifie.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 51)
                            {
                                divLicGrantRenewSch.Visible = true;
                                hpl51LicGrantRenewSch.Visible = true;
                                hpl51LicGrantRenewSch.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl51LicGrantRenewSch.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 52)
                            {
                                divLicManuVolumesera.Visible = true;
                                hpl52LicManuVolumesera.Visible = true;
                                hpl52LicManuVolumesera.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl52LicManuVolumesera.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 53)
                            {
                                divProffessTax.Visible = true;
                                hpl53ProffessTax.Visible = true;
                                hpl53ProffessTax.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl53ProffessTax.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 54)
                            {
                                divPCB.Visible = true;
                                hpl54PCB.Visible = true;
                                hpl54PCB.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl54PCB.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 55)
                            {
                                divOccupancyCert.Visible = true;
                                hpl55OccupancyCert.Visible = true;
                                hpl55OccupancyCert.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl55OccupancyCert.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 56)
                            {
                                divBoilerDept.Visible = true;
                                hpl56BoilerDept.Visible = true;
                                hpl56BoilerDept.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl56BoilerDept.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 57)
                            {
                                divRegPipelineSteam.Visible = true;
                                hpl57RegPipelineSteam.Visible = true;
                                hpl57RegPipelineSteam.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl57RegPipelineSteam.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 58)
                            {
                                divRegShopEst.Visible = true;
                                hpl58RegShopEst.Visible = true;
                                hpl58RegShopEst.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl58RegShopEst.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 59)
                            {
                                divLicGrantBusiness.Visible = true;
                                hpl59LicGrantBusiness.Visible = true;
                                hpl59LicGrantBusiness.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl59LicGrantBusiness.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 60)
                            {
                                divLicIMFL.Visible = true;
                                hpl60LicIMFL.Visible = true;
                                hpl60LicIMFL.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl60LicIMFL.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFOA_APPROVALID"]) == 61)
                            {
                                divSatateExcise.Visible = true;
                                hpl61SatateExcise.Visible = true;
                                hpl61SatateExcise.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILEPATH"]);
                                hpl61SatateExcise.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFOA_FILENAME"]);
                            }
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
        protected void btnMigrantReg_Click(object sender, EventArgs e)
        {
            try
            {
                SetGridLabelValue();
                string Error = ""; string message = "";
                if (fup32MigrantReg.HasFile)
                {
                    Error = validations(fup32MigrantReg);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup32MigrantReg.PostedFile.SaveAs(serverpath + "\\" + fup32MigrantReg.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "32";
                        objPCBNOC.DeptID = "10";
                        objPCBNOC.FilePath = serverpath + fup32MigrantReg.PostedFile.FileName;
                        objPCBNOC.FileName = fup32MigrantReg.PostedFile.FileName;
                        objPCBNOC.FileType = fup32MigrantReg.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalMIGRANTREGISTRATION";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtMigrant.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl32MigrantReg.Text = fup32MigrantReg.PostedFile.FileName;
                            hpl32MigrantReg.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup32MigrantReg.PostedFile.FileName);
                            hpl32MigrantReg.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                if (Attachment.PostedFile.ContentType != "application/pdf"
                     || !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                {

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
                }
                return Error;
            }
            catch (Exception ex)
            { throw ex; }
        }

        protected void btnUpld33ManufactureReg_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup33ManufactureReg.HasFile)
                {
                    Error = validations(fup33ManufactureReg);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup33ManufactureReg.PostedFile.SaveAs(serverpath + "\\" + fup33ManufactureReg.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "33";
                        objPCBNOC.DeptID = "10";
                        objPCBNOC.FilePath = serverpath + fup33ManufactureReg.PostedFile.FileName;
                        objPCBNOC.FileName = fup33ManufactureReg.PostedFile.FileName;
                        objPCBNOC.FileType = fup33ManufactureReg.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalMANUFACTUREREGISTRATION";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtManufacture.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl33ManufactureReg.Text = fup33ManufactureReg.PostedFile.FileName;
                            hpl33ManufactureReg.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup33ManufactureReg.PostedFile.FileName);
                            hpl33ManufactureReg.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld34RenewalReg_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup34RenewalReg.HasFile)
                {
                    Error = validations(fup34RenewalReg);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup34RenewalReg.PostedFile.SaveAs(serverpath + "\\" + fup34RenewalReg.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "34";
                        objPCBNOC.DeptID = "16";
                        objPCBNOC.FilePath = serverpath + fup34RenewalReg.PostedFile.FileName;
                        objPCBNOC.FileName = fup34RenewalReg.PostedFile.FileName;
                        objPCBNOC.FileType = fup34RenewalReg.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalRENEWALREGISTRATION";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtRegWorksService.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl34RenewalReg.Text = fup34RenewalReg.PostedFile.FileName;
                            hpl34RenewalReg.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup34RenewalReg.PostedFile.FileName);
                            hpl34RenewalReg.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld35BoilerReg_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup35BoilerReg.HasFile)
                {
                    Error = validations(fup35BoilerReg);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup35BoilerReg.PostedFile.SaveAs(serverpath + "\\" + fup35BoilerReg.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "35";
                        objPCBNOC.DeptID = "10";
                        objPCBNOC.FilePath = serverpath + fup35BoilerReg.PostedFile.FileName;
                        objPCBNOC.FileName = fup35BoilerReg.PostedFile.FileName;
                        objPCBNOC.FileType = fup35BoilerReg.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalBOILERREGISTER";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtRegBoiler.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl35BoilerReg.Text = fup35BoilerReg.PostedFile.FileName;
                            hpl35BoilerReg.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup35BoilerReg.PostedFile.FileName);
                            hpl35BoilerReg.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld36LICFactory_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup36LICFactory.HasFile)
                {
                    Error = validations(fup36LICFactory);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup36LICFactory.PostedFile.SaveAs(serverpath + "\\" + fup36LICFactory.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "36";
                        objPCBNOC.DeptID = "10";
                        objPCBNOC.FilePath = serverpath + fup36LICFactory.PostedFile.FileName;
                        objPCBNOC.FileName = fup36LICFactory.PostedFile.FileName;
                        objPCBNOC.FileType = fup36LICFactory.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICFACTORY";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtLicFactory.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl36LICFactory.Text = fup36LICFactory.PostedFile.FileName;
                            hpl36LICFactory.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup36LICFactory.PostedFile.FileName);
                            hpl36LICFactory.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld37LICMIGRANTWORKMEN_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup37LICMIGRANTWORKMEN.HasFile)
                {
                    Error = validations(fup37LICMIGRANTWORKMEN);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup37LICMIGRANTWORKMEN.PostedFile.SaveAs(serverpath + "\\" + fup37LICMIGRANTWORKMEN.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "37";
                        objPCBNOC.DeptID = "10";
                        objPCBNOC.FilePath = serverpath + fup37LICMIGRANTWORKMEN.PostedFile.FileName;
                        objPCBNOC.FileName = fup37LICMIGRANTWORKMEN.PostedFile.FileName;
                        objPCBNOC.FileType = fup37LICMIGRANTWORKMEN.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICMIGRANTWORKMEN";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtLicWorkmen1979.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl37LICMIGRANTWORKMEN.Text = fup37LICMIGRANTWORKMEN.PostedFile.FileName;
                            hpl37LICMIGRANTWORKMEN.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup37LICMIGRANTWORKMEN.PostedFile.FileName);
                            hpl37LICMIGRANTWORKMEN.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld38LICLabourContractor_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup38LICLabourContractor.HasFile)
                {
                    Error = validations(fup38LICLabourContractor);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup38LICLabourContractor.PostedFile.SaveAs(serverpath + "\\" + fup38LICLabourContractor.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "38";
                        objPCBNOC.DeptID = "10";
                        objPCBNOC.FilePath = serverpath + fup38LICLabourContractor.PostedFile.FileName;
                        objPCBNOC.FileName = fup38LICLabourContractor.PostedFile.FileName;
                        objPCBNOC.FileType = fup38LICLabourContractor.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICLABOURCONTRACTOR";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtLicLabour1970.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl38LICLabourContractor.Text = fup38LICLabourContractor.PostedFile.FileName;
                            hpl38LICLabourContractor.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup38LICLabourContractor.PostedFile.FileName);
                            hpl38LICLabourContractor.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld39LicRetailDrug_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup39LicRetailDrug.HasFile)
                {
                    Error = validations(fup39LicRetailDrug);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup39LicRetailDrug.PostedFile.SaveAs(serverpath + "\\" + fup39LicRetailDrug.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "39";
                        objPCBNOC.DeptID = "8";
                        objPCBNOC.FilePath = serverpath + fup39LicRetailDrug.PostedFile.FileName;
                        objPCBNOC.FileName = fup39LicRetailDrug.PostedFile.FileName;
                        objPCBNOC.FileType = fup39LicRetailDrug.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICRETAILSDRUG";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtLicRetailsDrug.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl39LicRetailDrug.Text = fup39LicRetailDrug.PostedFile.FileName;
                            hpl39LicRetailDrug.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup39LicRetailDrug.PostedFile.FileName);
                            hpl39LicRetailDrug.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld40LicRepairWeight_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup40LicRepairWeight.HasFile)
                {
                    Error = validations(fup40LicRepairWeight);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup40LicRepairWeight.PostedFile.SaveAs(serverpath + "\\" + fup40LicRepairWeight.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "40";
                        objPCBNOC.DeptID = "11";
                        objPCBNOC.FilePath = serverpath + fup40LicRepairWeight.PostedFile.FileName;
                        objPCBNOC.FileName = fup40LicRepairWeight.PostedFile.FileName;
                        objPCBNOC.FileType = fup40LicRepairWeight.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICREPAIREWEIGHT";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtLicRepairers.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl40LicRepairWeight.Text = fup40LicRepairWeight.PostedFile.FileName;
                            hpl40LicRepairWeight.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup40LicRepairWeight.PostedFile.FileName);
                            hpl40LicRepairWeight.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld41LicManuMeasure_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup41LicManuMeasure.HasFile)
                {
                    Error = validations(fup41LicManuMeasure);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup41LicManuMeasure.PostedFile.SaveAs(serverpath + "\\" + fup41LicManuMeasure.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "41";
                        objPCBNOC.DeptID = "11";
                        objPCBNOC.FilePath = serverpath + fup41LicManuMeasure.PostedFile.FileName;
                        objPCBNOC.FileName = fup41LicManuMeasure.PostedFile.FileName;
                        objPCBNOC.FileType = fup41LicManuMeasure.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICMANUFACTUREMEASURE";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtMeasuresLic.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl41LicManuMeasure.Text = fup41LicManuMeasure.PostedFile.FileName;
                            hpl41LicManuMeasure.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup41LicManuMeasure.PostedFile.FileName);
                            hpl41LicManuMeasure.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld42LicDealerWeight_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup42LicDealerWeight.HasFile)
                {
                    Error = validations(fup42LicDealerWeight);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup42LicDealerWeight.PostedFile.SaveAs(serverpath + "\\" + fup42LicDealerWeight.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "42";
                        objPCBNOC.DeptID = "11";
                        objPCBNOC.FilePath = serverpath + fup42LicDealerWeight.PostedFile.FileName;
                        objPCBNOC.FileName = fup42LicDealerWeight.PostedFile.FileName;
                        objPCBNOC.FileType = fup42LicDealerWeight.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICENSEDEALERWEIGHT";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtLicDealer.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl42LicDealerWeight.Text = fup42LicDealerWeight.PostedFile.FileName;
                            hpl42LicDealerWeight.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup42LicDealerWeight.PostedFile.FileName);
                            hpl42LicDealerWeight.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld43IVSMeasure_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup43IVSMeasure.HasFile)
                {
                    Error = validations(fup43IVSMeasure);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup43IVSMeasure.PostedFile.SaveAs(serverpath + "\\" + fup43IVSMeasure.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "43";
                        objPCBNOC.DeptID = "11";
                        objPCBNOC.FilePath = serverpath + fup43IVSMeasure.PostedFile.FileName;
                        objPCBNOC.FileName = fup43IVSMeasure.PostedFile.FileName;
                        objPCBNOC.FileType = fup43IVSMeasure.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalMEASUREIV";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtWeightInstrument.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl43IVSMeasure.Text = fup43IVSMeasure.PostedFile.FileName;
                            hpl43IVSMeasure.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup43IVSMeasure.PostedFile.FileName);
                            hpl43IVSMeasure.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld44FireSafeCert_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup44FireSafeCert.HasFile)
                {
                    Error = validations(fup44FireSafeCert);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup44FireSafeCert.PostedFile.SaveAs(serverpath + "\\" + fup44FireSafeCert.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "44";
                        objPCBNOC.DeptID = "9";
                        objPCBNOC.FilePath = serverpath + fup44FireSafeCert.PostedFile.FileName;
                        objPCBNOC.FileName = fup44FireSafeCert.PostedFile.FileName;
                        objPCBNOC.FileType = fup44FireSafeCert.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalFIRESAFECERTIFICATE";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtFiresaftey.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl44FireSafeCert.Text = fup44FireSafeCert.PostedFile.FileName;
                            hpl44FireSafeCert.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup44FireSafeCert.PostedFile.FileName);
                            hpl44FireSafeCert.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld45ExiseRetail_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup45ExiseRetail.HasFile)
                {
                    Error = validations(fup45ExiseRetail);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup45ExiseRetail.PostedFile.SaveAs(serverpath + "\\" + fup45ExiseRetail.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "45";
                        objPCBNOC.DeptID = "7";
                        objPCBNOC.FilePath = serverpath + fup45ExiseRetail.PostedFile.FileName;
                        objPCBNOC.FileName = fup45ExiseRetail.PostedFile.FileName;
                        objPCBNOC.FileType = fup45ExiseRetail.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalEXCISERETAIL";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtRetailPlant.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl45ExiseRetail.Text = fup45ExiseRetail.PostedFile.FileName;
                            hpl45ExiseRetail.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup45ExiseRetail.PostedFile.FileName);
                            hpl45ExiseRetail.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld46LicWholeDrug_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup46LicWholeDrug.HasFile)
                {                   
                    Error = validations(fup46LicWholeDrug);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup46LicWholeDrug.PostedFile.SaveAs(serverpath + "\\" + fup46LicWholeDrug.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "46";
                        objPCBNOC.DeptID = "8";
                        objPCBNOC.FilePath = serverpath + fup46LicWholeDrug.PostedFile.FileName;
                        objPCBNOC.FileName = fup46LicWholeDrug.PostedFile.FileName;
                        objPCBNOC.FileType = fup46LicWholeDrug.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICWHOLEDRUG";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtWholeDrugLic.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl46LicWholeDrug.Text = fup46LicWholeDrug.PostedFile.FileName;
                            hpl46LicWholeDrug.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup46LicWholeDrug.PostedFile.FileName);
                            hpl46LicWholeDrug.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld47BrandReg_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup47BrandReg.HasFile)
                {
                    Error = validations(fup47BrandReg);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup47BrandReg.PostedFile.SaveAs(serverpath + "\\" + fup47BrandReg.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "47";
                        objPCBNOC.DeptID = "7";
                        objPCBNOC.FilePath = serverpath + fup47BrandReg.PostedFile.FileName;
                        objPCBNOC.FileName = fup47BrandReg.PostedFile.FileName;
                        objPCBNOC.FileType = fup47BrandReg.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalBRANGDREGISTRATION";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtBrandReg.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl47BrandReg.Text = fup47BrandReg.PostedFile.FileName;
                            hpl47BrandReg.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup47BrandReg.PostedFile.FileName);
                            hpl47BrandReg.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld48LicGrantRenew_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup48LicGrantRenew.HasFile)
                {
                    Error = validations(fup48LicGrantRenew);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup48LicGrantRenew.PostedFile.SaveAs(serverpath + "\\" + fup48LicGrantRenew.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "48";
                        objPCBNOC.DeptID = "8";
                        objPCBNOC.FilePath = serverpath + fup48LicGrantRenew.PostedFile.FileName;
                        objPCBNOC.FileName = fup48LicGrantRenew.PostedFile.FileName;
                        objPCBNOC.FileType = fup48LicGrantRenew.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICGRANTRENEWAL";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtDrugRenewal.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl48LicGrantRenew.Text = fup48LicGrantRenew.PostedFile.FileName;
                            hpl48LicGrantRenew.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup48LicGrantRenew.PostedFile.FileName);
                            hpl48LicGrantRenew.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld49LicManuDrug_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup49LicManuDrug.HasFile)
                {
                    Error = validations(fup49LicManuDrug);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup49LicManuDrug.PostedFile.SaveAs(serverpath + "\\" + fup49LicManuDrug.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "49";
                        objPCBNOC.DeptID = "8";
                        objPCBNOC.FilePath = serverpath + fup49LicManuDrug.PostedFile.FileName;
                        objPCBNOC.FileName = fup49LicManuDrug.PostedFile.FileName;
                        objPCBNOC.FileType = fup49LicManuDrug.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICMANUFACTUREDRUG";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtLicManufacture.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl49LicManuDrug.Text = fup49LicManuDrug.PostedFile.FileName;
                            hpl49LicManuDrug.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup49LicManuDrug.PostedFile.FileName);
                            hpl49LicManuDrug.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld50LicManuDrugSpecifie_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup50LicManuDrugSpecifie.HasFile)
                {
                    Error = validations(fup50LicManuDrugSpecifie);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup50LicManuDrugSpecifie.PostedFile.SaveAs(serverpath + "\\" + fup50LicManuDrugSpecifie.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "50";
                        objPCBNOC.DeptID = "8";
                        objPCBNOC.FilePath = serverpath + fup50LicManuDrugSpecifie.PostedFile.FileName;
                        objPCBNOC.FileName = fup50LicManuDrugSpecifie.PostedFile.FileName;
                        objPCBNOC.FileType = fup50LicManuDrugSpecifie.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICMANUFACTUREDRUG";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtLicLoanDrug.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl50LicManuDrugSpecifie.Text = fup50LicManuDrugSpecifie.PostedFile.FileName;
                            hpl50LicManuDrugSpecifie.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup50LicManuDrugSpecifie.PostedFile.FileName);
                            hpl50LicManuDrugSpecifie.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld51LicGrantRenewSch_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup51LicGrantRenewSch.HasFile)
                {
                    Error = validations(fup51LicGrantRenewSch);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup51LicGrantRenewSch.PostedFile.SaveAs(serverpath + "\\" + fup51LicGrantRenewSch.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "51";
                        objPCBNOC.DeptID = "8";
                        objPCBNOC.FilePath = serverpath + fup51LicGrantRenewSch.PostedFile.FileName;
                        objPCBNOC.FileName = fup51LicGrantRenewSch.PostedFile.FileName;
                        objPCBNOC.FileType = fup51LicGrantRenewSch.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICGRANTRENEWAL";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtDrugSale.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl51LicGrantRenewSch.Text = fup51LicGrantRenewSch.PostedFile.FileName;
                            hpl51LicGrantRenewSch.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup51LicGrantRenewSch.PostedFile.FileName);
                            hpl51LicGrantRenewSch.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld52LicManuVolumesera_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup52LicManuVolumesera.HasFile)
                {
                    Error = validations(fup52LicManuVolumesera);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup52LicManuVolumesera.PostedFile.SaveAs(serverpath + "\\" + fup52LicManuVolumesera.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "52";
                        objPCBNOC.DeptID = "8";
                        objPCBNOC.FilePath = serverpath + fup52LicManuVolumesera.PostedFile.FileName;
                        objPCBNOC.FileName = fup52LicManuVolumesera.PostedFile.FileName;
                        objPCBNOC.FileType = fup52LicManuVolumesera.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICMANUFACTUREVOLUME";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtGrantManu.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl52LicManuVolumesera.Text = fup52LicManuVolumesera.PostedFile.FileName;
                            hpl52LicManuVolumesera.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup52LicManuVolumesera.PostedFile.FileName);
                            hpl52LicManuVolumesera.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld53ProffessTax_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup53ProffessTax.HasFile)
                {
                    Error = validations(fup53ProffessTax);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup53ProffessTax.PostedFile.SaveAs(serverpath + "\\" + fup53ProffessTax.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "53";
                        objPCBNOC.DeptID = "6";
                        objPCBNOC.FilePath = serverpath + fup53ProffessTax.PostedFile.FileName;
                        objPCBNOC.FileName = fup53ProffessTax.PostedFile.FileName;
                        objPCBNOC.FileType = fup53ProffessTax.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalPROFFIENCYTAX";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtProfessionalTax.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl53ProffessTax.Text = fup53ProffessTax.PostedFile.FileName;
                            hpl53ProffessTax.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup53ProffessTax.PostedFile.FileName);
                            hpl53ProffessTax.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld54PCB_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup54PCB.HasFile)
                {
                    Error = validations(fup54PCB);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup54PCB.PostedFile.SaveAs(serverpath + "\\" + fup54PCB.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "54";
                        objPCBNOC.DeptID = "12";
                        objPCBNOC.FilePath = serverpath + fup54PCB.PostedFile.FileName;
                        objPCBNOC.FileName = fup54PCB.PostedFile.FileName;
                        objPCBNOC.FileType = fup54PCB.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalPCB";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtPCB.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl54PCB.Text = fup54PCB.PostedFile.FileName;
                            hpl54PCB.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup54PCB.PostedFile.FileName);
                            hpl54PCB.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld55OccupancyCert_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup55OccupancyCert.HasFile)
                {
                    Error = validations(fup55OccupancyCert);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup55OccupancyCert.PostedFile.SaveAs(serverpath + "\\" + fup55OccupancyCert.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "55";
                        objPCBNOC.DeptID = "12";
                        objPCBNOC.FilePath = serverpath + fup55OccupancyCert.PostedFile.FileName;
                        objPCBNOC.FileName = fup55OccupancyCert.PostedFile.FileName;
                        objPCBNOC.FileType = fup55OccupancyCert.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalOCCUPANCYCERTIFICATE";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtCertificate.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl55OccupancyCert.Text = fup55OccupancyCert.PostedFile.FileName;
                            hpl55OccupancyCert.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup55OccupancyCert.PostedFile.FileName);
                            hpl55OccupancyCert.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld56BoilerDept_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup56BoilerDept.HasFile)
                {
                    Error = validations(fup56BoilerDept);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup56BoilerDept.PostedFile.SaveAs(serverpath + "\\" + fup56BoilerDept.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "56";
                        objPCBNOC.DeptID = "12";
                        objPCBNOC.FilePath = serverpath + fup56BoilerDept.PostedFile.FileName;
                        objPCBNOC.FileName = fup56BoilerDept.PostedFile.FileName;
                        objPCBNOC.FileType = fup56BoilerDept.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalBOILREDEPARTMENT";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtsteamDept.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl56BoilerDept.Text = fup56BoilerDept.PostedFile.FileName;
                            hpl56BoilerDept.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup56BoilerDept.PostedFile.FileName);
                            hpl56BoilerDept.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld57RegPipelineSteam_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup57RegPipelineSteam.HasFile)
                {
                    Error = validations(fup57RegPipelineSteam);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup57RegPipelineSteam.PostedFile.SaveAs(serverpath + "\\" + fup57RegPipelineSteam.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "57";
                        objPCBNOC.DeptID = "12";
                        objPCBNOC.FilePath = serverpath + fup57RegPipelineSteam.PostedFile.FileName;
                        objPCBNOC.FileName = fup57RegPipelineSteam.PostedFile.FileName;
                        objPCBNOC.FileType = fup57RegPipelineSteam.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalREGISTERPIPLINE";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtBoilerSteam.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl57RegPipelineSteam.Text = fup57RegPipelineSteam.PostedFile.FileName;
                            hpl57RegPipelineSteam.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup57RegPipelineSteam.PostedFile.FileName);
                            hpl57RegPipelineSteam.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld58RegShopEst_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup58RegShopEst.HasFile)
                {
                    Error = validations(fup58RegShopEst);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup58RegShopEst.PostedFile.SaveAs(serverpath + "\\" + fup58RegShopEst.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "58";
                        objPCBNOC.DeptID = "10";
                        objPCBNOC.FilePath = serverpath + fup58RegShopEst.PostedFile.FileName;
                        objPCBNOC.FileName = fup58RegShopEst.PostedFile.FileName;
                        objPCBNOC.FileType = fup58RegShopEst.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalREDISTERSHOP";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtShopESt.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl58RegShopEst.Text = fup58RegShopEst.PostedFile.FileName;
                            hpl58RegShopEst.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup58RegShopEst.PostedFile.FileName);
                            hpl58RegShopEst.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld59LicGrantBusiness_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup59LicGrantBusiness.HasFile)
                {
                    Error = validations(fup59LicGrantBusiness);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup59LicGrantBusiness.PostedFile.SaveAs(serverpath + "\\" + fup59LicGrantBusiness.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "59";
                        objPCBNOC.DeptID = "12";
                        objPCBNOC.FilePath = serverpath + fup59LicGrantBusiness.PostedFile.FileName;
                        objPCBNOC.FileName = fup59LicGrantBusiness.PostedFile.FileName;
                        objPCBNOC.FileType = fup59LicGrantBusiness.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICGRANTBUSINESS";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtGrantLic.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl59LicGrantBusiness.Text = fup59LicGrantBusiness.PostedFile.FileName;
                            hpl59LicGrantBusiness.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup59LicGrantBusiness.PostedFile.FileName);
                            hpl59LicGrantBusiness.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld60LicIMFL_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup60LicIMFL.HasFile)
                {
                    Error = validations(fup60LicIMFL);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup60LicIMFL.PostedFile.SaveAs(serverpath + "\\" + fup60LicIMFL.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "60";
                        objPCBNOC.DeptID = "7";
                        objPCBNOC.FilePath = serverpath + fup60LicIMFL.PostedFile.FileName;
                        objPCBNOC.FileName = fup60LicIMFL.PostedFile.FileName;
                        objPCBNOC.FileType = fup60LicIMFL.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalLICMFL";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtLocalSale.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl60LicIMFL.Text = fup60LicIMFL.PostedFile.FileName;
                            hpl60LicIMFL.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup60LicIMFL.PostedFile.FileName);
                            hpl60LicIMFL.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpld61SatateExcise_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup61SatateExcise.HasFile)
                {
                    Error = validations(fup61SatateExcise);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnQuesid.Value + "\\" + "OfflineApprovals" + "\\" + "1" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup61SatateExcise.PostedFile.SaveAs(serverpath + "\\" + fup61SatateExcise.PostedFile.FileName);

                        CFOAttachments objPCBNOC = new CFOAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objPCBNOC.Questionnareid = hdnQuesid.Value;
                        objPCBNOC.ApprovalID = "61";
                        objPCBNOC.DeptID = "7";
                        objPCBNOC.FilePath = serverpath + fup61SatateExcise.PostedFile.FileName;
                        objPCBNOC.FileName = fup61SatateExcise.PostedFile.FileName;
                        objPCBNOC.FileType = fup61SatateExcise.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalSTATEEXCISE";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        objPCBNOC.ReferenceNo = txtExcise.Text;
                        result = objcfobal.InsertCFOAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl61SatateExcise.Text = fup61SatateExcise.PostedFile.FileName;
                            hpl61SatateExcise.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fup61SatateExcise.PostedFile.FileName);
                            hpl61SatateExcise.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
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

        protected void btnNext2_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = OfflineValidations();
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFO/CFOIndustryDetails.aspx?next=N");
                else
                {
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

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
        public String OfflineValidations()
        {
            try
            {
                string errormsg = "";
                int SlNo = 1;
                if (divMigrantReg2020.Visible == true && (string.IsNullOrWhiteSpace(hpl32MigrantReg.Text) || hpl32MigrantReg.Text == "" || hpl32MigrantReg.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from The Meghalaya Identification, Registration of Migrant Workers Act, 2020  \\n";
                    SlNo = SlNo + 1;
                }
                if (divManufactureReg.Visible == true && (string.IsNullOrWhiteSpace(hpl33ManufactureReg.Text) || hpl33ManufactureReg.Text == "" || hpl33ManufactureReg.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Registration of Manufacturers / Repairers/Erectors of Boilers  \\n";
                    SlNo = SlNo + 1;
                }
                if (divRenewalReg.Visible == true && (string.IsNullOrWhiteSpace(hpl34RenewalReg.Text) || hpl34RenewalReg.Text == "" || hpl34RenewalReg.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Registration of Contractors for Works and services and Renewal  \\n";
                    SlNo = SlNo + 1;
                }
                if (divBoilerReg.Visible == true && (string.IsNullOrWhiteSpace(hpl35BoilerReg.Text) || hpl35BoilerReg.Text == "" || hpl35BoilerReg.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Registration of Boiler  \\n";
                    SlNo = SlNo + 1;
                }
                if (divLICFactory.Visible == true && (string.IsNullOrWhiteSpace(hpl36LICFactory.Text) || hpl36LICFactory.Text == "" || hpl36LICFactory.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from License to Work as a Factory  \\n";
                    SlNo = SlNo + 1;
                }
                if (divLICMIGRANTWORKMEN1979.Visible == true && (string.IsNullOrWhiteSpace(hpl37LICMIGRANTWORKMEN.Text) || hpl37LICMIGRANTWORKMEN.Text == "" || hpl37LICMIGRANTWORKMEN.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from License for Contractors under the Interstate Migrant Workmen Act 1979 \\n";
                    SlNo = SlNo + 1;
                }
                if (divLICLabourContractor1970.Visible == true && (string.IsNullOrWhiteSpace(hpl38LICLabourContractor.Text) || hpl38LICLabourContractor.Text == "" || hpl38LICLabourContractor.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from License for Contractors under the Contract Labour Act 1970 \\n";
                    SlNo = SlNo + 1;
                }
                if (divLicRetailDrug.Visible == true && (string.IsNullOrWhiteSpace(hpl39LicRetailDrug.Text) || hpl39LicRetailDrug.Text == "" || hpl39LicRetailDrug.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Licence for Retail and Wholesale Drug licence \\n";
                    SlNo = SlNo + 1;
                }
                if (divLicRepairWeight.Visible == true && (string.IsNullOrWhiteSpace(hpl40LicRepairWeight.Text) || hpl40LicRepairWeight.Text == "" || hpl40LicRepairWeight.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Licence as Repairers of Weights & Measures  \\n";
                    SlNo = SlNo + 1;
                }
                if (divLicManuMeasure.Visible == true && (string.IsNullOrWhiteSpace(hpl41LicManuMeasure.Text) || hpl41LicManuMeasure.Text == "" || hpl41LicManuMeasure.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Licence as Manufacturer of Weights & Measures \\n";
                    SlNo = SlNo + 1;
                }
                if (div42LicDealerWeight.Visible == true && (string.IsNullOrWhiteSpace(hpl42LicDealerWeight.Text) || hpl42LicDealerWeight.Text == "" || hpl42LicDealerWeight.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Licence as Dealers in Weights & Measures \\n";
                    SlNo = SlNo + 1;
                }
                if (divIVSMeasure.Visible == true && (string.IsNullOrWhiteSpace(hpl43IVSMeasure.Text) || hpl43IVSMeasure.Text == "" || hpl43IVSMeasure.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Initial Verification And Stamping of Weighing and Measuring Instrument \\n";
                    SlNo = SlNo + 1;
                }
                if (divFireSafeCert.Visible == true && (string.IsNullOrWhiteSpace(hpl44FireSafeCert.Text) || hpl44FireSafeCert.Text == "" || hpl44FireSafeCert.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Fire Safety Certificate \\n";
                    SlNo = SlNo + 1;
                }
                if (divExiseRetail.Visible == true && (string.IsNullOrWhiteSpace(hpl45ExiseRetail.Text) || hpl45ExiseRetail.Text == "" || hpl45ExiseRetail.Text == null))
                {
                    errormsg = errormsg + SlNo + "Please Upload Pre Operational Approval from Excise License for Wholesale, Retail, Bottling, Distillery Plant \\n";
                    SlNo = SlNo + 1;
                }
                if (divLicWholeDrug.Visible == true && (string.IsNullOrWhiteSpace(hpl46LicWholeDrug.Text) || hpl46LicWholeDrug.Text == "" || hpl46LicWholeDrug.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Change of Constitution of Licence for Retail and Wholesale Drug licence \\n";
                    SlNo = SlNo + 1;
                }
                if (divBrandReg.Visible == true && (string.IsNullOrWhiteSpace(hpl47BrandReg.Text) || hpl47BrandReg.Text == "" || hpl47BrandReg.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Brand and Label Registration \\n";
                    SlNo = SlNo + 1;
                }
                if (divLicGrantRenew.Visible == true && (string.IsNullOrWhiteSpace(hpl48LicGrantRenew.Text) || hpl48LicGrantRenew.Text == "" || hpl48LicGrantRenew.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Application For The Grant/Renewal Of License To Manufacture Drugs For Purpose Of Examination, Test Or Analysis \\n";
                    SlNo = SlNo + 1;
                }
                if (divLicManuDrug.Visible == true && (string.IsNullOrWhiteSpace(hpl49LicManuDrug.Text) || hpl49LicManuDrug.Text == "" || hpl49LicManuDrug.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Application For The Grant Of Loan License To Manufacture For Sale Or For Distribution Of Drugs \\n";
                    SlNo = SlNo + 1;
                }
                if (divLicManuDrugSpecifie.Visible == true && (string.IsNullOrWhiteSpace(hpl50LicManuDrugSpecifie.Text) || hpl50LicManuDrugSpecifie.Text == "" || hpl50LicManuDrugSpecifie.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Application For The Grant Of A Loan License To Manufacture For Sale Or For Distribution Of Drugs \\n";
                    SlNo = SlNo + 1;
                }
                if (divLicGrantRenewSch.Visible == true && (string.IsNullOrWhiteSpace(hpl51LicGrantRenewSch.Text) || hpl51LicGrantRenewSch.Text == "" || hpl51LicGrantRenewSch.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Application For The Grant /Renewal Of License To Repack For Sale Or For Distribution Of Drugs \\n";
                    SlNo = SlNo + 1;
                }
                if (divLicManuVolumesera.Visible == true && (string.IsNullOrWhiteSpace(hpl52LicManuVolumesera.Text) || hpl52LicManuVolumesera.Text == "" || hpl52LicManuVolumesera.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Application For Application For The Grant /Renewal Of License To Manufacture For Sale Or For Distribution Of Large Volume Parenterals/Sera And Vacciness \\n";
                    SlNo = SlNo + 1;
                }
                if (divProffessTax.Visible == true && (string.IsNullOrWhiteSpace(hpl53ProffessTax.Text) || hpl53ProffessTax.Text == "" || hpl53ProffessTax.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Application For Application for Certificate of Enrollment of Professional Tax under the Meghalaya Professions \\n";
                    SlNo = SlNo + 1;
                }
                if (divPCB.Visible == true && (string.IsNullOrWhiteSpace(hpl54PCB.Text) || hpl54PCB.Text == "" || hpl54PCB.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Application For CFO from Pollution Contorl Board  \\n";
                    SlNo = SlNo + 1;
                }
                if (divOccupancyCert.Visible == true && (string.IsNullOrWhiteSpace(hpl55OccupancyCert.Text) || hpl55OccupancyCert.Text == "" || hpl55OccupancyCert.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Occupancy Certificate  \\n";
                    SlNo = SlNo + 1;
                }
                if (divBoilerDept.Visible == true && (string.IsNullOrWhiteSpace(hpl56BoilerDept.Text) || hpl56BoilerDept.Text == "" || hpl56BoilerDept.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Boilers Steam Pipeline Erection Permission Certificate from Boilers Department \\n";
                    SlNo = SlNo + 1;
                }
                if (divRegPipelineSteam.Visible == true && (string.IsNullOrWhiteSpace(hpl57RegPipelineSteam.Text) || hpl57RegPipelineSteam.Text == "" || hpl57RegPipelineSteam.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Boilers Steam Pipeline Registration Number Certificate  \\n";
                    SlNo = SlNo + 1;
                }
                if (divRegShopEst.Visible == true && (string.IsNullOrWhiteSpace(hpl58RegShopEst.Text) || hpl58RegShopEst.Text == "" || hpl58RegShopEst.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Registration of Shops and Establishment - FORM - A \\n";
                    SlNo = SlNo + 1;
                }
                if (divLicGrantBusiness.Visible == true && (string.IsNullOrWhiteSpace(hpl59LicGrantBusiness.Text) || hpl59LicGrantBusiness.Text == "" || hpl59LicGrantBusiness.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from Application for Grant of Business License \\n";
                    SlNo = SlNo + 1;
                }
                if (divLicIMFL.Visible == true && (string.IsNullOrWhiteSpace(hpl60LicIMFL.Text) || hpl60LicIMFL.Text == "" || hpl60LicIMFL.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from License for Local Sale, Import and Export Permit of Spirit and Indian-Made Foreign Liquor (IMFL)  \\n";
                    SlNo = SlNo + 1;
                }
                if (divSatateExcise.Visible == true && (string.IsNullOrWhiteSpace(hpl61SatateExcise.Text) || hpl61SatateExcise.Text == "" || hpl61SatateExcise.Text == null))
                {
                    errormsg = errormsg + SlNo + ". Please Upload Pre Operational Approval from State Excise - Excise Verification Certificate  \\n";
                    SlNo = SlNo + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SetGridLabelValue()
        {
            try
            {
                int rowsIndex = grdApprovalsCFO.Rows.Count;

                if (rowsIndex > 0)
                {

                    for (int i = 0; i < rowsIndex; i++)
                    {
                        CheckBox chkCheck = (CheckBox)grdApprovalsCFO.Rows[i].FindControl("ChkApproval");
                        GridViewRow grdRwos = (GridViewRow)chkCheck.NamingContainer;
                        if (chkCheck.Checked == true)
                            grdRwos.Cells[6].Text = grdRwos.Cells[3].Text;
                        else
                            grdRwos.Cells[6].Text = "0";
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