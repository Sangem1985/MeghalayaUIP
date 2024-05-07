using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFECommonApplication : System.Web.UI.Page
    {
        CFEBAL objcfebal = new CFEBAL(); //Decimal TotalFee = 0, TotalFeeAmount = 0; string amt = "0";
        CFEQuestionnaireDet cfeqs = new CFEQuestionnaireDet();
        decimal TotalFee, TotalFeeAmount;
        decimal amounts1;
        decimal amounts22 = 0;
        string UnitID;

        

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
                    }
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.Userid;
                    }
                    if (Convert.ToString(Session["UNITID"]) != "")
                    { 
                        UnitID = Convert.ToString(Session["UNITID"]); 
                    }
                    else
                    {
                        string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                        Response.Redirect(newurl);
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
                        else
                        {
                            string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                            Response.Redirect(newurl);
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void grdApprovals_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if ((e.Row.RowType == DataControlRowType.DataRow))
                {
                    decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFEQA_APPROVALFEE"));
                    TotalFee = TotalFee + TotalFee1;

                    HiddenField HdfAmount = (HiddenField)e.Row.FindControl("HdfAmount");
                    HiddenField HdfDeptid = (HiddenField)e.Row.FindControl("HdfDeptid");
                    HiddenField HdfQueid = (HiddenField)e.Row.FindControl("HdfQueid");
                    HiddenField HdfApprovalid = (HiddenField)e.Row.FindControl("HdfApprovalid");
                    CheckBox ChkApproval = (CheckBox)e.Row.FindControl("ChkApproval");
                    RadioButtonList rblObtained = (RadioButtonList)e.Row.FindControl("rblAlrdyObtained");

                    HdfAmount.Value = DataBinder.Eval(e.Row.DataItem, "CFEQA_APPROVALFEE").ToString().Trim();
                    HdfDeptid.Value = DataBinder.Eval(e.Row.DataItem, "CFEQA_DEPTID").ToString().Trim();
                    //HdfQueid.Value = DataBinder.Eval(e.Row.DataItem, "intQuessionaireid").ToString().Trim();
                    HdfApprovalid.Value = DataBinder.Eval(e.Row.DataItem, "CFEQA_APPROVALID").ToString().Trim();

                    string approvalName = DataBinder.Eval(e.Row.DataItem, "ApprovalName").ToString().Trim();

                    ChkApproval.Checked = true;

                    Label lblAmount = (Label)e.Row.FindControl("lblAmounts");
                    lblAmount.Text = HdfAmount.Value.ToString();


                    lblAmount.Text = string.Format("{0:N0}", lblAmount.Text.ToString());
                    decimal amounts = Convert.ToDecimal(lblAmount.Text.ToString());
                    int textCheck = grdApprovals.Columns.Count;

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

                    if (e.Row.RowIndex >= 0)
                    {
                        amounts1 = amounts;
                        amounts22 = amounts1 + amounts22;
                    }
                }

                if ((e.Row.RowType == DataControlRowType.Footer))
                {
                    e.Row.Cells[5].Text = "Total Fee";
                    e.Row.Cells[6].Text = amounts22.ToString("#,##0");
                }





                ////if ((e.Row.RowType == DataControlRowType.DataRow))
                ////{
                ////    Label lblFee = e.Row.FindControl("lblAmounts") as Label;
                ////    CheckBox ChkApproval = (CheckBox)e.Row.FindControl("ChkApproval");
                ////    RadioButtonList rblAlrdyObtained = (RadioButtonList)e.Row.FindControl("rblAlrdyObtained");
                ////    decimal Fee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFEQA_APPROVALFEE"));
                ////    lblFee.Text = Convert.ToString(Fee);
                ////    TotalFee = TotalFee + Fee;
                ////    //e.Row.Cells[6].Text = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFEQA_APPROVALFEE")).ToString("#,##0");
                ////    decimal amounts = Convert.ToDecimal(lblFee.Text.ToString());

                ////    ChkApproval.Checked = true;
                ////    if (ChkApproval.Checked == true && amounts != 0)
                ////    {
                ////        e.Row.Cells[6].Text = e.Row.Cells[3].Text;
                ////    }
                ////    if (e.Row.Cells[6].Text != "" && amounts != 0)
                ////    {
                ////        decimal TotalFeeAmount1 = Convert.ToDecimal(e.Row.Cells[6].Text);
                ////        TotalFeeAmount = TotalFeeAmount + TotalFeeAmount1;
                ////        if (e.Row.Cells[6].Text != "")
                ////            e.Row.Cells[6].Text = Convert.ToDecimal(e.Row.Cells[6].Text).ToString("#,##0");
                ////    }
                ////}
                ////if ((e.Row.RowType == DataControlRowType.Footer))
                ////{
                ////    e.Row.Cells[2].Text = "Total Fee";
                ////    e.Row.Cells[3].Text = TotalFee.ToString("#,##0");
                ////    e.Row.Cells[5].Text = "Total Fee";
                ////    e.Row.Cells[6].Text = TotalFee.ToString("#,##0");

                ////}
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void rblAlrdyObtained_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButtonList rblobtained = (RadioButtonList)sender;
                GridViewRow row = (GridViewRow)rblobtained.NamingContainer;
                int Rowindex = row.RowIndex;
                RadioButtonList rdbCheck = (RadioButtonList)grdApprovals.Rows[Rowindex].FindControl("rblAlrdyObtained");
                HiddenField hdAmountCheck = (HiddenField)grdApprovals.Rows[Rowindex].FindControl("HdfAmount");
                CheckBox chkCheck = (CheckBox)grdApprovals.Rows[Rowindex].FindControl("ChkApproval");
                decimal amounts3 = 0;
                Label lblAmount = (Label)row.FindControl("lblAmounts");
                decimal amount = Convert.ToDecimal("0.00");

                foreach (GridViewRow row1 in grdApprovals.Rows)
                {
                    if (((RadioButtonList)row1.FindControl("rblAlrdyObtained")).SelectedItem.Value == "N")
                    {
                        if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                        {
                            row1.Cells[6].Text = row1.Cells[3].Text;

                            //if (row1.Cells[6].Text == "")
                            //{
                            //    if (row1.Cells[3].Text != "")

                            //        row1.Cells[6].Text = row1.Cells[3].Text;
                            //    else
                            //        row1.Cells[6].Text = "0";
                            //}
                            amount = amount + Convert.ToDecimal(row1.Cells[6].Text);

                        }
                        else
                        { /*if (row1.Cells[6].Text != "")*/
                            row1.Cells[6].Text = Convert.ToDecimal(0).ToString("#,##0");
                            chkCheck.Enabled = true;
                        }

                    }
                    else if (((RadioButtonList)row1.FindControl("rblAlrdyObtained")).SelectedItem.Value == "Y")
                    {
                        row1.Cells[6].Text = Convert.ToDecimal(0).ToString("#,##0");
                        chkCheck.Enabled = false;

                    }
                }


                //if (lblAmount.Text != "Label" && rdbCheck.SelectedItem.Value == "Y")
                //{
                //    amounts3 = Convert.ToDecimal(lblAmount.Text.ToString());
                //    amounts3 = 0;
                //}
                //else if (lblAmount.Text == "Label" && rdbCheck.SelectedItem.Value != "Y")
                //{
                //    string feees = hdAmountCheck.Value.ToString();
                //    feees = feees.Replace(",", "");
                //    amounts3 = Convert.ToDecimal(feees);
                //}
                //else if (lblAmount.Text == "Label" && rdbCheck.SelectedItem.Value == "Y")
                //{
                //    string feees = hdAmountCheck.Value.ToString();
                //    feees = feees.Replace(",", "");
                //    amounts3 = Convert.ToDecimal(feees);
                //}
                //else
                //{
                //    string feees = hdAmountCheck.Value.ToString();
                //    feees = feees.Replace(",", "");
                //    amounts3 = Convert.ToDecimal(feees);
                //}
                //decimal amounts4 = 0;
                //int initailRowindex = 0;
                //CheckBox ChkApproval = (CheckBox)row.FindControl("ChkApproval");

                //HiddenField HdfAmount = (HiddenField)row.FindControl("HdfAmount");
                //if (rblobtained.Items[0].Selected == true)
                //{
                //    ChkApproval.Visible = false;
                //    row.Cells[6].Text = "0";
                //    initailRowindex = row.RowIndex;
                //}
                //else
                //{
                //    ChkApproval.Visible = true;
                //    ChkApproval.Enabled = false;
                //    if (chkCheck.Checked == true)
                //    {
                //        row.Cells[6].Text = row.Cells[3].Text;
                //        rblobtained.Items[1].Selected = true;
                //        rblobtained.Enabled = false;
                //    }
                //    else
                //    {
                //        row.Cells[6].Text = "0";
                //        initailRowindex = row.RowIndex;
                //    }

                //}

                //int totalRowindex = grdApprovals.Rows.Count;
                //int incRowindex = 0;

                //while (incRowindex < totalRowindex)
                //{
                //    string ApprovalNameCheck = grdApprovals.Rows[incRowindex].Cells[2].Text.ToString();
                //    rdbCheck = (RadioButtonList)grdApprovals.Rows[incRowindex].FindControl("rblAlrdyObtained");
                //    if (incRowindex != totalRowindex && rdbCheck.SelectedItem.Value != "Y")
                //    {
                //        amounts3 = Convert.ToDecimal(grdApprovals.Rows[incRowindex].Cells[4].Text.ToString());
                //        grdApprovals.Rows[incRowindex].Cells[6].Text = grdApprovals.Rows[incRowindex].Cells[4].Text;
                //        amounts4 = amounts4 + amounts3;
                //    }
                //    else if (incRowindex <= totalRowindex || rdbCheck.SelectedItem.Value == "Y")
                //    {
                //        if (rdbCheck.SelectedItem.Value == "Y")
                //        {
                //            amounts3 = 0;
                //            grdApprovals.Rows[incRowindex].Cells[6].Text = "0";
                //        }

                //        string testing = grdApprovals.Rows[incRowindex].Cells[6].Text;
                //        amounts4 = amounts4 + amounts3;
                //    }
                //    string amountCheck = grdApprovals.Rows[incRowindex].Cells[6].Text.ToString();
                //    incRowindex = incRowindex + 1;
                //}  

                //string TEXT = amounts4.ToString();
                grdApprovals.FooterRow.Cells[6].Text = amount.ToString();
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
        {
            decimal amount = Convert.ToDecimal("0.00");
            CheckBox ChkApproval = (CheckBox)sender;
            GridViewRow row = (GridViewRow)ChkApproval.NamingContainer;
            //if (ChkApproval.Checked == true)
            //{
            //    row.Cells[6].Text = row.Cells[3].Text;
            //}
            //else
            //{
            //    row.Cells[6].Text = "0";
            //}
            foreach (GridViewRow row1 in grdApprovals.Rows)
            {
                if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                {
                    row1.Cells[6].Text = row1.Cells[3].Text;

                    //if (row1.Cells[6].Text == "")
                    //{
                    //    if (row1.Cells[3].Text != "")

                    //        row1.Cells[6].Text = row1.Cells[3].Text;
                    //    else
                    //        row1.Cells[6].Text = "0";
                    //}
                    amount = amount + Convert.ToDecimal(row1.Cells[6].Text);

                }
                else /*if (row1.Cells[6].Text != "")*/
                    row1.Cells[6].Text = Convert.ToDecimal(0).ToString("#,##0");
            }
            int Rowindex = row.RowIndex;
            int totalRowindex = grdApprovals.Rows.Count;

            //while (Rowindex < totalRowindex)
            //{
            //    grdApprovals.Rows[Rowindex].Cells[6].Text = grdApprovals.Rows[Rowindex].Cells[3].Text;
            //    grdApprovals.Rows[Rowindex].Cells[6].Text = string.Format("{0:N0}", grdApprovals.Rows[Rowindex].Cells[6].Text.ToString());
            //    Rowindex = Rowindex + 1;
            //}
            if ((row.RowType == DataControlRowType.Footer))
            {
                row.Cells[5].Text = "Total Fee";
                row.Cells[6].Text = amount.ToString("#,##0");
            }

            grdApprovals.FooterRow.Cells[6].Text = Convert.ToDecimal(amount).ToString("#,##0");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int cnt = 0;
                int selectedcount = 0;
                int selectedcount1 = 0;
                foreach (GridViewRow row in grdApprovals.Rows)
                {
                    RadioButtonList rblobtained = (RadioButtonList)row.FindControl("rblAlrdyObtained");
                    if (rblobtained.SelectedValue == "N")
                    {
                        selectedcount = selectedcount + 1;
                        if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                        {
                            selectedcount1 = selectedcount1 + 1;
                        }
                    }
                    if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                    {
                        cnt = cnt + 1;
                    }
                }
                if (cnt <= 1)
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Select Atleaset one Department for Approval";
                    lblmsg0.Visible = true;
                }
                CFEQuestionnaireDet objCFEQsnaire = new CFEQuestionnaireDet();
                int count = 0;
                foreach (GridViewRow row in grdApprovals.Rows)
                {
                    if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                    {
                        Label ApprovalID = (Label)row.FindControl("lblApprID");
                        Label DeptID = (Label)row.FindControl("lblDeptID") as Label;
                        Label lblFEE = (Label)row.FindControl("lblAmounts") as Label;
                        RadioButtonList rbloffline = (RadioButtonList)row.FindControl("rblAlrdyObtained");

                        objCFEQsnaire.UNITID = Convert.ToString(Session["UNITID"]);
                        objCFEQsnaire.CFEQDID = hdnQuestionnaireID.Value;
                        objCFEQsnaire.DeptID = DeptID.Text;
                        objCFEQsnaire.ApprovalID = ApprovalID.Text;
                        objCFEQsnaire.ApprovalFee = row.Cells[3].Text;
                        objCFEQsnaire.IsOffline = rbloffline.SelectedValue;
                        objCFEQsnaire.CreatedBy = hdnUserID.Value;
                        objCFEQsnaire.IPAddress = getclientIP();

                        string A = objcfebal.InsertCFEDepartmentApprovals(objCFEQsnaire);
                        if (A != "")
                        { count = count + 1; }
                    }
                }
                if (grdApprovals.Rows.Count == count)
                {
                    success.Visible = true;
                    lblmsg.Text = "Details Submitted Successfully";
                    string message = "alert('" + lblmsg.Text + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try { }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEEntrepreneurDetails.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        public static string getclientIP()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return result;
        }
    }
}