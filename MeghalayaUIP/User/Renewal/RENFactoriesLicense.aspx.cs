using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Renewal
{
    public partial class RENFactoriesLicense : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string UnitID, ErrorMsg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                    if (Convert.ToString(Session["RENUNITID"]) != "")
                    { UnitID = Convert.ToString(Session["RENUNITID"]); }
                    else
                    {
                        string newurl = "~/User/Renewal/RENUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }
                    //Session["UNITID"] = "1001";
                    //UnitID = Convert.ToString(Session["UNITID"]);

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        GetAppliedorNot();
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
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENUNITID"]), Convert.ToString(Session["RENQID"]), "10", "72");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "72")
                    {
                        BindNOOFYEARS();
                        BindGenerating();
                        BindDGPOWER();
                        BindMAXAMOUNTPOWER();
                        BindData();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Renewal/RENContractLabourDeatils.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/ContractorMigrantWork.aspx?Previous=" + "P");
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
        protected void rblpowerGeneration_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (rblpowerGeneration.SelectedValue == "Y")
                {
                    Generating.Visible = true;
                    DGSETKW.Visible = false;
                }
                else
                {
                    DGSETKW.Visible = true;
                    Generating.Visible = false;
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblpowerGeneration.BorderColor = System.Drawing.Color.White;
        }

        protected void rblfirmconcer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblfirmconcer.SelectedValue == "Y")
                {
                    Proprietor.Visible = true;
                }
                else { Proprietor.Visible = false; }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblfirmconcer.BorderColor = System.Drawing.Color.White;
        }

        protected void rblpublicfactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (rblpublicfactory.SelectedValue == "Y")
                {
                    Director.Visible = true;
                }
                else { Director.Visible = false; }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblpublicfactory.BorderColor = System.Drawing.Color.White;
        }

        protected void rbllocalfactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (rbllocalfactory.SelectedValue == "Y")
                {
                    Administrative.Visible = true;
                }
                else { Administrative.Visible = false; }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rbllocalfactory.BorderColor = System.Drawing.Color.White;
        }

        protected void rblAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblAgent.SelectedValue == "Y")
                {
                    ManagingAgent.Visible = true;
                }
                else { ManagingAgent.Visible = false; }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblAgent.BorderColor = System.Drawing.Color.White;
        }

        protected void rblDateofRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (rblDateofRules.SelectedValue == "Y")
                {
                    Div1.Visible = true;
                    Div2.Visible = true;
                }
                else
                {
                    Div1.Visible = false;
                    Div2.Visible = false;
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblDateofRules.BorderColor = System.Drawing.Color.White;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
           // string Quesstionriids = "1001";
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenFactoryLicense ObjRenFactoryLic = new RenFactoryLicense();

                    ObjRenFactoryLic.Questionnariid = Convert.ToString(Session["RENQID"]); ;
                    ObjRenFactoryLic.CreatedBy = hdnUserID.Value;
                    ObjRenFactoryLic.UnitId = Convert.ToString(Session["RENUNITID"]);
                    ObjRenFactoryLic.IPAddress = getclientIP();

                    ObjRenFactoryLic.FULLNAME = txtFullName.Text;
                    ObjRenFactoryLic.LICNO = txtLicNo.Text;
                    ObjRenFactoryLic.LICISSUEDDATE = txtLICIssuedDate.Text;
                    ObjRenFactoryLic.RENEWALNO = txtRenewalNo.Text;
                    ObjRenFactoryLic.RENEWALDATE = txtRenewaldate.Text;
                    ObjRenFactoryLic.LICVALIDYEAR = txtLICValidYear.Text;

                    ObjRenFactoryLic.FACTORIESL12MONTHS = txttradeLic12.Text;
                    ObjRenFactoryLic.NEXT12MONTHS = txtfactorymonths12.Text;
                    ObjRenFactoryLic.MANUPRODUCT = txtmanufacture12.Text;
                    ObjRenFactoryLic.PRINCIPALPRODUCT = txtproductManufacture12.Text;
                    //ObjRenFactoryLic.NAMESOFMANU = ddlEmpday.SelectedValue; txtmanufacture12
                    //ObjRenFactoryLic.MANUPRODUCT12MONTHS = txtMaxEmp12.Text; txtproductManufacture12
                    ObjRenFactoryLic.MAXNOEMP = ddlEmpday.SelectedValue;
                    ObjRenFactoryLic.MAXNOWORK = txtMaxEmp12.Text;
                    ObjRenFactoryLic.NOORDINARIYEMP = txtFactoryEmpWorker.Text;
                    ObjRenFactoryLic.UNITELECTRICPOWER = rblpowerGeneration.SelectedValue;
                    ObjRenFactoryLic.TOTALCAPGENERATING = ddlGenerating.SelectedValue;
                    ObjRenFactoryLic.TOTALDGSET = ddlDGSet.SelectedValue;
                    ObjRenFactoryLic.MAXPOWER = ddlPowerAmount.SelectedValue;
                    ObjRenFactoryLic.FULLNAMEMANAGER = txtFullNamefactory.Text;
                    ObjRenFactoryLic.RESIDENTIALADDRESS = txtaddress.Text;
                    ObjRenFactoryLic.FULLNAMEOWNER = txtsection93.Text;
                    ObjRenFactoryLic.OWNERADDRESSBUILD = txtaddressdection93.Text;
                    ObjRenFactoryLic.NAMEOCCUPIER = NameOccupier.Text;
                    ObjRenFactoryLic.ADDRESSOCCUPIER = txtAddressOccupier.Text;
                    ObjRenFactoryLic.PRIVATEFIRM = rblfirmconcer.SelectedValue;
                    ObjRenFactoryLic.PUBLICFIRM = rblpublicfactory.SelectedValue;
                    ObjRenFactoryLic.NAMEPROPRIETOR = txtproprietor.Text;
                    ObjRenFactoryLic.NAMEDIRECTORS = txtDirectors.Text;
                    ObjRenFactoryLic.GOVTLOCALFACTORY = rbllocalfactory.SelectedValue;
                    ObjRenFactoryLic.MANAGINGAPPOINTEDAGENT = rblAgent.SelectedValue;
                    ObjRenFactoryLic.NAMECHIEFHEAD = txtChiefHead.Text;
                    ObjRenFactoryLic.NAMEOFAGENT = txtMangingAgent.Text;
                    ObjRenFactoryLic.FACTORYEXTENDED = rblDateofRules.SelectedValue;
                    ObjRenFactoryLic.REFNOAPPROVALSITE = txtapprovalbuilding.Text;
                    ObjRenFactoryLic.DATEOFAPPROVAL = txtsiteApproval.Text;
                    ObjRenFactoryLic.REFAPPROVALAUTHORITY = txtapprovalnumber.Text;
                    ObjRenFactoryLic.DATEOFAPPROVALAUTHORITY = txtArrangement.Text;
                    ObjRenFactoryLic.FINALFEES = Fees.Text;
                    ObjRenFactoryLic.PENALTY = Penalty.Text;
                    ObjRenFactoryLic.LICVALIDUPTO = LicValidUpto.Text;
                    ObjRenFactoryLic.TOTALAMOUNTPAID = totalamount.Text;



                    result = objRenbal.InsertRENFactoryLicDetails(ObjRenFactoryLic);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal FactoryLicense Details Submitted Successfully";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected List<TextBox> FindEmptyTextboxes(Control container)
        {

            List<TextBox> emptyTextboxes = new List<TextBox>();
            foreach (Control control in container.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textbox = (TextBox)control;
                    if (string.IsNullOrWhiteSpace(textbox.Text))
                    {
                        emptyTextboxes.Add(textbox);
                        textbox.BorderColor = System.Drawing.Color.Red;
                    }
                }

                if (control.HasControls())
                {
                    emptyTextboxes.AddRange(FindEmptyTextboxes(control));
                }
            }
            return emptyTextboxes;
        }
        protected List<DropDownList> FindEmptyDropdowns(Control container)
        {
            List<DropDownList> emptyDropdowns = new List<DropDownList>();

            foreach (Control control in container.Controls)
            {
                if (control is DropDownList)
                {
                    DropDownList dropdown = (DropDownList)control;
                    if (string.IsNullOrWhiteSpace(dropdown.SelectedValue) || dropdown.SelectedValue == "" || dropdown.SelectedItem.Text == "--Select--" || dropdown.SelectedIndex == -1)
                    {
                        emptyDropdowns.Add(dropdown);
                        dropdown.BorderColor = System.Drawing.Color.Red;
                    }
                }

                if (control.HasControls())
                {
                    emptyDropdowns.AddRange(FindEmptyDropdowns(control));
                }
            }

            return emptyDropdowns;
        }

        private List<RadioButtonList> FindEmptyRadioButtonLists(Control container)
        {
            List<RadioButtonList> emptyRadioButtonLists = new List<RadioButtonList>();

            foreach (Control control in container.Controls)
            {
                if (control is RadioButtonList radioButtonList)
                {
                    if (string.IsNullOrWhiteSpace(radioButtonList.SelectedValue) || radioButtonList.SelectedIndex == -1)
                    {
                        emptyRadioButtonLists.Add(radioButtonList);

                        radioButtonList.BorderColor = System.Drawing.Color.Red;
                        radioButtonList.BorderWidth = Unit.Pixel(2);
                        radioButtonList.BorderStyle = BorderStyle.Solid;
                    }
                    else
                    {
                        radioButtonList.BorderColor = System.Drawing.Color.Empty;
                        radioButtonList.BorderWidth = Unit.Empty;
                        radioButtonList.BorderStyle = BorderStyle.NotSet;
                    }
                }

                if (control.HasControls())
                {
                    emptyRadioButtonLists.AddRange(FindEmptyRadioButtonLists(control));
                }
            }

            return emptyRadioButtonLists;
        }



        public string validations()
        {
            try
            {
                int slno = 1;
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);
                string errormsg = "";

                if (string.IsNullOrEmpty(txtFullName.Text) || txtFullName.Text == "" || txtFullName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Full Name Factory\\n";
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
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objRenbal.GetRenFactoriesLic(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENFL_UNITID"]);
                    txtFullName.Text = ds.Tables[0].Rows[0]["RENFL_FULLNAME"].ToString();
                    txtLicNo.Text = ds.Tables[0].Rows[0]["RENFL_LICNO"].ToString();
                    txtLICIssuedDate.Text = ds.Tables[0].Rows[0]["RENFL_LICISSUEDDATE"].ToString();
                    txtRenewalNo.Text = ds.Tables[0].Rows[0]["RENFL_RENEWALNO"].ToString();
                    txtRenewaldate.Text = ds.Tables[0].Rows[0]["RENFL_RENEWALDATE"].ToString();
                    txtLICValidYear.Text = ds.Tables[0].Rows[0]["RENFL_LICVALIDYEAR"].ToString();
                    txttradeLic12.Text = ds.Tables[0].Rows[0]["RENFL_FACTORIESL12MONTHS"].ToString();
                    txtfactorymonths12.Text = ds.Tables[0].Rows[0]["RENFL_NEXT12MONTHS"].ToString();
                    txtmanufacture12.Text = ds.Tables[0].Rows[0]["RENFL_MANUPRODUCT"].ToString();
                    txtproductManufacture12.Text = ds.Tables[0].Rows[0]["RENFL_PRINCIPALPRODUCT"].ToString();
                    ddlEmpday.SelectedValue = ds.Tables[0].Rows[0]["RENFL_MAXNOEMP"].ToString();
                    txtMaxEmp12.Text = ds.Tables[0].Rows[0]["RENFL_MAXNOWORK"].ToString();
                    txtFactoryEmpWorker.Text = ds.Tables[0].Rows[0]["RENFL_NOORDINARIYEMP"].ToString();
                    rblpowerGeneration.SelectedValue = ds.Tables[0].Rows[0]["RENFL_UNITELECTRICPOWER"].ToString();
                    if (rblpowerGeneration.SelectedValue == "Y")
                    {
                        Generating.Visible = true;
                        ddlGenerating.SelectedValue = ds.Tables[0].Rows[0]["RENFL_TOTALCAPGENERATING"].ToString();
                    }
                    else
                    {
                        Generating.Visible = true;
                        ddlDGSet.SelectedValue = ds.Tables[0].Rows[0]["RENFL_TOTALDGSET"].ToString();
                        ddlPowerAmount.SelectedValue = ds.Tables[0].Rows[0]["RENFL_MAXPOWER"].ToString();
                    }

                    txtFullNamefactory.Text = ds.Tables[0].Rows[0]["RENFL_FULLNAMEMANAGER"].ToString();
                    txtaddress.Text = ds.Tables[0].Rows[0]["RENFL_RESIDENTIALADDRESS"].ToString();
                    txtsection93.Text = ds.Tables[0].Rows[0]["RENFL_FULLNAMEOWNER"].ToString();
                    txtaddressdection93.Text = ds.Tables[0].Rows[0]["RENFL_OWNERADDRESSBUILD"].ToString();
                    NameOccupier.Text = ds.Tables[0].Rows[0]["RENFL_NAMEOCCUPIER"].ToString();
                    txtAddressOccupier.Text = ds.Tables[0].Rows[0]["RENFL_ADDRESSOCCUPIER"].ToString();
                    rblfirmconcer.SelectedValue = ds.Tables[0].Rows[0]["RENFL_PRIVATEFIRM"].ToString();
                    if (rblfirmconcer.SelectedValue == "Y")
                    {
                        Proprietor.Visible = true;
                        txtproprietor.Text = ds.Tables[0].Rows[0]["RENFL_NAMEPROPRIETOR"].ToString();
                    }
                    else { Proprietor.Visible = false; }
                    rblpublicfactory.SelectedValue = ds.Tables[0].Rows[0]["RENFL_PUBLICFIRM"].ToString();
                    if (rblpublicfactory.SelectedValue == "Y")
                    {
                        Director.Visible = true;
                        txtDirectors.Text = ds.Tables[0].Rows[0]["RENFL_NAMEDIRECTORS"].ToString();
                    }

                    rbllocalfactory.SelectedValue = ds.Tables[0].Rows[0]["RENFL_GOVTLOCALFACTORY"].ToString();
                    if (rbllocalfactory.SelectedValue == "Y")
                    {
                        Administrative.Visible = true;
                        txtChiefHead.Text = ds.Tables[0].Rows[0]["RENFL_NAMECHIEFHEAD"].ToString();
                    }
                    else { Administrative.Visible = false; }
                    rblAgent.SelectedValue = ds.Tables[0].Rows[0]["RENFL_MANAGINGAPPOINTEDAGENT"].ToString();
                    if (rblAgent.SelectedValue == "Y")
                    {
                        ManagingAgent.Visible = true;
                        txtMangingAgent.Text = ds.Tables[0].Rows[0]["RENFL_NAMEOFAGENT"].ToString();
                    }
                    else { ManagingAgent.Visible = false; }
                    rblDateofRules.SelectedValue = ds.Tables[0].Rows[0]["RENFL_FACTORYEXTENDED"].ToString();
                    if (rblDateofRules.SelectedValue == "Y")
                    {
                        Div1.Visible = true;
                        Div2.Visible = true;
                        txtapprovalbuilding.Text = ds.Tables[0].Rows[0]["RENFL_REFNOAPPROVALSITE"].ToString();
                        txtsiteApproval.Text = ds.Tables[0].Rows[0]["RENFL_DATEOFAPPROVAL"].ToString();
                        txtapprovalnumber.Text = ds.Tables[0].Rows[0]["RENFL_REFAPPROVALAUTHORITY"].ToString();
                        txtArrangement.Text = ds.Tables[0].Rows[0]["RENFL_DATEOFAPPROVALAUTHORITY"].ToString();
                    }
                    else
                    {
                        Div1.Visible = false;
                        Div2.Visible = false;
                    }
                    Fees.Text = ds.Tables[0].Rows[0]["RENFL_FINALFEES"].ToString();
                    Penalty.Text = ds.Tables[0].Rows[0]["RENFL_PENALTY"].ToString();
                    LicValidUpto.Text = ds.Tables[0].Rows[0]["RENFL_LICVALIDUPTO"].ToString();
                    totalamount.Text = ds.Tables[0].Rows[0]["RENFL_TOTALAMOUNTPAID"].ToString();


                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindDGPOWER()
        {
            try
            {

                ddlDGSet.Items.Clear();


                List<MasterDGPOWER> objDGPOWERModel = new List<MasterDGPOWER>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
                objDGPOWERModel = mstrBAL.GetDGPOWER();
                if (objDGPOWERModel != null)
                {
                    ddlDGSet.DataSource = objDGPOWERModel;
                    ddlDGSet.DataValueField = "DGPOWER_ID";
                    ddlDGSet.DataTextField = "DGPOWER_NAME";
                    ddlDGSet.DataBind();


                }
                else
                {
                    ddlDGSet.DataSource = null;
                    ddlDGSet.DataBind();


                }
                AddSelect(ddlDGSet);


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
        protected void BindMAXAMOUNTPOWER()
        {
            try
            {

                ddlPowerAmount.Items.Clear();


                List<MasterMAXAMOUNTPOWER> objDGPOWERModel = new List<MasterMAXAMOUNTPOWER>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
                objDGPOWERModel = mstrBAL.GetMaxAmountPower();
                if (objDGPOWERModel != null)
                {
                    ddlPowerAmount.DataSource = objDGPOWERModel;
                    ddlPowerAmount.DataValueField = "MAXAMOUNTPOWER_ID";
                    ddlPowerAmount.DataTextField = "MAXAMOUNTPOWER_NAME";
                    ddlPowerAmount.DataBind();


                }
                else
                {
                    ddlPowerAmount.DataSource = null;
                    ddlPowerAmount.DataBind();


                }
                AddSelect(ddlPowerAmount);


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindNOOFYEARS()
        {
            try
            {

                ddlEmpday.Items.Clear();


                List<MasterNOOFWORKERSYEARS> objNOOFWORKERModel = new List<MasterNOOFWORKERSYEARS>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
                objNOOFWORKERModel = mstrBAL.GetWORKERSYEARS();
                if (objNOOFWORKERModel != null)
                {
                    ddlEmpday.DataSource = objNOOFWORKERModel;
                    ddlEmpday.DataValueField = "NOOFWORKERSYEARS_ID";
                    ddlEmpday.DataTextField = "NOOFWORKERS_NAME";
                    ddlEmpday.DataBind();


                }
                else
                {
                    ddlEmpday.DataSource = null;
                    ddlEmpday.DataBind();


                }
                AddSelect(ddlEmpday);


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindGenerating()
        {
            try
            {
                ddlGenerating.Items.Clear();

                List<MasterDGPOWER> objDGPOWERModel = new List<MasterDGPOWER>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
                objDGPOWERModel = mstrBAL.GetDGPOWER();
                if (objDGPOWERModel != null)
                {
                    ddlGenerating.DataSource = objDGPOWERModel;
                    ddlGenerating.DataValueField = "DGPOWER_ID";
                    ddlGenerating.DataTextField = "DGPOWER_NAME";
                    ddlGenerating.DataBind();

                }
                else
                {
                    ddlGenerating.DataSource = null;
                    ddlGenerating.DataBind();
                }
                AddSelect(ddlGenerating);


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Renewal/RENContractLabourDeatils.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/Renewal/ContractorMigrantWork.aspx?Previous=" + "P");
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