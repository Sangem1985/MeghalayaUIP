using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFELabourDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
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
                    BindConstitutionType();
                }
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

                ddlappdistric.Items.Clear();
                ddlappMandal.Items.Clear();
                ddlappVilage.Items.Clear();


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



                    ddlappdistric.DataSource = objDistrictModel;
                    ddlappdistric.DataValueField = "DistrictId";
                    ddlappdistric.DataTextField = "DistrictName";
                    ddlappdistric.DataBind();


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

                    ddlappdistric.DataSource = null;
                    ddlappdistric.DataBind();
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

                AddSelect(ddlappdistric);
                AddSelect(ddlappMandal);
                AddSelect(ddlappVilage);

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
                throw ex;
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
                throw ex;
                // Failure.Visible = true;
                // lblmsg0.Text = ex.Message;
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
                throw ex;
            }
        }

        protected void ddlappdistric_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlappMandal.ClearSelection();
                ddlappVilage.ClearSelection();
                if (ddlappdistric.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlappMandal, ddlappdistric.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlappMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlappVilage.ClearSelection();
                if (ddlappMandal.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlappVilage, ddlappMandal.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
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

        protected void btnSave_Click(object sender, EventArgs e)
        {

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