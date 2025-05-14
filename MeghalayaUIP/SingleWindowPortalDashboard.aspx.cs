using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class SingleWindowPortalDashboard : System.Web.UI.Page
    {
        MasterBAL masterBAL = new MasterBAL();
        SMSandMail smsMail = new SMSandMail();
        int total = 0;
        int TOTALAPPLICATIONSRCVD = 0;
        int TOTALAPPROVRED = 0;
        int TOTALREJECTED = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string fullUrl = Request.Url.AbsoluteUri;
            string[] segments = Request.Url.Segments;
            if (!IsPostBack)
            {
                BindDepartments();
                Binddata();
                /*smsMail.SendEmail("1001", "1002", "Dash", "Board");
                smsMail.SendSms("1033", "1011", "1407172584852269031", "REG","");*/
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet dsnew = new DataSet();
                string fdate = txtFDate.Value.ToString();
                string tdate = txtTDate.Value.ToString();
                string DeptId = ddlDept.SelectedValue.ToString();
                dsnew = masterBAL.GetSingleWindowDepts(fdate, tdate, DeptId);
                if (dsnew.Tables.Count > 0)
                {
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {
                        gvDepts.DataSource = dsnew.Tables[0];
                        gvDepts.DataBind();
                    }
                }
                else
                {
                    gvDepts.DataSource = null;
                    gvDepts.DataBind();
                }
                LBLDATETIME.Text = System.DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindDepartments()
        {
            try
            {
                ddlDept.Items.Clear();
                DataSet dsnew = new DataSet();
                string fdate = txtFDate.Value.ToString();
                string tdate = txtTDate.Value.ToString();
                dsnew = masterBAL.GetSingleWindowDepts(fdate, tdate,"");
                if (dsnew.Tables.Count > 0)
                {
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {
                        ddlDept.DataSource = dsnew.Tables[0];
                        ddlDept.DataValueField = "TMD_DEPTID";
                        ddlDept.DataTextField = "TMD_DeptName";
                        ddlDept.DataBind();
                    }
                }
                else
                {
                    ddlDept.DataSource = null;
                    ddlDept.DataBind();
                }

                AddSelect(ddlDept);
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

        protected void gvDepts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string DeptId = gvDepts.DataKeys[e.Row.RowIndex].Value.ToString();
                    GridView gvApprovals = e.Row.FindControl("gvApprovals") as GridView;

                    DataSet dsnew = new DataSet();
                    string fdate = txtFDate.Value.ToString();
                    string tdate = txtTDate.Value.ToString();
                    dsnew = masterBAL.GetSingleWindowApprovals(fdate, tdate,DeptId);
                    if (dsnew.Tables.Count > 0)
                    {
                        if (dsnew.Tables[0].Rows.Count > 0)
                        {
                            TOTALAPPLICATIONSRCVD = 0; TOTALAPPROVRED = 0; TOTALREJECTED = 0;
                            gvApprovals.DataSource = dsnew.Tables[0];
                            gvApprovals.DataBind();
                        }
                    }
                    else
                    {
                        gvApprovals.DataSource = null;
                        gvApprovals.DataBind();
                    }

                    Label lblDeptid = (Label)e.Row.FindControl("lblDeptid");
                    LinkButton lnkApplProcess = (LinkButton)e.Row.FindControl("lblApplProcess");
                    LinkButton lnkAlprocess = (LinkButton)e.Row.FindControl("lblAlprocess");
                    string Departmentname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TMD_DeptName")).Trim();

                    if (lnkApplProcess.Text != "0")
                        lnkApplProcess.PostBackUrl = "SingleWindowPortalDashboardDrillDown.aspx?Depatid=" + lblDeptid.Text + "&FromDate=" + txtFDate.Value + "&ToDate=" + txtTDate.Value + "&ViewType=TOTALAPPLICATIONSRCVD" + "&Departmentname=" + Departmentname;

                    if (lnkAlprocess.Text != "0")
                        lnkAlprocess.PostBackUrl = "SingleWindowPortalDashboardDrillDown.aspx?Depatid=" + lblDeptid.Text + "&FromDate=" + txtFDate.Value + "&ToDate=" + txtTDate.Value + "&ViewType=TOTALPROCESSED" +  "&Departmentname=" + Departmentname;

                }
            }
            catch
            {

            }
        }

        protected void gvApprovals_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int TOTALAPPLICATIONSRCVD1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTALAPPLICATIONSRCVD"));
                TOTALAPPLICATIONSRCVD = TOTALAPPLICATIONSRCVD1 + TOTALAPPLICATIONSRCVD;

                int TOTALAPPROVRED1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTALAPPROVRED"));
                TOTALAPPROVRED = TOTALAPPROVRED1 + TOTALAPPROVRED;

                int TOTALREJECTED1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTALREJECTED"));
                TOTALREJECTED = TOTALREJECTED1 + TOTALREJECTED;

               /* int TOTALAPPLICATIONSRCVD = Convert.ToInt32((e.Row.FindControl("lblTOTALAPPLICATIONSRCVD") as Label).Text);
                total += TOTALAPPLICATIONSRCVD;
                grandTotal += freight;*/
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Text = "Total :";
                e.Row.Cells[3].Text = TOTALAPPLICATIONSRCVD.ToString();
                e.Row.Cells[4].Text = TOTALAPPROVRED.ToString();
                e.Row.Cells[5].Text = TOTALREJECTED.ToString();
                TOTALAPPLICATIONSRCVD = 0; TOTALAPPROVRED = 0; TOTALREJECTED = 0;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Binddata();
        }
    }
}