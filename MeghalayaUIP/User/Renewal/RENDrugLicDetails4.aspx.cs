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
    public partial class RENDrugLicDetails4 : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string ErrorMsg = "", Questionnaire;
        protected void Page_Load(object sender, EventArgs e)
        {

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
                if (string.IsNullOrEmpty(txtEquipmentmake.Text.Trim())|| string.IsNullOrEmpty(txtMakeEquipment.Text.Trim()))
                {
                    lblmsg0.Text = "Please Enter All Details..!";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("SERIALEQUIPMENT", typeof(string));
                    dt.Columns.Add("MAKEEQUIPMENT", typeof(string));

                    if (ViewState["Equipment"] != null)
                    {
                        dt = (DataTable)ViewState["Equipment"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["SERIALEQUIPMENT"] = txtEquipmentmake.Text.Trim();
                    dr["MAKEEQUIPMENT"] = txtMakeEquipment.Text.Trim();

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
                    dt.Columns.Add("RADIOLOGIST", typeof(string));
                    

                    if (ViewState["SONOLOGIST"] != null)
                    {
                        dt = (DataTable)ViewState["SONOLOGIST"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["RADIOLOGIST"] = txtRadiologist.Text.Trim();                    

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

                    int count = 0, count1=0;
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

                /* if (ddlservice.SelectedIndex == -1)
                 {
                     errormsg = errormsg + slno + ". Please Select Service Apply To \\n";
                     slno = slno + 1;
                 }
                 if (rblLicense.SelectedIndex == -1)
                 {
                     errormsg = errormsg + slno + ". Please specify the purpose of application \\n";
                     slno = slno + 1;
                 }
                 if (rblLicense.SelectedValue == "R")
                 {
                     if (string.IsNullOrEmpty(txtLicNo.Text) || txtLicNo.Text == "" || txtLicNo.Text == null)
                     {
                         errormsg = errormsg + slno + ". Please Enter License Number\\n";
                         slno = slno + 1;
                     }
                     if (string.IsNullOrEmpty(txtExpiryDate.Text) || txtExpiryDate.Text == "" || txtExpiryDate.Text == null)
                     {
                         errormsg = errormsg + slno + ". Please Enter Expiry date of license\\n";
                         slno = slno + 1;
                     }
                     if (rblCancelledLic.SelectedIndex == -1)
                     {
                         errormsg = errormsg + slno + ". Please Select Do you hold any previous cancelled license? \\n";
                         slno = slno + 1;
                     }
                     if (rblCancelledLic.SelectedValue == "Y")
                     {
                         if (string.IsNullOrEmpty(txtSpecifyLicNo.Text) || txtSpecifyLicNo.Text == "" || txtSpecifyLicNo.Text == null)
                         {
                             errormsg = errormsg + slno + ". Please Enter specify license no\\n";
                             slno = slno + 1;
                         }
                     }
                 }*/

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