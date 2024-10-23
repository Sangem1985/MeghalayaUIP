using MeghalayaUIP.BAL.CFEBLL;
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


namespace MeghalayaUIP.User.CFE
{
    public partial class CFEFuelNOC : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
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
                    if (Convert.ToString(Session["CFEUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["CFEUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/CFE/CFEUserDashboard.aspx";
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
                DataSet ds = new DataSet();
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "13", "10");


                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "10")
                        {
                            BindDistricts();
                            Binddata();
                        }
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFEProffessionalTax.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFE/CFEExplosivesNOC.aspx?Previous=" + "P");
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetCFEPETROLEUMDETAILS(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_CFEUNITID"]);
                        rblNOC.SelectedValue = ds.Tables[0].Rows[0]["CFEPD_NOCPETROLPUMP"].ToString();
                        txtNOCreq.Text = ds.Tables[0].Rows[0]["CFEPD_NOCREQ"].ToString();
                        ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["CFEPD_DISTRIC"].ToString();
                        ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["CFEPD_MANDAL"].ToString();
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["CFEPD_VILLAGE"].ToString();
                        rblLocated.SelectedValue = ds.Tables[0].Rows[0]["CFEPD_LOCATEDROAD"].ToString();
                        txtNameEst.Text = ds.Tables[0].Rows[0]["CFEPD_NAMEEST"].ToString();
                        txtLandHoldingNo.Text = ds.Tables[0].Rows[0]["CFEPD_LANDHOLDINGNO"].ToString();
                        rblLand.SelectedValue = ds.Tables[0].Rows[0]["CFEPD_LANDLEASER"].ToString();
                        rblLand_SelectedIndexChanged(null, EventArgs.Empty);
                        txtRegNo.Text = ds.Tables[0].Rows[0]["CFEPD_REGNO"].ToString();
                        txtHoldingNo.Text = ds.Tables[0].Rows[0]["CFEPD_AREALANDHOLDINGNO"].ToString();
                        txtNorth.Text = ds.Tables[0].Rows[0]["CFEPD_NORTH"].ToString();
                        txtEast.Text = ds.Tables[0].Rows[0]["CFEPD_EAST"].ToString();
                        txtsouth.Text = ds.Tables[0].Rows[0]["CFEPD_SOUTH"].ToString();
                        txtwest.Text = ds.Tables[0].Rows[0]["CFEPD_WEST"].ToString();
                        txtFrontage.Text = ds.Tables[0].Rows[0]["CFEPD_FRONTAGE"].ToString();
                        txtDepth.Text = ds.Tables[0].Rows[0]["CFEPD_DEPTH"].ToString();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 43)
                            {
                                hypPCB.Visible = true;
                                hypPCB.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                                hypPCB.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 44)
                            {
                                hypNocFire.Visible = true;
                                hypNocFire.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                                hypNocFire.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 45)
                            {
                                //  hypfireplan.Visible = true;
                                hypNHAI.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                                hypNHAI.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 46)
                            {
                                hypHighway.Visible = true;
                                hypHighway.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                                hypHighway.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 47)
                            {
                                hypIntent.Visible = true;
                                hypIntent.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                                hypIntent.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
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
        protected void rblLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLand.SelectedValue == "Y")
                {
                    RegNo.Visible = true;
                }
                else { RegNo.Visible = false; }
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    CFEPETROLEUM ObjCFEPetroleum = new CFEPETROLEUM();

                    ObjCFEPetroleum.Questionnareid = Convert.ToString(Session["CFEQID"]);
                    ObjCFEPetroleum.CreatedBy = hdnUserID.Value;
                    ObjCFEPetroleum.UnitId = Convert.ToString(Session["CFEUNITID"]);
                    ObjCFEPetroleum.IPAddress = getclientIP();
                    ObjCFEPetroleum.NOCPETROLPUMP = rblNOC.SelectedValue;
                    ObjCFEPetroleum.NOCREQ = txtNOCreq.Text;
                    ObjCFEPetroleum.DISTRIC = ddlDistrict.SelectedValue;
                    ObjCFEPetroleum.MANDAL = ddlMandal.SelectedValue;
                    ObjCFEPetroleum.VILLAGE = ddlVillage.SelectedValue;
                    ObjCFEPetroleum.LOCATEDROAD = rblLocated.SelectedValue;
                    ObjCFEPetroleum.NAMEEST = txtNameEst.Text;
                    ObjCFEPetroleum.LANDHOLDINGNO = txtLandHoldingNo.Text;
                    ObjCFEPetroleum.LANDLEASER = rblLand.SelectedValue;
                    ObjCFEPetroleum.REGNO = txtRegNo.Text;
                    ObjCFEPetroleum.AREALANDHOLDINGNO = txtHoldingNo.Text;
                    ObjCFEPetroleum.NORTH = txtNorth.Text;
                    ObjCFEPetroleum.EAST = txtEast.Text;
                    ObjCFEPetroleum.SOUTH = txtsouth.Text;
                    ObjCFEPetroleum.WEST = txtwest.Text;
                    ObjCFEPetroleum.FRONTAGE = txtFrontage.Text;
                    ObjCFEPetroleum.DEPTH = txtDepth.Text;

                    result = objcfebal.InsertCFEPetrolrumDetails(ObjCFEPetroleum);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Petroleum Details Submitted Successfully";
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
        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (rblNOC.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter NOC Clear Purpose\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNOCreq.Text) || txtNOCreq.Text == "" || txtNOCreq.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter NOC Clear Purpose\\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Distric\\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Mandal\\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Village\\n";
                    slno = slno + 1;
                }
                if (rblLocated.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter NOC Clear Purpose\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNameEst.Text) || txtNameEst.Text == "" || txtNameEst.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of Establishment\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandHoldingNo.Text) || txtLandHoldingNo.Text == "" || txtLandHoldingNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Land Holding Certificate No \\n";
                    slno = slno + 1;
                }
                if (rblLand.SelectedIndex == -1)
                {
                    if (string.IsNullOrEmpty(txtRegNo.Text) || txtRegNo.Text == "" || txtRegNo.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Lease Deed Registration No\\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtHoldingNo.Text) || txtHoldingNo.Text == "" || txtHoldingNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Land Holding Certificate No\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNorth.Text) || txtNorth.Text == "" || txtNorth.Text == null || txtNorth.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtNorth.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter North\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtsouth.Text) || txtsouth.Text == "" || txtsouth.Text == null || txtsouth.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtsouth.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter south\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEast.Text) || txtEast.Text == "" || txtEast.Text == null || txtEast.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtEast.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter east\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtwest.Text) || txtwest.Text == "" || txtwest.Text == null || txtwest.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtwest.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter West\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFrontage.Text) || txtFrontage.Text == "" || txtFrontage.Text == null || txtFrontage.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtFrontage.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Frontage\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDepth.Text) || txtDepth.Text == "" || txtDepth.Text == null || txtDepth.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtDepth.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Depth\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypNHAI.Text) || hypNHAI.Text == "" || hypNHAI.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload NOC from National Highways Authority of India (NHAI) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypHighway.Text) || hypHighway.Text == "" || hypHighway.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload NOC from concerned Executive Engineer (PWD –Roads) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypIntent.Text) || hypIntent.Text == "" || hypIntent.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Letter of Intent \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypPCB.Text) || hypPCB.Text == "" || hypPCB.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload NoC from Meghalaya State Pollution Control Board \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypNocFire.Text) || hypNocFire.Text == "" || hypNocFire.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload NoC from Fire Department \\n";
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
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEExplosivesNOC.aspx?Previous=" + "P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnPCB_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupPCB.HasFile)
                {
                    Error = validations(fupPCB);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "NoC from Meghalaya State PCB" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupPCB.PostedFile.SaveAs(serverpath + "\\" + fupPCB.PostedFile.FileName);

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "43";
                        objManufacture.FilePath = serverpath + fupPCB.PostedFile.FileName;
                        objManufacture.FileName = fupPCB.PostedFile.FileName;
                        objManufacture.FileType = fupPCB.PostedFile.ContentType;
                        objManufacture.FileDescription = "NoC from Meghalaya State Pollution Control Board";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypPCB.Text = fupPCB.PostedFile.FileName;
                            hypPCB.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
                            hypPCB.Target = "blank";
                            message = "alert('" + "NoC from Meghalaya State Pollution Control Board Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnNocFire_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupNocFire.HasFile)
                {
                    Error = validations(fupNocFire);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "NoC from Fire Department" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupNocFire.PostedFile.SaveAs(serverpath + "\\" + fupNocFire.PostedFile.FileName);

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "44";
                        objManufacture.FilePath = serverpath + fupNocFire.PostedFile.FileName;
                        objManufacture.FileName = fupNocFire.PostedFile.FileName;
                        objManufacture.FileType = fupNocFire.PostedFile.ContentType;
                        objManufacture.FileDescription = "NoC from Fire Department";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypNocFire.Text = fupNocFire.PostedFile.FileName;
                            hypNocFire.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
                            hypNocFire.Target = "blank";
                            message = "alert('" + "NoC from Fire Department Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnNHAI_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupNHAI.HasFile)
                {
                    Error = validations(fupNHAI);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "NHAI" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupNHAI.PostedFile.SaveAs(serverpath + "\\" + fupNHAI.PostedFile.FileName);

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "45";
                        objManufacture.FilePath = serverpath + fupNHAI.PostedFile.FileName;
                        objManufacture.FileName = fupNHAI.PostedFile.FileName;
                        objManufacture.FileType = fupNHAI.PostedFile.ContentType;
                        objManufacture.FileDescription = "NOC from National Highways Authority of India (NHAI)";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypNHAI.Text = fupNHAI.PostedFile.FileName;
                            hypNHAI.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
                            hypNHAI.Target = "blank";
                            message = "alert('" + "NOC from National Highways Authority of India (NHAI) Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnHighway_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupHighway.HasFile)
                {
                    Error = validations(fupHighway);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "NOC from concerned Executive Engineer (PWD –Roads)" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupHighway.PostedFile.SaveAs(serverpath + "\\" + fupHighway.PostedFile.FileName);

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "46";
                        objManufacture.FilePath = serverpath + fupHighway.PostedFile.FileName;
                        objManufacture.FileName = fupHighway.PostedFile.FileName;
                        objManufacture.FileType = fupHighway.PostedFile.ContentType;
                        objManufacture.FileDescription = "NOC from concerned Executive Engineer (PWD –Roads)";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypHighway.Text = fupHighway.PostedFile.FileName;
                            hypHighway.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
                            hypHighway.Target = "blank";
                            message = "alert('" + "NOC from concerned Executive Engineer (PWD –Roads) Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnIntent_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupIntent.HasFile)
                {
                    Error = validations(fupIntent);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Letter of Intent" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupIntent.PostedFile.SaveAs(serverpath + "\\" + fupIntent.PostedFile.FileName);

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "47";
                        objManufacture.FilePath = serverpath + fupIntent.PostedFile.FileName;
                        objManufacture.FileName = fupIntent.PostedFile.FileName;
                        objManufacture.FileType = fupIntent.PostedFile.ContentType;
                        objManufacture.FileDescription = "Letter of Intent";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypIntent.Text = fupIntent.PostedFile.FileName;
                            hypIntent.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
                            hypIntent.Target = "blank";
                            message = "alert('" + "Letter of Intent Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                //  }
                return Error;
            }
            catch (Exception ex)
            {
                throw ex;
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFE/CFEProffessionalTax.aspx?Next=" + "N");
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