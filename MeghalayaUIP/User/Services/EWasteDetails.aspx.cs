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
    public partial class EWasteDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string UnitID, Questionnaire, ErrorMsg = "", result = "", UID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindStates();
                    BindDistricts();
                    BindData();

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        private void BindData()
        {
            try
            {
                // Fetching session values
                //string srvcQdId = Convert.ToString(Session["SRVCQID"]);
                //string unitId = Convert.ToString(Session["SRVCUNITID"]);
                string srvcQdId = Convert.ToString(116);
                string unitId = Convert.ToString("1001");

                DataSet ds = new DataSet();
                ds = objSrvcbal.GetEWasteDetails(srvcQdId, unitId);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                txtNameLocalBody.Text = ds.Tables[0].Rows[0]["EWD_NAME"].ToString();
                                txtDoorNo.Text = ds.Tables[0].Rows[0]["EWD_DOORNO"].ToString();
                                txtLocal.Text = ds.Tables[0].Rows[0]["EWD_LOCALITY"].ToString();
                                ddlstate.SelectedValue = ds.Tables[0].Rows[0]["EWD_STATEID"].ToString(); 
                                ddlstate_SelectedIndexChanged(null, EventArgs.Empty);

                                if (ddlstate.SelectedItem.Text == "Meghalaya")
                                {
                                    trMeghalaya.Visible = true;
                                    trotherstate.Visible = false;
                                    ddldist.SelectedValue = ds.Tables[0].Rows[0]["EWD_DISTRICTID"].ToString();
                                    ddldist_SelectedIndexChanged(null, EventArgs.Empty);
                                    ddlmand.SelectedValue = ds.Tables[0].Rows[0]["EWD_MANDALID"].ToString();
                                    ddlmand_SelectedIndexChanged(null, EventArgs.Empty);
                                    ddlvilla.SelectedValue = ds.Tables[0].Rows[0]["EWD_VILLAGEID"].ToString();

                                }
                                else
                                {
                                    trotherstate.Visible = true;
                                    trMeghalaya.Visible = false;
                                    txtApplDist.Text = ds.Tables[0].Rows[0]["EWD_DISTRICT"].ToString();
                                    txtApplTaluka.Text = ds.Tables[0].Rows[0]["EWD_MANDAL"].ToString();
                                    txtApplVillage.Text = ds.Tables[0].Rows[0]["EWD_VILLAGE"].ToString();
                                }
                                txtpincode.Text = ds.Tables[0].Rows[0]["EWD_PINCODE"].ToString();
                                txtLANDMARK.Text = ds.Tables[0].Rows[0]["EWD_LANDMARK"].ToString();
                                txtDesignation.Text = ds.Tables[0].Rows[0]["EWD_DESIGNATION"].ToString();
                                txtEmailId.Text = ds.Tables[0].Rows[0]["EWD_EMAILID"].ToString();
                                txtMobileNo.Text = ds.Tables[0].Rows[0]["EWD_MOBILE"].ToString();
                                txtAltMobile.Text = ds.Tables[0].Rows[0]["EWD_ALTMOBILE"].ToString();
                                txtLandlineno.Text = ds.Tables[0].Rows[0]["EWD_LANDLINE"].ToString();

                                string[] selectedAuthValues = ds.Tables[0].Rows[0]["EWD_AUTHORIZATION"].ToString().Split('/');

                                foreach (ListItem item in CHKAuthorization.Items)
                                {
                                    if (selectedAuthValues.Contains(item.Text.Trim()))
                                    {
                                        item.Selected = true;
                                    }
                                }

                                txtEwasteValue.Text = ds.Tables[0].Rows[0]["EWD_EWASTEGENQUANTITY"].ToString();
                                txtQtyRefbd.Text = ds.Tables[0].Rows[0]["EWD_EWASTEREFURBISHED"].ToString();
                                txtQtyRecyl.Text = ds.Tables[0].Rows[0]["EWD_EWASTERECYCLE"].ToString();
                                txtQtyDisp.Text = ds.Tables[0].Rows[0]["EWD_EWASTEDISPOSAL"].ToString();
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

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;

                strmode = "";
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    //ddlDistrict.DataSource = objDistrictModel;
                    //ddlDistrict.DataValueField = "DistrictId";
                    //ddlDistrict.DataTextField = "DistrictName";
                    //ddlDistrict.DataBind();

                    ddldist.DataSource = objDistrictModel;
                    ddldist.DataValueField = "DistrictId";
                    ddldist.DataTextField = "DistrictName";
                    ddldist.DataBind();

                }
                else
                {
                    //ddlDistrict.DataSource = null;
                    //ddlDistrict.DataBind();

                    ddldist.DataSource = null;
                    ddldist.DataBind();

                }
                //AddSelect(ddlDistrict);
                //AddSelect(ddlMandal);
                //AddSelect(ddlVillage);

                AddSelect(ddldist);
                AddSelect(ddlmand);
                AddSelect(ddlvilla);


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
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
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
        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    ServiceEWasteDetails serviceEWasteDetails = new ServiceEWasteDetails();

                    serviceEWasteDetails.SrvcQdId = "116";//Convert.ToString(Session["SRVCQID"]);
                    serviceEWasteDetails.CreatedBy = "1001";//hdnUserID.Value;
                    serviceEWasteDetails.UidNo = "SRVC/2025/116";
                    serviceEWasteDetails.UnitId = "1001";//Convert.ToString(Session["SRVCUNITID"]);
                    serviceEWasteDetails.CreatedByIp = getclientIP();

                    serviceEWasteDetails.Name = txtNameLocalBody.Text;
                    serviceEWasteDetails.DoorNo = txtDoorNo.Text;
                    serviceEWasteDetails.Locality = txtLocal.Text;
                    serviceEWasteDetails.StateId = ddlstate.SelectedValue;
                    serviceEWasteDetails.DistrictId = ddldist.SelectedValue;
                    serviceEWasteDetails.MandalId = ddlmand.SelectedValue;
                    serviceEWasteDetails.VillageId = ddlvilla.SelectedValue;
                    serviceEWasteDetails.District = txtApplDist.Text;
                    serviceEWasteDetails.Mandal = txtApplTaluka.Text;
                    serviceEWasteDetails.Village = txtApplVillage.Text;
                    serviceEWasteDetails.Pincode = txtpincode.Text;
                    serviceEWasteDetails.Landmark = txtLANDMARK.Text;
                    serviceEWasteDetails.Designation = txtDesignation.Text;
                    serviceEWasteDetails.EmailId = txtEmailId.Text;
                    serviceEWasteDetails.Mobile = txtMobileNo.Text;
                    serviceEWasteDetails.AltMobile = txtAltMobile.Text;
                    serviceEWasteDetails.Landline = txtLandlineno.Text;

                    List<string> selectedAuthItems = new List<string>();
                    foreach (ListItem item in CHKAuthorization.Items)
                    {
                        if (item.Selected)
                        {
                            selectedAuthItems.Add(item.Text);
                        }
                    }
                    serviceEWasteDetails.Authorization = string.Join("/", selectedAuthItems);

                    serviceEWasteDetails.EWasteGenQuantity = txtEwasteValue.Text;
                    serviceEWasteDetails.EWasteRefurbished = txtQtyRefbd.Text;
                    serviceEWasteDetails.EWasteRecycle = txtQtyRecyl.Text;
                    serviceEWasteDetails.EWasteDisposal = txtQtyDisp.Text;

                    // Generating UID


                    // Inserting data into the database
                    result = objSrvcbal.InsertEWasteDetails(serviceEWasteDetails);

                    if (result != "")
                    {
                        //Session["RENQID"] = result;
                        //result = "SRVC" + "/" + DateTime.Now.Year.ToString() + "/" + result;
                        //success.Visible = true;
                        lblmsg.Text = "Ewaste Details Submitted Successfully";
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

        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtNameLocalBody.Text) || txtNameLocalBody.Text == "" || txtNameLocalBody.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of Local Body \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtDoorNo.Text) || txtDoorNo.Text == "" || txtDoorNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Door Number \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtLocal.Text) || txtLocal.Text == "" || txtLocal.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality \\n";
                    slno = slno + 1;
                }

                if (ddlstate.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select State \\n";
                    slno = slno + 1;
                }

                if (ddlstate.SelectedItem.Text == "Meghalaya")
                {
                    // If state is Meghalaya, validate dropdown fields
                    if (ddldist.SelectedIndex == 0)
                    {
                        errormsg += slno + ". Please Select District \\n";
                        slno++;
                    }
                    if (ddlmand.SelectedIndex == 0)
                    {
                        errormsg += slno + ". Please Select Mandal \\n";
                        slno++;
                    }
                    if (ddlvilla.SelectedIndex == 0)
                    {
                        errormsg += slno + ". Please Select Village \\n";
                        slno++;
                    }
                }
                else
                {
                    // For other states, validate textbox fields
                    if (string.IsNullOrEmpty(txtApplDist.Text))
                    {
                        errormsg += slno + ". Please Enter Application District \\n";
                        slno++;
                    }
                    if (string.IsNullOrEmpty(txtApplTaluka.Text))
                    {
                        errormsg += slno + ". Please Enter Application Taluka \\n";
                        slno++;
                    }
                    if (string.IsNullOrEmpty(txtApplVillage.Text))
                    {
                        errormsg += slno + ". Please Enter Application Village \\n";
                        slno++;
                    }
                }

                if (string.IsNullOrEmpty(txtpincode.Text) || txtpincode.Text == "" || txtpincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtLANDMARK.Text) || txtLANDMARK.Text == "" || txtLANDMARK.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Landmark \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtDesignation.Text) || txtDesignation.Text == "" || txtDesignation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Designation \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtEmailId.Text) || txtEmailId.Text == "" || txtEmailId.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Email ID \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile Number \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtAltMobile.Text) || txtAltMobile.Text == "" || txtAltMobile.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Alternative Mobile Number \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtLandlineno.Text) || txtLandlineno.Text == "" || txtLandlineno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Landline Number \\n";
                    slno = slno + 1;
                }

                if (CHKAuthorization.Items.Cast<ListItem>().All(item => !item.Selected))
                {
                    errormsg = errormsg + slno + ". Please Check Authorization \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtEwasteValue.Text) || txtEwasteValue.Text == "" || txtEwasteValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter E-Waste Value \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtQtyRefbd.Text) || txtQtyRefbd.Text == "" || txtQtyRefbd.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Quantity Refurbished \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtQtyRecyl.Text) || txtQtyRecyl.Text == "" || txtQtyRecyl.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Quantity Recycled \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtQtyDisp.Text) || txtQtyDisp.Text == "" || txtQtyDisp.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Quantity Disposed \\n";
                    slno = slno + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
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