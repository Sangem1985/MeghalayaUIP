using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User
{
    public partial class ComplainDashboard : System.Web.UI.Page
    {
        MGCommonBAL objcommonBAL = new MGCommonBAL();
        string Unitid;
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
                Session["Unitid"] = "1001";
                Unitid = Session["Unitid"].ToString();


                Page.MaintainScrollPositionOnPostBack = true;

                if (!IsPostBack)
                {
                    ApplicationDetails();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        public void ApplicationDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcommonBAL.GetApplicationDetails(Unitid, hdnUserID.Value);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    labNameandAddress.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                    labLineofActivity.Text = ds.Tables[0].Rows[0]["LineofActivity"].ToString();
                    labTotalInvestment.Text = ds.Tables[0].Rows[0]["PROJECTCOST"].ToString();

                    labNameandAddress0.Text = ds.Tables[0].Rows[0]["ADDRESSED"].ToString();
                    lblindustryscale.Text = ds.Tables[0].Rows[0]["CATEGORY"].ToString();
                    lblriskcategory.Text = ds.Tables[0].Rows[0]["POLLUTION"].ToString();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}