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
      
        ///--------Chanakya-////
        public string InsertQuestionnaireCFO(CFOQuestionnaireDet objCFOQsnaire)
        {
            return objCFODAL.InsertQuestionnaireCFO(objCFOQsnaire);
        }
        public DataSet GetApprovalsReqWithFee(CFOQuestionnaireDet objCFOQ)
        {
            return objCFODAL.GetApprovalsReqWithFee(objCFOQ);
        }
        public DataSet GetIndustryRegDetails(string userid, string UnitID)
        {
            return objCFODAL.GetIndustryRegDetails(userid, UnitID);
        }
        public string InsertCFOQuestionnaireApprovals(CFOQuestionnaireDet objCFOQsnaire)
        {
            return objCFODAL.InsertCFOQuestionnaireApprovals(objCFOQsnaire);
        }
        public DataSet RetrieveQuestionnaireDetails(string userid, string UnitID)
        {
            return objCFODAL.RetrieveQuestionnaireDetails(userid, UnitID);
        }
        public DataSet GetPaymentAmounttoPay(string userid, string UNITID)
        {
            return objCFODAL.GetPaymentAmounttoPay(userid, UNITID);
        }
        public string InsertPaymentDetails(CFOPayments objpay)
        {
            return objCFODAL.InsertPaymentDetails(objpay);
        }
        public string InsertCFOAttachments(CFOAttachments objAttach)
        {
            return objCFODAL.InsertCFOAttachments(objAttach);
        }

        public DataSet GetCFEApprovedandCFOAppliedApplications(string userid, string UnitID)
        {
            return objCFODAL.GetIndustryRegDetails(userid, UnitID);
        }

        //------------------DEPARTMENT STARTED HERE ---------------------------------//

        public DataTable GetCFODashBoard(CFODtls objCFO)
        {
            return objCFODAL.GetCFODashBoard(objCFO);
        }
        public DataTable GetCFODashBoardView(CFODtls objCFO)
        {
            return objCFODAL.GetCFODashBoardView(objCFO);
        }
        public DataSet GetCFOApplicationDetails(string UnitID, string InvesterID)
        {
            return objCFODAL.GetCFOApplicationDetails(UnitID, InvesterID);
        }
        public string UpdateCFODepartmentProcess(CFODtls Objcfodtls)
        {
            return objCFODAL.UpdateCFODepartmentProcess(Objcfodtls);
        }


    }
}
