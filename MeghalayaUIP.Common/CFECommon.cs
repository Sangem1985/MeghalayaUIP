using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    public class CFEConstants
    {
        public static string GetCFERegDetails = "USP_GETAPPROVEDINDUSTRYREGDATA";
        public static string GetCFEApprovalsReq = "USP_GETCFEAPPROVALSWITHFEE";
        public static string InsertCFEQuestionnaire = "USP_INSCFEQUESTIONNAREDETAILS";
        public static string InsertCFEQuestionnaireApprovals = "USP_INSCFEREQUIREDAPPROVALS";
        public static string GetApprovalsReqFromTable = "USP_GETCFEQUESTIONNAIREAPPROVALS";
    }
    public class CFEQuestionnaireDet
    {
        public string UNITID { get; set; }
        public string PREREGUIDNO { get; set; }
        public string CFEQDID { get; set; }
        public string CreatedBy { get; set; }
        public string ApprovalID { get; set; }
        public string DeptID { get; set; }
        public string ApprovalFee { get; set; }

        public string IPAddress { get; set; }
        public string CompanyName { get; set; }
        public string ConstofUnit { get; set; }
        public string ProposalFor { get; set; }
        public string LandFromMIDCL { get; set; }
        public string PropLocDitrictID { get; set; }
        public string PropLocMandalID { get; set; }
        public string PropLocVillageID { get; set; }
        public string ExtentofLand { get; set; }        
        public string Acres { get; set; }
        public string Gunthas { get; set; }
        public string Square_Meters { get; set; }
        public string BuiltUpArea { get; set; }
        public string SectorName { get; set; }
        public string Lineofacitivityid { get; set; }
        public string PCBCategory { get; set; }      
        public string NatureofActivity { get; set; }
        public string UnitLocation { get; set; }

        public string PropEmployment { get; set; }
        public string ProjectCost { get; set; }
        public string LandValue { get; set; }
        public string BuildingValue { get; set; }
        public string PlantnMachineryCost { get; set; }
        public string ExpectedTurnover { get; set; }
        public string TotalProjCost { get; set; }
        public string EnterpriseCategory { get; set; }
        public string PowerReqKW { get; set; }
        public string GeneratorReq { get; set; }
        public string BuildingHeight { get; set; }
        public string StoringRSDS { get; set; }

        public string ManfExplosives { get; set; }
        public string ManfPetroleum { get; set; }
        public string RdCtngPermission { get; set; }
        public string NonEncmbrnceCert { get; set; }
        public string CommTaxApproval { get; set; }
        public string HTMeteruse { get; set; }
        public string CEARegulationID { get; set; }
        public string PowerPlantID { get; set; }
        public string AggCapacity { get; set; }
        public string VoltageRating { get; set; }
        public string TreesFelling { get; set; }
        public string NoofTrees { get; set; }
        public string NonForstLandCert { get; set; }
        public string ForstDistLetr { get; set; }

        public string NearWaterBodyLocation { get; set; }
        public string ExistingBoreWell { get; set; }
        public string LabourAct1970 { get; set; }
        public string LabourAct1970_Workers { get; set; }
        public string LabourAct1979 { get; set; }
        public string LabourAct1979_Workers { get; set; }
        public string LabourAct1996 { get; set; }
        public string LabourAct1996_10Workers { get; set; }
        public string LabourAct1996_Workers { get; set; }

        public string ContractLabourAct { get; set; }
        public string ContractLabourAct_Workers { get; set; }

    }
    public class Labour_Details
    {
        public string Category_Estab { get; set; }
        public string Name_Contractor { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Father_Name { get; set; }
        public string Door_No { get; set; }
        public string Locality { get; set; }
        public string District { get; set; }
        public string Mandal { get; set; }
        public string Village { get; set; }
        public string Pincode { get; set; }
        public string Other_State_Address { get; set; }
        public string EASTERN_WEST { get; set; }
        public string NORTH_GARO { get; set; }
        public string SOUTH_GARO { get; set; }
        public string WEST_GARO { get; set; }
        public string Date_birth { get; set; }
        public string Age { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }
        public string DoorNo { get; set; }
        public string Localitys { get; set; }
        public string Districts { get; set; }
        public string Mandals { get; set; }
        public string Villages { get; set; }
        public string Pincodes { get; set; }
        public string Name { get; set; }
        public string Fathers_Name { get; set; }
        public string Ages { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string DoorNos { get; set; }
        public string Localit { get; set; }
        public string Distric { get; set; }
        public string Manda { get; set; }
        public string Villag { get; set; }
        public string Name_Employer { get; set; }
        public string Door_Locality { get; set; }
        public string Dist { get; set; }
        public string Mand { get; set; }
        public string Vill { get; set; }
        public string Pin { get; set; }
        public string State_Address { get; set; }
        public string FullName { get; set; }
        public string District1 { get; set; }
        public string Mandal1 { get; set; }
        public string Village1 { get; set; }
        public string Door { get; set; }
        public string Pincode1 { get; set; }
        public string FullName1 { get; set; }
        public string District2 { get; set; }
        public string Mandal2 { get; set; }
        public string Village2 { get; set; }
        public string Door1 { get; set; }
        public string Name1 { get; set; }
        public string Mobile_No { get; set; }
        public string EmailId1 { get; set; }
        public string Father_Name1 { get; set; }
        public string DoorNo3 { get; set; }
        public string Locality1 { get; set; }
        public string District3 { get; set; }
        public string Mandal3 { get; set; }
        public string Village3 { get; set; }
        public string Pincode3 { get; set; }
        public string Designation1 { get; set; }
        public string Address { get; set; }
        public string Commence_Date { get; set; }
        public string End_Date { get; set; }
        public string Name2 { get; set; }
        public string DoorNo4 { get; set; }
        public string Locality2 { get; set; }
        public string District4 { get; set; }
        public string Mandal4 { get; set; }
        public string Village4 { get; set; }
        public string Pincode4 { get; set; }
        public string business_Estab { get; set; }
        public string Regitration_PE { get; set; }
        public string Nature_LAB_emp { get; set; }
        public string est_constraction { get; set; }
        public string max_emp_worker { get; set; }
        public string est_building_con { get; set; }
        public string max_migrant_work { get; set; }
        public string convicted_preceding { get; set; }
        public string revoking_Lic { get; set; }
        public string Principal_Emplyer_est { get; set; }
        public string Principal_Employer_cet { get; set; }
        public string Amount_paid { get; set; }
        public string Amount_payable { get; set; }
        public string Challan_No { get; set; }
        public string Challan_Date { get; set; }
        public string Attach_Challan { get; set; }
        public string Name_Contractors { get; set; }
        public string Addre { get; set; }
        public string Mobile1 { get; set; }
        public string Nature_work { get; set; }
        public string Max_Migrant_Workmen { get; set; }
        public string Est_Date { get; set; }
        public string Date_est_Completion { get; set; }
        public string Manufacture_Details { get; set; }
    }
    public class Water_Details
    {
        public string Drinking_Water { get; set; }
        public string water_Industrial { get; set; }
        public string Quantity_Water { get; set; }
        public string Non_Consumptive_water { get; set; }
        public string persons_residing { get; set; }
        public string natural_spring { get; set; }
        public string Purpose_drilling { get; set; }
        public string Name_Registered { get; set; }
        public string E_Mail_Registered { get; set; }
        public string Water_demand { get; set; }
        public string Sub_Divisional { get; set; }
        public string Number_persons_working { get; set; }
        public string Water_perday_demand { get; set; }

    }
    public class Land_Details
    {
        public string Survey_Plot { get; set; }
        public string District { get; set; }
        public string Mandal { get; set; }
        public string Village { get; set; }
        public string Name_Grampanchayat { get; set; }
        public string Pincode { get; set; }
        public string Landline { get; set; }
        public string Total_Extent_Area { get; set; }
        public string Type_Building { get; set; }
        public string Land_Master_Plan { get; set; }
        public string Proposed_Area_Develop { get; set; }
        public string Total_Built_Area { get; set; }
        public string Height_Building { get; set; }
        public string Existing_Width { get; set; }
        public string Type_ApproachRoad { get; set; }
        public string Land_Locationfalls { get; set; }
        public string Building_Approval { get; set; }
        public string Industry_Product { get; set; }
        public string Category_Industry { get; set; }
        public string Name_indu_Under { get; set; }
        public string Road_Widening { get; set; }
        public string land_part { get; set; }
        public string Architect_LICNo { get; set; }
        public string Architect_Name { get; set; }
        public string Architect_MobileNo { get; set; }
        public string Structural_Engineer { get; set; }
        public string Structural_Mobile_No { get; set; }
        public string StructuralLicNo { get; set; }
        public string Architectural_dwg { get; set; }
        public string Common_Affidavit { get; set; }

    }
    public class Power_Details
    {
        public string Con_Load_HP { get; set; }
        public string Maximum_KVA { get; set; }
        public string Voltage_Level { get; set; }
        public string Existing_Service { get; set; }
        public string Per_Day { get; set; }
        public string Per_Month { get; set; }
        public string Expected_Month_Trial { get; set; }
        public string Probable_Date_Power { get; set; }

    }
    public class Forest_Details
    {
        public string Species { get; set; }
        public string Est_Length_Timber { get; set; }
        public string Est_Volume_Timber { get; set; }
        public string Girth { get; set; }
        public string Est_Firewood { get; set; }
        public string No_Poles { get; set; }
        public string North { get; set; }
        public string East { get; set; }
        public string West { get; set; }
        public string South { get; set; }
        public string Area_Land { get; set; }
        public string Non_Forest_land_cet { get; set; }
        public string Loc_Address_Land { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Village { get; set; }
        public string Pincode { get; set; }
        public string Geographic_Land { get; set; }
        public string ordinates_desc { get; set; }
        public string Latitude { get; set; }
        public string Degrees { get; set; }
        public string Minutes { get; set; }
        public string Seconds { get; set; }
        public string Degree { get; set; }
        public string Minute { get; set; }
        public string Second { get; set; }
        public string GPS_Coordinates { get; set; }
        public string pur_Application { get; set; }
        public string Forest_Division { get; set; }

    }
    public class Line_Manufacture
    {
        public string Line_Activity { get; set; }
        public string Item { get; set; }
        public string Quantity_Per { get; set; }
        public string Quantity { get; set; }
        public string Quantity_In { get; set; }
        public string Items { get; set; }
        public string Quantity_Pers { get; set; }
        public string Quantitys { get; set; }
        public string Quantity_Ins { get; set; }

    }
}
