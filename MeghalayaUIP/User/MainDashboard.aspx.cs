using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace MeghalayaUIP.User
{
    public partial class MainDashboard : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL indstregBAL = new PreRegBAL();
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
                        // txtPANno.Text = ObjUserInfo.PANno;
                        unitname.InnerText = ObjUserInfo.EntityName;
                    }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                //Failure.Visible = true;
                throw ex;
            }
        }
        protected void RegistrationMIIPPTotal_Click(object sender, EventArgs e)
        {
        }
        public void BindData(string userid)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = indstregBAL.GetIndustryRegUserDashboard(userid);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvPreRegUserDashboard.DataSource = ds;
                    gvPreRegUserDashboard.DataBind();
                }
                //if (lnkbtn.Text != "0")
                //{
                //    LinkButton lnkbtn = (LinkButton)sender;
                //    lnkbtn.Style["text-decoration"] = "none";
                //}
            }
            catch (Exception ex)
            {
            }

        }
    }
}