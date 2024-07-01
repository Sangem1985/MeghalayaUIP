using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.DAL.CommonDAL;

namespace MeghalayaUIP
{
    public partial class StateProfileNew : System.Web.UI.Page
    {
        MGCommonDAL objMGCommonDAL = new MGCommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public DataTable GetData()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objMGCommonDAL.GetGrowthFinancialYear();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
               
            return dt;
        }
        public string GetChartData()
        {
            var data = ProcessData(GetData());
            var years = data.Select(d => d.Year).ToArray();
            var gsdps = data.Select(d => d.GSDP).ToArray();
            var yoyChanges = data.Select(d => d.YoYChange).ToArray();

            var chartData = new
            {
                years,
                gsdps,
                yoyChanges
            };

            return new JavaScriptSerializer().Serialize(chartData);
        }
        public List<DataPoint> ProcessData(DataTable dt)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var year = dt.Rows[i]["TG_FINANCIALYEAR"].ToString();
                var gsdp = Convert.ToDouble(dt.Rows[i]["TG_GSDP"]);

                double? yoyChange = null;
                if (i > 0)
                {
                    var prevGsdp = Convert.ToDouble(dt.Rows[i - 1]["TG_GSDP"]);
                    yoyChange = ((gsdp - prevGsdp) / prevGsdp) * 100;
                }

                dataPoints.Add(new DataPoint
                {
                    Year = year,
                    GSDP = gsdp,
                    YoYChange = yoyChange
                });
            }

            return dataPoints;
        }

        public class DataPoint
        {
            public string Year { get; set; }
            public double GSDP { get; set; }
            public double? YoYChange { get; set; }
        }
    }
}