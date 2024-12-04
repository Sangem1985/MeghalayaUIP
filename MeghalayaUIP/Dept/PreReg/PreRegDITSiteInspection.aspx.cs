using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegDITSiteInspection : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        MGCommonBAL objcomBal = new MGCommonBAL();
        PreRegBAL PreBAL = new PreRegBAL();
        string ErrorMsg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["DeptUserInfo"] != null)
                {
                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.UserID;
                    }

                    Page.MaintainScrollPositionOnPostBack = true;

                }
                else
                {
                    Response.Redirect("~/DeptLogin.aspx");
                }
            }
            catch (Exception ex)
            {
                savelbl.Visible = true;
                savelbl.Text = "Oops, You've have encountered an error!! please contact administrator.";


                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

            if (!IsPostBack)
            {
                InitializeDataTable();
                BindGrid();
            }
        }
        //public void BindRetrive()
        //{
        //    try
        //    {
        //        if (Request.QueryString.Count > 0)
        //        {
        //            UNITID = Convert.ToString(Request.QueryString[0]);
        //            Investerid = Convert.ToString(Request.QueryString[1]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblmsg0.Text = ex.Message;
        //        Failure.Visible = true;
        //        MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
        //    }
        //}


        private DataTable TeamMembers
        {
            get
            {
                if (ViewState["TeamMembers"] == null)
                {
                    InitializeDataTable(); // Initialize if null
                }
                return (DataTable)ViewState["TeamMembers"];
            }
            set
            {
                ViewState["TeamMembers"] = value;
            }
        }

        private void InitializeDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MemberName", typeof(string));
            dt.Columns.Add("Designation", typeof(string));

            // Add an initial blank row
            DataRow blankRow = dt.NewRow();
            dt.Rows.Add(blankRow);

            TeamMembers = dt; // Store in ViewState
        }

        private void BindGrid()
        {
            DataSet ds = new DataSet();

            gvTeamMembers.DataSource = TeamMembers;
            gvTeamMembers.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string reportid = "";

                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    DistrictSiteReport report = new DistrictSiteReport();

                    report.UnitId = Session["UNITID"].ToString();
                    report.UnitName = txtUnitName.Text;
                    report.UnitLocation = txtUnitLocation.Text;
                    report.GpsCoordinates = txtCoordinates.Text;
                    report.SiteArea = txtArea.Text;
                    report.Ownership = ddlOwnershipStatus.SelectedValue;
                    report.UnderPossession = rblPossession.SelectedValue;
                    report.DistanceFromMainRoad = txtDistanceMainRoad.Text;
                    report.RoadType = txtTypeOfRoad.Text;
                    report.ConstructionCommencement = rblProjectConstruction.SelectedValue +
                        (string.IsNullOrWhiteSpace(txtConstructionRemarks.Text) ? "" : " - " + txtConstructionRemarks.Text);
                    report.AnyNaturalBodies = txtNaturalBodies.Text;
                    report.EnvVulnerableLoc = rblEnvVulnerable.SelectedValue +
                        (string.IsNullOrWhiteSpace(txtEnvVulnerableRemarks.Text) ? "" : " - " + txtEnvVulnerableRemarks.Text);
                    report.AvailabilityOfPower = rblPowerAvailability.SelectedValue +
                        (string.IsNullOrWhiteSpace(txtPowerDrawPoint.Text) ? "" : " - " + txtPowerDrawPoint.Text);
                    report.AvailabilityOfWater = txtWaterSource.Text;
                    report.OtherObservations = txtOtherObservations.Text;
                    report.Comments = txtComments.Text;
                    report.createdBy = hdnUserID.Value;
                    report.ipAddress = getclientIP();
                    report.DateInspection = txtDate.Text;


                    reportid = PreBAL.PreRegDISTRPTSAVE(report);


                    DistrictSiteInspectionTeam teamMember = new DistrictSiteInspectionTeam();
                    int count1 = 0;
                    for (int i = 0; i < gvTeamMembers.Rows.Count; i++)
                    {
                        teamMember.MemberName = gvTeamMembers.Rows[i].Cells[1].Text.Trim();
                        teamMember.Designation = gvTeamMembers.Rows[i].Cells[2].Text;
                        teamMember.District = txtUnitLocation.Text;
                        teamMember.createdBy = hdnUserID.Value;
                        teamMember.ipAddress = getclientIP();

                        string A = PreBAL.SaveTeamMember(reportid, teamMember);
                        if (A != "")
                        { count1 = count1 + 1; }
                    }


                    if (reportid != "0")// && result != "0")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Data Saved Successfully !!!";
                        // lblmsg.ForeColor = System.Drawing.Color.Green;

                    }
                    else
                    {
                        Failure.Visible = true;
                        lblmsg0.Text = "Something Went Wrong Try Again !!!";
                        // lblmsg0.ForeColor = System.Drawing.Color.DarkRed;
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

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect("~/Dept/PreReg/PreRegApplDeptProcess.aspx?Status=" + Request.QueryString["status"].ToString());

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDepartment.Text))
                {
                    lblmsg0.Text = "Please Enter All Details Of Inspector Officer";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("MemberName", typeof(string));
                    dt.Columns.Add("Designation", typeof(string));

                    if (ViewState["TeamMembers"] != null)
                    {
                        dt = (DataTable)ViewState["TeamMembers"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["MemberName"] = txtName.Text;
                    dr["Designation"] = txtDepartment.Text;


                    dt.Rows.Add(dr);
                    gvTeamMembers.Visible = true;
                    gvTeamMembers.DataSource = dt;
                    gvTeamMembers.DataBind();
                    ViewState["TeamMembers"] = dt;


                    txtName.Text = "";
                    txtDepartment.Text = "";

                }
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
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);

                if (string.IsNullOrEmpty(txtUnit.Text) || txtUnit.Text == "" || txtUnit.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Unit ....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocation.Text) || txtLocation.Text == "" || txtLocation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Location Details ....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtUnitName.Text) || txtUnitName.Text == "" || txtUnitName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Unit ....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtUnitLocation.Text) || txtUnitLocation.Text == "" || txtUnitLocation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Location of the Unit ....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCoordinates.Text) || txtCoordinates.Text == "" || txtCoordinates.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Coordinates of the Site ....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtArea.Text) || txtArea.Text == "" || txtArea.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total area of Site ....!\\n";
                    slno = slno + 1;
                }
                if (ddlOwnershipStatus.SelectedIndex == -1 || ddlOwnershipStatus.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Ownership Status....! \\n";
                    slno = slno + 1;
                }
                if (rblPossession.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Land under Possession of unit....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDistanceMainRoad.Text) || txtDistanceMainRoad.Text == "" || txtDistanceMainRoad.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Distance from the Main Road....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTypeOfRoad.Text) || txtTypeOfRoad.Text == "" || txtTypeOfRoad.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Type of Road....!\\n";
                    slno = slno + 1;
                }
                if (rblProjectConstruction.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Project Construction commencement....! \\n";
                    slno = slno + 1;

                }
                if (string.IsNullOrEmpty(txtConstructionRemarks.Text) || txtConstructionRemarks.Text == "" || txtConstructionRemarks.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Project Construction commencement....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNaturalBodies.Text) || txtNaturalBodies.Text == "" || txtNaturalBodies.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Any Natural Bodies....!\\n";
                    slno = slno + 1;
                }
                if (rblEnvVulnerable.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Environmentally Vulnerable location....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEnvVulnerableRemarks.Text) || txtEnvVulnerableRemarks.Text == "" || txtEnvVulnerableRemarks.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Environmentally Vulnerable location....!\\n";
                    slno = slno + 1;
                }
                if (rblPowerAvailability.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Availability of Power....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPowerDrawPoint.Text) || txtPowerDrawPoint.Text == "" || txtPowerDrawPoint.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Availability of Power....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWaterSource.Text) || txtWaterSource.Text == "" || txtWaterSource.Text == null)
                {
                    errormsg = errormsg + slno + ". Please EnterAvailability of Water....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtOtherObservations.Text) || txtOtherObservations.Text == "" || txtOtherObservations.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Other observations....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtComments.Text) || txtComments.Text == "" || txtComments.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Comments/ Remarks....!\\n";
                    slno = slno + 1;
                }
                if (gvTeamMembers.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Details Of Inspector Officer click on Add Details button \\n";
                    slno = slno + 1;
                }


                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvTeamMembers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (gvTeamMembers.Rows.Count > 0)
                {
                    ((DataTable)ViewState["TeamMembers"]).Rows.RemoveAt(e.RowIndex);
                    this.gvTeamMembers.DataSource = ((DataTable)ViewState["TeamMembers"]).DefaultView;
                    this.gvTeamMembers.DataBind();
                    gvTeamMembers.Visible = true;
                    gvTeamMembers.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected List<TextBox> FindEmptyTextboxes(Control container)
        {

            List<TextBox> emptyTextboxes = new List<TextBox>();
            foreach (Control control in container.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textbox = (TextBox)control;
                    if (string.IsNullOrWhiteSpace(textbox.Text))
                    {
                        emptyTextboxes.Add(textbox);
                        textbox.BorderColor = System.Drawing.Color.Red;
                    }
                }

                if (control.HasControls())
                {
                    emptyTextboxes.AddRange(FindEmptyTextboxes(control));
                }
            }
            return emptyTextboxes;
        }
    }
}