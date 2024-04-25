using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    public class MasterCountry
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }

    }
    public class MasterStates
    {
        public string StateId { get; set; }
        public string StateName { get; set; }

    }
    public class MasterDistrcits
    {
        public string DistrictId { get; set; }
        public string DistrictName { get; set; }

    }

    public class MasterMandals
    {
        public string MandalId { get; set; }
        public string MandalName { get; set; }

    }

    public class MasterVillages
    {
        public string VillageId { get; set; }
        public string VillageName { get; set; }

    }

    public class MasterNationality
    {
        public string NationalityId { get; set; }
        public string Nationality { get; set; }

    }
    public class MasterEntrSector
    {
        public string SectorId { get; set; }
        public string SectorName { get; set; }

    }
    public class MasterDepartments
    {
        public string MD_DEPTID { get; set; }
        public string MD_DEPT_NAME { get; set; }

    }
    public class MasterLineOfActivity
    {
        public string LOAId { get; set; }
        public string LOAName { get; set; }

    }
    public class MasterSector
    {
        public string SectorId { get; set; }
        public string SectorName { get; set; }

    }
}
