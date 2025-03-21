using System;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static AjaxControlToolkit.AsyncFileUpload.Constants;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Linq.Expressions;

namespace MeghalayaUIP.User.Services
{
    public partial class PlasticWasteDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string Questionnaire, ErrorMsg = "", result = "", SRVCQID = ""; //UID = "",
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
                    if (Convert.ToString(Session["SRVCQID"]) != "")
                    {
                        SRVCQID = Convert.ToString(Session["SRVCQID"]);
                        if (!IsPostBack)
                        {
                            Questionnaire = Convert.ToString(Session["SRVCQID"]);
                            divProducer.Visible = false;
                            divBrandOwner.Visible = false;
                            GetAppliedorNot();

                        }
                    }
                    else
                    {
                        string newurl = "~/User/Services/SRVCUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }
                    Page.MaintainScrollPositionOnPostBack = true;

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

                ds = objSrvcbal.GetsrvcapprovalID(hdnUserID.Value, Convert.ToString(Session["SRVCQID"]), "12", "105");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["SRVCDA_APPROVALID"]) == "105")
                    {
                        BindStates();
                        BindDistricts();
                        BindData();

                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Services/SRVCUploadEnclosures.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Services/CDWMDetails.aspx?Previous=" + "P");
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


        private void BindData()
        {
            try
            {
                // Fetching session values
                string srvcQdId = Convert.ToString(Session["SRVCQID"]);
                //string unitId = Convert.ToString("1001");
                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();

                ds1 = objSrvcbal.GetProdPlasticWasteDetails(hdnUserID.Value, srvcQdId);
                ds2 = objSrvcbal.GetBOPlasticWasteDetails(hdnUserID.Value, srvcQdId);
                //ds1 = objSrvcbal.GetPaymentAmounttoPay(hdnUserID.Value, srvcQdId);

                //ds2 = objSrvcbal.GetPaymentAmounttoPay(hdnUserID.Value, srvcQdId);

                if (ds1.Tables.Count > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ds1.Tables[0].Rows[0];

                        txtProdName.Text = row["SRVCPWD_NAMEOFPROD"].ToString();
                        txtUnitName.Text = row["SRVCPWD_NAMEOFUNIT"].ToString();

                        string[] selectedCarryBag = ds1.Tables[0].Rows[0]["SRVCPWD_CARRYBAG"].ToString().Split('/');

                        foreach (ListItem item in chkCarryBags.Items)
                        {
                            if (selectedCarryBag.Contains(item.Text.Trim()))
                            {
                                item.Selected = true;
                            }
                        }
                        chkMultilayeredPlastics.Text = row["SRVCPWD_MULTILAYEREDPLASTIC"].ToString();
                        txtManufacturingCapacity.Text = row["SRVCPWD_MANFCTRNGCAPACITY"].ToString();
                        txtPreviousRegistration.Text = row["SRVCPWD_PREVREGNO"].ToString();
                        if (row["SRVCPWD_REGDATE"] != DBNull.Value)
                        {
                            DateTime boDate = Convert.ToDateTime(row["SRVCPWD_REGDATE"]);
                            txtDate.Text = boDate.ToString("dd-MM-yyyy"); // Format to dd-MM-yyyy
                        }
                        else
                        {
                            txtDate.Text = ""; // Handle null values
                        }

                        txtCapitalInvestment.Text = row["SRVCPWD_TOTCAPTLINV"].ToString();
                        txtCommencementYear.Text = row["SRVCPWD_YEAROFCMNCEMNT"].ToString();
                        txtProductsList.Text = row["SRVCPWD_LISTQNTMPROD"].ToString();
                        txtRawMaterials.Text = row["SRVCPWD_LISTQNTMRAWMAT"].ToString();
                        txtTotalWaste.Text = row["SRVCPWD_TOTALQNTMWASTEGENERATED"].ToString();
                        txtStorageMode.Text = row["SRVCPWD_MODEOFSTORAGEWITHINPLANT"].ToString();
                        txtDisposal.Text = row["SRVCPWD_DISPOSALPROVISION"].ToString();
                        rblCmplnc.Text = row["SRVCPWD_COMPLIANCE"].ToString();
                        rblRole.SelectedValue = row["SRVCPWD_ROLE"].ToString();
                        rblAirCont.SelectedValue = row["SRVCPWD_AIRPOL"].ToString();
                        rblSgUt.SelectedValue = row["SRVCPWD_SGUT"].ToString();
                        rblWater.SelectedValue = row["SRVCPWD_WATERACT"].ToString();
                    }
                    if (ds1.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds1.Tables[1].Rows.Count; i++)
                        {

                            if (Convert.ToInt32(ds1.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 173) // list of personnel or brand Owners to whom the products will be supplied
                            {
                                hypPrsnlBOList.Visible = true;
                                hypPrsnlBOList.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypPrsnlBOList.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                hypPrsnlBOList.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds1.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 174) //Water (Prevention and control of Pollution) Act
                            {
                                hypBOWaterActConsent.Visible = true;
                                hypBOWaterActConsent.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypBOWaterActConsent.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtBOWaterActConsent.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds1.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 176) //Air (Prevention and Control of Pollution) Act
                            {
                                hypAirPoltn.Visible = true;
                                hypAirPoltn.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypAirPoltn.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtBOAirPoltn.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds1.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 175) //unit registered with the District Industries Centre	of	the	State	Government	or	Union territory
                            {
                                hypBOStUT.Visible = true;
                                hypBOStUT.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypBOStUT.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtBOStUT.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds1.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 166) // Consent to Establish/ Operate
                            {
                                hypEstbOpr.Visible = true;
                                hypEstbOpr.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypEstbOpr.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtEstbOpr.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds1.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 170) // list of people supplying plastic material
                            {
                                hypPMList.Visible = true;
                                hypPMList.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypPMList.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtPMList.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds1.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 171) //Action plan on collecting back the plastic wastes
                            {
                                hypActnPln.Visible = true;
                                hypActnPln.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypActnPln.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtActnPln.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds1.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 172) // flow diagram of manufacturing process
                            {
                                hypFlowDgrm.Visible = true;
                                hypFlowDgrm.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypFlowDgrm.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtFlowDgrm.Text = Convert.ToString(ds1.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                        }
                    }
                }

                if (ds2.Tables.Count > 0 )
                {
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ds2.Tables[0].Rows[0];

                        txtBrandOwnrName.Text = row["BOPWD_NAMEOFBRANDOWNER"].ToString();
                        txtBORegNo.Text = row["BOPWD_PREVREGNO"].ToString();
                        if (row["BOPWD_REGDATE"] != DBNull.Value)
                        {
                            DateTime boDate = Convert.ToDateTime(row["BOPWD_REGDATE"]);
                            txtBODate.Text = boDate.ToString("dd-MM-yyyy"); // Format to dd-MM-yyyy
                        }
                        else
                        {
                            txtBODate.Text = ""; // Handle null values
                        }
                        txtBOTotalCapInv.Text = row["BOPWD_TOTALCAPINV"].ToString();
                        txtBOYearOfComncmnt.Text = row["BOPWD_INVYEAROFCOMNCMNT"].ToString();
                        txtBOProdQuan.Text = row["BOPWD_BYPRODPRODLIST"].ToString();
                        txtBORawMatQuan.Text = row["BOPWD_BYPRODRAWMATLIST"].ToString();
                        txtBOQntmWasteGenertd.Text = row["BOPWD_SWTOTALQNTMWASTEGEN"].ToString();
                        txtBOModeStrge.Text = row["BOPWD_SWMODEOFSTORAGE"].ToString();
                        txtBODispProv.Text = row["BOPWD_SWDISPOSALPROV"].ToString();
                        rblRole.SelectedValue = row["BOPWD_ROLE"].ToString();
                        rblAirCont.SelectedValue = row["BOPWD_AIRPOL"].ToString();
                        rblSgUt.SelectedValue = row["BOPWD_SGUT"].ToString();
                        rblWater.SelectedValue = row["BOPWD_WATERACT"].ToString();

                    }
                    if (ds2.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds2.Tables[1].Rows.Count; i++)
                        {
                            if (Convert.ToInt32(ds2.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 174) //Water (Prevention and control of Pollution) Act
                            {
                                hypBOWaterActConsent.Visible = true;
                                hypBOWaterActConsent.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypBOWaterActConsent.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtBOWaterActConsent.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds2.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 176) //Air (Prevention and Control of Pollution) Act
                            {
                                hypAirPoltn.Visible = true;
                                hypAirPoltn.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypAirPoltn.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtBOAirPoltn.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds2.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 175) //unit registered with the District Industries Centre	of	the	State	Government	or	Union territory
                            {
                                hypBOStUT.Visible = true;
                                hypBOStUT.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypBOStUT.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtBOStUT.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds2.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 166) // Consent to Establish/ Operate
                            {
                                hypEstbOpr.Visible = true;
                                hypEstbOpr.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypEstbOpr.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtEstbOpr.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds2.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 170) // list of people supplying plastic material
                            {
                                hypPMList.Visible = true;
                                hypPMList.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypPMList.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtPMList.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds2.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 171) //Action plan on collecting back the plastic wastes
                            {
                                hypActnPln.Visible = true;
                                hypActnPln.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypActnPln.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtActnPln.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds2.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 172) // flow diagram of manufacturing process
                            {
                                hypFlowDgrm.Visible = true;
                                hypFlowDgrm.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypFlowDgrm.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtFlowDgrm.Text = Convert.ToString(ds2.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }

                        }
                    }

                }
                
                if (rblRole.SelectedValue == "BrandOwner")
                {
                    divBrandOwner.Visible = true;
                    divProducer.Visible = false;
                    if(rblWater.SelectedValue == "Yes")
                    {
                        divWater.Visible = true;
                    }
                    if(rblSgUt.SelectedValue == "Yes")
                    {
                        divSgUt.Visible = true;
                    }
                    if(rblAirCont.SelectedValue == "Yes")
                    {
                        divAirCont.Visible = true;
                    }
                    ClearProducerFields();
                }
                else if (rblRole.SelectedValue == "Producer")
                {
                    divProducer.Visible = true;
                    divBrandOwner.Visible = false;
                    if (rblWater.SelectedValue == "Yes")
                    {
                        divWater.Visible = true;
                    }
                    if (rblSgUt.SelectedValue == "Yes")
                    {
                        divSgUt.Visible = true;
                    }
                    if (rblAirCont.SelectedValue == "Yes")
                    {
                        divAirCont.Visible = true;
                    }
                    ClearBrandOwnerFields();
                }


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        private void ClearProducerFields()
        {
            try
            {
                txtProdName.Text = "";
                txtUnitName.Text = "";
                // Clear checkbox selections
                foreach (ListItem item in chkCarryBags.Items)
                {
                    item.Selected = false;
                }
                chkMultilayeredPlastics.Text = "";
                txtManufacturingCapacity.Text = "";
                txtPreviousRegistration.Text = "";
                txtDate.Text = "";
                txtCapitalInvestment.Text = "";
                txtCommencementYear.Text = "";
                txtProductsList.Text = "";
                txtRawMaterials.Text = "";
                txtTotalWaste.Text = "";
                txtStorageMode.Text = "";
                txtDisposal.Text = "";
                rblCmplnc.ClearSelection();
                //rblAirCont.ClearSelection();
                //rblSgUt.ClearSelection();
                //rblWater.ClearSelection();
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        private void ClearBrandOwnerFields()
        {
            try
            {
                txtBOTotalCapInv.Text = "";
                txtBOYearOfComncmnt.Text = "";
                txtBOProdQuan.Text = "";
                txtBORawMatQuan.Text = "";
                txtBOQntmWasteGenertd.Text = "";
                txtBOModeStrge.Text = "";
                txtBODispProv.Text = "";

                //rblAirCont.ClearSelection();
                //rblSgUt.ClearSelection();
                //rblWater.ClearSelection();
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void BindStates()
        {
            try
            {
                ddlstate.Items.Clear();

                List<MasterStates> objStatesModel = new List<MasterStates>();

                objStatesModel = mstrBAL.GetStates();
                if (objStatesModel != null)
                {
                    ddlstate.DataSource = objStatesModel;
                    ddlstate.DataValueField = "StateId";
                    ddlstate.DataTextField = "StateName";
                    ddlstate.DataBind();

                    ddlUnitState.DataSource = objStatesModel;
                    ddlUnitState.DataValueField = "StateId";
                    ddlUnitState.DataTextField = "StateName";
                    ddlUnitState.DataBind();

                    ddlBOState.DataSource = objStatesModel;
                    ddlBOState.DataValueField = "StateId";
                    ddlBOState.DataTextField = "StateName";
                    ddlBOState.DataBind();

                }
                else
                {
                    ddlstate.DataSource = null;
                    ddlstate.DataBind();

                    ddlUnitState.DataSource = null;
                    ddlUnitState.DataBind();

                    ddlBOState.DataSource = null;
                    ddlBOState.DataBind();
                }
                AddSelect(ddlstate);
                AddSelect(ddlUnitState);
                AddSelect(ddlBOState);
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

                ddldist.Items.Clear();
                ddlmand.Items.Clear();
                ddlvilla.Items.Clear();

                ddlUnitDist.Items.Clear();
                ddlUnitVilla.Items.Clear();
                ddlUnitMand.Items.Clear();

                ddlBODis.Items.Clear();
                ddlBOVill.Items.Clear();
                ddlBOMan.Items.Clear();



                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;

                strmode = "";
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {

                    ddldist.DataSource = objDistrictModel;
                    ddldist.DataValueField = "DistrictId";
                    ddldist.DataTextField = "DistrictName";
                    ddldist.DataBind();

                    ddlUnitDist.DataSource = objDistrictModel;
                    ddlUnitDist.DataValueField = "DistrictId";
                    ddlUnitDist.DataTextField = "DistrictName";
                    ddlUnitDist.DataBind();

                    ddlBODis.DataSource = objDistrictModel;
                    ddlBODis.DataValueField = "DistrictId";
                    ddlBODis.DataTextField = "DistrictName";
                    ddlBODis.DataBind();

                }
                else
                {
                    ddldist.DataSource = null;
                    ddldist.DataBind();

                    ddlUnitDist.DataSource = null;
                    ddlUnitDist.DataBind();

                    ddlBODis.DataSource = null;
                    ddlBODis.DataBind();

                }

                AddSelect(ddldist);
                AddSelect(ddlmand);
                AddSelect(ddlvilla);

                AddSelect(ddlUnitDist);
                AddSelect(ddlUnitMand);
                AddSelect(ddlUnitVilla);

                AddSelect(ddlBODis);
                AddSelect(ddlBOMan);
                AddSelect(ddlBOVill);


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

                    ddlUnitVilla.DataSource = objVillage;
                    ddlUnitVilla.DataValueField = "VillageId";
                    ddlUnitVilla.DataTextField = "VillageName";
                    ddlUnitVilla.DataBind();

                    ddlBOVill.DataSource = objVillage;
                    ddlBOVill.DataValueField = "VillageId";
                    ddlBOVill.DataTextField = "VillageName";
                    ddlBOVill.DataBind();


                }
                else
                {
                    ddlvlg.DataSource = null;
                    ddlvlg.DataBind();

                    ddlUnitVilla.DataSource = null;
                    ddlUnitVilla.DataBind();

                    ddlBOVill.DataSource = null;
                    ddlBOVill.DataBind();
                }
                AddSelect(ddlvlg);
                AddSelect(ddlUnitVilla);
                AddSelect(ddlBOVill);
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

                    ddlUnitMand.DataSource = objMandal;
                    ddlUnitMand.DataValueField = "MandalId";
                    ddlUnitMand.DataTextField = "MandalName";
                    ddlUnitMand.DataBind();

                    ddlBOMan.DataSource = objMandal;
                    ddlBOMan.DataValueField = "MandalId";
                    ddlBOMan.DataTextField = "MandalName";
                    ddlBOMan.DataBind();
                }
                else
                {

                    ddlmndl.DataSource = null;
                    ddlmndl.DataBind();

                    ddlUnitMand.DataSource = null;
                    ddlUnitMand.DataBind();

                    ddlBOMan.DataSource = null;
                    ddlBOMan.DataBind();
                }

                AddSelect(ddlmndl);
                AddSelect(ddlUnitMand);
                AddSelect(ddlBOMan);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlstate.SelectedItem.Text == "Meghalaya")
                {
                    trMeghalaya.Visible = true;
                    trotherstate.Visible = false;
                }
                else
                {
                    trotherstate.Visible = true;
                    trMeghalaya.Visible = false;
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
                ddlvilla.ClearSelection();
                if (ddldist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlmand, ddldist.SelectedValue);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlUnitState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitState.SelectedItem.Text == "Meghalaya")
                {
                    trUnitMeghalaya.Visible = true;
                    trUnitOtrSt.Visible = false;
                }
                else
                {
                    trUnitOtrSt.Visible = true;
                    trUnitMeghalaya.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlUnitDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlUnitMand.ClearSelection();
                ddlUnitVilla.ClearSelection();
                if (ddlUnitDist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlUnitMand, ddlUnitDist.SelectedValue);
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

        protected void ddlUnitMand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlUnitVilla.ClearSelection();
                if (ddlUnitMand.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlUnitVilla, ddlUnitMand.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void ddlBOState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlBOState.SelectedItem.Text == "Meghalaya")
                {
                    divBOMeg.Visible = true;
                    divBOtrstate.Visible = false;
                }
                else
                {
                    divBOtrstate.Visible = true;
                    divBOMeg.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void ddlBODis_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlBOMan.ClearSelection();
                ddlBOVill.ClearSelection();
                if (ddlUnitDist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlBOMan, ddlBOVill.SelectedValue);
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

        protected void ddlBOMan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlBOVill.ClearSelection();
                if (ddlBOMan.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlBOVill, ddlBOMan.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";

                if (rblRole.SelectedValue == "Producer")
                {
                    ErrorMsg = ValidateProducerForm();

                    if (string.IsNullOrEmpty(ErrorMsg))
                    {
                        ServiceProdPlasticsWasteDetails serviceProdPlasticsWasteDetails = new ServiceProdPlasticsWasteDetails();

                        // Assigning session values
                        //serviceProdPlasticsWasteDetails.UnitId = "1001";// Convert.ToString(Session["SRVCUNITID"]);

                        serviceProdPlasticsWasteDetails.SrvcQdId = Convert.ToString(Session["SRVCQID"]);
                        serviceProdPlasticsWasteDetails.CreatedBy = hdnUserID.Value;
                        serviceProdPlasticsWasteDetails.CreatedByIp = getclientIP();

                        // Assigning values from producer form controls
                        serviceProdPlasticsWasteDetails.NameOfProduct = txtProdName.Text;
                        serviceProdPlasticsWasteDetails.NameOfUnit = txtUnitName.Text;

                        List<string> selectedChkItems = new List<string>();
                        foreach (ListItem item in chkCarryBags.Items)
                        {
                            if (item.Selected)
                            {
                                selectedChkItems.Add(item.Text);
                            }
                        }
                        serviceProdPlasticsWasteDetails.CarryBag = string.Join("/", selectedChkItems);

                        serviceProdPlasticsWasteDetails.MultilayeredPlastic = chkMultilayeredPlastics.Checked ? "1" : "0";
                        serviceProdPlasticsWasteDetails.ManufacturingCapacity = txtManufacturingCapacity.Text;
                        serviceProdPlasticsWasteDetails.PreviousRegistration = txtPreviousRegistration.Text;
                        serviceProdPlasticsWasteDetails.RegistrationDate =( txtDate.Text);
                        serviceProdPlasticsWasteDetails.TotalCapitalInvestment = txtCapitalInvestment.Text;
                        serviceProdPlasticsWasteDetails.YearOfCommencement = txtCommencementYear.Text;
                        serviceProdPlasticsWasteDetails.ListQuantityProduct = txtProductsList.Text;
                        serviceProdPlasticsWasteDetails.ListQuantityRawMaterial = txtRawMaterials.Text;
                        serviceProdPlasticsWasteDetails.TotalQuantityWasteGenerated = txtTotalWaste.Text;
                        serviceProdPlasticsWasteDetails.ModeOfStorageWithinPlant = txtStorageMode.Text;
                        serviceProdPlasticsWasteDetails.DisposalProvision = txtDisposal.Text;
                        serviceProdPlasticsWasteDetails.Compliance = rblCmplnc.Text;
                        serviceProdPlasticsWasteDetails.Role = "Producer";
                        serviceProdPlasticsWasteDetails.WaterAct = rblWater.SelectedItem.Text;
                        serviceProdPlasticsWasteDetails.SgUt = rblSgUt.SelectedItem.Text;
                        serviceProdPlasticsWasteDetails.AirCont = rblAirCont.SelectedItem.Text;

                        // Insert into Producer Database Table
                        result = objSrvcbal.InsertProdPlasticsWasteDetails(serviceProdPlasticsWasteDetails);
                    }
                }
                else if (rblRole.SelectedValue == "BrandOwner")
                {
                    ErrorMsg = ValidateBrandOwnerForm();

                    if (string.IsNullOrEmpty(ErrorMsg))
                    {
                        ServiceBOPlasticsWasteDetails serviceBOPlasticsWasteDetails = new ServiceBOPlasticsWasteDetails();

                        // Assigning session values
                        serviceBOPlasticsWasteDetails.SrvcQdId = Convert.ToString(Session["SRVCQID"]);
                        serviceBOPlasticsWasteDetails.CreatedBy = hdnUserID.Value;
                        //serviceBOPlasticsWasteDetails.UnitId = "1001";// Convert.ToString(Session["SRVCUNITID"]);
                        serviceBOPlasticsWasteDetails.CreatedByIp = getclientIP();

                        // Assigning values from brand owner form controls
                        serviceBOPlasticsWasteDetails.NameOfBrandOwner = txtBrandOwnrName.Text;
                        serviceBOPlasticsWasteDetails.PreviousRegistrationNumber = txtBORegNo.Text;
                        serviceBOPlasticsWasteDetails.RegistrationDate = txtBODate.Text;
                        serviceBOPlasticsWasteDetails.TotalCapitalInvestment = txtBOTotalCapInv.Text;
                        serviceBOPlasticsWasteDetails.YearOfCommencement = txtBOYearOfComncmnt.Text;
                        serviceBOPlasticsWasteDetails.ByProdProductList = txtBOProdQuan.Text;
                        serviceBOPlasticsWasteDetails.ByProdRawMaterialList = txtBORawMatQuan.Text;
                        serviceBOPlasticsWasteDetails.TotalQuantityWasteGenerated = txtBORawMatQuan.Text;
                        serviceBOPlasticsWasteDetails.ModeOfStorageWithinPlant = txtBOModeStrge.Text;
                        serviceBOPlasticsWasteDetails.DisposalProvision = txtBODispProv.Text;
                        serviceBOPlasticsWasteDetails.Role = "BrandOwner";
                        serviceBOPlasticsWasteDetails.WaterAct = rblWater.SelectedItem.Text;
                        serviceBOPlasticsWasteDetails.SgUt = rblSgUt.SelectedItem.Text;
                        serviceBOPlasticsWasteDetails.AirCont = rblAirCont.SelectedItem.Text;

                        // Insert into Brand Owner Database Table
                        result = objSrvcbal.InsertBOPlasticsWasteDetails(serviceBOPlasticsWasteDetails);
                    }
                }

                if (!string.IsNullOrEmpty(result))
                {
                    lblmsg.Text = "Details Submitted Successfully";
                    string message = "alert('" + lblmsg.Text + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
                else if (!string.IsNullOrEmpty(ErrorMsg))
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

        private string ValidateBrandOwnerForm()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtBrandOwnrName.Text) || txtBrandOwnrName.Text == "" || txtBrandOwnrName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Brand Owner Name \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtBORegNo.Text) || txtBORegNo.Text == "" || txtBORegNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Brand Owner Registration Number \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtBODate.Text) || txtBODate.Text == "" || txtBODate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration Date \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtBOTotalCapInv.Text) || txtBOTotalCapInv.Text == "" || txtBOTotalCapInv.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total Capital Investment \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtBOYearOfComncmnt.Text) || txtBOYearOfComncmnt.Text == "" || txtBOYearOfComncmnt.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Year of Commencement \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtBOProdQuan.Text) || txtBOProdQuan.Text == "" || txtBOProdQuan.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Production Quantity \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtBORawMatQuan.Text) || txtBORawMatQuan.Text == "" || txtBORawMatQuan.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Raw Material Quantity \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtBOQntmWasteGenertd.Text) || txtBOQntmWasteGenertd.Text == "" || txtBOQntmWasteGenertd.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Quantum of Waste Generated \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtBOModeStrge.Text) || txtBOModeStrge.Text == "" || txtBOModeStrge.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mode of Storage \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtBODispProv.Text) || txtBODispProv.Text == "" || txtBODispProv.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Disposal Provisions \\n";
                    slno = slno + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidateProducerForm()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtProdName.Text) || txtProdName.Text == "" || txtProdName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Product Name \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtUnitName.Text) || txtUnitName.Text == "" || txtUnitName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Unit Name \\n";
                    slno = slno + 1;
                }

                if (chkCarryBags.Items.Cast<ListItem>().All(item => !item.Selected))
                {
                    errormsg = errormsg + slno + ". Please Select Carry Bags Option \\n";
                    slno = slno + 1;
                }

                if (!chkMultilayeredPlastics.Checked)
                {
                    errormsg = errormsg + slno + ". Please Select Multilayered Plastics Option \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtManufacturingCapacity.Text) || txtManufacturingCapacity.Text == "" || txtManufacturingCapacity.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Manufacturing Capacity \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtPreviousRegistration.Text) || txtPreviousRegistration.Text == "" || txtPreviousRegistration.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Previous Registration Details \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtDate.Text) || txtDate.Text == "" || txtDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Date \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtCapitalInvestment.Text) || txtCapitalInvestment.Text == "" || txtCapitalInvestment.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Capital Investment \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtCommencementYear.Text) || txtCommencementYear.Text == "" || txtCommencementYear.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Commencement Year \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtProductsList.Text) || txtProductsList.Text == "" || txtProductsList.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Products List \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtRawMaterials.Text) || txtRawMaterials.Text == "" || txtRawMaterials.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Raw Materials Details \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtTotalWaste.Text) || txtTotalWaste.Text == "" || txtTotalWaste.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total Waste Generated \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtStorageMode.Text) || txtStorageMode.Text == "" || txtStorageMode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Storage Mode \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtDisposal.Text) || txtDisposal.Text == "" || txtDisposal.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Disposal Method \\n";
                    slno = slno + 1;
                }
                if (rblCmplnc.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Compliance with 50-micron Thickness Rule\\n";
                    slno = slno + 1;
                }
                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Services/SRVCUploadEnclosures.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/Services/CDWMDetails.aspx?Previous=" + "P");
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

        protected void rblRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                divProducer.Visible = rblRole.SelectedValue == "Producer";
                divBrandOwner.Visible = rblRole.SelectedValue == "BrandOwner";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
        protected void btnBOWater_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupBOWaterActConsent.HasFile)
                {
                    Error = validations(fupBOWaterActConsent);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["SRVCQID"]) + "\\" + "Land Document" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupBOWaterActConsent.PostedFile.SaveAs(serverpath + "\\" + fupBOWaterActConsent.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupBOWaterActConsent.PostedFile.SaveAs(serverpath + "\\" + fupBOWaterActConsent.PostedFile.FileName);
                            }
                        }

                        SRVCAttachments objWaterActConsent = new SRVCAttachments();
                        objWaterActConsent.Questionnareid = Convert.ToString(Session["SRVCQID"]);  //Convert.ToString(Session["CFEQID"]);
                        objWaterActConsent.MasterID = "174";
                        objWaterActConsent.FilePath = serverpath + fupBOWaterActConsent.PostedFile.FileName;
                        objWaterActConsent.FileName = fupBOWaterActConsent.PostedFile.FileName;
                        objWaterActConsent.FileType = fupBOWaterActConsent.PostedFile.ContentType;
                        objWaterActConsent.FileDescription = "Valid consent under the Water (Prevention and control of Pollution) Act";
                        objWaterActConsent.CreatedBy = hdnUserID.Value;
                        objWaterActConsent.IPAddress = getclientIP();
                        objWaterActConsent.ReferenceNo = txtBOWaterActConsent.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objWaterActConsent);
                        if (result != "")
                        {
                            hypBOWaterActConsent.Text = fupBOWaterActConsent.PostedFile.FileName;
                            hypBOWaterActConsent.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupBOWaterActConsent.PostedFile.FileName);
                            hypBOWaterActConsent.Target = "blank";
                            message = "alert('" + "Valid consent under the Water (Prevention and control of Pollution) Act Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnBOAir_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupAIrPoltn.HasFile)
                {
                    Error = validations(fupAIrPoltn);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["SRVCQID"]) + "\\" + "Air (Prevention and Control of Pollution) Act" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupAIrPoltn.PostedFile.SaveAs(serverpath + "\\" + fupAIrPoltn.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupAIrPoltn.PostedFile.SaveAs(serverpath + "\\" + fupAIrPoltn.PostedFile.FileName);
                            }
                        }

                        SRVCAttachments objBOAirPol = new SRVCAttachments();
                        objBOAirPol.Questionnareid = Convert.ToString(Session["SRVCQID"]);  //Convert.ToString(Session["CFEQID"]);
                        objBOAirPol.MasterID = "176";
                        objBOAirPol.FilePath = serverpath + fupAIrPoltn.PostedFile.FileName;
                        objBOAirPol.FileName = fupAIrPoltn.PostedFile.FileName;
                        objBOAirPol.FileType = fupAIrPoltn.PostedFile.ContentType;
                        objBOAirPol.FileDescription = "Valid consent under the Air (Prevention and Control of Pollution) Act Document";
                        objBOAirPol.CreatedBy = hdnUserID.Value;
                        objBOAirPol.IPAddress = getclientIP();
                        objBOAirPol.ReferenceNo = txtBOAirPoltn.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objBOAirPol);
                        if (result != "")
                        {
                            hypAirPoltn.Text = fupAIrPoltn.PostedFile.FileName;
                            hypAirPoltn.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupAIrPoltn.PostedFile.FileName);
                            hypAirPoltn.Target = "blank";
                            message = "alert('" + "Valid consent under the Air (Prevention and Control of Pollution) Act Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnFlowDgrm_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupFlowDgrm.HasFile)
                {
                    Error = validations(fupFlowDgrm);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["SRVCQID"]) + "\\" + "Flow diagram for captive power generation and water" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupFlowDgrm.PostedFile.SaveAs(serverpath + "\\" + fupFlowDgrm.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupFlowDgrm.PostedFile.SaveAs(serverpath + "\\" + fupFlowDgrm.PostedFile.FileName);
                            }
                        }

                        SRVCAttachments objFlowDgrn = new SRVCAttachments();
                        objFlowDgrn.Questionnareid = Convert.ToString(Session["SRVCQID"]);
                        objFlowDgrn.MasterID = "172";
                        objFlowDgrn.FilePath = serverpath + fupFlowDgrm.PostedFile.FileName;
                        objFlowDgrn.FileName = fupFlowDgrm.PostedFile.FileName;
                        objFlowDgrn.FileType = fupFlowDgrm.PostedFile.ContentType;
                        objFlowDgrn.FileDescription = "Flow diagram of manufacturing process showing input and output in terms of products and waste generated including for captive power generation and water";
                        objFlowDgrn.CreatedBy = hdnUserID.Value;
                        objFlowDgrn.IPAddress = getclientIP();
                        objFlowDgrn.ReferenceNo = txtFlowDgrm.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objFlowDgrn);
                        if (result != "")
                        {
                            hypFlowDgrm.Text = fupFlowDgrm.PostedFile.FileName;
                            hypFlowDgrm.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupFlowDgrm.PostedFile.FileName);
                            hypFlowDgrm.Target = "blank";
                            message = "alert('" + "Flow diagram for captive power generation and water Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnPMList_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupPMList.HasFile)
                {
                    Error = validations(fupPMList);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["SRVCQID"]) + "\\" + "List of people supplying plastic material" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupPMList.PostedFile.SaveAs(serverpath + "\\" + fupPMList.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupPMList.PostedFile.SaveAs(serverpath + "\\" + fupPMList.PostedFile.FileName);
                            }
                        }

                        SRVCAttachments objPMList = new SRVCAttachments();
                        objPMList.Questionnareid = Convert.ToString(Session["SRVCQID"]);
                        objPMList.MasterID = "170";
                        objPMList.FilePath = serverpath + fupPMList.PostedFile.FileName;
                        objPMList.FileName = fupPMList.PostedFile.FileName;
                        objPMList.FileType = fupPMList.PostedFile.ContentType;
                        objPMList.FileDescription = "List of people supplying plastic material";
                        objPMList.CreatedBy = hdnUserID.Value;
                        objPMList.IPAddress = getclientIP();
                        objPMList.ReferenceNo = txtPMList.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objPMList);
                        if (result != "")
                        {
                            hypPMList.Text = fupPMList.PostedFile.FileName;
                            hypPMList.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupPMList.PostedFile.FileName);
                            hypPMList.Target = "blank";
                            message = "alert('" + "List of people supplying plastic material Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnActnPln_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupActnPln.HasFile)
                {
                    Error = validations(fupActnPln);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["SRVCQID"]) + "\\" + "Action plan on collecting back the plastic wastes" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupActnPln.PostedFile.SaveAs(serverpath + "\\" + fupActnPln.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupActnPln.PostedFile.SaveAs(serverpath + "\\" + fupActnPln.PostedFile.FileName);
                            }
                        }

                        SRVCAttachments objActnPln = new SRVCAttachments();
                        objActnPln.Questionnareid = Convert.ToString(Session["SRVCQID"]);
                        objActnPln.MasterID = "171";
                        objActnPln.FilePath = serverpath + fupActnPln.PostedFile.FileName;
                        objActnPln.FileName = fupActnPln.PostedFile.FileName;
                        objActnPln.FileType = fupActnPln.PostedFile.ContentType;
                        objActnPln.FileDescription = "Action plan on collecting back the plastic wastes ";
                        objActnPln.CreatedBy = hdnUserID.Value;
                        objActnPln.IPAddress = getclientIP();
                        objActnPln.ReferenceNo = txtActnPln.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objActnPln);
                        if (result != "")
                        {
                            hypActnPln.Text = fupActnPln.PostedFile.FileName;
                            hypActnPln.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupActnPln.PostedFile.FileName);
                            hypActnPln.Target = "blank";
                            message = "alert('" + "Action plan on collecting back the plastic wastes Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnEstbOpr_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupEstbOpr.HasFile)
                {
                    Error = validations(fupEstbOpr);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["SRVCQID"]) + "\\" + "Consent to Establish or Operate" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupEstbOpr.PostedFile.SaveAs(serverpath + "\\" + fupEstbOpr.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupEstbOpr.PostedFile.SaveAs(serverpath + "\\" + fupEstbOpr.PostedFile.FileName);
                            }
                        }

                        SRVCAttachments objEstbOpr = new SRVCAttachments();
                        objEstbOpr.Questionnareid = Convert.ToString(Session["SRVCQID"]);  //Convert.ToString(Session["CFEQID"]);
                        objEstbOpr.MasterID = "166";
                        objEstbOpr.FilePath = serverpath + fupEstbOpr.PostedFile.FileName;
                        objEstbOpr.FileName = fupEstbOpr.PostedFile.FileName;
                        objEstbOpr.FileType = fupEstbOpr.PostedFile.ContentType;
                        objEstbOpr.FileDescription = "Consent to Establish or Operate";
                        objEstbOpr.CreatedBy = hdnUserID.Value;
                        objEstbOpr.IPAddress = getclientIP();
                        objEstbOpr.ReferenceNo = txtEstbOpr.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objEstbOpr);
                        if (result != "")
                        {
                            hypEstbOpr.Text = fupEstbOpr.PostedFile.FileName;
                            hypEstbOpr.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupEstbOpr.PostedFile.FileName);
                            hypEstbOpr.Target = "blank";
                            message = "alert('" + "Consent to Establish or Operate Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnPrsnlBOList_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupPrsnlBOList.HasFile)
                {
                    Error = validations(fupPrsnlBOList);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["SRVCQID"]) + "\\" + "List of personnel or brand Owners to whom the products will be supplied" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupPrsnlBOList.PostedFile.SaveAs(serverpath + "\\" + fupPrsnlBOList.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupPrsnlBOList.PostedFile.SaveAs(serverpath + "\\" + fupPrsnlBOList.PostedFile.FileName);
                            }
                        }

                        SRVCAttachments objDPR = new SRVCAttachments();
                        objDPR.Questionnareid = Convert.ToString(Session["SRVCQID"]);
                        objDPR.MasterID = "173";
                        objDPR.FilePath = serverpath + fupPrsnlBOList.PostedFile.FileName;
                        objDPR.FileName = fupPrsnlBOList.PostedFile.FileName;
                        objDPR.FileType = fupPrsnlBOList.PostedFile.ContentType;
                        objDPR.FileDescription = "list of personnel or brand Owners to whom the products will be supplied";
                        objDPR.CreatedBy = hdnUserID.Value;
                        objDPR.IPAddress = getclientIP();
                        objDPR.ReferenceNo = txtPrsnlBOList.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objDPR);
                        if (result != "")
                        {
                            hypPrsnlBOList.Text = fupPrsnlBOList.PostedFile.FileName;
                            hypPrsnlBOList.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupPrsnlBOList.PostedFile.FileName);
                            hypPrsnlBOList.Target = "blank";
                            message = "alert('" + "List of personnel or brand Owners to whom the products will be supplied Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblWater_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblWater.SelectedValue == "Yes")
                    divWater.Visible = true;
                else
                    divWater.Visible = false;

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblSgUt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblSgUt.SelectedValue == "Yes")
                    divSgUt.Visible = true;
                else
                    divSgUt.Visible = false;

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblAirCont_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblAirCont.SelectedValue == "Yes")
                    divAirCont.Visible = true;
                else
                    divAirCont.Visible = false;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnDisCentre_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupBOStUT.HasFile)
                {
                    Error = validations(fupBOStUT);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["SRVCQID"]) + "\\" + "Unit registered with the District Industries Centre of the State Government or Union territory Document" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupBOStUT.PostedFile.SaveAs(serverpath + "\\" + fupBOStUT.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupBOStUT.PostedFile.SaveAs(serverpath + "\\" + fupBOStUT.PostedFile.FileName);
                            }
                        }

                        SRVCAttachments objSTDT = new SRVCAttachments();
                        objSTDT.Questionnareid = Convert.ToString(Session["SRVCQID"]);  //Convert.ToString(Session["CFEQID"]);
                        objSTDT.MasterID = "175";
                        objSTDT.FilePath = serverpath + fupBOStUT.PostedFile.FileName;
                        objSTDT.FileName = fupBOStUT.PostedFile.FileName;
                        objSTDT.FileType = fupBOStUT.PostedFile.ContentType;
                        objSTDT.FileDescription = "Unit registered with the District Industries Centre of the State Government or Union territory Document";
                        objSTDT.CreatedBy = hdnUserID.Value;
                        objSTDT.IPAddress = getclientIP();
                        objSTDT.ReferenceNo = txtBOStUT.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSTDT);
                        if (result != "")
                        {
                            hypBOStUT.Text = fupBOStUT.PostedFile.FileName;
                            hypBOStUT.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupBOStUT.PostedFile.FileName);
                            hypBOStUT.Target = "blank";
                            message = "alert('" + "Unit registered with the District Industries Centre of the State Government or Union territory Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        public string validations(FileUpload Attachment)
        {
            try
            {
                string filesize = Convert.ToString(ConfigurationManager.AppSettings["FileSize"].ToString());
                int slno = 1; string Error = "";

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
                //  }
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


    }
}