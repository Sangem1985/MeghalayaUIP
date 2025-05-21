using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;

namespace MeghalayaUIP
{
    public partial class WaterDashboard : System.Web.UI.Page
    {
        MasterBAL masterBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                string Type = ddlMunicipalBoard.SelectedValue.ToString();
                dsnew = masterBAL.GetWaterDashBoardReport(Type);
                if (dsnew.Tables.Count > 0)
                {
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {
                        gvWaterQuality.DataSource = dsnew.Tables[0];
                        gvWaterQuality.DataBind();
                    }
                    else
                    {
                        gvWaterQuality.DataSource = null;
                        gvWaterQuality.DataBind();
                    }
                }

                LBLDATETIME.Text = System.DateTime.Now.ToString();
            }
            catch (Exception ex)
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