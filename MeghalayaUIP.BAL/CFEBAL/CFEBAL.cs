﻿using System;
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
        public string InsertCFEWaterDetails(CFEWater ObjCFEWater)
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