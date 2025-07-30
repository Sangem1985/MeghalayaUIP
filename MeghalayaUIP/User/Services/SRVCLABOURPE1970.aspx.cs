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
    public partial class SRVCLABOURPE1970 : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string UnitID, Questionnaire, ErrorMsg = "", result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStates();
                BindDistricts();
            }
        }
        protected void BindStates()
        {
            try
            {
                ddlState.Items.Clear();

                List<MasterStates> objStatesModel = new List<MasterStates>();

                objStatesModel = mstrBAL.GetStates();
                if (objStatesModel != null)
                {
                    ddlState.DataSource = objStatesModel;
                    ddlState.DataValueField = "StateId";
                    ddlState.DataTextField = "StateName";
                    ddlState.DataBind();
                }
                else
                {
                    ddlState.DataSource = null;
                    ddlState.DataBind();
                }
                AddSelect(ddlState);
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

                ddlPropLocDist.Items.Clear();
                ddlPropLocTaluka.Items.Clear();
                ddlPropLocVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;

                strmode = "";

                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlPropLocDist.DataSource = objDistrictModel;
                    ddlPropLocDist.DataValueField = "DistrictId";
                    ddlPropLocDist.DataTextField = "DistrictName";
                    ddlPropLocDist.DataBind();

                }
                else
                {
                    ddlPropLocDist.DataSource = null;
                    ddlPropLocDist.DataBind();
                }
                AddSelect(ddlPropLocDist);
                AddSelect(ddlPropLocTaluka);
                AddSelect(ddlPropLocVillage);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlPropLocDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPropLocTaluka.ClearSelection();
                ddlPropLocVillage.ClearSelection();
                if (ddlPropLocDist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlPropLocTaluka, ddlPropLocDist.SelectedValue);
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

        protected void ddlPropLocTaluka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPropLocVillage.ClearSelection();
                if (ddlPropLocTaluka.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlPropLocVillage, ddlPropLocTaluka.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlState.SelectedValue != "23")
                {
                    divOtherState.Visible = true;

                    divMeghaState.Visible = false;

                    ddlPropLocDist.ClearSelection();
                    ddlPropLocTaluka.ClearSelection();
                    ddlPropLocVillage.ClearSelection();
                }
                else if (ddlState.SelectedValue == "23")
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

        protected void Btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = stepValidations();
                if (ErrorMsg == "")
                {
                    Labour1970 objLabour = new Labour1970();

                    objLabour.Questionnariid = Convert.ToString(Session["SRVCQID"]);
                    objLabour.Createdby = hdnUserID.Value;
                    objLabour.IPAddress = getclientIP();
                    objLabour.EmpName = txtEmpName.Text;
                    objLabour.Father = txtEmpfather.Text;
                    objLabour.EmpEMail = txtEmpEmail1.Text;
                    objLabour.EmpMobileNo = txtEmpmobile.Text;
                    objLabour.State = ddlState.SelectedValue;
                    objLabour.DistrictId = ddlPropLocDist.SelectedValue;
                    objLabour.MandalId = ddlPropLocTaluka.SelectedValue;
                    objLabour.VillageId = ddlPropLocVillage.SelectedValue;
                    objLabour.District = txtDistricted.Text;
                    objLabour.Mandal = txtMandaled.Text;
                    objLabour.Village = txtVillagede.Text;
                    objLabour.Locality = txtEmplocality.Text;
                    objLabour.Landmark = txtEmpLandMark.Text;
                    objLabour.Station = txtEmpStation.Text;
                    objLabour.PostOffice = txtEmpPost.Text;
                    objLabour.Pincode = txtEmpPincode.Text;


                    result = objSrvcbal.InsertLabour1970Details(objLabour);
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

                /*  if (rblDateofBirth.SelectedIndex == -1 || rblDateofBirth.SelectedItem.Text == "--Select--")
                  {
                      errormsg = errormsg + slno + ". Please Select Date of Birth or Age..! \\n";
                      slno = slno + 1;
                  }
                  if (string.IsNullOrEmpty(txtDateBirth.Text) || txtDateBirth.Text.Trim() == "")
                  {
                      errormsg += slno + ". Please enter Date of Birth...! \\n";
                      slno++;
                  }
                  if (string.IsNullOrEmpty(txtAges.Text) || txtAges.Text.Trim() == "")
                  {
                      errormsg += slno + ". Please enter Age...! \\n";
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
                          errormsg = errormsg + slno + ". Please Enter District...! \\n";
                          slno = slno + 1;
                      }
                      if (string.IsNullOrEmpty(txtMandaled.Text) || txtMandaled.Text == "" || txtMandaled.Text == null)
                      {
                          errormsg = errormsg + slno + ". Please Enter Mandal...! \\n";
                          slno = slno + 1;
                      }
                      if (string.IsNullOrEmpty(txtVillagede.Text) || txtVillagede.Text == "" || txtVillagede.Text == null)
                      {
                          errormsg = errormsg + slno + ". Please Enter Village...! \\n";
                          slno = slno + 1;
                      }
                  }
                  if (string.IsNullOrEmpty(txtLocal.Text) || txtLocal.Text.Trim() == "" || txtLocal.Text == null)
                  {
                      errormsg += slno + ". Please enter Locality...! \\n";
                      slno++;
                  }
                  if (string.IsNullOrEmpty(txtNearMark.Text) || txtNearMark.Text.Trim() == "" || txtNearMark.Text == null)
                  {
                      errormsg += slno + ". Please enter Land Mark...! \\n";
                      slno++;
                  }
                  if (string.IsNullOrEmpty(txtPin.Text) || txtPin.Text.Trim() == "" || txtPin.Text == null)
                  {
                      errormsg += slno + ". Please enter Pincode...! \\n";
                      slno++;
                  }
                */


                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
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