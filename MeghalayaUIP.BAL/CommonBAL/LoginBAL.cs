﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeghalayaUIP.DAL;
using MeghalayaUIP.DAL.CommonDAL;
using MeghalayaUIP.Common;
using System.Data;

namespace MeghalayaUIP.BAL.CommonBAL
{
    public class LoginBAL
    {
        public LoginDAL objLoginDAL { get; } = new LoginDAL();

        public UserInfo GetUserInfo(string UserName, string Password, string IPAdrs)
        {
            return objLoginDAL.GetUserInfo(UserName, Password, IPAdrs);
        }
        public int LogUserLoginHistory(string User_id, string IP)
        {
            return objLoginDAL.LogUserLoginHistory(User_id, IP);
        }
        public DeptUserInfo GetDeptUserInfo(string UserName, string Password, string IPAdrs)
        {
            return objLoginDAL.GetDeptUserInfo(UserName, Password, IPAdrs);
        }
        //public List<UserOptionsEnt> GetUserOptions(string roleID, string userId)
        //{
        //    return objLoginDAL.GetUserOptions(roleID, userId);
        //}
        public DataSet ForgetPassword(string EmailId)
        {
            return objLoginDAL.ForgetPassword(EmailId);
        }
        public DataSet GetDeptUserPwdInfo(string UserName, string Type)
        {
            return objLoginDAL.GetDeptUserPwdInfo(UserName, Type);
        }
        public string UpdateLogout(string UserName, string Type)
        {
            return objLoginDAL.UpdateLogout(UserName, Type);
        }

    }

    public class UserRegBAL
    {
        public UserRegDAL URDAL { get; } = new UserRegDAL();
        public string InsertUserRegDetails(UserRegDetails Userregdtls)
        {
            return URDAL.InsertUserRegDetails(Userregdtls);
        }
    }
}
