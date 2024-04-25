using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    public class UserRegDetails
    {
        public string Fullname { get; set; }
        public string PANno { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string State { get; set; }
        public string DateofBirth { get; set; }
        public string IPAddress { get; set; }

    }
    public class UserInfo
    {
        public string Userid { get; set; }
        public string Fullname { get; set; }
        public string PANno { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string EntityName { get; set; }

    }
    public class UserOptions
    {
        public string Userid { get; set; }
        public string Fullname { get; set; }
        public string PANno { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string EntityName { get; set; }

    }
    public class DeptUserInfo
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserStatus { get; set; }
        public string Roleid { get; set; }
        public string Deptid { get; set; }
    }
}
