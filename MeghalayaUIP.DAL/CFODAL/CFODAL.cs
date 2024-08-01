using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MeghalayaUIP.DAL.CFODAL
{
    public class CFODAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();

        public DataSet GetCFOIndustryDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFOIndustryDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFOIndustryDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));

                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string InsertCFOIndustryDetails(CFOCommonDet objCFOEntrepreneur)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOIndustryDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFOID_CREATEDBY", Convert.ToInt32(objCFOEntrepreneur.CreatedBy));
                com.Parameters.AddWithValue("@CFOID_CREATEDBYIP", objCFOEntrepreneur.IPAddress);

                com.Parameters.AddWithValue("@CFOID_PREREGUIDNO", objCFOEntrepreneur.PreRegUID);
                com.Parameters.AddWithValue("@CFOID_UNITID", Convert.ToInt32(objCFOEntrepreneur.UNITID));

                com.Parameters.AddWithValue("@CFOID_COMPANYNAME", objCFOEntrepreneur.CompanyName);
                com.Parameters.AddWithValue("@CFOID_COMPANYTYPE", Convert.ToInt32(objCFOEntrepreneur.CompanyType));
                com.Parameters.AddWithValue("@CFOID_PROPOSALFOR", objCFOEntrepreneur.CompanyPraposal);
                com.Parameters.AddWithValue("@CFOID_REGTYPE", Convert.ToInt32(objCFOEntrepreneur.CompanyRegType));
                com.Parameters.AddWithValue("@CFOID_REGNO", objCFOEntrepreneur.CompanyRegNo);
                com.Parameters.AddWithValue("@CFOID_REGDATE", DateTime.ParseExact(objCFOEntrepreneur.CompanyRegDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFOID_FACTORYTYPE", objCFOEntrepreneur.FactoryType);
                com.Parameters.AddWithValue("@CFOID_REPNAME", objCFOEntrepreneur.AuthRep_Name);
                com.Parameters.AddWithValue("@CFOID_REPSoWoDo", objCFOEntrepreneur.AuthRep_SoWoDo);
                com.Parameters.AddWithValue("@CFOID_REPEMAIL", objCFOEntrepreneur.AuthRep_Email);
                com.Parameters.AddWithValue("@CFOID_REPMOBILE", Convert.ToInt64(objCFOEntrepreneur.AuthRep_Mobile));
                com.Parameters.AddWithValue("@CFOID_REPALTMOBILE", objCFOEntrepreneur.AuthRep_AltMobile);
                com.Parameters.AddWithValue("@CFOID_REPTELPHNO", objCFOEntrepreneur.AuthRep_TelNo);
                com.Parameters.AddWithValue("@CFOID_REPDOORNO", objCFOEntrepreneur.AuthRep_DoorNo);
                com.Parameters.AddWithValue("@CFOID_REPLOCALITY", objCFOEntrepreneur.AuthRep_Locality);
                com.Parameters.AddWithValue("@CFOID_REPDISTRICTID", Convert.ToInt32(objCFOEntrepreneur.AuthRep_DistrictID));
                com.Parameters.AddWithValue("@CFOID_REPMANDALID", Convert.ToInt32(objCFOEntrepreneur.AuthRep_MandalID));
                com.Parameters.AddWithValue("@CFOID_REPVILLAGEID", Convert.ToInt32(objCFOEntrepreneur.AuthRep_VillageID));
                com.Parameters.AddWithValue("@CFOID_REPPINCODE", Convert.ToInt32(objCFOEntrepreneur.AuthRep_Pincode));
                com.Parameters.AddWithValue("@CFOID_REPISDIFFABLED", objCFOEntrepreneur.AuthRep_DiffAbled);
                com.Parameters.AddWithValue("@CFOID_REPISWOMANENTR", objCFOEntrepreneur.AuthRep_Woman);

                com.Parameters.AddWithValue("@CFOID_DEVELOPAREA", Convert.ToDecimal(objCFOEntrepreneur.DevelopmentArea));

                com.Parameters.AddWithValue("@CFOID_ARCHTCTNAME", objCFOEntrepreneur.ArchitechtureName);
                com.Parameters.AddWithValue("@CFOID_ARCHTCTLICNO", objCFOEntrepreneur.ArchitechtureLICNo);
                com.Parameters.AddWithValue("@CFOID_ARCHTCTMOBILE", Convert.ToInt64(objCFOEntrepreneur.ArchitechtureMobileNo));
                com.Parameters.AddWithValue("@CFOID_SRTCTENGNRNAME", objCFOEntrepreneur.strctralName);
                com.Parameters.AddWithValue("@CFOID_SRTCTENGNRLICNO", objCFOEntrepreneur.strctralLicNo);
                com.Parameters.AddWithValue("@CFOID_SRTCTENGNRMOBILE", Convert.ToInt64(objCFOEntrepreneur.strctralMobileNo));

                com.Parameters.AddWithValue("@CFOID_APPROACHROADTYPE", objCFOEntrepreneur.ApprchRdType);
                com.Parameters.AddWithValue("@CFOID_APPROACHROADWIDTH", Convert.ToDecimal(objCFOEntrepreneur.ApprchRdWidth));
                com.Parameters.AddWithValue("@CFOID_AFFECTEDRDWDNG", objCFOEntrepreneur.AffectedRdWdng);
                com.Parameters.AddWithValue("@CFOID_AFFECTEDRDAREA", objCFOEntrepreneur.AffectedExtended);

                com.Parameters.AddWithValue("@CFOID_TOTALEMP", Convert.ToInt32(objCFOEntrepreneur.TotalEmp));

                com.Parameters.AddWithValue("@CFOID_DIRECTMALE", Convert.ToInt32(objCFOEntrepreneur.DirectMale));
                com.Parameters.AddWithValue("@CFOID_DIRECTFEMALE", Convert.ToInt32(objCFOEntrepreneur.DirectFemale));
                com.Parameters.AddWithValue("@CFOID_DIRECTOTHERS", Convert.ToInt32(objCFOEntrepreneur.DirectOthers));

                com.Parameters.AddWithValue("@CFOID_INDIRECTMALE", Convert.ToInt32(objCFOEntrepreneur.InDirectMale));
                com.Parameters.AddWithValue("@CFOID_INDIRECTFEMALE", Convert.ToInt32(objCFOEntrepreneur.InDirectFemale));
                com.Parameters.AddWithValue("@CFOID_INDIRECTOTHERS", Convert.ToInt32(objCFOEntrepreneur.InDirectOthers));

                com.Parameters.AddWithValue("@CFOID_RDCUTLENGTH", objCFOEntrepreneur.RoadCut);
                com.Parameters.AddWithValue("@CFOID_RDCUTLOCATIONS", objCFOEntrepreneur.RoadCutLocation);


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertCFOLineofManf(CFOLineOfManuf objCFOManufacture)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOManufactureDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFOLM_CREATEDBY", Convert.ToInt32(objCFOManufacture.CreatedBy));
                com.Parameters.AddWithValue("@CFOLM_CREATEDBYIP", objCFOManufacture.IPAddress);
                com.Parameters.AddWithValue("@CFOLM_CFOQDID", Convert.ToInt32(objCFOManufacture.Questionnareid));
                com.Parameters.AddWithValue("@CFOLM_UNITID", Convert.ToInt32(objCFOManufacture.UnitID));
                com.Parameters.AddWithValue("@CFOLM_LOAID", Convert.ToInt32(objCFOManufacture.LOAID));
                com.Parameters.AddWithValue("@CFOLM_ITEMNAME", objCFOManufacture.ManfItemName);
                com.Parameters.AddWithValue("@CFOLM_ITEMANNUALCAPACITY", Convert.ToDecimal(objCFOManufacture.ManfItemAnnualCapacity));
                com.Parameters.AddWithValue("@CFOLM_ITEMVALUE", Convert.ToDecimal(objCFOManufacture.ManfItemValue));

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertCFORawMaterial(CFOLineOfManuf objCFOManufacture)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFORAWMaterialDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFORM_CREATEDBY", Convert.ToInt32(objCFOManufacture.CreatedBy));
                com.Parameters.AddWithValue("@CFORM_CREATEDBYIP", objCFOManufacture.IPAddress);
                com.Parameters.AddWithValue("@CFORM_CFOQDID", Convert.ToInt32(objCFOManufacture.Questionnareid));
                com.Parameters.AddWithValue("@CFORM_UNITID", Convert.ToInt32(objCFOManufacture.UnitID));
                com.Parameters.AddWithValue("@CFORM_LOAID", Convert.ToInt32(objCFOManufacture.LOAID));
                com.Parameters.AddWithValue("@CFORM_ITEMNAME", objCFOManufacture.RMItemName);
                com.Parameters.AddWithValue("@CFORM_ITEMANNUALCAPACITY", Convert.ToDecimal(objCFOManufacture.RMItemAnnualCapacity));
                com.Parameters.AddWithValue("@CFORM_ITEMVALUE", Convert.ToDecimal(objCFOManufacture.RMItemValue));
                com.Parameters.AddWithValue("@CFORM_SOURCEOFSUPPLY", objCFOManufacture.RMSourceofSupply);


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertCFOExciseData(CFOExciseDetails data, List<CFOExciseBrandDetails> brandDetails, List<CFOExciseLiquorDetails> liquorDetails)
        {
            string res = "Fail";

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand("InsertCFOExciseData", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for CFOExciseDetails
                    cmd.Parameters.AddWithValue("@CFOunitid", data.CFOunitid);
                    cmd.Parameters.AddWithValue("@CFOQID", data.CFOQID);
                    cmd.Parameters.AddWithValue("@Artical5Selection", data.Artical5Selection);
                    cmd.Parameters.AddWithValue("@ApplicantSelection", data.ApplicantSelection);
                    cmd.Parameters.AddWithValue("@MemberSelection", data.MemberSelection);
                    cmd.Parameters.AddWithValue("@TaxSelection", data.TaxSelection);
                    cmd.Parameters.AddWithValue("@SaleTaxSelection", data.SaleTaxSelection);
                    cmd.Parameters.AddWithValue("@ProfessionSelection", data.ProfessionSelection);
                    cmd.Parameters.AddWithValue("@GovernmentSelection", data.GovernmentSelection);
                    cmd.Parameters.AddWithValue("@GovernmentDetails", data.GovernmentDetails);
                    cmd.Parameters.AddWithValue("@ViolationSelection", data.ViolationSelection);
                    cmd.Parameters.AddWithValue("@ViolationDetails", data.ViolationDetails);
                    cmd.Parameters.AddWithValue("@ConvictedSelection", data.ConvictedSelection);
                    cmd.Parameters.AddWithValue("@ConvictedDetails", data.ConvictedDetails);
                    cmd.Parameters.AddWithValue("@RenewBrand", data.RenewBrand);
                    cmd.Parameters.AddWithValue("@RegFromDate", data.RegFromDate);
                    cmd.Parameters.AddWithValue("@RegToDate", data.RegToDate);
                    cmd.Parameters.AddWithValue("@FirmAddress", data.FirmAddress);
                    cmd.Parameters.AddWithValue("@CreatedBy", data.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedIp", data.CreatedIp);
                    cmd.Parameters.AddWithValue("@UpdatedBy", data.UpdatedBy);
                    cmd.Parameters.AddWithValue("@UpdatedDate", data.UpdatedDate);
                    cmd.Parameters.AddWithValue("@UpdatedIp", data.UpdatedIp);
                    cmd.Parameters.AddWithValue("@flag", data.Flag);

                    // Convert BrandDetails to XML
                    XDocument brandDetailsXml = null;
                    if (brandDetails.Count > 0)
                    {
                        brandDetailsXml = new XDocument(
                            new XElement("BrandDetails",
                                brandDetails.ConvertAll(brand =>
                                    new XElement("BrandDetail",
                                        new XElement("NameOfBrand", brand.NameOfBrand),
                                        new XElement("Strength", brand.Strength),
                                        new XElement("Size", brand.Size),
                                        new XElement("NumberOfBottles", brand.NumberOfBottles),
                                        new XElement("MRPRs", brand.MRPRs),
                                        new XElement("BulkLiter", brand.BulkLiter),
                                        new XElement("LandOnProof", brand.LandOnProof),
                                        new XElement("BottlePlant", brand.BottlePlant),
                                        new XElement("CreatedBy", brand.CreatedBy),
                                        new XElement("CreatedIp", brand.CreatedIp),
                                        new XElement("UpdatedBy", brand.UpdatedBy),
                                        new XElement("UpdatedDate", brand.UpdatedDate),
                                        new XElement("UpdatedIp", brand.UpdatedIp),
                                        new XElement("flag", brand.Flag)
                                    )
                                )
                            )
                        );
                    }
                    // Convert LiquorDetails to XML
                    XDocument liquorDetailsXml = null;
                    if (liquorDetails != null)
                    {
                        liquorDetailsXml = new XDocument(
                            new XElement("LiquorDetails",
                                liquorDetails.ConvertAll(liquor =>
                                    new XElement("LiquorDetail",
                                        new XElement("CountryID", liquor.CountryID),
                                        new XElement("CountryName", liquor.CountryName),
                                        new XElement("MRPSSelection", liquor.MRPSSelection),
                                        new XElement("BrandName", liquor.BrandName),
                                        new XElement("CreatedBy", liquor.CreatedBy),
                                        new XElement("CreatedIp", liquor.CreatedIp),
                                        new XElement("UpdatedBy", liquor.UpdatedBy),
                                        new XElement("UpdatedDate", liquor.UpdatedDate),
                                        new XElement("UpdatedIp", liquor.UpdatedIp),
                                        new XElement("flag", liquor.Flag)
                                    )
                                )
                            )
                        );
                    }
                    cmd.Parameters.AddWithValue("@BrandDetailsXml", brandDetailsXml.ToString());
                    cmd.Parameters.AddWithValue("@LiquorDetailsXml", liquorDetailsXml == null ? "" : liquorDetailsXml.ToString());

                    conn.Open();
                    int cnt = cmd.ExecuteNonQuery();
                    if (cnt > 0)
                    {
                        res = "Success";
                    }
                }
            }
            return res;
        }
        public CFOExciseDetails GetCFOExciseData(int CFOunitid, int CFOQID)
        {
            CFOExciseDetails data = new CFOExciseDetails();
            using (SqlConnection con = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCFOExciseData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CFOunitid", CFOunitid);
                    cmd.Parameters.AddWithValue("@CFOQID", CFOQID);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Read CFOExciseDetails
                        if (reader.Read())
                        {
                            data = new CFOExciseDetails
                            {
                                CFOunitid = reader.GetInt32(0),
                                CFOQID = reader.GetInt32(1),
                                Artical5Selection = reader.GetString(2),
                                ApplicantSelection = reader.GetString(3),
                                MemberSelection = reader.GetString(4),
                                TaxSelection = reader.GetString(5),
                                SaleTaxSelection = reader.GetString(6),
                                ProfessionSelection = reader.GetString(7),
                                GovernmentSelection = reader.GetString(8),
                                GovernmentDetails = reader.IsDBNull(9) ? null : reader.GetString(9),
                                ViolationSelection = reader.GetString(10),
                                ViolationDetails = reader.IsDBNull(11) ? null : reader.GetString(11),
                                ConvictedSelection = reader.GetString(12),
                                ConvictedDetails = reader.IsDBNull(13) ? null : reader.GetString(13),
                                RenewBrand = reader.GetString(14),
                                RegFromDate = reader.IsDBNull(15) ? (DateTime?)null : reader.GetDateTime(15),
                                RegToDate = reader.IsDBNull(16) ? (DateTime?)null : reader.GetDateTime(16),
                                FirmAddress = reader.IsDBNull(17) ? null : reader.GetString(17),
                                CreatedBy = reader.GetString(18),
                                CreatedDate = reader.GetDateTime(19),
                                CreatedIp = reader.GetString(20),
                                UpdatedBy = reader.IsDBNull(21) ? null : reader.GetString(21),
                                UpdatedDate = reader.IsDBNull(22) ? (DateTime?)null : reader.GetDateTime(22),
                                UpdatedIp = reader.IsDBNull(23) ? null : reader.GetString(23),
                                Flag = reader.GetString(24)
                            };
                        }

                        // Move to next result set (CFOExciseBrandDetails)
                        if (reader.NextResult())
                        {
                            data.brandgridlist = new List<CFOExciseBrandDetails>();
                            while (reader.Read())
                            {
                                CFOExciseBrandDetails brandDetail = new CFOExciseBrandDetails
                                {
                                    CFOunitid = reader.GetInt32(0),
                                    CFOQID = reader.GetInt32(1),
                                    NameOfBrand = reader.GetString(2),
                                    Strength = reader.GetString(3),
                                    Size = reader.GetString(4),
                                    NumberOfBottles = reader.GetString(5),
                                    MRPRs = reader.GetString(6),
                                    BulkLiter = reader.GetString(7),
                                    LandOnProof = reader.GetString(8),
                                    BottlePlant = reader.GetString(9),
                                    CreatedBy = reader.GetString(10),
                                    CreatedDate = reader.GetDateTime(11),
                                    CreatedIp = reader.GetString(12),
                                    UpdatedBy = reader.IsDBNull(13) ? null : reader.GetString(13),
                                    UpdatedDate = reader.IsDBNull(14) ? (DateTime?)null : reader.GetDateTime(14),
                                    UpdatedIp = reader.IsDBNull(15) ? null : reader.GetString(15),
                                    Flag = reader.GetString(16)
                                };
                                data.brandgridlist.Add(brandDetail);
                            }
                        }

                        // Move to next result set (CFOExciseLiquorDetails)
                        if (reader.NextResult())
                        {
                            data.liquorgridlist = new List<CFOExciseLiquorDetails>();
                            while (reader.Read())
                            {
                                CFOExciseLiquorDetails liquorDetail = new CFOExciseLiquorDetails
                                {
                                    CFOunitid = reader.GetInt32(0),
                                    CFOQID = reader.GetInt32(1),
                                    CountryID = reader.GetString(2),
                                    CountryName = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    MRPSSelection = reader.GetString(4),
                                    BrandName = reader.GetString(5),
                                    CreatedBy = reader.GetString(6)
                                    //CreatedDate = reader.GetDateTime(7),
                                    //CreatedIp = reader.GetString(8),
                                    //UpdatedBy = reader.IsDBNull(9) ? null : reader.GetString(9),
                                    //UpdatedDate = reader.IsDBNull(10) ? (DateTime?)null : reader.GetDateTime(10),
                                    //UpdatedIp = reader.IsDBNull(11) ? null : reader.GetString(11),
                                    //Flag = reader.GetString(12)
                                };
                                data.liquorgridlist.Add(liquorDetail);
                            }
                        }
                    }
                }
            }
            return data;
        }

        public string InsertCFOLabourDetails(CFOLabourDet ObjCFOLabourDet)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOLabourDet;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFOLD_CREATEDBY", Convert.ToInt32(ObjCFOLabourDet.CreatedBy));
                com.Parameters.AddWithValue("@CFOLD_CREATEDBYIP", ObjCFOLabourDet.IPAddress);
                com.Parameters.AddWithValue("@CFOLD_CFOQDID", Convert.ToInt32(ObjCFOLabourDet.Questionnariid));
                com.Parameters.AddWithValue("@CFOLD_UNITID", Convert.ToInt32(ObjCFOLabourDet.UnitId));

                com.Parameters.AddWithValue("@CFOLD_DIRECTINDIRECT", ObjCFOLabourDet.DirectorateBoiler);
                com.Parameters.AddWithValue("@CFOLD_APPLIED", ObjCFOLabourDet.Classification);
                com.Parameters.AddWithValue("@CFOLD_PROVIDEDETAILS", ObjCFOLabourDet.ProvideDetails);
                com.Parameters.AddWithValue("@CFOLD_YEAR", Convert.ToInt32(ObjCFOLabourDet.Establishmentyear));
                com.Parameters.AddWithValue("@CFOLD_TEMPMATERIAL", ObjCFOLabourDet.temperature);
                com.Parameters.AddWithValue("@CFOLD_REGULATION1950", ObjCFOLabourDet.BoilerRegulation);
                com.Parameters.AddWithValue("@CFOLD_GENGRINDE", ObjCFOLabourDet.generatortool);
                com.Parameters.AddWithValue("@CFOLD_DESIGNATION", ObjCFOLabourDet.Document);
                com.Parameters.AddWithValue("@CFOLD_SITES", Convert.ToInt32(ObjCFOLabourDet.firm));
                com.Parameters.AddWithValue("@CFOLD_REGULATION81", ObjCFOLabourDet.regulationstrictly);
                com.Parameters.AddWithValue("@CFOLD_CONTROVERSIAL", ObjCFOLabourDet.controversial);
                com.Parameters.AddWithValue("@CFOLD_MATERIAL", ObjCFOLabourDet.materials);
                com.Parameters.AddWithValue("@CFOLD_OWNSYSTEM", ObjCFOLabourDet.OwnSystem);
                com.Parameters.AddWithValue("@CFOLD_UPLOADDOCUMENT", ObjCFOLabourDet.Upload_Document);
                com.Parameters.AddWithValue("@CFOLD_MANUFACTURENAME", ObjCFOLabourDet.NameManufacture);
                com.Parameters.AddWithValue("@CFOLD_MANUYEAR", Convert.ToInt32(ObjCFOLabourDet.manufactureYear));
                com.Parameters.AddWithValue("@CFOLD_MANUPLACE", ObjCFOLabourDet.manufactureplace);
                com.Parameters.AddWithValue("@CFOLD_BOILERNUMBER", Convert.ToInt32(ObjCFOLabourDet.BoilerNumber));
                com.Parameters.AddWithValue("@CFOLD_INTENDED", ObjCFOLabourDet.Intendedpressure);
                com.Parameters.AddWithValue("@CFOLD_MANUFACTUREPLACE", ObjCFOLabourDet.manufacture);
                com.Parameters.AddWithValue("@CFOLD_HEATERRATING", Convert.ToDecimal(ObjCFOLabourDet.HeaterRating));
                com.Parameters.AddWithValue("@CFOLD_ECONOMISERRATING", Convert.ToDecimal(ObjCFOLabourDet.Economiser));
                com.Parameters.AddWithValue("@CFOLD_EVAPORATION", Convert.ToDecimal(ObjCFOLabourDet.MaximumTonne));
                com.Parameters.AddWithValue("@CFOLD_REHEATERRATING", Convert.ToDecimal(ObjCFOLabourDet.RatingHeaters));
                com.Parameters.AddWithValue("@CFOLD_SEASON", ObjCFOLabourDet.WorkingSeason);
                com.Parameters.AddWithValue("@CFOLD_PRESSURE", Convert.ToDecimal(ObjCFOLabourDet.PressurePSI));
                com.Parameters.AddWithValue("@CFOLD_OWNERNAME", ObjCFOLabourDet.NameOwner);
                com.Parameters.AddWithValue("@CFOLD_TYPEBOILER", ObjCFOLabourDet.BoilerType);
                com.Parameters.AddWithValue("@CFOLD_DESCBOILER", ObjCFOLabourDet.DescriptionBoiler);
                com.Parameters.AddWithValue("@CFOLD_BOILERRATING", Convert.ToInt32(ObjCFOLabourDet.BoilerRating));
                com.Parameters.AddWithValue("@CFOLD_BOILEROWNERTRANSF", ObjCFOLabourDet.ownershipBoiler);
                com.Parameters.AddWithValue("@CFOLD_REMARK", ObjCFOLabourDet.Remarks);
                com.Parameters.AddWithValue("@CFOLD_MANUNAME", ObjCFOLabourDet.ManufactureNames);
                com.Parameters.AddWithValue("@CFOLD_MANUFACTUREYEAR", Convert.ToInt32(ObjCFOLabourDet.ManufactureYears));
                com.Parameters.AddWithValue("@CFOLD_MANUFACTPLACE", ObjCFOLabourDet.Placemanu);
                com.Parameters.AddWithValue("@CFOLD_NAMEAGENT", ObjCFOLabourDet.NameAgent);
                com.Parameters.AddWithValue("@CFOLD_ADDRESSAGENT", ObjCFOLabourDet.Address);
                com.Parameters.AddWithValue("@CFOLD_DAYSLABOUR", Convert.ToInt32(ObjCFOLabourDet.contractorlabour));
                com.Parameters.AddWithValue("@CFOLD_ESTDATE", DateTime.ParseExact( ObjCFOLabourDet.Estimateddate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFOLD_ENDDATE", DateTime.ParseExact( ObjCFOLabourDet.Endingdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFOLD_CONTRACTEMP", Convert.ToInt32(ObjCFOLabourDet.Maximumemployed));
                com.Parameters.AddWithValue("@CFOLD_FIVEYEARCONVICTED", ObjCFOLabourDet.withinfiveyear);
                com.Parameters.AddWithValue("@CFOLD_DETAILS", ObjCFOLabourDet.Details);
                com.Parameters.AddWithValue("@CFOLD_REVORKING", ObjCFOLabourDet.licenseDeposite);
                com.Parameters.AddWithValue("@CFOLD_ORDERDAET", ObjCFOLabourDet.OrderDate);
                com.Parameters.AddWithValue("@CFOLD_ESTCONTRACTOR", ObjCFOLabourDet.establishmentpast);
                com.Parameters.AddWithValue("@CFOLD_PRINCIPLEEMP", ObjCFOLabourDet.PrincipalEMP);
                com.Parameters.AddWithValue("@CFOLD_ESTDETAILS", ObjCFOLabourDet.EstablishmentDET);
                com.Parameters.AddWithValue("@CFOLD_NATUREWORK", ObjCFOLabourDet.NatureWORK);
                com.Parameters.AddWithValue("@CFOLD_MANAGERNAME", ObjCFOLabourDet.generalManagement);
                com.Parameters.AddWithValue("@CFOLD_ADDRESSMANAGER", ObjCFOLabourDet.AddressAgent);
                com.Parameters.AddWithValue("@CFOLD_CATEGORYEST", ObjCFOLabourDet.CategoryEst);
                com.Parameters.AddWithValue("@CFOLD_NATUREBUSINESS", ObjCFOLabourDet.NatureBusiness);
                com.Parameters.AddWithValue("@CFOLD_FAMILYEMP", ObjCFOLabourDet.establishmentfamily);
                com.Parameters.AddWithValue("@CFOLD_EMPEST", ObjCFOLabourDet.employeeswork);
                com.Parameters.AddWithValue("@CFOLD_TOTALEMP", Convert.ToInt32(ObjCFOLabourDet.TotalNumberEMP));


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertCFOlabourContractor(CFOLabourDet ObjCFOLabourDet)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOLabourContractorDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFOLD_CFOQDID", Convert.ToInt32(ObjCFOLabourDet.Questionnariid));
                com.Parameters.AddWithValue("@CFOLD_CREATEDBY", Convert.ToInt32(ObjCFOLabourDet.CreatedBy));
                com.Parameters.AddWithValue("@CFOLD_CREATEDBYIP", ObjCFOLabourDet.IPAddress);
                com.Parameters.AddWithValue("@CFOLD_UNITID", Convert.ToInt32(ObjCFOLabourDet.UNITID));
                com.Parameters.AddWithValue("@CFOLD_NAME", ObjCFOLabourDet.NAME);
                com.Parameters.AddWithValue("@CFOLD_GENDER", ObjCFOLabourDet.GENDER);
                com.Parameters.AddWithValue("@CFOLD_AGE", Convert.ToInt32(ObjCFOLabourDet.AGE));
                com.Parameters.AddWithValue("@CFOLD_COMMUNITY", ObjCFOLabourDet.COMMUNITY);
                com.Parameters.AddWithValue("@CFOLD_FULLADDRESS", ObjCFOLabourDet.FULLADDRESS);
                com.Parameters.AddWithValue("@CFOLD_ADDRESS", ObjCFOLabourDet.ADDRESS);
                com.Parameters.AddWithValue("@CFOLD_HALFDAY", ObjCFOLabourDet.HALFDAY);
                com.Parameters.AddWithValue("@CFOLD_FULLDAY", ObjCFOLabourDet.FULLDAY);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }

        public string InsertCFOLegalMetrologyDetails(CFOLEGALMETROLOGYDEP ObjCFOlegalDet)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOLegalMetrologyDep;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFOLGM_CREATEDBY", Convert.ToInt32(ObjCFOlegalDet.CreatedBy));
                com.Parameters.AddWithValue("@CFOLGM_CREATEDBYIP", ObjCFOlegalDet.IPAddress);
                com.Parameters.AddWithValue("@CFOLGM_CFOUNITID", Convert.ToInt32(ObjCFOlegalDet.UnitId));
                com.Parameters.AddWithValue("@CFOLGM_CFOQDID", Convert.ToInt32(ObjCFOlegalDet.Questionnariid ));

                com.Parameters.AddWithValue("@CFOLGM_ESTBLSHDATE", DateTime.ParseExact( ObjCFOlegalDet.DateEstablish, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFOLGM_HADESTBLSHREG", ObjCFOlegalDet.RegFactoryShop);
                com.Parameters.AddWithValue("@CFOLGM_ESTBLSHREGDATE",DateTime.ParseExact( ObjCFOlegalDet.DateReg, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFOLGM_ESTBLSHREGNO", ObjCFOlegalDet.CurrentRegNumber);
                com.Parameters.AddWithValue("@CFOLGM_HADMTLREG", ObjCFOlegalDet.LicADCnO);
                //com.Parameters.AddWithValue("@CFOLGM_ESTBLSHREGDATE",DateTime.ParseExact( ObjCFOlegalDet.DateReg, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFOLGM_MTLREGDATE", DateTime.ParseExact( ObjCFOlegalDet.RegDateNo, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFOLGM_MTLREGNO", ObjCFOlegalDet.RegCurrentNo);
                com.Parameters.AddWithValue("@CFOLGM_WEIGHS", ObjCFOlegalDet.Weight);
                com.Parameters.AddWithValue("@CFOLGM_MEASURES", ObjCFOlegalDet.Measures);
                com.Parameters.AddWithValue("@CFOLGM_WEIGHINGINSTR", ObjCFOlegalDet.WeightingIns);
                com.Parameters.AddWithValue("@CFOLGM_PROFTAXREGNO", ObjCFOlegalDet.ProfessionalTax);
                com.Parameters.AddWithValue("@CFOLGM_GSTREGNO", ObjCFOlegalDet.GST);
                com.Parameters.AddWithValue("@CFOLGM_ITNO", ObjCFOlegalDet.ITNUMBER);
                com.Parameters.AddWithValue("@CFOLGM_ISIMPORTING", ObjCFOlegalDet.StateCountry);
                com.Parameters.AddWithValue("@CFOLGM_IMPORTLICNO", ObjCFOlegalDet.LICNUMBER);
                com.Parameters.AddWithValue("@CFOLGM_REGOFIMPORTER", ObjCFOlegalDet.WeightMeasure);
                com.Parameters.AddWithValue("@CFOLGM_SELLINGPLACE", ObjCFOlegalDet.StateSide);
                com.Parameters.AddWithValue("@CFOLGM_SKILLEDEMP", Convert.ToInt32(ObjCFOlegalDet.Skilled));
                com.Parameters.AddWithValue("@CFOLGM_SEMISKILLEDEMP", Convert.ToInt32(ObjCFOlegalDet.SemiSkilled));
                com.Parameters.AddWithValue("@CFOLGM_UNSKILLEDEMP", Convert.ToInt32(ObjCFOlegalDet.Unskilled));
                com.Parameters.AddWithValue("@CFOLGM_TRAINEDEMP", Convert.ToInt32(ObjCFOlegalDet.SpecialistTrain));
                com.Parameters.AddWithValue("@CFOLGM_MACHINERYDETAILS", ObjCFOlegalDet.MachinaryOwn);
                com.Parameters.AddWithValue("@CFOLGM_WORKSHOPDETAILS", ObjCFOlegalDet.ownershiplong);
                com.Parameters.AddWithValue("@CFOLGM_TESTFACILITIES", ObjCFOlegalDet.FacilitiesSteel);
                com.Parameters.AddWithValue("@CFOLGM_ELCENRGYAVLBL", ObjCFOlegalDet.ElectricEnergy);
                com.Parameters.AddWithValue("@CFOLGM_LOANAVAILED", ObjCFOlegalDet.Institution);
                com.Parameters.AddWithValue("@CFOLGM_LOANBANKERS", ObjCFOlegalDet.NameBankers);
                com.Parameters.AddWithValue("@CFOLGM_LOANDETAILS", ObjCFOlegalDet.DetailsDet);
                com.Parameters.AddWithValue("@CFOLGM_MANFLICAPPLIED", ObjCFOlegalDet.LICState);
                com.Parameters.AddWithValue("@CFOLGM_MANFLICDETAILS", ObjCFOlegalDet.GiveDetailsin);
                com.Parameters.AddWithValue("@CFOLGM_DEALERLICAPPLIED", ObjCFOlegalDet.LICDeal);
                com.Parameters.AddWithValue("@CFOLGM_DEALERLICDETAILS", ObjCFOlegalDet.GiveDetails);
                com.Parameters.AddWithValue("@CFOLGM_REPAIRERLICAPPLIED", ObjCFOlegalDet.repairerLic);
                com.Parameters.AddWithValue("@CFOLGM_REPAIRERLICDETAILS", ObjCFOlegalDet.results);
                com.Parameters.AddWithValue("@CFOLGM_HADSUFFSTOCK", ObjCFOlegalDet.stock);
                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertCFOLegalMetrologyDet(CFOLEGALMETROLOGYDEP ObjCFOlegalDet)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOMetrologyDet;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFOLMI_CFOQDID", Convert.ToInt32(ObjCFOlegalDet.Questionnariid));
                com.Parameters.AddWithValue("@CFOLMI_CREATEDBY", Convert.ToInt32(ObjCFOlegalDet.CreatedBy));
                com.Parameters.AddWithValue("@CFOLMI_CREATEDBYIP", ObjCFOlegalDet.IPAddress);
                com.Parameters.AddWithValue("@CFOLMI_CFOUNITID", Convert.ToInt32(ObjCFOlegalDet.UNITID));
                com.Parameters.AddWithValue("@CFOLMI_INSTRTYPE", ObjCFOlegalDet.Instrumenttype);
                com.Parameters.AddWithValue("@CFOLMI_INSTRCLASS", ObjCFOlegalDet.Class);
                com.Parameters.AddWithValue("@CFOLMI_INSTRCAPACITY", ObjCFOlegalDet.Capacity);
                com.Parameters.AddWithValue("@CFOLMI_INSTRMAKE", ObjCFOlegalDet.Make);
                com.Parameters.AddWithValue("@CFOLMI_INSTRMODELNO", ObjCFOlegalDet.Model);
                com.Parameters.AddWithValue("@CFOLMI_INSTRSLNO", ObjCFOlegalDet.SerialNo);
                com.Parameters.AddWithValue("@CFOLMI_INSTRPRODUCT", ObjCFOlegalDet.Product);
                com.Parameters.AddWithValue("@CFOLMI_INSTRQUANTITY", ObjCFOlegalDet.Quantity);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;

        }

        public string InsertCFOProfessionalTax(CFOPROFESSIONALTAX ObjCFOPROFESSIONALTAX)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOProfessionalTax;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFOPT_CREATEDBY", Convert.ToInt32(ObjCFOPROFESSIONALTAX.CreatedBy));
                com.Parameters.AddWithValue("@CFOPT_CREATEDBYIP", ObjCFOPROFESSIONALTAX.IPAddress);
                com.Parameters.AddWithValue("@CFOPT_CFOQDID", Convert.ToInt32(ObjCFOPROFESSIONALTAX.Questionnariid));
                com.Parameters.AddWithValue("@CFOPT_CFOUNITID", Convert.ToInt32(ObjCFOPROFESSIONALTAX.UNITID));

                com.Parameters.AddWithValue("@CFOPT_ESTBLSHNAME", ObjCFOPROFESSIONALTAX.NameEst);
                com.Parameters.AddWithValue("@CFOPT_ESTBLSHADDRESS", ObjCFOPROFESSIONALTAX.AddressEst);
                com.Parameters.AddWithValue("@CFOPT_ESTBLSHDISTID", Convert.ToInt32(ObjCFOPROFESSIONALTAX.DistrictEst));
                com.Parameters.AddWithValue("@CFOPT_ESTBLSHPINCODE", Convert.ToInt32(ObjCFOPROFESSIONALTAX.PinCode));
                com.Parameters.AddWithValue("@CFOPT_ESTBLSHEMP", ObjCFOPROFESSIONALTAX.TotalEMP);
                com.Parameters.AddWithValue("@CFOPT_ESTBLSHGOODS", ObjCFOPROFESSIONALTAX.SERVIOCEEST);
                com.Parameters.AddWithValue("@CFOPT_COMMENCEDDATE",DateTime.ParseExact( ObjCFOPROFESSIONALTAX.Date, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFOPT_ANNUALINCOME", ObjCFOPROFESSIONALTAX.GrossAnnual);
                com.Parameters.AddWithValue("@CFOPT_ADDLBSNESTATE", ObjCFOPROFESSIONALTAX.BusinessPlace);
                com.Parameters.AddWithValue("@CFOPT_ADDLBSNECOUNTRY", ObjCFOPROFESSIONALTAX.BUSINESS);
                com.Parameters.AddWithValue("@CFOPT_ADDLBSNEFOREIGN", ObjCFOPROFESSIONALTAX.FORIGEN);
                com.Parameters.AddWithValue("@CFOPT_BRANCHCERTNO", ObjCFOPROFESSIONALTAX.Branch);
                com.Parameters.AddWithValue("@CFOPT_HADANYREG", ObjCFOPROFESSIONALTAX.RegUnderAct);
                com.Parameters.AddWithValue("@CFOPT_REGTYPE", ObjCFOPROFESSIONALTAX.RegistrationType);
                com.Parameters.AddWithValue("@CFOPT_REGNO", ObjCFOPROFESSIONALTAX.RegisrationNo);



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }

        public string INSERTCFOSTATETAX(CFOPROFESSIONALTAX ObjCFOPROFESSIONALTAX)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.INSERTCFOPROFESSIONALTAXSTATE;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFOPS_CREATEDBY", Convert.ToInt32(ObjCFOPROFESSIONALTAX.CreatedBy));
                com.Parameters.AddWithValue("@CFOPS_CREATEDBYIP", ObjCFOPROFESSIONALTAX.IPAddress);
                com.Parameters.AddWithValue("CFOPS_CFOUNITID", Convert.ToInt32(ObjCFOPROFESSIONALTAX.Questionnariid));
                com.Parameters.AddWithValue("@CFOPS_CFOQDID", Convert.ToInt32(ObjCFOPROFESSIONALTAX.UnitId));

                com.Parameters.AddWithValue("@CFOPS_PLACEBUSINESS", ObjCFOPROFESSIONALTAX.Business);
                com.Parameters.AddWithValue("@CFOPS_ADDRESS", ObjCFOPROFESSIONALTAX.Address);
                com.Parameters.AddWithValue("@CFOPS_DISTRIC", ObjCFOPROFESSIONALTAX.District);
                com.Parameters.AddWithValue("@CFOPS_TOTALEMP", ObjCFOPROFESSIONALTAX.TotalworkingEMP);



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }

        public string INSERTCFOCOUNTRYTAX(CFOPROFESSIONALTAX ObjCFOPROFESSIONALTAX)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.INSERTCFOPROFESSIONALTAXCOUNTRY;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFOPC_CREATEDBY", Convert.ToInt32(ObjCFOPROFESSIONALTAX.CreatedBy));
                com.Parameters.AddWithValue("@CFOPC_CREATEDBYIP", ObjCFOPROFESSIONALTAX.IPAddress);
                com.Parameters.AddWithValue("@CFOPC_CFOUNITID", Convert.ToInt32(ObjCFOPROFESSIONALTAX.Questionnariid));
                com.Parameters.AddWithValue("@CFOPC_CFOQDID", Convert.ToInt32(ObjCFOPROFESSIONALTAX.UnitId));

                com.Parameters.AddWithValue("@CFOPC_PLACEBUSINESS", ObjCFOPROFESSIONALTAX.PlaceBUSINESS);
                com.Parameters.AddWithValue("@CFOPC_ADDRESS", ObjCFOPROFESSIONALTAX.AddressEST);
                com.Parameters.AddWithValue("@CFOPC_STATE", ObjCFOPROFESSIONALTAX.State);
                com.Parameters.AddWithValue("@CFOPC_TOTALEMP", ObjCFOPROFESSIONALTAX.Totalworkingemployees);



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }

        public string INSERTCFOFOREIGNTAX(CFOPROFESSIONALTAX ObjCFOPROFESSIONALTAX)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.INSERTCFOPROFESSIONALTAXFOREIGN;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFOPF_CREATEDBY", Convert.ToInt32(ObjCFOPROFESSIONALTAX.CreatedBy));
                com.Parameters.AddWithValue("@CFOPF_CREATEDBYIP", ObjCFOPROFESSIONALTAX.IPAddress);
                com.Parameters.AddWithValue("@CFOPF_CFOUNITID", Convert.ToInt32(ObjCFOPROFESSIONALTAX.Questionnariid));
                com.Parameters.AddWithValue("@CFOPF_CFOQDID", Convert.ToInt32(ObjCFOPROFESSIONALTAX.UnitId));

                com.Parameters.AddWithValue("@CFOPF_PRINCIPLEWORK", ObjCFOPROFESSIONALTAX.PrincipalWORK);
                com.Parameters.AddWithValue("@CFOPF_ADDRESS", ObjCFOPROFESSIONALTAX.AddressWORK);
                com.Parameters.AddWithValue("@CFOPF_EMPNAME", ObjCFOPROFESSIONALTAX.EmployerName);
                com.Parameters.AddWithValue("@CFOPF_MONTHLYWAGES", ObjCFOPROFESSIONALTAX.MontlySalary);



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }

        public string InsertCFOExciseDepaertment(CFOTAXDEPARTMENT ObjCFOExcise)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOExicseDept;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFOPT_CREATEDBY", Convert.ToInt32(ObjCFOExcise.CreatedBy));
                com.Parameters.AddWithValue("@CFOPT_CREATEDBYIP", ObjCFOExcise.IPAddress);
                com.Parameters.AddWithValue("@CFOPT_CFOQDID", Convert.ToInt32(ObjCFOExcise.Questionnariid));
                com.Parameters.AddWithValue("@CFOPT_CFOUNITID", Convert.ToInt32(ObjCFOExcise.UnitId));

                com.Parameters.AddWithValue("", ObjCFOExcise);
                com.Parameters.AddWithValue("", ObjCFOExcise);
                com.Parameters.AddWithValue("", Convert.ToInt32(ObjCFOExcise));
                com.Parameters.AddWithValue("", Convert.ToInt32(ObjCFOExcise));
                com.Parameters.AddWithValue("", ObjCFOExcise);
                com.Parameters.AddWithValue("", ObjCFOExcise);
                com.Parameters.AddWithValue("", ObjCFOExcise);
                com.Parameters.AddWithValue("", ObjCFOExcise);
                com.Parameters.AddWithValue("", ObjCFOExcise);
                com.Parameters.AddWithValue("", ObjCFOExcise);
                com.Parameters.AddWithValue("", ObjCFOExcise);
                com.Parameters.AddWithValue("", ObjCFOExcise);
                com.Parameters.AddWithValue("", ObjCFOExcise);
                com.Parameters.AddWithValue("", ObjCFOExcise);
                com.Parameters.AddWithValue("", ObjCFOExcise);



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }

        public string InsertCFOFIREDEPT(HOMEDEPARTMENT ObjCFOFireDepartment)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOFireDepartment;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFOFD_CFOQDID", Convert.ToInt32(ObjCFOFireDepartment.Questionnariid));
                com.Parameters.AddWithValue("@CFOFD_CREATEDBY", Convert.ToInt32(ObjCFOFireDepartment.CreatedBy));
                com.Parameters.AddWithValue("@CFOFD_CREATEDBYIP", ObjCFOFireDepartment.IPAddress);
                com.Parameters.AddWithValue("@CFOFD_UNITID", Convert.ToInt32(ObjCFOFireDepartment.UnitId));

                com.Parameters.AddWithValue("@CFOFD_BUILDNAME", ObjCFOFireDepartment.BuildingName);
                com.Parameters.AddWithValue("@CFOFD_CATEGORYBUILD", ObjCFOFireDepartment.CategoryBuild);
                com.Parameters.AddWithValue("@CFOFD_FEEAMOUNT", Convert.ToDecimal(ObjCFOFireDepartment.FeeAmount));
                com.Parameters.AddWithValue("@CFOFD_DISTRICID", Convert.ToInt32(ObjCFOFireDepartment.District));
                com.Parameters.AddWithValue("@CFOFD_MANDALID", Convert.ToInt32(ObjCFOFireDepartment.Mandal));
                com.Parameters.AddWithValue("@CFOFD_VILLAGEID", Convert.ToInt32(ObjCFOFireDepartment.Village));
                com.Parameters.AddWithValue("@CFOFD_Locality", ObjCFOFireDepartment.Locality);
                com.Parameters.AddWithValue("@CFOFD_Landmark", ObjCFOFireDepartment.Landmark);
                com.Parameters.AddWithValue("@CFOFD_Pincode", Convert.ToInt32(ObjCFOFireDepartment.Pincode));
                com.Parameters.AddWithValue("@CFOFD_PLOTAREA", Convert.ToDecimal(ObjCFOFireDepartment.PlotArea));
                com.Parameters.AddWithValue("@CFOFD_DRIVEPROPSED", Convert.ToDecimal(ObjCFOFireDepartment.Breadth));
                com.Parameters.AddWithValue("@CFOFD_BUILDUPAREA ", Convert.ToDecimal(ObjCFOFireDepartment.BuildUpArea));
                com.Parameters.AddWithValue("@CFOFD_EXISTINGROAD", Convert.ToDecimal(ObjCFOFireDepartment.RoadApproach));
                com.Parameters.AddWithValue("@CFOFD_East ", Convert.ToDecimal(ObjCFOFireDepartment.East));
                com.Parameters.AddWithValue("@CFOFD_West ", Convert.ToDecimal(ObjCFOFireDepartment.West));
                com.Parameters.AddWithValue("@CFOFD_North", Convert.ToDecimal(ObjCFOFireDepartment.North));
                com.Parameters.AddWithValue("@CFOFD_South", Convert.ToDecimal(ObjCFOFireDepartment.South));
                com.Parameters.AddWithValue("@CFOFD_DISTANCEEAST ", Convert.ToDecimal(ObjCFOFireDepartment.DistanceEAST));
                com.Parameters.AddWithValue("@CFOFD_DISTANCEWEST ", Convert.ToDecimal(ObjCFOFireDepartment.DistanceWEST));
                com.Parameters.AddWithValue("@CFOFD_DISTANCENORTH", Convert.ToDecimal(ObjCFOFireDepartment.DistanceNORTH));
                com.Parameters.AddWithValue("@CFOFD_DISTANCESOUTH", Convert.ToDecimal(ObjCFOFireDepartment.DistanceSOUTH));
                com.Parameters.AddWithValue("@CFOFD_FIRESTATION", Convert.ToDecimal(ObjCFOFireDepartment.FireStation));


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }

        public string InsertCFOPollutionControlBoard(PollutionControlBoard ObjCFOPollutionControl)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertPollutionControlBoardDet;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFOBN_CREATEDBY", Convert.ToInt32(ObjCFOPollutionControl.CreatedBy));
                com.Parameters.AddWithValue("@CFOBN_CREATEDBYIP", ObjCFOPollutionControl.IPAddress);
                com.Parameters.AddWithValue("@CFOBN_CFOQDID", Convert.ToInt32(ObjCFOPollutionControl.Questionnariid));
                com.Parameters.AddWithValue("@CFOBN_UNITID ", Convert.ToInt32(ObjCFOPollutionControl.UnitId));

                com.Parameters.AddWithValue("@CFOBN_MAINCATEGORY", ObjCFOPollutionControl.MainCategory);
                com.Parameters.AddWithValue("@CFOBN_SUBCATEGORY", ObjCFOPollutionControl.SubCategory);
                com.Parameters.AddWithValue("@CFOBN_FEE", Convert.ToDecimal(ObjCFOPollutionControl.Fees));




                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }

        public string InsertCFOPollutioncontrol(PollutionControlBoard ObjCFOPollutionControl)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOPollutioncontrolDet;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFOB_CREATEDBY", Convert.ToInt32(ObjCFOPollutionControl.CreatedBy));
                com.Parameters.AddWithValue("@CFOB_CREATEDBYIP", ObjCFOPollutionControl.IPAddress);
                com.Parameters.AddWithValue("@CFOB_CFOQDID", Convert.ToInt32(ObjCFOPollutionControl.Questionnariid));
                com.Parameters.AddWithValue("@CFOB_UNITID", Convert.ToInt32(ObjCFOPollutionControl.UnitId));

                com.Parameters.AddWithValue("@CFOB_ESTBDATE", DateTime.ParseExact( ObjCFOPollutionControl.DateEst, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFOB_STALLLOCATION", ObjCFOPollutionControl.LocationStall);
                com.Parameters.AddWithValue("@CFOB_HOLDINGNO", ObjCFOPollutionControl.HoldingNumber);
                com.Parameters.AddWithValue("@CFOB_MARKETNAME", ObjCFOPollutionControl.MarketName);
                com.Parameters.AddWithValue("@CFOB_ESTBDISTRICT", ObjCFOPollutionControl.DistrictEST);
                com.Parameters.AddWithValue("@CFOB_STALLNO", ObjCFOPollutionControl.Stallnumber);
                com.Parameters.AddWithValue("@CFOB_ANYBUSINESS", ObjCFOPollutionControl.Municipality);
                com.Parameters.AddWithValue("@CFOB_BUSINESSDETAILS", ObjCFOPollutionControl.Details);
                com.Parameters.AddWithValue("@CFOB_ANNUALGROSSTURNOVER", ObjCFOPollutionControl.AnnualGross);
                com.Parameters.AddWithValue("@CFOB_TOTALFEE", ObjCFOPollutionControl.TotalAmount);



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertCFOPublicworkDetails(PublicWorKDepartment ObjCFOWorkDepartment)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOPublicWorkDep;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFOWC_CREATEDBY", Convert.ToInt32(ObjCFOWorkDepartment.CreatedBy));
                com.Parameters.AddWithValue("@CFOWC_CREATEDBYIP", ObjCFOWorkDepartment.IPAddress);
                com.Parameters.AddWithValue("@CFOWC_CFOQDID", Convert.ToInt32(ObjCFOWorkDepartment.Questionnariid));
                com.Parameters.AddWithValue("@CFOWC_UNITID", Convert.ToInt32(ObjCFOWorkDepartment.UnitId));

                com.Parameters.AddWithValue("@CFOWC_APPLPURPOSE", ObjCFOWorkDepartment.PurposeApplicant);
                com.Parameters.AddWithValue("@CFOWC_CONTRREGCLASS", ObjCFOWorkDepartment.ContractorReg);
                com.Parameters.AddWithValue("@CFOWC_DIRECTORATE", ObjCFOWorkDepartment.Director);
                com.Parameters.AddWithValue("@CFOWC_CIRCLE", ObjCFOWorkDepartment.Circle);
                com.Parameters.AddWithValue("@CFOWC_DIVISION", ObjCFOWorkDepartment.Division);
                com.Parameters.AddWithValue("@CFOWC_CONTRBANKNAME", ObjCFOWorkDepartment.BankerName);
                com.Parameters.AddWithValue("@CFOWC_CONTRTURNOVER", Convert.ToDecimal(ObjCFOWorkDepartment.Turnover));
                com.Parameters.AddWithValue("@CFOWC_CONTR3YRSTURNOVER", Convert.ToDecimal(ObjCFOWorkDepartment.financialYear));
                com.Parameters.AddWithValue("@CFOWC_CONTRSTARTDATE", DateTime.ParseExact( ObjCFOWorkDepartment.Datework, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));




                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string INSERTCFOManufactureDetails(CFOHealthyWelfare ObjCFOHealthyWelfare)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.IncerstCFOManufactureDet;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFODM_CREATEDBY", Convert.ToInt32(ObjCFOHealthyWelfare.CreatedBy));
                com.Parameters.AddWithValue("@CFODM_CREATEDBYIP", ObjCFOHealthyWelfare.IPAddress);
                com.Parameters.AddWithValue("@CFODM_CFOQDID", Convert.ToInt32(ObjCFOHealthyWelfare.Questionnariid));
                com.Parameters.AddWithValue("@CFODM_UNITID", Convert.ToInt32(ObjCFOHealthyWelfare.UnitId));

                com.Parameters.AddWithValue("@CFODM_EMPNAME", ObjCFOHealthyWelfare.ManufName);
                com.Parameters.AddWithValue("@CFODM_EMPQLFCATION", ObjCFOHealthyWelfare.ManufQualification);
                com.Parameters.AddWithValue("@CFODM_EMPEXPRNC", ObjCFOHealthyWelfare.ManufExperience);




                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string INSERTCFOTestingDetails(CFOHealthyWelfare ObjCFOHealthyWelfare)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.IncerstCFOTestingDet;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFODT_CREATEDBY", Convert.ToInt32(ObjCFOHealthyWelfare.CreatedBy));
                com.Parameters.AddWithValue("@CFODT_CREATEDBYIP", ObjCFOHealthyWelfare.IPAddress);
                com.Parameters.AddWithValue("@CFODT_CFOQDID", Convert.ToInt32(ObjCFOHealthyWelfare.Questionnariid));
                com.Parameters.AddWithValue("@CFODT_UNITID", Convert.ToInt32(ObjCFOHealthyWelfare.UnitId));

                com.Parameters.AddWithValue("@CFODT_EMPNAME", ObjCFOHealthyWelfare.testingName);
                com.Parameters.AddWithValue("@CFODT_EMPQLFCATION", ObjCFOHealthyWelfare.testingQualification);
                com.Parameters.AddWithValue("@CFODT_EMPEXPRNC", ObjCFOHealthyWelfare.testingExperience);


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertCFODRUGLICDetails(CFOHealthyWelfare ObjCFOHealthyWelfare)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFODrugLicense;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFOD_CREATEDBY", Convert.ToInt32(ObjCFOHealthyWelfare.CreatedBy));
                com.Parameters.AddWithValue("@CFOD_CREATEDBYIP", ObjCFOHealthyWelfare.IPAddress);
                com.Parameters.AddWithValue("@CFOD_CFOQDID", Convert.ToInt32(ObjCFOHealthyWelfare.Questionnariid));
                com.Parameters.AddWithValue("@CFOD_UNITID", Convert.ToInt32(ObjCFOHealthyWelfare.UnitId));

                com.Parameters.AddWithValue("@CFOD_DRUGNAME", ObjCFOHealthyWelfare.NameDrug);



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertCFODrugLicenseDet(CFOHealthyWelfare ObjCFOHealthyWelfare)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFODrugLicenseDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFODL_CREATEDBY", Convert.ToInt32(ObjCFOHealthyWelfare.CreatedBy));
                com.Parameters.AddWithValue("@CFODL_CREATEDBYIP", ObjCFOHealthyWelfare.IPAddress);
                com.Parameters.AddWithValue("@CFODL_CFOQDID", Convert.ToInt32(ObjCFOHealthyWelfare.Questionnariid));
                com.Parameters.AddWithValue("@CFODL_UNITID", Convert.ToInt32(ObjCFOHealthyWelfare.UnitId));

                com.Parameters.AddWithValue("@CFODL_APPLTYPE", ObjCFOHealthyWelfare.TypeApplication);
                com.Parameters.AddWithValue("@CFODL_TRADELICVALDTYDATE", DateTime.ParseExact( ObjCFOHealthyWelfare.TradingLICDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFODL_MUNCPERMVALDTYDATE",DateTime.ParseExact( ObjCFOHealthyWelfare.Valideuptodate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFODL_COLDSTORGDETAILS", ObjCFOHealthyWelfare.coldstorage);
                com.Parameters.AddWithValue("@CFODL_ANYPREVLIC", ObjCFOHealthyWelfare.cancelledlicense);
                com.Parameters.AddWithValue("@CFODL_PREVLICDETAILS", ObjCFOHealthyWelfare.specifylicense);
                com.Parameters.AddWithValue("@CFODL_PREMISERDYFORINSP", ObjCFOHealthyWelfare.readyinspection);
                com.Parameters.AddWithValue("@CFODL_DATEOFINSP",DateTime.ParseExact( ObjCFOHealthyWelfare.inceptionDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));




                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertCFODepartmentApprovals(CFOQuestionnaireDet objCFOQsnaire)
        {
            string Result = "";

            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            //connection.Open();
            //transaction = connection.BeginTransaction();
            try
            {

                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFODepartmentapprovals;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFODA_UNITID", Convert.ToInt32(objCFOQsnaire.UNITID));
                com.Parameters.AddWithValue("@CFODA_CFOQDID", Convert.ToInt32(objCFOQsnaire.CFEQDID));
                com.Parameters.AddWithValue("@CFODA_DEPTID", Convert.ToInt32(objCFOQsnaire.DeptID));
                com.Parameters.AddWithValue("@CFODA_APPROVALID", Convert.ToInt32(objCFOQsnaire.ApprovalID));
                com.Parameters.AddWithValue("@CFODA_APPROVALFEE", Convert.ToDecimal(objCFOQsnaire.ApprovalFee));
                com.Parameters.AddWithValue("@CFODA_ISOFFLINE", objCFOQsnaire.IsOffline);
                com.Parameters.AddWithValue("@CFODA_CREATEDBY", Convert.ToInt32(objCFOQsnaire.CreatedBy));
                com.Parameters.AddWithValue("@CFODA_CREATEDBYIP", objCFOQsnaire.IPAddress);

                int DAID = Convert.ToInt32(com.ExecuteScalar());
                transaction.Commit();
                connection.Close();
                Result = Convert.ToString(DAID);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public DataSet GetCFOAlreadyObtainedApprovals(string userid, string UnitID, string CfoQid, string IsOffline)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFOObtainedOffline, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFOObtainedOffline;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@CRETAEDBY", Convert.ToInt32(userid));
                da.SelectCommand.Parameters.AddWithValue("@CFOQDID", Convert.ToInt32(CfoQid));
                da.SelectCommand.Parameters.AddWithValue("@ISOFFLINE", IsOffline);

                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetApprovalsReqFromTable(CFOQuestionnaireDet objCFOQsnaire)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetApprovalsReqFromTable, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetApprovalsReqFromTable;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(objCFOQsnaire.UNITID));
                da.SelectCommand.Parameters.AddWithValue("@CRETAEDBY", Convert.ToInt32(objCFOQsnaire.CreatedBy));
                da.SelectCommand.Parameters.AddWithValue("@CFOQDID", Convert.ToInt32(objCFOQsnaire.CFOQDID));

                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public string InsertQuestionnaireCFO(CFOQuestionnaireDet objCFOQsnaire)
        {
            string Result = "";

            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOQuestionnaire;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFOQD_UNITID", Convert.ToInt32(objCFOQsnaire.UNITID));
                com.Parameters.AddWithValue("@CFOQD_PREREGUIDNO", objCFOQsnaire.PREREGUIDNO);
                com.Parameters.AddWithValue("@CFOQD_APPLSTATUS", 2);
                com.Parameters.AddWithValue("@CFOQD_COMPANYNAME", objCFOQsnaire.CompanyName);
                com.Parameters.AddWithValue("@CFOQD_COMPANYTYPE", Convert.ToInt32(objCFOQsnaire.CompanyType));
                com.Parameters.AddWithValue("@CFOQD_PROPOSALFOR", objCFOQsnaire.ProposalFor);
                com.Parameters.AddWithValue("@CFOQD_MIDCLLAND", Convert.ToInt32(objCFOQsnaire.LandFromMIDCL));
                com.Parameters.AddWithValue("@CFOQD_PROPDISTRICTID", Convert.ToInt32(objCFOQsnaire.PropLocDitrictID));
                com.Parameters.AddWithValue("@CFOQD_PROPMANDALID", Convert.ToInt32(objCFOQsnaire.PropLocMandalID));
                com.Parameters.AddWithValue("@CFOQD_PROPVILLAGEID", Convert.ToInt32(objCFOQsnaire.PropLocVillageID));
                com.Parameters.AddWithValue("@CFOQD_TOTALEXTENTLAND", Convert.ToDecimal(objCFOQsnaire.ExtentofLand));
                com.Parameters.AddWithValue("@CFOQD_BUILTUPAREA", Convert.ToDecimal(objCFOQsnaire.BuiltUpArea));
                com.Parameters.AddWithValue("@CFOQD_SECTOR", objCFOQsnaire.SectorName);
                com.Parameters.AddWithValue("@CFOQD_LOAID", Convert.ToInt32(objCFOQsnaire.Lineofacitivityid));
                com.Parameters.AddWithValue("@CFOQD_PCBCATEGORY", objCFOQsnaire.PCBCategory);
                com.Parameters.AddWithValue("@CFOQD_INDUSTRYTYPE", objCFOQsnaire.NatureofActivity);
                com.Parameters.AddWithValue("@CFOQD_UNTLOCATION", objCFOQsnaire.UnitLocation);
                com.Parameters.AddWithValue("@CFOQD_PROPEMP", Convert.ToInt32(objCFOQsnaire.PropEmployment));
                com.Parameters.AddWithValue("@CFOQD_LANDVALUE", Convert.ToDecimal(objCFOQsnaire.LandValue));
                com.Parameters.AddWithValue("@CFOQD_BUILDINGVALUE", Convert.ToDecimal(objCFOQsnaire.BuildingValue));
                com.Parameters.AddWithValue("@CFOQD_PMCOST", Convert.ToDecimal(objCFOQsnaire.PlantnMachineryCost));
                com.Parameters.AddWithValue("@CFOQD_EXPECTEDTURNOVER", Convert.ToDecimal(objCFOQsnaire.ExpectedTurnover));
                com.Parameters.AddWithValue("@CFOQD_TOTALPROJCOST", Convert.ToDecimal(objCFOQsnaire.TotalProjCost));
                com.Parameters.AddWithValue("@CFOQD_ENTERPRISETYPE", objCFOQsnaire.EnterpriseCategory);
                com.Parameters.AddWithValue("@CFOQD_LABOURACT2020", objCFOQsnaire.LabourAct2020);
                com.Parameters.AddWithValue("@CFOQD_BOILERMANFREG", objCFOQsnaire.BoilerManfreg);
                com.Parameters.AddWithValue("@CFOQD_WORKCONTRACTORSREG", objCFOQsnaire.WorkContractorsReg);
                com.Parameters.AddWithValue("@CFOQD_BOILERREG", objCFOQsnaire.BoilerReg);
                com.Parameters.AddWithValue("@CFOQD_FACTORYLICENCE", objCFOQsnaire.FactoryLicence);
                com.Parameters.AddWithValue("@CFOQD_LABOURACT1979", objCFOQsnaire.Labouract1979);
                com.Parameters.AddWithValue("@CFOQD_LABOURACT1970", objCFOQsnaire.Labouract1970);
                com.Parameters.AddWithValue("@CFOQD_DRUGLIC", objCFOQsnaire.DrugLic);
                com.Parameters.AddWithValue("@CFOQD_WANDMREPARERLIC", objCFOQsnaire.Wandmreparerlic);
                com.Parameters.AddWithValue("@CFOQD_WANDMMANFLIC", objCFOQsnaire.Wandmmanflic);
                com.Parameters.AddWithValue("@CFOQD_WANDMDEALERLIC", objCFOQsnaire.Wandmdealerlic);
                com.Parameters.AddWithValue("@CFOQD_WANDMVERIFICATION", objCFOQsnaire.Wandmverification);
                com.Parameters.AddWithValue("@CFOQD_FIRESAFTYCERT", objCFOQsnaire.Firesaftycert);
                com.Parameters.AddWithValue("@CFOQD_EXCISELIC", objCFOQsnaire.Exciselic);
                com.Parameters.AddWithValue("@CFOQD_DRUGLICCONSTCHANGE", objCFOQsnaire.Druglicconstchange);
                com.Parameters.AddWithValue("@CFOQD_BRANDLABELREG", objCFOQsnaire.Brandlabelreg);
                com.Parameters.AddWithValue("@CFOQD_DRUGLICMANFFORTEST", objCFOQsnaire.Druglicmanffortest);
                com.Parameters.AddWithValue("@CFOQD_DRUGLOANLICMANFSHEDULEC", objCFOQsnaire.Drugloanlicmanfshedulec);
                com.Parameters.AddWithValue("@CFOQD_DRUGLOANLICMANFNOTSHEDULEC", objCFOQsnaire.Drugloanlicmanfnotshedulec);
                com.Parameters.AddWithValue("@CFOQD_DRUGLICREPACKSALE", objCFOQsnaire.Druglicrepacksale);
                com.Parameters.AddWithValue("@CFOQD_DRUGLICMANFSALEVACCNOTSHEDULEX", objCFOQsnaire.Druglicmanfsalevaccnotshedulex);
                com.Parameters.AddWithValue("@CFOQD_PROFTAXCERT", objCFOQsnaire.Proftaxcert);
                com.Parameters.AddWithValue("@CFOQD_CFOPCB", objCFOQsnaire.Cfopcb);
                com.Parameters.AddWithValue("@CFOQD_OCCUPANCYCERT", objCFOQsnaire.Occupancycert);
                com.Parameters.AddWithValue("@CFOQD_BOILERSTMPIPELINEERECTION", objCFOQsnaire.Boilerstmpipelineerection);
                com.Parameters.AddWithValue("@CFOQD_BOILERSTMPIPELINEREGISTRATION", objCFOQsnaire.Boilerstmpipelineregistration);
                com.Parameters.AddWithValue("@CFOQD_SHPSESTBREG_FORMA", objCFOQsnaire.Shpsestbreg_forma);
                com.Parameters.AddWithValue("@CFOQD_BUSINESSSLIC", objCFOQsnaire.Businessslic);
                com.Parameters.AddWithValue("@CFOQD_LIQUORLIC", objCFOQsnaire.Liquorlic);
                com.Parameters.AddWithValue("@CFOQD_STATEEXCISEVERFCERT", objCFOQsnaire.Stateexciseverfcert);
                com.Parameters.AddWithValue("@CFOQD_CREATEDBY", Convert.ToInt32(objCFOQsnaire.CreatedBy));
                com.Parameters.AddWithValue("@CFOQD_CREATEDBYIP", objCFOQsnaire.IPAddress);
                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public DataSet GetApprovalsReqWithFee(CFOQuestionnaireDet objCFOQ)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFOApprovalsReq, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFOApprovalsReq;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@ENTPRISETYPE", objCFOQ.EnterpriseCategory);
                da.SelectCommand.Parameters.AddWithValue("@APPROVALID", objCFOQ.ApprovalID);
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetIndustryRegDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFORegDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFORegDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(userid));
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));

                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public string InsertCFOQuestionnaireApprovals(CFOQuestionnaireDet objCFOQsnaire)
        {
            string Result = "";

            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            //connection.Open();
            //transaction = connection.BeginTransaction();
            try
            {

                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOQuestionnaireApprovals;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFOQDID", Convert.ToInt32(objCFOQsnaire.CFOQDID));
                com.Parameters.AddWithValue("@CFOQA_DEPTID", Convert.ToInt32(objCFOQsnaire.DeptID));
                com.Parameters.AddWithValue("@CFOQA_APPROVALID", Convert.ToInt32(objCFOQsnaire.ApprovalID));
                com.Parameters.AddWithValue("@CFOQA_APPROVALFEE", Convert.ToDecimal(objCFOQsnaire.ApprovalFee));
                com.Parameters.AddWithValue("@CFOQA_CREATEDBY", Convert.ToInt32(objCFOQsnaire.CreatedBy));
                com.Parameters.AddWithValue("@CFOQA_CREATEDBYIP", objCFOQsnaire.IPAddress);
                com.Parameters.AddWithValue("@CFOQA_UNITID", Convert.ToInt32(objCFOQsnaire.UNITID));

                int QAID = Convert.ToInt32(com.ExecuteScalar());
                transaction.Commit();
                connection.Close();
                Result = Convert.ToString(QAID);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public DataSet RetrieveQuestionnaireDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.RetrieveQuestionnaire, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.RetrieveQuestionnaire;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));

                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetPaymentAmounttoPay(string userid, string UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFEApprovalsAmounttoPay, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFEApprovalsAmounttoPay;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UNITID));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public string InsertPaymentDetails(CFOPayments objpay)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertPaymentDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFOPD_UNITID", Convert.ToInt32(objpay.UNITID));
                com.Parameters.AddWithValue("@CFOPD_CFOQDID", Convert.ToInt32(objpay.Questionnareid));
                com.Parameters.AddWithValue("@CFOPD_UIDNO", objpay.CFEUID);
                com.Parameters.AddWithValue("@CFOPD_DEPTID", objpay.DeptID);
                com.Parameters.AddWithValue("@CFOPD_APPROVALID", Convert.ToInt32(objpay.ApprovalID));
                com.Parameters.AddWithValue("@CFOPD_ONLINEORDERNO", objpay.OnlineOrderNo);
                com.Parameters.AddWithValue("@CFOPD_ONLINEAMOUNT", objpay.OnlineOrderAmount);
                com.Parameters.AddWithValue("@CFOPD_PAYMENTFLAG", objpay.PaymentFlag);
                com.Parameters.AddWithValue("@CFOPD_TRANSACTIONNO", objpay.TransactionNo);
                com.Parameters.AddWithValue("@CFOPD_BANKNAME", objpay.BankName);
                com.Parameters.AddWithValue("@CFOPD_TRANSACTIONDATE", objpay.TransactionDate);
                com.Parameters.AddWithValue("@CFOPD_CRETAEDBY", Convert.ToInt32(objpay.CreatedBy));
                com.Parameters.AddWithValue("@CFOPD_CRETAEDBYIP", objpay.IPAddress);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertCFOAttachments(CFOAttachments objAttachments)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOAttachments;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFOA_UNITID", Convert.ToInt32(objAttachments.UNITID));
                com.Parameters.AddWithValue("@CFOA_CFOQDID", Convert.ToInt32(objAttachments.Questionnareid));
                com.Parameters.AddWithValue("@CFOA_MASTERAID", objAttachments.MasterID);
                com.Parameters.AddWithValue("@CFOA_FILEPATH", objAttachments.FilePath);
                com.Parameters.AddWithValue("@CFOA_FILENAME", objAttachments.FileName);
                com.Parameters.AddWithValue("@CFOA_FILETYPE", objAttachments.FileType);
                com.Parameters.AddWithValue("@CFOA_FILEDESCRIPTION", objAttachments.FileDescription);
                com.Parameters.AddWithValue("@CFOA_DEPTID", objAttachments.DeptID);
                com.Parameters.AddWithValue("@CFOA_APPROVALID", objAttachments.ApprovalID);
                com.Parameters.AddWithValue("@CFOA_CREATEDBY", Convert.ToInt32(objAttachments.CreatedBy));
                com.Parameters.AddWithValue("@CFOA_CREATEDBYIP", objAttachments.IPAddress);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }

        public DataSet GetCFEApprovedandCFOAppliedApplications(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFEApprovedandCFOAppliedApplications, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFEApprovedandCFOAppliedApplications;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", UnitID);
                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", userid);
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetApprovalDataByDeptId(string CFOQDID, string UNITID, string DEPTID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetApprovalDataByDeptId, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetApprovalDataByDeptId;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@CFOQDID", CFOQDID);
                da.SelectCommand.Parameters.AddWithValue("@UNITID", UNITID);
                da.SelectCommand.Parameters.AddWithValue("@DEPTID", DEPTID);
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetCFOTracker(string UserID, string UnitID, string Type)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFOTracker, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFOTracker;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@USERID", UserID);
                da.SelectCommand.Parameters.AddWithValue("@UNITID", UnitID);
                da.SelectCommand.Parameters.AddWithValue("@TYPE", Type);
                da.Fill(ds);

                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return ds;
        }

        public DataSet GetUserCFOApplStatus(string Userid, string UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetUserCFOApplStatus, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetUserCFOApplStatus;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UNITID));
                da.SelectCommand.Parameters.AddWithValue("@USERID", Convert.ToInt32(Userid));
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        //-------------------------- DEPARTMENT STARTED HERE -------------------//

        public DataTable GetCFODashBoard(CFODtls objCFO)
        {
            DataTable dt = new DataTable();
            //string valid = "";
            //  IDno = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFODashBoard, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFODashBoard;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;


                da.SelectCommand.Parameters.AddWithValue("@USERID", objCFO.UserID);
                da.SelectCommand.Parameters.AddWithValue("@ROLEID", objCFO.Role);
                if (objCFO.deptid != null && objCFO.deptid != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@DEPTID", objCFO.deptid);
                }

                da.Fill(dt);
                if (dt.Rows.Count > 0)

                    transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return dt;
        }

        public DataTable GetCFODashBoardView(CFODtls objCFO)
        {
            string valid = "";
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFODashBoardView, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFODashBoardView;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                //PRD.deptid = 1;
                //PRD.status = 4;
                //PRD.Role = 0;

                da.SelectCommand.Parameters.AddWithValue("@USERID", objCFO.UserID);
                da.SelectCommand.Parameters.AddWithValue("@VIEWSTATUS", objCFO.ViewStatus);
                if (objCFO.deptid != null && objCFO.deptid != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@DEPTID", objCFO.deptid);
                }
                da.SelectCommand.Parameters.AddWithValue("@ROLEID", objCFO.Role);
                da.Fill(dt);
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return dt;
        }
        public DataSet GetCFOApplicationDetails(string UnitID, string InvesterID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFOApplicationDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFOApplicationDet;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(InvesterID));
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public string UpdateCFODepartmentProcess(CFODtls Objcfodtls)
        {
            string valid = "";

            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.UpdateCFODepartmentProcess;

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@UNITID", Objcfodtls.Unitid);
                com.Parameters.AddWithValue("@CFOQDID", Objcfodtls.Questionnaireid);
                if (Objcfodtls.deptid != null && Objcfodtls.deptid != 0)
                {
                    com.Parameters.AddWithValue("@DEPTID", Objcfodtls.deptid);
                }
                com.Parameters.AddWithValue("@APPROVALID", Objcfodtls.ApprovalId);
                com.Parameters.AddWithValue("@ACTIONID", Objcfodtls.status);
                com.Parameters.AddWithValue("@REMARKS", Objcfodtls.Remarks);
                com.Parameters.AddWithValue("@CFODA_SCRUTINYREJECTIONFLAG", Objcfodtls.PrescrutinyRejectionFlag);
                if (Objcfodtls.AdditionalAmount != null && Objcfodtls.AdditionalAmount != "")
                {
                    com.Parameters.AddWithValue("@ADDLAMOUNT", Objcfodtls.AdditionalAmount);
                }

                com.Parameters.AddWithValue("@IPADDRESS", Objcfodtls.IPAddress);
                com.Parameters.AddWithValue("@CREATEDBY", Objcfodtls.UserID);
                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 500);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                valid = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();
            }

            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;

        }
        public DataSet GetLabourDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFOLabourDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFOLabourDet;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetLegalMeterologyDet(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFOLegalMeterologyDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFOLegalMeterologyDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetCFOContractors(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFOContractorsDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFOContractorsDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetCFODrugLicenseDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFODrugLicDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFODrugLicDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetCFODistricCouncile(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFOProffessionalTaxDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFOProffessionalTaxDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetCFOFireDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFOFireDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFOFireDet;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetCFOBusinessLicenseDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFOBusinessLicDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFOBusinessLicDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetCFOLineOfActivityDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFOLINEOFACTIVITYDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFOLINEOFACTIVITYDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));

                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public string InsertCFOLineOfActivityDetails(CFOLineOfManuf objCFOManufacture)
        //{
        //    string Result = "";
        //    SqlConnection connection = new SqlConnection(connstr);
        //    SqlTransaction transaction = null;
        //    try
        //    {
        //        connection.Open();
        //        transaction = connection.BeginTransaction();

        //        SqlCommand com = new SqlCommand();
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.CommandText = CFOConstants.InsertCFOLineOfActivityDetails;

        //        com.Transaction = transaction;
        //        com.Connection = connection;

        //        com.Parameters.AddWithValue("@CFOLA_CREATEDBY", Convert.ToInt32(objCFOManufacture.CreatedBy));
        //        com.Parameters.AddWithValue("@CFOLA_CREATEDBYIP", objCFOManufacture.IPAddress);
        //        com.Parameters.AddWithValue("@CFOLA_CFEQDID", Convert.ToInt32(objCFOManufacture.Questionnareid));
        //        com.Parameters.AddWithValue("@CFOLA_UNITID", Convert.ToInt32(objCFOManufacture.UnitID));
        //        com.Parameters.AddWithValue("@CFOLA_LINEOFACTIVITY", objCFOManufacture.LOAID);


        //        com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
        //        com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
        //        com.ExecuteNonQuery();

        //        Result = com.Parameters["@RESULT"].Value.ToString();
        //        transaction.Commit();
        //        connection.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //        connection.Dispose();
        //    }
        //    return Result;
        //}
        public DataSet GetCFOQueryDashBoard(string Unitid, string Queryid)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOConstants.GetCFOQueryDashBoard, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOConstants.GetCFOQueryDashBoard;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                //da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(InvesterID));
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(Unitid));
                if (Queryid != "" && Queryid != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@QUERYID", Convert.ToInt32(Queryid));
                }
                da.Fill(ds);
                if (ds.Tables.Count > 0)

                    transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return ds;
        }
        public string InsertCFOQueryResponse(CFOQueryDet CFOQuery)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            try
            {

                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFOConstants.InsertCFOQueryResponse;

                com.Transaction = transaction;
                com.Connection = connection;


                com.Parameters.AddWithValue("@UNITID", Convert.ToInt32(CFOQuery.Unitid));
                com.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(CFOQuery.Investerid));
                com.Parameters.AddWithValue("@CFOQDID", Convert.ToInt32(CFOQuery.Questionnariid));
                com.Parameters.AddWithValue("@QUERYID", Convert.ToInt32(CFOQuery.QueryID));
                com.Parameters.AddWithValue("@DEPTID", Convert.ToInt32(CFOQuery.Deptid));
                com.Parameters.AddWithValue("@APPROVALID", Convert.ToInt32(CFOQuery.Approvalid));
                com.Parameters.AddWithValue("@RESPONSE", CFOQuery.QueryResponse);
                com.Parameters.AddWithValue("@IPADDRESS", CFOQuery.IPAddress);


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();


            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }

    }
}
