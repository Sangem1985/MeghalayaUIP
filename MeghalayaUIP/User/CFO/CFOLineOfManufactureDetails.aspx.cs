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
    public partial class CFOLineOfManufactureDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
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
                //Session["CFEUNITID"] = "1001";
                //UnitID = Convert.ToString(Session["CFEUNITID"]);

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
                if (!IsPostBack)
                {

                    DataSet dsnew = new DataSet();
                    dsnew = objcfobal.GetApprovalDataByDeptId(Session["CFOQID"].ToString(), Session["CFOUNITID"].ToString(), "");
                    //if (dsnew.Tables[0].Rows.Count > 0)
                    //{

                    //}
                    //else
                    //{
                    //    if (Request.QueryString[0].ToString() == "N")
                    //    {
                    //        Response.Redirect("~/User/CFO/CFOLabourDetails.aspx?next=N");
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("~/User/CFO/CFOCombinedApplication.aspx?Previous=P");
                    //    }
                    //}
                    BindLineOfActivity("");
                    BindData();

                }
            }

        }
        public void BindData()
        {

            try
            {
                DataSet ds = new DataSet();
                ds = objcfobal.GetCFOLineOfActivityDetails(hdnUserID.Value, UnitID); //Convert.ToString(Session["CFEUNITID"]));
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ddlLineOfActivity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOLA_LINEOFACTIVITY"]);


                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {

                        gvManufacture.DataSource = ds.Tables[1];
                        gvManufacture.DataBind();
                        gvManufacture.Visible = true;


                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        gvRwaMaterial.DataSource = ds.Tables[2];
                        gvRwaMaterial.DataBind();
                        gvRwaMaterial.Visible = true;
                    }
                }
                else
                {
                    //ddlLineOfActivity.SelectedValue = Convert.ToString(ds.Tables[2].Rows[0]["PROJECT_LOAID"]);
                    //hdnQuesID.Value = Convert.ToString(Session["CFEQID"]);

                    //if (Convert.ToString(ds.Tables[2].Rows[0]["PROJECT_NOA"]) == "Manufacturing")
                    //{

                    //    divManf.Visible = true;
                    //    txtManfItemName.Text = Convert.ToString(ds.Tables[2].Rows[0]["PROJECT_MANFPRODUCT"]);
                    //    txtRMItemName.Text = Convert.ToString(ds.Tables[2].Rows[0]["PROJECT_MAINRM"]);
                    //}

                }




            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }
        protected void BindLineOfActivity(string Sector)
        {
            try
            {
                List<MasterLineOfActivity> objLOA = mstrBAL.GetLineOfActivity(Sector);

                if (objLOA != null && objLOA.Count > 0)
                {
                    ddlLineOfActivity.DataSource = objLOA;
                    ddlLineOfActivity.DataValueField = "LOAId";
                    ddlLineOfActivity.DataTextField = "LOAName";
                    ddlLineOfActivity.DataBind();
                }
                else
                {
                    ddlLineOfActivity.DataSource = null;
                    ddlLineOfActivity.DataBind();
                }

                AddSelect(ddlLineOfActivity);
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
        protected void btnAddLOM_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtManfItemName.Text) || string.IsNullOrEmpty(txtManfAnnualCapacity.Text) || string.IsNullOrEmpty(txtManfValue.Text))
                {
                    lblmsg0.Text = "Please Enter All Details of Manufacture Items";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFOLM_UNITID", typeof(string));
                    dt.Columns.Add("CFOLM_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFOLM_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFOLM_ITEMNAME", typeof(string));
                    dt.Columns.Add("CFOLM_ITEMANNUALCAPACITY", typeof(string));
                    dt.Columns.Add("CFOLM_ITEMVALUE", typeof(string));

                    if (ViewState["ManufactureTable"] != null)
                    {
                        dt = (DataTable)ViewState["ManufactureTable"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["CFOLM_UNITID"] = Convert.ToString(ViewState["CFOUNITID"]);
                    dr["CFOLM_CREATEDBY"] = hdnUserID.Value;
                    dr["CFOLM_CREATEDBYIP"] = getclientIP();
                    dr["CFOLM_ITEMNAME"] = txtManfItemName.Text;
                    dr["CFOLM_ITEMANNUALCAPACITY"] = txtManfAnnualCapacity.Text;
                    dr["CFOLM_ITEMVALUE"] = txtManfValue.Text;

                    dt.Rows.Add(dr);
                    gvManufacture.Visible = true;
                    gvManufacture.DataSource = dt;
                    gvManufacture.DataBind();
                    ViewState["ManufactureTable"] = dt;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnaddRM_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRMItemName.Text) || string.IsNullOrEmpty(txtRMAnnualCapacity.Text)
                    || string.IsNullOrEmpty(txtRMValue.Text) || string.IsNullOrEmpty(txtRMSource.Text))
                {
                    lblmsg0.Text = "Please Enter All Details of Raw-Materials used";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("CFORM_UNITID", typeof(string));
                    dt.Columns.Add("CFORM_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFORM_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFORM_ITEMNAME", typeof(string));
                    dt.Columns.Add("CFORM_ITEMANNUALCAPACITY", typeof(string));
                    dt.Columns.Add("CFORM_ITEMVALUE", typeof(string));
                    dt.Columns.Add("CFORM_SOURCEOFSUPPLY", typeof(string));

                    if (ViewState["RawMaterialTable"] != null)
                    {
                        dt = (DataTable)ViewState["RawMaterialTable"];
                    }
                    DataRow dr = dt.NewRow();

                    dr["CFORM_UNITID"] = Convert.ToString(ViewState["CFOUNITID"]);
                    dr["CFORM_CREATEDBY"] = hdnUserID.Value;
                    dr["CFORM_CREATEDBYIP"] = getclientIP();
                    dr["CFORM_ITEMNAME"] = txtRMItemName.Text;
                    dr["CFORM_ITEMANNUALCAPACITY"] = txtRMAnnualCapacity.Text;
                    dr["CFORM_ITEMVALUE"] = txtRMValue.Text;
                    dr["CFORM_SOURCEOFSUPPLY"] = txtRMSource.Text;

                    dt.Rows.Add(dr);
                    gvRwaMaterial.Visible = true;
                    gvRwaMaterial.DataSource = dt;
                    gvRwaMaterial.DataBind();
                    ViewState["RawMaterialTable"] = dt;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void gvManufacture_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (gvManufacture.Rows.Count > 0)
                {
                    ((DataTable)ViewState["ManufactureTable"]).Rows.RemoveAt(e.RowIndex);
                    this.gvManufacture.DataSource = ((DataTable)ViewState["ManufactureTable"]).DefaultView;
                    this.gvManufacture.DataBind();
                    gvManufacture.Visible = true;
                    gvManufacture.Focus();

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

        protected void gvRwaMaterial_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                if (gvRwaMaterial.Rows.Count > 0)
                {
                    ((DataTable)ViewState["RawMaterialTable"]).Rows.RemoveAt(e.RowIndex);
                    this.gvRwaMaterial.DataSource = ((DataTable)ViewState["RawMaterialTable"]).DefaultView;
                    this.gvRwaMaterial.DataBind();
                    gvRwaMaterial.Visible = true;
                    gvRwaMaterial.Focus();

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //  String Questionnareid = "1001";
            try
            {
                string ErrorMsg = "";
                ErrorMsg = Validations();

                if (ErrorMsg == "")
                {
                    CFOLineOfManuf objCFOManufacture = new CFOLineOfManuf();

                    int count1 = 0, count2 = 0;

                    for (int i = 0; i < gvManufacture.Rows.Count; i++)
                    {

                        objCFOManufacture.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        //   objCFOManufacture.LOAID = ddlLineOfActivity.SelectedValue;
                        objCFOManufacture.UnitID = Convert.ToString(Session["CFOUNITID"]);
                        objCFOManufacture.ManfItemName = gvManufacture.Rows[i].Cells[1].Text;
                        objCFOManufacture.ManfItemAnnualCapacity = gvManufacture.Rows[i].Cells[2].Text;
                        objCFOManufacture.ManfItemValue = gvManufacture.Rows[i].Cells[3].Text;
                        objCFOManufacture.CreatedBy = hdnUserID.Value;
                        objCFOManufacture.IPAddress = getclientIP();

                        string A = objcfobal.InsertCFOLineofManf(objCFOManufacture);
                        if (A != "")
                        { count1 = count1 + 1; }
                    }
                    for (int i = 0; i < gvRwaMaterial.Rows.Count; i++)
                    {
                        objCFOManufacture.Questionnareid = Convert.ToString(Session["CFOQID"]);  //Convert.ToString(Session["CFEQID"]);
                                                                                                 //  objCFOManufacture.LOAID = ddlLineOfActivity.SelectedValue;
                        objCFOManufacture.RMItemName = gvRwaMaterial.Rows[i].Cells[1].Text;
                        objCFOManufacture.RMItemAnnualCapacity = gvRwaMaterial.Rows[i].Cells[2].Text;
                        objCFOManufacture.RMItemValue = gvRwaMaterial.Rows[i].Cells[3].Text;
                        objCFOManufacture.RMSourceofSupply = gvRwaMaterial.Rows[i].Cells[4].Text;
                        objCFOManufacture.CreatedBy = hdnUserID.Value;
                        objCFOManufacture.UnitID = Convert.ToString(Session["CFOUNITID"]);
                        objCFOManufacture.IPAddress = getclientIP();

                        string A = objcfobal.InsertCFORawMaterial(objCFOManufacture);
                        if (A != "")
                        { count2 = count2 + 1; }

                    }
                    if (gvRwaMaterial.Rows.Count == count2 || gvManufacture.Rows.Count == count1)
                    {
                        success.Visible = true;
                        lblmsg.Text = " Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    objCFOManufacture.Questionnareid = Convert.ToString(Session["CFOQID"]);
                    objCFOManufacture.CreatedBy = hdnUserID.Value;
                    objCFOManufacture.UnitID = Convert.ToString(Session["CFOUNITID"]);
                    objCFOManufacture.IPAddress = getclientIP();
                    objCFOManufacture.LOAID = ddlLineOfActivity.SelectedValue;


                    string B = objcfobal.InsertCFOLineOfActivityDetails(objCFOManufacture);

                    if (B != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Line Of Activity Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                }
                else
                {
                    Failure.Visible = true;
                    lblmsg.Text = "Line Of Activity Details No Recordes";
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (divManf.Visible == true && gvManufacture.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Line of Manufacture Details \\n";
                    slno = slno + 1;
                }
                if (gvRwaMaterial.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Raw Material Details \\n";
                    slno = slno + 1;
                }
                if (ddlLineOfActivity.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Line Of Activity  \\n";
                    slno = slno + 1;
                }

                return errormsg;
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
                btnSave_Click(sender, e);
                Response.Redirect("~/User/CFO/CFOLabourDetails.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFO/CFOIndustryDetails.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
}