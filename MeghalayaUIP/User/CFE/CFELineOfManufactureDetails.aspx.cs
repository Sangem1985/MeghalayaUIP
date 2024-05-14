using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFELineOfManufactureDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
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
                Page.MaintainScrollPositionOnPostBack = true;
                if (Convert.ToString(Session["UNITID"]) != "")
                {
                    UnitID = Convert.ToString(Session["UNITID"]);
                }
                else
                {
                    string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                    Response.Redirect(newurl);
                }
                if (!IsPostBack)
                {

                }
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
                    dt.Columns.Add("CFELA_UNITID", typeof(string));
                    dt.Columns.Add("CFELA_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFELA_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("ManfItemName", typeof(string));
                    dt.Columns.Add("ManfItemQuantity", typeof(string));
                    dt.Columns.Add("ManfItemValue", typeof(string));


                    if (ViewState["ManufactureTable"] != null)
                    {
                        dt = (DataTable)ViewState["ManufactureTable"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFELA_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["CFELA_CREATEDBY"] = hdnUserID.Value;
                    dr["CFELA_CREATEDBYIP"] = getclientIP();
                    dr["ManfItemName"] = txtManfItemName.Text;
                    dr["ManfItemQuantity"] = txtManfAnnualCapacity.Text;
                    dr["ManfItemValue"] = txtManfValue.Text;

                    dt.Rows.Add(dr);
                    gvManufacture.Visible = true;
                    gvManufacture.DataSource = dt;
                    gvManufacture.DataBind();
                    ViewState["ManufactureTable"] = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    dt.Columns.Add("CFERM_UNITID", typeof(string));
                    dt.Columns.Add("CFERM_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFERM_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RMName", typeof(string));
                    dt.Columns.Add("RMAnnualCapacity", typeof(string));
                    dt.Columns.Add("RMValue", typeof(string));
                    dt.Columns.Add("RMSource", typeof(string));

                    if (ViewState["RawMaterialTable"] != null)
                    {
                        dt = (DataTable)ViewState["RawMaterialTable"];
                    }
                    DataRow dr = dt.NewRow();
                    dr["CFERM_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["CFERM_CREATEDBY"] = hdnUserID.Value;
                    dr["CFERM_CREATEDBYIP"] = getclientIP();
                    dr["RMName"] = txtRMItemName.Text;
                    dr["RMAnnualCapacity"] = txtRMAnnualCapacity.Text;
                    dr["RMValue"] = txtRMValue.Text;
                    dr["RMSource"] = txtRMSource.Text;


                    dt.Rows.Add(dr);
                    gvRwaMaterial.Visible = true;
                    gvRwaMaterial.DataSource = dt;
                    gvRwaMaterial.DataBind();
                    ViewState["RawMaterialTable"] = dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {

            String Quesstionriids = "1001";
            string UnitId = "1";
            string UNITID = "1001";
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    CFELineOfManuf objCFEManufacture = new CFELineOfManuf();
                    objCFEManufacture.UNITID = UNITID;
                    objCFEManufacture.CreatedBy = hdnUserID.Value;
                    objCFEManufacture.IPAddress = getclientIP();
                    objCFEManufacture.Questionnariid = Quesstionriids;
                    objCFEManufacture.UnitId = UnitId;
                    objCFEManufacture.Line_Activity = ddlLineOfActivity.SelectedValue;
                    objCFEManufacture.ItemLA = txtManfItemName.Text;
                    objCFEManufacture.QuantityLA = txtManfAnnualCapacity.Text;


                    int count = 0;

                    for (int i = 0; i < gvManufacture.Rows.Count; i++)
                    {
                        objCFEManufacture.CreatedBy = hdnUserID.Value;
                        objCFEManufacture.IPAddress = getclientIP();
                        objCFEManufacture.Questionnariid = Quesstionriids;
                        objCFEManufacture.UNITID = UNITID; //Convert.ToString(ViewState["UnitID"]); 
                        objCFEManufacture.ItemLA = gvManufacture.Rows[i].Cells[1].Text;
                        objCFEManufacture.Quantity_PerLA = gvManufacture.Rows[i].Cells[4].Text;
                        objCFEManufacture.QuantityLA = gvManufacture.Rows[i].Cells[2].Text;
                        objCFEManufacture.Quantity_InLA = gvManufacture.Rows[i].Cells[3].Text;

                        string A = objcfebal.GetInsertManufacture(objCFEManufacture);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (gvManufacture.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Consent For Establishment - Questionnaire Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                    for (int i = 0; i < gvRwaMaterial.Rows.Count; i++)
                    {
                        objCFEManufacture.Questionnariid = Quesstionriids;
                        objCFEManufacture.ItemNameRM = gvRwaMaterial.Rows[i].Cells[1].Text;
                        objCFEManufacture.QuantitysRM = gvRwaMaterial.Rows[i].Cells[2].Text;
                        objCFEManufacture.Quantity_InsRM = gvRwaMaterial.Rows[i].Cells[3].Text;
                        objCFEManufacture.Quantity_PersRM = gvRwaMaterial.Rows[i].Cells[4].Text;
                        objCFEManufacture.CreatedBy = hdnUserID.Value;
                        objCFEManufacture.UNITID = UNITID;
                        objCFEManufacture.IPAddress = getclientIP();

                        string A = objcfebal.GetInsertCFERawMaterial(objCFEManufacture);
                        if (A != "")
                        { count = count + 1; }

                    }
                    if (gvRwaMaterial.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Consent For Establishment - Questionnaire Details Submitted Successfully";
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
                if (string.IsNullOrEmpty(txtManfItemName.Text) || txtManfItemName.Text == "" || txtManfItemName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter item \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtManfAnnualCapacity.Text) || txtManfAnnualCapacity.Text == "" || txtManfAnnualCapacity.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Quantity \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtManfValue.Text) || txtManfValue.Text == "" || txtManfValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Raw Material Items \\n";
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
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFELabourDetails.aspx");
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
                Response.Redirect("~/User/CFE/CFEIndustryDetails.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
}