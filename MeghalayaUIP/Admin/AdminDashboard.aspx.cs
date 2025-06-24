using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Admin
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{

            //    if (Session["UserInfo"] != null)
            //    {
            //        var ObjUserInfo = new UserInfo();
            //        if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
            //        {
            //            ObjUserInfo = (UserInfo)Session["UserInfo"];
            //            hdnUserID.Value = ObjUserInfo.Userid;

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //lblmsg0.Text = ex.Message;
            //    //Failure.Visible = true;
            //    MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            //}
        }
    }
}