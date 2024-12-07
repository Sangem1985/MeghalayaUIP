using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.DAL.INCDAL
{
    public class INCDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();
        public DataTable GetFixedCaptial()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(INCCommon.GetFixedCapitalInvestment, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = INCCommon.GetFixedCapitalInvestment;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.Fill(dt);

                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

            return dt;
        }
        public DataTable GetSourceFinance()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(INCCommon.GetSourceFinance, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = INCCommon.GetSourceFinance;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.Fill(dt);

                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

            return dt;
        }
        public DataTable GetEmploymentGeneration()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(INCCommon.GetEmploymenttype, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = INCCommon.GetEmploymenttype;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.Fill(dt);

                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

            return dt;
        }
        public int INSIncentiveReg(IncentiveReg1 IncentiveReg)
        {
            int valid = 0;
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                da = new SqlDataAdapter(INCCommon.InsertIncentiveReg, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = INCCommon.InsertIncentiveReg;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("", Convert.ToInt32(IncentiveReg.UserID));
                da.SelectCommand.Parameters.AddWithValue("", IncentiveReg.IPAddress);


            }
            catch(Exception ex)
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
