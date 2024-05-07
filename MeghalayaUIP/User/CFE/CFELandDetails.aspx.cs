using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFELandDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
        string UnitID;
        protected void Page_Load(object sender, EventArgs e)
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
                if (Convert.ToString(Session["UNITID"]) != "")
                { 
                    UnitID = Convert.ToString(Session["UNITID"]);
                }
                else
                {
                    string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                    Response.Redirect(newurl);
                }
                Page.MaintainScrollPositionOnPostBack = true;
                if (!IsPostBack)
                {
                    BindLineOfActivity();
                    BindDistricts();
                    BindData();
                }
            }
        }
        protected void BindDistricts()
        {
            try
            {
                ddlDistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;

                strmode = "";

                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlDistrict.DataSource = objDistrictModel;
                    ddlDistrict.DataValueField = "DistrictId";
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataBind();
                }
                else
                {
                    ddlDistrict.DataSource = null;
                    ddlDistrict.DataBind();
                }
                AddSelect(ddlDistrict);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void BindMandal(DropDownList ddlmndl, string DistrictID)
        {
            try
            {
                List<MasterMandals> objMandal = mstrBAL.GetMandals(DistrictID);

                if (objMandal != null && objMandal.Count > 0)
                {
                    ddlmndl.DataSource = objMandal;
                    ddlmndl.DataValueField = "MandalId";
                    ddlmndl.DataTextField = "MandalName";
                    ddlmndl.DataBind();
                }
                else
                {
                    ddlmndl.DataSource = null;
                    ddlmndl.DataBind();
                }
                AddSelect(ddlmndl);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }

        }
        protected void BindVillages(DropDownList ddlvlg, string MandalID)
        {
            try
            {
                List<MasterVillages> objVillage = new List<MasterVillages>();
                string strmode = string.Empty;

                objVillage = mstrBAL.GetVillages(MandalID);

                if (objVillage != null)
                {
                    ddlvlg.DataSource = objVillage;
                    ddlvlg.DataValueField = "VillageId";
                    ddlvlg.DataTextField = "VillageName";
                    ddlvlg.DataBind();
                }
                else
                {
                    ddlvlg.DataSource = null;
                    ddlvlg.DataBind();
                }
                AddSelect(ddlvlg);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetCFELandDet(hdnUserID.Value, UnitID);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtSurveyno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_SURVEYNO"]);
                            ddlDistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_DISTID"]);
                            ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANDALID"]);
                            ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_VILLAGEID"]);

                            //ddlDistrict.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_DISTNAME"]);
                            //ddlMandal.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANDALNAME"]);
                            //ddlVillage.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_VILLAGENAME"]);

                            txtGrampanchayat.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_GRAMPANCHAYAT"]);
                            txtpincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_PINCODE"]);
                            txtLandline.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_TELEPHONENO"]);
                            txtSiteArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_TOTALEXTEND"]);
                            ddlBuildingType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_BUILDINGTYPE"]);
                            ddlLandplan.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_LAND"]);
                            txtDevelopmentArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_AREADEVELOPMENT"]);
                            txtBuiltUpArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_TOTALBUILTUP"]);
                            txtBuildingHeight.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_BUILDINGHT"]);


                            txtExstngWidth.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_EXISTINGWIDTH"]);
                            ddlApproachRoad.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_APPROACHTYPE"]);
                            ddllandlocation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_LANDLOACTION"]);
                            ddlBuildingApproval.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_BUILDINGAPPROVAL"]);
                            ddlLineofActivity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_INDUSTRYACTIVITY"]);
                            txtPCBCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_CATEGORYINDUSTRY"]);
                            rblAffectedroad.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_ROADWIDENING"]);
                            ddlland.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_LANDPART"]);
                            txtArchitectLicNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_ARCHITECTLICNO"]);
                            txtArchitectName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_ARCHITECTNAME"]);
                            txtArchitectMobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_ARCHITECTMOBILE"]);
                            txtStrEngnrName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_STRUCTURALENGNAME"]);
                            txtStrEngnrMobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_STRUCTURALENGMOBILE"]);
                            txtStrLicNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_STRUCTURALLICNO"]);
                        }
                        else
                        {
                            ddlDistrict.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_PROPDISTRICTID"]);
                            ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlMandal.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_PROPMANDALID"]);
                            ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlVillage.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_PROPVILLAGEID"]);
                            txtSiteArea.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_TOTALEXTENTLAND"]);
                            txtBuiltUpArea.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_BUILTUPAREA"]);
                            txtBuildingHeight.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_BUILDINGHT"]);
                            //string Sector = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_SECTOR"]);
                            // BindLineOfActivity(Sector);
                            ddlLineofActivity.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_LOAID"]);
                            txtPCBCategory.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_PCBCATEGORY"]);


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void BindLineOfActivity()
        {
            try
            {
                List<MasterLineOfActivity> objLOA = mstrBAL.GetLineOfActivity("");

                if (objLOA != null && objLOA.Count > 0)
                {
                    ddlLineofActivity.DataSource = objLOA;
                    ddlLineofActivity.DataValueField = "LOAId";
                    ddlLineofActivity.DataTextField = "LOAName";
                    ddlLineofActivity.DataBind();
                }
                else
                {

                    ddlLineofActivity.DataSource = null;
                    ddlLineofActivity.DataBind();
                }

                AddSelect(ddlLineofActivity);
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                if (ddlDistrict.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistrict.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }

        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillage.ClearSelection();
                if (ddlMandal.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlVillage, ddlMandal.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void btnPreviuos_Click(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            string Quesstionriids = "1001";
            string UnitId = "1";
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {

                    CFELand objCFELandDet = new CFELand();

                    if (Convert.ToString(ViewState["UnitID"]) != "")
                    { objCFELandDet.UNITID = Convert.ToString(ViewState["UnitID"]); }
                    objCFELandDet.CreatedBy = hdnUserID.Value;
                    objCFELandDet.IPAddress = getclientIP();
                    objCFELandDet.Questionnariid = Quesstionriids;
                    objCFELandDet.UnitId = UnitId;
                    objCFELandDet.Survey_Plot = txtSurveyno.Text;
                    objCFELandDet.District = ddlDistrict.SelectedValue;
                    objCFELandDet.Mandal = ddlMandal.SelectedValue;
                    objCFELandDet.Village = ddlVillage.SelectedValue;
                    objCFELandDet.DistrictName = ddlDistrict.SelectedItem.Text;
                    objCFELandDet.MandalName = ddlMandal.SelectedItem.Text;
                    objCFELandDet.VillageName = ddlVillage.SelectedItem.Text;
                    objCFELandDet.Name_Grampanchayat = txtGrampanchayat.Text;
                    objCFELandDet.Pincode = txtpincode.Text;
                    objCFELandDet.Landline = txtLandline.Text;
                    objCFELandDet.Total_Extent_Area = txtSiteArea.Text;
                    objCFELandDet.Type_Building = ddlBuildingType.SelectedValue;
                    objCFELandDet.Land_Master_Plan = ddlLandplan.SelectedValue;
                    objCFELandDet.Proposed_Area_Develop = txtDevelopmentArea.Text;
                    objCFELandDet.Total_Built_Area = txtBuiltUpArea.Text;
                    objCFELandDet.Height_Building = txtBuildingHeight.Text;
                    objCFELandDet.Existing_Width = txtExstngWidth.Text;
                    objCFELandDet.Type_ApproachRoad = ddlApproachRoad.SelectedValue;
                    objCFELandDet.Land_Locationfalls = ddllandlocation.SelectedValue;
                    objCFELandDet.Building_Approval = ddlBuildingApproval.SelectedValue;
                    objCFELandDet.Industry_Product = ddlLineofActivity.SelectedValue;
                    objCFELandDet.Category_Industry = txtPCBCategory.Text;
                    objCFELandDet.Road_Widening = rblAffectedroad.SelectedValue;
                    objCFELandDet.land_part = ddlland.SelectedValue;
                    objCFELandDet.Architect_LICNo = txtArchitectLicNo.Text;
                    objCFELandDet.Architect_Name = txtArchitectName.Text;
                    objCFELandDet.Architect_MobileNo = txtArchitectMobileno.Text;
                    objCFELandDet.Structural_Engineer = txtStrEngnrName.Text;
                    objCFELandDet.Structural_Mobile_No = txtStrEngnrMobileno.Text;
                    objCFELandDet.StructuralLicNo = txtStrLicNo.Text;
                    // objCFELandDet.Architectural_dwg = FileArchitech.FileName;
                    //objCFELandDet.Common_Affidavit = Fileaffidavit.FileName;


                    result = objcfebal.InsertCFELandDet(objCFELandDet);
                    ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Basic Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                }
                else
                {
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {

        }
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtSurveyno.Text) || txtSurveyno.Text == "" || txtSurveyno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Plot Number  \\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedIndex == -1 || ddlDistrict.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric \\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == -1 || ddlMandal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtGrampanchayat.Text) || txtGrampanchayat.Text == "" || txtGrampanchayat.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Grampanchayat   \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtpincode.Text) || txtpincode.Text == "" || txtpincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode Number  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandline.Text) || txtLandline.Text == "" || txtLandline.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter LandLine Number  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSiteArea.Text) || txtSiteArea.Text == "" || txtSiteArea.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Extended Land SitArea  \\n";
                    slno = slno + 1;
                }
                if (ddlBuildingType.SelectedIndex == -1 || ddlBuildingType.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Building \\n";
                    slno = slno + 1;
                }
                if (ddlLandplan.SelectedIndex == -1 || ddlLandplan.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Land Use Master \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuiltUpArea.Text) || txtBuiltUpArea.Text == "" || txtBuiltUpArea.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter BuildUp Area Sqft  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuildingHeight.Text) || txtBuildingHeight.Text == "" || txtBuildingHeight.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Height of the Building   \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExstngWidth.Text) || txtExstngWidth.Text == "" || txtExstngWidth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter RoadFeet  \\n";
                    slno = slno + 1;
                }
                if (ddlApproachRoad.SelectedIndex == -1 || ddlApproachRoad.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Approach Road \\n";
                    slno = slno + 1;
                }
                if (ddllandlocation.SelectedIndex == -1 || ddllandlocation.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Land Location Falls Under \\n";
                    slno = slno + 1;
                }
                if (ddlBuildingApproval.SelectedIndex == -1 || ddlBuildingApproval.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Building Approval \\n";
                    slno = slno + 1;
                }
                if (ddlLineofActivity.SelectedIndex == -1 || ddlLineofActivity.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Industry/Product/Activity \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPCBCategory.Text) || txtPCBCategory.Text == "" || txtPCBCategory.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Architect License No  \\n";
                    slno = slno + 1;
                }
                if (rblAffectedroad.SelectedIndex == -1 || rblAffectedroad.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Affected Road \\n";
                    slno = slno + 1;
                }
                if (ddlland.SelectedIndex == -1 || ddlland.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Land \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtArchitectLicNo.Text) || txtArchitectLicNo.Text == "" || txtArchitectLicNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Architect License No  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtArchitectName.Text) || txtArchitectName.Text == "" || txtArchitectName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Architect Name  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtArchitectMobileno.Text) || txtArchitectMobileno.Text == "" || txtArchitectMobileno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Architect Mobile No  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtStrEngnrName.Text) || txtStrEngnrName.Text == "" || txtStrEngnrName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Structural Engineer Name  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtStrEngnrMobileno.Text) || txtStrEngnrMobileno.Text == "" || txtStrEngnrMobileno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Structural Mobile No \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtStrLicNo.Text) || txtStrLicNo.Text == "" || txtStrLicNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Structural License No  \\n";
                    slno = slno + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
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

    }
}