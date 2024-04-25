using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.Common.CFE;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.BAL;
using MeghalayaUIP.BAL.CFEBLL;

namespace MeghalayaUIP.User.CFE
{
    public partial class Questionnaire : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
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
                if (!IsPostBack)
                {
                    BindSectors();
                    BindDistricts();
                    BINDDATA();
                }

            }
        }
        public void BINDDATA()
        {
            try
            {               

                DataSet ds = new DataSet();
                ds = objcfebal.GetCFEQuestionnaireDet(hdnUserID.Value);
                if(ds != null)
                {
                    Name_Unit.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                    Constit_Unit.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    ddlProposal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["COMPANYTYPE"]);
                    rblTSIIC.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    ddlLocation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_DISTRICTID"]);
                    ddlLocation_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_MANDALID"]);
                    ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_VILLAGEID"]);
                    ddlLand.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    Acres.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDAREA"]);
                    Gunthas.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    Square_Meters.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    Built_Area.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_BUILDINGAREA"]);
                    Pollution_Category.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PCBCATEGORY"]);
                    ddlLine_Activity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LOAID"]);
                    Type_Enterprise.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    Location_Unit.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    ddlSector.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SECTORNAME"]);
                    ddlSector_SelectedIndexChanged(null, EventArgs.Empty);
                    txtProposed.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    ddlProjectCost.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PMCOST"]);
                    txtLandsale.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    txtbuilding.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_BUILDINGVALUE"]);
                    txtplant.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    txtAnnualTurn.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    lbllabel.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                  //  Line_Activity.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindSectors()
        {
            try
            {
                ddlSector.Items.Clear();

                List<MasterSector> objSectorModel = new List<MasterSector>();

                objSectorModel = mstrBAL.GetSectors();
                if (objSectorModel != null)
                {
                    ddlSector.DataSource = objSectorModel;
                    ddlSector.DataValueField = "SectorName";
                    ddlSector.DataTextField = "SectorName";
                    ddlSector.DataBind();
                }
                else
                {
                    ddlSector.DataSource = null;
                    ddlSector.DataBind();
                }
                AddSelect(ddlSector);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindLineOfActivity(string Sector)
        {
            try
            {
                List<MasterLineOfActivity> objLOA = mstrBAL.GetLineOfActivity(Sector);

                if (objLOA != null && objLOA.Count > 0)
                {
                    ddlLine_Activity.DataSource = objLOA;
                    ddlLine_Activity.DataValueField = "LOAId";
                    ddlLine_Activity.DataTextField = "LOAName";
                    ddlLine_Activity.DataBind();
                }
                else
                {

                    ddlLine_Activity.DataSource = null;
                    ddlLine_Activity.DataBind();
                }

                AddSelect(ddlLine_Activity);
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

        protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSector.SelectedValue.ToString() != "--Select--")
                {
                    BindLineOfActivity(ddlSector.SelectedItem.Text);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlLine_Activity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLine_Activity.SelectedItem.Text != "--Select--")
                {
                    Pollution_Category.Text = mstrBAL.GetPCBCategory(ddlLine_Activity.SelectedValue);

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

                ddlLocation.Items.Clear();
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
                    ddlLocation.DataSource = objDistrictModel;
                    ddlLocation.DataValueField = "DistrictId";
                    ddlLocation.DataTextField = "DistrictName";
                    ddlLocation.DataBind();

                   
                }
                else
                {
                    ddlLocation.DataSource = null;
                    ddlLocation.DataBind();

                   
                }
                AddSelect(ddlLocation);
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

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                if (ddlLocation.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlLocation.SelectedValue);
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
                throw ex;
            }
        }
    }
}