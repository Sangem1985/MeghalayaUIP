using MeghalayaAPI.DAL;
using MeghalayaAPI.Models;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web; 

namespace MeghalayaAPI.BAL
{
    public class CFOProcessBAL
    {
        public CFOProcessDAL _ObjCFODAL { get; } = new CFOProcessDAL();

        public DataSet GetCFOUnitIDBasedonQDID(int CFEQDID)
        {
            return _ObjCFODAL.GetCFOUnitIDBasedonQDID(CFEQDID);
        }
        public string InsertCRCertificateDetails(CFODtls _cfocrcertificate)
        {
            return _ObjCFODAL.InsertCRCertificateDetails(_cfocrcertificate);
        }
    }
}