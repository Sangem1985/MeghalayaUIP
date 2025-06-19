using MeghalayaAPI.Models;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MeghalayaAPI.DAL
{
    public class CFEProcessDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();
        public string CFEFeasibilityReportInsert(CFE_FEASIBILITY Objcfedtls)
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
                com.CommandText = CFEProcConstants.InsertCFEFeasibilityReport;

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@CFE_QDID", Objcfedtls.QuestionaryId);
                com.Parameters.AddWithValue("@CFE_APPLICATION_REG_NO", Objcfedtls.ApplicationRegNo);
                com.Parameters.AddWithValue("@CFE_NEAREST_CONSUMER_ID", Objcfedtls.NearestConsumerId);
                com.Parameters.AddWithValue("@CFE_SUBSTATION", Objcfedtls.Substation);
                com.Parameters.AddWithValue("@CFE_FEEDER_NAME", Objcfedtls.FeederName);
                com.Parameters.AddWithValue("@CFE_DTC", Objcfedtls.Dtc);
                com.Parameters.AddWithValue("@CFE_POLE_NO", Objcfedtls.PoleNumber);
                com.Parameters.AddWithValue("@CFE_PRODUCT", Objcfedtls.Product);
                com.Parameters.AddWithValue("@CFE_CONNECTION_TYPE", Objcfedtls.ConnectionType);
                com.Parameters.AddWithValue("@CFE_LOAD_KW", Objcfedtls.Loadkw);
                com.Parameters.AddWithValue("@CFE_NO_OF_PREMISES", Objcfedtls.NoofPremises);

                com.Parameters.AddWithValue("@CFE_SITE_DIMENSION_SFT", Objcfedtls.SiteDimensionSft);
                com.Parameters.AddWithValue("@CFE_BUILTUP_AREA", Objcfedtls.BuiltupArea);
                com.Parameters.AddWithValue("@CFE_NO_OF_FLOORS", Objcfedtls.NoofFloors);
                com.Parameters.AddWithValue("@CFE_CONNECTION_PHASE", Objcfedtls.ConnectionPhase);
                com.Parameters.AddWithValue("@CFE_BUILDING", Objcfedtls.Building);
                com.Parameters.AddWithValue("@CFE_REQUESTED_UG_CABLE_SIZE", Objcfedtls.RequestedUgCableSize);
                com.Parameters.AddWithValue("@CFE_REQUESTED_OH_CABLE_SIZE", Objcfedtls.RequestedOhCableSize);
                com.Parameters.AddWithValue("@CFE_LATITUDE", Objcfedtls.Latitude);
                com.Parameters.AddWithValue("@CFE_LONGITUDE", Objcfedtls.Longitude);
                com.Parameters.AddWithValue("@CFE_SERVICE_TYPE", Objcfedtls.ServiceType);

                com.Parameters.AddWithValue("@CFE_BILLING_TYPE", Objcfedtls.BillingType);
                com.Parameters.AddWithValue("@CFE_AREA_TYPE", Objcfedtls.AreaType);
                com.Parameters.AddWithValue("@CFE_REMARKS", Objcfedtls.Remarks);
                com.Parameters.AddWithValue("@CFE_DOCUMENT_ID", Objcfedtls.DocumentId);
                com.Parameters.AddWithValue("@CFE_DOCUMENT_NAME", Objcfedtls.DocumentName);
                com.Parameters.AddWithValue("@CFE_DOCUMENT_PATH", Objcfedtls.DocumentPath);
                com.Parameters.AddWithValue("@CFE_METER_TYPE", Objcfedtls.MeterType);
                com.Parameters.AddWithValue("@CFE_METERED_SIDE", Objcfedtls.MeteredSide);
                com.Parameters.AddWithValue("@CFE_LOAD_KVA", Objcfedtls.LoadKva);
                com.Parameters.AddWithValue("@CFE_CREATED_BY", Objcfedtls.UserId);
                com.Parameters.AddWithValue("@CFE_CREATED_BY_IP", Objcfedtls.UserIp);

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

        public DataSet GetUnitIDBasedonQDID(int CFEQDID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetPREREGandCFEapplications, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetPREREGandCFEapplications;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@CFEQDID", Convert.ToInt32(CFEQDID));

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
    }
}