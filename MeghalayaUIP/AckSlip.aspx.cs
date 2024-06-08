using MeghalayaUIP.BAL.CommonBAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class AckSlip : System.Web.UI.Page
    {
        MasterBAL masterBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                string UnitId = Request.QueryString["UnitId"].ToString();
                string AppType = Request.QueryString["AppType"].ToString();
                DataSet dsnew = new DataSet();
                dsnew = masterBAL.GetAcknowlegementDetails(UnitId, AppType);
                if (dsnew.Tables.Count > 0)
                {
                    DateTime dateTime = DateTime.UtcNow.Date;
                    lblDate.InnerHtml = dateTime.ToString("dd/MM/yyyy");
                    lblEnterPrise.InnerText = "Dear " + dsnew.Tables[0].Rows[0]["NAMEOFUNIT"].ToString();
                    lblUIDNo.InnerText = dsnew.Tables[0].Rows[0]["UIDNO"].ToString();
                }
            }
        }
    }
}