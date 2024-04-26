using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegApplIMAProcess : System.Web.UI.Page
    {
        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
        DropDownList ddldepartment;
        DataTable dt = new DataTable();
        List<PreRegDtls> lstPreRegDtlsVo = new List<PreRegDtls>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                success.Visible = false;
                Failure.Visible = false;
                if (!IsPostBack)
                {
                    var ObjUserInfo = new DeptUserInfo();
                    if (Session["DeptUserInfo"] != null)
                    {
                        if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                        {
                            ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                        }
                        // username = ObjUserInfo.UserName;
                    }
                    BindaApplicatinDetails();
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        public void BindaApplicatinDetails()
        {
            try
            {
                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {

                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    // username = ObjUserInfo.UserName;
                }

                if (Session["UNITID"] != null && Session["INVESTERID"] != null && Session["stage"] != null)
                {
                    prd.Unitid = Session["UNITID"].ToString();
                    prd.Investerid = Session["INVESTERID"].ToString();
                    prd.UserID = ObjUserInfo.UserID;
                    prd.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                    prd.Stage = Convert.ToInt32(Session["stage"]);
                    if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                    {
                        prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    }
                    DataSet ds = new DataSet();
                    ds = PreBAL.GetPreRegNodelOfficer(prd);


                    DataRow row = ds.Tables[0].Rows[0];
                    lblCompanyName.Text = Convert.ToString(row["COMPANYNAME"]);
                    lblCompanyPAN.Text = Convert.ToString(row["COMPANYPANNO"]);
                    lblCompanyType.Text = Convert.ToString(row["COMPANYTYPE"]);
                    lblregdate.Text = Convert.ToString(row["REGISTRATIONDATE"]);
                    lblUdyam.Text = Convert.ToString(row["UDYAMNO"]);
                    lblGSTIN.Text = Convert.ToString(row["GSTNNO"]);
                    lblName.Text = Convert.ToString(row["REP_NAME"]);
                    lblMobile.Text = Convert.ToString(row["REP_MOBILE"]);
                    lblEmail.Text = Convert.ToString(row["REP_EMAIL"]);
                    lblLocality.Text = Convert.ToString(row["REP_LOCALITY"]);
                    lblDistict.Text = Convert.ToString(row["REP_DISTRICT"]);
                    lblMandal.Text = Convert.ToString(row["REP_MANDAL"]);
                    lblVillage.Text = Convert.ToString(row["REP_VILLAGE"]);
                    lblPincode.Text = Convert.ToString(row["REP_PINCODE"]);
                    lblPincode.Text = Convert.ToString(row["REP_PINCODE"]);
                    //lblLandtype.Text= Convert.ToString(row["UNIT_LANDTYPE"]);
                    lbldrno.Text = Convert.ToString(row["UNIT_DOORNO"]);
                    lblPro_loc.Text = Convert.ToString(row["UNIT_LOCALITY"]);
                    lblpro_dis.Text = Convert.ToString(row["UNIT_DISTRICT"]);
                    lblPro_Man.Text = Convert.ToString(row["UNIT_MANDAL"]);
                    lblPro_vill.Text = Convert.ToString(row["UNIT_VILLAGE"]);
                    lblPro_Pin.Text = Convert.ToString(row["UNIT_PINCODE"]);

                    lblDateofcomm.Text = Convert.ToString(row["PROJECT_DCP"]);
                    lblNatureofAct.Text = Convert.ToString(row["PROJECT_NOA"]);
                    if (lblNatureofAct.Text == "Manufacturing")
                        divManf.Visible = true;
                    else divServc.Visible = true;
                    lblMainmanuf.Text = Convert.ToString(row["PROJECT_MANFACTIVITY"]);
                    lblmanufProdct.Text = Convert.ToString(row["PROJECT_MANFPRODUCT"]);
                    lblProdNo.Text = Convert.ToString(row["PROJECT_MANFPRODNO"]);

                    lblMainSrvc.Text = Convert.ToString(row["PROJECT_SRVCACTIVITY"]);
                    lblSrvcProvdng.Text = Convert.ToString(row["PROJECT_SRVCNAME"]);
                    lblSrvcNo.Text = Convert.ToString(row["PROJECT_SRVCNO"]);

                    lblSector.Text = Convert.ToString(row["PROJECT_SECTORNAME"]);
                    lblLOA.Text = Convert.ToString(row["LineofActivity_Name"]);
                    lblPCBcatogry.Text = Convert.ToString(row["PROJECT_PCBCATEGORY"]);

                    lblmainRM.Text = Convert.ToString(row["PROJECT_MAINRM"]);
                    lblwastedtls.Text = Convert.ToString(row["PROJECT_WASTEDETAILS"]);
                    lblhazdtls.Text = Convert.ToString(row["PROJECT_HAZWASTEDETAILS"]);
                    lblcivilConstr.Text = Convert.ToString(row["PROJECT_CIVILCONSTR"]);
                    lbllandArea.Text = Convert.ToString(row["PROJECT_LANDAREA"]);
                    lblBuildingArea.Text = Convert.ToString(row["PROJECT_BUILDINGAREA"]);

                    lblWaterReq.Text = Convert.ToString(row["PROJECT_WATERREQ"]);
                    lblPowerReq.Text = Convert.ToString(row["PROJECT_POWERRREQ"]);
                    lblunitofmeasure.Text = Convert.ToString(row["PROJECT_UNITOFMEASURE"]);
                    lblAnnualCap.Text = Convert.ToString(row["PROJECT_ANNUALCAPACITY"]);
                    lblEstProjcost.Text = Convert.ToString(row["PROJECT_EPCOST"]);
                    lblPMCost.Text = Convert.ToString(row["PROJECT_PMCOST"]);
                    lblIFC.Text = Convert.ToString(row["PROJECT_IFC"]);
                    lblDFA.Text = Convert.ToString(row["PROJECT_DFA"]);
                    lblBuldingValue.Text = Convert.ToString(row["PROJECT_BUILDINGVALUE"]);
                    lblLandValue.Text = Convert.ToString(row["PROJECT_LANDVALUE"]);
                    lblWaterValue.Text = Convert.ToString(row["PROJECT_WATERVALUE"]);
                    lblElectricityValue.Text = Convert.ToString(row["PROJECT_ELECTRICITYVALUE"]);
                    lblWorkingCapital.Text = Convert.ToString(row["PROJECT_WORKINGCAPITAL"]);

                    lblCapitalSubsidy.Text = Convert.ToString(row["FRD_CAPITALSUBSIDY"]);
                    lblPromoterEquity.Text = Convert.ToString(row["FRD_PROMOTEREQUITY"]);
                    lblLoan.Text = Convert.ToString(row["FRD_LOAN"]);
                    lbl_Name1.Text = Convert.ToString(row["REP_NAME"]);
                    lblunitname1.Text = Convert.ToString(row["REP_NAME"]);
                    lblApplNo.Text = Convert.ToString(row["PREREGUIDNO"]);
                    lblapplDate.Text = Convert.ToString(row["REP_MOBILE"]);
                    lblapplDate.Text = Convert.ToString(row["CREATEDDATE"]);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                    {
                        grdRevenueProj.DataSource = ds.Tables[1];
                        grdRevenueProj.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[2].Rows.Count > 0)
                    {
                        grdDirectors.DataSource = ds.Tables[2];
                        grdDirectors.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
                    {
                        grdApplStatus.DataSource = ds.Tables[3];
                        grdApplStatus.DataBind();
                    }

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[4].Rows.Count > 0)
                    {
                        grdQueries.DataSource = ds.Tables[4];
                        grdQueries.DataBind();

                    }

                    grdQryAttachments.DataSource = null;
                    grdQryAttachments.DataBind();
                    if(Request.QueryString["status"].ToString()== "IMATOBEPROCESSED" || Request.QueryString["status"].ToString() == "IMAQUERYREPLIED")
                    {
                        verifypanel.Visible = true;
                    }
                    else
                    {
                        verifypanel.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {

                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    // username = ObjUserInfo.UserName;
                }
                if (ddlStatus.SelectedValue == "7" || ddlStatus.SelectedValue == "11")
                {
                    if ((ddlStatus.SelectedValue == "7") && (string.IsNullOrWhiteSpace(txtRequest.Text) || txtRequest.Text == "" || txtRequest.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Query Description";
                        Failure.Visible = true;
                        return;
                    }

                    else
                    {
                        prd.Unitid = Session["UNITID"].ToString();
                        prd.Investerid = Session["INVESTERID"].ToString();
                        if (ddlStatus != null)
                            prd.status = Convert.ToInt32(ddlStatus.SelectedValue);
                        prd.UserID = ObjUserInfo.UserID;
                        if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                        {
                            prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                        }
                        prd.Remarks = txtRequest.Text;

                        var Hostname = Dns.GetHostName();
                        prd.IPAddress = Dns.GetHostByName(Hostname).AddressList[0].ToString();
                        if (ddlStatus.SelectedValue == "11")
                        {
                            string valid = PreBAL.PreRegApprovals(prd);
                            btnSubmit.Enabled = false;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Submitted Successfully!');  window.location.href='PreRegApplIMADashBoard.aspx'", true);
                            return;
                        }


                    }
                }
                else
                {
                    lblmsg0.Text = "Please Select Action";
                    Failure.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatus.SelectedValue == "11")
                {
                    int value = ddlStatus.SelectedIndex;
                    tdquryorrej.Visible = true;
                    tdquryorrejTxtbx.Visible = true;
                    txtRequest.Focus();
                    tdquery.Visible = false;
                    btnSubmit.Visible = true;
                    btnQuery.Visible = false;
                    tdaction.Visible = true;
                }
                else
                {
                    tdquryorrej.Visible = false;
                    tdquryorrejTxtbx.Visible = false;
                    tdquery.Visible = true;
                    btnSubmit.Visible = false;
                    gvdeptquery.DataSource = BindWorkerPlaceGrid();
                    gvdeptquery.DataBind();
                    btnQuery.Visible = true;
                    tdaction.Visible = false;
                }

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }


        }

        protected void gvdeptquery_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                int valid = 0;
                if (e.CommandName == "Add")
                {
                    dt = BindWorkerPlaceGridAdd();

                    DropDownList ddldepartment;
                    TextBox txtquery;

                    String[] arraydata = new String[2];

                    int gvrcnt = gvdeptquery.Rows.Count;
                    decimal extent = 0;
                    for (int i = 0; i < gvrcnt; i++)
                    {
                        ddldepartment = (DropDownList)gvdeptquery.Rows[i].Cells[1].Controls[1];
                        arraydata[0] = ddldepartment.SelectedValue;
                        GridViewRow gvr = gvdeptquery.Rows[i];
                        txtquery = (TextBox)gvr.FindControl("txtquery");
                        arraydata[1] = txtquery.Text;

                        if (txtquery.Text == "")// || txtEnjExtent.Value == "")
                        {
                            valid = 1;
                            lblmsg.Text = "Please enter Query details";
                            lblmsg.CssClass = "errormsg";
                        }

                        dt.Rows[i].ItemArray = arraydata;
                        DataRow dRow;
                        dRow = null;
                        dRow = dt.NewRow();
                        dt.Rows.Add(dRow);
                    }


                    if (valid == 0)
                    {
                        ViewState["dtWorkerDtls"] = dt;
                        gvdeptquery.DataSource = dt;
                        gvdeptquery.DataBind();
                    }
                    //SetFocus(gvEnjoyer);
                }
                else if (e.CommandName == "Remove")
                {
                    int gvrcnt = gvdeptquery.Rows.Count;
                    if (gvrcnt > 1)
                    {
                        dt = BindWorkerPlaceGridAdd();
                        DropDownList ddldepartment;
                        TextBox txtquery;
                        String[] arraydata = new String[2];

                        int j = Convert.ToInt32(e.CommandArgument);
                        decimal extent = 0;
                        int i;
                        for (i = 0; i < gvrcnt; i++)
                        {

                            if (i != j)
                            {
                                ddldepartment = (DropDownList)gvdeptquery.Rows[i].Cells[1].Controls[1];
                                arraydata[0] = ddldepartment.SelectedValue;
                                GridViewRow gvr = gvdeptquery.Rows[i];
                                txtquery = (TextBox)gvr.FindControl("txtquery");
                                arraydata[1] = txtquery.Text;

                                if (j == 0)
                                    dt.Rows[i - 1].ItemArray = arraydata;
                                else
                                    dt.Rows[i].ItemArray = arraydata;


                                DataRow dRow;
                                dRow = null;
                                dRow = dt.NewRow();
                                dt.Rows.Add(dRow);
                            }
                        }
                        dt.Rows.RemoveAt(i - 1);
                        ViewState["dtWorkerDtls"] = dt;
                        gvdeptquery.DataSource = dt;
                        gvdeptquery.DataBind();
                    }
                    else
                    {
                        lblmsg.Text = "Cannot remove the details, Please modify";
                        lblmsg.CssClass = "errormsg";
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.CssClass = "errormsg";
            }
        }

        protected void gvdeptquery_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {
                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    // username = ObjUserInfo.UserName;
                }

                DataSet dsdepartments = new DataSet();
                dsdepartments = PreBAL.GetDeptMst(Session["UNITID"].ToString(), ObjUserInfo.UserID);
                if (dsdepartments != null && dsdepartments.Tables.Count > 0 && dsdepartments.Tables[0].Rows.Count > 0)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        ddldepartment = (DropDownList)e.Row.Cells[1].Controls[1];

                        ddldepartment.DataSource = dsdepartments.Tables[0];
                        ddldepartment.DataTextField = "MD_DEPT_NAME";
                        ddldepartment.DataValueField = "MD_DEPTID";
                        ddldepartment.DataBind();

                        AddSelect(ddldepartment);

                        //var department = ddldepartment.Items.FindByValue(ddldepartment.SelectedValue);
                        //ddldepartment.Items.Remove(department);

                        DataTable dt = (DataTable)ViewState["dtWorkerDtls"];

                        if (dt != null)
                        {
                            if (e.Row.RowIndex < dt.Rows.Count)
                            {
                                GridViewRow gvr = e.Row;
                                TextBox txtquery = (TextBox)gvr.FindControl("txtquery");

                                txtquery.Text = dt.Rows[e.Row.RowIndex]["Query"].ToString();
                                ddldepartment.SelectedValue = dt.Rows[e.Row.RowIndex]["Departments"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.CssClass = "errormsg";
            }

        }

        protected DataTable BindWorkerPlaceGridAdd()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Departments");
            dt.Columns.Add("Query");
            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "";

            dt.Rows.Add(dr);
            return dt;
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.CssClass = "errormsg";
            }
        }
        protected DataTable BindWorkerPlaceGrid()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Departments");

            DataRow dr = dt.NewRow();
            dr[0] = "";

            dt.Rows.Add(dr);

            return dt;
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {

                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    // username = ObjUserInfo.UserName;
                }
                PreRegDtls PreRegDtlsVo = new PreRegDtls();
                foreach (GridViewRow gvrow in gvdeptquery.Rows)
                {
                    DropDownList ddldepartment = (DropDownList)gvrow.FindControl("ddldepartment");
                    TextBox txtquery = (TextBox)gvrow.FindControl("txtquery");
                    PreRegDtlsVo.QuerytoDeptID = ddldepartment.SelectedValue;
                   // PreRegDtlsVo.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    PreRegDtlsVo.DeptDesc = ddldepartment.SelectedItem.Text.Trim();
                    PreRegDtlsVo.Remarks = txtquery.Text.Trim();
                    PreRegDtlsVo.Unitid = Session["UNITID"].ToString();
                    PreRegDtlsVo.Investerid = Session["INVESTERID"].ToString();
                    if (ddlStatus != null)
                        PreRegDtlsVo.status = Convert.ToInt32(ddlStatus.SelectedValue);
                    PreRegDtlsVo.UserID = ObjUserInfo.UserID;
                    //lstPreRegDtlsVo.Add(PreRegDtlsVo);
                    var Hostname = Dns.GetHostName();
                    PreRegDtlsVo.IPAddress = Dns.GetHostByName(Hostname).AddressList[0].ToString();
                    string valid = PreBAL.PreRegUpdateQuery(PreRegDtlsVo);
                }
                btnQuery.Enabled = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Query Raised Successfully!');  window.location.href='PreRegApplIMADashBoard.aspx'", true);
                return;
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
    }
}