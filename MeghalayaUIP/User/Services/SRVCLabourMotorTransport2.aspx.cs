using iTextSharp.tool.xml.parser.state;
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
using static AjaxControlToolkit.AsyncFileUpload.Constants;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCLabourMotorTransport2 : System.Web.UI.Page
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
                ds = objSrvcbal.GetSRVCLabourMotor(hdnUserID.Value, Convert.ToString(Session["SRVCQID"]));

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtNatureMotor.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLM_NATUREMOTORTRANSPORT"]);
                        txtTotalNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLM_TOTALNOROUTE"]);
                        txtTotalRoute.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLM_TOTALMILEAGE"]);
                        txtTotalNoMotor.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLM_TOTALNOVEHICLE"]);
                        txtMaxNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLM_MAXNOEMPWORK"]);
                        rblTransport.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLM_TYPETRANSPORT"]);
                        rblTransport_SelectedIndexChanged(null, EventArgs.Empty);

                        if (rblTransport.SelectedValue == "1")
                        {
                            divProprietorship.Visible = true;
                            txtProName.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLM_PROPNAME"]);
                            txtProAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLM_PROPADDRESS"]);
                        }
                        else if (rblTransport.SelectedValue == "2")
                        {
                            divContrLabr.Visible = true;
                        }
                        else if (rblTransport.SelectedValue == "3")
                        {
                            divCompanies1956.Visible = true;
                        }
                        else if (rblTransport.SelectedValue == "4")
                        {
                            divUndertaking.Visible = true;
                            txtSectorName.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLM_SECTORNAME"]);
                            txtSectorAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLM_SECTORADDRESS"]);
                        }

                        txtVehicleNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLM_VEHICLENO"]);
                        txtTypeVehicle.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLM_TYPEVEHICLE"]);

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GVPartnership.DataSource = ds.Tables[1];
                        GVPartnership.DataBind();
                        GVPartnership.Visible = true;
                        ViewState["PartnerDetails"] = ds.Tables[1];
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[2];
                        ViewState["DirectorDetails"] = dt;
                        GVDirector.Visible = true;
                        GVDirector.DataSource = dt;
                        GVDirector.DataBind();
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
        protected void rblTransport_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblTransport.SelectedValue == "1")
                {
                    divProprietorship.Visible = true;
                    divContrLabr.Visible = false;
                    divCompanies1956.Visible = false;
                    divUndertaking.Visible = false;
                }
                else if (rblTransport.SelectedValue == "2")
                {
                    divContrLabr.Visible = true;
                    divProprietorship.Visible = false;
                    divCompanies1956.Visible = false;
                    divUndertaking.Visible = false;
                }
                else if (rblTransport.SelectedValue == "3")
                {
                    divCompanies1956.Visible = true;
                    divProprietorship.Visible = false;
                    divContrLabr.Visible = false;
                    divUndertaking.Visible = false;
                }
                else if (rblTransport.SelectedValue == "4")
                {
                    divUndertaking.Visible = true;
                    divProprietorship.Visible = false;
                    divContrLabr.Visible = false;
                    divCompanies1956.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private DataTable PartnerDetails
        {
            get
            {
                if (ViewState["PartnerDetails"] == null)
                {
                    DataTable dt = new DataTable("Table1");
                    dt.Columns.Add("SRVCPD_FULLNAME", typeof(string));
                    dt.Columns.Add("SRVCPD_RESIDENTIALADDRESS", typeof(string));
                    ViewState["PartnerDetails"] = dt;
                }
                return (DataTable)ViewState["PartnerDetails"];
            }
            set
            {
                ViewState["PartnerDetails"] = value;
            }
        }
        protected void Addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNameAddress.Text) ||
                    string.IsNullOrWhiteSpace(txtLocation.Text))
                {
                    lblmsg0.Text = "Please enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = PartnerDetails;

                DataRow dr = dt.NewRow();
                dr["SRVCPD_FULLNAME"] = txtNameAddress.Text.Trim();
                dr["SRVCPD_RESIDENTIALADDRESS"] = txtLocation.Text.Trim();
                dt.Rows.Add(dr);

                PartnerDetails = dt;

                GVPartnership.Visible = true;
                GVPartnership.DataSource = dt;
                GVPartnership.DataBind();

                txtNameAddress.Text = "";
                txtLocation.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        private string GetPartnersXML()
        {
            DataTable dt = PartnerDetails;
            DataSet ds = new DataSet("Root");
            ds.Tables.Add(dt.Copy());

            using (StringWriter sw = new StringWriter())
            {
                ds.WriteXml(sw);
                return sw.ToString();
            }
        }

        protected void GVPartnership_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GVPartnership.Rows[e.RowIndex].Cells[1].Text.Trim();

                SRVCLabourMotor objLabour = new SRVCLabourMotor();
                {
                    objLabour.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objLabour.PartnershipName = name;
                };
                string result = objSrvcbal.DeletePartner(objLabour);

                DataTable dt = PartnerDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                PartnerDetails = dt;

                GVPartnership.DataSource = dt;
                GVPartnership.DataBind();
                GVPartnership.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        private DataTable DirectorDetails
        {
            get
            {
                if (ViewState["DirectorDetails"] == null)
                {
                    DataTable dt = new DataTable("Table1");
                    dt.Columns.Add("SRVCDD_FULLNAME", typeof(string));
                    dt.Columns.Add("SRVCDD_RESIDENTIALADDRESS", typeof(string));
                    ViewState["DirectorDetails"] = dt;
                }
                return (DataTable)ViewState["DirectorDetails"];
            }
            set
            {
                ViewState["DirectorDetails"] = value;
            }
        }

        protected void btnDirector_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                    string.IsNullOrWhiteSpace(txtResAddress.Text))
                {
                    lblmsg0.Text = "Please enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = DirectorDetails;

                DataRow dr = dt.NewRow();
                dr["SRVCDD_FULLNAME"] = txtFullName.Text.Trim();
                dr["SRVCDD_RESIDENTIALADDRESS"] = txtResAddress.Text.Trim();
                dt.Rows.Add(dr);

                DirectorDetails = dt;

                GVDirector.Visible = true;
                GVDirector.DataSource = dt;
                GVDirector.DataBind();

                txtFullName.Text = "";
                txtResAddress.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private string GetDirectorXML()
        {
            DataTable dt = DirectorDetails;
            DataSet ds = new DataSet("Root");
            ds.Tables.Add(dt.Copy());

            using (StringWriter sw = new StringWriter())
            {
                ds.WriteXml(sw);
                return sw.ToString();
            }
        }

        protected void GVDirector_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GVDirector.Rows[e.RowIndex].Cells[1].Text.Trim();

                SRVCLabourMotor objLabour = new SRVCLabourMotor();
                {
                    objLabour.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objLabour.DirectorFullName = name;
                };
                string result = objSrvcbal.DeleteDirector(objLabour);

                DataTable dt = DirectorDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                DirectorDetails = dt;

                GVDirector.DataSource = dt;
                GVDirector.DataBind();
                GVDirector.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void Btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = stepValidations();
                if (ErrorMsg == "")
                {

                    DataTable dt = PartnerDetails;
                    DataSet ds = new DataSet("Root");
                    ds.Tables.Add(dt.Copy());

                    string xmlData;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds.WriteXml(sw);
                        xmlData = sw.ToString();
                    }

                    SRVCLabourMotor objLabourPart = new SRVCLabourMotor();
                    {
                        objLabourPart.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objLabourPart.Createdby = "1001"; //hdnUserID.Value;
                        objLabourPart.IPAddress = getclientIP();
                        objLabourPart.XMLData = GetPartnersXML();
                    };

                    string status = objSrvcbal.InsertPartners(objLabourPart);
                    lblmsg0.Text = status == "Success" ? "Saved successfully!" : "Error saving data.";



                    DataTable dt1 = DirectorDetails;
                    DataSet ds1 = new DataSet("Root");
                    ds1.Tables.Add(dt1.Copy());

                    string xmlData1;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds1.WriteXml(sw);
                        xmlData1 = sw.ToString();
                    }

                    SRVCLabourMotor objLabour1 = new SRVCLabourMotor();
                    {
                        objLabour1.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objLabour1.Createdby = "1001"; //hdnUserID.Value;
                        objLabour1.IPAddress = getclientIP();
                        objLabour1.XMLData = GetDirectorXML();
                    };

                    result = objSrvcbal.InsertDirector(objLabour1);
                    lblmsg0.Text = result == "Success" ? "Saved successfully!" : "Error saving data.";


                    SRVCLabourMotor objLabour = new SRVCLabourMotor();

                    objLabour.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objLabour.Createdby = "1001";//hdnUserID.Value;
                    objLabour.IPAddress = getclientIP();
                    objLabour.NatureMotor = txtNatureMotor.Text;
                    objLabour.TotalNo = txtTotalNo.Text;
                    objLabour.Totalroute = txtTotalRoute.Text;
                    objLabour.TotalNoVehicle = txtTotalNoMotor.Text;
                    objLabour.MaxNoMotor = txtMaxNo.Text;
                    objLabour.TypeOfTransport = rblTransport.SelectedValue;
                    objLabour.ProprietorshipName = txtProName.Text;
                    objLabour.ProprietorshipAddress = txtProAddress.Text;
                    objLabour.SectorName = txtSectorName.Text;
                    objLabour.SectorAddress = txtSectorAddress.Text;
                    objLabour.VehicleNo = txtVehicleNo.Text;
                    objLabour.TypeVehicle = txtTypeVehicle.Text;

                    result = objSrvcbal.InsertSRVCLabourMotorDetails(objLabour);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = " Labour Motor Transport Details Submitted Successfully";
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

                if (string.IsNullOrEmpty(txtNatureMotor.Text) || txtNatureMotor.Text.Trim() == "" || txtNatureMotor.Text == null)
                {
                    errormsg += slno + ". Please enter Nature of Motor Transport Service...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtTotalNo.Text) || txtTotalNo.Text.Trim() == "" || txtTotalNo.Text == null)
                {
                    errormsg += slno + ". Please enter Total number of routes...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtTotalRoute.Text) || txtTotalRoute.Text == "" || txtTotalRoute.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total route mileage...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTotalNoMotor.Text) || txtTotalNoMotor.Text == "" || txtTotalNoMotor.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total number of motor transport vehicles...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMaxNo.Text) || txtMaxNo.Text == "" || txtMaxNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Maximum number of Motor Transport Workers employed...! \\n";
                    slno = slno + 1;
                }
                if (rblTransport.SelectedValue == "0" || rblTransport.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select State \\n";
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