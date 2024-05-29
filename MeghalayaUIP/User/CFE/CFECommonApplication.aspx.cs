using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
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
        string UnitID, result;
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
                    if (Convert.ToString(Session["CFEUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["CFEUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }
                    Page.MaintainScrollPositionOnPostBack = true;
                    if (!IsPostBack)
                    {
                        if (Convert.ToString(Session["CFEUNITID"]) != "")
                        {
                            BindData();
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
        protected void BindData()
        {
            try
            {
                DataSet dsApprovals = new DataSet();
                cfeqs.UNITID = Convert.ToString(Session["CFEUNITID"]);
                cfeqs.CreatedBy = hdnUserID.Value;
                dsApprovals = objcfebal.GetApprovalsReqFromTable(cfeqs);
                if (dsApprovals.Tables.Count > 0)
                {
                    if (dsApprovals.Tables[0].Rows.Count > 0)
                    {
                        grdApprovals.DataSource = dsApprovals.Tables[0]; 
                        grdApprovals.DataBind();
                        hdnQuesid.Value = Convert.ToString(dsApprovals.Tables[0].Rows[0]["CFEQA_CFEQDID"]);
                    }
                    if (dsApprovals.Tables[1].Rows.Count > 0)
                    {
                        divOffline.Visible= true; //btnNext.Enabled = false;
                        for (int i = 0; i < dsApprovals.Tables[1].Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 1)//PCB NOC
                            {divPCB.Visible= true;
                                hpl1PCB.Visible = true;
                                hpl1PCB.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl1PCB.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 2)//PCB HAZ NOC
                            {
                                divHazPCB.Visible = true;
                                hpl2HazPCB.Visible = true;
                                hpl2HazPCB.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl2HazPCB.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 3)
                            {
                                divSrvcCon.Visible = true;
                                hpl3SrvcCon.Visible = true;
                                hpl3SrvcCon.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl3SrvcCon.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 4)
                            {
                                divEleCon.Visible = true;
                                hpl4EleCon.Visible = true;
                                hpl4EleCon.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl4EleCon.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 5) 
                            {
                                divFctryPlan.Visible = true;
                                hpl5FctryPlan.Visible = true;
                                hpl5FctryPlan.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl5FctryPlan.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 6) 
                            {
                                divDGsetNOC.Visible = true;
                                hpl6DGsetNOC.Visible = true;
                                hpl6DGsetNOC.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl6DGsetNOC.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 7) 
                            {
                                divFireSfty.Visible = true;
                                hpl7FireSfty.Visible = true;
                                hpl7FireSfty.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl7FireSfty.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 8) 
                            {
                                divRSDSLic.Visible = true;
                                hpl8RSDSLic.Visible = true;
                                hpl8RSDSLic.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl8RSDSLic.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 9) 
                            {
                                divExplsvNOC.Visible = true;
                                hpl9ExplsvNOC.Visible = true;
                                hpl9ExplsvNOC.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl9ExplsvNOC.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 10) 
                            {
                                divPtrlNOC.Visible = true;
                                hpl10PtrlNOC.Visible = true;
                                hpl10PtrlNOC.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl10PtrlNOC.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 11) 
                            {
                                divRdCtng.Visible = true;
                                hpl11RdCtng.Visible = true;
                                hpl11RdCtng.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl11RdCtng.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 12) 
                            {
                                divNonEncmb.Visible = true;
                                hpl12NonEncmb.Visible = true;
                                hpl12NonEncmb.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl12NonEncmb.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 13) 
                            {
                                divProfTax.Visible = true;
                                hpl13ProfTax.Visible = true;
                                hpl13ProfTax.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl13ProfTax.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 14) 
                            {
                                divElcInsp.Visible = true;
                                hpl14ElcInsp.Visible = true;
                                hpl14ElcInsp.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl14ElcInsp.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 15) 
                            {
                                divForstDist.Visible = true;
                                hpl15ForstDist.Visible = true;
                                hpl15ForstDist.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl15ForstDist.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 16) 
                            {
                                divNonForstLand.Visible = true;
                                hpl16NonForstLand.Visible = true;
                                hpl16NonForstLand.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl16NonForstLand.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 17) 
                            {
                                divIrrgNOC.Visible = true;
                                hpl17IrrgNOC.Visible = true;
                                hpl17IrrgNOC.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl17IrrgNOC.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 18) 
                            {
                                divRevNOC.Visible = true;
                                hpl18RevNOC.Visible = true;
                                hpl18RevNOC.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl18RevNOC.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 19) 
                            {
                                divGrndWtrNOC.Visible = true;
                                hpl19GrndWtrNOC.Visible = true;
                                hpl19GrndWtrNOC.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl19GrndWtrNOC.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 20) 
                            {
                                divNoWtrSplyCertfct.Visible = true;
                                hpl20NoWtrSply.Visible = true;
                                hpl20NoWtrSply.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl20NoWtrSply.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 21) 
                            {
                                divPrmsntoDrawWtr.Visible = true;
                                hpl21ToDrawWtr.Visible = true;
                                hpl21ToDrawWtr.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl21ToDrawWtr.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 22) 
                            {
                                divMunicipalWatr.Visible = true;
                                hpl22MunicipalWatr.Visible = true;
                                hpl22MunicipalWatr.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl22MunicipalWatr.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 23) 
                            {
                                divUrbanWatr.Visible = true;
                                hpl23UrbanWatr.Visible = true;
                                hpl23UrbanWatr.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl23UrbanWatr.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 25) 
                            {
                                divLbrAct1970.Visible = true;
                                hpl25LbrAct1970.Visible = true;
                                hpl25LbrAct1970.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl25LbrAct1970.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 26) 
                            {
                                divLbrAct1979.Visible = true;
                                hpl26LbrAct1979.Visible = true;
                                hpl26LbrAct1979.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl26LbrAct1979.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 27) 
                            {
                                divLbrAct1996.Visible = true;
                                hpl27LbrAct1996.Visible = true;
                                hpl27LbrAct1996.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl27LbrAct1996.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 28) 
                            {
                                divContrLbrAct.Visible = true;
                                hpl28ContrLbrAct.Visible = true;
                                hpl28ContrLbrAct.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl28ContrLbrAct.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 29)
                            {
                                divContrLbrAct1979.Visible = true;
                                hpl29ContrLbrAct1979.Visible = true;
                                hpl29ContrLbrAct1979.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl29ContrLbrAct1979.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 30)
                            {
                                divConstrPermit.Visible = true;
                                hpl30ConstrPermit.Visible = true;
                                hpl30ConstrPermit.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl30ConstrPermit.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(dsApprovals.Tables[1].Rows[i]["CFEA_APPROVALID"]) == 31)
                            {
                                divBldngPlan.Visible = true;
                                hpl31BldngPlan.Visible = true;
                                hpl31BldngPlan.NavigateUrl = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILEPATH"]);
                                hpl31BldngPlan.Text = Convert.ToString(dsApprovals.Tables[1].Rows[i]["CFEA_FILENAME"]);
                            }
                        }

                    }
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
                    //rblObtained.SelectedIndexChanged += new EventHandler(rblAlrdyObtained_SelectedIndexChanged);

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
                    if (rblObtained.SelectedValue == "Y")
                    {
                        rblObtained.Enabled = false;
                        ChkApproval.Checked = false; ChkApproval.Enabled = false;
                        lblAmount.Text = "0";
                        amounts = 0;
                        e.Row.Cells[6].Text = "0";
                    }
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
                if (Rowindex >= 0)
                {
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
                            ((CheckBox)row1.FindControl("ChkApproval")).Checked = true;

                            if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                            {
                                row1.Cells[6].Text = row1.Cells[3].Text;
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
                            chkCheck.Checked = false;
                        }
                    }
                    grdApprovals.FooterRow.Cells[6].Text = amount.ToString();
                }
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

            foreach (GridViewRow row1 in grdApprovals.Rows)
            {
                if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                {
                    row1.Cells[6].Text = row1.Cells[3].Text;

                    amount = amount + Convert.ToDecimal(row1.Cells[6].Text);

                }
                else /*if (row1.Cells[6].Text != "")*/
                    row1.Cells[6].Text = Convert.ToDecimal(0).ToString("#,##0");
            }
            int Rowindex = row.RowIndex;
            int totalRowindex = grdApprovals.Rows.Count;

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
                    return;
                }
                CFEQuestionnaireDet objCFEQsnaire = new CFEQuestionnaireDet();
                int count = 0;
                foreach (GridViewRow row in grdApprovals.Rows)
                {
                    //if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                    //{
                    Label ApprovalID = (Label)row.FindControl("lblApprID");
                    Label DeptID = (Label)row.FindControl("lblDeptID") as Label;
                    Label lblFEE = (Label)row.FindControl("lblAmounts") as Label;
                    RadioButtonList rbloffline = (RadioButtonList)row.FindControl("rblAlrdyObtained");

                    objCFEQsnaire.UNITID = Convert.ToString(Session["CFEUNITID"]);
                    objCFEQsnaire.CFEQDID = Convert.ToString(Session["CFEQID"]);
                    objCFEQsnaire.DeptID = DeptID.Text;
                    objCFEQsnaire.ApprovalID = ApprovalID.Text;
                    objCFEQsnaire.ApprovalFee = row.Cells[3].Text;
                    objCFEQsnaire.IsOffline = rbloffline.SelectedValue;
                    objCFEQsnaire.CreatedBy = hdnUserID.Value;
                    objCFEQsnaire.IPAddress = getclientIP();

                    string A = objcfebal.InsertCFEDepartmentApprovals(objCFEQsnaire);
                    if (A != "")
                    { count = count + 1; }
                    //}

                }
                if (grdApprovals.Rows.Count == count)
                {
                    DataSet dsOffline = new DataSet();
                    dsOffline = objcfebal.GetCFEAlreadyObtainedApprovals(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));
                    if (dsOffline.Tables.Count > 0)
                    {
                        if (dsOffline.Tables[0].Rows.Count > 0)
                        {
                            btnNext.Enabled = false;
                            divOffline.Visible = true;
                            for (int i = 0; i < dsOffline.Tables[0].Rows.Count; i++)
                            {
                                if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "1")
                                    divPCB.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "2")
                                    divHazPCB.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "3")
                                    divSrvcCon.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "4")
                                    divEleCon.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "5")
                                    divFctryPlan.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "6")
                                    divDGsetNOC.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "7")
                                    divFireSfty.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "8")
                                    divRSDSLic.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "9")
                                    divExplsvNOC.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "10")
                                    divPtrlNOC.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "11")
                                    divRdCtng.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "12")
                                    divNonEncmb.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "13")
                                    divProfTax.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "14")
                                    divElcInsp.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "15")
                                    divForstDist.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "16")
                                    divNonForstLand.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "17")
                                    divIrrgNOC.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "18")
                                    divRevNOC.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "19")
                                    divGrndWtrNOC.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "20")
                                    divNoWtrSplyCertfct.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "21")
                                    divPrmsntoDrawWtr.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "22")
                                    divMunicipalWatr.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "23")
                                    divUrbanWatr.Visible = true;

                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "25")
                                    divLbrAct1970.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "26")
                                    divLbrAct1979.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "27")
                                    divLbrAct1996.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "28")
                                    divContrLbrAct.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "29")
                                    divContrLbrAct1979.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "30")
                                    divConstrPermit.Visible = true;
                                else if (Convert.ToString(dsOffline.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "31")
                                    divBldngPlan.Visible = true;

                            }
                        }
                        
                        success.Visible = true;
                        lblmsg.Text = "Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";

                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
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
                Response.Redirect("~/User/CFE/CFEIndustryDetails.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }


        protected void btnUpld1PCB_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup1PCB.HasFile)
                {
                    Error = validations(fup1PCB);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "1" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup1PCB.PostedFile.SaveAs(serverpath + "\\" + fup1PCB.PostedFile.FileName);

                        CFEAttachments objPCBNOC = new CFEAttachments();
                        objPCBNOC.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objPCBNOC.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objPCBNOC.ApprovalID = "1";
                        objPCBNOC.DeptID = "12";
                        objPCBNOC.FilePath = serverpath + fup1PCB.PostedFile.FileName;
                        objPCBNOC.FileName = fup1PCB.PostedFile.FileName;
                        objPCBNOC.FileType = fup1PCB.PostedFile.ContentType;
                        objPCBNOC.FileDescription = "OfflineApprovalPCBNOC";
                        objPCBNOC.CreatedBy = hdnUserID.Value;
                        objPCBNOC.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objPCBNOC);
                        if (result != "")
                        {
                            hpl1PCB.Text = fup1PCB.PostedFile.FileName;
                            hpl1PCB.NavigateUrl = serverpath;
                            hpl1PCB.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld2HazPCB_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup2HazPCB.HasFile)
                {
                    Error = validations(fup2HazPCB);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "2" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup2HazPCB.PostedFile.SaveAs(serverpath + "\\" + fup2HazPCB.PostedFile.FileName);

                        CFEAttachments objHAZNOC = new CFEAttachments();
                        objHAZNOC.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objHAZNOC.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objHAZNOC.ApprovalID = "2";
                        objHAZNOC.DeptID = "12";
                        objHAZNOC.FilePath = serverpath + fup2HazPCB.PostedFile.FileName;
                        objHAZNOC.FileName = fup2HazPCB.PostedFile.FileName;
                        objHAZNOC.FileType = fup2HazPCB.PostedFile.ContentType;
                        objHAZNOC.FileDescription = "OfflineApprovalPCBHAZNOC";
                        objHAZNOC.CreatedBy = hdnUserID.Value;
                        objHAZNOC.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objHAZNOC);
                        if (result != "")
                        {
                            hpl2HazPCB.Text = fup2HazPCB.PostedFile.FileName;
                            hpl2HazPCB.NavigateUrl = serverpath;
                            hpl2HazPCB.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnUpld3SrvcCon_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup3SrvcCon.HasFile)
                {
                    Error = validations(fup3SrvcCon);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "3" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup3SrvcCon.PostedFile.SaveAs(serverpath + "\\" + fup3SrvcCon.PostedFile.FileName);

                        CFEAttachments objSrvcCon = new CFEAttachments();
                        objSrvcCon.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objSrvcCon.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objSrvcCon.ApprovalID = "3";
                        objSrvcCon.DeptID = "14";
                        objSrvcCon.FilePath = serverpath + fup3SrvcCon.PostedFile.FileName;
                        objSrvcCon.FileName = fup3SrvcCon.PostedFile.FileName;
                        objSrvcCon.FileType = fup3SrvcCon.PostedFile.ContentType;
                        objSrvcCon.FileDescription = "OfflineApprovalServiceConnection";
                        objSrvcCon.CreatedBy = hdnUserID.Value;
                        objSrvcCon.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objSrvcCon);
                        if (result != "")
                        {
                            hpl3SrvcCon.Text = fup3SrvcCon.PostedFile.FileName;
                            hpl3SrvcCon.NavigateUrl = serverpath;
                            hpl3SrvcCon.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld4EleCon_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup4EleCon.HasFile)
                {
                    Error = validations(fup4EleCon);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "4" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup4EleCon.PostedFile.SaveAs(serverpath + "\\" + fup4EleCon.PostedFile.FileName);

                        CFEAttachments objEleCon = new CFEAttachments();
                        objEleCon.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objEleCon.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objEleCon.ApprovalID = "4";
                        objEleCon.DeptID = "14";
                        objEleCon.FilePath = serverpath + fup4EleCon.PostedFile.FileName;
                        objEleCon.FileName = fup4EleCon.PostedFile.FileName;
                        objEleCon.FileType = fup4EleCon.PostedFile.ContentType;
                        objEleCon.FileDescription = "OfflineApprovalElectricConnection";
                        objEleCon.CreatedBy = hdnUserID.Value;
                        objEleCon.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objEleCon);
                        if (result != "")
                        {
                            hpl4EleCon.Text = fup4EleCon.PostedFile.FileName;
                            hpl4EleCon.NavigateUrl = serverpath;
                            hpl4EleCon.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld5FctryPlan_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup5FctryPlan.HasFile)
                {
                    Error = validations(fup5FctryPlan);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "5" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup5FctryPlan.PostedFile.SaveAs(serverpath + "\\" + fup5FctryPlan.PostedFile.FileName);

                        CFEAttachments objFctryPlan = new CFEAttachments();
                        objFctryPlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objFctryPlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objFctryPlan.ApprovalID = "5";
                        objFctryPlan.DeptID = "19";
                        objFctryPlan.FilePath = serverpath + fup5FctryPlan.PostedFile.FileName;
                        objFctryPlan.FileName = fup5FctryPlan.PostedFile.FileName;
                        objFctryPlan.FileType = fup5FctryPlan.PostedFile.ContentType;
                        objFctryPlan.FileDescription = "OfflineApprovalFactoryPlan";
                        objFctryPlan.CreatedBy = hdnUserID.Value;
                        objFctryPlan.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objFctryPlan);
                        if (result != "")
                        {
                            hpl5FctryPlan.Text = fup5FctryPlan.PostedFile.FileName;
                            hpl5FctryPlan.NavigateUrl = serverpath;
                            hpl5FctryPlan.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld6DGsetNOC_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup6DGsetNOC.HasFile)
                {
                    Error = validations(fup6DGsetNOC);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "6" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup6DGsetNOC.PostedFile.SaveAs(serverpath + "\\" + fup6DGsetNOC.PostedFile.FileName);

                        CFEAttachments objDGsetNOC = new CFEAttachments();
                        objDGsetNOC.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objDGsetNOC.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objDGsetNOC.ApprovalID = "6";
                        objDGsetNOC.DeptID = "14";
                        objDGsetNOC.FilePath = serverpath + fup6DGsetNOC.PostedFile.FileName;
                        objDGsetNOC.FileName = fup6DGsetNOC.PostedFile.FileName;
                        objDGsetNOC.FileType = fup6DGsetNOC.PostedFile.ContentType;
                        objDGsetNOC.FileDescription = "OfflineApprovalDGsetNOC";
                        objDGsetNOC.CreatedBy = hdnUserID.Value;
                        objDGsetNOC.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objDGsetNOC);
                        if (result != "")
                        {
                            hpl6DGsetNOC.Text = fup6DGsetNOC.PostedFile.FileName;
                            hpl6DGsetNOC.NavigateUrl = serverpath;
                            hpl6DGsetNOC.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld7FireSfty_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup7FireSfty.HasFile)
                {
                    Error = validations(fup7FireSfty);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "7" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup7FireSfty.PostedFile.SaveAs(serverpath + "\\" + fup7FireSfty.PostedFile.FileName);

                        CFEAttachments objFireSfty = new CFEAttachments();
                        objFireSfty.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objFireSfty.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objFireSfty.ApprovalID = "7";
                        objFireSfty.DeptID = "9";
                        objFireSfty.FilePath = serverpath + fup7FireSfty.PostedFile.FileName;
                        objFireSfty.FileName = fup7FireSfty.PostedFile.FileName;
                        objFireSfty.FileType = fup7FireSfty.PostedFile.ContentType;
                        objFireSfty.FileDescription = "OfflineApprovalFireSafetyCertificate";
                        objFireSfty.CreatedBy = hdnUserID.Value;
                        objFireSfty.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objFireSfty);
                        if (result != "")
                        {
                            hpl7FireSfty.Text = fup7FireSfty.PostedFile.FileName;
                            hpl7FireSfty.NavigateUrl = serverpath;
                            hpl7FireSfty.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnUpld8RSDSLic_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup8RSDSLic.HasFile)
                {
                    Error = validations(fup8RSDSLic);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "8" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup8RSDSLic.PostedFile.SaveAs(serverpath + "\\" + fup8RSDSLic.PostedFile.FileName);

                        CFEAttachments objRSDSLic = new CFEAttachments();
                        objRSDSLic.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objRSDSLic.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objRSDSLic.ApprovalID = "8";
                        objRSDSLic.DeptID = "7";
                        objRSDSLic.FilePath = serverpath + fup8RSDSLic.PostedFile.FileName;
                        objRSDSLic.FileName = fup8RSDSLic.PostedFile.FileName;
                        objRSDSLic.FileType = fup8RSDSLic.PostedFile.ContentType;
                        objRSDSLic.FileDescription = "OfflineApprovalRSDSLicence";
                        objRSDSLic.CreatedBy = hdnUserID.Value;
                        objRSDSLic.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objRSDSLic);
                        if (result != "")
                        {
                            hpl8RSDSLic.Text = fup8RSDSLic.PostedFile.FileName;
                            hpl8RSDSLic.NavigateUrl = serverpath;
                            hpl8RSDSLic.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld9ExplsvNOC_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup9ExplsvNOC.HasFile)
                {
                    Error = validations(fup9ExplsvNOC);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "9" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup9ExplsvNOC.PostedFile.SaveAs(serverpath + "\\" + fup9ExplsvNOC.PostedFile.FileName);

                        CFEAttachments objExplsvNOC = new CFEAttachments();
                        objExplsvNOC.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objExplsvNOC.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objExplsvNOC.ApprovalID = "9";
                        objExplsvNOC.DeptID = "13";
                        objExplsvNOC.FilePath = serverpath + fup9ExplsvNOC.PostedFile.FileName;
                        objExplsvNOC.FileName = fup9ExplsvNOC.PostedFile.FileName;
                        objExplsvNOC.FileType = fup9ExplsvNOC.PostedFile.ContentType;
                        objExplsvNOC.FileDescription = "OfflineApprovalExplosivesManufactureNOC";
                        objExplsvNOC.CreatedBy = hdnUserID.Value;
                        objExplsvNOC.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objExplsvNOC);
                        if (result != "")
                        {
                            hpl9ExplsvNOC.Text = fup9ExplsvNOC.PostedFile.FileName;
                            hpl9ExplsvNOC.NavigateUrl = serverpath;
                            hpl9ExplsvNOC.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld10PtrlNOC_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup10PtrlNOC.HasFile)
                {
                    Error = validations(fup10PtrlNOC);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "10" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup10PtrlNOC.PostedFile.SaveAs(serverpath + "\\" + fup10PtrlNOC.PostedFile.FileName);

                        CFEAttachments objPtrlNOC = new CFEAttachments();
                        objPtrlNOC.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objPtrlNOC.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objPtrlNOC.ApprovalID = "10";
                        objPtrlNOC.DeptID = "13";
                        objPtrlNOC.FilePath = serverpath + fup10PtrlNOC.PostedFile.FileName;
                        objPtrlNOC.FileName = fup10PtrlNOC.PostedFile.FileName;
                        objPtrlNOC.FileType = fup10PtrlNOC.PostedFile.ContentType;
                        objPtrlNOC.FileDescription = "OfflineApprovalPetrolManfactureNOC";
                        objPtrlNOC.CreatedBy = hdnUserID.Value;
                        objPtrlNOC.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objPtrlNOC);
                        if (result != "")
                        {
                            hpl10PtrlNOC.Text = fup10PtrlNOC.PostedFile.FileName;
                            hpl10PtrlNOC.NavigateUrl = serverpath;
                            hpl10PtrlNOC.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnUpld11RdCtng_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup11RdCtng.HasFile)
                {
                    Error = validations(fup11RdCtng);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "11" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        fup11RdCtng.PostedFile.SaveAs(serverpath + "\\" + fup11RdCtng.PostedFile.FileName);

                        CFEAttachments objRdCtng = new CFEAttachments();
                        objRdCtng.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objRdCtng.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objRdCtng.ApprovalID = "11";
                        objRdCtng.DeptID = "16";
                        objRdCtng.FilePath = serverpath + fup11RdCtng.PostedFile.FileName;
                        objRdCtng.FileName = fup11RdCtng.PostedFile.FileName;
                        objRdCtng.FileType = fup11RdCtng.PostedFile.ContentType;
                        objRdCtng.FileDescription = "OfflineApprovalRoadCuttingPermission";
                        objRdCtng.CreatedBy = hdnUserID.Value;
                        objRdCtng.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objRdCtng);
                        if (result != "")
                        {
                            hpl11RdCtng.Text = fup11RdCtng.PostedFile.FileName;
                            hpl11RdCtng.NavigateUrl = serverpath;
                            hpl11RdCtng.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnUpld12NonEncmb_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup12NonEncmb.HasFile)
                {
                    Error = validations(fup12NonEncmb);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "12" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup12NonEncmb.PostedFile.SaveAs(serverpath + "\\" + fup12NonEncmb.PostedFile.FileName);

                        CFEAttachments objNonEncmb = new CFEAttachments();
                        objNonEncmb.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objNonEncmb.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objNonEncmb.ApprovalID = "12";
                        objNonEncmb.DeptID = "13";
                        objNonEncmb.FilePath = serverpath + fup12NonEncmb.PostedFile.FileName;
                        objNonEncmb.FileName = fup12NonEncmb.PostedFile.FileName;
                        objNonEncmb.FileType = fup12NonEncmb.PostedFile.ContentType;
                        objNonEncmb.FileDescription = "OfflineApprovalNonEncumbrance";
                        objNonEncmb.CreatedBy = hdnUserID.Value;
                        objNonEncmb.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objNonEncmb);
                        if (result != "")
                        {
                            hpl12NonEncmb.Text = fup12NonEncmb.PostedFile.FileName;
                            hpl12NonEncmb.NavigateUrl = serverpath;
                            hpl12NonEncmb.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld13ProfTax_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup13ProfTax.HasFile)
                {
                    Error = validations(fup13ProfTax);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "13" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup13ProfTax.PostedFile.SaveAs(serverpath + "\\" + fup13ProfTax.PostedFile.FileName);

                        CFEAttachments objProfTax = new CFEAttachments();
                        objProfTax.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objProfTax.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objProfTax.ApprovalID = "13";
                        objProfTax.DeptID = "6";
                        objProfTax.FilePath = serverpath + fup13ProfTax.PostedFile.FileName;
                        objProfTax.FileName = fup13ProfTax.PostedFile.FileName;
                        objProfTax.FileType = fup13ProfTax.PostedFile.ContentType;
                        objProfTax.FileDescription = "OfflineApprovalProffessionalTax";
                        objProfTax.CreatedBy = hdnUserID.Value;
                        objProfTax.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objProfTax);
                        if (result != "")
                        {
                            hpl13ProfTax.Text = fup13ProfTax.PostedFile.FileName;
                            hpl13ProfTax.NavigateUrl = serverpath;
                            hpl13ProfTax.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnUpld14ElcInsp_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup14ElcInsp.HasFile)
                {
                    Error = validations(fup14ElcInsp);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "14" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup14ElcInsp.PostedFile.SaveAs(serverpath + "\\" + fup14ElcInsp.PostedFile.FileName);

                        CFEAttachments objElcInsp = new CFEAttachments();
                        objElcInsp.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objElcInsp.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objElcInsp.ApprovalID = "14";
                        objElcInsp.DeptID = "18";
                        objElcInsp.FilePath = serverpath + fup14ElcInsp.PostedFile.FileName;
                        objElcInsp.FileName = fup14ElcInsp.PostedFile.FileName;
                        objElcInsp.FileType = fup14ElcInsp.PostedFile.ContentType;
                        objElcInsp.FileDescription = "OfflineApprovalElectricalInspectorate";
                        objElcInsp.CreatedBy = hdnUserID.Value;
                        objElcInsp.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objElcInsp);
                        if (result != "")
                        {
                            hpl14ElcInsp.Text = fup14ElcInsp.PostedFile.FileName;
                            hpl14ElcInsp.NavigateUrl = serverpath;
                            hpl14ElcInsp.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnUpld15ForstDist_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup15ForstDist.HasFile)
                {
                    Error = validations(fup15ForstDist);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "15" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup15ForstDist.PostedFile.SaveAs(serverpath + "\\" + fup15ForstDist.PostedFile.FileName);

                        CFEAttachments objForstDist = new CFEAttachments();
                        objForstDist.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objForstDist.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objForstDist.ApprovalID = "15";
                        objForstDist.DeptID = "4";
                        objForstDist.FilePath = serverpath + fup15ForstDist.PostedFile.FileName;
                        objForstDist.FileName = fup15ForstDist.PostedFile.FileName;
                        objForstDist.FileType = fup15ForstDist.PostedFile.ContentType;
                        objForstDist.FileDescription = "OfflineApprovalDistancefromForestLetter";
                        objForstDist.CreatedBy = hdnUserID.Value;
                        objForstDist.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objForstDist);
                        if (result != "")
                        {
                            hpl15ForstDist.Text = fup15ForstDist.PostedFile.FileName;
                            hpl15ForstDist.NavigateUrl = serverpath;
                            hpl15ForstDist.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld16NonForstLand_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup16NonForstLand.HasFile)
                {
                    Error = validations(fup16NonForstLand);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "16" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup16NonForstLand.PostedFile.SaveAs(serverpath + "\\" + fup16NonForstLand.PostedFile.FileName);

                        CFEAttachments objNonForstLand = new CFEAttachments();
                        objNonForstLand.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objNonForstLand.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objNonForstLand.ApprovalID = "16";
                        objNonForstLand.DeptID = "4";
                        objNonForstLand.FilePath = serverpath + fup16NonForstLand.PostedFile.FileName;
                        objNonForstLand.FileName = fup16NonForstLand.PostedFile.FileName;
                        objNonForstLand.FileType = fup16NonForstLand.PostedFile.ContentType;
                        objNonForstLand.FileDescription = "OfflineApprovalNonForestLandCertificate";
                        objNonForstLand.CreatedBy = hdnUserID.Value;
                        objNonForstLand.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objNonForstLand);
                        if (result != "")
                        {
                            hpl16NonForstLand.Text = fup16NonForstLand.PostedFile.FileName;
                            hpl16NonForstLand.NavigateUrl = serverpath;
                            hpl16NonForstLand.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld17IrrgNOC_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup17IrrgNOC.HasFile)
                {
                    Error = validations(fup17IrrgNOC);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "17" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup17IrrgNOC.PostedFile.SaveAs(serverpath + "\\" + fup17IrrgNOC.PostedFile.FileName);

                        CFEAttachments objIrrgNOC = new CFEAttachments();
                        objIrrgNOC.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objIrrgNOC.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objIrrgNOC.ApprovalID = "17";
                        objIrrgNOC.DeptID = "20";
                        objIrrgNOC.FilePath = serverpath + fup17IrrgNOC.PostedFile.FileName;
                        objIrrgNOC.FileName = fup17IrrgNOC.PostedFile.FileName;
                        objIrrgNOC.FileType = fup17IrrgNOC.PostedFile.ContentType;
                        objIrrgNOC.FileDescription = "OfflineApprovalFTLIrrigationNOC";
                        objIrrgNOC.CreatedBy = hdnUserID.Value;
                        objIrrgNOC.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objIrrgNOC);
                        if (result != "")
                        {
                            hpl17IrrgNOC.Text = fup17IrrgNOC.PostedFile.FileName;
                            hpl17IrrgNOC.NavigateUrl = serverpath;
                            hpl17IrrgNOC.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld18RevNOC_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup18RevNOC.HasFile)
                {
                    Error = validations(fup18RevNOC);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "18" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup18RevNOC.PostedFile.SaveAs(serverpath + "\\" + fup18RevNOC.PostedFile.FileName);

                        CFEAttachments objFctryPlan = new CFEAttachments();
                        objFctryPlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objFctryPlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objFctryPlan.ApprovalID = "18";
                        objFctryPlan.DeptID = "20";
                        objFctryPlan.FilePath = serverpath + fup18RevNOC.PostedFile.FileName;
                        objFctryPlan.FileName = fup18RevNOC.PostedFile.FileName;
                        objFctryPlan.FileType = fup18RevNOC.PostedFile.ContentType;
                        objFctryPlan.FileDescription = "OfflineApprovalFTLRevenueNOC";
                        objFctryPlan.CreatedBy = hdnUserID.Value;
                        objFctryPlan.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objFctryPlan);
                        if (result != "")
                        {
                            hpl18RevNOC.Text = fup18RevNOC.PostedFile.FileName;
                            hpl18RevNOC.NavigateUrl = serverpath;
                            hpl18RevNOC.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void btnUpld19GrndWtrNOC_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup19GrndWtrNOC.HasFile)
                {
                    Error = validations(fup19GrndWtrNOC);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "19" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup19GrndWtrNOC.PostedFile.SaveAs(serverpath + "\\" + fup19GrndWtrNOC.PostedFile.FileName);

                        CFEAttachments objGrndWtrNOC = new CFEAttachments();
                        objGrndWtrNOC.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objGrndWtrNOC.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objGrndWtrNOC.ApprovalID = "19";
                        objGrndWtrNOC.DeptID = "5";
                        objGrndWtrNOC.FilePath = serverpath + fup19GrndWtrNOC.PostedFile.FileName;
                        objGrndWtrNOC.FileName = fup19GrndWtrNOC.PostedFile.FileName;
                        objGrndWtrNOC.FileType = fup19GrndWtrNOC.PostedFile.ContentType;
                        objGrndWtrNOC.FileDescription = "OfflineApprovalGroundWaterAbstractionNOC";
                        objGrndWtrNOC.CreatedBy = hdnUserID.Value;
                        objGrndWtrNOC.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objGrndWtrNOC);
                        if (result != "")
                        {
                            hpl19GrndWtrNOC.Text = fup19GrndWtrNOC.PostedFile.FileName;
                            hpl19GrndWtrNOC.NavigateUrl = serverpath;
                            hpl19GrndWtrNOC.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld20NoWtrSply_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup20NoWtrSply.HasFile)
                {
                    Error = validations(fup20NoWtrSply);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "20" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup20NoWtrSply.PostedFile.SaveAs(serverpath + "\\" + fup20NoWtrSply.PostedFile.FileName);

                        CFEAttachments objNoWtrSply = new CFEAttachments();
                        objNoWtrSply.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objNoWtrSply.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objNoWtrSply.ApprovalID = "20";
                        objNoWtrSply.DeptID = "15";
                        objNoWtrSply.FilePath = serverpath + fup20NoWtrSply.PostedFile.FileName;
                        objNoWtrSply.FileName = fup20NoWtrSply.PostedFile.FileName;
                        objNoWtrSply.FileType = fup20NoWtrSply.PostedFile.ContentType;
                        objNoWtrSply.FileDescription = "OfflineApprovalNonAvailablityofWaterSupply";
                        objNoWtrSply.CreatedBy = hdnUserID.Value;
                        objNoWtrSply.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objNoWtrSply);
                        if (result != "")
                        {
                            hpl20NoWtrSply.Text = fup20NoWtrSply.PostedFile.FileName;
                            hpl20NoWtrSply.NavigateUrl = serverpath;
                            hpl20NoWtrSply.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld21ToDrawWtr_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup21ToDrawWtr.HasFile)
                {
                    Error = validations(fup21ToDrawWtr);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "21" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup21ToDrawWtr.PostedFile.SaveAs(serverpath + "\\" + fup21ToDrawWtr.PostedFile.FileName);

                        CFEAttachments objToDrawWtr = new CFEAttachments();
                        objToDrawWtr.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objToDrawWtr.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objToDrawWtr.ApprovalID = "21";
                        objToDrawWtr.DeptID = "15";
                        objToDrawWtr.FilePath = serverpath + fup21ToDrawWtr.PostedFile.FileName;
                        objToDrawWtr.FileName = fup21ToDrawWtr.PostedFile.FileName;
                        objToDrawWtr.FileType = fup21ToDrawWtr.PostedFile.ContentType;
                        objToDrawWtr.FileDescription = "OfflineApprovalPermissionToDrawWaterFromRivers";
                        objToDrawWtr.CreatedBy = hdnUserID.Value;
                        objToDrawWtr.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objToDrawWtr);
                        if (result != "")
                        {
                            hpl21ToDrawWtr.Text = fup21ToDrawWtr.PostedFile.FileName;
                            hpl21ToDrawWtr.NavigateUrl = serverpath;
                            hpl21ToDrawWtr.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld22MunicipalWatr_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup22MunicipalWatr.HasFile)
                {
                    Error = validations(fup22MunicipalWatr);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "22" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup22MunicipalWatr.PostedFile.SaveAs(serverpath + "\\" + fup22MunicipalWatr.PostedFile.FileName);

                        CFEAttachments objMunWatr = new CFEAttachments();
                        objMunWatr.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objMunWatr.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objMunWatr.ApprovalID = "22";
                        objMunWatr.DeptID = "2";
                        objMunWatr.FilePath = serverpath + fup22MunicipalWatr.PostedFile.FileName;
                        objMunWatr.FileName = fup22MunicipalWatr.PostedFile.FileName;
                        objMunWatr.FileType = fup22MunicipalWatr.PostedFile.ContentType;
                        objMunWatr.FileDescription = "OfflineApprovalMuniciaplWaterConnection";
                        objMunWatr.CreatedBy = hdnUserID.Value;
                        objMunWatr.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objMunWatr);
                        if (result != "")
                        {
                            hpl22MunicipalWatr.Text = fup22MunicipalWatr.PostedFile.FileName;
                            hpl22MunicipalWatr.NavigateUrl = serverpath;
                            hpl22MunicipalWatr.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld23UrbanWatr_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup23UrbanWatr.HasFile)
                {
                    Error = validations(fup23UrbanWatr);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "23" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup23UrbanWatr.PostedFile.SaveAs(serverpath + "\\" + fup23UrbanWatr.PostedFile.FileName);

                        CFEAttachments objFctryPlan = new CFEAttachments();
                        objFctryPlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objFctryPlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objFctryPlan.ApprovalID = "23";
                        objFctryPlan.DeptID = "15";
                        objFctryPlan.FilePath = serverpath + fup23UrbanWatr.PostedFile.FileName;
                        objFctryPlan.FileName = fup23UrbanWatr.PostedFile.FileName;
                        objFctryPlan.FileType = fup23UrbanWatr.PostedFile.ContentType;
                        objFctryPlan.FileDescription = "OfflineApprovalUrbanWaterConnection";
                        objFctryPlan.CreatedBy = hdnUserID.Value;
                        objFctryPlan.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objFctryPlan);
                        if (result != "")
                        {
                            hpl23UrbanWatr.Text = fup23UrbanWatr.PostedFile.FileName;
                            hpl23UrbanWatr.NavigateUrl = serverpath;
                            hpl23UrbanWatr.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }
        protected void btnUpld25LbrAct1970_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup25LbrAct1970.HasFile)
                {
                    Error = validations(fup25LbrAct1970);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "25" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup25LbrAct1970.PostedFile.SaveAs(serverpath + "\\" + fup25LbrAct1970.PostedFile.FileName);

                        CFEAttachments objLbrAct1970 = new CFEAttachments();
                        objLbrAct1970.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objLbrAct1970.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objLbrAct1970.ApprovalID = "25";
                        objLbrAct1970.DeptID = "10";
                        objLbrAct1970.FilePath = serverpath + fup25LbrAct1970.PostedFile.FileName;
                        objLbrAct1970.FileName = fup25LbrAct1970.PostedFile.FileName;
                        objLbrAct1970.FileType = fup25LbrAct1970.PostedFile.ContentType;
                        objLbrAct1970.FileDescription = "OfflineApprovalRegistrationunderLAbourAct1970";
                        objLbrAct1970.CreatedBy = hdnUserID.Value;
                        objLbrAct1970.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objLbrAct1970);
                        if (result != "")
                        {
                            hpl25LbrAct1970.Text = fup25LbrAct1970.PostedFile.FileName;
                            hpl25LbrAct1970.NavigateUrl = serverpath;
                            hpl25LbrAct1970.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld26LbrAct1979_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup26LbrAct1979.HasFile)
                {
                    Error = validations(fup26LbrAct1979);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "26" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup26LbrAct1979.PostedFile.SaveAs(serverpath + "\\" + fup26LbrAct1979.PostedFile.FileName);

                        CFEAttachments objLbrAct1979 = new CFEAttachments();
                        objLbrAct1979.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objLbrAct1979.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objLbrAct1979.ApprovalID = "26";
                        objLbrAct1979.DeptID = "10";
                        objLbrAct1979.FilePath = serverpath + fup26LbrAct1979.PostedFile.FileName;
                        objLbrAct1979.FileName = fup26LbrAct1979.PostedFile.FileName;
                        objLbrAct1979.FileType = fup26LbrAct1979.PostedFile.ContentType;
                        objLbrAct1979.FileDescription = "OfflineApprovalRegistrationunderLAbourAct1979";
                        objLbrAct1979.CreatedBy = hdnUserID.Value;
                        objLbrAct1979.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objLbrAct1979);
                        if (result != "")
                        {
                            hpl26LbrAct1979.Text = fup26LbrAct1979.PostedFile.FileName;
                            hpl26LbrAct1979.NavigateUrl = serverpath;
                            hpl26LbrAct1979.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld27LbrAct1996_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup27LbrAct1996.HasFile)
                {
                    Error = validations(fup27LbrAct1996);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "27" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup27LbrAct1996.PostedFile.SaveAs(serverpath + "\\" + fup27LbrAct1996.PostedFile.FileName);

                        CFEAttachments objFctryPlan = new CFEAttachments();
                        objFctryPlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objFctryPlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objFctryPlan.ApprovalID = "27";
                        objFctryPlan.DeptID = "10";
                        objFctryPlan.FilePath = serverpath + fup27LbrAct1996.PostedFile.FileName;
                        objFctryPlan.FileName = fup27LbrAct1996.PostedFile.FileName;
                        objFctryPlan.FileType = fup27LbrAct1996.PostedFile.ContentType;
                        objFctryPlan.FileDescription = "OfflineApprovalRegistrationunderLAbourAct1996";
                        objFctryPlan.CreatedBy = hdnUserID.Value;
                        objFctryPlan.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objFctryPlan);
                        if (result != "")
                        {
                            hpl27LbrAct1996.Text = fup27LbrAct1996.PostedFile.FileName;
                            hpl27LbrAct1996.NavigateUrl = serverpath;
                            hpl27LbrAct1996.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld28ContrLbrAct_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup28ContrLbrAct.HasFile)
                {
                    Error = validations(fup28ContrLbrAct);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "28" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup28ContrLbrAct.PostedFile.SaveAs(serverpath + "\\" + fup28ContrLbrAct.PostedFile.FileName);

                        CFEAttachments objContrLbrAct = new CFEAttachments();
                        objContrLbrAct.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objContrLbrAct.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objContrLbrAct.ApprovalID = "28";
                        objContrLbrAct.DeptID = "10";
                        objContrLbrAct.FilePath = serverpath + fup28ContrLbrAct.PostedFile.FileName;
                        objContrLbrAct.FileName = fup28ContrLbrAct.PostedFile.FileName;
                        objContrLbrAct.FileType = fup28ContrLbrAct.PostedFile.ContentType;
                        objContrLbrAct.FileDescription = "OfflineApprovalRegistrationunderContractLAbourAct";
                        objContrLbrAct.CreatedBy = hdnUserID.Value;
                        objContrLbrAct.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objContrLbrAct);
                        if (result != "")
                        {
                            hpl5FctryPlan.Text = fup28ContrLbrAct.PostedFile.FileName;
                            hpl5FctryPlan.NavigateUrl = serverpath;
                            hpl5FctryPlan.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnUpld29ContrLbrAct1979_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup29ContrLbrAct1979.HasFile)
                {
                    Error = validations(fup29ContrLbrAct1979);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "29" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        fup29ContrLbrAct1979.PostedFile.SaveAs(serverpath + "\\" + fup29ContrLbrAct1979.PostedFile.FileName);

                        CFEAttachments objContrLbrAct1979 = new CFEAttachments();
                        objContrLbrAct1979.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objContrLbrAct1979.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objContrLbrAct1979.ApprovalID = "29";
                        objContrLbrAct1979.DeptID = "10";
                        objContrLbrAct1979.FilePath = serverpath + fup29ContrLbrAct1979.PostedFile.FileName;
                        objContrLbrAct1979.FileName = fup29ContrLbrAct1979.PostedFile.FileName;
                        objContrLbrAct1979.FileType = fup29ContrLbrAct1979.PostedFile.ContentType;
                        objContrLbrAct1979.FileDescription = "OfflineApprovalRegistrationunderConractLAbourAct1979";
                        objContrLbrAct1979.CreatedBy = hdnUserID.Value;
                        objContrLbrAct1979.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objContrLbrAct1979);
                        if (result != "")
                        {
                            hpl5FctryPlan.Text = fup29ContrLbrAct1979.PostedFile.FileName;
                            hpl5FctryPlan.NavigateUrl = serverpath;
                            hpl5FctryPlan.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnUpld30ConstrPermit_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup30ConstrPermit.HasFile)
                {
                    Error = validations(fup30ConstrPermit);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "30" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fup30ConstrPermit.PostedFile.SaveAs(serverpath + "\\" + fup30ConstrPermit.PostedFile.FileName);

                        CFEAttachments objFctryPlan = new CFEAttachments();
                        objFctryPlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objFctryPlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objFctryPlan.ApprovalID = "30";
                        objFctryPlan.DeptID = "0";
                        objFctryPlan.FilePath = serverpath + fup30ConstrPermit.PostedFile.FileName;
                        objFctryPlan.FileName = fup30ConstrPermit.PostedFile.FileName;
                        objFctryPlan.FileType = fup30ConstrPermit.PostedFile.ContentType;
                        objFctryPlan.FileDescription = "OfflineApprovalConstructionPermit";
                        objFctryPlan.CreatedBy = hdnUserID.Value;
                        objFctryPlan.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objFctryPlan);
                        if (result != "")
                        {
                            hpl30ConstrPermit.Text = fup30ConstrPermit.PostedFile.FileName;
                            hpl30ConstrPermit.NavigateUrl = serverpath;
                            hpl30ConstrPermit.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnUpld31BldngPlan_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fup31BldngPlan.HasFile)
                {
                    Error = validations(fup31BldngPlan);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "OfflineApprovals" + "\\" + "31" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        fup31BldngPlan.PostedFile.SaveAs(serverpath + "\\" + fup31BldngPlan.PostedFile.FileName);

                        CFEAttachments objBldngPlan = new CFEAttachments();
                        objBldngPlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objBldngPlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objBldngPlan.ApprovalID = "31";
                        objBldngPlan.DeptID = "0";
                        objBldngPlan.FilePath = serverpath + fup31BldngPlan.PostedFile.FileName;
                        objBldngPlan.FileName = fup31BldngPlan.PostedFile.FileName;
                        objBldngPlan.FileType = fup31BldngPlan.PostedFile.ContentType;
                        objBldngPlan.FileDescription = "OfflineApprovalBuildingPlanApproval";
                        objBldngPlan.CreatedBy = hdnUserID.Value;
                        objBldngPlan.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objBldngPlan);
                        if (result != "")
                        {
                            hpl5FctryPlan.Text = fup31BldngPlan.PostedFile.FileName;
                            hpl5FctryPlan.NavigateUrl = serverpath;
                            hpl5FctryPlan.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    message = "alert('" + "Please Upload Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }
        public string validations(FileUpload Attachment)
        {
            try
            {
                int slno = 1; string Error = "";
                if (Attachment.PostedFile.ContentType != "application/pdf"
                     || !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                {

                    if (Attachment.PostedFile.ContentType != "application/pdf")
                    {
                        Error = Error + slno + ". Please Upload PDF Documents only \\n";
                        slno = slno + 1;
                    }
                    if (!ValidateFileName(Attachment.PostedFile.FileName))
                    {
                        Error = Error + slno + ". Document name should not contain symbols like  <, >, %, $, @, &,=, / \\n";
                        slno = slno + 1;
                    }
                    else if (!ValidateFileExtension(Attachment))
                    {
                        Error = Error + slno + ". Document should not contain double extension (double . ) \\n";
                        slno = slno + 1;
                    }
                }
                return Error;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static bool ValidateFileName(string fileName)
        {
            try
            {
                string pattern = @"[<>%$@&=!:*?|]";

                if (Regex.IsMatch(fileName, pattern))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static bool ValidateFileExtension(FileUpload Attachment)
        {
            try
            {
                string Attachmentname = Attachment.PostedFile.FileName;
                string[] fileType = Attachmentname.Split('.');
                int i = fileType.Length;

                if (i == 2)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            { throw ex; }
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