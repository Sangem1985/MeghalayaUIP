using MeghalayaUIP.BAL.CFEBLL;
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

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEProffessionalTax : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
        string UnitID, ErrorMsg = "";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "6", "13");


                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "13")
                        {
                            BindDistric();
                            BindRegType();
                            Binddata();
                        }
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFEPowerCEIGDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFE/CFEFuelNOC.aspx?Previous=" + "P");
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblAdditional_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblAdditional.SelectedValue == "Y")
                {

                    Business.Visible = true;
                    Div1.Visible = true;
                }
                else
                {
                    Business.Visible = false;
                    Div1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblother_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblother.SelectedItem.Text == "Yes")
                {
                    RegistrationType.Visible = true;
                    RegNo.Visible = true;
                }
                else
                {
                    RegistrationType.Visible = false;
                    RegNo.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBusiness.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtEMP.Text) || string.IsNullOrEmpty(ddldist.SelectedItem.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFEPB_CFEUNITID", typeof(string));
                    dt.Columns.Add("CFEPB_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFEPB_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFEPB_PLACEOFBUSINESS", typeof(string));
                    dt.Columns.Add("CFEPB_ADDRESS", typeof(string));
                    dt.Columns.Add("CFEPB_DISTRIC", typeof(string));
                    dt.Columns.Add("CFEPB_TOTALWORKINGEMP", typeof(string));


                    if (ViewState["PROFESSIONALTAX"] != null)
                    {
                        dt = (DataTable)ViewState["PROFESSIONALTAX"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFEPB_CFEUNITID"] = Convert.ToString(Session["CFEUNITID"]);
                    dr["CFEPB_CREATEDBY"] = hdnUserID.Value;
                    dr["CFEPB_CREATEDBYIP"] = getclientIP();
                    dr["CFEPB_PLACEOFBUSINESS"] = txtBusiness.Text;
                    dr["CFEPB_ADDRESS"] = txtAddress.Text;
                    dr["CFEPB_DISTRIC"] = ddldist.SelectedItem.Text;
                    dr["CFEPB_TOTALWORKINGEMP"] = txtEMP.Text;


                    dt.Rows.Add(dr);
                    GVState.Visible = true;
                    GVState.DataSource = dt;
                    GVState.DataBind();
                    ViewState["PROFESSIONALTAX"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
        protected void BindRegType()
        {
            try
            {
                ddlRegType.Items.Clear();

                List<MasterREGTYPE> objRegTypeModel = new List<MasterREGTYPE>();

                objRegTypeModel = mstrBAL.GetRegType();
                if (objRegTypeModel != null)
                {
                    ddlRegType.DataSource = objRegTypeModel;
                    ddlRegType.DataValueField = "REGISTRATIONTYPE_ID";
                    ddlRegType.DataTextField = "REGISTRATIONTYPE_NAME";
                    ddlRegType.DataBind();
                }
                else
                {
                    ddlRegType.DataSource = null;
                    ddlRegType.DataBind();
                }
                AddSelect(ddlRegType);
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
        protected void BindDistric()
        {
            try
            {
                ddlDistric.Items.Clear();
                ddldist.Items.Clear();

                List<MasterDistric> objDistricModel = new List<MasterDistric>();

                objDistricModel = mstrBAL.GetDistric();
                if (objDistricModel != null)
                {
                    ddlDistric.DataSource = objDistricModel;
                    ddlDistric.DataValueField = "DISTRIC_ID";
                    ddlDistric.DataTextField = "DISTRIC_NAME";
                    ddlDistric.DataBind();

                    ddldist.DataSource = objDistricModel;
                    ddldist.DataValueField = "DISTRIC_ID";
                    ddldist.DataTextField = "DISTRIC_NAME";
                    ddldist.DataBind();
                }
                else
                {
                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();

                    ddldist.DataSource = null;
                    ddldist.DataBind();
                }
                AddSelect(ddlDistric);
                AddSelect(ddldist);
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                string  result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    CFETAXDetails ObjCFETax = new CFETAXDetails();

                    int count = 0;

                    for (int i = 0; i < GVState.Rows.Count; i++)
                    {
                        ObjCFETax.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        ObjCFETax.CreatedBy = hdnUserID.Value;
                        ObjCFETax.UnitId = Convert.ToString(Session["CFEUNITID"]);
                        ObjCFETax.IPAddress = getclientIP();
                        ObjCFETax.PLACEBUSINESS = GVState.Rows[i].Cells[1].Text;
                        ObjCFETax.ADDRESS = GVState.Rows[i].Cells[2].Text;
                        ObjCFETax.DISTRIC = GVState.Rows[i].Cells[3].Text;
                        ObjCFETax.TOTALWORKINGEMPTE = GVState.Rows[i].Cells[4].Text;


                        string A = objcfebal.InsertCFETaxDetails(ObjCFETax);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVState.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "ProffessionalTax Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    ObjCFETax.Questionnareid = Convert.ToString(Session["CFEQID"]);
                    ObjCFETax.CreatedBy = hdnUserID.Value;
                    ObjCFETax.UnitId = Convert.ToString(Session["CFEUNITID"]);
                    ObjCFETax.IPAddress = getclientIP();

                    ObjCFETax.APPLYAS = rblApply.SelectedValue;
                    ObjCFETax.NAMEEST = txtEstDet.Text.Trim();
                    ObjCFETax.ADDRESSEST = txtadd.Text;
                    ObjCFETax.DISTRICEST = ddlDistric.SelectedValue;
                    ObjCFETax.PINCODEEST = txtPincode.Text;
                    ObjCFETax.TOTALNOEMPEST = txtEmployeeESt.Text;
                    ObjCFETax.DATE = txtDate.Text;
                    ObjCFETax.CONSTITUTIONEST = rblConstitution.SelectedValue;
                    ObjCFETax.GOODSSUPPLIESEST = txtGoodssupplie.Text;
                    ObjCFETax.ADDITIONPLACEBUSINESS = rblAdditional.SelectedValue;
                    ObjCFETax.DESIGNATION = rblDesignation.SelectedValue;
                    ObjCFETax.REGUNDERACT = rblother.SelectedValue;
                    ObjCFETax.REGTYPE = ddlRegType.SelectedValue;
                    ObjCFETax.REGNO = TXTRegNo.Text;

                    result = objcfebal.InsertCFEPROFFESSIONALTAXDetails(ObjCFETax);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "ProffessionalTax Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (rblApply.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Apply as \\n";
                    slno = slno + 1;
                }
                //if (string.IsNullOrEmpty(txtEstDet.Text.Trim()) || txtEstDet.Text.Trim() == "" || txtEstDet.Text.Trim() == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Name Establishment\\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtadd.Text) || txtadd.Text == "" || txtadd.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Address\\n";
                //    slno = slno + 1;
                //}
                //if (ddlDistric.SelectedIndex == 0)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Distric Establishment\\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtPincode.Text) || txtPincode.Text == "" || txtPincode.Text == null || txtPincode.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtPincode.Text, @"^0+(\.0+)?$"))
                //{
                //    errormsg = errormsg + slno + ". Please Enter Pincode\\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtEmployeeESt.Text) || txtEmployeeESt.Text == "" || txtEmployeeESt.Text == null || txtEmployeeESt.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtEmployeeESt.Text, @"^0+(\.0+)?$"))
                //{
                //    errormsg = errormsg + slno + ". Please Enter Employee Establishment\\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtDate.Text) || txtDate.Text == "" || txtDate.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Date\\n";
                //    slno = slno + 1;
                //}
                //if (rblConstitution.SelectedIndex == -1)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Constitution \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtGoodssupplie.Text) || txtGoodssupplie.Text == "" || txtGoodssupplie.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Description Goods Supplies\\n";
                    slno = slno + 1;
                }
                if (rblAdditional.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Additional \\n";
                    slno = slno + 1;
                }
                if (rblAdditional.SelectedValue == "Y")
                {
                    if (GVState.Rows.Count <= 0)
                    {
                        errormsg = errormsg + slno + ". Please Enter Additional place of Business details then click on Add Details Button \\n";
                        slno = slno + 1;
                    }
                }
                if (rblDesignation.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Designation \\n";
                    slno = slno + 1;
                }
                if (rblother.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter registration under any other act \\n";
                    slno = slno + 1;
                }
                if (ddlRegType.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Distric Registration Type\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(TXTRegNo.Text) || TXTRegNo.Text == "" || TXTRegNo.Text == null || TXTRegNo.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(TXTRegNo.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Registration Number\\n";
                    slno = slno + 1;
                }
                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetCFETAXDetails(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEPT_CFEUNITID"]);
                        rblApply.SelectedValue = ds.Tables[0].Rows[0]["CFEPT_APPLYAS"].ToString();
                        txtEstDet.Text = ds.Tables[0].Rows[0]["CFEPT_NAMEEST"].ToString();
                        txtadd.Text = ds.Tables[0].Rows[0]["CFEPT_ADDRESSEST"].ToString();
                        ddlDistric.SelectedValue = ds.Tables[0].Rows[0]["CFEPT_DISTRICEST"].ToString();
                        txtPincode.Text = ds.Tables[0].Rows[0]["CFEPT_PINCODEEST"].ToString();
                        txtEmployeeESt.Text = ds.Tables[0].Rows[0]["CFEPT_TOTALNOEMPEST"].ToString();
                        txtDate.Text = ds.Tables[0].Rows[0]["CFEPT_DATE"].ToString();
                        rblConstitution.SelectedValue = ds.Tables[0].Rows[0]["CFEPT_CONSTITUTIONEST"].ToString();
                        txtGoodssupplie.Text = ds.Tables[0].Rows[0]["CFEPT_GOODSSUPPLIESEST"].ToString();
                        rblAdditional.SelectedValue = ds.Tables[0].Rows[0]["CFEPT_ADDITIONPLACEBUSINESS"].ToString();
                        rblAdditional_SelectedIndexChanged(null, EventArgs.Empty);
                        rblDesignation.SelectedValue = ds.Tables[0].Rows[0]["CFEPT_DESIGNATION"].ToString();
                        rblother.SelectedValue = ds.Tables[0].Rows[0]["CFEPT_REGUNDERACT"].ToString();
                        if (rblother.SelectedValue == "Y")
                        {
                            RegistrationType.Visible = true;
                            RegNo.Visible = true;
                            ddlRegType.SelectedValue = ds.Tables[0].Rows[0]["CFEPT_REGTYPE"].ToString();
                            TXTRegNo.Text = ds.Tables[0].Rows[0]["CFEPT_REGNO"].ToString();
                        }
                      

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        ViewState["PROFESSIONALTAX"] = ds.Tables[1];
                        GVState.DataSource = ds.Tables[1];
                        GVState.DataBind();
                        GVState.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GVState_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVState.Rows.Count > 0)
                {
                    ((DataTable)ViewState["PROFESSIONALTAX"]).Rows.RemoveAt(e.RowIndex);
                    this.GVState.DataSource = ((DataTable)ViewState["PROFESSIONALTAX"]).DefaultView;
                    this.GVState.DataBind();
                    GVState.Visible = true;
                    GVState.Focus();

                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEFuelNOC.aspx?Previous=" + "P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFE/CFEPowerCEIGDetails.aspx?Next=" + "N");
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