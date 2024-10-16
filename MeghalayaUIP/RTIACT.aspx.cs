using MeghalayaUIP.BAL.CommonBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class RTIACT : System.Web.UI.Page
    {
        MasterBAL masterball = new MasterBAL();
        protected string MIIPP2024 { get; set; }
        protected string MSIPFACT2024 { get; set; }
        protected string AppointmentShriPBakshiIASCEO { get; set; }
        protected string AppointmentShriRChitturiIASCEO { get; set; }
        protected string AppointmentDrVijayKumarCEO { get; set; }
        protected string AppointmentShriKHynniewtaCAO { get; set; }
        protected string ConstitutionDistrictInvestmentCommittee { get; set; }
        protected string ConstitutionGoverningCouncil { get; set; }
        protected string ConstitutionHighPoweredCommittee { get; set; }
        protected string ConstitutionStateInvestmentCommittee { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.Url.ToString().Contains("localhost"))
                masterball.InsPageAccessed("", "", Request.Url.ToString(), getclientIP(), "");

            MIIPP2024 = masterball.EncryptFilePath("D:/Meghalaya/Documents/MIIPP%202024.pdf");
            MSIPFACT2024 = masterball.EncryptFilePath("D:/Meghalaya/Documents/RTIACT/MSIPF Act 2024.pdf");
            AppointmentShriPBakshiIASCEO = masterball.EncryptFilePath("D:/Meghalaya/Documents/RTIACT/Additional and Jt CEO Notification IMA.pdf");
            AppointmentShriRChitturiIASCEO = masterball.EncryptFilePath("D:/Meghalaya/Documents/RTIACT/Additional and Jt CEO Notification IMA (1).pdf");
            AppointmentDrVijayKumarCEO = masterball.EncryptFilePath("D:/Meghalaya/Documents/RTIACT/CEO Notification.pdf");
            AppointmentShriKHynniewtaCAO = masterball.EncryptFilePath("D:/Meghalaya/Documents/RTIACT/1. Notification of CAO.pdf");
            ConstitutionDistrictInvestmentCommittee = masterball.EncryptFilePath("D:/Meghalaya/Documents/RTIACT/1. District Investment Committeee Notification No.PLR-22-2024-109 dated 14.03.2024_0001.pdf");
            ConstitutionGoverningCouncil = masterball.EncryptFilePath("D:/Meghalaya/Documents/RTIACT/2. Governing Council Notification No.PLR-22-2024-100 dated 14.03.2024_0001.pdf");
            ConstitutionHighPoweredCommittee = masterball.EncryptFilePath("D:/Meghalaya/Documents/RTIACT/3. HPC Notification No.PLR-22-2024-103 dated 14.03.2024_0001.pdf");
            ConstitutionStateInvestmentCommittee = masterball.EncryptFilePath("D:/Meghalaya/Documents/RTIACT/4. State Investment Committee Notification No.PLR-22-2024-106 dated 14.03.2024_0001.pdf");
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