using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeghalayaUIP.DAL.CommonDAL;

namespace MeghalayaUIP.BAL.CommonBAL
{
    public partial class MGCommonBAL
    {
        public MGCommonDAL objCommonDAL { get; } = new MGCommonDAL();
        public string LogerrorDB(Exception ex, string path, string CreatedBy)
        {
            return objCommonDAL.LogerrorDB(ex, path, CreatedBy);
        }
        public DataSet GetMainApplicantDashBoard(String Investerid)
        {
            return objCommonDAL.GetMainApplicantDashBoard(Investerid);
        }
        public int InsertGrievance(string RegisterType, string ModuleType, string UIDNo, string UnitID, string UnitName, string ApplcantName,
            string DistID, string Email, string Mobile, string intDeptid, string Subject, string Description, string Grivance_FilePath,
            string Grivance_FileType, string GrievnaceFileName, string Createdby, string IPAddress)
        {
            return objCommonDAL.InsertGrievance(  RegisterType,   ModuleType,   UIDNo,   UnitID,   UnitName,   ApplcantName,
              DistID,   Email,   Mobile,   intDeptid,   Subject,   Description,   Grivance_FilePath,
              Grivance_FileType,   GrievnaceFileName,   Createdby,   IPAddress);  }
        public DataSet GetApplByModuleName(string UserID, string ModuleID)
        { 
            return objCommonDAL.GetApplByModuleName(UserID, ModuleID);
        }
        public DataSet GetCFEUserDashboardStatus(string UserID, string UnitID, string Type)
        {
            return objCommonDAL.GetCFEUserDashboardStatus(UserID, UnitID, Type);
        }
        public DataSet GetUserDashboardStatusByModule(string UserID, string UnitID)
        {
            return objCommonDAL.GetUserDashboardStatusByModule(UserID, UnitID);
        }
        public DataSet GetDepGrievanceDashboard(string DeptID, string Userid)
        {
            return objCommonDAL.GetDepGrievanceDashboard(DeptID, Userid);
        }
        public DataSet GetUserGrievanceList(string Userid)
        {
            return objCommonDAL.GetUserGrievanceList(Userid);
        }

        public DataSet GetDepGrievanceList( string DeptID, string GrvncID)
        {
            return objCommonDAL.GetDepGrievanceList(DeptID, GrvncID);
        }
        public int UpdateGrievanceDeptProcess(string Process, string ProcessFalg, string Remarks, string ReplyFilePath, string ReplyFileType, 
            string ReplyFileName, string GrvncID, string UserID, string DeptID, string IPAddress)
        {
            return objCommonDAL.UpdateGrievanceDeptProcess(Process, ProcessFalg, Remarks, ReplyFilePath, ReplyFileType, ReplyFileName,
                GrvncID, UserID, DeptID, IPAddress);
        }
        public DataSet GetGrowthFinancialYear()
        {
            return objCommonDAL.GetGrowthFinancialYear();
        }
    }
}
