using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeghalayaUIP.Common;


namespace MeghalayaUIP.DAL.CommonDAL
{
    public class LoginDAL
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();
        public UserInfo GetUserInfo(string UserName, string Password, string IPAdrs)
        {
            SqlDataReader objSqlDataReader = null;
            var ObjUserInf = new UserInfo();

            try
            {

                SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@emailid",UserName),
                new SqlParameter("@PWD",Password),
                new SqlParameter("@IPADDRESS",IPAdrs)
                };
                objSqlDataReader = SqlHelper.ExecuteReader(connstr, LoginConstants.ValidateUser, param);

                if (objSqlDataReader != null && objSqlDataReader.HasRows)
                {
                    //SELECT InvesterId, EntityName, Fullname, emailid FROM Insvester_Login WHERE emailid = @emailid AND pwd = @PWD

                    while (objSqlDataReader.Read())
                    {
                        ObjUserInf.Userid = objSqlDataReader["InvesterId"] == null ? "" : Convert.ToString(objSqlDataReader["InvesterId"]);
                        ObjUserInf.Fullname = objSqlDataReader["Fullname"] == null ? "" : Convert.ToString(objSqlDataReader["Fullname"]);
                        ObjUserInf.Email = objSqlDataReader["emailid"] == null ? "" : Convert.ToString(objSqlDataReader["emailid"]);
                        ObjUserInf.EntityName = objSqlDataReader["EntityName"] == null ? "" : Convert.ToString(objSqlDataReader["EntityName"]);
                        ObjUserInf.PANno = objSqlDataReader["PanNo"] == null ? "" : Convert.ToString(objSqlDataReader["PanNo"]);
                        ObjUserInf.RoleId = objSqlDataReader["ROLEID"] == null ? "" : Convert.ToString(objSqlDataReader["ROLEID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSqlDataReader != null && !objSqlDataReader.IsClosed)
                {
                    objSqlDataReader.Close();
                }
            }
            return ObjUserInf;
        }

        public DeptUserInfo GetDeptUserInfo(string UserName, string Password, string IPAdrs)
        {
            SqlDataReader objSqlDataReader = null;
            var ObjDeptUserInfo = new DeptUserInfo();

            try
            {

                SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@UserName",UserName),
                new SqlParameter("@PWD",Password),
                new SqlParameter("@IPADDRESS",IPAdrs)
                };
                objSqlDataReader = SqlHelper.ExecuteReader(connstr, LoginConstants.ValidateMasterUser, param);

                if (objSqlDataReader != null && objSqlDataReader.HasRows)
                {
                    //SELECT InvesterId, EntityName, Fullname, emailid FROM Insvester_Login WHERE emailid = @emailid AND pwd = @PWD

                    while (objSqlDataReader.Read())
                    {
                        ObjDeptUserInfo.UserID = objSqlDataReader["USERID"] == null ? "" : Convert.ToString(objSqlDataReader["USERID"]);
                        ObjDeptUserInfo.UserName = objSqlDataReader["USERNAME"] == null ? "" : Convert.ToString(objSqlDataReader["USERNAME"]);
                        ObjDeptUserInfo.UserStatus = objSqlDataReader["USERSTATUS"] == null ? "" : Convert.ToString(objSqlDataReader["USERSTATUS"]);
                        ObjDeptUserInfo.Roleid = objSqlDataReader["Roleid"] == null ? "" : Convert.ToString(objSqlDataReader["Roleid"]);
                        ObjDeptUserInfo.Deptid = objSqlDataReader["Deptid"] == null ? "" : Convert.ToString(objSqlDataReader["Deptid"]);
                        //ObjDeptUserInfo.EntityName = objSqlDataReader["EntityName"] == null ? "" : Convert.ToString(objSqlDataReader["EntityName"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSqlDataReader != null && !objSqlDataReader.IsClosed)
                {
                    objSqlDataReader.Close();
                }
            }
            return ObjDeptUserInfo;
        }
        public int LogUserLoginHistory(string Userid, string IP)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Userid",Userid),
                new SqlParameter("@IP",IP)
                };
                return SqlHelper.ExecuteNonQuery(connstr, LoginConstants.UserLogHistory, param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<UserOptions> GetUserOptions(string roleID, string userId)
        //{
        //    List<UserOptions> portalUserOptionList = new List<UserOptions>();
        //    SqlDataReader drOptions = null;
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[] {
        //        new SqlParameter("@v_roleID",roleID),
        //        new SqlParameter("@v_userId",userId)
        //        };

        //        drOptions = SqlHelper.ExecuteReader(connstr, LoginSPName.UserOptions, param);

        //        if (drOptions != null && drOptions.HasRows)
        //        {
        //            while (drOptions.Read())
        //            {
        //                var portalUserOption = new UserOptionsEnt()
        //                {
        //                    OptionId = Convert.ToString(drOptions["OPTION_ID"]),
        //                    OptionName = Convert.ToString(drOptions["OPTION_NAME"]),
        //                    GroupName = Convert.ToString(drOptions["GROUP_NAME"]),
        //                    Url = Convert.ToString(drOptions["URL"])
        //                };
        //                portalUserOptionList.Add(portalUserOption);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (drOptions != null)
        //        {
        //            drOptions.Close();
        //        }
        //    }
        //    return portalUserOptionList;
        //}
    }
}
