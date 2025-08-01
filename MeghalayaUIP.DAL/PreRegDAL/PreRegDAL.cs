﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Globalization;
using MeghalayaUIP.Common;
using System.Net;


namespace MeghalayaUIP.DAL.PreRegDAL
{
    public class PreRegDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();

        //-------------------USER METHODS-------------------------------------//
        public DataTable GetRevenueProjectionsMaster()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetRevenueProjectionsMaster, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetRevenueProjectionsMaster;

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
        public DataTable GetSectorDepartments(string sectorname)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetSectorDepartments, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetSectorDepartments;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@SECTOR", sectorname);
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
        public int InsertIndRegBasicDetails(IndustryDetails ID)
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
                da = new SqlDataAdapter(PreRegConstants.InsertIndRegBasicDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.InsertIndRegBasicDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(ID.UserID));
                da.SelectCommand.Parameters.AddWithValue("@IPADDRESS", ID.IPAddress);
                if (ID.CompnyRegDt != "" && ID.CompnyRegDt != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@REGISTRATIONDATE", DateTime.ParseExact(ID.CompnyRegDt, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }

                da.SelectCommand.Parameters.AddWithValue("@COMPANYNAME", ID.CompanyName);
                da.SelectCommand.Parameters.AddWithValue("@COMPANYPANNO", ID.CompanyPAN);
                da.SelectCommand.Parameters.AddWithValue("@COMPANYTYPE", ID.CompnyType);
                da.SelectCommand.Parameters.AddWithValue("@COMPANYPRAPOSAL", ID.CompnyProposal);
                da.SelectCommand.Parameters.AddWithValue("@UDYAMNO", ID.RegistrationNo);
                da.SelectCommand.Parameters.AddWithValue("@GSTNNO", ID.GSTNo);

                da.SelectCommand.Parameters.AddWithValue("@REP_NAME", ID.AuthReprName);
                da.SelectCommand.Parameters.AddWithValue("@REP_MOBILE", Convert.ToInt64(ID.AuthReprMobile));
                da.SelectCommand.Parameters.AddWithValue("@REP_EMAIL", ID.AuthReprEmail);
                da.SelectCommand.Parameters.AddWithValue("@REP_LOCALITY", ID.AuthReprLocality);
                da.SelectCommand.Parameters.AddWithValue("@STATEID", ID.REP_STATEID);
                if (ID.AuthReprDistID != "" && ID.AuthReprDistID != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@REP_DISTRICTID", Convert.ToInt32(ID.AuthReprDistID));
                }
                if (ID.AuthReprTalukaID != "" && ID.AuthReprTalukaID != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@REP_MANDALID", Convert.ToInt32(ID.AuthReprTalukaID));
                }
                if (ID.AuthReprVillageID != "" && ID.AuthReprVillageID != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@REP_VILLAGEID", Convert.ToInt32(ID.AuthReprVillageID));
                }
                da.SelectCommand.Parameters.AddWithValue("@REP_DISTRICTNAME", ID.REP_DISTRICNAME);
                da.SelectCommand.Parameters.AddWithValue("@REP_MANDALNAME", ID.REP_MANDALNAME);
                da.SelectCommand.Parameters.AddWithValue("@REP_VILLAGENAME", ID.REP_VILLAGENAME);
                da.SelectCommand.Parameters.AddWithValue("@REP_PINCODE", ID.AuthReprPincode);
                da.SelectCommand.Parameters.AddWithValue("@UNIT_LANDTYPE", ID.LandType);
                if (ID.PropLocDoorno != "")
                    da.SelectCommand.Parameters.AddWithValue("@UNIT_DOORNO", ID.PropLocDoorno);
                else
                    da.SelectCommand.Parameters.AddWithValue("@UNIT_DOORNO", null);


                da.SelectCommand.Parameters.AddWithValue("@UNIT_LOCALITY", ID.PropLocLocality);
                if (ID.PropLocDistID != "" && ID.PropLocDistID != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@UNIT_DISTRICTID", Convert.ToInt32(ID.PropLocDistID));
                }
                if (ID.PropLocTalukaID != "" && ID.PropLocTalukaID != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@UNIT_MANDALID", Convert.ToInt32(ID.PropLocTalukaID));
                }
                if (ID.PropLocVillageID != "" && ID.PropLocVillageID != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@UNIT_VILLAGEID", Convert.ToInt32(ID.PropLocVillageID));
                }
                da.SelectCommand.Parameters.AddWithValue("@UNIT_PINCODE", ID.PropLocPincode);
                if (ID.DCPorOperation != "" && ID.DCPorOperation != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_DCP", DateTime.ParseExact(ID.DCPorOperation, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_NOA", ID.NatureofActivity);

                if (ID.ManfActivity != "")
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_MANFACTIVITY", ID.ManfActivity);
                if (ID.Manfproduct != "")
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_MANFPRODUCT", ID.Manfproduct);
                if (ID.ProductionNO != "")
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_MANFPRODNO", ID.ProductionNO);
                if (ID.ServiceTobeProviding != "")
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_SRVCNAME", ID.ServiceTobeProviding);
                if (ID.ServiceActivity != "")
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_SRVCACTIVITY", ID.ServiceActivity);
                if (ID.ServiceNo != "")
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_SRVCNO", ID.ServiceNo);

                da.SelectCommand.Parameters.AddWithValue("@PROJECT_SECTORNAME", ID.SectorName);
                if (ID.Lineofacitivityid != "" && ID.Lineofacitivityid != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_LOAID", Convert.ToInt32(ID.Lineofacitivityid));
                }
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_PCBCATEGORY", ID.Category);

                da.SelectCommand.Parameters.AddWithValue("@PROJECT_MAINRM", ID.Rawmaterial);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_WASTEDETAILS", ID.WasteDetails);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_HAZWASTEDETAILS", ID.HazWasteDetails);

