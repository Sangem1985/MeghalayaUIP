using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.BAL.CommonBAL;

namespace MeghalayaUIP
{
    public partial class Home : System.Web.UI.Page
    {
        MasterBAL objmgbal = new MasterBAL();
        protected string IncentivePackageDemo027082024 { get; set; }
        protected string unnati2024 { get; set; }
        protected string mipp2024 { get; set; }
        static string connStr = ConfigurationManager.ConnectionStrings["MIPASS"].ConnectionString;
        private static readonly ObjectCache Cache = MemoryCache.Default;
        // string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            Killsession();
            IncentivePackageDemo027082024 = objmgbal.EncryptFilePath("D:/Meghalaya/Documents/Incentive Package Demo 027082024.pdf");
            unnati2024 = objmgbal.EncryptFilePath("D:/Meghalaya/Documents/unnati2024.pdf");
            mipp2024 = objmgbal.EncryptFilePath("D:/Meghalaya/Documents/mipp2024.pdf");
            if (Session.Count != 0)
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();

                if (!Page.IsPostBack)
                    Session.Abandon();
            }
        }
        public void Killsession()
        {

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {

                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;

                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);

            }
            if (Request.Cookies["ASP.NET_SessionIdTemp"] != null)
            {
                Response.Cookies["ASP.NET_SessionIdTemp"].Value = string.Empty;

                Response.Cookies["ASP.NET_SessionIdTemp"].Expires = DateTime.Now.AddMonths(-20);
            }

            if (Request.Cookies["AuthToken"] != null)
            {

                Response.Cookies["AuthToken"].Value = string.Empty;

                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);

            }
            if (Request.Cookies["__AntiXsrfToken"] != null)
            {

                Response.Cookies["__AntiXsrfToken"].Value = string.Empty;

                Response.Cookies["__AntiXsrfToken"].Expires = DateTime.Now.AddMonths(-20);

            }
            Session.Abandon();
            Session.Clear();

            var manager = new System.Web.SessionState.SessionIDManager();
            string newSessionId = manager.CreateSessionID(HttpContext.Current);
            bool isRedirected = false;
            bool isAdded = false;
            manager.SaveSessionID(HttpContext.Current, newSessionId, out isRedirected, out isAdded);

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoStore();
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);

            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetExpires(DateTime.Now);
            //Response.Cache.SetNoStore();
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);

        }      
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetModules()
        {
            string key = "chat_modules_v1";
            var cached = Cache.Get(key) as List<string>;
            if (cached != null) return cached;

            var modules = new List<string>();
            try
            {
                using (var con = new SqlConnection(connStr))
                using (var cmd = new SqlCommand("USP_GET_MODULES", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                            modules.Add(rdr["MODULE"]?.ToString());
                    }
                }
                Cache.Set(key, modules, DateTimeOffset.Now.AddMinutes(10)); 
            }
            catch (Exception ex)
            {
                modules = new List<string>();
            }
            return modules;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<QuestionModel> GetQuestions(string module)
        {
            string key = "chat_questions_v1_" + (module ?? "").Trim();
            var cached = Cache.Get(key) as List<QuestionModel>;
            if (cached != null) return cached;

            var list = new List<QuestionModel>();
            try
            {
                using (var con = new SqlConnection(connStr))
                using (var cmd = new SqlCommand("USP_GET_QUESTIONS_BY_MODULE", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Module", module ?? "");
                    con.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            list.Add(new QuestionModel
                            {
                                SLNO = Convert.ToInt32(rdr["SLNO"]),
                                QUESTION = rdr["QUESTION"]?.ToString()
                            });
                        }
                    }
                }
                Cache.Set(key, list, DateTimeOffset.Now.AddMinutes(10)); 
            }
            catch (Exception ex)
            {
                list = new List<QuestionModel>();
            }
            return list;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetAnswer(int slno)
        {
            string key = "chat_answer_v1_" + slno;
            var cached = Cache.Get(key) as string;
            if (cached != null) return cached;

            string answer = string.Empty;
            try
            {
                using (var con = new SqlConnection(connStr))
                using (var cmd = new SqlCommand("USP_GET_ANSWER_BY_ID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SLNO", slno);
                    con.Open();
                    var o = cmd.ExecuteScalar();
                    answer = (o == null || o == DBNull.Value) ? "" : o.ToString();
                }
                Cache.Set(key, answer, DateTimeOffset.Now.AddMinutes(30)); 
            }
            catch (Exception ex)
            {
                answer = "";
            }
            return answer;
        }

        public class QuestionModel
        {
            public int SLNO { get; set; }
            public string QUESTION { get; set; }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static void RecordChatbotClick()
        {
            try
            {
                string ipAddress = getclientIP();
                using (SqlConnection con = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("USP_INSCHATBOTCLICK", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IPADDRESS", ipAddress);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static string getclientIP()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return result;
        }

    }
}