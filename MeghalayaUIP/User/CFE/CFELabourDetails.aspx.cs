using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
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
        string UnitID, result;
        protected void Page_Load(object sender, EventArgs e)
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
                    BindDatas();
                    BindDataMigrant();
                    GetAppliedorNot();
                    BindData();
                    BindingData();

                }
            }
        }
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "10");


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
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                throw ex;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        public void BindDatas()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetRetriveCFELabourContractorDet(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_UNITID"]);
                            txtNameAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_CONTRACTORNAMEADDRESS"]);
                            txtLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_WORKNAMENATURELOCATION"]);
                            ddlMaximumNo.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_MAXCONTRACTLABOUR"]);
                            txtContactWork.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_CONTRACTDURATION"]);
                            txtEstimated.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_COMMENCEMENTDATEOFWORK"]);
                            txtDateWork.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_COMPLETIONDATEOFWORK"]);
                            txtEmployeeLabour.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFECL_TERMINATIONDATEOFEMP"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BindDataMigrant()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetRetriveCFEMigrantDetails(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_UNITID"]);
                            txtAddressName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_CONTRACTORNAMEADDRESS"]);
                            txtEmployedName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_MIGRANTNAMENATURELOCATION"]);
                            txtMaxmigrant.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_MAXCONTRACTMIGRANT"]);
                            txtContractwork.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_CONTRACTDURATION"]);
                            txtEstwork.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_COMMENCEMENTDATE"]);
                            txtEstDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_COMPLETIONDATEOFWORK"]);
                            txtEstDateWork.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEMW_TERMINATIONDATEOFEMPMigrant"]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
                        //ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_UNITID"]);
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
                        txtcontractor.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_NAMECONTRACTOR"]);
                        txtfathername.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_FATHER"]);
                        txtAges.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_AGES"]);
                        txtmobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MOBILE"]);
                        txtemailid.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_EMAIL"]);
                        ddlDistric.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_DISTID"]);
                        ddlDistric_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandals.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_MANDALID"]);
                        ddlMandals_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlvillages.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_VILLAGEID"]);
                        txtdoorno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_DOORNO"]);
                        txtlocal.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_LOCALITYNAME"]);
                        txtpinnumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFELD_PIN"]);
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 1)//Aadhar
                                {
                                    hplForm5.Visible = true;
                                    hplForm5.NavigateUrl = Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                                    hplForm5.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);

                                    hplLicgrant.Visible = true;
                                    hplLicgrant.NavigateUrl = Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                                    hplLicgrant.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);

                                    hplForm8.Visible = true;
                                    hplForm8.NavigateUrl = Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                                    hplForm8.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);

                                    hplForm10.Visible = true;
                                    hplForm10.NavigateUrl = Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                                    hplForm10.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);

                                    hplCrimeForm10.Visible = true;
                                    hplCrimeForm10.NavigateUrl = Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                                    hplCrimeForm10.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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

                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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

                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        protected void ddlDistricts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                if (ddlDistricts.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistricts.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlmand.ClearSelection();
                ddlvilla.ClearSelection();
                if (ddldist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlmand, ddldist.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        protected void ddlmand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlvilla.ClearSelection();
                if (ddlmand.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlvilla, ddlmand.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                ddlPropLocVillage.ClearSelection();
                if (ddlPropLocDist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlPropLocTaluka, ddlPropLocDist.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlPropLocTaluka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPropLocVillage.ClearSelection();
                if (ddlPropLocTaluka.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlPropLocVillage, ddlPropLocTaluka.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                if (string.IsNullOrEmpty(txtNameAddress.Text) || string.IsNullOrEmpty(txtLocation.Text) || string.IsNullOrEmpty(txtContactWork.Text) || string.IsNullOrEmpty(txtEstimated.Text) || string.IsNullOrEmpty(txtDateWork.Text) || string.IsNullOrEmpty(txtEmployeeLabour.Text))
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
                    dr["CFECL_CONTRACTORNAMEADDRESS"] = txtNameAddress.Text;
                    dr["CFECL_WORKNAMENATURELOCATION"] = txtLocation.Text;
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
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        protected void btnAddMigrant_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAddressName.Text) || string.IsNullOrEmpty(txtEmployedName.Text) || string.IsNullOrEmpty(txtMaxmigrant.Text) || string.IsNullOrEmpty(txtContractwork.Text) || string.IsNullOrEmpty(txtEstwork.Text) || string.IsNullOrEmpty(txtEstDate.Text) || string.IsNullOrEmpty(txtEstDateWork.Text))
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
                    dr["CFEMW_CONTRACTORNAMEADDRESS"] = txtAddressName.Text;
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
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + hdnUserID.Value + "\\" + "License Grant" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupLicgrant.PostedFile.SaveAs(serverpath + "\\" + fupLicgrant.PostedFile.FileName);

                        CFEAttachments objAadhar = new CFEAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objAadhar.MasterID = "1";
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
                            hplLicgrant.NavigateUrl = serverpath;
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
                throw ex;
            }
        }
        public string validations(FileUpload Attachment)
        {
            try
            {
                int slno = 1; string Error = "";
                if (Attachment.PostedFile.ContentType != "application/pdf"
                     || !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                {

                    if (Attachment.PostedFile.ContentType != "application/pdf")
                    {
                        Error = Error + slno + ". Please Upload PDF Documents only \\n";
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
                }
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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + hdnUserID.Value + "\\" + "Form5" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupForm5.PostedFile.SaveAs(serverpath + "\\" + fupForm5.PostedFile.FileName);

                        CFEAttachments objApplPhoto = new CFEAttachments();
                        objApplPhoto.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objApplPhoto.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objApplPhoto.MasterID = "3";
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
                            hplForm5.NavigateUrl = serverpath;
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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + hdnUserID.Value + "\\" + "Form 8" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupForm8.PostedFile.SaveAs(serverpath + "\\" + fupForm8.PostedFile.FileName);

                        CFEAttachments objLandDoc = new CFEAttachments();
                        objLandDoc.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objLandDoc.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objLandDoc.MasterID = "4";
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
                            hplForm8.NavigateUrl = serverpath;
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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                        + hdnUserID.Value + "\\" + "Form 10" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupForm10.PostedFile.SaveAs(serverpath + "\\" + fupForm10.PostedFile.FileName);

                        CFEAttachments objSitePlan = new CFEAttachments();
                        objSitePlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objSitePlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objSitePlan.MasterID = "1";
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
                            hplForm10.NavigateUrl = serverpath;
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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                        + hdnUserID.Value + "\\" + "Criminal Issues" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupCrimeForm10.PostedFile.SaveAs(serverpath + "\\" + fupCrimeForm10.PostedFile.FileName);

                        CFEAttachments objSitePlan = new CFEAttachments();
                        objSitePlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objSitePlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objSitePlan.MasterID = "1";
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
                            hplCrimeForm10.NavigateUrl = serverpath;
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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                        + hdnUserID.Value + "\\" + "Employer" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupemployer.PostedFile.SaveAs(serverpath + "\\" + fupemployer.PostedFile.FileName);

                        CFEAttachments objSitePlan = new CFEAttachments();
                        objSitePlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objSitePlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objSitePlan.MasterID = "1";
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
                            hplEmployer.NavigateUrl = serverpath;
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
            }
        }
        public static bool ValidateFileExtension(FileUpload Attachment)
        {
            try
            {
                string Attachmentname = Attachment.PostedFile.FileName;
                string[] fileType = Attachmentname.Split('.');
                int i = fileType.Length;

                if (i == 2)
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
                string ErrorMsg = "", result = "";
                ErrorMsg = Stepvalidations();
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
                    ObjCFELabourDet.Name_Contractor = txtname1.Text;
                    ObjCFELabourDet.Father_Name = txtfather.Text;
                    ObjCFELabourDet.Date_birth = txtage.Text;
                    ObjCFELabourDet.Designation = txtdesignation.Text;
                    ObjCFELabourDet.Mobile = txtmobile.Text;
                    ObjCFELabourDet.Email = txtEmail1.Text;
                    ObjCFELabourDet.Distric = ddlPropLocDist.SelectedValue;
                    ObjCFELabourDet.DistrictName = ddlPropLocDist.SelectedItem.Text;
                    ObjCFELabourDet.Mandal = ddlPropLocTaluka.SelectedValue;
                    ObjCFELabourDet.MandalName = ddlPropLocTaluka.SelectedItem.Text;
                    ObjCFELabourDet.Village = ddlPropLocVillage.SelectedValue;
                    ObjCFELabourDet.VillageName = ddlPropLocVillage.SelectedItem.Text;
                    ObjCFELabourDet.DoorNo = txtdoor3.Text;
                    ObjCFELabourDet.Locality = txtlocality3.Text;
                    ObjCFELabourDet.Pincode = TXTPIN.Text;
                    ObjCFELabourDet.Name = txtcontractor.Text;
                    ObjCFELabourDet.Fathers_Name = txtfathername.Text;
                    ObjCFELabourDet.Age = txtAges.Text;
                    ObjCFELabourDet.MobileNo = txtmobileno.Text;
                    ObjCFELabourDet.EmailId = txtemailid.Text;
                    ObjCFELabourDet.District = ddlDistric.SelectedValue;
                    ObjCFELabourDet.DistrictsName = ddlDistric.SelectedItem.Text;
                    ObjCFELabourDet.Mandals = ddlMandals.SelectedValue;
                    ObjCFELabourDet.MandalsName = ddlMandals.SelectedItem.Text;
                    ObjCFELabourDet.Villages = ddlvillages.SelectedValue;
                    ObjCFELabourDet.VillagesName = ddlvillages.SelectedItem.Text;
                    ObjCFELabourDet.Door_No = txtdoorno.Text;
                    ObjCFELabourDet.Localitys = txtlocal.Text;
                    ObjCFELabourDet.Pincodes = txtpinnumber.Text;

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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        public string Stepvalidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtname1.Text) || txtname1.Text == "" || txtname1.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter NAME \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtfather.Text) || txtfather.Text == "" || txtfather.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter FatherName \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtage.Text) || txtage.Text == "" || txtage.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Age \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdesignation.Text) || txtdesignation.Text == "" || txtdesignation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Desigantion \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtmobile.Text) || txtmobile.Text == "" || txtmobile.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile No \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmail1.Text) || txtEmail1.Text == "" || txtEmail1.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EmailId \\n";
                    slno = slno + 1;
                }
                if (ddlPropLocDist.SelectedIndex == -1 || ddlPropLocDist.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric \\n";
                    slno = slno + 1;
                }
                if (ddlPropLocTaluka.SelectedIndex == -1 || ddlPropLocTaluka.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlPropLocVillage.SelectedIndex == -1 || ddlPropLocVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdoor3.Text) || txtdoor3.Text == "" || txtdoor3.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter DOOR No \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtlocality3.Text) || txtlocality3.Text == "" || txtlocality3.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(TXTPIN.Text) || TXTPIN.Text == "" || TXTPIN.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtcontractor.Text) || txtcontractor.Text == "" || txtcontractor.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtfathername.Text) || txtfathername.Text == "" || txtfathername.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter AGE \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtmobileno.Text) || txtmobileno.Text == "" || txtmobileno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter MOBILE NO \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtemailid.Text) || txtemailid.Text == "" || txtemailid.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EMAILID \\n";
                    slno = slno + 1;
                }
                if (ddlDistric.SelectedIndex == -1 || ddlDistric.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric \\n";
                    slno = slno + 1;
                }
                if (ddlMandals.SelectedIndex == -1 || ddlMandals.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlvillages.SelectedIndex == -1 || ddlvillages.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdoorno.Text) || txtdoorno.Text == "" || txtdoorno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter DOOR NO \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtlocal.Text) || txtlocal.Text == "" || txtlocal.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter LOCALITY \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtpinnumber.Text) || txtpinnumber.Text == "" || txtpinnumber.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter PINNUMBER \\n";
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

        protected void btnPreviuos1_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFELineOfManufactureDetails.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEPowerDetails.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }


    }
}