using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Dashboard
{
    public partial class CentralRepository : System.Web.UI.Page
    {
        MasterBAL masterBAL = new MasterBAL();
        MGCommonBAL objcommon = new MGCommonBAL();
        MasterBAL mstrBAL = new MasterBAL();
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
                    if (!IsPostBack)
                    {
                        CalendarExtender1.EndDate = DateTime.Now;
                        CalendarExtender2.EndDate = DateTime.Now;

                        BindModuleType();

                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!!";               
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void BindModuleType()
        {
            try
            {
                ddlModule.Items.Clear();

                List<MasterModule> objConsttype = new List<MasterModule>();

                objConsttype = mstrBAL.GetMasterModules();
                if (objConsttype != null)
                {
                    ddlModule.DataSource = objConsttype;
                    ddlModule.DataValueField = "ModuleID";
                    ddlModule.DataTextField = "ModuleName";
                    ddlModule.DataBind();
                }
                AddSelect(ddlModule);
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
        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlModule.SelectedIndex != 0)
                {

                    DataSet dsUnits = new DataSet();
                    dsUnits = objcommon.GetApplByModuleName(hdnUserID.Value, ddlModule.SelectedValue);
                    if (ddlModule.SelectedValue != "0")
                    {
                        if (ddlModule.SelectedValue == "1")
                        {
                            BindPreRegDepts();

                        }
                        if (ddlModule.SelectedValue == "2")
                        {
                            BindDepartment();

                        }
                        if (ddlModule.SelectedValue == "3")
                        {
                            BindDepartment();

                        }
                        if (ddlModule.SelectedValue == "4")
                        {
                            BindDepartment();

                        }
                        if (ddlModule.SelectedValue == "5")
                        {
                            BindDepartment();

                        }
                        if (ddlModule.SelectedValue == "6")
                        {
                            BindDepartment();

                        }
                        if (ddlModule.SelectedValue == "7")
                        {
                            BindPreRegDepts();
                        }
                    }

                }
                else
                {

                    ddldept.Enabled = true;
                    ddldept.Items.Clear();
                    AddSelect(ddldept);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindPreRegDepts()
        {
            try
            {
                List<MasterDepartment> objDepartmentModel = new List<MasterDepartment>();
                objDepartmentModel = mstrBAL.GetDepartment(ddlModule.SelectedValue);
                if (objDepartmentModel != null)
                {
                    ddldept.DataSource = objDepartmentModel;
                    ddldept.DataValueField = "DepartmentId";
                    ddldept.DataTextField = "DepartmentName";
                    ddldept.DataBind();
                    ddldept.Enabled = true;


                }
                else
                {
                    ddldept.DataSource = null;
                    ddldept.DataBind();

                }
                AddSelect(ddldept);
                if (ddlModule.SelectedValue == "7")
                {
                    ddldept.SelectedValue = "1012";
                    ddldept.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindDepartment()
        {

            try
            {
                ddldept.Items.Clear();
                List<MasterDepartment> objDepartmentModel = new List<MasterDepartment>();
                objDepartmentModel = mstrBAL.GetDepartment(ddlModule.SelectedValue);
                if (objDepartmentModel != null)
                {
                    ddldept.DataSource = objDepartmentModel;
                    ddldept.DataValueField = "DepartmentId";
                    ddldept.DataTextField = "DepartmentName";
                    ddldept.DataBind();
                    ddldept.Enabled = true;
                }
                else
                {
                    ddldept.DataSource = null;
                    ddldept.DataBind();
                }
                AddSelect(ddldept);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsCR = new DataSet();
                string deptid = ddldept.SelectedValue == "--Select--" ? "0" : ddldept.SelectedValue;


                dsCR = masterBAL.GetCentralRepository(Convert.ToInt16(ddlModule.SelectedValue), Convert.ToInt16(deptid), txtFDate.Text, txtTDate.Text, Convert.ToInt16(hdnUserID.Value));
                if (dsCR.Tables.Count > 0)
                {
                    if (dsCR.Tables[0].Rows.Count > 0)
                    {
                        grdCentralRepo.DataSource = dsCR.Tables[0];
                        grdCentralRepo.DataBind();
                        divgrd.Visible = true;
                    }
                    else
                    {
                        grdCentralRepo.DataSource = null;
                        grdCentralRepo.DataBind();
                        divgrd.Visible = false;
                    }
                }
                else
                {
                    grdCentralRepo.DataSource = null;
                    grdCentralRepo.DataBind();
                    divgrd.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void grdCentralRepo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewFile")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdCentralRepo.Rows[index];

                Label relativeFilePath = (Label)row.FindControl("lblpath");
                Label fileName = (Label)row.FindControl("lblfilename");

                string virtualPath = relativeFilePath.Text;// +"\\"+ fileName.Text;

                string physicalPath = virtualPath.Replace(@"\", "/");

                if (File.Exists(physicalPath))
                {
                    string script = "openPdf('" + physicalPath + "');";

                    ScriptManager.RegisterStartupScript(this, GetType(), "OpenPdfScript", script, true);


                    //Response.ContentType = "application/pdf";
                    //Response.AppendHeader("Content-Disposition", $"attachment; filename={fileName.Text}");
                    //Response.TransmitFile(physicalPath);
                    //Response.End();
                }
                else
                {
                    Context.Response.Write("<script>");
                    Context.Response.Write("window.open('" + physicalPath + "', '_newtab');");
                    Context.Response.Write("</script>");

                    //string script = "openPdf('" + physicalPath + "');";

                    //ScriptManager.RegisterStartupScript(this, GetType(), "OpenPdfScript", script, true);
                    //Response.Write("<script>alert('File not found.');</script>");
                }
            }
        }
    }
}