﻿using MeghalayaUIP.BAL.CFOBAL;
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
        CFOBAL objcfebal = new CFOBAL();
        string UNITID;
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
                Session["UNITID"] = "1001";
                UNITID = Convert.ToString(Session["UNITID"]);

                Page.MaintainScrollPositionOnPostBack = true;
                Failure.Visible = false;
                success.Visible = false;
                if (!IsPostBack)
                {

                }
            }
        }

        protected void rblinsection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblinsection.SelectedItem.Text == "Yes")
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
            String Quesstionriids = "1001";
            string UnitId = "1001";
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Validations();
                {
                    CFOHealthyWelfare ObjCFOHealthyWelfare = new CFOHealthyWelfare();


                    int count = 0, count1 = 0, count2 = 0;
                    for (int i = 0; i < GVHealthy.Rows.Count; i++)
                    {
                        ObjCFOHealthyWelfare.Questionnariid = Quesstionriids;
                        ObjCFOHealthyWelfare.CreatedBy = hdnUserID.Value;
                        ObjCFOHealthyWelfare.UNITID = Convert.ToString(Session["UNITID"]);
                        ObjCFOHealthyWelfare.IPAddress = getclientIP();
                        ObjCFOHealthyWelfare.ManufName = GVHealthy.Rows[i].Cells[1].Text;
                        ObjCFOHealthyWelfare.ManufQualification = GVHealthy.Rows[i].Cells[2].Text;
                        ObjCFOHealthyWelfare.ManufExperience = GVHealthy.Rows[i].Cells[3].Text;




                        string A = objcfebal.INSERTCFOManufactureDetails(ObjCFOHealthyWelfare);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVHealthy.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "CFO PROFESSIONALTAX Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                    for (int i = 0; i < GVTESTING.Rows.Count; i++)
                    {
                        ObjCFOHealthyWelfare.Questionnariid = Quesstionriids;
                        ObjCFOHealthyWelfare.CreatedBy = hdnUserID.Value;
                        ObjCFOHealthyWelfare.UNITID = Convert.ToString(Session["UNITID"]);
                        ObjCFOHealthyWelfare.IPAddress = getclientIP();
                        ObjCFOHealthyWelfare.testingName = GVTESTING.Rows[i].Cells[1].Text;
                        ObjCFOHealthyWelfare.testingQualification = GVTESTING.Rows[i].Cells[2].Text;
                        ObjCFOHealthyWelfare.testingExperience = GVTESTING.Rows[i].Cells[3].Text;




                        string A = objcfebal.INSERTCFOTestingDetails(ObjCFOHealthyWelfare);
                        if (A != "")
                        { count1 = count + 1; }
                    }
                    if (GVTESTING.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "CFO PROFESSIONALTAXCOUNTRY Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                    for (int i = 0; i < GVDrug.Rows.Count; i++)
                    {
                        ObjCFOHealthyWelfare.Questionnariid = Quesstionriids;
                        ObjCFOHealthyWelfare.CreatedBy = hdnUserID.Value;
                        ObjCFOHealthyWelfare.UNITID = Convert.ToString(Session["UNITID"]);
                        ObjCFOHealthyWelfare.IPAddress = getclientIP();
                        ObjCFOHealthyWelfare.NameDrug = GVDrug.Rows[i].Cells[1].Text;




                        string A = objcfebal.InsertCFODRUGLICDetails(ObjCFOHealthyWelfare);
                        if (A != "")
                        { count2 = count + 1; }
                    }
                    if (GVDrug.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "CFO DrugLicense Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }



                    { ObjCFOHealthyWelfare.UNITID = Convert.ToString(ViewState["UnitID"]); }
                    ObjCFOHealthyWelfare.CreatedBy = hdnUserID.Value;
                    ObjCFOHealthyWelfare.IPAddress = getclientIP();
                    ObjCFOHealthyWelfare.Questionnariid = Quesstionriids;
                    ObjCFOHealthyWelfare.UnitId = UnitId;


                    ObjCFOHealthyWelfare.TypeApplication = rblApplication.SelectedValue;
                    ObjCFOHealthyWelfare.TradingLICDate = txttradeLic.Text;
                    ObjCFOHealthyWelfare.Valideuptodate = txtClass.Text;
                    ObjCFOHealthyWelfare.coldstorage = txtCapacity.Text;
                    ObjCFOHealthyWelfare.cancelledlicense = rblLicense.SelectedValue;
                    ObjCFOHealthyWelfare.specifylicense = txtspecifyLICNo.Text;
                    ObjCFOHealthyWelfare.readyinspection = rblinsection.SelectedValue;
                    ObjCFOHealthyWelfare.inceptionDate = txtInspection.Text;


                    result = objcfebal.InsertCFODrugLicenseDet(ObjCFOHealthyWelfare);
                    ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "CFO DrugLicense Details Submitted Successfully";
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
                if (rblApplication.SelectedIndex == -1 || rblApplication.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric \\n";
                    slno = slno + 1;
                }
                if (rblLicense.SelectedIndex == -1 || rblLicense.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Canceled License \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txttradeLic.Text) || txttradeLic.Text == "" || txttradeLic.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Trade License\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtClass.Text) || txtClass.Text == "" || txtClass.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCapacity.Text) || txtCapacity.Text == "" || txtCapacity.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Cold Storage\\n";
                    slno = slno + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rblLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblLicense.SelectedItem.Text == "Yes")
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
                    dr["CFODM_UNITID"] = Convert.ToString(ViewState["UnitID"]);
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
                    dr["CFODT_UNITID"] = Convert.ToString(ViewState["UnitID"]);
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
                    dr["CFOD_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["CFOD_CREATEDBY"] = hdnUserID.Value;
                    dr["CFOD_CREATEDBYIP"] = getclientIP();
                    dr["CFOD_DRUGNAME"] = txtNameDrug.Text;



                    dt.Rows.Add(dr);
                    GVDrug.Visible = true;
                    GVDrug.DataSource = dt;
                    GVDrug.DataBind();
                    ViewState["NameDrug"] = dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("DistricCouncile.aspx");
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublicWorkDepartment.aspx");
        }
    }
}