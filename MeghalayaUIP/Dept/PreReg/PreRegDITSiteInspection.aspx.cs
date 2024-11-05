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
        string UNITID;
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
                    //if (Convert.ToString(Session["UNITID"]) != "")
                    //{
                    //    UNITID = Convert.ToString(Session["UNITID"]);
                    //}

                    Page.MaintainScrollPositionOnPostBack = true;

                    //if (!IsPostBack)
                    //{



                    //}
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
                InitializeDataTable(); // Initialize with one blank row on first load
                BindGrid();
            }
        }

        // Property to manage TeamMembers DataTable in ViewState
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

        // Initialize DataTable with one blank row
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

        // Bind DataTable to GridView
        private void BindGrid()
        {
            gvTeamMembers.DataSource = TeamMembers;
            gvTeamMembers.DataBind();
        }

        // Event to handle adding a new row
        protected void gvTeamMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddNew")
            {
                DataTable dt = TeamMembers;

                // Get the last row (empty row) for the current input
                GridViewRow lastRow = gvTeamMembers.Rows[gvTeamMembers.Rows.Count - 1];
                TextBox txtMemberName = (TextBox)lastRow.FindControl("txtMemberName");
                TextBox txtDesignation = (TextBox)lastRow.FindControl("txtDesignation");

                // Only add the new row if there is data
                if (!string.IsNullOrWhiteSpace(txtMemberName.Text) || !string.IsNullOrWhiteSpace(txtDesignation.Text))
                {
                    // Add data from the last empty row to the DataTable
                    //DataRow dr = dt.NewRow();
                    dt.Rows[gvTeamMembers.Rows.Count - 1]["MemberName"] = txtMemberName.Text;
                    dt.Rows[gvTeamMembers.Rows.Count - 1]["Designation"] = txtDesignation.Text;
                }

                // Add a new empty row to allow adding a new person
                DataRow newRow = dt.NewRow();
                dt.Rows.Add(newRow);

                // Update ViewState with new data and re-bind GridView
                TeamMembers = dt;
                BindGrid();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string reportid = "";


            // Create a new instance of DistrictSiteReport
            DistrictSiteReport report = new DistrictSiteReport();

            // Assign values from controls to the properties in the report object
            // Assuming UId is an integer
            report.UnitId = 0;
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



            reportid = PreBAL.PreRegDISTRPTSAVE(report);




            string district = txtUnitLocation.Text;
            string result = "0";
            // Loop through each row in the GridView
            foreach (GridViewRow row in gvTeamMembers.Rows)
            {
                // Get the TextBox controls from the current row
                TextBox txtMemberName = (TextBox)row.FindControl("txtMemberName");
                TextBox txtDesignation = (TextBox)row.FindControl("txtDesignation");

                if (txtMemberName != null && txtDesignation != null)
                {
                    string memberName = txtMemberName.Text.Trim();
                    string designation = txtDesignation.Text.Trim();

                    // Add a check to ensure that MemberName is not empty
                    if (!string.IsNullOrEmpty(memberName))
                    {
                        // Create a new DistrictSiteInspectionTeam object
                        DistrictSiteInspectionTeam teamMember = new DistrictSiteInspectionTeam
                        {
                            MemberName = memberName,
                            Designation = designation,
                            District = district, // Assuming you are fetching this from the context
                            ipAddress = getclientIP(),
                            createdBy = hdnUserID.Value
                        };

                        // Save the team member to the database using the stored procedure
                        result = PreBAL.SaveTeamMember(reportid, teamMember);

                    }

                }

            }
            if (reportid != "0" && result != "0")
            {
                savelbl.Visible = true;
                savelbl.Text = "Data Saved Successfully !!!";
                savelbl.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                savelbl.Visible = true;
                savelbl.Text = "Something Went Wrong Try Again !!!";
                savelbl.ForeColor = System.Drawing.Color.DarkRed;
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