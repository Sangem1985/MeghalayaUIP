using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class BMWDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();

        string Category;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindWasteDetails();
                BindBMW();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddlcategory.SelectedValue) || string.IsNullOrEmpty(ddlwaste.SelectedValue) || string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtMethod.Text))
                {
                    lblmsg0.Text = "Please Enter All Details of BMW WASTE";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));

                    if (ViewState[""] != null)
                    {
                        dt = (DataTable)ViewState[""];
                    }
                    DataRow dr = dt.NewRow();
                    dr[""] = ddlcategory.SelectedValue;
                    dr[""] = ddlwaste.SelectedValue;
                    dr[""] = txtQuantity.Text;
                    dr[""] = txtMethod.Text;

                    dt.Rows.Add(dr);
                    GVWaste.Visible = true;
                    GVWaste.DataSource = dt;
                    GVWaste.DataBind();
                    ViewState[""] = dt;
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
                ddlwaste.Items.Clear();

                // List<MasterBMWWASTE> objWaste = new List<MasterBMWWASTE>();
                DataSet ds = new DataSet();

                ds = mstrBAL.GetWasteDet(Category);
                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlcategory.DataSource = ds.Tables[0];
                    ddlcategory.DataValueField = "BMW_TYPE";
                    ddlcategory.DataTextField = "BMW_TYPE";
                    ddlcategory.DataBind();

                    ddlwaste.DataSource = ds.Tables[1];
                    ddlwaste.DataValueField = "BMW_TYPE";
                    ddlwaste.DataTextField = "BMW_TYPE";
                    ddlwaste.DataBind();


                }
                else
                {
                    ddlcategory.DataSource = null;
                    ddlcategory.DataBind();

                    ddlwaste.DataSource = null;
                    ddlwaste.DataBind();
                }
                AddSelect(ddlcategory);
                AddSelect(ddlwaste);
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

        protected void ddlwaste_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlwaste.ClearSelection();
                AddSelect(ddlwaste);
                if (ddlcategory.SelectedItem.Text != "--Select--")
                {
                    //  BindWasteDetails(ddlwaste, ddlcategory.SelectedValue);
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
        protected void BindBMW()
        {
            try
            {
                DataSet dt = new DataSet();

                dt = objSrvcbal.BMWEquipment();

                if (dt != null && dt.Tables.Count > 3)
                {
                    GVBIOMedical.DataSource = dt.Tables[3];
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
        /*  public string Stepvalidations()
          {
              try
              {
                  int slno = 1;
                  string errormsg = "";
                  if (string.IsNullOrEmpty(txtUnitName.Text) || txtUnitName.Text == "" || txtUnitName.Text == null)
                  {
                      errormsg = errormsg + slno + ". Please Enter Unit Address Name of Unit...! \\n";
                      slno = slno + 1;
                  }

                  return errormsg;
              }
              catch(Exception ex)
              {

              }
          }*/
    }
}