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
    public partial class GrievanceMisReportDrilldown : System.Web.UI.Page
    {
        MasterBAL masterBAL = new MasterBAL();

        string Deptid,FromDate,ToDate, ViewType,Status, Department;
             
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrievanceReport();
            }
        }
        protected void BindGrievanceReport()
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {
                    Deptid = Convert.ToString(Request.QueryString[0]);
                    FromDate = Convert.ToString(Request.QueryString[1]);
                    ToDate = Convert.ToString(Request.QueryString[2]);
                    ViewType = Convert.ToString(Request.QueryString[3]);
                    Status = Convert.ToString(Request.QueryString[4]);
                    Department = Convert.ToString(Request.QueryString[4]);

                    DataSet ds = new DataSet();

                    ds = masterBAL.GetGrievanceMisReportDrilldiwn(Deptid, FromDate, ToDate, ViewType, Status);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GVgrivancereport.DataSource = ds.Tables[0];
                        GVgrivancereport.DataBind();
                        lblStatus.Visible = true;
                        if (Status == "Pending")
                        {
                            lblStatus.InnerText = Department + " " + " " + "&" + " " + " " + FromDate + " " + " " + "In" + " " + " " + ToDate;
                        }
                        else if(Status== "Redressed")
                        {
                            lblStatus.InnerText = Department + " " + " " + "&" + " " + " " + FromDate + " " + " " + "In" + " " + " " + ToDate;
                        }
                        else if(Status== "Rejected")
                        {
                            lblStatus.InnerText = Department + " " + " " + "&" + " " + " " + FromDate + " " + " " + "In" + " " + " " + ToDate;
                        }
                        else if (Status == "%")
                        {
                            lblStatus.InnerText = "All Departments";
                        }
                    }
                    else
                    {
                        GVgrivancereport.DataSource = null;
                        GVgrivancereport.DataBind();
                    }

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                GridViewRow row = (GridViewRow)linkButton.NamingContainer;
                Label lblFilePath = (Label)row.FindControl("lblFilePath");

              //  lblbutton.Text = "View";
                if (lblFilePath != null || lblFilePath.Text != "")
                {
                    Response.Redirect("~/PdfFile.ashx?filePath=" + lblFilePath.Text); 
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/GrievanceMisReport.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                //throw ex;
            }
        }

    }
}