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
        public int InsertIndRegBasicDetails(IndustryDetails ID)
        {
            return IRD.InsertIndRegBasicDetails(ID);
        }
        public string InsertIndRegRevenueDetails(DataTable dt, string UNITID, string USERID)
        {
            return IRD.InsertIndRegRevenueDetails(dt, UNITID, USERID);
        }
        public string InsertIndustryRegDetails(DataTable dt, string UNITID, string USERID)
        {
            return IRD.InsertIndustryRegDetails(dt, UNITID, USERID);
        }
        public string InsertIndPromotersDetails(DataTable dt, string UNITID, string USERID)
        {
            return IRD.InsertIndPromotersDetails(dt, UNITID, USERID);
        }
        public int InsertAttachments_PREREG(IndustryDetails objattachments)
        {
            return IRD.InsertAttachments_PREREG(objattachments);
        }
        public int InsertAttachments_PREREG_RESPONSE(IndustryDetails objattachments)
        {
            return IRD.InsertAttachments_PREREG_RESPONSE(objattachments);
        }
        public DataSet GetIndustryRegUserDashboard(string userid, string UnitID,string Status)
        {
            return IRD.GetIndustryRegUserDashboard(userid, UnitID, Status);
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
        //public string InsertDeptDetails(DataTable dt)
        //{
        //    return IRD.InsertDeptDetails(dt);
        //}      
        public DataSet GetIndustryRegData(string userid)
        {
            return IRD.GetIndustryRegData(userid);
        }

        public DataTable GetIntentInvestDashBoard()//Need to be removed later
        {
            return IRD.GetIntentInvestDashBoard();
        }
        public DataTable PreRegDPRDashBoard(PreRegDtls PRD)
        {
            return IRD.PreRegDPRDashBoard(PRD);
        }


    }

}
