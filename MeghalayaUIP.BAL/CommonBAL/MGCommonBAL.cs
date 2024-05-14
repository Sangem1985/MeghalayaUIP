using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeghalayaUIP.DAL.CommonDAL;

namespace MeghalayaUIP.BAL.CommonBAL
{
    public partial class MGCommonBAL
    {
        public MGCommonDAL objCommonDAL { get; } = new MGCommonDAL();
        public string LogerrorDB(Exception ex, string path, string CreatedBy)
        {
            return objCommonDAL.LogerrorDB(ex, path, CreatedBy);
        }
        public DataTable GetMainApplicantDashBoard(String Investerid)
        {
            return objCommonDAL.GetMainApplicantDashBoard(Investerid);
        }
    }
}
