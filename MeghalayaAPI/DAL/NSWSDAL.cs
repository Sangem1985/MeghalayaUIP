using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using MeghalayaAPI.Common;
using System.Drawing;
using MeghalayaAPI.Models;


namespace MeghalayaAPI.DAL
{
    public class NSWSDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();
        public DataTable NSWSUserAuthentication(string Username, string Password)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(Constants.NSWSUserAuthentication, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = Constants.NSWSUserAuthentication;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                if (Username.Trim() == "" || Username.Trim() == null)
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = "%";
                else
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = Username.ToString();
                if (Password.Trim() == "" || Password.Trim() == null)
                    da.SelectCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = "%";
                else
                    da.SelectCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password.ToString();

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

        public string InsertNSWSOnlineUsers(InsertNSWSUserRequest ObjNSWSUserRequest)
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
                com.CommandText = Constants.InsertNSWSOnlineUsers;

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@Firstname", ObjNSWSUserRequest.Fullname);
                com.Parameters.AddWithValue("@Email", ObjNSWSUserRequest.Email);
                com.Parameters.AddWithValue("@MobileNo", ObjNSWSUserRequest.MobileNo);
                com.Parameters.AddWithValue("@username", ObjNSWSUserRequest.username);
                com.Parameters.AddWithValue("@investorSwsId", ObjNSWSUserRequest.investorSwsId);
                com.Parameters.Add("@valid", SqlDbType.VarChar, 100);
                com.Parameters["@valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@valid"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                ErrorLog.LogData(Result.ToString(), "InsertNSWSOnlineUsers");
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