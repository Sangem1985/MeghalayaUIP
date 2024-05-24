using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.CFODAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.BAL.CFOBAL
{
    public class CFOBAL
    {
        public CFODAL objCFODAL { get; } = new CFODAL();
        public string InsertCFOLabourDetails(CFOLabourDet ObjCFOLabourDet)
        {
            return objCFODAL.InsertCFOLabourDetails(ObjCFOLabourDet);
        }
        public string InsertCFOlabourContractor(CFOLabourDet ObjCFOLabourDet)
        {
            return objCFODAL.InsertCFOlabourContractor(ObjCFOLabourDet);
        }
        public string InsertCFOExciseData(CFOExciseDetails data, List<CFOExciseBrandDetails> brandDetails, List<CFOExciseLiquorDetails> liquorDetails)
        {
            return objCFODAL.InsertCFOExciseData(data, brandDetails, liquorDetails);
        }
        public CFOExciseDetails GetCFOExciseData(int CFOunitid, int CFOQID)
        {
            return objCFODAL.GetCFOExciseData(CFOunitid, CFOQID);
        }
    }
}
