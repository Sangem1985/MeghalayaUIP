using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeghalayaUIP.Common;
using MeghalayaUIP.DAL;
using MeghalayaUIP.DAL.CommonDAL;
using System.Security.Cryptography;
using System.IO;

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
        public List<MasterMANUFACTUREGRANT> GetGrantManufacture()
        {
            return objMasterDAL.GetGrantManufacture();
        }
        public List<MasterElecRegulations> GetElectricRegulations()
        { return objMasterDAL.GetElectricRegulations(); }
        public List<MasterVoltages> GetVoltages()
        { return objMasterDAL.GetVoltageMaster(); }

        public List<MasterPowerPlants> GetPowerPlantsMaster()
        { return objMasterDAL.GetPowerPlantsMaster(); }
        public List<MasterWATERMUNICIPAL> GetMunicipalareaMaster()
        { return objMasterDAL.GetMunicipalareaMaster(); }
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
        public string GetPageAuthorization(string PageName, string RoleCode)
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
            return objMasterDAL.GetAmmendamentFullName(AmmendementID);
        }
        public DataSet GetGrievanceMisReportDrilldiwn(string Deptid, string FromDate, string ToDate, string ViewType, string Status)
        {
            return objMasterDAL.GetGrievanceMisReportDrilldiwn(Deptid, FromDate, ToDate, ViewType, Status);
        }
        public string InsPageAccessed(string Userid, string Email, string Pagename, string IPAddress, string RoleId)
        {
            return objMasterDAL.InsPageAccessed(Userid, Email, Pagename, IPAddress, RoleId);
        }

        ///////user search////

        public DataSet UserSearch(string Userid, string username)
        {
            return objMasterDAL.UserSearch(Userid, username);
        }

        /// encryption and decryption code///
        public string EncryptFilePath(string filePath)
        {
            string encryptionKey = "SYSTIMEMIPASS";
            // Convert the file path into bytes
            byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(filePath);

            // Generate the key and IV (use a secure derivation method)
            byte[] key = GenerateKey(encryptionKey, 256); // AES-256 key (32 bytes)
            byte[] iv = GenerateIV();

            // Perform AES encryption
            byte[] encryptedBytes;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.FlushFinalBlock();
                        encryptedBytes = ms.ToArray();
                    }
                }
            }

            // Combine IV and encrypted data (IV is needed for decryption)
            byte[] combined = new byte[iv.Length + encryptedBytes.Length];
            Buffer.BlockCopy(iv, 0, combined, 0, iv.Length);
            Buffer.BlockCopy(encryptedBytes, 0, combined, iv.Length, encryptedBytes.Length);

            // Convert to hexadecimal string for URL-safe representation
            return BitConverter.ToString(combined).Replace("-", "");
        }

        // Generate a random IV (Initialization Vector)
        private byte[] GenerateIV()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateIV();
                return aes.IV;
            }
        }

        // Key generation from password
        private byte[] GenerateKey(string password, int keySize)
        {
            byte[] salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }; // Example salt
            using (var pdb = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                return pdb.GetBytes(keySize / 8);
            }
        }

        public string DecryptFilePath(string encryptedHex)
        {
            string encryptionKey = "SYSTIMEMIPASS";
            // Convert hex string back to byte array
            byte[] combinedBytes = HexStringToByteArray(encryptedHex);

            // Extract IV and encrypted data
            byte[] iv = new byte[16]; // AES block size is 16 bytes
            byte[] encryptedBytes = new byte[combinedBytes.Length - 16];
            Buffer.BlockCopy(combinedBytes, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(combinedBytes, 16, encryptedBytes, 0, encryptedBytes.Length);

            // Generate the key
            byte[] key = GenerateKey(encryptionKey, 256);

            // Perform AES decryption
            byte[] decryptedBytes;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                        cs.FlushFinalBlock();
                        decryptedBytes = ms.ToArray();
                    }
                }
            }

            // Convert the decrypted bytes back to the original file path string
            return System.Text.Encoding.UTF8.GetString(decryptedBytes);
        }

        // Helper function to convert hex string back to byte array
        private byte[] HexStringToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

    }
}
