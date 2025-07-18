﻿using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.RenewalDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.BAL.RenewalBAL
{
    public class RenewalBAL
    {
        public RenewalDAL objRENDAL { get; } = new RenewalDAL();
        public string InsertRENPublicWorkDep(RenPublicWorK ObjRenPublicWork)
        {
            return objRENDAL.InsertRENPublicWorkDep(ObjRenPublicWork);
        }
        public DataSet GetRenPublicWork(string userid, string RENQID)
        {
            return objRENDAL.GetRenPublicWork(userid, RENQID);
        }
        public string InsertRENDrugLicDetails(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertRENDrugLicDetails(ObjRenDrugLic);
        }
        public string InsertDrugDetails(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertDrugDetails(ObjRenDrugLic);
        }
        public string INSERTRENTestingDetails(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.INSERTRENTestingDetails(ObjRenDrugLic);
        }
        public string InsertRENManufacture(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertRENManufacture(ObjRenDrugLic);
        }
        public string InsertRenDrugItemDet(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertRenDrugItemDet(ObjRenDrugLic);
        }
        public DataSet GetRenDrugLicDetails(string userid, string RENQID, int ApprovalID)
        {
            return objRENDAL.GetRenDrugLicDetails(userid, RENQID, ApprovalID);
        }
        public string InsertRENBusinessLicDet(RenBusinessLicDetails ObjRenBusinessLic)
        {
            return objRENDAL.InsertRENBusinessLicDet(ObjRenBusinessLic);
        }
        public DataSet GetRenBusinessLicDet(string userid, string RENQID)
        {
            return objRENDAL.GetRenBusinessLicDet(userid, RENQID);
        }
        public string InsertRENCinemaLicDet(RenCinemaLicDetails ObjRenCinemaLicDet)
        {
            return objRENDAL.InsertRENCinemaLicDet(ObjRenCinemaLicDet);
        }
        public DataSet GetRenCinemaLicDetails(string userid, string RENQID)
        {
            return objRENDAL.GetRenCinemaLicDetails(userid, RENQID);
        }
        public string InsertRENContractLabourDet(RenContractLabour ObjRenContractLic)
        {
            return objRENDAL.InsertRENContractLabourDet(ObjRenContractLic);
        }
        public string InsertRenConLabourDetails(RenContractLabour ObjRenContractLic)
        {
            return objRENDAL.InsertRenConLabourDetails(ObjRenContractLic);
        }
        public DataSet GetRenContractDetails(string userid, string RENQID)
        {
            return objRENDAL.GetRenContractDetails(userid, RENQID);
        }
        public string InsertRENBoilerDetails(RenBoilerDetails ObjRenBoilerDetails)
        {
            return objRENDAL.InsertRENBoilerDetails(ObjRenBoilerDetails);
        }
        public DataSet GetRenBoilerDetails(string userid, string RENQID)
        {
            return objRENDAL.GetRenBoilerDetails(userid, RENQID);
        }
        public string InsertRenShopEstablishmentDetails(RenShopsEstablishment ObjRenShopEst)
        {
            return objRENDAL.InsertRenShopEstablishmentDetails(ObjRenShopEst);
        }
        public string InsertRenewalShopsDetails(RenShopsEstablishment ObjRenShopEst)
        {
            return objRENDAL.InsertRenewalShopsDetails(ObjRenShopEst);
        }
        public string INSERTRENTRenLabourEstablishmentDetails(RenShopsEstablishment ObjRenShopEst)
        {
            return objRENDAL.INSERTRENTRenLabourEstablishmentDetails(ObjRenShopEst);
        }
        public string InsertAttachmentsRenewal(RenAttachments objRenAttachments)
        {
            return objRENDAL.InsertAttachmentsRenewal(objRenAttachments);
        }
        public DataSet GetRenShposEstablishmentLabourDetails(string userid, string RENQDID)
        {
            return objRENDAL.GetRenShposEstablishmentLabourDetails(userid, RENQDID);
        }
        public string InsertRenPropertiesDetails(RenShopsEstablishment ObjRenShopEst)
        {
            return objRENDAL.InsertRenPropertiesDetails(ObjRenShopEst);
        }
        public string InsertRenPatnerDetails(RenShopsEstablishment ObjRenShopEst)
        {
            return objRENDAL.InsertRenPatnerDetails(ObjRenShopEst);
        }
        public string InsertRenLimitedCompanyDetails(RenShopsEstablishment ObjRenShopEst)
        {
            return objRENDAL.InsertRenLimitedCompanyDetails(ObjRenShopEst);
        }
        public string InsertRenApplicationDetails(RenApplicationDetails ObjApplicationDetails)
        {
            return objRENDAL.InsertRenApplicationDetails(ObjApplicationDetails);
        }
        public DataSet GetRenApplicantDetails(string userid, string UnitID)
        {
            return objRENDAL.GetRenApplicantDetails(userid, UnitID);
        }
        public DataTable GetApprovalsReqWithFee(RenApplicationDetails ObjApplicationDetails)
        {
            return objRENDAL.GetApprovalsReqWithFee(ObjApplicationDetails);
        }
        public string InsertRENSafteySecurityDetails(RenSafteySecurity ObjRenSafteySecurity)
        {
            return objRENDAL.InsertRENSafteySecurityDetails(ObjRenSafteySecurity);
        }
        public DataSet GetRenSafteySecurity(string userid, string RENQID)
        {
            return objRENDAL.GetRenSafteySecurity(userid, RENQID);
        }
        public string InsertMigrantWorkDetails(RenMigrantwork ObjRenMigrant)
        {
            return objRENDAL.InsertMigrantWorkDetails(ObjRenMigrant);
        }
        public string InsertRENMigrantContractorDetails(RenMigrantwork ObjRenMigrant)
        {
            return objRENDAL.InsertRENMigrantContractorDetails(ObjRenMigrant);
        }
        public DataSet GetRenMigrantWorker(string userid, string RENQDID)
        {
            return objRENDAL.GetRenMigrantWorker(userid, RENQDID);
        }
        public string InsertRENFactoryLicDetails(RenFactoryLicense ObjRenFactoryLic)
        {
            return objRENDAL.InsertRENFactoryLicDetails(ObjRenFactoryLic);
        }
        public DataSet GetRenFactoriesLic(string userid, string RENQDID)
        {
            return objRENDAL.GetRenFactoriesLic(userid, RENQDID);
        }
        public DataSet GetRenApprovals(string userid,string RENQDID)
        {
            return objRENDAL.GetRenApprovals(userid, RENQDID);
        }
        public DataSet GetRENapplications(string USERID, string UnitID)
        {
            return objRENDAL.GetRENapplications(USERID, UnitID);
        }
        public string InsertRenDeptApprovals(RenApplicationDetails ObjApplicationDetails)
        {
            return objRENDAL.InsertRenDeptApprovals(ObjApplicationDetails);
        }

        public string GETANNUALTURNOVER(string PMAMOUNT, string ANNUALTURNOVER)
        {
            return objRENDAL.GETANNUALTURNOVER(PMAMOUNT, ANNUALTURNOVER);
        }
        public string CFEENTERPRISETYPE(string ANNUALTURNOVER)  
        {
            return objRENDAL.CFEENTERPRISETYPE(ANNUALTURNOVER);
        }
        public DataSet GetRENApplicationDetails(string RENQDID, string InvesterID)
        {
            return objRENDAL.GetRENApplicationDetails(RENQDID, InvesterID);
        }
        public DataTable GetRENDashboard(RENDtls ObjREN)
        {
            return objRENDAL.GetRENDashboard(ObjREN);
        }
        public DataTable GetRENDashBoardView(RENDtls ObjREN)
        {
            return objRENDAL.GetRENDashBoardView(ObjREN);
        }
        public DataSet GetRenAppliedApprovalID(string userid, string QusestionnaireID, string DeptID, string ApprovalID)
        { return objRENDAL.GetRenAppliedApprovalID(userid, QusestionnaireID, DeptID, ApprovalID); }
        public string InsertRENLegalMetrologyDetails(RenLegalMetrology objRenLegal)
        {
            return objRENDAL.InsertRENLegalMetrologyDetails(objRenLegal);
        }
        public DataSet GetRenLegalmetrologyDetails(string userid, string RENQDID)
        {
            return objRENDAL.GetRenLegalmetrologyDetails(userid, RENQDID);
        }
        public string InsertPaymentDetails(RENPayments objpay)
        {
            return objRENDAL.InsertPaymentDetails(objpay);
        }
        public DataSet GetPaymentAmounttoPay(string userid, string RENQDID)
        {
            return objRENDAL.GetPaymentAmounttoPay(userid, RENQDID);
        }

        public DataSet GetCFOPaymentReceipt(string UnitId, string Createdby, string TransactionNo, string Uid)
        {
            return objRENDAL.GetRENPaymentReceipt(UnitId, Createdby, TransactionNo, Uid);
        }
        public DataSet GetUserRENApplStatus(string Userid, string RENQID)
        {
            return objRENDAL.GetUserRENApplStatus(Userid, RENQID);
        }
        public DataSet GetRENApplicationStatus(string userid, string RENQID, string Status)
        {
            return objRENDAL.GetRENApplicationStatus(userid, RENQID, Status);
        }
        public string UpdateRENDepartmentProcess(RENDtls objrenDtls)
        {
            return objRENDAL.UpdateRENDepartmentProcess(objrenDtls);
        }
        public DataSet GetRENQueryDashBoard(string RENQID, string Queryid)
        {
            return objRENDAL.GetRENQueryDashBoard(RENQID, Queryid);
        }
        public string InsertRENQueryResponse(RENQueryDet RENQuery)
        {
            return objRENDAL.InsertRENQueryResponse(RENQuery);
        }
        public string InsertDrugDet(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertDrugDet(ObjRenDrugLic);
        }
        public string InsertRenStaff(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertRenStaff(ObjRenDrugLic);
        }
        public string InsertRENDrugLicDetails63(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertRENDrugLicDetails63(ObjRenDrugLic);
        }
        public string InsertRENDrugLicDetails64(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertRENDrugLicDetails64(ObjRenDrugLic);
        }
        public string InsertRenDrugItemDet64(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertRenDrugItemDet64(ObjRenDrugLic);
        }
        public string InsertRENManufacture64(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertRENManufacture64(ObjRenDrugLic);
        }
        public string InsertDrugDet64(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertDrugDet64(ObjRenDrugLic);
        }
        public string InsertDrugDet65(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertDrugDet65(ObjRenDrugLic);
        }
        public string InsertRENDrugLicDetails65(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertRENDrugLicDetails65(ObjRenDrugLic);
        }
        public string InsertEquipment67(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertEquipment67(ObjRenDrugLic);
        }
        public string InsertRENRadiologist(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertRENRadiologist(ObjRenDrugLic);
        }
        public string InsertRENPCPNDTAMENDED67(RenDrugLicDet ObjRenDrugLic)
        {
            return objRENDAL.InsertRENPCPNDTAMENDED67(ObjRenDrugLic);
        }
        public DataSet GetRenDrugLicDetails67(string Userid, string RENQID)
        {
            return objRENDAL.GetRenDrugLicDetails67(Userid, RENQID);
        }
        public DataSet GetRenDrugLicDetails63(string Userid, string RENQID)
        {
            return objRENDAL.GetRenDrugLicDetails63(Userid, RENQID);
        }
        public DataSet GetRenDrugLicDetails64(string userid, string RENQID)
        {
            return objRENDAL.GetRenDrugLicDetails64(userid, RENQID);
        }
        public DataSet GetRenDrugLicDetails65(string userid, string RENQID)
        {
            return objRENDAL.GetRenDrugLicDetails65(userid, RENQID);
        }
        public DataSet GetRenDrugLicDetails3(string userid, string RENQID)
        {
            return objRENDAL.GetRenDrugLicDetails3(userid, RENQID);
        }
        public string InsertRENDrugLicDetails3(RenDrugLicDet ObjRenDrugLic3)
        {
            return objRENDAL.InsertRENDrugLicDetails3(ObjRenDrugLic3);
        }
        public DataSet GetFactoryFees(RenFactoryLicense ObjRenFactoryLic)
        {
            return objRENDAL.GetFactoryFees(ObjRenFactoryLic);
        }

        public string INSAddtionalPaymentDetails(RENPayments objpay)
        {
            return objRENDAL.INSAddtionalPaymentDetails(objpay);
        }
    }
}
