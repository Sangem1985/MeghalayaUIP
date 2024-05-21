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
        public int InsertGrievance(string IndustryName, string intDistrictid, string Email, string MobileNumber, string intDeptid, string Grivance_Subject, string Grievance_Description, string Grivance_File_Path, string Grivance_File_Type, string Grievnace_FileName, string Created_by, string Register_Your, string uidno, string Grivance_ID)
        {
            return objCommonDAL.InsertGrievance(IndustryName,  intDistrictid,  Email,  MobileNumber,  intDeptid,  Grivance_Subject,  Grievance_Description,  Grivance_File_Path,  Grivance_File_Type,  Grievnace_FileName,  Created_by,  Register_Your,  uidno,  Grivance_ID);
        }
        public DataSet GetApplByModuleName(string UserID, string ModuleID)
        { 
            return objCommonDAL.GetApplByModuleName(UserID, ModuleID);
        }
        public DataSet GetCFEUserDashboardStatus(string UserID, string UnitID)
        {
            return objCommonDAL.GetCFEUserDashboardStatus(UserID, UnitID);
        }
        public DataSet GetUserDashboardStatusByModule(int ModuleID, string UnitID)
        {
            return objCommonDAL.GetUserDashboardStatusByModule(ModuleID, UnitID);
        }
    }
}
