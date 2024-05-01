using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFECommonApplication : System.Web.UI.Page
    {
        CFEBAL objcfebal = new CFEBAL(); Decimal TotalFee = 0, TotalFeeAmount = 0; string amt = "0";
        CFEQuestionnaireDet cfeqs = new CFEQuestionnaireDet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] != null)
            {
                var ObjUserInfo = new UserInfo();
                if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                {
                    ObjUserInfo = (UserInfo)Session["UserInfo"]; Session["UNITID"] = 1001;
                }
                if (hdnUserID.Value == "")
                {
                    hdnUserID.Value = ObjUserInfo.Userid;
                }
                Page.MaintainScrollPositionOnPostBack = true;
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["UNITID"]) != "")
                    {
                        DataSet dsApprovals = new DataSet();
                        cfeqs.UNITID = Convert.ToString(Session["UNITID"]);
                        cfeqs.CreatedBy = hdnUserID.Value;
                        dsApprovals = objcfebal.GetApprovalsReqFromTable(cfeqs);
                        if (dsApprovals.Tables.Count > 0)
                        {
                            if (dsApprovals.Tables[0].Rows.Count > 0)
                            {
                                grdApprovals.DataSource = dsApprovals.Tables[0];
                                grdApprovals.DataBind();
                                hdnQuestionnaireID.Value = Convert.ToString(dsApprovals.Tables[0].Rows[0]["CFEQA_CFEQDID"]);
                            }
                        }
                    }

                }

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

        }

        protected void grdApprovals_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                Label lblFee = e.Row.FindControl("lblAmounts") as Label;
                CheckBox ChkApproval = (CheckBox)e.Row.FindControl("ChkApproval");
                RadioButtonList rblAlrdyObtained = (RadioButtonList)e.Row.FindControl("rblAlrdyObtained");
                decimal Fee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFEQA_APPROVALFEE"));
                lblFee.Text = Convert.ToString(Fee);
                TotalFee = TotalFee + Fee;
                //e.Row.Cells[6].Text = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFEQA_APPROVALFEE")).ToString("#,##0");
                decimal amounts = Convert.ToDecimal(lblFee.Text.ToString());

                ChkApproval.Checked = true;
                if (ChkApproval.Checked == true && amounts != 0)
                {
                    e.Row.Cells[6].Text = e.Row.Cells[3].Text;
                }
                if (e.Row.Cells[6].Text != "" && amounts != 0)
                {
                    decimal TotalFeeAmount1 = Convert.ToDecimal(e.Row.Cells[6].Text);
                    TotalFeeAmount = TotalFeeAmount + TotalFeeAmount1;
                    if (e.Row.Cells[6].Text != "")
                        e.Row.Cells[6].Text = Convert.ToDecimal(e.Row.Cells[6].Text).ToString("#,##0");
                }
            }
            if ((e.Row.RowType == DataControlRowType.Footer))
            {
                e.Row.Cells[2].Text = "Total Fee";
                e.Row.Cells[3].Text = TotalFee.ToString("#,##0");
                e.Row.Cells[5].Text = "Total Fee";
                e.Row.Cells[6].Text = TotalFee.ToString("#,##0");

            }

        }

        protected void rblAlrdyObtained_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
        {
            decimal amount = Convert.ToDecimal("0.00");
            CheckBox ChkApproval = (CheckBox)sender;
            GridViewRow row = (GridViewRow)ChkApproval.NamingContainer;
            if (ChkApproval.Checked == true)
            {
                row.Cells[6].Text = row.Cells[3].Text;
            }
            else
            {
                row.Cells[6].Text = "0";
            }
            foreach (GridViewRow row1 in grdApprovals.Rows)
            {
                if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                {
                    //if (row1.Cells[6].Text == "")
                    //{
                    //    if (row1.Cells[3].Text != "")

                    row1.Cells[6].Text = row1.Cells[3].Text;
                    //    else
                    //        row1.Cells[6].Text = "0";
                    //}
                    amount = amount + Convert.ToDecimal(row1.Cells[6].Text);

                }
                else if (row1.Cells[6].Text != "")
                    row1.Cells[6].Text = Convert.ToDecimal(0).ToString("#,##0");
            }
            int Rowindex = row.RowIndex;
            int totalRowindex = grdApprovals.Rows.Count;

            while (Rowindex < totalRowindex)
            {
                grdApprovals.Rows[Rowindex].Cells[6].Text = grdApprovals.Rows[Rowindex].Cells[3].Text;
                grdApprovals.Rows[Rowindex].Cells[6].Text = string.Format("{0:N0}", grdApprovals.Rows[Rowindex].Cells[6].Text.ToString());
                Rowindex = Rowindex + 1;
            }
            if ((row.RowType == DataControlRowType.Footer))
            {
                row.Cells[5].Text = "Total Fee";
                row.Cells[6].Text = amount.ToString("#,##0");
            }

            grdApprovals.FooterRow.Cells[6].Text = Convert.ToDecimal(amount).ToString("#,##0");
        }
    }
}