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
    public partial class CFEHazWasteDetails : System.Web.UI.Page
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
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "12", "2");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "2")
                        {
                            BindData();
                        }
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFEPowerDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFE/CFEPCBAEDetails.aspx");
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
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetCFEHAZARDOUSDEATILS(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEHWD_UNITID"]);
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Generation"))
                        CHKAuthorized.Items[0].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Collection"))
                        CHKAuthorized.Items[1].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Storage"))
                        CHKAuthorized.Items[2].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Transportation"))
                        CHKAuthorized.Items[3].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Reception"))
                        CHKAuthorized.Items[4].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Reuse"))
                        CHKAuthorized.Items[5].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Recycling"))
                        CHKAuthorized.Items[6].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Recovery"))
                        CHKAuthorized.Items[7].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Pre-processing"))
                        CHKAuthorized.Items[8].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Co-processing"))
                        CHKAuthorized.Items[9].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Utilization"))
                        CHKAuthorized.Items[10].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Treatment"))
                        CHKAuthorized.Items[11].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Disposal"))
                        CHKAuthorized.Items[12].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_AUTHORIZATIONREQ"].ToString().Contains("Incineration"))
                        CHKAuthorized.Items[13].Selected = true;
                    txtMetricTons.Text = ds.Tables[0].Rows[0]["CFEHWD_WASTEHANDLEANNUM"].ToString();
                    txtstoredtons.Text = ds.Tables[0].Rows[0]["CFEHWD_WASTESTOREDTIME"].ToString();
                    txtwasteannum.Text = ds.Tables[0].Rows[0]["CFEHWD_QUANTITYWASTEANNUM"].ToString();
                    txtnature.Text = ds.Tables[0].Rows[0]["CFEHWD_QUANTITYSTOREDTIME"].ToString();
                    txtYearpro.Text = ds.Tables[0].Rows[0]["CFEHWD_YEAROFPRODUCTION"].ToString();

                    if (ds.Tables[0].Rows[0]["CFEHWD_INDUSTRYWORK"].ToString().Contains("01 Shift"))
                        chkindustrywork.Items[0].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_INDUSTRYWORK"].ToString().Contains("02 Shifts"))
                        chkindustrywork.Items[1].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFEHWD_INDUSTRYWORK"].ToString().Contains("Round the clock"))
                        chkindustrywork.Items[2].Selected = true;
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
                string  result = "";
                ErrorMsg = Validations();

                if (ErrorMsg == "")
                {
                    CFEPCBHAZARDOUSDET ObjCFEhazardous = new CFEPCBHAZARDOUSDET();

                    var selectedItems = CHKAuthorized.Items.Cast<ListItem>()
                              .Where(li => li.Selected)
                              .Select(li => li.Text);

                    string selectedActivities = string.Join(", ", selectedItems);

                    var selectedItems1 = chkindustrywork.Items.Cast<ListItem>()
                              .Where(li => li.Selected)
                              .Select(li => li.Text);

                    string selectedINDUSTRY = string.Join(", ", selectedItems1);

                    ObjCFEhazardous.Questionnareid = Convert.ToString(Session["CFEQID"]);
                    ObjCFEhazardous.CreatedBy = hdnUserID.Value;
                    ObjCFEhazardous.UnitId = Convert.ToString(Session["CFEUNITID"]);
                    ObjCFEhazardous.IPAddress = getclientIP();
                    ObjCFEhazardous.AUTHORIZATIONREQ = selectedActivities;
                    ObjCFEhazardous.WASTEHANDLEANNUM = txtMetricTons.Text;
                    ObjCFEhazardous.WASTESTOREDTIME = txtstoredtons.Text;
                    ObjCFEhazardous.QUANTITYWASTEANNUM = txtwasteannum.Text;
                    ObjCFEhazardous.QUANTITYSTOREDTIME = txtnature.Text;
                    ObjCFEhazardous.YEAROFPRODUCTION = txtYearpro.Text;
                    ObjCFEhazardous.INDUSTRYWORK = selectedINDUSTRY;

                    result = objcfebal.InsertCFEHazardous(ObjCFEhazardous);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = " HAZARDOUS WASTE Details Submitted Successfully";
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
                //List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                if (CHKAuthorized.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Authorization required for  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMetricTons.Text) || txtMetricTons.Text == "" || txtMetricTons.Text == null || txtMetricTons.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtMetricTons.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Nature Quantity  waste handled per annum (in Metric Tons) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtstoredtons.Text) || txtstoredtons.Text == "" || txtstoredtons.Text == null || txtstoredtons.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtstoredtons.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Nature and Quantity to waste stored at any time \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtwasteannum.Text) || txtwasteannum.Text == "" || txtwasteannum.Text == null || txtwasteannum.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtwasteannum.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Nature and Quantity to waste handled per annum (in Kilo Litre) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtnature.Text) || txtnature.Text == "" || txtnature.Text == null || txtnature.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtnature.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Nature and Quantity to waste stored at any time (in Kilo Litre) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtYearpro.Text) || txtYearpro.Text == "" || txtYearpro.Text == null || txtYearpro.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtYearpro.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Year of commissioning and commence of production \\n";
                    slno = slno + 1;
                }
                if (chkindustrywork.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Whether the industry works \\n";
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
                Response.Redirect("~/User/CFE/CFEPCBAEDetails.aspx");
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
                    Response.Redirect("~/User/CFE/CFEPowerDetails.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                if (ex.Message != "Thread was being aborted.")
                {
                    MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
                }
            }

        }
        //protected List<TextBox> FindEmptyTextboxes(Control container)
        //{

        //    List<TextBox> emptyTextboxes = new List<TextBox>();
        //    foreach (Control control in container.Controls)
        //    {
        //        if (control is TextBox)
        //        {
        //            TextBox textbox = (TextBox)control;
        //            if (string.IsNullOrWhiteSpace(textbox.Text))
        //            {
        //                emptyTextboxes.Add(textbox);
        //                textbox.BorderColor = System.Drawing.Color.Red;
        //            }
        //        }

        //        if (control.HasControls())
        //        {
        //            emptyTextboxes.AddRange(FindEmptyTextboxes(control));
        //        }
        //    }
        //    return emptyTextboxes;
        //}
    }
}