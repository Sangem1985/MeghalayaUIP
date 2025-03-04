using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.BAL.SVRCBAL;
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
using System.Xml.Linq;

namespace MeghalayaUIP.User.Services
{
    public partial class EWasteDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
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
                    if (Convert.ToString(Session["SRVCUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["SRVCUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/Services/SRVCUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }


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

                ds = objSrvcbal.GetsrvcapprovalID(hdnUserID.Value, Convert.ToString(Session["SRVCUNITID"]), Convert.ToString(Session["SRVCQID"]), "12", "92");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["SRVCDA_APPROVALID"]) == "92")
                    {
                        BindStates();
                        BindDistricts();
                        BindData();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Services/CDWMDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Services/PDCLDetails.aspx?Previous=" + "P");
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
        private void BindData()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = objSrvcbal.GetEWasteDetails(Convert.ToString(Session["SRVCQID"]), hdnUserID.Value);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                txtNameLocalBody.Text = ds.Tables[0].Rows[0]["EWD_NAME"].ToString();
                                txtDoorNo.Text = ds.Tables[0].Rows[0]["EWD_DOORNO"].ToString();
                                txtLocal.Text = ds.Tables[0].Rows[0]["EWD_LOCALITY"].ToString();
                                ddlstate.SelectedValue = ds.Tables[0].Rows[0]["EWD_STATEID"].ToString();
                                ddlstate_SelectedIndexChanged(null, EventArgs.Empty);

                                if (ddlstate.SelectedItem.Text == "Meghalaya")
                                {
                                    trMeghalaya.Visible = true;
                                    trotherstate.Visible = false;
                                    ddldist.SelectedValue = ds.Tables[0].Rows[0]["EWD_DISTRICTID"].ToString();
                                    ddldist_SelectedIndexChanged(null, EventArgs.Empty);
                                    ddlmand.SelectedValue = ds.Tables[0].Rows[0]["EWD_MANDALID"].ToString();
                                    ddlmand_SelectedIndexChanged(null, EventArgs.Empty);
                                    ddlvilla.SelectedValue = ds.Tables[0].Rows[0]["EWD_VILLAGEID"].ToString();

                                }
                                else
                                {
                                    trotherstate.Visible = true;
                                    trMeghalaya.Visible = false;
                                    txtApplDist.Text = ds.Tables[0].Rows[0]["EWD_DISTRICT"].ToString();
                                    txtApplTaluka.Text = ds.Tables[0].Rows[0]["EWD_MANDAL"].ToString();
                                    txtApplVillage.Text = ds.Tables[0].Rows[0]["EWD_VILLAGE"].ToString();
                                }
                                txtpincode.Text = ds.Tables[0].Rows[0]["EWD_PINCODE"].ToString();
                                txtLANDMARK.Text = ds.Tables[0].Rows[0]["EWD_LANDMARK"].ToString();
                                txtDesignation.Text = ds.Tables[0].Rows[0]["EWD_DESIGNATION"].ToString();
                                txtEmailId.Text = ds.Tables[0].Rows[0]["EWD_EMAILID"].ToString();
                                txtMobileNo.Text = ds.Tables[0].Rows[0]["EWD_MOBILE"].ToString();
                                txtAltMobile.Text = ds.Tables[0].Rows[0]["EWD_ALTMOBILE"].ToString();
                                txtLandlineno.Text = ds.Tables[0].Rows[0]["EWD_LANDLINE"].ToString();

                                string[] selectedAuthValues = ds.Tables[0].Rows[0]["EWD_AUTHORIZATION"].ToString().Split('/');

                                foreach (ListItem item in CHKAuthorization.Items)
                                {
                                    if (selectedAuthValues.Contains(item.Text.Trim()))
                                    {
                                        item.Selected = true;
                                    }
                                }

                                txtEwasteValue.Text = ds.Tables[0].Rows[0]["EWD_EWASTEGENQUANTITY"].ToString();
                                txtQtyRefbd.Text = ds.Tables[0].Rows[0]["EWD_EWASTEREFURBISHED"].ToString();
                                txtQtyRecyl.Text = ds.Tables[0].Rows[0]["EWD_EWASTERECYCLE"].ToString();
                                txtQtyDisp.Text = ds.Tables[0].Rows[0]["EWD_EWASTEDISPOSAL"].ToString();
                            }
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(ds.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 20)
                                    {
                                        hypSitePlan.Visible = true;
                                        hypSitePlan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                        hypSitePlan.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                        txtSitePlan.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                                    }
                                    if (Convert.ToInt32(ds.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 21)
                                    {
                                        hypEstablish.Visible = true;
                                        hypEstablish.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                        hypEstablish.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                        txtEstablish.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                                    }
                                    if (Convert.ToInt32(ds.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 22)
                                    {
                                        hypLand.Visible = true;
                                        hypLand.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                        hypLand.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                        txtLand.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                                    }
                                    if (Convert.ToInt32(ds.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 23)
                                    {
                                        hypProject.Visible = true;
                                        hypProject.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                        hypProject.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                        txtProject.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                                    }
                                    if (Convert.ToInt32(ds.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 24)
                                    {
                                        hypFacilities.Visible = true;
                                        hypFacilities.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                        hypFacilities.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                        txtFacilities.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                                    }
                                    if (Convert.ToInt32(ds.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 25)
                                    {
                                        hypEwaste.Visible = true;
                                        hypEwaste.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                        hypEwaste.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                        txtEwaste.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                                    }
                                    if (Convert.ToInt32(ds.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 26)
                                    {
                                        hypRecyling.Visible = true;
                                        hypRecyling.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                        hypRecyling.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                        txtRecyling.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                                    }
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

        protected void BindStates()
        {
            try
            {
                ddlstate.Items.Clear();

                List<MasterStates> objStatesModel = new List<MasterStates>();

                objStatesModel = mstrBAL.GetStates();
                if (objStatesModel != null)
                {
                    ddlstate.DataSource = objStatesModel;
                    ddlstate.DataValueField = "StateId";
                    ddlstate.DataTextField = "StateName";
                    ddlstate.DataBind();
                }
                else
                {
                    ddlstate.DataSource = null;
                    ddlstate.DataBind();
                }
                AddSelect(ddlstate);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindDistricts()
        {
            try
            {

                ddldist.Items.Clear();
                ddlmand.Items.Clear();
                ddlvilla.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;

                strmode = "";
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {

                    ddldist.DataSource = objDistrictModel;
                    ddldist.DataValueField = "DistrictId";
                    ddldist.DataTextField = "DistrictName";
                    ddldist.DataBind();

                }
                else
                {

                    ddldist.DataSource = null;
                    ddldist.DataBind();

                }

                AddSelect(ddldist);
                AddSelect(ddlmand);
                AddSelect(ddlvilla);


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
                ddlmand.ClearSelection();
                ddlvilla.ClearSelection();
                if (ddldist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlmand, ddldist.SelectedValue);
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
                ddlvilla.ClearSelection();
                if (ddlmand.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlvilla, ddlmand.SelectedValue);
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
                    ServiceEWasteDetails serviceEWasteDetails = new ServiceEWasteDetails();

                    serviceEWasteDetails.SrvcQdId = Convert.ToString(Session["SRVCQID"]);
                    serviceEWasteDetails.CreatedBy = hdnUserID.Value;
                    ///serviceEWasteDetails.UidNo = "SRVC/2025/116";
                    serviceEWasteDetails.UnitId = Convert.ToString(Session["SRVCUNITID"]);
                    serviceEWasteDetails.CreatedByIp = getclientIP();

                    serviceEWasteDetails.Name = txtNameLocalBody.Text;
                    serviceEWasteDetails.DoorNo = txtDoorNo.Text;
                    serviceEWasteDetails.Locality = txtLocal.Text;
                    serviceEWasteDetails.StateId = ddlstate.SelectedValue;
                    serviceEWasteDetails.DistrictId = ddldist.SelectedValue;
                    serviceEWasteDetails.MandalId = ddlmand.SelectedValue;
                    serviceEWasteDetails.VillageId = ddlvilla.SelectedValue;
                    serviceEWasteDetails.District = txtApplDist.Text;
                    serviceEWasteDetails.Mandal = txtApplTaluka.Text;
                    serviceEWasteDetails.Village = txtApplVillage.Text;
                    serviceEWasteDetails.Pincode = txtpincode.Text;
                    serviceEWasteDetails.Landmark = txtLANDMARK.Text;
                    serviceEWasteDetails.Designation = txtDesignation.Text;
                    serviceEWasteDetails.EmailId = txtEmailId.Text;
                    serviceEWasteDetails.Mobile = txtMobileNo.Text;
                    serviceEWasteDetails.AltMobile = txtAltMobile.Text;
                    serviceEWasteDetails.Landline = txtLandlineno.Text;

                    List<string> selectedAuthItems = new List<string>();
                    foreach (ListItem item in CHKAuthorization.Items)
                    {
                        if (item.Selected)
                        {
                            selectedAuthItems.Add(item.Text);
                        }
                    }
                    serviceEWasteDetails.Authorization = string.Join("/", selectedAuthItems);

                    serviceEWasteDetails.EWasteGenQuantity = txtEwasteValue.Text;
                    serviceEWasteDetails.EWasteRefurbished = txtQtyRefbd.Text;
                    serviceEWasteDetails.EWasteRecycle = txtQtyRecyl.Text;
                    serviceEWasteDetails.EWasteDisposal = txtQtyDisp.Text;


                    result = objSrvcbal.InsertEWasteDetails(serviceEWasteDetails);

                    if (result != "")
                    {
                        //Session["RENQID"] = result;
                        //result = "SRVC" + "/" + DateTime.Now.Year.ToString() + "/" + result;
                        //success.Visible = true;
                        lblmsg.Text = "Ewaste Details Submitted Successfully";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }


        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlstate.SelectedItem.Text == "Meghalaya")
                {
                    trMeghalaya.Visible = true;
                    trotherstate.Visible = false;
                }
                else
                {
                    trotherstate.Visible = true;
                    trMeghalaya.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlmand.ClearSelection();
                ddlvilla.ClearSelection();
                if (ddldist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlmand, ddldist.SelectedValue);
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
        protected void ddlmand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlvilla.ClearSelection();
                if (ddlmand.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlvilla, ddlmand.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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

        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtNameLocalBody.Text) || txtNameLocalBody.Text == "" || txtNameLocalBody.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of Local Body \\n";
                    slno = slno + 1;
                }

                /* if (string.IsNullOrEmpty(txtDoorNo.Text) || txtDoorNo.Text == "" || txtDoorNo.Text == null)
                 {
                     errormsg = errormsg + slno + ". Please Enter Door Number \\n";
                     slno = slno + 1;
                 }

                 if (string.IsNullOrEmpty(txtLocal.Text) || txtLocal.Text == "" || txtLocal.Text == null)
                 {
                     errormsg = errormsg + slno + ". Please Enter Locality \\n";
                     slno = slno + 1;
                 }

                 if (ddlstate.SelectedIndex == 0)
                 {
                     errormsg = errormsg + slno + ". Please Select State \\n";
                     slno = slno + 1;
                 }

                 if (ddlstate.SelectedItem.Text == "Meghalaya")
                 {
                     // If state is Meghalaya, validate dropdown fields
                     if (ddldist.SelectedIndex == 0)
                     {
                         errormsg += slno + ". Please Select District \\n";
                         slno++;
                     }
                     if (ddlmand.SelectedIndex == 0)
                     {
                         errormsg += slno + ". Please Select Mandal \\n";
                         slno++;
                     }
                     if (ddlvilla.SelectedIndex == 0)
                     {
                         errormsg += slno + ". Please Select Village \\n";
                         slno++;
                     }
                 }
                 else
                 {
                     // For other states, validate textbox fields
                     if (string.IsNullOrEmpty(txtApplDist.Text))
                     {
                         errormsg += slno + ". Please Enter Application District \\n";
                         slno++;
                     }
                     if (string.IsNullOrEmpty(txtApplTaluka.Text))
                     {
                         errormsg += slno + ". Please Enter Application Taluka \\n";
                         slno++;
                     }
                     if (string.IsNullOrEmpty(txtApplVillage.Text))
                     {
                         errormsg += slno + ". Please Enter Application Village \\n";
                         slno++;
                     }
                 }

                 if (string.IsNullOrEmpty(txtpincode.Text) || txtpincode.Text == "" || txtpincode.Text == null)
                 {
                     errormsg = errormsg + slno + ". Please Enter Pincode \\n";
                     slno = slno + 1;
                 }

                 if (string.IsNullOrEmpty(txtLANDMARK.Text) || txtLANDMARK.Text == "" || txtLANDMARK.Text == null)
                 {
                     errormsg = errormsg + slno + ". Please Enter Landmark \\n";
                     slno = slno + 1;
                 } */

                if (string.IsNullOrEmpty(txtDesignation.Text) || txtDesignation.Text == "" || txtDesignation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Designation \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtEmailId.Text) || txtEmailId.Text == "" || txtEmailId.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Email ID \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile Number \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtAltMobile.Text) || txtAltMobile.Text == "" || txtAltMobile.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Alternative Mobile Number \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtLandlineno.Text) || txtLandlineno.Text == "" || txtLandlineno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Landline Number \\n";
                    slno = slno + 1;
                }

                if (CHKAuthorization.Items.Cast<ListItem>().All(item => !item.Selected))
                {
                    errormsg = errormsg + slno + ". Please Check Authorization \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtEwasteValue.Text) || txtEwasteValue.Text == "" || txtEwasteValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter E-Waste Value \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtQtyRefbd.Text) || txtQtyRefbd.Text == "" || txtQtyRefbd.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Quantity Refurbished \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtQtyRecyl.Text) || txtQtyRecyl.Text == "" || txtQtyRecyl.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Quantity Recycled \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtQtyDisp.Text) || txtQtyDisp.Text == "" || txtQtyDisp.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Quantity Disposed \\n";
                    slno = slno + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
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

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/Services/PDCLDetails.aspx?Previous=" + "P");
        }
        protected void btnSitePlan_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupSitePlan.HasFile)
                {
                    Error = validations(fupSitePlan);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["SRVCQID"]) + "\\" + "Site Plan/Plan Layout" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupSitePlan.PostedFile.SaveAs(serverpath + "\\" + fupSitePlan.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupSitePlan.PostedFile.SaveAs(serverpath + "\\" + fupSitePlan.PostedFile.FileName);
                            }
                        }


                        SRVCAttachments objSiteSelection = new SRVCAttachments();
                        objSiteSelection.UNITID = Convert.ToString(Session["SRVCUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objSiteSelection.Questionnareid = Convert.ToString(Session["SRVCQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSiteSelection.MasterID = "20";
                        objSiteSelection.FilePath = serverpath + fupSitePlan.PostedFile.FileName;
                        objSiteSelection.FileName = fupSitePlan.PostedFile.FileName;
                        objSiteSelection.FileType = fupSitePlan.PostedFile.ContentType;
                        objSiteSelection.FileDescription = "Site Plan/Plan Layout";
                        objSiteSelection.CreatedBy = hdnUserID.Value;
                        objSiteSelection.IPAddress = getclientIP();
                        objSiteSelection.ReferenceNo = txtSitePlan.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSiteSelection);
                        if (result != "")
                        {
                            hypSitePlan.Text = fupSitePlan.PostedFile.FileName;
                            hypSitePlan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupSitePlan.PostedFile.FileName);
                            hypSitePlan.Target = "blank";
                            message = "alert('" + "Site Plan/Plan Layout Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnEstablish_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupEstablish.HasFile)
                {
                    Error = validations(fupEstablish);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["SRVCQID"]) + "\\" + "Consent for Establish/ Operate" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupEstablish.PostedFile.SaveAs(serverpath + "\\" + fupEstablish.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupEstablish.PostedFile.SaveAs(serverpath + "\\" + fupEstablish.PostedFile.FileName);
                            }
                        }


                        SRVCAttachments objSiteSelection = new SRVCAttachments();
                        objSiteSelection.UNITID = Convert.ToString(Session["SRVCUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objSiteSelection.Questionnareid = Convert.ToString(Session["SRVCQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSiteSelection.MasterID = "21";
                        objSiteSelection.FilePath = serverpath + fupEstablish.PostedFile.FileName;
                        objSiteSelection.FileName = fupEstablish.PostedFile.FileName;
                        objSiteSelection.FileType = fupEstablish.PostedFile.ContentType;
                        objSiteSelection.FileDescription = "Consent for Establish/ Operate";
                        objSiteSelection.CreatedBy = hdnUserID.Value;
                        objSiteSelection.IPAddress = getclientIP();
                        objSiteSelection.ReferenceNo = txtEstablish.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSiteSelection);
                        if (result != "")
                        {
                            hypEstablish.Text = fupEstablish.PostedFile.FileName;
                            hypEstablish.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupEstablish.PostedFile.FileName);
                            hypEstablish.Target = "blank";
                            message = "alert('" + "Consent for Establish/ Operate Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnLand_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLand.HasFile)
                {
                    Error = validations(fupLand);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["SRVCQID"]) + "\\" + "Land Documents" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupLand.PostedFile.SaveAs(serverpath + "\\" + fupLand.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupLand.PostedFile.SaveAs(serverpath + "\\" + fupLand.PostedFile.FileName);
                            }
                        }


                        SRVCAttachments objSiteSelection = new SRVCAttachments();
                        objSiteSelection.UNITID = Convert.ToString(Session["SRVCUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objSiteSelection.Questionnareid = Convert.ToString(Session["SRVCQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSiteSelection.MasterID = "22";
                        objSiteSelection.FilePath = serverpath + fupLand.PostedFile.FileName;
                        objSiteSelection.FileName = fupLand.PostedFile.FileName;
                        objSiteSelection.FileType = fupLand.PostedFile.ContentType;
                        objSiteSelection.FileDescription = "Land Documents";
                        objSiteSelection.CreatedBy = hdnUserID.Value;
                        objSiteSelection.IPAddress = getclientIP();
                        objSiteSelection.ReferenceNo = txtLand.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSiteSelection);
                        if (result != "")
                        {
                            hypLand.Text = fupLand.PostedFile.FileName;
                            hypLand.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupLand.PostedFile.FileName);
                            hypLand.Target = "blank";
                            message = "alert('" + "Land Documents Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnProject_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupProject.HasFile)
                {
                    Error = validations(fupProject);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["SRVCQID"]) + "\\" + "Detailed Project Report" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupProject.PostedFile.SaveAs(serverpath + "\\" + fupProject.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupProject.PostedFile.SaveAs(serverpath + "\\" + fupProject.PostedFile.FileName);
                            }
                        }


                        SRVCAttachments objSiteSelection = new SRVCAttachments();
                        objSiteSelection.UNITID = Convert.ToString(Session["SRVCUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objSiteSelection.Questionnareid = Convert.ToString(Session["SRVCQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSiteSelection.MasterID = "23";
                        objSiteSelection.FilePath = serverpath + fupProject.PostedFile.FileName;
                        objSiteSelection.FileName = fupProject.PostedFile.FileName;
                        objSiteSelection.FileType = fupProject.PostedFile.ContentType;
                        objSiteSelection.FileDescription = "Detailed Project Report";
                        objSiteSelection.CreatedBy = hdnUserID.Value;
                        objSiteSelection.IPAddress = getclientIP();
                        objSiteSelection.ReferenceNo = txtProject.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSiteSelection);
                        if (result != "")
                        {
                            hypProject.Text = fupProject.PostedFile.FileName;
                            hypProject.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupProject.PostedFile.FileName);
                            hypProject.Target = "blank";
                            message = "alert('" + "Detailed Project Report Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnFacilities_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupFacilities.HasFile)
                {
                    Error = validations(fupFacilities);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["SRVCQID"]) + "\\" + "Details of Facilities for storage/handling/treatment/refurbishing" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupFacilities.PostedFile.SaveAs(serverpath + "\\" + fupFacilities.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupFacilities.PostedFile.SaveAs(serverpath + "\\" + fupFacilities.PostedFile.FileName);
                            }
                        }


                        SRVCAttachments objSiteSelection = new SRVCAttachments();
                        objSiteSelection.UNITID = Convert.ToString(Session["SRVCUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objSiteSelection.Questionnareid = Convert.ToString(Session["SRVCQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSiteSelection.MasterID = "24";
                        objSiteSelection.FilePath = serverpath + fupFacilities.PostedFile.FileName;
                        objSiteSelection.FileName = fupFacilities.PostedFile.FileName;
                        objSiteSelection.FileType = fupFacilities.PostedFile.ContentType;
                        objSiteSelection.FileDescription = "Details of Facilities for storage/handling/treatment/refurbishing";
                        objSiteSelection.CreatedBy = hdnUserID.Value;
                        objSiteSelection.IPAddress = getclientIP();
                        objSiteSelection.ReferenceNo = txtFacilities.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSiteSelection);
                        if (result != "")
                        {
                            hypFacilities.Text = fupFacilities.PostedFile.FileName;
                            hypFacilities.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupFacilities.PostedFile.FileName);
                            hypFacilities.Target = "blank";
                            message = "alert('" + "Details of Facilities for storage/handling/treatment/refurbishing Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnEwaste_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupEwaste.HasFile)
                {
                    Error = validations(fupEwaste);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["SRVCQID"]) + "\\" + "Authorization letter for collection of E-waste from Dismantler or Recycler" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupEwaste.PostedFile.SaveAs(serverpath + "\\" + fupEwaste.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupEwaste.PostedFile.SaveAs(serverpath + "\\" + fupEwaste.PostedFile.FileName);
                            }
                        }


                        SRVCAttachments objSiteSelection = new SRVCAttachments();
                        objSiteSelection.UNITID = Convert.ToString(Session["SRVCUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objSiteSelection.Questionnareid = Convert.ToString(Session["SRVCQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSiteSelection.MasterID = "25";
                        objSiteSelection.FilePath = serverpath + fupEwaste.PostedFile.FileName;
                        objSiteSelection.FileName = fupEwaste.PostedFile.FileName;
                        objSiteSelection.FileType = fupEwaste.PostedFile.ContentType;
                        objSiteSelection.FileDescription = "Authorization letter for collection of E-waste from Dismantler or Recycler";
                        objSiteSelection.CreatedBy = hdnUserID.Value;
                        objSiteSelection.IPAddress = getclientIP();
                        objSiteSelection.ReferenceNo = txtEwaste.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSiteSelection);
                        if (result != "")
                        {
                            hypEwaste.Text = fupEwaste.PostedFile.FileName;
                            hypEwaste.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupEwaste.PostedFile.FileName);
                            hypEwaste.Target = "blank";
                            message = "alert('" + "Authorization letter for collection of E-waste from Dismantler or Recycler (Only applicable to refurbisher) Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnRecyling_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupRecyling.HasFile)
                {
                    Error = validations(fupRecyling);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["SRVCQID"]) + "\\" + "Authorization letter for collection and recycling of E-waste from Recycler" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupRecyling.PostedFile.SaveAs(serverpath + "\\" + fupRecyling.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupRecyling.PostedFile.SaveAs(serverpath + "\\" + fupRecyling.PostedFile.FileName);
                            }
                        }


                        SRVCAttachments objSiteSelection = new SRVCAttachments();
                        objSiteSelection.UNITID = Convert.ToString(Session["SRVCUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objSiteSelection.Questionnareid = Convert.ToString(Session["SRVCQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSiteSelection.MasterID = "26";
                        objSiteSelection.FilePath = serverpath + fupRecyling.PostedFile.FileName;
                        objSiteSelection.FileName = fupRecyling.PostedFile.FileName;
                        objSiteSelection.FileType = fupRecyling.PostedFile.ContentType;
                        objSiteSelection.FileDescription = "Authorization letter for collection and recycling of E-waste from Recycler";
                        objSiteSelection.CreatedBy = hdnUserID.Value;
                        objSiteSelection.IPAddress = getclientIP();
                        objSiteSelection.ReferenceNo = txtRecyling.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSiteSelection);
                        if (result != "")
                        {
                            hypRecyling.Text = fupRecyling.PostedFile.FileName;
                            hypRecyling.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupRecyling.PostedFile.FileName);
                            hypRecyling.Target = "blank";
                            message = "alert('" + "Authorization letter for collection and recycling of E-waste from Recycler (Only applicable to Dismantler) Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string validations(FileUpload Attachment)
        {
            try
            {
                string filesize = Convert.ToString(ConfigurationManager.AppSettings["FileSize"].ToString());
                int slno = 1; string Error = "";

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
            { throw ex; }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                //btnsave_Click(sender, e);
                //if (ErrorMsg == "")
                    Response.Redirect("~/User/Services/CDWMDetails.aspx?Next=" + "N");
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



    }
}