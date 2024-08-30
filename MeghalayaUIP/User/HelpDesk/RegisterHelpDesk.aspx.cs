using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.HelpDesk
{
    public partial class RegisterHelpDesk : System.Web.UI.Page
    {
        MGCommonBAL objcommon = new MGCommonBAL();
        MasterBAL mstrBAL = new MasterBAL();
        string File_Path = "", File_Type = "", FileName = "";
        string ErrorMsg = "";
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
                        hdnusername.Value = ObjUserInfo.Email;
                    }
                    if (!IsPostBack)
                    {
                       // BindDistricts();
                        //BindModuleType();
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!!";
                Failure.Visible = true;
                throw ex;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    string newPath = "";
                    string sFileDir = Server.MapPath("~\\HelpDeskAttachment");
                    if (FileUpload.HasFile)
                    {
                        if ((FileUpload.PostedFile != null) && (FileUpload.PostedFile.ContentLength > 0))
                        {
                            string sFileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                            try
                            {
                                string[] fileType = FileUpload.PostedFile.FileName.Split('.');
                                int i = fileType.Length;
                                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" ||
                                    fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" ||
                                    fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" ||
                                    fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" ||
                                    fileType[i - 1].ToUpper().Trim() == "DWG")
                                {
                                    newPath = System.IO.Path.Combine(sFileDir, hdnUserID.Value);
                                    File_Path = newPath + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                                    File_Type = fileType[i - 1].ToUpper().Trim();
                                    FileName = sFileName;
                                    if (!Directory.Exists(File_Path))

                                        System.IO.Directory.CreateDirectory(File_Path);
                                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(File_Path);
                                    int count = dir.GetFiles().Length;
                                    if (count == 0)
                                        FileUpload.PostedFile.SaveAs(File_Path + "\\" + FileName);
                                    else
                                    {
                                        if (count == 1)
                                        {
                                            string[] Files = Directory.GetFiles(File_Path);

                                            foreach (string file in Files)
                                            {
                                                File.Delete(file);
                                            }
                                            FileUpload.PostedFile.SaveAs(File_Path + "\\" + FileName);
                                        }
                                    }

                                }
                                else
                                {
                                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                                    Failure.Visible = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                DeleteFile(newPath + "\\" + sFileName);
                                throw ex;
                            }
                        }
                    }
                    int j = 0;
                   // string USER = "";

                    j = objcommon.InsertHelpDesk(txtindname.Text, txtApplcantName.Text,
                       txtUIDNO.Text.Trim(), txtMobileNo.Text.Trim(), ddlHelpdesk.SelectedItem.Text,
                       txtEmailid.Text.Trim(), txtDesc.Text.Trim(), File_Path, File_Type, FileName,
                      "USER", hdnusername.Value, hdnUserID.Value, getclientIP());

                    if (j != 0)
                    {
                        lblmsg.Text = "Details Submited Successfully..!";
                        btnsave.Enabled = false;
                        success.Visible = true;
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    }
                    else
                    {
                        lblmsg0.Text = "Error Occured, Please try again!";
                        Failure.Visible = false;
                    }


                }
                else
                {
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }


            }
            catch(Exception ex)
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
              
                if (string.IsNullOrEmpty(txtindname.Text) || txtindname.Text == "" || txtindname.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Industry Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtApplcantName.Text) || txtApplcantName.Text == "" || txtApplcantName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Applicant Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtUIDNO.Text) || txtUIDNO.Text == "" || txtUIDNO.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter UIDNUMBER \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile Number \\n";
                    slno = slno + 1;
                }
                if (ddlHelpdesk.SelectedIndex == -1 || ddlHelpdesk.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select HelpDesk Type \\n";
                    slno = slno + 1;
                }               
                if (string.IsNullOrEmpty(txtEmailid.Text) || txtEmailid.Text == "" || txtEmailid.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EmailId  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDesc.Text) || txtDesc.Text == "" || txtDesc.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Description  \\n";
                    slno = slno + 1;
                }

                return errormsg;

            }
            catch (Exception ex)
            {
                throw ex;
                //lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtindname.Text = "";
                txtApplcantName.Text = "";
                txtUIDNO.Text = "";           
                txtMobileNo.Text = "";
                ddlHelpdesk.SelectedIndex = 0;
                txtEmailid.Text = "";
                txtDesc.Text = "";
            }
            catch(Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;
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
        public void DeleteFile(string strFileName)
        {
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }

    }
}