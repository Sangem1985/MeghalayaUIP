using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Grievance
{
    public partial class GrievanceDeptProcess : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        MGCommonBAL objcomBal = new MGCommonBAL();
        string Reply_FilePath="", Reply_FileType="", Reply_FileName="";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["DeptUserInfo"] != null)
                {
                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.UserID;
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        if (Request.QueryString.Count > 0)
                        {
                            hdnGrvID.Value = Request.QueryString[0];
                            BindData(ObjUserInfo.Deptid);
                        }
                        else Response.Redirect("~/DeptLogin.aspx");

                    }
                }
                else
                {
                    Response.Redirect("~/DeptLogin.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;               
            }
        }
        public void BindData(string DeptID)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objcomBal.GetDepGrievanceList(DeptID, Request.QueryString[0]);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblindustry.Text= Convert.ToString(ds.Tables[0].Rows[0]["UNITNAME"]);
                    lblEmail.Text= Convert.ToString(ds.Tables[0].Rows[0]["EMAIL"]);
                    lblUID.Text= Convert.ToString(ds.Tables[0].Rows[0]["UID_NO"]);
                    lblName.Text= Convert.ToString(ds.Tables[0].Rows[0]["APPLICANTNAME"]);
                    lblNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["MOBILE"]);
                    lblSubject.Text= Convert.ToString(ds.Tables[0].Rows[0]["SUBJECT"]);
                    lblDate.Text= Convert.ToString(ds.Tables[0].Rows[0]["REGDATE"]);
                    lblDistric.Text= Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
                    lblDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["DESCRIPTION"]);
                    hplAttach.NavigateUrl = Convert.ToString(ds.Tables[0].Rows[0]["GRIEVANCE_FILEPATH"]);
                    hplAttach.Text = Convert.ToString(ds.Tables[0].Rows[0]["GRIEVNACE_FILENAME"]);
                   
                }
                else
                {
                    lblmsg0.Text = "Some Internal Error Occured please try again";
                    Failure.Visible = true;
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try 
            {
                int Result = 0;
                if(ddlProcess.SelectedItem.Text!= "--Select--" && !string.IsNullOrEmpty(txtRemarks.Text) && txtRemarks.Text != "" 
                    && txtRemarks.Text != null)
                {
                    string newPath = "";
                    string sFileDir = Server.MapPath("~\\GrievanceAttachments");
                    if (fupReplyFile.HasFile)
                    {
                        if ((fupReplyFile.PostedFile != null) && (fupReplyFile.PostedFile.ContentLength > 0))
                        {
                            string sFileName = System.IO.Path.GetFileName(fupReplyFile.PostedFile.FileName);
                            try
                            {

                                string[] fileType = fupReplyFile.PostedFile.FileName.Split('.');
                                int i = fileType.Length;
                                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || 
                                    fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" ||
                                    fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || 
                                    fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || 
                                    fileType[i - 1].ToUpper().Trim() == "DWG")
                                {
                                   
                                    newPath = System.IO.Path.Combine(sFileDir, hdnGrvID.Value+hdnUserID.Value);
                                    Reply_FilePath = newPath + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                                    Reply_FileType = fileType[i - 1].ToUpper().Trim();
                                    Reply_FileName = sFileName;
                                    //////////////
                                   // FileNameofrMail = Reply_FilePath + "\\" + Reply_FileType;
                                    if (!Directory.Exists(Reply_FilePath))

                                        System.IO.Directory.CreateDirectory(Reply_FilePath);
                                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Reply_FilePath);
                                    int count = dir.GetFiles().Length;
                                    if (count == 0)
                                        fupReplyFile.PostedFile.SaveAs(Reply_FilePath + "\\" + Reply_FileName);
                                    else
                                    {
                                        if (count == 1)
                                        {
                                            string[] Files = Directory.GetFiles(Reply_FilePath);

                                            foreach (string file in Files)
                                            {
                                                File.Delete(file);
                                            }
                                            fupReplyFile.PostedFile.SaveAs(Reply_FilePath + "\\" + Reply_FileName);
                                        }
                                    }

                                }
                                else
                                {
                                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                                    //success.Visible = false;
                                    Failure.Visible = true;
                                }

                            }
                            catch (Exception)//in case of an error
                            {
                                DeleteFile(newPath + "\\" + sFileName);
                            }
                        }
                    }


                    Result = objcomBal.UpdateGrievanceDeptProcess(ddlProcess.SelectedItem.Text, ddlProcess.SelectedValue, txtRemarks.Text, 
                        Reply_FilePath, Reply_FileType, Reply_FileName, hdnGrvID.Value, hdnUserID.Value,
                        Convert.ToString( ObjUserInfo.Deptid), getclientIP());
                    if (Result != 0)
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
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
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
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Grievance/GrievanceDeptView.aspx");
            }
            catch (Exception ex)
            {

            }
        }
    }
}