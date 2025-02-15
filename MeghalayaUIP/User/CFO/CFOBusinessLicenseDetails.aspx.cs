using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOBusinessLicenseDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
        string UnitID, ErrorMsg = "";
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
                    //DataSet dsnew = new DataSet();
                    //dsnew = objcfobal.GetApprovalDataByDeptId(Session["CFOQID"].ToString(), Session["CFOUNITID"].ToString(), "12");
                    //if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                    //{

                    //}
                    //else
                    //{
                    //    if (Request.QueryString[0].ToString() == "N")
                    //    {
                    //        Response.Redirect("~/User/CFO/CFOExcise.aspx?next=N");
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("~/User/CFO/CFOFireDetails.aspx?Previous=P");
                    //    }
                    //}
                    BindDistricEST();
                    BindMARKET();
                    BindANNUALGROSS();
                    BindMAINCATEGORY();
                    Binddata();
                }
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfobal.GetCFOBusinessLicenseDetails(hdnUserID.Value, UnitID);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            ViewState["UnitID"] = Convert.ToString(ds.Tables[1].Rows[0]["CFOB_UNITID"]);
                            txtaddress.Text = ds.Tables[1].Rows[0]["CFOB_ESTBDATE"].ToString();
                            rblBusiness.SelectedValue = ds.Tables[1].Rows[0]["CFOB_STALLLOCATION"].ToString();
                            rblBusiness_SelectedIndexChanged(null, EventArgs.Empty);
                            if (rblBusiness.SelectedValue == "Y")
                            {
                                stall.Visible = true;
                                txtHolding.Text = ds.Tables[1].Rows[0]["CFOB_HOLDINGNO"].ToString();
                                ddlDistric.SelectedValue = ds.Tables[1].Rows[0]["CFOB_MARKETNAME"].ToString();
                                Districmaster.Visible = false;
                            }
                            else
                            {
                                Districmaster.Visible = true;
                                ddlESTDistric.SelectedValue = ds.Tables[1].Rows[0]["CFOB_ESTBDISTRICT"].ToString();
                                txtstall.Text = ds.Tables[1].Rows[0]["CFOB_STALLNO"].ToString();
                                stall.Visible = false;
                            }


                            rblmunicipality.SelectedValue = ds.Tables[1].Rows[0]["CFOB_ANYBUSINESS"].ToString();
                            rblmunicipality_SelectedIndexChanged(null, EventArgs.Empty);
                            if (rblmunicipality.Text == "Y")
                            {
                                Municipality.Visible = true;
                                txtDetails.Text = ds.Tables[1].Rows[0]["CFOB_BUSINESSDETAILS"].ToString();
                            }
                            else { Municipality.Visible = false; }

                            ddlAnnual.SelectedValue = ds.Tables[1].Rows[0]["CFOB_ANNUALGROSSTURNOVER"].ToString();
                            txtAmount.Text = ds.Tables[1].Rows[0]["CFOB_TOTALFEE"].ToString();
                        }
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            hdnUserID.Value = Convert.ToString(ds.Tables[2].Rows[0]["CFOBN_CFOQDID"]);
                            ViewState["PollutionControlBOARD"] = ds.Tables[2];
                            GVPollution.DataSource = ds.Tables[2];
                            GVPollution.DataBind();
                            GVPollution.Visible = true;
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

        protected void rblBusiness_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblBusiness.SelectedValue == "Y")
                {
                    stall.Visible = true;
                    Districmaster.Visible = false;
                }
                else if (rblBusiness.SelectedValue == "N")
                {
                    Districmaster.Visible = true;
                    stall.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblBusiness.BorderColor = System.Drawing.Color.White;
        }

        protected void rblmunicipality_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblmunicipality.SelectedValue == "Y")
                {
                    Municipality.Visible = true;
                }
                else
                {
                    Municipality.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblmunicipality.BorderColor = System.Drawing.Color.White;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFees.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFOBN_UNITID", typeof(string));
                    dt.Columns.Add("CFOBN_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFOBN_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFOBN_MAINCATEGORY", typeof(string));
                    dt.Columns.Add("CFOBN_SUBCATEGORY", typeof(string));
                    dt.Columns.Add("CFOBN_FEE", typeof(string));


                    if (ViewState["PollutionControlBOARD"] != null)
                    {
                        dt = (DataTable)ViewState["PollutionControlBOARD"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFOBN_UNITID"] = Convert.ToString(Session["CFOUNITID"]);
                    dr["CFOBN_CREATEDBY"] = hdnUserID.Value;
                    dr["CFOBN_CREATEDBYIP"] = getclientIP();
                    dr["CFOBN_MAINCATEGORY"] = ddlNature.SelectedItem.Text;
                    dr["CFOBN_SUBCATEGORY"] = ddlBusiness.SelectedItem.Text;
                    dr["CFOBN_FEE"] = txtFees.Text;


                    dt.Rows.Add(dr);
                    GVPollution.Visible = true;
                    GVPollution.DataSource = dt;
                    GVPollution.DataBind();
                    ViewState["PollutionControlBOARD"] = dt;


                    ddlNature.ClearSelection();
                    ddlBusiness.ClearSelection();
                    ddlAnnual.ClearSelection();
                    txtFees.Text = "";
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
                if (string.IsNullOrEmpty(txtaddress.Text) || txtaddress.Text == "" || txtaddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Date\\n";
                    slno = slno + 1;
                }
                if (rblBusiness.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Select Location of Stall \\n";
                    slno = slno + 1;
                }
                if (rblBusiness.SelectedValue == "Y")
                {

                    if (string.IsNullOrEmpty(txtHolding.Text) || txtHolding.Text == "" || txtHolding.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Holding Number\\n";
                        slno = slno + 1;
                    }

                    if (ddlDistric.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Select Market Name \\n";
                        slno = slno + 1;
                    }

                }
                else
                {

                    if (ddlESTDistric.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Select District of Establishment\\n";
                        slno = slno + 1;
                    }

                    if (string.IsNullOrEmpty(txtstall.Text) || txtstall.Text == "" || txtstall.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Stall Number\\n";
                        slno = slno + 1;
                    }

                }
                if (rblmunicipality.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Yes or No any business in Shillong Municipality during the previous 5 (five) years?\\n";
                    slno = slno + 1;
                }
                if (rblmunicipality.SelectedValue == "Y")
                {
                    Municipality.Visible = true;
                    if (string.IsNullOrEmpty(txtDetails.Text) || txtDetails.Text == "" || txtDetails.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Details\\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtAmount.Text) || txtAmount.Text == "" || txtAmount.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total Amount\\n";
                    slno = slno + 1;
                }
                if (GVPollution.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Nature of Business \\n";
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

        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                string result = "";
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    PollutionControlBoard ObjCFOPollutionControl = new PollutionControlBoard();

                    int count = 0;
                    for (int i = 0; i < GVPollution.Rows.Count; i++)
                    {
                        ObjCFOPollutionControl.Questionnariid = Convert.ToString(Session["CFOQID"]);
                        ObjCFOPollutionControl.CreatedBy = hdnUserID.Value;
                        ObjCFOPollutionControl.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        ObjCFOPollutionControl.IPAddress = getclientIP();
                        ObjCFOPollutionControl.MainCategory = GVPollution.Rows[i].Cells[1].Text;
                        ObjCFOPollutionControl.SubCategory = GVPollution.Rows[i].Cells[2].Text;
                        ObjCFOPollutionControl.Fees = GVPollution.Rows[i].Cells[3].Text;
                        string A = objcfobal.InsertCFOPollutionControlBoard(ObjCFOPollutionControl);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVPollution.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Business License Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }



                    ObjCFOPollutionControl.UNITID = Convert.ToString(Session["CFOUNITID"]);
                    ObjCFOPollutionControl.CreatedBy = hdnUserID.Value;
                    ObjCFOPollutionControl.IPAddress = getclientIP();
                    ObjCFOPollutionControl.Questionnariid = Convert.ToString(Session["CFOQID"]);
                    ObjCFOPollutionControl.UnitId = Convert.ToString(Session["CFOUNITID"]);

                    ObjCFOPollutionControl.DateEst = txtaddress.Text;
                    ObjCFOPollutionControl.LocationStall = rblBusiness.SelectedValue;
                    ObjCFOPollutionControl.HoldingNumber = txtHolding.Text;
                    ObjCFOPollutionControl.MarketName = ddlDistric.SelectedValue;
                    ObjCFOPollutionControl.DistrictEST = ddlESTDistric.SelectedValue;
                    ObjCFOPollutionControl.Stallnumber = txtstall.Text;
                    ObjCFOPollutionControl.Municipality = rblmunicipality.SelectedValue;
                    ObjCFOPollutionControl.Details = txtDetails.Text;
                    ObjCFOPollutionControl.AnnualGross = ddlAnnual.SelectedValue;
                    ObjCFOPollutionControl.TotalAmount = txtAmount.Text;


                    result = objcfobal.InsertCFOPollutioncontrol(ObjCFOPollutionControl);
                    // ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Business License Details Submitted Successfully";
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

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/CFO/CFOFireDetails.aspx?Previous=P");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFO/CFOExcise.aspx?next=N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void BindDistricEST()
        {
            try
            {
                ddlESTDistric.Items.Clear();


                List<MasterDistricEST> objDistricESTModel = new List<MasterDistricEST>();

                objDistricESTModel = mstrBAL.GetDistricEST();
                if (objDistricESTModel != null)
                {
                    ddlESTDistric.DataSource = objDistricESTModel;
                    ddlESTDistric.DataValueField = "DISTRICEST_ID";
                    ddlESTDistric.DataTextField = "DISTRICEST_NAME";
                    ddlESTDistric.DataBind();


                }
                else
                {
                    ddlESTDistric.DataSource = null;
                    ddlESTDistric.DataBind();


                }
                AddSelect(ddlESTDistric);

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
        protected void BindMARKET()
        {
            try
            {
                ddlDistric.Items.Clear();


                List<MasterMARKET> objMARKETModel = new List<MasterMARKET>();

                objMARKETModel = mstrBAL.GetMARKET();
                if (objMARKETModel != null)
                {
                    ddlDistric.DataSource = objMARKETModel;
                    ddlDistric.DataValueField = "MARKET_ID";
                    ddlDistric.DataTextField = "MARKET_NAME";
                    ddlDistric.DataBind();


                }
                else
                {
                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();


                }
                AddSelect(ddlDistric);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindANNUALGROSS()
        {
            try
            {
                ddlAnnual.Items.Clear();


                List<MasterANNUALGROSS> objMARKETModel = new List<MasterANNUALGROSS>();

                objMARKETModel = mstrBAL.Getannualgross();
                if (objMARKETModel != null)
                {
                    ddlAnnual.DataSource = objMARKETModel;
                    ddlAnnual.DataValueField = "ANNUALGROSS_ID";
                    ddlAnnual.DataTextField = "ANNUALGROSS_NAME";
                    ddlAnnual.DataBind();


                }
                else
                {
                    ddlAnnual.DataSource = null;
                    ddlAnnual.DataBind();


                }
                AddSelect(ddlAnnual);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindMAINCATEGORY()
        {
            try
            {
                ddlNature.Items.Clear();


                List<MasterMAINCATEGORY> objMARKETModel = new List<MasterMAINCATEGORY>();

                objMARKETModel = mstrBAL.GetMAINCATEGORY();
                if (objMARKETModel != null)
                {
                    ddlNature.DataSource = objMARKETModel;
                    ddlNature.DataValueField = "MAINCATEGORY_ID";
                    ddlNature.DataTextField = "MAINCATEGORY_NAME";
                    ddlNature.DataBind();


                }
                else
                {
                    ddlNature.DataSource = null;
                    ddlNature.DataBind();


                }
                AddSelect(ddlNature);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GVPollution_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVPollution.Rows.Count > 0)
                {
                    ((DataTable)ViewState["PollutionControlBOARD"]).Rows.RemoveAt(e.RowIndex);
                    this.GVPollution.DataSource = ((DataTable)ViewState["PollutionControlBOARD"]).DefaultView;
                    this.GVPollution.DataBind();
                    GVPollution.Visible = true;
                    GVPollution.Focus();

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
    }
}