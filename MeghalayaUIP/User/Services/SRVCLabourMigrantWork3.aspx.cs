using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCLabourMigrantWork3 : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string ErrorMsg = "", result = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objSrvcbal.GetSRVCLabourAct2020DETAILS(Convert.ToString(Session["SRVCQID"]), hdnUserID.Value);

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {


                        txtName.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblApplication.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblcrime.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);

                        rblmind.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtEmpDesignation.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtEmpDate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);

                        txtDurationstay.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtDetailsskill.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        ddlDistric.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtAreaWorkcomm.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtNameEstEmp.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtAddressEst.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtContactNo.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);




                    }

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindDistricts()
        {
            try
            {
                ddlDistric.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;

                strmode = "";

                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlDistric.DataSource = objDistrictModel;
                    ddlDistric.DataValueField = "DistrictId";
                    ddlDistric.DataTextField = "DistrictName";
                    ddlDistric.DataBind();

                }
                else
                {
                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();

                }
                AddSelect(ddlDistric);


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = stepValidations();
                if (ErrorMsg == "")
                {
                    SRVCLABOURAMIGRANTWORK2020 objLabour = new SRVCLABOURAMIGRANTWORK2020();

                    objLabour.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                    objLabour.Createdby = "1001"; //hdnUserID.Value;
                    objLabour.IPAddress = getclientIP();

                    objLabour.Namekin = txtName.Text;
                    objLabour.Address = txtAddress.Text;
                    objLabour.convictedlaw = rblApplication.SelectedValue;
                    objLabour.criminalCase = rblcrime.SelectedValue;
                    objLabour.Declaration = rblmind.SelectedValue;
                    objLabour.EmpDesignation = txtEmpDesignation.Text;
                    objLabour.Datecommencement = txtEmpDate.Text;
                    objLabour.Expected = txtDurationstay.Text;
                    objLabour.DetailsWork = txtDetailsskill.Text;
                    objLabour.District = ddlDistric.SelectedValue;
                    objLabour.Areawork = txtAreaWorkcomm.Text;
                    objLabour.EstName = txtNameEstEmp.Text;
                    objLabour.EstAddress = txtAddressEst.Text;
                    objLabour.EstContact = txtContactNo.Text;


                    result = objSrvcbal.InsertSRVCLabourMigrantWorkAct2020Details(objLabour);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = " Labour Migrant Work Act 2020 Details Submitted Successfully";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string stepValidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtName.Text) || txtName.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Name of next of kin...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Address ...! \\n";
                    slno++;
                }
                if (rblApplication.SelectedValue == "0" || rblApplication.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Whether the applicant was convicted of any offence under any law in force in India? \\n";
                    slno = slno + 1;
                }
                if (rblcrime.SelectedValue == "0" || rblcrime.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Whether the applicant has any criminal case pending against him/her? \\n";
                    slno = slno + 1;
                }
                if (rblmind.SelectedValue == "0" || rblmind.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Declaration that the applicant is not of unsound mind? \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmpDesignation.Text) || txtEmpDesignation.Text.Trim() == "" || txtEmpDesignation.Text == null)
                {
                    errormsg += slno + ". Please enter Nature of Employment/Designation...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtEmpDate.Text) || txtEmpDate.Text.Trim() == "" || txtEmpDate.Text == null)
                {
                    errormsg += slno + ". Please enter Date of commencement of employment or expected date of commencement...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtDurationstay.Text) || txtDurationstay.Text.Trim() == "" || txtDurationstay.Text == null)
                {
                    errormsg += slno + ". Please enter Expected duration of stay...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtDetailsskill.Text) || txtDetailsskill.Text.Trim() == "" || txtDetailsskill.Text == null)
                {
                    errormsg += slno + ". Please enter Details of the work [ Mention specific skill only]...! \\n";
                    slno++;
                }
                if (ddlDistric.SelectedValue == "0" || ddlDistric.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select District of the area of work \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAreaWorkcomm.Text) || txtAreaWorkcomm.Text.Trim() == "" || txtAreaWorkcomm.Text == null)
                {
                    errormsg += slno + ". Please enter Area of work [ mention communication address of the work area]...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtNameEstEmp.Text) || txtNameEstEmp.Text.Trim() == "" || txtNameEstEmp.Text == null)
                {
                    errormsg += slno + ". Please enter Address of the establishment...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtAddressEst.Text) || txtAddressEst.Text.Trim() == "" || txtAddressEst.Text == null)
                {
                    errormsg += slno + ". Please enter Address of the establishment...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtContactNo.Text) || txtContactNo.Text.Trim() == "" || txtContactNo.Text == null)
                {
                    errormsg += slno + ". Please enter Contact number of Establishment/Employeer...! \\n";
                    slno++;
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
    }
}