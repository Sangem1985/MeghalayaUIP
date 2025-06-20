﻿using AjaxControlToolkit.Bundling;
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
                lblAmendment.Text = lblAmendmentFinal.Text = Convert.ToString(dsdepts.Tables[0].Rows[0]["AMMENDMENT_NAME"]);
                lblDepatname.Text = lblDeptFinal.Text = Convert.ToString(dsdepts.Tables[0].Rows[0]["DEPT_NAME"]);
                lblAmendmentID.Text = Convert.ToString(Request.QueryString[0]);
                lblDeptID.Text = Convert.ToString(dsdepts.Tables[0].Rows[0]["DEPT_ID"]);
                lblDeptMailid.Text = Convert.ToString(dsdepts.Tables[0].Rows[0]["TMD_MAILIDFOR_AMMENDMENTS"]);

                lblLegalBasis.Text = Convert.ToString(dsdepts.Tables[0].Rows[0]["LEGALBASIS"]);
                lblNecessity.Text = Convert.ToString(dsdepts.Tables[0].Rows[0]["NECESSITY"]);
                lblbusinsfrndly.Text = Convert.ToString(dsdepts.Tables[0].Rows[0]["BUSINESSFRIENDLY"]);

                string PathFile = dsdepts.Tables[0].Rows[0]["AMMENDMENT_FILEPATH"].ToString();
                MGCommonClass.LogData("PDFFILEPPATH - " + PathFile);
                PathFile = PathFile.Replace("@\\", "/");

                MGCommonClass.LogData("AFTER REPLACE PDFFILEPPATH - " + PathFile);
                PathFile = mstrBAL.EncryptFilePath(Convert.ToString(PathFile));
                MGCommonClass.LogData("AFTER ENCRYPT PDFFILEPPATH - " + PathFile);

                IframePanel.Attributes["src"] = "~/PdfFile.ashx?filePath=" + PathFile;
                //IframePanel.Attributes["src"] = "https://invest.meghalaya.gov.in/Documents/mipp2024.pdf";
                //MGCommonClass.LogData("SRC PDFFILEPPATH - " + IframePanel.Attributes["src"]);
                //"~/PdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(PathFile));


            }
            if (dsdepts != null && dsdepts.Tables.Count > 1 && dsdepts.Tables[1].Rows.Count > 0)
            {
                lblNocomments.Text = "Comments on this Ammendment:"; lblNocomments.ForeColor = System.Drawing.Color.Green;
                grdComments.DataSource = dsdepts.Tables[1];
                grdComments.DataBind();
            }
            else
            {
                lblNocomments.Text = "There are no Comments on this Ammendment";
                grdComments.DataSource = null;
                grdComments.DataBind();
            }
            if (Request.QueryString["Type"] == "Final")
            {
                tdFinal.Visible = true;
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
            try
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
                    if (lblDeptMailid.Text.Trim() != "")
                    {
                        string loginlink = "https://invest.meghalaya.gov.in/Login.aspx";
                        string EmailText = "Dear Team,<br/><br/>" + "The following feedback has been submitted by User for " + lblAmendmentFinal.Text.Trim() + "<br/>" +
                          "<strong>User Name:</strong> " + txtUserName.Text.Trim() + "<br/>" + "<strong>Email ID:</strong> " + txtEmailId.Text.Trim() + "<br/>" +
                          "<strong>Mobile No:</strong> " + txtMobileNo.Text.Trim() + "<br/>" + "<strong>District:</strong> " + ddlDistrict.SelectedItem.Text.Trim() + "<br/>" +
                          "<strong>Comments/Feedback:</strong>" + txtComments.Text.Trim() + "<br/><br/>" + "Thanks & Regards,<br/>" +
                          "Meghalaya Investment Promotion Authority";

                        SMSandMail smsMail = new SMSandMail();
                        smsMail.SendEmailSingle(lblDeptMailid.Text.Trim(), "sangem_madhuri@cms.co.in,chinni_sowjanya@cms.co.in", "Feedback /Comments on " + lblAmendmentFinal.Text.Trim(), EmailText, "", "Ammendments",
                                     "", "", Result);
                    }

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Comments Saved Successfully');" + "window.location='UseCommentsOnAmmendments.aspx';", true);
                    lblresult.Text = "Comments Saved Successfully";
                    lblresult.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblerrMsg.Text = ex.Message;
                //Failure.Visible = true;
                // MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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