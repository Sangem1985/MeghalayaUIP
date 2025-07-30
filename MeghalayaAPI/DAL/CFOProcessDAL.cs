
using MeghalayaAPI.Models;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;


namespace MeghalayaAPI.DAL
{

    public class CFOProcessDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();

        public DataSet GetCFOUnitIDBasedonQDID(int CFEQDID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFOProcConstants.GetCFOUnitIDBasedonQDID, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFOProcConstants.GetCFOUnitIDBasedonQDID;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@CFEQDID", Convert.ToInt32(CFEQDID));
                da.SelectCommand.Parameters.AddWithValue("@APPROVALID", 4);
                da.SelectCommand.Parameters.AddWithValue("@DEPTID", 14);

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
        public string InsertCRCertificateDetails(CFODtls Objest)
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
                com.CommandText = CFOProcConstants.InsertCRCertificateDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFOQDID", Objest.Questionnaireid);
                com.Parameters.AddWithValue("@POWERSANCTIONLETTERNUMBER", Objest.Powersanctionletternumber);
                com.Parameters.AddWithValue("@POWERSANCTIONDATE", DateTime.ParseExact(Objest.Powersanctiondate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));  
                com.Parameters.AddWithValue("@CONSUMERID", Objest.Consumerid);
                com.Parameters.AddWithValue("@DATEOFSERVICE", DateTime.ParseExact(Objest.Dateofservice, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@SANCTIONEDLOAD", Objest.Sanctionedload);
                com.Parameters.AddWithValue("@METERMAKE", Objest.Metermake);
                com.Parameters.AddWithValue("@METERSERIALNUMBER", Objest.Meterserialnumber);
                com.Parameters.AddWithValue("@METERTYPE", Objest.Metertype);
                com.Parameters.AddWithValue("@CTBYPTRATIO", Objest.Ctbyptratio);
                com.Parameters.AddWithValue("@METERCONSTANT", Objest.Meterconstant);
                com.Parameters.AddWithValue("@CATEGORYAPPLICABLE", Objest.Categoryapplicable);
                com.Parameters.AddWithValue("@CREATEDBY", Objest.UserID);
                com.Parameters.AddWithValue("@CREATEDBYIP", Objest.IPAddress);
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
    }
}