using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Renewal
{
    public partial class RENIndustryDetails : System.Web.UI.Page
    {
        decimal PropEmp;
        decimal LandValue;
        decimal Building;
        decimal PMCost;
        decimal AnnualCost;

        decimal sum;
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
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
                Session["UNITID"] = "1001";
                UnitID = Convert.ToString(Session["UNITID"]);

                Page.MaintainScrollPositionOnPostBack = true;
                Failure.Visible = false;
                success.Visible = false;
                if (!IsPostBack)
                {
                    BindStates();
                    BindDistricts();
                    BindSectors();
                    BindConstitutionType();
                    TotalAmount();
                    BindData();

                }
            }
            //lblTotProjCost.Text = Convert.ToString(Convert.ToString(string.IsNullOrEmpty(txtPropEmp.Text)) + Convert.ToDecimal(string.IsNullOrEmpty(txtLandValue.Text)) + Convert.ToDecimal(string.IsNullOrEmpty(txtBuildingValue.Text)) + Convert.ToDecimal(string.IsNullOrEmpty(txtPMCost.Text)) + Convert.ToString(string.IsNullOrEmpty(txtAnnualTurnOver.Text)));

        }
        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlstate.SelectedItem.Text == "Meghalaya")
                {
                    otherDistric.Visible = true;
                    trotherstate.Visible = false;
                }
                else
                {
                    trotherstate.Visible = true;
                    otherDistric.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void BindDistricts()
        {
            try
            {

                ddlDistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                ddldist.Items.Clear();
                ddlmand.Items.Clear();
                ddlvilla.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlDistrict.DataSource = objDistrictModel;
                    ddlDistrict.DataValueField = "DistrictId";
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataBind();

                    ddldist.DataSource = objDistrictModel;
                    ddldist.DataValueField = "DistrictId";
                    ddldist.DataTextField = "DistrictName";
                    ddldist.DataBind();

                }
                else
                {
                    ddlDistrict.DataSource = null;
                    ddlDistrict.DataBind();

                    ddldist.DataSource = null;
                    ddldist.DataBind();

                }
                AddSelect(ddlDistrict);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

                AddSelect(ddldist);
                AddSelect(ddlmand);
                AddSelect(ddlvilla);


            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                if (ddlDistrict.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistrict.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                //Failure.Visible = true;
                //lblmsg0.Text = ex.Message;
                throw ex;
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
                else return;
            }
            catch (Exception ex)
            {
                //Failure.Visible = true;
                //lblmsg0.Text = ex.Message;
                throw ex;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        protected void BindSectors()
        {
            try
            {
                ddlsector.Items.Clear();

                List<MasterSector> objSectorModel = new List<MasterSector>();

                objSectorModel = mstrBAL.GetSectors();
                if (objSectorModel != null)
                {
                    ddlsector.DataSource = objSectorModel;
                    ddlsector.DataValueField = "SectorName";
                    ddlsector.DataTextField = "SectorName";
                    ddlsector.DataBind();
                }
                else
                {
                    ddlsector.DataSource = null;
                    ddlsector.DataBind();
                }
                AddSelect(ddlsector);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void BindLineOfActivity(string Sector)
        {
            try
            {
                List<MasterLineOfActivity> objLOA = mstrBAL.GetLineOfActivity(Sector);

                if (objLOA != null && objLOA.Count > 0)
                {
                    ddlLineActivity.DataSource = objLOA;
                    ddlLineActivity.DataValueField = "LOAId";
                    ddlLineActivity.DataTextField = "LOAName";
                    ddlLineActivity.DataBind();
                }
                else
                {

                    ddlLineActivity.DataSource = null;
                    ddlLineActivity.DataBind();
                }

                AddSelect(ddlLineActivity);
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }

        protected void ddlsector_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlsector.SelectedValue.ToString() != "--Select--")
                {
                    BindLineOfActivity(ddlsector.SelectedItem.Text);

                }
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }

        protected void ddlLineActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLineActivity.SelectedItem.Text != "--Select--")
                {
                    lblPCBCategory.Text = mstrBAL.GetPCBCategory(ddlLineActivity.SelectedValue);

                }
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                }
                else
                {
                    ddlstate.DataSource = null;
                    ddlstate.DataBind();
                }
                AddSelect(ddlstate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindConstitutionType()
        {
            try
            {
                ddlCompanyType.Items.Clear();

                List<MasterConstType> objConsttype = new List<MasterConstType>();

                objConsttype = mstrBAL.GetConstitutionType();
                if (objConsttype != null)
                {
                    ddlCompanyType.DataSource = objConsttype;
                    ddlCompanyType.DataValueField = "ConstId";
                    ddlCompanyType.DataTextField = "ConstName";
                    ddlCompanyType.DataBind();
                }
                else
                {
                    ddlCompanyType.DataSource = null;
                    ddlCompanyType.DataBind();
                }
                AddSelect(ddlCompanyType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string Quesstionriids = "1001";
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    RenApplicationDetails ObjApplicationDetails = new RenApplicationDetails();


                    ObjApplicationDetails.Questionnariid = Quesstionriids;
                    ObjApplicationDetails.CreatedBy = hdnUserID.Value;
                    ObjApplicationDetails.UnitId = Convert.ToString(Session["UnitID"]);
                    ObjApplicationDetails.IPAddress = getclientIP();

                    ObjApplicationDetails.Nameofunit = txtUnitName.Text;
                    ObjApplicationDetails.companyType = ddlCompanyType.SelectedValue;
                    ObjApplicationDetails.RegNumber = txtRegNo.Text;
                    ObjApplicationDetails.RegDate = txtRegDate.Text;
                    ObjApplicationDetails.SectorEntrprise = ddlSectorEnter.SelectedItem.Text;
                    ObjApplicationDetails.Sector = ddlsector.SelectedValue;
                    ObjApplicationDetails.LineofActivity = ddlLineActivity.SelectedValue;
                    ObjApplicationDetails.PCB = lblPCBCategory.Text;
                    ObjApplicationDetails.ProposedEmp = txtPropEmp.Text;
                    ObjApplicationDetails.LandSaleDeed = txtLandValue.Text;
                    ObjApplicationDetails.Building = txtBuildingValue.Text;
                    ObjApplicationDetails.PlantMachinary = txtPMCost.Text;
                    ObjApplicationDetails.AnnualTurnOver = txtAnnualTurnOver.Text;
                    //ObjApplicationDetails.ProjectCost = lblTotProjCost.Text;
                    ObjApplicationDetails.TotalProjectCost = lblTotProjCost.Text;
                    ObjApplicationDetails.EnterpriseCategory = lblEntCategory.Text;
                    ObjApplicationDetails.District = ddlDistrict.SelectedValue;
                    ObjApplicationDetails.Mandal = ddlMandal.SelectedValue;
                    ObjApplicationDetails.Village = ddlVillage.SelectedValue;
                    ObjApplicationDetails.EmailId = txtEmailId.Text;
                    ObjApplicationDetails.MobileNo = txtMobileNo.Text;
                    ObjApplicationDetails.Door = txtDoors.Text;
                    ObjApplicationDetails.Locality = txtLocality.Text;
                    ObjApplicationDetails.Landmark = txtLANDMARK.Text;
                    ObjApplicationDetails.Pincode = txtpincode.Text;
                    ObjApplicationDetails.NamePromoter = txtName.Text;
                    ObjApplicationDetails.Email = txtEmail.Text;
                    ObjApplicationDetails.MobileNumber = txtphoneno.Text;
                    ObjApplicationDetails.DoorNo = txtDoorNo.Text;
                    ObjApplicationDetails.Local = txtLocal.Text;
                    ObjApplicationDetails.State = ddlstate.SelectedValue;
                    ObjApplicationDetails.Districts = ddldist.SelectedValue;
                    ObjApplicationDetails.Mandals = ddlmand.SelectedValue;
                    ObjApplicationDetails.Villages = ddlvilla.SelectedValue;
                    ObjApplicationDetails.AppDistrict = txtApplDist.Text;
                    ObjApplicationDetails.AppMandal = txtApplTaluka.Text;
                    ObjApplicationDetails.AppVillge = txtApplVillage.Text;
                    ObjApplicationDetails.Pin = txtPin.Text;
                    ObjApplicationDetails.Age = txtAge.Text;
                    ObjApplicationDetails.Designation = txtDesignation.Text;

                    result = objRenbal.InsertRenApplicationDetails(ObjApplicationDetails);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Application Details Submitted Successfully";
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


                if (string.IsNullOrEmpty(txtUnitName.Text) || txtUnitName.Text == "" || txtUnitName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Unit Name \\n";
                    slno = slno + 1;
                }
                if (ddlCompanyType.SelectedValue == "0" || ddlCompanyType.SelectedValue == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Company Type\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRegNo.Text) || txtRegNo.Text == "" || txtRegNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration Number \\n";
                    slno = slno + 1;

                }
                if (string.IsNullOrEmpty(txtUnitName.Text) || txtUnitName.Text == "" || txtUnitName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration Date \\n";
                    slno = slno + 1;
                }
                if (ddlSectorEnter.SelectedValue == "0" || ddlSectorEnter.SelectedValue == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select sector Enterprise\\n";
                    slno = slno + 1;
                }
                if (ddlsector.SelectedValue == "0" || ddlsector.SelectedValue == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select sector \\n";
                    slno = slno + 1;
                }
                if (ddlLineActivity.SelectedValue == "0" || ddlLineActivity.SelectedValue == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Line Of Activity \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPropEmp.Text) || txtPropEmp.Text == "" || txtPropEmp.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed Employment \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandValue.Text) || txtLandValue.Text == "" || txtLandValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Land Saledeed(INR) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuildingValue.Text) || txtBuildingValue.Text == "" || txtBuildingValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Building(INR) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPMCost.Text) || txtPMCost.Text == "" || txtPMCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Plant and Machinery(INR) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAnnualTurnOver.Text) || txtAnnualTurnOver.Text == "" || txtAnnualTurnOver.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expected Annual TurnOver \\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedValue == "0" || ddlDistrict.SelectedValue == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric....! \\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedValue == "0" || ddlMandal.SelectedValue == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Mandal.....! \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedValue == "0" || ddlVillage.SelectedValue == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Village....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmailId.Text) || txtEmailId.Text == "" || txtEmailId.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EmailId \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter MobileNo....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDoors.Text) || txtDoors.Text == "" || txtDoors.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Doors....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text == "" || txtLocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLANDMARK.Text) || txtLANDMARK.Text == "" || txtLANDMARK.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter landmark....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtpincode.Text) || txtpincode.Text == "" || txtpincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "" || txtName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter NameofPromoter....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "" || txtEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Email....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtphoneno.Text) || txtphoneno.Text == "" || txtphoneno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile Number....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDoorNo.Text) || txtDoorNo.Text == "" || txtDoorNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Door....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocal.Text) || txtLocal.Text == "" || txtLocal.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality....! \\n";
                    slno = slno + 1;
                }
                if (ddlstate.SelectedValue == "0" || ddlstate.SelectedValue == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select State....! \\n";
                    slno = slno + 1;
                }
                if (ddlstate.SelectedItem.Text == "Meghalaya")
                {
                    if (ddldist.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Select distric....! \\n";
                        slno = slno + 1;
                    }
                    if (ddlmand.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Select Mandal....! \\n";
                        slno = slno + 1;
                    }
                    if (ddlvilla.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Select village....! \\n";
                        slno = slno + 1;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtApplDist.Text) || txtApplDist.Text == "" || txtApplDist.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Distric....! \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtApplTaluka.Text) || txtApplTaluka.Text == "" || txtApplTaluka.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Mandal....! \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtApplVillage.Text) || txtApplVillage.Text == "" || txtApplVillage.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Village....! \\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtPin.Text) || txtPin.Text == "" || txtPin.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAge.Text) || txtAge.Text == "" || txtAge.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Age....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDesignation.Text) || txtDesignation.Text == "" || txtDesignation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Designation....! \\n";
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
        public void TotalAmount()
        {

            if (txtPropEmp.Text == "0" || string.IsNullOrEmpty(txtPropEmp.Text))
            {

                PropEmp = 0;

            }
            else
            {
                PropEmp = Convert.ToDecimal(txtPropEmp.Text);

            }
            if (txtLandValue.Text == "0" || string.IsNullOrEmpty(txtLandValue.Text))
            {

                LandValue = 0;

            }
            else
            {
                LandValue = Convert.ToDecimal(txtLandValue.Text);

            }
            if (txtBuildingValue.Text == "0" || string.IsNullOrEmpty(txtBuildingValue.Text))
            {

                Building = 0;

            }
            else
            {
                Building = Convert.ToDecimal(txtBuildingValue.Text);

            }
            if (txtPMCost.Text == "0" || string.IsNullOrEmpty(txtPMCost.Text))
            {

                PMCost = 0;

            }
            else
            {
                PMCost = Convert.ToDecimal(txtPMCost.Text);

            }
            if (txtAnnualTurnOver.Text == "0" || string.IsNullOrEmpty(txtAnnualTurnOver.Text))
            {

                AnnualCost = 0;

            }
            else
            {
                AnnualCost = Convert.ToDecimal(txtAnnualTurnOver.Text);

            }
            sum = PropEmp + LandValue + Building + PMCost + AnnualCost;
            lblTotProjCost.Text = sum.ToString();

        }

        protected void txtPropEmp_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        protected void txtLandValue_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        protected void txtBuildingValue_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        protected void txtPMCost_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        protected void txtAnnualTurnOver_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objRenbal.GetRenApplicantDetails(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENID_UNITID"]);
                        txtUnitName.Text = ds.Tables[0].Rows[0]["RENID_NAMEOFUNIT"].ToString();
                        ddlCompanyType.SelectedItem.Text = ds.Tables[0].Rows[0]["RENID_COMPANYTYPE"].ToString();
                        txtRegNo.Text = ds.Tables[0].Rows[0]["RENID_REGNUMBER"].ToString();
                        txtRegDate.Text = ds.Tables[0].Rows[0]["RENID_REGDATE"].ToString();
                        ddlSectorEnter.SelectedItem.Text = ds.Tables[0].Rows[0]["RENID_SECTORENTERPRISE"].ToString();
                        ddlsector.SelectedItem.Text = ds.Tables[0].Rows[0]["RENID_SECTOR"].ToString();
                        ddlsector_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlLineActivity.SelectedItem.Text = ds.Tables[0].Rows[0]["RENID_LINEOFACTIVITY"].ToString();
                        ddlLineActivity_SelectedIndexChanged(null, EventArgs.Empty);
                        lblPCBCategory.Text = ds.Tables[0].Rows[0]["RENID_POLLUTIONCATG"].ToString();
                        txtPropEmp.Text = ds.Tables[0].Rows[0]["RENID_PROPOSEDEMP"].ToString();
                        txtLandValue.Text = ds.Tables[0].Rows[0]["RENID_LANDSALEDEED"].ToString();
                        txtBuildingValue.Text = ds.Tables[0].Rows[0]["RENID_BUILDING"].ToString();
                        txtPMCost.Text = ds.Tables[0].Rows[0]["RENID_PLANTMACHINERY"].ToString();
                        txtAnnualTurnOver.Text = ds.Tables[0].Rows[0]["RENID_ANNUALTURNOVER"].ToString();
                        lblTotProjCost.Text = ds.Tables[0].Rows[0]["RENID_PROJECTCOST"].ToString();
                        lblEntCategory.Text = ds.Tables[0].Rows[0]["RENID_ENTERPRISECATEG"].ToString();
                        ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["RENID_DISTRIC"].ToString();
                        ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["RENID_MANDAL"].ToString();
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["RENID_VILLAGE"].ToString();
                        txtEmailId.Text = ds.Tables[0].Rows[0]["RENID_EMAILID"].ToString();
                        txtMobileNo.Text = ds.Tables[0].Rows[0]["RENID_MOBILENO"].ToString();
                        txtDoors.Text = ds.Tables[0].Rows[0]["RENID_DOORNO"].ToString();
                        txtLocality.Text = ds.Tables[0].Rows[0]["RENID_LOCALITY"].ToString();
                        txtLANDMARK.Text = ds.Tables[0].Rows[0]["RENID_LANDMARK"].ToString();
                        txtpincode.Text = ds.Tables[0].Rows[0]["RENID_PINCODE"].ToString();
                        txtName.Text = ds.Tables[0].Rows[0]["RENID_NAMEOFPROMOTER"].ToString();
                        txtEmail.Text = ds.Tables[0].Rows[0]["RENID_EMAIL"].ToString();
                        txtphoneno.Text = ds.Tables[0].Rows[0]["RENID_MOBILENUMBER"].ToString();
                        txtDoorNo.Text = ds.Tables[0].Rows[0]["RENID_DOOR"].ToString();
                        txtLocal.Text = ds.Tables[0].Rows[0]["RENID_LOCALITYADD"].ToString();
                        ddlstate.SelectedValue = ds.Tables[0].Rows[0]["RENID_STATE"].ToString();
                        ddlstate_SelectedIndexChanged(null, EventArgs.Empty);
                        ddldist.SelectedValue = ds.Tables[0].Rows[0]["RENID_DISTRICS"].ToString();
                        ddldist_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlmand.SelectedValue = ds.Tables[0].Rows[0]["RENID_MANDALS"].ToString();
                        ddlmand_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlvilla.SelectedValue = ds.Tables[0].Rows[0]["RENID_VILLAGES"].ToString();
                        txtApplDist.Text = ds.Tables[0].Rows[0]["RENID_DIST"].ToString();
                        txtApplTaluka.Text = ds.Tables[0].Rows[0]["RENID_MANDA"].ToString();
                        txtApplVillage.Text = ds.Tables[0].Rows[0]["RENID_VILLA"].ToString();
                        txtPin.Text = ds.Tables[0].Rows[0]["RENID_PIN"].ToString();
                        txtAge.Text = ds.Tables[0].Rows[0]["RENID_AGE"].ToString();
                        txtDesignation.Text = ds.Tables[0].Rows[0]["RENID_DESIGNATION"].ToString();


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void GetApprovals()
        {
            try
            {
                RenApplicationDetails ObjApplicationDetails = new RenApplicationDetails();
                DataTable dtApprReq = new DataTable();
                DataTable dtPCB = new DataTable();

                ObjApplicationDetails.EnterpriseCategory = lblEntCategory.Text;

                if (lblPCBCategory.Text.Trim() != "White")
                {
                    ObjApplicationDetails.PCB = lblPCBCategory.Text;
                    ObjApplicationDetails.ApprovalID = "1";
                    //dtPCB = ObjApplicationDetails.GetApprovalsReqWithFee(ObjApplicationDetails);
                    dtApprReq.Merge(dtPCB);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
    }
}