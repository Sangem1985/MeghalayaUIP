using System;
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
        public string InsertIndRegBasicDetails(IndustryDetails ID, out string IDno)
        {
            string valid = "";
            IDno = "";
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

                da.SelectCommand.Parameters.AddWithValue("@REGISTRATIONDATE", Convert.ToDateTime(ID.CompnyRegDt).ToString("yyyy-dd-MM"));
                da.SelectCommand.Parameters.AddWithValue("@COMPANYNAME", ID.CompanyName);
                da.SelectCommand.Parameters.AddWithValue("@COMPANYPANNO", ID.CompanyPAN);
                da.SelectCommand.Parameters.AddWithValue("@COMPANYTYPE", ID.CompnyType);
                da.SelectCommand.Parameters.AddWithValue("@UDYAMNO", ID.UdyamorIEMNo);
                da.SelectCommand.Parameters.AddWithValue("@GSTNNO", ID.GSTNo);

                da.SelectCommand.Parameters.AddWithValue("@REP_NAME", ID.AuthReprName);
                da.SelectCommand.Parameters.AddWithValue("@REP_MOBILE", Convert.ToInt64(ID.AuthReprMobile));
                da.SelectCommand.Parameters.AddWithValue("@REP_EMAIL", ID.AuthReprEmail);
                da.SelectCommand.Parameters.AddWithValue("@REP_LOCALITY", ID.AuthReprLocality);
                da.SelectCommand.Parameters.AddWithValue("@REP_DISTRICTID", Convert.ToInt32(ID.AuthReprDistID));
                da.SelectCommand.Parameters.AddWithValue("@REP_MANDALID", Convert.ToInt32(ID.AuthReprTalukaID));
                da.SelectCommand.Parameters.AddWithValue("@REP_VILLAGEID", Convert.ToInt32(ID.AuthReprVillageID));
                da.SelectCommand.Parameters.AddWithValue("@REP_PINCODE", ID.AuthReprPincode);
                da.SelectCommand.Parameters.AddWithValue("@UNIT_LANDTYPE", ID.LandType);

                da.SelectCommand.Parameters.AddWithValue("@UNIT_DOORNO", ID.PropLocDoorno);
                da.SelectCommand.Parameters.AddWithValue("@UNIT_LOCALITY", ID.PropLocLocality);
                da.SelectCommand.Parameters.AddWithValue("@UNIT_DISTRICTID", Convert.ToInt32(ID.PropLocDistID));
                da.SelectCommand.Parameters.AddWithValue("@UNIT_MANDALID", Convert.ToInt32(ID.PropLocTalukaID));
                da.SelectCommand.Parameters.AddWithValue("@UNIT_VILLAGEID", Convert.ToInt32(ID.PropLocVillageID));
                da.SelectCommand.Parameters.AddWithValue("@UNIT_PINCODE", ID.PropLocPincode);

                da.SelectCommand.Parameters.AddWithValue("@PROJECT_DCP", Convert.ToDateTime(ID.DCPorOperation).ToString("yyyy-dd-MM"));
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_NOA", ID.NatureofActivity);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_MANFACTIVITY", ID.ManfActivity);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_MANFPRODUCT", ID.Manfproduct);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_MANFPRODNO", ID.ProductionNO);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_SRVCNAME", ID.ServiceTobeProviding);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_SRVCACTIVITY", ID.ServiceActivity);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_SRVCNO", ID.ServiceNo);

                da.SelectCommand.Parameters.AddWithValue("@PROJECT_SECTORNAME", ID.SectorName);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_LOAID", Convert.ToInt32(ID.Lineofacitivityid));
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_PCBCATEGORY", ID.Category);

                da.SelectCommand.Parameters.AddWithValue("@PROJECT_MAINRM", ID.Rawmaterial);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_WASTEDETAILS", ID.WasteDetails);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_HAZWASTEDETAILS", ID.HazWasteDetails);

                da.SelectCommand.Parameters.AddWithValue("@PROJECT_CIVILCONSTR", ID.CivilConstr);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_LANDAREA", ID.LandAreainSqft);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_BUILDINGAREA", ID.BuildingAreaSqm);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_WATERREQ", ID.WaterReqKLD);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_POWERRREQ", ID.PowerReqKV);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_UNITOFMEASURE", ID.MeasurementUnits);

                da.SelectCommand.Parameters.AddWithValue("@PROJECT_ANNUALCOST", ID.AnnualCapacity);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_EPCOST", ID.EstimatedProjCost);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_PMCOST", ID.PlantnMachineryCost);

                da.SelectCommand.Parameters.AddWithValue("@PROJECT_IFC", ID.CapitalInvestment);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_DFA", ID.FixedAssets);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_LANDVALUE", ID.LandValue);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_BUILDINGVALUE", ID.BuildingValue);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_WATERVALUE", ID.WaterValue);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_ELECTRICITYVALUE", ID.ElectricityValue);
                da.SelectCommand.Parameters.AddWithValue("@PROJECT_WORKINGCAPITAL", ID.WorkingCapital);
                da.SelectCommand.Parameters.AddWithValue("@FRD_CAPITALSUBSIDY", ID.CapitalSubsidy);
                da.SelectCommand.Parameters.AddWithValue("@FRD_PROMOTEREQUITY", ID.PromoterEquity);
                da.SelectCommand.Parameters.AddWithValue("@FRD_LOAN", ID.LoanAmount);
                da.SelectCommand.Parameters.AddWithValue("@STAGEID", 1);
                da.SelectCommand.Parameters.AddWithValue("@UNITID", ID.UnitID);
                da.SelectCommand.Parameters.AddWithValue("@DEPTID", ID.Deptid);

                //da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(ID.UserID));
                //da.SelectCommand.Parameters.AddWithValue("@IPADDRESS", ID.IPAddress);
                //// da.SelectCommand.Parameters.AddWithValue("@REGISTRATIONDATE", DateTime.ParseExact(ID.CompnyRegDt.ToString(), "yyy-dd-MM", CultureInfo.InvariantCulture) );
                //da.SelectCommand.Parameters.AddWithValue("@REGISTRATIONDATE", Convert.ToDateTime(ID.CompnyRegDt).ToString("yyyy-dd-MM"));
                //da.SelectCommand.Parameters.AddWithValue("@UDYAMNO", ID.UdyamorIEMNo);
                //da.SelectCommand.Parameters.AddWithValue("@GSTNNO", ID.GSTNo);
                //da.SelectCommand.Parameters.AddWithValue("@REP_NAME", ID.AuthReprName);
                //da.SelectCommand.Parameters.AddWithValue("@REP_MOBILE", Convert.ToInt64(ID.AuthReprMobile));
                //da.SelectCommand.Parameters.AddWithValue("@REP_EMAIL", ID.AuthReprEmail);
                //da.SelectCommand.Parameters.AddWithValue("@REP_LOCALITY", ID.AuthReprLocality);
                ////da.SelectCommand.Parameters.AddWithValue("@REP_DISTRICT", ID.AuthReprDist);
                //da.SelectCommand.Parameters.AddWithValue("@REP_DISTRICT", Convert.ToInt32(ID.AuthReprDistID));
                //// da.SelectCommand.Parameters.AddWithValue("@REP_MANDAL", ID.AuthReprTaluka);
                //// da.SelectCommand.Parameters.AddWithValue("@REP_DISTRICT", Convert.ToInt32(ID.AuthReprDistID));
                //da.SelectCommand.Parameters.AddWithValue("@REP_MANDAL", Convert.ToInt32(ID.AuthReprTalukaID));
                ////da.SelectCommand.Parameters.AddWithValue("@AuthReprVillage", ID.AuthReprVillage);
                ////da.SelectCommand.Parameters.AddWithValue("@REP_DISTRICT", Convert.ToInt32(ID.AuthReprDistID));
                //da.SelectCommand.Parameters.AddWithValue("@REP_VILLAGE", Convert.ToInt32(ID.AuthReprVillageID));
                //da.SelectCommand.Parameters.AddWithValue("@REP_PINCODE", ID.AuthReprPincode);
                //da.SelectCommand.Parameters.AddWithValue("@UNIT_DOORNO", ID.PropLocDoorno);
                //da.SelectCommand.Parameters.AddWithValue("@UNIT_LOCALITY", ID.PropLocLocality);
                //da.SelectCommand.Parameters.AddWithValue("@UNIT_DISTRICT", Convert.ToInt32(ID.PropLocDistID));
                //da.SelectCommand.Parameters.AddWithValue("@UNIT_MANDAL", Convert.ToInt32(ID.PropLocTalukaID));
                //da.SelectCommand.Parameters.AddWithValue("@UNIT_VILLAGE", Convert.ToInt32(ID.PropLocVillageID));
                //da.SelectCommand.Parameters.AddWithValue("@UNIT_PICODE", ID.PropLocPincode);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_NOA", ID.NatureofActivity);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_MMSA", ID.ManfActivity);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_PMSP", ID.Manfproduct);
                ////da.SelectCommand.Parameters.AddWithValue("@PROJECT_MMSA", ID.ServiceActivity);
                ////da.SelectCommand.Parameters.AddWithValue("@@PROJECT_PMSP", ID.ServiceTobeProviding);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_DCP", Convert.ToDateTime(ID.DCPorOperation).ToString("yyyy-dd-MM"));
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_PROD_NO", ID.ProductionNO);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_AC", ID.AnnualCapacity);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_IFC", ID.CapitalInvestment);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_EPC", ID.EstimatedProjCost);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_LAND", ID.LandAreainSqft);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_CIVIL_CONSTRCTION", ID.CivilConstr);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_PM", ID.PlantnMachineryCost);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_MMPP", ID.Rawmaterial);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_BUILDING", ID.BuildingAreaSqm);
                ////da.SelectCommand.Parameters.AddWithValue("@PROJECT_hazardous", ID.WasteDetails);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_hazardous", ID.HazWasteDetails);
                ////da.SelectCommand.Parameters.AddWithValue("@PROJECT_DFA", ID.CapitalInvestment);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_DFA", ID.FixedAssets);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_UM", ID.MeasurementUnits);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_BS", ID.BuildingValue);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_WATER", ID.WaterValue);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_ELECTRIC", ID.ElectricityValue);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_WC", ID.WorkingCapital);
                //da.SelectCommand.Parameters.AddWithValue("@FRD_CS", ID.CapitalSubsidy);
                //da.SelectCommand.Parameters.AddWithValue("@FRD_PE", ID.PromoterEquity);
                //da.SelectCommand.Parameters.AddWithValue("@FRD_LOAN", ID.LoanAmount);
                //da.SelectCommand.Parameters.AddWithValue("@PROJECT_LVALUE", ID.LandValue);
                //da.SelectCommand.Parameters.AddWithValue("@COMPANYNAME", ID.CompanyName);
                //da.SelectCommand.Parameters.AddWithValue("@COMPANYPANNO", ID.CompanyPAN);
                //da.SelectCommand.Parameters.AddWithValue("@UNITID", ID.UnitID);
                //da.SelectCommand.Parameters.AddWithValue("@DEPTID", ID.Deptid);
                //da.SelectCommand.Parameters.AddWithValue("@SectorName", ID.SectorName);
                //da.SelectCommand.Parameters.AddWithValue("@Lineofacitivityid", ID.Lineofacitivityid);
                //da.SelectCommand.Parameters.AddWithValue("@Category", ID.Category);
                //da.SelectCommand.Parameters.AddWithValue("@STATUS", 1);

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    valid = Convert.ToString(dt.Rows[0]["UNITID"]);
                IDno = valid;

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
        public string InsertIndRegRevenueDetails(DataTable dt)
        {
            string valid = "";

            SqlConnection connection = new SqlConnection(connstr);
            //SqlTransaction transaction = null;
            connection.Open();
            // transaction = connection.BeginTransaction();
            try
            {
                SqlParameter[] p = new SqlParameter[] {
                 new SqlParameter("@TVP",SqlDbType.Structured) };
                p[0].Value = dt;
                p[0].TypeName = "dbo.REVENUE_PROJEECTIONS";
                valid = Convert.ToString(SqlHelper.ExecuteNonQuery(connection, PreRegConstants.InsertIndRegRevenueDetails, p));

                //transaction.Commit();
                //connection.Close();
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
        public string InsertIndPromotersDetails(DataTable dt)
        {
            string valid = "";

            SqlConnection connection = new SqlConnection(connstr);
            //SqlTransaction transaction = null;
            connection.Open();
            //transaction = connection.BeginTransaction();
            try
            {
                SqlParameter[] p = new SqlParameter[] {
                 new SqlParameter("@TVP",SqlDbType.Structured) };
                p[0].Value = dt;
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

        public DataSet GetIndustryRegUserDashboard(string userid)
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
                com.Parameters.AddWithValue("@UNITID", Convert.ToInt32(ID.Unitid ));
                com.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(ID.UserID));
                com.Parameters.AddWithValue("@IRQID", Convert.ToInt32(ID.QueryID));
                com.Parameters.AddWithValue("@DEPTID", Convert.ToInt32(ID.deptid));
                com.Parameters.AddWithValue("@RESPONSE", ID.QueryResponse);
                com.Parameters.AddWithValue("@IPADDRESS", ID.IPAddress);
                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 0);
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
        public DataSet GetIndustryRegistrationQueryDetails(string userid)
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
                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(userid));
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(userid)); 

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
            string valid = "";
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
                if (PRD.LandArea != null && PRD.LandArea != "")
                {
                    com.Parameters.AddWithValue("@DEPTLANDAREA", PRD.LandArea);
                }
                if (PRD.Power != null && PRD.Power != "")
                {
                    com.Parameters.AddWithValue("@DEPTPOWER", PRD.Power);
                }
                if (PRD.Water != null && PRD.Water != "")
                {
                    com.Parameters.AddWithValue("@DEPTWATER", PRD.Water);
                }
                if (PRD.WasteDetails != null && PRD.WasteDetails != "")
                {
                    com.Parameters.AddWithValue("@DEPTWASTEDETAILS", PRD.WasteDetails);
                }
                if (PRD.HazDetails != null && PRD.HazDetails != "")
                {
                    com.Parameters.AddWithValue("@DEPTHAZDETAILS", PRD.HazDetails);
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
        public string InsertDeptDetails(DataTable dt)
        {
            string valid = "";

            SqlConnection connection = new SqlConnection(connstr);
            //SqlTransaction transaction = null;
            connection.Open();
            // transaction = connection.BeginTransaction();
            try
            {
                SqlParameter[] p = new SqlParameter[] {
                new SqlParameter("@DS",SqlDbType.Structured) };
                p[0].Value = dt;
                p[0].TypeName = "dbo.DEPARTMENT_SELECTIONS";
                valid = Convert.ToString(SqlHelper.ExecuteNonQuery(connection, PreRegConstants.InsertPreRegJDDept, p));

                //transaction.Commit();
                //connection.Close();
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
        public DataSet GetDeptMst(string Unitid,string Userid)
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

    }
}
