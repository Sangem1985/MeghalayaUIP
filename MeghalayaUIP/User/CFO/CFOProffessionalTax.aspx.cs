using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOProffessionalTax : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
        string UnitID, ErrorMsg = "";
        protected void Page_Load(object sender, EventArgs e)
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
                if (Convert.ToString(Session["CFOUNITID"]) != "")
                { UnitID = Convert.ToString(Session["CFOUNITID"]); }
                else
                {
                    string newurl = "~/User/CFO/CFOUserDashboard.aspx";
                    Response.Redirect(newurl);
                }

                Page.MaintainScrollPositionOnPostBack = true;
                Failure.Visible = false;
                success.Visible = false;
                if (!IsPostBack)
                {
                    DataSet dsnew = new DataSet();
                    dsnew = objcfobal.GetApprovalDataByDeptId(Session["CFOQID"].ToString(), Session["CFOUNITID"].ToString(), "6");
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        if (Request.QueryString[0].ToString() == "N")
                        {
                            Response.Redirect("~/User/CFO/CFOFireDetails.aspx?next=N");
                        }
                        else
                        {
                            Response.Redirect("~/User/CFO/CFODrugLicenseDetails.aspx?Previous=P");
                        }
                    }
                    BindDistric();
                    Binddata();
                    BindRegType();
                    BindState();


                }
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfobal.GetCFODistricCouncile(hdnUserID.Value, UnitID);
                if (ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0 || ds.Tables[3].Rows.Count > 0 || ds.Tables[4].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[1].Rows[0]["CFOPT_CFOUNITID"]);

                        txtEstDet.Text = ds.Tables[1].Rows[0]["CFOPT_ESTBLSHNAME"].ToString();
                        txtaddress.Text = ds.Tables[1].Rows[0]["CFOPT_ESTBLSHADDRESS"].ToString();
                        ddlDistric.SelectedValue = ds.Tables[1].Rows[0]["CFOPT_ESTBLSHDISTID"].ToString();
                        txtPincode.Text = ds.Tables[1].Rows[0]["CFOPT_ESTBLSHPINCODE"].ToString();
                        txtEmployeeESt.Text = ds.Tables[1].Rows[0]["CFOPT_ESTBLSHEMP"].ToString();
                        txtGoodssupplie.Text = ds.Tables[1].Rows[0]["CFOPT_ESTBLSHGOODS"].ToString();
                        txtDate.Text = ds.Tables[1].Rows[0]["CFOPT_COMMENCEDDATE"].ToString();
                        txtIncome.Text = ds.Tables[1].Rows[0]["CFOPT_ANNUALINCOME"].ToString();
                        rblBusiness.SelectedValue = ds.Tables[1].Rows[0]["CFOPT_ADDLBSNESTATE"].ToString();
                        if (rblBusiness.SelectedValue == "Y")
                        {
                            Div2.Visible = true;
                        }
                        // rblBusiness_SelectedIndexChanged(null, EventArgs.Empty);
                        rblbusinessindia.SelectedValue = ds.Tables[1].Rows[0]["CFOPT_ADDLBSNECOUNTRY"].ToString();
                        if (rblbusinessindia.SelectedValue == "Y")
                        {
                            Div1.Visible = true;
                        }
                        //  rblbusinessindia_SelectedIndexChanged(null, EventArgs.Empty);
                        rblForeign.SelectedValue = ds.Tables[1].Rows[0]["CFOPT_ADDLBSNEFOREIGN"].ToString();
                        if (rblForeign.SelectedValue == "Y")
                        {
                            Address.Visible = true;
                        }
                        //  rblForeign_SelectedIndexChanged(null, EventArgs.Empty);
                        txtBranch.Text = ds.Tables[1].Rows[0]["CFOPT_BRANCHCERTNO"].ToString();
                        rblother.SelectedValue = ds.Tables[1].Rows[0]["CFOPT_HADANYREG"].ToString();
                        if (rblother.SelectedValue == "Y")
                        {
                            ddlRegType.SelectedValue = ds.Tables[1].Rows[0]["CFOPT_REGTYPE"].ToString();
                            TXTRegNo.Text = ds.Tables[1].Rows[0]["CFOPT_REGNO"].ToString();
                        }


                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[2].Rows[0]["CFOPS_CFOQDID"]);
                        ViewState["PROFESSIONALTAX"] = ds.Tables[2];
                        GVState.DataSource = ds.Tables[2];
                        GVState.DataBind();
                        GVState.Visible = true;
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[3].Rows[0]["CFOPC_CFOQDID"]);
                        ViewState["PROFESSIONALTAXCOUNTRY"] = ds.Tables[3];
                        GVCOUNTRY.DataSource = ds.Tables[3];
                        GVCOUNTRY.DataBind();
                        GVCOUNTRY.Visible = true;
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[4].Rows[0]["CFOPF_CFOQDID"]);
                        ViewState["PROFESSIONALTAXFOREIGN"] = ds.Tables[4];
                        GVFOREIGN.DataSource = ds.Tables[4];
                        GVFOREIGN.DataBind();
                        GVFOREIGN.Visible = true;
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rblBusiness_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblBusiness.SelectedValue == "Y")
            {
                AdditionDetails.Visible = true;
                AdditionPlace.Visible = true;
                totalemp.Visible = true;
            }
            else
            {
                AdditionDetails.Visible = false;
                AdditionPlace.Visible = false;
                totalemp.Visible = false;
            }
        }

        protected void rblother_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblother.SelectedValue == "Y")
            {
                RegistrationType.Visible = true;
                RegNo.Visible = true;
            }
            else
            {
                RegistrationType.Visible = false;
                RegNo.Visible = false;
            }
        }

        protected void rblForeign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblForeign.SelectedValue == "Y")
            {
                foreign.Visible = true;
                country.Visible = true;
                monthly.Visible = true;
                Address.Visible = true;
            }
            else
            {
                foreign.Visible = false;
                country.Visible = false;
                monthly.Visible = false;
                Address.Visible = false;
            }
        }

        protected void rblbusinessindia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblbusinessindia.SelectedValue == "Y")
            {
                Added.Visible = true;
            }
            else
            {
                Added.Visible = false;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            //String Quesstionriids = "1001";
            //string UnitId = "1001";

            try
            {
                string result = "";
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    CFOPROFESSIONALTAX ObjCFOPROFESSIONALTAX = new CFOPROFESSIONALTAX();

                    int count = 0, count1 = 0, count2 = 0;
                    for (int i = 0; i < GVState.Rows.Count; i++)
                    {
                        ObjCFOPROFESSIONALTAX.Questionnariid = Convert.ToString(Session["CFOQID"]); //Quesstionriids;;
                        ObjCFOPROFESSIONALTAX.CreatedBy = hdnUserID.Value;
                        ObjCFOPROFESSIONALTAX.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        ObjCFOPROFESSIONALTAX.IPAddress = getclientIP();
                        ObjCFOPROFESSIONALTAX.Business = GVState.Rows[i].Cells[1].Text;
                        ObjCFOPROFESSIONALTAX.Address = GVState.Rows[i].Cells[2].Text;
                        ObjCFOPROFESSIONALTAX.District = GVState.Rows[i].Cells[3].Text;
                        ObjCFOPROFESSIONALTAX.TotalworkingEMP = GVState.Rows[i].Cells[4].Text;



                        string A = objcfobal.INSERTCFOSTATETAX(ObjCFOPROFESSIONALTAX);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVState.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "PROFESSIONALTAX Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                    for (int i = 0; i < GVCOUNTRY.Rows.Count; i++)
                    {
                        ObjCFOPROFESSIONALTAX.Questionnariid = Convert.ToString(Session["CFOQID"]); ;
                        ObjCFOPROFESSIONALTAX.CreatedBy = hdnUserID.Value;
                        ObjCFOPROFESSIONALTAX.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        ObjCFOPROFESSIONALTAX.IPAddress = getclientIP();
                        ObjCFOPROFESSIONALTAX.PlaceBUSINESS = GVCOUNTRY.Rows[i].Cells[1].Text;
                        ObjCFOPROFESSIONALTAX.AddressEST = GVCOUNTRY.Rows[i].Cells[2].Text;
                        ObjCFOPROFESSIONALTAX.State = GVCOUNTRY.Rows[i].Cells[3].Text;
                        ObjCFOPROFESSIONALTAX.Totalworkingemployees = GVCOUNTRY.Rows[i].Cells[4].Text;



                        string A = objcfobal.INSERTCFOCOUNTRYTAX(ObjCFOPROFESSIONALTAX);
                        if (A != "")
                        { count1 = count + 1; }
                    }
                    if (GVCOUNTRY.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = " PROFESSIONALTAXCOUNTRY Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                    for (int i = 0; i < GVFOREIGN.Rows.Count; i++)
                    {
                        ObjCFOPROFESSIONALTAX.Questionnariid = Convert.ToString(Session["CFOQID"]);
                        ObjCFOPROFESSIONALTAX.CreatedBy = hdnUserID.Value;
                        ObjCFOPROFESSIONALTAX.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        ObjCFOPROFESSIONALTAX.IPAddress = getclientIP();
                        ObjCFOPROFESSIONALTAX.PrincipalWORK = GVFOREIGN.Rows[i].Cells[1].Text;
                        ObjCFOPROFESSIONALTAX.AddressWORK = GVFOREIGN.Rows[i].Cells[2].Text;
                        ObjCFOPROFESSIONALTAX.EmployerName = GVFOREIGN.Rows[i].Cells[3].Text;
                        ObjCFOPROFESSIONALTAX.MontlySalary = GVFOREIGN.Rows[i].Cells[4].Text;



                        string A = objcfobal.INSERTCFOFOREIGNTAX(ObjCFOPROFESSIONALTAX);
                        if (A != "")
                        { count2 = count + 1; }
                    }
                    if (GVFOREIGN.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "PROFESSIONALTAXCOUNTRY Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    ObjCFOPROFESSIONALTAX.UNITID = Convert.ToString(ViewState["CFOUNITID"]);
                    ObjCFOPROFESSIONALTAX.UNITID = Convert.ToString(Session["CFOUNITID"]);
                    ObjCFOPROFESSIONALTAX.CreatedBy = hdnUserID.Value;
                    ObjCFOPROFESSIONALTAX.IPAddress = getclientIP();
                    ObjCFOPROFESSIONALTAX.Questionnariid = Convert.ToString(Session["CFOQID"]);
                    // ObjCFOPROFESSIONALTAX.UnitId = UnitId;

                    ObjCFOPROFESSIONALTAX.NameEst = txtEstDet.Text.Trim();
                    ObjCFOPROFESSIONALTAX.AddressEst = txtaddress.Text;
                    ObjCFOPROFESSIONALTAX.DistrictEst = ddlDistric.SelectedValue;
                    ObjCFOPROFESSIONALTAX.PinCode = txtPincode.Text;
                    ObjCFOPROFESSIONALTAX.TotalEMP = txtEmployeeESt.Text;
                    ObjCFOPROFESSIONALTAX.SERVIOCEEST = txtGoodssupplie.Text;
                    ObjCFOPROFESSIONALTAX.Date = txtDate.Text;
                    ObjCFOPROFESSIONALTAX.GrossAnnual = txtIncome.Text;
                    ObjCFOPROFESSIONALTAX.BusinessPlace = rblBusiness.SelectedValue;
                    // ObjCFOPROFESSIONALTAX.Business= txtplacebusiness.Text;
                    //ObjCFOPROFESSIONALTAX.Address = txtadd.Text;
                    //ObjCFOPROFESSIONALTAX.District = ddldist.SelectedValue;
                    //ObjCFOPROFESSIONALTAX.TotalworkingEMP = txtEMP.Text;
                    ObjCFOPROFESSIONALTAX.BUSINESS = rblbusinessindia.SelectedValue;
                    //ObjCFOPROFESSIONALTAX.PlaceBUSINESS = txtBusinessplace.Text;
                    //ObjCFOPROFESSIONALTAX.AddressEST = txtAddeddet.Text;
                    //ObjCFOPROFESSIONALTAX.State = ddlState.SelectedValue;
                    //ObjCFOPROFESSIONALTAX.Totalworkingemployees = txtwork.Text;
                    ObjCFOPROFESSIONALTAX.FORIGEN = rblForeign.SelectedValue;
                    //ObjCFOPROFESSIONALTAX.PrincipalWORK = txtPrinciple.Text;
                    //ObjCFOPROFESSIONALTAX.AddressWORK = txtAdded.Text;
                    //ObjCFOPROFESSIONALTAX.EmployerName = txtEmployee.Text;
                    //ObjCFOPROFESSIONALTAX.MontlySalary = txtsalary.Text;
                    ObjCFOPROFESSIONALTAX.Branch = txtBranch.Text;
                    ObjCFOPROFESSIONALTAX.RegUnderAct = rblother.SelectedValue;
                    ObjCFOPROFESSIONALTAX.RegistrationType = ddlRegType.SelectedValue;
                    ObjCFOPROFESSIONALTAX.RegisrationNo = TXTRegNo.Text;


                    result = objcfobal.InsertCFOProfessionalTax(ObjCFOPROFESSIONALTAX);
                    ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "PROFESSIONALTAX Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtEstDet.Text.Trim()) || txtEstDet.Text.Trim() == "" || txtEstDet.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name Of Establishment \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtaddress.Text) || txtaddress.Text == "" || txtaddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address\\n";
                    slno = slno + 1;
                }
                if (ddlDistric.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select Distric \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPincode.Text) || txtPincode.Text == "" || txtPincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Picode\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmployeeESt.Text) || txtEmployeeESt.Text == "" || txtEmployeeESt.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Employee Establishment\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtGoodssupplie.Text) || txtGoodssupplie.Text == "" || txtGoodssupplie.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Description of Goods and Services\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDate.Text) || txtDate.Text == "" || txtDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Date\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIncome.Text) || txtIncome.Text == "" || txtIncome.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Gross Annual Income\\n";
                    slno = slno + 1;
                }
                if (rblBusiness.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Yes or No Additional Place of Business in MEGHALAYA \\n";
                    slno = slno + 1;
                }
                if (rblBusiness.SelectedValue == "Y")
                {
                    if (GVState.Rows.Count <= 0)
                    {
                        errormsg = errormsg + slno + ". Please Enter Additional Place of Business Details \\n";
                        slno = slno + 1;
                    }
                }
                if (rblbusinessindia.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Yes or No Additional Place of Business in INDIA \\n";
                    slno = slno + 1;
                }
                if (rblbusinessindia.SelectedValue == "Y")
                {
                    if (GVCOUNTRY.Rows.Count <= 0)
                    {
                        errormsg = errormsg + slno + ". Please Enter Additional Place of Business Details \\n";
                        slno = slno + 1;
                    }
                }
                if (rblForeign.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Yes or No Whether office from foreign country?  \\n";
                    slno = slno + 1;
                }
                if (rblForeign.SelectedValue == "Y")
                {
                    if (GVFOREIGN.Rows.Count <= 0)
                    {
                        errormsg = errormsg + slno + ". Please Enter Other Details \\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtBranch.Text) || txtBranch.Text == "" || txtBranch.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Branch Cretificate\\n";
                    slno = slno + 1;
                }
                if (rblother.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Yes or No Do you have registration under any other act? \\n";
                    slno = slno + 1;
                }
                if (rblother.SelectedValue == "Y")
                {
                    //RegistrationType.Visible = true;
                    //if (ddlRegType.SelectedIndex == 0)
                    //{
                    //    errormsg = errormsg + slno + ". Please Enter Registration Type\\n";
                    //    slno = slno + 1;
                    //}

                    RegNo.Visible = true;
                    if (string.IsNullOrEmpty(TXTRegNo.Text) || TXTRegNo.Text == "" || TXTRegNo.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Regisration No\\n";
                        slno = slno + 1;
                    }

                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtplacebusiness.Text.Trim()) || string.IsNullOrEmpty(txtadd.Text) || string.IsNullOrEmpty(txtEMP.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFOPS_CFOUNITID", typeof(string));
                    dt.Columns.Add("CFOPS_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFOPS_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFOPS_PLACEBUSINESS", typeof(string));
                    dt.Columns.Add("CFOPS_ADDRESS", typeof(string));
                    dt.Columns.Add("CFOPS_DISTRIC", typeof(string));
                    dt.Columns.Add("CFOPS_TOTALEMP", typeof(string));


                    if (ViewState["PROFESSIONALTAX"] != null)
                    {
                        dt = (DataTable)ViewState["PROFESSIONALTAX"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFOPS_CFOUNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["CFOPS_CREATEDBY"] = hdnUserID.Value;
                    dr["CFOPS_CREATEDBYIP"] = getclientIP();
                    dr["CFOPS_PLACEBUSINESS"] = txtplacebusiness.Text.Trim();
                    dr["CFOPS_ADDRESS"] = txtadd.Text;
                    dr["CFOPS_DISTRIC"] = ddldist.SelectedItem.Text;
                    dr["CFOPS_TOTALEMP"] = txtEMP.Text;


                    dt.Rows.Add(dr);
                    GVState.Visible = true;
                    GVState.DataSource = dt;
                    GVState.DataBind();
                    ViewState["PROFESSIONALTAX"] = dt;

                    txtplacebusiness.Text = "";
                    txtadd.Text = "";
                    txtEMP.Text = "";
                    ddldist.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAdeed_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBusinessplace.Text.Trim()) || string.IsNullOrEmpty(txtAddeddet.Text) || string.IsNullOrEmpty(txtwork.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFOPC_CFOUNITID", typeof(string));
                    dt.Columns.Add("CFOPC_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFOPC_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFOPC_PLACEBUSINESS", typeof(string));
                    dt.Columns.Add("CFOPC_ADDRESS", typeof(string));
                    dt.Columns.Add("CFOPC_STATE", typeof(string));
                    dt.Columns.Add("CFOPC_TOTALEMP", typeof(string));


                    if (ViewState["PROFESSIONALTAXCOUNTRY"] != null)
                    {
                        dt = (DataTable)ViewState["PROFESSIONALTAXCOUNTRY"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFOPC_CFOUNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["CFOPC_CREATEDBY"] = hdnUserID.Value;
                    dr["CFOPC_CREATEDBYIP"] = getclientIP();
                    dr["CFOPC_PLACEBUSINESS"] = txtBusinessplace.Text.Trim();
                    dr["CFOPC_ADDRESS"] = txtAddeddet.Text;
                    dr["CFOPC_STATE"] = ddlState.SelectedItem.Text;
                    dr["CFOPC_TOTALEMP"] = txtwork.Text;


                    dt.Rows.Add(dr);
                    GVCOUNTRY.Visible = true;
                    GVCOUNTRY.DataSource = dt;
                    GVCOUNTRY.DataBind();
                    ViewState["PROFESSIONALTAXCOUNTRY"] = dt;

                    txtBusinessplace.Text = "";
                    txtAddeddet.Text = "";
                    ddlState.ClearSelection();
                    txtwork.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Addedbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPrinciple.Text.Trim()) || string.IsNullOrEmpty(txtAdded.Text) || string.IsNullOrEmpty(txtEmployee.Text.Trim()) || string.IsNullOrEmpty(txtsalary.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFOPF_CFOUNITID", typeof(string));
                    dt.Columns.Add("CFOPF_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFOPF_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFOPF_PRINCIPLEWORK", typeof(string));
                    dt.Columns.Add("CFOPF_ADDRESS", typeof(string));
                    dt.Columns.Add("CFOPF_EMPNAME", typeof(string));
                    dt.Columns.Add("CFOPF_MONTHLYWAGES", typeof(string));


                    if (ViewState["PROFESSIONALTAXFOREIGN"] != null)
                    {
                        dt = (DataTable)ViewState["PROFESSIONALTAXFOREIGN"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFOPF_CFOUNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["CFOPF_CREATEDBY"] = hdnUserID.Value;
                    dr["CFOPF_CREATEDBYIP"] = getclientIP();
                    dr["CFOPF_PRINCIPLEWORK"] = txtPrinciple.Text.Trim();
                    dr["CFOPF_ADDRESS"] = txtAdded.Text;
                    dr["CFOPF_EMPNAME"] = txtEmployee.Text.Trim();
                    dr["CFOPF_MONTHLYWAGES"] = txtsalary.Text;


                    dt.Rows.Add(dr);
                    GVFOREIGN.Visible = true;
                    GVFOREIGN.DataSource = dt;
                    GVFOREIGN.DataBind();
                    ViewState["PROFESSIONALTAXFOREIGN"] = dt;

                    txtPrinciple.Text = "";
                    txtAdded.Text = "";
                    txtEmployee.Text = "";
                    txtsalary.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFO/CFOFireDetails.aspx?next=N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
            // Response.Redirect("~/User/CFO/CFOFireDetails.aspx?next=N");
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFO/CFODrugLicenseDetails.aspx?Previous=P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
            //  Response.Redirect("~/User/CFO/CFODrugLicenseDetails.aspx?Previous=P");
        }
        protected void BindDistric()
        {
            try
            {
                ddlDistric.Items.Clear();
                ddldist.Items.Clear();

                List<MasterDistric> objDistricModel = new List<MasterDistric>();

                objDistricModel = mstrBAL.GetDistric();
                if (objDistricModel != null)
                {
                    ddlDistric.DataSource = objDistricModel;
                    ddlDistric.DataValueField = "DISTRIC_ID";
                    ddlDistric.DataTextField = "DISTRIC_NAME";
                    ddlDistric.DataBind();

                    ddldist.DataSource = objDistricModel;
                    ddldist.DataValueField = "DISTRIC_ID";
                    ddldist.DataTextField = "DISTRIC_NAME";
                    ddldist.DataBind();
                }
                else
                {
                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();

                    ddldist.DataSource = null;
                    ddldist.DataBind();
                }
                AddSelect(ddlDistric);
                AddSelect(ddldist);
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
        protected void BindRegType()
        {
            try
            {
                ddlRegType.Items.Clear();

                List<MasterREGTYPE> objRegTypeModel = new List<MasterREGTYPE>();

                objRegTypeModel = mstrBAL.GetRegType();
                if (objRegTypeModel != null)
                {
                    ddlRegType.DataSource = objRegTypeModel;
                    ddlRegType.DataValueField = "REGISTRATIONTYPE_ID";
                    ddlRegType.DataTextField = "REGISTRATIONTYPE_NAME";
                    ddlRegType.DataBind();
                }
                else
                {
                    ddlRegType.DataSource = null;
                    ddlRegType.DataBind();
                }
                AddSelect(ddlRegType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindState()
        {
            try
            {
                ddlState.Items.Clear();

                List<MasterStates> objRegTypeModel = new List<MasterStates>();

                objRegTypeModel = mstrBAL.GetStates();
                if (objRegTypeModel != null)
                {
                    ddlState.DataSource = objRegTypeModel;
                    ddlState.DataValueField = "StateId";
                    ddlState.DataTextField = "StateName";
                    ddlState.DataBind();
                }
                else
                {
                    ddlState.DataSource = null;
                    ddlState.DataBind();
                }
                AddSelect(ddlState);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GVState_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVState.Rows.Count > 0)
                {
                    ((DataTable)ViewState["PROFESSIONALTAX"]).Rows.RemoveAt(e.RowIndex);
                    this.GVState.DataSource = ((DataTable)ViewState["PROFESSIONALTAX"]).DefaultView;
                    this.GVState.DataBind();
                    GVState.Visible = true;
                    GVState.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void GVCOUNTRY_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVCOUNTRY.Rows.Count > 0)
                {
                    ((DataTable)ViewState["PROFESSIONALTAXCOUNTRY"]).Rows.RemoveAt(e.RowIndex);
                    this.GVCOUNTRY.DataSource = ((DataTable)ViewState["PROFESSIONALTAXCOUNTRY"]).DefaultView;
                    this.GVCOUNTRY.DataBind();
                    GVCOUNTRY.Visible = true;
                    GVCOUNTRY.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void GVFOREIGN_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVFOREIGN.Rows.Count > 0)
                {
                    ((DataTable)ViewState["PROFESSIONALTAXFOREIGN"]).Rows.RemoveAt(e.RowIndex);
                    this.GVFOREIGN.DataSource = ((DataTable)ViewState["PROFESSIONALTAXFOREIGN"]).DefaultView;
                    this.GVFOREIGN.DataBind();
                    GVFOREIGN.Visible = true;
                    GVFOREIGN.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
    }
}