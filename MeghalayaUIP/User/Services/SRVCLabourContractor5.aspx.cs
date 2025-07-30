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
    public partial class SRVCLabourContractor5 : System.Web.UI.Page
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
                ds = objSrvcbal.GetSRVCLabourAct1970DETAILS(Convert.ToString(Session["SRVCQID"]), hdnUserID.Value);

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ddlEmptitle.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_TITLE"]);
                        txtEMPName.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_EMPNAME"]);
                        ddlSates.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_STATE"]);
                        ddlSates_SelectedIndexChanged(null, EventArgs.Empty);
                        if (ddlSates.SelectedItem.Text == "Meghalaya")
                        {
                            divMeghaState.Visible = true;
                            divOtherState.Visible = false;

                            ddlDistric.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_DISTRICTID"]);
                            ddlDistric_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_MANDALID"]);
                            ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_VILLAGEID"]);
                        }
                        else
                        {
                            divOtherState.Visible = true;
                            divMeghaState.Visible = false;
                            txtDistricted.Text = ds.Tables[0].Rows[0]["SRVCLD_DISTRICT"].ToString();
                            txtMandaled.Text = ds.Tables[0].Rows[0]["SRVCLD_MANDAL"].ToString();
                            txtVillagede.Text = ds.Tables[0].Rows[0]["SRVCLD_VILLAGE"].ToString();
                        }



                        txtLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_LOCALITY"]);
                        txtLandMark.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_LANDMARK"]);
                        txtPoliceStation.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_PSTATION"]);
                        txtPostOffice.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_POFFICE"]);

                        TXTPIN.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_PINCODE"]);
                        txtBusiness.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_TYPEBUSINESS"]);
                        txtRegNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_REGNO"]);

                        txtRegDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_REGDATE"]);
                        txtNameAgent.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_AGENTNAME"]);
                        txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_AHENTMANAGERNAME"]);
                        txtlocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_CONTACTLABOUREMP"]);
                        txtdayslabour.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_NOOFDAYSLABOUR"]);
                        txtEStdate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_ESTDATE"]);
                        txtEndDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_ENDDATE"]);

                        txtMaximumnumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_MAXNOLABOUREMP"]);
                        rblConvicated.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_CONTRACTORCONVICTED5"]);

                        if (rblConvicated.SelectedValue == "Y")
                        {
                            divcontractor.Visible = true;
                            txtDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_DETAILS"]);
                        }
                        else { divcontractor.Visible = false; }
                        rblrevoking.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_CONTRACTORREVOKINGLIC"]);
                        if (rblrevoking.SelectedValue == "Y")
                        {
                            divsuspend.Visible = true;
                            txtOrderDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_ORDERDATE"]);
                        }
                        else { divsuspend.Visible = false; }
                        rblcontractor.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_CONTRACTOREST5"]);
                        if (rblrevoking.SelectedValue == "Y")
                        {
                            divfiveyear.Visible = true;
                            txtprinciple.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_PRINCIPALEMPDET"]);
                            txtEstablishment.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_ESTDETAILS"]);
                            txtNature.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCLD_NATUREWORK"]);
                        }
                        else { divfiveyear.Visible = false; }

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GVDirector.DataSource = ds.Tables[1];
                        GVDirector.DataBind();
                        GVDirector.Visible = true;
                        ViewState["DirectorDetails"] = ds.Tables[1];
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        GVManager.DataSource = ds.Tables[2];
                        GVManager.DataBind();
                        GVManager.Visible = true;
                        ViewState["ManagerDetails"] = ds.Tables[2];
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
        protected void rblConvicated_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblConvicated.SelectedValue == "Y")
                {
                    divcontractor.Visible = true;
                }
                else { divcontractor.Visible = false; }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        protected void rblrevoking_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblrevoking.SelectedValue == "Y")
                {
                    divsuspend.Visible = true;
                }
                else { divsuspend.Visible = false; }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        protected void rblcontractor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblcontractor.SelectedValue == "Y")
                {
                    divfiveyear.Visible = true;
                    divnature.Visible = true;
                }
                else
                {
                    divfiveyear.Visible = false;
                    divnature.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        protected void BindStates()
        {
            try
            {
                ddlSates.Items.Clear();

                List<MasterStates> objStatesModel = new List<MasterStates>();

                objStatesModel = mstrBAL.GetStates();
                if (objStatesModel != null)
                {
                    ddlSates.DataSource = objStatesModel;
                    ddlSates.DataValueField = "StateId";
                    ddlSates.DataTextField = "StateName";
                    ddlSates.DataBind();
                }
                else
                {
                    ddlSates.DataSource = null;
                    ddlSates.DataBind();
                }
                AddSelect(ddlSates);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindDistricts()
        {
            try
            {

                ddlDistric.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;

                strmode = "";

                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlDistric.DataSource = objDistrictModel;
                    ddlDistric.DataValueField = "DistrictId";
                    ddlDistric.DataTextField = "DistrictName";
                    ddlDistric.DataBind();

                }
                else
                {
                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();

                }
                AddSelect(ddlDistric);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

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
        protected void BindMandal(DropDownList ddlmndl, string DistrictID)
        {
            try
            {
                List<MasterMandals> objMandal = mstrBAL.GetMandals(DistrictID);

                if (objMandal != null && objMandal.Count > 0)
                {
                    ddlmndl.DataSource = objMandal;
                    ddlmndl.DataValueField = "MandalId";
                    ddlmndl.DataTextField = "MandalName";
                    ddlmndl.DataBind();
                }
                else
                {

                    ddlmndl.DataSource = null;
                    ddlmndl.DataBind();
                }

                AddSelect(ddlmndl);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void BindVillages(DropDownList ddlvlg, string MandalID)
        {
            try
            {
                List<MasterVillages> objVillage = new List<MasterVillages>();
                string strmode = string.Empty;

                objVillage = mstrBAL.GetVillages(MandalID);

                if (objVillage != null)
                {
                    ddlvlg.DataSource = objVillage;
                    ddlvlg.DataValueField = "VillageId";
                    ddlvlg.DataTextField = "VillageName";
                    ddlvlg.DataBind();
                }
                else
                {
                    ddlvlg.DataSource = null;
                    ddlvlg.DataBind();
                }
                AddSelect(ddlvlg);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlSates_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSates.SelectedValue != "23")
                {
                    divOtherState.Visible = true;

                    divMeghaState.Visible = false;

                    ddlDistric.ClearSelection();
                    ddlMandal.ClearSelection();
                    ddlVillage.ClearSelection();
                }
                else if (ddlSates.SelectedValue == "23")
                {
                    divMeghaState.Visible = true;

                    divOtherState.Visible = false;
                    txtDistricted.Text = "";
                    txtMandaled.Text = "";
                    txtVillagede.Text = "";

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlDistric_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                if (ddlDistric.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistric.SelectedValue);
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
        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillage.ClearSelection();
                if (ddlMandal.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlVillage, ddlMandal.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnDirector_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ddlTitle.SelectedValue) ||
                    string.IsNullOrWhiteSpace(txtDirectorName.Text) || string.IsNullOrWhiteSpace(txtDirectorAddress.Text))
                {
                    lblmsg0.Text = "Please enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = DirectorDetails;

                DataRow dr = dt.NewRow();
                dr["SRVCLDD_TITLE"] = ddlTitle.SelectedValue;
                dr["SRVCLDD_FULLNAME"] = txtDirectorName.Text.Trim();
                dr["SRVCLDD_ADDRESS"] = txtDirectorAddress.Text.Trim();
                dt.Rows.Add(dr);

                DirectorDetails = dt;

                GVDirector.Visible = true;
                GVDirector.DataSource = dt;
                GVDirector.DataBind();

                ddlTitle.ClearSelection();
                txtDirectorName.Text = "";
                txtDirectorAddress.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private DataTable DirectorDetails
        {
            get
            {
                if (ViewState["DirectorDetails"] == null)
                {
                    DataTable dt = new DataTable("Table1");
                    dt.Columns.Add("SRVCLDD_TITLE", typeof(string));
                    dt.Columns.Add("SRVCLDD_FULLNAME", typeof(string));
                    dt.Columns.Add("SRVCLDD_ADDRESS", typeof(string));
                    ViewState["DirectorDetails"] = dt;
                }
                return (DataTable)ViewState["DirectorDetails"];
            }
            set
            {
                ViewState["DirectorDetails"] = value;
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
                string name = GVDirector.Rows[e.RowIndex].Cells[2].Text.Trim();

                SRVCLABOURACT1970DETAILS objLabour = new SRVCLABOURACT1970DETAILS();
                {
                    objLabour.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objLabour.DirectorsName = name;
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
        protected void btnManager_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ddlTitles.SelectedValue) ||
                    string.IsNullOrWhiteSpace(txtManagerName.Text) || string.IsNullOrWhiteSpace(txtManagerAddress.Text))
                {
                    lblmsg0.Text = "Please enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = ManagerDetails;

                DataRow dr = dt.NewRow();
                dr["SRVCLMD_TITLE"] = ddlTitles.SelectedValue;
                dr["SRVCLMD_FULLNAME"] = txtManagerName.Text.Trim();
                dr["SRVCLMD_ADDRESS"] = txtManagerAddress.Text.Trim();
                dt.Rows.Add(dr);

                ManagerDetails = dt;

                GVManager.Visible = true;
                GVManager.DataSource = dt;
                GVManager.DataBind();

                ddlTitle.ClearSelection();
                txtDirectorName.Text = "";
                txtDirectorAddress.Text = "";
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
                    dt.Columns.Add("SRVCLMD_TITLE", typeof(string));
                    dt.Columns.Add("SRVCLMD_FULLNAME", typeof(string));
                    dt.Columns.Add("SRVCLMD_ADDRESS", typeof(string));
                    ViewState["ManagerDetails"] = dt;
                }
                return (DataTable)ViewState["ManagerDetails"];
            }
            set
            {
                ViewState["ManagerDetails"] = value;
            }
        }
        protected void GVManager_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GVManager.Rows[e.RowIndex].Cells[2].Text.Trim();

                SRVCLABOURACT1970DETAILS objLabour = new SRVCLABOURACT1970DETAILS();
                {
                    objLabour.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objLabour.ManagerName = name;
                };
                string result = objSrvcbal.DeleteManager(objLabour);

                DataTable dt = ManagerDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                ManagerDetails = dt;

                GVManager.DataSource = dt;
                GVManager.DataBind();
                GVManager.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
        protected void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = stepValidations();
                if (ErrorMsg == "")
                {
                    SRVCLABOURACT1970DETAILS objLabour = new SRVCLABOURACT1970DETAILS();

                    DataTable dt = DirectorDetails;
                    DataSet ds = new DataSet("Root");
                    ds.Tables.Add(dt.Copy());

                    string xmlData;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds.WriteXml(sw);
                        xmlData = sw.ToString();
                    }


                    {
                        objLabour.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objLabour.Createdby = "1001"; //hdnUserID.Value;
                        objLabour.IPAddress = getclientIP();
                        objLabour.XMLData = GetDirectorXML();
                    };
                    result = objSrvcbal.InsertLabourDirectorDetails(objLabour);




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
                        objLabour.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objLabour.Createdby = "1001"; //hdnUserID.Value;
                        objLabour.IPAddress = getclientIP();
                        objLabour.XMLData = GetManagerXML();
                    };
                    result = objSrvcbal.InsertLabourManagerDetails(objLabour);





                    objLabour.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                    objLabour.Createdby = "1001"; //hdnUserID.Value;
                    objLabour.IPAddress = getclientIP();
                    objLabour.Title = ddlEmptitle.SelectedItem.Text;
                    objLabour.PrincipalEMPNAME = txtEMPName.Text;
                    objLabour.State = ddlSates.SelectedValue;
                    objLabour.DISTRICTID = ddlDistric.SelectedValue;
                    objLabour.MANDALID = ddlMandal.SelectedValue;
                    objLabour.VILLAGEID = ddlVillage.SelectedValue;
                    objLabour.DISTRICT = txtDistricted.Text;
                    objLabour.MANDAL = txtMandaled.Text;
                    objLabour.VILLAGE = txtVillagede.Text;
                    objLabour.Locality = txtLocality.Text;
                    objLabour.Landmark = txtLandMark.Text;
                    objLabour.PoliceStation = txtPoliceStation.Text;
                    objLabour.PostOffice = txtPostOffice.Text;
                    objLabour.PinCode = TXTPIN.Text;
                    objLabour.TypeBusiness = txtBusiness.Text;
                    objLabour.RegNo = txtRegNo.Text;
                    objLabour.RegDate = txtRegDate.Text;
                    objLabour.Nameagentmanager = txtNameAgent.Text;
                    objLabour.Addressagentmanager = txtAddress.Text;
                    objLabour.NameNatureEmp = txtlocation.Text;
                    objLabour.LabourNoDays = txtdayslabour.Text;
                    objLabour.EstDate = txtEStdate.Text;
                    objLabour.EndingDate = txtEndDate.Text;
                    objLabour.MaxnoLabourEmp = txtMaximumnumber.Text;
                    objLabour.Othersconvicted = rblConvicated.SelectedValue;
                    objLabour.Details = txtDetails.Text;
                    objLabour.Othersrevoking = rblrevoking.SelectedValue;
                    objLabour.OrderDate = txtOrderDate.Text;
                    objLabour.otherscontractorEst = rblcontractor.SelectedValue;
                    objLabour.PrincipalEmpDetails = txtprinciple.Text;
                    objLabour.EstDetails = txtEstablishment.Text;
                    objLabour.Naturework = txtNature.Text;


                    result = objSrvcbal.InsertSRVCLabour1970Details(objLabour);

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
        public string stepValidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (ddlEmptitle.SelectedIndex == -1)
                {
                    errormsg += slno + ". Please enter Title...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtEMPName.Text) || txtEMPName.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Principal Employer's Name...! \\n";
                    slno++;
                }

                if (ddlSates.SelectedValue == "0" || ddlSates.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select State \\n";
                    slno = slno + 1;
                }
                if (ddlSates.SelectedValue == "23")
                {
                    if (ddlDistric.SelectedIndex == -1 || ddlDistric.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select District \\n";
                        slno = slno + 1;
                    }
                    if (ddlMandal.SelectedIndex == -1 || ddlMandal.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select Mandal \\n";
                        slno = slno + 1;
                    }
                    if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select Village \\n";
                        slno = slno + 1;
                    }
                }
                else if (ddlSates.SelectedValue != "23" && ddlSates.SelectedValue != "0")
                {
                    if (string.IsNullOrEmpty(txtDistricted.Text) || txtDistricted.Text == "" || txtDistricted.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Authorised Representative District...! \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtMandaled.Text) || txtMandaled.Text == "" || txtMandaled.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Authorised Representative Mandal...! \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtVillagede.Text) || txtVillagede.Text == "" || txtVillagede.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Authorised Representative Village...! \\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Locality ...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtLandMark.Text) || txtLandMark.Text.Trim() == "" || txtLandMark.Text == null)
                {
                    errormsg += slno + ". Please enter Nearest Landmark...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtPoliceStation.Text) || txtPoliceStation.Text.Trim() == "" || txtPoliceStation.Text == null)
                {
                    errormsg += slno + ". Please enter Police Station/Outpost...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtPostOffice.Text) || txtPostOffice.Text.Trim() == "" || txtPostOffice.Text == null)
                {
                    errormsg += slno + ". Please enter Post Office ...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(TXTPIN.Text) || TXTPIN.Text.Trim() == "" || TXTPIN.Text == null)
                {
                    errormsg += slno + ". Please enter Pincode...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtBusiness.Text) || txtBusiness.Text.Trim() == "" || txtBusiness.Text == null)
                {
                    errormsg += slno + ". Please enter ype of Business, Trade, Industry, Manufacture ...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtRegNo.Text) || txtRegNo.Text.Trim() == "" || txtRegNo.Text == null)
                {
                    errormsg += slno + ". Please enter Registration number...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtRegDate.Text) || txtRegDate.Text.Trim() == "" || txtRegDate.Text == null)
                {
                    errormsg += slno + ". Please enter Registration Date...! \\n";
                    slno++;
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