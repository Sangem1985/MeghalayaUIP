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
    public partial class CFEFuelNOC : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
        string UnitID, ErrorMsg = "";
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
                        BindDistricts();
                        Binddata();
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
                string  result = "";
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
                if (string.IsNullOrEmpty(txtNorth.Text) || txtNorth.Text == "" || txtNorth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter North\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtsouth.Text) || txtsouth.Text == "" || txtsouth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter south\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEast.Text) || txtEast.Text == "" || txtEast.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter east\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtwest.Text) || txtwest.Text == "" || txtwest.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter West\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFrontage.Text) || txtFrontage.Text == "" || txtFrontage.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Frontage\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDepth.Text) || txtDepth.Text == "" || txtDepth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Depth\\n";
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