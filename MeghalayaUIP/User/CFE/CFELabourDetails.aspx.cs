using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFELabourDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
        string UnitID, result, ErrorMsg = "";
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
                    if (Convert.ToString(Session["CFEUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["CFEUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }

                    Page.MaintainScrollPositionOnPostBack = true;

                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindDistricts();
                        //BindConstitutionType();
                        BindCategoryEST();
                        //BindDistric();
                        //BindDatas();
                        //BindDataMigrant();
                        GetAppliedorNot();
                        BindData();
                        BindingData();

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
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "10", "");


                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "25")
                        {
                            divsupervision.Visible = true;
                            divContrLabr.Visible = true;
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "26")
                        {
                            divsupervision.Visible = true;
                            divMigrLabr.Visible = true;
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "27")
                        {
                            div4questions.Visible = true;
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "28")
                        {
                            divsupervision.Visible = true;
                            div4questions.Visible = true;
                            div5questions.Visible = true;
                            divAgentDtls.Visible = true;
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "29")
                        {
                            div5questions.Visible = true;
                            divContractorDtls.Visible = true;
                        }
                    }

                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFEUploadEnclosures.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFE/CFEWaterDetails.aspx?Previous=" + "P");
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
        protected void BindDistricts()
        {
            try
            {

                ddlDistric.Items.Clear();
                ddlMandals.Items.Clear();
                ddlvillages.Items.Clear();
                ddlDistricts.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();
                ddldist.Items.Clear();
                ddlmand.Items.Clear();
                ddlvilla.Items.Clear();
                //ddlDistdrop.Items.Clear();
                //ddlAuthReprTaluka.Items.Clear();
                //ddlAuthReprVillage.Items.Clear();
                ddlPropLocDist.Items.Clear();
                ddlPropLocTaluka.Items.Clear();
                ddlPropLocVillage.Items.Clear();




                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlDistric.DataSource = objDistrictModel;
                    ddlDistric.DataValueField = "DistrictId";
                    ddlDistric.DataTextField = "DistrictName";
                    ddlDistric.DataBind();

                    ddlDistricts.DataSource = objDistrictModel;
                    ddlDistricts.DataValueField = "DistrictId";
                    ddlDistricts.DataTextField = "DistrictName";
                    ddlDistricts.DataBind();


                    ddldist.DataSource = objDistrictModel;
                    ddldist.DataValueField = "DistrictId";
                    ddldist.DataTextField = "DistrictName";
                    ddldist.DataBind();

                    //ddlDistdrop.DataSource = objDistrictModel;
                    //ddlDistdrop.DataValueField = "DistrictId";
                    //ddlDistdrop.DataTextField = "DistrictName";
                    //ddlDistdrop.DataBind();

                    ddlPropLocDist.DataSource = objDistrictModel;
                    ddlPropLocDist.DataValueField = "DistrictId";
                    ddlPropLocDist.DataTextField = "DistrictName";
                    ddlPropLocDist.DataBind();




                }
                else
                {
                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();

                    ddlDistricts.DataSource = null;
                    ddlDistricts.DataBind();

                    ddldist.DataSource = null;
                    ddldist.DataBind();

                    ddlPropLocDist.DataSource = null;
                    ddlPropLocDist.DataBind();


                }
                AddSelect(ddlDistric);
                AddSelect(ddlMandals);
                AddSelect(ddlvillages);

                AddSelect(ddlDistricts);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

                AddSelect(ddldist);
                AddSelect(ddlmand);
                AddSelect(ddlvilla);

                //AddSelect(ddlDistdrop);
                //AddSelect(ddlAuthReprTaluka);
                //AddSelect(ddlAuthReprVillage);

                AddSelect(ddlPropLocDist);
                AddSelect(ddlPropLocTaluka);
                AddSelect(ddlPropLocVillage);


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void BindDistric()
        {
            try
            {

                ddlDistric.Items.Clear();
                ddlMandals.Items.Clear();
                ddlvillages.Items.Clear();
                ddlDistricts.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();
                ddldist.Items.Clear();
                ddlmand.Items.Clear();
                ddlvilla.Items.Clear();
                ddlPropLocDist.Items.Clear();
                ddlPropLocTaluka.Items.Clear();
                ddlPropLocVillage.Items.Clear();


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

                    ddlDistricts.DataSource = objDistrictModel;
                    ddlDistricts.DataValueField = "DistrictId";
                    ddlDistricts.DataTextField = "DistrictName";
                    ddlDistricts.DataBind();


                    ddldist.DataSource = objDistrictModel;
                    ddldist.DataValueField = "DistrictId";
                    ddldist.DataTextField = "DistrictName";
                    ddldist.DataBind();

                    ddlPropLocDist.DataSource = objDistrictModel;
                    ddlPropLocDist.DataValueField = "DistrictId";
                    ddlPropLocDist.DataTextField = "DistrictName";
                    ddlPropLocDist.DataBind();


                }
                else
                {
                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();

                    ddlDistricts.DataSource = null;
                    ddlDistricts.DataBind();

                    ddldist.DataSource = null;
                    ddldist.DataBind();

                    //ddlDistdrop.DataSource = null;
                    //ddlDistdrop.DataBind();

                    ddlPropLocDist.DataSource = null;
                    ddlPropLocDist.DataBind();
                }
                AddSelect(ddlDistric);
                AddSelect(ddlMandals);
                AddSelect(ddlvillages);

                AddSelect(ddlDistricts);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

                AddSelect(ddldist);
                AddSelect(ddlmand);
                AddSelect(ddlvilla);

                AddSelect(ddlPropLocDist);
                AddSelect(ddlPropLocTaluka);
                AddSelect(ddlPropLocVillage);


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void BindCategoryEST()
        {
            try
            {
                ddlCategory.Items.Clear();

                List<MasterCategoryEst> objCategoryModel = new List<MasterCategoryEst>();

                objCategoryModel = mstrBAL.GetCategoryEST();
                if (objCategoryModel != null)
                {
                    ddlCategory.DataSource = objCategoryModel;
                    ddlCategory.DataValueField = "CATEGORYEST_ID";
                    ddlCategory.DataTextField = "CATEGORYEST_NAME";
                    ddlCategory.DataBind();
                }
                else
                {
                    ddlCategory.DataSource = null;
                    ddlCategory.DataBind();
                }
                AddSelect(ddlCategory);
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
        //public void BindDatas()
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        ds = objcfebal.GetRetriveCFELabourContractorDet(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));

        //        if (ds != null)
        //        {
        //            if (ds.Tables.Count > 0)
        //            {
        //                //if (ds.Tables[0].Rows.Count > 0)
        //                //{
        //                //    //ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_UNITID"]);
        //                //    txtNameAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_CONTRACTORNAMEADDRESS"]);
        //                //    txtLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_WORKNAMENATURELOCATION"]);
        //                //    ddlMaximumNo.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_MAXCONTRACTLABOUR"]);
        //                //    txtContactWork.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_CONTRACTDURATION"]);
        //                //    txtEstimated.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_COMMENCEMENTDATEOFWORK"]);
        //                //    txtDateWork.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_COMPLETIONDATEOFWORK"]);
        //                //    txtEmployeeLabour.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_TERMINATIONDATEOFEMP"]);
        //                //}

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void BindDataMigrant()
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        ds = objcfebal.GetRetriveCFEMigrantDetails(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));

        //        if (ds != null)
        //        {
        //            if (ds.Tables.Count > 0)
        //            {
        //                //if (ds.Tables[0].Rows.Count > 0)
        //                //{
        //                //    //ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_UNITID"]);
        //                //    txtAddressName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_CONTRACTORNAMEADDRESS"]);
        //                //    txtEmployedName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_MIGRANTNAMENATURELOCATION"]);
        //                //    txtMaxmigrant.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_MAXCONTRACTMIGRANT"]);
        //                //    txtContractwork.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_CONTRACTDURATION"]);
        //                //    txtEstwork.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_COMMENCEMENTDATE"]);
        //                //    txtEstDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_COMPLETIONDATEOFWORK"]);
        //                //    txtEstDateWork.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_TERMINATIONDATEOFEMPMigrant"]);
        //                //}

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetRetriveCFELabourDet(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ddlCategory.SelectedValue = ds.Tables[0].Rows[0]["CFELD_CATEGORY_ESTABLISHMENT"].ToString();
                        txtname1.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_NAME"]);
                        txtfather.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_FATHERNAME"]);
                        txtage.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_AGE"]);
                        txtdesignation.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_DESIGNATION"]);
                        txtmobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MOBILENO"]);
                        txtEmail1.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_EMAILID"]);
                        ddlPropLocDist.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_DISTRICSID"]);
                        ddlPropLocDist_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlPropLocTaluka.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANDALSID"]);
                        ddlPropLocTaluka_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlPropLocVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_VILLAGESID"]);
                        txtdoor3.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_DOOR"]);
                        txtlocality3.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_LOCALITY"]);
                        TXTPIN.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_PINCODE"]);
                        if (divsupervision.Visible == true)
                        {
                            txtnames.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANAGERNAME"]);
                            txtMobilenumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANAGERMOBILENO"]);
                            txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANAGEREMAILID"]);
                            txtFathersname.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANAGERFATHERNAME"]);
                            txtDoor1.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANAGERDOOR"]);
                            txtLocality1.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANAGERLOCALITY"]);
                            ddlDistricts.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANAGERDISTRICSID"]);
                            ddlDistricts_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANAGERMANDALSID"]);
                            ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANAGERVILLAGESID"]);
                            txtpincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANAGERPINCODE"]);
                            txtDesignations.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANAGERDESIGNATION"]);
                        }
                        else { divsupervision.Visible = false; }

                        if (div4questions.Visible == true)
                        {
                            txtLabourEmp.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_NATUREOFWORKLABOUREMP"]);
                            txtconstructionwork.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_ESTDATEBUILDING"]);
                            txtContractEmployees.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MAXNUMBEROFCONTRACTEMP"]);
                            txtbuilding.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_ESTDATEOFCONSTRUCTIONWORK"]);
                        }
                        else { div4questions.Visible = false; }

                        if (div5questions.Visible == true)
                        {
                            txtMaximum.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MAXNUMBERMIGRANTESTDATE"]);
                            rblconvicted.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_CONTRACTORCONVICTED5YEARS"]);
                            rblrevoking.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_REVOKINGSUSPENDINGLIC"]);
                            rblcontractor.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_ESTPAST5YEARSNATUREOFWORK"]);
                            ddlbusiness.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_INDUSTRYMANUOCCUPATIONEST"]);
                        }
                        else { div5questions.Visible = false; }

                        if (divContractorDtls.Visible == true)
                        {
                            txtcontractor.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_CONTRACTORNAMECONTRACTOR"]);
                            txtfathername.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_CONTRACTORFATHER"]);
                            txtAges.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_CONTRACTORAGES"]);
                            txtmobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_CONTRACTORMOBILE"]);
                            txtemailid.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_CONTRACTOREMAIL"]);
                            ddlDistric.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_CONTRACTORDISTID"]);
                            ddlDistric_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlMandals.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_CONTRACTORMANDALID"]);
                            ddlMandals_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlvillages.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_CONTRACTORVILLAGEID"]);
                            txtdoorno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_CONTRACTORDOORNO"]);
                            txtlocal.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_CONTRACTORLOCALITYNAME"]);
                            txtpinnumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_CONTRACTORPIN"]);
                        }
                        else { divContractorDtls.Visible = false; }

                        if (divAgentDtls.Visible == true)
                        {
                            txtname.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_AGENTNAME"]);
                            txtDoor.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_AGENTDOORNO"]);
                            txtLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_AGENTLOCALITY"]);
                            ddldist.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_AGENTDISTRICT"]);
                            ddldist_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlmand.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_AGENTMANDAL"]);
                            ddlmand_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlvilla.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_AGENTVILLAGE"]);
                            txtAgentPincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_AGENTPINCODE"]);
                        }
                        else { divAgentDtls.Visible = false; }

                    }
                    if (divContrLabr.Visible == true)
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            ViewState["LabourDetails"] = ds.Tables[1];
                            GVLabour.DataSource = ds.Tables[1];
                            GVLabour.DataBind();
                            GVLabour.Visible = true;
                        }
                    }
                    else { divContrLabr.Visible = false; }

                    if (divMigrLabr.Visible == true)
                    {
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            ViewState["MIGRANTDETAILS"] = ds.Tables[2];
                            GVMigrant.DataSource = ds.Tables[2];
                            GVMigrant.DataBind();
                            GVMigrant.Visible = true;
                        }
                    }
                    else { divMigrLabr.Visible = false; }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                        {
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFEA_MASTERAID"]) == 16)
                            {
                                hplLicgrant.Visible = true;
                                hplLicgrant.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["FILELOCATION"]));
                                hplLicgrant.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFEA_MASTERAID"]) == 17)
                            {
                                hplForm5.Visible = true;
                                hplForm5.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["FILELOCATION"]));
                                hplForm5.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFEA_MASTERAID"]) == 18)
                            {
                                hplForm8.Visible = true;
                                hplForm8.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["FILELOCATION"]));
                                hplForm8.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFEA_MASTERAID"]) == 19)
                            {
                                hplForm10.Visible = true;
                                hplForm10.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["FILELOCATION"]));
                                hplForm10.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFEA_MASTERAID"]) == 20)
                            {
                                hplCrimeForm10.Visible = true;
                                hplCrimeForm10.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["FILELOCATION"]));
                                hplCrimeForm10.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFEA_MASTERAID"]) == 21)
                            {
                                hplEmployer.Visible = true;
                                hplEmployer.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["FILELOCATION"]));
                                hplEmployer.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFEA_FILENAME"]);
                            }
                        }

                    }


                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindingData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetCFEAttachmentsData(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //hdnUserID.Value = Convert.ToString(ds.Tables[0].Rows[0]["CFEQDID"]);

                        }

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
        protected void ddlDistric_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandals.ClearSelection();
                ddlvillages.ClearSelection();
                if (ddlDistric.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandals, ddlDistric.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlMandals_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlvillages.ClearSelection();
                if (ddlMandals.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlvillages, ddlMandals.SelectedValue);
                }
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlDistricts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlMandal.Items.Clear();
                AddSelect(ddlMandal);
                ddlVillage.ClearSelection();
                ddlVillage.Items.Clear();
                AddSelect(ddlVillage);
                if (ddlDistricts.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistricts.SelectedValue);
                }
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
                ddlVillage.Items.Clear();
                AddSelect(ddlVillage);
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
        protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlmand.ClearSelection();
                ddlmand.Items.Clear();
                AddSelect(ddlmand);
                ddlvilla.ClearSelection();
                ddlvilla.Items.Clear();
                AddSelect(ddlvilla);
                if (ddldist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlmand, ddldist.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlmand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlvilla.ClearSelection();
                ddlvilla.Items.Clear();
                AddSelect(ddlvilla);
                if (ddlmand.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlvilla, ddlmand.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlAuthReprDist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlPropLocDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPropLocTaluka.ClearSelection();
                ddlPropLocTaluka.Items.Clear();
                AddSelect(ddlPropLocTaluka);
                ddlPropLocVillage.ClearSelection();
                ddlPropLocVillage.Items.Clear();
                AddSelect(ddlPropLocVillage);
                if (ddlPropLocDist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlPropLocTaluka, ddlPropLocDist.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlPropLocTaluka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPropLocVillage.ClearSelection();
                ddlPropLocVillage.Items.Clear();
                AddSelect(ddlPropLocVillage);
                if (ddlPropLocTaluka.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlPropLocVillage, ddlPropLocTaluka.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlDistricdist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //ddlMandalmand.ClearSelection();
                //ddlvillagevill.ClearSelection();
                //if (ddlDistricdist.SelectedItem.Text != "--Select--")
                //{
                //    BindMandal(ddlMandalmand, ddlDistricdist.SelectedValue);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlMandalmand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //ddlvillagevill.ClearSelection();
                //if (ddlMandalmand.SelectedItem.Text != "--Select--")
                //{
                //    BindVillages(ddlvillagevill, ddlMandalmand.SelectedValue);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNameAddress.Text.Trim()) || string.IsNullOrEmpty(txtLocation.Text.Trim()) || string.IsNullOrEmpty(txtContactWork.Text) || string.IsNullOrEmpty(txtEstimated.Text) || string.IsNullOrEmpty(txtDateWork.Text) || string.IsNullOrEmpty(txtEmployeeLabour.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFECL_UNITID", typeof(string));
                    dt.Columns.Add("CFECL_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFECL_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFECL_CONTRACTORNAMEADDRESS", typeof(string));
                    dt.Columns.Add("CFECL_WORKNAMENATURELOCATION", typeof(string));
                    dt.Columns.Add("CFECL_MAXCONTRACTLABOUR", typeof(string));
                    dt.Columns.Add("CFECL_CONTRACTDURATION", typeof(string));
                    dt.Columns.Add("CFECL_COMMENCEMENTDATEOFWORK", typeof(string));
                    dt.Columns.Add("CFECL_COMPLETIONDATEOFWORK", typeof(string));
                    dt.Columns.Add("CFECL_TERMINATIONDATEOFEMP", typeof(string));

                    if (ViewState["LabourDetails"] != null)
                    {
                        dt = (DataTable)ViewState["LabourDetails"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFECL_UNITID"] = Convert.ToString(Session["CFEUNITID"]);
                    dr["CFECL_CREATEDBY"] = hdnUserID.Value;
                    dr["CFECL_CREATEDBYIP"] = getclientIP();
                    dr["CFECL_CONTRACTORNAMEADDRESS"] = txtNameAddress.Text.Trim();
                    dr["CFECL_WORKNAMENATURELOCATION"] = txtLocation.Text.Trim();
                    dr["CFECL_MAXCONTRACTLABOUR"] = ddlMaximumNo.SelectedItem.Text;
                    dr["CFECL_CONTRACTDURATION"] = txtContactWork.Text;

                    dr["CFECL_COMMENCEMENTDATEOFWORK"] = txtEstimated.Text;
                    dr["CFECL_COMPLETIONDATEOFWORK"] = txtDateWork.Text;
                    dr["CFECL_TERMINATIONDATEOFEMP"] = txtEmployeeLabour.Text;

                    dt.Rows.Add(dr);
                    GVLabour.Visible = true;
                    GVLabour.DataSource = dt;
                    GVLabour.DataBind();
                    ViewState["LabourDetails"] = dt;

                    txtNameAddress.Text = "";
                    txtLocation.Text = "";
                    ddlMaximumNo.ClearSelection();
                    txtContactWork.Text = "";
                    txtEstimated.Text = "";
                    txtDateWork.Text = "";
                    txtEmployeeLabour.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GVLabour_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                if (GVLabour.Rows.Count > 0)
                {
                    ((DataTable)ViewState["LabourDetails"]).Rows.RemoveAt(e.RowIndex);
                    this.GVLabour.DataSource = ((DataTable)ViewState["LabourDetails"]).DefaultView;
                    this.GVLabour.DataBind();
                    GVLabour.Visible = true;
                    GVLabour.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnAddMigrant_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAddressName.Text.Trim()) || string.IsNullOrEmpty(txtEmployedName.Text) || string.IsNullOrEmpty(txtMaxmigrant.Text) || string.IsNullOrEmpty(txtContractwork.Text) || string.IsNullOrEmpty(txtEstwork.Text) || string.IsNullOrEmpty(txtEstDate.Text) || string.IsNullOrEmpty(txtEstDateWork.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFEMW_UNITID", typeof(string));
                    dt.Columns.Add("CFEMW_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFEMW_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFEMW_CONTRACTORNAMEADDRESS", typeof(string));
                    dt.Columns.Add("CFEMW_MIGRANTNAMENATURELOCATION", typeof(string));
                    dt.Columns.Add("CFEMW_MAXCONTRACTMIGRANT", typeof(string));
                    dt.Columns.Add("CFEMW_CONTRACTDURATION", typeof(string));
                    dt.Columns.Add("CFEMW_COMMENCEMENTDATE", typeof(string));
                    dt.Columns.Add("CFEMW_COMPLETIONDATEOFWORK", typeof(string));
                    dt.Columns.Add("CFEMW_TERMINATIONDATEOFEMPMigrant", typeof(string));

                    if (ViewState["MIGRANTDETAILS"] != null)
                    {
                        dt = (DataTable)ViewState["MIGRANTDETAILS"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFEMW_UNITID"] = Convert.ToString(Session["CFEUNITID"]);
                    dr["CFEMW_CREATEDBY"] = hdnUserID.Value;
                    dr["CFEMW_CREATEDBYIP"] = getclientIP();
                    dr["CFEMW_CONTRACTORNAMEADDRESS"] = txtAddressName.Text.Trim();
                    dr["CFEMW_MIGRANTNAMENATURELOCATION"] = txtEmployedName.Text;
                    dr["CFEMW_MAXCONTRACTMIGRANT"] = txtMaxmigrant.Text;
                    dr["CFEMW_CONTRACTDURATION"] = txtContractwork.Text;
                    dr["CFEMW_COMMENCEMENTDATE"] = txtEstwork.Text;
                    dr["CFEMW_COMPLETIONDATEOFWORK"] = txtEstDate.Text;
                    dr["CFEMW_TERMINATIONDATEOFEMPMigrant"] = txtEstDateWork.Text;

                    dt.Rows.Add(dr);
                    GVMigrant.Visible = true;
                    GVMigrant.DataSource = dt;
                    GVMigrant.DataBind();
                    ViewState["MIGRANTDETAILS"] = dt;

                    txtAddressName.Text = "";
                    txtEmployedName.Text = "";
                    txtMaxmigrant.Text = "";
                    txtContractwork.Text = "";
                    txtEstwork.Text = "";
                    txtEstDate.Text = "";
                    txtEstDateWork.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GVMigrant_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVMigrant.Rows.Count > 0)
                {
                    ((DataTable)ViewState["MIGRANTDETAILS"]).Rows.RemoveAt(e.RowIndex);
                    this.GVMigrant.DataSource = ((DataTable)ViewState["MIGRANTDETAILS"]).DefaultView;
                    this.GVMigrant.DataBind();
                    GVMigrant.Visible = true;
                    GVMigrant.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnUpldLICgrant_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLicgrant.HasFile)
                {
                    Error = validations(fupLicgrant);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnUserID.Value + "\\" + "License Grant" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupLicgrant.PostedFile.SaveAs(serverpath + "\\" + fupLicgrant.PostedFile.FileName);

                        CFEAttachments objAadhar = new CFEAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objAadhar.MasterID = "16";
                        objAadhar.FilePath = serverpath + fupLicgrant.PostedFile.FileName;
                        objAadhar.FileName = fupLicgrant.PostedFile.FileName;
                        objAadhar.FileType = fupLicgrant.PostedFile.ContentType;
                        objAadhar.FileDescription = "License Grant";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objAadhar);
                        if (result != "")
                        {
                            hplLicgrant.Text = fupLicgrant.PostedFile.FileName;
                            hplLicgrant.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hplLicgrant.Target = "blank";
                            message = "alert('" + "License Grant Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
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
        public string validations(FileUpload Attachment)
        {
            try
            {
                string filesize = Convert.ToString(ConfigurationManager.AppSettings["FileSize"].ToString());
                int slno = 1; string Error = "";

                //if (Attachment.PostedFile.ContentType != "application/pdf"
                //     || !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                //{

                if (Attachment.PostedFile.ContentType != "application/pdf")
                {
                    Error = Error + slno + ". Please Upload PDF Documents only \\n";
                    slno = slno + 1;
                }
                if (Attachment.PostedFile.ContentLength >= Convert.ToInt32(filesize))
                {
                    Error = Error + slno + ". Please Upload file size less than " + Convert.ToInt32(filesize) / 1000000 + "MB \\n";
                    slno = slno + 1;
                }
                if (!ValidateFileName(Attachment.PostedFile.FileName))
                {
                    Error = Error + slno + ". Document name should not contain symbols like  <, >, %, $, @, &,=, / \\n";
                    slno = slno + 1;
                }
                else if (!ValidateFileExtension(Attachment))
                {
                    Error = Error + slno + ". Document should not contain double extension (double . ) \\n";
                    slno = slno + 1;
                }
                // }
                return Error;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static bool ValidateFileName(string fileName)
        {
            try
            {
                string pattern = @"[<>%$@&=!:*?|]";

                if (Regex.IsMatch(fileName, pattern))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            { throw ex; }
        }
        protected void btnUpldForm5_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupForm5.HasFile)
                {
                    Error = validations(fupForm5);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnUserID.Value + "\\" + "Form5" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupForm5.PostedFile.SaveAs(serverpath + "\\" + fupForm5.PostedFile.FileName);

                        CFEAttachments objApplPhoto = new CFEAttachments();
                        objApplPhoto.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objApplPhoto.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objApplPhoto.MasterID = "17";
                        objApplPhoto.FilePath = serverpath + fupForm5.PostedFile.FileName;
                        objApplPhoto.FileName = fupForm5.PostedFile.FileName;
                        objApplPhoto.FileType = fupForm5.PostedFile.ContentType;
                        objApplPhoto.FileDescription = "Form 5";
                        objApplPhoto.CreatedBy = hdnUserID.Value;
                        objApplPhoto.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objApplPhoto);
                        if (result != "")
                        {
                            hplForm5.Text = fupForm5.PostedFile.FileName;
                            hplForm5.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objApplPhoto.FilePath);
                            hplForm5.Target = "blank";
                            message = "alert('" + "Form5 Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
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
        protected void btnUpldForm8_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupForm8.HasFile)
                {
                    Error = validations(fupForm8);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + hdnUserID.Value + "\\" + "Form 8" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupForm8.PostedFile.SaveAs(serverpath + "\\" + fupForm8.PostedFile.FileName);

                        CFEAttachments objLandDoc = new CFEAttachments();
                        objLandDoc.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objLandDoc.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objLandDoc.MasterID = "18";
                        objLandDoc.FilePath = serverpath + fupForm8.PostedFile.FileName;
                        objLandDoc.FileName = fupForm8.PostedFile.FileName;
                        objLandDoc.FileType = fupForm8.PostedFile.ContentType;
                        objLandDoc.FileDescription = "Form 8";
                        objLandDoc.CreatedBy = hdnUserID.Value;
                        objLandDoc.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objLandDoc);
                        if (result != "")
                        {
                            hplForm8.Text = fupForm8.PostedFile.FileName;
                            hplForm8.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objLandDoc.FilePath);
                            hplForm8.Target = "blank";
                            message = "alert('" + "Form 8 Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
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
        protected void btnUplForm10_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupForm10.HasFile)
                {
                    Error = validations(fupForm10);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + hdnUserID.Value + "\\" + "Form 10" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupForm10.PostedFile.SaveAs(serverpath + "\\" + fupForm10.PostedFile.FileName);

                        CFEAttachments objSitePlan = new CFEAttachments();
                        objSitePlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objSitePlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objSitePlan.MasterID = "19";
                        objSitePlan.FilePath = serverpath + fupForm10.PostedFile.FileName;
                        objSitePlan.FileName = fupForm10.PostedFile.FileName;
                        objSitePlan.FileType = fupForm10.PostedFile.ContentType;
                        objSitePlan.FileDescription = "Form 10";
                        objSitePlan.CreatedBy = hdnUserID.Value;
                        objSitePlan.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objSitePlan);
                        if (result != "")
                        {
                            hplForm10.Text = fupForm10.PostedFile.FileName;
                            hplForm10.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objSitePlan.FilePath);
                            hplForm10.Target = "blank";
                            message = "alert('" + "Form 10 Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
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
        protected void btnUpldCrimeForm10_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupCrimeForm10.HasFile)
                {
                    Error = validations(fupCrimeForm10);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + hdnUserID.Value + "\\" + "Criminal Issues" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupCrimeForm10.PostedFile.SaveAs(serverpath + "\\" + fupCrimeForm10.PostedFile.FileName);

                        CFEAttachments objSitePlan = new CFEAttachments();
                        objSitePlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objSitePlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objSitePlan.MasterID = "20";
                        objSitePlan.FilePath = serverpath + fupCrimeForm10.PostedFile.FileName;
                        objSitePlan.FileName = fupCrimeForm10.PostedFile.FileName;
                        objSitePlan.FileType = fupCrimeForm10.PostedFile.ContentType;
                        objSitePlan.FileDescription = "Criminal Issued";
                        objSitePlan.CreatedBy = hdnUserID.Value;
                        objSitePlan.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objSitePlan);
                        if (result != "")
                        {
                            hplCrimeForm10.Text = fupCrimeForm10.PostedFile.FileName;
                            hplCrimeForm10.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objSitePlan.FilePath);
                            hplCrimeForm10.Target = "blank";
                            message = "alert('" + "Residence and Criminal antecedents issued by District Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
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
        protected void btnUplEmployer_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupemployer.HasFile)
                {
                    Error = validations(fupemployer);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + hdnUserID.Value + "\\" + "Employer" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupemployer.PostedFile.SaveAs(serverpath + "\\" + fupemployer.PostedFile.FileName);

                        CFEAttachments objSitePlan = new CFEAttachments();
                        objSitePlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objSitePlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objSitePlan.MasterID = "21";
                        objSitePlan.FilePath = serverpath + fupemployer.PostedFile.FileName;
                        objSitePlan.FileName = fupemployer.PostedFile.FileName;
                        objSitePlan.FileType = fupemployer.PostedFile.ContentType;
                        objSitePlan.FileDescription = "Employer";
                        objSitePlan.CreatedBy = hdnUserID.Value;
                        objSitePlan.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objSitePlan);
                        if (result != "")
                        {
                            hplEmployer.Text = fupemployer.PostedFile.FileName;
                            hplEmployer.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objSitePlan.FilePath);
                            hplEmployer.Target = "blank";
                            message = "alert('" + "Principle Employer Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
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
        public static bool ValidateFileExtension(FileUpload Attachment)
        {
            try
            {
                string Attachmentname = Attachment.PostedFile.FileName;
                string[] fileType = Attachmentname.Split('.');
                int i = fileType.Length;

                if (i == 2 && fileType[i - 1].ToUpper().Trim() == "PDF")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            { throw ex; }
        }
        protected void Btnsave_Click(object sender, EventArgs e)
        {
            //String Quesstionriids = "1001";
            //string UnitId = "1";

            try
            {
                //  string result = "";
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    Labour_Details ObjCFELabourDet = new Labour_Details();
                    int count = 0, count1 = 0;
                    for (int i = 0; i < GVLabour.Rows.Count; i++)
                    {
                        ObjCFELabourDet.Questionnariid = Convert.ToString(Session["CFEQID"]);
                        ObjCFELabourDet.CreatedBy = hdnUserID.Value;
                        ObjCFELabourDet.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        ObjCFELabourDet.IPAddress = getclientIP();
                        ObjCFELabourDet.CFECL_CONTRACTORNAMEADDRESS = GVLabour.Rows[i].Cells[1].Text;
                        ObjCFELabourDet.CFECL_WORKNAMENATURELOCATION = GVLabour.Rows[i].Cells[2].Text;
                        ObjCFELabourDet.CFECL_MAXCONTRACTLABOUR = GVLabour.Rows[i].Cells[3].Text;
                        ObjCFELabourDet.CFECL_CONTRACTDURATION = GVLabour.Rows[i].Cells[4].Text;
                        ObjCFELabourDet.CFECL_COMMENCEMENTDATEOFWORK = GVLabour.Rows[i].Cells[5].Text;
                        ObjCFELabourDet.CFECL_COMPLETIONDATEOFWORK = GVLabour.Rows[i].Cells[6].Text;
                        ObjCFELabourDet.CFECL_TERMINATIONDATEOFEMP = GVLabour.Rows[i].Cells[7].Text;

                        string A = objcfebal.InsertCFElabourContractor(ObjCFELabourDet);
                        if (A != "")
                        { count = count + 1; }

                    }
                    if (GVLabour.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "LABOUR CONTRACTOR Details Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    for (int i = 0; i < GVMigrant.Rows.Count; i++)
                    {
                        ObjCFELabourDet.Questionnariid = Convert.ToString(Session["CFEQID"]);
                        ObjCFELabourDet.CreatedBy = hdnUserID.Value;
                        ObjCFELabourDet.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        ObjCFELabourDet.IPAddress = getclientIP();
                        ObjCFELabourDet.CONTRACTORNAMEADDRESS = GVMigrant.Rows[i].Cells[1].Text;
                        ObjCFELabourDet.MIGRANTNAMENATURELOCATION = GVMigrant.Rows[i].Cells[2].Text;
                        ObjCFELabourDet.MAXCONTRACTMIGRANT = GVMigrant.Rows[i].Cells[3].Text;
                        ObjCFELabourDet.CONTRACTDURATION = GVMigrant.Rows[i].Cells[4].Text;
                        ObjCFELabourDet.COMMENCEMENTDATE = GVMigrant.Rows[i].Cells[5].Text;
                        ObjCFELabourDet.COMPLETIONDATEOFWORK = GVMigrant.Rows[i].Cells[6].Text;
                        ObjCFELabourDet.TERMINATIONDATEOFEMPMigrant = GVMigrant.Rows[i].Cells[7].Text;

                        string A = objcfebal.InsertMigrantDetails(ObjCFELabourDet);
                        if (A != "")
                        { count1 = count1 + 1; }
                    }
                    if (GVMigrant.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "LABOUR CONTRACTOR Details Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                    ObjCFELabourDet.UNITID = Convert.ToString(Session["CFEUNITID"]);
                    ObjCFELabourDet.CreatedBy = hdnUserID.Value;
                    ObjCFELabourDet.IPAddress = getclientIP();
                    ObjCFELabourDet.Questionnariid = Convert.ToString(Session["CFEQID"]);
                    ObjCFELabourDet.UnitId = Convert.ToString(Session["CFEUNITID"]);

                    ObjCFELabourDet.Category_Estab = ddlCategory.SelectedValue;
                    ObjCFELabourDet.Name_Contractor = txtname1.Text.Trim();
                    ObjCFELabourDet.Father_Name = txtfather.Text.Trim();
                    ObjCFELabourDet.Age = txtage.Text;
                    ObjCFELabourDet.Designation = txtdesignation.Text.Trim();
                    ObjCFELabourDet.MobileNo = txtmobile.Text;
                    ObjCFELabourDet.EmailId = txtEmail1.Text;
                    ObjCFELabourDet.District = ddlPropLocDist.SelectedValue;
                    ObjCFELabourDet.DistrictName = ddlPropLocDist.SelectedItem.Text;
                    ObjCFELabourDet.Mandal = ddlPropLocTaluka.SelectedValue;
                    ObjCFELabourDet.MandalName = ddlPropLocTaluka.SelectedItem.Text;
                    ObjCFELabourDet.Village = ddlPropLocVillage.SelectedValue;
                    ObjCFELabourDet.VillageName = ddlPropLocVillage.SelectedItem.Text;
                    ObjCFELabourDet.Door_No = txtdoor3.Text.Trim();
                    ObjCFELabourDet.Locality = txtlocality3.Text.Trim();
                    ObjCFELabourDet.Pincode = TXTPIN.Text;

                    ObjCFELabourDet.ManagerName = txtnames.Text.Trim();
                    ObjCFELabourDet.ManagerMobile = txtMobilenumber.Text;
                    ObjCFELabourDet.ManagerEmail = txtEmail.Text;
                    ObjCFELabourDet.ManagerFather = txtFathersname.Text.Trim();
                    ObjCFELabourDet.ManagerDoor = txtDoor1.Text.Trim();
                    ObjCFELabourDet.ManagerLocality = txtLocality1.Text.Trim();
                    ObjCFELabourDet.ManagerDistrict = ddlDistricts.SelectedValue;
                    ObjCFELabourDet.ManagerMandal = ddlMandal.SelectedValue;
                    ObjCFELabourDet.ManagerVillage = ddlVillage.SelectedValue;
                    ObjCFELabourDet.ManagerPincode = txtpincode.Text;
                    ObjCFELabourDet.ManagerDesignation = txtDesignations.Text;

                    ObjCFELabourDet.NatureOflabourCont = txtLabourEmp.Text.Trim();
                    ObjCFELabourDet.BuildingContractWork = txtconstructionwork.Text.Trim();
                    ObjCFELabourDet.BuildingEmpDay = txtContractEmployees.Text.Trim();
                    ObjCFELabourDet.EstDateBuilding = txtbuilding.Text.Trim();
                    ObjCFELabourDet.MigrantWork = txtMaximum.Text.Trim();
                    ObjCFELabourDet.ContractFiveYears = rblconvicted.SelectedValue;
                    ObjCFELabourDet.Revoking = rblrevoking.SelectedValue;
                    ObjCFELabourDet.PrincipleEmpWork = rblcontractor.SelectedValue;
                    ObjCFELabourDet.ManuooCupation = ddlbusiness.SelectedValue;

                    ObjCFELabourDet.ContarctorName = txtcontractor.Text.Trim();
                    ObjCFELabourDet.ContarctorFather = txtfathername.Text.Trim();
                    ObjCFELabourDet.ContarctorAge = txtAges.Text;
                    ObjCFELabourDet.ContarctorMobile = txtmobileno.Text;
                    ObjCFELabourDet.ContarctorEmailId = txtemailid.Text;
                    ObjCFELabourDet.ContarctorDistrict = ddlDistric.SelectedValue;
                    ObjCFELabourDet.ContarctorMandals = ddlMandals.SelectedValue;
                    ObjCFELabourDet.ContarctorVillages = ddlvillages.SelectedValue;
                    ObjCFELabourDet.ContarctorDoor = txtdoorno.Text.Trim();
                    ObjCFELabourDet.ContarctorLocality = txtlocal.Text.Trim();
                    ObjCFELabourDet.ContarctorPincode = txtpinnumber.Text;
                    ObjCFELabourDet.AgentName = txtname.Text;
                    ObjCFELabourDet.AgentDoorNo = txtDoor.Text;
                    ObjCFELabourDet.AgentLocality = txtLocality.Text;
                    ObjCFELabourDet.AgentDistric = ddldist.SelectedValue;
                    ObjCFELabourDet.AgentMandal = ddlmand.SelectedValue;
                    ObjCFELabourDet.AgentVillage = ddlvilla.SelectedValue;
                    ObjCFELabourDet.AgentPinCode = txtAgentPincode.Text;



                    result = objcfebal.InsertCFELabourDetails(ObjCFELabourDet);
                    //ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Labour Details Submitted Successfully";
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
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);

                if (ddlCategory.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Category of Establishment \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtname1.Text.Trim()) || txtname1.Text.Trim() == "" || txtname1.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter NAME \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtfather.Text.Trim()) || txtfather.Text.Trim() == "" || txtfather.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter FatherName \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtage.Text) || txtage.Text == "" || txtage.Text == null || txtage.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtage.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Age \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdesignation.Text.Trim()) || txtdesignation.Text.Trim() == "" || txtdesignation.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Desigantion \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtmobile.Text) || txtmobile.Text == "" || txtmobile.Text == null || txtmobile.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtmobile.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile No \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmail1.Text) || txtEmail1.Text == "" || txtEmail1.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EmailId \\n";
                    slno = slno + 1;
                }
                if (ddlPropLocDist.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select Distric \\n";
                    slno = slno + 1;
                }
                if (ddlPropLocTaluka.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlPropLocVillage.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdoor3.Text.Trim()) || txtdoor3.Text.Trim() == "" || txtdoor3.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter DOOR No \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtlocality3.Text.Trim()) || txtlocality3.Text.Trim() == "" || txtlocality3.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(TXTPIN.Text) || TXTPIN.Text == "" || TXTPIN.Text == null || TXTPIN.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(TXTPIN.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode \\n";
                    slno = slno + 1;
                }
                if (divsupervision.Visible == true)
                {
                    if (string.IsNullOrEmpty(txtnames.Text.Trim()) || txtnames.Text.Trim() == "" || txtnames.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Name \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtMobilenumber.Text) || txtMobilenumber.Text == "" || txtMobilenumber.Text == null || txtMobilenumber.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtMobilenumber.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter Mobile Number \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "" || txtEmail.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter EmailId \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtFathersname.Text.Trim()) || txtFathersname.Text.Trim() == "" || txtFathersname.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter FatherName \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtDoor1.Text.Trim()) || txtDoor1.Text.Trim() == "" || txtDoor1.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter DoorNo \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtLocality1.Text.Trim()) || txtLocality1.Text.Trim() == "" || txtLocality1.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Locality \\n";
                        slno = slno + 1;
                    }
                    if (ddlDistricts.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Enter District \\n";
                        slno = slno + 1;
                    }
                    if (ddlMandal.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Enter Mandal \\n";
                        slno = slno + 1;
                    }
                    if (ddlVillage.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Enter Village \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtpincode.Text) || txtpincode.Text == "" || txtpincode.Text == null || txtpincode.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtpincode.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter PinCode \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtDesignations.Text) || txtDesignations.Text == "" || txtDesignations.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Designation \\n";
                        slno = slno + 1;
                    }
                }
                else { divsupervision.Visible = false; }

                if (div4questions.Visible == true)
                {
                    if (string.IsNullOrEmpty(txtLabourEmp.Text.Trim()) || txtLabourEmp.Text.Trim() == "" || txtLabourEmp.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Nature of work in which contract labour is employed \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtconstructionwork.Text.Trim()) || txtconstructionwork.Text.Trim() == "" || txtconstructionwork.Text.Trim() == null || txtconstructionwork.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtconstructionwork.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter  Estimated date of commencement of building or other construction work \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtContractEmployees.Text.Trim()) || txtContractEmployees.Text.Trim() == "" || txtContractEmployees.Text.Trim() == null || txtContractEmployees.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtContractEmployees.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter Maximum number of Contract Employees \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtbuilding.Text.Trim()) || txtbuilding.Text.Trim() == "" || txtbuilding.Text.Trim() == null || txtbuilding.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtbuilding.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter  Estimated date of completion of building \\n";
                        slno = slno + 1;
                    }
                }
                else { div4questions.Visible = false; }

                if (div5questions.Visible == true)
                {
                    if (string.IsNullOrEmpty(txtMaximum.Text.Trim()) || txtMaximum.Text.Trim() == "" || txtMaximum.Text.Trim() == null || txtMaximum.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtMaximum.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter Maximum Number of migrant workmen proposed to be employed \\n";
                        slno = slno + 1;
                    }
                    if (rblconvicted.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Enter the contractor was convicted of any offence within the preceding five years...! \\n";
                        slno = slno + 1;
                    }
                    if (rblrevoking.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Enter there was any order against the contractor revoking or suspending license...! \\n";
                        slno = slno + 1;
                    }
                    if (rblcontractor.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Enter the contractor has worked in any other establishment within the past five years...! \\n";
                        slno = slno + 1;
                    }
                    //if (ddlbusiness.SelectedIndex == 0)
                    //{
                    //    errormsg = errormsg + slno + ". Please Enter Type of business, trade, industry, manufacture or occupation...! \\n";
                    //    slno = slno + 1;
                    //}
                }
                else { div5questions.Visible = false; }

                if (divContractorDtls.Visible == true)
                {
                    if (string.IsNullOrEmpty(txtcontractor.Text.Trim()) || txtcontractor.Text.Trim() == "" || txtcontractor.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Name \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtfathername.Text.Trim()) || txtfathername.Text.Trim() == "" || txtfathername.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter AGE \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtmobileno.Text) || txtmobileno.Text == "" || txtmobileno.Text == null || txtmobileno.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtmobileno.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter MOBILE NO \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtemailid.Text) || txtemailid.Text == "" || txtemailid.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter EMAILID \\n";
                        slno = slno + 1;
                    }
                    if (ddlDistric.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Select Distric \\n";
                        slno = slno + 1;
                    }
                    if (ddlMandals.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Select Mandal \\n";
                        slno = slno + 1;
                    }
                    if (ddlvillages.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Select Village \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtdoorno.Text.Trim()) || txtdoorno.Text.Trim() == "" || txtdoorno.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter DOOR NO \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtlocal.Text.Trim()) || txtlocal.Text.Trim() == "" || txtlocal.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter LOCALITY \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtpinnumber.Text) || txtpinnumber.Text == "" || txtpinnumber.Text == null || txtpinnumber.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtpinnumber.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter PINNUMBER \\n";
                        slno = slno + 1;
                    }
                }
                else { divContractorDtls.Visible = false; }

                if (divAgentDtls.Visible == true)
                {
                    if (string.IsNullOrEmpty(txtname.Text) || txtname.Text == "" || txtname.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Name \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtDoor.Text) || txtDoor.Text == "" || txtDoor.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter DOOR NO \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text == "" || txtLocality.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter LOCALITY \\n";
                        slno = slno + 1;
                    }
                    if (ddldist.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Select Distric \\n";
                        slno = slno + 1;
                    }
                    if (ddlmand.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Select Mandal \\n";
                        slno = slno + 1;
                    }
                    if (ddlvilla.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Select Village \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtAgentPincode.Text) || txtAgentPincode.Text == "" || txtAgentPincode.Text == null || txtAgentPincode.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtAgentPincode.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter PINNUMBER \\n";
                        slno = slno + 1;
                    }
                }
                else { divAgentDtls.Visible = false; }

                if (divContrLabr.Visible == true)
                {
                    if (GVLabour.Rows.Count <= 0)
                    {
                        errormsg = errormsg + slno + ". Please Enter Particulars of Contract Labour\\n";
                        slno = slno + 1;
                    }
                }
                else { divContrLabr.Visible = false; }
                if (divMigrLabr.Visible == true)
                {
                    if (GVMigrant.Rows.Count <= 0)
                    {
                        errormsg = errormsg + slno + ". Please Enter Particulars of Migrant Workmen\\n";
                        slno = slno + 1;
                    }
                }
                else { divMigrLabr.Visible = false; }

                if (string.IsNullOrEmpty(hplLicgrant.Text) || hplLicgrant.Text == "" || hplLicgrant.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Trading / business license granted by the respective District Council \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplForm5.Text) || hplForm5.Text == "" || hplForm5.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Form-V Certificate \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplForm8.Text) || hplForm8.Text == "" || hplForm8.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Form VIII  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplForm10.Text) || hplForm10.Text == "" || hplForm10.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Form X affixed with epic and photograph of all the workmen \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplCrimeForm10.Text) || hplCrimeForm10.Text == "" || hplCrimeForm10.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Proof of Residence and Criminal antecedents issued by District Magistrates/Additional \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplEmployer.Text) || hplEmployer.Text == "" || hplEmployer.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Registration of establishment of the principal employer \\n";
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

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEWaterDetails.aspx?Previous=" + "P");
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
                Btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFE/CFEUploadEnclosures.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                if (ex.Message != "Thread was being aborted.")
                {
                    MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
                }
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

    }
}