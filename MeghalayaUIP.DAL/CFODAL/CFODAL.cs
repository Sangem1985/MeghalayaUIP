using MeghalayaUIP.Common; 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MeghalayaUIP.DAL.CFODAL
{
    public class CFODAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();

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
                com.Parameters.AddWithValue("@CFOLD_ESTDATE", ObjCFOLabourDet.Estimateddate);
                com.Parameters.AddWithValue("@CFOLD_ENDDATE", ObjCFOLabourDet.Endingdate);
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

    }
}
