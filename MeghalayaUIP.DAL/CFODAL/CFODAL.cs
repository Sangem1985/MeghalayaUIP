using MeghalayaUIP.Common; 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

    }
}
