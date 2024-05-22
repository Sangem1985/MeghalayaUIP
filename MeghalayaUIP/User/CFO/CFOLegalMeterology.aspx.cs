using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOLegalMeterology : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtinstrment.Text) || string.IsNullOrEmpty(txtClass.Text) || string.IsNullOrEmpty(txtCapacity.Text) || string.IsNullOrEmpty(txtMake.Text) || string.IsNullOrEmpty(txtModel.Text) || string.IsNullOrEmpty(txtSerial.Text) || string.IsNullOrEmpty(txtProduct.Text) || string.IsNullOrEmpty(txtQuantity.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    //dt.Columns.Add("CFOLD_UNITID", typeof(string));
                    //dt.Columns.Add("CFOLD_CREATEDBY", typeof(string));
                    //dt.Columns.Add("CFOLD_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("Instrument", typeof(string));
                    dt.Columns.Add("Class", typeof(string));
                    dt.Columns.Add("Capacity", typeof(string));
                    dt.Columns.Add("Make", typeof(string));
                    dt.Columns.Add("Model", typeof(string));
                    dt.Columns.Add("Serial", typeof(string));
                    dt.Columns.Add("Product", typeof(string));
                    dt.Columns.Add("Quantity", typeof(string));

                    if (ViewState["LegalDepartment"] != null)
                    {
                        dt = (DataTable)ViewState["LegalDepartment"];
                    }

                    DataRow dr = dt.NewRow();
                    //dr["CFOLD_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    //dr["CFOLD_CREATEDBY"] = hdnUserID.Value;
                    //dr["CFOLD_CREATEDBYIP"] = getclientIP();
                    dr["Instrument"] = txtinstrment.Text;
                    dr["Class"] = txtClass.Text;
                    dr["Capacity"] = txtCapacity.Text;
                    dr["Make"] = txtMake.Text;
                    dr["Model"] = txtModel.Text;
                    dr["Serial"] = txtSerial.Text;
                    dr["Product"] = txtProduct.Text;
                    dr["Quantity"] = txtQuantity.Text;

                    dt.Rows.Add(dr);
                    GVLegalDept.Visible = true;
                    GVLegalDept.DataSource = dt;
                    GVLegalDept.DataBind();
                    ViewState["LegalDepartment"] = dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rblfactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblfactory.SelectedItem.Text == "Yes")
            {
                Registration.Visible = true;
            }
            else
            {
                Registration.Visible = false;
            }
        }

        protected void rblMunicipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblMunicipal.SelectedItem.Text == "Yes")
            {
                ADCLicense.Visible = true;
                DateReg.Visible = true;
            }
            else
            {
                ADCLicense.Visible = false;
                DateReg.Visible = false;
            }
        }

        protected void rblState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblState.SelectedItem.Text == "Yes")
            {
                State.Visible = true;
                Country.Visible = true;
            }
            else
            {
                State.Visible = false;
                Country.Visible = false;
            }
        }

        protected void rblDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblDealer.SelectedItem.Text == "Yes")
            {
                DealerLic.Visible = true;
            }
            else
            {
                DealerLic.Visible = false;
            }
        }

        protected void rblLicdealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblLicdealer.SelectedItem.Text == "Yes")
            {
                applieddealer.Visible = true;
            }
            else
            {
                applieddealer.Visible = false;
            }
        }
    }
}