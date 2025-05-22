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
                        gvWaterQuality.DataSource = dsnew;
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

        protected void gvWaterQuality_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvHeaderRow = e.Row;
                GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                this.gvWaterQuality.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

                int headerCellCount = gvHeaderRow.Cells.Count;
                int cellIndex = 0;

                for (int i = 0; i < headerCellCount; i++)
                {
                    if (i == 4 || i == 5 || i == 6 || i == 7|| i == 8 || i == 9 || i == 10 || i == 11|| i == 12 || i == 13 )
                    {
                        cellIndex++;
                    }
                    else
                    {
                        TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                        tcHeader.RowSpan = 2;
                        gvHeaderRowCopy.Cells.Add(tcHeader);
                    }
                }

                TableCell tcMergePackage = new TableCell();
                tcMergePackage.Text = "pH@ 25°C";
                tcMergePackage.Font.Bold = true;
                tcMergePackage.ForeColor = System.Drawing.Color.White;
                tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage.ColumnSpan = 1;
                tcMergePackage.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E73BE");
                gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage);

                TableCell tcMergePackage1 = new TableCell();
                tcMergePackage1.Text = "TDS (mg/L)";
                tcMergePackage1.Font.Bold = true;
                tcMergePackage1.ForeColor = System.Drawing.Color.White;
                tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage1.ColumnSpan = 1;
                tcMergePackage1.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E73BE");
                gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage1);

                TableCell tcMergePackage2 = new TableCell();
                tcMergePackage2.Text = "Iron (mg/L)";
                tcMergePackage2.Font.Bold = true;
                tcMergePackage2.ForeColor = System.Drawing.Color.White;
                tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage2.ColumnSpan = 1;
                tcMergePackage2.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E73BE");

                gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage2);

                TableCell tcMergePackage3 = new TableCell();
                tcMergePackage3.Text = "Turbidity(NTU)";
                tcMergePackage3.Font.Bold = true;
                tcMergePackage3.ForeColor = System.Drawing.Color.White;
                tcMergePackage3.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage3.ColumnSpan = 1;
                tcMergePackage3.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E73BE");

                gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage3);


                TableCell tcMergePackage4 = new TableCell();
                tcMergePackage4.Text = "Fluoride (mg/L)";
                tcMergePackage4.Font.Bold = true;
                tcMergePackage4.ForeColor = System.Drawing.Color.White;
                tcMergePackage4.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage4.ColumnSpan = 1;
                tcMergePackage4.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E73BE");

                gvHeaderRowCopy.Cells.AddAt(8, tcMergePackage4);

                TableCell tcMergePackage5 = new TableCell();
                tcMergePackage5.Text = "Chloride (mg/L)";
                tcMergePackage5.Font.Bold = true;
                tcMergePackage5.ForeColor = System.Drawing.Color.White;
                tcMergePackage5.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage5.ColumnSpan = 1;
                tcMergePackage5.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E73BE");

                gvHeaderRowCopy.Cells.AddAt(9, tcMergePackage5);

                TableCell tcMergePackage6 = new TableCell();
                tcMergePackage6.Text = "Alkalinity (mg/ L)";
                tcMergePackage6.Font.Bold = true;
                tcMergePackage6.ForeColor = System.Drawing.Color.White;
                tcMergePackage6.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage6.ColumnSpan = 1;
                tcMergePackage6.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E73BE");

                gvHeaderRowCopy.Cells.AddAt(10, tcMergePackage6);

                TableCell tcMergePackage7 = new TableCell();
                tcMergePackage7.Text = "Arsenic (mg/L)";
                tcMergePackage7.Font.Bold = true;
                tcMergePackage7.ForeColor = System.Drawing.Color.White;
                tcMergePackage7.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage7.ColumnSpan = 1;
                tcMergePackage7.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E73BE");

                gvHeaderRowCopy.Cells.AddAt(11, tcMergePackage7);

                TableCell tcMergePackage8 = new TableCell();
                tcMergePackage8.Text = "Residual Free Chorine (mg/L)";
                tcMergePackage8.Font.Bold = true;
                tcMergePackage8.ForeColor = System.Drawing.Color.White;
                tcMergePackage8.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage8.ColumnSpan = 1;
                tcMergePackage8.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E73BE");

                gvHeaderRowCopy.Cells.AddAt(12, tcMergePackage8);

                TableCell tcMergePackage9 = new TableCell();
                tcMergePackage9.Text = "Total Hardness (mg/L)";
                tcMergePackage9.Font.Bold = true;
                tcMergePackage9.ForeColor = System.Drawing.Color.White;
                tcMergePackage9.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage9.ColumnSpan = 1;
                tcMergePackage9.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E73BE");

                gvHeaderRowCopy.Cells.AddAt(13, tcMergePackage9);


            }



        }
    }
}