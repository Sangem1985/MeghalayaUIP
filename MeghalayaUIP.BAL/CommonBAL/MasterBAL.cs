using System;
using System.Collections.Generic;
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

    }
}