                da.SelectCommand.Parameters.AddWithValue("@PROJECT_CIVILCONSTR", ID.CivilConstr);
                if (ID.LandAreainSqft != "" && ID.LandAreainSqft != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_LANDAREA", Convert.ToDecimal(ID.LandAreainSqft));
                }
                if (ID.BuildingAreaSqm != "" && ID.BuildingAreaSqm != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_BUILDINGAREA", Convert.ToDecimal(ID.BuildingAreaSqm));
                }
                if (ID.WaterReqKLD != "" && ID.WaterReqKLD != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_WATERREQ", Convert.ToDecimal(ID.WaterReqKLD));
                }
                if (ID.PowerReqKV != "" && ID.PowerReqKV != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_POWERRREQ", Convert.ToDecimal(ID.PowerReqKV));
                }
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_UNITOFMEASURE", ID.MeasurementUnits);

                da.SelectCommand.Parameters.AddWithValue("@PROJECT_ANNUALCOST", ID.AnnualCapacity);
                if (ID.EstimatedProjCost != "" && ID.EstimatedProjCost != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_EPCOST", Convert.ToDecimal(ID.EstimatedProjCost));
                }
                if (ID.PlantnMachineryCost != "" && ID.PlantnMachineryCost != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_PMCOST", Convert.ToDecimal(ID.PlantnMachineryCost));
                }
                if (ID.CapitalInvestment != "" && ID.CapitalInvestment != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_IFC", Convert.ToDecimal(ID.CapitalInvestment));
                }
                if (ID.FixedAssets != "" && ID.FixedAssets != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_DFA", Convert.ToDecimal(ID.FixedAssets));
                }
                if (ID.LandValue != "" && ID.LandValue != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_LANDVALUE", Convert.ToDecimal(ID.LandValue));
                }
                if (ID.BuildingValue != "" && ID.BuildingValue != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_BUILDINGVALUE", Convert.ToDecimal(ID.BuildingValue));
                }
                if (ID.WaterValue != "" && ID.WaterValue != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_WATERVALUE", Convert.ToDecimal(ID.WaterValue));
                }
                if (ID.ElectricityValue != "" && ID.ElectricityValue != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_ELECTRICITYVALUE", Convert.ToDecimal(ID.ElectricityValue));
                }
                if (ID.WorkingCapital != "" && ID.WorkingCapital != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@PROJECT_WORKINGCAPITAL", Convert.ToDecimal(ID.WorkingCapital));
                }
                if (ID.CapitalSubsidy != "")
                    da.SelectCommand.Parameters.AddWithValue("@FRD_CAPITALSUBSIDY", Convert.ToDecimal(ID.CapitalSubsidy));
                if (ID.PromoterEquity != "")
                    da.SelectCommand.Parameters.AddWithValue("@FRD_PROMOTEREQUITY", Convert.ToDecimal(ID.PromoterEquity));
                if (ID.LoanAmount != "" && ID.LoanAmount != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@FRD_LOAN", Convert.ToDecimal(ID.LoanAmount));
                }
                da.SelectCommand.Parameters.AddWithValue("@STAGEID", 1);
                da.SelectCommand.Parameters.AddWithValue("@UNITID", ID.UnitID);
                da.SelectCommand.Parameters.AddWithValue("@DEPTID", ID.Deptid);
                if (ID.RegistrationType != "" && ID.RegistrationType != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@COMPANYREGTYPE", Convert.ToInt32(ID.RegistrationType));
                }
                da.SelectCommand.Parameters.AddWithValue("@COMPANYREGNO", ID.RegistrationNo);
                da.SelectCommand.Parameters.AddWithValue("@REP_DOORNO", ID.DoorNo);
                if (ID.EquityAmount != "" && ID.EquityAmount != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@FRD_EQUITY", Convert.ToDecimal(ID.EquityAmount));
                }
                if (ID.UnsecuredLoan != "" && ID.UnsecuredLoan != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@FRD_UNSECUREDLOAN", Convert.ToDecimal(ID.UnsecuredLoan));
                }
                if (ID.InternalResources != "" && ID.InternalResources != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@FRD_INTERNALRESOURCE", Convert.ToDecimal(ID.InternalResources));
                }
                if (ID.UnnatiSchemeAmount != "" && ID.UnnatiSchemeAmount != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@FRD_UNNATI", Convert.ToDecimal(ID.UnnatiSchemeAmount));
                }
                if (ID.CetralSchemeAmount != "" && ID.CetralSchemeAmount != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@FRD_CENTRAL", Convert.ToDecimal(ID.CetralSchemeAmount));
                }
                if (ID.StateSchemeAmount != "" && ID.StateSchemeAmount != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@FRD_STATE", Convert.ToDecimal(ID.StateSchemeAmount));
                }
                da.SelectCommand.Parameters.AddWithValue("@ELIGIBLE_FLAG", (ID.EligibleFlag));

