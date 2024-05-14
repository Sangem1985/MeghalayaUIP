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
        public DataSet GetPREREGandCFEapplications(string USERID)
        { 
            return objCFEDAL.GetPREREGandCFEapplications(USERID);
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
        { return objCFEDAL.GetApprovalsReqFromTable(objCFEQsnaire); }
        public string InsertCFEDepartmentApprovals(CFEQuestionnaireDet objCFEQsnaire)
        { return objCFEDAL.InsertCFEDepartmentApprovals(objCFEQsnaire); }

        public DataSet GetEntrepreneurDetails(string userid, string UnitID)
        {
            return objCFEDAL.GetEntrepreneurDetails(userid, UnitID);
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
        public string InsertCFEForestDet(CFEForest objCFEQForest)
        {
            return objCFEDAL.InsertCFEForestDet(objCFEQForest);
        }
        public string InsertCFEWaterDetails(CFEWater ObjCFEWater)
        {
            return objCFEDAL.InsertCFEWaterDetails(ObjCFEWater);
        }
        public string InsertCFEPowerDetails(CFEPower objCFEPower)
        {
            return objCFEDAL.InsertCFEPowerDetails(objCFEPower);
        }
        public string GetInsertManufacture(CFELineOfManuf objCFEManufacture)
        {
            return objCFEDAL.GetInsertManufacture(objCFEManufacture);
        }
        public string GetInsertCFERawMaterial(CFELineOfManuf objCFEManufacture)
        {
            return objCFEDAL.GetInsertCFERawMaterial(objCFEManufacture);
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
    }
}
