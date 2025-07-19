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
    public partial class SRVCTourOperatorDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string UnitID, Questionnaire, ErrorMsg = "", result = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = stepValidations();
                if (ErrorMsg == "")
                {
                    SRVCTourism ObjTourismDet = new SRVCTourism();

                    ObjTourismDet.Questionnariid = Convert.ToString(Session["SRVCQID"]);
                    ObjTourismDet.Createdby = hdnUserID.Value;
                    ObjTourismDet.IPAddress = getclientIP();

                    ObjTourismDet.NatureOrganization = txtNature.Text;
                    ObjTourismDet.YearRegComm = txtYearReg.Text;
                    ObjTourismDet.NameDirector = txtNameProprietor.Text;
                    ObjTourismDet.Interestsindicated = txtDetIntrest.Text;
                    //ObjTourismDet.NameEmp = ddlMandal.SelectedValue;
                    //ObjTourismDet.DesignationEmp = ddlVillage.SelectedValue;
                    //ObjTourismDet.QualificationsEmp = txtDistricted.Text;
                    //ObjTourismDet.ExperienceEmp = txtMandaled.Text;
                    ObjTourismDet.SpaceSqft = txtSqft.Text;
                    ObjTourismDet.LocationArea = txtLocationArea.Text;
                    ObjTourismDet.ReceptionArea = txtReception.Text;
                    ObjTourismDet.AccessibilityToilet = txtAccessibility.Text;
                    ObjTourismDet.NameBankers = txtNameBankers.Text;
                    ObjTourismDet.NameAuditors = txtAuditors.Text;
                    ObjTourismDet.indicatemembership = txtIndicate.Text;
                    ObjTourismDet.touristtraffic = txttourist.Text;
                    ObjTourismDet.Clientele = txtClientele.Text;
                    ObjTourismDet.domestictouristtraffic = txtpromote.Text;
                    ObjTourismDet.Numberconferences = txtnoConferences.Text;
                    

                    result = objSrvcbal.InsertTourismDetails(ObjTourismDet);

                    if (result != "")
                    {
                        string message = "alert('" + "Tourism Details Saved Successfully" + "')";
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
        public string stepValidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtNature.Text) || txtNature.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Nature of the Organization...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtYearReg.Text) || txtYearReg.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Year Of Registration/Commencement of Business...! \\n";
                    slno++;
                }            
                if (string.IsNullOrEmpty(txtNameProprietor.Text) || txtNameProprietor.Text.Trim() == "" || txtNameProprietor.Text == null)
                {
                    errormsg += slno + ". Please enter Name of Proprietor/Director/Partner...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtDetIntrest.Text) || txtDetIntrest.Text.Trim() == "" || txtDetIntrest.Text == null)
                {
                    errormsg += slno + ". Please enter Details of their Interests, in other business...! \\n";
                    slno++;
                }



                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}