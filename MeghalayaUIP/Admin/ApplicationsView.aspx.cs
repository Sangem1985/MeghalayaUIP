using MeghalayaUIP.BAL.CommonBAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Admin
{
    public partial class ApplicationsView : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        MGCommonBAL objcommon = new MGCommonBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string TypeOfApplication = ddlTypeApplication.SelectedItem.Text;
                string Invester = txtInvester.Value.ToString();
                string UnitName = txtUnitName.Value.ToString();

                DataSet ds = new DataSet();
                ds = objcommon.GetApplicationView(TypeOfApplication, Invester, UnitName);


                if (ds.Tables.Count > 0 || ds.Tables[0].Rows.Count > 0)
                {
                    if (ddlTypeApplication.SelectedItem.Text == "USERREG")
                    {
                        GVUser.DataSource = ds.Tables[0];
                        GVUser.DataBind();
                        User.Visible = true;
                        Industry.Visible = false;
                        CFE.Visible = false;
                        CFO.Visible = false;
                    }
                    else if (ddlTypeApplication.SelectedItem.Text == "INDUSTRY")
                    {
                        GVIndustry.DataSource = ds.Tables[0];
                        GVIndustry.DataBind();
                        Industry.Visible = true;
                        User.Visible = false;
                        CFE.Visible = false;
                        CFO.Visible = false;
                    }
                    else if (ddlTypeApplication.SelectedItem.Text == "CFE")
                    {
                        GVCFE.DataSource = ds.Tables[0];
                        GVCFE.DataBind();
                        CFE.Visible = true;
                        User.Visible = false;
                        Industry.Visible = false;
                        CFO.Visible = false;
                    }
                    else if (ddlTypeApplication.SelectedItem.Text == "CFO")
                    {
                        GVCFO.DataSource = ds.Tables[0];
                        GVCFO.DataBind();
                        CFO.Visible = true;
                        User.Visible = false;
                        Industry.Visible = false;
                        CFE.Visible = false;
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