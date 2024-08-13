using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Renewal
{
    public partial class RENDrugsLicenseDetails : System.Web.UI.Page
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

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENUNITID"]), Convert.ToString(Session["RENQID"]), "8", "62");

                if(ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "62")
                    {
                        Binddata();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Renewal/RENSafetySecurityDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RenewalServices.aspx?Previous=" + "P");
                    }
                }
              
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txttradeLic.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("REND_UNITID", typeof(string));
                    dt.Columns.Add("REND_CREATEDBY", typeof(string));
                    dt.Columns.Add("REND_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("REND_DRUGNAME", typeof(string));




                    if (ViewState["NameDrug"] != null)
                    {
                        dt = (DataTable)ViewState["NameDrug"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["REND_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["REND_CREATEDBY"] = hdnUserID.Value;
                    dr["REND_CREATEDBYIP"] = getclientIP();
                    dr["REND_DRUGNAME"] = txttradeLic.Text;



                    dt.Rows.Add(dr);
                    GVDrugName.Visible = true;
                    GVDrugName.DataSource = dt;
                    GVDrugName.DataBind();
                    ViewState["NameDrug"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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

        protected void btnTesting_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtnames.Text) || string.IsNullOrEmpty(txtqualifies.Text) || string.IsNullOrEmpty(txtexpered.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENST_UNITID", typeof(string));
                    dt.Columns.Add("RENST_CREATEDBY", typeof(string));
                    dt.Columns.Add("RENST_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RENST_NAME", typeof(string));
                    dt.Columns.Add("RENST_QUALIFICATION", typeof(string));
                    dt.Columns.Add("RENST_EXPERIENCE", typeof(string));



                    if (ViewState["TESTING"] != null)
                    {
                        dt = (DataTable)ViewState["TESTING"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RENST_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["RENST_CREATEDBY"] = hdnUserID.Value;
                    dr["RENST_CREATEDBYIP"] = getclientIP();
                    dr["RENST_NAME"] = txtnames.Text;
                    dr["RENST_QUALIFICATION"] = txtqualifies.Text;
                    dr["RENST_EXPERIENCE"] = txtexpered.Text;


                    dt.Rows.Add(dr);
                    GVTEST.Visible = true;
                    GVTEST.DataSource = dt;
                    GVTEST.DataBind();
                    ViewState["TESTING"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void btnAddmanu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNAME.Text) || string.IsNullOrEmpty(txtQualif.Text) || string.IsNullOrEmpty(txtExpe.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENDM_UNITID", typeof(string));
                    dt.Columns.Add("RENDM_CREATEDBY", typeof(string));
                    dt.Columns.Add("RENDM_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RENDM_NAME", typeof(string));
                    dt.Columns.Add("RENDM_QUALIFICATION", typeof(string));
                    dt.Columns.Add("RENDM_EXPERIENCE", typeof(string));



                    if (ViewState["MANUFACTURE"] != null)
                    {
                        dt = (DataTable)ViewState["MANUFACTURE"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RENDM_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["RENDM_CREATEDBY"] = hdnUserID.Value;
                    dr["RENDM_CREATEDBYIP"] = getclientIP();
                    dr["RENDM_NAME"] = txtNAME.Text;
                    dr["RENDM_QUALIFICATION"] = txtQualif.Text;
                    dr["RENDM_EXPERIENCE"] = txtExpe.Text;


                    dt.Rows.Add(dr);
                    GVMANU.Visible = true;
                    GVMANU.DataSource = dt;
                    GVMANU.DataBind();
                    ViewState["MANUFACTURE"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void btnitem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtitem.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENDA_UNITID", typeof(string));
                    dt.Columns.Add("RENDA_CREATEDBY", typeof(string));
                    dt.Columns.Add("RENDA_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RENDA_ADDITIONALITEM", typeof(string));




                    if (ViewState["ADDEDITEM"] != null)
                    {
                        dt = (DataTable)ViewState["ADDEDITEM"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RENDA_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["RENDA_CREATEDBY"] = hdnUserID.Value;
                    dr["RENDA_CREATEDBYIP"] = getclientIP();
                    dr["RENDA_ADDITIONALITEM"] = txtitem.Text;



                    dt.Rows.Add(dr);
                    GVADDED.Visible = true;
                    GVADDED.DataSource = dt;
                    GVADDED.DataBind();
                    ViewState["ADDEDITEM"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
           // string Quesstionriids = "1001";
            try
            {
                string  result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenDrugLicDet ObjRenDrugLic = new RenDrugLicDet();

                    int count = 0, count1 = 0, count2 = 0, count3 = 0;
                    for (int i = 0; i < GVDrugName.Rows.Count; i++)
                    {
                        ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]); 
                        ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                        ObjRenDrugLic.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenDrugLic.IPAddress = getclientIP();
                        ObjRenDrugLic.NameDrug = GVDrugName.Rows[i].Cells[1].Text;




                        string A = objRenbal.InsertDrugDetails(ObjRenDrugLic);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVDrugName.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Drug Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    for (int i = 0; i < GVTEST.Rows.Count; i++)
                    {
                        ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]); 
                        ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                        ObjRenDrugLic.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenDrugLic.IPAddress = getclientIP();
                        ObjRenDrugLic.Name = GVTEST.Rows[i].Cells[1].Text;
                        ObjRenDrugLic.Qualification = GVTEST.Rows[i].Cells[2].Text;
                        ObjRenDrugLic.Experience = GVTEST.Rows[i].Cells[3].Text;




                        string A = objRenbal.INSERTRENTestingDetails(ObjRenDrugLic);
                        if (A != "")
                        { count1 = count + 1; }
                    }
                    if (GVTESTING.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Drug staff Testing Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    for (int i = 0; i < GVMANU.Rows.Count; i++)
                    {
                        ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]); 
                        ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                        ObjRenDrugLic.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenDrugLic.IPAddress = getclientIP();
                        ObjRenDrugLic.NameManu = GVMANU.Rows[i].Cells[1].Text;
                        ObjRenDrugLic.QualificationManu = GVMANU.Rows[i].Cells[2].Text;
                        ObjRenDrugLic.ExperienceManu = GVMANU.Rows[i].Cells[3].Text;



                        string A = objRenbal.InsertRENManufacture(ObjRenDrugLic);
                        if (A != "")
                        { count2 = count + 1; }
                    }
                    if (GVDrug.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Drug Manufacture Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    for (int i = 0; i < GVADDED.Rows.Count; i++)
                    {
                        ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]); 
                        ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                        ObjRenDrugLic.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenDrugLic.IPAddress = getclientIP();
                        ObjRenDrugLic.AdditionalItem = GVADDED.Rows[i].Cells[1].Text;




                        string A = objRenbal.InsertRenDrugItemDet(ObjRenDrugLic);
                        if (A != "")
                        { count3 = count + 1; }
                    }
                    if (GVADDED.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Additional Item Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }




                    ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                    ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                    ObjRenDrugLic.UnitId = Convert.ToString(Session["RENUNITID"]);
                    ObjRenDrugLic.IPAddress = getclientIP();

                    ObjRenDrugLic.Licnumber = txtLicNo.Text;
                    ObjRenDrugLic.ExpiryDate = txtExpiryDate.Text;
                    ObjRenDrugLic.CancelledLic = rblCancelledLic.SelectedValue;
                    ObjRenDrugLic.SpecifyLicno = txtSpecifyLicNo.Text;
                    ObjRenDrugLic.PremiseInspection = rblInspection.SelectedValue;
                    ObjRenDrugLic.DateInspection = txtDateInsp.Text;
                    ObjRenDrugLic.TotalAmount = txtTotalpaid.Text;
                    ObjRenDrugLic.AdditionalFees = txtFeeAdd.Text;
                    ObjRenDrugLic.LateFees = txtLatefee.Text;
                    ObjRenDrugLic.RegFees = txtRegFees.Text;
                    ObjRenDrugLic.TotalPaidAmount = txtPaidTotalAMount.Text;

                    result = objRenbal.InsertRENDrugLicDetails(ObjRenDrugLic);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal DrugLicense Details Submitted Successfully";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                if (string.IsNullOrEmpty(txtExpiryDate.Text) || txtExpiryDate.Text == "" || txtExpiryDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Expiry Date\\n";
                    slno = slno + 1;
                }
                if (rblCancelledLic.SelectedIndex == -1 || rblCancelledLic.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Cancelled License \\n";
                    slno = slno + 1;
                }
                //if (string.IsNullOrEmpty(txtSpecifyLicNo.Text) || txtSpecifyLicNo.Text == "" || txtSpecifyLicNo.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter specify license no\\n";
                //    slno = slno + 1;
                //}
                if (rblInspection.SelectedIndex == -1 || rblInspection.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select premise and plan ready for inspection \\n";
                    slno = slno + 1;
                }
                //if (string.IsNullOrEmpty(txtDateInsp.Text) || txtDateInsp.Text == "" || txtDateInsp.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Date for Inspection\\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtTotalpaid.Text) || txtTotalpaid.Text == "" || txtTotalpaid.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total Amount to be Paid\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFeeAdd.Text) || txtFeeAdd.Text == "" || txtFeeAdd.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Additional Fees Paid\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLatefee.Text) || txtLatefee.Text == "" || txtLatefee.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Late Fees\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRegFees.Text) || txtRegFees.Text == "" || txtRegFees.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration Fees Paid \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPaidTotalAMount.Text) || txtPaidTotalAMount.Text == "" || txtPaidTotalAMount.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total Amount Paid \\n";
                    slno = slno + 1;
                }
                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objRenbal.GetRenDrugLicDetails(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0 || ds.Tables[3].Rows.Count > 0 || ds.Tables[4].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENDL_UNITID"]);
                        txtLicNo.Text = ds.Tables[0].Rows[0]["RENDL_LICNO"].ToString();
                        txtExpiryDate.Text = ds.Tables[0].Rows[0]["RENDL_EXPIRYDATE"].ToString();
                        rblCancelledLic.SelectedValue = ds.Tables[0].Rows[0]["RENDL_LICCANCEL"].ToString();
                        txtSpecifyLicNo.Text = ds.Tables[0].Rows[0]["RENDL_LICNOSPECIFY"].ToString();
                        rblInspection.SelectedValue = ds.Tables[0].Rows[0]["RENDL_PREMISEINSPECTION"].ToString();
                        txtDateInsp.Text = ds.Tables[0].Rows[0]["RENDL_INSPECTIONDATE"].ToString();
                        txtTotalpaid.Text = ds.Tables[0].Rows[0]["RENDL_TOTALAMOUNT"].ToString();
                        txtFeeAdd.Text = ds.Tables[0].Rows[0]["RENDL_ADDITIONALFEES"].ToString();
                        txtLatefee.Text = ds.Tables[0].Rows[0]["RENDL_LATEFEES"].ToString();
                        txtRegFees.Text = ds.Tables[0].Rows[0]["RENDL_REGFEES"].ToString();
                        txtPaidTotalAMount.Text = ds.Tables[0].Rows[0]["RENDL_TOTALPAIDAMOUNT"].ToString();

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[1].Rows[0]["REND_CFOQDID"]);
                        ViewState["NameDrug"]= ds.Tables[1];
                        GVDrugName.DataSource = ds.Tables[1];
                        GVDrugName.DataBind();
                        GVDrugName.Visible = true;
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[2].Rows[0]["RENSTCFOQDID"]);
                        ViewState["TESTING"]= ds.Tables[2];
                        GVTEST.DataSource = ds.Tables[2];
                        GVTEST.DataBind();
                        GVTEST.Visible = true;
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[3].Rows[0]["RENDMCFOQDID"]);
                        ViewState["MANUFACTURE"]= ds.Tables[3];
                        GVMANU.DataSource = ds.Tables[3];
                        GVMANU.DataBind();
                        GVMANU.Visible = true;
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[4].Rows[0]["RENDA_CFOQDID"]);
                        ViewState["ADDEDITEM"]= ds.Tables[4];
                        GVADDED.DataSource = ds.Tables[4];
                        GVADDED.DataBind();
                        GVADDED.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void GVDrugName_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVDrugName.Rows.Count > 0)
                {
                    ((DataTable)ViewState["NameDrug"]).Rows.RemoveAt(e.RowIndex);
                    this.GVDrugName.DataSource = ((DataTable)ViewState["NameDrug"]).DefaultView;
                    this.GVDrugName.DataBind();
                    GVDrugName.Visible = true;
                    GVDrugName.Focus();

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

        protected void GVTEST_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVTEST.Rows.Count > 0)
                {
                    ((DataTable)ViewState["TESTING"]).Rows.RemoveAt(e.RowIndex);
                    this.GVTEST.DataSource = ((DataTable)ViewState["TESTING"]).DefaultView;
                    this.GVTEST.DataBind();
                    GVTEST.Visible = true;
                    GVTEST.Focus();

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

        protected void GVMANU_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVMANU.Rows.Count > 0)
                {
                    ((DataTable)ViewState["MANUFACTURE"]).Rows.RemoveAt(e.RowIndex);
                    this.GVMANU.DataSource = ((DataTable)ViewState["MANUFACTURE"]).DefaultView;
                    this.GVMANU.DataBind();
                    GVMANU.Visible = true;
                    GVMANU.Focus();

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

        protected void GVADDED_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVADDED.Rows.Count > 0)
                {
                    ((DataTable)ViewState["ADDEDITEM"]).Rows.RemoveAt(e.RowIndex);
                    this.GVADDED.DataSource = ((DataTable)ViewState["ADDEDITEM"]).DefaultView;
                    this.GVADDED.DataBind();
                    GVADDED.Visible = true;
                    GVADDED.Focus();

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

        protected void rblCancelledLic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblCancelledLic.SelectedValue == "Y")
            {
                LicNos.Visible = true;
            }
            else { LicNos.Visible = false; }
        }

        protected void rblInspection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblInspection.SelectedValue == "Y")
            {
                DateInsp.Visible = true;
            }
            else { DateInsp.Visible = false; }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Renewal/RENBoilerDetails.aspx?Next=" + "N");
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
                Response.Redirect("~/User/Renewal/RenewalServices.aspx?Previous=" + "P");
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