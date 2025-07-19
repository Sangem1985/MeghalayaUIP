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
    public partial class SRVCNonEncumbrance : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string UnitID, Questionnaire, ErrorMsg = "", result = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void rblApply_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblApply.SelectedValue=="D")
                {
                    divDistrict.Visible = true;
                    divSubdivision.Visible = false;
                }
                else
                {
                    divDistrict.Visible = false;
                    divSubdivision.Visible = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlDocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDocument.SelectedValue=="4")
                {
                    divother.Visible = true;
                }
                else { divother.Visible = false; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = stepValidations();
                if (ErrorMsg == "")
                {
                    SRVCEncumbrance ObjEncumbrance = new SRVCEncumbrance();

                    ObjEncumbrance.Questionnariid = Convert.ToString(Session["SRVCQID"]);
                    ObjEncumbrance.Createdby = hdnUserID.Value;
                    ObjEncumbrance.IPAddress = getclientIP();

                    ObjEncumbrance.Applyservice = rblApply.SelectedValue;
                    ObjEncumbrance.Depty = ddlService.SelectedValue;
                    ObjEncumbrance.Division = ddlSubDivision.SelectedValue;
                    ObjEncumbrance.Search = txtSearh.Text;
                    ObjEncumbrance.searchfrom = txtSearchFrom.Text;
                    ObjEncumbrance.ApplicantDocument = ddlDocument.SelectedValue;
                    ObjEncumbrance.others = txtOthers.Text;
                    ObjEncumbrance.SearchNecessary = txtnecessaryName.Text;
                    ObjEncumbrance.NatureDocument = txtNatureDoc.Text;
                    ObjEncumbrance.Dated = txtDate.Text;
                    //ObjEncumbrance.Location = txtLocation.Text;
                    //ObjEncumbrance.Direction = txtPincodeEst.Text;
                    //ObjEncumbrance.Description = txtNameManager.Text;
                    //ObjEncumbrance.Distance = txtAddressManager.Text;
                    ObjEncumbrance.AreaIn = ddlAreaIn.SelectedValue;
                    ObjEncumbrance.Area = txtArea.Text;
                   

                    result = objSrvcbal.InsertEncumbranceDetails(ObjEncumbrance);

                    if (result != "")
                    {
                        string message = "alert('" + "Encumbrance Details Saved Successfully" + "')";
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

                if (string.IsNullOrEmpty(txtSearh.Text) || txtSearh.Text.Trim() == "" || txtSearh.Text == null)
                {
                    errormsg += slno + ". Please enter Search is to be made from which year...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtSearchFrom.Text) || txtSearchFrom.Text.Trim() == "" || txtSearchFrom.Text == null)
                {
                    errormsg += slno + ". Please enter Search is to be made to which year...! \\n";
                    slno++;
                }               
                if (string.IsNullOrEmpty(txtnecessaryName.Text) || txtnecessaryName.Text.Trim() == "" || txtnecessaryName.Text == null)
                {
                    errormsg += slno + ". Please enter Search is necessary in whose names...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtNatureDoc.Text) || txtNatureDoc.Text.Trim() == "" || txtNatureDoc.Text == null)
                {
                    errormsg += slno + ". Please enter Nature of the document...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtDate.Text) || txtDate.Text.Trim() == "" || txtDate.Text == null)
                {
                    errormsg += slno + ". Please enter Dated...! \\n";
                    slno++;
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