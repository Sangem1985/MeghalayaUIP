using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Admin
{
    public partial class HelpdeskDrilldown : System.Web.UI.Page
    {
        MGCommonBAL objcommon = new MGCommonBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void HelpDeskGrid()
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {                  
                    string DistrictID = Request.QueryString[0].ToString().Trim();
                    string status = Request.QueryString[1].ToString().Trim();
                    txtFormDate.Text = Request.QueryString[2].ToString().Trim();
                    txtToDate.Text = Request.QueryString[3].ToString().Trim();
                    DataSet ds = new DataSet();
                    ds = objcommon.GetHelpDeskReportDrilldown(status, DistrictID, txtFormDate.Text, txtToDate.Text);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GVHelpdesk.DataSource = ds.Tables[0];
                        GVHelpdesk.DataBind();
                        label.Text = "Report from " + txtFormDate.Text.Trim() + " To " + txtToDate.Text.Trim();

                    }
                }


            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
    }
}