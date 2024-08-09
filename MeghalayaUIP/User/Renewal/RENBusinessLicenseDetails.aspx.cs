using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Renewal
{
    public partial class RENBusinessLicenseDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string UnitID;
        protected void Page_Load(object sender, EventArgs e)
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
                if (Convert.ToString(Session["RENUNITID"]) != "")
                { UnitID = Convert.ToString(Session["RENUNITID"]); }
                else
                {
                    string newurl = "~/User/Renewal/RENUserDashboard.aspx";
                    Response.Redirect(newurl);
                }
                //Session["UNITID"] = "1001";
                //UnitID = Convert.ToString(Session["UNITID"]);

                Page.MaintainScrollPositionOnPostBack = true;
                Failure.Visible = false;
                success.Visible = false;
                if (!IsPostBack)
                {
                    GetAppliedorNot();
                }
            }
        }
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENUNITID"]), Convert.ToString(Session["RENQID"]), "2", "77");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "77")
                    {
                        Binddata();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Renewal/RENCinemaLicenseDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RENBusinessLicenseDetails.aspx?Previous=" + "P");
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
           // string Quesstionriids = "1001";
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenBusinessLicDetails ObjRenBusinessLic = new RenBusinessLicDetails();

                    ObjRenBusinessLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                    ObjRenBusinessLic.CreatedBy = hdnUserID.Value;
                    ObjRenBusinessLic.UnitId = Convert.ToString(Session["RENUNITID"]);
                    ObjRenBusinessLic.IPAddress = getclientIP();

                    ObjRenBusinessLic.LICNO = txtLicNo.Text;
                    ObjRenBusinessLic.LICISSUEDT = txtLicIssue.Text;
                    ObjRenBusinessLic.LICVALID = txtLicValid.Text;
                    ObjRenBusinessLic.NAMEOFBUSINESS = txtNameBusiness.Text;
                    ObjRenBusinessLic.ESTOWNED = rblOwned.SelectedValue;
                    ObjRenBusinessLic.NAMEREPRESENTATIVE = txtIndividualName.Text;
                    ObjRenBusinessLic.MOBILENO = txtMobileNo.Text;
                    ObjRenBusinessLic.EMAILID = txtEmailId.Text;
                    ObjRenBusinessLic.ADDRESS = txtAddress.Text;
                    ObjRenBusinessLic.NATUREBUSINESS = txtNatureBusiness.Text;
                    ObjRenBusinessLic.TYPEOFEST = rblApplication.SelectedValue;

                    result = objRenbal.InsertRENBusinessLicDet(ObjRenBusinessLic);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Business License Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtLicNo.Text) || txtLicNo.Text == "" || txtLicNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Number\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLicIssue.Text) || txtLicIssue.Text == "" || txtLicIssue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License issue Date\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLicValid.Text) || txtLicValid.Text == "" || txtLicValid.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Valid upto\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNameBusiness.Text) || txtNameBusiness.Text == "" || txtNameBusiness.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Shop/Business Establishment\\n";
                    slno = slno + 1;
                }
                if (rblOwned.SelectedIndex == -1 || rblOwned.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Whether Establishment is owned \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIndividualName.Text) || txtIndividualName.Text == "" || txtIndividualName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Individual\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile number\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmailId.Text) || txtEmailId.Text == "" || txtEmailId.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EmailId\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text == "" || txtAddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNatureBusiness.Text) || txtNatureBusiness.Text == "" || txtNatureBusiness.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Nature Business\\n";
                    slno = slno + 1;
                }
                if (rblApplication.SelectedIndex == -1 || rblApplication.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Type of Establishment \\n";
                    slno = slno + 1;
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
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objRenbal.GetRenBusinessLicDet(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENBD_UNITID"]);
                    txtLicNo.Text = ds.Tables[0].Rows[0]["RENBD_LICNUMBER"].ToString();
                    txtLicIssue.Text = ds.Tables[0].Rows[0]["RENBD_LICISSUEDT"].ToString();
                    txtLicValid.Text = ds.Tables[0].Rows[0]["RENBD_LICVALID"].ToString();
                    txtNameBusiness.Text = ds.Tables[0].Rows[0]["RENBD_NAMEOFBUSINESS"].ToString();
                    rblOwned.SelectedValue = ds.Tables[0].Rows[0]["RENBD_ESTOWNED"].ToString();
                    txtIndividualName.Text = ds.Tables[0].Rows[0]["RENBD_NAMEREPRESENTATIVE"].ToString();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["RENBD_MOBILENO"].ToString();
                    txtEmailId.Text = ds.Tables[0].Rows[0]["RENBD_EMAILID"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["RENBD_ADDRESS"].ToString();
                    txtNatureBusiness.Text = ds.Tables[0].Rows[0]["RENBD_NATUREBUSINESS"].ToString();
                    rblApplication.SelectedValue = ds.Tables[0].Rows[0]["RENBD_TYPEOFEST"].ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btndpr_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(ViewState["UnitID"]) != "")
                {
                    string newPath = "";
                    string sFileDir = Server.MapPath("~\\RenewalsAttachments");
                    if (fupDPR.HasFile)
                    {
                        if ((fupDPR.PostedFile != null) && (fupDPR.PostedFile.ContentLength > 0))
                        {
                            string sFileName = System.IO.Path.GetFileName(fupDPR.PostedFile.FileName);
                            try
                            {


                                string[] fileType = fupDPR.PostedFile.FileName.Split('.');
                                int i = fileType.Length;
                                if (fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                                {
                                    newPath = System.IO.Path.Combine(sFileDir, hdnUserID.Value, ViewState["UnitID"].ToString() + "\\DPR");

                                    if (!Directory.Exists(newPath))
                                        System.IO.Directory.CreateDirectory(newPath);

                                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                    int count = dir.GetFiles().Length;
                                    if (count == 0)
                                        fupDPR.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                    else
                                    {
                                        if (count == 1)
                                        {
                                            string[] Files = Directory.GetFiles(newPath);

                                            foreach (string file in Files)
                                            {
                                                File.Delete(file);
                                            }
                                            fupDPR.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                        }
                                    }
                                    RenShopsEstablishment ObjRenShopEst = new RenShopsEstablishment();

                                    ObjRenShopEst.UnitId = ViewState["UnitID"].ToString();
                                    ObjRenShopEst.CreatedBy = hdnUserID.Value;
                                    ObjRenShopEst.FileType = fileType[i - 1].ToUpper().ToString();
                                    ObjRenShopEst.FileName = sFileName.ToString();
                                    ObjRenShopEst.Filepath = newPath.ToString();
                                    ObjRenShopEst.FileDescription = "DPR";
                                    ObjRenShopEst.Deptid = "0";
                                    ObjRenShopEst.ApprovalId = "0";

                                    int result = 0;
                                    result = objRenbal.InsertAttachmentsRenewal(ObjRenShopEst);

                                    if (result > 0)
                                    {
                                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                        lbldpr.Text = fupDPR.FileName;
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
                                    lblmsg0.Text = "<font color='red'>Upload JPG, ZIP files only..!</font>";
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
                throw ex;
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