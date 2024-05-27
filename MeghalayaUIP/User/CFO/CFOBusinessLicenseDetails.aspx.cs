using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
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
        CFOBAL objcfebal = new CFOBAL();
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
                Session["CFOUNITID"] = "1001";
                UnitID = Convert.ToString(Session["CFOUNITID"]);
                if (Convert.ToString(Session["CFOUNITID"]) != "")
                { UnitID = Convert.ToString(Session["CFOUNITID"]); }
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

                }
            }
        }

        protected void rblBusiness_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblBusiness.SelectedValue == "1")
            {
                stall.Visible = true;
            }
            else if (rblBusiness.SelectedValue == "2")
            {
                Districmaster.Visible = true;
            }
        }

        protected void rblmunicipality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblmunicipality.SelectedItem.Text == "Yes")
            {
                Municipality.Visible = true;
            }
            else
            {
                Municipality.Visible = false;
            }
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
                    dr["CFOBN_UNITID"] = Convert.ToString(ViewState["UnitID"]);
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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                //if (string.IsNullOrEmpty(txtEstDet.Text) || txtEstDet.Text == "" || txtEstDet.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Name Of Establishment \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtaddress.Text) || txtaddress.Text == "" || txtaddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address\\n";
                    slno = slno + 1;
                }
                if (ddlDistric.SelectedIndex == -1 || ddlDistric.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric \\n";
                    slno = slno + 1;
                }
                if (rblBusiness.SelectedIndex == -1 || rblBusiness.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Place of Business in Meghalaya \\n";
                    slno = slno + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            String Quesstionriids = "1001";
            string UnitId = "1001";
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Validations();
                {
                    PollutionControlBoard ObjCFOPollutionControl = new PollutionControlBoard();

                    int count = 0;
                    for (int i = 0; i < GVPollution.Rows.Count; i++)
                    {
                        ObjCFOPollutionControl.Questionnariid = Quesstionriids;
                        ObjCFOPollutionControl.CreatedBy = hdnUserID.Value;
                        ObjCFOPollutionControl.UNITID = Convert.ToString(Session["UNITID"]);
                        ObjCFOPollutionControl.IPAddress = getclientIP();
                        ObjCFOPollutionControl.MainCategory = GVPollution.Rows[i].Cells[1].Text;
                        ObjCFOPollutionControl.SubCategory = GVPollution.Rows[i].Cells[2].Text;
                        ObjCFOPollutionControl.Fees = GVPollution.Rows[i].Cells[3].Text;
                        string A = objcfebal.InsertCFOPollutionControlBoard(ObjCFOPollutionControl);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVPollution.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "CFO Pollution Control Board Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }



                    { ObjCFOPollutionControl.UNITID = Convert.ToString(ViewState["UnitID"]); }
                    ObjCFOPollutionControl.CreatedBy = hdnUserID.Value;
                    ObjCFOPollutionControl.IPAddress = getclientIP();
                    ObjCFOPollutionControl.Questionnariid = Quesstionriids;
                    ObjCFOPollutionControl.UnitId = UnitId;

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


                    result = objcfebal.InsertCFOPollutioncontrol(ObjCFOPollutionControl);
                    ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "CFO Pollution Control Board Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
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

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/CFO/CFOFireDetails.aspx");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/CFO/CFOExcise.aspx");
        }
    }
}