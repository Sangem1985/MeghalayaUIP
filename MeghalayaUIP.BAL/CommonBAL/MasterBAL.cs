using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeghalayaUIP.Common;
using MeghalayaUIP.DAL;
using MeghalayaUIP.DAL.CommonDAL;

namespace MeghalayaUIP.BAL.CommonBAL
{
    public class MasterBAL
    {
        public MasterDAL objMasterDAL { get; } = new MasterDAL();
        public List<MasterCountry> GetCountries()
        {
            return objMasterDAL.GetCountries();
        }
        public List<MasterStates> GetStates()
        {
            return objMasterDAL.GetStates();
        }
        public List<MasterDistrcits> GetDistrcits()
        {
            return objMasterDAL.GetDistrcits();
        }
        public List<MasterMandals> GetMandals(string DistrictId)
        {
            return objMasterDAL.GetMandals(DistrictId);
        }
        public List<MasterVillages> GetVillages(string MandalId)
        {
            return objMasterDAL.GetVillages(MandalId);
        }

        public List<MasterLineOfActivity> GetLineOfActivity(string Sector)
        {
            return objMasterDAL.GetLineOfActivity(Sector);
        }
        public List<MasterSector> GetSectors()
        {
            return objMasterDAL.GetSectors();
        }
        public string GetPCBCategory(string LineofActivityID)
        {
            return objMasterDAL.GetPCBCategory(LineofActivityID);
        }
        public List<MasterConstType> GetConstitutionType()
        {
            return objMasterDAL.GetConstitutionType();
        }
        public List<MasterPowerReq> GetPowerKW()
        {
            return objMasterDAL.GetPowerKW();
        }
        public List<MasterElecRegulations> GetElectricRegulations()
        { return objMasterDAL.GetElectricRegulations(); }
        public List<MasterVoltages> GetVoltages()
        { return objMasterDAL.GetVoltageMaster(); }

