using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace MeghalayaUIP
{
    public partial class BusinessRegulation : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                Page.MaintainScrollPositionOnPostBack = true;
                Failure.Visible = false;
                success.Visible = false;
                if (!IsPostBack)
                {
                    DataSet ds1 = mstrBAL.GetAmmendments(0);
                    if (ds1.Tables.Count > 0)
                    {
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            grdDraft.DataSource = ds1.Tables[0];
                            grdDraft.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex) { }


        }
        protected void linkDraft_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton link = (LinkButton)sender;
                GridViewRow row = (GridViewRow)link.NamingContainer;
                Label lblAmmndmntID = (Label)row.FindControl("lblAmndmntID");
                Label lblDraftPath = (Label)row.FindControl("lblDraftPath");


                if ((lblAmmndmntID != null || lblAmmndmntID.Text != "") && (lblDraftPath != null || lblDraftPath.Text != ""))
                    Response.Redirect("~/CommentsonAmmendments.aspx?AmmndmntID =" + lblAmmndmntID.Text + "&Filepath=" + lblDraftPath.Text);
            }
            catch (Exception ex) { }
        }
        protected void btnComments_Click(object sender, EventArgs e)
        {
            BindDistricts(ddlDistrict);
            trComments.Visible = true;
            DataSet dsdepts = new DataSet();
            dsdepts = mstrBAL.GetDepartmentSofAmmendments();
            if (dsdepts != null && dsdepts.Tables.Count > 0 && dsdepts.Tables[0].Rows.Count > 0)
            {
                ddlDepartments.DataSource = dsdepts.Tables[0];
                ddlDepartments.DataTextField = "TMD_DeptName";
                ddlDepartments.DataValueField = "TMD_DEPTID";
                ddlDepartments.DataBind();
                AddSelect(ddlDepartments);
            }
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
                lblmsg.Text = ex.Message;
                lblmsg.CssClass = "errormsg";
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
                //DataSet dsd = new DataSet();
                //ddlDistrict.Items.Clear();
                //List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                //objDistrictModel = mstrBAL.GetDistrcits();
                //dsd = objDistrictModel
                //if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
                //{
                //    ddlDistrict.DataSource = dsd.Tables[0];
                //    ddlDistrict.DataValueField = "District_Id";
                //    ddlDistrict.DataTextField = "District_Name";
                //    ddlDistrict.DataBind();
                //    ddlDistrict.Items.Insert(0, "--District--");
                //}
                //else
                //{
                //    ddlDistrict.Items.Insert(0, "--District--");
                //}
            }
            catch (Exception ex)
            {
                lblerrMsg.Text = ex.Message;
                lblerrMsg.CssClass = "errormsg";
            }
        }

        protected void ddlDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlAmendment.Items.Clear();
                int DEPTID = Convert.ToInt32(ddlDepartments.SelectedValue);
                DataSet ds1 = mstrBAL.GetAmmendments(DEPTID);
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    ddlAmendment.DataSource = ds1.Tables[0];
                    ddlAmendment.DataTextField = "AMMENDMENT_NAME";
                    ddlAmendment.DataValueField = "AMMENDMENT_ID";
                    ddlAmendment.DataBind();
                }
                AddSelect(ddlAmendment);

            }
            catch (Exception ex)
            {
                lblerrMsg.Text = ex.Message;
                lblerrMsg.CssClass = "errormsg";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Ammendmentvo ammendment = new Ammendmentvo();
            ammendment.UserName = txtUserName.Text;
            ammendment.District = ddlDistrict.SelectedValue;
            ammendment.MobileNo = txtMobileNo.Text;
            ammendment.MailId = txtEmailId.Text;
            ammendment.Dept_ID = ddlDepartments.SelectedValue;
            ammendment.Ammendment_Id = ddlAmendment.SelectedValue;
            ammendment.Comments = txtComments.Text;
            ammendment.IPAddress = getclientIP();
            string Result = "";
            Result = mstrBAL.InsertAmmendmentsComments(ammendment);
            if (Result != "")
            {
                lblresult.Text = "Comments Saved Successfully";
                lblresult.Visible = true;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("BusinessRegulation.aspx");
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