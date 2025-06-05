using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class Document : System.Web.UI.UserControl
    {

        public string DocumentUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Document"] != null)
                {
                    DocumentUrl = Session["Document"].ToString();
                    DataBind();
                }
            }
        }
    }

}