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
    public partial class SRVCExcise : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string ErrorMsg = "", result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountries();
                BindData();
            }
        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objSrvcbal.GetSRVCExciseDet(hdnUserID.Value, Convert.ToString(Session["SRVCQID"]));

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                       
                        rblBrand.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCED_APPLYREGBIOBRAND"]);
                        rblBrand_SelectedIndexChanged(null, EventArgs.Empty);

                        if (rblBrand.SelectedValue=="Y")
                        {
                            divBrands.Visible = true;
                            divTodateReg.Visible = true;
                            txtFromDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCED_FROMDATE"]);
                            txtTodate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCED_TODATE"]);
                            txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCED_NAMEADDRESS"]);
                        }
                        else
                        {
                            divBrands.Visible = false;
                            divTodateReg.Visible = false;
                        }


                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GVBrand.DataSource = ds.Tables[1];
                        GVBrand.DataBind();
                        GVBrand.Visible = true;
                        ViewState["BrandDetails"] = ds.Tables[1];
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[2];
                        ViewState["CountryDetails"] = dt;
                        GvLiquor.Visible = true;
                        GvLiquor.DataSource = dt;
                        GvLiquor.DataBind();
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[3];
                        ViewState["AimDetails"] = dt;
                        GVAIM.Visible = true;
                        GVAIM.DataSource = dt;
                        GVAIM.DataBind();
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[4];
                        ViewState["MemberDetails"] = dt;
                        GVMember.Visible = true;
                        GVMember.DataSource = dt;
                        GVMember.DataBind();
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
        protected void rblBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblBrand.SelectedValue == "Y")
                {
                    divBrands.Visible = true;
                    divTodateReg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rblMRPRS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblBIOBrand.SelectedValue == "Y")
                {
                    MRPGRID.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindCountries()
        {
            try
            {
                ddlCountry.Items.Clear();

                List<MasterCountry> objCoutryModel = new List<MasterCountry>();

                objCoutryModel = mstrBAL.GetCountries();
                if (objCoutryModel != null)
                {
                    ddlCountry.DataSource = objCoutryModel;
                    ddlCountry.DataValueField = "CountryId";
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataBind();
                }
                else
                {
                    ddlCountry.DataSource = null;
                    ddlCountry.DataBind();
                }
                AddSelect(ddlCountry);
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

        protected void btnBrand_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNameBrand.Text) || string.IsNullOrWhiteSpace(txtStrength.Text) || string.IsNullOrWhiteSpace(txtSize.Text) ||
                    string.IsNullOrWhiteSpace(txtBottle.Text) || string.IsNullOrWhiteSpace(txtMRP.Text) || string.IsNullOrWhiteSpace(txtBulkLiter.Text) ||
                    string.IsNullOrWhiteSpace(txtLandonProof.Text) || string.IsNullOrWhiteSpace(txtBottlePlant.Text))
                {
                    lblmsg0.Text = "Please Enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = BrandDetails;

                DataRow dr = dt.NewRow();
                dr["SRVCEBD_NAMEOFBRAND"] = txtNameBrand.Text.Trim();
                dr["SRVCEBD_STRENGTH"] = txtStrength.Text.Trim();
                dr["SRVCEBD_SIZE"] = txtSize.Text.Trim();
                dr["SRVCEBD_NUMBEROFBOTTLES"] = txtBottle.Text.Trim();
                dr["SRVCEBD_MRPRS"] = txtMRP.Text.Trim();
                dr["SRVCEBD_BULKLITER"] = txtBulkLiter.Text.Trim();
                dr["SRVCEBD_LANDONPROOF"] = txtLandonProof.Text.Trim();
                dr["SRVCEBD_BOTTLEPLANT"] = txtBottlePlant.Text.Trim();
                dt.Rows.Add(dr);

                BrandDetails = dt;

                GVBrand.Visible = true;
                GVBrand.DataSource = dt;
                GVBrand.DataBind();

                txtNameBrand.Text = "";
                txtStrength.Text = "";
                txtSize.Text = "";
                txtBottle.Text = "";
                txtMRP.Text = "";
                txtBulkLiter.Text = "";
                txtLandonProof.Text = "";
                txtBottlePlant.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private DataTable BrandDetails
        {
            get
            {
                if (ViewState["BrandDetails"] == null)
                {
                    DataTable dt = new DataTable("Table1");
                    dt.Columns.Add("SRVCEBD_NAMEOFBRAND", typeof(string));
                    dt.Columns.Add("SRVCEBD_STRENGTH", typeof(string));
                    dt.Columns.Add("SRVCEBD_SIZE", typeof(string));
                    dt.Columns.Add("SRVCEBD_NUMBEROFBOTTLES", typeof(string));
                    dt.Columns.Add("SRVCEBD_MRPRS", typeof(string));
                    dt.Columns.Add("SRVCEBD_BULKLITER", typeof(string));
                    dt.Columns.Add("SRVCEBD_LANDONPROOF", typeof(string));
                    dt.Columns.Add("SRVCEBD_BOTTLEPLANT", typeof(string));

                    ViewState["BrandDetails"] = dt;
                }
                return (DataTable)ViewState["BrandDetails"];
            }
            set
            {
                ViewState["BrandDetails"] = value;
            }
        }
        private string GetBrandXML()
        {
            DataTable dt = BrandDetails;
            DataSet ds = new DataSet("Root");
            ds.Tables.Add(dt.Copy());

            using (StringWriter sw = new StringWriter())
            {
                ds.WriteXml(sw);
                return sw.ToString();
            }
        }
        protected void GVBrand_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GVBrand.Rows[e.RowIndex].Cells[1].Text.Trim();

                SRVCEXICEBRAND objBrand = new SRVCEXICEBRAND();
                {
                    objBrand.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objBrand.NameBrand = name;
                };
                string result = objSrvcbal.DeleteBrand(objBrand);

                DataTable dt = BrandDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                BrandDetails = dt;

                GVBrand.DataSource = dt;
                GVBrand.DataBind();
                GVBrand.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void BtnCountry_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ddlCountry.SelectedValue) || string.IsNullOrWhiteSpace(rblBIOBrand.SelectedValue) || string.IsNullOrWhiteSpace(txtBrandName.Text))
                {
                    lblmsg0.Text = "Please Enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = CountryDetails;

                DataRow dr = dt.NewRow();
                dr["SRVCELD_COUNTRYID"] = ddlCountry.SelectedValue;
                dr["SRVCELD_APPLYREGBIOBRAND"] = rblBIOBrand.SelectedValue;
                dr["SRVCELD_BRANDNAME"] = txtBrandName.Text.Trim();
                dt.Rows.Add(dr);

                CountryDetails = dt;

                GvLiquor.Visible = true;
                GvLiquor.DataSource = dt;
                GvLiquor.DataBind();

                ddlCountry.ClearSelection();
                rblBIOBrand.ClearSelection();
                txtBrandName.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private DataTable CountryDetails
        {
            get
            {
                if (ViewState["CountryDetails"] == null)
                {
                    DataTable dt = new DataTable("Table2");
                    dt.Columns.Add("SRVCELD_COUNTRYID", typeof(string));
                    dt.Columns.Add("SRVCELD_APPLYREGBIOBRAND", typeof(string));
                    dt.Columns.Add("SRVCELD_BRANDNAME", typeof(string));                   

                    ViewState["CountryDetails"] = dt;
                }
                return (DataTable)ViewState["CountryDetails"];
            }
            set
            {
                ViewState["CountryDetails"] = value;
            }
        }
        protected void GvLiquor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GvLiquor.Rows[e.RowIndex].Cells[1].Text.Trim();

                SRVCEXICEBRAND objBrand = new SRVCEXICEBRAND();
                {
                    objBrand.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objBrand.Country = name;
                };
                string result = objSrvcbal.DeleteCountry(objBrand);

                DataTable dt = CountryDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                CountryDetails = dt;

                GvLiquor.DataSource = dt;
                GvLiquor.DataBind();
                GvLiquor.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        private string GetCountryXML()
        {
            DataTable dt = CountryDetails;
            DataSet ds = new DataSet("Root");
            ds.Tables.Add(dt.Copy());

            using (StringWriter sw = new StringWriter())
            {
                ds.WriteXml(sw);
                return sw.ToString();
            }
        }
        protected void btnAim_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAim.Text) || string.IsNullOrWhiteSpace(txtObject.Text))
                {
                    lblmsg0.Text = "Please Enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = AIMDetails;

                DataRow dr = dt.NewRow();
                dr["SRVCAD_AIM"] = txtAim.Text.Trim();
                dr["SRVCAD_OBJECT"] = txtObject.Text.Trim();
                dt.Rows.Add(dr);

                AIMDetails = dt;

                GVAIM.Visible = true;
                GVAIM.DataSource = dt;
                GVAIM.DataBind();

                txtAim.Text = "";
                txtObject.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private DataTable AIMDetails
        {
            get
            {
                if (ViewState["AimDetails"] == null)
                {
                    DataTable dt = new DataTable("Table1");
                    dt.Columns.Add("SRVCAD_AIM", typeof(string));
                    dt.Columns.Add("SRVCAD_OBJECT", typeof(string));

                    ViewState["AimDetails"] = dt;
                }
                return (DataTable)ViewState["AimDetails"];
            }
            set
            {
                ViewState["AimDetails"] = value;
            }
        }
        protected void GVAIM_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GVAIM.Rows[e.RowIndex].Cells[1].Text.Trim();

                SRVCEXICEBRAND objBrand = new SRVCEXICEBRAND();
                {
                    objBrand.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objBrand.AIM = name;
                };
                string result = objSrvcbal.DeleteAIM(objBrand);

                DataTable dt = AIMDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                AIMDetails = dt;

                GVAIM.DataSource = dt;
                GVAIM.DataBind();
                GVAIM.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        private string GetAIMXML()
        {
            DataTable dt = AIMDetails;
            DataSet ds = new DataSet("Root");
            ds.Tables.Add(dt.Copy());

            using (StringWriter sw = new StringWriter())
            {
                ds.WriteXml(sw);
                return sw.ToString();
            }
        }
        protected void btnMembers_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtDesignation.Text) || string.IsNullOrWhiteSpace(txtOccupation.Text) ||
                    string.IsNullOrWhiteSpace(txtAddressEPIC.Text) || string.IsNullOrWhiteSpace(txtState.Text) || string.IsNullOrWhiteSpace(txtDistrict.Text) ||
                    string.IsNullOrWhiteSpace(txtMobileno.Text))
                {
                    lblmsg0.Text = "Please enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = MemberDetails;

                DataRow dr = dt.NewRow();
                dr["SRVCEMD_NAME"] = txtName.Text.Trim();
                dr["SRVCEMD_DESIGNATION"] = txtDesignation.Text.Trim();
                dr["SRVCEMD_OCCUPATION"] = txtOccupation.Text.Trim();
                dr["SRVCEMD_ADDRESS"] = txtAddressEPIC.Text.Trim();
                dr["SRVCEMD_STATE"] = txtState.Text.Trim();
                dr["SRVCEMD_DISTRICT"] = txtDistrict.Text.Trim();
                dr["SRVCEMD_MOBILENO"] = txtMobileno.Text.Trim();
                dt.Rows.Add(dr);

                MemberDetails = dt;

                GVMember.Visible = true;
                GVMember.DataSource = dt;
                GVMember.DataBind();

                txtName.Text = "";
                txtDesignation.Text = "";
                txtOccupation.Text = "";
                txtAddressEPIC.Text = "";
                txtState.Text = "";
                txtDistrict.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private DataTable MemberDetails
        {
            get
            {
                if (ViewState["MemberDetails"] == null)
                {
                    DataTable dt = new DataTable("Table1");
                    dt.Columns.Add("SRVCEMD_NAME", typeof(string));
                    dt.Columns.Add("SRVCEMD_DESIGNATION", typeof(string));
                    dt.Columns.Add("SRVCEMD_OCCUPATION", typeof(string));
                    dt.Columns.Add("SRVCEMD_ADDRESS", typeof(string));
                    dt.Columns.Add("SRVCEMD_STATE", typeof(string));
                    dt.Columns.Add("SRVCEMD_DISTRICT", typeof(string));
                    dt.Columns.Add("SRVCEMD_MOBILENO", typeof(string));

                    ViewState["MemberDetails"] = dt;
                }
                return (DataTable)ViewState["MemberDetails"];
            }
            set
            {
                ViewState["MemberDetails"] = value;
            }
        }
        protected void GVMember_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GVMember.Rows[e.RowIndex].Cells[1].Text.Trim();

                SRVCEXICEBRAND objBrand = new SRVCEXICEBRAND();
                {
                    objBrand.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objBrand.MemberName = name;
                };
                string result = objSrvcbal.DeleteMemberDet(objBrand);

                DataTable dt = MemberDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                MemberDetails = dt;

                GVMember.DataSource = dt;
                GVMember.DataBind();
                GVMember.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        private string GetMembersXML()
        {
            DataTable dt = MemberDetails;
            DataSet ds = new DataSet("Root");
            ds.Tables.Add(dt.Copy());

            using (StringWriter sw = new StringWriter())
            {
                ds.WriteXml(sw);
                return sw.ToString();
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = Stepvalidations();
                if (ErrorMsg == "")
                {
                    SRVCEXICEBRAND objBrand = new SRVCEXICEBRAND();

                    DataTable dt = BrandDetails;
                    DataSet ds = new DataSet("Root");
                    ds.Tables.Add(dt.Copy());

                    string xmlData;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds.WriteXml(sw);
                        xmlData = sw.ToString();
                    }

                   
                    {
                        objBrand.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objBrand.Createdby = "1001"; //hdnUserID.Value;
                        objBrand.IPAddress = getclientIP();
                        objBrand.XMLData = GetBrandXML();
                    };
                    result = objSrvcbal.InsertBrand(objBrand);



                    DataTable dt1 = CountryDetails;
                    DataSet ds1 = new DataSet("Root");
                    ds1.Tables.Add(dt1.Copy());

                    string xmlData1;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds1.WriteXml(sw);
                        xmlData1 = sw.ToString();
                    }

                    {
                        objBrand.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objBrand.Createdby = "1001"; //hdnUserID.Value;
                        objBrand.IPAddress = getclientIP();
                        objBrand.XMLData = GetCountryXML();
                    };
                    result = objSrvcbal.InsertCountry(objBrand);



                    DataTable dt2 = AIMDetails;
                    DataSet ds2 = new DataSet("Root");
                    ds2.Tables.Add(dt2.Copy());

                    string xmlData2;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds2.WriteXml(sw);
                        xmlData2 = sw.ToString();
                    }

                    {
                        objBrand.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objBrand.Createdby = "1001"; //hdnUserID.Value;
                        objBrand.IPAddress = getclientIP();
                        objBrand.XMLData = GetAIMXML();
                    };
                    result = objSrvcbal.InsertAimDetails(objBrand);



                    DataTable dt3 = MemberDetails;
                    DataSet ds3 = new DataSet("Root");
                    ds3.Tables.Add(dt3.Copy());

                    string xmlData3;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds3.WriteXml(sw);
                        xmlData3 = sw.ToString();
                    }

                    {
                        objBrand.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objBrand.Createdby = "1001"; //hdnUserID.Value;
                        objBrand.IPAddress = getclientIP();
                        objBrand.XMLData = GetMembersXML();
                    };
                    result = objSrvcbal.InsertMembersDetails(objBrand);


                    objBrand.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                    objBrand.Createdby = "1001"; //hdnUserID.Value;
                    objBrand.IPAddress = getclientIP();
                    objBrand.RENBIOBrand = rblBrand.SelectedValue;
                    objBrand.RegFromDate = txtFromDate.Text;
                    objBrand.ToDate = txtTodate.Text;
                    objBrand.NameaddressFirm = txtAddress.Text;

                     result = objSrvcbal.InsertSRVCExciseDetails(objBrand);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = " Excise Details Submitted Successfully";
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
               
                if (rblBrand.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Applying for Renewal of BIO Brands?...! \\n";
                    slno = slno + 1;
                }
                if (rblBrand.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtFromDate.Text) || txtFromDate.Text == "" || txtFromDate.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Original Year of Registration- From Date...! \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtTodate.Text) || txtTodate.Text == "" || txtTodate.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter To Date ...! \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text == "" || txtAddress.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Name and address of the Firm ...! \\n";
                        slno = slno + 1;
                    }
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