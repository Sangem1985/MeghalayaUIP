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
                if (string.IsNullOrEmpty(txtquant.Text) || txtquant.Text == "" || txtquant.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Raw Material Quantity \\n";
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

        protected void btnAddPromtr_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtManfItemName.Text) || string.IsNullOrEmpty(txtManfAnnualCapacity.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFELA_UNITID", typeof(string));
                    dt.Columns.Add("CFELA_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFELA_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFELA_Manf_ItemName", typeof(string));
                    dt.Columns.Add("CFELA_Manf_Item_Quantity", typeof(string));
                    dt.Columns.Add("CFELA_Manf_Item_Quantity_Per", typeof(string));
                    dt.Columns.Add("CFELA_Manf_Item_Quantity_In", typeof(string));


                    if (ViewState["ManufactureTable"] != null)
                    {
                        dt = (DataTable)ViewState["ManufactureTable"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFELA_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["CFELA_CREATEDBY"] = hdnUserID.Value;
                    dr["CFELA_CREATEDBYIP"] = getclientIP();
                    dr["CFELA_Manf_Item_Quantity"] = txtManfAnnualCapacity.Text;
                    // dr["CFELA_LineofActivityMid"] = ddlLineOfActivity.SelectedValue;
                    dr["CFELA_Manf_ItemName"] = txtManfItemName.Text;
                  

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

        protected void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaterial.Text) || string.IsNullOrEmpty(txtquant.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFERM_UNITID", typeof(string));
                    dt.Columns.Add("CFERM_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFERM_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFERM_RAW_ITEMNAME", typeof(string));
                    dt.Columns.Add("CFERM_RAW_ITEM_QUANTITY", typeof(string));
                    dt.Columns.Add("CFERM_RAW_ITEM_QUANTITY_IN", typeof(string));
                    dt.Columns.Add("CFERM_RAW_ITEM_QUANTITY_PER", typeof(string));

                    if (ViewState["RawMaterialTable"] != null)
                    {
                        dt = (DataTable)ViewState["RawMaterialTable"];
                    }
                    DataRow dr = dt.NewRow();
                    dr["CFERM_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["CFERM_CREATEDBY"] = hdnUserID.Value;
                    dr["CFERM_CREATEDBYIP"] = getclientIP();
                    dr["CFERM_RAW_ITEMNAME"] = txtMaterial.Text;
                    dr["CFERM_RAW_ITEM_QUANTITY"] = txtquant.Text;
                    dr["CFERM_RAW_ITEM_QUANTITY_IN"] = ddlinquantity.SelectedValue;
                    dr["CFERM_RAW_ITEM_QUANTITY_PER"] = ddlPerQuantity.SelectedValue;


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
                    //if (Convert.ToString(ViewState["UnitID"]) != "")
                    //{ objCFEManufacture.UNITID = Convert.ToString(ViewState["UnitID"]); }
                    objCFEManufacture.UNITID = UNITID;
                    objCFEManufacture.CreatedBy = hdnUserID.Value;
                    objCFEManufacture.IPAddress = getclientIP();
                    objCFEManufacture.Questionnariid = Quesstionriids;
                    objCFEManufacture.UnitId = UnitId;
                    objCFEManufacture.Line_Activity = ddlLineOfActivity.SelectedValue;
                    objCFEManufacture.ItemLA = txtManfItemName.Text;
                    objCFEManufacture.QuantityLA = txtManfAnnualCapacity.Text;
                    objCFEManufacture.ItemNameRM = txtMaterial.Text;
                    objCFEManufacture.QuantitysRM = txtquant.Text;
                    objCFEManufacture.Quantity_InsRM = ddlinquantity.SelectedValue;
                    objCFEManufacture.Quantity_PersRM = ddlPerQuantity.SelectedValue;

                    int count = 0;
                    //result = objcfebal.GetInsertManufacture(objCFEManufacture);
                    //if (result != "100")
                    //{
                    //  Line_Manufacture objRM = new Line_Manufacture();
                    // Session["QUESTIONRID"] = result;
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

                    //DataTable dtManufacture = (DataTable)ViewState["ManufactureTable"];
                    //// DataTable dt = new DataTable();
                    //if (gvManufacture.Rows.Count > 0)
                    // {

                    //     foreach (DataRow row in dtManufacture.Rows)
                    //     {

                    //          result = objcfebal.GetInsertManufacture(objCFEManufacture);

                    //     }

                    // }

                    //DataTable dtRwaMaterial = (DataTable)ViewState["RwaMaterialTable"];
                    //if (gvRwaMaterial.Rows.Count > 0)
                    // {

                    //     foreach (DataRow row in dtRwaMaterial.Rows)
                    //     {

                    //         result = objcfebal.GetInsertCFERawMaterial(objCFEManufacture);

                    //     }

                    // }
                    // if (result != "")
                    // {
                    //     success.Visible = true;
                    //     lblmsg.Text = "Application Submitted Successfully";
                    //     string message = "alert('" + "Application Submitted Successfully" + "')";
                    //     ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    // }



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

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {

        }
    }
}