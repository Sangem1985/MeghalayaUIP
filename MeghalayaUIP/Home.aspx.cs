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
        protected void Page_Load(object sender, EventArgs e)
        {
            IncentivePackageDemo027082024 = objmgbal.EncryptFilePath("D:/Meghalaya/Documents/Incentive Package Demo 027082024.pdf");
        }
    }
}