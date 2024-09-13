using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
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
                    // username = ObjUserInfo.UserName;

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
                        // BindData();
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
                throw ex;
            }
        }

        protected void ddlamendmenttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlamendmenttype.SelectedItem.Text == "Draft")
                {
                    lblammentname.Text = "Draft Regulation";
                    lblamendentdate.Text = "Draft Regulation Date";
                    lblamendentupload.Text = "Draft Regulation Upload";
                    tramendentype.Visible = false;
                    tramentext.Visible = true;
                }
                else if (ddlamendmenttype.SelectedItem.Text == "Final")
                {
                    tramendenname.Visible = true;
                    tramentext.Visible = false;                  
                    lblamendentdate.Text = "Final Regulation Date";
                    lblamendentupload.Text = "Final Regulation Upload";
                   

                    ddlAmendment.Items.Clear();
                  
                    DataSet ds1 = indstregBAL.GetAmmendments(9);
                    if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                    {
                        ddlAmendment.DataSource = ds1.Tables[0];
                        ddlAmendment.DataTextField = "AMMENDMENT";
                        ddlAmendment.DataValueField = "AMMENDMENT_ID";
                        ddlAmendment.DataBind();
                    }
                    AddSelect(ddlAmendment);
                }
            }
            catch (Exception ex)
            {
                lblerrMsg.Text = ex.Message;
            }
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
                ds = indstregBAL.GetUserCommentsofAmmendmentsid(Convert.ToInt32(ddlAmendment.SelectedValue));
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
                lblerrMsg.Text = ex.Message;
                lblerrMsg.Visible = true;
            }
        }

        protected void BtnSave3_Click(object sender, EventArgs e)
        {
            int valid = 0;
            if (txtAmendmentName.Text == "" && ddlamendmenttype.SelectedItem.Text != "Final")
            {
                lblerrMsg.Text = "<font color='red'>Please Enter Regulation </font>" + "<br/>";              
                success.Visible = false;
                Failure.Visible = true;
                valid = 1;
            }
            if (txtAmendmentDate.Text == "")
            {
                lblerrMsg.Text += "<font color='red'>Please Enter Regulation Date </font>";               
                success.Visible = false;
                Failure.Visible = true;
                valid = 1;
            }
            if (ddlamendmenttype.SelectedValue == "0")
            {
                lblerrMsg.Text += "<font color='red'>Please Select Regulation Type </font>";               
                success.Visible = false;
                Failure.Visible = true;
                valid = 1;
            }
            if (valid == 0)
            {
                string newPath = "";

                string sFileDir = Server.MapPath("~\\Attachments");

               // General t1 = new General();
                if (FileUpload1.HasFile)
                {
                    if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                    {

                        string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                        try
                        {

                            string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            if (fileType[i - 1].ToUpper().Trim() == "PDF")
                            //if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                            {
                                string serverpath = Server.MapPath("~/Attachments/AMENDMENTS/");
                                if (!Directory.Exists(serverpath))
                                    Directory.CreateDirectory(serverpath);

                                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Attachments/AMENDMENTS/") + sFileName);
                                string CrtdUser = hdnUserID.Value; 

                                int result = 0;
                                AmmendmentVo ammendment = new AmmendmentVo();
                                ammendment.Ammendment = txtAmendmentName.Text;
                                if (ddlamendmenttype.SelectedValue == "2")
                                {
                                    ammendment.Ammendment = ddlAmendment.SelectedItem.Text;
                                    ammendment.Ammendment_Id = ddlAmendment.SelectedValue;
                                }
                                ammendment.Ammendment_Date = txtAmendmentDate.Text;
                                ammendment.Ammendment_Path = serverpath;
                                ammendment.Amm_FileName = sFileName;
                                ammendment.IPAddress= getclientIP();

                                                            
                                ammendment.Dept_ID = hdnDeptid.Value;
                                ammendment.Created_By = hdnUserID.Value; 
                                ammendment.Amm_Type = ddlamendmenttype.SelectedValue;
                                List<Deptcomments> lstformvo = new List<Deptcomments>();
                                lstformvo.Clear();
                                if (ddlamendmenttype.SelectedValue == "2")
                                {
                                    foreach (GridViewRow gvrow in gvComments.Rows)
                                    {
                                        Deptcomments fromvo = new Deptcomments();
                                        int rowIndex = gvrow.RowIndex;

                                        fromvo.DeptComments = ((TextBox)gvrow.FindControl("lbldeptcoments")).Text.ToString().Trim().TrimStart();
                                        fromvo.id = ((Label)gvrow.FindControl("lblamdid")).Text.ToString();
                                        fromvo.Created_By = Session["uid"].ToString();
                                        if (fromvo.DeptComments != "")
                                        {
                                            lstformvo.Add(fromvo);
                                        }
                                    }
                                }
                                indstregBAL.InsertDeptAmmendments(ammendment, lstformvo);
                                                                
                               
                                lblresult.Text = "<font color='green'>Attachment Successfully Added..!</font>";                              
                                Label444.Text = FileUpload1.FileName;
                                                             
                                success.Visible = true;
                                Failure.Visible = false;                               

                            }
                            else
                            {
                                lblerrMsg.Text = "<font color='red'>Upload PDF files only..!</font>";
                              
                                success.Visible = false;
                                Failure.Visible = true;
                                
                            }

                        }
                        catch (Exception)//in case of an error
                        {
                            //lblError.Visible = true;
                            //lblError.Text = "An Error Occured. Please Try Again!";
                            DeleteFile(newPath + "\\" + sFileName);
                            // DeleteFile(sFileDir + sFileName);
                        }
                    }
                }
                else
                {
                    lblerrMsg.Text = "<font color='red'>Please Select a file To Upload..!</font>";                  
                    success.Visible = false;
                    Failure.Visible = true;
                  
                }
            }
        }

        protected void BTNcLEAR_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ammendments.aspx");
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