                da.SelectCommand.Parameters.Add("@RESULT", SqlDbType.Int, 100);
                da.SelectCommand.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                valid = (Int32)da.SelectCommand.Parameters["@RESULT"].Value;


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
        public string InsertIndRegRevenueDetails(DataTable dt, string UNITID, string USERID)
        {
            string valid = "";

            SqlConnection connection = new SqlConnection(connstr);
            connection.Open();
            try
            {
                SqlParameter[] p = new SqlParameter[] {
                new SqlParameter("@TVP",SqlDbType.Structured),
                new SqlParameter("@UNITID",SqlDbType.Structured),
                new SqlParameter("@INVESTERID",SqlDbType.Structured) };
                p[0].Value = dt;
                p[1].Value = UNITID;
                p[2].Value = USERID;
                p[0].TypeName = "dbo.REVENUE_PROJEECTIONS";
                valid = Convert.ToString(SqlHelper.ExecuteNonQuery(connection, PreRegConstants.InsertIndRegRevenueDetails, p));

            }

            catch (Exception ex)
            {
                //transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }
        public string InsertIndustryRegDetails(DataTable dt, string UNITID, string USERID)
        {
            string valid = "";

            SqlConnection connection = new SqlConnection(connstr);
            //SqlTransaction transaction = null;
            connection.Open();
            //transaction = connection.BeginTransaction();
            try
            {
                SqlParameter[] p = new SqlParameter[] {
         new SqlParameter("@TVP",SqlDbType.Structured),
         new SqlParameter("@UNITID",SqlDbType.Structured),
        new SqlParameter("@INVESTERID",SqlDbType.Structured) };
                p[0].Value = dt;
                p[1].Value = UNITID;
                p[2].Value = USERID;
                p[0].TypeName = "dbo.DIRECTOR_DETAILS";
                valid = Convert.ToString(SqlHelper.ExecuteNonQuery(connection, PreRegConstants.InsertIndustryRegistration, p));

                //transaction.Commit();
                connection.Close();
            }

            catch (Exception ex)
            {
                // transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }
        public string InsertIndPromotersDetails(DataTable dt, string UNITID, string USERID)
        {
            string valid = "";

            SqlConnection connection = new SqlConnection(connstr);
            //SqlTransaction transaction = null;
            connection.Open();
            //transaction = connection.BeginTransaction();
            try
            {
                SqlParameter[] p = new SqlParameter[] {
         new SqlParameter("@TVP",SqlDbType.Structured),
         new SqlParameter("@UNITID",SqlDbType.Structured),
        new SqlParameter("@INVESTERID",SqlDbType.Structured) };
                p[0].Value = dt;
                p[1].Value = UNITID;
                p[2].Value = USERID;
                p[0].TypeName = "dbo.DIRECTOR_DETAILS";
                valid = Convert.ToString(SqlHelper.ExecuteNonQuery(connection, PreRegConstants.InsertIndRegPromotersDetails, p));

                //transaction.Commit();
                connection.Close();
            }

            catch (Exception ex)
            {
                // transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }
        public int InsertAttachments_PREREG(IndustryDetails objattachments)
        {
            int valid = 0;

            SqlConnection connection = new SqlConnection(connstr);
            //SqlTransaction transaction = null;
            connection.Open();
            //transaction = connection.BeginTransaction();
            try
            {
                SqlParameter[] p = new SqlParameter[] {
                new SqlParameter("@UNITID",SqlDbType.Structured),
                new SqlParameter("@INVESTORID",SqlDbType.Structured),
                new SqlParameter("@FILETYPE",SqlDbType.Structured),
                new SqlParameter("@FILEPATH",SqlDbType.Structured),
                new SqlParameter("@FILENAME",SqlDbType.Structured),
                new SqlParameter("@FILEDESCRIPTION",SqlDbType.Structured),
                new SqlParameter("@DEPTID",SqlDbType.Structured),
                new SqlParameter("@APPROVALID",SqlDbType.Structured),
                };

                p[0].Value = objattachments.UnitID;
                p[1].Value = objattachments.UserID;
                p[2].Value = objattachments.FileType;

                p[3].Value = objattachments.Filepath;
                p[4].Value = objattachments.FileName;
                p[5].Value = objattachments.FileDescription;
                p[6].Value = objattachments.Deptid;
                p[7].Value = objattachments.ApprovalId;
                string A = "";
                A = Convert.ToString(SqlHelper.ExecuteNonQuery(connection, PreRegConstants.InsertAttachmentDetails, p));
                valid = Convert.ToInt16(A);
                //transaction.Commit();
                connection.Close();
            }

            catch (Exception ex)
            {
                // transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }
        public int InsertAttachments_PREREG_RESPONSE(IndustryDetails objattachments)
        {
            int valid = 0;

            SqlConnection connection = new SqlConnection(connstr);
            connection.Open();
            try
            {
                SqlParameter[] p = new SqlParameter[] {
                new SqlParameter("@UNITID",SqlDbType.Structured),
                new SqlParameter("@INVESTORID",SqlDbType.Structured),
                new SqlParameter("@FILETYPE",SqlDbType.Structured),
                new SqlParameter("@FILEPATH",SqlDbType.Structured),
                new SqlParameter("@FILENAME",SqlDbType.Structured),
                new SqlParameter("@FILEDESCRIPTION",SqlDbType.Structured),
                new SqlParameter("@DEPTID",SqlDbType.Structured),
                new SqlParameter("@APPROVALID",SqlDbType.Structured),
                new SqlParameter("@QUERYID",SqlDbType.Structured),
                new SqlParameter("@CREATEBY",SqlDbType.Structured),
                new SqlParameter("@RESPONSEFILEBY",SqlDbType.Structured),

                };

                p[0].Value = objattachments.UnitID;
                p[1].Value = objattachments.InvestorId;
                p[2].Value = objattachments.FileType;
                p[3].Value = objattachments.Filepath;
                p[4].Value = objattachments.FileName;
                p[5].Value = objattachments.FileDescription;
                p[6].Value = objattachments.Deptid;
                p[7].Value = objattachments.ApprovalId;
                p[8].Value = objattachments.QueryID;
                p[9].Value = objattachments.UserID;
                p[10].Value = objattachments.ResponseFileBy;
                string A = "";
                A = Convert.ToString(SqlHelper.ExecuteNonQuery(connection, PreRegConstants.InsertAttachmentDetails_Reponse, p));
                valid = Convert.ToInt16(A);
                //transaction.Commit();
                connection.Close();
            }

            catch (Exception ex)
            {
                // transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }
        public DataSet GetIndustryRegData(string userid)
        {

            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetIndustryRegData, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetIndustryRegData;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(userid));
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

        public DataSet GetIndustryRegUserDashboard(string userid, string UnitID, string Status)
        {

            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetIndustryRegUserDashboard, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetIndustryRegUserDashboard;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(userid));
                da.SelectCommand.Parameters.AddWithValue("@UNITID", UnitID);
                da.SelectCommand.Parameters.AddWithValue("@STATUS", Status);
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

        public DataSet GetIndRegUserApplDetails(string UnitID, string InvesterID)
        {

            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetIndRegUserApplDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetIndRegUserApplDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(InvesterID));
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
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

        public string UpdateIndRegApplQueryRespose(PreRegDtls ID)
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
                com.CommandText = PreRegConstants.UpdateIndRegApplQueryRespose;

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@UNITID", Convert.ToInt32(ID.Unitid));
                com.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(ID.Investerid));
                com.Parameters.AddWithValue("@IRQID", Convert.ToInt32(ID.QueryID));
                com.Parameters.AddWithValue("@DEPTID", Convert.ToInt32(ID.QuerytoDeptID));
                com.Parameters.AddWithValue("@RESPONSE", ID.QueryResponse);
                com.Parameters.AddWithValue("@IPADDRESS", ID.IPAddress);
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
        public DataSet GetIndustryRegistrationQueryDetails(string Unitid, string InvesterID, string Queryid)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetIndustryRegistrationQueryDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetIndustryRegistrationQueryDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(InvesterID));
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(Unitid));
                if (Queryid != "" && Queryid != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@QUERYID", Convert.ToInt32(Queryid));
                }
                da.Fill(ds);
                if (ds.Tables.Count > 0)

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

        //-------------------END OF USER METHODS-------------------------------------//
        public DataTable GetPreRegDashBoard(PreRegDtls PRD)
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
                da = new SqlDataAdapter(PreRegConstants.GetPreRegDashBoard, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetPreRegDashBoard;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;


                da.SelectCommand.Parameters.AddWithValue("@USERID", PRD.UserID);
                da.SelectCommand.Parameters.AddWithValue("@ROLEID", PRD.Role);
                if (PRD.deptid != null && PRD.deptid != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@DEPTID", PRD.deptid);
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
        public DataTable GetPreRegDashBoardView(PreRegDtls PRD)
        {
            string valid = "";
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetPreRegDashBoardView, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetPreRegDashBoardView;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                //PRD.deptid = 1;
                //PRD.status = 4;
                //PRD.Role = 0;

                da.SelectCommand.Parameters.AddWithValue("@USERID", PRD.UserID);
                da.SelectCommand.Parameters.AddWithValue("@VIEWSTATUS", PRD.ViewStatus);
                if (PRD.deptid != null && PRD.deptid != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@DEPTID", PRD.deptid);
                }
                da.SelectCommand.Parameters.AddWithValue("@ROLEID", PRD.Role);


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
        public DataSet GetPreRegNodelOfficer(PreRegDtls PRD)
        {

            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetPreRegNodelOfficer, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetPreRegNodelOfficer;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", PRD.Unitid);
                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", PRD.Investerid);
                da.SelectCommand.Parameters.AddWithValue("@USERID", PRD.UserID);
                da.SelectCommand.Parameters.AddWithValue("@ROLEID", PRD.Role);
                if (PRD.deptid != null && PRD.deptid != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("DEPTID", PRD.deptid);
                }

                da.Fill(ds);
                if (ds.Tables.Count > 0)
                    //   valid = Convert.ToString(dt.Rows[0]["UNITID"]);
                    // IDno = valid;

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
        public string PreRegApprovals(PreRegDtls PRD)
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
                com.CommandText = PreRegConstants.GetPreRegApprovals;

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@UNITID", PRD.Unitid);
                com.Parameters.AddWithValue("@INVESTERID", PRD.Investerid);
                if (PRD.deptid != null && PRD.deptid != 0)
                {
                    com.Parameters.AddWithValue("@DEPTID", PRD.deptid);
                }
                com.Parameters.AddWithValue("@ACTIONID", PRD.status);
                com.Parameters.AddWithValue("@REMARKS", PRD.Remarks);
                com.Parameters.AddWithValue("@QUERY", PRD.QuerytoDept);
                if (PRD.LandArea != null && PRD.LandArea != "")
                {
                    com.Parameters.AddWithValue("@COMMLANDAREA", PRD.LandArea);
                }
                if (PRD.Power != null && PRD.Power != "")
                {
                    com.Parameters.AddWithValue("@COMMPOWER", PRD.Power);
                }
                if (PRD.Water != null && PRD.Water != "")
                {
                    com.Parameters.AddWithValue("@COMMWATER", PRD.Water);
                }
                if (PRD.WasteDetails != null && PRD.WasteDetails != "")
                {
                    com.Parameters.AddWithValue("@COMMWASTEDETAILS", PRD.WasteDetails);
                }
                if (PRD.HazDetails != null && PRD.HazDetails != "")
                {
                    com.Parameters.AddWithValue("@COMMHAZDETAILS", PRD.HazDetails);
                }
                com.Parameters.AddWithValue("@IPADDRESS", PRD.IPAddress);
                com.Parameters.AddWithValue("@USERID", PRD.UserID);
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



            //string valid = "";
            //DataTable dt = new DataTable();
            //SqlConnection connection = new SqlConnection(connstr);
            //SqlTransaction transaction = null;
            //connection.Open();
            //transaction = connection.BeginTransaction();
            //try
            //{

            //    SqlDataAdapter da;
            //    da = new SqlDataAdapter(IndustryRegConstants.GetPreRegApprovals, connection);
            //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    da.SelectCommand.CommandText = IndustryRegConstants.GetPreRegApprovals;

            //    da.SelectCommand.Transaction = transaction;
            //    da.SelectCommand.Connection = connection;

            //    da.SelectCommand.Parameters.AddWithValue("@UNITID", PRD.Unitid);
            //    da.SelectCommand.Parameters.AddWithValue("@INVESTERID", PRD.Investerid);
            //    da.SelectCommand.Parameters.AddWithValue("@STATUS", PRD.status);
            //    da.SelectCommand.Parameters.AddWithValue("@USERID", PRD.UserID);
            //    da.SelectCommand.Parameters.AddWithValue("@IPADDRESS", PRD.IPAddress);
            //    da.SelectCommand.Parameters.AddWithValue("@REMARKS", PRD.Remarks);

            //    /* da.SelectCommand.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
            //     da.SelectCommand.Parameters["@Valid"].Direction = ParameterDirection.Output;
            //     da.SelectCommand.Parameters.Add("@NewWork_progress_code", SqlDbType.VarChar, 500);
            //     da.SelectCommand.Parameters["@NewWork_progress_code"].Direction = ParameterDirection.Output;*/
            //    da.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //        valid = Convert.ToString(dt.Rows[0]["UNITID"]);
            //    //IDno = valid;

            //    transaction.Commit();
            //    connection.Close();
            //}
            //catch (Exception ex)
            //{
            //    transaction.Rollback();
            //    throw ex;
            //}
            //finally
            //{
            //    connection.Close();
            //    connection.Dispose();
            //}
            //return dt;
        }
        public string PreRegUpdateQuery(PreRegDtls PRD)
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
                com.CommandText = PreRegConstants.PreRegUpdateQuery;

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@UNITID", PRD.Unitid);
                com.Parameters.AddWithValue("@INVESTERID", PRD.Investerid);
                if (PRD.deptid != null && PRD.deptid != 0)
                {
                    com.Parameters.AddWithValue("@DEPTID", PRD.deptid);
                }
                com.Parameters.AddWithValue("@ACTIONID", PRD.status);
                com.Parameters.AddWithValue("@REMARKS", PRD.Remarks);
                if (PRD.QuerytoDeptID != null && PRD.QuerytoDeptID != "0")
                {
                    com.Parameters.AddWithValue("@QUERYTODEPTID", PRD.QuerytoDeptID);
                }
                if (PRD.deptid != null && PRD.deptid != 0)
                {
                    com.Parameters.AddWithValue("@QUERYTODEPT", PRD.deptid);
                }
                if (PRD.QueryID != null && PRD.QueryID != "0")
                {
                    com.Parameters.AddWithValue("@QueryID", PRD.QueryID);
                }
                if (PRD.@QueryResponse != null && PRD.@QueryResponse != "")
                {
                    com.Parameters.AddWithValue("@QueryResponse", PRD.@QueryResponse);
                }
                com.Parameters.AddWithValue("@IPADDRESS", PRD.IPAddress);
                com.Parameters.AddWithValue("@USERID", PRD.UserID);
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
        public string PreRegUpdateQueryDC(PreRegDtls PRD)
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
                com.CommandText = PreRegConstants.PreRegUpdateQueryDC;

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@UNITID", PRD.Unitid);
                com.Parameters.AddWithValue("@INVESTERID", PRD.Investerid);
                if (PRD.deptid != null && PRD.deptid != 0)
                {
                    com.Parameters.AddWithValue("@DEPTID", PRD.deptid);
                }
                com.Parameters.AddWithValue("@ACTIONID", PRD.status);
                com.Parameters.AddWithValue("@REMARKS", PRD.Remarks);
                if (PRD.QuerytoDeptID != null && PRD.QuerytoDeptID != "0")
                {
                    com.Parameters.AddWithValue("@QUERYTODEPTID", PRD.QuerytoDeptID);
                }
                if (PRD.deptid != null && PRD.deptid != 0)
                {
                    com.Parameters.AddWithValue("@QUERYTODEPT", PRD.deptid);
                }
                if (PRD.QueryID != null && PRD.QueryID != "0")
                {
                    com.Parameters.AddWithValue("@QueryID", PRD.QueryID);
                }
                if (PRD.@QueryResponse != null && PRD.@QueryResponse != "")
                {
                    com.Parameters.AddWithValue("@QueryResponse", PRD.@QueryResponse);
                }
                com.Parameters.AddWithValue("@IPADDRESS", PRD.IPAddress);
                com.Parameters.AddWithValue("@USERID", PRD.UserID);
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
        //public string InsertDeptDetails(DataTable dt)
        //{
        //    string valid = "";

        //    SqlConnection connection = new SqlConnection(connstr);
        //    //SqlTransaction transaction = null;
        //    connection.Open();
        //    // transaction = connection.BeginTransaction();
        //    try
        //    {
        //        SqlParameter[] p = new SqlParameter[] {
        //        new SqlParameter("@DS",SqlDbType.Structured) };
        //        p[0].Value = dt;
        //        p[0].TypeName = "dbo.DEPARTMENT_SELECTIONS";
        //        valid = Convert.ToString(SqlHelper.ExecuteNonQuery(connection, PreRegConstants.InsertPreRegJDDept, p));

        //        //transaction.Commit();
        //        //connection.Close();
        //    }

        //    catch (Exception ex)
        //    {
        //        //transaction.Rollback();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //        connection.Dispose();
        //    }
        //    return valid;
        //}
        public DataSet GetDeptMst(string Unitid, string Userid)
        {

            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetDeptMst, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetDeptMst;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Unitid);
                da.SelectCommand.Parameters.AddWithValue("@USERID", Userid);

                da.Fill(ds);
                if (ds.Tables.Count > 0)
                    //   valid = Convert.ToString(dt.Rows[0]["UNITID"]);
                    // IDno = valid;

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
        public DataSet GetDeptMst1(string Unitid, string Userid)
        {

            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetDeptMst1, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetDeptMst1;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Unitid);
                da.SelectCommand.Parameters.AddWithValue("@USERID", Userid);

                da.Fill(ds);
                if (ds.Tables.Count > 0)
                    //   valid = Convert.ToString(dt.Rows[0]["UNITID"]);
                    // IDno = valid;

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
        public DataTable GetIntentInvestDashBoard()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetIntentInvestdash, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetIntentInvestdash;

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
        public DataTable PreRegDPRDashBoard(PreRegDtls PRD)
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
                da = new SqlDataAdapter(PreRegConstants.GetPreRegDPRDashBoard, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetPreRegDPRDashBoard;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;


                da.SelectCommand.Parameters.AddWithValue("@USERID", PRD.UserID);
                da.SelectCommand.Parameters.AddWithValue("@ROLEID", PRD.Role);
                if (PRD.deptid != null && PRD.deptid != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@DEPTID", PRD.deptid);
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
        public DataTable GetPreRegDPRDashBoardView(PreRegDtls PRD)
        {
            string valid = "";
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetPreRegDPRDashBoardView, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetPreRegDPRDashBoardView;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                //PRD.deptid = 1;
                //PRD.status = 4;
                //PRD.Role = 0;

                da.SelectCommand.Parameters.AddWithValue("@USERID", PRD.UserID);
                da.SelectCommand.Parameters.AddWithValue("@VIEWSTATUS", PRD.ViewStatus);
                if (PRD.deptid != null && PRD.deptid != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@DEPTID", PRD.deptid);
                }
                da.SelectCommand.Parameters.AddWithValue("@ROLEID", PRD.Role);


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

        public string DPRDeptProcess(PreRegDtls prd)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetDPRDeptProcess, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetDPRDeptProcess;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(prd.Unitid));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(prd.DPRCRETEDBY));
                da.SelectCommand.Parameters.AddWithValue("@CHECKLISTID", Convert.ToInt32(prd.DPRCHECKLIST));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBYIP", prd.DPRBYIP);
                da.SelectCommand.Parameters.AddWithValue("@VERIFYFLAG", prd.VERIFYFLAG);


                da.SelectCommand.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                da.SelectCommand.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                valid = da.SelectCommand.Parameters["@RESULT"].Value.ToString();


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
        public string PreRegDISTRPTSAVE(DistrictSiteReport report)
        {
            string reportid = "0";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(PreRegConstants.SaveDistrictSiteReport, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                // Add parameters to the command
                cmd.Parameters.AddWithValue("@UnitId", Convert.ToInt32(report.UnitId));
                cmd.Parameters.AddWithValue("@UnitName", report.UnitName);
                cmd.Parameters.AddWithValue("@UnitLocation", report.UnitLocation);
                cmd.Parameters.AddWithValue("@GpsCoordinates", report.GpsCoordinates);
                cmd.Parameters.AddWithValue("@SiteArea", report.SiteArea);
                cmd.Parameters.AddWithValue("@Ownership", report.Ownership);
                cmd.Parameters.AddWithValue("@UnderPossession", report.UnderPossession);
                cmd.Parameters.AddWithValue("@DistanceFromMainRoad", report.DistanceFromMainRoad);
                cmd.Parameters.AddWithValue("@RoadType", report.RoadType);
                cmd.Parameters.AddWithValue("@ConstructionCommencement", report.ConstructionCommencement);
                cmd.Parameters.AddWithValue("@AnyNaturalBodies", report.AnyNaturalBodies);
                cmd.Parameters.AddWithValue("@EnvVulnerableLoc", report.EnvVulnerableLoc);
                cmd.Parameters.AddWithValue("@AvailabilityOfPower", report.AvailabilityOfPower);
                cmd.Parameters.AddWithValue("@AvailabilityOfWater", report.AvailabilityOfWater);
                cmd.Parameters.AddWithValue("@OtherObservations", report.OtherObservations);
                cmd.Parameters.AddWithValue("@Comments", report.Comments);
                cmd.Parameters.AddWithValue("@CreatedBy", report.createdBy);
                cmd.Parameters.AddWithValue("@IpAddress", report.ipAddress);
                cmd.Parameters.AddWithValue("@DATEOFINSPECTION", DateTime.ParseExact(report.DateInspection, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));

                cmd.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                cmd.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                reportid = cmd.Parameters["@RESULT"].Value.ToString();



                // Execute the command

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
            return reportid;

        }

        public string PreRegDistSaveTeam(string reportid, DistrictSiteInspectionTeam teamMember)
        {
            string valid = "0";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmd = new SqlCommand(PreRegConstants.InsertTeamMember, connection);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                // Add parameters to the command
                cmd.Parameters.AddWithValue("@ReportId", reportid);
                cmd.Parameters.AddWithValue("@MemberName", teamMember.MemberName);
                cmd.Parameters.AddWithValue("@Designation", teamMember.Designation);
                cmd.Parameters.AddWithValue("@District", teamMember.District);
                cmd.Parameters.AddWithValue("@CreatedBy", teamMember.createdBy);
                cmd.Parameters.AddWithValue("@IpAddress", teamMember.ipAddress);



                // Execute the command
                cmd.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                cmd.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                valid = cmd.Parameters["@RESULT"].Value.ToString();


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
        public string PreRegDITProcess(PreRegDtls prd)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetPreRegDITProcess, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetPreRegDITProcess;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(prd.Unitid));
                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(prd.Investerid));
                da.SelectCommand.Parameters.AddWithValue("@DCDEPTID", Convert.ToInt32(prd.deptid));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(prd.DPRCRETEDBY));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDIP", prd.IPAddress);
                da.SelectCommand.Parameters.AddWithValue("@REMARK", prd.Remark);
                da.SelectCommand.Parameters.AddWithValue("@ACTION", Convert.ToInt32(prd.Forward));


                da.SelectCommand.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                da.SelectCommand.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                valid = da.SelectCommand.Parameters["@RESULT"].Value.ToString();


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
       /* public string PreRegDITProcessDIC1(PreRegDtls prd)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetPreRegDITProcessDICFORWARD, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetPreRegDITProcessDICFORWARD;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(prd.Unitid));
                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(prd.Investerid));
                da.SelectCommand.Parameters.AddWithValue("@DCDEPTID", Convert.ToInt32(prd.deptid));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(prd.DPRCRETEDBY));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDIP", prd.IPAddress);
                da.SelectCommand.Parameters.AddWithValue("@REMARK", prd.Remark);
                da.SelectCommand.Parameters.AddWithValue("@ACTION", Convert.ToInt32(prd.Forward));


                da.SelectCommand.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                da.SelectCommand.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                valid = da.SelectCommand.Parameters["@RESULT"].Value.ToString();


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
        }*/
        public string PreRegDICProcess(PreRegDtls prd)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetPreRegDICProcess, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetPreRegDICProcess;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(prd.Unitid));
                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(prd.Investerid));
                da.SelectCommand.Parameters.AddWithValue("@DCDEPTID", Convert.ToInt32(prd.deptid));
                if (prd.DCFORWARD != "" && prd.DCFORWARD != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@ACTION", Convert.ToInt32(prd.DCFORWARD));
                }
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(prd.DPRCRETEDBY));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDIP", prd.IPAddress);
                da.SelectCommand.Parameters.AddWithValue("@REMARK", prd.Remark);


                da.SelectCommand.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                da.SelectCommand.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                valid = da.SelectCommand.Parameters["@RESULT"].Value.ToString();


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
        public DataSet GetDitSiteReportby(string unitId, string createdBy)
        {

            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(PreRegConstants.GetDitSiteReport, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = PreRegConstants.GetDitSiteReport;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@Unitid", Convert.ToInt32(unitId));
                da.SelectCommand.Parameters.AddWithValue("@Createdby", Convert.ToInt32(createdBy));


                da.Fill(ds);
                if (ds.Tables.Count > 0)
                    //   valid = Convert.ToString(dt.Rows[0]["UNITID"]);
                    // IDno = valid;

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
