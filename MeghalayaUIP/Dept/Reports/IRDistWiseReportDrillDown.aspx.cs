using MeghalayaUIP.BAL.ReportBAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Reports
{
    public partial class IRDistWiseReportDrillDown : System.Web.UI.Page
    {
        ReportBAL Objreport = new ReportBAL();
        string Distid,FromDate, ToDate, EntType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                Distid = Convert.ToString(Request.QueryString[0]);
                FromDate = Convert.ToString(Request.QueryString[1]);
                ToDate = Convert.ToString(Request.QueryString[2]);
                EntType = Convert.ToString(Request.QueryString[3]);

            }
        }
        protected void BindDistrictWiseReport()
        {
            try
            {
                DataSet ds = new DataSet();
              //  ds = Objreport.DistrictReport();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}