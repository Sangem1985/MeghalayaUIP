using MeghalayaUIP.DAL.ReportDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.BAL.ReportBAL
{
    public class ReportBAL
    {
        public ReportDAL reportDAL { get; } = new ReportDAL();

        public DataSet DistrictWiseReports(string District, string EntType,string Formdate,string Todate)
        {
            return reportDAL.DistrictWiseReports(District, EntType, Formdate, Todate);
        }
    }
}
