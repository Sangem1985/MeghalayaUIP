using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeghalayaUIP.DAL.PreRegDAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.CommonDAL;
using System.Data;
using System.Security.Policy;

namespace MeghalayaUIP.BAL.PreRegBAL
{
    public class PreRegBAL
    {
        public PreRegDAL IRD { get; } = new PreRegDAL();
        public MasterDAL MDAL { get; } = new MasterDAL();

        //-------------------USER METHODS-------------------------------------//
        public DataTable GetRevenueProjectionsMaster()
        {
            return IRD.GetRevenueProjectionsMaster();
        }
        public DataTable GetSectorDepartments(string sectorname)
        {
            return IRD.GetSectorDepartments(sectorname);
        }
        public string InsertIndRegBasicDetails(IndustryDetails ID, out string IDno)
        {
            return IRD.InsertIndRegBasicDetails(ID, out IDno);
        }
        public string InsertIndRegRevenueDetails(DataTable dt)
        {
            return IRD.InsertIndRegRevenueDetails(dt);
        }
        public string InsertIndPromotersDetails(DataTable dt)
        {
            return IRD.InsertIndPromotersDetails(dt);
        }
        public DataSet GetIndustryRegUserDashboard(string userid)
        {
            return IRD.GetIndustryRegUserDashboard(userid);
        }
        public DataSet GetIndRegUserApplDetails(string UnitID, string InvesterID)
        {
            return IRD.GetIndRegUserApplDetails(UnitID, InvesterID);
        }
        public string UpdateIndRegApplQueryRespose(PreRegDtls ID)
        {
            return IRD.UpdateIndRegApplQueryRespose(ID);
        }
        public DataSet GetIndustryRegistrationQueryDetails(string Unitid, string InvesterID,string Queryid)
        {
            return IRD.GetIndustryRegistrationQueryDetails(Unitid,InvesterID,Queryid);
        }
       
        //-------------------END OF USER METHODS-------------------------------------//

        public DataTable GetPreRegDashBoard(PreRegDtls PRD)
        {
            return IRD.GetPreRegDashBoard(PRD);
        }
        public DataTable GetPreRegDashBoardView(PreRegDtls PRD)
        {
            return IRD.GetPreRegDashBoardView(PRD);
        }
        public DataSet GetPreRegNodelOfficer(PreRegDtls PRD)
        {
            return IRD.GetPreRegNodelOfficer(PRD);
        }
        public string PreRegApprovals(PreRegDtls PRD)
        {
            return IRD.PreRegApprovals(PRD);
        }
        public string PreRegUpdateQuery(PreRegDtls PRD)
        {
            return IRD.PreRegUpdateQuery(PRD);
        }
        public DataSet GetDeptMst(string UnitID, string Userid)
        {
            return IRD.GetDeptMst(UnitID,Userid);
        }
        public string InsertDeptDetails(DataTable dt)
        {
            return IRD.InsertDeptDetails(dt);
        }      
        public DataSet GetIndustryRegData(string userid)
        {
            return IRD.GetIndustryRegData(userid);
        }        
        
    }

}
