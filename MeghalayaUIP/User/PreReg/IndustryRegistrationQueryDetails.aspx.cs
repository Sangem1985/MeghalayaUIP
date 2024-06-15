using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;

namespace MeghalayaUIP.User.PreReg
{
    public partial class IndustryRegistrationQueryDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL indstregBAL = new PreRegBAL();
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

                    if (!IsPostBack)
                    {
                        string UnitID = Request.QueryString[0].ToString();
                        string InvesterID = Request.QueryString[1].ToString();
                        //string Dept = Request.QueryString[2].ToString();
                        string QueryID = Request.QueryString[2].ToString();
                        BindData(UnitID,ObjUserInfo.Userid,QueryID);
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public void BindData(string Unitid, string InvesterID, string Queryid)
        {
            try
            {
                DataSet ds = new DataSet();                 
                string Dept = Request.QueryString[2].ToString();
                ds = indstregBAL.GetIndustryRegistrationQueryDetails(Unitid, InvesterID, Queryid);
                if (ds.Tables.Count > 0)
                {
                    lblUnitId.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNITID"]);
                    lblRid.Text = Convert.ToString(ds.Tables[0].Rows[0]["IMAQID"]);
                    lblinsert.Text = Convert.ToString(ds.Tables[0].Rows[0]["INVESTERID"]);
                    lbldept.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYBY"]);
                    lblUnitName.Text = Convert.ToString(ds.Tables[0].Rows[0]["COMPANYNAME"]);
                    lblRmId.Text = Convert.ToString(ds.Tables[0].Rows[0]["PREREGUIDNO"]);
                    lblQueryRaised.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYBY"]);
                    lblQueryRaisedDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYDATE"]);
                    lblQueryDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYRAISEDESC"]);
                    //  txtQueryResponse.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYRESPONSEBY"]);
                    //  btnAttach.Text = Convert.ToString(ds.Tables[0].Rows[0]["RESPONSEBYIP"]);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        protected void btnAttach_Click(object sender, EventArgs e)
        {
            //string newPath = "";

            //if (fupResAttachment.HasFile)
            //{
            //   if ((fupResAttachment.PostedFile != null) && (fupResAttachment.PostedFile.ContentLength > 0))
            //    {
            //        string sFileName = System.IO.Path.GetFileName(fupResAttachment.PostedFile.FileName);
            //        try
            //        {
            //            string[] fileType = fupResAttachment.PostedFile.FileName.Split('.');
            //            int i = fileType.Length;
            //            if (i == 2)
            //            {
            //                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
            //                {
            //                    string serverpath = Server.MapPath("~\\ResponseAttachmentforRawmaterials\\" + lblUnitId.ToString() /*+ "\\" + lblRmId.Value.ToString()*/);  // incentiveid2
            //                    if (!Directory.Exists(serverpath))
            //                        Directory.CreateDirectory(serverpath);

            //                    fupResAttachment.PostedFile.SaveAs(serverpath + "\\" + sFileName);
            //                    string CrtdUser = Session["uid"].ToString();

            //                    string Path = serverpath;
            //                    string FileName = sFileName;
            //                    ViewState["AttachmentName"] = sFileName;
            //                    ViewState["pathAttachment"] = serverpath;

            //                }

            //            }
            //        }
            //        catch(Exception ex)
            //        {
            //            throw ex;
            //        }
            //    }


            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                DataSet ds = new DataSet();

                PreRegDtls PRE = new PreRegDtls();
                if (Convert.ToString(ViewState["UnitID"]) != "")
                { PRE.Unitid = Convert.ToString(ViewState["UnitID"]); }
                PRE.Investerid = hdnUserID.Value;
                PRE.IPAddress = getclientIP();
                PRE.Unitid = lblUnitId.Text;
                PRE.UserName = lblUnitName.Text;
                PRE.QueryResponse = txtQueryResponse.Text;
                //PRE.deptid = lbldept.Text;
                PRE.QuerytoDeptID = lbldept.Text;
                PRE.QuerytoDept = lblQueryDescription.Text;
                PRE.QueryID = lblRid.Text;
                string indus = indstregBAL.UpdateIndRegApplQueryRespose(PRE);

                btnSubmit.Enabled = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Query Replied Successfully!');  window.location.href='IndustryRegistrationUserDashboard.aspx'", true);
                return;
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
        protected void btnUpldAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblUnitId.Text != "")
                {
                    string newPath = "";
                    string sFileDir = Server.MapPath("~\\PreRegAttachments");
                    if (fupAttachment.HasFile)
                    {
                        if ((fupAttachment.PostedFile != null) && (fupAttachment.PostedFile.ContentLength > 0))
                        {
                            string sFileName = System.IO.Path.GetFileName(fupAttachment.PostedFile.FileName);
                            try
                            {

                                string[] fileType = fupAttachment.PostedFile.FileName.Split('.');
                                int i = fileType.Length;
                                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                                {
                                    newPath = System.IO.Path.Combine(sFileDir, hdnUserID.Value, lblUnitId.Text + "\\RESPONSEATTACHMENTS");

                                    if (!Directory.Exists(newPath))
                                        System.IO.Directory.CreateDirectory(newPath);

                                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                    int count = dir.GetFiles().Length;
                                    if (count == 0)
                                        fupAttachment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                    else
                                    {
                                        if (count == 1)
                                        {
                                            string[] Files = Directory.GetFiles(newPath);

                                            foreach (string file in Files)
                                            {
                                                File.Delete(file);
                                            }
                                            fupAttachment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                        }
                                    }
                                    IndustryDetails objattachments = new IndustryDetails();

                                    objattachments.UnitID = lblUnitId.Text;
                                    objattachments.UserID = hdnUserID.Value;
                                    objattachments.FileType = fileType[i - 1].ToUpper().ToString();
                                    objattachments.FileName = sFileName.ToString();
                                    objattachments.Filepath = newPath.ToString();
                                    objattachments.FileDescription = "RESPONSE ATTACHMENT";
                                    objattachments.Deptid = "0";
                                    objattachments.ApprovalId = "0";

                                    int result = 0;
                                    result = indstregBAL.InsertAttachments_PREREG(objattachments);

                                    if (result > 0)
                                    {
                                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                        lbldept.Text = fupAttachment.FileName;
                                        success.Visible = true;
                                        Failure.Visible = false;
                                    }
                                    else
                                    {
                                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                        success.Visible = false;
                                        Failure.Visible = true;
                                    }
                                }
                                else
                                {
                                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                                    success.Visible = false;
                                    Failure.Visible = true;
                                }
                            }
                            catch (Exception)//in case of an error
                            {

                                DeleteFile(newPath + "\\" + sFileName);
                            }
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
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Fill Basic Details";
                    string message = "alert('" + "Please Fill Basic Details First and then Upload DPR " + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
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


    }
}