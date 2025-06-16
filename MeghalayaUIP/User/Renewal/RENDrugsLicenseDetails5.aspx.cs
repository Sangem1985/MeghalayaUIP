using iText.Forms.Form.Element;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Renewal
{
    public partial class RENDrugsLicenseDetails5 : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string ErrorMsg = "", Questionnaire;
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

                    if (Convert.ToString(Session["RENQID"]) != "")
                    {
                        Questionnaire = Convert.ToString(Session["RENQID"]);
                        if (!IsPostBack)
                        {
                            GetAppliedorNot();
                        }
                    }
                    else
                    {
                        string newurl = "~/User/Renewal/RENUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;

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

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENQID"]), "8", "67");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "67")
                    {
                        Binddata();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Renewal/RENSafetySecurityDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RENDrugsLicenseDetails4.aspx?Previous=" + "P");
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objRenbal.GetRenDrugLicDetails(hdnUserID.Value, Questionnaire,67);
                if (ds.Tables[5].Rows.Count > 0 || ds.Tables[6].Rows.Count > 0 || ds.Tables[7].Rows.Count > 0)
                {
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        txtClinical.Text = ds.Tables[5].Rows[0]["RENPC_VALIDCLINICALNO"].ToString();

                        if (ds.Tables[5].Rows[0]["RENPC_GENETICCOUNSELLINGCENTRE"].ToString().Contains("Genetic Counselling Centre"))
                            CHKRegistered.Items[0].Selected = true;
                        if (ds.Tables[5].Rows[0]["RENPC_GENETICCOUNSELLINGCENTRE"].ToString().Contains("Genetic Laboratory"))
                            CHKRegistered.Items[1].Selected = true;
                        if (ds.Tables[5].Rows[0]["RENPC_GENETICCOUNSELLINGCENTRE"].ToString().Contains("Genetic Clinic"))
                            CHKRegistered.Items[2].Selected = true;
                        if (ds.Tables[5].Rows[0]["RENPC_GENETICCOUNSELLINGCENTRE"].ToString().Contains("Ultrasound Clinic"))
                            CHKRegistered.Items[3].Selected = true;
                        if (ds.Tables[5].Rows[0]["RENPC_GENETICCOUNSELLINGCENTRE"].ToString().Contains("Imaging Centre"))
                            CHKRegistered.Items[4].Selected = true;

                        txtFacility.Text = ds.Tables[5].Rows[0]["RENPC_TYPEFACILITYREG"].ToString();



                        rblLicense.SelectedValue = ds.Tables[5].Rows[0]["RENPC_TYPEOFOWNERSHIP"].ToString();

                        if (rblLicense.SelectedValue == "7")
                        {
                            otherownership.Visible = true;
                            txtOwnership.Text = ds.Tables[5].Rows[0]["RENPC_ANYOTHEROWNERSHIP"].ToString();
                        }
                        else
                        {
                            otherownership.Visible = false;
                        }


                        ddlType.SelectedValue = ds.Tables[5].Rows[0]["RENPC_TYPEOFINSTITUTION"].ToString();
                        if (ddlType.SelectedValue == "7")
                        {
                            Starttype.Visible = true;
                            txtanyinstitute.Text = ds.Tables[5].Rows[0]["RENPC_ANYOTHERINSTITUTION"].ToString();
                        }
                        else { Starttype.Visible = false; }

                        txtDescription.Text = ds.Tables[5].Rows[0]["RENPC_DECRIPTION"].ToString();
                        ddlprenatal.SelectedValue = ds.Tables[5].Rows[0]["RENPC_PRENATALDIAGNOSTIC"].ToString();
                        txtFciliites.Text = ds.Tables[5].Rows[0]["RENPC_FACILITIESCOUNSELL"].ToString();
                        rblequipments.SelectedValue = ds.Tables[5].Rows[0]["RENPC_EQUIPMENTSALREADY"].ToString();
                        rblequipments_SelectedIndexChanged(null, EventArgs.Empty);
                        if (rblequipments.SelectedValue == "Y")
                        {
                            if (ds.Tables[6].Rows.Count > 0)
                            {
                                ViewState["Equipment"] = ds.Tables[6];
                                GVEquipment.DataSource = ds.Tables[6];
                                GVEquipment.DataBind();
                                GVEquipment.Visible = true;
                            }
                        }

                    }
                    if (ds.Tables[7].Rows.Count > 0)
                    {
                        ViewState["SONOLOGIST"] = ds.Tables[7];
                        GVRADIO.DataSource = ds.Tables[7];
                        GVRADIO.DataBind();
                        GVRADIO.Visible = true;
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
        protected void rblLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLicense.SelectedValue == "7")
                {
                    otherownership.Visible = true;
                }
                else
                {
                    otherownership.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlType.SelectedValue == "7")
                {
                    Starttype.Visible = true;
                }
                else
                {
                    Starttype.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblequipments_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblequipments.SelectedValue == "Y")
                {
                    divequipment.Visible = true;
                }
                else
                {
                    divequipment.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEquipmentmake.Text.Trim()) || string.IsNullOrEmpty(txtMakeEquipment.Text.Trim()))
                {
                    lblmsg0.Text = "Please Enter All Details..!";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENE_SERIALNO", typeof(string));
                    dt.Columns.Add("RENE_MAKEMODEL", typeof(string));

                    if (ViewState["Equipment"] != null)
                    {
                        dt = (DataTable)ViewState["Equipment"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["RENE_SERIALNO"] = txtEquipmentmake.Text.Trim();
                    dr["RENE_MAKEMODEL"] = txtMakeEquipment.Text.Trim();

                    dt.Rows.Add(dr);
                    GVEquipment.Visible = true;
                    GVEquipment.DataSource = dt;
                    GVEquipment.DataBind();
                    ViewState["Equipment"] = dt;

                    txtEquipmentmake.Text = "";
                    txtMakeEquipment.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnradiologist_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRadiologist.Text.Trim()))
                {
                    lblmsg0.Text = "Please Enter All Details..!";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENR_RADIONAME", typeof(string));


                    if (ViewState["SONOLOGIST"] != null)
                    {
                        dt = (DataTable)ViewState["SONOLOGIST"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["RENR_RADIONAME"] = txtRadiologist.Text.Trim();

                    dt.Rows.Add(dr);
                    GVRADIO.Visible = true;
                    GVRADIO.DataSource = dt;
                    GVRADIO.DataBind();
                    ViewState["SONOLOGIST"] = dt;

                    txtRadiologist.Text = "";
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
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenDrugLicDet ObjRenDrugLic = new RenDrugLicDet();

                    int count = 0, count1 = 0;
                    for (int i = 0; i < GVEquipment.Rows.Count; i++)
                    {
                        ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                        ObjRenDrugLic.IPAddress = getclientIP();
                        ObjRenDrugLic.SERIALNO = GVEquipment.Rows[i].Cells[1].Text;
                        ObjRenDrugLic.MAKEMODEL = GVEquipment.Rows[i].Cells[2].Text;
                        string A = objRenbal.InsertEquipment67(ObjRenDrugLic);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVEquipment.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Drug Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                    for (int i = 0; i < GVRADIO.Rows.Count; i++)
                    {
                        ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                        ObjRenDrugLic.IPAddress = getclientIP();
                        ObjRenDrugLic.RADIOLOGIST = GVRADIO.Rows[i].Cells[1].Text;

                        string A = objRenbal.InsertRENRadiologist(ObjRenDrugLic);
                        if (A != "")
                        { count1 = count + 1; }
                    }


                    ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                    ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                    ObjRenDrugLic.IPAddress = getclientIP();

                    var selectedItems = CHKRegistered.Items.Cast<ListItem>()
                            .Where(li => li.Selected)
                            .Select(li => li.Text);

                    string selectedActivities = string.Join(", ", selectedItems);

                    ObjRenDrugLic.ValidClinicReg = txtClinical.Text;
                    ObjRenDrugLic.geneticcounselling = selectedActivities;
                    ObjRenDrugLic.Typefacility = txtFacility.Text;
                    ObjRenDrugLic.ownership = rblLicense.SelectedValue;
                    ObjRenDrugLic.Institute = ddlType.SelectedValue;
                    ObjRenDrugLic.Description = txtDescription.Text;
                    ObjRenDrugLic.nataldiagnostic = ddlprenatal.SelectedValue;
                    ObjRenDrugLic.Anyownership = txtOwnership.Text;
                    ObjRenDrugLic.AnyInstitute = txtanyinstitute.Text;
                    ObjRenDrugLic.Whetherequipment = rblequipments.SelectedValue;
                    ObjRenDrugLic.Facilitiescounsell = txtFciliites.Text;

                    result = objRenbal.InsertRENPCPNDTAMENDED67(ObjRenDrugLic);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal DrugLicense Details Submitted Successfully";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtClinical.Text) || txtClinical.Text == "" || txtClinical.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Valid clinical establishment registration number\\n";
                    slno = slno + 1;
                }
                if (CHKRegistered.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Type of facility to be registered   \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFacility.Text) || txtFacility.Text == "" || txtFacility.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Type of facility to be registered\\n";
                    slno = slno + 1;
                }
                if (rblLicense.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Type of ownership of Organization \\n";
                    slno = slno + 1;
                }
                if (rblLicense.SelectedValue == "7")
                {
                    if (string.IsNullOrEmpty(txtOwnership.Text) || txtOwnership.Text == "" || txtOwnership.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Any other type of ownership to be stated\\n";
                        slno = slno + 1;
                    }
                }
                if (ddlType.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Type of Institution  \\n";
                    slno = slno + 1;
                }
                if (ddlType.SelectedValue == "7")
                {
                    if (string.IsNullOrEmpty(txtanyinstitute.Text) || txtanyinstitute.Text == "" || txtanyinstitute.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Any other type of institution to be stated\\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtDescription.Text) || txtDescription.Text == "" || txtDescription.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Description\\n";
                    slno = slno + 1;
                }
                if (ddlprenatal.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Specific pre-natal diagnostic procedures  \\n";
                    slno = slno + 1;
                }
                if (rblequipments.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether equipments already available  \\n";
                    slno = slno + 1;
                }
                if (rblequipments.SelectedValue == "Y")
                {
                    if (GVEquipment.Rows.Count <= 0)
                    {
                        errormsg = errormsg + slno + ". Please Enter Equipment available with the make and model of each equipment \\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtFciliites.Text) || txtFciliites.Text == "" || txtFciliites.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Facilities available in the Counselling Centre\\n";
                    slno = slno + 1;
                }
                if (GVRADIO.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of Radiologists/Sonologists \\n";
                    slno = slno + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GVEquipment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVEquipment.Rows.Count > 0)
                {
                    ((DataTable)ViewState["Equipment"]).Rows.RemoveAt(e.RowIndex);
                    this.GVEquipment.DataSource = ((DataTable)ViewState["Equipment"]).DefaultView;
                    this.GVEquipment.DataBind();
                    GVEquipment.Visible = true;
                    GVEquipment.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GVRADIO_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVRADIO.Rows.Count > 0)
                {
                    ((DataTable)ViewState["SONOLOGIST"]).Rows.RemoveAt(e.RowIndex);
                    this.GVRADIO.DataSource = ((DataTable)ViewState["SONOLOGIST"]).DefaultView;
                    this.GVRADIO.DataBind();
                    GVRADIO.Visible = true;
                    GVRADIO.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/Renewal/RENDrugsLicenseDetails4.aspx?Previous=" + "P");
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
                    Response.Redirect("~/User/Renewal/RENSafetySecurityDetails.aspx?Next=" + "N");
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