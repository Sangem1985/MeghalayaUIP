using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                BindDistricts(ddlDistrict);
                trComments.Visible = true;
                DataSet dsdepts = new DataSet();
                //  dsdepts = Gen.GetDepartmentSofAmmendments();
                dsdepts = mstrBAL.GetAmmendamentFullName();
                if (dsdepts != null && dsdepts.Tables.Count > 0 && dsdepts.Tables[0].Rows.Count > 0)
                {
                    //ddlDepartments.DataSource = dsdepts.Tables[0];
                    //ddlDepartments.DataTextField = "Dept_Name";
                    //ddlDepartments.DataValueField = "Dept_Id";
                    //ddlDepartments.DataBind();
                    //AddSelect(ddlDepartments);

                    ddlDepartments.DataSource = dsdepts.Tables[0];
                    ddlDepartments.DataValueField = "TMD_DEPTID";
                    ddlDepartments.DataTextField = "TMD_DeptName";
                    ddlDepartments.DataBind();
                    ddlDepartments.Items.Insert(0, "--Select--");
                    AddSelect(ddlDepartments);
                }




               // string Deptid = "";
                if (Request.QueryString.Count > 0)
                {
                    ddlAmendment.SelectedValue = Request.QueryString[0];
                    IframePanel.Attributes["src"] = Request.QueryString[1];
                  //  ddlDepartments.SelectedValue = Request.QueryString[1];
                  //  ddlDepartments_SelectedIndexChanged(sender, e);                  
                    ddlDepartments.Enabled = false;
                    ddlAmendment.Enabled = false;
                }
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

        protected void btnviewcomments_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dept/Ammendments.aspx?filename=" + ddlAmendment.SelectedValue);
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
            Response.Redirect("BussinessRegulation.aspx");
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