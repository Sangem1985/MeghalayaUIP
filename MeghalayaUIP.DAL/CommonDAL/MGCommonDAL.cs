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
using System.Reflection;
using System.Xml.Linq;
using System.Diagnostics;
using System.Net;

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

        public DataSet GetMainApplicantDashBoard(string Investerid)
        {
            DataSet ds = new DataSet();
            //string valid = "";
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
                da.Fill(ds);

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
            return ds;
        }

        public int InsertGrievance(string RegisterType, string ModuleType, string UIDNo, string UnitID, string UnitName, string ApplcantName,
            string DistID, string Email, string Mobile, string intDeptid, string Subject, string Description, string Grivance_FilePath,
            string Grivance_FileType, string GrievnaceFileName, string Createdby, string IPAddress)
        {
            int valid = 0;

            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CommonConstants.InsertGrievance;

                com.Transaction = transaction;
                com.Connection = connection;


                if (RegisterType.Trim() == "" || RegisterType.Trim() == null)
                    com.Parameters.Add("@REGISTERTYPE", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@REGISTERTYPE", SqlDbType.VarChar).Value = RegisterType.Trim();

                if (ModuleType.ToString().Trim() == "" || ModuleType.ToString().Trim() == null)
                    com.Parameters.Add("@MODULETYPE", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@MODULETYPE", SqlDbType.VarChar).Value = ModuleType.Trim();

                if (UIDNo.Trim() == "" || UIDNo.Trim() == null)
                    com.Parameters.Add("@UID_NO", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@UID_NO", SqlDbType.VarChar).Value = UIDNo.Trim();

                if (UnitID.ToString().Trim() == "" || UnitID.ToString().Trim() == null)
                    com.Parameters.Add("@UNITID", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@UNITID", SqlDbType.VarChar).Value = UnitID.Trim();

                if (UnitName.ToString().Trim() == "" || UnitName.ToString().Trim() == null)
                    com.Parameters.Add("@UNITNAME", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@UNITNAME", SqlDbType.VarChar).Value = UnitName.Trim();

                if (ApplcantName.ToString().Trim() == "" || ApplcantName.ToString().Trim() == null)
                    com.Parameters.Add("@APPLICANTNAME", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@APPLICANTNAME", SqlDbType.VarChar).Value = ApplcantName.Trim();

                if (DistID.Trim() == "" || DistID == null)
                    com.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = DistID.Trim();

                if (Email.Trim() == "" || Email.Trim() == null)
                    com.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = Email.Trim();

                if (Mobile.Trim() == "" || Mobile.Trim() == null)
                    com.Parameters.Add("@MOBILE", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@MOBILE", SqlDbType.VarChar).Value = Mobile.Trim();

                if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
                    com.Parameters.Add("@INTDEPTID", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@INTDEPTID", SqlDbType.VarChar).Value = intDeptid.Trim();

                if (Subject.Trim() == "" || Subject.Trim() == null)
                    com.Parameters.Add("@SUBJECT", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@SUBJECT", SqlDbType.VarChar).Value = Subject.Trim();

                if (Description.Trim() == "" || Description.Trim() == null)
                    com.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar).Value = Description.Trim();

                if (Grivance_FilePath.Trim() == "" || Grivance_FilePath.Trim() == null)
                    com.Parameters.Add("@GRIVANCE_FILEPATH", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@GRIVANCE_FILEPATH", SqlDbType.VarChar).Value = Grivance_FilePath.Trim();

                if (Grivance_FileType.Trim() == "" || Grivance_FileType.Trim() == null)
                    com.Parameters.Add("@GRIVANCE_FILETYPE", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@GRIVANCE_FILETYPE", SqlDbType.VarChar).Value = Grivance_FileType.Trim();

                if (GrievnaceFileName.Trim() == "" || GrievnaceFileName.Trim() == null)
                    com.Parameters.Add("@GRIEVNACE_FILENAME", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@GRIEVNACE_FILENAME", SqlDbType.VarChar).Value = GrievnaceFileName.Trim();


                if (Createdby.Trim() == "" || Createdby.Trim() == null)
                    com.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = Createdby.Trim();
                if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
                    com.Parameters.Add("@CREATEDBYIP", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@CREATEDBYIP", SqlDbType.VarChar).Value = IPAddress.Trim();

                com.Parameters.Add("@valid", SqlDbType.Int, 500);
                com.Parameters["@valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                valid = (Int32)com.Parameters["@valid"].Value;

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
        public DataSet GetApplByModuleName(string UserID, string ModuleID)
        {
            DataSet ds = new DataSet();

            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CommonConstants.GetApplbyModuleName, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CommonConstants.GetApplbyModuleName;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;


                da.SelectCommand.Parameters.AddWithValue("@USERID", UserID);
                da.SelectCommand.Parameters.AddWithValue("@MODULETYPE", ModuleID);

                da.Fill(ds);

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
            return ds;
        }
        public DataSet GetCFEUserDashboardStatus(string UserID, string UnitID, string Type)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CommonConstants.GetUserCFETracker, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CommonConstants.GetUserCFETracker;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@USERID", UserID);
                da.SelectCommand.Parameters.AddWithValue("@UNITID", UnitID);
                da.SelectCommand.Parameters.AddWithValue("@TYPE", Type);
                da.Fill(ds);

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
            return ds;
        }

        public DataSet GetUserDashboardStatusByModule(string UserID, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CommonConstants.GetUserStatusByModule, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CommonConstants.GetUserStatusByModule;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@USERID", UserID);
                da.SelectCommand.Parameters.AddWithValue("@UNITID", UnitID);

                da.Fill(ds);

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
            return ds;
        }

        public DataSet GetUserGrievanceList(string UserID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CommonConstants.GetUserGrievanceList, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CommonConstants.GetUserGrievanceList;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@USERID", UserID);

                da.Fill(ds);

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
            return ds;
        }

        public DataSet GetGrowthFinancialYear()
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CommonConstants.GetGrowthFinancialYear, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CommonConstants.GetGrowthFinancialYear;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection; 

                da.Fill(ds);

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
            return ds;
        }        
        //---------------------------------dept------------------------//
        public DataSet GetDepGrievanceDashboard(string DeptID, string Userid)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CommonConstants.GetDeptGrievanceDashboard, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CommonConstants.GetDeptGrievanceDashboard;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@DEPTID", DeptID);
                da.SelectCommand.Parameters.AddWithValue("@USERID", Userid);

                da.Fill(ds);

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
            return ds;
        }
        public DataSet GetDepGrievanceList(string DeptID, string GrvncID, string Status)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CommonConstants.GetDepGrievanceList, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CommonConstants.GetDepGrievanceList;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@DEPTID", DeptID);
                da.SelectCommand.Parameters.AddWithValue("@GRIEVANCEID", GrvncID);
                da.SelectCommand.Parameters.AddWithValue("@STATUS", Status);

                da.Fill(ds);

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
            return ds;
        }
        public int UpdateGrievanceDeptProcess(string Process, string ProcessFalg, string Remarks, string ReplyFilePath, string ReplyFileType, string ReplyFileName,
                string GrvncID, string UserID, string DeptID, string IPAddress)
        {
            int valid = 0;

            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CommonConstants.UpdateGrievanceDeptProcess;

                com.Transaction = transaction;
                com.Connection = connection;

                if (Process.Trim() == "" || Process.Trim() == null)
                    com.Parameters.Add("@PROCESS", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@PROCESS", SqlDbType.VarChar).Value = Process.Trim();

                if (ProcessFalg.Trim() == "" || ProcessFalg.Trim() == null)
                    com.Parameters.Add("@PROCESSFLAG", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@PROCESSFLAG", SqlDbType.VarChar).Value = ProcessFalg.Trim();

                if (Remarks.ToString().Trim() == "")
                    com.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = Remarks.Trim();

                if (ReplyFilePath.Trim() == "")
                    com.Parameters.Add("@REPLYFILEPATH", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@REPLYFILEPATH", SqlDbType.VarChar).Value = ReplyFilePath.Trim();

                if (ReplyFileType.ToString().Trim() == "")
                    com.Parameters.Add("@REPLYFILETYPE", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@REPLYFILETYPE", SqlDbType.VarChar).Value = ReplyFileType.Trim();

                if (ReplyFileName.ToString().Trim() == "" || ReplyFileName.ToString().Trim() == null)
                    com.Parameters.Add("@REPLYFILENAME", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@REPLYFILENAME", SqlDbType.VarChar).Value = ReplyFileName.Trim();

                if (GrvncID.ToString().Trim() == "" || GrvncID.ToString().Trim() == null)
                    com.Parameters.Add("@GRIEVANCEID", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@GRIEVANCEID", SqlDbType.VarChar).Value = GrvncID.Trim();

                if (UserID.Trim() == "" || UserID == null)
                    com.Parameters.Add("@PROCESSBY", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@PROCESSBY", SqlDbType.VarChar).Value = UserID.Trim();

                if (DeptID.Trim() == "" || DeptID.Trim() == null)
                    com.Parameters.Add("@DEPTID", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@DEPTID", SqlDbType.VarChar).Value = DeptID.Trim();

                if (DeptID.Trim() == "" || DeptID.Trim() == null)
                    com.Parameters.Add("@PROCESSBYIP", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@PROCESSBYIP", SqlDbType.VarChar).Value = IPAddress.Trim();
                com.Parameters.Add("@VALID", SqlDbType.Int, 500);
                com.Parameters["@VALID"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                valid = (Int32)com.Parameters["@VALID"].Value;

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
