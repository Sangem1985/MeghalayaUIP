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
        string UnitID;
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
                UnitID = Convert.ToString(Session["CFOUNITID"]);
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
                }
            }
        }

        protected void rblBusiness_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblBusiness.SelectedItem.Text == "Yes")
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
            if (rblother.SelectedItem.Text == "Yes")
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
            if (rblForeign.SelectedItem.Text == "Yes")
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
            if (rblbusinessindia.SelectedItem.Text == "Yes")
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
            String Quesstionriids = "1001";
            string UnitId = "1001";

            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Validations();
                {
                    CFOPROFESSIONALTAX ObjCFOPROFESSIONALTAX = new CFOPROFESSIONALTAX();

                    int count = 0, count1 = 0, count2 = 0;
                    for (int i = 0; i < GVState.Rows.Count; i++)
                    {
                        ObjCFOPROFESSIONALTAX.Questionnariid = Quesstionriids;
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
                        lblmsg.Text = "CFO PROFESSIONALTAX Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                    for (int i = 0; i < GVCOUNTRY.Rows.Count; i++)
                    {
                        ObjCFOPROFESSIONALTAX.Questionnariid = Quesstionriids;
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
                        lblmsg.Text = "CFO PROFESSIONALTAXCOUNTRY Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                    for (int i = 0; i < GVFOREIGN.Rows.Count; i++)
                    {
                        ObjCFOPROFESSIONALTAX.Questionnariid = Quesstionriids;
                        ObjCFOPROFESSIONALTAX.CreatedBy = hdnUserID.Value;
                        ObjCFOPROFESSIONALTAX.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        ObjCFOPROFESSIONALTAX.IPAddress = getclientIP();
                        ObjCFOPROFESSIONALTAX.PrincipalWORK = GVCOUNTRY.Rows[i].Cells[1].Text;
                        ObjCFOPROFESSIONALTAX.AddressWORK = GVCOUNTRY.Rows[i].Cells[2].Text;
                        ObjCFOPROFESSIONALTAX.EmployerName = GVCOUNTRY.Rows[i].Cells[3].Text;
                        ObjCFOPROFESSIONALTAX.MontlySalary = GVCOUNTRY.Rows[i].Cells[4].Text;



                        string A = objcfobal.INSERTCFOFOREIGNTAX(ObjCFOPROFESSIONALTAX);
                        if (A != "")
                        { count2 = count + 1; }
                    }
                    if (GVFOREIGN.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "CFO PROFESSIONALTAXCOUNTRY Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }





                    { ObjCFOPROFESSIONALTAX.UNITID = Convert.ToString(ViewState["UnitID"]); }
                    ObjCFOPROFESSIONALTAX.CreatedBy = hdnUserID.Value;
                    ObjCFOPROFESSIONALTAX.IPAddress = getclientIP();
                    ObjCFOPROFESSIONALTAX.Questionnariid = Quesstionriids;
                    ObjCFOPROFESSIONALTAX.UnitId = UnitId;

                    ObjCFOPROFESSIONALTAX.NameEst = txtEstDet.Text;
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
                        lblmsg.Text = "CFO legalMetrology Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
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
                if (string.IsNullOrEmpty(txtEstDet.Text) || txtEstDet.Text == "" || txtEstDet.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name Of Establishment \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtaddress.Text) || txtaddress.Text == "" || txtaddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address\\n";
                    slno = slno + 1;
                }
                if (ddlDistric.SelectedIndex == -1 || ddlDistric.SelectedItem.Text == "--Select--")
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
                if (rblBusiness.SelectedIndex == -1 || rblBusiness.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Place of Business in Meghalaya \\n";
                    slno = slno + 1;
                }
                if (rblbusinessindia.SelectedIndex == -1 || rblbusinessindia.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Place of Business in India \\n";
                    slno = slno + 1;
                }
                if (rblForeign.SelectedIndex == -1 || rblForeign.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Foreign Country \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBranch.Text) || txtBranch.Text == "" || txtBranch.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Branch Cretificate\\n";
                    slno = slno + 1;
                }
                if (rblother.SelectedIndex == -1 || rblother.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select registration under any other act \\n";
                    slno = slno + 1;
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
                if (string.IsNullOrEmpty(txtplacebusiness.Text) || string.IsNullOrEmpty(txtadd.Text) || string.IsNullOrEmpty(txtEMP.Text))
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
                    dr["CFOPS_PLACEBUSINESS"] = txtplacebusiness.Text;
                    dr["CFOPS_ADDRESS"] = txtadd.Text;
                    dr["CFOPS_DISTRIC"] = ddldist.SelectedItem.Text;
                    dr["CFOPS_TOTALEMP"] = txtEMP.Text;


                    dt.Rows.Add(dr);
                    GVState.Visible = true;
                    GVState.DataSource = dt;
                    GVState.DataBind();
                    ViewState["PROFESSIONALTAX"] = dt;
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
                if (string.IsNullOrEmpty(txtBusinessplace.Text) || string.IsNullOrEmpty(txtAddeddet.Text) || string.IsNullOrEmpty(txtwork.Text))
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
                    dr["CFOPC_PLACEBUSINESS"] = txtBusinessplace.Text;
                    dr["CFOPC_ADDRESS"] = txtAddeddet.Text;
                    dr["CFOPC_STATE"] = ddlState.SelectedItem.Text;
                    dr["CFOPC_TOTALEMP"] = txtwork.Text;


                    dt.Rows.Add(dr);
                    GVCOUNTRY.Visible = true;
                    GVCOUNTRY.DataSource = dt;
                    GVCOUNTRY.DataBind();
                    ViewState["PROFESSIONALTAXCOUNTRY"] = dt;
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
                if (string.IsNullOrEmpty(txtPrinciple.Text) || string.IsNullOrEmpty(txtAdded.Text) || string.IsNullOrEmpty(txtEmployee.Text) || string.IsNullOrEmpty(txtsalary.Text))
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
                    dr["CFOPF_PRINCIPLEWORK"] = txtPrinciple.Text;
                    dr["CFOPF_ADDRESS"] = txtAdded.Text;
                    dr["CFOPF_EMPNAME"] = txtEmployee.Text;
                    dr["CFOPF_MONTHLYWAGES"] = txtsalary.Text;


                    dt.Rows.Add(dr);
                    GVFOREIGN.Visible = true;
                    GVFOREIGN.DataSource = dt;
                    GVFOREIGN.DataBind();
                    ViewState["PROFESSIONALTAXFOREIGN"] = dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/CFO/CFOFireDetails.aspx?next=N");
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/CFO/CFODrugLicenseDetails.aspx?Previous=P");
        }
    }
}