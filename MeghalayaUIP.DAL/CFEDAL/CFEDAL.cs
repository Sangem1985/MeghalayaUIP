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

        //public CFEQuestionnaireDet GetIndustryRegData(string InvesterID)
        //{
        //    CFEQuestionnaireDet lstQuestDtls = new CFEQuestionnaireDet();

        //    SqlDataReader objSqlDataReader = null;
        //    var ObjDivisionAllotmentModel = new CFEQuestionnaireDet();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[]
        //        {
        //            new SqlParameter("@InvesterID",Convert.ToInt32(InvesterID))
        //        };
        //        objSqlDataReader = SqlHelper.ExecuteReader(connstr, MasterConstants.GetIndustrismaster, param);
        //        if (objSqlDataReader != null && objSqlDataReader.HasRows)
        //        {
        //            while (objSqlDataReader.Read())
        //            {

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public DataSet GetCFEQuestionnaireDet(string userid)
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
    }
}
