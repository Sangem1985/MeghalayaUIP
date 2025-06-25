using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFECLUDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
        string Result = "", ErrorMsg = "", UnitID;
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

                    if (!IsPostBack)
                    {
                        BindDistricts();
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
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetCFECLUDETAILS(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEHWD_UNITID"]);
                    if (ds.Tables[0].Rows[0][""].ToString().Contains("Sale Deed"))
                        CHKAuthorized.Items[0].Selected = true;
                    if (ds.Tables[0].Rows[0][""].ToString().Contains("Patta"))
                        CHKAuthorized.Items[1].Selected = true;
                    if (ds.Tables[0].Rows[0][""].ToString().Contains("Land Holding Certificate"))
                        CHKAuthorized.Items[2].Selected = true;

                    ddlDistric.SelectedValue = ds.Tables[0].Rows[0][""].ToString();
                    ddlMandal.Text = ds.Tables[0].Rows[0][""].ToString();
                    ddlVillage.Text = ds.Tables[0].Rows[0][""].ToString();
                    txtLand.Text = ds.Tables[0].Rows[0][""].ToString();
                    ddlownership.SelectedValue = ds.Tables[0].Rows[0][""].ToString();

                    ddlCurrentLand.SelectedValue = ds.Tables[0].Rows[0][""].ToString();

                    if (ddlCurrentLand.SelectedValue=="4")
                    {
                        divOther.Visible = true;
                        txtOther.Text = ds.Tables[0].Rows[0][""].ToString();
                    }

                    ddlLandProposed.SelectedValue = ds.Tables[0].Rows[0][""].ToString();


                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlCurrentLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCurrentLand.SelectedValue == "4")
                {
                    divOther.Visible = true;
                }
                else { divOther.Visible = false; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CHKAuthorized_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                divSaleDeed.Visible = false;
                divPatta.Visible = false;
                divLand.Visible = false;

                foreach (ListItem item in CHKAuthorized.Items)
                {
                    if (item.Selected)
                    {
                        switch (item.Value)
                        {
                            case "1":
                                divSaleDeed.Visible = true;
                                break;
                            case "2":
                                divPatta.Visible = true;
                                break;
                            case "3":
                                divLand.Visible = true;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
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
        protected void BindMandal(DropDownList ddlmndl, string DistrictID)
        {
            try
            {
                List<MasterMandals> objMandal = mstrBAL.GetMandals(DistrictID);

                if (objMandal != null && objMandal.Count > 0)
                {
                    //ddlApplTaluka.Enabled = true;
                    //ddlApplVillage.Enabled = false;

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
                    //ddlApplVillage.Enabled = true ;
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

        protected void ddlDistric_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlMandal.Items.Clear();
                AddSelect(ddlMandal);
                if (ddlDistric.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistric.SelectedValue);
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

                    CFECLU objCFECLU = new CFECLU();

                    var selectedItems = CHKAuthorized.Items.Cast<ListItem>()
                                 .Where(li => li.Selected)
                                 .Select(li => li.Text);

                    string selectedActivities = string.Join(", ", selectedItems);

                    objCFECLU.Questionnariid = Convert.ToString(Session["CFEQID"]);
                    objCFECLU.Createdby = hdnUserID.Value;
                    objCFECLU.UnitId = Convert.ToString(Session["CFEUNITID"]);
                    objCFECLU.IPAddress = getclientIP();
                    objCFECLU.District = ddlDistric.SelectedValue;
                    objCFECLU.Mandal = ddlMandal.SelectedValue;
                    objCFECLU.Village = ddlVillage.SelectedValue;
                    objCFECLU.ExtendLand = txtLand.Text;
                    objCFECLU.TypeOwnership = ddlownership.SelectedValue;
                    objCFECLU.OwnershipProof = selectedActivities;
                    objCFECLU.CurrentLand = ddlCurrentLand.SelectedValue;
                    objCFECLU.LandUse = ddlLandProposed.SelectedValue;
                    objCFECLU.Others = txtOther.Text;

                    Result = objcfebal.InsertCFECLU(objCFECLU);

                    if (Result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = " Change Of Land Use Details Submitted Successfully";
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
                throw ex;
            }
        }
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
              

                if (ddlDistric.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select District \\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLand.Text) || txtLand.Text == "" || txtLand.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Extent of Land \\n";
                    slno = slno + 1;
                }
                if (ddlownership.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Type of Ownership \\n";
                    slno = slno + 1;
                }
                if (CHKAuthorized.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Check Ownership Proof(upload)  \\n";
                    slno = slno + 1;
                }
                if (ddlCurrentLand.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Current Land Use \\n";
                    slno = slno + 1;
                }
                if (ddlCurrentLand.SelectedValue=="4")
                {
                    if (string.IsNullOrEmpty(txtOther.Text) || txtOther.Text == "" || txtOther.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Others \\n";
                        slno = slno + 1;
                    }
                }
                if (ddlLandProposed.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Proposed Land Use \\n";
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