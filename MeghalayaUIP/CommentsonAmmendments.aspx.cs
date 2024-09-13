using MeghalayaUIP.BAL.CommonBAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class CommentsonAmmendments : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString.Count > 0)
                    {
                        IframePanel.Attributes["src"] = Request.QueryString[1];

                        DataSet ds = new DataSet();
                        ds = mstrBAL.GetUserCommentsofAmmendmentsid(Convert.ToInt32(Request.QueryString[0].ToString()));
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            gvComments.DataSource = ds.Tables[0];
                            gvComments.DataBind();
                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                        {
                            trlegal.Visible = true;
                            gridlegal.DataSource = ds.Tables[1];
                            gridlegal.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}