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
        string Distid,FromDate, ToDate, ViewType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDistrictWiseReport();
            }
        }
        protected void BindDistrictWiseReport()
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {
                    Distid = Convert.ToString(Request.QueryString[0]);
                    FromDate = Convert.ToString(Request.QueryString[1]);
                    ToDate = Convert.ToString(Request.QueryString[2]);
                    ViewType = Convert.ToString(Request.QueryString[3]);

                    DataSet ds = new DataSet();

                     ds = Objreport.DistrictReport(Distid,FromDate,ToDate,ViewType);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GVDistWise.DataSource = ds.Tables[0];
                        GVDistWise.DataBind();
                    }
                    else
                    {
                        GVDistWise.DataSource = null;
                        GVDistWise.DataBind();
                    }
                }



            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}