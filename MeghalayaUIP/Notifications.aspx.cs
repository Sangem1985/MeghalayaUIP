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
        protected void Page_Load(object sender, EventArgs e)
        {
            Notification_6May2022 = mbal.EncryptFilePath("D:/Meghalaya/Documents/Notification_6May2022.pdf");

        }
    }
}