        public List<MasterPowerPlants> GetPowerPlantsMaster()
        { return objMasterDAL.GetPowerPlantsMaster(); }
        public List<MasterIndustryType> GetIndustryTypeMaster()
        { return objMasterDAL.GetIndustryTypeMaster(); }
        public List<MasterCaste> GetCaste()
        { return objMasterDAL.GetCaste(); }
        public List<MasterRegistrationType> GetRegistrationType()
        { return objMasterDAL.GetRegistrationType(); }
        public string InsertInvestment(InvtentInvest objInvest)
        {
            return objMasterDAL.InsertInvestment(objInvest);
        }
        public List<MasterSECTORS> GetSector()
        {
            return objMasterDAL.GetSector();
        }
        public List<MasterDepartment> GetDepartment(string ModuleType)
        {
            return objMasterDAL.GetDepartment(ModuleType);
        }
        public List<MasterENTERPRISETYPE> GetENTERPRISETYPE()
        {
            return objMasterDAL.GetENTERPRISETYPE();
        }
        public List<MasterENERGYLOAD> GetPowerEnergyLoad()
        {
            return objMasterDAL.GetPowerEnergyLoad();
        }
        public List<MasterVoltage> GetVoltageRange()
        {
            return objMasterDAL.GetVoltageRange();
        }
        public List<MasterForestDivision> GetForestDivision()
        {
            return objMasterDAL.GetForestDivision();
        }
        public List<MasterModule> GetMasterModules()
        {
            return objMasterDAL.GetMasterModules();
        }
        public List<MasterCategoryEst> GetCategoryEST()
        {
            return objMasterDAL.GetCategoryEST();
        }
        public List<MasterDistricEST> GetDistricEST()
        {
            return objMasterDAL.GetDistricEST();
        }
        public List<MasterBOILERTYPE> GetBoilerType()
        {
            return objMasterDAL.GetBoilerType();
        }
        public List<MasterREGTYPE> GetRegType()
        {
            return objMasterDAL.GetRegType();
        }
        public List<MasterDistric> GetDistric()
        {
            return objMasterDAL.GetDistric();
        }
        public List<MasterBuildingType> GetBuildingType()
        {
            return objMasterDAL.GetBuildingType();
        }
        public List<MasterMARKET> GetMARKET()
        {
            return objMasterDAL.GetMARKET();
        }
        public List<MasterANNUALGROSS> Getannualgross()
        {
            return objMasterDAL.Getannualgross();
        }
        public List<MasterMAINCATEGORY> GetMAINCATEGORY()
        {
            return objMasterDAL.GetMAINCATEGORY();
        }
        public DataSet GetCertifcateDetails(string TypeOfApplication, string UIDNo, string UnitName)
        {
            return objMasterDAL.GetCertifcateDetails(TypeOfApplication, UIDNo, UnitName);
        }
        public DataSet GetAcknowlegementDetails(string UnitId, string AppType)
        {
            return objMasterDAL.GetAcknowlegementDetails(UnitId, AppType);
        }
        public DataSet GetSingleWindowDepts(string fdate, string tdate, string DeptId)
        {
            return objMasterDAL.GetSingleWindowDepts(fdate, tdate, DeptId);
        }
        public DataSet GetSingleWindowApprovals(string fdate, string tdate, string DeptId)
        {
            return objMasterDAL.GetSingleWindowApprovals(fdate, tdate, DeptId);
        }
        public List<MasterDGPOWER> GetDGPOWER()
        {
            return objMasterDAL.GetDGPOWER();
        }
        public List<MasterMAXAMOUNTPOWER> GetMaxAmountPower()
        {
            return objMasterDAL.GetMaxAmountPower();
        }
        public List<MasterNOOFWORKERSYEARS> GetWORKERSYEARS()
        {
            return objMasterDAL.GetWORKERSYEARS();
        }
        public List<MasterINDUSTRIALPARKS> GetIndustryParks()
        {
            return objMasterDAL.GetIndustryParks();
        }
        public List<MasterWaterSource> GetWaterSource()
        {
            return objMasterDAL.GetWaterSource();
        }
        public DataSet GetCentralRepository(int moduleid, int deptid, string fdate, string tdate, int userid)
        {
            return objMasterDAL.GetCentralRepository(moduleid, deptid, fdate, tdate, userid);
        }
        public string GetPageAuthorization (string PageName,string RoleCode)
        {
            return objMasterDAL.GetPageAuthorization(PageName, RoleCode);
        }
        public DataSet GetInformationWizard(string module, string deptid, string sector)
        {
            return objMasterDAL.GetInformationWizard(module, deptid, sector);
        }
        public DataSet GetGrievanceMisReport(string fdate, string tdate, string Type)
        {
            return objMasterDAL.GetGrievanceMisReport(fdate, tdate, Type);
        }
        public List<MasterYear> GetYear()
        {
            return objMasterDAL.GetYear();
        }
        public List<MasterMonth> GetMonth()
        {
            return objMasterDAL.GetMonth();
        }
        public DataSet GrievanceHandledDashboard(string fdate, string tdate)
        {
            return objMasterDAL.GrievanceHandledDashboard(fdate, tdate);
        }
        public DataSet MISIIncentiveDashboard(string fdate, string tdate)
        {
            return objMasterDAL.MISIIncentiveDashboard(fdate, tdate);
        }
        public DataSet GetAmmendments(int DEPTID)
        {
            return objMasterDAL.GetAmmendments(DEPTID);
        }
        public string InsertAmmendmentsComments(Ammendmentvo ammendment)
        {
            return objMasterDAL.InsertAmmendmentsComments(ammendment);
        }
        public DataSet GetDepartmentSofAmmendments()
        {
            return objMasterDAL.GetDepartmentSofAmmendments();
        }
        public DataSet GetUserCommentsofAmmendmentsid(int ammendentid)
        {
            return objMasterDAL.GetUserCommentsofAmmendmentsid(ammendentid);
        }
        //public DataSet GetUserCommentsofAmmendmentsid(int ammendentid)
        //{
        //    return objMasterDAL.GetUserCommentsofAmmendmentsid(ammendentid);
        //}      
        public string InsertDeptAmmendments(AmmendmentVo ammendment, List<Deptcomments> lstformvo)
        {
            return objMasterDAL.InsertDeptAmmendments(ammendment, lstformvo);
        }
        public DataSet GetAmmendamentFullName(string AmmendementID)
        {
            return objMasterDAL.GetAmmendamentFullName( AmmendementID);
        }
        public DataSet GetGrievanceMisReportDrilldiwn(string Deptid, string FromDate, string ToDate, string ViewType,string Status)
        {
            return objMasterDAL.GetGrievanceMisReportDrilldiwn(Deptid, FromDate, ToDate, ViewType, Status);
        }

    }
}
