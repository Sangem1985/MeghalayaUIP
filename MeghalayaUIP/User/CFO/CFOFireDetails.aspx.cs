using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOFireDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfebal = new CFOBAL();
        string UNITID;
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
                UNITID = Convert.ToString(Session["UNITID"]);

                Page.MaintainScrollPositionOnPostBack = true;
                Failure.Visible = false;
                success.Visible = false;
                if (!IsPostBack)
                {
                    BindDistricts();
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            String Quesstionriids = "1001";
            string UnitId = "1001";
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Validations();
                {
                    HOMEDEPARTMENT ObjCFOFireDepartment = new HOMEDEPARTMENT();

                    { ObjCFOFireDepartment.UNITID = Convert.ToString(ViewState["UnitID"]); }
                    ObjCFOFireDepartment.CreatedBy = hdnUserID.Value;
                    ObjCFOFireDepartment.IPAddress = getclientIP();
                    ObjCFOFireDepartment.Questionnariid = Quesstionriids;
                    ObjCFOFireDepartment.UnitId = UnitId;

                    ObjCFOFireDepartment.BuildingName = txtName.Text;
                    ObjCFOFireDepartment.CategoryBuild = ddlCategory.SelectedValue;
                    ObjCFOFireDepartment.FeeAmount = txtFeeAmount.Text;
                    ObjCFOFireDepartment.District = ddlDistrict.SelectedValue;
                    ObjCFOFireDepartment.Mandal = ddlMandal.SelectedValue;
                    ObjCFOFireDepartment.Village = ddlVillage.SelectedValue;
                    ObjCFOFireDepartment.Locality = txtLandline.Text;
                    ObjCFOFireDepartment.Landmark = txtSitArea.Text;
                    ObjCFOFireDepartment.Pincode = txtPincode.Text;
                    ObjCFOFireDepartment.PlotArea = txtPlotAREA.Text;
                    ObjCFOFireDepartment.Breadth = txtBreadth.Text;
                    ObjCFOFireDepartment.BuildUpArea = txtBuildupArea.Text;
                    ObjCFOFireDepartment.RoadApproach = txtExisting.Text;
                    ObjCFOFireDepartment.East = txtEast.Text;
                    ObjCFOFireDepartment.West = txtWest.Text;
                    ObjCFOFireDepartment.North = txtNorth.Text;
                    ObjCFOFireDepartment.South = txtSouth.Text;
                    ObjCFOFireDepartment.DistanceEAST = txtDistEast.Text;
                    ObjCFOFireDepartment.DistanceWEST = txtDistWest.Text;
                    ObjCFOFireDepartment.DistanceNORTH = txtDistNorth.Text;
                    ObjCFOFireDepartment.DistanceSOUTH = txtDistSouth.Text;
                    ObjCFOFireDepartment.FireStation = txtFire.Text;

                    result = objcfebal.InsertCFOFIREDEPT(ObjCFOFireDepartment);
                    ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "CFO HOME DEPARTMENT Details Submitted Successfully";
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
                if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "" || txtName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name \\n";
                    slno = slno + 1;
                }
                if (ddlCategory.SelectedIndex == -1 || ddlCategory.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Building Category \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFeeAmount.Text) || txtFeeAmount.Text == "" || txtFeeAmount.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter AMOUNT\\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedIndex == -1 || ddlDistrict.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric \\n";
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
                if (string.IsNullOrEmpty(txtLandline.Text) || txtLandline.Text == "" || txtLandline.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSitArea.Text) || txtSitArea.Text == "" || txtSitArea.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter LandMark\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPincode.Text) || txtPincode.Text == "" || txtPincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter PinCode\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPlotAREA.Text) || txtPlotAREA.Text == "" || txtPlotAREA.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Plotarea\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBreadth.Text) || txtBreadth.Text == "" || txtBreadth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Breadth\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuildupArea.Text) || txtBuildupArea.Text == "" || txtBuildupArea.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter BuildUpArea\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExisting.Text) || txtExisting.Text == "" || txtExisting.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing Road\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEast.Text) || txtEast.Text == "" || txtEast.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter East\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNorth.Text) || txtNorth.Text == "" || txtNorth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter North\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSouth.Text) || txtSouth.Text == "" || txtSouth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter South\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWest.Text) || txtWest.Text == "" || txtWest.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter West\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDistEast.Text) || txtDistEast.Text == "" || txtDistEast.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Distric East\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDistNorth.Text) || txtDistNorth.Text == "" || txtDistNorth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Distric North\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDistSouth.Text) || txtDistSouth.Text == "" || txtDistSouth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Distric South\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDistWest.Text) || txtDistWest.Text == "" || txtDistWest.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter DistricWest\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFire.Text) || txtFire.Text == "" || txtFire.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter FireStation\\n";
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

        protected void BindDistricts()
        {

            try
            {

                ddlDistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

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


                }
                else
                {
                    ddlDistrict.DataSource = null;
                    ddlDistrict.DataBind();


                }
                AddSelect(ddlDistrict);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

            }
            catch (Exception ex)
            {
                throw ex;
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

                throw ex;
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
                throw ex;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("CFOPollutionControlBoard.aspx");
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            Response.Redirect("DistricCouncile.aspx");
        }
    }
}