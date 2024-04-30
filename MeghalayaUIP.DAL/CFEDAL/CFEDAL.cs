using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeghalayaUIP.Common;
using System.Data.SqlClient;
using System.Data;

namespace MeghalayaUIP.DAL.CFEDAL
{
    public class CFEDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();

        
        public DataSet GetIndustryRegDetails(string userid)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFECommon.GetCFERegDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFECommon.GetCFERegDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(userid));
                da.Fill(ds);
                transaction.Commit();
                return ds;
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
                da = new SqlDataAdapter(CFECommon.GetCFEApprovalsReq, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFECommon.GetCFEApprovalsReq;

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

        public string InsertQuestionnaireCFE(CFEQuestionnaireDet objCFEQsnaire, out string IDno)
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
                da = new SqlDataAdapter(CFECommon.InsertCFEQuestionnaire, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFECommon.InsertCFEQuestionnaire;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                // da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(objCFEQsnaire.UserID));
                // da.SelectCommand.Parameters.AddWithValue("@IPADDRESS", objCFEQsnaire.IPAddress);

                da.SelectCommand.Parameters.AddWithValue("@CFEQD_COMPANYNAME", objCFEQsnaire.CompanyName);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_CONSTOFUNIT", Convert.ToInt32(objCFEQsnaire.ConstofUnit));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_PROPOSALFOR", objCFEQsnaire.ProposalFor);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_MIDCLLAND", Convert.ToInt32(objCFEQsnaire.LandFromMIDCL));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_PROPDISTRICTID", Convert.ToInt32(objCFEQsnaire.PropLocDitrictID));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_PROPMANDALID", Convert.ToInt32(objCFEQsnaire.PropLocMandalID));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_PROPVILLAGEID", Convert.ToInt32(objCFEQsnaire.PropLocVillageID));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_TOTALEXTENTLAND", objCFEQsnaire.ExtentofLand);
                //da.SelectCommand.Parameters.AddWithValue("", objCFEQsnaire.Acres);
                //da.SelectCommand.Parameters.AddWithValue("", objCFEQsnaire.Square_Meters);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_BUILTUPAREA", objCFEQsnaire.BuiltUpArea);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_SECTOR", Convert.ToInt32(objCFEQsnaire.SectorName));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_LOAID", Convert.ToInt32(objCFEQsnaire.Lineofacitivityid));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_PCBCATEGORY", objCFEQsnaire.PCBCategory);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_INDUSTRYTYPE", Convert.ToInt32(objCFEQsnaire.NatureofActivity));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_UNTLOCATION", objCFEQsnaire.UnitLocation);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_PROPEMP", objCFEQsnaire.PropEmployment);
                //da.SelectCommand.Parameters.AddWithValue("", objCFEQsnaire.ProjectCost);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_LANDVALUE", objCFEQsnaire.LandValue);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_BUILDINGVALUE", objCFEQsnaire.BuildingValue);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_PMCOST", objCFEQsnaire.PlantnMachineryCost);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_EXPECTEDTURNOVER", objCFEQsnaire.ExpectedTurnover);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_TOTALPROJCOST", objCFEQsnaire.TotalProjCost);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_ENTERPRISETYPE", objCFEQsnaire.EnterpriseCategory);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_POWERREQKW", Convert.ToInt32(objCFEQsnaire.PowerReqKW));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_GENREQ", Convert.ToInt32(objCFEQsnaire.GeneratorReq));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_BUILDINGHT", objCFEQsnaire.BuildingHeight);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_STORINGRSDS", Convert.ToInt32(objCFEQsnaire.StoringRSDS));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_MANFEXPLOSIVES", Convert.ToInt32(objCFEQsnaire.ManfExplosives));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_MANFPETROL", Convert.ToInt32(objCFEQsnaire.ManfPetroleum));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_RDCTNGREQ", Convert.ToInt32(objCFEQsnaire.RdCtngPermission));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_NONENCMCERTREQ", Convert.ToInt32(objCFEQsnaire.NonEncmbrnceCert));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_COMMTAXREQ", Convert.ToInt32(objCFEQsnaire.CommTaxApproval));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_USINGHTMETER", Convert.ToInt32(objCFEQsnaire.HTMeteruse));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_CEIGREGULATION", Convert.ToInt32(objCFEQsnaire.CEARegulationID));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_POWERPLANT", Convert.ToInt32(objCFEQsnaire.PowerPlantID));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_AGGRCAPACITY", objCFEQsnaire.AggCapacity);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_VOLTAGERATING", Convert.ToInt32(objCFEQsnaire.VoltageRating));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_TREESFELLING", Convert.ToInt32(objCFEQsnaire.TreesFelling));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_NOOFTREES", objCFEQsnaire.NoofTrees);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_NONFORSTLANDCERTREQ", Convert.ToInt32(objCFEQsnaire.NonForstLandCert));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_FORSTDISTLTRREQ", Convert.ToInt32(objCFEQsnaire.ForstDistLetr));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_WATERBODYVICINITY", Convert.ToInt32(objCFEQsnaire.NearWaterBodyLocation));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_BOREWELLEXISTS", Convert.ToInt32(objCFEQsnaire.ExistingBoreWell));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_LABOURACT1970", Convert.ToInt32(objCFEQsnaire.LabourAct1970));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_NOOFWORKERS1970", objCFEQsnaire.LabourAct1970_Workers);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_LABOURACT1979", Convert.ToInt32(objCFEQsnaire.LabourAct1979));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_NOOFWORKERS1979", objCFEQsnaire.LabourAct1979_Workers);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_LABOURACT1996", Convert.ToInt32(objCFEQsnaire.LabourAct1996));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_BUILDINGWORKS1996", Convert.ToInt32(objCFEQsnaire.LabourAct1996_10Workers));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_NOOFWORKERS1996", objCFEQsnaire.LabourAct1996_Workers);
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_CONTRLABOURACT", Convert.ToInt32(objCFEQsnaire.ContractLabourAct));
                da.SelectCommand.Parameters.AddWithValue("@CFEQD_NOOFWORKERSCONTR", objCFEQsnaire.ContractLabourAct_Workers);


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
        public DataTable GetsectorDep(string sectorname)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(CFECommon.GetSector_Department, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = CFECommon.GetSector_Department;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@SECTOR", sectorname);
                da.Fill(dt);

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
            return dt;
        }
    }
}
