using AjaxControlToolkit.Bundling;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace MeghalayaUIP
{
    public partial class CommentsonAmmendments : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        string Result;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if (Request.QueryString.Count > 0)
                    {

                        BindData();
                    }
                    else
                    {
                        Response.Redirect("~/BusinessRegulation.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                lblerrMsg.Text = ex.Message;
                lblerrMsg.CssClass = "errormsg";
            }
        }

        public void BindData()
        {
            DataSet dsdepts = new DataSet();
            dsdepts = mstrBAL.GetAmmendamentFullName(Request.QueryString[0]);
            if (dsdepts != null && dsdepts.Tables.Count > 0 && dsdepts.Tables[0].Rows.Count > 0)
            {
                lblAmendment.Text = Convert.ToString(dsdepts.Tables[0].Rows[0]["AMMENDMENT_NAME"]);
                lblDepatname.Text = Convert.ToString(dsdepts.Tables[0].Rows[0]["DEPT_NAME"]);
                lblAmendmentID.Text = Convert.ToString(Request.QueryString[0]);
                lblDeptID.Text = Convert.ToString(dsdepts.Tables[0].Rows[0]["DEPT_ID"]);
                IframePanel.Attributes["src"] = Convert.ToString(dsdepts.Tables[0].Rows[0]["AMMENDMENT_FILEPATH"]).Replace(@"\", @"/").Replace(@"D:/InvestMegha/MeghalayaUIP/", @"~/");
            }
            if (dsdepts != null && dsdepts.Tables.Count > 1 && dsdepts.Tables[1].Rows.Count > 0)
            {
                lblNocomments.Text = "Comments on this Ammendment:"; lblNocomments.ForeColor = System.Drawing.Color.Green;
                grdComments.DataSource = dsdepts.Tables[1];
                grdComments.DataBind();
            }
            else { lblNocomments.Text = "There are no Comments on this Ammendment"; }
            if (Request.QueryString["Type"] == "Final")
            {
                grdComments.Visible = true; lblNocomments.Visible = true;
                lblheading.Text = "Final Ammendment ";
                tdComments.Visible = false;

            }
            else if (Request.QueryString["Type"] == "Draft")
            {
                BindDistricts(ddlDistrict);
            }
        }

        protected void btnviewcomments_Click(object sender, EventArgs e)
        {
            DataSet dsdepts = new DataSet();
            dsdepts = mstrBAL.GetAmmendamentFullName(lblAmendmentID.Text);
            if (dsdepts != null && dsdepts.Tables.Count > 1 && dsdepts.Tables[1].Rows.Count > 0)
            {
                grdComments.Visible = true;
                grdComments.DataSource = dsdepts.Tables[1];
                grdComments.DataBind();
            }
            else
            { lblerrMsg.Text = "There are no comments on this Ammendment"; }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Ammendmentvo ammendment = new Ammendmentvo();
            ammendment.UserName = txtUserName.Text;
            ammendment.District = ddlDistrict.SelectedValue;
            ammendment.MobileNo = txtMobileNo.Text;
            ammendment.MailId = txtEmailId.Text;
            ammendment.Dept_ID = lblDeptID.Text;
            ammendment.Ammendment_Id = lblAmendmentID.Text;
            ammendment.Comments = txtComments.Text;
            //  ammendment.Created_By = "";
            ammendment.IPAddress = getclientIP();
            //int VALID = 0;
            Result = mstrBAL.InsertAmmendmentsComments(ammendment);
            if (Result != "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Comments Saved Successfully');" + "window.location='UseCommentsOnAmmendments.aspx';", true);
                lblresult.Text = "Comments Saved Successfully";
                lblresult.Visible = true;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BusinessRegulation.aspx");
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblerrMsg.Text = ex.Message;
                lblerrMsg.CssClass = "errormsg";
            }
        }
        public void BindDistricts(DropDownList ddlDistrict)
        {
            try
            {
                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                strmode = "";
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

            }
            catch (Exception ex)
            {
                lblerrMsg.Text = ex.Message;
                lblerrMsg.CssClass = "errormsg";
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
    }
}