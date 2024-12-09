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

namespace MeghalayaUIP.User.Services
{
	public partial class BMWDetails : System.Web.UI.Page
	{
        MasterBAL mstrBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                BindWasteDetails();
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
            catch(Exception ex)
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

                List<MasterBMWWASTE> objWaste = new List<MasterBMWWASTE>();

                objWaste = mstrBAL.GetWasteDet();
                if (objWaste != null)
                {
                    ddlcategory.DataSource = objWaste;
                    ddlcategory.DataValueField = "BMW_TYPE";
                    ddlcategory.DataTextField = "BMW_TYPE";
                    ddlcategory.DataBind();

                    ddlwaste.DataSource = objWaste;
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
    }
}