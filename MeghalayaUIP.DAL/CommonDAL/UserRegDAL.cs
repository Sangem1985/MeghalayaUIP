
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using MeghalayaUIP.Common;
namespace MeghalayaUIP.DAL.CommonDAL
{
    public class UserRegDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();

        public string InsertUserRegDetails(UserRegDetails Userregdtls)
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
                com.CommandText = LoginConstants.InsertUserRegDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                //@Fullname Varchar(100) ,  
                //@EntityName varchar(100) ,  
                //@emailid varchar(50),  
                //@mobile bigint,
                //@pwd varchar(100) ,  
                //@PanNo varchar(15),  
                //@dob datetime,
                //@Ipaddress varchar(50)
                com.Parameters.AddWithValue("@Fullname", Userregdtls.Fullname);
                com.Parameters.AddWithValue("@EntityName", "Test");
                com.Parameters.AddWithValue("@emailid", Userregdtls.Email);
                com.Parameters.AddWithValue("@mobile", Userregdtls.MobileNo);
                com.Parameters.AddWithValue("@pwd", Userregdtls.Password);
                com.Parameters.AddWithValue("@PanNo", Userregdtls.PANno);
                com.Parameters.AddWithValue("@dob", Userregdtls.DateofBirth);
                com.Parameters.AddWithValue("@Ipaddress", Userregdtls.IPAddress);
                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                valid = com.Parameters["@RESULT"].Value.ToString();


                //valid = Convert.ToString(com.ExecuteNonQuery());



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
