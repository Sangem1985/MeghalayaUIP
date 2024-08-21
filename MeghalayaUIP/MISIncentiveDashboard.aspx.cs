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
    public partial class MISIncentiveDashboard : System.Web.UI.Page
    {
        MasterBAL masterBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFDate.Value = "2020-01-01";
                DateTime today = DateTime.Today;
                txtTDate.Value = today.ToString("yyyy-MM-dd");
                Binddata();
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet dsnew = new DataSet();
                string fdate = txtFDate.Value.ToString();
                string tdate = txtTDate.Value.ToString();
                dsnew = masterBAL.MISIIncentiveDashboard(fdate, tdate);
                if (dsnew.Tables.Count > 0)
                {
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {
                        gvDetails.DataSource = dsnew.Tables[0];
                        gvDetails.DataBind();
                    }
                }
                else
                {
                    gvDetails.DataSource = null;
                    gvDetails.DataBind();
                }
                LBLDATETIME.Text = System.DateTime.Now.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Binddata();
        }
    }
}