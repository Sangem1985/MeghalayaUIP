using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeghalayaUIP.Common;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using iText.Layout.Borders;
using Org.BouncyCastle.Asn1.Ocsp;

namespace MeghalayaUIP.DAL.CFEDAL
{
    public class CFEDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();

        public DataSet GetPREREGandCFEapplications(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetPREREGandCFEapplications, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetPREREGandCFEapplications;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(userid));
                da.SelectCommand.Parameters.AddWithValue("@UNITID", UnitID);

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
        public DataSet GetIndustryRegDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFERegDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFERegDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(userid));
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
        public DataSet RetrieveQuestionnaireDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.RetrieveQuestionnaire, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.RetrieveQuestionnaire;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
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
        public DataTable GetApprovalsReqWithFee(CFEQuestionnaireDet objCFEQ)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFEApprovalsReq, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFEApprovalsReq;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@ENTPRISETYPE", objCFEQ.EnterpriseCategory);
                da.SelectCommand.Parameters.AddWithValue("@APPROVALID", objCFEQ.ApprovalID);
                da.SelectCommand.Parameters.AddWithValue("@POWERKW_ID", objCFEQ.PowerReqKW);
                da.SelectCommand.Parameters.AddWithValue("@EMPLOYEE", Convert.ToInt32(objCFEQ.PropEmployment));
                da.SelectCommand.Parameters.AddWithValue("@BUILDINGHEIGHT", objCFEQ.BuildingHeight);

                if (objCFEQ.Investment != null && objCFEQ.Investment != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@INVESTMENT", objCFEQ.Investment);
                }



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
        public string InsertQuestionnaireCFE(CFEQuestionnaireDet objCFEQsnaire)
        {
            string Result = "";

            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            //connection.Open();
            //transaction = connection.BeginTransaction();
            try
            {

                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFEConstants.InsertCFEQuestionnaire;

                com.Transaction = transaction;
                com.Connection = connection;
                //    com.Parameters.AddWithValue("@UNITID", Convert.ToInt32(ID.Unitid));
                //    com.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(ID.UserID));
                //    com.Parameters.AddWithValue("@IRQID", Convert.ToInt32(ID.QueryID));
                //    com.Parameters.AddWithValue("@DEPTID", Convert.ToInt32(ID.deptid));
                //    com.Parameters.AddWithValue("@RESPONSE", ID.QueryResponse);
                //    com.Parameters.AddWithValue("@IPADDRESS", ID.IPAddress);
                //    com.Parameters.Add("@RESULT", SqlDbType.VarChar, 0);
                //    com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                //    com.ExecuteNonQuery();

                //    valid = com.Parameters["@RESULT"].Value.ToString();
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
                //return valid;
                //DataTable dt = new DataTable();
                //SqlDataAdapter da;
                //da = new SqlDataAdapter(CFECommon.InsertCFEQuestionnaire, connection);
                //da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.CommandText = CFECommon.InsertCFEQuestionnaire;

                //da.SelectCommand.Transaction = transaction;
                //da.SelectCommand.Connection = connection;

                com.Parameters.AddWithValue("@CFEQDID", objCFEQsnaire.CFEQDID);

                com.Parameters.AddWithValue("@CFEQD_UNITID", Convert.ToInt32(objCFEQsnaire.UNITID));
                com.Parameters.AddWithValue("@CFEQD_PREREGUIDNO", objCFEQsnaire.PREREGUIDNO);
                com.Parameters.AddWithValue("@CFEQD_APPLSTATUS", 2);
                com.Parameters.AddWithValue("@CFEQD_COMPANYNAME", objCFEQsnaire.CompanyName);
                com.Parameters.AddWithValue("@CFEQD_COMPANYTYPE", Convert.ToInt32(objCFEQsnaire.CompanyType));
                com.Parameters.AddWithValue("@CFEQD_PROPOSALFOR", objCFEQsnaire.ProposalFor);
                com.Parameters.AddWithValue("@CFEQD_MIDCLLAND", Convert.ToInt32(objCFEQsnaire.LandFromMIDCL));
                com.Parameters.AddWithValue("@CFEQD_PROPDISTRICTID", Convert.ToInt32(objCFEQsnaire.PropLocDitrictID));
                com.Parameters.AddWithValue("@CFEQD_PROPMANDALID", Convert.ToInt32(objCFEQsnaire.PropLocMandalID));
                com.Parameters.AddWithValue("@CFEQD_PROPVILLAGEID", Convert.ToInt32(objCFEQsnaire.PropLocVillageID));
                com.Parameters.AddWithValue("@CFEQD_TOTALEXTENTLAND", Convert.ToDecimal(objCFEQsnaire.ExtentofLand));
                com.Parameters.AddWithValue("@CFEQD_BUILTUPAREA", Convert.ToDecimal(objCFEQsnaire.BuiltUpArea));
                com.Parameters.AddWithValue("@CFEQD_SECTOR", objCFEQsnaire.SectorName);
                com.Parameters.AddWithValue("@CFEQD_LOAID", Convert.ToInt32(objCFEQsnaire.Lineofacitivityid));
                com.Parameters.AddWithValue("@CFEQD_PCBCATEGORY", objCFEQsnaire.PCBCategory);
                com.Parameters.AddWithValue("@CFEQD_INDUSTRYTYPE", objCFEQsnaire.NatureofActivity);
                com.Parameters.AddWithValue("@CFEQD_UNTLOCATION", objCFEQsnaire.UnitLocation);
                com.Parameters.AddWithValue("@CFEQD_PROPEMP", Convert.ToInt32(objCFEQsnaire.PropEmployment));
                com.Parameters.AddWithValue("@CFEQD_LANDVALUE", Convert.ToDecimal(objCFEQsnaire.LandValue));
                com.Parameters.AddWithValue("@CFEQD_BUILDINGVALUE", Convert.ToDecimal(objCFEQsnaire.BuildingValue));
                com.Parameters.AddWithValue("@CFEQD_PMCOST", Convert.ToDecimal(objCFEQsnaire.PlantnMachineryCost));
                com.Parameters.AddWithValue("@CFEQD_EXPECTEDTURNOVER", Convert.ToDecimal(objCFEQsnaire.ExpectedTurnover));
                com.Parameters.AddWithValue("@CFEQD_TOTALPROJCOST", Convert.ToDecimal(objCFEQsnaire.TotalProjCost));
                com.Parameters.AddWithValue("@CFEQD_ENTERPRISETYPE", objCFEQsnaire.EnterpriseCategory);
                com.Parameters.AddWithValue("@CFEQD_POWERREQKW", Convert.ToInt32(objCFEQsnaire.PowerReqKW));
                com.Parameters.AddWithValue("@CFEQD_GENREQ", objCFEQsnaire.GeneratorReq);
                com.Parameters.AddWithValue("@CFEQD_BUILDINGHT", objCFEQsnaire.BuildingHeight);
                com.Parameters.AddWithValue("@CFEQD_STORINGRSDS", objCFEQsnaire.StoringRSDS);
                com.Parameters.AddWithValue("@CFEQD_MANFEXPLOSIVES", objCFEQsnaire.ManfExplosives);
                com.Parameters.AddWithValue("@CFEQD_MANFPETROL", objCFEQsnaire.ManfPetroleum);
                com.Parameters.AddWithValue("@CFEQD_RDCTNGREQ", objCFEQsnaire.RdCtngPermission);
                com.Parameters.AddWithValue("@CFEQD_NONENCMCERTREQ", objCFEQsnaire.NonEncmbrnceCert);
                com.Parameters.AddWithValue("@CFEQD_COMMTAXREQ", objCFEQsnaire.CommTaxApproval);
                com.Parameters.AddWithValue("@CFEQD_USINGHTMETER", objCFEQsnaire.HTMeteruse);
                com.Parameters.AddWithValue("@CFEQD_CEIGREGULATION", objCFEQsnaire.CEARegulationID);
                com.Parameters.AddWithValue("@CFEQD_POWERPLANT", objCFEQsnaire.PowerPlantID);
                com.Parameters.AddWithValue("@CFEQD_AGGRCAPACITY", objCFEQsnaire.AggCapacity);
                com.Parameters.AddWithValue("@CFEQD_VOLTAGERATING", objCFEQsnaire.VoltageRating);
                com.Parameters.AddWithValue("@CFEQD_TREESFELLING", objCFEQsnaire.TreesFelling);
                com.Parameters.AddWithValue("@CFEQD_NOOFTREES", objCFEQsnaire.NoofTrees);
                com.Parameters.AddWithValue("@CFEQD_NONFORSTLANDCERTREQ", objCFEQsnaire.NonForstLandCert);
                com.Parameters.AddWithValue("@CFEQD_FORSTDISTLTRREQ", objCFEQsnaire.ForstDistLetr);
                com.Parameters.AddWithValue("@CFEQD_WATERBODYVICINITY", objCFEQsnaire.NearWaterBodyLocation);
                com.Parameters.AddWithValue("@CFEQD_BOREWELLEXISTS", objCFEQsnaire.ExistingBoreWell);
                com.Parameters.AddWithValue("@CFEQD_LABOURACT1970", objCFEQsnaire.LabourAct1970);
                com.Parameters.AddWithValue("@CFEQD_NOOFWORKERS1970", objCFEQsnaire.LabourAct1970_Workers);
                com.Parameters.AddWithValue("@CFEQD_LABOURACT1979", objCFEQsnaire.LabourAct1979);
                com.Parameters.AddWithValue("@CFEQD_NOOFWORKERS1979", objCFEQsnaire.LabourAct1979_Workers);
                com.Parameters.AddWithValue("@CFEQD_LABOURACT1996", objCFEQsnaire.LabourAct1996);
                com.Parameters.AddWithValue("@CFEQD_BUILDINGWORKS1996", objCFEQsnaire.LabourAct1996_10Workers);
                com.Parameters.AddWithValue("@CFEQD_NOOFWORKERS1996", objCFEQsnaire.LabourAct1996_Workers);
                com.Parameters.AddWithValue("@CFEQD_CONTRLABOURACT", objCFEQsnaire.ContractLabourAct);
                com.Parameters.AddWithValue("@CFEQD_NOOFWORKERSCONTR", objCFEQsnaire.ContractLabourAct_Workers);
                com.Parameters.AddWithValue("@CFEQD_CONTRLABOURACT1970", objCFEQsnaire.ContractLabourAct1970);
                com.Parameters.AddWithValue("@CFEQD_NOOFWORKERSCONTR1970", objCFEQsnaire.ContractLabourAct1970_Workers);
                com.Parameters.AddWithValue("@CFEQD_CREATEDBY", Convert.ToInt32(objCFEQsnaire.CreatedBy));
                com.Parameters.AddWithValue("@CFEQD_CREATEDBYIP", objCFEQsnaire.IPAddress);

                com.Parameters.AddWithValue("@CFEQD_NOCGROUNDWATER", objCFEQsnaire.GrandWaterConnection);
                com.Parameters.AddWithValue("@CFEQD_NONAVAILABILITYCERT", objCFEQsnaire.WaterSupplyAgency);
                com.Parameters.AddWithValue("@CFEQD_PERRIVERPUBLICTANKERS", objCFEQsnaire.RiverPublicTanker);
                com.Parameters.AddWithValue("@CFEQD_MUNICIPALAREAWATERCON", objCFEQsnaire.MuncipalAreawater);
                com.Parameters.AddWithValue("@CFEQD_WATERCONNONMUNICIPALURBAN", objCFEQsnaire.NonMuncipalAreaUrban);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();
                //int QID = Convert.ToInt32(com.ExecuteScalar());
                //transaction.Commit();
                //connection.Close();
                //Result = Convert.ToString(QID);

                // transaction.Commit();
                //connection.Close();

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
            return Result;
        }
        public string InsertCFEQuestionnaireApprovals(CFEQuestionnaireDet objCFEQsnaire)
        {
            string Result = "";

            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            //connection.Open();
            //transaction = connection.BeginTransaction();
            try
            {

                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFEConstants.InsertCFEQuestionnaireApprovals;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFEQDID", Convert.ToInt32(objCFEQsnaire.CFEQDID));
                com.Parameters.AddWithValue("@CFEQA_DEPTID", Convert.ToInt32(objCFEQsnaire.DeptID));
                com.Parameters.AddWithValue("@CFEQA_APPROVALID", Convert.ToInt32(objCFEQsnaire.ApprovalID));
                com.Parameters.AddWithValue("@CFEQA_APPROVALFEE", Convert.ToDecimal(objCFEQsnaire.ApprovalFee));
                com.Parameters.AddWithValue("@CFEQA_CREATEDBY", Convert.ToInt32(objCFEQsnaire.CreatedBy));
                com.Parameters.AddWithValue("@CFEQA_CREATEDBYIP", objCFEQsnaire.IPAddress);
                com.Parameters.AddWithValue("@CFEQA_UNITID", Convert.ToInt32(objCFEQsnaire.UNITID));


                int QAID = Convert.ToInt32(com.ExecuteScalar());
                transaction.Commit();
                connection.Close();
                Result = Convert.ToString(QAID);



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
            return Result;
        }
        public string DeleteDepartmentApprovals(CFEQuestionnaireDet objCFEQsnaire)
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
                com.CommandText = CFEConstants.DeleteDepartmentApprovals;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFEQDID", Convert.ToInt32(objCFEQsnaire.CFEQDID));
                com.Parameters.AddWithValue("@CFEQA_CREATEDBY", Convert.ToInt32(objCFEQsnaire.CreatedBy));
                com.Parameters.AddWithValue("@CFEQA_UNITID", Convert.ToInt32(objCFEQsnaire.UNITID));

                int QAID = Convert.ToInt32(com.ExecuteScalar());
                transaction.Commit();
                connection.Close();
                Result = Convert.ToString(QAID);
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
            return Result;
        }
        public DataSet GetApprovalsReqFromTable(CFEQuestionnaireDet objCFEQ)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetApprovalsReqFromTable, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetApprovalsReqFromTable;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(objCFEQ.UNITID));
                da.SelectCommand.Parameters.AddWithValue("@CRETAEDBY", Convert.ToInt32(objCFEQ.CreatedBy));

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
        public string InsertCFEDepartmentApprovals(CFEQuestionnaireDet objCFEQsnaire)
        {
            string Result = "";

            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            //connection.Open();
            //transaction = connection.BeginTransaction();
            try
            {

                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFEConstants.InsertCFEDepartmentapprovals;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFEDA_UNITID", Convert.ToInt32(objCFEQsnaire.UNITID));
                com.Parameters.AddWithValue("@CFEDA_CFEQDID", Convert.ToInt32(objCFEQsnaire.CFEQDID));
                com.Parameters.AddWithValue("@CFEDA_DEPTID", Convert.ToInt32(objCFEQsnaire.DeptID));
                com.Parameters.AddWithValue("@CFEDA_APPROVALID", Convert.ToInt32(objCFEQsnaire.ApprovalID));
                com.Parameters.AddWithValue("@CFEDA_APPROVALFEE", Convert.ToDecimal(objCFEQsnaire.ApprovalFee));
                com.Parameters.AddWithValue("@CFEDA_ISOFFLINE", objCFEQsnaire.IsOffline);
                com.Parameters.AddWithValue("@CFDA_CREATEDBY", Convert.ToInt32(objCFEQsnaire.CreatedBy));
                com.Parameters.AddWithValue("@CFDA_CREATEDBYIP", objCFEQsnaire.IPAddress);

                int DAID = Convert.ToInt32(com.ExecuteScalar());
                transaction.Commit();
                connection.Close();
                Result = Convert.ToString(DAID);
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
            return Result;
        }
        public DataSet GetCFEAlreadyObtainedApprovals(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFEObtainedOffline, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFEObtainedOffline;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@CRETAEDBY", Convert.ToInt32(userid));

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
        public DataSet GetCFEIndustryDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFEIndustryDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFEIndustryDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));

                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string InsertCFEIndustryDetails(CFECommonDet objCFEEntrepreneur)
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
                com.CommandText = CFEConstants.InsertCFEIndustryDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFEID_CREATEDBY", Convert.ToInt32(objCFEEntrepreneur.CreatedBy));
                com.Parameters.AddWithValue("@CFEID_CREATEDBYIP", objCFEEntrepreneur.IPAddress);

                com.Parameters.AddWithValue("@CFEID_PREREGUIDNO", objCFEEntrepreneur.PreRegUID);
                com.Parameters.AddWithValue("@CFEID_UNITID", Convert.ToInt32(objCFEEntrepreneur.UNITID));

                com.Parameters.AddWithValue("@CFEID_COMPANYNAME", objCFEEntrepreneur.CompanyName);
                com.Parameters.AddWithValue("@CFEID_COMPANYTYPE", Convert.ToInt32(objCFEEntrepreneur.CompanyType));
                com.Parameters.AddWithValue("@CFEID_PROPOSALFOR", objCFEEntrepreneur.CompanyPraposal);
                com.Parameters.AddWithValue("@CFEID_REGTYPE", Convert.ToInt32(objCFEEntrepreneur.CompanyRegType));
                com.Parameters.AddWithValue("@CFEID_REGNO", objCFEEntrepreneur.CompanyRegNo);
                com.Parameters.AddWithValue("@CFEID_REGDATE", DateTime.ParseExact(objCFEEntrepreneur.CompanyRegDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFEID_FACTORYTYPE", objCFEEntrepreneur.FactoryType);
                com.Parameters.AddWithValue("@CFEID_REPNAME", objCFEEntrepreneur.AuthRep_Name);
                com.Parameters.AddWithValue("@CFEID_REPSoWoDo", objCFEEntrepreneur.AuthRep_SoWoDo);
                com.Parameters.AddWithValue("@CFEID_REPEMAIL", objCFEEntrepreneur.AuthRep_Email);
                com.Parameters.AddWithValue("@CFEID_REPMOBILE", Convert.ToInt64(objCFEEntrepreneur.AuthRep_Mobile));
                com.Parameters.AddWithValue("@CFEID_REPALTMOBILE", objCFEEntrepreneur.AuthRep_AltMobile);
                com.Parameters.AddWithValue("@CFEID_REPTELPHNO", objCFEEntrepreneur.AuthRep_TelNo);
                com.Parameters.AddWithValue("@CFEID_REPDOORNO", objCFEEntrepreneur.AuthRep_DoorNo);
                com.Parameters.AddWithValue("@CFEID_REPLOCALITY", objCFEEntrepreneur.AuthRep_Locality);
                com.Parameters.AddWithValue("@CFEID_REPDISTRICTID", Convert.ToInt32(objCFEEntrepreneur.AuthRep_DistrictID));
                com.Parameters.AddWithValue("@CFEID_REPMANDALID", Convert.ToInt32(objCFEEntrepreneur.AuthRep_MandalID));
                com.Parameters.AddWithValue("@CFEID_REPVILLAGEID", Convert.ToInt32(objCFEEntrepreneur.AuthRep_VillageID));
                com.Parameters.AddWithValue("@CFEID_REPPINCODE", Convert.ToInt32(objCFEEntrepreneur.AuthRep_Pincode));
                com.Parameters.AddWithValue("@CFEID_REPISDIFFABLED", objCFEEntrepreneur.AuthRep_DiffAbled);
                com.Parameters.AddWithValue("@CFEID_REPISWOMANENTR", objCFEEntrepreneur.AuthRep_Woman);

                com.Parameters.AddWithValue("@CFEID_DEVELOPAREA", Convert.ToDecimal(objCFEEntrepreneur.DevelopmentArea));

                com.Parameters.AddWithValue("@CFEID_ARCHTCTNAME", objCFEEntrepreneur.ArchitechtureName);
                com.Parameters.AddWithValue("@CFEID_ARCHTCTLICNO", objCFEEntrepreneur.ArchitechtureLICNo);
                com.Parameters.AddWithValue("@CFEID_ARCHTCTMOBILE", Convert.ToInt64(objCFEEntrepreneur.ArchitechtureMobileNo));
                com.Parameters.AddWithValue("@CFEID_SRTCTENGNRNAME", objCFEEntrepreneur.strctralName);
                com.Parameters.AddWithValue("@CFEID_SRTCTENGNRLICNO", objCFEEntrepreneur.strctralLicNo);
                com.Parameters.AddWithValue("@CFEID_SRTCTENGNRMOBILE", Convert.ToInt64(objCFEEntrepreneur.strctralMobileNo));

                com.Parameters.AddWithValue("@CFEID_APPROACHROADTYPE", objCFEEntrepreneur.ApprchRdType);
                com.Parameters.AddWithValue("@CFEID_APPROACHROADWIDTH", Convert.ToDecimal(objCFEEntrepreneur.ApprchRdWidth));
                com.Parameters.AddWithValue("@CFEID_AFFECTEDRDWDNG", objCFEEntrepreneur.AffectedRdWdng);
                com.Parameters.AddWithValue("@CFEID_AFFECTEDRDAREA", objCFEEntrepreneur.AffectedExtended);

                com.Parameters.AddWithValue("@CFEID_TOTALEMP", Convert.ToInt32(objCFEEntrepreneur.TotalEmp));

                com.Parameters.AddWithValue("@CFEID_DIRECTMALE", Convert.ToInt32(objCFEEntrepreneur.DirectMale));
                com.Parameters.AddWithValue("@CFEID_DIRECTFEMALE", Convert.ToInt32(objCFEEntrepreneur.DirectFemale));
                com.Parameters.AddWithValue("@CFEID_DIRECTOTHERS", Convert.ToInt32(objCFEEntrepreneur.DirectOthers));

                com.Parameters.AddWithValue("@CFEID_INDIRECTMALE", Convert.ToInt32(objCFEEntrepreneur.InDirectMale));
                com.Parameters.AddWithValue("@CFEID_INDIRECTFEMALE", Convert.ToInt32(objCFEEntrepreneur.InDirectFemale));
                com.Parameters.AddWithValue("@CFEID_INDIRECTOTHERS", Convert.ToInt32(objCFEEntrepreneur.InDirectOthers));

                com.Parameters.AddWithValue("@CFEID_RDCUTLENGTH", objCFEEntrepreneur.RoadCut);
                com.Parameters.AddWithValue("@CFEID_RDCUTLOCATIONS", objCFEEntrepreneur.RoadCutLocation);


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
        public DataSet GetCFELOMandRMDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFELOMANDRMDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFELOMANDRMDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));

                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string InsertCFELineofManf(CFELineOfManuf objCFEManufacture)
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
                com.CommandText = CFEConstants.InsertCFEManufactureDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFELM_CREATEDBY", Convert.ToInt32(objCFEManufacture.CreatedBy));
                com.Parameters.AddWithValue("@CFELM_CREATEDBYIP", objCFEManufacture.IPAddress);
                com.Parameters.AddWithValue("@CFELM_CFEQDID", Convert.ToInt32(objCFEManufacture.Questionnareid));
                com.Parameters.AddWithValue("@CFELM_UNITID", Convert.ToInt32(objCFEManufacture.UNITID));
                com.Parameters.AddWithValue("@CFELM_LOAID", Convert.ToInt32(objCFEManufacture.LOAID));
                com.Parameters.AddWithValue("@CFELM_ITEMNAME", objCFEManufacture.ManfItemName);
                com.Parameters.AddWithValue("@CFELM_ITEMANNUALCAPACITY", Convert.ToDecimal(objCFEManufacture.ManfItemAnnualCapacity));
                com.Parameters.AddWithValue("@CFELM_ITEMVALUE", Convert.ToDecimal(objCFEManufacture.ManfItemValue));

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
        public string InsertCFERawMaterial(CFELineOfManuf objCFEManufacture)
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
                com.CommandText = CFEConstants.InsertCFERAWMaterialDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFERM_CREATEDBY", Convert.ToInt32(objCFEManufacture.CreatedBy));
                com.Parameters.AddWithValue("@CFERM_CREATEDBYIP", objCFEManufacture.IPAddress);
                com.Parameters.AddWithValue("@CFERM_CFEQDID", Convert.ToInt32(objCFEManufacture.Questionnareid));
                com.Parameters.AddWithValue("@CFERM_UNITID", Convert.ToInt32(objCFEManufacture.UNITID));
                com.Parameters.AddWithValue("@CFERM_LOAID", Convert.ToInt32(objCFEManufacture.LOAID));
                com.Parameters.AddWithValue("@CFERM_ITEMNAME", objCFEManufacture.RMItemName);
                com.Parameters.AddWithValue("@CFERM_ITEMANNUALCAPACITY", Convert.ToDecimal(objCFEManufacture.RMItemAnnualCapacity));
                com.Parameters.AddWithValue("@CFERM_ITEMVALUE", Convert.ToDecimal(objCFEManufacture.RMItemValue));
                com.Parameters.AddWithValue("@CFERM_SOURCEOFSUPPLY", objCFEManufacture.RMSourceofSupply);


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
        public DataSet GetPowerDetailsRetrive(string userid, String UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFEPowerDetRetrive, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFEPowerDetRetrive;

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
        public string InsertCFEPowerDetails(CFEPower objCFEPower)
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
                com.CommandText = CFEConstants.InsertCFEPowerDet;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFEPD_CFEQDID", Convert.ToInt32(objCFEPower.Questionnariid));
                com.Parameters.AddWithValue("@CFEPD_UNITID", Convert.ToInt32(objCFEPower.UnitId));
                com.Parameters.AddWithValue("@CFEPD_CONNECTEDLOAD", Convert.ToDecimal(objCFEPower.Con_Load_HP));
                com.Parameters.AddWithValue("@CFEPD_MAXIMUMDEMAND", Convert.ToDecimal(objCFEPower.Maximum_KVA));
                com.Parameters.AddWithValue("@CFEPD_VOLTEAGELEVEL", Convert.ToInt32(objCFEPower.Voltage_Level));
                com.Parameters.AddWithValue("@CFEPD_WRKNGHRSPERDAY", Convert.ToInt32(objCFEPower.Per_Day));
                com.Parameters.AddWithValue("@CFEPD_WRKNGHRSPERMONTH", Convert.ToInt32(objCFEPower.Per_Month));
                com.Parameters.AddWithValue("@CFEPD_TRIALPRODUCTIONDATE", DateTime.ParseExact(objCFEPower.Expected_Month_Trial, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFEPD_POWERREQDATE", DateTime.ParseExact(objCFEPower.Probable_Date_Power, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFEPD_REQLOAD", Convert.ToDecimal(objCFEPower.LoadReq));
                com.Parameters.AddWithValue("@CFEPD_ENERGYSOURCE", Convert.ToInt32(objCFEPower.EnergySource));
                com.Parameters.AddWithValue("CFEPD_CREATEDBY", Convert.ToInt32(objCFEPower.CreatedBy));
                com.Parameters.AddWithValue("CFEPD_CREATEDBYIP", objCFEPower.IPAddress);

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
        public DataSet GetForestRetrive(string userid, String UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetForestRetriveDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetForestRetriveDet;

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
        public string InsertCFEFireDetails(CFEFire ObjCCFEFireDetails)
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
                com.CommandText = CFEConstants.InsertCFEFierDet;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFEFD_CREATEDBY", Convert.ToInt32(ObjCCFEFireDetails.CreatedBy));
                com.Parameters.AddWithValue("@CFEFD_CREATEDBYIP", ObjCCFEFireDetails.IPAddress);
                com.Parameters.AddWithValue("@CFEFD_CFEQDID", Convert.ToInt32(ObjCCFEFireDetails.Questionnariid));
                com.Parameters.AddWithValue("@CFEFD_UNITID", Convert.ToInt32(ObjCCFEFireDetails.UnitId));

                if (ObjCCFEFireDetails.DistricId != null && ObjCCFEFireDetails.DistricId != "")
                {
                    com.Parameters.AddWithValue("@CFEFD_DISTRICID", Convert.ToInt32(ObjCCFEFireDetails.DistricId));
                }
                if (ObjCCFEFireDetails.MandalId != null && ObjCCFEFireDetails.MandalId != "")
                {
                    com.Parameters.AddWithValue("@CFEFD_MANDALID", Convert.ToInt32(ObjCCFEFireDetails.MandalId));
                }
                if (ObjCCFEFireDetails.VillageId != null && ObjCCFEFireDetails.VillageId != "")
                {
                    com.Parameters.AddWithValue("@CFEFD_VILLAGEID", Convert.ToInt32(ObjCCFEFireDetails.VillageId));
                }
                if (ObjCCFEFireDetails.DistricName != null && ObjCCFEFireDetails.DistricName != "")
                {
                    com.Parameters.AddWithValue("@CFEFD_DISTRICNAME", ObjCCFEFireDetails.DistricName);
                }
                if (ObjCCFEFireDetails.MandalName != null && ObjCCFEFireDetails.MandalName != "")
                {
                    com.Parameters.AddWithValue("@CFEFD_MANDALNAME", ObjCCFEFireDetails.MandalName);
                }
                if (ObjCCFEFireDetails.VillageName != null && ObjCCFEFireDetails.VillageName != "")
                {
                    com.Parameters.AddWithValue("@CFEFD_VILLAGENAME", ObjCCFEFireDetails.VillageName);
                }
                if (ObjCCFEFireDetails.Locality != null && ObjCCFEFireDetails.Locality != "")
                {
                    com.Parameters.AddWithValue("@CFEFD_Locality", ObjCCFEFireDetails.Locality);
                }
                if (ObjCCFEFireDetails.Landmark != null && ObjCCFEFireDetails.Landmark != "")
                {
                    com.Parameters.AddWithValue("@CFEFD_Landmark", ObjCCFEFireDetails.Landmark);
                }
                if (ObjCCFEFireDetails.Pincode != null && ObjCCFEFireDetails.Pincode != "")
                {
                    com.Parameters.AddWithValue("@CFEFD_Pincode", Convert.ToInt32(ObjCCFEFireDetails.Pincode));
                }
               

                com.Parameters.AddWithValue("@CFEFD_BUILDINGHT", SqlDbType.Decimal).Value = ObjCCFEFireDetails.HeightBuilding;
                com.Parameters.AddWithValue("@CFEFD_FLOORHT", SqlDbType.Decimal).Value = ObjCCFEFireDetails.HeightFloor;
                com.Parameters.AddWithValue("@CFEFD_PLOTAREA", SqlDbType.Decimal).Value = ObjCCFEFireDetails.PlotArea;
                com.Parameters.AddWithValue("@CFEFD_BUILDINGAREA", SqlDbType.Decimal).Value = ObjCCFEFireDetails.builoduparea;
                com.Parameters.AddWithValue("@CFEFD_DRIVEPROPSED", SqlDbType.Decimal).Value = ObjCCFEFireDetails.ProposedDrive;
                com.Parameters.AddWithValue("@CFEFD_EXISTINGROAD", SqlDbType.Decimal).Value = ObjCCFEFireDetails.ExistingRoad;
                com.Parameters.AddWithValue("@CFEFD_CATEGORYBUILD", ObjCCFEFireDetails.CategoryBuilding);
                com.Parameters.AddWithValue("@CFEFD_FEEAMOUNT", SqlDbType.Decimal).Value = ObjCCFEFireDetails.FeeAmount;
                com.Parameters.AddWithValue("@CFEFD_East", ObjCCFEFireDetails.East);
                com.Parameters.AddWithValue("@CFEFD_West", ObjCCFEFireDetails.West);
                com.Parameters.AddWithValue("@CFEFD_North", ObjCCFEFireDetails.North);
                com.Parameters.AddWithValue("@CFEFD_South", ObjCCFEFireDetails.South);
                com.Parameters.AddWithValue("@CFEFD_DISTANCEEAST", SqlDbType.Decimal).Value = ObjCCFEFireDetails.Distancebuild;
                com.Parameters.AddWithValue("@CFEFD_DISTANCEWEST", SqlDbType.Decimal).Value = ObjCCFEFireDetails.Distanceproposed;
                com.Parameters.AddWithValue("@CFEFD_DISTANCENORTH", SqlDbType.Decimal).Value = ObjCCFEFireDetails.Distancemeter;
                com.Parameters.AddWithValue("@CFEFD_DISTANCESOUTH", SqlDbType.Decimal).Value = ObjCCFEFireDetails.buildingdist;
                com.Parameters.AddWithValue("@CFEFD_FIRESTATION", SqlDbType.Decimal).Value = ObjCCFEFireDetails.Firestation;


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
        public string InsertEntrepreneurDet(CFEEntrepreneur objCFEEntrepreneur)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            // connection.Open();
            // transaction = connection.BeginTransaction();
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = CFEConstants.InsertEntrepreneurDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFEED_CREATEDBY", Convert.ToInt32(objCFEEntrepreneur.CreatedBy));
                com.Parameters.AddWithValue("@CFEED_CREATEDBYIP", objCFEEntrepreneur.IPAddress);

                com.Parameters.AddWithValue("@CFEED_CFEQDID", Convert.ToInt32(objCFEEntrepreneur.Questionnariid));
                com.Parameters.AddWithValue("@CFEED_UNITID", Convert.ToInt32(objCFEEntrepreneur.UNITID));

                com.Parameters.AddWithValue("@CFEED_COMPANYNAME", objCFEEntrepreneur.CompanyName);
                com.Parameters.AddWithValue("@CFEED_PROMOTERNAME", objCFEEntrepreneur.PromoterName);
                com.Parameters.AddWithValue("@CFEED_SOWODO", objCFEEntrepreneur.SoWoDoName);
                com.Parameters.AddWithValue("@CFEED_STATEID", Convert.ToInt32(objCFEEntrepreneur.StateID));
                com.Parameters.AddWithValue("@CFEED_DISTID", Convert.ToInt32(objCFEEntrepreneur.DistrictID));
                com.Parameters.AddWithValue("@CFEED_MANDALID", Convert.ToInt32(objCFEEntrepreneur.MandalID));
                com.Parameters.AddWithValue("@CFEED_VILLAGEID", Convert.ToInt32(objCFEEntrepreneur.VillageID));

                com.Parameters.AddWithValue("@CFEED_STATENAME", objCFEEntrepreneur.StateName);
                com.Parameters.AddWithValue("@CFEED_DISTNAME", objCFEEntrepreneur.DistrictName);
                com.Parameters.AddWithValue("@CFEED_MANDALNAME", objCFEEntrepreneur.MandalName);
                com.Parameters.AddWithValue("@CFEED_VILLAGENAME", objCFEEntrepreneur.VillageName);

                com.Parameters.AddWithValue("@CFEED_STREET", objCFEEntrepreneur.StreetName);
                com.Parameters.AddWithValue("@CFEED_DOORNO", objCFEEntrepreneur.DoorNo);

                com.Parameters.AddWithValue("@CFEED_PINCODE", Convert.ToInt32(objCFEEntrepreneur.Pincode));
                com.Parameters.AddWithValue("@CFEED_MOBILE", Convert.ToInt64(objCFEEntrepreneur.MobileNo));
                com.Parameters.AddWithValue("@CFEED_ALTMOBILE", Convert.ToInt64(objCFEEntrepreneur.AltMobileNo));
                com.Parameters.AddWithValue("@CFEED_EMAIL", objCFEEntrepreneur.Email);
                com.Parameters.AddWithValue("@CFEED_COMPANYTYPE", Convert.ToInt32(objCFEEntrepreneur.Organization));
                com.Parameters.AddWithValue("@CFEED_TELEPHONENO", objCFEEntrepreneur.TelePhoneNo);
                com.Parameters.AddWithValue("@CFEED_PROPOSALFOR", objCFEEntrepreneur.ProposalFor);
                com.Parameters.AddWithValue("@CFEED_CASTE", Convert.ToInt32(objCFEEntrepreneur.SocialStatus));
                com.Parameters.AddWithValue("@CFEED_ISDIFFABLED", objCFEEntrepreneur.IsDiffAbled);
                com.Parameters.AddWithValue("@CFEED_ISWOMENENTR", objCFEEntrepreneur.IsWomenEntr);
                com.Parameters.AddWithValue("@CFEED_ISMINORITY", objCFEEntrepreneur.IsMinority);

                com.Parameters.AddWithValue("@CFEED_LANDVALUE", SqlDbType.Decimal).Value = objCFEEntrepreneur.LandValue;
                com.Parameters.AddWithValue("@CFEED_BUILDINGVALUE", SqlDbType.Decimal).Value = objCFEEntrepreneur.BuildingValue;
                com.Parameters.AddWithValue("@CFEED_PMCOST", SqlDbType.Decimal).Value = objCFEEntrepreneur.Plant_Machinary;
                com.Parameters.AddWithValue("@CFEED_TOTALPROJCOST", SqlDbType.Decimal).Value = objCFEEntrepreneur.TotalProjectValue;

                com.Parameters.AddWithValue("@CFEED_DIRECTMALE", Convert.ToInt32(objCFEEntrepreneur.DirectMale));
                com.Parameters.AddWithValue("@CFEED_DIRECTFEMALE", Convert.ToInt32(objCFEEntrepreneur.DirectFemale));
                com.Parameters.AddWithValue("@CFEED_INDIRECTMALE", Convert.ToInt32(objCFEEntrepreneur.InDirectMale));
                com.Parameters.AddWithValue("@CFEED_INDIRECTFEMALE", Convert.ToInt32(objCFEEntrepreneur.InDirectFemale));
                com.Parameters.AddWithValue("@CFEED_TOTALEMP", Convert.ToInt32(objCFEEntrepreneur.TotalEmp));

                com.Parameters.AddWithValue("@CFEED_REGISTRATIONTYPE", Convert.ToInt32(objCFEEntrepreneur.RegistrationType));
                com.Parameters.AddWithValue("@CFEED_REGISTRATIONNO", objCFEEntrepreneur.RegistrationNo);
                com.Parameters.AddWithValue("@CFEED_REGISTRATIONDATE", objCFEEntrepreneur.RegistrationDate);
                com.Parameters.AddWithValue("@CFEED_FACTORYTYPE", objCFEEntrepreneur.FactoryType);
                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public string InsertCFELandDet(CFELand objCFELandDet)
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
                com.CommandText = CFEConstants.InsertCFELandDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFELD_CREATEDBY", Convert.ToInt32(objCFELandDet.CreatedBy));
                com.Parameters.AddWithValue("@CFELD_CREATEDBYIP", objCFELandDet.IPAddress);

                com.Parameters.AddWithValue("@CFELD_CFEQDID", Convert.ToInt32(objCFELandDet.Questionnariid));
                com.Parameters.AddWithValue("@CFELD_UNITID", Convert.ToInt32(objCFELandDet.UnitId));

                com.Parameters.AddWithValue("@CFELD_SURVEYNO", objCFELandDet.Survey_Plot);
                com.Parameters.AddWithValue("@CFELD_DISTID", Convert.ToInt32(objCFELandDet.District));
                com.Parameters.AddWithValue("@CFELD_MANDALID", Convert.ToInt32(objCFELandDet.Mandal));
                com.Parameters.AddWithValue("@CFELD_VILLAGEID", Convert.ToInt32(objCFELandDet.Village));
                com.Parameters.AddWithValue("CFELD_DISTNAME", objCFELandDet.DistrictName);
                com.Parameters.AddWithValue("CFELD_MANDALNAME", objCFELandDet.MandalName);
                com.Parameters.AddWithValue("CFELD_VILLAGENAME", objCFELandDet.VillageName);

                com.Parameters.AddWithValue("@CFELD_GRAMPANCHAYAT", objCFELandDet.Name_Grampanchayat);
                com.Parameters.AddWithValue("@CFELD_PINCODE", Convert.ToInt32(objCFELandDet.Pincode));

                com.Parameters.AddWithValue("@CFELD_TELEPHONENO", objCFELandDet.Landline);
                com.Parameters.AddWithValue("@CFELD_TOTALEXTEND", Convert.ToInt32(objCFELandDet.Total_Extent_Area));

                //  com.Parameters.AddWithValue("@CFELD_TOTALEXTEND", objCFELandDet.Total_Extent_Area);
                com.Parameters.AddWithValue("@CFELD_BUILDINGTYPE", Convert.ToInt32(objCFELandDet.Type_Building));
                com.Parameters.AddWithValue("@CFELD_LAND", Convert.ToInt32(objCFELandDet.Land_Master_Plan));
                com.Parameters.AddWithValue("@CFELD_AREADEVELOPMENT", Convert.ToInt32(objCFELandDet.Proposed_Area_Develop));
                //  com.Parameters.AddWithValue("", objCFELandDet.Proposed_Area_Develop);
                // com.Parameters.AddWithValue("", objCFELandDet.Total_Built_Area);
                com.Parameters.AddWithValue("@CFELD_TOTALBUILTUP", Convert.ToInt32(objCFELandDet.Total_Built_Area));

                // com.Parameters.AddWithValue("", objCFELandDet.Height_Building);
                com.Parameters.AddWithValue("@CFELD_BUILDINGHT", SqlDbType.Decimal).Value = objCFELandDet.Height_Building;
                //  com.Parameters.AddWithValue("", objCFELandDet.Existing_Width);
                com.Parameters.AddWithValue("@CFELD_EXISTINGWIDTH", Convert.ToInt32(objCFELandDet.Existing_Width));

                com.Parameters.AddWithValue("@CFELD_APPROACHTYPE", Convert.ToInt32(objCFELandDet.Type_ApproachRoad));
                com.Parameters.AddWithValue("@CFELD_LANDLOACTION", Convert.ToInt32(objCFELandDet.Land_Locationfalls));
                com.Parameters.AddWithValue("@CFELD_BUILDINGAPPROVAL", Convert.ToInt32(objCFELandDet.Building_Approval));
                com.Parameters.AddWithValue("@CFELD_INDUSTRYACTIVITY", Convert.ToInt32(objCFELandDet.Industry_Product));
                //  com.Parameters.AddWithValue("@CFELD_CATEGORYINDUSTRY", Convert.ToInt32(objCFELandDet.Category_Industry));
                com.Parameters.AddWithValue("@CFELD_CATEGORYINDUSTRY", objCFELandDet.Category_Industry);
                com.Parameters.AddWithValue("@CFELD_ROADWIDENING", objCFELandDet.Road_Widening);
                com.Parameters.AddWithValue("@CFELD_LANDPART", objCFELandDet.land_part);

                //  com.Parameters.AddWithValue("", Convert.ToInt32(objCFELandDet.Road_Widening));
                com.Parameters.AddWithValue("@CFELD_ARCHITECTLICNO", Convert.ToInt32(objCFELandDet.Architect_LICNo));
                com.Parameters.AddWithValue("@CFELD_ARCHITECTNAME", objCFELandDet.Architect_Name);
                com.Parameters.AddWithValue("CFELD_ARCHITECTMOBILE", Convert.ToInt64(objCFELandDet.Architect_MobileNo));
                com.Parameters.AddWithValue("@CFELD_STRUCTURALENGNAME", objCFELandDet.Structural_Engineer);
                com.Parameters.AddWithValue("CFELD_STRUCTURALENGMOBILE", Convert.ToInt64(objCFELandDet.Structural_Mobile_No));
                com.Parameters.AddWithValue("CFELD_STRUCTURALLICNO", Convert.ToInt32(objCFELandDet.StructuralLicNo));
                // com.Parameters.AddWithValue("@CFELD_ARCHITECTURALDWG", SqlDbType.VarBinary).Value = objCFELandDet.Architectural_dwg;
                //com.Parameters.AddWithValue("@CFELD_AFFIDAVIT", SqlDbType.VarBinary).Value = objCFELandDet.Common_Affidavit;

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public DataSet GetCFELandDet(string UserID, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFELandDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFELandDet;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitID));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(UserID));


                da.Fill(ds);
                transaction.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string InsertCFEForestDet(Forest_Details objCFEQForest)
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
                com.CommandText = CFEConstants.InsertCFEForestDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFEFD_CREATEDBY", Convert.ToInt32(objCFEQForest.CreatedBy));
                com.Parameters.AddWithValue("@CFEFD_CREATEDBYIP", objCFEQForest.IPAddress);

                com.Parameters.AddWithValue("@CFEFD_CFEQDID", Convert.ToInt32(objCFEQForest.Questionnariid));
                com.Parameters.AddWithValue("@CFEFD_UNITID", Convert.ToInt32(objCFEQForest.UnitId));
                com.Parameters.AddWithValue("@CFEFD_ADDRESS", objCFEQForest.Address);
                com.Parameters.AddWithValue("@CFEFD_LATTITUDE", objCFEQForest.Lattitude);
                com.Parameters.AddWithValue("@CFEFD_DEGREES", objCFEQForest.LatDegrees);
                com.Parameters.AddWithValue("@CFEFD_MINUTES", objCFEQForest.LatMinutes);
                com.Parameters.AddWithValue("@CFEFD_SECONDS", objCFEQForest.LatSeconds);
                com.Parameters.AddWithValue("@CFEFD_LONGITUDE", objCFEQForest.Longitude);
                com.Parameters.AddWithValue("@CFEFD_DEGREE", objCFEQForest.LongDegrees);
                com.Parameters.AddWithValue("@CFEFD_MINUTE", objCFEQForest.LongMinutes);
                com.Parameters.AddWithValue("@CFEFD_SECOND", objCFEQForest.LongSeconds);
                com.Parameters.AddWithValue("@CFEFD_GPSCOORDINATES", objCFEQForest.GPSCoodinates);
                com.Parameters.AddWithValue("@CFEFD_PURPOSEAPPLICATION", objCFEQForest.Purpose);
                com.Parameters.AddWithValue("@CFEFD_FORESTDIVISION", objCFEQForest.ForestDivision);
                com.Parameters.AddWithValue("@CFEFD_INFORMATION", objCFEQForest.information);
                com.Parameters.AddWithValue("@CFEFD_SPECIES", objCFEQForest.Species);
                com.Parameters.AddWithValue("@CFEFD_TIMBERLENGTH", objCFEQForest.EstTimberLength);
                com.Parameters.AddWithValue("@CFEFD_TIMBERVOLUME", objCFEQForest.EstTimberVolume);
                com.Parameters.AddWithValue("@CFEFD_GIRTH", objCFEQForest.Girth);
                com.Parameters.AddWithValue("@CFEFD_ESTIMATED", objCFEQForest.Est_Firewood);

                com.Parameters.AddWithValue("@CFEFD_POLES", Convert.ToInt32(objCFEQForest.No_Poles));
                com.Parameters.AddWithValue("@CFEFD_NORTH", objCFEQForest.North);
                com.Parameters.AddWithValue("@CFEFD_EAST", objCFEQForest.East);
                com.Parameters.AddWithValue("@CFEFD_WEST", objCFEQForest.West);
                com.Parameters.AddWithValue("@CFEFD_SOUTH", objCFEQForest.South);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public string InsertCFEWaterDetails(Water_Details ObjCFEWater)
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
                com.CommandText = CFEConstants.INSERTCFEWaterDet;

                com.Transaction = transaction;
                com.Connection = connection;

                //DataTable dt = new DataTable();
                //SqlDataAdapter da;
                //da = new SqlDataAdapter(CFEConstants.INSERTCFEWaterDet, connection);
                //da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.CommandText = CFEConstants.INSERTCFEWaterDet;
                //da.SelectCommand.Transaction = transaction;
                //da.SelectCommand.Connection = connection;

                com.Parameters.AddWithValue("@CFEWD_CREATEDBY", Convert.ToInt32(ObjCFEWater.CreatedBy));
                com.Parameters.AddWithValue("@CFEWD_CREATEDBYIP", ObjCFEWater.IPAddress);
                com.Parameters.AddWithValue("@CFEWD_CFEQDID", Convert.ToInt32(ObjCFEWater.Questionnariid));
                com.Parameters.AddWithValue("@CFEWD_UNITID", Convert.ToInt32(ObjCFEWater.UNITID));
                com.Parameters.AddWithValue("@CFEWD_WATERDRINK", Convert.ToDecimal(ObjCFEWater.Drinking_Water));
                com.Parameters.AddWithValue("@CFEWD_WATERPROCESS", Convert.ToDecimal(ObjCFEWater.water_Industrial));
                com.Parameters.AddWithValue("@CFEWD_CONSUMPTIVEWATER", Convert.ToDecimal(ObjCFEWater.Quantity_Water));
                com.Parameters.AddWithValue("@CFEWD_NONCONSUMPTIVEWATER", Convert.ToDecimal(ObjCFEWater.Non_Consumptive_water));
                //com.Parameters.AddWithValue("@CFEWD_OVERHEAD", ObjCFEWater.OVERHEAD);
                //com.Parameters.AddWithValue("@CFEWD_UNDERGROUND", ObjCFEWater.UNDERGROUND);
                //com.Parameters.AddWithValue("@CFEWD_TANKER", ObjCFEWater.TANKER_CAPACITY);
                com.Parameters.AddWithValue("@CFEWD_WATERCONN", ObjCFEWater.WATERCONNECTION);
                com.Parameters.AddWithValue("@CFEWD_HOLDINGNO", ObjCFEWater.HOLDING);
                com.Parameters.AddWithValue("@CFEWD_WARDNO", ObjCFEWater.WARDNO);
                com.Parameters.AddWithValue("@CFEWD_DIVISIONAL", ObjCFEWater.SUBDIVISION);
                com.Parameters.AddWithValue("@CFEWD_NOOFPREMISE", Convert.ToInt32(ObjCFEWater.PREMISENUMBER));
                com.Parameters.AddWithValue("@CFEWD_DEMANDPERDAY", Convert.ToInt32(ObjCFEWater.WATERDEMAND));
                com.Parameters.AddWithValue("@CFEWD_INFORMATION", ObjCFEWater.ANYOTHERINFORMATION);
                com.Parameters.AddWithValue("@CFEWD_DISTRIC", Convert.ToInt32(ObjCFEWater.DISTRIC));
                com.Parameters.AddWithValue("@CFEWD_MANDAL ", Convert.ToInt32(ObjCFEWater.MANDAL));
                com.Parameters.AddWithValue("@CFEWD_VILLAGE", Convert.ToInt32(ObjCFEWater.VILLAGE));
                com.Parameters.AddWithValue("@CFEWD_LOCALITY", ObjCFEWater.LOCALITY);
                com.Parameters.AddWithValue("@CFEWD_LANDMARK", ObjCFEWater.LANDMARK);
                com.Parameters.AddWithValue("@CFEWD_PINCODE ", Convert.ToInt32(ObjCFEWater.PINCODE));
                com.Parameters.AddWithValue("@CFEWD_PURPOSECON", ObjCFEWater.PURPOSECONN);
                com.Parameters.AddWithValue("@CFEWD_TYPECONN", ObjCFEWater.TYPECON);
                com.Parameters.AddWithValue("@CFEWD_DOMESTIC", ObjCFEWater.DOMESTIC);
                com.Parameters.AddWithValue("@CFEWD_BULK", ObjCFEWater.BULK);


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex; throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public DataSet GetWaterDetailos(string userid, string UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFEWaterDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFEWaterDetails;

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
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet getIntentInvestPrint(string ID) // Need to remove later
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetRetriveIntentInvest, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetRetriveIntentInvest;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@ID", Convert.ToInt32(ID));
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
        public DataSet GetRetriveFireDet(string userid, String UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetRetriveFireDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetRetriveFireDetails;

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
        public DataSet GetPaymentAmounttoPay(string userid, string UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFEApprovalsAmounttoPay, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFEApprovalsAmounttoPay;

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
        public string InsertPaymentDetails(CFEPayments objpay)
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
                com.CommandText = CFEConstants.InsertPaymentDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFEPD_UNITID", Convert.ToInt32(objpay.UNITID));
                com.Parameters.AddWithValue("@CFEPD_CFEQDID", Convert.ToInt32(objpay.Questionnareid));
                com.Parameters.AddWithValue("@CFEPD_UIDNO", objpay.CFEUID);
                com.Parameters.AddWithValue("@CFEPD_DEPTID", objpay.DeptID);
                com.Parameters.AddWithValue("@CFEPD_APPROVALID", Convert.ToInt32(objpay.ApprovalID));
                com.Parameters.AddWithValue("@CFEPD_ONLINEORDERNO", objpay.OnlineOrderNo);
                com.Parameters.AddWithValue("@CFEPD_ONLINEAMOUNT", objpay.OnlineOrderAmount);
                com.Parameters.AddWithValue("@CFEPD_PAYMENTFLAG", objpay.PaymentFlag);
                com.Parameters.AddWithValue("@CFEPD_TRANSACTIONNO", objpay.TransactionNo);
                com.Parameters.AddWithValue("@CFEPD_BANKNAME", objpay.BankName);
                com.Parameters.AddWithValue("@CFEPD_TRANSACTIONDATE", objpay.TransactionDate);
                com.Parameters.AddWithValue("@CFEPD_CRETAEDBY", Convert.ToInt32(objpay.CreatedBy));
                com.Parameters.AddWithValue("@CFEPD_CRETAEDBYIP", objpay.IPAddress);

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
        public string InsertCFEAttachments(CFEAttachments objAttachments)
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
                com.CommandText = CFEConstants.InsertCFEAttachments;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFEA_UNITID", Convert.ToInt32(objAttachments.UNITID));
                com.Parameters.AddWithValue("@CFEA_CFEQDID", Convert.ToInt32(objAttachments.Questionnareid));
                com.Parameters.AddWithValue("@CFEA_QUERYID", objAttachments.QueryID);
                com.Parameters.AddWithValue("@CFEA_MASTERAID", objAttachments.MasterID);
                com.Parameters.AddWithValue("@CFEA_FILEPATH", objAttachments.FilePath);
                com.Parameters.AddWithValue("@CFEA_FILENAME", objAttachments.FileName);
                com.Parameters.AddWithValue("@CFEA_FILETYPE", objAttachments.FileType);
                com.Parameters.AddWithValue("@CFEA_FILEDESCRIPTION", objAttachments.FileDescription);
                com.Parameters.AddWithValue("@CFEA_DEPTID", objAttachments.DeptID);
                com.Parameters.AddWithValue("@CFEA_APPROVALID", objAttachments.ApprovalID);
                com.Parameters.AddWithValue("@CFEA_CREATEDBY", Convert.ToInt32(objAttachments.CreatedBy));
                com.Parameters.AddWithValue("@CFEA_CREATEDBYIP", objAttachments.IPAddress);
                if (objAttachments.ReferenceNo != null && objAttachments.ReferenceNo != "")
                {
                    com.Parameters.AddWithValue("@CFEA_REFERENCENO", objAttachments.ReferenceNo);
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
        public DataSet GetCFEAttachmentsData(string userid, string UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFEAttachments, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFEAttachments;

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
        public DataSet GetUserCFEApplStatus(string Userid, string UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetUserCFEApplStatus, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetUserCFEApplStatus;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UNITID));
                da.SelectCommand.Parameters.AddWithValue("@USERID", Convert.ToInt32(Userid));
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
        public DataSet GetUserCFEApplStatusView(string Userid, string UNITID, string Status)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetUserCFEApplStatusView, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetUserCFEApplStatusView;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UNITID));
                da.SelectCommand.Parameters.AddWithValue("@USERID", Convert.ToInt32(Userid));
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

        public string InsertCFElabourContractor(Labour_Details ObjCFELabourDet)
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
                com.CommandText = CFEConstants.InsertCFELabourContractorDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFECL_CFEQDID", Convert.ToInt32(ObjCFELabourDet.Questionnariid));
                com.Parameters.AddWithValue("@CFECL_CREATEDBY", Convert.ToInt32(ObjCFELabourDet.CreatedBy));
                com.Parameters.AddWithValue("@CFECL_CREATEDBYIP", ObjCFELabourDet.IPAddress);
                com.Parameters.AddWithValue("@CFECL_UNITID", Convert.ToInt32(ObjCFELabourDet.UNITID));
                com.Parameters.AddWithValue("@CFECL_CONTRACTORNAMEADDRESS", ObjCFELabourDet.CFECL_CONTRACTORNAMEADDRESS);
                com.Parameters.AddWithValue("@CFECL_WORKNAMENATURELOCATION", ObjCFELabourDet.CFECL_WORKNAMENATURELOCATION);
                com.Parameters.AddWithValue("@CFECL_MAXCONTRACTLABOUR", ObjCFELabourDet.CFECL_MAXCONTRACTLABOUR);
                com.Parameters.AddWithValue("@CFECL_CONTRACTDURATION", ObjCFELabourDet.CFECL_CONTRACTDURATION);
                com.Parameters.AddWithValue("@CFECL_COMMENCEMENTDATEOFWORK", DateTime.ParseExact(ObjCFELabourDet.CFECL_COMMENCEMENTDATEOFWORK, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFECL_COMPLETIONDATEOFWORK", DateTime.ParseExact(ObjCFELabourDet.CFECL_COMPLETIONDATEOFWORK, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFECL_TERMINATIONDATEOFEMP", DateTime.ParseExact(ObjCFELabourDet.CFECL_TERMINATIONDATEOFEMP, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));

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

        public DataSet GetRetriveCFELabourContractorDet(string userid, string UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFELabourContractorDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFELabourContractorDet;

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
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public string InsertMigrantDetails(Labour_Details ObjCFELabourDet)
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
                com.CommandText = CFEConstants.InsertCFEMigrantDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFEMW_CFEQDID", Convert.ToInt32(ObjCFELabourDet.Questionnariid));
                com.Parameters.AddWithValue("@CFEMW_CREATEDBY", Convert.ToInt32(ObjCFELabourDet.CreatedBy));
                com.Parameters.AddWithValue("@CFEMW_CREATEDBYIP", ObjCFELabourDet.IPAddress);
                com.Parameters.AddWithValue("@CFEMW_UNITID", Convert.ToInt32(ObjCFELabourDet.UNITID));
                com.Parameters.AddWithValue("@CFEMW_CONTRACTORNAMEADDRESS", ObjCFELabourDet.CONTRACTORNAMEADDRESS);
                com.Parameters.AddWithValue("@CFEMW_MIGRANTNAMENATURELOCATION", ObjCFELabourDet.MIGRANTNAMENATURELOCATION);
                com.Parameters.AddWithValue("@CFEMW_MAXCONTRACTMIGRANT", ObjCFELabourDet.MAXCONTRACTMIGRANT);
                com.Parameters.AddWithValue("@CFEMW_CONTRACTDURATION", Convert.ToInt32(ObjCFELabourDet.CONTRACTDURATION));
                com.Parameters.AddWithValue("@CFEMW_COMMENCEMENTDATE", DateTime.ParseExact(ObjCFELabourDet.COMMENCEMENTDATE, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFEMW_COMPLETIONDATEOFWORK", DateTime.ParseExact(ObjCFELabourDet.COMPLETIONDATEOFWORK, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFEMW_TERMINATIONDATEOFEMPMigrant", DateTime.ParseExact(ObjCFELabourDet.TERMINATIONDATEOFEMPMigrant, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));

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
        public string InsertCFELabourDetails(Labour_Details ObjCFELabourDet)
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
                com.CommandText = CFEConstants.InsertCFELabourDet;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFELD_CREATEDBY", Convert.ToInt32(ObjCFELabourDet.CreatedBy));
                com.Parameters.AddWithValue("@CFELD_CREATEDBYIP", ObjCFELabourDet.IPAddress);
                com.Parameters.AddWithValue("@CFELD_CFEQDID", Convert.ToInt32(ObjCFELabourDet.Questionnariid));
                com.Parameters.AddWithValue("@CFELD_UNITID", Convert.ToInt32(ObjCFELabourDet.UnitId));

                com.Parameters.AddWithValue("@CFELD_CATEGORY_ESTABLISHMENT", ObjCFELabourDet.Category_Estab);
                com.Parameters.AddWithValue("@CFELD_NAME", ObjCFELabourDet.Name_Contractor);
                com.Parameters.AddWithValue("@CFELD_FATHERNAME", ObjCFELabourDet.Father_Name);
                com.Parameters.AddWithValue("@CFELD_AGE", Convert.ToInt32(ObjCFELabourDet.Age));
                com.Parameters.AddWithValue("@CFELD_DESIGNATION", ObjCFELabourDet.Designation);
                com.Parameters.AddWithValue("@CFELD_MOBILENO", Convert.ToInt64(ObjCFELabourDet.MobileNo));
                com.Parameters.AddWithValue("@CFELD_EMAILID", ObjCFELabourDet.EmailId);
                com.Parameters.AddWithValue("@CFELD_DISTRICSID", Convert.ToInt32(ObjCFELabourDet.District));
                com.Parameters.AddWithValue("@CFELD_MANDALSID", Convert.ToInt32(ObjCFELabourDet.Mandal));
                com.Parameters.AddWithValue("@CFELD_VILLAGESID", Convert.ToInt32(ObjCFELabourDet.Village));
                com.Parameters.AddWithValue("@CFELD_DISTRICNAME ", ObjCFELabourDet.DistrictName);
                com.Parameters.AddWithValue("@CFELD_MANDALSNAME ", ObjCFELabourDet.MandalName);
                com.Parameters.AddWithValue("@CFELD_VILLAGESNAME", ObjCFELabourDet.VillageName);
                com.Parameters.AddWithValue("@CFELD_DOOR", ObjCFELabourDet.Door_No);
                com.Parameters.AddWithValue("@CFELD_LOCALITY", ObjCFELabourDet.Locality);
                com.Parameters.AddWithValue("@CFELD_PINCODE", Convert.ToInt32(ObjCFELabourDet.Pincode));

                com.Parameters.AddWithValue("@CFELD_MANAGERNAME", ObjCFELabourDet.ManagerName);
                com.Parameters.AddWithValue("@CFELD_MANAGERMOBILENO", Convert.ToInt64(ObjCFELabourDet.ManagerMobile));
                com.Parameters.AddWithValue("@CFELD_MANAGEREMAILID", ObjCFELabourDet.ManagerEmail);
                com.Parameters.AddWithValue("@CFELD_MANAGERFATHERNAME", ObjCFELabourDet.ManagerFather);
                com.Parameters.AddWithValue("@CFELD_MANAGERDOOR", ObjCFELabourDet.ManagerDoor);
                com.Parameters.AddWithValue("@CFELD_MANAGERLOCALITY", ObjCFELabourDet.ManagerLocality);
                com.Parameters.AddWithValue("@CFELD_MANAGERDISTRICSID", Convert.ToInt32(ObjCFELabourDet.ManagerDistrict));
                com.Parameters.AddWithValue("@CFELD_MANAGERMANDALSID", Convert.ToInt32(ObjCFELabourDet.ManagerMandal));
                com.Parameters.AddWithValue("@CFELD_MANAGERVILLAGESID", Convert.ToInt32(ObjCFELabourDet.ManagerVillage));
                com.Parameters.AddWithValue("@CFELD_MANAGERPINCODE", Convert.ToInt32(ObjCFELabourDet.ManagerPincode));
                com.Parameters.AddWithValue("@CFELD_MANAGERDESIGNATION", ObjCFELabourDet.ManagerDesignation);

                com.Parameters.AddWithValue("@CFELD_NATUREOFWORKLABOUREMP", ObjCFELabourDet.NatureOflabourCont);
                com.Parameters.AddWithValue("@CFELD_ESTDATEBUILDING", ObjCFELabourDet.BuildingContractWork);
                com.Parameters.AddWithValue("@CFELD_MAXNUMBEROFCONTRACTEMP", ObjCFELabourDet.BuildingEmpDay);
                com.Parameters.AddWithValue("@CFELD_ESTDATEOFCONSTRUCTIONWORK", ObjCFELabourDet.EstDateBuilding);
                com.Parameters.AddWithValue("@CFELD_MAXNUMBERMIGRANTESTDATE", ObjCFELabourDet.MigrantWork);
                com.Parameters.AddWithValue("@CFELD_CONTRACTORCONVICTED5YEARS", ObjCFELabourDet.ContractFiveYears);
                com.Parameters.AddWithValue("@CFELD_REVOKINGSUSPENDINGLIC", ObjCFELabourDet.Revoking);
                com.Parameters.AddWithValue("@CFELD_ESTPAST5YEARSNATUREOFWORK", ObjCFELabourDet.PrincipleEmpWork);
                com.Parameters.AddWithValue("@CFELD_INDUSTRYMANUOCCUPATIONEST", ObjCFELabourDet.ManuooCupation);


                com.Parameters.AddWithValue("@CFELD_CONTRACTORNAMECONTRACTOR", ObjCFELabourDet.ContarctorName);
                com.Parameters.AddWithValue("@CFELD_CONTRACTORFATHER", ObjCFELabourDet.ContarctorFather);
                com.Parameters.AddWithValue("@CFELD_CONTRACTORAGES", Convert.ToInt32(ObjCFELabourDet.ContarctorAge));
                com.Parameters.AddWithValue("@CFELD_CONTRACTORMOBILE", Convert.ToInt64(ObjCFELabourDet.ContarctorMobile));
                com.Parameters.AddWithValue("@CFELD_CONTRACTOREMAIL", ObjCFELabourDet.ContarctorEmailId);
                com.Parameters.AddWithValue("@CFELD_CONTRACTORDISTID", Convert.ToInt32(ObjCFELabourDet.ContarctorDistrict));
                com.Parameters.AddWithValue("@CFELD_CONTRACTORMANDALID", Convert.ToInt32(ObjCFELabourDet.ContarctorMandals));
                com.Parameters.AddWithValue("@CFELD_CONTRACTORVILLAGEID", Convert.ToInt32(ObjCFELabourDet.ContarctorVillages));
                com.Parameters.AddWithValue("@CFELD_CONTRACTORDOORNO", ObjCFELabourDet.ContarctorDoor);
                com.Parameters.AddWithValue("@CFELD_CONTRACTORLOCALITYNAME", ObjCFELabourDet.ContarctorLocality);
                com.Parameters.AddWithValue("@CFELD_CONTRACTORPIN", Convert.ToInt32(ObjCFELabourDet.ContarctorPincode));
                com.Parameters.AddWithValue("@CFELD_AGENTNAME", ObjCFELabourDet.AgentName);
                com.Parameters.AddWithValue("@CFELD_AGENTDOORNO", ObjCFELabourDet.AgentDoorNo);
                com.Parameters.AddWithValue("@CFELD_AGENTLOCALITY", ObjCFELabourDet.AgentLocality);
                com.Parameters.AddWithValue("@CFELD_AGENTDISTRICT", Convert.ToInt32(ObjCFELabourDet.AgentDistric));
                com.Parameters.AddWithValue("@CFELD_AGENTMANDAL", Convert.ToInt32(ObjCFELabourDet.AgentMandal));
                com.Parameters.AddWithValue("@CFELD_AGENTVILLAGE", Convert.ToInt32(ObjCFELabourDet.AgentVillage));
                com.Parameters.AddWithValue("@CFELD_AGENTPINCODE", Convert.ToInt32(ObjCFELabourDet.AgentPinCode));

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
        public DataSet GetRetriveCFELabourDet(string userid, String UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetRetriveCFELabourDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetRetriveCFELabourDet;

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
        public DataSet GetRetriveCFEMigrantDetails(string userid, string UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFEMigrantDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFEMigrantDetails;

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
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetAppliedApprovalIDs(string userid, string UNITID, string QusestionnaireID, string DeptID, string ApprovalID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetAppliedApprovalIDs, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetAppliedApprovalIDs;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", UNITID);
                da.SelectCommand.Parameters.AddWithValue("@USERID", userid);
                da.SelectCommand.Parameters.AddWithValue("@CFEQID", QusestionnaireID);
                da.SelectCommand.Parameters.AddWithValue("@DEPTID", DeptID);
                if (ApprovalID == "")
                    da.SelectCommand.Parameters.AddWithValue("@APPROVALID", null);
                else
                    da.SelectCommand.Parameters.AddWithValue("@APPROVALID", ApprovalID);

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

        public string GETANNUALTURNOVER(string PMAMOUNT, string ANNUALTURNOVER)
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
                com.CommandText = CFEConstants.GETANNUALTURNOVER;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@PMVALUE", Convert.ToDecimal(PMAMOUNT));
                com.Parameters.AddWithValue("@AnnualTurnoverAmount", Convert.ToDecimal(ANNUALTURNOVER));


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public string CFEENTERPRISETYPE(string ANNUALTURNOVER)
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
                com.CommandText = CFEConstants.CFEENTERPRISETYPEDET;

                com.Transaction = transaction;
                com.Connection = connection;


                com.Parameters.AddWithValue("@AnnualTurnoverAmount", Convert.ToDecimal(ANNUALTURNOVER));


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }

        public string INSERTCFEDGSET(CFEDGset ObjCFEDGset)
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
                com.CommandText = CFEConstants.INSERTCFEDGSETDETAILS;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFEDG_CREATEDBY", Convert.ToInt32(ObjCFEDGset.CreatedBy));
                com.Parameters.AddWithValue("@CFEDG_CREATEDBYIP", ObjCFEDGset.IPAddress);
                com.Parameters.AddWithValue("@CFEDG_CFEQDID", Convert.ToInt32(ObjCFEDGset.Questionnaireid));
                com.Parameters.AddWithValue("@CFEDG_UNITID", Convert.ToInt32(ObjCFEDGset.UnitId));

                com.Parameters.AddWithValue("@CFEDG_LOCDOORNO", ObjCFEDGset.LocDoorno);
                com.Parameters.AddWithValue("@CFEDG_LOCALITY", ObjCFEDGset.Locality);
                com.Parameters.AddWithValue("@CFEDG_LANDMARK", ObjCFEDGset.Landamark);
                com.Parameters.AddWithValue("@CFEDG_LOCDISTRICTID", Convert.ToInt32(ObjCFEDGset.LocDistrictID));
                com.Parameters.AddWithValue("@CFEDG_LOCMANDALID", Convert.ToInt32(ObjCFEDGset.LocMandalID));
                com.Parameters.AddWithValue("@CFEDG_LOCVILLAGEID", Convert.ToInt32(Convert.ToInt64(ObjCFEDGset.LocVillageID)));
                if (ObjCFEDGset.LocPincode != null && ObjCFEDGset.LocPincode != "")
                {
                    com.Parameters.AddWithValue("@CFEDG_LOCPINCODE", Convert.ToInt64(ObjCFEDGset.LocPincode));
                }

                com.Parameters.AddWithValue("@CFEDG_SUPPLIERNAME", ObjCFEDGset.SupplierName);
                com.Parameters.AddWithValue("@CFEDG_TOTLCONNECTEDLOAD", ObjCFEDGset.TotalConnectedLoad);
                com.Parameters.AddWithValue("@CFEDG_TOTLPROPDGSETLOAD", ObjCFEDGset.PropLoadfromDGSet);
                com.Parameters.AddWithValue("@CFEDG_INTERLOCKPROVIDED", ObjCFEDGset.InterlockProvided);
                com.Parameters.AddWithValue("@CFEDG_MOTORLOAD", ObjCFEDGset.MotorLoad);
                com.Parameters.AddWithValue("@CFEDG_LIGHTSFANSLOAD", ObjCFEDGset.LightsandFansLoad);
                com.Parameters.AddWithValue("@CFEDG_OTHERLOAD", ObjCFEDGset.OtherlLoad);
                com.Parameters.AddWithValue("@CFEDG_GENRUNNINGMODE", ObjCFEDGset.GenRunningMode);

                com.Parameters.AddWithValue("@CFEDG_WRKCOMPLETIONDATE", DateTime.ParseExact(ObjCFEDGset.WorkCompletionDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyy-MM-dd"));
                com.Parameters.AddWithValue("@CFEDG_INSTLATIONSTARTDATE", DateTime.ParseExact(ObjCFEDGset.WorkStartingDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFEDG_COMMISSIONINGDATE", DateTime.ParseExact(ObjCFEDGset.CommissioningDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyy-MM-dd"));

                com.Parameters.AddWithValue("@CFEDG_SUPERVISORNAME", ObjCFEDGset.SupervisorName);
                com.Parameters.AddWithValue("@CFEDG_SUPERVISORLICNO", ObjCFEDGset.SupervisorLicNo);
                com.Parameters.AddWithValue("@CFEDG_CONTRACTORNAME", ObjCFEDGset.ContractorName);
                com.Parameters.AddWithValue("@CFEDG_CONTRACTORLICNO", ObjCFEDGset.ContractorLicNo);
                com.Parameters.AddWithValue("@CFEDG_DGSETOPERATORNAME", ObjCFEDGset.DGSetOperatorNmae);
                com.Parameters.AddWithValue("@CFEDG_DGSETCAPACITY", ObjCFEDGset.DGSetCapacity);
                com.Parameters.AddWithValue("@CFEDG_DGSETCAPACITYIN", ObjCFEDGset.DGSetCapacityin);
                com.Parameters.AddWithValue("@CFEDG_DGSETPOWERFACTOR", ObjCFEDGset.DGSetPowerFactor);
                com.Parameters.AddWithValue("@CFEDG_DGSETRATEDVOLTAGE", ObjCFEDGset.DGSetRatedVoltage);
                com.Parameters.AddWithValue("@CFEDG_DGSETENGINEDTLS", ObjCFEDGset.DGSetEngineDetails);
                com.Parameters.AddWithValue("@CFEDG_DGSETALTERNATORDTLS", ObjCFEDGset.DGSetAlternatorDetails);

                com.Parameters.AddWithValue("@CFEDG_EQUIPMENTTYPE", ObjCFEDGset.EquipmentType);
                com.Parameters.AddWithValue("@CFEDG_EARTHCONDCTRDTLS", ObjCFEDGset.EarthingCondctrDtls);
                com.Parameters.AddWithValue("@CFEDG_CONDUCTORPATHS", ObjCFEDGset.ConductrPaths);
                com.Parameters.AddWithValue("@CFEDG_ELECTRODEDTLS", ObjCFEDGset.ElectrodeDtls);

                com.Parameters.AddWithValue("@CFEDG_IMPEDANCE", ObjCFEDGset.Impedance);
                com.Parameters.AddWithValue("@CFEDG_TOTALIMPEDANCE", ObjCFEDGset.TotalImpedance);
                com.Parameters.AddWithValue("@CFEDG_LIGHTINGTYPE", ObjCFEDGset.LighingType);
                com.Parameters.AddWithValue("@CFEDG_ALTERNATORTESTDTLS", ObjCFEDGset.AlternatorTestDtls);
                com.Parameters.AddWithValue("@CFEDG_EARTHTESTERNO", ObjCFEDGset.EarthTesterNo);
                com.Parameters.AddWithValue("@CFEDG_EARTHTESTERMAKE", ObjCFEDGset.EarthTesterMake);
                com.Parameters.AddWithValue("@CFEDG_EARTHTESTERRANGE", ObjCFEDGset.EarthTesterRange);
                com.Parameters.AddWithValue("@CFEDG_MEGGERNO", ObjCFEDGset.MeggerNo);
                com.Parameters.AddWithValue("@CFEDG_MEGGERMAKE", ObjCFEDGset.MeggerMake);
                com.Parameters.AddWithValue("@CFEDG_MEGGERRANGE", ObjCFEDGset.MeggerRange);

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
        public DataSet RetrieveCFEDGSETDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GETCFEGSETDETAILS, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GETCFEGSETDETAILS;

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

        public string InsertCFECEIGDetails(CFECEIG ObjCFECEIG)
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
                com.CommandText = CFEConstants.InsertCFECEIGDEATISL;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFECD_CREATEDBY", Convert.ToInt32(ObjCFECEIG.CreatedBy));
                com.Parameters.AddWithValue("@CFECD_CREATEDBYIP", ObjCFECEIG.IPAddress);
                com.Parameters.AddWithValue("@CFECD_CFEQDID", Convert.ToInt32(ObjCFECEIG.Questionnareid));
                com.Parameters.AddWithValue("@CFECD_CFEUNITID", Convert.ToInt32(ObjCFECEIG.UnitId));

                com.Parameters.AddWithValue("@CFECD_ALREADYINSTALLED", ObjCFECEIG.ALREADY);
                com.Parameters.AddWithValue("@CFECD_PROPOSED", ObjCFECEIG.PROPOSED);
                com.Parameters.AddWithValue("@CFECD_TOTAL", Convert.ToInt32(ObjCFECEIG.TOTAL));
                com.Parameters.AddWithValue("@CFECD_CONNECTEDLOAD", ObjCFECEIG.CONNECTEDLOAD);
                com.Parameters.AddWithValue("@CFECD_ALREADTINSTALL", ObjCFECEIG.INSTALLED);
                com.Parameters.AddWithValue("@CFECD_PROPSE", ObjCFECEIG.PROPOSE);
                com.Parameters.AddWithValue("@CFECD_TOTALS", Convert.ToInt32(ObjCFECEIG.TOTALS));
                com.Parameters.AddWithValue("@CFECD_REGULATION", Convert.ToInt32(ObjCFECEIG.REGULATION));
                com.Parameters.AddWithValue("@CFECD_VOLTAGE", Convert.ToInt32(ObjCFECEIG.voltage));
                com.Parameters.AddWithValue("@CFECD_PLANT", Convert.ToInt32(ObjCFECEIG.Plant));
                com.Parameters.AddWithValue("@CFECD_CAPACITY", Convert.ToDecimal(ObjCFECEIG.CAPACITY));
                com.Parameters.AddWithValue("@CFECD_FACTORYLOCATION", ObjCFECEIG.LOCATIONFACTORY);
                com.Parameters.AddWithValue("@CFECD_SURVEYNO", ObjCFECEIG.SURVEYNO);
                com.Parameters.AddWithValue("@CFECD_EXTENT", Convert.ToDecimal(ObjCFECEIG.EXTENT));
                com.Parameters.AddWithValue("@CFECD_DISTRIC", Convert.ToInt32(ObjCFECEIG.DISTRIC));
                com.Parameters.AddWithValue("@CFECD_MANDAL ", Convert.ToInt32(ObjCFECEIG.MANDAL));
                com.Parameters.AddWithValue("@CFECD_VILLAGE", Convert.ToInt32(ObjCFECEIG.VILLAGE));
                com.Parameters.AddWithValue("@CFECD_STREETNAME", ObjCFECEIG.STREETNAME);
                com.Parameters.AddWithValue("@CFECD_PINCODE", Convert.ToInt32(ObjCFECEIG.PINCODE));
                com.Parameters.AddWithValue("@CFECD_TELEPHONE", Convert.ToInt64(ObjCFECEIG.TELEPHOPNE));
                com.Parameters.AddWithValue("@CFECD_NEARTELEPHONENO", Convert.ToInt64(ObjCFECEIG.NEARESTPHONENO));
                com.Parameters.AddWithValue("@CFECD_DATE", DateTime.ParseExact(ObjCFECEIG.DATE, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public DataSet GetCFEPOWERCEIGDETAILS(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GETCFEPOWERCEIGDETAILS, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GETCFEPOWERCEIGDETAILS;

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
        public string InsertCFEPetrolrumDetails(CFEPETROLEUM ObjCFEPetroleum)
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
                com.CommandText = CFEConstants.InsertCFEPetroleum;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFEPD_CREATEDBY", Convert.ToInt32(ObjCFEPetroleum.CreatedBy));
                com.Parameters.AddWithValue("@CFEPD_CREATEDBYIP", ObjCFEPetroleum.IPAddress);
                com.Parameters.AddWithValue("@CFEPD_CFEQDID", Convert.ToInt32(ObjCFEPetroleum.Questionnareid));
                com.Parameters.AddWithValue("@CFEPD_CFEUNITID", Convert.ToInt32(ObjCFEPetroleum.UnitId));

                com.Parameters.AddWithValue("@CFEPD_NOCPETROLPUMP", ObjCFEPetroleum.NOCPETROLPUMP);
                com.Parameters.AddWithValue("@CFEPD_NOCREQ", ObjCFEPetroleum.NOCREQ);
                com.Parameters.AddWithValue("@CFEPD_DISTRIC", Convert.ToInt32(ObjCFEPetroleum.DISTRIC));
                com.Parameters.AddWithValue("@CFEPD_MANDAL ", Convert.ToInt32(ObjCFEPetroleum.MANDAL));
                com.Parameters.AddWithValue("@CFEPD_VILLAGE", Convert.ToInt32(ObjCFEPetroleum.VILLAGE));
                com.Parameters.AddWithValue("@CFEPD_LOCATEDROAD", ObjCFEPetroleum.LOCATEDROAD);
                com.Parameters.AddWithValue("@CFEPD_NAMEEST", ObjCFEPetroleum.NAMEEST);
                com.Parameters.AddWithValue("@CFEPD_LANDHOLDINGNO", ObjCFEPetroleum.LANDHOLDINGNO);
                com.Parameters.AddWithValue("@CFEPD_LANDLEASER", ObjCFEPetroleum.LANDLEASER);
                com.Parameters.AddWithValue("@CFEPD_REGNO", ObjCFEPetroleum.REGNO);
                com.Parameters.AddWithValue("@CFEPD_AREALANDHOLDINGNO", ObjCFEPetroleum.AREALANDHOLDINGNO);
                com.Parameters.AddWithValue("@CFEPD_NORTH", Convert.ToInt32(ObjCFEPetroleum.NORTH));
                com.Parameters.AddWithValue("@CFEPD_EAST ", Convert.ToInt32(ObjCFEPetroleum.EAST));
                com.Parameters.AddWithValue("@CFEPD_SOUTH", Convert.ToInt32(ObjCFEPetroleum.SOUTH));
                com.Parameters.AddWithValue("@CFEPD_WEST ", Convert.ToInt32(ObjCFEPetroleum.WEST));
                com.Parameters.AddWithValue("@CFEPD_FRONTAGE", Convert.ToDecimal(ObjCFEPetroleum.FRONTAGE));
                com.Parameters.AddWithValue("@CFEPD_DEPTH", Convert.ToDecimal(ObjCFEPetroleum.DEPTH));



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public DataSet GetCFEPETROLEUMDETAILS(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GETCFEPERTROLEUMDETAILS, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GETCFEPERTROLEUMDETAILS;

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
        public string InsertCFEExplosiveManuDetails(CFEEXPLOSIVE ObjCFEExplosive)
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
                com.CommandText = CFEConstants.InsertCFEExplosiveManu;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFEME_CREATEDBY", Convert.ToInt32(ObjCFEExplosive.CreatedBy));
                com.Parameters.AddWithValue("@CFEME_CREATEDBYIP", ObjCFEExplosive.IPAddress);
                com.Parameters.AddWithValue("@CFEME_CFEQDID", Convert.ToInt32(ObjCFEExplosive.Questionnareid));
                com.Parameters.AddWithValue("@CFEME_CFEUNITID", Convert.ToInt32(ObjCFEExplosive.UnitId));

                com.Parameters.AddWithValue("@CFEME_NAME", ObjCFEExplosive.NAME);
                com.Parameters.AddWithValue("@CFEME_CLASS", ObjCFEExplosive.CLASS);
                com.Parameters.AddWithValue("@CFEME_DIVISION", ObjCFEExplosive.DIVISION);
                com.Parameters.AddWithValue("@CFEME_QUANTITYTIME", ObjCFEExplosive.QUANTITYTIME);
                com.Parameters.AddWithValue("@CFEME_QUANTITYMONTH", ObjCFEExplosive.QUANTITYMONTH);


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
        public string InsertCFEExplosiveDetails(CFEEXPLOSIVE ObjCFEExplosive)
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
                com.CommandText = CFEConstants.InsertCFEEXPLOSIVE;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFEED_CREATEDBY", Convert.ToInt32(ObjCFEExplosive.CreatedBy));
                com.Parameters.AddWithValue("@CFEED_CREATEDBYIP", ObjCFEExplosive.IPAddress);
                com.Parameters.AddWithValue("@CFEED_CFEQDID", Convert.ToInt32(ObjCFEExplosive.Questionnareid));
                com.Parameters.AddWithValue("@CFEED_CFEUNITID", Convert.ToInt32(ObjCFEExplosive.UnitId));

                com.Parameters.AddWithValue("@CFEED_EXPLOSIVESITE", ObjCFEExplosive.EXPLOSIVESITE);
                com.Parameters.AddWithValue("@CFEED_EXPLOSIVEROADVAN", ObjCFEExplosive.EXPLOSIVEROADVAN);
                com.Parameters.AddWithValue("@CFEED_CRIMINAL1973", ObjCFEExplosive.CRIMINAL1973);
                com.Parameters.AddWithValue("@CFEED_DETAIL", ObjCFEExplosive.DETAIL);
                com.Parameters.AddWithValue("@CFEED_EXPLOSIVE1884", ObjCFEExplosive.EXPLOSIVE1884);
                com.Parameters.AddWithValue("@CFEED_DETAILS", ObjCFEExplosive.DETAILS);
                com.Parameters.AddWithValue("@CFEED_APPROVAL101", ObjCFEExplosive.APPROVAL101);
                com.Parameters.AddWithValue("@CFEED_APPROVALDETAILS", ObjCFEExplosive.APPROVALDETAILS);
                com.Parameters.AddWithValue("@CFEED_ANYINFORMATION", ObjCFEExplosive.INFORMATION);



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public DataSet GetCFEEXPLOSIVE(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GETEXPLOSIVEDETAILS, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GETEXPLOSIVEDETAILS;

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

        public string InsertCFETaxDetails(CFETAXDetails ObjCFETax)
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
                com.CommandText = CFEConstants.InsertTaxDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFEPB_CREATEDBY", Convert.ToInt32(ObjCFETax.CreatedBy));
                com.Parameters.AddWithValue("@CFEPB_CREATEDBYIP", ObjCFETax.IPAddress);
                com.Parameters.AddWithValue("@CFEPB_CFEQDID", Convert.ToInt32(ObjCFETax.Questionnareid));
                com.Parameters.AddWithValue("@CFEPB_CFEUNITID", Convert.ToInt32(ObjCFETax.UnitId));

                com.Parameters.AddWithValue("@CFEPB_PLACEOFBUSINESS", ObjCFETax.PLACEBUSINESS);
                com.Parameters.AddWithValue("@CFEPB_ADDRESS", ObjCFETax.ADDRESS);
                com.Parameters.AddWithValue("@CFEPB_DISTRIC", ObjCFETax.DISTRIC);
                com.Parameters.AddWithValue("@CFEPB_TOTALWORKINGEMP", ObjCFETax.TOTALWORKINGEMPTE);


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
        public string InsertCFEPROFFESSIONALTAXDetails(CFETAXDetails ObjCFETax)
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
                com.CommandText = CFEConstants.InsertCFEProffessionalTaxDETAILS;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFEPT_CREATEDBY", Convert.ToInt32(ObjCFETax.CreatedBy));
                com.Parameters.AddWithValue("@CFEPT_CREATEDBYIP", ObjCFETax.IPAddress);
                com.Parameters.AddWithValue("@CFEPT_CFEQDID", Convert.ToInt32(ObjCFETax.Questionnareid));
                com.Parameters.AddWithValue("@CFEPT_CFEUNITID", Convert.ToInt32(ObjCFETax.UnitId));

                com.Parameters.AddWithValue("@CFEPT_APPLYAS", ObjCFETax.APPLYAS);
                com.Parameters.AddWithValue("@CFEPT_NAMEEST", ObjCFETax.NAMEEST);
                com.Parameters.AddWithValue("@CFEPT_ADDRESSEST", ObjCFETax.ADDRESSEST);
                com.Parameters.AddWithValue("@CFEPT_DISTRICEST", Convert.ToInt32(ObjCFETax.DISTRICEST));
                com.Parameters.AddWithValue("@CFEPT_PINCODEEST", Convert.ToInt32(ObjCFETax.PINCODEEST));
                com.Parameters.AddWithValue("@CFEPT_TOTALNOEMPEST", Convert.ToInt32(ObjCFETax.TOTALNOEMPEST));
                com.Parameters.AddWithValue("@CFEPT_DATE", DateTime.ParseExact(ObjCFETax.DATE, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFEPT_CONSTITUTIONEST", ObjCFETax.CONSTITUTIONEST);
                com.Parameters.AddWithValue("@CFEPT_GOODSSUPPLIESEST", ObjCFETax.GOODSSUPPLIESEST);
                com.Parameters.AddWithValue("@CFEPT_ADDITIONPLACEBUSINESS", ObjCFETax.ADDITIONPLACEBUSINESS);
                com.Parameters.AddWithValue("@CFEPT_DESIGNATION", ObjCFETax.DESIGNATION);
                com.Parameters.AddWithValue("@CFEPT_REGUNDERACT", ObjCFETax.REGUNDERACT);
                com.Parameters.AddWithValue("@CFEPT_REGTYPE", ObjCFETax.REGTYPE);
                com.Parameters.AddWithValue("@CFEPT_REGNO", Convert.ToInt32(ObjCFETax.REGNO));



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public DataSet GetCFETAXDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFETAXDETAILS, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFETAXDETAILS;

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
        public string InsertCFEHazardous(CFEPCBHAZARDOUSDET ObjCFEhazardous)
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
                com.CommandText = CFEConstants.InsertCFEPCBHAZARDOUSDETAILS;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@CFEHWD_CREATEDBY", Convert.ToInt32(ObjCFEhazardous.CreatedBy));
                com.Parameters.AddWithValue("@CFEHWD_CREATEDBYIP", ObjCFEhazardous.IPAddress);
                com.Parameters.AddWithValue("@CFEHWD_CFEQDID", Convert.ToInt32(ObjCFEhazardous.Questionnareid));
                com.Parameters.AddWithValue("@CFEHWD_UNITID", Convert.ToInt32(ObjCFEhazardous.UnitId));
                com.Parameters.AddWithValue("@CFEHWD_AUTHORIZATIONREQ", ObjCFEhazardous.AUTHORIZATIONREQ);
                com.Parameters.AddWithValue("@CFEHWD_WASTEHANDLEANNUM", Convert.ToDecimal(ObjCFEhazardous.WASTEHANDLEANNUM));
                com.Parameters.AddWithValue("@CFEHWD_WASTESTOREDTIME", Convert.ToDecimal(ObjCFEhazardous.WASTESTOREDTIME));
                com.Parameters.AddWithValue("@CFEHWD_QUANTITYWASTEANNUM", Convert.ToDecimal(ObjCFEhazardous.QUANTITYWASTEANNUM));
                com.Parameters.AddWithValue("@CFEHWD_QUANTITYSTOREDTIME", Convert.ToDecimal(ObjCFEhazardous.QUANTITYSTOREDTIME));
                com.Parameters.AddWithValue("@CFEHWD_YEAROFPRODUCTION", ObjCFEhazardous.YEAROFPRODUCTION);
                com.Parameters.AddWithValue("@CFEHWD_INDUSTRYWORK", ObjCFEhazardous.INDUSTRYWORK);


                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public DataSet GetCFEHAZARDOUSDEATILS(string userid, String UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFEHazardousDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFEHazardousDetails;

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
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public DataSet GetCFEQueryDashBoard(string Unitid, string Queryid)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFEQueryDashBoard, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFEQueryDashBoard;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                //da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(InvesterID));
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

        //-------------------------- DEPARTMENT STARTED HERE -------------------//

        public DataTable GetCFEDashBoard(CFEDtls objCFE)
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
                da = new SqlDataAdapter(CFEConstants.GetCFEDashBoard, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFEDashBoard;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;


                da.SelectCommand.Parameters.AddWithValue("@USERID", objCFE.UserID);
                da.SelectCommand.Parameters.AddWithValue("@ROLEID", objCFE.Role);
                if (objCFE.deptid != null && objCFE.deptid != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@DEPTID", objCFE.deptid);
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
        public DataTable GetCFEDashBoardView(CFEDtls objCFE)
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
                da = new SqlDataAdapter(CFEConstants.GetCFEDashBoardView, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFEDashBoardView;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                //PRD.deptid = 1;
                //PRD.status = 4;
                //PRD.Role = 0;

                da.SelectCommand.Parameters.AddWithValue("@USERID", objCFE.UserID);
                da.SelectCommand.Parameters.AddWithValue("@VIEWSTATUS", objCFE.ViewStatus);
                if (objCFE.deptid != null && objCFE.deptid != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@DEPTID", objCFE.deptid);
                }
                da.SelectCommand.Parameters.AddWithValue("@ROLEID", objCFE.Role);


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

        public DataSet GetCFEApplicationDetails(string UnitID, string InvesterID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetCFEApplicationDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetCFEApplicationDet;

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

        //// DEPARTMENT DASHBOARD///
        ///

        /////
        ///CFE
        ///
        public string UpdateCFEDepartmentProcess(CFEDtls Objcfedtls)
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
                com.CommandText = CFEConstants.UpdateCFEDepartmentProcess;

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@UNITID", Objcfedtls.Unitid);
                com.Parameters.AddWithValue("@CFEQDID", Objcfedtls.Questionnaireid);
                if (Objcfedtls.deptid != null && Objcfedtls.deptid != 0)
                {
                    com.Parameters.AddWithValue("@DEPTID", Objcfedtls.deptid);
                }
                com.Parameters.AddWithValue("@APPROVALID", Objcfedtls.ApprovalId);
                com.Parameters.AddWithValue("@ACTIONID", Objcfedtls.status);
                com.Parameters.AddWithValue("@REMARKS", Objcfedtls.Remarks);
                com.Parameters.AddWithValue("@CFDA_SCRUTINYREJECTIONFLAG", Objcfedtls.PrescrutinyRejectionFlag);
                if (Objcfedtls.AdditionalAmount != null && Objcfedtls.AdditionalAmount != "")
                {
                    com.Parameters.AddWithValue("@ADDLAMOUNT", Objcfedtls.AdditionalAmount);
                }

                com.Parameters.AddWithValue("@IPADDRESS", Objcfedtls.IPAddress);
                com.Parameters.AddWithValue("@CREATEDBY", Objcfedtls.UserID);
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
        public DataSet GetUnitDetailsforPayment(string UnitID, string InvesterID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetUnitDetailsforPayment, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetUnitDetailsforPayment;

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
        public string InsertPaymentRequest(string UnitID, string InvestorId, string Receiptorder, string OrderId, string PayAmount, string Name, string Desc, string Mail,
            string Contact, string Notes, string IpAddress)
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
                com.CommandText = CFEConstants.InsertPaymentRequest;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@UNITID", UnitID);
                com.Parameters.AddWithValue("@INVESTORID", InvestorId);
                com.Parameters.AddWithValue("@ONLINE_ORDER_NO", Receiptorder);
                com.Parameters.AddWithValue("@ORDERID", OrderId);
                com.Parameters.AddWithValue("@PAYMENTAMOUNT", PayAmount);
                com.Parameters.AddWithValue("@NAME", Name);
                com.Parameters.AddWithValue("@DESCRIPTION", Desc);
                com.Parameters.AddWithValue("@MAIL", Mail);
                com.Parameters.AddWithValue("@CONTACT", Contact);
                com.Parameters.AddWithValue("@NOTES", Notes);
                com.Parameters.AddWithValue("@IPADDRESS", IpAddress);

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
        public string UpdatePaymentResponse(string paymentId, string OrderId, string Signature, string IpAddress)
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
                com.CommandText = CFEConstants.UpdatePaymentResponse;

                com.Transaction = transaction;
                com.Connection = connection;


                com.Parameters.AddWithValue("@ORDERID", OrderId);
                com.Parameters.AddWithValue("@PAYMENT_ID", paymentId);
                com.Parameters.AddWithValue("@RESPONSE_SIGNATURE", Signature);
                com.Parameters.AddWithValue("@IPADDRESS", IpAddress);

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
        public string UpdatePaymentErrorResponse(string paymentId, string OrderId, string Signature, string IpAddress, string code, string description,
            string source, string step, string reason)
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
                com.CommandText = CFEConstants.UpdatePaymentErrorResponse;

                com.Transaction = transaction;
                com.Connection = connection;


                com.Parameters.AddWithValue("@ORDERID", OrderId);
                com.Parameters.AddWithValue("@PAYMENT_ID", paymentId);
                com.Parameters.AddWithValue("@RESPONSE_SIGNATURE", Signature);
                com.Parameters.AddWithValue("@IPADDRESS", IpAddress);
                com.Parameters.AddWithValue("@ERRORCODE", code);
                com.Parameters.AddWithValue("@ERRORDESC", description);
                com.Parameters.AddWithValue("@ERRORSOURCE", source);
                com.Parameters.AddWithValue("@ERRORSTEP", step);
                com.Parameters.AddWithValue("@ERRORREASON", reason);

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
        public DataSet GetPaymentOrderNo(string OrderId)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFEConstants.GetPaymentOrderNo, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.GetPaymentOrderNo;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@ORDERID", OrderId);
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
    }
}
