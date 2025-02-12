using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.BAL.CommonBAL;


namespace MeghalayaUIP
{
    public partial class Notifications : System.Web.UI.Page
    {
        MasterBAL mbal = new MasterBAL();
        protected string Notification_6May2022;
        protected string Notification_29July2021;
        protected string MRPSA_2020;
        protected string Labour_29012021;

        protected string Taxation_GST_Centers;
        protected string GO_UrbanAffairs_19012021;
        protected string OO_Excise_18012021;
        protected string Transport_15012021;

        protected string Tourism_11012021;
        protected string Power_23122020;
        protected string UrbanAffairs;
        protected string CIBF_27012021;

        protected string LabourCommissioner;
        protected string Drugs;
        protected string LegalMetrology;
        protected string GO_CS_1;

        protected string ERTS_MAAAR_04022020;
        protected string ERTS_MARA_10082018;
        //protected string NoUAU1102020Pt11_dated15thOctober2024;
        //protected string NoUAU1102020Pt10_dated15thOctober2024;
        //protected string NoDUAUR132019307dated10thOctober2024;

        protected void Page_Load(object sender, EventArgs e)
        {
            Notification_6May2022 = mbal.EncryptFilePath("D:/Meghalaya/Documents/Notification_6May2022.pdf");
            Notification_29July2021 = mbal.EncryptFilePath("D:/Meghalaya/Documents/Notification_29July2021.pdf");
            MRPSA_2020 = mbal.EncryptFilePath("D:/Meghalaya/Documents/MRPSA_2020.pdf");
            Labour_29012021 = mbal.EncryptFilePath("D:/Meghalaya/Documents/Labour_29012021.pdf");
            Taxation_GST_Centers = mbal.EncryptFilePath("D:/Meghalaya/Documents/Taxation_GST_Centers.pdf");
            GO_UrbanAffairs_19012021 = mbal.EncryptFilePath("D:/Meghalaya/Documents/GO_UrbanAffairs_19012021.pdf");
            OO_Excise_18012021 = mbal.EncryptFilePath("D:/Meghalaya/Documents/OO_Excise_18012021.pdf");
            Transport_15012021 = mbal.EncryptFilePath("D:/Meghalaya/Documents/Transport_15012021.pdf");
            Tourism_11012021 = mbal.EncryptFilePath("D:/Meghalaya/Documents/Tourism_11012021.pdf");
            Power_23122020 = mbal.EncryptFilePath("D:/Meghalaya/Documents/Power_23122020.pdf");
            UrbanAffairs = mbal.EncryptFilePath("D:/Meghalaya/Documents/UrbanAffairs.pdf");
            CIBF_27012021 = mbal.EncryptFilePath("D:/Meghalaya/Documents/CIBF_27012021.pdf");
            LabourCommissioner = mbal.EncryptFilePath("D:/Meghalaya/Documents/LabourCommissioner.pdf");
            Drugs = mbal.EncryptFilePath("D:/Meghalaya/Documents/Drugs.pdf");
            LegalMetrology = mbal.EncryptFilePath("D:/Meghalaya/Documents/LegalMetrology.pdf");
            GO_CS_1 = mbal.EncryptFilePath("D:/Meghalaya/Documents/GO_CS_1.pdf");
            ERTS_MAAAR_04022020 = mbal.EncryptFilePath("D:/Meghalaya/Documents/ERTS_MAAAR_04022020.pdf");
            ERTS_MARA_10082018 = mbal.EncryptFilePath("D:/Meghalaya/Documents/ERTS_MARA_10082018.pdf");
            //NoUAU1102020Pt11_dated15thOctober2024 = mbal.EncryptFilePath("D:/Meghalaya/Documents/Urban Affairs Dept[NoUAU1102020Pt11dated15thOctober2024].pdf");
            //NoUAU1102020Pt10_dated15thOctober2024 = mbal.EncryptFilePath("D:/Meghalaya/Documents/Urban Affairs Dept[NoUAU1102020Pt10dated15thOctober2024].pdf");
            //NoDUAUR132019307dated10thOctober2024 = mbal.EncryptFilePath("D:/Meghalaya/Documents/Urban Affairs DeptNA2reforms[NoDUAUR132019307dated10thOctober2024].pdf");

        }
    }
}