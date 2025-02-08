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
using MeghalayaUIP.Common;
using Microsoft.Kiota.Abstractions;
using MeghalayaAPI.Services;


namespace MeghalayaAPI.DAL
{
    public class NSWSDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();
        List<string> consumedSwsids = new List<string>();
        List<string> consumedPanNumbers = new List<string>();
        CommonServices _getSRVC = new CommonServices();
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

        public ApiResponse_ACK InsertNSWSDETAILS(List<CompanyInfo> companyInfos)
        {

            string Result = "";
            string Result2 = "";
            

            using (SqlConnection connection = new SqlConnection(connstr))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // This will store the result of the batch operation (Valid value)
                    var validParam = new SqlParameter("@Valid", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlCommand command;
                    
                    foreach (var item in companyInfos)
                    {
                        if (item.PanNumber != null && item.SwsId != null)
                        {
                            // Prepare the command to execute the stored procedure
                            using (command = new SqlCommand(Constants.InsertNSWSPANUsers, connection, transaction))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                // Add parameters for the stored procedure
                                command.Parameters.AddWithValue("@PANNumber", item.PanNumber ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@NameAsPerPAN", item.NameAsPerPan ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@GSTNumebr", item.GstIn ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@CINNumber", item.CinNumber ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@NSWSId", item.SwsId ?? (object)DBNull.Value);

                                command.Parameters.AddWithValue("@Valid", SqlDbType.Int);
                                command.Parameters["@Valid"].Direction = ParameterDirection.Output;

                                consumedSwsids.Add(item.SwsId);
                                consumedPanNumbers.Add(item.PanNumber);

                                // Execute the stored procedure within the transaction
                                Result = Convert.ToString(command.ExecuteNonQuery());
                                Result = command.Parameters["@Valid"].Value.ToString();

                            }
                        }
                        
                        
                    }

                   
                    
                    // Avoid blocking if possible, use async
                    ApiResponse_ACK apiResponse_ACK = _getSRVC.ACKPanDetailsAsync(consumedSwsids, "24").Result;

                    if (apiResponse_ACK != null)
                    {
                        for (int i = 0; i < consumedSwsids.Count; i++)
                        {
                            if (consumedPanNumbers[i] != null && consumedSwsids[i] != null)
                            {
                                using (command = new SqlCommand(Constants.UPDATEACKNSWSPANUSERS, connection, transaction))
                                {
                                    command.CommandType = CommandType.StoredProcedure;

                                    // Add parameters for the stored procedure
                                    command.Parameters.AddWithValue("@PANNumber", consumedPanNumbers[i]);
                                    command.Parameters.AddWithValue("@NSWSId", consumedSwsids[i]);
                                    command.Parameters.AddWithValue("@AckStatusCode", apiResponse_ACK.StatusCode);
                                    command.Parameters.AddWithValue("@AckResponse", apiResponse_ACK.Status.ToString());
                                    command.Parameters.AddWithValue("@AckMsg", apiResponse_ACK.Message);

                                    command.Parameters.AddWithValue("@Valid", SqlDbType.Int);
                                    command.Parameters["@Valid"].Direction = ParameterDirection.Output;

                                    Result2 = Convert.ToString(command.ExecuteNonQuery());
                                    Result2 = command.Parameters["@Valid"].Value.ToString();


                                }
                            }
                               
                        }
                        // Commit the transaction since all operations are successful
                        transaction.Commit();
                    }
                    
                    
                    return apiResponse_ACK;
                                                                              
                }
                catch (Exception ex)
                {
                    ErrorLog.LogData(Result.ToString(), "NSWS_ACKRESPONSE");
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
    
}