using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MeghalayaUIP.User.Services
{
    public partial class PlasticWasteDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string UnitID, Questionnaire, ErrorMsg = "", result = "", UID = "";
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
                    if (Convert.ToString(Session["SRVCUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["SRVCUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/Services/SRVCUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }

                    if (!IsPostBack)
                    {
                        divProducer.Visible = false;
                        divBrandOwner.Visible = false;

                        GetAppliedorNot();
                        //BindData();
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

                ds = objSrvcbal.GetsrvcapprovalID(hdnUserID.Value, Convert.ToString(Session["SRVCQID"]), "12", "105");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["SRVCDA_APPROVALID"]) == "105")
                    {
                        BindStates();
                        BindDistricts();
                       // BindData();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Services/CDWMDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Services/EWasteDetails.aspx?Previous=" + "P");
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


        //private void BindData()
        //{
        //    try
        //    {
        //        // Fetching session values
        //        string srvcQdId = Convert.ToString(116);
        //        string unitId = Convert.ToString("1001");

        //        if (rblRole.SelectedValue == "Producer")
        //        {

        //            DataSet ds = new DataSet();
        //            ds = objSrvcbal.GetProdPlasticWasteDetails(srvcQdId, unitId);

        //            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //            {
        //                DataRow row = ds.Tables[0].Rows[0];

        //                txtProdName.Text = row["SRVCPWD_NAMEOFPROD"].ToString();
        //                txtUnitName.Text = row["SRVCPWD_NAMEOFUNIT"].ToString();

        //                string[] selectedCarryBag = ds.Tables[0].Rows[0]["SRVCPWD_CARRYBAG"].ToString().Split('/');

        //                foreach (ListItem item in chkCarryBags.Items)
        //                {
        //                    if (selectedCarryBag.Contains(item.Text.Trim()))
        //                    {
        //                        item.Selected = true;
        //                    }
        //                }
        //                chkMultilayeredPlastics.Text = row["SRVCPWD_MULTILAYEREDPLASTIC"].ToString();

        //                txtManufacturingCapacity.Text = row["SRVCPWD_MANFCTRNGCAPACITY"].ToString();
        //                txtPreviousRegistration.Text = row["SRVCPWD_PREVREGNO"].ToString();
        //                txtDate.Text = Convert.ToDateTime(row["SRVCPWD_REGDATE"]).ToString();
        //                txtCapitalInvestment.Text = row["SRVCPWD_TOTCAPTLINV"].ToString();
        //                txtCommencementYear.Text = row["SRVCPWD_YEAROFCMNCEMNT"].ToString();
        //                txtProductsList.Text = row["SRVCPWD_LISTQNTMPROD"].ToString();
        //                txtRawMaterials.Text = row["SRVCPWD_LISTQNTMRAWMAT"].ToString();
        //                txtTotalWaste.Text = row["SRVCPWD_TOTALQNTMWASTEGENERATED"].ToString();
        //                txtStorageMode.Text = row["SRVCPWD_MODEOFSTORAGEWITHINPLANT"].ToString();
        //                txtDisposal.Text = row["SRVCPWD_DISPOSALPROVISION"].ToString();
        //                rblCmplnc.Text = row["SRVCPWD_COMPLIANCE"].ToString();
        //            }
        //        }
        //        else if (rblRole.SelectedValue == "BrandOwner") 
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblmsg0.Text = ex.Message;
        //        Failure.Visible = true;
        //        MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
        //    }

        //}

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
                    ddlBOState.DataBind() ;

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

                    ddlUnitMand.DataSource= null;
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
                        serviceProdPlasticsWasteDetails.SrvcQdId = "116";//Convert.ToString(Session["SRVCQID"]);
                        serviceProdPlasticsWasteDetails.CreatedBy = "1001";// hdnUserID.Value;
                        serviceProdPlasticsWasteDetails.UnitId = "1001";// Convert.ToString(Session["SRVCUNITID"]);
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
                        serviceProdPlasticsWasteDetails.RegistrationDate = txtDate.Text.Trim();
                        serviceProdPlasticsWasteDetails.TotalCapitalInvestment = txtCapitalInvestment.Text;
                        serviceProdPlasticsWasteDetails.YearOfCommencement = txtCommencementYear.Text;
                        serviceProdPlasticsWasteDetails.ListQuantityProduct = txtProductsList.Text;
                        serviceProdPlasticsWasteDetails.ListQuantityRawMaterial = txtRawMaterials.Text;
                        serviceProdPlasticsWasteDetails.TotalQuantityWasteGenerated = txtTotalWaste.Text;
                        serviceProdPlasticsWasteDetails.ModeOfStorageWithinPlant = txtStorageMode.Text;
                        serviceProdPlasticsWasteDetails.DisposalProvision = txtDisposal.Text;
                        serviceProdPlasticsWasteDetails.Compliance = rblCmplnc.Text;



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
                        serviceBOPlasticsWasteDetails.SrvcQdId = "116";//Convert.ToString(Session["SRVCQID"]);
                        serviceBOPlasticsWasteDetails.CreatedBy = "1001"; //hdnUserID.Value;
                        serviceBOPlasticsWasteDetails.UnitId = "1001";// Convert.ToString(Session["SRVCUNITID"]);
                        serviceBOPlasticsWasteDetails.CreatedByIp = getclientIP();

                        // Assigning values from brand owner form controls
                        serviceBOPlasticsWasteDetails.NameOfBrandOwner = txtBrandOwnrName.Text;
                        serviceBOPlasticsWasteDetails.PreviousRegistrationNumber = txtBORegNo.Text;
                        serviceBOPlasticsWasteDetails.RegistrationDate = txtBODate.Text.Trim();
                        serviceBOPlasticsWasteDetails.TotalCapitalInvestment = txtBOTotalCapInv.Text;
                        serviceBOPlasticsWasteDetails.YearOfCommencement = txtBOYearOfComncmnt.Text;
                        serviceBOPlasticsWasteDetails.ByProdProductList = txtBOProdQuan.Text;
                        serviceBOPlasticsWasteDetails.ByProdRawMaterialList = txtBORawMatQuan.Text;
                        serviceBOPlasticsWasteDetails.TotalQuantityWasteGenerated = txtBORawMatQuan.Text;
                        serviceBOPlasticsWasteDetails.ModeOfStorageWithinPlant = txtBOModeStrge.Text;
                        serviceBOPlasticsWasteDetails.DisposalProvision = txtBODispProv.Text;

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
                //btnsave_Click(sender, e);
                //if (ErrorMsg == "")
                    Response.Redirect("~/User/Services/CDWMDetails.aspx?Next=" + "N");
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
            Response.Redirect("~/User/Services/EWasteDetails.aspx?Previous=" + "P");
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
            divProducer.Visible = rblRole.SelectedValue == "Producer";
            divBrandOwner.Visible = rblRole.SelectedValue == "BrandOwner";
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

        
    }
}