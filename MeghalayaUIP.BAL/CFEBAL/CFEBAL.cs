using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeghalayaUIP.DAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.CommonDAL;
using MeghalayaUIP.DAL.CFEDAL;
using System.Data;
using MeghalayaUIP.DAL.PreRegDAL;

namespace MeghalayaUIP.BAL.CFEBLL
{
    public class CFEBAL
    {
        public CFEQuestionnaireDet objCFEQ { get; } = new CFEQuestionnaireDet();
        public CFEDAL objCFEDAL { get; } = new CFEDAL();
        public DataSet GetPREREGandCFEapplications(string USERID, string UnitID)
        {
            return objCFEDAL.GetPREREGandCFEapplications(USERID, UnitID);
        }
        public DataSet GetIndustryRegDetails(string userid, string UnitID)
        {
            return objCFEDAL.GetIndustryRegDetails(userid, UnitID);
        }
        public DataSet RetrieveQuestionnaireDetails(string userid, string UnitID)
        { return objCFEDAL.RetrieveQuestionnaireDetails(userid, UnitID); }
        public DataTable GetApprovalsReqWithFee(CFEQuestionnaireDet objCFEQ)
        { return objCFEDAL.GetApprovalsReqWithFee(objCFEQ); }
        public string InsertQuestionnaireCFE(CFEQuestionnaireDet objCFEQsnaire)
        {
            return objCFEDAL.InsertQuestionnaireCFE(objCFEQsnaire);
        }
        public string InsertCFEQuestionnaireApprovals(CFEQuestionnaireDet objCFEQsnaire)
        {
            return objCFEDAL.InsertCFEQuestionnaireApprovals(objCFEQsnaire);
        }
        public DataSet GetApprovalsReqFromTable(CFEQuestionnaireDet objCFEQsnaire)
        {
            return objCFEDAL.GetApprovalsReqFromTable(objCFEQsnaire);
        }
        public string InsertCFEDepartmentApprovals(CFEQuestionnaireDet objCFEQsnaire)
        {
            return objCFEDAL.InsertCFEDepartmentApprovals(objCFEQsnaire);
        }
        public DataSet GetCFEAlreadyObtainedApprovals(string userid, string UnitID)
        { return objCFEDAL.GetCFEAlreadyObtainedApprovals(userid, UnitID); }
        public DataSet GetCFEIndustryDetails(string userid, string UnitID)
        {
            return objCFEDAL.GetCFEIndustryDetails(userid, UnitID);
        }
        public string InsertCFEIndustryDetails(CFECommonDet objCFEEntrepreneur)
        {
            return objCFEDAL.InsertCFEIndustryDetails(objCFEEntrepreneur);
        }
        public DataSet GetCFELOMandRMDetails(string userid, string UnitID)
        {
            return objCFEDAL.GetCFELOMandRMDetails(userid, UnitID);
        }
        public string InsertCFELineofManf(CFELineOfManuf objCFEManufacture)
        {
            return objCFEDAL.InsertCFELineofManf(objCFEManufacture);
        }
        public string InsertCFERawMaterial(CFELineOfManuf objCFEManufacture)
        {
            return objCFEDAL.InsertCFERawMaterial(objCFEManufacture);
        }
        public string InsertEntrepreneurDet(CFEEntrepreneur objCFEEntrepreneur)
        {
            return objCFEDAL.InsertEntrepreneurDet(objCFEEntrepreneur);
        }
        public string InsertCFELandDet(CFELand objCFELandDet)
        {
            return objCFEDAL.InsertCFELandDet(objCFELandDet);
        }
        public DataSet GetCFELandDet(string UserID, string UnitID)
        {
            return objCFEDAL.GetCFELandDet(UserID, UnitID);
        }
        public string InsertCFEForestDet(Forest_Details objCFEQForest)
        {
            return objCFEDAL.InsertCFEForestDet(objCFEQForest);
        }
        public string InsertCFEWaterDetails(Water_Details ObjCFEWater)
        {
            return objCFEDAL.InsertCFEWaterDetails(ObjCFEWater);
        }
        public string InsertCFEPowerDetails(CFEPower objCFEPower)
        {
            return objCFEDAL.InsertCFEPowerDetails(objCFEPower);
        }

