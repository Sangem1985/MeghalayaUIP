using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class DocUserControl : System.Web.UI.UserControl
    {
        public string DocumentUrl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            DocumentUrl = "~/Documents/3drparty_NA2.pdf";

            if (!string.IsNullOrEmpty(DocumentUrl))
            {
                litPdfObject.Text = $@"
            <object type='application/pdf' data='{ResolveUrl(DocumentUrl)}' width='50%' height='600px'>               
               
            </object>";
            }

        }
    }
}