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
    public partial class SRVCLegalMeterology42 : System.Web.UI.Page
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
                ds = objSrvcbal.GetSRVCLegalMetrologyDet115(hdnUserID.Value, Convert.ToString(Session["SRVCQID"]));

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtValidate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblFactRegNo.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblFactRegNo_SelectedIndexChanged(null, EventArgs.Empty);
                        txtRegDate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtRegNumber.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        //if (rblFactRegNo.SelectedValue == "Y")
                        //{
                        //    divRegistration.Visible = true;                           
                        //}
                        //else
                        //{
                        //    divRegistration.Visible = false;
                        //}
                        rblLicADC.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblLicADC_SelectedIndexChanged(null, EventArgs.Empty);
                        txtDateReg.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtCurrentRegNo.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        //if (rblLicADC.SelectedValue == "Y")
                        //{
                        //    divDateReg.Visible = true;
                        //    divCutRegNo.Visible = true;

                        //}
                        //else
                        //{
                        //    divDateReg.Visible = false;
                        //    divCutRegNo.Visible = false;
                        //}
                        rblpartnership.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblpartnership_SelectedIndexChanged(null, EventArgs.Empty);
                        //if (rblpartnership.SelectedValue == "Y")
                        //{
                        //    divpartnership.Visible = true;
                        //}
                        //else { divpartnership.Visible = false; }

                        rblcompany.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblcompany_SelectedIndexChanged(null, EventArgs.Empty);
                        //if (rblcompany.SelectedValue == "Y")
                        //{
                        //    divcompany.Visible = true;
                        //}
                        //else { divcompany.Visible = false; }

                        txtWeights.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtMeasures.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtWeight.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtRegNo.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtGST.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtITNo.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblState_SelectedIndexChanged(null, EventArgs.Empty);
                        txtLICNumber.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtRegWeight.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);

                        //if (rblState.SelectedValue == "Y")
                        //{
                        //    divLicNo.Visible = true;
                        //    divWeight.Visible = true;

                        //}
                        //else 
                        //{
                        //    divLicNo.Visible = false;
                        //    divWeight.Visible = false;
                        //}

                        rblDealer.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblDealer_SelectedIndexChanged(null, EventArgs.Empty);
                        txtGiveDetails.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GVpartners.DataSource = ds.Tables[1];
                        GVpartners.DataBind();
                        GVpartners.Visible = true;
                        ViewState["PartnersDetails"] = ds.Tables[1];
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[2];
                        ViewState["ManagerDetails"] = dt;
                        GVManaging.Visible = true;
                        GVManaging.DataSource = dt;
                        GVManaging.DataBind();
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[3];
                        ViewState["InstrumentDetails"] = dt;
                        GVLegalDept.Visible = true;
                        GVLegalDept.DataSource = dt;
                        GVLegalDept.DataBind();
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
        protected void rblState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblState.SelectedValue == "Y")
            {
                divLicNo.Visible = true;
                divWeight.Visible = true;
            }
            else
            {
                divLicNo.Visible = false;
                divWeight.Visible = false;
            }
        }
        protected void rblDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblDealer.SelectedValue == "Y")
            {
                divDealerLic.Visible = true;
            }
            else { divDealerLic.Visible = false; }
        }
        protected void rblpartnership_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblpartnership.SelectedValue=="Y")
            {
                divpartnership.Visible = true;
            }
            else { divpartnership.Visible = false; }
        }
        protected void rblcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblcompany.SelectedValue == "Y")
            {
                divcompany.Visible = true;
            }
            else { divcompany.Visible = false; }
        }
        protected void rblLicADC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblLicADC.SelectedValue=="Y")
            {
                divDateReg.Visible = true;
                divCutRegNo.Visible = true;
            }
            else 
            { 
                divDateReg.Visible = false;
                divCutRegNo.Visible = false;
            }
        }
        protected void rblFactRegNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblFactRegNo.SelectedValue=="Y")
            {
                divRegistration.Visible = true;
            }
            else { divRegistration.Visible = false; }
        }
        protected void btnAddPartners_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPartnerAddress.Text) || string.IsNullOrWhiteSpace(txtPartnermName.Text))
                {
                    lblmsg0.Text = "Please enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = PartnersDetails;

                DataRow dr = dt.NewRow();
                dr[""] = txtPartnermName.Text.Trim();
                dr[""] = txtPartnerAddress.Text.Trim();
                dt.Rows.Add(dr);

                PartnersDetails = dt;

                GVpartners.Visible = true;
                GVpartners.DataSource = dt;
                GVpartners.DataBind();

                txtPartnermName.Text = "";
                txtPartnerAddress.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private DataTable PartnersDetails
        {
            get
            {
                if (ViewState["PartnersDetails"] == null)
                {
                    DataTable dt = new DataTable("Table1");
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    ViewState["PartnersDetails"] = dt;
                }
                return (DataTable)ViewState["PartnersDetails"];
            }
            set
            {
                ViewState["PartnersDetails"] = value;
            }
        }
        private string GetDirectorXML()
        {
            DataTable dt = PartnersDetails;
            DataSet ds = new DataSet("Root");
            ds.Tables.Add(dt.Copy());

            using (StringWriter sw = new StringWriter())
            {
                ds.WriteXml(sw);
                return sw.ToString();
            }
        }
        protected void GVpartners_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GVpartners.Rows[e.RowIndex].Cells[1].Text.Trim();

                SRVCLegalMetrology115 objLegal = new SRVCLegalMetrology115();
                {
                    objLegal.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objLegal.Namepartner = name;
                };
                string result = objSrvcbal.DeletePatnerDet(objLegal);

                DataTable dt = PartnersDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                PartnersDetails = dt;

                GVpartners.DataSource = dt;
                GVpartners.DataBind();
                GVpartners.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void btnManager_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtManagerName.Text) ||string.IsNullOrWhiteSpace(txtManagerAddress.Text))
                {
                    lblmsg0.Text = "Please enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = ManagerDetails;

                DataRow dr = dt.NewRow();
                dr[""] = txtManagerName.Text.Trim();
                dr[""] = txtManagerAddress.Text.Trim();
                dt.Rows.Add(dr);

                ManagerDetails = dt;

                GVManaging.Visible = true;
                GVManaging.DataSource = dt;
                GVManaging.DataBind();

                txtManagerName.Text = "";
                txtManagerAddress.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private DataTable ManagerDetails
        {
            get
            {
                if (ViewState["ManagerDetails"] == null)
                {
                    DataTable dt = new DataTable("Table1");
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    ViewState["ManagerDetails"] = dt;
                }
                return (DataTable)ViewState["ManagerDetails"];
            }
            set
            {
                ViewState["ManagerDetails"] = value;
            }
        }
        private string GetManagerXML()
        {
            DataTable dt = ManagerDetails;
            DataSet ds = new DataSet("Root");
            ds.Tables.Add(dt.Copy());

            using (StringWriter sw = new StringWriter())
            {
                ds.WriteXml(sw);
                return sw.ToString();
            }
        }
        protected void GVManaging_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GVManaging.Rows[e.RowIndex].Cells[1].Text.Trim();

                SRVCLegalMetrology115 objLegal = new SRVCLegalMetrology115();
                {
                    objLegal.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objLegal.NameManaging = name;
                };
                string result = objSrvcbal.DeleteLegalManagerDetails(objLegal);

                DataTable dt = ManagerDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                ManagerDetails = dt;

                GVManaging.DataSource = dt;
                GVManaging.DataBind();
                GVManaging.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void btnAddDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtinstrment.Text) || string.IsNullOrWhiteSpace(txtClass.Text)||string.IsNullOrWhiteSpace(txtCapacity.Text)||
                    string.IsNullOrWhiteSpace(txtMake.Text) || string.IsNullOrWhiteSpace(txtModel.Text) || string.IsNullOrWhiteSpace(txtSerial.Text)||
                    string.IsNullOrWhiteSpace(txtProduct.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text))
                {
                    lblmsg0.Text = "Please enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = InstrumentDetails;

                DataRow dr = dt.NewRow();
                dr[""] = txtinstrment.Text.Trim();
                dr[""] = txtClass.Text.Trim();
                dr[""] = txtCapacity.Text.Trim();
                dr[""] = txtMake.Text.Trim();
                dr[""] = txtModel.Text.Trim();
                dr[""] = txtSerial.Text.Trim();
                dr[""] = txtProduct.Text.Trim();
                dr[""] = txtQuantity.Text.Trim();
                dt.Rows.Add(dr);

                InstrumentDetails = dt;

                GVLegalDept.Visible = true;
                GVLegalDept.DataSource = dt;
                GVLegalDept.DataBind();

                txtinstrment.Text = "";
                txtClass.Text = "";
                txtCapacity.Text = "";
                txtMake.Text = "";
                txtModel.Text = "";
                txtSerial.Text = "";
                txtProduct.Text = "";
                txtQuantity.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private DataTable InstrumentDetails
        {
            get
            {
                if (ViewState["InstrumentDetails"] == null)
                {
                    DataTable dt = new DataTable("Table1");
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    ViewState["InstrumentDetails"] = dt;
                }
                return (DataTable)ViewState["InstrumentDetails"];
            }
            set
            {
                ViewState["InstrumentDetails"] = value;
            }
        }
        protected void GVLegalDept_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GVLegalDept.Rows[e.RowIndex].Cells[1].Text.Trim();

                SRVCLegalMetrology115 objLegal = new SRVCLegalMetrology115();
                {
                    objLegal.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objLegal.Instrumenttype = name;
                };
                string result = objSrvcbal.DeleteLegalInstrumentDetails(objLegal);

                DataTable dt = InstrumentDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                InstrumentDetails = dt;

                GVLegalDept.DataSource = dt;
                GVLegalDept.DataBind();
                GVLegalDept.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        private string GetInstrumentXML()
        {
            DataTable dt = InstrumentDetails;
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
                ErrorMsg = stepValidations();
                if (ErrorMsg == "")
                {
                    SRVCLegalMetrology115 objLegal = new SRVCLegalMetrology115();

                    DataTable dt = PartnersDetails;
                    DataSet ds = new DataSet("Root");
                    ds.Tables.Add(dt.Copy());

                    string xmlData;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds.WriteXml(sw);
                        xmlData = sw.ToString();
                    }


                    {
                        objLegal.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objLegal.Createdby = "1001"; //hdnUserID.Value;
                        objLegal.IPAddress = getclientIP();
                        objLegal.XMLData = GetDirectorXML();
                    };
                    result = objSrvcbal.InsertLeaglPartnersDet(objLegal);


                    DataTable dt1 = ManagerDetails;
                    DataSet ds1 = new DataSet("Root");
                    ds1.Tables.Add(dt1.Copy());

                    string xmlData1;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds.WriteXml(sw);
                        xmlData1 = sw.ToString();
                    }


                    {
                        objLegal.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objLegal.Createdby = "1001"; //hdnUserID.Value;
                        objLegal.IPAddress = getclientIP();
                        objLegal.XMLData = GetManagerXML();
                    };
                    result = objSrvcbal.InsertLegalManagerDet(objLegal);


                    DataTable dt2 = InstrumentDetails;
                    DataSet ds2 = new DataSet("Root");
                    ds2.Tables.Add(dt2.Copy());

                    string xmlData2;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds.WriteXml(sw);
                        xmlData2 = sw.ToString();
                    }


                    {
                        objLegal.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objLegal.Createdby = "1001"; //hdnUserID.Value;
                        objLegal.IPAddress = getclientIP();
                        objLegal.XMLData = GetInstrumentXML();
                    };
                    result = objSrvcbal.InsertLegalInstrumentDetails(objLegal);



                    objLegal.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                    objLegal.Createdby = "1001"; //hdnUserID.Value;
                    objLegal.IPAddress = getclientIP();
                    objLegal.Dateestablishment = txtValidate.Text;
                    objLegal.RegFactoryEst = rblFactRegNo.SelectedValue;
                    objLegal.ShopRegDate = txtRegDate.Text;
                    objLegal.ShopCurrentRegNo = txtRegNumber.Text;
                    objLegal.RegNoADC = rblLicADC.SelectedValue;
                    objLegal.ADCDateReg = txtDateReg.Text;
                    objLegal.ADCCurrentRegNo = txtCurrentRegNo.Text;
                    objLegal.partnershipfirm = rblpartnership.SelectedValue;
                    objLegal.limitedcompany = rblcompany.SelectedValue;
                    objLegal.Weights = txtWeights.Text;
                    objLegal.Measures = txtMeasures.Text;
                    objLegal.WeightingInstrument = txtWeight.Text;
                    objLegal.ProfessionalTaxReg = txtRegNo.Text;
                    objLegal.GST = txtGST.Text;
                    objLegal.ITNumber = txtITNo.Text;
                    objLegal.State = rblState.SelectedValue;
                    objLegal.LicNo = txtLICNumber.Text;
                    objLegal.RegWeightMeasure = txtRegWeight.Text;
                    objLegal.DealerLic = rblDealer.SelectedValue;
                    objLegal.GiveDetails = txtGiveDetails.Text;                   

                    result = objSrvcbal.INSSRVCLegalMetrologyDetails(objLegal);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "LegalMetrology Details Submitted Successfully";
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
        public string stepValidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
               
                if (string.IsNullOrEmpty(txtValidate.Text) || txtValidate.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Date of establishment...! \\n";
                    slno++;
                }
                if (rblFactRegNo.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select registration number of factory/ shop/ establishment? \\n";
                    slno = slno + 1;
                }
                if (rblFactRegNo.SelectedValue=="Y")
                {
                    if (string.IsNullOrEmpty(txtRegDate.Text) || txtRegDate.Text.Trim() == "")
                    {
                        errormsg += slno + ". Please enter Date of registration(w) ...! \\n";
                        slno++;
                    }
                    if (string.IsNullOrEmpty(txtRegNumber.Text) || txtRegNumber.Text.Trim() == "" || txtRegNumber.Text == null)
                    {
                        errormsg += slno + ". Please enter Current registration number(w)...! \\n";
                        slno++;
                    }
                }
                if (rblLicADC.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select registration number of Municipal Trade licence/ADC? \\n";
                    slno = slno + 1;
                }
                if (rblLicADC.SelectedValue=="Y")
                {
                    if (string.IsNullOrEmpty(txtDateReg.Text) || txtDateReg.Text.Trim() == "" || txtDateReg.Text == null)
                    {
                        errormsg += slno + ". Please enter Date of registration...! \\n";
                        slno++;
                    }
                    if (string.IsNullOrEmpty(txtCurrentRegNo.Text) || txtCurrentRegNo.Text.Trim() == "" || txtCurrentRegNo.Text == null)
                    {
                        errormsg += slno + ". Please enter Current registration number(w) ...! \\n";
                        slno++;
                    }
                }
                if (string.IsNullOrEmpty(txtWeight.Text) || txtWeight.Text.Trim() == "" || txtWeight.Text == null)
                {
                    errormsg += slno + ". Please enter Weights...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtMeasures.Text) || txtMeasures.Text.Trim() == "" || txtMeasures.Text == null)
                {
                    errormsg += slno + ". Please enter Measures...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtWeight.Text) || txtWeight.Text.Trim() == "" || txtWeight.Text == null)
                {
                    errormsg += slno + ". Please enter txtInstruWeight...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtRegNo.Text) || txtRegNo.Text.Trim() == "" || txtRegNo.Text == null)
                {
                    errormsg += slno + ". Please enter Professional Tax registration Number...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtGST.Text) || txtGST.Text.Trim() == "" || txtGST.Text == null)
                {
                    errormsg += slno + ". Please enter GST...! \\n";
                    slno++;
                }

                if (string.IsNullOrEmpty(txtITNo.Text) || txtITNo.Text.Trim() == "" || txtITNo.Text == null)
                {
                    errormsg += slno + ". Please enter IT Number...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtRegNumber.Text) || txtRegNumber.Text.Trim() == "" || txtRegNumber.Text == null)
                {
                    errormsg += slno + ". Please enter Current registration number(w) ...! \\n";
                    slno++;
                }
                if (rblState.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select from places outside the State/Country?....! \\n";
                    slno = slno + 1;
                }
                if (rblState.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtLICNumber.Text) || txtLICNumber.Text.Trim() == "" || txtLICNumber.Text == null)
                    {
                        errormsg += slno + ". Please enter Licence number ...! \\n";
                        slno++;
                    }
                    if (string.IsNullOrEmpty(txtRegWeight.Text) || txtRegWeight.Text.Trim() == "" || txtRegWeight.Text == null)
                    {
                        errormsg += slno + ". Please enter Registration of Importer of Weights and Measures ...! \\n";
                        slno++;
                    }
                }
                if (rblDealer.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select licence,either in this State or elsewhere ?...! \\n";
                    slno = slno + 1;
                }
                if (rblDealer.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtGiveDetails.Text) || txtGiveDetails.Text.Trim() == "" || txtGiveDetails.Text == null)
                    {
                        errormsg += slno + ". Please enter Give details...! \\n";
                        slno++;
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