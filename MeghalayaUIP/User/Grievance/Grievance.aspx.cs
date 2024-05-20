using System;
using System.Collections.Generic;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;


namespace MeghalayaUIP.User.Grievance
{
    public partial class Grievance : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();
        string Grivance_File_Path, Grivance_File_Type, Grievnace_FileName;
        MGCommonBAL objcommon = new MGCommonBAL();
        MasterBAL mstrBAL = new MasterBAL();
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
                    BindDistricts();
                    BindDepartment();
                }
            }

            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                throw ex;
            }
        }
        protected void BindDistricts()
        {

            try
            {
                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
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
                List<MasterDepartment> objDepartmentModel = new List<MasterDepartment>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
                objDepartmentModel = mstrBAL.GetDepartment();
                if (objDepartmentModel != null)
                {
                    ddldept.DataSource = objDepartmentModel;
                    ddldept.DataValueField = "DepartmentId";
                    ddldept.DataTextField = "DepartmentName";
                    ddldept.DataBind();

                }
                else
                {
                    ddldept.DataSource = null;
                    ddldept.DataBind();

                }

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
                trData.Visible = false;
                trgrivenance.Visible = true;

            }
            else if (ddlRegisterAs.SelectedValue == "G")
            {
                //lblHead1.Text = "Grievance Registration";
                //lblHead2.Text = "Grievance";
                LabelHeading.Text = "Grievance Details";
                LabelUnitname.InnerText = "Industry Name";
                trSubject.Visible = true;
                trdepartment.Visible = true;
                trData.Visible = true;
                trgrivenance.Visible = false;

            }
            else if (ddlRegisterAs.SelectedValue == "F")
            {
                //lblHead1.Text = "Feedback";
                //lblHead2.Text = "Feedback";
                LabelHeading.Text = "Feedback Details";
                LabelUnitname.InnerText = "Industry Name";
                trSubject.Visible = true;
                trdepartment.Visible = true;
                trData.Visible = true;
                trgrivenance.Visible = false;
            }
            else if (ddlRegisterAs.SelectedValue == "Q")
            {
                //lblHead1.Text = "Query";
                //lblHead2.Text = "General Query";
                LabelHeading.Text = "Query Details";
                LabelUnitname.InnerText = "Applicant Name";
                trSubject.Visible = false;
                trdepartment.Visible = false;
                trData.Visible = true;
                trgrivenance.Visible = false;
            }
            else
            {
                LabelUnitname.InnerText = "Industry Name";
                trSubject.Visible = true;
                trdepartment.Visible = true;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Grivance_File_Path = "";
                Grivance_File_Type = "";
                Grievnace_FileName = "";
                //////////////
                //int j = Gen.InsGrevience(txtindname.Text.Trim(),ddldept.SelectedValue.ToString(),txtEmail.Text.Trim(),txtMob.Text.Trim(),ddldist.SelectedValue,txtSub.Text.Trim(),txtDesc.Text.Trim(),"", "","", Session["uid"].ToString());
                // Create the subfolder
                string newPath = "";
                string sFileDir = Server.MapPath("~\\Grievance");

                if (FileUpload.HasFile)
                {
                    if ((FileUpload.PostedFile != null) && (FileUpload.PostedFile.ContentLength > 0))
                    {
                        //determine file name
                        string sFileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                        try
                        {

                            string[] fileType = FileUpload.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                            {
                                //Create a new subfolder under the current active folder
                                //newPath = System.IO.Path.Combine(sFileDir, "1000");
                                newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString());
                                //////////////
                                Grivance_File_Path = newPath + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                                Grivance_File_Type = fileType[i - 1].ToUpper().Trim();
                                Grievnace_FileName = sFileName;
                                //////////////

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
                                lblmsg.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                                //success.Visible = false;
                                //Failure.Visible = true;
                            }

                        }
                        catch (Exception)//in case of an error
                        {
                            DeleteFile(newPath + "\\" + sFileName);
                        }
                    }
                }
                int j = 0;
                j = objcommon.InsertGrievance(txtindname.Text.Trim(), ddldist.SelectedValue, txtEmail.Text.Trim(), txtMob.Text.Trim(), ddldept.SelectedValue.ToString(), txtSub.Text.Trim(), txtDesc.Text.Trim(), Grivance_File_Path, Grivance_File_Type, Grievnace_FileName, Session["uid"].ToString(), ddlRegisterAs.SelectedValue, txtuidno.Text.Trim(), null);

                lblmsg.Text = "Submited Successfully..!";
                success.Visible = true;
                Failure.Visible = false;

            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                throw ex;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
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

        protected void txtuidno_TextChanged(object sender, EventArgs e)
        {
            try
            { }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                throw ex;
            }
        }

        public void DeleteFile(string strFileName)
        {//Delete file from the server
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