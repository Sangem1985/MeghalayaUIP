using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class RegisterGrievance : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();
        string Grivance_File_Path = "", Grivance_File_Type = "", Grievnace_FileName = "";
        MGCommonBAL objcommon = new MGCommonBAL();
        MasterBAL mstrBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindDistricts();
                    BindModuleType();
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!!";
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindDistricts()
        {
            try
            {
                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddldist.DataSource = objDistrictModel;
                    ddldist.DataValueField = "DistrictId";
                    ddldist.DataTextField = "DistrictName";
                    ddldist.DataBind();
                }
                else
                {
                    ddldist.DataSource = null;
                    ddldist.DataBind();
                }
                AddSelect(ddldist);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindModuleType()
        {
            try
            {
                ddlModule.Items.Clear();

                List<MasterModule> objConsttype = new List<MasterModule>();

                objConsttype = mstrBAL.GetMasterModules();
                if (objConsttype != null)
                {
                    ddlModule.DataSource = objConsttype;
                    ddlModule.DataValueField = "ModuleID";
                    ddlModule.DataTextField = "ModuleName";
                    ddlModule.DataBind();
                }
                AddSelect(ddlModule);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void BindPreRegDepts()
        {
            try
            {
                List<MasterDepartment> objDepartmentModel = new List<MasterDepartment>();
                objDepartmentModel = mstrBAL.GetDepartment(ddlModule.SelectedValue);
                if (objDepartmentModel != null)
                {
                    ddldept.DataSource = objDepartmentModel;
                    ddldept.DataValueField = "DepartmentId";
                    ddldept.DataTextField = "DepartmentName";
                    ddldept.DataBind();
                    ddldept.Enabled = true;


                }
                else
                {
                    ddldept.DataSource = null;
                    ddldept.DataBind();

                }
                AddSelect(ddldept);
                if (ddlModule.SelectedValue == "7")
                {
                    ddldept.SelectedValue = "104";
                    ddldept.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindDepartment()
        {

            try
            {
                ddldept.Items.Clear();
                List<MasterDepartment> objDepartmentModel = new List<MasterDepartment>();
                objDepartmentModel = mstrBAL.GetDepartment(ddlModule.SelectedValue);
                if (objDepartmentModel != null)
                {
                    ddldept.DataSource = objDepartmentModel;
                    ddldept.DataValueField = "DepartmentId";
                    ddldept.DataTextField = "DepartmentName";
                    ddldept.DataBind();
                    ddldept.Enabled = true;
                }
                else
                {
                    ddldept.DataSource = null;
                    ddldept.DataBind();
                }
                AddSelect(ddldept);
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
                throw ex;
            }
        }
        protected void ddlRegisterAs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRegisterAs.SelectedIndex <= 0)
            {
                LabelHeading.Text = "";
            }
            else if (ddlRegisterAs.SelectedValue == "G")
            {
                LabelHeading.Text = "Grievance Details";
                trData.Visible = true;

            }
            else if (ddlRegisterAs.SelectedValue == "F")
            {
                LabelHeading.Text = "Feedback Details";
                trData.Visible = true;
            }
            else if (ddlRegisterAs.SelectedValue == "Q")
            {
                LabelHeading.Text = "Query Details";
                trData.Visible = true;
            }

        }
        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlModule.SelectedIndex != 0)
                {                  
                    
                 
                    if (ddlModule.SelectedValue != "0")
                    {
                        if (ddlModule.SelectedValue == "1" || ddlModule.SelectedValue == "7")
                        {
                            BindPreRegDepts();                            
                        }
                        if (ddlModule.SelectedValue == "2" || ddlModule.SelectedValue == "3" || ddlModule.SelectedValue == "4" ||
                            ddlModule.SelectedValue == "5" || ddlModule.SelectedValue == "6")
                        {
                            BindDepartment();                            
                        }                                            
                    }
                }
                else
                {                    
                    ddldept.Items.Clear();
                    AddSelect(ddldept);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;

            }
        }
        protected void ddlPreRegUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtindname.Text = ddlPreRegUnits.SelectedItem.Text;
        }

        protected void ddlCFEUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtindname.Text = ddlCFEUnits.SelectedItem.Text;
        }

        protected void ddlCFOUnits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlIncUnits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlRENUnits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    string newPath = "";
                    string sFileDir = ConfigurationManager.AppSettings["GrievanceAttachments"];
                   
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
                                    newPath = System.IO.Path.Combine(sFileDir, System.DateTime.Now.ToString("ddMMyyyy"));
                                    Grivance_File_Path = newPath + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                                    Grivance_File_Type = fileType[i - 1].ToUpper().Trim();
                                    Grievnace_FileName = sFileName;

                                    if (!Directory.Exists(Grivance_File_Path))

                                        System.IO.Directory.CreateDirectory(Grivance_File_Path);
                                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Grivance_File_Path);
                                    int count = dir.GetFiles().Length;
                                    if (count == 0)
                                        FileUpload.PostedFile.SaveAs(Grivance_File_Path + "\\" + Grievnace_FileName);
                                    else
                                    {
                                        if (count == 1)
                                        {
                                            string[] Files = Directory.GetFiles(Grivance_File_Path);

                                            foreach (string file in Files)
                                            {
                                                File.Delete(file);
                                            }
                                            FileUpload.PostedFile.SaveAs(Grivance_File_Path + "\\" + Grievnace_FileName);
                                        }
                                    }

                                }
                                else
                                {
                                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                                    Failure.Visible = true;
                                }

                            }
                            catch (Exception)//in case of an error
                            {
                                DeleteFile(newPath + "\\" + sFileName);
                            }
                        }
                    }
                    int j = 0;
                    string UnitID = "";
                    if (ddlModule.SelectedValue == "1" && ddlPreRegUnits.Items.Count > 0)
                    { UnitID = ddlPreRegUnits.SelectedValue; }
                    else if (ddlModule.SelectedValue == "2" && ddlCFEUnits.Items.Count > 0)
                    { UnitID = ddlCFEUnits.SelectedValue; }
                    else if (ddlModule.SelectedValue == "3" && ddlCFOUnits.Items.Count > 0)
                    { UnitID = ddlCFOUnits.SelectedValue; }
                    else if (ddlModule.SelectedValue == "4" && ddlRENUnits.Items.Count > 0)
                    { UnitID = ddlRENUnits.SelectedValue; }
                    else if (ddlModule.SelectedValue == "5" && ddlIncUnits.Items.Count > 0)
                    { UnitID = ddlIncUnits.SelectedValue; }
                    else UnitID = "";

                    j = objcommon.InsertGrievance(ddlRegisterAs.SelectedValue, ddlModule.SelectedItem.Text, "", UnitID, txtindname.Text, txtApplcantName.Text,
                        ddldist.SelectedValue, txtEmail.Text.Trim(), txtMob.Text.Trim(), ddldept.SelectedValue.ToString(),
                        txtSub.Text.Trim(), txtDesc.Text.Trim(), Grivance_File_Path, Grivance_File_Type, Grievnace_FileName,
                       "", getclientIP());
                    if (j != 0)
                    {
                        lblmsg.Text = "Details Submited Successfully..!";
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
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                throw ex;
            }
        }
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (ddlRegisterAs.SelectedIndex == -1 || ddlRegisterAs.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Register Type \\n";
                    slno = slno + 1;
                }
                if (ddlModule.SelectedIndex == -1 || ddlModule.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Module Type \\n";
                    slno = slno + 1;
                }
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
                if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "" || txtEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Email \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMob.Text) || txtMob.Text == "" || txtMob.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile Number \\n";
                    slno = slno + 1;
                }

                if (ddldist.SelectedIndex == -1 || ddldist.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select District \\n";
                    slno = slno + 1;
                }
                if (ddldept.SelectedIndex == -1 || ddldept.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Department \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSub.Text) || txtSub.Text == "" || txtSub.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Subject  \\n";
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
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ddlRegisterAs.ClearSelection();
                ddlModule.ClearSelection();
                txtApplcantName.Text = "";
                txtindname.Text = "";
                ddldept.SelectedIndex = 0;
                txtEmail.Text = "";
                txtMob.Text = "";
                ddldist.SelectedIndex = 0;
                txtSub.Text = "";
                txtDesc.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                throw ex;
            }
        }
    }
}