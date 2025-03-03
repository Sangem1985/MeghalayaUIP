using System;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static AjaxControlToolkit.AsyncFileUpload.Constants;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;

namespace MeghalayaUIP.User.Services
{
    public partial class CDWMDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();

        string UnitID, ErrorMsg = "", result;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string stepValidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtNameLocalAuth.Text) || txtNameLocalAuth.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter the name of the Local Authority. \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtNodalOff.Text) || txtNodalOff.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter the Nodal Officer name. \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtNodalDesgn.Text) || txtNodalDesgn.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter the designation of the Nodal Officer. \\n";
                    slno++;
                }
                if (ddlAuthorization.SelectedItem == null || ddlAuthorization.SelectedIndex == 0)
                {
                    errormsg += slno + ". Please select an authorization option. \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtAvgQuan.Text) || txtAvgQuan.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter the average quantity of waste generated per day. \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtQuanWasteProc.Text) || txtQuanWasteProc.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter the quantity of waste processed per day. \\n";
                    slno++;
                }
                if (rblSiteClearance.SelectedItem == null)
                {
                    errormsg += slno + ". Please select a site clearance option. \\n";
                    slno++;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = stepValidations();
                if (ErrorMsg == "")
                {
                    SRVCCDWMdetails ObjCDWMDet = new SRVCCDWMdetails();

                    ObjCDWMDet.unitid = "116";// Convert.ToString(Session["SRVCUNITID"]);
                    ObjCDWMDet.Questionnareid = "1001"; //Convert.ToString(Session["SRVCQID"]);
                    ObjCDWMDet.createdby = hdnUserID.Value;
                    ObjCDWMDet.createdbyip = getclientIP();
                    ObjCDWMDet.NameLocalAuthority = txtNameLocalAuth.Text;
                    ObjCDWMDet.NameOfNodalOfficer = txtNodalOff.Text.Trim();
                    ObjCDWMDet.DesignationOfNodalOfficer = txtNodalDesgn.Text.Trim();
                    ObjCDWMDet.AuthorizationRequiredFor = ddlAuthorization.SelectedItem.Text;
                    ObjCDWMDet.AvgQuantityHandledPerDay = txtAvgQuan.Text.Trim();
                    ObjCDWMDet.QuantityWasteProcessedPerDay = txtQuanWasteProc.Text.Trim();
                    ObjCDWMDet.SiteClearanceFromAuthority = rblSiteClearance.SelectedValue == "1";

                    //result = ObjCDWMDet.InsertSVRCAttachments(ObjCDWMDet);
                    if (result != "")
                    {
                        string message = "alert('" + "SWMD Details Saved Successfully" + "')";
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

        
    }

  
}