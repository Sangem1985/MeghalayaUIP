using MeghalayaAPI.DAL;
using MeghalayaAPI.Models;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data;

namespace MeghalayaAPI.BAL
{   
    public class CFEProcessBAL
    {
        public CFEProcessDAL _ObjCFEDAL { get; } = new CFEProcessDAL();

        public string CFEFeasibilityReportInsert(CFE_FEASIBILITY _cfefeasibility)
        {
            return _ObjCFEDAL.CFEFeasibilityReportInsert(_cfefeasibility);
        }
        public DataSet GetDetailsByQstnryId(string Questionary, string Feasibility)
        {
            return _ObjCFEDAL.GetDetailsByQstnryId(Questionary, Feasibility);
        }
        public DataSet GetUnitIDBasedonQDID(int CFEQDID)
        {
            return _ObjCFEDAL.GetUnitIDBasedonQDID(CFEQDID);
        }
        public string UpdateEstimationDetails(CFEDtls _cfestimation)
        {
            return _ObjCFEDAL.UpdateEstimationDetails(_cfestimation);
        }

    }
}