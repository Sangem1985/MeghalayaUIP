using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCForest : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string ErrorMsg = "", result = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objSrvcbal.GetSRVCFORESTDet(hdnUserID.Value, Convert.ToString(Session["SRVCQID"]));

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ddlForest.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCFD_FORESTDIVISION"]);
                        ddlLandType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCFD_TYPELAND"]);
                        txtLandArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCFD_LANDAREA"]);
                        txtNFLPurpose.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCFD_NONFORESTLAND"]);
                        txtLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCFD_ADDRESS"]);

                        ddlDistric.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCFD_DISTRICT"]);
                        ddlDistric_SelectedIndexChanged(null, EventArgs.Empty);

                        ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCFD_MANDAL"]);
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCFD_VILLAGE"]);
                        txtPincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCFD_PINCODE"]);


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
        protected void BindDistricts()
        {
            try
            {

                ddlDistric.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

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

                }
                else
                {
                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();

                }
                AddSelect(ddlDistric);
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    SRVCForestDetails objSRVCForest = new SRVCForestDetails();

                    objSRVCForest.CreatedBy = hdnUserID.Value;
                    objSRVCForest.IPAddress = getclientIP();
                    objSRVCForest.Questionnariid = Convert.ToString(Session[""]);
                    objSRVCForest.ForestDivision = ddlForest.SelectedValue;
                    objSRVCForest.LandType = ddlLandType.SelectedValue;
                    objSRVCForest.LandArea = txtLandArea.Text;
                    objSRVCForest.NonForest = txtNFLPurpose.Text;
                    objSRVCForest.Address = txtLocation.Text;
                    objSRVCForest.District = ddlDistric.SelectedValue;
                    objSRVCForest.Manadal = ddlMandal.SelectedValue;
                    objSRVCForest.Village = ddlVillage.SelectedValue;
                    objSRVCForest.Pincode = txtPincode.Text;



                    result = objSrvcbal.INSSRVCForestDet(objSRVCForest);

                    if (result != "")
                    {
                        string message = "alert('" + "Forest Details Saved Successfully" + "')";
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
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";


                if (ddlForest.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Forest Division...! \\n";
                    slno = slno + 1;
                }
                if (ddlLandType.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Type of Land...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandArea.Text) || txtLandArea.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter 1. Area of Land in Ha...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtNFLPurpose.Text) || txtNFLPurpose.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Purpose Non-Forest land Certificate sought...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtLocation.Text) || txtLocation.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Address...! \\n";
                    slno++;
                }
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
                if (string.IsNullOrEmpty(txtPincode.Text) || txtPincode.Text.Trim() == "" || txtPincode.Text == null)
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
        protected void BindDivisionForest()
        {
            try
            {
                ddlForest.Items.Clear();

                List<MasterForestDivision> objStatesModel = new List<MasterForestDivision>();

                objStatesModel = mstrBAL.GetForestDivision();
                if (objStatesModel != null)
                {
                    ddlForest.DataSource = objStatesModel;
                    ddlForest.DataValueField = "FORESTDIV_ID";
                    ddlForest.DataTextField = "FORESTDIV_NAME";
                    ddlForest.DataBind();
                }
                else
                {
                    ddlForest.DataSource = null;
                    ddlForest.DataBind();
                }
                AddSelect(ddlForest);
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