using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
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
                        if (ds1.Tables[1].Rows.Count > 0)
                        {
                            grdFinal.DataSource = ds1.Tables[1];
                            grdFinal.DataBind();
                        }
                        LBLDATETIME.Text =DateTime.Now.AddHours(-1).ToString();
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
        protected void linkDraft_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton link = (LinkButton)sender;
                GridViewRow row = (GridViewRow)link.NamingContainer;
                Label lblAmmndmntID = (Label)row.FindControl("lblAmndmntID");
                Label lblDraftPath = (Label)row.FindControl("lblDraftPath");


                if ((lblAmmndmntID != null || lblAmmndmntID.Text != "") && (lblDraftPath != null || lblDraftPath.Text != ""))
                    Response.Redirect("~/CommentsonAmmendments.aspx?AmmndmntID =" + lblAmmndmntID.Text + "&Filepath=" + lblDraftPath.Text+"&Type=Draft");
            }
            catch (Exception ex) { }
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

        protected void linkFinal_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton link = (LinkButton)sender;
                GridViewRow row = (GridViewRow)link.NamingContainer;
                Label lblAmmndmntID = (Label)row.FindControl("lblAmndmntID");
                Label lblFinalPath = (Label)row.FindControl("lblFinalPath");


                if ((lblAmmndmntID != null || lblAmmndmntID.Text != "") && (lblFinalPath != null || lblFinalPath.Text != ""))
                    Response.Redirect("~/CommentsonAmmendments.aspx?AmmndmntID =" + lblAmmndmntID.Text + "&Filepath=" + lblFinalPath.Text + "&Type=Final");
            }
            catch (Exception ex) { }

        }
    }
}