using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
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
    public partial class RENCinemaLicenseDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string UnitID, ErrorMsg = "";
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

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENUNITID"]), Convert.ToString(Session["RENQID"]), "13", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "78")
                    {
                        BindDistricts();
                        Binddata();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Renewal/RENContractRegistationDetails.aspx?Next=" + "N");
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
        protected void BindDistricts()
        {
            try
            {

                ddlDistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlDistrict.DataSource = objDistrictModel;
                    ddlDistrict.DataValueField = "DistrictId";
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataBind();


                }
                else
                {
                    ddlDistrict.DataSource = null;
                    ddlDistrict.DataBind();


                }
                AddSelect(ddlDistrict);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindMandal(DropDownList ddlmndl, string DistrictID)
        {
            try
            {
                List<MasterMandals> objMandal = mstrBAL.GetMandals(DistrictID);

                if (objMandal != null && objMandal.Count > 0)
                {
                    ddlmndl.DataSource = objMandal;
                    ddlmndl.DataValueField = "MandalId";
                    ddlmndl.DataTextField = "MandalName";
                    ddlmndl.DataBind();
                }
                else
                {

                    ddlmndl.DataSource = null;
                    ddlmndl.DataBind();
                }

                AddSelect(ddlmndl);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected void BindVillages(DropDownList ddlvlg, string MandalID)
        {
            try
            {
                List<MasterVillages> objVillage = new List<MasterVillages>();
                string strmode = string.Empty;

                objVillage = mstrBAL.GetVillages(MandalID);

                if (objVillage != null)
                {
                    ddlvlg.DataSource = objVillage;
                    ddlvlg.DataValueField = "VillageId";
                    ddlvlg.DataTextField = "VillageName";
                    ddlvlg.DataBind();
                }
                else
                {
                    ddlvlg.DataSource = null;
                    ddlvlg.DataBind();
                }
                AddSelect(ddlvlg);
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

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                if (ddlDistrict.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistrict.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                //Failure.Visible = true;
                //lblmsg0.Text = ex.Message;
                throw ex;
            }
        }

        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillage.ClearSelection();
                if (ddlMandal.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlVillage, ddlMandal.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
          //  string Quesstionriids = "1001";
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenCinemaLicDetails ObjRenCinemaLicDet = new RenCinemaLicDetails();

                    ObjRenCinemaLicDet.Questionnariid = Convert.ToString(Session["RENQID"]); 
                    ObjRenCinemaLicDet.CreatedBy = hdnUserID.Value;
                    ObjRenCinemaLicDet.UnitId = Convert.ToString(Session["RENUNITID"]);
                    ObjRenCinemaLicDet.IPAddress = getclientIP();

                    ObjRenCinemaLicDet.OLDREGNO = txtOldRegNumber.Text;
                    ObjRenCinemaLicDet.REGDATE = txtRegDate.Text;
                    ObjRenCinemaLicDet.NAMEESTCINEMA = txtEstName.Text;
                    ObjRenCinemaLicDet.NOCISSUEDATE = txtIssuedDate.Text;
                    ObjRenCinemaLicDet.NUMBERSEAT = txtNumberseats.Text;
                    ObjRenCinemaLicDet.CINEMATOGRAPHY = txtCinematography.Text;
                    ObjRenCinemaLicDet.BUSINESSTYPE = rblBusinesstype.SelectedValue;
                    ObjRenCinemaLicDet.NAMEPARTNER = txtProprietorname.Text;
                    ObjRenCinemaLicDet.GSTNO = txtGstinno.Text;
                    ObjRenCinemaLicDet.OWNERSHIP = rblOwned.SelectedValue;
                    ObjRenCinemaLicDet.DISTRIC = ddlDistrict.SelectedValue;
                    ObjRenCinemaLicDet.MANDAL = ddlMandal.SelectedValue;
                    ObjRenCinemaLicDet.VILLAGE = ddlVillage.SelectedValue;
                    ObjRenCinemaLicDet.LOCALITY = txtLocality.Text;
                    ObjRenCinemaLicDet.LANDMARK = txtLandmark.Text;
                    ObjRenCinemaLicDet.Pincode = txtPincode.Text;

                    result = objRenbal.InsertRENCinemaLicDet(ObjRenCinemaLicDet);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Cinema License Details Submitted Successfully";
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
                if (string.IsNullOrEmpty(txtOldRegNumber.Text) || txtOldRegNumber.Text == "" || txtOldRegNumber.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Old Registration Number\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRegDate.Text) || txtRegDate.Text == "" || txtRegDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration Date\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEstName.Text) || txtEstName.Text == "" || txtEstName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name OF Establishment Cinema \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIssuedDate.Text) || txtIssuedDate.Text == "" || txtIssuedDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Issue Date \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNumberseats.Text) || txtNumberseats.Text == "" || txtNumberseats.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Number OF Seat \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCinematography.Text) || txtCinematography.Text == "" || txtCinematography.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter cinematography equipment's \\n";
                    slno = slno + 1;
                }
                if (rblBusinesstype.SelectedIndex == -1 || rblBusinesstype.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Type of Business\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtProprietorname.Text) || txtProprietorname.Text == "" || txtProprietorname.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Proprietor \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtGstinno.Text) || txtGstinno.Text == "" || txtGstinno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter GSTIN number of Business \\n";
                    slno = slno + 1;
                }
                if (rblOwned.SelectedIndex == -1 || rblOwned.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Ownership of Premises\\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedIndex == -1 || ddlDistrict.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric\\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == -1 || ddlMandal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Mandal\\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Village\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text == "" || txtLocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandmark.Text) || txtLandmark.Text == "" || txtLandmark.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Landmark \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPincode.Text) || txtPincode.Text == "" || txtPincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode \\n";
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
                ds = objRenbal.GetRenCinemaLicDetails(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENCD_UNITID"]);
                    txtOldRegNumber.Text = ds.Tables[0].Rows[0]["RENCD_OLDREGNO"].ToString();
                    txtRegDate.Text = ds.Tables[0].Rows[0]["RENCD_REGDATE"].ToString();
                    txtEstName.Text = ds.Tables[0].Rows[0]["RENCD_NAMEESTCINEMA"].ToString();
                    txtIssuedDate.Text = ds.Tables[0].Rows[0]["RENCD_NOCISSUEDATE"].ToString();
                    txtNumberseats.Text = ds.Tables[0].Rows[0]["RENCD_NUMBERSEAT"].ToString();
                    txtCinematography.Text = ds.Tables[0].Rows[0]["RENCD_CINEMATOGRAPHY"].ToString();
                    rblBusinesstype.SelectedValue = ds.Tables[0].Rows[0]["RENCD_BUSINESSTYPE"].ToString();
                    txtProprietorname.Text = ds.Tables[0].Rows[0]["RENCD_NAMEPARTNER"].ToString();
                    txtGstinno.Text = ds.Tables[0].Rows[0]["RENCD_GSTNO"].ToString();
                    rblOwned.SelectedValue = ds.Tables[0].Rows[0]["RENCD_OWNERSHIP"].ToString();
                    ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["RENCD_DISTRIC"].ToString();
                    ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["RENCD_MANDAL"].ToString();
                    ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["RENCD_VILLAGE"].ToString();
                    txtLocality.Text = ds.Tables[0].Rows[0]["RENCD_LOCALITY"].ToString();
                    txtLandmark.Text = ds.Tables[0].Rows[0]["RENCD_LANDMARK"].ToString();
                    txtPincode.Text = ds.Tables[0].Rows[0]["RENCD_PINCODE"].ToString();

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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Renewal/RENCinemaLicenseDetails.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/Renewal/RENBusinessLicenseDetails.aspx?Previous=" + "P");
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