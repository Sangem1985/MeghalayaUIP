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

namespace MeghalayaUIP.User.PreReg
{
    public partial class IndustryRegistrationUserDashboard : System.Web.UI.Page
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
                    }  
                    
                    if (!IsPostBack)
                    {
                        BindData(ObjUserInfo.Userid);
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            { 
            }
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
            }
            catch (Exception ex)
            { 
            }

        }       

        protected void lnkQueryCount_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = (LinkButton)sender;

            GridViewRow row = (GridViewRow)lnkbtn.NamingContainer;
            string UNITID = row.Cells[1].Text;
            if (lnkbtn.Text != "0")
            {
                string newurl = "IndustryRegistrationViewDetails.aspx?AppId=" + UNITID ;

                Response.Redirect(newurl);
            }

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string UNITID = row.Cells[1].Text;
            string newurl = "IndustryRegistrationViewDetails.aspx?AppId=" + UNITID ;

            Response.Redirect(newurl);
        }
    }
}