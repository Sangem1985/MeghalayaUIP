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

        public DataSet GetMainApplicantDashBoard(string Investerid)
        {
            DataSet ds = new DataSet();
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

        public int InsertGrievance(string IndustryName, string intDistrictid, string Email, string MobileNumber, string intDeptid, string Grivance_Subject, string Grievance_Description, string Grivance_File_Path, string Grivance_File_Type, string Grievnace_FileName, string Created_by, string Register_Your, string uidno, string Grivance_ID)
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
                if (IndustryName.Trim() == "" || IndustryName.Trim() == null)
                    com.Parameters.Add("@IndustryName", SqlDbType.VarChar).Value = IndustryName.Trim();
                else
                    com.Parameters.Add("@IndustryName", SqlDbType.VarChar).Value = IndustryName.Trim();

                if (intDistrictid.Trim() == "" || intDistrictid == null)
                    com.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = intDistrictid.Trim();

                if (Email.Trim() == "" || Email.Trim() == null)
                    com.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email.Trim();
                else
                    com.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email.Trim();

                if (MobileNumber.Trim() == "" || MobileNumber.Trim() == null)
                    com.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = MobileNumber.Trim();

                if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
                    com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

                if (Grivance_Subject.Trim() == "" || Grivance_Subject.Trim() == null)
                    com.Parameters.Add("@Grivance_Subject", SqlDbType.VarChar).Value = Grivance_Subject.Trim();
                else
                    com.Parameters.Add("@Grivance_Subject", SqlDbType.VarChar).Value = Grivance_Subject.Trim();

                if (Grievance_Description.Trim() == "" || Grievance_Description.Trim() == null)
                    com.Parameters.Add("@Grievance_Description", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Grievance_Description", SqlDbType.VarChar).Value = Grievance_Description.Trim();

                if (Grivance_File_Path.Trim() == "" || Grivance_File_Path.Trim() == null)
                    com.Parameters.Add("@Grivance_File_Path", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Grivance_File_Path", SqlDbType.VarChar).Value = Grivance_File_Path.Trim();

                if (Grivance_File_Type.Trim() == "" || Grivance_File_Type.Trim() == null)
                    com.Parameters.Add("@Grivance_File_Type", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Grivance_File_Type", SqlDbType.VarChar).Value = Grivance_File_Type.Trim();

                if (Grievnace_FileName.Trim() == "" || Grievnace_FileName.Trim() == null)
                    com.Parameters.Add("@Grievnace_FileName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Grievnace_FileName", SqlDbType.VarChar).Value = Grievnace_FileName.Trim();


                if (Created_by.Trim() == "" || Created_by.Trim() == null)
                    com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
                if (Register_Your.Trim() == "" || Register_Your.Trim() == null)
                    com.Parameters.Add("@Register_Your", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Register_Your", SqlDbType.VarChar).Value = Register_Your.Trim();

                if (uidno.Trim() == "" || uidno.Trim() == null)
                    com.Parameters.Add("@Uidno", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Uidno", SqlDbType.VarChar).Value = uidno.Trim();

                if (Grivance_ID.ToString().Trim() == "" || Grivance_ID.ToString().Trim() == null)
                    com.Parameters.Add("@Grivance_ID", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Grivance_ID", SqlDbType.VarChar).Value = Grivance_ID.Trim();

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
    }
}
