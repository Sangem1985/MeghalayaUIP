using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEDGSetDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
        string UnitID;
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
                        GetAppliedorNot();
                    }
                }
            }
            catch (Exception ex)
            { lblmsg0.Text = ex.Message; Failure.Visible = true; }
        }
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "14", "6");


                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "6")
                        {
                            BindDistricts();
                        }

                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFEFireDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFE/CFEPowerDetails.aspx?Previous=" + "P");
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
                ddlLocDist.Items.Clear();
                ddlLocTaluka.Items.Clear();
                ddlLocVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();

                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlLocDist.DataSource = objDistrictModel;
                    ddlLocDist.DataValueField = "DistrictId";
                    ddlLocDist.DataTextField = "DistrictName";
                    ddlLocDist.DataBind();
                }
                else
                {
                    ddlLocDist.DataSource = null;
                    ddlLocDist.DataBind();

                }
                AddSelect(ddlLocDist);
                AddSelect(ddlLocTaluka);
                AddSelect(ddlLocVillage);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void ddlLocDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLocTaluka.ClearSelection();
                ddlLocVillage.ClearSelection();
                if (ddlLocDist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlLocTaluka, ddlLocDist.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }

        }
        protected void ddlLocTaluka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLocVillage.ClearSelection();
                if (ddlLocTaluka.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlLocVillage, ddlLocTaluka.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string ErrorMsg = "", result = "";


                ErrorMsg = Validations();

                if (ErrorMsg == "")
                { }
                else
                {
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex) { lblmsg0.Text = ex.Message; Failure.Visible = true; }
        }

       
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtDoorNo.Text) || txtDoorNo.Text == "" || txtDoorNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Door No of the Location  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text == "" || txtLocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandmark.Text) || txtLandmark.Text == "" || txtLandmark.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Landmark  \\n";
                    slno = slno + 1;
                }
                if (ddlLocDist.SelectedIndex == -1 || ddlLocDist.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric \\n";
                    slno = slno + 1;
                }
                if (ddlLocTaluka.SelectedIndex == -1 || ddlLocTaluka.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlLocVillage.SelectedIndex == -1 || ddlLocVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPincode.Text) || txtPincode.Text == "" || txtPincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode No\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSupplierName.Text) || txtSupplierName.Text == "" || txtSupplierName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Supplier Name  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtConnectedLoad.Text) || txtConnectedLoad.Text == "" || txtConnectedLoad.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total Connected Load\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPropLoadfrmDGSet.Text) || txtPropLoadfrmDGSet.Text == "" || txtPropLoadfrmDGSet.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total Proposed Load to be Supplied from D.G. Sets (in KW)\\n";
                    slno = slno + 1;
                }
                if (rblInterlockProvision.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Details of Interlock/Change over arrangement provided or not \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMotorLoad.Text) || txtMotorLoad.Text == "" || txtMotorLoad.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Motor Load\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLghtsFansLoad.Text) || txtLghtsFansLoad.Text == "" || txtLghtsFansLoad.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Lights and Fans Load\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtOtherLoad.Text) || txtOtherLoad.Text == "" || txtOtherLoad.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Other Load\\n";
                    slno = slno + 1;
                }
                if (ddlGenRunningMode.SelectedIndex == -1 || ddlGenRunningMode.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Generator Running Mode  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWrkComplDate.Text) || txtWrkComplDate.Text == "" || txtWrkComplDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expected Date of Completion of work  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWrkStartDate.Text) || txtWrkStartDate.Text == "" || txtWrkStartDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expected Date of starting of Installation work \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCommissiongDate.Text) || txtCommissiongDate.Text == "" || txtCommissiongDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expected Date of Commissioning \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSuprvisorName.Text) || txtSuprvisorName.Text == "" || txtSuprvisorName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Suprvisor Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSuprvisorLICno.Text) || txtSuprvisorLICno.Text == "" || txtSuprvisorLICno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Supervisor License Number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtContractorName.Text) || txtContractorName.Text == "" || txtContractorName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Contractor who will carry out the internal electricfication \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtContractorLICno.Text) || txtContractorLICno.Text == "" || txtContractorLICno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Contractor License Number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDGsetOperatorName.Text) || txtDGsetOperatorName.Text == "" || txtDGsetOperatorName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Person who will be authorized to operate the D.G Sets \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtDGSetCapacity.Text) || txtDGSetCapacity.Text == "" || txtDGSetCapacity.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter  DG Set Capacity\\n";
                    slno = slno + 1;
                }
                if (rblDGSetCapacity.SelectedIndex == -1 || rblDGSetCapacity.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select DG Set Capacity in KW or KVA \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPowerFactor.Text) || txtPowerFactor.Text == "" || txtPowerFactor.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Power Factor\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRatedVolatge.Text) || txtRatedVolatge.Text == "" || txtRatedVolatge.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Rated Volatge\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEngineDtls.Text) || txtEngineDtls.Text == "" || txtEngineDtls.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Engine Make/Serial No. \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtAlternatorDtls.Text) || txtAlternatorDtls.Text == "" || txtAlternatorDtls.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Alternator Make/Serial No \\n";
                    slno = slno + 1;
                }
                if (ddlEquipment.SelectedIndex == -1 || ddlEquipment.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Type of Equipment  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtConductorDtls.Text) || txtConductorDtls.Text == "" || txtConductorDtls.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Size & materials of earthing conductor \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtConductorPaths.Text) || txtConductorPaths.Text == "" || txtConductorPaths.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter No. of independent conductor path \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtElectrodeDtls.Text) || txtElectrodeDtls.Text == "" || txtElectrodeDtls.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Type & size electrode and length/dia \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtImpedance.Text) || txtImpedance.Text == "" || txtImpedance.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Impedance of the systems in ohm \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTotalImpedance.Text) || txtTotalImpedance.Text == "" || txtTotalImpedance.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total Impedance of the system in ohm\\n";
                    slno = slno + 1;
                }

                if (ddllighting.SelectedIndex == -1 || ddllighting.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Type of lighting \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAltrnatrInsTest.Text) || txtAltrnatrInsTest.Text == "" || txtAltrnatrInsTest.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of Insulation Test of Alternator\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEarthTesterNo.Text) || txtEarthTesterNo.Text == "" || txtEarthTesterNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Earth Tester No \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEarthTesterMake.Text) || txtEarthTesterMake.Text == "" || txtEarthTesterMake.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Make of Earth Tester \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEarthTesterRange.Text) || txtEarthTesterRange.Text == "" || txtEarthTesterRange.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Range of Earth Tester\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMeggerNo.Text) || txtMeggerNo.Text == "" || txtMeggerNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Megger No.\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMeggerMake.Text) || txtMeggerMake.Text == "" || txtMeggerMake.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Megger Make \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMeggerRange.Text) || txtMeggerRange.Text == "" || txtMeggerRange.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter megger Range\\n";
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
                Response.Redirect("~/User/CFE/CFEPowerDetails.aspx?Previous="+"P");
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
                btnSave_Click(sender, e);
                Response.Redirect("~/User/CFE/CFEFireDetails.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
}