using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Globalization;

namespace MeghalayaUIP.DAL.SVRCDAL
{
    public class SVRCDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();
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
                com.CommandText = SvrcConstants.GETANNUALTURNOVER;

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
                com.CommandText = SvrcConstants.CFEENTERPRISETYPEDET;

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

        public DataSet GetSvrcApplicantDetails(string userid, string unitID)
        {

            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetRENApplicantDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetRENApplicantDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(unitID));
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

        public string InsertRenApplicationDetails(SvrcApplicationDetails ObjApplicationDetails)
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
                com.CommandText = SvrcConstants.InsertRenApplicationDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@SRVCED_CREATEDBY", Convert.ToInt32(ObjApplicationDetails.CreatedBy));
                com.Parameters.AddWithValue("@SRVCED_CREATEDBYIP", ObjApplicationDetails.IPAddress);
                if (ObjApplicationDetails.Questionnariid != null && ObjApplicationDetails.Questionnariid != "")
                {
                    com.Parameters.AddWithValue("@SRVCED_SRVCQDID", Convert.ToInt32(ObjApplicationDetails.Questionnariid));
                }
                com.Parameters.AddWithValue("@SRVCED_UNITID", Convert.ToInt32(ObjApplicationDetails.UnitId));

                //com.Parameters.AddWithValue("@SRVCED_UIDNO", ObjApplicationDetails.UidNo);
                com.Parameters.AddWithValue("@SRVCED_NAMEOFUNIT", ObjApplicationDetails.Nameofunit);
                com.Parameters.AddWithValue("@SRVCED_COMPANYTYPE", ObjApplicationDetails.companyType);
                com.Parameters.AddWithValue("@SRVCED_SECTORENTERPRISE", ObjApplicationDetails.INDUSTRY);
                com.Parameters.AddWithValue("@SRVCED_CATEGORYREG", ObjApplicationDetails.CATEGORYREG);
                com.Parameters.AddWithValue("@SRVCED_REGNUMBER", Convert.ToInt32(ObjApplicationDetails.RegNumber));
                com.Parameters.AddWithValue("@SRVCED_REGDATE", ObjApplicationDetails.RegDate);
                //com.Parameters.AddWithValue("@RENID_SECTORENTERPRISE", ObjApplicationDetails.SectorEntrprise);
                com.Parameters.AddWithValue("@SRVCED_SECTOR", ObjApplicationDetails.Sector);
                com.Parameters.AddWithValue("@SRVCED_LINEOFACTIVITY", ObjApplicationDetails.LineofActivity);
                com.Parameters.AddWithValue("@SRVCED_POLLUTIONCATG", ObjApplicationDetails.PCB);
                com.Parameters.AddWithValue("@SRVCED_SURVEYDOOR", ObjApplicationDetails.SURVEY);
                com.Parameters.AddWithValue("@SRVCED_LOCALITY", ObjApplicationDetails.LOCALITY);
                com.Parameters.AddWithValue("@SRVCED_LANDMARK", ObjApplicationDetails.LANMARK);
                com.Parameters.AddWithValue("@SRVCED_DISTRIC", Convert.ToInt32(ObjApplicationDetails.DISTRICT));
                com.Parameters.AddWithValue("@SRVCED_MANDAL ", Convert.ToInt32(ObjApplicationDetails.MANDAL));
                com.Parameters.AddWithValue("@SRVCED_VILLAGE", Convert.ToInt32(ObjApplicationDetails.VILLAGE));
                com.Parameters.AddWithValue("@SRVCED_EMAILID", ObjApplicationDetails.EMAILID);
                com.Parameters.AddWithValue("@SRVCED_MOBILENO", Convert.ToInt64(ObjApplicationDetails.MOBILENO));
                com.Parameters.AddWithValue("@SRVCED_PINCODE", Convert.ToInt32(ObjApplicationDetails.PINCODE));
                com.Parameters.AddWithValue("@SRVCED_TOTALEXTENTLAND", Convert.ToDecimal(ObjApplicationDetails.TOTALEXTENT));
                com.Parameters.AddWithValue("@SRVCED_BUILTUPAREA", Convert.ToDecimal(ObjApplicationDetails.BUILDUPAREA));

