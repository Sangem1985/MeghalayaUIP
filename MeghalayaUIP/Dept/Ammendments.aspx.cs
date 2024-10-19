using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept
{
    public partial class Ammendments : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL indstregBAL = new PreRegBAL();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
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
                    if (hdnDeptid.Value == "")
                    {
                        hdnDeptid.Value = ObjUserInfo.Deptid;
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        bindAmmendments();
                    }
                }
                else
                {
                    Response.Redirect("~/DeptLogin.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";              
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlamendmenttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlamendmenttype.SelectedValue != "0")
                {
                    trAmndName.Visible = true;
                    if (ddlamendmenttype.SelectedItem.Text == "Draft")
                    {
                        lblamendentdate.Text = "Draft Regulation Date";
                        lblamendentupload.Text = "Upload Draft Regulation ";
                        ddlAmendment.Visible = false; txtAmendmentName.Visible = true;
                        trusercomments.Visible = false;
                    }
                    else if (ddlamendmenttype.SelectedItem.Text == "Final")
                    {
                        lblamendentdate.Text = "Final Regulation Date";
                        lblamendentupload.Text = "Upload Final Regulation ";
                        txtAmendmentName.Visible = false; ddlAmendment.Visible = true;
                    }
                }
                else
                {
                    txtAmendmentName.Visible = false;
                    ddlAmendment.Visible = false;
                    trAmndName.Visible = false;
                    trusercomments.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void bindAmmendments()
        {
            ddlAmendment.Items.Clear();

            DataSet ds1 = mstrBAL.GetAmmendments(Convert.ToInt32(hdnDeptid.Value));
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                ddlAmendment.DataSource = ds1.Tables[0];
                ddlAmendment.DataTextField = "AMMENDMENT_NAME";
                ddlAmendment.DataValueField = "Ammendment_Id";
                ddlAmendment.DataBind();
            }
            AddSelect(ddlAmendment);
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.CssClass = "errormsg";
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

        protected void ddlAmendment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DataSet ds = new DataSet();
                ds = mstrBAL.GetUserCommentsofAmmendmentsid(Convert.ToInt32(ddlAmendment.SelectedValue));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvComments.DataSource = ds.Tables[0];
                    gvComments.DataBind();
                    trusercomments.Visible = true;
                }
                else
                {
                    trusercomments.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void BtnSave3_Click(object sender, EventArgs e)
        {
            int valid = 0; string Error = "", message = "", result = "";

            if (ddlamendmenttype.SelectedValue == "0")
            {
                Error = Error + "Please Select Regulation Type \\n";

                valid = 1;
            }
            if (txtAmendmentDate.Text == "")
            {
                Error = Error + "Please Enter Regulation Date \\n";
                valid = 1;
            }
            if (txtAmendmentName.Text == "" && ddlamendmenttype.SelectedItem.Text != "Final")
            {
                Error = Error + "Please Enter Regulation \\n";
                lblmsg0.Text = "<font color='red'>Please Enter Regulation </font>" + "<br/>";
                success.Visible = false;
                Failure.Visible = true;
                valid = 1;
            }
            if (!fupRegulation.HasFile)
            {
                Error = Error + "Please upload Regulation Document \\n";

                valid = 1;
            }
            if (fupRegulation.HasFile)
            {
                Error = validations(fupRegulation);
                if (Error != "")
                {
                    valid = 1;
                    message = "alert('" + Error + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            if (valid == 0)
            {

                if (fupRegulation.HasFile)
                {
                    try
                    {
                        string sFileDir = ConfigurationManager.AppSettings["Ammendments"];
                        string serverpath = sFileDir + hdnDeptid.Value + "\\"
                            + ddlamendmenttype.SelectedValue + "\\" + System.DateTime.Now.ToString("ddMMyyyyhhmmss") + "\\";


                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }

                        fupRegulation.PostedFile.SaveAs(serverpath + "\\" + fupRegulation.PostedFile.FileName);

                        AmmendmentVo ammendment = new AmmendmentVo();
                        ammendment.Ammendment = txtAmendmentName.Text;
                        if (ddlamendmenttype.SelectedValue == "Final")
                        {
                            ammendment.Ammendment = ddlAmendment.SelectedItem.Text;
                            ammendment.Ammendment_Id = ddlAmendment.SelectedValue;
                        }
                        ammendment.Ammendment_Date = txtAmendmentDate.Text;
                        ammendment.Ammendment_Path = serverpath + "\\" + fupRegulation.PostedFile.FileName;
                        ammendment.Amm_FileName = fupRegulation.PostedFile.FileName;
                        ammendment.IPAddress = getclientIP();


                        ammendment.Dept_ID = hdnDeptid.Value;
                        ammendment.Created_By = hdnUserID.Value;
                        ammendment.Amm_Type = ddlamendmenttype.SelectedValue;
                        List<Deptcomments> lstformvo = new List<Deptcomments>();
                        lstformvo.Clear();
                        if (ddlamendmenttype.SelectedValue == "Final")
                        {
                            foreach (GridViewRow gvrow in gvComments.Rows)
                            {
                                Deptcomments fromvo = new Deptcomments();
                                int rowIndex = gvrow.RowIndex;

                                fromvo.DeptComments = ((TextBox)gvrow.FindControl("lbldeptcoments")).Text.ToString().Trim().TrimStart();
                                fromvo.id = ((Label)gvrow.FindControl("lblamdid")).Text.ToString();
                                fromvo.Created_By = hdnUserID.Value;
                                if (fromvo.DeptComments != "")
                                {
                                    lstformvo.Add(fromvo);
                                }
                            }
                        }
                        result = mstrBAL.InsertDeptAmmendments(ammendment, lstformvo);

                        if (result != "")
                        {
                            lblmsg.Text = "<font color='green'>Details Successfully Added..!</font>";
                            lblDraftReg.Text = fupRegulation.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            BtnSave3.Enabled = false;
                        }
                    }
                    catch (Exception ex)//in case of an error
                    {
                        lblmsg0.Text = ex.Message;
                        Failure.Visible = true;
                        MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            else
            {
                message = "alert('" + Error + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                //lblerrMsg.Text = "<font color='red'>Upload PDF files only..!</font>";
                //success.Visible = false;
                //Failure.Visible = true;
            }
        }
        public string validations(FileUpload Attachment)
        {
            try
            {
                int slno = 1; string Error = "";
                string filesize = Convert.ToString(ConfigurationManager.AppSettings["FileSize"].ToString());

                if (Attachment.PostedFile.ContentType != "application/pdf")
                {
                    Error = Error + "Please Upload PDF Documents only \\n";
                }
                if (!ValidateFileName(Attachment.PostedFile.FileName))
                {
                    Error = Error + "Document name should not contain symbols like  <, >, %, $, @, &,=, / \\n";
                }
                if (!ValidateFileExtension(Attachment))
                {
                    Error = Error + "Document should not contain double extension (double . ) \\n";
                }
                if (Attachment.PostedFile.ContentLength >= Convert.ToInt32(filesize))
                {
                    Error = Error + "Please Upload file size less than " + Convert.ToInt32(filesize) / 1000000 + "MB \\n";
                }

                return Error;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        protected void BTNcLEAR_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Ammendments.aspx");
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
          
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Dashboard/DeptDashBoard.aspx");
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