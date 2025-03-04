using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.SVRCBAL;
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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class BMWDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();

        string Category, ErrorMsg, result, UnitID, Questionnaire;
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
                if (Convert.ToString(Session["SRVCUNITID"]) != "")
                {
                    UnitID = Convert.ToString(Session["SRVCUNITID"]);
                }
                if (Convert.ToString(Session["SRVCQID"]) != "")
                {
                    Questionnaire = Convert.ToString(Session["SRVCQID"]);
                }
                else
                {
                    string newurl = "~/User/Services/SRVCUserDashboard.aspx";
                    Response.Redirect(newurl);
                }

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

                ds = objSrvcbal.GetsrvcapprovalID(hdnUserID.Value, Convert.ToString(Session["SRVCUNITID"]), Convert.ToString(Session["SRVCQID"]), "12", "83");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["SRVCDA_APPROVALID"]) == "83")
                    {
                        BindBMW();
                        BindWasteDetails();
                        BindData();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Services/PDCLDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Services/SWMDetails.aspx?Previous=" + "P");
                    }
                }


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objSrvcbal.GetSrvcBMWDet(hdnUserID.Value, Convert.ToString(Session["SRVCUNITID"]));

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtNameApplicant.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_NAME"]);
                        rblMedical.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["BMW_NAMEHCF_CBWTF"]);
                        txtEmailId.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_EMAILID"]);
                        txtMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_MOBILENO"]);
                        txtweb.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_WEBSITE"]);
                        //CHKAuthorized.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"]);
                        if (ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"].ToString().Contains("Generation"))
                            CHKAuthorized.Items[0].Selected = true;
                        if (ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"].ToString().Contains("segregation"))
                            CHKAuthorized.Items[1].Selected = true;
                        if (ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"].ToString().Contains("Collection"))
                            CHKAuthorized.Items[2].Selected = true;
                        if (ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"].ToString().Contains("Storage"))
                            CHKAuthorized.Items[3].Selected = true;
                        if (ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"].ToString().Contains("Packing"))
                            CHKAuthorized.Items[4].Selected = true;
                        if (ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"].ToString().Contains("Reception"))
                            CHKAuthorized.Items[5].Selected = true;
                        if (ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"].ToString().Contains("Transportation"))
                            CHKAuthorized.Items[6].Selected = true;
                        if (ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"].ToString().Contains("Treatment or processing or conversation"))
                            CHKAuthorized.Items[7].Selected = true;
                        if (ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"].ToString().Contains("Recycling"))
                            CHKAuthorized.Items[8].Selected = true;
                        if (ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"].ToString().Contains("Disposal or destruction"))
                            CHKAuthorized.Items[9].Selected = true;
                        if (ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"].ToString().Contains("Disposal or destruction"))
                            CHKAuthorized.Items[10].Selected = true;
                        if (ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"].ToString().Contains("transfer"))
                            CHKAuthorized.Items[11].Selected = true;
                        if (ds.Tables[0].Rows[0]["BMW_AUTHORIZATION"].ToString().Contains("Any other form of handling"))
                            CHKAuthorized.Items[12].Selected = true;

                        rblauthorisation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["BMW_APPLIEDCTO_CTE"]);
                        txtRenno.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_RENAUTHORIZATIONNO"]);
                        txtAuthorisationDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_RENAUTHORIZATIONDATE"]);
                        txtPCB.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_PCB1974"]);
                        txtPCB1981.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_PCB1981"]);
                        rblHealth.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["BMW_BIOHCF_CBWTF"]);
                        rblGPS.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["BMW_GPSCOORDINATE"]);
                        txtNoHCF.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_NOBEDHCF"]);
                        txtHCFNO.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_NOPATIENTSMONTHHCF"]);
                        txtHealthCBMWFT.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_NOHELTHCBMWTF"]);
                        txtNobedcbmwtf.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_NOBEDCBMWTF"]);
                        txtcapacitytreat.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_CAPACITYCBMWTF"]);
                        txtdistance.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_AREADISTANCECBMWTF"]);
                        txtwastetreat.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_BIOMEDICALDISPOSED"]);
                        txtBiowaste.Text = Convert.ToString(ds.Tables[0].Rows[0]["BMW_MODETRANSPORTATION"]);

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GVWaste.DataSource = ds.Tables[1];
                        GVWaste.DataBind();
                        GVWaste.Visible = true;
                        ViewState["BMWWasteData"] = ds.Tables[1];
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[2];
                        ViewState["BioMedical"] = dt;

                        GVBIOMedical.Visible = true;
                        GVBIOMedical.DataSource = dt;
                        GVBIOMedical.DataBind();
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                        {
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["SRVCA_MASTERID"]) == 10)
                            {
                                hypBiomedicalwaste.Visible = true;
                                hypBiomedicalwaste.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["SRVCA_FILEPATH"]));
                                hypBiomedicalwaste.Text = Convert.ToString(ds.Tables[3].Rows[i]["SRVCA_FILENAME"]);
                                txtCBWTFBIO.Text = Convert.ToString(ds.Tables[3].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["SRVCA_MASTERID"]) == 11)
                            {
                                hyplegalnotice.Visible = true;
                                hyplegalnotice.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["SRVCA_FILEPATH"]));
                                hyplegalnotice.Text = Convert.ToString(ds.Tables[3].Rows[i]["SRVCA_FILENAME"]);
                                txtlegalDet.Text = Convert.ToString(ds.Tables[3].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindWasteDetails()
        {
            try
            {
                ddlcategory.Items.Clear();


                // List<MasterBMWWASTE> objWaste = new List<MasterBMWWASTE>();
                DataSet ds = new DataSet();

                ds = mstrBAL.GetWasteDet(Category);
                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlcategory.DataSource = ds.Tables[0];
                    ddlcategory.DataValueField = "BMW_TYPE";
                    ddlcategory.DataTextField = "BMW_TYPE";
                    ddlcategory.DataBind();

                }
                else
                {
                    ddlcategory.DataSource = null;
                    ddlcategory.DataBind();


                }
                AddSelect(ddlcategory);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindCategory(DropDownList ddlwaste, string Category)
        {
            try
            {
                ddlwaste.Items.Clear();

                DataSet ds = new DataSet();
                ds = mstrBAL.GetWasteDet(Category);
                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlwaste.DataSource = ds.Tables[1];
                    ddlwaste.DataValueField = "BMW_TYPE";
                    ddlwaste.DataTextField = "BMW_NAME";
                    ddlwaste.DataBind();
                }
                else
                {
                    ddlwaste.DataSource = null;
                    ddlwaste.DataBind();
                }
                AddSelect(ddlwaste);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindBMW()
        {
            try
            {
                DataSet dt = new DataSet();

                dt = objSrvcbal.BMWEquipment();

                if (dt != null && dt.Tables.Count > 2)
                {
                    GVBIOMedical.DataSource = dt.Tables[2];
                    GVBIOMedical.DataBind();
                }
                else
                {
                    GVBIOMedical.DataSource = null;
                    GVBIOMedical.DataBind();
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlwaste.ClearSelection();
                AddSelect(ddlwaste);
                if (ddlcategory.SelectedItem.Text != "--Select--")
                {
                    BindCategory(ddlwaste, ddlcategory.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlcategory.SelectedIndex == -1 || ddlwaste.SelectedIndex == -1 ||
    string.IsNullOrWhiteSpace(txtQuantity.Text) || string.IsNullOrWhiteSpace(txtMethod.Text))
                {
                    lblmsg0.Text = "Please Enter All Details of BMW WASTE";
                    Failure.Visible = true;
                    string message = $"alert('{lblmsg0.Text}')";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("BMW_TYPE", typeof(string));
                    dt.Columns.Add("BMW_NAME", typeof(string));
                    dt.Columns.Add("BMW_QUANTITYGENERATED", typeof(string));
                    dt.Columns.Add("BMW_TREATMENTDISPOSAL", typeof(string));

                    if (ViewState["BMWWasteData"] != null)
                    {
                        dt = (DataTable)ViewState["BMWWasteData"];
                    }
                    DataRow dr = dt.NewRow();
                    dr["BMW_TYPE"] = ddlcategory.SelectedValue;
                    dr["BMW_NAME"] = ddlwaste.SelectedItem.Text;
                    dr["BMW_QUANTITYGENERATED"] = txtQuantity.Text;
                    dr["BMW_TREATMENTDISPOSAL"] = txtMethod.Text;

                    dt.Rows.Add(dr);
                    GVWaste.Visible = true;
                    GVWaste.DataSource = dt;
                    GVWaste.DataBind();
                    ViewState["BMWWasteData"] = dt;

                    ddlcategory.ClearSelection();
                    ddlwaste.ClearSelection();
                    txtQuantity.Text = "";
                    txtMethod.Text = "";

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        /*  public string SaveBMWMedical()
          {
              string result = "";

              DataTable dt = new DataTable();           
              dt.Columns.Add("BMW_UNITID");
              dt.Columns.Add("BMW_CREATEDBY");
              dt.Columns.Add("BMW_EQUIPMENT");
              dt.Columns.Add("BMW_NO_UNIT");
              dt.Columns.Add("BMW_CAPACITY_UNIT");


              if (GVBIOMedical.Rows.Count > 0)
              {
                  foreach (GridViewRow row in GVBIOMedical.Rows)
                  {

                      Label lblitem = row.FindControl("lblItemName") as Label;
                      TextBox txtsource = row.FindControl("txtSource") as TextBox;
                      TextBox txtcapacity = row.FindControl("txtCapacity") as TextBox;

                      if (lblitem != null && txtsource != null && txtcapacity != null)
                      {

                          DataRow dr = dt.NewRow();
                          dr["BMW_EQUIPMENT"] = lblitem.Text;
                          dr["BMW_NO_UNIT"] = txtsource.Text;
                          dr["BMW_CAPACITY_UNIT"] = txtcapacity.Text;

                          dt.Rows.Add(dr);
                      }
                  }
                  if (dt.Rows.Count > 0)
                  {
                      // SvrcBMWDet objSrvcbal = new SvrcBMWDet();
                      result = objSrvcbal.InsertBMWWASTEDET(dt, UnitID, hdnUserID.Value, getclientIP());
                  }
              }

              return result;
          }*/
        public string SaveBMWMedical()
        {
            string result = "";
            DataTable dt = new DataTable();

            // Define columns for the DataTable
            dt.Columns.Add("BMW_ID", typeof(string));
            dt.Columns.Add("BMW_SERVICEQDID", typeof(string));
            dt.Columns.Add("BMW_UNITID", typeof(string));
            dt.Columns.Add("BMW_CREATEDBY", typeof(string));
            dt.Columns.Add("BMW_EQUIPMENT", typeof(string));
            dt.Columns.Add("BMW_NO_UNIT", typeof(string));
            dt.Columns.Add("BMW_CAPACITY_UNIT", typeof(string));

            try
            {

                if (GVBIOMedical.Rows.Count > 0)
                {
                    foreach (GridViewRow row in GVBIOMedical.Rows)
                    {
                        Label lblBMW = row.FindControl("lblBMWID") as Label;
                        Label lblItem = row.FindControl("lblItemName") as Label;
                        TextBox txtSource = row.FindControl("txtSource") as TextBox;
                        TextBox txtCapacity = row.FindControl("txtCapacity") as TextBox;

                        if (lblItem != null && txtSource != null && txtCapacity != null)
                        {

                            if (!string.IsNullOrEmpty(lblItem.Text) &&
                                !string.IsNullOrEmpty(lblBMW.Text) &&
                                !string.IsNullOrEmpty(txtSource.Text) &&
                                !string.IsNullOrEmpty(txtCapacity.Text))
                            {
                                DataRow dr = dt.NewRow();
                                dr["BMW_ID"] = lblBMW.Text;
                                dr["BMW_EQUIPMENT"] = lblItem.Text;
                                dr["BMW_NO_UNIT"] = txtSource.Text;
                                dr["BMW_CAPACITY_UNIT"] = txtCapacity.Text;
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    // SvrcBMWDet objSrvcbal = new SvrcBMWDet(); // Ensure this is initialized
                    result = objSrvcbal.InsertBMWWASTEDET(dt, UnitID, Questionnaire, hdnUserID.Value, getclientIP());
                }
                else
                {
                    result = "No data to save.";
                }
            }
            catch (Exception ex)
            {
                result = "Error: " + ex.Message;
            }

            return result;
        }



        protected void btnBiomedicalwaste_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupBiomedicalwaste.HasFile)
                {
                    Error = validations(fupBiomedicalwaste);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["SRVCQID"]) + "\\" + "Bio-medical waste treatment facility (CBWTF)" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupBiomedicalwaste.PostedFile.SaveAs(serverpath + "\\" + fupBiomedicalwaste.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupBiomedicalwaste.PostedFile.SaveAs(serverpath + "\\" + fupBiomedicalwaste.PostedFile.FileName);
                            }
                        }

                        SRVCAttachments objAadhar = new SRVCAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["SRVCUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["SRVCQID"]);  //Convert.ToString(Session["CFEQID"]);
                        objAadhar.MasterID = "10";
                        objAadhar.FilePath = serverpath + fupBiomedicalwaste.PostedFile.FileName;
                        objAadhar.FileName = fupBiomedicalwaste.PostedFile.FileName;
                        objAadhar.FileType = fupBiomedicalwaste.PostedFile.ContentType;
                        objAadhar.FileDescription = "Bio-medical waste treatment facility (CBWTF)";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        objAadhar.ReferenceNo = txtCBWTFBIO.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objAadhar);
                        if (result != "")
                        {
                            hypBiomedicalwaste.Text = fupBiomedicalwaste.PostedFile.FileName;
                            hypBiomedicalwaste.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupBiomedicalwaste.PostedFile.FileName);
                            hypBiomedicalwaste.Target = "blank";
                            message = "alert('" + "Bio-medical waste treatment facility (CBWTF) Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnlegalnotice_Click(object sender, EventArgs e)
        {

            try
            {
                string Error = ""; string message = "";
                if (fuplegalnotice.HasFile)
                {
                    Error = validations(fuplegalnotice);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["SRVCQID"]) + "\\" + "Directions or notices or legal actions authorisation" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fuplegalnotice.PostedFile.SaveAs(serverpath + "\\" + fuplegalnotice.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fuplegalnotice.PostedFile.SaveAs(serverpath + "\\" + fuplegalnotice.PostedFile.FileName);
                            }
                        }

                        SRVCAttachments objSitePlan = new SRVCAttachments();
                        objSitePlan.UNITID = Convert.ToString(Session["SRVCUNITID"]);
                        objSitePlan.Questionnareid = Convert.ToString(Session["SRVCQID"]);
                        objSitePlan.MasterID = "11";
                        objSitePlan.FilePath = serverpath + fuplegalnotice.PostedFile.FileName;
                        objSitePlan.FileName = fuplegalnotice.PostedFile.FileName;
                        objSitePlan.FileType = fuplegalnotice.PostedFile.ContentType;
                        objSitePlan.FileDescription = "Directions or notices or legal actions authorisation";
                        objSitePlan.CreatedBy = hdnUserID.Value;
                        objSitePlan.IPAddress = getclientIP();
                        objSitePlan.ReferenceNo = txtlegalDet.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSitePlan);
                        if (result != "")
                        {
                            hyplegalnotice.Text = fuplegalnotice.PostedFile.FileName;
                            hyplegalnotice.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fuplegalnotice.PostedFile.FileName);
                            hyplegalnotice.Target = "blank";
                            message = "alert('" + "Details of directions or notices or legal actions authorisation Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }


        }
        public string validations(FileUpload Attachment)
        {
            try
            {
                string filesize = Convert.ToString(ConfigurationManager.AppSettings["FileSize"].ToString());
                int slno = 1; string Error = "";
                //if (Attachment.PostedFile.ContentType != "application/pdf"
                //     || !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                //{

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

        protected void GVWaste_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVWaste.Rows.Count > 0)
                {
                    ((DataTable)ViewState["BMWWasteData"]).Rows.RemoveAt(e.RowIndex);
                    this.GVWaste.DataSource = ((DataTable)ViewState["BMWWasteData"]).DefaultView;
                    this.GVWaste.DataBind();
                    GVWaste.Visible = true;
                    GVWaste.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
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
                Response.Redirect("~/User/Services/SWMDetails.aspx?Previous=" + "P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GVBIOMedical_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataTable dt = (DataTable)ViewState["BioMedical"];
                    if (dt != null)
                    {
                        if (e.Row.RowIndex < 12)
                        {
                            GridViewRow gvr = e.Row;
                            TextBox Source = (TextBox)gvr.FindControl("txtSource");
                            TextBox Capacity = (TextBox)gvr.FindControl("txtCapacity");

                            Source.Text = dt.Rows[e.Row.RowIndex]["BMW_NO_UNIT"].ToString();
                            Capacity.Text = dt.Rows[e.Row.RowIndex]["BMW_CAPACITY_UNIT"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Services/PDCLDetails.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = Stepvalidations();
                if (ErrorMsg == "")
                {
                    SvrcBMWDet ObjBMWDetails = new SvrcBMWDet();
                    int count = 0;                  

                    for (int i = 0; i < GVWaste.Rows.Count; i++)
                    {
                        Label lblCategory = GVWaste.Rows[i].FindControl("lblCategory") as Label;
                        Label lblWaste = GVWaste.Rows[i].FindControl("lblItemName") as Label;
                        Label lblQuantity = GVWaste.Rows[i].FindControl("lblQuantity") as Label;
                        Label lblDisposal = GVWaste.Rows[i].FindControl("lblDisposal") as Label;

                        ObjBMWDetails.Createdby = hdnUserID.Value;
                        ObjBMWDetails.UnitId = Convert.ToString(Session["SRVCUNITID"]);
                        ObjBMWDetails.Questionnariid = Convert.ToString(Session["SRVCQID"]);
                        ObjBMWDetails.IPAddress = getclientIP();
                        ObjBMWDetails.Category = lblCategory.Text;
                        ObjBMWDetails.Waste = lblWaste.Text;
                        ObjBMWDetails.QuantityGenerated = lblQuantity.Text;
                        ObjBMWDetails.MethodDisposal = lblDisposal.Text;

                        string A = objSrvcbal.SRVCBMWWASTEDET(ObjBMWDetails);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVWaste.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "BMWDETAILS Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                    var selectedItems = CHKAuthorized.Items.Cast<ListItem>()
                             .Where(li => li.Selected)
                             .Select(li => li.Text);

                    string selectedActivities = string.Join(", ", selectedItems);


                    ObjBMWDetails.UnitId = Convert.ToString(Session["SRVCUNITID"]);
                    ObjBMWDetails.Questionnariid = Convert.ToString(Session["SRVCQID"]);
                    ObjBMWDetails.Createdby = hdnUserID.Value;
                    ObjBMWDetails.IPAddress = getclientIP();
                    ObjBMWDetails.Name_applicant = txtNameApplicant.Text;
                    ObjBMWDetails.HCFCBWTF = rblMedical.SelectedValue;
                    ObjBMWDetails.email = txtEmailId.Text;
                    ObjBMWDetails.mobile = txtMobileNo.Text;
                    ObjBMWDetails.website = txtweb.Text;
                    ObjBMWDetails.Authorizationactivity = selectedActivities;
                    ObjBMWDetails.AppliedCTO_CTE = rblauthorisation.SelectedValue;
                    ObjBMWDetails.authorisationnumber = txtRenno.Text;
                    ObjBMWDetails.authorisation_Date = txtAuthorisationDate.Text;
                    ObjBMWDetails.Pollution1974 = txtPCB.Text;
                    ObjBMWDetails.ControlPollution1981 = txtPCB1981.Text;
                    ObjBMWDetails.AddressHealthHCFCBWFT = rblHealth.SelectedValue;
                    ObjBMWDetails.GPSCOORDINATES = rblGPS.SelectedValue;
                    ObjBMWDetails.NumberBED = txtNoHCF.Text;
                    ObjBMWDetails.patientsHCF = txtHCFNO.Text;
                    ObjBMWDetails.healthcareCBMWTF = txtHealthCBMWFT.Text;
                    ObjBMWDetails.NOBEDCBMWTF = txtNobedcbmwtf.Text;
                    ObjBMWDetails.DISPOSALCBMWTF = txtcapacitytreat.Text;
                    ObjBMWDetails.DISTANCECBMWTF = txtdistance.Text;
                    ObjBMWDetails.BMWTREATED = txtwastetreat.Text;
                    ObjBMWDetails.MODETRANSACTION = txtBiowaste.Text;


                    result = objSrvcbal.SRVCBMWDetails(ObjBMWDetails);
                    result = SaveBMWMedical();
                    if (result != "")
                    {
                        string message = "alert('" + "BMW Details Saved Successfully" + "')";
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

        public string Stepvalidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtNameApplicant.Text) || txtNameApplicant.Text == "" || txtNameApplicant.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Applicant...! \\n";
                    slno = slno + 1;
                }
                if (rblMedical.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Name of the health care facility HCF/CBWTF...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmailId.Text) || txtEmailId.Text == "" || txtEmailId.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter E-Mail ID...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile Number...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtweb.Text) || txtweb.Text == "" || txtweb.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Website Address...! \\n";
                    slno = slno + 1;
                }
                if (rblauthorisation.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Applied for CTO/CTE...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRenno.Text) || txtRenno.Text == "" || txtRenno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter renewal previous authorisation number...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAuthorisationDate.Text) || txtAuthorisationDate.Text == "" || txtAuthorisationDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter renewal previous authorisation Date...! \\n";
                    slno = slno + 1;
                }
                //if (string.IsNullOrEmpty(txtPCB.Text) || txtPCB.Text == "" || txtPCB.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Prevention and Control of Pollution) Act, 1974...! \\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtPCB1981.Text) || txtPCB1981.Text == "" || txtPCB1981.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Prevention and Control of Pollution) Act, 1981...! \\n";
                //    slno = slno + 1;
                //}
                if (rblHealth.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Address health care facility (HCF)/(CBWTF)...! \\n";
                    slno = slno + 1;
                }
                if (rblGPS.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select GPS coordinates of health care facility (HCF)/(CBWTF)...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNoHCF.Text) || txtNoHCF.Text == "" || txtNoHCF.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Number of beds of HCF...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtHCFNO.Text) || txtHCFNO.Text == "" || txtHCFNO.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Number of patients treated per month by HCF...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtHealthCBMWFT.Text) || txtHealthCBMWFT.Text == "" || txtHealthCBMWFT.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Number of patients treated per month by HCF...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNobedcbmwtf.Text) || txtNobedcbmwtf.Text == "" || txtNobedcbmwtf.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter No of beds covered by CBMWTF...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtcapacitytreat.Text) || txtcapacitytreat.Text == "" || txtcapacitytreat.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Installed treatment and disposal capacity of CBMWTF...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdistance.Text) || txtdistance.Text == "" || txtdistance.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Area or distance covered by CBMWTF...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtwastetreat.Text) || txtwastetreat.Text == "" || txtwastetreat.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Quantity of Bio-medical waste handled, treated or disposed...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBiowaste.Text) || txtBiowaste.Text == "" || txtBiowaste.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mode of transportation (if any) of bio-medical waste...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBiowaste.Text) || txtBiowaste.Text == "" || txtBiowaste.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mode of transportation (if any) of bio-medical waste...! \\n";
                    slno = slno + 1;
                }
                if (GVWaste.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter BMW Waste Type...! \\n";
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

    }
}