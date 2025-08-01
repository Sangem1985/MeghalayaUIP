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

                if (ObjApplicationDetails.UnitId != null && ObjApplicationDetails.UnitId != "")
                {
                    com.Parameters.AddWithValue("@SRVCED_UNITID", Convert.ToInt32(ObjApplicationDetails.UnitId));
                }

                //com.Parameters.AddWithValue("@SRVCED_UIDNO", ObjApplicationDetails.UidNo);
                com.Parameters.AddWithValue("@SRVCED_NAMEOFUNIT", ObjApplicationDetails.Nameofunit);
                com.Parameters.AddWithValue("@SRVCED_COMPANYTYPE", ObjApplicationDetails.companyType);
                com.Parameters.AddWithValue("@SRVCED_SECTORENTERPRISE", ObjApplicationDetails.INDUSTRY);
                com.Parameters.AddWithValue("@SRVCED_CATEGORYREG", ObjApplicationDetails.CATEGORYREG);
                com.Parameters.AddWithValue("@SRVCED_REGNUMBER", ObjApplicationDetails.RegNumber);
                if (ObjApplicationDetails.RegDate != null && ObjApplicationDetails.RegDate != "")
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
                if (ObjApplicationDetails.LANDLINENO != null && ObjApplicationDetails.LANDLINENO != "")
                {
                    com.Parameters.AddWithValue("@SRVCED_LANDLINENUMBER", ObjApplicationDetails.LANDLINENO);
                }
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
                com.Parameters.AddWithValue("@SRVCED_DIRECTMALE", Convert.ToInt32(ObjApplicationDetails.DIRECTMALE));
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

                //com.Parameters.AddWithValue("@BMW_UNITID", Convert.ToInt32(ObjBMWDetails.UnitId));
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
                if (ObjBMWDetails.Pollution1974 != null && ObjBMWDetails.Pollution1974 != "")
                {
                    com.Parameters.AddWithValue("@BMW_PCB1974", ObjBMWDetails.Pollution1974);
                }
                if (ObjBMWDetails.ControlPollution1981 != null && ObjBMWDetails.ControlPollution1981 != "")
                {
                    com.Parameters.AddWithValue("@BMW_PCB1981", ObjBMWDetails.ControlPollution1981);
                }

                com.Parameters.AddWithValue("@BMW_APPLIEDFOR", ObjBMWDetails.AppliedFor);
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
                com.Parameters.AddWithValue("@BMW_BEDFEE", Convert.ToDecimal(ObjBMWDetails.BedFee));
                com.Parameters.AddWithValue("@BMW_BEDTYPE", ObjBMWDetails.BedType);
                com.Parameters.AddWithValue("@BMW_YEARS", ObjBMWDetails.AuthYears);

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
                // com.Parameters.AddWithValue("@BMW_UNITID", Convert.ToInt32(ObjBMWDetails.UnitId));
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
        public string InsertBMWWASTEDET(DataTable dtBMWDetails, string Questionnaire, string Createdby, string IPAddress)
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

                        //cmd.Parameters.AddWithValue("@BMW_UNITID", Unitid);
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
        public DataSet GetSRVCApprovals(string userid, string SRVCQDID)
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
                if (SRVCQDID != null && SRVCQDID != "")
                {
                    da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(SRVCQDID));
                }
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
        public DataSet GetSrvcBMWDet(string userid, String SRVCQID)
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

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(SRVCQID));
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
                // com.Parameters.AddWithValue("@SRVCSWD_UNITID", Convert.ToInt32(ObjSWMDet.unitid));
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
                com.Parameters.AddWithValue("@SRVCSWD_AUTHFEE", Convert.ToDecimal(ObjSWMDet.authfee));
                com.Parameters.AddWithValue("@SRVCSOLIDWASTENO", ObjSWMDet.Totalsolid);


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
        public DataSet GetSrvcSWMDetails(string userid, String SRVCQDID)
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

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(SRVCQDID));
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
        public DataSet GetsrvcapprovalID(string userid, string QusestionnaireID, string DeptID, string ApprovalID)
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

                //da.SelectCommand.Parameters.AddWithValue("@UNITID", UNITID);
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
        public DataSet GetApplicationStatus(string userid, string SRVCQID, string Status)
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

                da.SelectCommand.Parameters.AddWithValue("@USERID", userid);
                da.SelectCommand.Parameters.AddWithValue("@SRVCQID", SRVCQID);
                da.SelectCommand.Parameters.AddWithValue("@TYPE", Status);
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
        public DataSet GetSRVCApplicationDetails(string QusestionnaireID, string InvesterID, string ApprovalID)
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
                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(QusestionnaireID));
                da.SelectCommand.Parameters.AddWithValue("@INVESTERID", Convert.ToInt32(InvesterID));
                if (ApprovalID != "")
                    da.SelectCommand.Parameters.AddWithValue("@APPROVALID", ApprovalID);
                else
                    da.SelectCommand.Parameters.AddWithValue("@APPROVALID", null);
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
                //com.Parameters.AddWithValue("@SRVCPDC_UNITID", Convert.ToInt32(Power.UnitId));
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
        public DataSet GetSrvcPDCLDetails(string userid, String SRVCQID)
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

                da.SelectCommand.Parameters.AddWithValue("@SRVCQID", Convert.ToInt32(SRVCQID));
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
                // com.Parameters.AddWithValue("@EWD_UNITID", Convert.ToInt32(serviceEWasteDetails.UnitId));
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
                com.Parameters.AddWithValue("@EWD_AUTHFEE", Convert.ToDecimal(serviceEWasteDetails.EWasteAuthFee));

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
                // com.Parameters.AddWithValue("@SRVCPWD_REGDATE", Convert.ToDateTime (serviceProdPlasticsWasteDetails.RegistrationDate).ToString());
                com.Parameters.AddWithValue("@SRVCPWD_REGDATE", DateTime.ParseExact(serviceProdPlasticsWasteDetails.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));


                com.Parameters.AddWithValue("@SRVCPWD_TOTCAPTLINV", serviceProdPlasticsWasteDetails.TotalCapitalInvestment);
                com.Parameters.AddWithValue("@SRVCPWD_YEAROFCMNCEMNT", serviceProdPlasticsWasteDetails.YearOfCommencement);
                com.Parameters.AddWithValue("@SRVCPWD_LISTQNTMPROD", serviceProdPlasticsWasteDetails.ListQuantityProduct);
                com.Parameters.AddWithValue("@SRVCPWD_LISTQNTMRAWMAT", serviceProdPlasticsWasteDetails.ListQuantityRawMaterial);
                com.Parameters.AddWithValue("@SRVCPWD_TOTALQNTMWASTEGENERATED", serviceProdPlasticsWasteDetails.TotalQuantityWasteGenerated);
                com.Parameters.AddWithValue("@SRVCPWD_MODEOFSTORAGEWITHINPLANT", serviceProdPlasticsWasteDetails.ModeOfStorageWithinPlant);
                com.Parameters.AddWithValue("@SRVCPWD_DISPOSALPROVISION", serviceProdPlasticsWasteDetails.DisposalProvision);
                com.Parameters.AddWithValue("@SRVCPWD_COMPLIANCE", serviceProdPlasticsWasteDetails.Compliance);
                com.Parameters.AddWithValue("@SRVCPWD_ROLE", serviceProdPlasticsWasteDetails.Role);
                com.Parameters.AddWithValue("@SRVCPWD_WATERACT", serviceProdPlasticsWasteDetails.WaterAct);
                com.Parameters.AddWithValue("@SRVCPWD_SGUT", serviceProdPlasticsWasteDetails.SgUt);
                com.Parameters.AddWithValue("@SRVCPWD_AIRPOL", serviceProdPlasticsWasteDetails.AirCont);





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
                com.Parameters.AddWithValue("@BOPWD_ROLE", serviceBOPlasticsWasteDetails.Role);
                com.Parameters.AddWithValue("@BOPWD_WATERACT", serviceBOPlasticsWasteDetails.WaterAct);
                com.Parameters.AddWithValue("@BOPWD_SGUT", serviceBOPlasticsWasteDetails.SgUt);
                com.Parameters.AddWithValue("@BOPWD_AIRPOL", serviceBOPlasticsWasteDetails.AirCont);

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
                //com.Parameters.AddWithValue("@CDWM_UNITID", Convert.ToInt32(objCDWMDet.unitid));
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
        public DataSet GetSRVCUploadEnclosures(string Quid, string userid)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCUploadEnclosures, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCUploadEnclosures;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(Quid));
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
        public DataSet GetUserSRVCApplStatus(string Userid, string SRVCQID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCApplStatus, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCApplStatus;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@USERID", Convert.ToInt32(Userid));
                da.SelectCommand.Parameters.AddWithValue("@SRVCQID", Convert.ToInt32(SRVCQID));
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

        public DataSet GetProdPlasticWasteDetails(string hdnUserID, string srvcQdId)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetProdPlasticWasteDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetProdPlasticWasteDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(srvcQdId));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(hdnUserID));
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

        public DataSet GetBOPlasticWasteDetails(string hdnUserID, string srvcQdId)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetBOPlasticWasteDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetBOPlasticWasteDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(srvcQdId));
                da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(hdnUserID));
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
        public string InsertRegSocietiesDetails(SRVCRegSocietiesDetailos ObjRegSocietiesDetails)
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
                    CommandText = SvrcConstants.InsertRegSocietiesDetails,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("@SRVCMD_SRVCQDID", Convert.ToInt32(ObjRegSocietiesDetails.SRVCQDID));
                com.Parameters.AddWithValue("@SRVCMD_CREATEDBY", Convert.ToInt32(ObjRegSocietiesDetails.createdby));
                com.Parameters.AddWithValue("@SRVCMD_FULLNAME", ObjRegSocietiesDetails.FullName);
                com.Parameters.AddWithValue("@SRVCMD_FULLADDRESS", ObjRegSocietiesDetails.FullAddress);
                com.Parameters.AddWithValue("@SRVCMD_POLICESTATION", ObjRegSocietiesDetails.Policestation);
                com.Parameters.AddWithValue("@SRVCMD_DESIGNATION", ObjRegSocietiesDetails.Designation);
                com.Parameters.AddWithValue("@SRVCMD_MOBILENO", Convert.ToInt32(ObjRegSocietiesDetails.MobileNo));
                com.Parameters.AddWithValue("@SRVCMD_CREATEDBYIP", ObjRegSocietiesDetails.createdbyip);

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
        public string SRVCRegSocietiesDet(SRVCRegSocietiesDetailos ObjRegSocietiesDetails)
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
                    CommandText = SvrcConstants.InsRegSocietiesDet,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("@SRVCRS_SRVCQDID", Convert.ToInt32(ObjRegSocietiesDetails.SRVCQDID));
                com.Parameters.AddWithValue("@SRVCRS_CREATEDBY", ObjRegSocietiesDetails.createdby);
                com.Parameters.AddWithValue("@SRVCRS_APPLICATIONSUBMISSION", ObjRegSocietiesDetails.Applicationassociation);
                com.Parameters.AddWithValue("@SRVCRS_DISTRICT", Convert.ToInt32(ObjRegSocietiesDetails.District));
                com.Parameters.AddWithValue("@SRVCRS_SUBDIVISION", Convert.ToInt32(ObjRegSocietiesDetails.SUBDIVISION));
                com.Parameters.AddWithValue("@SRVCRS_TYPEAPPLICATION", ObjRegSocietiesDetails.TypeApplication);
                com.Parameters.AddWithValue("@SRVCRS_OLDREGNO", ObjRegSocietiesDetails.OldRegNumber);
                com.Parameters.AddWithValue("@SRVCRS_REGDATE", ObjRegSocietiesDetails.RegDate);
                com.Parameters.AddWithValue("@SRVCRS_NAMEOFASSOCIATION", ObjRegSocietiesDetails.NameAssociation);
                com.Parameters.AddWithValue("@SRVCRS_ADDRESSSOCIETY", ObjRegSocietiesDetails.AddressSociety);
                com.Parameters.AddWithValue("@SRVCRS_DATEOFESTABLISHMENT", ObjRegSocietiesDetails.Dateest);
                com.Parameters.AddWithValue("@SRVCRS_CONTACTNO", Convert.ToInt32(ObjRegSocietiesDetails.ContactNo));
                com.Parameters.AddWithValue("@SRVCRS_GENERALSECRETYNO", Convert.ToInt32(ObjRegSocietiesDetails.GeneralNo));
                com.Parameters.AddWithValue("@SRVCRS_EMAIL", ObjRegSocietiesDetails.Email);



                com.Parameters.AddWithValue("", ObjRegSocietiesDetails.createdbyip);

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
        public DataSet GetRegSocietiesDet(string userid, String SRVCQID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetRegSocietiesDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetRegSocietiesDetails;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(SRVCQID));
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
        public DataSet RetrieveSRVCDGSETDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GETSRVCGSETDETAILS, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GETSRVCGSETDETAILS;

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
        public string INSERTSRVCDGSET(SRVCDGset ObjSRVCDGset)
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
                com.CommandText = SvrcConstants.INSERTSRVCDGSETDETAILS;

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CFEDG_CREATEDBY", Convert.ToInt32(ObjSRVCDGset.CreatedBy));
                com.Parameters.AddWithValue("@CFEDG_CREATEDBYIP", ObjSRVCDGset.IPAddress);
                com.Parameters.AddWithValue("@CFEDG_CFEQDID", Convert.ToInt32(ObjSRVCDGset.Questionnaireid));
                com.Parameters.AddWithValue("@CFEDG_UNITID", Convert.ToInt32(ObjSRVCDGset.UnitId));

                com.Parameters.AddWithValue("@CFEDG_LOCDOORNO", ObjSRVCDGset.LocDoorno);
                com.Parameters.AddWithValue("@CFEDG_LOCALITY", ObjSRVCDGset.Locality);
                com.Parameters.AddWithValue("@CFEDG_LANDMARK", ObjSRVCDGset.Landamark);
                com.Parameters.AddWithValue("@CFEDG_LOCDISTRICTID", Convert.ToInt32(ObjSRVCDGset.LocDistrictID));
                com.Parameters.AddWithValue("@CFEDG_LOCMANDALID", Convert.ToInt32(ObjSRVCDGset.LocMandalID));
                com.Parameters.AddWithValue("@CFEDG_LOCVILLAGEID", Convert.ToInt32(Convert.ToInt64(ObjSRVCDGset.LocVillageID)));
                if (ObjSRVCDGset.LocPincode != null && ObjSRVCDGset.LocPincode != "")
                {
                    com.Parameters.AddWithValue("@CFEDG_LOCPINCODE", Convert.ToInt64(ObjSRVCDGset.LocPincode));
                }

                com.Parameters.AddWithValue("@CFEDG_SUPPLIERNAME", ObjSRVCDGset.SupplierName);
                com.Parameters.AddWithValue("@CFEDG_TOTLCONNECTEDLOAD", ObjSRVCDGset.TotalConnectedLoad);
                com.Parameters.AddWithValue("@CFEDG_TOTLPROPDGSETLOAD", ObjSRVCDGset.PropLoadfromDGSet);
                com.Parameters.AddWithValue("@CFEDG_INTERLOCKPROVIDED", ObjSRVCDGset.InterlockProvided);
                com.Parameters.AddWithValue("@CFEDG_MOTORLOAD", ObjSRVCDGset.MotorLoad);
                com.Parameters.AddWithValue("@CFEDG_LIGHTSFANSLOAD", ObjSRVCDGset.LightsandFansLoad);
                com.Parameters.AddWithValue("@CFEDG_OTHERLOAD", ObjSRVCDGset.OtherlLoad);
                com.Parameters.AddWithValue("@CFEDG_GENRUNNINGMODE", ObjSRVCDGset.GenRunningMode);

                com.Parameters.AddWithValue("@CFEDG_WRKCOMPLETIONDATE", DateTime.ParseExact(ObjSRVCDGset.WorkCompletionDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyy-MM-dd"));
                com.Parameters.AddWithValue("@CFEDG_INSTLATIONSTARTDATE", DateTime.ParseExact(ObjSRVCDGset.WorkStartingDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@CFEDG_COMMISSIONINGDATE", DateTime.ParseExact(ObjSRVCDGset.CommissioningDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyy-MM-dd"));

                com.Parameters.AddWithValue("@CFEDG_SUPERVISORNAME", ObjSRVCDGset.SupervisorName);
                com.Parameters.AddWithValue("@CFEDG_SUPERVISORLICNO", ObjSRVCDGset.SupervisorLicNo);
                com.Parameters.AddWithValue("@CFEDG_CONTRACTORNAME", ObjSRVCDGset.ContractorName);
                com.Parameters.AddWithValue("@CFEDG_CONTRACTORLICNO", ObjSRVCDGset.ContractorLicNo);
                com.Parameters.AddWithValue("@CFEDG_DGSETOPERATORNAME", ObjSRVCDGset.DGSetOperatorNmae);
                com.Parameters.AddWithValue("@CFEDG_DGSETCAPACITY", ObjSRVCDGset.DGSetCapacity);
                com.Parameters.AddWithValue("@CFEDG_DGSETCAPACITYIN", ObjSRVCDGset.DGSetCapacityin);
                com.Parameters.AddWithValue("@CFEDG_DGSETPOWERFACTOR", ObjSRVCDGset.DGSetPowerFactor);
                com.Parameters.AddWithValue("@CFEDG_DGSETRATEDVOLTAGE", ObjSRVCDGset.DGSetRatedVoltage);
                com.Parameters.AddWithValue("@CFEDG_DGSETENGINEDTLS", ObjSRVCDGset.DGSetEngineDetails);
                com.Parameters.AddWithValue("@CFEDG_DGSETALTERNATORDTLS", ObjSRVCDGset.DGSetAlternatorDetails);

                com.Parameters.AddWithValue("@CFEDG_EQUIPMENTTYPE", ObjSRVCDGset.EquipmentType);
                com.Parameters.AddWithValue("@CFEDG_EARTHCONDCTRDTLS", ObjSRVCDGset.EarthingCondctrDtls);
                com.Parameters.AddWithValue("@CFEDG_CONDUCTORPATHS", ObjSRVCDGset.ConductrPaths);
                com.Parameters.AddWithValue("@CFEDG_ELECTRODEDTLS", ObjSRVCDGset.ElectrodeDtls);

                com.Parameters.AddWithValue("@CFEDG_IMPEDANCE", ObjSRVCDGset.Impedance);
                com.Parameters.AddWithValue("@CFEDG_TOTALIMPEDANCE", ObjSRVCDGset.TotalImpedance);
                com.Parameters.AddWithValue("@CFEDG_LIGHTINGTYPE", ObjSRVCDGset.LighingType);
                com.Parameters.AddWithValue("@CFEDG_ALTERNATORTESTDTLS", ObjSRVCDGset.AlternatorTestDtls);
                com.Parameters.AddWithValue("@CFEDG_EARTHTESTERNO", ObjSRVCDGset.EarthTesterNo);
                com.Parameters.AddWithValue("@CFEDG_EARTHTESTERMAKE", ObjSRVCDGset.EarthTesterMake);
                com.Parameters.AddWithValue("@CFEDG_EARTHTESTERRANGE", ObjSRVCDGset.EarthTesterRange);
                com.Parameters.AddWithValue("@CFEDG_MEGGERNO", ObjSRVCDGset.MeggerNo);
                com.Parameters.AddWithValue("@CFEDG_MEGGERMAKE", ObjSRVCDGset.MeggerMake);
                com.Parameters.AddWithValue("@CFEDG_MEGGERRANGE", ObjSRVCDGset.MeggerRange);

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
        public string InsertLabourConWorkDetails(LabourConstructionwork objCDWMDet)
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
                    CommandText = SvrcConstants.InsertLabourContractorDetails,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("", Convert.ToInt32(objCDWMDet.Questionnariid));
                com.Parameters.AddWithValue("", objCDWMDet.Createdby);
                com.Parameters.AddWithValue("", objCDWMDet.FullNamePE);
                com.Parameters.AddWithValue("", objCDWMDet.AddressPE);
                com.Parameters.AddWithValue("", Convert.ToInt32(objCDWMDet.StatePE));
                com.Parameters.AddWithValue("", Convert.ToInt32(objCDWMDet.DistrictPE));
                com.Parameters.AddWithValue("", Convert.ToInt32(objCDWMDet.MandalPE));
                com.Parameters.AddWithValue("", Convert.ToInt32(objCDWMDet.VillagePE));
                com.Parameters.AddWithValue("", objCDWMDet.DistPE);
                com.Parameters.AddWithValue("", objCDWMDet.MandalesPE);
                com.Parameters.AddWithValue("", objCDWMDet.VillagesPE);
                com.Parameters.AddWithValue("", objCDWMDet.PostOfficePE);
                com.Parameters.AddWithValue("", objCDWMDet.PincodePE);
                com.Parameters.AddWithValue("", objCDWMDet.NameManager);
                com.Parameters.AddWithValue("", objCDWMDet.AddressManager);
                com.Parameters.AddWithValue("", objCDWMDet.DistrictManager);
                com.Parameters.AddWithValue("", objCDWMDet.MandalManager);
                com.Parameters.AddWithValue("", objCDWMDet.VillageManager);
                com.Parameters.AddWithValue("", objCDWMDet.PoliceStationManager);
                com.Parameters.AddWithValue("", objCDWMDet.PostOfficeManager);
                com.Parameters.AddWithValue("", objCDWMDet.PincodeManager);
                com.Parameters.AddWithValue("", objCDWMDet.NatureofBuilding);
                com.Parameters.AddWithValue("", objCDWMDet.NoofWorkEmpDay);
                com.Parameters.AddWithValue("", objCDWMDet.EstConDate);
                com.Parameters.AddWithValue("", objCDWMDet.EstConworkDate);
                com.Parameters.AddWithValue("", objCDWMDet.IPAddress);

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
        public DataSet GetSRVCLabourDETAILS(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GETSRVCLabour7DETAILS, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GETSRVCLabour7DETAILS;

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
        /* public string InsertTourismDetails(SRVCTourism ObjTourismDet)
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
                     CommandText = SvrcConstants.InsertTourismDetails,
                     Transaction = transaction,
                     Connection = connection
                 };

                 com.Parameters.AddWithValue("", Convert.ToInt32(ObjTourismDet.Questionnariid));
                 com.Parameters.AddWithValue("", ObjTourismDet.Createdby);
                 com.Parameters.AddWithValue("", ObjTourismDet.NatureOrganization);
                 com.Parameters.AddWithValue("", ObjTourismDet.YearRegComm);

                 com.Parameters.AddWithValue("", ObjTourismDet.NameDirector);
                 com.Parameters.AddWithValue("", ObjTourismDet.Interestsindicated);
                 com.Parameters.AddWithValue("", ObjTourismDet.SpaceSqft);
                 com.Parameters.AddWithValue("", ObjTourismDet.LocationArea);
                 com.Parameters.AddWithValue("", ObjTourismDet.ReceptionArea);
                 com.Parameters.AddWithValue("", ObjTourismDet.AccessibilityToilet);
                 com.Parameters.AddWithValue("", ObjTourismDet.NameBankers);
                 com.Parameters.AddWithValue("", ObjTourismDet.NameAuditors);
                 com.Parameters.AddWithValue("", ObjTourismDet.indicatemembership);
                 com.Parameters.AddWithValue("", ObjTourismDet.touristtraffic);
                 com.Parameters.AddWithValue("", ObjTourismDet.Clientele);
                 com.Parameters.AddWithValue("", ObjTourismDet.domestictouristtraffic);
                 com.Parameters.AddWithValue("", ObjTourismDet.Numberconferences);
                 com.Parameters.AddWithValue("", ObjTourismDet.IPAddress);

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
         }*/
        public string InsertEncumbranceDetails(SRVCEncumbrance ObjEncumbrance)
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
                    CommandText = SvrcConstants.InsertEncumberanceDetails,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("", Convert.ToInt32(ObjEncumbrance.Questionnariid));
                com.Parameters.AddWithValue("", ObjEncumbrance.Createdby);
                com.Parameters.AddWithValue("", ObjEncumbrance.Applyservice);
                com.Parameters.AddWithValue("", ObjEncumbrance.Depty);

                com.Parameters.AddWithValue("", ObjEncumbrance.Division);
                com.Parameters.AddWithValue("", ObjEncumbrance.Search);
                com.Parameters.AddWithValue("", ObjEncumbrance.searchfrom);
                com.Parameters.AddWithValue("", ObjEncumbrance.ApplicantDocument);
                com.Parameters.AddWithValue("", ObjEncumbrance.others);
                com.Parameters.AddWithValue("", ObjEncumbrance.SearchNecessary);
                com.Parameters.AddWithValue("", ObjEncumbrance.NatureDocument);
                com.Parameters.AddWithValue("", ObjEncumbrance.Dated);
                com.Parameters.AddWithValue("", ObjEncumbrance.AreaIn);
                com.Parameters.AddWithValue("", ObjEncumbrance.Area);
                com.Parameters.AddWithValue("", ObjEncumbrance.IPAddress);

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
        public DataSet GetSRVCNonEncumbranceDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GETSRVCNonEncumbranceDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GETSRVCNonEncumbranceDetails;

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
        public string InsertLabourWorkmenDetails(Labourworkme6 ObjCDWMDet)
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
                    CommandText = SvrcConstants.InsertLabourworkmenDetails,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("@SRVCLD_SRVCQDID", Convert.ToInt32(ObjCDWMDet.Questionnariid));
                com.Parameters.AddWithValue("@SRVCLD_CREATEDBY", ObjCDWMDet.Createdby);
                com.Parameters.AddWithValue("@SRVCLD_DATEAGE", ObjCDWMDet.DateofBirth);

                if (ObjCDWMDet.Date != null && ObjCDWMDet.Date != "")
                {
                    com.Parameters.AddWithValue("@SRVCLD_DATE", DateTime.ParseExact(ObjCDWMDet.Date, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyy-MM-dd"));
                }

                if (ObjCDWMDet.Age != null && ObjCDWMDet.Age != "")
                {
                    com.Parameters.AddWithValue("@SRVCLD_AGE", Convert.ToInt32(ObjCDWMDet.Age));
                }

                com.Parameters.AddWithValue("@SRVCLD_STATEID", Convert.ToInt32(ObjCDWMDet.State));
                if (ObjCDWMDet.Districtid != null && ObjCDWMDet.Districtid != "")
                { com.Parameters.AddWithValue("@SRVCLD_DISTRICTID", Convert.ToInt32(ObjCDWMDet.Districtid)); }
                if (ObjCDWMDet.Mandaleid != null && ObjCDWMDet.Mandaleid != "")
                { com.Parameters.AddWithValue("@SRVCLD_MANDALID", Convert.ToInt32(ObjCDWMDet.Mandaleid)); }
                if (ObjCDWMDet.Villageid != null && ObjCDWMDet.Villageid != "")
                { com.Parameters.AddWithValue("@SRVCLD_VILLAGEID", Convert.ToInt32(ObjCDWMDet.Villageid)); }
                if (ObjCDWMDet.District != null && ObjCDWMDet.District != "")
                {
                    com.Parameters.AddWithValue("@SRVCLD_DISTRICT", ObjCDWMDet.District);
                }
                if (ObjCDWMDet.Mandal != null && ObjCDWMDet.Mandal != "")
                {
                    com.Parameters.AddWithValue("@SRVCLD_MANDAL", ObjCDWMDet.Mandal);
                }
                if (ObjCDWMDet.Village != null && ObjCDWMDet.Village != "")
                {
                    com.Parameters.AddWithValue("@SRVCLD_VILLAGE", ObjCDWMDet.Village);
                }
                com.Parameters.AddWithValue("@SRVCLD_LOCALITY", ObjCDWMDet.Locality);
                com.Parameters.AddWithValue("@SRVCLD_LANDMARK", ObjCDWMDet.Landmark);
                com.Parameters.AddWithValue("@SRVCLD_PINCODE", ObjCDWMDet.Pincode);
                com.Parameters.AddWithValue("@SRVCLD_ARTICAL5OTHERDETAILS", ObjCDWMDet.Artical5);
                com.Parameters.AddWithValue("@SRVCLD_CRIMINALOTHERDETAILS", ObjCDWMDet.Criminalcase);
                com.Parameters.AddWithValue("@SRVCLD_CRIMINALCASEFIVEYEAROTHERDETAILS", ObjCDWMDet.ConvictedCrimecase);
                com.Parameters.AddWithValue("@SRVCLD_DISTRICTCOUNCIL", ObjCDWMDet.DistrictCouncil);
                com.Parameters.AddWithValue("@SRVCLD_LICENSE", ObjCDWMDet.License);
                com.Parameters.AddWithValue("@SRVCLD_LICNO", ObjCDWMDet.Licenseno);
                com.Parameters.AddWithValue("@SRVCLD_DATEOFLIC", ObjCDWMDet.DateofLicense);
                com.Parameters.AddWithValue("@SRVCLD_VALIDTILLDATE", ObjCDWMDet.ValidDate);
                com.Parameters.AddWithValue("", ObjCDWMDet.Trible);
                com.Parameters.AddWithValue("", ObjCDWMDet.Reason);
                com.Parameters.AddWithValue("@SRVCLD_EMPNAME", ObjCDWMDet.NameEst);
                com.Parameters.AddWithValue("@SRVCLD_EMPTYPEOFBUSINESS", ObjCDWMDet.TypeofBusiness);
                com.Parameters.AddWithValue("@SRVCLD_EMPREGNO", ObjCDWMDet.RegNoEst);
                com.Parameters.AddWithValue("@SRVCLD_EMPDATEREG", ObjCDWMDet.DateofReg);
                com.Parameters.AddWithValue("@SRVCLD_ESTDISTRICTID", Convert.ToInt32(ObjCDWMDet.DistrictEst));
                com.Parameters.AddWithValue("@SRVCLD_ESTMANDALID", Convert.ToInt32(ObjCDWMDet.MandalEst));
                com.Parameters.AddWithValue("@SRVCLD_ESTVILLAGEID", Convert.ToInt32(ObjCDWMDet.VillageEst));
                com.Parameters.AddWithValue("@SRVCLD_ESTLOCALITY", ObjCDWMDet.LocalityEst);
                com.Parameters.AddWithValue("@SRVCLD_ESTLANDMARK", ObjCDWMDet.LandMarkEst);
                com.Parameters.AddWithValue("@SRVCLD_ESTPINCODE", ObjCDWMDet.PincodeEst);
                com.Parameters.AddWithValue("@SRVCLD_EMPTITLE", ObjCDWMDet.TitleEmpDet);
                com.Parameters.AddWithValue("@SRVCLD_EMPNAMEPRINCIPAL", ObjCDWMDet.NameEmpPrincipal);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTNAME", ObjCDWMDet.NameLocationNature);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTDURATIONDAY", ObjCDWMDet.DurationWorkDay);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTDATE", ObjCDWMDet.CommencingDate);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTENDDATE", ObjCDWMDet.EndingDate);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTNAMEAGENT", ObjCDWMDet.NameAgent);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTMAXNO", Convert.ToInt32(ObjCDWMDet.MaxMigrantWorkmenNo));
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTSTATEID", Convert.ToInt32(ObjCDWMDet.MigrantState));
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTDISTRICTID", ObjCDWMDet.MigrantDistrict);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTNAMEADDRESS", ObjCDWMDet.MigrantNameAddress);
                com.Parameters.AddWithValue("@SRVCLD_MIKGRANTCONTRACTOR5YEAR", ObjCDWMDet.Convicted5Year);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTDETAILS", ObjCDWMDet.Details);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTSUSPENDINGLICENSE", ObjCDWMDet.suspendinglicense);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTORDERNO", ObjCDWMDet.OrderNo);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTORDERDATE", ObjCDWMDet.OrderDate);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTEST5YEARS", ObjCDWMDet.ContractEst5Year);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTESTABLISHMENT", ObjCDWMDet.Establishment);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTPRINCIPALEMPLOYER", ObjCDWMDet.PrincipalEmp);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTNATUREWORK", ObjCDWMDet.NatureWork);
                com.Parameters.AddWithValue("@SRVCLD_MIGRANTEMP", ObjCDWMDet.PrincipalEmployer);
                com.Parameters.AddWithValue("@SRVCLD_CREATEDBYIP", ObjCDWMDet.IPAddress);

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
        public string InsertLabour1970Details(Labour1970 objLabour)
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
                    CommandText = SvrcConstants.InsertLabour1970Details,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.Questionnariid));
                com.Parameters.AddWithValue("", objLabour.Createdby);
                com.Parameters.AddWithValue("", objLabour.EmpName);
                com.Parameters.AddWithValue("", objLabour.Father);

                com.Parameters.AddWithValue("", objLabour.EmpEMail);
                com.Parameters.AddWithValue("", objLabour.EmpMobileNo);
                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.State));
                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.DistrictId));
                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.MandalId));
                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.VillageId));
                com.Parameters.AddWithValue("", objLabour.District);
                com.Parameters.AddWithValue("", objLabour.Mandal);
                com.Parameters.AddWithValue("", objLabour.Village);
                com.Parameters.AddWithValue("", objLabour.Locality);
                com.Parameters.AddWithValue("", objLabour.Landmark);
                com.Parameters.AddWithValue("", objLabour.Station);
                com.Parameters.AddWithValue("", objLabour.PostOffice);
                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.Pincode));
                com.Parameters.AddWithValue("", objLabour.IPAddress);

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
        public string InsertSRVCLabourMotorDetails(SRVCLabourMotor objLabour)
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
                    CommandText = SvrcConstants.InsertSrvcLabourMotorDetails,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("@SRVCLM_SRVCQDID", Convert.ToInt32(objLabour.Questionnariid));
                com.Parameters.AddWithValue("@SRVCLM_CREATEDBY", Convert.ToInt32(objLabour.Createdby));
                com.Parameters.AddWithValue("@SRVCLM_NATUREMOTORTRANSPORT", objLabour.NatureMotor);
                com.Parameters.AddWithValue("@SRVCLM_TOTALNOROUTE", objLabour.TotalNo);
                com.Parameters.AddWithValue("@SRVCLM_TOTALMILEAGE", objLabour.Totalroute);
                com.Parameters.AddWithValue("@SRVCLM_TOTALNOVEHICLE", objLabour.TotalNoVehicle);
                com.Parameters.AddWithValue("@SRVCLM_MAXNOEMPWORK", objLabour.MaxNoMotor);
                com.Parameters.AddWithValue("@SRVCLM_TYPETRANSPORT", objLabour.TypeOfTransport);
                com.Parameters.AddWithValue("@SRVCLM_PROPNAME", objLabour.ProprietorshipName);
                com.Parameters.AddWithValue("@SRVCLM_PROPADDRESS", objLabour.ProprietorshipAddress);
                com.Parameters.AddWithValue("@SRVCLM_SECTORNAME", objLabour.SectorName);
                com.Parameters.AddWithValue("@SRVCLM_SECTORADDRESS", objLabour.SectorAddress);
                com.Parameters.AddWithValue("@SRVCLM_VEHICLENO", objLabour.VehicleNo);
                com.Parameters.AddWithValue("@SRVCLM_TYPEVEHICLE", objLabour.TypeVehicle);
                com.Parameters.AddWithValue("@SRVCLM_CREATEDBYIP", objLabour.IPAddress);

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
        public string InsertDirectorsFromXml(DirectorXmlDTO dto)
        {
            string result = "";
            SqlConnection conn = new SqlConnection(connstr);
            SqlTransaction transaction = null;

            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                SqlCommand cmd = new SqlCommand("SP_INSERT_SRVCDIRECTORS_XML", conn, transaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@XmlData", dto.XmlData);
                cmd.Parameters.AddWithValue("@SRVCQDID", dto.SRVCQDID);
                cmd.Parameters.AddWithValue("@CreatedBy", dto.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedByIP", dto.CreatedByIP);
                cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                transaction.Commit();
                result = cmd.Parameters["@Result"].Value.ToString();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                result = "ERROR: " + ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
        public int InsertPartners(SRVCLabourMotor objLabourPart)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_INSERT_SRVCPARTNERSHIPDETAILS_XML", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabourPart.Questionnariid));
                cmd.Parameters.AddWithValue("@CreatedBy", Convert.ToInt32(objLabourPart.Createdby));
                cmd.Parameters.AddWithValue("@IPAddress", objLabourPart.IPAddress);
                cmd.Parameters.AddWithValue("@PartnersXML", objLabourPart.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeletePartner(SRVCLabourMotor objLabour)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_DELETE_SRVCPARTNERSHIPDETAIL_BYNAME", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabour.Questionnariid));
                cmd.Parameters.AddWithValue("@FullName", objLabour.PartnershipName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertDirector(SRVCLabourMotor objLabour1)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_INSERT_SRVCDIRECTORDETAILS_XML", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabour1.Questionnariid));
                cmd.Parameters.AddWithValue("@CreatedBy", Convert.ToInt32(objLabour1.Createdby));
                cmd.Parameters.AddWithValue("@IPAddress", objLabour1.IPAddress);
                cmd.Parameters.AddWithValue("@DirectorXML", objLabour1.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteDirector(SRVCLabourMotor objLabour)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_SRVCDIRECTORDETAILDET_BYNAME", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabour.Questionnariid));
                cmd.Parameters.AddWithValue("@FullName", objLabour.DirectorFullName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public DataSet GetSRVCLabourMotor(string userid, String SRVCQID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSrvcLabourMotorDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSrvcLabourMotorDet;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(SRVCQID));
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
        public int InsertBrand(SRVCEXICEBRAND objBrand)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_INSSRVCEXCISEBRANDDETAILS_XML", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objBrand.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objBrand.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objBrand.IPAddress);
                cmd.Parameters.AddWithValue("@BRANDXML", objBrand.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteBrand(SRVCEXICEBRAND objBrand)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_DELETESRVCEXCISEBRANDDETAILS_BYNAME", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objBrand.Questionnariid));
                cmd.Parameters.AddWithValue("@FullName", objBrand.NameBrand);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertCountry(SRVCEXICEBRAND objBrand)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_INSSRVCEXCISELIQUORDETAILS_XML", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objBrand.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objBrand.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objBrand.IPAddress);
                cmd.Parameters.AddWithValue("@LIQUORXML", objBrand.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteCountry(SRVCEXICEBRAND objBrand)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_DELETESRVCEXCISELIQUORDETAILS_BYNAME", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objBrand.Questionnariid));
                cmd.Parameters.AddWithValue("@Country", objBrand.Country);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertAimDetails(SRVCEXICEBRAND objBrand)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_INSSRVCAIMDETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objBrand.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objBrand.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objBrand.IPAddress);
                cmd.Parameters.AddWithValue("@AIMXML", objBrand.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteAIM(SRVCEXICEBRAND objBrand)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_DELETESRVCAIMDETAILS_BYNAME", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objBrand.Questionnariid));
                cmd.Parameters.AddWithValue("@NAME", objBrand.AIM);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertMembersDetails(SRVCEXICEBRAND objBrand)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_INSSRVCEXCISEMEMBERSDETAILS_XML", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objBrand.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objBrand.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objBrand.IPAddress);
                cmd.Parameters.AddWithValue("@MEMBERSXML", objBrand.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteMemberDet(SRVCEXICEBRAND objBrand)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_DELETESRVCEXCISEMEMBERSDETAILS_BYNAME", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objBrand.Questionnariid));
                cmd.Parameters.AddWithValue("@NAME", objBrand.MemberName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public string InsertSRVCExciseDetails(SRVCEXICEBRAND objBrand)
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
                    CommandText = SvrcConstants.INSERTSRVCEXCISEDETAILS,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("@SRVCED_SRVCQDID", Convert.ToInt32(objBrand.Questionnariid));
                com.Parameters.AddWithValue("@SRVCED_CREATEDBY", Convert.ToInt32(objBrand.Createdby));
                com.Parameters.AddWithValue("@SRVCED_APPLYREGBIOBRAND", objBrand.RENBIOBrand);
                com.Parameters.AddWithValue("@SRVCED_FROMDATE", DateTime.ParseExact(objBrand.RegFromDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@SRVCED_TODATE", DateTime.ParseExact(objBrand.ToDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@SRVCED_NAMEADDRESS", objBrand.NameaddressFirm);
                com.Parameters.AddWithValue("@SRVCED_CREATEDBYIP", objBrand.IPAddress);

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
        public DataSet GetSRVCExciseDet(string userid, String SRVCQID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSrvcExciseDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSrvcExciseDet;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(SRVCQID));
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
        public int InsertDrugRetailsDet(SRVCDRUGDETAILS objDrug)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_INSSRVCDRUGRETAILDETAILS_XML", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objDrug.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objDrug.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objDrug.IPAddress);
                cmd.Parameters.AddWithValue("@DRUGRXML", objDrug.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteDrug(SRVCDRUGDETAILS objDrug)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("USP_DELETESRVCDRUGRETAILDETAILS_BYNAME", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objDrug.Questionnariid));
                cmd.Parameters.AddWithValue("@NAME", objDrug.RetailName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public string InsertSRVCDSrugDetails(SRVCDRUGDETAILS objDrug)
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
                    CommandText = SvrcConstants.INSERTSRVCDRUGDETAILS,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("@SRVCDD_SRVCQDID", Convert.ToInt32(objDrug.Questionnariid));
                com.Parameters.AddWithValue("@SRVCDD_CREATEDBY", Convert.ToInt32(objDrug.Createdby));
                com.Parameters.AddWithValue("@SRVCDD_APPLTYPE", objDrug.ApplicationType);
                if (objDrug.Select != "" && objDrug.Select != null)
                {
                    com.Parameters.AddWithValue("@SRVCDD_NAMECOMPETENT", objDrug.Select);
                }
                if (objDrug.NameCompetent != "" && objDrug.NameCompetent != null)
                {
                    com.Parameters.AddWithValue("@SRVCDD_NAMEPHARMACIST", objDrug.NameCompetent);
                }

                if (objDrug.PharmacistDate != "" && objDrug.PharmacistDate != null)
                {
                    com.Parameters.AddWithValue("@SRVCDD_VALIDDATE", DateTime.ParseExact(objDrug.PharmacistDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                }
                if (objDrug.PharmacistRegNo != "" && objDrug.PharmacistRegNo != null)
                {
                    com.Parameters.AddWithValue("@SRVCDD_REGNO", objDrug.PharmacistRegNo);
                }

                com.Parameters.AddWithValue("@SRVCDD_VALIDTNT", DateTime.ParseExact(objDrug.ValidTNT, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@SRVCDD_VALIDMUNICIPALLITYDATE", DateTime.ParseExact(objDrug.MunicipallityDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@SRVCDD_COLDSTORAGE", objDrug.ColdStorage);
                com.Parameters.AddWithValue("@SRVCDD_DRUGCATEGORY", objDrug.DrugsCategory);
                com.Parameters.AddWithValue("@SRVCDD_CREATEDBYIP", objDrug.IPAddress);

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
        public DataSet GetSRVCDRUGDet(string userid, String SRVCQID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCDRUGDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCDRUGDet;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(SRVCQID));
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
        public string INSSRVCForestDet(SRVCForestDetails objSRVCForest)
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
                    CommandText = SvrcConstants.INSERTSRVCFORESTDETAILS,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("@SRVCFD_SRVCQDID", Convert.ToInt32(objSRVCForest.Questionnariid));
                com.Parameters.AddWithValue("@SRVCFD_CREATEDBY", Convert.ToInt32(objSRVCForest.CreatedBy));
                com.Parameters.AddWithValue("@SRVCFD_FORESTDIVISION", Convert.ToInt32(objSRVCForest.ForestDivision));
                com.Parameters.AddWithValue("@SRVCFD_TYPELAND", Convert.ToInt32(objSRVCForest.LandType));
                com.Parameters.AddWithValue("@SRVCFD_LANDAREA", objSRVCForest.LandArea);
                com.Parameters.AddWithValue("@SRVCFD_NONFORESTLAND", objSRVCForest.NonForest);
                com.Parameters.AddWithValue("@SRVCFD_ADDRESS", objSRVCForest.Address);
                com.Parameters.AddWithValue("@SRVCFD_DISTRICT", Convert.ToInt32(objSRVCForest.District));
                com.Parameters.AddWithValue("@SRVCFD_MANDAL", Convert.ToInt32(objSRVCForest.Manadal));
                com.Parameters.AddWithValue("@SRVCFD_VILLAGE", Convert.ToInt32(objSRVCForest.Village));
                com.Parameters.AddWithValue("@SRVCFD_PINCODE", Convert.ToInt32(objSRVCForest.Pincode));
                com.Parameters.AddWithValue("@SRVCFD_CREATEDBYIP", objSRVCForest.IPAddress);

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
        public DataSet GetSRVCFORESTDet(string userid, String SRVCQID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCFORESTDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCFORESTDet;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(SRVCQID));
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
        public int InsertLabourDirectorDetails(SRVCLABOURACT1970DETAILS objLabour)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabour.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objLabour.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objLabour.IPAddress);
                cmd.Parameters.AddWithValue("", objLabour.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteDirector(SRVCLABOURACT1970DETAILS objLabour)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabour.Questionnariid));
                cmd.Parameters.AddWithValue("@NAME", objLabour.DirectorsName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertLabourManagerDetails(SRVCLABOURACT1970DETAILS objLabour)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabour.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objLabour.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objLabour.IPAddress);
                cmd.Parameters.AddWithValue("", objLabour.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteManager(SRVCLABOURACT1970DETAILS objLabour)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabour.Questionnariid));
                cmd.Parameters.AddWithValue("@NAME", objLabour.ManagerName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public string InsertSRVCLabour1970Details(SRVCLABOURACT1970DETAILS objLabour)
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
                    CommandText = SvrcConstants.INSERTSRVCLabourAct1970DETAILS,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.Questionnariid));
                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.Createdby));
                com.Parameters.AddWithValue("", objLabour.Title);
                com.Parameters.AddWithValue("", objLabour.PrincipalEMPNAME);
                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.State));
                if (objLabour.DISTRICTID != "" && objLabour.DISTRICTID != null)
                {
                    com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.DISTRICTID));
                }
                if (objLabour.MANDALID != "" && objLabour.MANDALID != null)
                {
                    com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.MANDALID));
                }
                if (objLabour.VILLAGEID != "" && objLabour.VILLAGEID != null)
                {
                    com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.VILLAGEID));
                }
                if (objLabour.DISTRICT != "" && objLabour.DISTRICT != null)
                {
                    com.Parameters.AddWithValue("", objLabour.DISTRICT);
                }
                if (objLabour.MANDAL != "" && objLabour.MANDAL != null)
                {
                    com.Parameters.AddWithValue("", objLabour.MANDAL);
                }
                if (objLabour.VILLAGE != "" && objLabour.VILLAGE != null)
                {
                    com.Parameters.AddWithValue("", objLabour.VILLAGE);
                }


                com.Parameters.AddWithValue("", objLabour.Locality);
                com.Parameters.AddWithValue("", objLabour.Landmark);
                com.Parameters.AddWithValue("", objLabour.PoliceStation);
                com.Parameters.AddWithValue("", objLabour.PostOffice);
                com.Parameters.AddWithValue("", objLabour.PinCode);
                com.Parameters.AddWithValue("", objLabour.TypeBusiness);
                com.Parameters.AddWithValue("", objLabour.RegNo);
                com.Parameters.AddWithValue("", objLabour.RegDate);
                com.Parameters.AddWithValue("", objLabour.Nameagentmanager);
                com.Parameters.AddWithValue("", objLabour.Addressagentmanager);
                com.Parameters.AddWithValue("", objLabour.NameNatureEmp);
                com.Parameters.AddWithValue("", objLabour.LabourNoDays);
                com.Parameters.AddWithValue("", objLabour.EstDate);
                com.Parameters.AddWithValue("", objLabour.EndingDate);
                com.Parameters.AddWithValue("", objLabour.MaxnoLabourEmp);
                com.Parameters.AddWithValue("", objLabour.Othersconvicted);
                if (objLabour.Details != "" && objLabour.Details != null)
                {
                    com.Parameters.AddWithValue("", objLabour.Details);
                }
                com.Parameters.AddWithValue("", objLabour.Othersrevoking);
                if (objLabour.OrderDate != "" && objLabour.OrderDate != null)
                {
                    com.Parameters.AddWithValue("", objLabour.OrderDate);
                }
                com.Parameters.AddWithValue("", objLabour.otherscontractorEst);
                if (objLabour.PrincipalEmpDetails != "" && objLabour.PrincipalEmpDetails != null)
                {
                    com.Parameters.AddWithValue("", objLabour.PrincipalEmpDetails);
                }
                //com.Parameters.AddWithValue("", DateTime.ParseExact(objLabour.RegFromDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                //com.Parameters.AddWithValue("", DateTime.ParseExact(objLabour.ToDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                if (objLabour.EstDetails != "" && objLabour.EstDetails != null)
                {
                    com.Parameters.AddWithValue("", objLabour.EstDetails);
                }
                if (objLabour.Naturework != "" && objLabour.Naturework != null)
                {
                    com.Parameters.AddWithValue("", objLabour.Naturework);

                }

                com.Parameters.AddWithValue("", objLabour.IPAddress);

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
        public DataSet GetSRVCLabourAct1970DETAILS(string userid, String SRVCQID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCLabourAct1970TDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCLabourAct1970TDet;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(SRVCQID));
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
        public string InsertTourismDetails(SRVCTourism ObjTourismDet)
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
                    CommandText = SvrcConstants.InsertTourismDetails,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("", Convert.ToInt32(ObjTourismDet.Questionnariid));
                com.Parameters.AddWithValue("", ObjTourismDet.Createdby);
                com.Parameters.AddWithValue("", ObjTourismDet.NatureOrganization);
                com.Parameters.AddWithValue("", ObjTourismDet.YearRegComm);

                com.Parameters.AddWithValue("", ObjTourismDet.NameDirector);
                com.Parameters.AddWithValue("", ObjTourismDet.Interestsindicated);
                com.Parameters.AddWithValue("", ObjTourismDet.SpaceSqft);
                com.Parameters.AddWithValue("", ObjTourismDet.LocationArea);
                com.Parameters.AddWithValue("", ObjTourismDet.ReceptionArea);
                com.Parameters.AddWithValue("", ObjTourismDet.AccessibilityToilet);
                com.Parameters.AddWithValue("", ObjTourismDet.NameBankers);
                com.Parameters.AddWithValue("", ObjTourismDet.NameAuditors);
                com.Parameters.AddWithValue("", ObjTourismDet.indicatemembership);
                com.Parameters.AddWithValue("", ObjTourismDet.touristtraffic);
                com.Parameters.AddWithValue("", ObjTourismDet.Clientele);
                com.Parameters.AddWithValue("", ObjTourismDet.domestictouristtraffic);
                com.Parameters.AddWithValue("", ObjTourismDet.Numberconferences);
                com.Parameters.AddWithValue("", ObjTourismDet.IPAddress);

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
        public int InsertTourismParticularsDet(SRVCTourism ObjTourismDet)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(ObjTourismDet.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(ObjTourismDet.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", ObjTourismDet.IPAddress);
                cmd.Parameters.AddWithValue("", ObjTourismDet.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteParticulars(SRVCTourism ObjTourismDet)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(ObjTourismDet.Questionnariid));
                cmd.Parameters.AddWithValue("@FullName", ObjTourismDet.NameEmp);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public DataSet GetSRVCTourismDetails(string userid, string UnitID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GETSRVCTourismDetails, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GETSRVCTourismDetails;

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
        public DataSet GetSRVCLabourAct2020DETAILS(string userid, String SRVCQID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCLabourAct2020TDet, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCLabourAct2020TDet;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(SRVCQID));
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
        public string InsertSRVCLabourMigrantWorkAct2020Details(SRVCLABOURAMIGRANTWORK2020 objLabour)
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
                    CommandText = SvrcConstants.INSERTSRVCLABOURMIGRANTACT2020DET,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.Questionnariid));
                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.Createdby));
                com.Parameters.AddWithValue("", objLabour.Namekin);
                com.Parameters.AddWithValue("", objLabour.Address);
                com.Parameters.AddWithValue("", objLabour.convictedlaw);
                com.Parameters.AddWithValue("", objLabour.criminalCase);

                com.Parameters.AddWithValue("", objLabour.Declaration);
                com.Parameters.AddWithValue("", objLabour.EmpDesignation);
                com.Parameters.AddWithValue("", objLabour.Datecommencement);
                com.Parameters.AddWithValue("", objLabour.Expected);
                com.Parameters.AddWithValue("", objLabour.DetailsWork);
                com.Parameters.AddWithValue("", objLabour.Areawork);
                com.Parameters.AddWithValue("", objLabour.EstName);
                com.Parameters.AddWithValue("", objLabour.EstAddress);
                com.Parameters.AddWithValue("", objLabour.EstContact);


                com.Parameters.AddWithValue("", objLabour.IPAddress);

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
        public DataSet GetSRVCLabourMigrantAct1979DETAILS(string userid, String SRVCQID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCLabourMigrantAct1979DET, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCLabourMigrantAct1979DET;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(SRVCQID));
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
        public int InsertLabourDirectorMigrantDetails(SRVCLABOURAMIGRANT1979DETAILS objLabour)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabour.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objLabour.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objLabour.IPAddress);
                cmd.Parameters.AddWithValue("", objLabour.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteDirectorMigrant(SRVCLABOURAMIGRANT1979DETAILS objLabour)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabour.Questionnariid));
                cmd.Parameters.AddWithValue("@NAME", objLabour.ManagerName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertLabourManagerMigrantDetails(SRVCLABOURAMIGRANT1979DETAILS objLabour)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabour.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objLabour.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objLabour.IPAddress);
                cmd.Parameters.AddWithValue("", objLabour.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteManagerMigrant(SRVCLABOURAMIGRANT1979DETAILS objLabour)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabour.Questionnariid));
                cmd.Parameters.AddWithValue("@NAME", objLabour.ManagerName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertLabourParticularsDetails(SRVCLABOURAMIGRANT1979DETAILS objLabour)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabour.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objLabour.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objLabour.IPAddress);
                cmd.Parameters.AddWithValue("", objLabour.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteParticulars(SRVCLABOURAMIGRANT1979DETAILS objLabour)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLabour.Questionnariid));
                cmd.Parameters.AddWithValue("@NAME", objLabour.ManagerName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public string InsertSRVCLabourMigrant1979Details(SRVCLABOURAMIGRANT1979DETAILS objLabour)
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
                    CommandText = SvrcConstants.INSERTSRVCLABOURMIGRANT1979DETAILS,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.Questionnariid));
                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.Createdby));
                com.Parameters.AddWithValue("", objLabour.PrincipalEMPNAME);
                com.Parameters.AddWithValue("", objLabour.PrincipalFather);
                com.Parameters.AddWithValue("", objLabour.PrincipalEMAILID);
                com.Parameters.AddWithValue("", objLabour.PrincipalMOBILENO);
                com.Parameters.AddWithValue("", Convert.ToInt32(objLabour.State));
                if (objLabour.DISTRICTID != "" && objLabour.DISTRICTID != null)
                {
                    com.Parameters.AddWithValue("@SRVCLD_DISTRICTID", Convert.ToInt32(objLabour.DISTRICTID));
                }
                if (objLabour.MANDALID != "" && objLabour.MANDALID != null)
                {
                    com.Parameters.AddWithValue("@SRVCLD_MANDALID", Convert.ToInt32(objLabour.MANDALID));
                }
                if (objLabour.VILLAGEID != "" && objLabour.VILLAGEID != null)
                {
                    com.Parameters.AddWithValue("@SRVCLD_VILLAGEID", Convert.ToInt32(objLabour.VILLAGEID));
                }
                if (objLabour.DISTRICT != "" && objLabour.DISTRICT != null)
                {
                    com.Parameters.AddWithValue("@SRVCLD_DISTRICT", objLabour.DISTRICT);
                }
                if (objLabour.MANDAL != "" && objLabour.MANDAL != null)
                {
                    com.Parameters.AddWithValue("@SRVCLD_MANDAL", objLabour.MANDAL);
                }
                if (objLabour.VILLAGE != "" && objLabour.VILLAGE != null)
                {
                    com.Parameters.AddWithValue("@SRVCLD_VILLAGE", objLabour.VILLAGE);
                }

                com.Parameters.AddWithValue("", objLabour.Locality);
                com.Parameters.AddWithValue("", objLabour.Landmark);
                com.Parameters.AddWithValue("", objLabour.PoliceStation);
                com.Parameters.AddWithValue("", objLabour.PostOffice);
                com.Parameters.AddWithValue("", objLabour.PinCode);

                com.Parameters.AddWithValue("", objLabour.IPAddress);

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
        public int InsertLeaglPartnersDetails(SRVCLegalMetrology objLegal)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLegal.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objLegal.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objLegal.IPAddress);
                cmd.Parameters.AddWithValue("", objLegal.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeletePatner(SRVCLegalMetrology objLegal)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLegal.Questionnariid));
                cmd.Parameters.AddWithValue("@NAME", objLegal.Namepartner);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertLegalManagerDetails(SRVCLegalMetrology objLegal)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLegal.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objLegal.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objLegal.IPAddress);
                cmd.Parameters.AddWithValue("", objLegal.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteLegalManagerDet(SRVCLegalMetrology objLegal)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLegal.Questionnariid));
                cmd.Parameters.AddWithValue("@NAME", objLegal.NameManaging);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public string InsertSRVCLegalMetrologyDetails(SRVCLegalMetrology objLegal)
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
                    CommandText = SvrcConstants.INSLegalMetrologyDet,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("", Convert.ToInt32(objLegal.Questionnariid));
                com.Parameters.AddWithValue("", Convert.ToInt32(objLegal.Createdby));

                if (objLegal.District != "" && objLegal.District != null)
                {
                    com.Parameters.AddWithValue("", Convert.ToInt32(objLegal.District));
                }
                if (objLegal.Mandal != "" && objLegal.Mandal != null)
                {
                    com.Parameters.AddWithValue("", Convert.ToInt32(objLegal.Mandal));
                }
                if (objLegal.Village != "" && objLegal.Village != null)
                {
                    com.Parameters.AddWithValue("", Convert.ToInt32(objLegal.Village));
                }

                com.Parameters.AddWithValue("", objLegal.landmark);
                com.Parameters.AddWithValue("", objLegal.Station);
                com.Parameters.AddWithValue("", objLegal.PostOffice);
                com.Parameters.AddWithValue("", Convert.ToInt32(objLegal.Pincode));
                com.Parameters.AddWithValue("", objLegal.DateOfEST);                 

                com.Parameters.AddWithValue("", objLegal.RegShopEst);
                com.Parameters.AddWithValue("", objLegal.RegADC);
                com.Parameters.AddWithValue("", objLegal.DateofReg);
                com.Parameters.AddWithValue("", objLegal.CurrentRegNo);
                com.Parameters.AddWithValue("", objLegal.DateOfRegADC);
                com.Parameters.AddWithValue("", objLegal.CurrentRegNoADC);
                com.Parameters.AddWithValue("", objLegal.partnershipfirm);
                com.Parameters.AddWithValue("", objLegal.limitedcompany);
                com.Parameters.AddWithValue("", objLegal.NatureManu);
                com.Parameters.AddWithValue("", objLegal.Weights);
                com.Parameters.AddWithValue("", objLegal.Measures);
                com.Parameters.AddWithValue("", objLegal.WeightingInstrument);
                com.Parameters.AddWithValue("", objLegal.Skilled);
                com.Parameters.AddWithValue("", objLegal.Semiskilled);
                com.Parameters.AddWithValue("", objLegal.Unskilled);
                com.Parameters.AddWithValue("", objLegal.Specialisttrain);
                com.Parameters.AddWithValue("", objLegal.electricenergy);
                com.Parameters.AddWithValue("", objLegal.Detailsmachinery);
                com.Parameters.AddWithValue("", objLegal.Detailsworkshop);
                com.Parameters.AddWithValue("", objLegal.FacilitiesCasting);
                com.Parameters.AddWithValue("", objLegal.receivedloan);
                com.Parameters.AddWithValue("", objLegal.bankersName);
                com.Parameters.AddWithValue("", objLegal.GiveBankerDetails);
                com.Parameters.AddWithValue("", objLegal.GST);
                com.Parameters.AddWithValue("", objLegal.ProfessionalTaxReg);
                com.Parameters.AddWithValue("", objLegal.ITNumber);
                com.Parameters.AddWithValue("", objLegal.manufacturedSold);
                com.Parameters.AddWithValue("", objLegal.manufacturerLicense);
                com.Parameters.AddWithValue("", objLegal.GiveLicenseDetails); 
                com.Parameters.AddWithValue("", objLegal.IPAddress);

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
        public int InsertLeaglPartnersDet(SRVCLegalMetrology115 objLegal)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLegal.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objLegal.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objLegal.IPAddress);
                cmd.Parameters.AddWithValue("", objLegal.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeletePatnerDet(SRVCLegalMetrology115 objLegal)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLegal.Questionnariid));
                cmd.Parameters.AddWithValue("@NAME", objLegal.Namepartner);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertLegalManagerDet(SRVCLegalMetrology115 objLegal)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLegal.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objLegal.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objLegal.IPAddress);
                cmd.Parameters.AddWithValue("", objLegal.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteLegalManagerDetails(SRVCLegalMetrology115 objLegal)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLegal.Questionnariid));
                cmd.Parameters.AddWithValue("@NAME", objLegal.NameManaging);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertLegalInstrumentDetails(SRVCLegalMetrology115 objLegal)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLegal.Questionnariid));
                cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToInt32(objLegal.Createdby));
                cmd.Parameters.AddWithValue("@IPADDRESS", objLegal.IPAddress);
                cmd.Parameters.AddWithValue("", objLegal.XMLData);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteLegalInstrumentDetails(SRVCLegalMetrology115 objLegal)
        {
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(objLegal.Questionnariid));
                cmd.Parameters.AddWithValue("@NAME", objLegal.NameManaging);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public string INSSRVCLegalMetrologyDetails(SRVCLegalMetrology115 objLegal)
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
                    CommandText = SvrcConstants.INSLegalMetrologyDetails115,
                    Transaction = transaction,
                    Connection = connection
                };

                com.Parameters.AddWithValue("", Convert.ToInt32(objLegal.Questionnariid));
                com.Parameters.AddWithValue("", Convert.ToInt32(objLegal.Createdby));            

                com.Parameters.AddWithValue("", objLegal.Dateestablishment);
                com.Parameters.AddWithValue("", objLegal.RegFactoryEst);
                com.Parameters.AddWithValue("", objLegal.ShopRegDate);
                com.Parameters.AddWithValue("", objLegal.ShopCurrentRegNo);
                com.Parameters.AddWithValue("", objLegal.RegNoADC);
                com.Parameters.AddWithValue("", objLegal.ADCDateReg);
                com.Parameters.AddWithValue("", objLegal.ADCCurrentRegNo);
                com.Parameters.AddWithValue("", objLegal.partnershipfirm);
                com.Parameters.AddWithValue("", objLegal.limitedcompany);
                com.Parameters.AddWithValue("", objLegal.Weights);
                com.Parameters.AddWithValue("", objLegal.Measures);
                com.Parameters.AddWithValue("", objLegal.WeightingInstrument);
                com.Parameters.AddWithValue("", objLegal.ProfessionalTaxReg);
                com.Parameters.AddWithValue("", objLegal.GST);
                com.Parameters.AddWithValue("", objLegal.ITNumber);
                com.Parameters.AddWithValue("", objLegal.State);
                com.Parameters.AddWithValue("", objLegal.LicNo);
                com.Parameters.AddWithValue("", objLegal.RegWeightMeasure);
                com.Parameters.AddWithValue("", objLegal.DealerLic);
                com.Parameters.AddWithValue("", objLegal.GiveDetails);
                com.Parameters.AddWithValue("", objLegal.IPAddress);

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
        public DataSet GetSRVCLegalMetrologyDet115(string userid, String SRVCQID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCLegalMetrologyDet115, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCLegalMetrologyDet115;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(SRVCQID));
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
        public DataSet GetSRVCLegalMetrologyDetails(string userid, String SRVCQID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlDataAdapter da;
                da = new SqlDataAdapter(SvrcConstants.GetSRVCLegalMetrology, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = SvrcConstants.GetSRVCLegalMetrology;

                da.SelectCommand.Transaction = transaction;
                da.SelectCommand.Connection = connection;

                da.SelectCommand.Parameters.AddWithValue("@SRVCQDID", Convert.ToInt32(SRVCQID));
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
    }
}