                com.Parameters.AddWithValue("@SRVCED_NAME", ObjApplicationDetails.NamePromoter);
                com.Parameters.AddWithValue("@SRVCED_SONOF", ObjApplicationDetails.SONOF);
                com.Parameters.AddWithValue("@SRVCED_EMAIL", ObjApplicationDetails.Email);
                com.Parameters.AddWithValue("@SRVCED_MOBILENUMBER", Convert.ToInt64(ObjApplicationDetails.MobileNumber));
                com.Parameters.AddWithValue("@SRVCED_ALTERNUMBER", Convert.ToInt64(ObjApplicationDetails.ALTERNATIVAENO));
                com.Parameters.AddWithValue("@SRVCED_LANDLINENUMBER", Convert.ToInt64(ObjApplicationDetails.LANDLINENO));
                com.Parameters.AddWithValue("@SRVCED_DOOR", ObjApplicationDetails.DoorNo);
                com.Parameters.AddWithValue("@SRVCED_LOCALITYADD", ObjApplicationDetails.Local);
                com.Parameters.AddWithValue("@SRVCED_STATE", ObjApplicationDetails.State);
                com.Parameters.AddWithValue("@SRVCED_DISTRICS", Convert.ToInt32(ObjApplicationDetails.Districts));
                com.Parameters.AddWithValue("@SRVCED_MANDALS ", Convert.ToInt32(ObjApplicationDetails.Mandals));
                com.Parameters.AddWithValue("@SRVCED_VILLAGES", Convert.ToInt32(ObjApplicationDetails.Villages));
                com.Parameters.AddWithValue("@SRVCED_DIST ", ObjApplicationDetails.AppDistrict);
                com.Parameters.AddWithValue("@SRVCED_MANDA", ObjApplicationDetails.AppMandal);
                com.Parameters.AddWithValue("@SRVCED_VILLA", ObjApplicationDetails.AppVillge);
                com.Parameters.AddWithValue("@SRVCED_PIN", Convert.ToInt32(ObjApplicationDetails.Pin));
                com.Parameters.AddWithValue("@SRVCED_AGE", Convert.ToInt32(ObjApplicationDetails.Age));
                com.Parameters.AddWithValue("@SRVCED_DESIGNATION", ObjApplicationDetails.Designation);
                com.Parameters.AddWithValue("@SRVCED_WOMENENTREPRENEUR", ObjApplicationDetails.WOMEN);
                com.Parameters.AddWithValue("@SRVCED_ABLED", ObjApplicationDetails.ABLED);
                com.Parameters.AddWithValue("@SRVCED_DIRECTMALE", Convert.ToInt32(ObjApplicationDetails.DIRECTFEMALE));
                com.Parameters.AddWithValue("@SRVCED_DIRECTFEMALE", Convert.ToInt32(ObjApplicationDetails.DIRECTFEMALE));
                com.Parameters.AddWithValue("@SRVCED_DIRECTEMP", ObjApplicationDetails.DIRECTEMP);
                com.Parameters.AddWithValue("@SRVCED_INDIRECTMALE", Convert.ToInt32(ObjApplicationDetails.INDIRECTFEMALE));
                com.Parameters.AddWithValue("@SRVCED_INDIRECTFEMALE", Convert.ToInt32(ObjApplicationDetails.INDIRECTFEMALE));
                com.Parameters.AddWithValue("@SRVCED_INDIRECTEMP", ObjApplicationDetails.INDIRECTEMP);
                com.Parameters.AddWithValue("@SRVCED_TOTALEMP", Convert.ToInt32(ObjApplicationDetails.TOTALEMP));

