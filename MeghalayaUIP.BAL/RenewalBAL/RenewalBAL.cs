using MeghalayaUIP.Common;
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
        public DataSet GetRenPublicWork(string userid, string UnitID)
        {
            return objRENDAL.GetRenPublicWork(userid, UnitID);
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
        public DataSet GetRenDrugLicDetails(string userid, string UnitID)
        {
            return objRENDAL.GetRenDrugLicDetails(userid, UnitID);
        }
        public string InsertRENBusinessLicDet(RenBusinessLicDetails ObjRenBusinessLic)
        {
            return objRENDAL.InsertRENBusinessLicDet(ObjRenBusinessLic);
        }
        public DataSet GetRenBusinessLicDet(string userid, string UnitID)
        {
            return objRENDAL.GetRenBusinessLicDet(userid, UnitID);
        }
        public string InsertRENCinemaLicDet(RenCinemaLicDetails ObjRenCinemaLicDet)
        {
            return objRENDAL.InsertRENCinemaLicDet(ObjRenCinemaLicDet);
        }
        public DataSet GetRenCinemaLicDetails(string userid, string UnitID)
        {
            return objRENDAL.GetRenCinemaLicDetails(userid, UnitID);
        }
        public string InsertRENContractLabourDet(RenContractLabour ObjRenContractLic)
        {
            return objRENDAL.InsertRENContractLabourDet(ObjRenContractLic);
        }
        public string InsertRenConLabourDetails(RenContractLabour ObjRenContractLic)
        {
            return objRENDAL.InsertRenConLabourDetails(ObjRenContractLic);
        }
        public DataSet GetRenContractDetails(string userid, string UnitID)
        {
            return objRENDAL.GetRenContractDetails(userid, UnitID);
        }
        public string InsertRENBoilerDetails(RenBoilerDetails ObjRenBoilerDetails)
        {
            return objRENDAL.InsertRENBoilerDetails(ObjRenBoilerDetails);
        }
        public DataSet GetRenBoilerDetails(string userid, string UnitID)
        {
            return objRENDAL.GetRenBoilerDetails(userid, UnitID);
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
        public DataSet GetRenShposEstablishmentLabourDetails(string userid, string UnitID)
        {
            return objRENDAL.GetRenShposEstablishmentLabourDetails(userid, UnitID);
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
        public DataSet GetRenSafteySecurity(string userid, string UnitID)
        {
            return objRENDAL.GetRenSafteySecurity(userid, UnitID);
        }
        public string InsertMigrantWorkDetails(RenMigrantwork ObjRenMigrant)
        {
            return objRENDAL.InsertMigrantWorkDetails(ObjRenMigrant);
        }
        public string InsertRENMigrantContractorDetails(RenMigrantwork ObjRenMigrant)
        {
            return objRENDAL.InsertRENMigrantContractorDetails(ObjRenMigrant);
        }
        public DataSet GetRenMigrantWorker(string userid, string UnitID)
        {
            return objRENDAL.GetRenMigrantWorker(userid, UnitID);
        }
        public string InsertRENFactoryLicDetails(RenFactoryLicense ObjRenFactoryLic)
        {
            return objRENDAL.InsertRENFactoryLicDetails(ObjRenFactoryLic);
        }
        public DataSet GetRenFactoriesLic(string userid, string UnitID)
        {
            return objRENDAL.GetRenFactoriesLic(userid, UnitID);
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
        public DataSet GetRENApplicationDetails(string UnitID, string InvesterID)
        {
            return objRENDAL.GetRENApplicationDetails(UnitID, InvesterID);
        }
        public DataTable GetRENDashboard(RENDtls ObjREN)
        {
            return objRENDAL.GetRENDashboard(ObjREN);
        }
        public DataTable GetRENDashBoardView(RENDtls ObjREN)
        {
            return objRENDAL.GetRENDashBoardView(ObjREN);
        }
        public DataSet GetRenAppliedApprovalID(string userid, string UNITID, string QusestionnaireID, string DeptID, string ApprovalID)
        { return objRENDAL.GetRenAppliedApprovalID(userid, UNITID, QusestionnaireID, DeptID, ApprovalID); }
        public string InsertRENLegalMetrologyDetails(RenLegalMetrology objRenLegal)
        {
            return objRENDAL.InsertRENLegalMetrologyDetails(objRenLegal);
        }
        public DataSet GetRenLegalmetrologyDetails(string userid, string UnitID)
        {
            return objRENDAL.GetRenLegalmetrologyDetails(userid, UnitID);
        }
        public string InsertPaymentDetails(RENPayments objpay)
        {
            return objRENDAL.InsertPaymentDetails(objpay);
        }
        public DataSet GetPaymentAmounttoPay(string userid, string UNITID)
        {
            return objRENDAL.GetPaymentAmounttoPay(userid, UNITID);
        }

        public DataSet GetCFOPaymentReceipt(string UnitId, string Createdby, string TransactionNo, string Uid)
        {
            return objRENDAL.GetRENPaymentReceipt(UnitId, Createdby, TransactionNo, Uid);
        }

    }
}
