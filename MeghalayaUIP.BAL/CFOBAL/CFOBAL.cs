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
        public DataSet GetCFOIndustryDetails(string userid, string UnitID)
        {
            return objCFODAL.GetCFOIndustryDetails(userid, UnitID);
        }
        public string InsertCFOIndustryDetails(CFOCommonDet objCFOEntrepreneur)
        {
            return objCFODAL.InsertCFOIndustryDetails(objCFOEntrepreneur);
        }
        public string InsertCFOLineofManf(CFOLineOfManuf objCFOManufacture)
        {
            return objCFODAL.InsertCFOLineofManf(objCFOManufacture);
        }
        public string InsertCFORawMaterial(CFOLineOfManuf objCFOManufacture)
        {
            return objCFODAL.InsertCFORawMaterial(objCFOManufacture);
        }
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
        public DataSet GetCFOAlreadyObtainedApprovals(string userid, string UnitID, string CfoQid, string IsOffline)
        { return objCFODAL.GetCFOAlreadyObtainedApprovals(userid, UnitID, CfoQid, IsOffline); }
        public DataSet GetApprovalsReqFromTable(CFOQuestionnaireDet objCFOQsnaire)
        {
            return objCFODAL.GetApprovalsReqFromTable(objCFOQsnaire);
        }
      
        ///--------Chanikya-////
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
            return objCFODAL.GetCFEApprovedandCFOAppliedApplications(userid, UnitID);
        }
        public DataSet GetApprovalDataByDeptId(string CFOQDID, string UNITID, string DEPTID)
        {
            return objCFODAL.GetApprovalDataByDeptId(CFOQDID, UNITID, DEPTID);
        }

        public DataSet GetCFOTracker(string UserID, string UnitID, string Type)
        {
            return objCFODAL.GetCFOTracker(UserID, UnitID, Type);
        }
        public DataSet GetUserCFOApplStatus(string Userid, string UNITID)
        { return objCFODAL.GetUserCFOApplStatus(Userid, UNITID); }
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

        //--------------------CFO GET-------//
        public DataSet GetLabourDetails(string userid, string UnitID)
        {
            return objCFODAL.GetLabourDetails(userid, UnitID);
        }
        public DataSet GetLegalMeterologyDet(string userid, string UnitID)
        {
            return objCFODAL.GetLegalMeterologyDet(userid, UnitID);
        }
        public DataSet GetCFOContractors(string userid, string UnitID)
        {
            return objCFODAL.GetCFOContractors(userid, UnitID);
        }
        public DataSet GetCFODrugLicenseDetails(string userid, string UnitID)
        {
            return objCFODAL.GetCFODrugLicenseDetails(userid, UnitID);
        }
        public DataSet GetCFODistricCouncile(string userid, string UnitID)
        {
            return objCFODAL.GetCFODistricCouncile(userid, UnitID);
        }
        public DataSet GetCFOFireDetails(string userid, string UnitID)
        {
            return objCFODAL.GetCFOFireDetails(userid, UnitID);
        }
        public DataSet GetCFOBusinessLicenseDetails(string userid, string UnitID)
        {
            return objCFODAL.GetCFOBusinessLicenseDetails(userid, UnitID);
        }
        public DataSet GetCFOLineOfActivityDetails(string userid, string UnitID)
        {
            return objCFODAL.GetCFOLineOfActivityDetails(userid, UnitID);
        }
        //public string InsertCFOLineOfActivityDetails(CFOLineOfManuf objCFOManufacture)
        //{
        //    return objCFODAL.InsertCFOLineOfActivityDetails(objCFOManufacture);
        //}
        public DataSet GetCFOQueryDashBoard(string Unitid, string Queryid)
        {
            return objCFODAL.GetCFOQueryDashBoard(Unitid, Queryid);
        }
        public string InsertCFOQueryResponse(CFOQueryDet CFOQuery)
        {
            return objCFODAL.InsertCFOQueryResponse(CFOQuery);
        }

        //---------------------CFO ATTACHMENT BINDING----------------//
        public DataSet GetCFOAttachmentsData(string userid, string UNITID)
        { return objCFODAL.GetCFOAttachmentsData(userid, UNITID); }
    }
}
