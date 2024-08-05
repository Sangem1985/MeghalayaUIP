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
    public partial class CFEExplosivesNOC : System.Web.UI.Page
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
                        Binddata();
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
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetCFEEXPLOSIVE(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_CFEUNITID"]);
                        txtExplosive.Text = ds.Tables[0].Rows[0]["CFEED_EXPLOSIVESITE"].ToString();
                        txtRoadVan.Text = ds.Tables[0].Rows[0]["CFEED_EXPLOSIVEROADVAN"].ToString();
                        rblcriminal1973.SelectedValue = ds.Tables[0].Rows[0]["CFEED_CRIMINAL1973"].ToString();
                        if (rblcriminal1973.SelectedValue == "Y")
                        {
                            Details.Visible = true;
                            txtDetails.Text = ds.Tables[0].Rows[0]["CFEED_DETAIL"].ToString();
                        }
                        else { Details.Visible = false; }
                        rblLIC1884.SelectedValue = ds.Tables[0].Rows[0]["CFEED_EXPLOSIVE1884"].ToString();
                        if (rblLIC1884.SelectedValue == "Y")
                        {
                            LicDetails.Visible = true;
                            txtDet.Text = ds.Tables[0].Rows[0]["CFEED_DETAILS"].ToString();
                        }
                        else { LicDetails.Visible = false; }
                        rblApproval101.SelectedValue = ds.Tables[0].Rows[0]["CFEED_APPROVAL101"].ToString();
                        if (rblApproval101.SelectedValue == "Y")
                        {
                            approvaldet.Visible = true;
                            txtDetail.Text = ds.Tables[0].Rows[0]["CFEED_APPROVALDETAILS"].ToString();
                        }
                        else { approvaldet.Visible = false; }
                        txtinformation.Text = ds.Tables[0].Rows[0]["CFEED_ANYINFORMATION"].ToString();


                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[1].Rows[0]["CFEME_CFEQDID"]);
                        ViewState["MANUFACTURE"] = ds.Tables[1];
                        GVEXPLOSIVE.DataSource = ds.Tables[1];                       
                        GVEXPLOSIVE.DataBind();
                        GVEXPLOSIVE.Visible = true;
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
        protected void rblcriminal1973_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblcriminal1973.SelectedValue == "Y")
                {
                    Details.Visible = true;
                }
                else { Details.Visible = false; }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void rblLIC1884_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLIC1884.SelectedValue == "Y")
                {
                    LicDetails.Visible = true;
                }
                else { LicDetails.Visible = false; }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void rblApproval101_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblApproval101.SelectedValue == "Y")
                {
                    approvaldet.Visible = true;
                }
                else { approvaldet.Visible = false; }
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
                if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtClass.Text) || string.IsNullOrEmpty(txtDivision.Text) || string.IsNullOrEmpty(txtQuantityTime.Text) || String.IsNullOrEmpty(txtQuantityMonth.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFEME_CFEUNITID", typeof(string));
                    dt.Columns.Add("CFEME_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFEME_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFEME_NAME", typeof(string));
                    dt.Columns.Add("CFEME_CLASS", typeof(string));
                    dt.Columns.Add("CFEME_DIVISION", typeof(string));
                    dt.Columns.Add("CFEME_QUANTITYTIME", typeof(string));
                    dt.Columns.Add("CFEME_QUANTITYMONTH", typeof(string));


                    if (ViewState["MANUFACTURE"] != null)
                    {
                        dt = (DataTable)ViewState["MANUFACTURE"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFEME_CFEUNITID"] = Convert.ToString(Session["CFEUNITID"]);
                    dr["CFEME_CREATEDBY"] = hdnUserID.Value;
                    dr["CFEME_CREATEDBYIP"] = getclientIP();
                    dr["CFEME_NAME"] = txtName.Text.Trim();
                    dr["CFEME_CLASS"] = txtClass.Text;
                    dr["CFEME_DIVISION"] = txtDivision.Text;
                    dr["CFEME_QUANTITYTIME"] = txtQuantityTime.Text;
                    dr["CFEME_QUANTITYMONTH"] = txtQuantityMonth.Text;

                    dt.Rows.Add(dr);
                    GVEXPLOSIVE.Visible = true;
                    GVEXPLOSIVE.DataSource = dt;
                    GVEXPLOSIVE.DataBind();
                    ViewState["MANUFACTURE"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    CFEEXPLOSIVE ObjCFEExplosive = new CFEEXPLOSIVE();

                    int count = 0;

                    for (int i = 0; i < GVEXPLOSIVE.Rows.Count; i++)
                    {
                        ObjCFEExplosive.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        ObjCFEExplosive.CreatedBy = hdnUserID.Value;
                        ObjCFEExplosive.UnitId = Convert.ToString(Session["CFEUNITID"]);
                        ObjCFEExplosive.IPAddress = getclientIP();
                        ObjCFEExplosive.NAME = GVEXPLOSIVE.Rows[i].Cells[1].Text;
                        ObjCFEExplosive.CLASS = GVEXPLOSIVE.Rows[i].Cells[2].Text;
                        ObjCFEExplosive.DIVISION = GVEXPLOSIVE.Rows[i].Cells[3].Text;
                        ObjCFEExplosive.QUANTITYTIME = GVEXPLOSIVE.Rows[i].Cells[4].Text;
                        ObjCFEExplosive.QUANTITYMONTH = GVEXPLOSIVE.Rows[i].Cells[5].Text;

                        string A = objcfebal.InsertCFEExplosiveManuDetails(ObjCFEExplosive);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVEXPLOSIVE.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    ObjCFEExplosive.Questionnareid = Convert.ToString(Session["CFEQID"]);
                    ObjCFEExplosive.CreatedBy = hdnUserID.Value;
                    ObjCFEExplosive.UnitId = Convert.ToString(Session["CFEUNITID"]);
                    ObjCFEExplosive.IPAddress = getclientIP();

                    ObjCFEExplosive.EXPLOSIVESITE = txtExplosive.Text;
                    ObjCFEExplosive.EXPLOSIVEROADVAN = txtRoadVan.Text;
                    ObjCFEExplosive.CRIMINAL1973 = rblcriminal1973.SelectedValue;
                    ObjCFEExplosive.DETAIL = txtDetails.Text;
                    ObjCFEExplosive.EXPLOSIVE1884 = rblLIC1884.SelectedValue;
                    ObjCFEExplosive.DETAILS = txtDet.Text;
                    ObjCFEExplosive.APPROVAL101 = rblApproval101.SelectedValue;
                    ObjCFEExplosive.APPROVALDETAILS = txtDetail.Text;
                    ObjCFEExplosive.INFORMATION = txtinformation.Text;

                    result = objcfebal.InsertCFEExplosiveDetails(ObjCFEExplosive);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = " Details Submitted Successfully";
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

                if (string.IsNullOrEmpty(txtExplosive.Text) || txtExplosive.Text == "" || txtExplosive.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of site where explosives  License\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRoadVan.Text) || txtRoadVan.Text == "" || txtRoadVan.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of explosives road van\\n";
                    slno = slno + 1;
                }
                if (rblcriminal1973.SelectedIndex == -1)
                {
                    Details.Visible = true;
                    if (string.IsNullOrEmpty(txtDetails.Text) || txtDetails.Text == "" || txtDetails.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Details \\n";
                        slno = slno + 1;
                    }
                }
                if (rblLIC1884.SelectedIndex == -1)
                {
                    if (string.IsNullOrEmpty(txtDet.Text) || txtDet.Text == "" || txtDet.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Details \\n";
                        slno = slno + 1;
                    }
                }
                if (rblApproval101.SelectedIndex == -1)
                {
                    if (string.IsNullOrEmpty(txtDetails.Text) || txtDetails.Text == "" || txtDetails.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Details \\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtinformation.Text) || txtinformation.Text == "" || txtinformation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Any information \\n";
                    slno = slno + 1;
                }
                if (GVEXPLOSIVE.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Explosive GridView Details\\n";
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
        protected void GVEXPLOSIVE_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVEXPLOSIVE.Rows.Count > 0)
                {
                    ((DataTable)ViewState["MANUFACTURE"]).Rows.RemoveAt(e.RowIndex);
                    this.GVEXPLOSIVE.DataSource = ((DataTable)ViewState["MANUFACTURE"]).DefaultView;
                    this.GVEXPLOSIVE.DataBind();
                    GVEXPLOSIVE.Visible = true;
                    GVEXPLOSIVE.Focus();

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
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEFireDetails.aspx?Previous=" + "P");
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
                btnSave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFE/CFEFuelNOC.aspx?Next=" + "N");
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