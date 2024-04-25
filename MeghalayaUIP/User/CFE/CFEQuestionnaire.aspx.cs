using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.BAL;
using MeghalayaUIP.BAL.CFEBLL;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEQuestionnaire : System.Web.UI.Page
    {
        int index;
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
                    MVQues.ActiveViewIndex = index;
                    BindSectors();
                    BindDistricts();
                    BindConstitutionType();
                    //BINDDATA();
                }

            }
        }
        protected void MVQues_ActiveViewChanged(object sender, EventArgs e)
        {
            index = MVQues.ActiveViewIndex;


        }
        public void BINDDATA()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = objcfebal.GetCFEQuestionnaireDet(hdnUserID.Value);
                if (ds != null)
                {
                    hdnPreRegUNITID.Value = Convert.ToString(ds.Tables[0].Rows[0]["UNITID"]);
                    txtUnitName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                    txtProposalfor.Text = Convert.ToString(ds.Tables[0].Rows[0]["COMPANYTYPE"]);
                    ddlDistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_DISTRICTID"]);
                    ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_MANDALID"]);
                    ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_VILLAGEID"]);
                    txtLandArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDAREA"]);
                    txtAcres.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDAREA"]);
                    txtGunthas.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDAREA"]);
                    txtSquareMeters.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDAREA"]);

                    txtBuiltArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_BUILDINGAREA"]);
                    txtPolCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PCBCATEGORY"]);
                    ddlLine_Activity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LOAID"]);
                    txtEnterpriseType.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_NOA"]);
                    ddlSector.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SECTORNAME"]);
                    ddlSector_SelectedIndexChanged(null, EventArgs.Empty);
                    //txtPropEmp.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    txtEstProjCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_EPCOST"]);
                    txtLandValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDVALUE"]);
                    txtBuildingValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_BUILDINGVALUE"]);
                    txtPMCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PMCOST"]);
                }


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
                ddlConstType.Items.Clear();

                List<MasterConstType> objConsttype = new List<MasterConstType>();

                objConsttype = mstrBAL.GetConstitutionType();
                if (objConsttype != null)
                {
                    ddlConstType.DataSource = objConsttype;
                    ddlConstType.DataValueField = "ConstId";
                    ddlConstType.DataTextField = "ConstName";
                    ddlConstType.DataBind();
                }
                else
                {
                    ddlConstType.DataSource = null;
                    ddlConstType.DataBind();
                }
                AddSelect(ddlConstType);
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
                    txtPolCategory.Text = mstrBAL.GetPCBCategory(ddlLine_Activity.SelectedValue);

                }
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
                throw ex;
            }
        }

        protected void btnsave1_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext1_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 1;
        }
        protected void btnPreviuos2_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 0;
        }
        protected void btnsave2_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext2_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 2;

        }

        protected void btnSave3_Click(object sender, EventArgs e)
        {

        }

        protected void btnPreviuos3_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 2;

        }

        protected void btnShowEncl_Click(object sender, EventArgs e)
        {

        }

        protected void btnApprvlsReq_Click(object sender, EventArgs e)
        {

        }


    }
}