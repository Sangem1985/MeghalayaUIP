using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace MeghalayaUIP.DAL.LADAL
{
    public class LADAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();

        public string InsertindustrialareaDetails(LANDQUESTIONNAIRE Objindustry)
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
                //com.CommandText = LANDConstants.InsertIndustryDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@IE_CREATEDBY", Convert.ToInt32(Objindustry.CreatedBy));
                com.Parameters.AddWithValue("@IE_CREATEDBYIP", Objindustry.IPAddress);
                com.Parameters.AddWithValue("@IE_QDID", Convert.ToInt32(Objindustry.Questionnariid));
                com.Parameters.AddWithValue("@IE_UNITID", Convert.ToInt32(Objindustry.UnitId));

                com.Parameters.AddWithValue("@IE_NAMEOFINUSTRIALPARK", Objindustry.NAMEINDUSTRYPARK);
                com.Parameters.AddWithValue("@IE_LANDREQ", Objindustry.QUANTUMLAND);
                com.Parameters.AddWithValue("@IE_SHEDSNO", Objindustry.SHEDSNO);


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertLandIndState(LANDQUESTIONNAIRE Objindustry)
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
                com.CommandText = LANDConstants.InsertIndLandStateDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@IE_CREATEDBY", Convert.ToInt32(Objindustry.CreatedBy));
                com.Parameters.AddWithValue("@IE_CREATEDBYIP", Objindustry.IPAddress);
                com.Parameters.AddWithValue("@IE_QDID", Convert.ToInt32(Objindustry.Questionnariid));
                com.Parameters.AddWithValue("@IE_UNITID", Convert.ToInt32(Objindustry.UnitId));

                com.Parameters.AddWithValue("@IE_NAMEOFINUSTRIALPARK", Objindustry.NAMEINDUSTRYPARK);
                com.Parameters.AddWithValue("@IE_LANDREQ", Objindustry.QUANTUMLAND);
                com.Parameters.AddWithValue("@IE_SHEDSNO", Objindustry.SHEDSNO);


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertManufactureDetails(LANDQUESTIONNAIRE Objindustry)
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
                com.CommandText = LANDConstants.InsertManufactureDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@MD_CREATEDBY", Convert.ToInt32(Objindustry.CreatedBy));
                com.Parameters.AddWithValue("@MD_CREATEDBYIP", Objindustry.IPAddress);
                com.Parameters.AddWithValue("@MD_QDID", Convert.ToInt32(Objindustry.Questionnariid));
                com.Parameters.AddWithValue("@MD_UNITID", Convert.ToInt32(Objindustry.UnitId));

                com.Parameters.AddWithValue("@MD_NAMEOFPRODUCT", Objindustry.NAMEPRODUCT);
                com.Parameters.AddWithValue("@MD_ANNUALCAPACITY", Convert.ToDecimal(Objindustry.MUNUCAPACITY));
                com.Parameters.AddWithValue("@MD_APPROXVALUE", Convert.ToDecimal(Objindustry.APPROXVALUE));


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertRawMaterial(LANDQUESTIONNAIRE Objindustry)
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
                com.CommandText = LANDConstants.InsertRawMaterialDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@RD_CREATEDBY", Convert.ToInt32(Objindustry.CreatedBy));
                com.Parameters.AddWithValue("@RD_CREATEDBYIP", Objindustry.IPAddress);
                com.Parameters.AddWithValue("@RD_QDID", Convert.ToInt32(Objindustry.Questionnariid));
                com.Parameters.AddWithValue("@RD_UNITID", Convert.ToInt32(Objindustry.UnitId));

                com.Parameters.AddWithValue("@RD_NAMEOFRAWMATERIAL", Objindustry.RAWMATERIALNAME);
                com.Parameters.AddWithValue("@RD_ANNUALCONSUMPTIONCAPACITY", Convert.ToDecimal(Objindustry.ANNUALCONSUMPTION));
                com.Parameters.AddWithValue("@RD_APPOX", Convert.ToDecimal(Objindustry.APPROXVALUELAKH));


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertPowerdetails(LANDQUESTIONNAIRE Objindustry)
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
                com.CommandText = LANDConstants.InsertPowerDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@PD_CREATEDBY", Convert.ToInt32(Objindustry.CreatedBy));
                com.Parameters.AddWithValue("@PD_CREATEDBYIP", Objindustry.IPAddress);
                com.Parameters.AddWithValue("@PD_QDID", Convert.ToInt32(Objindustry.Questionnariid));
                com.Parameters.AddWithValue("@PD_UNITID", Convert.ToInt32(Objindustry.UnitId));

                com.Parameters.AddWithValue("@PD_QUANTUMENERGYLOAD", Convert.ToDecimal(Objindustry.QUANTUMENERGYLOAD));
                com.Parameters.AddWithValue("@PD_ENERGYLOAD", Objindustry.SOURCEENERGYLOAD);



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertWaterDetails(LANDQUESTIONNAIRE Objindustry)
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
                com.CommandText = LANDConstants.InsertWaterDetails;

                com.Transaction = transaction;
                com.Connection = connection;


                com.Parameters.AddWithValue("@WD_CREATEDBY", Convert.ToInt32(Objindustry.CreatedBy));
                com.Parameters.AddWithValue("@WD_CREATEDBYIP", Objindustry.IPAddress);
                com.Parameters.AddWithValue("@WD_QDID", Convert.ToInt32(Objindustry.Questionnariid));
                com.Parameters.AddWithValue("@WD_UNITID", Convert.ToInt32(Objindustry.UnitId));

                com.Parameters.AddWithValue("@WD_REQWATER", Objindustry.WATERMANU);
                com.Parameters.AddWithValue("@WD_SOURCEOFWATER", Objindustry.SOURCEWATER);



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string InsertIndustrialShedDetails(LANDQUESTIONNAIRE Objindustry)
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
                com.CommandText = LANDConstants.InsertIndustrialShedDetails;

                com.Transaction = transaction;
                com.Connection = connection;


                com.Parameters.AddWithValue("@ISD_CREATEDBY", Convert.ToInt32(Objindustry.CreatedBy));
                com.Parameters.AddWithValue("@ISD_CREATEDBYIP", Objindustry.IPAddress);
                com.Parameters.AddWithValue("@ISD_QDID", Objindustry.Questionnariid);
                com.Parameters.AddWithValue("@ISD_UNITID", Convert.ToInt32(Objindustry.UnitId));

                com.Parameters.AddWithValue("@ISD_NAMEOFCOMPANY", Objindustry.COMPANYNAME);
                com.Parameters.AddWithValue("@ISD_DISTRIC", Convert.ToInt32(Objindustry.DISTRIC));
                com.Parameters.AddWithValue("@ISD_MANDAL ", Convert.ToInt32(Objindustry.MANDAL));
                com.Parameters.AddWithValue("@ISD_VILLAGE", Convert.ToInt32(Objindustry.VILLAGE));
                com.Parameters.AddWithValue("@ISD_EQUITY", Objindustry.EQUITY);
                com.Parameters.AddWithValue("@ISD_LOANBANK", Objindustry.LOANBANK);
                com.Parameters.AddWithValue("@ISD_UNSECUREDLOAN", Objindustry.UnsecuredLOAN);
                com.Parameters.AddWithValue("@ISD_INTERNALRESOURCES", Objindustry.INTERNALRESOURCE);
                com.Parameters.AddWithValue("@ISD_OTHERSOURCE", Objindustry.OTHERSOURCE);
                com.Parameters.AddWithValue("@ISD_TOTAL", Convert.ToInt32(Objindustry.TOTAL));
                com.Parameters.AddWithValue("@ISD_CATEGORYENTERPRISE", Objindustry.ENTERPRISE);
                com.Parameters.AddWithValue("@ISD_PMLAKH", Convert.ToDecimal(Objindustry.PMLAKH));
                com.Parameters.AddWithValue("@ISD_PROJECTCOSTLAKH", Convert.ToDecimal(Objindustry.TOTALPROJECTCOST));
                com.Parameters.AddWithValue("@ISD_WASTEGENERATED", Objindustry.WASTEGENERATOR);
                //com.Parameters.AddWithValue("@ISD_NAMEOFINUSTRIALPARK", Objindustry.NAMEINDUSTRYPARK);
                //com.Parameters.AddWithValue("@ISD_LANDREQ", Objindustry.QUANTUMLAND);
                //com.Parameters.AddWithValue("@ISD_SHEDSNO", Objindustry.SHEDSNO);
                com.Parameters.AddWithValue("@ISD_LAUIDNO", Objindustry.UIDNO);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string SubmitLandApplication(LANDQUESTIONNAIRE Objindustry)
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
                com.CommandText = LANDConstants.SubmitLandApplication;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(Objindustry.CreatedBy));
                com.Parameters.AddWithValue("@QDID", Convert.ToInt32(Objindustry.Questionnariid));
                com.Parameters.AddWithValue("@UNITID", Convert.ToInt32(Objindustry.UnitId));
                com.Parameters.AddWithValue("@IPADDRESS",Objindustry.IPAddress);
                
                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public DataSet GetLANDPaymentAmounttoPay(string userid, string UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(LANDConstants.GetLANDApprovalsAmounttoPay, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = LANDConstants.GetLANDApprovalsAmounttoPay;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UNITID));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
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
        public DataSet GETIndustrialShedDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(LANDConstants.GetIndustrialShedDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = LANDConstants.GetIndustrialShedDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetLandUserDashboard(string userid, string unitid)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(LANDConstants.GetLandUserDashBoard, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = LANDConstants.GetLandUserDashBoard;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(userid));
                da.SelectCommand.Parameters.AddWithValue("@UNITID", unitid);


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
        public DataSet GetLandApplicationDetails(string UnitID, string InvesterID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(LANDConstants.GetLandApplicationDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = LANDConstants.GetLandApplicationDet;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(InvesterID));
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

        /////////////////////////////////////////////////-------------------------------------------------///////////////////

        public DataTable GetLADeptDashBoard(LADeptDtls objDtls)
        {
            DataTable dt = new DataTable();
            //string valid = "";
            //  IDno = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(LANDConstants.GetLandDeptDashBoard, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = LANDConstants.GetLandDeptDashBoard;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;


                da.SelectCommand.Parameters.AddWithValue("@USERID", objDtls.UserID);
                da.SelectCommand.Parameters.AddWithValue("@ROLEID", objDtls.Role);
                if (objDtls.deptid != null && objDtls.deptid != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@DEPTID", objDtls.deptid);
                }

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
        public DataTable GetLandAllottmentDashBoardView(LADeptDtls objDtls)
        {
           // string valid = "";
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(LANDConstants.GetLANDDashBoardView, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = LANDConstants.GetLANDDashBoardView;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                //PRD.deptid = 1;
                //PRD.status = 4;
                //PRD.Role = 0;

                da.SelectCommand.Parameters.AddWithValue("@USERID", objDtls.UserID);
                da.SelectCommand.Parameters.AddWithValue("@VIEWSTATUS", objDtls.ViewStatus);
                if (objDtls.deptid != null && objDtls.deptid != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@DEPTID", objDtls.deptid);
                }
                da.SelectCommand.Parameters.AddWithValue("@ROLEID", objDtls.Role);


                da.Fill(dt);
                // if (dt.Rows.Count > 0)
                //     valid = Convert.ToString(dt.Rows[0]["UNITID"]);
                //// IDno = valid;

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
        public DataSet GetLAAttachmentsData(string userid, string UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(LANDConstants.GetLAAttachments, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = LANDConstants.GetLAAttachments;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UNITID));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
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
        public string InsertLAAttachments(LAAttachments objAttachments)
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
                com.CommandText = LANDConstants.InsertLAAttachments;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@LAA_UNITID", Convert.ToInt32(objAttachments.UNITID));
                com.Parameters.AddWithValue("@LAA_LAQDID", Convert.ToInt32(objAttachments.Questionnareid));
                com.Parameters.AddWithValue("@LAA_QUERYID", objAttachments.QueryID);
                com.Parameters.AddWithValue("@LAA_MASTERAID", objAttachments.MasterID);
                com.Parameters.AddWithValue("@LAA_FILEPATH", objAttachments.FilePath);
                com.Parameters.AddWithValue("@LAA_FILENAME", objAttachments.FileName);
                com.Parameters.AddWithValue("@LAA_FILETYPE", objAttachments.FileType);
                com.Parameters.AddWithValue("@LAA_FILEDESCRIPTION", objAttachments.FileDescription);
                com.Parameters.AddWithValue("@LAA_DEPTID", objAttachments.DeptID);
                com.Parameters.AddWithValue("@LAA_APPROVALID", objAttachments.ApprovalID);
                com.Parameters.AddWithValue("@LAA_CREATEDBY", Convert.ToInt32(objAttachments.CreatedBy));
                com.Parameters.AddWithValue("@LAA_CREATEDBYIP", objAttachments.IPAddress);
                //if (objAttachments.ReferenceNo != null && objAttachments.ReferenceNo != "")
                //{
                //    com.Parameters.AddWithValue("@CFEA_REFERENCENO", objAttachments.ReferenceNo);
                //}
                if (objAttachments.UploadBy != null && objAttachments.UploadBy != "")
                {
                    com.Parameters.AddWithValue("@LAA_UPLOADBY", objAttachments.UploadBy);
                }
                if (objAttachments.UploadByID != null && objAttachments.UploadByID != "")
                {
                    com.Parameters.AddWithValue("@LAA_UPLOADBYID", objAttachments.UploadByID);
                }


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public string LADeptProcess(LANDALLOTMENTIND land)
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
                com.CommandText = LANDConstants.GetLandDetails;

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@UNITID", land.UNITID);
                com.Parameters.AddWithValue("@INVESTERID", land.Investerid);

                if (land.deptid != null && land.deptid != "")
                {
                    com.Parameters.AddWithValue("@DEPTID", land.deptid);
                }
                com.Parameters.AddWithValue("@ACTIONID", land.status);
                com.Parameters.AddWithValue("@REMARKS", land.Remarks);
              
                com.Parameters.AddWithValue("@IPADDRESS", land.IPAddress);
                com.Parameters.AddWithValue("@USERID", land.UserID);
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
