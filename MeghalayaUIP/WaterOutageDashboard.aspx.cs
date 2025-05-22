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
    public partial class WaterOutageDashboard : System.Web.UI.Page
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
                dsnew = masterBAL.GetWaterOutageDashBoard(Type);
                if (dsnew.Tables.Count > 0)
                {
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {                    

                        GVWater.DataSource = dsnew.Tables[0];
                        GVWater.DataBind();
                    }
                    else
                    {                       
                        GVWater.DataSource = dsnew;
                        GVWater.DataBind();


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
            try
            {
                Binddata();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}