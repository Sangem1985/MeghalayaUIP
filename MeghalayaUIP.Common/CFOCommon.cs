using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    public class CFOConstants
    {

        public static string InsertCFOLabourDet = "USP_INSCFOLABOURDETAILS";
        public static string InsertCFOLabourContractorDetails = "USP_INSCFOCONTRACTLABOURDETAILS";
    }

    public class CFOLabourDet
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string DirectorateBoiler { get; set; }
        public string Classification { get; set; }
        public string ProvideDetails { get; set; }
        public string Establishmentyear { get; set; }
        public string temperature { get; set; }
        public string BoilerRegulation { get; set; }
        public string generatortool { get; set; }
        public string Document { get; set; }
        public string firm { get; set; }
        public string regulationstrictly { get; set; }
        public string controversial { get; set; }
        public string materials { get; set; }
        public string OwnSystem { get; set; }
        public string Upload_Document { get; set; }
        public string NameManufacture { get; set; }
        public string manufactureYear { get; set; }
        public string manufactureplace { get; set; }
        public string BoilerNumber { get; set; }
        public string Intendedpressure { get; set; }
        public string manufacture { get; set; }
        public string HeaterRating { get; set; }
        public string Economiser { get; set; }
        public string MaximumTonne { get; set; }
        public string RatingHeaters { get; set; }
        public string WorkingSeason { get; set; }
        public string PressurePSI { get; set; }
        public string NameOwner { get; set; }
        public string BoilerType { get; set; }
        public string DescriptionBoiler { get; set; }
        public string BoilerRating { get; set; }
        public string ownershipBoiler { get; set; }
        public string Remarks { get; set; }
        public string ManufactureNames { get; set; }
        public string ManufactureYears { get; set; }
        public string Placemanu { get; set; }

        public string NameAgent { get; set; }
        public string Address { get; set; }
        public string NameNature { get; set; }
        public string contractorlabour { get; set; }
        public string Estimateddate { get; set; }
        public string Endingdate { get; set; }
        public string Maximumemployed { get; set; }
        public string withinfiveyear { get; set; }
        public string Details { get; set; }
        public string licenseDeposite { get; set; }
        public string OrderDate { get; set; }
        public string establishmentpast { get; set; }
        public string PrincipalEMP { get; set; }
        public string EstablishmentDET { get; set; }
        public string NatureWORK { get; set; }
        public string generalManagement { get; set; }
        public string AddressAgent { get; set; }
        public string CategoryEst { get; set; }
        public string NatureBusiness { get; set; }
        public string establishmentfamily { get; set; }
        public string employeeswork { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Community { get; set; }
        public string FullPresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string HalfDay { get; set; }
        public string FullDay { get; set; }
        public string TotalNumberEMP { get; set; }

        public string NAME { get; set; }
        public string GENDER { get; set; }
        public string AGE { get; set; }
        public string COMMUNITY { get; set; }
        public string FULLADDRESS { get; set; }
        public string ADDRESS { get; set; }
        public string HALFDAY { get; set; }
        public string FULLDAY { get; set; }

    }

    public class CFOExciseDetails
    {
        public int CFOExciseID { get; set; }
        public int CFOunitid { get; set; }
        public int CFOQID { get; set; }
        public string Artical5Selection { get; set; }
        public string ApplicantSelection { get; set; }
        public string MemberSelection { get; set; }
        public string TaxSelection { get; set; }
        public string SaleTaxSelection { get; set; }
        public string ProfessionSelection { get; set; }
        public string GovernmentSelection { get; set; }
        public string GovernmentDetails { get; set; }
        public string ViolationSelection { get; set; }
        public string ViolationDetails { get; set; }
        public string ConvictedSelection { get; set; }
        public string ConvictedDetails { get; set; }
        public string RenewBrand { get; set; }
        public DateTime? RegFromDate { get; set; }
        public DateTime? RegToDate { get; set; }
        public string FirmAddress { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedIp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedIp { get; set; }
        public string Flag { get; set; }
        public List<CFOExciseBrandDetails> brandgridlist { get; set; }
        public List<CFOExciseLiquorDetails> liquorgridlist { get; set; }

    }
    [Serializable]
    public class CFOExciseBrandDetails
    {
        public int CFOExciseBrandID { get; set; }
        public int CFOunitid { get; set; }
        public int CFOQID { get; set; }
        public string NameOfBrand { get; set; }
        public string Strength { get; set; }
        public string Size { get; set; }
        public string NumberOfBottles { get; set; }
        public string MRPRs { get; set; }
        public string BulkLiter { get; set; }
        public string LandOnProof { get; set; }
        public string BottlePlant { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedIp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedIp { get; set; }
        public string Flag { get; set; }
    }
    [Serializable]
    public class CFOExciseLiquorDetails
    {
        public int CFOExciseLiquorID { get; set; }
        public int CFOunitid { get; set; }
        public int CFOQID { get; set; }
        public string CountryID { get; set; }
        public string CountryName { get; set; }
        public string MRPSSelection { get; set; }
        public string BrandName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedIp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedIp { get; set; }
        public string Flag { get; set; }
    }
}
