using MeghalayaUIP.BAL.CommonBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class OuterNew : System.Web.UI.MasterPage
    {
        MasterBAL masterball = new MasterBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            masterball.InsPageAccessed( "","", Request.Url.ToString(), getclientIP(),"");

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