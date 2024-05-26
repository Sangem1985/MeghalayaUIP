using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.CFODAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.BAL.CFOBAL
{
    public class CFOBAL
    {
        public CFODAL objCFODAL { get; } = new CFODAL();
        public string InsertCFOExciseData(CFOExciseDetails data, List<CFOExciseBrandDetails> brandDetails, List<CFOExciseLiquorDetails> liquorDetails)
        {
            return objCFODAL.InsertCFOExciseData(data, brandDetails, liquorDetails);
        }
        public CFOExciseDetails GetCFOExciseData(int CFOunitid, int CFOQID)
        {
            return objCFODAL.GetCFOExciseData(CFOunitid, CFOQID);
        }

        public string InsertCFOLabourDetails(CFOLabourDet ObjCFOLabourDet)
        {
            return objCFODAL.InsertCFOLabourDetails(ObjCFOLabourDet);
        }
        public string InsertCFOlabourContractor(CFOLabourDet ObjCFOLabourDet)
        {
            return objCFODAL.InsertCFOlabourContractor(ObjCFOLabourDet);
        }
        public string InsertCFOLegalMetrologyDetails(CFOLEGALMETROLOGYDEP ObjCFOlegalDet)
        {
            return objCFODAL.InsertCFOLegalMetrologyDetails(ObjCFOlegalDet);
        }
        public string InsertCFOLegalMetrologyDet(CFOLEGALMETROLOGYDEP ObjCFOlegalDet)
        {
            return objCFODAL.InsertCFOLegalMetrologyDet(ObjCFOlegalDet);
        }
        public string InsertCFOProfessionalTax(CFOPROFESSIONALTAX ObjCFOPROFESSIONALTAX)
        {
            return objCFODAL.InsertCFOProfessionalTax(ObjCFOPROFESSIONALTAX);
        }
        public string INSERTCFOSTATETAX(CFOPROFESSIONALTAX ObjCFOPROFESSIONALTAX)
        {
            return objCFODAL.INSERTCFOSTATETAX(ObjCFOPROFESSIONALTAX);
        }
        public string INSERTCFOCOUNTRYTAX(CFOPROFESSIONALTAX ObjCFOPROFESSIONALTAX)
        {
            return objCFODAL.INSERTCFOCOUNTRYTAX(ObjCFOPROFESSIONALTAX);
        }
        public string INSERTCFOFOREIGNTAX(CFOPROFESSIONALTAX ObjCFOPROFESSIONALTAX)
        {
            return objCFODAL.INSERTCFOFOREIGNTAX(ObjCFOPROFESSIONALTAX);
        }
        public string InsertCFOExciseDepaertment(CFOTAXDEPARTMENT ObjCFOExcise)
        {
            return objCFODAL.InsertCFOExciseDepaertment(ObjCFOExcise);
        }
        public string InsertCFOFIREDEPT(HOMEDEPARTMENT ObjCFOFireDepartment)
        {
            return objCFODAL.InsertCFOFIREDEPT(ObjCFOFireDepartment);
        }
        public string InsertCFOPollutionControlBoard(PollutionControlBoard ObjCFOPollutionControl)
        {
            return objCFODAL.InsertCFOPollutionControlBoard(ObjCFOPollutionControl);
        }
        public string InsertCFOPollutioncontrol(PollutionControlBoard ObjCFOPollutionControl)
        {
            return objCFODAL.InsertCFOPollutioncontrol(ObjCFOPollutionControl);
        }
        public string InsertCFOPublicworkDetails(PublicWorKDepartment ObjCFOWorkDepartment)
        {
            return objCFODAL.InsertCFOPublicworkDetails(ObjCFOWorkDepartment);
        }
        public string INSERTCFOManufactureDetails(CFOHealthyWelfare ObjCFOHealthyWelfare)
        {
            return objCFODAL.INSERTCFOManufactureDetails(ObjCFOHealthyWelfare);
        }
        public string INSERTCFOTestingDetails(CFOHealthyWelfare ObjCFOHealthyWelfare)
        {
            return objCFODAL.INSERTCFOTestingDetails(ObjCFOHealthyWelfare);
        }
        public string InsertCFODRUGLICDetails(CFOHealthyWelfare ObjCFOHealthyWelfare)
        {
            return objCFODAL.InsertCFODRUGLICDetails(ObjCFOHealthyWelfare);
        }
        public string InsertCFODrugLicenseDet(CFOHealthyWelfare ObjCFOHealthyWelfare)
        {
            return objCFODAL.InsertCFODrugLicenseDet(ObjCFOHealthyWelfare);
        }
        public string InsertCFODepartmentApprovals(CFOQuestionnaireDet objCFOQsnaire)
        {
            return objCFODAL.InsertCFODepartmentApprovals(objCFOQsnaire);
        }
        public DataSet GetCFOAlreadyObtainedApprovals(string userid, string UnitID)
        { return objCFODAL.GetCFOAlreadyObtainedApprovals(userid, UnitID); }
        public DataSet GetApprovalsReqFromTable(CFOQuestionnaireDet objCFOQsnaire)
        {
            return objCFODAL.GetApprovalsReqFromTable(objCFOQsnaire);
        }
        public string InsertCFOAttachments(CFOAttachments objAttach)
        {
            return objCFODAL.InsertCFOAttachments(objAttach);
        }
        public DataSet GetCFOApplicationDetails(string UnitID, string InvesterID)
        {
            return objCFODAL.GetCFOApplicationDetails(UnitID, InvesterID);
        }



    }
}
