using MeghalayaUIP.BAL.CFEBLL;
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

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEFireDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
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
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "9", "");


                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "7")
                        {
                            BindDistricts();
                            BindBuildingType();
                            BINDDATA();
                           
                        }

                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFEExplosivesNOC.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFE/CFEDGSetDetails.aspx?Previous=" + "P");
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
        protected void BindDistricts()
        {

            try
            {
                ddldistric.Items.Clear();
                ddlmandal.Items.Clear();
                ddlvillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();

                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddldistric.DataSource = objDistrictModel;
                    ddldistric.DataValueField = "DistrictId";
                    ddldistric.DataTextField = "DistrictName";
                    ddldistric.DataBind();
                }
                else
                {
                    ddldistric.DataSource = null;
                    ddldistric.DataBind();
                }
                AddSelect(ddldistric);
                AddSelect(ddlmandal);
                AddSelect(ddlvillage);

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
        protected void BindBuildingType()
        {
            try
            {
                ddlbuilding.Items.Clear();

                List<MasterBuildingType> objDistrictModel = new List<MasterBuildingType>();
                string strmode = string.Empty;
                strmode = "";

                objDistrictModel = mstrBAL.GetBuildingType();
                if (objDistrictModel != null)
                {
                    ddlbuilding.DataSource = objDistrictModel;
                    ddlbuilding.DataValueField = "BUILDINGTYPE_ID";
                    ddlbuilding.DataTextField = "BUILDINGTYPE_NAME";
                    ddlbuilding.DataBind();
                }
                else
                {
                    ddlbuilding.DataSource = null;
                    ddlbuilding.DataBind();
                }
                AddSelect(ddlbuilding);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BINDDATA()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetRetriveFireDet(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_UNITID"]);
                            ddldistric.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_DISTRICID"]);
                            ddlmandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_MANDALID"]);
                            ddlvillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_VILLAGEID"]);

                            ddldistric.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_DISTRICNAME"]);
                            ddlmandal.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_MANDALNAME"]);
                            ddlvillage.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_VILLAGENAME"]);

                            txtLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_Locality"]);
                            txtlandmark.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_Landmark"]);
                            txtpincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_Pincode"]);
                            txtheight.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_BUILDINGHT"]);
                            txtheightfloor.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_FLOORHT"]);
                            txtplot.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_PLOTAREA"]);
                            txtbuildup.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_BUILDINGAREA"]);
                            txtdriveway.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_DRIVEPROPSED"]);


                            txtBreadth.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_EXISTINGROAD"]);
                            ddlbuilding.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_CATEGORYBUILD"]);
                            //  ddlbuilding.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_CATEGORYBUILD"]);
                            txtAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_FEEAMOUNT"]);
                            txtEast.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_East"]);
                            txtdistance.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_DISTANCEEAST"]);
                            txtWest.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_West"]);
                            txtbuilding.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_DISTANCEWEST"]);
                            txtnorth.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_North"]);
                            txtproposedbuid.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_DISTANCENORTH"]);
                            txtsouth.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_South"]);

                            txtdistancebuild.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_DISTANCESOUTH"]);
                            txtstation.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_FIRESTATION"]);
                        }

                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                            {
                                if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFEA_MASTERAID"]) == 37)
                                {
                                  //  hypbuildingplan.Visible = true;
                                    hypbuildingplan.NavigateUrl = Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]);
                                    hypbuildingplan.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFEA_MASTERAID"]) == 38)
                                {
                                  //  hypfireplan.Visible = true;
                                    hypfireplan.NavigateUrl = Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]);
                                    hypfireplan.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILENAME"]);
                                }
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
        protected void ddldistric_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlmandal.ClearSelection();
                ddlmandal.Items.Clear();
                AddSelect(ddlmandal);
                ddlvillage.ClearSelection();
                ddlvillage.Items.Clear();
                AddSelect(ddlvillage);
                if (ddldistric.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlmandal, ddldistric.SelectedValue);
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
        protected void ddlmandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlvillage.ClearSelection();
                ddlvillage.Items.Clear();
                AddSelect(ddlvillage);
                if (ddlmandal.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlvillage, ddlmandal.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    CFEFire ObjCCFEFireDetails = new CFEFire();

                    ObjCCFEFireDetails.UNITID = Convert.ToString(Session["CFEUNITID"]);
                    ObjCCFEFireDetails.CreatedBy = hdnUserID.Value;
                    ObjCCFEFireDetails.IPAddress = getclientIP();
                    ObjCCFEFireDetails.Questionnariid = Convert.ToString(Session["CFEQID"]);
                    ObjCCFEFireDetails.UnitId = Convert.ToString(Session["CFEUNITID"]);
                    ObjCCFEFireDetails.DistricId = ddldistric.SelectedValue;
                    ObjCCFEFireDetails.MandalId = ddlmandal.SelectedValue;
                    ObjCCFEFireDetails.VillageId = ddlvillage.SelectedValue;
                    ObjCCFEFireDetails.DistricName = ddldistric.SelectedItem.Text;
                    ObjCCFEFireDetails.MandalName = ddlmandal.SelectedItem.Text;
                    ObjCCFEFireDetails.VillageName = ddlvillage.SelectedItem.Text;
                    ObjCCFEFireDetails.Locality = txtLocality.Text.Trim();
                    ObjCCFEFireDetails.Landmark = txtlandmark.Text.Trim();
                    ObjCCFEFireDetails.Pincode = txtpincode.Text;
                    ObjCCFEFireDetails.HeightBuilding = txtheight.Text;
                    ObjCCFEFireDetails.HeightFloor = txtheightfloor.Text;
                    ObjCCFEFireDetails.PlotArea = txtplot.Text;
                    ObjCCFEFireDetails.builoduparea = txtbuildup.Text;
                    ObjCCFEFireDetails.ProposedDrive = txtdriveway.Text;
                    ObjCCFEFireDetails.ExistingRoad = txtBreadth.Text;
                    ObjCCFEFireDetails.CategoryBuilding = ddlbuilding.SelectedValue;
                    ObjCCFEFireDetails.FeeAmount = txtAmount.Text;
                    ObjCCFEFireDetails.East = txtEast.Text;
                    ObjCCFEFireDetails.Distancebuild = txtdistance.Text;
                    ObjCCFEFireDetails.West = txtWest.Text;
                    ObjCCFEFireDetails.Distanceproposed = txtbuilding.Text;
                    ObjCCFEFireDetails.North = txtnorth.Text;
                    ObjCCFEFireDetails.Distancemeter = txtproposedbuid.Text;
                    ObjCCFEFireDetails.South = txtsouth.Text;
                    ObjCCFEFireDetails.buildingdist = txtdistancebuild.Text;
                    ObjCCFEFireDetails.Firestation = txtstation.Text;

                    result = objcfebal.InsertCFEFireDetails(ObjCCFEFireDetails);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Fire Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
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
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtstation.Text) || txtstation.Text == "" || txtstation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Fire Station \\n";
                    slno = slno + 1;
                }
                //if (string.IsNullOrEmpty(txtLocality.Text.Trim()) || txtLocality.Text.Trim() == "" || txtLocality.Text.Trim() == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Locality \\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtlandmark.Text.Trim()) || txtlandmark.Text.Trim() == "" || txtlandmark.Text.Trim() == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter LandMark \\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtpincode.Text) || txtpincode.Text == "" || txtpincode.Text == null || txtpincode.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtpincode.Text, @"^0+(\.0+)?$"))
                //{
                //    errormsg = errormsg + slno + ". Please Enter Pincode \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtheight.Text) || txtheight.Text == "" || txtheight.Text == null || txtheight.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtheight.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Building Height \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtheightfloor.Text) || txtheightfloor.Text == "" || txtheightfloor.Text == null || txtheightfloor.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtheightfloor.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Height floor \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtplot.Text) || txtplot.Text == "" || txtplot.Text == null || txtplot.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtplot.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Plot Area \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtbuildup.Text) || txtbuildup.Text == "" || txtbuildup.Text == null || txtbuildup.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtbuildup.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Building Proposed area \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdriveway.Text) || txtdriveway.Text == "" || txtdriveway.Text == null || txtdriveway.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtdriveway.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed Drive way \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBreadth.Text) || txtBreadth.Text == "" || txtBreadth.Text == null || txtBreadth.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtBreadth.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Existing or proposed Approach Road \\n";
                    slno = slno + 1;
                }
                if (ddlbuilding.SelectedIndex == -1 || ddlbuilding.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Category of Building \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAmount.Text) || txtAmount.Text == "" || txtAmount.Text == null || txtAmount.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtAmount.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Fee amount RS \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEast.Text) || txtEast.Text == "" || txtEast.Text == null || txtEast.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtEast.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter EAST \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdistance.Text) || txtdistance.Text == "" || txtdistance.Text == null || txtdistance.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtdistance.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Distance from proposed Building \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWest.Text) || txtWest.Text == "" || txtWest.Text == null || txtWest.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtWest.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter West \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtbuilding.Text) || txtbuilding.Text == "" || txtbuilding.Text == null || txtbuilding.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtbuilding.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Distance from proposed Building \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtnorth.Text) || txtnorth.Text == "" || txtnorth.Text == null || txtnorth.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtnorth.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter North \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtproposedbuid.Text) || txtproposedbuid.Text == "" || txtproposedbuid.Text == null || txtproposedbuid.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtproposedbuid.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Distance from proposed Building \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtsouth.Text) || txtsouth.Text == "" || txtsouth.Text == null || txtsouth.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtsouth.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter south \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdistancebuild.Text) || txtdistancebuild.Text == "" || txtdistancebuild.Text == null || txtdistancebuild.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtdistancebuild.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Distance from proposed Building \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtstation.Text) || txtstation.Text == "" || txtstation.Text == null || txtstation.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtstation.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Distance from Nearest Station \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(hypbuildingplan.Text) || hypbuildingplan.Text == "" || hypbuildingplan.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Blueprint of Building i.e. Building Plan as per NBC \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypfireplan.Text) || hypfireplan.Text == "" || hypfireplan.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Fire Lay out Plan \\n";
                    slno = slno + 1;
                }


                //if (ddldistric.SelectedIndex == -1 || ddldistric.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select Distric \\n";
                //    slno = slno + 1;
                //}
                //if (ddlmandal.SelectedIndex == -1 || ddlmandal.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select Mandal \\n";
                //    slno = slno + 1;
                //}
                //if (ddlvillage.SelectedIndex == -1 || ddlvillage.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select Village \\n";
                //    slno = slno + 1;
                //}

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
                Response.Redirect("~/User/CFE/CFEDGSetDetails.aspx?Previous=" + "P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnbuildingplan_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupBuildingplan.HasFile)
                {
                    Error = validations(fupBuildingplan);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Blueprint of Building" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupBuildingplan.PostedFile.SaveAs(serverpath + "\\" + fupBuildingplan.PostedFile.FileName);

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "37";
                        objManufacture.FilePath = serverpath + fupBuildingplan.PostedFile.FileName;
                        objManufacture.FileName = fupBuildingplan.PostedFile.FileName;
                        objManufacture.FileType = fupBuildingplan.PostedFile.ContentType;
                        objManufacture.FileDescription = "Blueprint of Building i.e. Building Plan as per NBC";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypbuildingplan.Text = fupBuildingplan.PostedFile.FileName;
                            hypbuildingplan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + objManufacture.FilePath; 
                            hypbuildingplan.Target = "blank";
                            message = "alert('" + "Blueprint of Building i.e. Building Plan as per NBC Uploaded successfully" + "')";
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

        protected void btnfireplan_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupfireplan.HasFile)
                {
                    Error = validations(fupfireplan);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Fire Lay out Plan" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupfireplan.PostedFile.SaveAs(serverpath + "\\" + fupfireplan.PostedFile.FileName);

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "38";
                        objManufacture.FilePath = serverpath + fupfireplan.PostedFile.FileName;
                        objManufacture.FileName = fupfireplan.PostedFile.FileName;
                        objManufacture.FileType = fupfireplan.PostedFile.ContentType;
                        objManufacture.FileDescription = "Fire Lay out Plan ";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypfireplan.Text = fupfireplan.PostedFile.FileName;
                            hypfireplan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + objManufacture.FilePath;
                            hypfireplan.Target = "blank";
                            message = "alert('" + "Fire Lay out Plan Uploaded successfully" + "')";
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

                if (i == 2)
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
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFE/CFEExplosivesNOC.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
    }
}