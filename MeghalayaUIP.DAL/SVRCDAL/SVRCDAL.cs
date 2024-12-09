using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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
                da = new SqlDataAdapter(RENConstants.GetRENApplicantDetails, connection);
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
                //  com.Parameters.AddWithValue("@RENID_RENQDID", Convert.ToInt32(ObjApplicationDetails.Questionnariid));
                com.Parameters.AddWithValue("@SRVCED_UNITID", Convert.ToInt32(ObjApplicationDetails.UnitId));

                com.Parameters.AddWithValue("@SRVCED_UIDNO", ObjApplicationDetails.UidNo);
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
    }
}
