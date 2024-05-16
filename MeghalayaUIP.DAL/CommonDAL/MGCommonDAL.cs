using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Data.SqlTypes;
using MeghalayaUIP.Common;

namespace MeghalayaUIP.DAL.CommonDAL
{
    public class MGCommonDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();
        public string LogerrorDB(Exception ex, string path, string CreatedBy)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(connstr);
            connection.Open();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CommonConstants.LogEorror;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Message", ex.Message);
                com.Parameters.AddWithValue("@StackTrace", ex.StackTrace);
                com.Parameters.AddWithValue("@Source", ex.Source);
                com.Parameters.AddWithValue("@TargetSite", ex.TargetSite.ToString());
                com.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                com.Parameters.AddWithValue("@path", path);

                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                valid = com.Parameters["@Valid"].Value.ToString();
                connection.Close();
            }
            catch (Exception ex1)
            {
                throw ex1;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }

        public DataTable GetMainApplicantDashBoard(string Investerid)
        {
            DataTable dt = new DataTable();
            string valid = "";
            //  IDno = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(CommonConstants.GetMainApplicantDashBoard, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CommonConstants.GetMainApplicantDashBoard;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;


                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Investerid); 
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
    }
}
