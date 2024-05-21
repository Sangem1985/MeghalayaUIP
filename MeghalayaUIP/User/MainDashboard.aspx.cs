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
                //if (lnkbtn.Text != "0")
                //{
                //    LinkButton lnkbtn = (LinkButton)sender;
                //    lnkbtn.Style["text-decoration"] = "none";
                //}
            }
            catch (Exception ex)
            {
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

                h1.NavigateUrl = "~/IndustryRegistrationUserDashboard.aspx?Unit=" + hdnUserID.Value + "&Module=MIIPP";

                HyperLink h2 = (HyperLink)e.Row.Cells[5].Controls[0];

                h2.NavigateUrl = "DashboardDrill.aspx?Unit=" + hdnUserID.Value + "&Module=PreEstablishment";

                HyperLink h3 = (HyperLink)e.Row.Cells[6].Controls[0];

                h3.NavigateUrl = "DashboardDrill.aspx?Unit=" + hdnUserID.Value + "&Module=PreOperational";

                HyperLink h4 = (HyperLink)e.Row.Cells[7].Controls[0];

                h4.NavigateUrl = "DashboardDrill.aspx?Unit=" + hdnUserID.Value + "&Module=Incentives";



            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {              

            //    e.Row.Cells[1].Text = "Total";
            //    // Label lblTotal = new Label();
            //    HyperLink Total = new HyperLink();
            //    Total.ForeColor = System.Drawing.Color.White;
            //    Total.NavigateUrl = "FrmDistDrilldownold2New.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Total Applications Received&dist=" + district + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            //    Total.Text = NumberTotal.ToString();
            //    //e.Row.Cells[2].Controls.RemoveAt(0);
            //    //lblTotal.Text = NumberTotal.ToString();
            //    e.Row.Cells[2].Text = NumberTotal.ToString();
            //    e.Row.Cells[2].Controls.Add(Total);
            //    // e.Row.Cells[2].Controls.Add(lblTotal);
            //    //e.Row.Cells[2].Text = NumberTotal.ToString();
            //    e.Row.Cells[3].Text = InvestmnetTotal.ToString();
            //    e.Row.Cells[4].Text = EmploymentTotal.ToString();
                //lblTotal.Visible = false;
            }
        }
    }
}