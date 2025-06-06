﻿using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.LADAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.BAL.LABAL
{
    public class LABAL
    {
        public LADAL objLANDDAL { get; } = new LADAL();

        public string InsertindustrialareaDetails(LANDQUESTIONNAIRE Objindustry)
        {
            return objLANDDAL.InsertindustrialareaDetails(Objindustry);
        }
        public string InsertLandIndState(LANDQUESTIONNAIRE Objindustry)
        {
            return objLANDDAL.InsertLandIndState(Objindustry);
        }
        public string InsertManufactureDetails(LANDQUESTIONNAIRE Objindustry)
        {
            return objLANDDAL.InsertManufactureDetails(Objindustry);
        }
        public string InsertRawMaterial(LANDQUESTIONNAIRE Objindustry)
        {
            return objLANDDAL.InsertRawMaterial(Objindustry);
        }
        public string InsertPowerdetails(LANDQUESTIONNAIRE Objindustry)
        {
            return objLANDDAL.InsertPowerdetails(Objindustry);
        }
        public string InsertWaterDetails(LANDQUESTIONNAIRE Objindustry)
        {
            return objLANDDAL.InsertWaterDetails(Objindustry);
        }
        public string InsertIndustrialShedDetails(LANDQUESTIONNAIRE Objindustry)
        {
            return objLANDDAL.InsertIndustrialShedDetails(Objindustry);
        }
        public DataSet GETIndustrialShedDetails(string userid, string UnitID)
        {
            return objLANDDAL.GETIndustrialShedDetails(userid, UnitID);
        }
        public DataSet GetLandUserDashboard(string USERID, string UnitID)
        {
            return objLANDDAL.GetLandUserDashboard(USERID, UnitID);
        }
        public DataSet GetLandApplicationDetails(LADeptDtls objDtls)
        {
            return objLANDDAL.GetLandApplicationDetails(objDtls);
        }
        public string SubmitLandApplication(LANDQUESTIONNAIRE Objindustry)
        {
            return objLANDDAL.SubmitLandApplication(Objindustry);
        }
        public DataSet GetLANDPaymentAmounttoPay(string userid, string UNITID)
        {
            return objLANDDAL.GetLANDPaymentAmounttoPay(userid, UNITID);
        }
        //////////////////////////---------------------------------------------------------------/////////////////////////

        public DataTable GetLADeptDashBoard(LADeptDtls objDtls)
        {
            return objLANDDAL.GetLADeptDashBoard(objDtls);
        }
        public DataTable GetLandAllottmentDashBoardView(LADeptDtls objDtls)
        {
            return objLANDDAL.GetLandAllottmentDashBoardView(objDtls);
        }
        public DataSet GetLAAttachmentsData(string userid, string UNITID)
        { return objLANDDAL.GetLAAttachmentsData(userid, UNITID); }
        public string InsertLAAttachments(LAAttachments objAttach)
        {
            return objLANDDAL.InsertLAAttachments(objAttach); 
        }
        public string LADeptProcess(LANDALLOTMENTIND land)
        {
            return objLANDDAL.LADeptProcess(land);
        }
        public string LandAllotmentProcess(LANDALLOTMENTIND land)
        {
            return objLANDDAL.LandAllotmentProcess(land);
        }

    }
}
