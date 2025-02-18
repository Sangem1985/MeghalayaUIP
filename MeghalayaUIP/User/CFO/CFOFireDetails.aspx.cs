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
    public partial class CFOFireDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
        string UnitID, ErrorMsg = "", result = "";
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
                        UnitID = Convert.ToString(Session["CFOUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/CFO/CFOUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {

                        GetAppliedorNot();

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
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = objcfobal.GetApprovalDataByDeptId(hdnUserID.Value, Convert.ToString(Session["CFOUNITID"]), Convert.ToString(Session["CFOQID"]), "9", "");
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsnew.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(dsnew.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "44" || Convert.ToString(dsnew.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "55")
                        {
                            BindDistricts();
                            BindBuildingType();
                            Binddata();
                        }

                    }
                }
                else
                {
                    if (Request.QueryString[0].ToString() == "N")
                    {
                        Response.Redirect("~/User/CFO/CFOBusinessLicenseDetails.aspx?next=N");
                    }
                    else
                    {
                        Response.Redirect("~/User/CFO/CFOProffessionalTax.aspx?Previous=P");
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
        protected List<TextBox> FindEmptyTextboxes(Control container)
        {

            List<TextBox> emptyTextboxes = new List<TextBox>();
            foreach (Control control in container.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textbox = (TextBox)control;
                    if (string.IsNullOrWhiteSpace(textbox.Text))
                    {
                        emptyTextboxes.Add(textbox);
                        textbox.BorderColor = System.Drawing.Color.Red;
                    }
                }

                if (control.HasControls())
                {
                    emptyTextboxes.AddRange(FindEmptyTextboxes(control));
                }
            }
            return emptyTextboxes;
        }
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfobal.GetCFOFireDetails(hdnUserID.Value, UnitID);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[1].Rows[0]["CFOFD_UNITID"]);

                    txtName.Text = ds.Tables[1].Rows[0]["CFOFD_BUILDNAME"].ToString();
                    ddlCategory.SelectedValue = ds.Tables[1].Rows[0]["CFOFD_CATEGORYBUILD"].ToString();
                    txtFeeAmount.Text = ds.Tables[1].Rows[0]["CFOFD_FEEAMOUNT"].ToString();
                    ddlDistrict.SelectedValue = ds.Tables[1].Rows[0]["CFOFD_DISTRICID"].ToString();
                    ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlMandal.SelectedValue = ds.Tables[1].Rows[0]["CFOFD_MANDALID"].ToString();
                    ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlVillage.SelectedValue = ds.Tables[1].Rows[0]["CFOFD_VILLAGEID"].ToString();
                    txtLandline.Text = ds.Tables[1].Rows[0]["CFOFD_Locality"].ToString();
                    txtSitArea.Text = ds.Tables[1].Rows[0]["CFOFD_Landmark"].ToString();
                    txtPincode.Text = ds.Tables[1].Rows[0]["CFOFD_Pincode"].ToString();
                    txtPlotAREA.Text = ds.Tables[1].Rows[0]["CFOFD_PLOTAREA"].ToString();
                    txtBreadth.Text = ds.Tables[1].Rows[0]["CFOFD_DRIVEPROPSED"].ToString();
                    txtBuildupArea.Text = ds.Tables[1].Rows[0]["CFOFD_BUILDUPAREA"].ToString();
                    txtExisting.Text = ds.Tables[1].Rows[0]["CFOFD_EXISTINGROAD"].ToString();
                    txtEast.Text = ds.Tables[1].Rows[0]["CFOFD_East"].ToString();
                    txtWest.Text = ds.Tables[1].Rows[0]["CFOFD_West"].ToString();
                    txtNorth.Text = ds.Tables[1].Rows[0]["CFOFD_North"].ToString();
                    txtSouth.Text = ds.Tables[1].Rows[0]["CFOFD_South"].ToString();
                    txtDistEast.Text = ds.Tables[1].Rows[0]["CFOFD_DISTANCEEAST"].ToString();
                    txtDistWest.Text = ds.Tables[1].Rows[0]["CFOFD_DISTANCEWEST"].ToString();
                    txtDistNorth.Text = ds.Tables[1].Rows[0]["CFOFD_DISTANCENORTH"].ToString();
                    txtDistSouth.Text = ds.Tables[1].Rows[0]["CFOFD_DISTANCESOUTH"].ToString();
                    txtFire.Text = ds.Tables[1].Rows[0]["CFOFD_FIRESTATION"].ToString();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 99)
                        {
                            hypFireLayout.Visible = true;
                            hypFireLayout.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILEPATH"]));
                            hypFireLayout.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 100)
                        {
                            hypFireCertificate.Visible = true;
                            hypFireCertificate.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILEPATH"]));
                            hypFireCertificate.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 101)
                        {
                            hypBuildingplan.Visible = true;
                            hypBuildingplan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILEPATH"]));
                            hypBuildingplan.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 102)
                        {
                            hypElectricalinstall.Visible = true;
                            hypElectricalinstall.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILEPATH"]));
                            hypElectricalinstall.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 103)
                        {
                            hypFireSaftey.Visible = true;
                            hypFireSaftey.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILEPATH"]));
                            hypFireSaftey.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 104)
                        {
                            hypPreconNOC.Visible = true;
                            hypPreconNOC.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILEPATH"]));
                            hypPreconNOC.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
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

        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {

                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    HOMEDEPARTMENT ObjCFOFireDepartment = new HOMEDEPARTMENT();

                    ObjCFOFireDepartment.UNITID = Convert.ToString(Session["CFOUNITID"]);
                    ObjCFOFireDepartment.CreatedBy = hdnUserID.Value;
                    ObjCFOFireDepartment.IPAddress = getclientIP();
                    ObjCFOFireDepartment.Questionnariid = Convert.ToString(Session["CFOQID"]);
                    ObjCFOFireDepartment.UnitId = Convert.ToString(Session["CFOUNITID"]);

                    ObjCFOFireDepartment.BuildingName = txtName.Text.Trim();
                    ObjCFOFireDepartment.CategoryBuild = ddlCategory.SelectedValue;
                    ObjCFOFireDepartment.FeeAmount = txtFeeAmount.Text;
                    ObjCFOFireDepartment.District = ddlDistrict.SelectedValue;
                    ObjCFOFireDepartment.Mandal = ddlMandal.SelectedValue;
                    ObjCFOFireDepartment.Village = ddlVillage.SelectedValue;
                    ObjCFOFireDepartment.Locality = txtLandline.Text.Trim();
                    ObjCFOFireDepartment.Landmark = txtSitArea.Text.Trim();
                    ObjCFOFireDepartment.Pincode = txtPincode.Text;
                    ObjCFOFireDepartment.PlotArea = txtPlotAREA.Text;
                    ObjCFOFireDepartment.Breadth = txtBreadth.Text;
                    ObjCFOFireDepartment.BuildUpArea = txtBuildupArea.Text;
                    ObjCFOFireDepartment.RoadApproach = txtExisting.Text;
                    ObjCFOFireDepartment.East = txtEast.Text;
                    ObjCFOFireDepartment.West = txtWest.Text;
                    ObjCFOFireDepartment.North = txtNorth.Text;
                    ObjCFOFireDepartment.South = txtSouth.Text;
                    ObjCFOFireDepartment.DistanceEAST = txtDistEast.Text;
                    ObjCFOFireDepartment.DistanceWEST = txtDistWest.Text;
                    ObjCFOFireDepartment.DistanceNORTH = txtDistNorth.Text;
                    ObjCFOFireDepartment.DistanceSOUTH = txtDistSouth.Text;
                    ObjCFOFireDepartment.FireStation = txtFire.Text;

                    result = objcfobal.InsertCFOFIREDEPT(ObjCFOFireDepartment);
                    //ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Fire Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                }
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
        protected List<DropDownList> FindEmptyDropdowns(Control container)
        {
            List<DropDownList> emptyDropdowns = new List<DropDownList>();

            foreach (Control control in container.Controls)
            {
                if (control is DropDownList)
                {
                    DropDownList dropdown = (DropDownList)control;
                    if (string.IsNullOrWhiteSpace(dropdown.SelectedValue) || dropdown.SelectedValue == "" || dropdown.SelectedItem.Text == "--Select--" || dropdown.SelectedIndex == -1)
                    {
                        emptyDropdowns.Add(dropdown);
                        dropdown.BorderColor = System.Drawing.Color.Red;
                    }
                }

                if (control.HasControls())
                {
                    emptyDropdowns.AddRange(FindEmptyDropdowns(control));
                }
            }

            return emptyDropdowns;
        }

        private List<RadioButtonList> FindEmptyRadioButtonLists(Control container)
        {
            List<RadioButtonList> emptyRadioButtonLists = new List<RadioButtonList>();

            foreach (Control control in container.Controls)
            {
                if (control is RadioButtonList radioButtonList)
                {
                    if (string.IsNullOrWhiteSpace(radioButtonList.SelectedValue) || radioButtonList.SelectedIndex == -1)
                    {
                        emptyRadioButtonLists.Add(radioButtonList);

                        radioButtonList.BorderColor = System.Drawing.Color.Red;
                        radioButtonList.BorderWidth = Unit.Pixel(2);
                        radioButtonList.BorderStyle = BorderStyle.Solid;
                    }
                    else
                    {
                        radioButtonList.BorderColor = System.Drawing.Color.Empty;
                        radioButtonList.BorderWidth = Unit.Empty;
                        radioButtonList.BorderStyle = BorderStyle.NotSet;
                    }
                }

                if (control.HasControls())
                {
                    emptyRadioButtonLists.AddRange(FindEmptyRadioButtonLists(control));
                }
            }

            return emptyRadioButtonLists;
        }



        public string Validations()
        {
            try
            {
                int slno = 1;
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);
                string errormsg = "";
                if (string.IsNullOrEmpty(txtName.Text.Trim()) || txtName.Text.Trim() == "" || txtName.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name \\n";
                    slno = slno + 1;
                }
                if (ddlCategory.SelectedIndex == -1 || ddlCategory.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Building Category \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFeeAmount.Text) || txtFeeAmount.Text == "" || txtFeeAmount.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter AMOUNT\\n";
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
                if (string.IsNullOrEmpty(txtLandline.Text.Trim()) || txtLandline.Text.Trim() == "" || txtLandline.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSitArea.Text.Trim()) || txtSitArea.Text.Trim() == "" || txtSitArea.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter LandMark\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPincode.Text) || txtPincode.Text == "" || txtPincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter PinCode\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPlotAREA.Text) || txtPlotAREA.Text == "" || txtPlotAREA.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Plot area\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBreadth.Text) || txtBreadth.Text == "" || txtBreadth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Breadth\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuildupArea.Text) || txtBuildupArea.Text == "" || txtBuildupArea.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter BuildUpArea\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExisting.Text) || txtExisting.Text == "" || txtExisting.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing Road\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEast.Text) || txtEast.Text == "" || txtEast.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter East\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNorth.Text) || txtNorth.Text == "" || txtNorth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter North\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSouth.Text) || txtSouth.Text == "" || txtSouth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter South\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWest.Text) || txtWest.Text == "" || txtWest.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter West\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDistEast.Text) || txtDistEast.Text == "" || txtDistEast.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Distric East\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDistNorth.Text) || txtDistNorth.Text == "" || txtDistNorth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Distric North\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDistSouth.Text) || txtDistSouth.Text == "" || txtDistSouth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Distric South\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDistWest.Text) || txtDistWest.Text == "" || txtDistWest.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter DistricWest\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFire.Text) || txtFire.Text == "" || txtFire.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter FireStation\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypFireLayout.Text) || hypFireLayout.Text == "" || hypFireLayout.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Fire Layout Plan \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypFireCertificate.Text) || hypFireCertificate.Text == "" || hypFireCertificate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Fire Safety Certificate  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypBuildingplan.Text) || hypBuildingplan.Text == "" || hypBuildingplan.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Building plan  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypElectricalinstall.Text) || hypElectricalinstall.Text == "" || hypElectricalinstall.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Certificate from the authorized /competent authority certifying that all the Electrical Installations  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypFireSaftey.Text) || hypFireSaftey.Text == "" || hypFireSaftey.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Declaration with Undertaking that all Fire Safety Measures implemented and installed  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypPreconNOC.Text) || hypPreconNOC.Text == "" || hypPreconNOC.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Pre Construction NOC  \\n";
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

        protected void BindDistricts()
        {

            try
            {

                ddlDistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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

                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlMandal.Items.Clear();
                AddSelect(ddlMandal);
                ddlVillage.ClearSelection();
                ddlVillage.Items.Clear();
                AddSelect(ddlVillage);
                if (ddlDistrict.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistrict.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillage.ClearSelection();
                ddlVillage.Items.Clear();
                AddSelect(ddlVillage);
                if (ddlMandal.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlVillage, ddlMandal.SelectedValue);
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
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFO/CFOBusinessLicenseDetails.aspx?next=N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            // Response.Redirect("~/User/CFO/CFOBusinessLicenseDetails.aspx?next=N");
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFO/CFOProffessionalTax.aspx?Previous=P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            //  Response.Redirect("~/User/CFO/CFOProffessionalTax.aspx?Previous=P");
        }

        protected void btnFireLayout_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupFireLayout.HasFile)
                {
                    Error = validations(fupFireLayout);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Fire Layout Plan" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupFireLayout.PostedFile.SaveAs(serverpath + "\\" + fupFireLayout.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "99";
                        objAadhar.FilePath = serverpath + fupFireLayout.PostedFile.FileName;
                        objAadhar.FileName = fupFireLayout.PostedFile.FileName;
                        objAadhar.FileType = fupFireLayout.PostedFile.ContentType;
                        objAadhar.FileDescription = "Fire Layout Plan";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypFireLayout.Text = fupFireLayout.PostedFile.FileName;
                            hypFireLayout.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypFireLayout.Target = "blank";
                            message = "alert('" + "Fire Layout Plan Uploaded successfully" + "')";
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

        protected void btnFireCertificate_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupFireCertificate.HasFile)
                {
                    Error = validations(fupFireCertificate);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Fire Safety Certificate" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupFireCertificate.PostedFile.SaveAs(serverpath + "\\" + fupFireCertificate.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "100";
                        objAadhar.FilePath = serverpath + fupFireCertificate.PostedFile.FileName;
                        objAadhar.FileName = fupFireCertificate.PostedFile.FileName;
                        objAadhar.FileType = fupFireCertificate.PostedFile.ContentType;
                        objAadhar.FileDescription = "Fire Safety Certificate";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypFireCertificate.Text = fupFireCertificate.PostedFile.FileName;
                            hypFireCertificate.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypFireCertificate.Target = "blank";
                            message = "alert('" + "Fire Safety Certificate Uploaded successfully" + "')";
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

        protected void btnBuildingplan_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupBuildingplan.HasFile)
                {
                    Error = validations(fupBuildingplan);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Building plan" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupBuildingplan.PostedFile.SaveAs(serverpath + "\\" + fupBuildingplan.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "101";
                        objAadhar.FilePath = serverpath + fupBuildingplan.PostedFile.FileName;
                        objAadhar.FileName = fupBuildingplan.PostedFile.FileName;
                        objAadhar.FileType = fupBuildingplan.PostedFile.ContentType;
                        objAadhar.FileDescription = "Building plan";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypBuildingplan.Text = fupBuildingplan.PostedFile.FileName;
                            hypBuildingplan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypBuildingplan.Target = "blank";
                            message = "alert('" + "Building plan Uploaded successfully" + "')";
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

        protected void btnElectricalinstall_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupElectricalinstall.HasFile)
                {
                    Error = validations(fupElectricalinstall);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Certificate from the authorized" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupElectricalinstall.PostedFile.SaveAs(serverpath + "\\" + fupElectricalinstall.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "102";
                        objAadhar.FilePath = serverpath + fupElectricalinstall.PostedFile.FileName;
                        objAadhar.FileName = fupElectricalinstall.PostedFile.FileName;
                        objAadhar.FileType = fupElectricalinstall.PostedFile.ContentType;
                        objAadhar.FileDescription = "Certificate from the authorized";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypElectricalinstall.Text = fupElectricalinstall.PostedFile.FileName;
                            hypElectricalinstall.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypElectricalinstall.Target = "blank";
                            message = "alert('" + "Certificate from the authorized Uploaded successfully" + "')";
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

        protected void btnFireSaftey_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupFireSaftey.HasFile)
                {
                    Error = validations(fupFireSaftey);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Fire Safety Measures implemented and installed" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupFireSaftey.PostedFile.SaveAs(serverpath + "\\" + fupFireSaftey.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "103";
                        objAadhar.FilePath = serverpath + fupFireSaftey.PostedFile.FileName;
                        objAadhar.FileName = fupFireSaftey.PostedFile.FileName;
                        objAadhar.FileType = fupFireSaftey.PostedFile.ContentType;
                        objAadhar.FileDescription = "Fire Safety Measures implemented and installed";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypFireSaftey.Text = fupFireSaftey.PostedFile.FileName;
                            hypFireSaftey.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypFireSaftey.Target = "blank";
                            message = "alert('" + "Fire Safety Measures implemented and installed Uploaded successfully" + "')";
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

        protected void btnPreconNOC_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupPreconNOC.HasFile)
                {
                    Error = validations(fupPreconNOC);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Pre Construction NOC" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupPreconNOC.PostedFile.SaveAs(serverpath + "\\" + fupPreconNOC.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "104";
                        objAadhar.FilePath = serverpath + fupPreconNOC.PostedFile.FileName;
                        objAadhar.FileName = fupPreconNOC.PostedFile.FileName;
                        objAadhar.FileType = fupPreconNOC.PostedFile.ContentType;
                        objAadhar.FileDescription = "Pre Construction NOC";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypPreconNOC.Text = fupPreconNOC.PostedFile.FileName;
                            hypPreconNOC.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypPreconNOC.Target = "blank";
                            message = "alert('" + "Pre Construction NOC Uploaded successfully" + "')";
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
                //}
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
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }
        protected void BindBuildingType()
        {

            try
            {
                ddlCategory.Items.Clear();

                List<MasterBuildingType> objDistrictModel = new List<MasterBuildingType>();
                string strmode = string.Empty;
                strmode = "";

                objDistrictModel = mstrBAL.GetBuildingType();
                if (objDistrictModel != null)
                {
                    ddlCategory.DataSource = objDistrictModel;
                    ddlCategory.DataValueField = "BUILDINGTYPE_ID";
                    ddlCategory.DataTextField = "BUILDINGTYPE_NAME";
                    ddlCategory.DataBind();


                }
                else
                {
                    ddlCategory.DataSource = null;
                    ddlCategory.DataBind();


                }
                AddSelect(ddlCategory);


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