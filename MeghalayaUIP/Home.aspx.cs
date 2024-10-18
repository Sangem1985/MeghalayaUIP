using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            IncentivePackageDemo027082024 = objmgbal.EncryptFilePath("D:/Meghalaya/Documents/Incentive Package Demo 027082024.pdf");
            unnati2024= objmgbal.EncryptFilePath("D:/Meghalaya/Documents/unnati2024.pdf");
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
    }
}