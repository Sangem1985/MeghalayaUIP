using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCLabour7 : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string UnitID, Questionnaire, ErrorMsg = "", result = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BindStates()
        {
            try
            {
                ddlSates.Items.Clear();

                List<MasterStates> objStatesModel = new List<MasterStates>();

                objStatesModel = mstrBAL.GetStates();
                if (objStatesModel != null)
                {
                    ddlSates.DataSource = objStatesModel;
                    ddlSates.DataValueField = "StateId";
                    ddlSates.DataTextField = "StateName";
                    ddlSates.DataBind();
                }
                else
                {
                    ddlSates.DataSource = null;
                    ddlSates.DataBind();
                }
                AddSelect(ddlSates);
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

                ddlDistric.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                ddlDistrictManager.Items.Clear();
                ddlMandalManager.Items.Clear();
                ddlVillageManager.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
   
                strmode = "";
                
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlDistric.DataSource = objDistrictModel;
                    ddlDistric.DataValueField = "DistrictId";
                    ddlDistric.DataTextField = "DistrictName";
                    ddlDistric.DataBind();

                    ddlDistrictManager.DataSource = objDistrictModel;
                    ddlDistrictManager.DataValueField = "DistrictId";
                    ddlDistrictManager.DataTextField = "DistrictName";
                    ddlDistrictManager.DataBind();

                }
                else
                {
                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();

                    ddlDistrictManager.DataSource = null;
                    ddlDistrictManager.DataBind();

                }
                AddSelect(ddlDistric);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

                AddSelect(ddlDistrictManager);
                AddSelect(ddlMandalManager);
                AddSelect(ddlVillageManager);


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

        protected void ddlSates_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSates.SelectedValue != "23")
                {
                    divOtherState.Visible = true;

                    divMeghaState.Visible = false;

                    ddlDistric.ClearSelection();
                    ddlMandal.ClearSelection();
                    ddlVillage.ClearSelection();
                }
                else if (ddlSates.SelectedValue == "23")
                {
                    divMeghaState.Visible = true;

                    divOtherState.Visible = false;
                    txtDistricted.Text = "";
                    txtMandaled.Text = "";
                    txtVillagede.Text = "";

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlDistric_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                if (ddlDistric.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistric.SelectedValue);
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = stepValidations();
                if (ErrorMsg == "")
                {
                    LabourConstructionwork ObjCDWMDet = new LabourConstructionwork();

                    ObjCDWMDet.Questionnariid = Convert.ToString(Session["SRVCQID"]);
                    ObjCDWMDet.Createdby = hdnUserID.Value;
                    ObjCDWMDet.IPAddress = getclientIP();

                    ObjCDWMDet.FullNamePE = txtFullNameEst.Text;
                    ObjCDWMDet.AddressPE = txtAddressEst.Text;
                    ObjCDWMDet.StatePE = ddlSates.SelectedValue;
                    ObjCDWMDet.DistrictPE= ddlDistric.SelectedValue;
                    ObjCDWMDet.MandalPE= ddlMandal.SelectedValue;
                    ObjCDWMDet.VillagePE= ddlVillage.SelectedValue;
                    ObjCDWMDet.DistPE= txtDistricted.Text;
                    ObjCDWMDet.MandalesPE = txtMandaled.Text;
                    ObjCDWMDet.VillagesPE= txtVillagede.Text;
                    ObjCDWMDet.PostOfficePE= txtPostEst.Text;
                    ObjCDWMDet.PincodePE= txtPincodeEst.Text;
                    ObjCDWMDet.NameManager= txtNameManager.Text;
                    ObjCDWMDet.AddressManager= txtAddressManager.Text;
                    ObjCDWMDet.DistrictManager= ddlDistrictManager.SelectedValue;
                    ObjCDWMDet.MandalManager= ddlMandalManager.SelectedValue;
                    ObjCDWMDet.VillageManager= ddlVillageManager.SelectedValue;
                    ObjCDWMDet.PoliceStationManager= txtPoliceManager.Text;
                    ObjCDWMDet.PostOfficeManager= txtPostOfficeManager.Text;
                    ObjCDWMDet.PincodeManager= txtPincodeManager.Text;
                    ObjCDWMDet.NatureofBuilding= txtNatureConWork.Text;
                    ObjCDWMDet.NoofWorkEmpDay= txtWorkEmpDay.Text;
                    ObjCDWMDet.EstConDate= txtEmpDatework.Text;
                    ObjCDWMDet.EstConworkDate= txtEstConDate.Text;

                    result = objSrvcbal.InsertLabourConWorkDetails(ObjCDWMDet);

                    if (result != "")
                    {
                        string message = "alert('" + "Labour Details Saved Successfully" + "')";
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
        public string stepValidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtFullNameEst.Text) || txtFullNameEst.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter FullName...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtAddressEst.Text) || txtAddressEst.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Address...! \\n";
                    slno++;
                }

                if (ddlSates.SelectedValue == "0" || ddlSates.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select State \\n";
                    slno = slno + 1;
                }
                if (ddlSates.SelectedValue == "23")
                {
                    if (ddlDistric.SelectedIndex == -1 || ddlDistric.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select District \\n";
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
                }
                else if (ddlSates.SelectedValue != "23" && ddlSates.SelectedValue != "0")
                {
                    if (string.IsNullOrEmpty(txtDistricted.Text) || txtDistricted.Text == "" || txtDistricted.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Authorised Representative District...! \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtMandaled.Text) || txtMandaled.Text == "" || txtMandaled.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Authorised Representative Mandal...! \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtVillagede.Text) || txtVillagede.Text == "" || txtVillagede.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Authorised Representative Village...! \\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtPostEst.Text) || txtPostEst.Text.Trim() == "" || txtPostEst.Text == null)
                {
                    errormsg += slno + ". Please enter Post Office...! \\n";
                    slno++;
                }               
                if (string.IsNullOrEmpty(txtPincodeEst.Text) || txtPincodeEst.Text.Trim() == "" || txtPincodeEst.Text == null)
                {
                    errormsg += slno + ". Please enter Pincode...! \\n";
                    slno++;
                }
              
               

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlDistrictManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandalManager.ClearSelection();
                ddlVillageManager.ClearSelection();
                if (ddlDistrictManager.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandalManager, ddlDistrictManager.SelectedValue);
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

        protected void ddlMandalManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillageManager.ClearSelection();
                if (ddlMandalManager.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlVillageManager, ddlMandalManager.SelectedValue);
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
    }
}