                com.Parameters.AddWithValue("@SRVCED_LANDSALEDEED", Convert.ToDecimal(ObjApplicationDetails.LandSaleDeed));
                com.Parameters.AddWithValue("@SRVCED_BUILDING", Convert.ToDecimal(ObjApplicationDetails.Building));
                com.Parameters.AddWithValue("@SRVCED_PLANTMACHINERY", Convert.ToDecimal(ObjApplicationDetails.PlantMachinary));
                com.Parameters.AddWithValue("@SRVCED_PROJECTCOST", Convert.ToDecimal(ObjApplicationDetails.TotalProjectCost));
                com.Parameters.AddWithValue("@SRVCED_ANNUALTURNOVER", Convert.ToDecimal(ObjApplicationDetails.AnnualTurnOver));
                com.Parameters.AddWithValue("@SRVCED_ENTERPRISECATEG", ObjApplicationDetails.EnterpriseCategory);


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
        public DataSet BMWEquipment()
        {
            DataSet dt = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetBMWEquipment, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetBMWEquipment;

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
        public string SRVCBMWDetails(SvrcBMWDet ObjBMWDetails)
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
                com.CommandText = SvrcConstants.InsertBMWDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@BMW_CREATEDBY", Convert.ToInt32(ObjBMWDetails.Createdby));
                com.Parameters.AddWithValue("@BMW_CREATEDBYIP", ObjBMWDetails.IPAddress);

                com.Parameters.AddWithValue("@BMW_UNITID", Convert.ToInt32(ObjBMWDetails.UnitId));
                com.Parameters.AddWithValue("@BMW_ServicesQDID", Convert.ToInt32(ObjBMWDetails.Questionnariid));
                com.Parameters.AddWithValue("@BMW_NAME", ObjBMWDetails.Name_applicant);
                com.Parameters.AddWithValue("@BMW_NAMEHCF_CBWTF", ObjBMWDetails.HCFCBWTF);

                com.Parameters.AddWithValue("@BMW_EMAILID", ObjBMWDetails.email);
                com.Parameters.AddWithValue("@BMW_MOBILENO", Convert.ToInt64(ObjBMWDetails.mobile));
                com.Parameters.AddWithValue("@BMW_WEBSITE", ObjBMWDetails.website);
                com.Parameters.AddWithValue("@BMW_AUTHORIZATION", ObjBMWDetails.Authorizationactivity);
                com.Parameters.AddWithValue("@BMW_APPLIEDCTO_CTE", ObjBMWDetails.AppliedCTO_CTE);


                com.Parameters.AddWithValue("@BMW_RENAUTHORIZATIONNO", ObjBMWDetails.authorisationnumber);
                // com.Parameters.AddWithValue("", Convert.ToDecimal(ObjBMWDetails.authorisation_Date));//
                com.Parameters.AddWithValue("@BMW_RENAUTHORIZATIONDATE", DateTime.ParseExact(ObjBMWDetails.authorisation_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));                
                com.Parameters.AddWithValue("@BMW_PCB1974", ObjBMWDetails.Pollution1974);
                com.Parameters.AddWithValue("@BMW_PCB1981", ObjBMWDetails.ControlPollution1981);
                com.Parameters.AddWithValue("@BMW_BIOHCF_CBWTF ", ObjBMWDetails.AddressHealthHCFCBWFT);
                com.Parameters.AddWithValue("@BMW_GPSCOORDINATE", ObjBMWDetails.GPSCOORDINATES);
                com.Parameters.AddWithValue("@BMW_NOBEDHCF", ObjBMWDetails.NumberBED);
                com.Parameters.AddWithValue("@BMW_NOPATIENTSMONTHHCF", ObjBMWDetails.patientsHCF);
                com.Parameters.AddWithValue("@BMW_NOHELTHCBMWTF", ObjBMWDetails.healthcareCBMWTF);
                com.Parameters.AddWithValue("@BMW_NOBEDCBMWTF", ObjBMWDetails.NOBEDCBMWTF);
                com.Parameters.AddWithValue("@BMW_CAPACITYCBMWTF", ObjBMWDetails.DISPOSALCBMWTF);
                com.Parameters.AddWithValue("@BMW_AREADISTANCECBMWTF", ObjBMWDetails.DISTANCECBMWTF);
                com.Parameters.AddWithValue("@BMW_BIOMEDICALDISPOSED", ObjBMWDetails.BMWTREATED);
                com.Parameters.AddWithValue("@BMW_MODETRANSPORTATION", ObjBMWDetails.MODETRANSACTION);



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
        public string SRVCBMWWASTEDET(SvrcBMWDet ObjBMWDetails)
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
                com.CommandText = SvrcConstants.InsertWasteDetails;

                com.Transaction = transaction;
                com.Connection = connection;



                com.Parameters.AddWithValue("@BMW_CREATEDBY", Convert.ToInt32(ObjBMWDetails.Createdby));
                com.Parameters.AddWithValue("@BMW_CREATEDBYIP", ObjBMWDetails.IPAddress);
                com.Parameters.AddWithValue("@BMW_UNITID", Convert.ToInt32(ObjBMWDetails.UnitId));
                com.Parameters.AddWithValue("@BMW_SERVICEQDID", Convert.ToInt32(ObjBMWDetails.Questionnariid));
                com.Parameters.AddWithValue("@BMW_CATEGORY", ObjBMWDetails.Category);
                com.Parameters.AddWithValue("@BMW_TYPEWASTE", ObjBMWDetails.Waste);
                com.Parameters.AddWithValue("@BMW_QUANTITYGENERATED", ObjBMWDetails.QuantityGenerated);
                com.Parameters.AddWithValue("@BMW_TREATMENTDISPOSAL", ObjBMWDetails.MethodDisposal);


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
        public string InsertBMWWASTEDET(DataTable dtBMWDetails, string Unitid, string Questionnaire, string Createdby, string IPAddress)
        {
            string result = "";
            SqlConnection connection = new SqlConnection(connstr);

            try
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                foreach (DataRow dr in dtBMWDetails.Rows)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand(SvrcConstants.InsertBMWBIOMEDICALDET, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = transaction;

                        cmd.Parameters.AddWithValue("@BMW_UNITID", Unitid);
                        cmd.Parameters.AddWithValue("@BMW_CREATEDBY", Createdby);
                        cmd.Parameters.AddWithValue("@BMW_CREATEDBYIP", IPAddress);
                        cmd.Parameters.AddWithValue("@BMW_SERVICEQDID", Questionnaire);
                        cmd.Parameters.AddWithValue("@BMW_ID", dr["BMW_ID"]);
                        cmd.Parameters.AddWithValue("@BMW_EQUIPMENT", dr["BMW_EQUIPMENT"]);
                        cmd.Parameters.AddWithValue("@BMW_NO_UNIT", dr["BMW_NO_UNIT"]);
                        cmd.Parameters.AddWithValue("@BMW_CAPACITY_UNIT", dr["BMW_CAPACITY_UNIT"]);
                        cmd.Parameters.Add("@RESULT", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        string outputResult = cmd.Parameters["@RESULT"].Value.ToString();

                        if (rowsAffected > 0)
                        {
                            result = "Success";
                        }
                        else
                        {
                            result = "Failed";
                            transaction.Rollback();
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                result = $"Error: {ex.Message}";
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();
            }

            return result;
        }
        public string InsertSRVCAttachments(SRVCAttachments objAttachments)
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
                com.CommandText = SvrcConstants.InsertSVRCAttachments;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@SRVCA_UNITID", Convert.ToInt32(objAttachments.UNITID));
                com.Parameters.AddWithValue("@SRVCA_SRVCQDID", Convert.ToInt32(objAttachments.Questionnareid));
                com.Parameters.AddWithValue("@SRVCA_QUERYID", objAttachments.QueryID);
                com.Parameters.AddWithValue("@SRVCA_MASTERID", objAttachments.MasterID);
                com.Parameters.AddWithValue("@SRVCA_FILEPATH", objAttachments.FilePath);
                com.Parameters.AddWithValue("@SRVCA_FILENAME", objAttachments.FileName);
                com.Parameters.AddWithValue("@SRVCA_FILETYPE", objAttachments.FileType);
                com.Parameters.AddWithValue("@SRVCA_FILEDESCRIPTION", objAttachments.FileDescription);
                com.Parameters.AddWithValue("@SRVCA_DEPTID", objAttachments.DeptID);
                com.Parameters.AddWithValue("@SRVCA_APPROVALID", objAttachments.ApprovalID);
                com.Parameters.AddWithValue("@SRVCA_CREATEDBY", Convert.ToInt32(objAttachments.CreatedBy));
                com.Parameters.AddWithValue("@SRVCA_CREATEDBYIP", objAttachments.IPAddress);
                if (objAttachments.ReferenceNo != null && objAttachments.ReferenceNo != "")
                {
                    com.Parameters.AddWithValue("@SRVCA_FILLREFNO", objAttachments.ReferenceNo);
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
        public DataSet GetSRVCapplications(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCapplications, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCapplications;

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
        public DataSet GetSRVCApprovals(string userid, string UnitId)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCApprovals, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCApprovals;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(userid));
                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(UnitId));
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
        public string InsertSRVCDeptApprovals(SRVCOtherServices ObjApplicationDetails)
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
                com.CommandText = SvrcConstants.InsertSRVCDeptApprovals;

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@SRVCAPPROVALSXML", ObjApplicationDetails.SRVCApprovalsXml);
                com.Parameters.AddWithValue("@APPROVALS", ObjApplicationDetails.ApprovalID);
                com.Parameters.AddWithValue("@UNITID", ObjApplicationDetails.UnitId);
                com.Parameters.AddWithValue("@SRVCQDID", ObjApplicationDetails.Questionnariid);
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
        public DataSet GetSrvcBMWDet(string userid, String UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSrvcBMWDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSrvcBMWDetails;

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

        /* public string SRVCSWDDetails(SWMdetails objDetails)
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
                 com.CommandText = SvrcConstants.InsertSRVCSWDdetails;

                 com.Transaction = transaction;
                 com.Connection = connection;
                 com.Parameters.AddWithValue("@SRVCSWD_UNITID", objDetails.unitid);
                 com.Parameters.AddWithValue("@SRVCSWD_NAMELOCALOPERATOR", objDetails.namelocaloperator);
                 com.Parameters.AddWithValue("@SRVCSWD_NODALAUTHORISEDAGENCY", objDetails.nodalauthorisedagency);
                 com.Parameters.AddWithValue("@SRVCSWD_AUTHORIZATIONOPEARTION", objDetails.authorizationopeartion);
                 com.Parameters.AddWithValue("@SRVCSWD_TOTALQUANTITYWASTE", objDetails.totalquantitywaste);
                 com.Parameters.AddWithValue("@SRVCSWD_QUANTITYWASTERECYCLE", objDetails.quantitywasterecycle);
                 com.Parameters.AddWithValue("@SRVCSWD_QUANTITYWASTETREATED", objDetails.quantitywastetreated);
                 com.Parameters.AddWithValue("@SRVCSWD_QUANTITYWASTEDISPOSED", objDetails.quantitywastedisposed);
                 com.Parameters.AddWithValue("@SRVCSWD_QUANTITYLEACHATE", objDetails.quantityleachate);
                 com.Parameters.AddWithValue("@SRVCSWD_TREATMENTTECHLEACHATE", objDetails.treatmenttechleachate);
                 com.Parameters.AddWithValue("@SRVCSWD_MEASURESCEP", objDetails.measurescep);
                 com.Parameters.AddWithValue("@SRVCSWD_MEASURESSAFTEYPLANT", objDetails.measuressafteyplant);
                 com.Parameters.AddWithValue("@SRVCSWD_NOSITES", objDetails.nosites);
                 com.Parameters.AddWithValue("@SRVCSWD_QUANTITYWASTEPERDAY", objDetails.quantitywasteperday);
                 com.Parameters.AddWithValue("@SRVCSWD_DETAILSEXISTINGSITE", objDetails.detailsexistingsite);
                 com.Parameters.AddWithValue("@SRVCSWD_METHODOLOGYDETAILS", objDetails.methodologydetails);
                 com.Parameters.AddWithValue("@SRVCSWD_CHECKENVIRONMENTPOLLUTION", objDetails.checkenvironmentpollution);
                 com.Parameters.AddWithValue("@SRVCSWD_CREATEDBY", objDetails.createdby);
                 com.Parameters.AddWithValue("@SRVCSWD_CREATEDBYIP", objDetails.createdbyip);

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
        */
        public string INSSRVCSOLIDDDetails(SWMdetails ObjSWMDet)
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
                com.CommandText = SvrcConstants.InsertSRVCSWDdetails;

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@SRVCSWD_UNITID", Convert.ToInt32(ObjSWMDet.unitid));
                com.Parameters.AddWithValue("@SRVCSWD_CREATEDBY", Convert.ToInt32(ObjSWMDet.createdby));
                com.Parameters.AddWithValue("@SRVCSWD_SRVCQDID", Convert.ToInt32(ObjSWMDet.Questionnariid));
                com.Parameters.AddWithValue("@SRVCSWD_CREATEDBYIP", ObjSWMDet.createdbyip);
                com.Parameters.AddWithValue("@SRVCSWD_AUTHORIZATIONOPEARTION", ObjSWMDet.authorizationopeartion);
                com.Parameters.AddWithValue("@SRVCSWD_NAMELOCALOPERATOR", ObjSWMDet.namelocaloperator);
                com.Parameters.AddWithValue("@SRVCSWD_NODALAUTHORISEDAGENCY", ObjSWMDet.nodalauthorisedagency);
                com.Parameters.AddWithValue("@SRVCSWD_TOTALQUANTITYWASTE", Convert.ToInt32(ObjSWMDet.totalquantitywaste));
                com.Parameters.AddWithValue("@SRVCSWD_QUANTITYWASTERECYCLE", Convert.ToInt32(ObjSWMDet.quantitywasterecycle));
                com.Parameters.AddWithValue("@SRVCSWD_QUANTITYWASTETREATED", Convert.ToInt32(ObjSWMDet.quantitywastetreated));
                com.Parameters.AddWithValue("@SRVCSWD_QUANTITYWASTEDISPOSED", Convert.ToInt32(ObjSWMDet.quantitywastedisposed));
                com.Parameters.AddWithValue("@SRVCSWD_QUANTITYLEACHATE", Convert.ToInt32(ObjSWMDet.quantityleachate));
                com.Parameters.AddWithValue("@SRVCSWD_TREATMENTTECHLEACHATE", ObjSWMDet.treatmenttechleachate);
                com.Parameters.AddWithValue("@SRVCSWD_MEASURESCEP", ObjSWMDet.measurescep);
                com.Parameters.AddWithValue("@SRVCSWD_MEASURESSAFTEYPLANT", ObjSWMDet.measuressafteyplant);
                com.Parameters.AddWithValue("@SRVCSWD_NOSITES", Convert.ToInt32(ObjSWMDet.nosites));
                com.Parameters.AddWithValue("@SRVCSWD_QUANTITYWASTEPERDAY", Convert.ToInt32(ObjSWMDet.quantitywasteperday));
                com.Parameters.AddWithValue("@SRVCSWD_DETAILSEXISTINGSITE", ObjSWMDet.detailsexistingsite);
                com.Parameters.AddWithValue("@SRVCSWD_METHODOLOGYDETAILS", ObjSWMDet.methodologydetails);
                com.Parameters.AddWithValue("@SRVCSWD_CHECKENVIRONMENTPOLLUTION", ObjSWMDet.checkenvironmentpollution);

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
        public DataSet GetSrvcSWMDetails(string userid, String UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSrvcSWMDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSrvcSWMDetails;

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
        public DataSet GetsrvcapprovalID(string userid, string UNITID, string QusestionnaireID, string DeptID, string ApprovalID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSrvcAppliedApprovalIDs, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSrvcAppliedApprovalIDs;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", UNITID);
                da.SelectCommand.Parameters.AddWithValue("@USERID", userid);
                da.SelectCommand.Parameters.AddWithValue("@SRVCQID", QusestionnaireID);
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
        public DataSet GetApplicationStatus(string userid, string UnitID, string Status)
        {

            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCApplUserDashboard, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCApplUserDashboard;

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
        public DataSet GetSRVCApplicationDetails(string UnitID, string InvesterID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCApplicationDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCApplicationDet;

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
        public string SRVCPSCLDetails(PDCLD Power)
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
                com.CommandText = SvrcConstants.InsertPDCLDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@SRVCPDC_CREATEDBY", Convert.ToInt32(Power.Createdby));
                com.Parameters.AddWithValue("@SRVCPDC_CREATEDBYIP", Power.IPAddress);
                com.Parameters.AddWithValue("@SRVCPDC_UNITID", Convert.ToInt32(Power.UnitId));
                com.Parameters.AddWithValue("@SRVCPDC_SERVICESQDID", Convert.ToInt32(Power.Questionnariid));
                com.Parameters.AddWithValue("@SRVCPDC_STATUSRELATION", Power.StatusRelation);
                com.Parameters.AddWithValue("@SRVCPDC_POLICESATION", Power.PoliceStation);
                com.Parameters.AddWithValue("@SRVCPDC_LTSUPPLY", Power.LTSupply);


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
        public DataSet GetSrvcPDCLDetails(string userid, String UNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSrvcPDCLDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSrvcPDCLDetails;

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
        public DataTable GetSrvcDashBoard(CFEDtls objSrvc)
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
                da = new SqlDataAdapter(SvrcConstants.GetSRVCDashBoard, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCDashBoard;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;


                da.SelectCommand.Parameters.AddWithValue("@USERID", objSrvc.UserID);
                da.SelectCommand.Parameters.AddWithValue("@ROLEID", objSrvc.Role);
                if (objSrvc.deptid != null && objSrvc.deptid != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@DEPTID", objSrvc.deptid);
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
        public DataTable GetSRVCDashBoardView(SVRCDtls SRVCDET)
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
                da = new SqlDataAdapter(SvrcConstants.GetSRVCDashBoardVIEW, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCDashBoardVIEW;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;


                da.SelectCommand.Parameters.AddWithValue("@USERID", SRVCDET.UserID);
                da.SelectCommand.Parameters.AddWithValue("@ROLEID", SRVCDET.Role);
                if (SRVCDET.deptid != null && SRVCDET.deptid != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@DEPTID", SRVCDET.deptid);
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
    }
}
