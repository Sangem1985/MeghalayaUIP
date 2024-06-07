using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOLabourDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
        string UnitID;
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

                    }
                    else
                    {
                        if (Request.QueryString[0].ToString() == "N")
                        {
                            Response.Redirect("~/User/CFO/CFOLegalMeterology.aspx?next=N");
                        }
                        else
                        {
                            Response.Redirect("~/User/CFO/CFOCombinedApplication.aspx?Previous=P");
                        }
                    }
                    BindBoilerType();
                    Binddata();

                }
            }

        }
        public void Binddata()
        {
            //hdnUserID.Value = "1001";
            try
            {
                DataSet ds = new DataSet();
                ds = objcfobal.GetLabourDetails(hdnUserID.Value, UnitID);

                if (ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[1].Rows[0]["CFOLD_UNITID"]);

                        RBLAPPROVED.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_DIRECTINDIRECT"].ToString();
                        ddlApplied.SelectedItem.Text = ds.Tables[1].Rows[0]["CFOLD_APPLIED"].ToString();
                        txtProvide.Text = ds.Tables[1].Rows[0]["CFOLD_PROVIDEDETAILS"].ToString();
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
                        if (rbldocument.Text == "Y")
                            Approved.Visible = true;
                        else Approved.Visible = false;
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
                        ddlTypeBoiler.SelectedItem.Text = ds.Tables[1].Rows[0]["CFOLD_TYPEBOILER"].ToString();
                        txtDESCBoiler.Text = ds.Tables[1].Rows[0]["CFOLD_DESCBOILER"].ToString();
                        txtBoilerRating.Text = ds.Tables[1].Rows[0]["CFOLD_BOILERRATING"].ToString();
                        rblBoilerTrans.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_BOILEROWNERTRANSF"].ToString();
                        if (rblBoilerTrans.Text == "Y")
                            txtBoiler.Visible = true;
                        else txtBoiler.Visible = false;
                        txtRemark.Text = ds.Tables[1].Rows[0]["CFOLD_REMARK"].ToString();
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
                            txtcontractor.Visible = true;
                        else txtcontractor.Visible = false;
                        txtDetails.Text = ds.Tables[1].Rows[0]["CFOLD_DETAILS"].ToString();
                        rblrevoking.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_REVORKING"].ToString();
                        if (rblrevoking.Text == "Y")
                            suspend.Visible = true;
                        else suspend.Visible = false;
                        txtOrderDate.Text = ds.Tables[1].Rows[0]["CFOLD_ORDERDAET"].ToString();
                        rblcontractor.SelectedValue = ds.Tables[1].Rows[0]["CFOLD_ESTCONTRACTOR"].ToString();
                        if (rblcontractor.Text == "Y")
                            fiveyear.Visible = true;
                        else fiveyear.Visible = false;
                        txtprinciple.Text = ds.Tables[1].Rows[0]["CFOLD_PRINCIPLEEMP"].ToString();
                        if (rblcontractor.Text == "Y")
                            nature.Visible = true;
                        else nature.Visible = false;
                        txtEstablishment.Text = ds.Tables[1].Rows[0]["CFOLD_ESTDETAILS"].ToString();
                        txtNature.Text = ds.Tables[1].Rows[0]["CFOLD_NATUREWORK"].ToString();
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
                        hdnUserID.Value = Convert.ToString(ds.Tables[2].Rows[0]["CFOLD_CFOQDID"]);
                        GVCFOLabour.DataSource = ds.Tables[2];
                        GVCFOLabour.DataBind();
                        GVCFOLabour.Visible = true;
                    }
                }

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
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtages.Text) || string.IsNullOrEmpty(txtFulladdress.Text) || string.IsNullOrEmpty(txtPermanent.Text) || string.IsNullOrEmpty(txtHalfDay.Text) || string.IsNullOrEmpty(txtFullDay.Text))
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
                    dr["CFOLD_NAME"] = txtName.Text;
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
                }
            }
            catch (Exception EX)
            {
                throw EX;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void savebtn_Click(object sender, EventArgs e)
        {
           
           

            try
            {
                string ErrorMsg = "", result = "";
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
                    ObjCFOLabourDet.Classification = ddlApplied.SelectedItem.Text;
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
                    ObjCFOLabourDet.NameManufacture = txtname1.Text;
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
                    ObjCFOLabourDet.BoilerType = ddlTypeBoiler.SelectedItem.Text;
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
                    ObjCFOLabourDet.generalManagement = txtAgent.Text;
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



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Validations()
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
            if (RBLAPPROVED.SelectedItem.Text == "Yes")
            {
                Approved.Visible = true;
            }
            else
            {
                Approved.Visible = false;
            }
        }

        protected void rblBoilerTrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblBoilerTrans.SelectedItem.Text == "Yes")
            {
                txtBoiler.Visible = true;
            }
            else
            {
                txtBoiler.Visible = false;
            }
        }

        protected void rblConvicated_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblConvicated.SelectedItem.Text == "Yes")
            {
                txtcontractor.Visible = true;
            }
            else
            {
                txtcontractor.Visible = false;
            }
        }

        protected void rblrevoking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblrevoking.SelectedItem.Text == "Yes")
            {
                suspend.Visible = true;
            }
            else
            {
                suspend.Visible = false;
            }
        }

        protected void rblcontractor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblcontractor.SelectedItem.Text == "Yes")
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
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFO/CFOCombinedApplication.aspx?Previous=P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/CFO/CFOLegalMeterology.aspx?next=N");
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
                throw ex;
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
                throw ex;
            }
        }
    }
}