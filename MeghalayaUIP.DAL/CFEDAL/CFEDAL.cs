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

namespace MeghalayaUIP.DAL.CFEDAL
{
    public class CFEDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();

        public DataSet GetPREREGandCFEapplications(string userid)
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
                com.Parameters.AddWithValue("@CFEID_REGDATE", objCFEEntrepreneur.CompanyRegDate);
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
                com.Parameters.AddWithValue("@CFEPD_TRIALPRODUCTIONDATE", DateTime.ParseExact(objCFEPower.Expected_Month_Trial, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFEPD_POWERREQDATE", DateTime.ParseExact(objCFEPower.Probable_Date_Power, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
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

                com.Parameters.AddWithValue("@CFEFD_DISTRICID", Convert.ToInt32(ObjCCFEFireDetails.DistricId));
                com.Parameters.AddWithValue("@CFEFD_MANDALID", Convert.ToInt32(ObjCCFEFireDetails.MandalId));
                com.Parameters.AddWithValue("@CFEFD_VILLAGEID", Convert.ToInt32(ObjCCFEFireDetails.VillageId));
                com.Parameters.AddWithValue("@CFEFD_DISTRICNAME", ObjCCFEFireDetails.DistricName);
                com.Parameters.AddWithValue("@CFEFD_MANDALNAME", ObjCCFEFireDetails.MandalName);
                com.Parameters.AddWithValue("@CFEFD_VILLAGENAME", ObjCCFEFireDetails.VillageName);
                com.Parameters.AddWithValue("@CFEFD_Locality", ObjCCFEFireDetails.Locality);
                com.Parameters.AddWithValue("@CFEFD_Landmark", ObjCCFEFireDetails.Landmark);
                com.Parameters.AddWithValue("@CFEFD_Pincode", Convert.ToInt32(ObjCCFEFireDetails.Pincode));
                com.Parameters.AddWithValue("@CFEFD_BUILDINGHT", SqlDbType.Decimal).Value = ObjCCFEFireDetails.HeightBuilding;
                com.Parameters.AddWithValue("@CFEFD_FLOORHT", SqlDbType.Decimal).Value = ObjCCFEFireDetails.HeightFloor;
                com.Parameters.AddWithValue("@CFEFD_PLOTAREA", SqlDbType.Decimal).Value = ObjCCFEFireDetails.PlotArea;
                com.Parameters.AddWithValue("@CFEFD_BUILDINGAREA", SqlDbType.Decimal).Value = ObjCCFEFireDetails.builoduparea;
                com.Parameters.AddWithValue("@CFEFD_DRIVEPROPSED", SqlDbType.Decimal).Value = ObjCCFEFireDetails.ProposedDrive;
                com.Parameters.AddWithValue("@CFEFD_EXISTINGROAD", SqlDbType.Decimal).Value = ObjCCFEFireDetails.ExistingRoad;
                com.Parameters.AddWithValue("@CFEFD_CATEGORYBUILD", ObjCCFEFireDetails.CategoryBuilding);
                com.Parameters.AddWithValue("@CFEFD_FEEAMOUNT", SqlDbType.Decimal).Value = ObjCCFEFireDetails.FeeAmount;
                com.Parameters.AddWithValue("@CFEFD_East", SqlDbType.Decimal).Value = ObjCCFEFireDetails.East;
                com.Parameters.AddWithValue("@CFEFD_West", SqlDbType.Decimal).Value = ObjCCFEFireDetails.West;
                com.Parameters.AddWithValue("@CFEFD_North", SqlDbType.Decimal).Value = ObjCCFEFireDetails.North;
                com.Parameters.AddWithValue("@CFEFD_South", SqlDbType.Decimal).Value = ObjCCFEFireDetails.South;
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
                com.Parameters.AddWithValue("@CFEFD_TIMBERLENGTH",  objCFEQForest.EstTimberLength);
                com.Parameters.AddWithValue("@CFEFD_TIMBERVOLUME", objCFEQForest.EstTimberVolume);
                com.Parameters.AddWithValue("@CFEFD_GIRTH",objCFEQForest.Girth);
                com.Parameters.AddWithValue("@CFEFD_ESTIMATED", objCFEQForest.Est_Firewood);
                
                com.Parameters.AddWithValue("@CFEFD_POLES", Convert.ToInt32(objCFEQForest.No_Poles));
                com.Parameters.AddWithValue("@CFEFD_NORTH", objCFEQForest.North);
                com.Parameters.AddWithValue("@CFEFD_EAST", objCFEQForest.East);
                com.Parameters.AddWithValue("@CFEFD_WEST",objCFEQForest.West);
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
        public string InsertCFEWaterDetails(CFEWater ObjCFEWater)
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
                da = new SqlDataAdapter(CFEConstants.INSERTCFEWaterDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFEConstants.INSERTCFEWaterDet;
                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;


                da.SelectCommand.Parameters.AddWithValue("", ObjCFEWater.BOREWELL);
                da.SelectCommand.Parameters.AddWithValue("", ObjCFEWater.RIVER);
                da.SelectCommand.Parameters.AddWithValue("", ObjCFEWater.HMWSSB);
                da.SelectCommand.Parameters.AddWithValue("", ObjCFEWater.water_Industrial);
                da.SelectCommand.Parameters.AddWithValue("", ObjCFEWater.Drinking_Water);
                da.SelectCommand.Parameters.AddWithValue("", ObjCFEWater.Quantity_Water);
                da.SelectCommand.Parameters.AddWithValue("", ObjCFEWater.Non_Consumptive_water);


                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    valid = Convert.ToString(dt.Rows[0]["UNITID"]);

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
            return valid;
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
    }
}