        public string InsertCFEFireDetails(CFEFire ObjCCFEFireDetails)
        {
            return objCFEDAL.InsertCFEFireDetails(ObjCCFEFireDetails);
        }
        public DataSet GetPowerDetailsRetrive(string userid, string UNITID)
        {
            return objCFEDAL.GetPowerDetailsRetrive(userid, UNITID);
        }
        public DataSet getIntentInvestPrint(string ID)
        {
            return objCFEDAL.getIntentInvestPrint(ID); // Need to remove later
        }
        public DataSet GetRetriveFireDet(string userid, string UNITID)
        {
            return objCFEDAL.GetRetriveFireDet(userid, UNITID);
        }
        public DataSet GetForestRetrive(string userid, string UNITID)
        {
            return objCFEDAL.GetForestRetrive(userid, UNITID);
        }
        public DataSet GetPaymentAmounttoPay(string userid, string UNITID)
        {
            return objCFEDAL.GetPaymentAmounttoPay(userid, UNITID);
        }
        public string InsertPaymentDetails(CFEPayments objpay)
        {
            return objCFEDAL.InsertPaymentDetails(objpay);
        }
        public string InsertCFEAttachments(CFEAttachments objAttach)
        {
            return objCFEDAL.InsertCFEAttachments(objAttach);
        }
        public DataSet GetCFEAttachmentsData(string userid, string UNITID)
        { return objCFEDAL.GetCFEAttachmentsData(userid, UNITID); }
        public DataSet GetUserCFEApplStatus(string Userid, string UNITID)
        { return objCFEDAL.GetUserCFEApplStatus( Userid,  UNITID); }
        public DataSet GetUserCFEApplStatusView(string Userid, string UNITID,string Status)
        { return objCFEDAL.GetUserCFEApplStatusView(Userid, UNITID,Status); }

        public DataSet GetRetriveCFELabourDet(string userid, string UNITID)
        {
            return objCFEDAL.GetRetriveCFELabourDet(userid, UNITID);
        }
        public DataSet GetRetriveCFEMigrantDetails(string userid, string UNITID)
        {
            return objCFEDAL.GetRetriveCFEMigrantDetails(userid, UNITID);
        }
        public string InsertCFElabourContractor(Labour_Details ObjCFELabourDet)
        {
            return objCFEDAL.InsertCFElabourContractor(ObjCFELabourDet);
        }
        public DataSet GetRetriveCFELabourContractorDet(string userid, string UNITID)
        {
            return objCFEDAL.GetRetriveCFELabourContractorDet(userid, UNITID);
        }
        public string InsertMigrantDetails(Labour_Details ObjCFELabourDet)
        {
            return objCFEDAL.InsertMigrantDetails(ObjCFELabourDet);
        }
        public string InsertCFELabourDetails(Labour_Details ObjCFELabourDet)
        {
            return objCFEDAL.InsertCFELabourDetails(ObjCFELabourDet);
        }
        public DataSet GetAppliedApprovalIDs(string userid, string UNITID, string QusestionnaireID, string DeptID, string ApprovalID)
        { return objCFEDAL.GetAppliedApprovalIDs(userid, UNITID, QusestionnaireID, DeptID, ApprovalID); }
        //public string InsertCFEWaterDetails(Water_Details ObjCFEWater)
        //{
        //    return objCFEDAL.InsertCFEWaterDetails(ObjCFEWater);
        //}
        public DataSet GetWaterDetailos(string userid, string UNITID)
        {
            return objCFEDAL.GetWaterDetailos(userid, UNITID);
        }
        public string GETANNUALTURNOVER(string PMAMOUNT, string ANNUALTURNOVER)
        {
            return objCFEDAL.GETANNUALTURNOVER(PMAMOUNT, ANNUALTURNOVER);
        }
        public string CFEENTERPRISETYPE(string ANNUALTURNOVER)
        {
            return objCFEDAL.CFEENTERPRISETYPE(ANNUALTURNOVER);
        }
        public string INSERTCFEDGSET(CFEDGset ObjCFEDGset)
        {
            return objCFEDAL.INSERTCFEDGSET(ObjCFEDGset);
        }
        public DataSet RetrieveCFEDGSETDetails(string userid, string UnitID)
        {
            return objCFEDAL.RetrieveCFEDGSETDetails(userid, UnitID);
        }

