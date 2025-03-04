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
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

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
                if(ObjApplicationDetails.RegDate !=null && ObjApplicationDetails.RegDate != "")
                {
                    com.Parameters.AddWithValue("@SRVCED_REGDATE", ObjApplicationDetails.RegDate);
                }
                
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
                com.Parameters.AddWithValue("@SRVCED_UIDNO", ObjApplicationDetails.UidNo);



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
                if(ObjBMWDetails.Pollution1974 !=null && ObjBMWDetails.Pollution1974 != "")
                {
                    com.Parameters.AddWithValue("@BMW_PCB1974", ObjBMWDetails.Pollution1974);
                }
                if(ObjBMWDetails.ControlPollution1981 != null && ObjBMWDetails.ControlPollution1981 != "")
                {
                    com.Parameters.AddWithValue("@BMW_PCB1981", ObjBMWDetails.ControlPollution1981);
                }
               
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

        public string InsertPaymentDetails(SRVCPayments objpay)
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
                com.CommandText = SvrcConstants.InsertPaymentDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@SRVCPD_UNITID", Convert.ToInt32(objpay.UNITID));
                com.Parameters.AddWithValue("@SRVCPD_SRVCQDID", Convert.ToInt32(objpay.Questionnareid));
                com.Parameters.AddWithValue("@SRVCPD_UIDNO", objpay.SRVCUID);
                com.Parameters.AddWithValue("@SRVCPD_DEPTID", objpay.DeptID);
                com.Parameters.AddWithValue("@SRVCPD_APPROVALID", Convert.ToInt32(objpay.ApprovalID));
                com.Parameters.AddWithValue("@SRVCPD_ONLINEORDERNO", objpay.OnlineOrderNo);
                com.Parameters.AddWithValue("@SRVCPD_ONLINEAMOUNT", objpay.OnlineOrderAmount);
                com.Parameters.AddWithValue("@SRVCPD_PAYMENTFLAG", objpay.PaymentFlag);
                com.Parameters.AddWithValue("@SRVCPD_TRANSACTIONNO", objpay.TransactionNo);
                com.Parameters.AddWithValue("@SRVCPD_BANKNAME", objpay.BankName);
                com.Parameters.AddWithValue("@SRVCPD_TRANSACTIONDATE", objpay.TransactionDate);
                com.Parameters.AddWithValue("@SRVCPD_CREATEDBY", Convert.ToInt32(objpay.CreatedBy));
                com.Parameters.AddWithValue("@SRVCPD_CREATEDBYIP", objpay.IPAddress);


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

        public DataSet GetPaymentAmounttoPay(string userid, object uNITID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCApprovalsAmounttoPay, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCApprovalsAmounttoPay;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(uNITID));
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
                da.SelectCommand.Parameters.AddWithValue("@VIEWSTATUS", SRVCDET.ViewStatus);

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
        public DataTable GetSrvcDashBoard(CFEDtls objSrvc)
        {
            DataTable dt = new DataTable();
            string valid = "";

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
                //  da.SelectCommand.Parameters.AddWithValue("@VIEWSTATUS", objSrvc.ViewStatus);

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

        public string InsertEWasteDetails(ServiceEWasteDetails serviceEWasteDetails)
        {
            string result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = SvrcConstants.InsertEWasteDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@EWD_SRVCQDID", Convert.ToInt32(serviceEWasteDetails.SrvcQdId));
                com.Parameters.AddWithValue("@EWD_CREATEDBY", serviceEWasteDetails.CreatedBy);
                com.Parameters.AddWithValue("@EWD_UNITID", Convert.ToInt32(serviceEWasteDetails.UnitId));
                // com.Parameters.AddWithValue("@EWD_UIDNO", serviceEWasteDetails.UidNo);
                com.Parameters.AddWithValue("@EWD_CREATEDBYIP", serviceEWasteDetails.CreatedByIp);
                com.Parameters.AddWithValue("@EWD_NAME", serviceEWasteDetails.Name);
                if (serviceEWasteDetails.DoorNo != "" && serviceEWasteDetails.DoorNo != null)
                {
                    com.Parameters.AddWithValue("@EWD_DOORNO", serviceEWasteDetails.DoorNo);
                }
                if (serviceEWasteDetails.Locality != "" && serviceEWasteDetails.Locality != null)
                {
                    com.Parameters.AddWithValue("@EWD_LOCALITY", serviceEWasteDetails.Locality);
                }
                if (serviceEWasteDetails.StateId != "" && serviceEWasteDetails.StateId != null)
                {
                    com.Parameters.AddWithValue("@EWD_STATEID", Convert.ToInt32(serviceEWasteDetails.StateId));
                }
                if (serviceEWasteDetails.DistrictId != "" && serviceEWasteDetails.DistrictId != null)
                {
                    com.Parameters.AddWithValue("@EWD_DISTRICTID", Convert.ToInt32(serviceEWasteDetails.DistrictId));
                }
                if (serviceEWasteDetails.MandalId != "" && serviceEWasteDetails.MandalId != null)
                {
                    com.Parameters.AddWithValue("@EWD_MANDALID", Convert.ToInt32(serviceEWasteDetails.MandalId));
                }
                if (serviceEWasteDetails.VillageId != "" && serviceEWasteDetails.VillageId != null)
                {
                    com.Parameters.AddWithValue("@EWD_VILLAGEID", Convert.ToInt32(serviceEWasteDetails.VillageId));
                }
                if (serviceEWasteDetails.District != "" && serviceEWasteDetails.District != null)
                {
                    com.Parameters.AddWithValue("@EWD_DISTRICT", serviceEWasteDetails.District);
                }
                if (serviceEWasteDetails.Mandal != "" && serviceEWasteDetails.Mandal != null)
                {
                    com.Parameters.AddWithValue("@EWD_MANDAL", serviceEWasteDetails.Mandal);
                }
                if (serviceEWasteDetails.Village != "" && serviceEWasteDetails.Village != null)
                {
                    com.Parameters.AddWithValue("@EWD_VILLAGE", serviceEWasteDetails.Village);
                }
                if (serviceEWasteDetails.Pincode != "" && serviceEWasteDetails.Pincode != null)
                {
                    com.Parameters.AddWithValue("@EWD_PINCODE", serviceEWasteDetails.Pincode);
                }
                if (serviceEWasteDetails.Landmark != "" && serviceEWasteDetails.Landmark != null)
                {
                    com.Parameters.AddWithValue("@EWD_LANDMARK", serviceEWasteDetails.Landmark);
                }
                if (serviceEWasteDetails.Designation != "" && serviceEWasteDetails.Designation != null)
                {
                    com.Parameters.AddWithValue("@EWD_DESIGNATION", serviceEWasteDetails.Designation);
                }
                if (serviceEWasteDetails.EmailId != "" && serviceEWasteDetails.EmailId != null)
                {
                    com.Parameters.AddWithValue("@EWD_EMAILID", serviceEWasteDetails.EmailId);
                }
                if (serviceEWasteDetails.Mobile != "" && serviceEWasteDetails.Mobile != null)
                {
                    com.Parameters.AddWithValue("@EWD_MOBILE", serviceEWasteDetails.Mobile);
                }
                if (serviceEWasteDetails.AltMobile != "" && serviceEWasteDetails.AltMobile != null)
                {
                    com.Parameters.AddWithValue("@EWD_ALTMOBILE", serviceEWasteDetails.AltMobile);
                }
                if (serviceEWasteDetails.Landline != "" && serviceEWasteDetails.Landline != null)
                {
                    com.Parameters.AddWithValue("@EWD_LANDLINE", serviceEWasteDetails.Landline);
                }

                com.Parameters.AddWithValue("@EWD_AUTHORIZATION", serviceEWasteDetails.Authorization);
                com.Parameters.AddWithValue("@EWD_EWASTEGENQUANTITY", serviceEWasteDetails.EWasteGenQuantity);
                com.Parameters.AddWithValue("@EWD_EWASTEREFURBISHED", serviceEWasteDetails.EWasteRefurbished);
                com.Parameters.AddWithValue("@EWD_EWASTERECYCLE", serviceEWasteDetails.EWasteRecycle);
                com.Parameters.AddWithValue("@EWD_EWASTEDISPOSAL", serviceEWasteDetails.EWasteDisposal);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return result;
        }


        public DataSet GetEWasteDetails(string srvcQdId, string Createdby)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetEWasteDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetEWasteDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(srvcQdId));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(Createdby));
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

        //public DataSet GetProdPlasticWasteDetails(string srvcQdId, string unitId)
        //{
        //    DataSet ds = new DataSet();
        //    SqlConnection connection = new SqlConnection(connstr);
        //    SqlTransaction transaction = null;
        //    connection.Open();
        //    transaction = connection.BeginTransaction();
        //    try
        //    {
        //        SqlDataAdapter da;
        //        da = new SqlDataAdapter(SvrcConstants.GetProdPlasticWasteDetails, connection);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.CommandText = SvrcConstants.GetProdPlasticWasteDetails;

        //        da.SelectCommand.Transaction = transaction;
        //        da.SelectCommand.Connection = connection;

        //        da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(srvcQdId));
        //        da.SelectCommand.Parameters.AddWithValue("@UNITID", Convert.ToInt32(unitId));
        //        da.Fill(ds);
        //        transaction.Commit();
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        transaction.Rollback();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //        connection.Dispose();
        //    }
        //}

        public string InsertProdPlasticsWasteDetails(ServiceProdPlasticsWasteDetails serviceProdPlasticsWasteDetails)
        {
            string result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = SvrcConstants.InsertProdPlasticsWasteDetails, // Ensure this stored procedure exists in DB
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("@SRVCPWD_SRVCQDID", Convert.ToInt32(serviceProdPlasticsWasteDetails.SrvcQdId));
                com.Parameters.AddWithValue("@SRVCPWD_UNITID", Convert.ToInt32(serviceProdPlasticsWasteDetails.UnitId));
                com.Parameters.AddWithValue("@SRVCPWD_NAMEOFPROD", serviceProdPlasticsWasteDetails.NameOfProduct);
                com.Parameters.AddWithValue("@SRVCPWD_NAMEOFUNIT", serviceProdPlasticsWasteDetails.NameOfUnit);
                com.Parameters.AddWithValue("@SRVCPWD_CREATEDBY", serviceProdPlasticsWasteDetails.CreatedBy);
                com.Parameters.AddWithValue("@SRVCPWD_CREATEDBYIP", serviceProdPlasticsWasteDetails.CreatedByIp);
                com.Parameters.AddWithValue("@SRVCPWD_CARRYBAG", serviceProdPlasticsWasteDetails.CarryBag);
                com.Parameters.AddWithValue("@SRVCPWD_MULTILAYEREDPLASTIC", serviceProdPlasticsWasteDetails.MultilayeredPlastic);
                com.Parameters.AddWithValue("@SRVCPWD_MANFCTRNGCAPACITY", serviceProdPlasticsWasteDetails.ManufacturingCapacity);
                com.Parameters.AddWithValue("@SRVCPWD_PREVREGNO", serviceProdPlasticsWasteDetails.PreviousRegistration);
                com.Parameters.AddWithValue("@SRVCPWD_REGDATE", DateTime.ParseExact(serviceProdPlasticsWasteDetails.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@SRVCPWD_TOTCAPTLINV", serviceProdPlasticsWasteDetails.TotalCapitalInvestment);
                com.Parameters.AddWithValue("@SRVCPWD_YEAROFCMNCEMNT", serviceProdPlasticsWasteDetails.YearOfCommencement);
                com.Parameters.AddWithValue("@SRVCPWD_LISTQNTMPROD", serviceProdPlasticsWasteDetails.ListQuantityProduct);
                com.Parameters.AddWithValue("@SRVCPWD_LISTQNTMRAWMAT", serviceProdPlasticsWasteDetails.ListQuantityRawMaterial);
                com.Parameters.AddWithValue("@SRVCPWD_TOTALQNTMWASTEGENERATED", serviceProdPlasticsWasteDetails.TotalQuantityWasteGenerated);
                com.Parameters.AddWithValue("@SRVCPWD_MODEOFSTORAGEWITHINPLANT", serviceProdPlasticsWasteDetails.ModeOfStorageWithinPlant);
                com.Parameters.AddWithValue("@SRVCPWD_DISPOSALPROVISION", serviceProdPlasticsWasteDetails.DisposalProvision);
                com.Parameters.AddWithValue("@SRVCPWD_COMPLIANCE", serviceProdPlasticsWasteDetails.Compliance);



                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return result;
        }

        public string InsertBOPlasticsWasteDetails(ServiceBOPlasticsWasteDetails serviceBOPlasticsWasteDetails)
        {
            string result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = SvrcConstants.InsertBOPlasticsWasteDetails,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("@BOPWD_SRVCQDID", Convert.ToInt32(serviceBOPlasticsWasteDetails.SrvcQdId));
                com.Parameters.AddWithValue("@BOPWD_UNITID", Convert.ToInt32(serviceBOPlasticsWasteDetails.UnitId));
                com.Parameters.AddWithValue("@BOPWD_NAMEOFBRANDOWNER", serviceBOPlasticsWasteDetails.NameOfBrandOwner);
                com.Parameters.AddWithValue("@BOPWD_CREATEDBY", serviceBOPlasticsWasteDetails.CreatedBy);
                com.Parameters.AddWithValue("@BOPWD_CREATEDBYIP", serviceBOPlasticsWasteDetails.CreatedByIp);
                com.Parameters.AddWithValue("@BOPWD_PREVREGNO", serviceBOPlasticsWasteDetails.PreviousRegistrationNumber);
                com.Parameters.AddWithValue("@BOPWD_REGDATE", DateTime.ParseExact(serviceBOPlasticsWasteDetails.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@BOPWD_TOTALCAPINV", serviceBOPlasticsWasteDetails.TotalCapitalInvestment);
                com.Parameters.AddWithValue("@BOPWD_INVYEAROFCOMNCMNT", serviceBOPlasticsWasteDetails.YearOfCommencement);
                com.Parameters.AddWithValue("@BOPWD_BYPRODPRODLIST", serviceBOPlasticsWasteDetails.ByProdProductList);
                com.Parameters.AddWithValue("@BOPWD_BYPRODRAWMATLIST", serviceBOPlasticsWasteDetails.ByProdRawMaterialList);
                com.Parameters.AddWithValue("@BOPWD_SWTOTALQNTMWASTEGEN", serviceBOPlasticsWasteDetails.TotalQuantityWasteGenerated);
                com.Parameters.AddWithValue("@BOPWD_SWMODEOFSTORAGE", serviceBOPlasticsWasteDetails.ModeOfStorageWithinPlant);
                com.Parameters.AddWithValue("@BOPWD_SWDISPOSALPROV", serviceBOPlasticsWasteDetails.DisposalProvision);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return result;
        }

        public DataSet GetSRVCHAZARDOUSDETAILS(string srvcQdId, string createdby)
        {

            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                SqlTransaction transaction = null;
                connection.Open();
                transaction = connection.BeginTransaction();
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(SvrcConstants.GetHzrdsDetails, connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.CommandText = SvrcConstants.GetHzrdsDetails;
                    da.SelectCommand.Transaction = transaction;
                    da.SelectCommand.Connection = connection;

                    da.SelectCommand.Parameters.AddWithValue("@SRVCHZD_SRVCQDID", Convert.ToInt32(srvcQdId));
                    da.SelectCommand.Parameters.AddWithValue("@SRVCHZD_CREATEDBY", Convert.ToInt32(createdby));

                    da.Fill(ds);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return ds;
        }

        public string InsertSrvHazardous(SRVCHAZZARDOUSDETAILS ObjHazardous)
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
                com.CommandText = SvrcConstants.InsertHzrdsDetails; ; // Stored Procedure Name

                com.Transaction = transaction;
                com.Connection = connection;

                // Add parameters
                com.Parameters.AddWithValue("@SRVCHZD_SRVCQDID", Convert.ToInt32(ObjHazardous.SRVCQDID));
                com.Parameters.AddWithValue("@SRVCHZD_UNITID", Convert.ToInt32(ObjHazardous.UNITID));
                com.Parameters.AddWithValue("@SRVCHZD_UIDNO", ObjHazardous.UIDNO);
                com.Parameters.AddWithValue("@SRVCHZD_FIRMNAME", ObjHazardous.FIRMNAME);
                com.Parameters.AddWithValue("@SRVCHZD_FIRMLOCATION", ObjHazardous.FIRMLOCATION);
                com.Parameters.AddWithValue("@SRVCHZD_OCCUPIERNAME", ObjHazardous.OCCUPIERNAME);
                com.Parameters.AddWithValue("@SRVCHZD_EMAILID", ObjHazardous.EMAILID);
                com.Parameters.AddWithValue("@SRVCHZD_MOBILENO", ObjHazardous.MOBILENO);
                com.Parameters.AddWithValue("@SRVCHZD_FAX", ObjHazardous.FAX);
                com.Parameters.AddWithValue("@SRVCHZD_ACTIVITIES", ObjHazardous.ACTIVITIES);
                com.Parameters.AddWithValue("@SRVCHZD_WSTNTRQTYANUM", Convert.ToDecimal(ObjHazardous.WSTNTRQTYANUM));
                com.Parameters.AddWithValue("@SRVCHZD_WSTNTRQTYATM", Convert.ToDecimal(ObjHazardous.WSTNTRQTYATM));
                com.Parameters.AddWithValue("@SRVCHZD_YEARCMSNG", ObjHazardous.YEARCMSNG);
                com.Parameters.AddWithValue("@SRVCHZD_SHIFTS", ObjHazardous.SHIFTS);
                com.Parameters.AddWithValue("@SRVCHZD_CREATEDBY", ObjHazardous.CREATEDBY);
                com.Parameters.AddWithValue("@SRVCHZD_CREATEDIP", ObjHazardous.CREATEDIP);

                // Output parameter to get the inserted/updated record ID
                SqlParameter outputParam = new SqlParameter("@RESULT", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                com.Parameters.Add(outputParam);

                // Execute the query
                com.ExecuteNonQuery();

                // Get the output result
                Result = com.Parameters["@RESULT"].Value.ToString();

                // Commit transaction
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Rollback transaction on error
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                // Close and dispose the connection
                connection.Close();
                connection.Dispose();
            }

            return Result;
        }

        public string InsertCDWMDetails(SRVCCDWMdetails objCDWMDet)
        {
            string result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = SvrcConstants.InsertCDWMDetails,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("@CDWM_CDWMQDID", Convert.ToInt32(objCDWMDet.SRVCQDID));
                com.Parameters.AddWithValue("@CDWM_UNITID", Convert.ToInt32(objCDWMDet.unitid));
                com.Parameters.AddWithValue("@CDWM_CREATEDBY", objCDWMDet.createdby);
                com.Parameters.AddWithValue("@CDWM_AUTHNAME", objCDWMDet.NameLocalAuthority);
                com.Parameters.AddWithValue("@CDWM_NAME_OF_NODAL_OFFICER", objCDWMDet.NameOfNodalOfficer);
                com.Parameters.AddWithValue("@CDWM_DESIGNATION_OF_NODAL_OFFICER", objCDWMDet.DesignationOfNodalOfficer);
                com.Parameters.AddWithValue("@CDWM_AUTHORIZATION", objCDWMDet.AuthorizationRequiredFor);
                com.Parameters.AddWithValue("@CDWM_AVG_QUANT_CDWM", objCDWMDet.AvgQuantityHandledPerDay);
                com.Parameters.AddWithValue("@CDWM_QUAT_CDWM_PROCESSED", objCDWMDet.QuantityWasteProcessedPerDay);
                com.Parameters.AddWithValue("@CDWM_SITE_CLEARANCE", objCDWMDet.SiteClearanceFromAuthority);
                com.Parameters.AddWithValue("@CDWM_CREATEDBYIP", objCDWMDet.createdbyip);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return result;
        }

        public DataSet GetSRVCCDWMDETAILS(string srvcQdId, string createdby)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SvrcConstants.GetSRVCCDWMDETAILS, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCCDWMDETAILS;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(srvcQdId));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(createdby));

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
        public DataSet GetSRVCPaymentAmounttoPay(string userid, string Quid)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCApprovalsAmounttoPay, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCApprovalsAmounttoPay;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@QUID", Convert.ToInt32(Quid));
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
        public string SRVCInsertPaymentDet(SRVCPayments SRVCPayment)
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
                com.CommandText = SvrcConstants.SRVCInsertPaymentDetails;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@SRVCPD_UNITID", Convert.ToInt32(SRVCPayment.UNITID));
                com.Parameters.AddWithValue("@SRVCPD_SRVCQDID", Convert.ToInt32(SRVCPayment.Questionnareid));
                com.Parameters.AddWithValue("@SRVCPD_UIDNO", SRVCPayment.SRVCUID);
                com.Parameters.AddWithValue("@SRVCPD_DEPTID", SRVCPayment.DeptID);
                com.Parameters.AddWithValue("@SRVCPD_APPROVALID", Convert.ToInt32(SRVCPayment.ApprovalID));
                com.Parameters.AddWithValue("@SRVCPD_ONLINEORDERNO", SRVCPayment.OnlineOrderNo);
                com.Parameters.AddWithValue("@SRVCPD_ONLINEAMOUNT", SRVCPayment.OnlineOrderAmount);
                com.Parameters.AddWithValue("@SRVCPD_PAYMENTFLAG", SRVCPayment.PaymentFlag);
                com.Parameters.AddWithValue("@SRVCPD_TRANSACTIONNO", SRVCPayment.TransactionNo);
                com.Parameters.AddWithValue("@SRVCPD_BANKNAME", SRVCPayment.BankName);
                com.Parameters.AddWithValue("@SRVCPD_TRANSACTIONDATE", SRVCPayment.TransactionDate);
                com.Parameters.AddWithValue("@SRVCPD_CRETAEDBY", Convert.ToInt32(SRVCPayment.CreatedBy));
                com.Parameters.AddWithValue("@SRVCPD_CRETAEDBYIP", SRVCPayment.IPAddress);

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
