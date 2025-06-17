using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class RegSocieties : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string ErrorMsg = "", Questionnaire;
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
                if (Convert.ToString(Session["SRVCQID"]) != "")
                {
                    Questionnaire = Convert.ToString(Session["SRVCQID"]);
                    if (!IsPostBack)
                    {
                        GetAppliedorNot();
                    }
                }
                else
                {
                    string newurl = "~/User/Services/SRVCUserDashboard.aspx";
                    Response.Redirect(newurl);
                }


            }
        }
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objSrvcbal.GetsrvcapprovalID(hdnUserID.Value, Convert.ToString(Session["SRVCQID"]), "7", "99");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["SRVCDA_APPROVALID"]) == "99")
                    {
                        BindDistricts();
                        BindSubdivision();
                        BindData();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Services/SRVCUploadEnclosures.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Services/PlasticWasteDetails.aspx?Previous=" + "P");
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
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objSrvcbal.GetRegSocietiesDet(hdnUserID.Value, Convert.ToString(Session["SRVCQID"]));
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlApplication.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCRS_APPLICATIONSUBMISSION"]);
                        if (ddlApplication.SelectedValue=="1")
                        {
                            District.Visible = true;
                            ddldistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCRS_DISTRICT"]);

                        }
                        else
                        {
                            subdivision.Visible = true;
                            ddlSubDiv.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCRS_SUBDIVISION"]);
                        }
                        rblApplication.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SRVCRS_TYPEAPPLICATION"]);
                        if (rblApplication.SelectedValue=="R")
                        {
                            divOldReg.Visible = true;
                            RegDate.Visible = true;
                            txtSoWoDo.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCRS_OLDREGNO"]);
                            txtRegDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCRS_REGDATE"]);
                        }

                        txtNameAssoci.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCRS_NAMEOFASSOCIATION"]);
                        txtAddressSociety.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCRS_ADDRESSSOCIETY"]);
                        txtEstDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCRS_DATEOFESTABLISHMENT"]);
                        txtPresidentNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCRS_CONTACTNO"]);
                        txtGeneralMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCRS_GENERALSECRETYNO"]);
                        txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCRS_EMAIL"]);
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GVRegSocieties.DataSource = ds.Tables[1];
                        GVRegSocieties.DataBind();
                        GVRegSocieties.Visible = true;
                        ViewState["RegSocieties"] = ds.Tables[1];
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
        protected void ddlApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlApplication.SelectedValue == "1")
                {
                    District.Visible = true;
                    subdivision.Visible = false;
                }
                else
                {
                    District.Visible = false;
                    subdivision.Visible = true;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindDistricts()
        {

            try
            {

                ddldistrict.Items.Clear();
                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                strmode = "";
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddldistrict.DataSource = objDistrictModel;
                    ddldistrict.DataValueField = "DistrictId";
                    ddldistrict.DataTextField = "DistrictName";
                    ddldistrict.DataBind();
                }
                else
                {
                    ddldistrict.DataSource = null;
                    ddldistrict.DataBind();

                }
                AddSelect(ddldistrict);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindSubdivision()
        {
            try
            {
                ddlSubDiv.Items.Clear();

                List<MasterSubDivisions> objCategoryModel = new List<MasterSubDivisions>();

                objCategoryModel = mstrBAL.GetSubDivisions();
                if (objCategoryModel != null)
                {
                    ddlSubDiv.DataSource = objCategoryModel;
                    ddlSubDiv.DataValueField = "SubDiv_ID";
                    ddlSubDiv.DataTextField = "SubDiv_NAME";
                    ddlSubDiv.DataBind();
                }
                else
                {
                    ddlSubDiv.DataSource = null;
                    ddlSubDiv.DataBind();
                }
                AddSelect(ddlSubDiv);
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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

        protected void rblApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblApplication.SelectedValue == "R")
                {
                    divOldReg.Visible = true;
                    RegDate.Visible = true;
                }
                else
                {
                    divOldReg.Visible = false;
                    RegDate.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnMember_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFullName.Text)|| string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtPoliceStation.Text) || string.IsNullOrEmpty(txtDesignation.Text) || string.IsNullOrEmpty(txtMobileno.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("NAME", typeof(string));
                    dt.Columns.Add("ADDRESS", typeof(string));
                    dt.Columns.Add("POLICESTATION", typeof(string));
                    dt.Columns.Add("DESIGNATION", typeof(string));
                    dt.Columns.Add("MOBILENO", typeof(string));

                    if (ViewState["RegSocieties"] != null)
                    {
                        dt = (DataTable)ViewState["RegSocieties"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["NAME"] = txtFullName.Text;
                    dr["ADDRESS"] = txtAddress.Text;
                    dr["POLICESTATION"] = txtPoliceStation.Text;
                    dr["DESIGNATION"] = txtDesignation.Text;
                    dr["MOBILENO"] = txtMobileno.Text;

                    dt.Rows.Add(dr);
                    GVRegSocieties.Visible = true;
                    GVRegSocieties.DataSource = dt;
                    GVRegSocieties.DataBind();
                    ViewState["RegSocieties"] = dt;

                    txtFullName.Text = "";
                    txtAddress.Text = "";
                    txtPoliceStation.Text = "";
                    txtDesignation.Text = "";
                    txtMobileno.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    SRVCRegSocietiesDetailos ObjRegSocietiesDetails = new SRVCRegSocietiesDetailos();
                    int count = 0;

                    for (int i = 0; i < GVRegSocieties.Rows.Count; i++)
                    {
                        ObjRegSocietiesDetails.SRVCQDID = Convert.ToString(Session[""]);
                        ObjRegSocietiesDetails.createdby = hdnUserID.Value;
                        ObjRegSocietiesDetails.createdbyip = getclientIP();
                        ObjRegSocietiesDetails.FullName = GVRegSocieties.Rows[i].Cells[1].Text;
                        ObjRegSocietiesDetails.FullAddress = GVRegSocieties.Rows[i].Cells[2].Text;
                        ObjRegSocietiesDetails.Policestation = GVRegSocieties.Rows[i].Cells[3].Text;
                        ObjRegSocietiesDetails.Designation = GVRegSocieties.Rows[i].Cells[4].Text;
                        ObjRegSocietiesDetails.MobileNo = GVRegSocieties.Rows[i].Cells[5].Text;

                        string A = objSrvcbal.InsertRegSocietiesDetails(ObjRegSocietiesDetails);
                        if (A != "")
                        { count = count + 1; }
                    }


                    ObjRegSocietiesDetails.SRVCQDID = Convert.ToString(Session["SRVCQID"]);
                    ObjRegSocietiesDetails.createdby = hdnUserID.Value;
                    ObjRegSocietiesDetails.createdbyip = getclientIP();
                    ObjRegSocietiesDetails.Applicationassociation = ddlApplication.SelectedValue;
                    ObjRegSocietiesDetails.District = ddldistrict.SelectedValue;
                    ObjRegSocietiesDetails.SUBDIVISION = ddlSubDiv.SelectedValue;
                    ObjRegSocietiesDetails.TypeApplication = rblApplication.SelectedValue;
                    ObjRegSocietiesDetails.OldRegNumber = txtSoWoDo.Text;
                    ObjRegSocietiesDetails.RegDate = txtRegDate.Text;
                    ObjRegSocietiesDetails.NameAssociation = txtNameAssoci.Text;
                    ObjRegSocietiesDetails.AddressSociety = txtAddressSociety.Text;
                    ObjRegSocietiesDetails.Dateest = txtEstDate.Text;
                    ObjRegSocietiesDetails.ContactNo = txtPresidentNo.Text;
                    ObjRegSocietiesDetails.GeneralNo = txtGeneralMobileNo.Text;
                    ObjRegSocietiesDetails.Email = txtEmail.Text;                 


                    result = objSrvcbal.SRVCRegSocietiesDet(ObjRegSocietiesDetails);
                    if (result != "")
                    {
                        string message = "alert('" + "Registration of Societies Details Saved Successfully" + "')";
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

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/Services/PlasticWasteDetails.aspx?Previous=" + "P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Services/SRVCUploadEnclosures.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (ddlApplication.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Kindly choose application submission office depending \\n";
                    slno = slno + 1;
                }

                if (ddlApplication.SelectedValue == "1")
                {
                    if (ddldistrict.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select DISTRICT \\n";
                        slno = slno + 1;
                    }
                   
                }
                else
                {
                    if (ddlSubDiv.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select SUB DIVISION \\n";
                        slno = slno + 1;
                    }

                }
                if (rblApplication.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Type of Application \\n";
                    slno = slno + 1;
                }
                if (rblApplication.SelectedValue == "R")
                {
                    if (string.IsNullOrEmpty(txtSoWoDo.Text) || txtSoWoDo.Text == "" || txtSoWoDo.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Old Registration Number..!\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtRegDate.Text) || txtRegDate.Text == "" || txtRegDate.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Registration Date\\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtNameAssoci.Text) || txtNameAssoci.Text == "" || txtNameAssoci.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Association\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAddressSociety.Text) || txtAddressSociety.Text == "" || txtAddressSociety.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address of the association/society\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEstDate.Text) || txtEstDate.Text == "" || txtEstDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Date of establishment\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPresidentNo.Text) || txtPresidentNo.Text == "" || txtPresidentNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter President Contact Number\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtGeneralMobileNo.Text) || txtGeneralMobileNo.Text == "" || txtGeneralMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter General Secretary Mobile Number\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "" || txtEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter E-Mail\\n";
                    slno = slno + 1;
                }
                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}