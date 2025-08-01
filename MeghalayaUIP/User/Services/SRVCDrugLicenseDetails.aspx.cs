using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCDrugLicenseDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string ErrorMsg = "", result = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objSrvcbal.GetSRVCDRUGDet(hdnUserID.Value, Convert.ToString(Session["SRVCQID"]));

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        rblApplication.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCDD_APPLTYPE"]);
                        rblApplication_SelectedIndexChanged(null, EventArgs.Empty);

                        //if (rblApplication.SelectedValue == "W")
                        //{
                            divWholesale.Visible = true;
                            rblSelect.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCDD_NAMECOMPETENT"]);
                            rblSelect_SelectedIndexChanged(null, EventArgs.Empty);
                            //if (rblSelect.SelectedValue == "1")
                            //{
                               // divCompetent.Visible = true;
                                txtCompetentName.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCDD_NAMEPHARMACIST"]);
                            //}
                            //else
                            //{
                               // divPharmacist.Visible = true;
                                txtValidate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCDD_VALIDDATE"]);
                                txtRegNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCDD_REGNO"]);
                            //}
                        //}
                        //else
                        //{
                        //    divRetail.Visible = true;
                        //}

                        txttradeLic.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCDD_VALIDTNT"]);
                        txtMunicipalDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCDD_VALIDMUNICIPALLITYDATE"]);
                        txtColdstorage.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCDD_COLDSTORAGE"]);
                        if (ds.Tables[0].Rows[0]["SRVCDD_DRUGCATEGORY"].ToString().Contains("Specified in Schedules C and C(1)"))
                            CHKAuthorized.Items[0].Selected = true;
                        if (ds.Tables[0].Rows[0]["SRVCDD_DRUGCATEGORY"].ToString().Contains("Specified in Schedule X"))
                            CHKAuthorized.Items[1].Selected = true;
                        if (ds.Tables[0].Rows[0]["SRVCDD_DRUGCATEGORY"].ToString().Contains("Other than those specified in Schedule C, C(I) and X"))
                            CHKAuthorized.Items[2].Selected = true;

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GVPharmacist.DataSource = ds.Tables[1];
                        GVPharmacist.DataBind();
                        GVPharmacist.Visible = true;
                        ViewState["PharmacistDetails"] = ds.Tables[1];
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
        protected void rblSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblSelect.SelectedValue == "2")
                {
                    divPharmacist.Visible = true;
                    divCompetent.Visible = false;
                }
                else
                {
                    divCompetent.Visible = true;
                    divPharmacist.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rblApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblApplication.SelectedValue == "W")
                {
                    divWholesale.Visible = true;
                    divRetail.Visible = false;
                }
                else
                {
                    divRetail.Visible = true;
                    divWholesale.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CHKAuthorized_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListItem item1 = CHKAuthorized.Items.FindByValue("1");
                ListItem item3 = CHKAuthorized.Items.FindByValue("3");

                if (item1.Selected || item3.Selected)
                {
                    item1.Selected = true;
                    item3.Selected = true;
                }
                else
                {
                    item1.Selected = false;
                    item3.Selected = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnPharmacist_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNamePharma.Text) || string.IsNullOrWhiteSpace(txtRetailRegNo.Text) || string.IsNullOrWhiteSpace(txtDateValid.Text))
                {
                    lblmsg0.Text = "Please Enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = PharmacistDetails;

                DataRow dr = dt.NewRow();
                dr["SRVCDRD_NAMEPHARMACIST"] = txtNamePharma.Text.Trim();
                dr["SRVCDRD_REGISTRATIONNO"] = txtRetailRegNo.Text.Trim();
                dr["SRVCDRD_VALIDDATE"] = txtDateValid.Text.Trim();
                dt.Rows.Add(dr);

                PharmacistDetails = dt;

                GVPharmacist.Visible = true;
                GVPharmacist.DataSource = dt;
                GVPharmacist.DataBind();

                txtNamePharma.Text = "";
                txtRetailRegNo.Text = "";
                txtDateValid.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private DataTable PharmacistDetails
        {
            get
            {
                if (ViewState["PharmacistDetails"] == null)
                {
                    DataTable dt = new DataTable("Table1");
                    dt.Columns.Add("SRVCDRD_NAMEPHARMACIST", typeof(string));
                    dt.Columns.Add("SRVCDRD_REGISTRATIONNO", typeof(string));
                    dt.Columns.Add("SRVCDRD_VALIDDATE", typeof(string));

                    ViewState["PharmacistDetails"] = dt;
                }
                return (DataTable)ViewState["PharmacistDetails"];
            }
            set
            {
                ViewState["PharmacistDetails"] = value;
            }
        }
        private string GetPharmacistXML()
        {
            DataTable dt = PharmacistDetails;
            DataSet ds = new DataSet("Root");
            ds.Tables.Add(dt.Copy());

            using (StringWriter sw = new StringWriter())
            {
                ds.WriteXml(sw);
                return sw.ToString();
            }
        }
        protected void GVPharmacist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GVPharmacist.Rows[e.RowIndex].Cells[1].Text.Trim();

                SRVCDRUGDETAILS objDrug = new SRVCDRUGDETAILS();
                {
                    objDrug.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objDrug.RetailName = name;
                };
                string result = objSrvcbal.DeleteDrug(objDrug);

                DataTable dt = PharmacistDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                PharmacistDetails = dt;

                GVPharmacist.DataSource = dt;
                GVPharmacist.DataBind();
                GVPharmacist.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = Stepvalidations();
                if (ErrorMsg == "")
                {
                    SRVCDRUGDETAILS objDrug = new SRVCDRUGDETAILS();

                    DataTable dt = PharmacistDetails;
                    DataSet ds = new DataSet("Root");
                    ds.Tables.Add(dt.Copy());

                    string xmlData;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds.WriteXml(sw);
                        xmlData = sw.ToString();
                    }


                    {
                        objDrug.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objDrug.Createdby = "1001"; //hdnUserID.Value;
                        objDrug.IPAddress = getclientIP();
                        objDrug.XMLData = GetPharmacistXML();
                    };
                    result = objSrvcbal.InsertDrugRetailsDet(objDrug);


                    var selectedItems = CHKAuthorized.Items.Cast<ListItem>()
                            .Where(li => li.Selected)
                            .Select(li => li.Text);

                    string selectedActivities = string.Join(", ", selectedItems);


                    objDrug.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                    objDrug.Createdby = "1001"; //hdnUserID.Value;
                    objDrug.IPAddress = getclientIP();
                    objDrug.ApplicationType = rblApplication.SelectedValue;
                    objDrug.Select = rblSelect.SelectedValue;
                    objDrug.NameCompetent = txtCompetentName.Text;
                    objDrug.PharmacistDate = txtValidate.Text;
                    objDrug.PharmacistRegNo = txtRegNo.Text;
                    objDrug.ValidTNT = txttradeLic.Text;
                    objDrug.MunicipallityDate = txtMunicipalDate.Text;
                    objDrug.ColdStorage = txtColdstorage.Text;
                    objDrug.DrugsCategory = selectedActivities;


                    result = objSrvcbal.InsertSRVCDSrugDetails(objDrug);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = " Drug Details Submitted Successfully";
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
        public string Stepvalidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (rblApplication.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Application Type(H)...! \\n";
                    slno = slno + 1;
                }
                if (rblApplication.SelectedValue == "W")
                {
                    if (rblSelect.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Enter Please Select...! \\n";
                        slno = slno + 1;
                    }
                    if (rblSelect.SelectedValue == "1")
                    {
                        if (string.IsNullOrEmpty(txtCompetentName.Text) || txtCompetentName.Text == "" || txtCompetentName.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Name of the Pharmacist/Competent Person ...! \\n";
                            slno = slno + 1;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtValidate.Text) || txtValidate.Text == "" || txtValidate.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Valid up to date...! \\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtRegNo.Text) || txtRegNo.Text == "" || txtRegNo.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Registration No ...! \\n";
                            slno = slno + 1;
                        }
                    }

                }
                else
                {

                }
                if (string.IsNullOrEmpty(txttradeLic.Text) || txttradeLic.Text == "" || txttradeLic.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Valid up to date Trading License(TNT)...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMunicipalDate.Text) || txtMunicipalDate.Text == "" || txtMunicipalDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Valid up to date permission from Municipallity ...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtColdstorage.Text) || txtColdstorage.Text == "" || txtColdstorage.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Particulars of cold storage...! \\n";
                    slno = slno + 1;
                }
                if (CHKAuthorized.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Drugs Categories...!  \\n";
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
    }
}