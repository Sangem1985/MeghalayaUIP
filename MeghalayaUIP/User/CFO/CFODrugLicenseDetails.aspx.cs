using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFODrugLicenseDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
        string UnitID, ErrorMsg = "", result = "";
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

                if (Convert.ToString(Session["CFOUNITID"]) != "")
                {
                    UnitID = Convert.ToString(Session["CFOUNITID"]);
                }
                else
                {
                    string newurl = "~/User/CFO/CFOUserDashboard.aspx";
                    Response.Redirect(newurl);
                }

                Page.MaintainScrollPositionOnPostBack = true;
                Failure.Visible = false;
                success.Visible = false;
                if (!IsPostBack)
                {
                    DataSet dsnew = new DataSet();
                    dsnew = objcfobal.GetApprovalDataByDeptId(Session["CFOQID"].ToString(), Session["CFOUNITID"].ToString(), "8");
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsnew.Tables[0].Rows.Count; i++)
                        {
                            if (dsnew.Tables[0].Rows[i]["CFOQA_APPROVALID"].ToString() == "39" || dsnew.Tables[0].Rows[i]["CFOQA_APPROVALID"].ToString() == "46")
                            {
                                div_39_46.Visible = true;
                            }
                            if (Convert.ToString(dsnew.Tables[0].Rows[i]["CFOQA_APPROVALID"]) == "48")
                            {
                                div_48.Visible = true;
                            }
                            if (dsnew.Tables[0].Rows[i]["CFOQA_APPROVALID"].ToString() == "49")
                            {
                                div_48.Visible = true;
                                div_Staff_Manf.Visible = true;
                                div_Staff_Test.Visible = true;
                            }
                            if (dsnew.Tables[0].Rows[i]["CFOQA_APPROVALID"].ToString() == "50")
                            {
                                div_48.Visible = true;
                                div_Staff_Manf.Visible = true;
                            }
                            if (dsnew.Tables[0].Rows[i]["CFOQA_APPROVALID"].ToString() == "51")
                            {
                                div_48.Visible = true;
                                div_Staff_Test.Visible = true;
                            }
                            if (dsnew.Tables[0].Rows[i]["CFOQA_APPROVALID"].ToString() == "52")
                            {
                                div_52.Visible = true;
                                div_48.Visible = true;
                                div_Staff_Manf.Visible = true;
                                div_Staff_Test.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        if (Request.QueryString[0].ToString() == "N")
                        {
                            Response.Redirect("~/User/CFO/CFOProffessionalTax.aspx?next=N");
                        }
                        else
                        {
                            Response.Redirect("~/User/CFO/CFOContractorsRegistration.aspx?Previous=P");
                        }
                    }
                    Binddata();
                }
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfobal.GetCFODrugLicenseDetails(hdnUserID.Value, UnitID);
                if (ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0 || ds.Tables[3].Rows.Count > 0 || ds.Tables[4].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[1].Rows[0]["CFODL_UNITID"]);

                        rblApplication.SelectedValue = ds.Tables[1].Rows[0]["CFODL_APPLTYPE"].ToString();
                        txttradeLic.Text = ds.Tables[1].Rows[0]["CFODL_TRADELICVALDTYDATE"].ToString();
                        txtClass.Text = ds.Tables[1].Rows[0]["CFODL_MUNCPERMVALDTYDATE"].ToString();
                        txtCapacity.Text = ds.Tables[1].Rows[0]["CFODL_COLDSTORGDETAILS"].ToString();
                        rblLicense.SelectedValue = ds.Tables[1].Rows[0]["CFODL_ANYPREVLIC"].ToString();
                        if (rblLicense.Text == "Yes")
                        {
                            CanceledLIC.Visible = true;
                            txtspecifyLICNo.Text = ds.Tables[1].Rows[0]["CFODL_PREVLICDETAILS"].ToString();
                        }
                        else { CanceledLIC.Visible = false; }

                        rblinsection.SelectedValue = ds.Tables[1].Rows[0]["CFODL_PREMISERDYFORINSP"].ToString();
                        if (rblinsection.Text == "Y")
                        {
                            InspectionDate.Visible = true;
                            txtInspection.Text = ds.Tables[1].Rows[0]["CFODL_DATEOFINSP"].ToString();
                        }
                        else { InspectionDate.Visible = false; }

                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[2].Rows[0]["CFODM_CFOQDID"]);
                        ViewState["MANUFACTURE"] = ds.Tables[2];
                        GVHealthy.DataSource = ds.Tables[2];
                        GVHealthy.DataBind();
                        GVHealthy.Visible = true;
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[3].Rows[0]["CFODT_CFOQDID"]);
                        ViewState["TESTING"] = ds.Tables[3];
                        GVTESTING.DataSource = ds.Tables[3];
                        GVTESTING.DataBind();
                        GVTESTING.Visible = true;
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[4].Rows[0]["CFOD_CFOQDID"]);
                        ViewState["NameDrug"] = ds.Tables[4];
                        GVDrug.DataSource = ds.Tables[4];
                        GVDrug.DataBind();
                        GVDrug.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rblinsection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblinsection.SelectedValue == "Y")
            {
                InspectionDate.Visible = true;
            }
            else
            {
                InspectionDate.Visible = false;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
               
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    CFOHealthyWelfare ObjCFOHealthyWelfare = new CFOHealthyWelfare();


                    int count = 0, count1 = 0, count2 = 0;
                    for (int i = 0; i < GVHealthy.Rows.Count; i++)
                    {
                        ObjCFOHealthyWelfare.Questionnariid = Convert.ToString(Session["CFOQID"]);
                        ObjCFOHealthyWelfare.CreatedBy = hdnUserID.Value;
                        ObjCFOHealthyWelfare.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        ObjCFOHealthyWelfare.IPAddress = getclientIP();
                        ObjCFOHealthyWelfare.ManufName = GVHealthy.Rows[i].Cells[1].Text;
                        ObjCFOHealthyWelfare.ManufQualification = GVHealthy.Rows[i].Cells[2].Text;
                        ObjCFOHealthyWelfare.ManufExperience = GVHealthy.Rows[i].Cells[3].Text;

                        string A = objcfobal.INSERTCFOManufactureDetails(ObjCFOHealthyWelfare);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVHealthy.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "DRUG LICENSE Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                    for (int i = 0; i < GVTESTING.Rows.Count; i++)
                    {
                        ObjCFOHealthyWelfare.Questionnariid = Convert.ToString(Session["CFOQID"]);
                        ObjCFOHealthyWelfare.CreatedBy = hdnUserID.Value;
                        ObjCFOHealthyWelfare.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        ObjCFOHealthyWelfare.IPAddress = getclientIP();
                        ObjCFOHealthyWelfare.testingName = GVTESTING.Rows[i].Cells[0].Text;
                        ObjCFOHealthyWelfare.testingQualification = GVTESTING.Rows[i].Cells[1].Text;
                        ObjCFOHealthyWelfare.testingExperience = GVTESTING.Rows[i].Cells[2].Text;

                        string A = objcfobal.INSERTCFOTestingDetails(ObjCFOHealthyWelfare);
                        if (A != "")
                        { count1 = count + 1; }
                    }
                    if (GVTESTING.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "DRUG LICENSE Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                    for (int i = 0; i < GVDrug.Rows.Count; i++)
                    {
                        ObjCFOHealthyWelfare.Questionnariid = Convert.ToString(Session["CFOQID"]);
                        ObjCFOHealthyWelfare.CreatedBy = hdnUserID.Value;
                        ObjCFOHealthyWelfare.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        ObjCFOHealthyWelfare.IPAddress = getclientIP();
                        ObjCFOHealthyWelfare.NameDrug = GVDrug.Rows[i].Cells[1].Text;

                        string A = objcfobal.InsertCFODRUGLICDetails(ObjCFOHealthyWelfare);
                        if (A != "")
                        { count2 = count + 1; }
                    }
                    if (GVDrug.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "DrugLicense Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }



                    ObjCFOHealthyWelfare.UNITID = Convert.ToString(Session["CFOUNITID"]);
                    ObjCFOHealthyWelfare.CreatedBy = hdnUserID.Value;
                    ObjCFOHealthyWelfare.IPAddress = getclientIP();
                    ObjCFOHealthyWelfare.Questionnariid = Convert.ToString(Session["CFOQID"]);
                    ObjCFOHealthyWelfare.UnitId = Convert.ToString(Session["CFOUNITID"]);
                    ObjCFOHealthyWelfare.TypeApplication = rblApplication.SelectedValue;
                    ObjCFOHealthyWelfare.TradingLICDate = txttradeLic.Text;
                    ObjCFOHealthyWelfare.Valideuptodate = txtClass.Text;
                    ObjCFOHealthyWelfare.coldstorage = txtCapacity.Text;
                    ObjCFOHealthyWelfare.cancelledlicense = rblLicense.SelectedValue;
                    ObjCFOHealthyWelfare.specifylicense = txtspecifyLICNo.Text;
                    ObjCFOHealthyWelfare.readyinspection = rblinsection.SelectedValue;
                    ObjCFOHealthyWelfare.inceptionDate = txtInspection.Text;


                    result = objcfobal.InsertCFODrugLicenseDet(ObjCFOHealthyWelfare);
                    //ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "DrugLicense Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                throw ex;
            }
        }
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtClass.Text) || txtClass.Text == "" || txtClass.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Valida Permission\\n";
                    slno = slno + 1;
                }
                if (rblApplication.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Applicant Type \\n";
                    slno = slno + 1;
                }
                //if (rblLicense.SelectedIndex == -1 || rblLicense.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select Canceled License \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txttradeLic.Text) || txttradeLic.Text == "" || txttradeLic.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Trade License\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtClass.Text) || txtClass.Text == "" || txtClass.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Valid up to date permission\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCapacity.Text) || txtCapacity.Text == "" || txtCapacity.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Cold Storage\\n";
                    slno = slno + 1;
                }
                if (rblinsection.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Yes or No Is the premise and plan ready for inspection? \\n";
                    slno = slno + 1;
                }
                if (rblinsection.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtInspection.Text) || txtInspection.Text == "" || txtInspection.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Date for Inspection\\n";
                        slno = slno + 1;
                    }
                }
                if (GVHealthy.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of Technical Staff employed for Manufacturing \\n";
                    slno = slno + 1;
                }
                if (GVTESTING.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Details Of Technical Staff Employed For Testing \\n";
                    slno = slno + 1;
                }
                if (GVDrug.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Drug Details \\n";
                    slno = slno + 1;
                }
                //if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "" || txtName.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Name\\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtQualification.Text) || txtQualification.Text == "" || txtQualification.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Qualification\\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtExperience.Text) || txtExperience.Text == "" || txtExperience.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Experience Year\\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtNameTest.Text) || txtNameTest.Text == "" || txtNameTest.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Name\\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtQualifyTest.Text) || txtQualifyTest.Text == "" || txtQualifyTest.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Qualification\\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtExperienceTest.Text) || txtExperienceTest.Text == "" || txtExperienceTest.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Experience Year\\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtNameDrug.Text) || txtNameDrug.Text == "" || txtNameDrug.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Drug\\n";
                //    slno = slno + 1;
                //}

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rblLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblLicense.SelectedValue == "Y")
            {
                CanceledLIC.Visible = true;
            }
            else
            {
                CanceledLIC.Visible = false;
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtQualification.Text.Trim()) || string.IsNullOrEmpty(txtExperience.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFODM_UNITID", typeof(string));
                    dt.Columns.Add("CFODM_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFODM_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFODM_EMPNAME", typeof(string));
                    dt.Columns.Add("CFODM_EMPQLFCATION", typeof(string));
                    dt.Columns.Add("CFODM_EMPEXPRNC", typeof(string));



                    if (ViewState["MANUFACTURE"] != null)
                    {
                        dt = (DataTable)ViewState["MANUFACTURE"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFODM_UNITID"] = Convert.ToString(Session["CFOUNITID"]);
                    dr["CFODM_CREATEDBY"] = hdnUserID.Value;
                    dr["CFODM_CREATEDBYIP"] = getclientIP();
                    dr["CFODM_EMPNAME"] = txtName.Text.Trim();
                    dr["CFODM_EMPQLFCATION"] = txtQualification.Text.Trim();
                    dr["CFODM_EMPEXPRNC"] = txtExperience.Text;


                    dt.Rows.Add(dr);
                    GVHealthy.Visible = true;
                    GVHealthy.DataSource = dt;
                    GVHealthy.DataBind();
                    ViewState["MANUFACTURE"] = dt;

                    txtName.Text = "";
                    txtQualification.Text = "";
                    txtExperience.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void addbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNameTest.Text.Trim()) || string.IsNullOrEmpty(txtQualifyTest.Text.Trim()) || string.IsNullOrEmpty(txtExperienceTest.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFODT_UNITID", typeof(string));
                    dt.Columns.Add("CFODT_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFODT_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFODT_EMPNAME", typeof(string));
                    dt.Columns.Add("CFODT_EMPQLFCATION", typeof(string));
                    dt.Columns.Add("CFODT_EMPEXPRNC", typeof(string));



                    if (ViewState["TESTING"] != null)
                    {
                        dt = (DataTable)ViewState["TESTING"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFODT_UNITID"] = Convert.ToString(Session["CFOUNITID"]);
                    dr["CFODT_CREATEDBY"] = hdnUserID.Value;
                    dr["CFODT_CREATEDBYIP"] = getclientIP();
                    dr["CFODT_EMPNAME"] = txtNameTest.Text.Trim();
                    dr["CFODT_EMPQLFCATION"] = txtQualifyTest.Text.Trim();
                    dr["CFODT_EMPEXPRNC"] = txtExperienceTest.Text;


                    dt.Rows.Add(dr);
                    GVTESTING.Visible = true;
                    GVTESTING.DataSource = dt;
                    GVTESTING.DataBind();
                    ViewState["TESTING"] = dt;

                    txtNameTest.Text = "";
                    txtQualifyTest.Text = "";
                    txtExperienceTest.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ADDBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNameDrug.Text.Trim()))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFOD_UNITID", typeof(string));
                    dt.Columns.Add("CFOD_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFOD_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFOD_DRUGNAME", typeof(string));




                    if (ViewState["NameDrug"] != null)
                    {
                        dt = (DataTable)ViewState["NameDrug"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFOD_UNITID"] = Convert.ToString(Session["CFOUNITID"]);
                    dr["CFOD_CREATEDBY"] = hdnUserID.Value;
                    dr["CFOD_CREATEDBYIP"] = getclientIP();
                    dr["CFOD_DRUGNAME"] = txtNameDrug.Text.Trim();



                    dt.Rows.Add(dr);
                    GVDrug.Visible = true;
                    GVDrug.DataSource = dt;
                    GVDrug.DataBind();
                    ViewState["NameDrug"] = dt;

                    txtNameDrug.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFO/CFOProffessionalTax.aspx?next=N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
            // Response.Redirect("~/User/CFO/CFOProffessionalTax.aspx?next=N");
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFO/CFOContractorsRegistration.aspx?Previous=P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
            //  Response.Redirect("~/User/CFO/CFOContractorsRegistration.aspx?Previous=P");
        }

        protected void GVHealthy_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVHealthy.Rows.Count > 0)
                {
                    ((DataTable)ViewState["MANUFACTURE"]).Rows.RemoveAt(e.RowIndex);
                    this.GVHealthy.DataSource = ((DataTable)ViewState["MANUFACTURE"]).DefaultView;
                    this.GVHealthy.DataBind();
                    GVHealthy.Visible = true;
                    GVHealthy.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void GVTESTING_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVTESTING.Rows.Count > 0)
                {
                    ((DataTable)ViewState["TESTING"]).Rows.RemoveAt(e.RowIndex);
                    this.GVTESTING.DataSource = ((DataTable)ViewState["TESTING"]).DefaultView;
                    this.GVTESTING.DataBind();
                    GVTESTING.Visible = true;
                    GVTESTING.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void btnTribal_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupTribal.HasFile)
                {
                    Error = validations(fupTribal);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "License in case of Non Tribal of new proprietor" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupTribal.PostedFile.SaveAs(serverpath + "\\" + fupTribal.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fupTribal.PostedFile.FileName;
                        objAadhar.FileName = fupTribal.PostedFile.FileName;
                        objAadhar.FileType = fupTribal.PostedFile.ContentType;
                        objAadhar.FileDescription = "License in case of Non Tribal of new proprietor";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypTribal.Text = fupTribal.PostedFile.FileName;
                            hypTribal.NavigateUrl = serverpath;
                            hypTribal.Target = "blank";
                            message = "alert('" + "ST Certificate/Trading License in case of Non Tribal of new proprietor  Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnQualification_Click(object sender, EventArgs e)
        {

            try
            {
                string Error = ""; string message = "";
                if (fupQualification.HasFile)
                {
                    Error = validations(fupQualification);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Qualification Certificate of new proprietor" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupQualification.PostedFile.SaveAs(serverpath + "\\" + fupQualification.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fupQualification.PostedFile.FileName;
                        objAadhar.FileName = fupQualification.PostedFile.FileName;
                        objAadhar.FileType = fupQualification.PostedFile.ContentType;
                        objAadhar.FileDescription = "Qualification Certificate of new proprietor";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypQualification.Text = fupQualification.PostedFile.FileName;
                            hypQualification.NavigateUrl = serverpath;
                            hypQualification.Target = "blank";
                            message = "alert('" + "Qualification Certificate of new proprietor  Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnSpecimen_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupSpecimen.HasFile)
                {
                    Error = validations(fupSpecimen);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Specimen signature of new proprietor" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupSpecimen.PostedFile.SaveAs(serverpath + "\\" + fupSpecimen.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fupSpecimen.PostedFile.FileName;
                        objAadhar.FileName = fupSpecimen.PostedFile.FileName;
                        objAadhar.FileType = fupSpecimen.PostedFile.ContentType;
                        objAadhar.FileDescription = "Specimen signature of new proprietor";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypSpecimen.Text = fupSpecimen.PostedFile.FileName;
                            hypSpecimen.NavigateUrl = serverpath;
                            hypSpecimen.Target = "blank";
                            message = "alert('" + "Specimen signature of new proprietor Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnHeadman_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupHeadman.HasFile)
                {
                    Error = validations(fupHeadman);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "NOC from Local Headman/Municipal/Cantonment Board" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupHeadman.PostedFile.SaveAs(serverpath + "\\" + fupHeadman.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fupHeadman.PostedFile.FileName;
                        objAadhar.FileName = fupHeadman.PostedFile.FileName;
                        objAadhar.FileType = fupHeadman.PostedFile.ContentType;
                        objAadhar.FileDescription = "NOC from Local Headman/Municipal/Cantonment Board";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypHeadman.Text = fupHeadman.PostedFile.FileName;
                            hypHeadman.NavigateUrl = serverpath;
                            hypHeadman.Target = "blank";
                            message = "alert('" + "NOC from Local Headman/Municipal/Cantonment Board in favour of new proprietor Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnTenancy_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupTenancy.HasFile)
                {
                    Error = validations(fupTenancy);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Tenancy agreement" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupTenancy.PostedFile.SaveAs(serverpath + "\\" + fupTenancy.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fupTenancy.PostedFile.FileName;
                        objAadhar.FileName = fupTenancy.PostedFile.FileName;
                        objAadhar.FileType = fupTenancy.PostedFile.ContentType;
                        objAadhar.FileDescription = "Tenancy agreement";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypTenancy.Text = fupTenancy.PostedFile.FileName;
                            hypTenancy.NavigateUrl = serverpath;
                            hypTenancy.Target = "blank";
                            message = "alert('" + "Tenancy agreement Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupRegistration.HasFile)
                {
                    Error = validations(fupRegistration);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Up to Date Registration of Pharmacist" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupRegistration.PostedFile.SaveAs(serverpath + "\\" + fupRegistration.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fupRegistration.PostedFile.FileName;
                        objAadhar.FileName = fupRegistration.PostedFile.FileName;
                        objAadhar.FileType = fupRegistration.PostedFile.ContentType;
                        objAadhar.FileDescription = "Up to Date Registration of Pharmacist";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypRegistration.Text = fupRegistration.PostedFile.FileName;
                            hypRegistration.NavigateUrl = serverpath;
                            hypRegistration.Target = "blank";
                            message = "alert('" + "Up to Date Registration of Pharmacist Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnPharmacist_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupPharmacist.HasFile)
                {
                    Error = validations(fupPharmacist);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Specimen Signature of Pharmacist" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupPharmacist.PostedFile.SaveAs(serverpath + "\\" + fupPharmacist.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fupPharmacist.PostedFile.FileName;
                        objAadhar.FileName = fupPharmacist.PostedFile.FileName;
                        objAadhar.FileType = fupPharmacist.PostedFile.ContentType;
                        objAadhar.FileDescription = "Specimen Signature of Pharmacist";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypPharmacist.Text = fupPharmacist.PostedFile.FileName;
                            hypPharmacist.NavigateUrl = serverpath;
                            hypPharmacist.Target = "blank";
                            message = "alert('" + "Specimen Signature of Pharmacist Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnQualificationcertificate_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupQualificationcertificate.HasFile)
                {
                    Error = validations(fupQualificationcertificate);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Qualification Certificate of Pharmacist" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupQualificationcertificate.PostedFile.SaveAs(serverpath + "\\" + fupQualificationcertificate.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fupQualificationcertificate.PostedFile.FileName;
                        objAadhar.FileName = fupQualificationcertificate.PostedFile.FileName;
                        objAadhar.FileType = fupQualificationcertificate.PostedFile.ContentType;
                        objAadhar.FileDescription = "Qualification Certificate of Pharmacist";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypQualificationcertificate.Text = fupQualificationcertificate.PostedFile.FileName;
                            hypQualificationcertificate.NavigateUrl = serverpath;
                            hypQualificationcertificate.Target = "blank";
                            message = "alert('" + "Qualification Certificate of Pharmacist Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnsiteplan_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupsiteplan.HasFile)
                {
                    Error = validations(fupsiteplan);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Key and Site Plan" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupsiteplan.PostedFile.SaveAs(serverpath + "\\" + fupsiteplan.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fupsiteplan.PostedFile.FileName;
                        objAadhar.FileName = fupsiteplan.PostedFile.FileName;
                        objAadhar.FileType = fupsiteplan.PostedFile.ContentType;
                        objAadhar.FileDescription = "Key and Site Plan";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypsiteplan.Text = fupsiteplan.PostedFile.FileName;
                            hypsiteplan.NavigateUrl = serverpath;
                            hypsiteplan.Target = "blank";
                            message = "alert('" + "Key and Site Plan Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnCompetentperson_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupCompetentperson.HasFile)
                {
                    Error = validations(fupCompetentperson);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Specimen Signature of pharmacist/ Competent person" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupCompetentperson.PostedFile.SaveAs(serverpath + "\\" + fupCompetentperson.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fupCompetentperson.PostedFile.FileName;
                        objAadhar.FileName = fupCompetentperson.PostedFile.FileName;
                        objAadhar.FileType = fupCompetentperson.PostedFile.ContentType;
                        objAadhar.FileDescription = "Specimen Signature of pharmacist/ Competent person";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypCompetentperson.Text = fupCompetentperson.PostedFile.FileName;
                            hypCompetentperson.NavigateUrl = serverpath;
                            hypCompetentperson.Target = "blank";
                            message = "alert('" + "Specimen Signature of pharmacist/ Competent person Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnpharmacistlist_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fuppharmacistlist.HasFile)
                {
                    Error = validations(fuppharmacistlist);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Qualification Certificate of pharmacist/ Competent person" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fuppharmacistlist.PostedFile.SaveAs(serverpath + "\\" + fuppharmacistlist.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fuppharmacistlist.PostedFile.FileName;
                        objAadhar.FileName = fuppharmacistlist.PostedFile.FileName;
                        objAadhar.FileType = fuppharmacistlist.PostedFile.ContentType;
                        objAadhar.FileDescription = "Qualification Certificate of pharmacist/ Competent person";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hyppharmacistlist.Text = fuppharmacistlist.PostedFile.FileName;
                            hyppharmacistlist.NavigateUrl = serverpath;
                            hyppharmacistlist.Target = "blank";
                            message = "alert('" + "Qualification Certificate of pharmacist/ Competent person Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnundertaking1_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupundertaking1.HasFile)
                {
                    Error = validations(fupundertaking1);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Undertaking I" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupundertaking1.PostedFile.SaveAs(serverpath + "\\" + fupundertaking1.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fupundertaking1.PostedFile.FileName;
                        objAadhar.FileName = fupundertaking1.PostedFile.FileName;
                        objAadhar.FileType = fupundertaking1.PostedFile.ContentType;
                        objAadhar.FileDescription = "Undertaking I";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypundertaking1.Text = fupundertaking1.PostedFile.FileName;
                            hypundertaking1.NavigateUrl = serverpath;
                            hypundertaking1.Target = "blank";
                            message = "alert('" + "Undertaking I Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnundertaking2_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupundertaking2.HasFile)
                {
                    Error = validations(fupundertaking2);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Undertaking II" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupundertaking2.PostedFile.SaveAs(serverpath + "\\" + fupundertaking2.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fupundertaking2.PostedFile.FileName;
                        objAadhar.FileName = fupundertaking2.PostedFile.FileName;
                        objAadhar.FileType = fupundertaking2.PostedFile.ContentType;
                        objAadhar.FileDescription = "Undertaking II";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypundertaking2.Text = fupundertaking2.PostedFile.FileName;
                            hypundertaking2.NavigateUrl = serverpath;
                            hypundertaking2.Target = "blank";
                            message = "alert('" + "Undertaking II Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnstaff_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupstaff.HasFile)
                {
                    Error = validations(fupstaff);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFOAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Staff List" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupstaff.PostedFile.SaveAs(serverpath + "\\" + fupstaff.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "55";
                        objAadhar.FilePath = serverpath + fupstaff.PostedFile.FileName;
                        objAadhar.FileName = fupstaff.PostedFile.FileName;
                        objAadhar.FileType = fupstaff.PostedFile.ContentType;
                        objAadhar.FileDescription = "Staff List";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypstaff.Text = fupstaff.PostedFile.FileName;
                            hypstaff.NavigateUrl = serverpath;
                            hypstaff.Target = "blank";
                            message = "alert('" + "Staff List Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        public string validations(FileUpload Attachment)
        {
            try
            {
                int slno = 1; string Error = "";
                if (Attachment.PostedFile.ContentType != "application/pdf"
                     || !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                {

                    if (Attachment.PostedFile.ContentType != "application/pdf")
                    {
                        Error = Error + slno + ". Please Upload PDF Documents only \\n";
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
                }
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

                if (i == 2)
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
        protected void GVDrug_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVDrug.Rows.Count > 0)
                {
                    ((DataTable)ViewState["NameDrug"]).Rows.RemoveAt(e.RowIndex);
                    this.GVDrug.DataSource = ((DataTable)ViewState["NameDrug"]).DefaultView;
                    this.GVDrug.DataBind();
                    GVDrug.Visible = true;
                    GVDrug.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
    }
}