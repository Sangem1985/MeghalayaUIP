using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.Common;

namespace MeghalayaUIP.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Home.aspx");

            }
            if (Session.Count > 0)
            {
                var ObjUserInfo = new UserInfo();
                if (Session["UserInfo"] != null)
                {                    
                    if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (UserInfo)Session["UserInfo"];
                    }
                }
                lblUser.Text = ObjUserInfo.Fullname;
            }
        }
    }
}