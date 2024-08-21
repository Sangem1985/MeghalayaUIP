using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class CentralInspectionDashboard : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        MGCommonBAL objcommon = new MGCommonBAL();
        //  PreRegBAL indstregBAL = new PreRegBAL();
     
        int Scheduled;
        int Done;
        int Pending;
        int DoneWithin;
        int Beyond;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindYear();
                    BindMonth();
                    //  Binddata();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
          
        }
        protected void BindYear()
        {
            try
            {
                ddlYear.Items.Clear();

                List<MasterYear> objCoutryModel = new List<MasterYear>();

                objCoutryModel = mstrBAL.GetYear();
                if (objCoutryModel != null)
                {
                    ddlYear.DataSource = objCoutryModel;
                    ddlYear.DataValueField = "YEAR_ID";
                    ddlYear.DataTextField = "YEAR";
                    ddlYear.DataBind();
                }
                else
                {
                    ddlYear.DataSource = null;
                    ddlYear.DataBind();
                }
                AddSelect(ddlYear);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindMonth()
        {
            try
            {
                ddlMonth.Items.Clear();

                List<MasterMonth> objCoutryModel = new List<MasterMonth>();

                objCoutryModel = mstrBAL.GetMonth();
                if (objCoutryModel != null)
                {
                    ddlMonth.DataSource = objCoutryModel;
                    ddlMonth.DataValueField = "MONTH_ID";
                    ddlMonth.DataTextField = "MONTH_NAME";
                    ddlMonth.DataBind();
                }
                else
                {
                    ddlMonth.DataSource = null;
                    ddlMonth.DataBind();
                }
                AddSelect(ddlMonth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
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
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();

                string fYear = ddlYear.SelectedValue.ToString();              
                string tMonth = ddlMonth.SelectedValue.ToString();
                string Insepction = txtInspectionDate.Text.ToString();

                ds = objcommon.GetCentralInspection(fYear, tMonth, Insepction);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GVInspection.DataSource = ds.Tables[0];
                        GVInspection.DataBind();
                    }
                }
                else
                {
                    GVInspection.DataSource = null;
                    GVInspection.DataBind();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void GVInspection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "TMD_DEPTID").ToString() != "")
                {

                    
                    int Pending1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "INSPSCHEDULED"));
                    Scheduled = Pending1 + Scheduled;

                    int Redress1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "INSPDONE"));
                    Done = Redress1 + Done;

                    int Reject1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "INSPPENDING"));
                    Pending = Reject1 + Pending;

                    int Within = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "INSPDONEWITHIN48HRS"));
                    DoneWithin = Reject1 + DoneWithin;

                    int DoneBeyond = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "INSPDONEBEYOND48HRS"));
                    Beyond = Reject1 + Beyond;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[2].Text = "Total";
                e.Row.Cells[3].Text = Scheduled.ToString();
                e.Row.Cells[4].Text = Done.ToString();
                e.Row.Cells[5].Text = Pending.ToString();
                e.Row.Cells[6].Text = DoneWithin.ToString();
                e.Row.Cells[7].Text = Beyond.ToString();
            }
        }
    }
}