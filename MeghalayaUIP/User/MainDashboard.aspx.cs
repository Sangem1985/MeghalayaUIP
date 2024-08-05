using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.CommonDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace MeghalayaUIP.User
{
    public partial class MainDashboard : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL indstregBAL = new PreRegBAL();
        MGCommonDAL objcommonDAL = new MGCommonDAL();
        decimal PreestablishmentTotal, PreoperationalTotal, IncentivesTotal;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserInfo"] != null)
                {
                    var ObjUserInfo = new UserInfo();
                    if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (UserInfo)Session["UserInfo"];
                        // txtPANno.Text = ObjUserInfo.PANno;
                        unitname.InnerText = ObjUserInfo.EntityName;
                        hdnUserID.Value = ObjUserInfo.Userid;
                        BindData(ObjUserInfo.Userid);

                    }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                //Failure.Visible = true;
                throw ex;
            }
        }
        protected void RegistrationMIIPPTotal_Click(object sender, EventArgs e)
        {
        }
        public void BindData(string userid)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcommonDAL.GetMainApplicantDashBoard(userid);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvUserDashboard.DataSource = ds.Tables[0];
                    gvUserDashboard.DataBind();
                }
                else
                {
                    
                    Failure.Visible = true;
                    //hplIndReg.Visible = true;
                    //hplIndReg.ForeColor = System.Drawing.Color.Green;
                    //hplIndReg.Text = "Click here to Apply Registration under MIIPP (2024)";
                    //hplIndReg.NavigateUrl = "PreReg/IndustryRegistration.aspx";
                    lblmsg0.Text = "There are no Applications to Show " ;
                    gvUserDashboard.DataSource = null;
                    gvUserDashboard.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void gvUserDashboard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal Preestablishment = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PRE_ESTB_APPROVALS"));
                PreestablishmentTotal = Preestablishment + PreestablishmentTotal;

                decimal Preoperational = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PRE_OPERATIONAL_APPROVALS"));
                PreoperationalTotal = Preoperational + PreoperationalTotal;


                decimal Incentives = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "INCENTIVES"));
                IncentivesTotal = Incentives + IncentivesTotal;

                HyperLink h1 = (HyperLink)e.Row.Cells[4].Controls[0];
                if (h1.Text != "0")
                    h1.NavigateUrl = "PreReg/IndustryRegistrationViewDetails.aspx?Unit=" + DataBinder.Eval(e.Row.DataItem, "UNITID") + "&Module=MIIPP";


                HyperLink h2 = (HyperLink)e.Row.Cells[5].Controls[0];
                if (h2.Text != "0")
                    h2.NavigateUrl = "DashboardDrill.aspx?Unit=" + DataBinder.Eval(e.Row.DataItem, "UNITID") + "&Module=PreEstablishment";

                
                HyperLink h3 = (HyperLink)e.Row.Cells[6].Controls[0];
                if (h3.Text != "0")
                    h3.NavigateUrl = "DashboardDrill.aspx?Unit=" + DataBinder.Eval(e.Row.DataItem, "UNITID") + "&Module=PreOperational";

                
                HyperLink h4 = (HyperLink)e.Row.Cells[7].Controls[0];
                if (h4.Text != "0")
                    h4.NavigateUrl = "DashboardDrill.aspx?Unit=" + DataBinder.Eval(e.Row.DataItem, "UNITID") + "&Module=Incentives";

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {

            }
        }
    }
}