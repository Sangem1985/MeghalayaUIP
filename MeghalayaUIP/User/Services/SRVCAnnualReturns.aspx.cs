using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static AjaxControlToolkit.AsyncFileUpload.Constants;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCAnnualReturns : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Acts = "";
            for (int i = 0; i < chkActs.Items.Count; i++)
            {
                if (chkActs.Items[i].Selected == true)
                {
                    Acts = Acts + "," + chkActs.Items[i].Value;
                }
            }
            if (Acts == "")
            {
                string message = "alert('" + "Please Select atleast one act to fill annual retun forms" + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            else
            {
                Session["ActsSelected"] = Acts;
                Response.Redirect("~/User/Services/SRVCARFactoryAct.aspx?Next=N"); 
            }
        }
    }
}