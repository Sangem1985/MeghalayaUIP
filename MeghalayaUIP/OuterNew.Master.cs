using MeghalayaUIP.BAL.CommonBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class OuterNew : System.Web.UI.MasterPage
    {
        MasterBAL masterball = new MasterBAL();
        protected string MeghalayaNextVision2028 { get; set; }
        protected string MeghalayaTourism { get; set; }
        protected string ITPolicy2024 { get; set; }
        protected string MeghalayaPowerPolicy { get; set; }
        protected string MeghalayaMicroSmallEnterprises { get; set; }
        protected string MeghalayaStartupPolicy { get; set; }
        protected string MinesandMineralsPolicy { get; set; }
        protected string EducationPolicy { get; set; }
        protected string HealthPolicy { get; set; }
        protected string TelecominfrastructurePolicy { get; set; }
        protected string OrganicFarmingpolicy { get; set; }
        protected string SportsPolicy { get; set; }
        protected string PPPPolicy { get; set; }
        protected string EVPolicy { get; set; }
        protected string MIIPP2024 { get; set; }
        protected string Decriminalizationlist { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.Url.ToString().Contains("localhost"))
                masterball.InsPageAccessed("", "", Request.Url.ToString(), getclientIP(), "");

            MeghalayaNextVision2028 = masterball.EncryptFilePath("D:/Meghalaya/Documents/Meghalaya Next Vision 2028.pdf");
            MeghalayaTourism = masterball.EncryptFilePath("D:/Meghalaya/Documents/Meghalaya Tourism.pdf");
            ITPolicy2024 = masterball.EncryptFilePath("D:/Meghalaya/Documents/ITPolicy2024.pdf");
            MeghalayaPowerPolicy = masterball.EncryptFilePath("D:/Meghalaya/Documents/MeghalayaPowerPolicy.pdf");
            MeghalayaStartupPolicy = masterball.EncryptFilePath("D:/Meghalaya/Documents/Meghalaya Startup Policy.pdf");
            MinesandMineralsPolicy = masterball.EncryptFilePath("D:/Meghalaya/Documents/Mines and Minerals Policy.pdf");
            EducationPolicy = masterball.EncryptFilePath("D:/Meghalaya/Documents/Education Policy.pdf");
            HealthPolicy = masterball.EncryptFilePath("D:/Meghalaya/Documents/Health Policy.pdf");
            TelecominfrastructurePolicy = masterball.EncryptFilePath("D:/Meghalaya/Documents/Telecom infrastructure Policy.pdf");
            OrganicFarmingpolicy = masterball.EncryptFilePath("D:/Meghalaya/Documents/Organic Farming policy.pdf");
            SportsPolicy = masterball.EncryptFilePath("D:/Meghalaya/Documents/Sports Policy.pdf");
            PPPPolicy = masterball.EncryptFilePath("D:/Meghalaya/Documents/PPP Policy.pdf");
            EVPolicy = masterball.EncryptFilePath("D:/Meghalaya/Documents/EV Policy.pdf");
            MIIPP2024 = masterball.EncryptFilePath("D:/Meghalaya/Documents/MIIPP 2024.pdf");
            Decriminalizationlist = masterball.EncryptFilePath("D:/Meghalaya/Documents/Decriminalization list (1) (1).pdf");
            MeghalayaMicroSmallEnterprises = masterball.EncryptFilePath("D:/Meghalaya/Documents/Procure MSME.pdf");

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