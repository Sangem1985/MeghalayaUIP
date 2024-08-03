using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFODrugLicenseDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
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
                            if (dsnew.Tables[0].Rows[i]["CFOQA_APPROVALID"].ToString() == "39" || dsnew.Tables[0].Rows[i]["CFOQA_APPROVALID"].ToString()=="46")
                            {
                                div_39_46.Visible=true;
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
                        if (rblinsection.Text == "Yes")
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
                        ViewState["TESTING"]= ds.Tables[3];
                        GVTESTING.DataSource = ds.Tables[3];
                        GVTESTING.DataBind();
                        GVTESTING.Visible = true;
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[4].Rows[0]["CFOD_CFOQDID"]);
                        ViewState["NameDrug"]= ds.Tables[4];
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
                string result = "";
                ErrorMsg = Validations();
                if(ErrorMsg == "")
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
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtQualification.Text) || string.IsNullOrEmpty(txtExperience.Text))
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
                    dr["CFODM_EMPNAME"] = txtName.Text;
                    dr["CFODM_EMPQLFCATION"] = txtQualification.Text;
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
                if (string.IsNullOrEmpty(txtNameTest.Text) || string.IsNullOrEmpty(txtQualifyTest.Text) || string.IsNullOrEmpty(txtExperienceTest.Text))
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
                    dr["CFODT_EMPNAME"] = txtNameTest.Text;
                    dr["CFODT_EMPQLFCATION"] = txtQualifyTest.Text;
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
                if (string.IsNullOrEmpty(txtNameDrug.Text))
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
                    dr["CFOD_DRUGNAME"] = txtNameDrug.Text;



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