using MeghalayaUIP.BAL.CFOBAL;
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

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOLabourDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
        string UnitID, ErrorMsg = "", result = "";
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

                    if (Convert.ToString(Session["CFOUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["CFOUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/CFO/CFOUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }




                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        DataSet dsnew = new DataSet();
                        dsnew = objcfobal.GetApprovalDataByDeptId(Session["CFOQID"].ToString(), Session["CFOUNITID"].ToString(), "10");
                        if (dsnew.Tables[0].Rows.Count > 0)
                        {
                            BindBoilerType();
                            Binddata();
                        }
                        else
                        {
                            if (Request.QueryString[0].ToString() == "N")
                            {
                                Response.Redirect("~/User/CFO/CFOLegalMeterology.aspx?next=N");
                            }
                            else
                            {
                                Response.Redirect("~/User/CFO/CFOLineOfManufactureDetails.aspx?Previous=P");
                            }
                        }
                       

                    }
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            
        }
        public void Binddata()
        {
            //hdnUserID.Value = "1001";
            try
            {
                DataSet ds = new DataSet();
                ds = objcfobal.GetLabourDetails(hdnUserID.Value, UnitID);
                
                if (ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0 || ds.Tables[3].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[1].Rows[0]["CFOLD_UNITID"]);

                        RBLAPPROVED.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_DIRECTINDIRECT"].ToString();
                        if (RBLAPPROVED.Text == "Y")
                        {
                            Approved.Visible = true;
                            txtProvide.Text = ds.Tables[1].Rows[0]["CFOLD_PROVIDEDETAILS"].ToString();
                        }
                        else { Approved.Visible = false; }
                        ddlApplied.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_APPLIED"].ToString();
                        txtESTYear.Text = ds.Tables[1].Rows[0]["CFOLD_YEAR"].ToString();
                        rblmaximum.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_TEMPMATERIAL"].ToString();
                        rblregulation.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_REGULATION1950"].ToString();
                        rblgenerator.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_GENGRINDE"].ToString();
                        rbldesignation.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_DESIGNATION"].ToString();
                        txtSite.Text = ds.Tables[1].Rows[0]["CFOLD_SITES"].ToString();
                        rblstrictly.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_REGULATION81"].ToString();
                        rblfirm.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_CONTROVERSIAL"].ToString();
                        rblmaterial.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_MATERIAL"].ToString();
                        rblinternalcontrol.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_OWNSYSTEM"].ToString();
                        rbldocument.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_UPLOADDOCUMENT"].ToString();
                        txtname1.Text = ds.Tables[1].Rows[0]["CFOLD_MANUFACTURENAME"].ToString();
                        txtfather.Text = ds.Tables[1].Rows[0]["CFOLD_MANUYEAR"].ToString();
                        txtage.Text = ds.Tables[1].Rows[0]["CFOLD_MANUPLACE"].ToString();
                        txtBoilerNumber.Text = ds.Tables[1].Rows[0]["CFOLD_BOILERNUMBER"].ToString();
                        txtIntendedPressure.Text = ds.Tables[1].Rows[0]["CFOLD_INTENDED"].ToString();
                        ddlManufacture.SelectedItem.Text = ds.Tables[1].Rows[0]["CFOLD_MANUFACTUREPLACE"].ToString();
                        txtSuperRating.Text = ds.Tables[1].Rows[0]["CFOLD_HEATERRATING"].ToString();
                        txtEconomise.Text = ds.Tables[1].Rows[0]["CFOLD_ECONOMISERRATING"].ToString();
                        txtTonnes.Text = ds.Tables[1].Rows[0]["CFOLD_EVAPORATION"].ToString();
                        txtHeaterRating.Text = ds.Tables[1].Rows[0]["CFOLD_REHEATERRATING"].ToString();
                        ddlWkgSeason.SelectedItem.Text = ds.Tables[1].Rows[0]["CFOLD_SEASON"].ToString();
                        txtPressure.Text = ds.Tables[1].Rows[0]["CFOLD_PRESSURE"].ToString();
                        txtOwner.Text = ds.Tables[1].Rows[0]["CFOLD_OWNERNAME"].ToString();
                        ddlTypeBoiler.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_TYPEBOILER"].ToString();
                        txtDESCBoiler.Text = ds.Tables[1].Rows[0]["CFOLD_DESCBOILER"].ToString();
                        txtBoilerRating.Text = ds.Tables[1].Rows[0]["CFOLD_BOILERRATING"].ToString();
                        rblBoilerTrans.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_BOILEROWNERTRANSF"].ToString();
                        if (rblBoilerTrans.Text == "Y")
                        {
                            txtBoiler.Visible = true;
                            txtRemark.Text = ds.Tables[1].Rows[0]["CFOLD_REMARK"].ToString();
                        }
                        else { txtBoiler.Visible = false; }

                        txtNameManu.Text = ds.Tables[1].Rows[0]["CFOLD_MANUNAME"].ToString();
                        txtYearManu.Text = ds.Tables[1].Rows[0]["CFOLD_MANUFACTUREYEAR"].ToString();
                        txtPlaceManu.Text = ds.Tables[1].Rows[0]["CFOLD_MANUFACTPLACE"].ToString();
                        txtNameAgent.Text = ds.Tables[1].Rows[0]["CFOLD_NAMEAGENT"].ToString();
                        txtAddress.Text = ds.Tables[1].Rows[0]["CFOLD_ADDRESSAGENT"].ToString();
                        txtlocation.Text = ds.Tables[1].Rows[0]["CFOLD_WORKETAILS"].ToString();
                        txtdayslabour.Text = ds.Tables[1].Rows[0]["CFOLD_DAYSLABOUR"].ToString();
                        txtEStdate.Text = ds.Tables[1].Rows[0]["CFOLD_ESTDATE"].ToString();
                        txtEndDate.Text = ds.Tables[1].Rows[0]["CFOLD_ENDDATE"].ToString();
                        txtMaximumnumber.Text = ds.Tables[1].Rows[0]["CFOLD_CONTRACTEMP"].ToString();
                        rblConvicated.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_FIVEYEARCONVICTED"].ToString();
                        if (rblConvicated.Text == "Y")
                        {
                            txtcontractor.Visible = true;
                            txtDetails.Text = ds.Tables[1].Rows[0]["CFOLD_DETAILS"].ToString();
                        }
                        else { txtcontractor.Visible = false; }

                        rblrevoking.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_REVORKING"].ToString();
                        if (rblrevoking.Text == "Y")
                        {
                            suspend.Visible = true;
                            txtOrderDate.Text = ds.Tables[1].Rows[0]["CFOLD_ORDERDAET"].ToString();
                        }
                        else { suspend.Visible = false; }
                        rblcontractor.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_ESTCONTRACTOR"].ToString();
                        if (rblcontractor.Text == "Y")
                        {
                            fiveyear.Visible = true;
                            txtprinciple.Text = ds.Tables[1].Rows[0]["CFOLD_PRINCIPLEEMP"].ToString();
                        }
                        else { fiveyear.Visible = false; }

                        if (rblcontractor.Text == "Y")
                        {
                            nature.Visible = true;
                            txtEstablishment.Text = ds.Tables[1].Rows[0]["CFOLD_ESTDETAILS"].ToString();
                            txtNature.Text = ds.Tables[1].Rows[0]["CFOLD_NATUREWORK"].ToString();
                        }
                        else { nature.Visible = false; }
                        txtAgent.Text = ds.Tables[1].Rows[0]["CFOLD_MANAGERNAME"].ToString();
                        txtfathername.Text = ds.Tables[1].Rows[0]["CFOLD_ADDRESSMANAGER"].ToString();
                        ddlCategory.SelectedItem.Text = ds.Tables[1].Rows[0]["CFOLD_CATEGORYEST"].ToString();
                        txtNaturebusiness.Text = ds.Tables[1].Rows[0]["CFOLD_NATUREBUSINESS"].ToString();
                        rblresinding.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_FAMILYEMP"].ToString();
                        rblestemployee.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_EMPEST"].ToString();
                        txtTotalEMP.Text = ds.Tables[1].Rows[0]["CFOLD_TOTALEMP"].ToString();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                      //  hdnUserID.Value = Convert.ToString(ds.Tables[2].Rows[0]["CFOLD_CFOQDID"]);
                        ViewState["LabourDetails"] = ds.Tables[2];
                        GVCFOLabour.DataSource = ds.Tables[2];
                        GVCFOLabour.DataBind();
                        GVCFOLabour.Visible = true;
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                        {
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 105)//
                            {
                                hypLICIssued.Visible = true;
                                hypLICIssued.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypLICIssued.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 106) //
                            {
                                hypFormX.Visible = true;
                                hypFormX.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypFormX.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 107) //
                            {
                                hypCriminal.Visible = true;
                                hypCriminal.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypCriminal.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 108)//
                            {
                                hypPrincipalEMP.Visible = true;
                                hypPrincipalEMP.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypPrincipalEMP.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 109) //
                            {
                                hypBusinessLic.Visible = true;
                                hypBusinessLic.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypBusinessLic.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 110) //
                            {
                                hypEST.Visible = true;
                                hypEST.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypEST.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 111) //
                            {
                                hypForm5.Visible = true;
                                hypForm5.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypForm5.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 112) //
                            {
                                hypADC.Visible = true;
                                hypADC.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypADC.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
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

        protected void Addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtages.Text) || string.IsNullOrEmpty(txtFulladdress.Text) || string.IsNullOrEmpty(txtPermanent.Text) || string.IsNullOrEmpty(txtHalfDay.Text) || string.IsNullOrEmpty(txtFullDay.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFOLD_UNITID", typeof(string));
                    dt.Columns.Add("CFOLD_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFOLD_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFOLD_NAME", typeof(string));
                    dt.Columns.Add("CFOLD_GENDER", typeof(string));
                    dt.Columns.Add("CFOLD_AGE", typeof(string));
                    dt.Columns.Add("CFOLD_COMMUNITY", typeof(string));
                    dt.Columns.Add("CFOLD_FULLADDRESS", typeof(string));
                    dt.Columns.Add("CFOLD_ADDRESS", typeof(string));
                    dt.Columns.Add("CFOLD_HALFDAY", typeof(string));
                    dt.Columns.Add("CFOLD_FULLDAY", typeof(string));

                    if (ViewState["LabourDetails"] != null)
                    {
                        dt = (DataTable)ViewState["LabourDetails"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFOLD_UNITID"] = Convert.ToString(Session["CFOUNITID"]);
                    dr["CFOLD_CREATEDBY"] = hdnUserID.Value;
                    dr["CFOLD_CREATEDBYIP"] = getclientIP();
                    dr["CFOLD_NAME"] = txtName.Text.Trim();
                    dr["CFOLD_GENDER"] = rblGender.SelectedItem.Text;
                    dr["CFOLD_AGE"] = txtages.Text;
                    dr["CFOLD_COMMUNITY"] = txtCommunity.Text;
                    dr["CFOLD_FULLADDRESS"] = txtFulladdress.Text;
                    dr["CFOLD_ADDRESS"] = txtPermanent.Text;
                    dr["CFOLD_HALFDAY"] = txtHalfDay.Text;
                    dr["CFOLD_FULLDAY"] = txtFullDay.Text;

                    dt.Rows.Add(dr);
                    GVCFOLabour.Visible = true;
                    GVCFOLabour.DataSource = dt;
                    GVCFOLabour.DataBind();
                    ViewState["LabourDetails"] = dt;

                    txtName.Text = "";
                    rblGender.SelectedValue = "";
                    txtages.Text = "";
                    txtCommunity.Text = "";
                    txtFulladdress.Text = "";
                    txtPermanent.Text = "";
                    txtHalfDay.Text = "";
                    txtFullDay.Text = "";
                    txtTotalEMP.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GVCFOLabour_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVCFOLabour.Rows.Count > 0)
                {
                    ((DataTable)ViewState["LabourDetails"]).Rows.RemoveAt(e.RowIndex);
                    this.GVCFOLabour.DataSource = ((DataTable)ViewState["LabourDetails"]).DefaultView;
                    this.GVCFOLabour.DataBind();
                    GVCFOLabour.Visible = true;
                    GVCFOLabour.Focus();

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

        protected void savebtn_Click(object sender, EventArgs e)
        {

            try
            {

                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    CFOLabourDet ObjCFOLabourDet = new CFOLabourDet();
                    int count = 0;
                    for (int i = 0; i < GVCFOLabour.Rows.Count; i++)
                    {
                        ObjCFOLabourDet.Questionnariid = Convert.ToString(Session["CFOQID"]);
                        ObjCFOLabourDet.CreatedBy = hdnUserID.Value;
                        ObjCFOLabourDet.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        ObjCFOLabourDet.IPAddress = getclientIP();
                        ObjCFOLabourDet.NAME = GVCFOLabour.Rows[i].Cells[1].Text;
                        ObjCFOLabourDet.GENDER = GVCFOLabour.Rows[i].Cells[2].Text;
                        ObjCFOLabourDet.AGE = GVCFOLabour.Rows[i].Cells[3].Text;
                        ObjCFOLabourDet.COMMUNITY = GVCFOLabour.Rows[i].Cells[4].Text;
                        ObjCFOLabourDet.FULLADDRESS = GVCFOLabour.Rows[i].Cells[5].Text;
                        ObjCFOLabourDet.ADDRESS = GVCFOLabour.Rows[i].Cells[6].Text;
                        ObjCFOLabourDet.HALFDAY = GVCFOLabour.Rows[i].Cells[7].Text;
                        ObjCFOLabourDet.FULLDAY = GVCFOLabour.Rows[i].Cells[8].Text;

                        string A = objcfobal.InsertCFOlabourContractor(ObjCFOLabourDet);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVCFOLabour.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "CFOLABOUR CONTRACTOR Details Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                    ObjCFOLabourDet.UNITID = Convert.ToString(Session["CFOUNITID"]);
                    ObjCFOLabourDet.CreatedBy = hdnUserID.Value;
                    ObjCFOLabourDet.IPAddress = getclientIP();
                    ObjCFOLabourDet.Questionnariid = Convert.ToString(Session["CFOQID"]);
                    ObjCFOLabourDet.UnitId = Convert.ToString(Session["CFOUNITID"]);
                    ObjCFOLabourDet.DirectorateBoiler = RBLAPPROVED.SelectedValue;
                    ObjCFOLabourDet.Classification = ddlApplied.SelectedValue;
                    ObjCFOLabourDet.ProvideDetails = txtProvide.Text;
                    ObjCFOLabourDet.Establishmentyear = txtESTYear.Text;
                    ObjCFOLabourDet.temperature = rblmaximum.SelectedValue;
                    ObjCFOLabourDet.BoilerRegulation = rblregulation.SelectedValue;
                    ObjCFOLabourDet.generatortool = rblgenerator.SelectedValue;
                    ObjCFOLabourDet.Document = rbldesignation.SelectedValue;
                    ObjCFOLabourDet.firm = txtSite.Text;
                    ObjCFOLabourDet.regulationstrictly = rblstrictly.SelectedValue;
                    ObjCFOLabourDet.controversial = rblfirm.SelectedValue;
                    ObjCFOLabourDet.materials = rblmaterial.SelectedValue;
                    ObjCFOLabourDet.OwnSystem = rblinternalcontrol.SelectedValue;
                    ObjCFOLabourDet.Upload_Document = rbldocument.SelectedValue;
                    ObjCFOLabourDet.NameManufacture = txtname1.Text.Trim();
                    ObjCFOLabourDet.manufactureYear = txtfather.Text;
                    ObjCFOLabourDet.manufactureplace = txtage.Text;
                    ObjCFOLabourDet.BoilerNumber = txtBoilerNumber.Text;
                    ObjCFOLabourDet.Intendedpressure = txtIntendedPressure.Text;
                    ObjCFOLabourDet.manufacture = ddlManufacture.SelectedItem.Text;
                    ObjCFOLabourDet.HeaterRating = txtSuperRating.Text;
                    ObjCFOLabourDet.Economiser = txtEconomise.Text;
                    ObjCFOLabourDet.MaximumTonne = txtTonnes.Text;
                    ObjCFOLabourDet.RatingHeaters = txtHeaterRating.Text;
                    ObjCFOLabourDet.WorkingSeason = ddlWkgSeason.SelectedItem.Text;
                    ObjCFOLabourDet.PressurePSI = txtPressure.Text;
                    ObjCFOLabourDet.NameOwner = txtOwner.Text;
                    ObjCFOLabourDet.BoilerType = ddlTypeBoiler.SelectedValue;
                    ObjCFOLabourDet.DescriptionBoiler = txtDESCBoiler.Text;
                    ObjCFOLabourDet.BoilerRating = txtBoilerRating.Text;
                    ObjCFOLabourDet.ownershipBoiler = rblBoilerTrans.SelectedValue;
                    ObjCFOLabourDet.Remarks = txtRemark.Text;
                    ObjCFOLabourDet.ManufactureNames = txtNameManu.Text;
                    ObjCFOLabourDet.ManufactureYears = txtYearManu.Text;
                    ObjCFOLabourDet.Placemanu = txtPlaceManu.Text;
                    ObjCFOLabourDet.NameAgent = txtNameAgent.Text;
                    ObjCFOLabourDet.Address = txtAddress.Text;
                    ObjCFOLabourDet.NameNature = txtlocation.Text;
                    ObjCFOLabourDet.contractorlabour = txtdayslabour.Text;
                    ObjCFOLabourDet.Estimateddate = txtEStdate.Text;
                    ObjCFOLabourDet.Endingdate = txtEndDate.Text;
                    ObjCFOLabourDet.Maximumemployed = txtMaximumnumber.Text;
                    ObjCFOLabourDet.withinfiveyear = rblConvicated.SelectedValue;
                    ObjCFOLabourDet.Details = txtDetails.Text;
                    ObjCFOLabourDet.licenseDeposite = rblrevoking.SelectedValue;
                    ObjCFOLabourDet.OrderDate = txtOrderDate.Text;
                    ObjCFOLabourDet.establishmentpast = rblcontractor.SelectedValue;
                    ObjCFOLabourDet.PrincipalEMP = txtprinciple.Text;
                    ObjCFOLabourDet.EstablishmentDET = txtEstablishment.Text;
                    ObjCFOLabourDet.NatureWORK = txtNature.Text;
                    ObjCFOLabourDet.generalManagement = txtAgent.Text.Trim();
                    ObjCFOLabourDet.AddressAgent = txtfathername.Text;
                    ObjCFOLabourDet.CategoryEst = ddlCategory.SelectedItem.Text;
                    ObjCFOLabourDet.NatureBusiness = txtNaturebusiness.Text;
                    ObjCFOLabourDet.establishmentfamily = rblresinding.SelectedValue;
                    ObjCFOLabourDet.employeeswork = rblestemployee.SelectedValue;
                    ObjCFOLabourDet.TotalNumberEMP = txtTotalEMP.Text;

                    result = objcfobal.InsertCFOLabourDetails(ObjCFOLabourDet);
                    //ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Labour Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                    else
                    {
                        Failure.Visible = true;
                        lblmsg0.Text = "Labour Details Not Submitted";
                        string message = "alert('" + lblmsg0.Text + "')";
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



        public string Validations()
        {
            try
            {
                int slno = 1;
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);
                string errormsg = "";
                if (GVCFOLabour.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter CFOLABOUR \\n";
                    slno = slno + 1;
                }
                if (RBLAPPROVED.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether the firm has ever been approved by any Boilers’ Directorate / Inspectorate? \\n";
                    slno = slno + 1;
                }
                if (RBLAPPROVED.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtProvide.Text) || txtProvide.Text == "" || txtProvide.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Provide Details \\n";
                        slno = slno + 1;
                    }
                }

                if (ddlApplied.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Classification applied for  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtESTYear.Text) || txtESTYear.Text == "" || txtESTYear.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Year of Establishment \\n";
                    slno = slno + 1;
                }
                if (rblmaximum.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter temperature and the materials involved, with documentary evidence? \\n";
                    slno = slno + 1;
                }
                if (rblregulation.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter repairer under Indian Boiler Regulation, 1950 been rejected by any authority \\n";
                    slno = slno + 1;
                }
                if (rblgenerator.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter  expander and measuring instruments or any other tools and tackles under regulation 392 (5) (i)? \\n";
                    slno = slno + 1;
                }
                if (rbldesignation.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter educational qualifications and relevant experience (attach copies of documents) who are permanently employed with the firm ? \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSite.Text) || txtSite.Text == "" || txtSite.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter working sites can be handled by the firm simultaneously? \\n";
                    slno = slno + 1;
                }
                if (rblstrictly.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter the firm is prepared to execute the job strictly in 81 conformity with the regulations and maintain a high standard of work ? \\n";
                    slno = slno + 1;
                }
                if (rblfirm.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter accept full responsibility for the work done and is prepared to clarify any controversial issue, if required? \\n";
                    slno = slno + 1;
                }
                if (rblmaterial.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter a position to supply materials to required specification with proper test certificates if asked for ? \\n";
                    slno = slno + 1;
                }
                if (rblinternalcontrol.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter the firm has an internal quality control system of their own ?? \\n";
                    slno = slno + 1;
                }
                if (rbldocument.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter employed with copies of current certificate issued by a Competent Authority under the Indian Boiler Regulations, 1950? \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtname1.Text.Trim()) || txtname1.Text.Trim() == "" || txtname1.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter MANUFACTURE NAME \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtfather.Text) || txtfather.Text == "" || txtfather.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Year of manufacture  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtage.Text) || txtage.Text == "" || txtage.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Place of manufacture \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBoilerNumber.Text) || txtBoilerNumber.Text == "" || txtBoilerNumber.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Boiler Maker's Number\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIntendedPressure.Text) || txtIntendedPressure.Text == "" || txtIntendedPressure.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Intended Working Pressure \\n";
                    slno = slno + 1;
                }
                //if (ddlManufacture.SelectedIndex == 0)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Place of manufacture  \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtSuperRating.Text) || txtSuperRating.Text == "" || txtSuperRating.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Super Heater Rating \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEconomise.Text) || txtEconomise.Text == "" || txtEconomise.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Economiser Rating \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTonnes.Text) || txtTonnes.Text == "" || txtTonnes.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Maximum Continuous Evaporation (Tonnes/Hour) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtHeaterRating.Text) || txtHeaterRating.Text == "" || txtHeaterRating.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Re-Heater Rating \\n";
                    slno = slno + 1;
                }
                //if (ddlWkgSeason.SelectedIndex == 0)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Working Season  \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtPressure.Text) || txtPressure.Text == "" || txtPressure.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Working Pressure \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtOwner.Text.Trim()) || txtOwner.Text.Trim() == "" || txtOwner.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the owner  \\n";
                    slno = slno + 1;
                }
                if (ddlTypeBoiler.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Type of Boiler  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDESCBoiler.Text) || txtDESCBoiler.Text == "" || txtDESCBoiler.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Description of Boiler  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBoilerRating.Text) || txtBoilerRating.Text == "" || txtBoilerRating.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter BoilerRating \\n";
                    slno = slno + 1;
                }
                if (rblBoilerTrans.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Boiler ownership being transfer  \\n";
                    slno = slno + 1;
                }
                if (rblBoilerTrans.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtRemark.Text) || txtRemark.Text == "" || txtRemark.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Remarks  \\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtNameManu.Text) || txtNameManu.Text == "" || txtNameManu.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Manufacturer \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtYearManu.Text) || txtYearManu.Text == "" || txtYearManu.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Year of manufacture  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPlaceManu.Text) || txtPlaceManu.Text == "" || txtPlaceManu.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Place of manufacture \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNameAgent.Text.Trim()) || txtNameAgent.Text.Trim() == "" || txtNameAgent.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of agent or manager\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text == "" || txtAddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address of the agent or manager  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtlocation.Text) || txtlocation.Text == "" || txtlocation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter which contract labour is employed / is to be employed in the establishment  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdayslabour.Text) || txtdayslabour.Text == "" || txtdayslabour.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter No of days of contract labour \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEStdate.Text) || txtEStdate.Text == "" || txtEStdate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Estimated date of commencement \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEndDate.Text) || txtEndDate.Text == "" || txtEndDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Ending Date  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMaximumnumber.Text) || txtMaximumnumber.Text == "" || txtMaximumnumber.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Maximum number of contract labour proposed to be employed \\n";
                    slno = slno + 1;
                }
                if (rblConvicated.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select the contractor is convicted of any offence within the proceeding five years \\n";
                    slno = slno + 1;
                }
                if (rblConvicated.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtDetails.Text) || txtDetails.Text == "" || txtDetails.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Details  \\n";
                        slno = slno + 1;
                    }
                }
                if (rblrevoking.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select there was any order against the contractor revoking or suspending license or forfeiting Security Deposit in respect of an earlier contract.  \\n";
                    slno = slno + 1;
                }
                if (rblrevoking.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtOrderDate.Text) || txtOrderDate.Text == "" || txtOrderDate.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Order Date  \\n";
                        slno = slno + 1;
                    }
                }
                if (rblcontractor.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select the contractor has work in any other establishment within the past five years  \\n";
                    slno = slno + 1;
                }
                if (rblcontractor.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtprinciple.Text) || txtprinciple.Text == "" || txtprinciple.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Principal's Employers Details  \\n";
                        slno = slno + 1;
                    }

                    if (string.IsNullOrEmpty(txtEstablishment.Text) || txtEstablishment.Text == "" || txtEstablishment.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Establishment's Details  \\n";
                        slno = slno + 1;
                    }

                    if (string.IsNullOrEmpty(txtNature.Text) || txtNature.Text == "" || txtNature.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Nature of work  \\n";
                        slno = slno + 1;
                    }

                }
                if (string.IsNullOrEmpty(txtAgent.Text.Trim()) || txtAgent.Text.Trim() == "" || txtAgent.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Manager /Agent/other  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtfathername.Text) || txtfathername.Text == "" || txtfathername.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address of the Manager/Agent \\n";
                    slno = slno + 1;
                }
                //if (ddlCategory.SelectedIndex==0)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Category of Establishmnet   \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtNaturebusiness.Text) || txtNaturebusiness.Text == "" || txtNaturebusiness.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Nature of Business  \\n";
                    slno = slno + 1;
                }
                if (rblresinding.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter your family members employed in the establishment and residing with and wholly dependent upon you?    \\n";
                    slno = slno + 1;
                }
                if (rblestemployee.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Do you have employees working in the establishment?   \\n";
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

        protected void RBLAPPROVED_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (RBLAPPROVED.SelectedValue == "Y")
                {
                    Approved.Visible = true;
                }
                else
                {
                    Approved.Visible = false;
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            RBLAPPROVED.BorderColor = System.Drawing.Color.White;
        }

        protected void rblBoilerTrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblBoilerTrans.SelectedValue == "Y")
                {
                    txtBoiler.Visible = true;
                }
                else
                {
                    txtBoiler.Visible = false;
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblBoilerTrans.BorderColor = System.Drawing.Color.White;
        }

        protected void rblConvicated_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblConvicated.SelectedValue == "Y")
                {
                    txtcontractor.Visible = true;
                }
                else
                {
                    txtcontractor.Visible = false;
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblConvicated.BorderColor = System.Drawing.Color.White;
        }

        protected void rblrevoking_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblrevoking.SelectedValue == "Y")
                {
                    suspend.Visible = true;
                }
                else
                {
                    suspend.Visible = false;
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblrevoking.BorderColor = System.Drawing.Color.White;
        }

        protected void rblcontractor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblcontractor.SelectedValue == "Y")
                {
                    fiveyear.Visible = true;
                    nature.Visible = true;
                }
                else
                {
                    fiveyear.Visible = false;
                    nature.Visible = false;
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblcontractor.BorderColor = System.Drawing.Color.White;
        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFO/CFOLineOfManufactureDetails.aspx?Previous=P");
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
                savebtn_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFO/CFOLegalMeterology.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

            //  Response.Redirect("~/User/CFO/CFOLegalMeterology.aspx?next=N");
        }
        protected void BindBoilerType()
        {
            try
            {
                ddlTypeBoiler.Items.Clear();

                List<MasterBOILERTYPE> objStatesModel = new List<MasterBOILERTYPE>();

                objStatesModel = mstrBAL.GetBoilerType();
                if (objStatesModel != null)
                {
                    ddlTypeBoiler.DataSource = objStatesModel;
                    ddlTypeBoiler.DataValueField = "BOILER_ID";
                    ddlTypeBoiler.DataTextField = "BOILER_NAME";
                    ddlTypeBoiler.DataBind();
                }
                else
                {
                    ddlTypeBoiler.DataSource = null;
                    ddlTypeBoiler.DataBind();
                }
                AddSelect(ddlTypeBoiler);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnLICIssued_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLICIssued.HasFile)
                {
                    Error = validations(fupLICIssued);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Form VIII" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupLICIssued.PostedFile.SaveAs(serverpath + "\\" + fupLICIssued.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "105";
                        objAadhar.FilePath = serverpath + fupLICIssued.PostedFile.FileName;
                        objAadhar.FileName = fupLICIssued.PostedFile.FileName;
                        objAadhar.FileType = fupLICIssued.PostedFile.ContentType;
                        objAadhar.FileDescription = "Form VIII - License issued for recruiting workers";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypLICIssued.Text = fupLICIssued.PostedFile.FileName;
                            hypLICIssued.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypLICIssued.Target = "blank";
                            message = "alert('" + "Form VIII - License issued for recruiting workers from the state of recruitment Uploaded successfully" + "')";
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

        protected void btnFormX_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupFormX.HasFile)
                {
                    Error = validations(fupFormX);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Form x" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupFormX.PostedFile.SaveAs(serverpath + "\\" + fupFormX.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "106";
                        objAadhar.FilePath = serverpath + fupFormX.PostedFile.FileName;
                        objAadhar.FileName = fupFormX.PostedFile.FileName;
                        objAadhar.FileType = fupFormX.PostedFile.ContentType;
                        objAadhar.FileDescription = "Form X affixed with epic and photograph of all the workmen";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypFormX.Text = fupFormX.PostedFile.FileName;
                            hypFormX.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypFormX.Target = "blank";
                            message = "alert('" + "Form X affixed with epic and photograph of all the workmen (single file of all workmen) Uploaded successfully" + "')";
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

        protected void btnCriminal_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupCriminal.HasFile)
                {
                    Error = validations(fupCriminal);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Proof of Residence and Criminal" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupCriminal.PostedFile.SaveAs(serverpath + "\\" + fupCriminal.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "107";
                        objAadhar.FilePath = serverpath + fupCriminal.PostedFile.FileName;
                        objAadhar.FileName = fupCriminal.PostedFile.FileName;
                        objAadhar.FileType = fupCriminal.PostedFile.ContentType;
                        objAadhar.FileDescription = "Proof of Residence and Criminal antecedents issued by District Magistrates";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypCriminal.Text = fupCriminal.PostedFile.FileName;
                            hypCriminal.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypCriminal.Target = "blank";
                            message = "alert('" + "Proof of Residence and Criminal antecedents issued by District Magistrates Uploaded successfully" + "')";
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

        protected void btnPrincipalEMP_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupPrincipalEMP.HasFile)
                {
                    Error = validations(fupPrincipalEMP);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Certificate from Principal Employer" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupPrincipalEMP.PostedFile.SaveAs(serverpath + "\\" + fupPrincipalEMP.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "108";
                        objAadhar.FilePath = serverpath + fupPrincipalEMP.PostedFile.FileName;
                        objAadhar.FileName = fupPrincipalEMP.PostedFile.FileName;
                        objAadhar.FileType = fupPrincipalEMP.PostedFile.ContentType;
                        objAadhar.FileDescription = "Certificate from Principal Employer";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypPrincipalEMP.Text = fupPrincipalEMP.PostedFile.FileName;
                            hypPrincipalEMP.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypPrincipalEMP.Target = "blank";
                            message = "alert('" + "Certificate from Principal Employer Uploaded successfully" + "')";
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

        protected void btnBusinessLic_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupBusinessLic.HasFile)
                {
                    Error = validations(fupBusinessLic);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Trading" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupBusinessLic.PostedFile.SaveAs(serverpath + "\\" + fupBusinessLic.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "109";
                        objAadhar.FilePath = serverpath + fupBusinessLic.PostedFile.FileName;
                        objAadhar.FileName = fupBusinessLic.PostedFile.FileName;
                        objAadhar.FileType = fupBusinessLic.PostedFile.ContentType;
                        objAadhar.FileDescription = "Trading";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypBusinessLic.Text = fupBusinessLic.PostedFile.FileName;
                            hypBusinessLic.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypBusinessLic.Target = "blank";
                            message = "alert('" + "Trading Uploaded successfully" + "')";
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

        protected void btnEST_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupEST.HasFile)
                {
                    Error = validations(fupEST);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Registration of establishment of the principal employer" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupEST.PostedFile.SaveAs(serverpath + "\\" + fupEST.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "110";
                        objAadhar.FilePath = serverpath + fupEST.PostedFile.FileName;
                        objAadhar.FileName = fupEST.PostedFile.FileName;
                        objAadhar.FileType = fupEST.PostedFile.ContentType;
                        objAadhar.FileDescription = "Registration of establishment of the principal employer";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypEST.Text = fupEST.PostedFile.FileName;
                            hypEST.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypEST.Target = "blank";
                            message = "alert('" + "Registration of establishment of the principal employer Uploaded successfully" + "')";
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
        protected void btnForm5_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupForm5.HasFile)
                {
                    Error = validations(fupForm5);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Form-V" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupForm5.PostedFile.SaveAs(serverpath + "\\" + fupForm5.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "111";
                        objAadhar.FilePath = serverpath + fupForm5.PostedFile.FileName;
                        objAadhar.FileName = fupForm5.PostedFile.FileName;
                        objAadhar.FileType = fupForm5.PostedFile.ContentType;
                        objAadhar.FileDescription = "Form-V – Certificate from Principal Employer";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypForm5.Text = fupForm5.PostedFile.FileName;
                            hypForm5.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypForm5.Target = "blank";
                            message = "alert('" + "Form-V – Certificate from Principal Employer Uploaded successfully" + "')";
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

        protected void btnADC_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupADC.HasFile)
                {
                    Error = validations(fupADC);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Trading Licence from ADC/Municipality" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupADC.PostedFile.SaveAs(serverpath + "\\" + fupADC.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "112";
                        objAadhar.FilePath = serverpath + fupADC.PostedFile.FileName;
                        objAadhar.FileName = fupADC.PostedFile.FileName;
                        objAadhar.FileType = fupADC.PostedFile.ContentType;
                        objAadhar.FileDescription = "Trading Licence from ADC/Municipality";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypADC.Text = fupADC.PostedFile.FileName;
                            hypADC.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypADC.Target = "blank";
                            message = "alert('" + "Trading Licence from ADC/Municipality Uploaded successfully" + "')";
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
            {
                throw ex;
            }
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
        public void DeleteFile(string strFileName)
        {
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }

        protected void rblmaximum_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblmaximum.BorderColor = System.Drawing.Color.White;
        }

        protected void rblregulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblregulation.BorderColor = System.Drawing.Color.White;
        }

        protected void rblgenerator_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblgenerator.BorderColor = System.Drawing.Color.White;
        }

        protected void rbldesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbldesignation.BorderColor = System.Drawing.Color.White;
        }

        protected void rblstrictly_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblstrictly.BorderColor = System.Drawing.Color.White;
        }

        protected void rblfirm_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblfirm.BorderColor = System.Drawing.Color.White;
        }

        protected void rblmaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblmaterial.BorderColor = System.Drawing.Color.White;
        }

        protected void rblinternalcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblinternalcontrol.BorderColor = System.Drawing.Color.White;
        }

        protected void rbldocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbldocument.BorderColor = System.Drawing.Color.White;
        }

        protected void rblresinding_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblresinding.BorderColor = System.Drawing.Color.White;
        }

        protected void rblestemployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblestemployee.BorderColor = System.Drawing.Color.White;
        }

        protected void rblGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblGender.BorderColor = System.Drawing.Color.White;
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