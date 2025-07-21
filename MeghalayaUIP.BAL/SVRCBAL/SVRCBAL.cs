using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.SVRCDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        public string InsertBMWWASTEDET(DataTable dtBMWDetails, string Questionnaire, string Createdby, string IPAddress)
        {
            return SvrcDal.InsertBMWWASTEDET(dtBMWDetails, Questionnaire, Createdby, IPAddress);
        }
        public string InsertSRVCAttachments(SRVCAttachments objAttach)
        {
            return SvrcDal.InsertSRVCAttachments(objAttach);
        }
        public DataSet GetSRVCapplications(string USERID, string UnitID)
        {
            return SvrcDal.GetSRVCapplications(USERID, UnitID);
        }
        public DataSet GetSRVCApprovals(string userid, string SRVCQDID)
        {
            return SvrcDal.GetSRVCApprovals(userid, SRVCQDID);
        }
        public string InsertSRVCDeptApprovals(SRVCOtherServices ObjApplicationDetails)
        {
            return SvrcDal.InsertSRVCDeptApprovals(ObjApplicationDetails);
        }
        public DataSet GetSrvcBMWDet(string userid, string SRVCQID)
        {
            return SvrcDal.GetSrvcBMWDet(userid, SRVCQID);
        }
        public string INSSRVCSOLIDDDetails(SWMdetails ObjSWMDet)
        {
            return SvrcDal.INSSRVCSOLIDDDetails(ObjSWMDet);
        }
        public DataSet GetSrvcSWMDetails(string userid, string SRVCQDID)
        {
            return SvrcDal.GetSrvcSWMDetails(userid, SRVCQDID);
        }
        public DataSet GetsrvcapprovalID(string userid, string QusestionnaireID, string DeptID, string ApprovalID)
        {
            return SvrcDal.GetsrvcapprovalID(userid, QusestionnaireID, DeptID, ApprovalID);
        }
        public DataSet GetApplicationStatus(string userid, string SRVCQID, string Status)
        {
            return SvrcDal.GetApplicationStatus(userid, SRVCQID, Status);
        }
        public DataSet GetSRVCApplicationDetails(string QusestionnaireID, string InvesterID, string ApprovalID)
        {
            return SvrcDal.GetSRVCApplicationDetails(QusestionnaireID, InvesterID,  ApprovalID);
        }

        public string InsertPaymentDetails(SRVCPayments objpay)
        {
            return SvrcDal.InsertPaymentDetails(objpay);
        }

        public DataSet GetPaymentAmounttoPay(string userid, string unitID)
        {
            return SvrcDal.GetPaymentAmounttoPay(userid, unitID);
        }
        public DataTable GetSRVCDashBoardView(SVRCDtls SRVCDET)
        {
            return SvrcDal.GetSRVCDashBoardView(SRVCDET);
        }
        public string SRVCPSCLDetails(PDCLD Power)
        {
            return SvrcDal.SRVCPSCLDetails(Power);
        }
        public DataTable GetSrvcDashBoard(CFEDtls objSrvc)
        {
            return SvrcDal.GetSrvcDashBoard(objSrvc);
        }
        public DataSet GetSrvcPDCLDetails(string userid, string UNITID)
        {
            return SvrcDal.GetSrvcPDCLDetails(userid, UNITID);
        }
        public string InsertEWasteDetails(ServiceEWasteDetails serviceEWasteDetails)
        {
            return SvrcDal.InsertEWasteDetails(serviceEWasteDetails);
        }   
        public string InsertProdPlasticsWasteDetails(ServiceProdPlasticsWasteDetails serviceProdPlasticsWasteDetails)
        {
            return SvrcDal.InsertProdPlasticsWasteDetails(serviceProdPlasticsWasteDetails);
        }
        public string InsertBOPlasticsWasteDetails(ServiceBOPlasticsWasteDetails serviceBOPlasticsWasteDetails)
        {
            return SvrcDal.InsertBOPlasticsWasteDetails(serviceBOPlasticsWasteDetails);
        }
        public DataSet GetEWasteDetails(string srvcQdId, string Createdby)
        {
            return SvrcDal.GetEWasteDetails(srvcQdId, Createdby);
        }
        public string InsertSrvHazardous(SRVCHAZZARDOUSDETAILS objSrvHazardous)
        {
            return SvrcDal.InsertSrvHazardous(objSrvHazardous);
        }
        public DataSet GetSRVCHAZARDOUSDETAILS(string srvcQdId, string Createdby)
        {
            return SvrcDal.GetSRVCHAZARDOUSDETAILS(srvcQdId, Createdby);
        }

        public string InsertCDWMDetails(SRVCCDWMdetails objCDWMDet)
        {
            return SvrcDal.InsertCDWMDetails(objCDWMDet);
        }

        public DataSet GetSRVCCDWMDETAILS(string srvcQdId, string Createdby)
        {
            return SvrcDal.GetSRVCCDWMDETAILS(srvcQdId, Createdby);
        }
        public DataSet GetSRVCPaymentAmounttoPay(string userid, string Quid)
        {
            return SvrcDal.GetSRVCPaymentAmounttoPay(userid, Quid);
        }
        public string SRVCInsertPaymentDet(SRVCPayments SRVCPayment)
        {
            return SvrcDal.SRVCInsertPaymentDet(SRVCPayment);
        }
        public DataSet GetSRVCUploadEnclosures(string Quid,string userid)
        {
            return SvrcDal.GetSRVCUploadEnclosures(Quid, userid);
        }
        public DataSet GetUserSRVCApplStatus(string Userid, string SRVCQID)
        {
            return SvrcDal.GetUserSRVCApplStatus(Userid, SRVCQID);
        }

        public DataSet GetProdPlasticWasteDetails(string hdnUserID, string srvcQdId)
        {
            return SvrcDal.GetProdPlasticWasteDetails(hdnUserID, srvcQdId);
        }

        public DataSet GetBOPlasticWasteDetails(string hdnUserID, string srvcQdId)
        {
            return SvrcDal.GetBOPlasticWasteDetails(hdnUserID, srvcQdId);
        }
        public string InsertRegSocietiesDetails(SRVCRegSocietiesDetailos ObjRegSocietiesDetails)
        {
            return SvrcDal.InsertRegSocietiesDetails(ObjRegSocietiesDetails);
        }
        public string SRVCRegSocietiesDet(SRVCRegSocietiesDetailos ObjRegSocietiesDetails)
        {
            return SvrcDal.SRVCRegSocietiesDet(ObjRegSocietiesDetails);
        }
        public DataSet GetRegSocietiesDet(string userid, string SRVCQID)
        {
            return SvrcDal.GetRegSocietiesDet(userid, SRVCQID);
        }
        public DataSet RetrieveSRVCDGSETDetails(string userid, string UnitID)
        {
            return SvrcDal.RetrieveSRVCDGSETDetails(userid, UnitID);
        }
        public string INSERTSRVCDGSET(SRVCDGset ObjSRVCDGset)
        {
            return SvrcDal.INSERTSRVCDGSET(ObjSRVCDGset);
        }
        public string InsertLabourConWorkDetails(LabourConstructionwork objCDWMDet)
        {
            return SvrcDal.InsertLabourConWorkDetails(objCDWMDet);
        }
        public DataSet GetSRVCLabourDETAILS(string userid, string UnitID)
        {
            return SvrcDal.GetSRVCLabourDETAILS(userid, UnitID);
        }
        public string InsertTourismDetails(SRVCTourism ObjTourismDet)
        {
            return SvrcDal.InsertTourismDetails(ObjTourismDet);
        }
        public string InsertEncumbranceDetails(SRVCEncumbrance ObjEncumbrance)
        {
            return SvrcDal.InsertEncumbranceDetails(ObjEncumbrance);
        }
        public string InsertLabourWorkmenDetails(Labourworkme6 ObjCDWMDet)
        {
            return SvrcDal.InsertLabourWorkmenDetails(ObjCDWMDet);
        }
        //public void SaveMigrantDataToDB(DataTable dt)
        //{
        //    string xmlData = ConvertDataTableToXML(dt);
        //    SvrcDal.SaveMigrantXml(xmlData);
        //}
        //private string ConvertDataTableToXML(DataTable dt)
        //{
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        dt.WriteXml(sw, XmlWriteMode.WriteSchema);
        //        return sw.ToString();
        //    }
        //}
        public string InsertLabour1970Details(Labour1970 objLabour)
        {
            return SvrcDal.InsertLabour1970Details(objLabour);
        }
        public string InsertSRVCLabourMotorDetails(SRVCLabourMotor objLabour)
        {
            return SvrcDal.InsertSRVCLabourMotorDetails(objLabour);
        }
        public string SaveDirectorListToDB(DataTable dt, int srvcqdid, int createdBy, string ip)
        {
            string xml = ConvertDataTableToXml(dt);

            DirectorXmlDTO dto = new DirectorXmlDTO
            {
                XmlData = xml,
                SRVCQDID = srvcqdid,
                CreatedBy = createdBy,
                CreatedByIP = ip
            };

            return SvrcDal.InsertDirectorsFromXml(dto);
        }

        private string ConvertDataTableToXml(DataTable dt)
        {
            using (StringWriter sw = new StringWriter())
            {
                dt.WriteXml(sw, XmlWriteMode.WriteSchema);
                return sw.ToString();
            }
        }
        public string InsertPartners(SRVCLabourMotor objLabourPart)
        {
            int result = SvrcDal.InsertPartners(objLabourPart);
            return result > 0 ? "Success" : "Failed";
        }

        public string DeletePartner(SRVCLabourMotor objLabour)
        {
            int result = SvrcDal.DeletePartner(objLabour);
            return result > 0 ? "Deleted" : "Not Found";
        }
        public string InsertDirector(SRVCLabourMotor objLabour1)
        {
            int result = SvrcDal.InsertDirector(objLabour1);
            return result > 0 ? "Success" : "Failed";
        }

        public string DeleteDirector(SRVCLabourMotor objLabour)
        {
            int result = SvrcDal.DeleteDirector(objLabour);
            return result > 0 ? "Deleted" : "Not Found";
        }
        public DataSet GetSRVCLabourMotor(string userid, string SRVCQID)
        {
            return SvrcDal.GetSRVCLabourMotor(userid, SRVCQID);
        }

        public string InsertBrand(SRVCEXICEBRAND objBrand)
        {
            int result = SvrcDal.InsertBrand(objBrand);
            return result > 0 ? "Success" : "Failed";
        }

        public string DeleteBrand(SRVCEXICEBRAND objBrand)
        {
            int result = SvrcDal.DeleteBrand(objBrand);
            return result > 0 ? "Deleted" : "Not Found";
        }
        public string InsertCountry(SRVCEXICEBRAND objBrand)
        {
            int result = SvrcDal.InsertCountry(objBrand);
            return result > 0 ? "Success" : "Failed";
        }

        public string DeleteCountry(SRVCEXICEBRAND objBrand)
        {
            int result = SvrcDal.DeleteCountry(objBrand);
            return result > 0 ? "Deleted" : "Not Found";
        }
        public string InsertAimDetails(SRVCEXICEBRAND objBrand)
        {
            int result = SvrcDal.InsertAimDetails(objBrand);
            return result > 0 ? "Success" : "Failed";
        }

        public string DeleteAIM(SRVCEXICEBRAND objBrand)
        {
            int result = SvrcDal.DeleteAIM(objBrand);
            return result > 0 ? "Deleted" : "Not Found";
        }
        public string InsertMembersDetails(SRVCEXICEBRAND objBrand)
        {
            int result = SvrcDal.InsertMembersDetails(objBrand);
            return result > 0 ? "Success" : "Failed";
        }

        public string DeleteMemberDet(SRVCEXICEBRAND objBrand)
        {
            int result = SvrcDal.DeleteMemberDet(objBrand);
            return result > 0 ? "Deleted" : "Not Found";
        }
        public string InsertSRVCExciseDetails(SRVCEXICEBRAND objBrand)
        {
            return SvrcDal.InsertSRVCExciseDetails(objBrand);
        }
        public DataSet GetSRVCExciseDet(string userid, string SRVCQID)
        {
            return SvrcDal.GetSRVCExciseDet(userid, SRVCQID);
        }
        public string InsertDrugRetailsDet(SRVCDRUGDETAILS objDrug)
        {
            int result = SvrcDal.InsertDrugRetailsDet(objDrug);
            return result > 0 ? "Success" : "Failed";
        }
        public string DeleteDrug(SRVCDRUGDETAILS objDrug)
        {
            int result = SvrcDal.DeleteDrug(objDrug);
            return result > 0 ? "Deleted" : "Not Found";
        }
        public string InsertSRVCDSrugDetails(SRVCDRUGDETAILS objDrug)
        {
            return SvrcDal.InsertSRVCDSrugDetails(objDrug);
        }
        public DataSet GetSRVCDRUGDet(string userid, string SRVCQID)
        {
            return SvrcDal.GetSRVCDRUGDet(userid, SRVCQID);
        }
        public string INSSRVCForestDet(SRVCForestDetails objSRVCForest)
        {
            return SvrcDal.INSSRVCForestDet(objSRVCForest);
        }
        public DataSet GetSRVCFORESTDet(string userid, string SRVCQID)
        {
            return SvrcDal.GetSRVCFORESTDet(userid, SRVCQID);
        }
        public string InsertLabourDirectorDetails(SRVCLABOURACT1970DETAILS objLabour)
        {
            int result = SvrcDal.InsertLabourDirectorDetails(objLabour);
            return result > 0 ? "Success" : "Failed";
        }

        public string DeleteDirector(SRVCLABOURACT1970DETAILS objLabour)
        {
            int result = SvrcDal.DeleteDirector(objLabour);
            return result > 0 ? "Deleted" : "Not Found";
        }
        public string InsertLabourManagerDetails(SRVCLABOURACT1970DETAILS objLabour)
        {
            int result = SvrcDal.InsertLabourManagerDetails(objLabour);
            return result > 0 ? "Success" : "Failed";
        }

        public string DeleteManager(SRVCLABOURACT1970DETAILS objLabour)
        {
            int result = SvrcDal.DeleteManager(objLabour);
            return result > 0 ? "Deleted" : "Not Found";
        }
        public string InsertSRVCLabour1970Details(SRVCLABOURACT1970DETAILS objLabour)
        {
            return SvrcDal.InsertSRVCLabour1970Details(objLabour);
        }
        public DataSet GetSRVCLabourAct1970DETAILS(string userid, string SRVCQID)
        {
            return SvrcDal.GetSRVCLabourAct1970DETAILS(userid, SRVCQID);
        }
    }
}
