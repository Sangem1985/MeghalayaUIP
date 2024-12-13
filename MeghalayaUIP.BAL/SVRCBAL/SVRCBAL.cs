using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.SVRCDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.BAL.SVRCBAL
{
    public class SVRCBAL
    {
        public SVRCDAL SvrcDal = new SVRCDAL();
        public string GETANNUALTURNOVER(string PMAMOUNT, string ANNUALTURNOVER)
        {
            return SvrcDal.GETANNUALTURNOVER(PMAMOUNT, ANNUALTURNOVER);
        }
        public string CFEENTERPRISETYPE(string ANNUALTURNOVER)
        {
            return SvrcDal.CFEENTERPRISETYPE(ANNUALTURNOVER);
        }

        public DataSet GetSvrcApplicantDetails(string userid, string UnitID)
        {
            return SvrcDal.GetSvrcApplicantDetails(userid, UnitID);
        }

        public string InsertRenApplicationDetails(SvrcApplicationDetails objApplicationDetails)
        {
            return SvrcDal.InsertRenApplicationDetails(objApplicationDetails);
        }
        public DataSet BMWEquipment()
        {
            return SvrcDal.BMWEquipment();
        }
        public string SRVCBMWDetails(SvrcBMWDet ObjBMWDetails)
        {
            return SvrcDal.SRVCBMWDetails(ObjBMWDetails);
        }

        //public string SRVCSWDDetails(SWMdetails ObjBMWDetails)
        //{
        //    return SvrcDal.SRVCSWDDetails(ObjBMWDetails);
        //}
        public string SRVCBMWWASTEDET(SvrcBMWDet ObjBMWDetails)
        {
            return SvrcDal.SRVCBMWWASTEDET(ObjBMWDetails);
        }
        public string InsertBMWWASTEDET(DataTable dtBMWDetails,string Unitid,string Createdby,string IPAddress)
        {
            return SvrcDal.InsertBMWWASTEDET(dtBMWDetails, Unitid, Createdby, IPAddress);
        }
        public string InsertSRVCAttachments(SRVCAttachments objAttach)
        {
            return SvrcDal.InsertSRVCAttachments(objAttach);
        }
        public DataSet GetSRVCapplications(string USERID, string UnitID)
        {
            return SvrcDal.GetSRVCapplications(USERID, UnitID);
        }
        public DataSet GetSRVCApprovals(string userid, string UnitId)
        {
            return SvrcDal.GetSRVCApprovals(userid, UnitId);
        }
        public string InsertSRVCDeptApprovals(SRVCOtherServices ObjApplicationDetails)
        {
            return SvrcDal.InsertSRVCDeptApprovals(ObjApplicationDetails);
        }
        public DataSet GetSrvcBMWDet(string userid, string UNITID)
        {
            return SvrcDal.GetSrvcBMWDet(userid, UNITID);
        }
        public string INSSRVCSOLIDDDetails(SWMdetails ObjSWMDet)
        {
            return SvrcDal.INSSRVCSOLIDDDetails(ObjSWMDet);
        }
        public DataSet GetSrvcSWMDetails(string userid, string UNITID)
        {
            return SvrcDal.GetSrvcSWMDetails(userid, UNITID);
        }

    }
}
