using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFELineOfManufactureDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
        string UnitID, ErrorMsg = "";
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
                    Page.MaintainScrollPositionOnPostBack = true;
                    if (Convert.ToString(Session["CFEUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["CFEUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }
                    if (!IsPostBack)
                    {
                        BindLineOfActivity("");
                        BindData();
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
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetCFELOMandRMDetails(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            hdnQuesID.Value = Convert.ToString(Session["CFEQID"]);
                            ddlLineOfActivity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELM_LOAID"]);
                            divManf.Visible = true;
                            gvManufacture.DataSource = ds.Tables[0];
                            gvManufacture.DataBind();
                            gvManufacture.Visible = true;
                            ViewState["ManufactureTable"] = ds.Tables[0];
                        }
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            hdnQuesID.Value = Convert.ToString(Session["CFEQID"]);
                            ddlLineOfActivity.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["CFERM_LOAID"]);
                            gvRwaMaterial.DataSource = ds.Tables[1];
                            gvRwaMaterial.DataBind();
                            gvRwaMaterial.Visible = true;
                            ViewState["RawMaterialTable"] = ds.Tables[1];
                        }
                    }
                    else
                    {
                        ddlLineOfActivity.SelectedValue = Convert.ToString(ds.Tables[2].Rows[0]["PROJECT_LOAID"]);
                        hdnQuesID.Value = Convert.ToString(Session["CFEQID"]);

                        if (Convert.ToString(ds.Tables[2].Rows[0]["PROJECT_NOA"]) == "Manufacturing")
                        {
                            divManf.Visible = true;
                            txtManfItemName.Text = Convert.ToString(ds.Tables[2].Rows[0]["PROJECT_MANFPRODUCT"]);
                            txtRMItemName.Text = Convert.ToString(ds.Tables[2].Rows[0]["PROJECT_MAINRM"]);
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
        protected void btnAddLOM_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtManfItemName.Text.Trim()) || string.IsNullOrEmpty(txtManfAnnualCapacity.Text) || string.IsNullOrEmpty(txtManfValue.Text))
                {
                    lblmsg0.Text = "Please Enter All Details of Manufacture Items";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ManfItemName", typeof(string));
                    dt.Columns.Add("ManfItemQuantity", typeof(string));
                    dt.Columns.Add("ManfItemValue", typeof(string));

                    if (ViewState["ManufactureTable"] != null)
                    {
                        dt = (DataTable)ViewState["ManufactureTable"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["ManfItemName"] = txtManfItemName.Text.Trim();
                    dr["ManfItemQuantity"] = txtManfAnnualCapacity.Text;
                    dr["ManfItemValue"] = txtManfValue.Text;

                    dt.Rows.Add(dr);
                    gvManufacture.Visible = true;
                    gvManufacture.DataSource = dt;
                    gvManufacture.DataBind();
                    ViewState["ManufactureTable"] = dt;


                    txtManfItemName.Text = "";
                    txtManfAnnualCapacity.Text = "";
                    txtManfValue.Text = "";

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnaddRM_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRMItemName.Text.Trim()) || string.IsNullOrEmpty(txtRMAnnualCapacity.Text)
                    || string.IsNullOrEmpty(txtRMValue.Text) || string.IsNullOrEmpty(txtRMSource.Text.Trim()))
                {
                    lblmsg0.Text = "Please Enter All Details of Raw-Materials used";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("RMName", typeof(string));
                    dt.Columns.Add("RMAnnualCapacity", typeof(string));
                    dt.Columns.Add("RMValue", typeof(string));
                    dt.Columns.Add("RMSource", typeof(string));

                    if (ViewState["RawMaterialTable"] != null)
                    {
                        dt = (DataTable)ViewState["RawMaterialTable"];
                    }
                    DataRow dr = dt.NewRow();

                    dr["RMName"] = txtRMItemName.Text.Trim();
                    dr["RMAnnualCapacity"] = txtRMAnnualCapacity.Text;
                    dr["RMValue"] = txtRMValue.Text;
                    dr["RMSource"] = txtRMSource.Text.Trim();

                    dt.Rows.Add(dr);
                    gvRwaMaterial.Visible = true;
                    gvRwaMaterial.DataSource = dt;
                    gvRwaMaterial.DataBind();
                    ViewState["RawMaterialTable"] = dt;

                    txtRMItemName.Text = "";
                    txtRMAnnualCapacity.Text = "";
                    txtRMValue.Text = "";
                    txtRMSource.Text = "";
                }


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                ErrorMsg = Validations();

                if (ErrorMsg == "")
                {
                    CFELineOfManuf objCFEManufacture = new CFELineOfManuf();

                    int count1 = 0, count2 = 0;

                    for (int i = 0; i < gvManufacture.Rows.Count; i++)
                    {

                        objCFEManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objCFEManufacture.LOAID = ddlLineOfActivity.SelectedValue;
                        objCFEManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objCFEManufacture.ManfItemName = gvManufacture.Rows[i].Cells[1].Text.Trim();
                        objCFEManufacture.ManfItemAnnualCapacity = gvManufacture.Rows[i].Cells[2].Text;
                        objCFEManufacture.ManfItemValue = gvManufacture.Rows[i].Cells[3].Text;
                        objCFEManufacture.CreatedBy = hdnUserID.Value;
                        objCFEManufacture.IPAddress = getclientIP();

                        string A = objcfebal.InsertCFELineofManf(objCFEManufacture);
                        if (A != "")
                        { count1 = count1 + 1; }
                    }
                    for (int i = 0; i < gvRwaMaterial.Rows.Count; i++)
                    {
                        objCFEManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objCFEManufacture.LOAID = ddlLineOfActivity.SelectedValue;
                        objCFEManufacture.RMItemName = gvRwaMaterial.Rows[i].Cells[1].Text.Trim();
                        objCFEManufacture.RMItemAnnualCapacity = gvRwaMaterial.Rows[i].Cells[2].Text;
                        objCFEManufacture.RMItemValue = gvRwaMaterial.Rows[i].Cells[3].Text;
                        objCFEManufacture.RMSourceofSupply = gvRwaMaterial.Rows[i].Cells[4].Text.Trim();
                        objCFEManufacture.CreatedBy = hdnUserID.Value;
                        objCFEManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objCFEManufacture.IPAddress = getclientIP();

                        string A = objcfebal.InsertCFERawMaterial(objCFEManufacture);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                if (divManf.Visible == true && gvManufacture.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Line of Manufacture Details and click on Add Details button \\n";
                    slno = slno + 1;
                }
                if (gvRwaMaterial.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Raw Material Details click on Add Details button \\n";
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
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEIndustryDetails.aspx");
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
                btnSave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFE/CFEHazWasteDetails.aspx?Next=" + "N");

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                if (ex.Message != "Thread was being aborted.")
                {
                    MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
                }
            }
        }
        protected List<TextBox> FindEmptyTextboxes(Control container)
        {

            List<TextBox> emptyTextboxes = new List<TextBox>();
            foreach (Control control in container.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textbox = (TextBox)control;
                    if (string.IsNullOrWhiteSpace(textbox.Text))
                    {
                        emptyTextboxes.Add(textbox);
                        textbox.BorderColor = System.Drawing.Color.Red;
                    }
                }

                if (control.HasControls())
                {
                    emptyTextboxes.AddRange(FindEmptyTextboxes(control));
                }
            }
            return emptyTextboxes;
        }

    }
}