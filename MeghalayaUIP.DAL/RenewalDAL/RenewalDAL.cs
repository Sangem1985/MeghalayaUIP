using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.DAL.RenewalDAL
{
    public class RenewalDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();
        public string InsertRENPublicWorkDep(RenPublicWorK ObjRenPublicWork)
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
                com.CommandText = RENConstants.InsertRENPublicWorkDep;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENWC_CREATEDBY", Convert.ToInt32(ObjRenPublicWork.CreatedBy));
                com.Parameters.AddWithValue("@RENWC_CREATEDBYIP", ObjRenPublicWork.IPAddress);
                com.Parameters.AddWithValue("@RENWC_CFOQDID", Convert.ToInt32(ObjRenPublicWork.Questionnariid));
                com.Parameters.AddWithValue("@RENWC_UNITID", Convert.ToInt32(ObjRenPublicWork.UnitId));

                com.Parameters.AddWithValue("@RENWC_APPLTYPE", ObjRenPublicWork.ApplicantType);
                com.Parameters.AddWithValue("@RENWC_APPLPURPOSE", ObjRenPublicWork.PurposeApplicant);
                com.Parameters.AddWithValue("@RENWC_CONTRREGCLASS", ObjRenPublicWork.ContractorReg);
                com.Parameters.AddWithValue("@RENWC_NAMEAPPL", ObjRenPublicWork.TYPENAME);
                com.Parameters.AddWithValue("@RENWC_TYPEAPPL", ObjRenPublicWork.TYPEAPPLICANT);
                com.Parameters.AddWithValue("@RENWC_DIRECTORATE", ObjRenPublicWork.Director);
                com.Parameters.AddWithValue("@RENWC_CIRCLE", ObjRenPublicWork.Circle);
                com.Parameters.AddWithValue("@RENWC_DIVISION", ObjRenPublicWork.Division);
                com.Parameters.AddWithValue("@RENWC_FATHERNAME", ObjRenPublicWork.FatherName);
                com.Parameters.AddWithValue("@RENWC_MOTHERNAME", ObjRenPublicWork.MotherName);
                com.Parameters.AddWithValue("@RENWC_DATEOFBIRTH", ObjRenPublicWork.DateofNBirth);
                com.Parameters.AddWithValue("@RENWC_POWERATTORNEY", ObjRenPublicWork.NamePower);
                com.Parameters.AddWithValue("@RENWC_PERMANENTADDRE", ObjRenPublicWork.PermanentAddress);
                com.Parameters.AddWithValue("@RENWC_FULLADDRESS", ObjRenPublicWork.FullAddress);
                com.Parameters.AddWithValue("@RENWC_NATIONALITY", ObjRenPublicWork.Nationality);
                com.Parameters.AddWithValue("@RENWC_STATEDOMICILE", ObjRenPublicWork.StateDomicile);
                com.Parameters.AddWithValue("@RENWC_MOBILENO", Convert.ToInt64(ObjRenPublicWork.MobileNo));
                com.Parameters.AddWithValue("@RENWC_SOCIALCATG", ObjRenPublicWork.SocialCat);
                com.Parameters.AddWithValue("@RENWC_EMAILID", ObjRenPublicWork.Emailid);
                com.Parameters.AddWithValue("@RENWC_CONTRBANKNAME", ObjRenPublicWork.BankerName);
                com.Parameters.AddWithValue("@RENWC_CONTRTURNOVER", Convert.ToDecimal(ObjRenPublicWork.Turnover));
                com.Parameters.AddWithValue("@RENWC_CONTR3YRSTURNOVER", Convert.ToDecimal(ObjRenPublicWork.financialYear));
                com.Parameters.AddWithValue("@RENWC_CONTRSTARTDATE", ObjRenPublicWork.Datework);




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
        public DataSet GetRenPublicWork(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(RENConstants.GetRenPublicWorkDep, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = RENConstants.GetRenPublicWorkDep;

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
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public string InsertRENDrugLicDetails(RenDrugLicDet ObjRenDrugLic)
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
                com.CommandText = RENConstants.InsertRENDrugLicDep;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENDL_CREATEDBY", Convert.ToInt32(ObjRenDrugLic.CreatedBy));
                com.Parameters.AddWithValue("@RENDL_CREATEDBYIP", ObjRenDrugLic.IPAddress);
                com.Parameters.AddWithValue("@RENDL_CFOQDID", Convert.ToInt32(ObjRenDrugLic.Questionnariid));
                com.Parameters.AddWithValue("@RENDL_UNITID", Convert.ToInt32(ObjRenDrugLic.UnitId));

                com.Parameters.AddWithValue("@RENDL_LICNO", ObjRenDrugLic.Licnumber);
                com.Parameters.AddWithValue("@RENDL_EXPIRYDATE", ObjRenDrugLic.ExpiryDate);
                com.Parameters.AddWithValue("@RENDL_LICCANCEL", ObjRenDrugLic.CancelledLic);
                com.Parameters.AddWithValue("@RENDL_LICNOSPECIFY", ObjRenDrugLic.SpecifyLicno);
                com.Parameters.AddWithValue("@RENDL_PREMISEINSPECTION", ObjRenDrugLic.PremiseInspection);
                com.Parameters.AddWithValue("@RENDL_INSPECTIONDATE", ObjRenDrugLic.DateInspection);
                com.Parameters.AddWithValue("@RENDL_TOTALAMOUNT", Convert.ToInt32(ObjRenDrugLic.TotalAmount));
                com.Parameters.AddWithValue("@RENDL_ADDITIONALFEES", Convert.ToInt32(ObjRenDrugLic.AdditionalFees));
                com.Parameters.AddWithValue("@RENDL_LATEFEES", Convert.ToInt32(ObjRenDrugLic.LateFees));
                com.Parameters.AddWithValue("@RENDL_REGFEES", Convert.ToInt32(ObjRenDrugLic.RegFees));
                com.Parameters.AddWithValue("@RENDL_TOTALPAIDAMOUNT", Convert.ToInt32(ObjRenDrugLic.TotalPaidAmount));


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
        public string InsertDrugDetails(RenDrugLicDet ObjRenDrugLic)
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
                com.CommandText = RENConstants.InsertRenDrugDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@REND_CREATEDBY", Convert.ToInt32(ObjRenDrugLic.CreatedBy));
                com.Parameters.AddWithValue("@REND_CREATEDBYIP", ObjRenDrugLic.IPAddress);
                com.Parameters.AddWithValue("@REND_CFOQDID", Convert.ToInt32(ObjRenDrugLic.Questionnariid));
                com.Parameters.AddWithValue("@REND_UNITID", Convert.ToInt32(ObjRenDrugLic.UnitId));

                com.Parameters.AddWithValue("@REND_DRUGNAME", ObjRenDrugLic.NameDrug);


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
        public string INSERTRENTestingDetails(RenDrugLicDet ObjRenDrugLic)
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
                com.CommandText = RENConstants.InsertDrugTesting;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENST_CREATEDBY", Convert.ToInt32(ObjRenDrugLic.CreatedBy));
                com.Parameters.AddWithValue("@RENST_CREATEDBYIP", ObjRenDrugLic.IPAddress);
                com.Parameters.AddWithValue("@RENSTCFOQDID", Convert.ToInt32(ObjRenDrugLic.Questionnariid));
                com.Parameters.AddWithValue("@RENST_UNITID", Convert.ToInt32(ObjRenDrugLic.UnitId));

                com.Parameters.AddWithValue("@RENST_NAME", ObjRenDrugLic.Name);
                com.Parameters.AddWithValue("@RENST_QUALIFICATION", ObjRenDrugLic.Qualification);
                com.Parameters.AddWithValue("@RENST_EXPERIENCE", ObjRenDrugLic.Experience);


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
        public string InsertRENManufacture(RenDrugLicDet ObjRenDrugLic)
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
                com.CommandText = RENConstants.InsertDrugManufactureDet;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENDM_CREATEDBY", Convert.ToInt32(ObjRenDrugLic.CreatedBy));
                com.Parameters.AddWithValue("@RENDM_CREATEDBYIP", ObjRenDrugLic.IPAddress);
                com.Parameters.AddWithValue("@RENDMCFOQDID", Convert.ToInt32(ObjRenDrugLic.Questionnariid));
                com.Parameters.AddWithValue("@RENDM_UNITID", Convert.ToInt32(ObjRenDrugLic.UnitId));

                com.Parameters.AddWithValue("@RENDM_NAME", ObjRenDrugLic.NameManu);
                com.Parameters.AddWithValue("@RENDM_QUALIFICATION", ObjRenDrugLic.QualificationManu);
                com.Parameters.AddWithValue("@RENDM_EXPERIENCE", ObjRenDrugLic.ExperienceManu);


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
        public string InsertRenDrugItemDet(RenDrugLicDet ObjRenDrugLic)
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
                com.CommandText = RENConstants.InsertRenDrugItemDet;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENDA_CREATEDBY", Convert.ToInt32(ObjRenDrugLic.CreatedBy));
                com.Parameters.AddWithValue("@RENDA_CREATEDBYIP", ObjRenDrugLic.IPAddress);
                com.Parameters.AddWithValue("@RENDA_CFOQDID", Convert.ToInt32(ObjRenDrugLic.Questionnariid));
                com.Parameters.AddWithValue("@RENDA_UNITID", Convert.ToInt32(ObjRenDrugLic.UnitId));

                com.Parameters.AddWithValue("@RENDA_ADDITIONALITEM", ObjRenDrugLic.AdditionalItem);


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
        public DataSet GetRenDrugLicDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(RENConstants.GetRENDrugLicenseDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = RENConstants.GetRENDrugLicenseDetails;

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
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public string InsertRENBusinessLicDet(RenBusinessLicDetails ObjRenBusinessLic)
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
                com.CommandText = RENConstants.InsertRenBusinessLicDet;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENBD_CREATEDBY", Convert.ToInt32(ObjRenBusinessLic.CreatedBy));
                com.Parameters.AddWithValue("@RENBD_CREATEDBYIP", ObjRenBusinessLic.IPAddress);
                com.Parameters.AddWithValue("@RENBD_RENQDID", Convert.ToInt32(ObjRenBusinessLic.Questionnariid));
                com.Parameters.AddWithValue("@RENBD_UNITID", Convert.ToInt32(ObjRenBusinessLic.UnitId));

                com.Parameters.AddWithValue("@RENBD_LICNUMBER", ObjRenBusinessLic.LICNO);
                com.Parameters.AddWithValue("@RENBD_LICISSUEDT", ObjRenBusinessLic.LICISSUEDT);
                com.Parameters.AddWithValue("@RENBD_LICVALID", ObjRenBusinessLic.LICVALID);
                com.Parameters.AddWithValue("@RENBD_NAMEOFBUSINESS", ObjRenBusinessLic.NAMEOFBUSINESS);
                com.Parameters.AddWithValue("@RENBD_ESTOWNED", ObjRenBusinessLic.ESTOWNED);
                com.Parameters.AddWithValue("@RENBD_NAMEREPRESENTATIVE", ObjRenBusinessLic.NAMEREPRESENTATIVE);
                com.Parameters.AddWithValue("@RENBD_MOBILENO", Convert.ToInt64(ObjRenBusinessLic.MOBILENO));
                com.Parameters.AddWithValue("@RENBD_EMAILID", ObjRenBusinessLic.EMAILID);
                com.Parameters.AddWithValue("@RENBD_ADDRESS", ObjRenBusinessLic.ADDRESS);
                com.Parameters.AddWithValue("@RENBD_NATUREBUSINESS", ObjRenBusinessLic.NATUREBUSINESS);
                com.Parameters.AddWithValue("@RENBD_TYPEOFEST", ObjRenBusinessLic.TYPEOFEST);

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
        public DataSet GetRenBusinessLicDet(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(RENConstants.GetRenBusinessLicDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = RENConstants.GetRenBusinessLicDetails;

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
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public string InsertRENCinemaLicDet(RenCinemaLicDetails ObjRenCinemaLicDet)
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
                com.CommandText = RENConstants.InsertRenCinemaLicDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENCD_CREATEDBY", Convert.ToInt32(ObjRenCinemaLicDet.CreatedBy));
                com.Parameters.AddWithValue("@RENCD_CREATEDBYIP", ObjRenCinemaLicDet.IPAddress);
                com.Parameters.AddWithValue("@RENCD_RENQDID", Convert.ToInt32(ObjRenCinemaLicDet.Questionnariid));
                com.Parameters.AddWithValue("@RENCD_UNITID", Convert.ToInt32(ObjRenCinemaLicDet.UnitId));

                com.Parameters.AddWithValue("@RENCD_OLDREGNO", ObjRenCinemaLicDet.OLDREGNO);
                com.Parameters.AddWithValue("@RENCD_REGDATE", ObjRenCinemaLicDet.REGDATE);
                com.Parameters.AddWithValue("@RENCD_NAMEESTCINEMA", ObjRenCinemaLicDet.NAMEESTCINEMA);
                com.Parameters.AddWithValue("@RENCD_NOCISSUEDATE", ObjRenCinemaLicDet.NOCISSUEDATE);
                com.Parameters.AddWithValue("@RENCD_NUMBERSEAT", Convert.ToInt32(ObjRenCinemaLicDet.NUMBERSEAT));
                com.Parameters.AddWithValue("@RENCD_CINEMATOGRAPHY", ObjRenCinemaLicDet.CINEMATOGRAPHY);
                com.Parameters.AddWithValue("@RENCD_BUSINESSTYPE", ObjRenCinemaLicDet.BUSINESSTYPE);
                com.Parameters.AddWithValue("@RENCD_NAMEPARTNER", ObjRenCinemaLicDet.NAMEPARTNER);
                com.Parameters.AddWithValue("@RENCD_GSTNO", ObjRenCinemaLicDet.GSTNO);
                com.Parameters.AddWithValue("@RENCD_OWNERSHIP", ObjRenCinemaLicDet.OWNERSHIP);
                com.Parameters.AddWithValue("@RENCD_DISTRIC", Convert.ToInt32(ObjRenCinemaLicDet.DISTRIC));
                com.Parameters.AddWithValue("@RENCD_MANDAL ", Convert.ToInt32(ObjRenCinemaLicDet.MANDAL));
                com.Parameters.AddWithValue("@RENCD_VILLAGE", Convert.ToInt32(ObjRenCinemaLicDet.VILLAGE));
                com.Parameters.AddWithValue("@RENCD_LOCALITY", ObjRenCinemaLicDet.LOCALITY);
                com.Parameters.AddWithValue("@RENCD_LANDMARK", ObjRenCinemaLicDet.LANDMARK);
                com.Parameters.AddWithValue("@RENCD_PINCODE ", ObjRenCinemaLicDet.Pincode);

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
        public DataSet GetRenCinemaLicDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(RENConstants.GetRenCinemaLicDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = RENConstants.GetRenCinemaLicDet;

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
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public string InsertRENContractLabourDet(RenContractLabour ObjRenContractLic)
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
                com.CommandText = RENConstants.InsertRenContractLabourDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENCLD_CREATEDBY", Convert.ToInt32(ObjRenContractLic.CreatedBy));
                com.Parameters.AddWithValue("@RENCLD_CREATEDBYIP", ObjRenContractLic.IPAddress);
                com.Parameters.AddWithValue("@RENCLD_RENQDID", Convert.ToInt32(ObjRenContractLic.Questionnariid));
                com.Parameters.AddWithValue("@RENCLD_UNITID", Convert.ToInt32(ObjRenContractLic.UnitId));

                com.Parameters.AddWithValue("@RENCLD_LICRENEWAL", ObjRenContractLic.LICRENEWAL);
                com.Parameters.AddWithValue("@RENCLD_LICISSUEDATE", ObjRenContractLic.LICISSUEDATE);
                com.Parameters.AddWithValue("@RENCLD_LICRENEWALDATE", ObjRenContractLic.LICRENEWALDATE);
                com.Parameters.AddWithValue("@RENCLD_TITLE", ObjRenContractLic.TITLE);
                com.Parameters.AddWithValue("@RENCLD_NAME", ObjRenContractLic.NAME);
                com.Parameters.AddWithValue("@RENCLD_EMAILID", ObjRenContractLic.EMAILID);
                com.Parameters.AddWithValue("@RENCLD_MOBILENO", Convert.ToInt64(ObjRenContractLic.MOBILENO));
                com.Parameters.AddWithValue("@RENCLD_FATHERNAME", ObjRenContractLic.FATHERNAME);
                com.Parameters.AddWithValue("@RENCLD_ESTNAME", ObjRenContractLic.ESTNAME);
                com.Parameters.AddWithValue("@RENCLD_DISTRIC", Convert.ToInt32(ObjRenContractLic.DISTRIC));
                com.Parameters.AddWithValue("@RENCLD_MANDAL ", Convert.ToInt32(ObjRenContractLic.MANDAL));
                com.Parameters.AddWithValue("@RENCLD_VILLAGE", Convert.ToInt32(ObjRenContractLic.VILLAGE));
                com.Parameters.AddWithValue("@RENCLD_LOCALITY", ObjRenContractLic.LOCALITY);
                com.Parameters.AddWithValue("@RENCLD_LANDMARK", ObjRenContractLic.LANDMARK);
                com.Parameters.AddWithValue("@RENCLD_PINCODE ", Convert.ToInt32(ObjRenContractLic.PINCODE));
                com.Parameters.AddWithValue("@RENCLD_REGNUMBER", Convert.ToInt32(ObjRenContractLic.REGNUMBER));
                com.Parameters.AddWithValue("@RENCLD_REGDATE", ObjRenContractLic.REGDATE);
                com.Parameters.AddWithValue("@RENCLD_TYPEOFBUSINESS", ObjRenContractLic.TYPEOFBUSINESS);
                com.Parameters.AddWithValue("@RENCLD_TITLES", ObjRenContractLic.TITLE);
                com.Parameters.AddWithValue("@RENCLD_EMPNAME", ObjRenContractLic.EMPNAME);
                com.Parameters.AddWithValue("@RENCLD_NAMES", ObjRenContractLic.NAME);
                com.Parameters.AddWithValue("@RENCLD_ADDRESS", ObjRenContractLic.ADDRESS);
                com.Parameters.AddWithValue("@RENCLD_LABOUREMPEST", ObjRenContractLic.LABOUREMPEST);
                com.Parameters.AddWithValue("@RENCLD_NOOFDAYS", Convert.ToInt32(ObjRenContractLic.NOOFDAYS));
                com.Parameters.AddWithValue("@RENCLD_LABOURAPPROVED", ObjRenContractLic.LABOURAPPROVED);
                com.Parameters.AddWithValue("@RENCLD_MAXNOLABOUREMP", ObjRenContractLic.MAXNOLABOUREMP);
                com.Parameters.AddWithValue("@RENCLD_WITHIN5YEARS", ObjRenContractLic.WITHIN5YEARS);
                com.Parameters.AddWithValue("@RENCLD_DETAILS", ObjRenContractLic.DETAILS);
                com.Parameters.AddWithValue("@RENCLD_REVOKINGLIC", ObjRenContractLic.REVOKINGLIC);
                com.Parameters.AddWithValue("@RENCLD_ORDERDATE", ObjRenContractLic.ORDERDATE);
                com.Parameters.AddWithValue("@RENCLD_ESTWITHIN5YEAR", ObjRenContractLic.ESTWITHIN5YEAR);
                com.Parameters.AddWithValue("@RENCLD_ESTDETAILS", ObjRenContractLic.ESTDETAILS);
                com.Parameters.AddWithValue("@RENCLD_EMPDETAILS", ObjRenContractLic.EMPDETAILS);
                com.Parameters.AddWithValue("@RENCLD_NATUREOFWORK", ObjRenContractLic.NATUREOFWORK);


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
        public string InsertRenConLabourDetails(RenContractLabour ObjRenContractLic)
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
                com.CommandText = RENConstants.InsertRenConLoabourDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENMD_CREATEDBY", Convert.ToInt32(ObjRenContractLic.CreatedBy));
                com.Parameters.AddWithValue("@RENMD_CREATEDBYIP", ObjRenContractLic.IPAddress);
                com.Parameters.AddWithValue("@RENMD_RENQDID", Convert.ToInt32(ObjRenContractLic.Questionnariid));
                com.Parameters.AddWithValue("@RENMD_UNITID", Convert.ToInt32(ObjRenContractLic.UnitId));

                com.Parameters.AddWithValue("@RENMD_TITLE", ObjRenContractLic.FULLTITLE);
                com.Parameters.AddWithValue("@RENMD_FULLNAME", ObjRenContractLic.FULLNAME);
                com.Parameters.AddWithValue("@RENMD_ADDRESS", ObjRenContractLic.FULLADDRESS);


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
        public DataSet GetRenContractDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(RENConstants.GetRENContractDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = RENConstants.GetRENContractDetails;

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
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public string InsertRENBoilerDetails(RenBoilerDetails ObjRenBoilerDetails)
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
                com.CommandText = RENConstants.InsertRenBoilerDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENBD_CREATEDBY", Convert.ToInt32(ObjRenBoilerDetails.CreatedBy));
                com.Parameters.AddWithValue("@RENBD_CREATEDBYIP", ObjRenBoilerDetails.IPAddress);
                com.Parameters.AddWithValue("@RENBD_RENQDID", Convert.ToInt32(ObjRenBoilerDetails.Questionnariid));
                com.Parameters.AddWithValue("@RENBD_UNITID", Convert.ToInt32(ObjRenBoilerDetails.UnitId));

                com.Parameters.AddWithValue("@RENBD_LICNO", ObjRenBoilerDetails.LICNO);
                com.Parameters.AddWithValue("@RENBD_LICISSUEDATE", ObjRenBoilerDetails.LICISSUEDDATE);
                com.Parameters.AddWithValue("@RENBD_LICVALIDDATE", ObjRenBoilerDetails.LICVALIDDATE);
                com.Parameters.AddWithValue("@RENBD_BOILERPLANT", ObjRenBoilerDetails.BOILERWORK);
                com.Parameters.AddWithValue("@RENBD_FACTORYNAME", ObjRenBoilerDetails.FACTORYNAME);
                com.Parameters.AddWithValue("@RENBD_FACTORYADDRESS", ObjRenBoilerDetails.ADDRESSFACTORY);
                com.Parameters.AddWithValue("@RENBD_DISTRIC", Convert.ToInt32(ObjRenBoilerDetails.DISTRIC));
                com.Parameters.AddWithValue("@RENBD_MANDAL", Convert.ToInt32(ObjRenBoilerDetails.MANDAL));
                com.Parameters.AddWithValue("@RENBD_VILLAGE", Convert.ToInt32(ObjRenBoilerDetails.VILLAGE));
                com.Parameters.AddWithValue("@RENBD_LOCALITY", ObjRenBoilerDetails.LOCALITY);
                com.Parameters.AddWithValue("@RENBD_PINCODE", Convert.ToInt32(ObjRenBoilerDetails.PINCODE));
                com.Parameters.AddWithValue("@RENBD_NAMEMANU", ObjRenBoilerDetails.NAMEMANU);
                com.Parameters.AddWithValue("@RENBD_YEARMANU", ObjRenBoilerDetails.YEARMANU);
                com.Parameters.AddWithValue("@RENBD_PLACEMANU", ObjRenBoilerDetails.PLACEMANU);

                com.Parameters.AddWithValue("@RENBD_BOILERMAKERNO", Convert.ToInt32(ObjRenBoilerDetails.BOILERNO));
                com.Parameters.AddWithValue("@RENBD_INTENDEDPRESSURE", ObjRenBoilerDetails.INTENDED);
                com.Parameters.AddWithValue("@RENBD_FULE", ObjRenBoilerDetails.FUEL);
                com.Parameters.AddWithValue("@RENBD_SUPERHEATER", Convert.ToDecimal(ObjRenBoilerDetails.HEATERRATING));
                com.Parameters.AddWithValue("@RENBD_ECONOMISERRATING", Convert.ToDecimal(ObjRenBoilerDetails.ECONOMISERATING));
                com.Parameters.AddWithValue("@RENBD_MAXIMUMEVAPORATION", Convert.ToDecimal(ObjRenBoilerDetails.MAXIMUMEVAPORATION));
                com.Parameters.AddWithValue("@RENBD_REHEATERRATING", Convert.ToDecimal(ObjRenBoilerDetails.REHEATER));
                com.Parameters.AddWithValue("@RENBD_WORKINGSEASON", ObjRenBoilerDetails.WORKINGSEASON);
                com.Parameters.AddWithValue("@RENBD_WORKINGPRESSURE", Convert.ToDecimal(ObjRenBoilerDetails.WORKINGPRESSURE));
                com.Parameters.AddWithValue("@RENBD_NAMEOWNER", ObjRenBoilerDetails.NAMEOWNER);
                com.Parameters.AddWithValue("@RENBD_TYPEBOILER", ObjRenBoilerDetails.BOILERTYPE);
                com.Parameters.AddWithValue("@RENBD_DESCBOILER", ObjRenBoilerDetails.DESCBOILER);
                com.Parameters.AddWithValue("@RENBD_BOILERRATE", ObjRenBoilerDetails.BOILERRATING);
                com.Parameters.AddWithValue("@RENBD_BOILEROWNERSHIP", ObjRenBoilerDetails.BOILEROWNERSHIP);
                com.Parameters.AddWithValue("@RENBD_REMARKSTRANS", ObjRenBoilerDetails.REMARKSTR);
                com.Parameters.AddWithValue("@RENBD_REGNO", Convert.ToInt32(ObjRenBoilerDetails.REGNO));
                com.Parameters.AddWithValue("@RENBD_BOILERTY", ObjRenBoilerDetails.BOILEROFTYPE);
                com.Parameters.AddWithValue("@RENBD_BOILERRATING", ObjRenBoilerDetails.BOILERRATINGS);
                com.Parameters.AddWithValue("@RENBD_WORKPLANTBOILER", ObjRenBoilerDetails.BOILERSITUATED);
                com.Parameters.AddWithValue("@RENBD_PLACEMANUFACTURE", ObjRenBoilerDetails.MANUFACTUREPLACE);
                com.Parameters.AddWithValue("@RENBD_YEARMANUFACTURE", ObjRenBoilerDetails.MANUFACTUREYEAR);
                com.Parameters.AddWithValue("@RENBD_NAMEMANUFACTURE", ObjRenBoilerDetails.OWNERNAMES);
                com.Parameters.AddWithValue("@RENBD_MAXCOUNT", Convert.ToDecimal(ObjRenBoilerDetails.MAXCOUNT));
                com.Parameters.AddWithValue("@RENBD_MAXIMUMPRESSURE", ObjRenBoilerDetails.MAXIMUMPRESSURE);
                com.Parameters.AddWithValue("@RENBD_REPAIRS", ObjRenBoilerDetails.REPAIRS);
                com.Parameters.AddWithValue("@RENBD_HYDRAULICALLY", ObjRenBoilerDetails.HYDRAULICALLY);
                com.Parameters.AddWithValue("@RENBD_UPTO", ObjRenBoilerDetails.UPTO);
                com.Parameters.AddWithValue("@RENBD_LOADING", ObjRenBoilerDetails.LOADING);
                com.Parameters.AddWithValue("@RENBD_SAFTEY", ObjRenBoilerDetails.SAFETY);
                com.Parameters.AddWithValue("@RENBD_PERIODDATE", ObjRenBoilerDetails.PERIODDATE);
                com.Parameters.AddWithValue("@RENBD_TODATE", ObjRenBoilerDetails.TODATE);
                com.Parameters.AddWithValue("@RENBD_REMARK", ObjRenBoilerDetails.REMARK);
                com.Parameters.AddWithValue("@RENBD_REGFEES", Convert.ToInt32(ObjRenBoilerDetails.REGFEES));
                com.Parameters.AddWithValue("@RENBD_TOTALAMOUNT", Convert.ToInt32(ObjRenBoilerDetails.TOTALAMOUNT));


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
        public DataSet GetRenBoilerDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(RENConstants.GetBoilerDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = RENConstants.GetBoilerDetails;

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
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public string InsertRenShopEstablishmentDetails(RenShopsEstablishment ObjRenShopEst)
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
                com.CommandText = RENConstants.InsertRenShopEstablishmentDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENSE_CREATEDBY", Convert.ToInt32(ObjRenShopEst.CreatedBy));
                com.Parameters.AddWithValue("@RENSE_CREATEDBYIP", ObjRenShopEst.IPAddress);
                com.Parameters.AddWithValue("@RENSE_RENQDID", Convert.ToInt32(ObjRenShopEst.Questionnariid));
                com.Parameters.AddWithValue("@RENSE_UNITID", Convert.ToInt32(ObjRenShopEst.UnitId));

                com.Parameters.AddWithValue("@RENSE_LICNO", ObjRenShopEst.LICNO);
                com.Parameters.AddWithValue("@RENSE_LICISSUEDATE", ObjRenShopEst.LICISSUEDATE);
                com.Parameters.AddWithValue("@RENSE_LICVALIDUP", ObjRenShopEst.LICVALIDUP);
                com.Parameters.AddWithValue("@RENSE_NAMEEST", ObjRenShopEst.NAMEEST);
                com.Parameters.AddWithValue("@RENSE_CONSTITUTION", ObjRenShopEst.CONSTITUTION);
                com.Parameters.AddWithValue("@RENSE_APPLICANTNAME", ObjRenShopEst.APPLICANTNAME);
                com.Parameters.AddWithValue("@RENSE_MOBILENO", Convert.ToInt64(ObjRenShopEst.MOBILENO));
                com.Parameters.AddWithValue("@RENSE_EMAILID", ObjRenShopEst.EMAILID);
                com.Parameters.AddWithValue("@RENSE_NAMEOFMANAGER", ObjRenShopEst.NAMEOFMANAGER);
                com.Parameters.AddWithValue("@RENSE_ADDRESS", ObjRenShopEst.ADDRESS);
                com.Parameters.AddWithValue("@RENSE_CATEGORYEST", ObjRenShopEst.CATEGORYEST);
                com.Parameters.AddWithValue("@RENSE_NATUREBUSINESS", ObjRenShopEst.NATUREBUSINESS);
                com.Parameters.AddWithValue("@RENSE_YOURFAMILY", ObjRenShopEst.YOURFAMILY);
                com.Parameters.AddWithValue("@RENSE_EMPLOYEESEST", ObjRenShopEst.EMPLOYEESEST);
                com.Parameters.AddWithValue("@RENSE_NOOFEMPLOYEE", ObjRenShopEst.NOOFEMPLOYEE);
                com.Parameters.AddWithValue("@RENSE_DISTRIC", Convert.ToInt32(ObjRenShopEst.DISTRIC));
                com.Parameters.AddWithValue("@RENSE_MANDAL", Convert.ToInt32(ObjRenShopEst.MANDAL));
                com.Parameters.AddWithValue("@RENSE_VILLAGE", Convert.ToInt32(ObjRenShopEst.VILLAGE));
                com.Parameters.AddWithValue("@RENSE_LOCALITY", ObjRenShopEst.LOCALITY);
                com.Parameters.AddWithValue("@RENSE_PINCODE", Convert.ToInt32(ObjRenShopEst.PINCODE));
                com.Parameters.AddWithValue("@RENSE_LANDMARK", ObjRenShopEst.LANDMARK);
                com.Parameters.AddWithValue("@RENSE_GODOWN", ObjRenShopEst.GODOWN);
                com.Parameters.AddWithValue("@RENSE_REGRENEWEDDATE", ObjRenShopEst.REGRENEWEDDATE);
                com.Parameters.AddWithValue("@RENSE_REGVALIDDATE", ObjRenShopEst.REGVALIDDATE);
                com.Parameters.AddWithValue("@RENSE_YEARRENEWED", ObjRenShopEst.YEARRENEWED);
                com.Parameters.AddWithValue("@RENSE_FEES", ObjRenShopEst.FEES);
                com.Parameters.AddWithValue("@RENSE_FEESNOTICE", ObjRenShopEst.FEESNOTICE);
                com.Parameters.AddWithValue("@RENSE_FINE", ObjRenShopEst.FINE);
                com.Parameters.AddWithValue("@RENSE_PENALTY", ObjRenShopEst.PENALTY);
                com.Parameters.AddWithValue("@RENSE_TOTALPAIDAMOUNT", ObjRenShopEst.TOTALPAIDAMOUNT);




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
        public string InsertRenewalShopsDetails(RenShopsEstablishment ObjRenShopEst)
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
                com.CommandText = RENConstants.InsertRenShopesestablishLabourDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENWP_CREATEDBY", Convert.ToInt32(ObjRenShopEst.CreatedBy));
                com.Parameters.AddWithValue("@RENWP_CREATEDBYIP", ObjRenShopEst.IPAddress);
                com.Parameters.AddWithValue("@RENWP_RENQDID", Convert.ToInt32(ObjRenShopEst.Questionnariid));
                com.Parameters.AddWithValue("@RENWP_UNITID", Convert.ToInt32(ObjRenShopEst.UnitId));

                com.Parameters.AddWithValue("@RENWP_DISTRIC", Convert.ToInt32(ObjRenShopEst.DISTICS));
                com.Parameters.AddWithValue("@RENWP_MANDAL", Convert.ToInt32(ObjRenShopEst.MANDALS));
                com.Parameters.AddWithValue("@RENWP_VILLAGE", Convert.ToInt32(ObjRenShopEst.VILLAGES));
                com.Parameters.AddWithValue("@RENWP_LOCALITY", ObjRenShopEst.LOCALITYS);
                com.Parameters.AddWithValue("@RENWP_PINCODE", Convert.ToInt32(ObjRenShopEst.PINCODES));



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
        public string INSERTRENTRenLabourEstablishmentDetails(RenShopsEstablishment ObjRenShopEst)
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
                com.CommandText = RENConstants.InsertRenLabourEstablishmentDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENED_CREATEDBY", Convert.ToInt32(ObjRenShopEst.CreatedBy));
                com.Parameters.AddWithValue("@RENED_CREATEDBYIP", ObjRenShopEst.IPAddress);
                com.Parameters.AddWithValue("@RENED_RENQDID", Convert.ToInt32(ObjRenShopEst.Questionnariid));
                com.Parameters.AddWithValue("@RENED_UNITID", Convert.ToInt32(ObjRenShopEst.UnitId));

                com.Parameters.AddWithValue("@RENED_NAME", ObjRenShopEst.NAMES);
                com.Parameters.AddWithValue("@RENED_GENDER", ObjRenShopEst.GENDER);
                com.Parameters.AddWithValue("@RENED_AGE", Convert.ToInt32(ObjRenShopEst.AGE));
                com.Parameters.AddWithValue("@RENED_RELATIONSHIP", ObjRenShopEst.RELATIONSHIP);


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
        public int InsertAttachmentsRenewal(RenShopsEstablishment ObjRenShopEst)
        {
            int valid = 0;

            SqlConnection connection = new SqlConnection(connstr);
            //SqlTransaction transaction = null;
            connection.Open();
            //transaction = connection.BeginTransaction();
            try
            {
                SqlParameter[] p = new SqlParameter[] {
         new SqlParameter("@REN_UNITID",SqlDbType.Structured),
         new SqlParameter("@REN_INVESTORID",SqlDbType.Structured),
        new SqlParameter("@REN_FILETYPE",SqlDbType.Structured),
        new SqlParameter("@REN_FILEPATH",SqlDbType.Structured),
        new SqlParameter("@REN_FILENAME",SqlDbType.Structured),
        new SqlParameter("@REN_FILEDESCRIPTION",SqlDbType.Structured),
        new SqlParameter("@REN_DEPTID",SqlDbType.Structured),
        new SqlParameter("@REN_APPROVALID",SqlDbType.Structured),
        };

                p[0].Value = ObjRenShopEst.UnitId;
                p[1].Value = ObjRenShopEst.CreatedBy;
                p[2].Value = ObjRenShopEst.FileType;

                p[3].Value = ObjRenShopEst.Filepath;
                p[4].Value = ObjRenShopEst.FileName;
                p[5].Value = ObjRenShopEst.FileDescription;
                p[6].Value = ObjRenShopEst.Deptid;
                p[7].Value = ObjRenShopEst.ApprovalId;
                string A = "";
                A = Convert.ToString(SqlHelper.ExecuteNonQuery(connection, RENConstants.InsertAttachmentDetails, p));
                valid = Convert.ToInt16(A);
                //transaction.Commit();
                connection.Close();
            }

            catch (Exception ex)
            {
                // transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }
        public DataSet GetRenShposEstablishmentLabourDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(RENConstants.GetRenShopsEstablishment, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = RENConstants.GetRenShopsEstablishment;

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
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public string InsertRenPropertiesDetails(RenShopsEstablishment ObjRenShopEst)
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
                com.CommandText = RENConstants.InsertRenPropertiesDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENP_CREATEDBY", Convert.ToInt32(ObjRenShopEst.CreatedBy));
                com.Parameters.AddWithValue("@RENP_CREATEDBYIP", ObjRenShopEst.IPAddress);
                com.Parameters.AddWithValue("@RENP_RENQDID", Convert.ToInt32(ObjRenShopEst.Questionnariid));
                com.Parameters.AddWithValue("@RENP_UNITID", Convert.ToInt32(ObjRenShopEst.UnitId));

                com.Parameters.AddWithValue("@RENP_NAMEPROPERTIE", ObjRenShopEst.NAME_PROPERTIE);
                com.Parameters.AddWithValue("@RENP_COMMUNICATIONADDRESS", ObjRenShopEst.COMMUNITIONADDRESS);
                com.Parameters.AddWithValue("@RENP_COMMUNITY", ObjRenShopEst.COMMUNITY);
                com.Parameters.AddWithValue("@RENP_COMMUNITYOTHER", ObjRenShopEst.COMMUNITYOTHER);


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
        public string InsertRenPatnerDetails(RenShopsEstablishment ObjRenShopEst)
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
                com.CommandText = RENConstants.InsertRenPatnerDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENPS_CREATEDBY", Convert.ToInt32(ObjRenShopEst.CreatedBy));
                com.Parameters.AddWithValue("@RENPS_CREATEDBYIP", ObjRenShopEst.IPAddress);
                com.Parameters.AddWithValue("@RENPS_RENQDID", Convert.ToInt32(ObjRenShopEst.Questionnariid));
                com.Parameters.AddWithValue("@RENPS_UNITID", Convert.ToInt32(ObjRenShopEst.UnitId));

                com.Parameters.AddWithValue("@RENPS_NAMEPATNER", ObjRenShopEst.NAMEPATNER);
                com.Parameters.AddWithValue("@RENPS_COMMUNICATIONADDRESS", ObjRenShopEst.PATNERADDRESS);



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
        public string InsertRenLimitedCompanyDetails(RenShopsEstablishment ObjRenShopEst)
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
                com.CommandText = RENConstants.InsertRenLimitedCompanyDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENLC_CREATEDBY", Convert.ToInt32(ObjRenShopEst.CreatedBy));
                com.Parameters.AddWithValue("@RENLC_CREATEDBYIP", ObjRenShopEst.IPAddress);
                com.Parameters.AddWithValue("@RENLC_RENQDID", Convert.ToInt32(ObjRenShopEst.Questionnariid));
                com.Parameters.AddWithValue("@RENLC_UNITID", Convert.ToInt32(ObjRenShopEst.UnitId));

                com.Parameters.AddWithValue("@RENLC_NAMEOFDIRECTOR", ObjRenShopEst.NAMEDIRECTOR);
                com.Parameters.AddWithValue("@RENLC_COMMUNICATIONADDRESS", ObjRenShopEst.LIMITEDADDRESS);



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
        public string InsertRenApplicationDetails(RenApplicationDetails ObjApplicationDetails)
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
                com.CommandText = RENConstants.InsertRenApplicationDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENLC_CREATEDBY", Convert.ToInt32(ObjApplicationDetails.CreatedBy));
                com.Parameters.AddWithValue("@RENLC_CREATEDBYIP", ObjApplicationDetails.IPAddress);
                com.Parameters.AddWithValue("@RENID_RENQDID", Convert.ToInt32(ObjApplicationDetails.Questionnariid));
                com.Parameters.AddWithValue("@RENID_UNITID", Convert.ToInt32(ObjApplicationDetails.UnitId));

                com.Parameters.AddWithValue("@RENID_NAMEOFUNIT", ObjApplicationDetails.Nameofunit);
                com.Parameters.AddWithValue("@RENID_COMPANYTYPE", ObjApplicationDetails.companyType);
                com.Parameters.AddWithValue("@RENID_REGNUMBER", Convert.ToInt32(ObjApplicationDetails.RegNumber));
                com.Parameters.AddWithValue("@RENID_REGDATE", ObjApplicationDetails.RegDate);
                com.Parameters.AddWithValue("@RENID_SECTORENTERPRISE", ObjApplicationDetails.SectorEntrprise);
                com.Parameters.AddWithValue("@RENID_SECTOR", ObjApplicationDetails.Sector);
                com.Parameters.AddWithValue("@RENID_LINEOFACTIVITY", ObjApplicationDetails.LineofActivity);
                com.Parameters.AddWithValue("@RENID_POLLUTIONCATG", ObjApplicationDetails.PCB);
                com.Parameters.AddWithValue("@RENID_PROPOSEDEMP", Convert.ToInt32(ObjApplicationDetails.ProposedEmp));
                com.Parameters.AddWithValue("@RENID_LANDSALEDEED", Convert.ToInt32(ObjApplicationDetails.LandSaleDeed));
                com.Parameters.AddWithValue("@RENID_BUILDING", Convert.ToInt32(ObjApplicationDetails.Building));
                com.Parameters.AddWithValue("@RENID_PLANTMACHINERY", Convert.ToInt32(ObjApplicationDetails.PlantMachinary));
                com.Parameters.AddWithValue("@RENID_ANNUALTURNOVER", Convert.ToInt32(ObjApplicationDetails.AnnualTurnOver));
                com.Parameters.AddWithValue("@RENID_PROJECTCOST", Convert.ToInt32(ObjApplicationDetails.TotalProjectCost));
                com.Parameters.AddWithValue("@RENID_ENTERPRISECATEG", ObjApplicationDetails.EnterpriseCategory);
                com.Parameters.AddWithValue("@RENID_DISTRIC", Convert.ToInt32(ObjApplicationDetails.District));
                com.Parameters.AddWithValue("@RENID_MANDAL ", Convert.ToInt32(ObjApplicationDetails.Mandal));
                com.Parameters.AddWithValue("@RENID_VILLAGE", Convert.ToInt32(ObjApplicationDetails.Village));
                com.Parameters.AddWithValue("@RENID_EMAILID", ObjApplicationDetails.EmailId);
                com.Parameters.AddWithValue("@RENID_MOBILENO", Convert.ToInt64(ObjApplicationDetails.MobileNo));
                com.Parameters.AddWithValue("@RENID_DOORNO", ObjApplicationDetails.Door);
                com.Parameters.AddWithValue("@RENID_LOCALITY", ObjApplicationDetails.Locality);
                com.Parameters.AddWithValue("@RENID_LANDMARK", ObjApplicationDetails.Landmark);
                com.Parameters.AddWithValue("@RENID_PINCODE", Convert.ToInt32(ObjApplicationDetails.Pincode));
                com.Parameters.AddWithValue("@RENID_NAMEOFPROMOTER", ObjApplicationDetails.NamePromoter);
                com.Parameters.AddWithValue("@RENID_EMAIL", ObjApplicationDetails.Email);
                com.Parameters.AddWithValue("@RENID_MOBILENUMBER", Convert.ToInt64(ObjApplicationDetails.MobileNumber));
                com.Parameters.AddWithValue("@RENID_DOOR", ObjApplicationDetails.DoorNo);
                com.Parameters.AddWithValue("@RENID_LOCALITYADD", ObjApplicationDetails.Local);
                com.Parameters.AddWithValue("@RENID_STATE", ObjApplicationDetails.State);
                com.Parameters.AddWithValue("@RENID_DISTRICS", Convert.ToInt32(ObjApplicationDetails.Districts));
                com.Parameters.AddWithValue("@RENID_MANDALS ", Convert.ToInt32(ObjApplicationDetails.Mandals));
                com.Parameters.AddWithValue("@RENID_VILLAGES", Convert.ToInt32(ObjApplicationDetails.Villages));
                com.Parameters.AddWithValue("@RENID_DIST ", ObjApplicationDetails.AppDistrict);
                com.Parameters.AddWithValue("@RENID_MANDA", ObjApplicationDetails.AppMandal);
                com.Parameters.AddWithValue("@RENID_VILLA", ObjApplicationDetails.AppVillge);
                com.Parameters.AddWithValue("@RENID_PIN", Convert.ToInt32(ObjApplicationDetails.Pin));
                com.Parameters.AddWithValue("@RENID_AGE", Convert.ToInt32(ObjApplicationDetails.Age));
                com.Parameters.AddWithValue("@RENID_DESIGNATION", ObjApplicationDetails.Designation);


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
        public DataSet GetRenApplicantDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(RENConstants.GetRENApplicantDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = RENConstants.GetRENApplicantDetails;

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
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataTable GetApprovalsReqWithFee(RenApplicationDetails ObjApplicationDetails)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(RENConstants.GetRENApprovalsReq, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = RENConstants.GetRENApprovalsReq;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@ENTPRISETYPE", ObjApplicationDetails.EnterpriseCategory);
                da.SelectCommand.Parameters.AddWithValue("@APPROVALID", ObjApplicationDetails.ApprovalID);
                //da.SelectCommand.Parameters.AddWithValue("@POWERKW_ID", ObjApplicationDetails.PowerReqKW);
                //da.SelectCommand.Parameters.AddWithValue("@EMPLOYEE", Convert.ToInt32(ObjApplicationDetails.PropEmployment));
                //da.SelectCommand.Parameters.AddWithValue("@BUILDINGHEIGHT", ObjApplicationDetails.BuildingHeight);
                da.Fill(ds);
                transaction.Commit();
                return ds.Tables[0];
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
        public string InsertRENSafteySecurityDetails(RenSafteySecurity ObjRenSafteySecurity)
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
                com.CommandText = RENConstants.InsertRENSafteySecurityDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENSD_CREATEDBY", Convert.ToInt32(ObjRenSafteySecurity.CreatedBy));
                com.Parameters.AddWithValue("@RENSD_CREATEDBYIP", ObjRenSafteySecurity.IPAddress);
                com.Parameters.AddWithValue("@RENSD_RENQDID", Convert.ToInt32(ObjRenSafteySecurity.Questionnariid));
                com.Parameters.AddWithValue("@RENSD_UNITID", Convert.ToInt32(ObjRenSafteySecurity.UnitId));

                com.Parameters.AddWithValue("@RENSD_MIGRANTREGNO", Convert.ToInt32(ObjRenSafteySecurity.MIGRANTREGNO));
                com.Parameters.AddWithValue("@RENSD_DISTRICREGISSUED", ObjRenSafteySecurity.DISTRICREGISSUED);
                com.Parameters.AddWithValue("@RENSD_NAMEKIN", ObjRenSafteySecurity.NAMEKIN);
                com.Parameters.AddWithValue("@RENSD_ADDRESS", ObjRenSafteySecurity.ADDRESS);
                com.Parameters.AddWithValue("@RENSD_FORCEININDIA", ObjRenSafteySecurity.FORCEININDIA);
                com.Parameters.AddWithValue("@RENSD_CRIMINALCASE", ObjRenSafteySecurity.CRIMINALCASE);
                com.Parameters.AddWithValue("@RENSD_UNSOUNDMIND", ObjRenSafteySecurity.UNSOUNDMIND);
                com.Parameters.AddWithValue("@RENSD_NATUREOFEMP", ObjRenSafteySecurity.NATUREOFEMP);
                com.Parameters.AddWithValue("@RENSD_EMPEXPECTEDDATE", ObjRenSafteySecurity.EMPEXPECTEDDATE);
                com.Parameters.AddWithValue("@RENSD_EXPECTEDDURATIONSTAY", ObjRenSafteySecurity.EXPECTEDDURATIONSTAY);
                com.Parameters.AddWithValue("@RENSD_WORKDETAILS", ObjRenSafteySecurity.WORKDETAILS);
                com.Parameters.AddWithValue("@RENSD_DISTRICAREA", ObjRenSafteySecurity.DISTRICAREA);
                com.Parameters.AddWithValue("@RENSD_AREAOFWORK", ObjRenSafteySecurity.AREAOFWORK);
                com.Parameters.AddWithValue("@RENSD_EXSTINGREGVALIDDATE", ObjRenSafteySecurity.EXSTINGREGVALIDDATE);
                com.Parameters.AddWithValue("@RENSD_DETAILSOFSPECIFICSKILL", ObjRenSafteySecurity.DETAILSOFSPECIFICSKILL);
                com.Parameters.AddWithValue("@RENSD_DISTRICAREAOFWORKER", ObjRenSafteySecurity.DISTRICAREAOFWORKER);
                com.Parameters.AddWithValue("@RENSD_WORKADDRESSAREA", ObjRenSafteySecurity.WORKADDRESSAREA);
                com.Parameters.AddWithValue("@RENSD_REGRENEWEDDATE", ObjRenSafteySecurity.REGRENEWEDDATE);
                com.Parameters.AddWithValue("@RENSD_NAMEESTEMP", ObjRenSafteySecurity.NAMEESTEMP);
                com.Parameters.AddWithValue("@RENSD_ADDRESSEST", ObjRenSafteySecurity.ADDRESSEST);
                com.Parameters.AddWithValue("@RENSD_CONTACTNO", Convert.ToInt64(ObjRenSafteySecurity.CONTACTNO));



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
        public DataSet GetRenSafteySecurity(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(RENConstants.GetRenSafteySecurityDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = RENConstants.GetRenSafteySecurityDetails;

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
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public string InsertMigrantWorkDetails(RenMigrantwork ObjRenMigrant)
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
                com.CommandText = RENConstants.InsertRenMigrantWorkDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENMW_CREATEDBY", Convert.ToInt32(ObjRenMigrant.CreatedBy));
                com.Parameters.AddWithValue("@RENMW_CREATEDBYIP", ObjRenMigrant.IPAddress);
                com.Parameters.AddWithValue("@RENMW_RENQDID", Convert.ToInt32(ObjRenMigrant.Questionnariid));
                com.Parameters.AddWithValue("@RENMW_UNITID", Convert.ToInt32(ObjRenMigrant.UnitId));

                com.Parameters.AddWithValue("@RENMW_TITLE", ObjRenMigrant.TITLESS);
                com.Parameters.AddWithValue("@RENMW_NAME", ObjRenMigrant.NAMES);
                com.Parameters.AddWithValue("@RENMW_ADDRESS", ObjRenMigrant.ADDRESS);


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
        public string InsertRENMigrantContractorDetails(RenMigrantwork ObjRenMigrant)
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
                com.CommandText = RENConstants.InsertRenContractorMigrantWorkDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENCM_CREATEDBY", Convert.ToInt32(ObjRenMigrant.CreatedBy));
                com.Parameters.AddWithValue("@RENCM_CREATEDBYIP", ObjRenMigrant.IPAddress);
                com.Parameters.AddWithValue("@RENCM_RENQDID", Convert.ToInt32(ObjRenMigrant.Questionnariid));
                com.Parameters.AddWithValue("@RENCM_UNITID", Convert.ToInt32(ObjRenMigrant.UnitId));

                com.Parameters.AddWithValue("@RENCM_LICRENO", ObjRenMigrant.LICRENO);
                com.Parameters.AddWithValue("@RENCM_LICISSUEDDATE", ObjRenMigrant.LICISSUEDDATE);
                com.Parameters.AddWithValue("@RENCM_LICRENVALIDDATE", ObjRenMigrant.LICRENVALIDDATE);
                com.Parameters.AddWithValue("@RENCM_TITLE", ObjRenMigrant.TITLE);
                com.Parameters.AddWithValue("@RENCM_NAME ", ObjRenMigrant.NAME);
                com.Parameters.AddWithValue("@RENCM_EMAILID ", ObjRenMigrant.EMAILID);
                com.Parameters.AddWithValue("@RENCM_MOBILENO", Convert.ToInt64(ObjRenMigrant.MOBILENO));
                com.Parameters.AddWithValue("@RENCM_FATHERNAME", ObjRenMigrant.FATHERNAME);
                com.Parameters.AddWithValue("@RENCM_STATE", Convert.ToInt32(ObjRenMigrant.STATE));
                com.Parameters.AddWithValue("@RENCM_DISTRIC", Convert.ToInt32(ObjRenMigrant.DISTRIC));
                com.Parameters.AddWithValue("@RENCM_MANDAL", Convert.ToInt32(ObjRenMigrant.MANDAL));
                com.Parameters.AddWithValue("@RENCM_VILLAGE ", Convert.ToInt32(ObjRenMigrant.VILLAGE));
                com.Parameters.AddWithValue("@RENCM_LOCALITY", ObjRenMigrant.LOCALITY);
                com.Parameters.AddWithValue("@RENCM_NEARLAND", ObjRenMigrant.NEARLAND);
                com.Parameters.AddWithValue("@RENCM_PINCODE", Convert.ToInt32(ObjRenMigrant.PINCODE));
                com.Parameters.AddWithValue("@RENCM_BIRTHAGE", ObjRenMigrant.DATEOFBIRTH);
                com.Parameters.AddWithValue("@RENCM_DATEOFBIRTH", ObjRenMigrant.DATE);
                com.Parameters.AddWithValue("@RENCM_AGE", ObjRenMigrant.AGE);
                com.Parameters.AddWithValue("@RENCM_STATES", Convert.ToInt32(ObjRenMigrant.STATES));
                com.Parameters.AddWithValue("@RENCM_DISTRICS ", Convert.ToInt32(ObjRenMigrant.DISTRICS));
                com.Parameters.AddWithValue("@RENCM_MANDALS", Convert.ToInt32(ObjRenMigrant.MANDALS));
                com.Parameters.AddWithValue("@RENCM_VILLAGES ", Convert.ToInt32(ObjRenMigrant.VILLAGES));
                com.Parameters.AddWithValue("@RENCM_LOCALITYS", ObjRenMigrant.LOCALITYS);
                com.Parameters.AddWithValue("@RENCM_LANDMARKS", ObjRenMigrant.LANDMARKS);
                com.Parameters.AddWithValue("@RENCM_PINCODES ", Convert.ToInt32(ObjRenMigrant.PINCODES));
                com.Parameters.AddWithValue("@RENCM_ARTICLE5 ", ObjRenMigrant.ARTICLE5);
                com.Parameters.AddWithValue("@RENCM_CRIMINALCASEAPP", ObjRenMigrant.CRIMINALCASEAPP);
                com.Parameters.AddWithValue("@RENCM_CONVICTED5APPLICATION", ObjRenMigrant.CONVICTED5APPLICATION);
                com.Parameters.AddWithValue("@RENCM_DISTRICCOUNCIL", ObjRenMigrant.DISTRICCOUNCIL);
                com.Parameters.AddWithValue("@RENCM_LICENSE", ObjRenMigrant.LICENSE);
                com.Parameters.AddWithValue("@RENCM_LICNOS", Convert.ToInt32(ObjRenMigrant.LICNOS));
                com.Parameters.AddWithValue("@RENCM_DATEOFLICENSE", ObjRenMigrant.DATEOFLICENSE);
                com.Parameters.AddWithValue("@RENCM_VALIDDATE", ObjRenMigrant.VALIDDATE);
                com.Parameters.AddWithValue("@RENCM_TRIBAL ", ObjRenMigrant.TRIBAL);
                com.Parameters.AddWithValue("@RENCM_REMARK ", ObjRenMigrant.REMARK);
                com.Parameters.AddWithValue("@RENCM_NAMEEST", ObjRenMigrant.NAMEEST);
                com.Parameters.AddWithValue("@RENCM_STATED ", Convert.ToInt32(ObjRenMigrant.STATED));
                com.Parameters.AddWithValue("@RENCM_DIST ", Convert.ToInt32(ObjRenMigrant.DIST));
                com.Parameters.AddWithValue("@RENCM_MAND ", Convert.ToInt32(ObjRenMigrant.MAND));
                com.Parameters.AddWithValue("@RENCM_VILLA", Convert.ToInt32(ObjRenMigrant.VILLA));
                com.Parameters.AddWithValue("@RENCM_LOCAL", ObjRenMigrant.LOCAL);
                com.Parameters.AddWithValue("@RENCM_NEARESTLANDMAEK", ObjRenMigrant.NEARESTLANDMAEK);
                com.Parameters.AddWithValue("@RENCM_PIN", Convert.ToInt32(ObjRenMigrant.PIN));
                com.Parameters.AddWithValue("@RENCM_TYPEOFBUSINESS", ObjRenMigrant.TYPEOFBUSINESS);
                com.Parameters.AddWithValue("@RENCM_REGNO", ObjRenMigrant.REGNO);
                com.Parameters.AddWithValue("@RENCM_DATEOFREG", ObjRenMigrant.DATEOFREG);
                com.Parameters.AddWithValue("@RENCM_TITLES", ObjRenMigrant.TITLES);
                com.Parameters.AddWithValue("@RENCM_NAMEOFEMP", ObjRenMigrant.NAMEOFEMP);
                com.Parameters.AddWithValue("@RENCM_MIGRANTNAMEEMP", ObjRenMigrant.MIGRANTNAMEEMP);
                com.Parameters.AddWithValue("@RENCM_CONTRACTWORK", ObjRenMigrant.CONTRACTWORK);
                com.Parameters.AddWithValue("@RENCM_DATECOMMENCING", ObjRenMigrant.DATECOMMENCING);
                com.Parameters.AddWithValue("@RENCM_ENDINGDATE", ObjRenMigrant.ENDINGDATE);
                com.Parameters.AddWithValue("@RENCM_AGENTNAME", ObjRenMigrant.AGENTNAME);
                com.Parameters.AddWithValue("@RENCM_MAXIMUMNOMIGRANT", ObjRenMigrant.MAXIMUMNOMIGRANT);
                com.Parameters.AddWithValue("@RENCM_AGENTNAMEADDRESS", ObjRenMigrant.AGENTNAMEADDRESS);
                com.Parameters.AddWithValue("@RENCM_5CONTRACTOR", ObjRenMigrant.CONTRACTOR);
                com.Parameters.AddWithValue("@RENCM_DEATILS", ObjRenMigrant.DEATILS);
                com.Parameters.AddWithValue("@RENCM_SUSPENDINGREVOKING", ObjRenMigrant.SUSPENDINGREVOKING);
                com.Parameters.AddWithValue("@RENCM_ORDERNO", Convert.ToInt32(ObjRenMigrant.ORDERNO));
                com.Parameters.AddWithValue("@RENCM_ORDERDATE", ObjRenMigrant.ORDERDATE);
                com.Parameters.AddWithValue("@RENCM_WORKESTPAST5YEARS", ObjRenMigrant.WORKESTPAST5YEARS);
                com.Parameters.AddWithValue("@RENCM_ESTDETAILS", ObjRenMigrant.ESTDETAILS);
                com.Parameters.AddWithValue("@RENCM_PRINCIPLEEMPDETAILS", ObjRenMigrant.PRINCIPLEEMPDETAILS);
                com.Parameters.AddWithValue("@RENCM_NATUREWORK", ObjRenMigrant.NATUREWORK);
                com.Parameters.AddWithValue("@RENCM_EMPENCLOSED", ObjRenMigrant.EMPENCLOSED);




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
        public DataSet GetRenMigrantWorker(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(RENConstants.GetRENMigrantDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = RENConstants.GetRENMigrantDetails;

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
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public string InsertRENFactoryLicDetails(RenFactoryLicense ObjRenFactoryLic)
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
                com.CommandText = RENConstants.InsertRENFactoryLicDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RENFL_CREATEDBY", Convert.ToInt32(ObjRenFactoryLic.CreatedBy));
                com.Parameters.AddWithValue("@RENFL_CREATEDBYIP", ObjRenFactoryLic.IPAddress);
                com.Parameters.AddWithValue("@RENFL_RENQDID", Convert.ToInt32(ObjRenFactoryLic.Questionnariid));
                com.Parameters.AddWithValue("@RENFL_UNITID", Convert.ToInt32(ObjRenFactoryLic.UnitId));

                com.Parameters.AddWithValue("@RENFL_FULLNAME", ObjRenFactoryLic.FULLNAME);
                com.Parameters.AddWithValue("@RENFL_LICNO", ObjRenFactoryLic.LICNO);
                com.Parameters.AddWithValue("@RENFL_LICISSUEDDATE", ObjRenFactoryLic.LICISSUEDDATE);
                com.Parameters.AddWithValue("@RENFL_RENEWALNO", Convert.ToInt32(ObjRenFactoryLic.RENEWALNO));
                com.Parameters.AddWithValue("@RENFL_RENEWALDATE", ObjRenFactoryLic.RENEWALDATE);
                com.Parameters.AddWithValue("@RENFL_LICVALIDYEAR", Convert.ToInt32(ObjRenFactoryLic.LICVALIDYEAR));
                com.Parameters.AddWithValue("@RENFL_FACTORIESL12MONTHS", ObjRenFactoryLic.FACTORIESL12MONTHS);
                com.Parameters.AddWithValue("@RENFL_NEXT12MONTHS", ObjRenFactoryLic.NEXT12MONTHS);
                com.Parameters.AddWithValue("@RENFL_MANUPRODUCT", ObjRenFactoryLic.MANUPRODUCT);
                com.Parameters.AddWithValue("@RENFL_PRINCIPALPRODUCT", ObjRenFactoryLic.PRINCIPALPRODUCT);
                //com.Parameters.AddWithValue("@RENFL_NAMESOFMANU", ObjRenFactoryLic.NAMESOFMANU);
                //com.Parameters.AddWithValue("@RENFL_MANUPRODUCT12MONTHS", ObjRenFactoryLic.MANUPRODUCT12MONTHS);
                com.Parameters.AddWithValue("@RENFL_MAXNOEMP", ObjRenFactoryLic.MAXNOEMP);
                com.Parameters.AddWithValue("@RENFL_MAXNOWORK", ObjRenFactoryLic.MAXNOWORK);
                com.Parameters.AddWithValue("@RENFL_NOORDINARIYEMP", ObjRenFactoryLic.NOORDINARIYEMP);
                com.Parameters.AddWithValue("@RENFL_UNITELECTRICPOWER", ObjRenFactoryLic.UNITELECTRICPOWER);
                com.Parameters.AddWithValue("@RENFL_TOTALCAPGENERATING", ObjRenFactoryLic.TOTALCAPGENERATING);
                com.Parameters.AddWithValue("@RENFL_TOTALDGSET", ObjRenFactoryLic.TOTALDGSET);
                com.Parameters.AddWithValue("@RENFL_MAXPOWER", ObjRenFactoryLic.MAXPOWER);
                com.Parameters.AddWithValue("@RENFL_FULLNAMEMANAGER", ObjRenFactoryLic.FULLNAMEMANAGER);
                com.Parameters.AddWithValue("@RENFL_RESIDENTIALADDRESS", ObjRenFactoryLic.RESIDENTIALADDRESS);
                com.Parameters.AddWithValue("@RENFL_FULLNAMEOWNER", ObjRenFactoryLic.FULLNAMEOWNER);
                com.Parameters.AddWithValue("@RENFL_OWNERADDRESSBUILD", ObjRenFactoryLic.OWNERADDRESSBUILD);
                com.Parameters.AddWithValue("@RENFL_NAMEOCCUPIER", ObjRenFactoryLic.NAMEOCCUPIER);
                com.Parameters.AddWithValue("@RENFL_ADDRESSOCCUPIER", ObjRenFactoryLic.ADDRESSOCCUPIER);
                com.Parameters.AddWithValue("@RENFL_PRIVATEFIRM", ObjRenFactoryLic.PRIVATEFIRM);
                com.Parameters.AddWithValue("@RENFL_PUBLICFIRM", ObjRenFactoryLic.PUBLICFIRM);
                com.Parameters.AddWithValue("@RENFL_NAMEPROPRIETOR", ObjRenFactoryLic.NAMEPROPRIETOR);
                com.Parameters.AddWithValue("@RENFL_NAMEDIRECTORS", ObjRenFactoryLic.NAMEDIRECTORS);
                com.Parameters.AddWithValue("@RENFL_GOVTLOCALFACTORY", ObjRenFactoryLic.GOVTLOCALFACTORY);
                com.Parameters.AddWithValue("@RENFL_MANAGINGAPPOINTEDAGENT", ObjRenFactoryLic.MANAGINGAPPOINTEDAGENT);
                com.Parameters.AddWithValue("@RENFL_NAMECHIEFHEAD", ObjRenFactoryLic.NAMECHIEFHEAD);
                com.Parameters.AddWithValue("@RENFL_NAMEOFAGENT", ObjRenFactoryLic.NAMEOFAGENT);
                com.Parameters.AddWithValue("@RENFL_FACTORYEXTENDED", ObjRenFactoryLic.FACTORYEXTENDED);
                com.Parameters.AddWithValue("@RENFL_REFNOAPPROVALSITE", ObjRenFactoryLic.REFNOAPPROVALSITE);
                com.Parameters.AddWithValue("@RENFL_DATEOFAPPROVAL", ObjRenFactoryLic.DATEOFAPPROVAL);
                com.Parameters.AddWithValue("@RENFL_REFAPPROVALAUTHORITY", ObjRenFactoryLic.REFAPPROVALAUTHORITY);
                com.Parameters.AddWithValue("@RENFL_DATEOFAPPROVALAUTHORITY", ObjRenFactoryLic.DATEOFAPPROVALAUTHORITY);
                com.Parameters.AddWithValue("@RENFL_FINALFEES", ObjRenFactoryLic.FINALFEES);
                com.Parameters.AddWithValue("@RENFL_PENALTY", ObjRenFactoryLic.PENALTY);
                com.Parameters.AddWithValue("@RENFL_LICVALIDUPTO", ObjRenFactoryLic.LICVALIDUPTO);
                com.Parameters.AddWithValue("@RENFL_TOTALAMOUNTPAID", ObjRenFactoryLic.TOTALAMOUNTPAID);


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
        public DataSet GetRenFactoriesLic(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(RENConstants.GetRenFactoriesLicenseDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = RENConstants.GetRenFactoriesLicenseDetails;

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
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetRenApprovals(string userid)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(RENConstants.GetRenApprovals, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = RENConstants.GetRenApprovals;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.Fill(ds);
                transaction.Commit();
                return ds;
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
        }
    }
}
