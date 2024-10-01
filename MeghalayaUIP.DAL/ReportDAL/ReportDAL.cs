using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.DAL.ReportDAL
{
    public class ReportDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();

        public DataSet DistrictWiseReports(string District, string EntType, string Formdate, string Todate)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(ReportCommon.GetDistrictWiseReports, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = ReportCommon.GetDistrictWiseReports;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@DISTRICT", District);
                da.SelectCommand.Parameters.AddWithValue("@ENTTYPE", EntType);
                if (Formdate != null && Formdate != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@FROMDATE", DateTime.ParseExact(Formdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));                   
                }
                if (Todate !=null && Todate !="")
                {
                    da.SelectCommand.Parameters.AddWithValue("@TODATE", DateTime.ParseExact(Todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }

                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet DistrictReport(string Distid, string FromDate, string ToDate, string ViewType)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(ReportCommon.GetDistrictReports, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = ReportCommon.GetDistrictReports;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@DISTRICTID", Distid);
                if (FromDate != null && FromDate != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@FROMDATE", DateTime.ParseExact(FromDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }
                if (ToDate != null && ToDate != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@TODATE", DateTime.ParseExact(ToDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }
                da.SelectCommand.Parameters.AddWithValue("@VIWETYPE", ViewType);
              

                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet CFEDeptWiseReport(string Department, string Formdate, string Todate)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(ReportCommon.GetCFEDeptReport, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = ReportCommon.GetCFEDeptReport;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@DEPTID", Department);              
                if (Formdate != null && Formdate != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@FDATE", DateTime.ParseExact(Formdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }
                if (Todate != null && Todate != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@TDATE", DateTime.ParseExact(Todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }

                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet CFEDeptwiseReportDrilldown(string Departid, string Formdate, string Todate)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(ReportCommon.GetCFEDeptWiseReportDrill, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = ReportCommon.GetCFEDeptWiseReportDrill;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@DEPTID", Departid);
                if (Formdate != null && Formdate != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@FDATE", DateTime.ParseExact(Formdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }
                if (Todate != null && Todate != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@TDATE", DateTime.ParseExact(Todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }
               


                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet CFODeptWiseReport(string Department, string Formdate, string Todate)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(ReportCommon.GetCFODeptReport, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = ReportCommon.GetCFODeptReport;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@DEPTID", Department);
                if (Formdate != null && Formdate != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@FDATE", DateTime.ParseExact(Formdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }
                if (Todate != null && Todate != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@TDATE", DateTime.ParseExact(Todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }

                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet CFODeptwiseReportDrilldown(string Departid, string Formdate, string Todate)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(ReportCommon.GetCFODeptWiseReportDrill, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = ReportCommon.GetCFODeptWiseReportDrill;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@DEPTID", Departid);
                if (Formdate != null && Formdate != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@FDATE", DateTime.ParseExact(Formdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }
                if (Todate != null && Todate != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@TDATE", DateTime.ParseExact(Todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }



                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet RENDeptWiseReport(string Department, string Formdate, string Todate)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(ReportCommon.GetRENDeptReport, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = ReportCommon.GetRENDeptReport;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@DEPTID", Department);
                if (Formdate != null && Formdate != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@FDATE", DateTime.ParseExact(Formdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }
                if (Todate != null && Todate != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@TDATE", DateTime.ParseExact(Todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }

                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