        public string InsertCFECEIGDetails(CFECEIG ObjCFECEIG)
        {
            return objCFEDAL.InsertCFECEIGDetails(ObjCFECEIG);
        }
        public DataSet GetCFEPOWERCEIGDETAILS(string userid, string UnitID)
        {
            return objCFEDAL.GetCFEPOWERCEIGDETAILS(userid, UnitID);
        }
        public string InsertCFEPetrolrumDetails(CFEPETROLEUM ObjCFEPetroleum)
        {
            return objCFEDAL.InsertCFEPetrolrumDetails(ObjCFEPetroleum);
        }
        public DataSet GetCFEPETROLEUMDETAILS(string userid, string UnitID)
        {
            return objCFEDAL.GetCFEPETROLEUMDETAILS(userid, UnitID);
        }
        public string InsertCFEExplosiveManuDetails(CFEEXPLOSIVE ObjCFEExplosive)
        {
            return objCFEDAL.InsertCFEExplosiveManuDetails(ObjCFEExplosive);
        }
        public string InsertCFEExplosiveDetails(CFEEXPLOSIVE ObjCFEExplosive)
        {
            return objCFEDAL.InsertCFEExplosiveDetails(ObjCFEExplosive);
        }
        public DataSet GetCFEEXPLOSIVE(string userid, string UnitID)
        {
            return objCFEDAL.GetCFEEXPLOSIVE(userid, UnitID);
        }

        public string InsertCFETaxDetails(CFETAXDetails ObjCFETax)
        {
            return objCFEDAL.InsertCFETaxDetails(ObjCFETax);
        }
        public string InsertCFEPROFFESSIONALTAXDetails(CFETAXDetails ObjCFETax)
        {
            return objCFEDAL.InsertCFEPROFFESSIONALTAXDetails(ObjCFETax);
        }
        public DataSet GetCFETAXDetails(string userid, string UnitID)
        {
            return objCFEDAL.GetCFETAXDetails(userid, UnitID);
        }
        public string InsertCFEHazardous(CFEPCBHAZARDOUSDET ObjCFEhazardous)
        {
            return objCFEDAL.InsertCFEHazardous(ObjCFEhazardous);
        }
        public DataSet GetCFEHAZARDOUSDEATILS(string userid, string UnitID)
        {
            return objCFEDAL.GetCFEHAZARDOUSDEATILS(userid, UnitID);
        }

        //------------------DEPARTMENT STARTED HERE ---------------------------------//

        public DataTable GetCFEDashBoard(CFEDtls objCFE)
        {
            return objCFEDAL.GetCFEDashBoard(objCFE);
        }
        public DataTable GetCFEDashBoardView(CFEDtls objCFE)
        {
            return objCFEDAL.GetCFEDashBoardView(objCFE);
        }
        public DataSet GetCFEApplicationDetails(string UnitID, string InvesterID)
        {
            return objCFEDAL.GetCFEApplicationDetails(UnitID, InvesterID);
        }
        public string UpdateCFEDepartmentProcess(CFEDtls Objcfedtls)
        {
            return objCFEDAL.UpdateCFEDepartmentProcess(Objcfedtls);
        }

        
    }
}
