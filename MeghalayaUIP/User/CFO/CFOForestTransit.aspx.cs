using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static AjaxControlToolkit.AsyncFileUpload.Constants;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOForestTransit : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
        string Unitid, Errormsg = "";
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
                    if (Convert.ToString(Session["CFOUNITID"]) != "")
                    {
                        Unitid = Convert.ToString(Session["CFOUNITID"]);
                    }
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
                        GetAppliedorNot();
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
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objcfobal.GetApprovalDataByDeptId(Session["CFOQID"].ToString(), Session["CFOUNITID"].ToString(), "4");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["CFOQA_APPROVALID"]) == "85")
                    {
                        LoadTransitData();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFO/CFOUploadEnclosures.aspx?next=N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFO/CFOExcise.aspx?Previous=P");
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

        private DataTable CreateLogsDataTable()
        {
            if (ViewState["LogData"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("SlNo", typeof(int));
                dt.Columns.Add("SpeciesName", typeof(string));
                dt.Columns.Add("LogNumber", typeof(string));
                dt.Columns.Add("Girth", typeof(string));
                dt.Columns.Add("Length", typeof(string));
                dt.Columns.Add("VolumeOrWeight", typeof(string));
                ViewState["LogData"] = dt;
            }
            return (DataTable)ViewState["LogData"];
        }


        private void BindLogsGrid()
        {
            gvLogs.DataSource = ViewState["LogData"];
            gvLogs.DataBind();
        }

        protected void GvLogs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Retrieve DataTable from ViewState
            DataTable dt = ViewState["LogsTable"] as DataTable;

            if (dt != null)
            {
                // Get the row index to delete
                int rowIndex = e.RowIndex;

                // Remove the row at the specified index
                dt.Rows.RemoveAt(rowIndex);

                // **Reassign serial numbers after deletion**
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["SlNo"] = i + 1;  // Reassign serial numbers sequentially
                }

                // Store updated DataTable in ViewState
                ViewState["LogsTable"] = dt;

                // Rebind the GridView
                gvLogs.DataSource = dt;
                gvLogs.DataBind();
            }
        }

        private DataTable dtBarriers // Stores the grid data in ViewState
        {
            get
            {
                return ViewState["dtBarriers"] as DataTable ?? CreateBariersTable();
            }
            set
            {
                ViewState["dtBarriers"] = value;
            }
        }

        private DataTable CreateBariersTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SlNo", typeof(int));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("Barriers", typeof(string));
            return dt;
        }

        private void BindBariersGrid()
        {
            gvBarriers.DataSource = dtBarriers;
            gvBarriers.DataBind();
        }

        protected void BtnAddBarrier_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBarriers;

            // Add new row
            DataRow dr = dt.NewRow();
            dr["SlNo"] = dt.Rows.Count + 1; // Auto-increment SlNo
            dr["State"] = txtState.Text.Trim();
            dr["Barriers"] = txtBarriers.Text.Trim();
            dt.Rows.Add(dr);

            dtBarriers = dt; // Save back to ViewState
            BindBariersGrid();

            // Clear input fields after adding
            txtState.Text = "";
            txtBarriers.Text = "";
        }

        public void GvBarriers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = dtBarriers;

            if (dt.Rows.Count > e.RowIndex)
            {
                dt.Rows.RemoveAt(e.RowIndex); // Remove the selected row
            }

            // Reassign serial numbers after deletion
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["SlNo"] = i + 1;
            }

            dtBarriers = dt;
            BindBariersGrid();
        }

        protected void BtnAddlogs_Click(object sender, EventArgs e)
        {
            // Retrieve DataTable from ViewState or create new if null
            DataTable dt = ViewState["LogsTable"] as DataTable;

            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("SlNo", typeof(int));
                dt.Columns.Add("SpeciesName", typeof(string));
                dt.Columns.Add("LogNumber", typeof(string));
                dt.Columns.Add("Girth", typeof(string));
                dt.Columns.Add("Length", typeof(string));
                dt.Columns.Add("VolumeOrWeight", typeof(string));
            }

            // Auto-increment serial number
            int slNo = dt.Rows.Count + 1;

            // Add new row
            DataRow dr = dt.NewRow();
            dr["SlNo"] = slNo;
            dr["SpeciesName"] = ddlSpeciesName.SelectedItem.Text;
            dr["LogNumber"] = txtLogNumber.Text;
            dr["Girth"] = txtGirth.Text;
            dr["Length"] = txtLength.Text;
            dr["VolumeOrWeight"] = txtVolumeWeight.Text;

            dt.Rows.Add(dr);

            // Store updated DataTable in ViewState
            ViewState["LogsTable"] = dt;

            // Rebind the GridView
            gvLogs.DataSource = dt;
            gvLogs.DataBind();

            // Clear textboxes after adding
            ddlSpeciesName.SelectedIndex = 0;
            txtLogNumber.Text = "";
            txtGirth.Text = "";
            txtLength.Text = "";
            txtVolumeWeight.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            try
            {
                Errormsg = Validations();
                if (Errormsg == "")
                {
                    SaveData();
                }
                else
                {
                    string message = "alert('" + Errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
           




        }

        public void SaveData()
        {
            string result = "";
            string result2 = "";
            string result3 = "";

            ForestTransit forestTransit = new ForestTransit
            {
                CFOQDID = Convert.ToString(Session["CFOQID"]),
                UNITID = Convert.ToString(Session["CFOUNITID"]),
                PERMITNO = txtpermitno.Text.Trim(),
                OWNERNAME = txtName.Text.Trim(),
                OWNERIDENTITYNO = txtIdentity.Text.Trim(),
                OWNEREMAIL = txtemail.Text.Trim(),
                OWNERADDRESS = txtowneraddress.Text.Trim(),
                OWNERMOBILE = txtmobile.Text.Trim(),
                OWNERPRODUCE = txtproduce.Text.Trim(),
                VEHICLETYPE = txtVehicleType.Text.Trim(),
                DRIVERLICENSE = txtDriverLicense.Text.Trim(),
                DRIVERNAME = txtDriverName.Text.Trim(),
                COMPARTMENTNOOBTAINED = txtCompartmentNo.Text.Trim(),
                RANGEWHEREOBTAINED = txtRangeWhereObtained.Text.Trim(),
                CIRCLEWHEREOBTAINED = txtCircleWhereObtained.Text.Trim(),
                ADDRESSWHEREOBTAINED = txtAddressWhereObtained.Text.Trim(),
                DIVISIONWHEREOBTAINED = txtDivisionWhereObtained.Text.Trim(),
                STATEDESTINATION = txtstateDestination.Text.Trim(),
                DESTRANGE = txtdestRange.Text.Trim(),
                DESTADDRESS = txtdestAddress.Text.Trim(),
                DESTCIRCLE = txtdestCircle.Text.Trim(),
                DESTDIVISION = txtdestDivision.Text.Trim(),
                CREATEDIP = getclientIP(),
                IMPRINTOFTRANSITMARK = txtImprintOfTransitMark.Text.Trim(),

                DESIGNATIONOFOFFICER = txtDesignationOfOfficial.Text.Trim(),
                OFFICERTELEPHONEMOBILE = txtOfficialTelephoneMobile.Text.Trim(),
                OFFICEREMAIL = txtOfficialEmail.Text.Trim(),
                OFFICEADDRESS = txtOfficeAddress.Text.Trim()
            };
            if (!string.IsNullOrWhiteSpace(txtDateOfIssue.Text.Trim()))
            {
                forestTransit.DATEOFISSUE = Convert.ToDateTime(txtDateOfIssue.Text.Trim());
            }
            if (!string.IsNullOrWhiteSpace(txtDateOfExpiryOfPermit.Text.Trim()))
            {
                forestTransit.DATEOFEXPIRYOFPERMIT = Convert.ToDateTime(txtDateOfExpiryOfPermit.Text.Trim());
            }

            result = objcfobal.InsertCFOFTransitDetails(forestTransit);
            int transitId = int.Parse(result);
            // ViewState["UnitID"] = result;
            if (transitId != null)
            {
                List<ForestTransitLog> logList = new List<ForestTransitLog>();

                foreach (GridViewRow row in gvLogs.Rows)
                {
                    ForestTransitLog log = new ForestTransitLog
                    {
                        TRANSITID = transitId,
                        CREATEDBY = hdnUserID.Value,
                        UNITID = Convert.ToString(Session["CFOUNITID"]),
                        CFOQDID = Convert.ToString(Session["CFOQID"]),
                        //? null: Session["CFOUNITID"].ToString().Trim(),

                        SPECIESNAME = row.Cells[1].Text.Trim(),
                        LOGNUMBER = row.Cells[2].Text.Trim(),

                        GIRTH = (decimal)((!string.IsNullOrWhiteSpace(row.Cells[3].Text))
                        ? Convert.ToDecimal(row.Cells[3].Text.Trim())
                        : (decimal?)null),

                        LENGTH = (!string.IsNullOrWhiteSpace(row.Cells[4].Text)) ? Convert.ToDecimal(row.Cells[4].Text.Trim()) : (decimal?)null,

                        VOLUMEORWEIGHT = (decimal)((!string.IsNullOrWhiteSpace(row.Cells[5].Text)) ? Convert.ToDecimal(row.Cells[5].Text.Trim()) : (decimal?)null),
                        CREATEDIP = getclientIP()
                    };

                    logList.Add(log);
                }

                result2 = objcfobal.InsertCFOFTransitLogs(logList);



            }
            if (result2 != null)
            {
                List<ForestTransitBarrier> barrierList = new List<ForestTransitBarrier>();

                foreach (GridViewRow row in gvBarriers.Rows)
                {
                    ForestTransitBarrier barrier = new ForestTransitBarrier
                    {

                        TRANSITID = transitId,
                        CREATEDBY = hdnUserID.Value,
                        UNITID = Convert.ToString(Session["CFOUNITID"]),
                        CFOQDID = Convert.ToString(Session["CFOQID"]),
                        STATE = row.Cells[1].Text.Trim(),
                        BARRIERS = row.Cells[2].Text.Trim(),
                        CREATEDIP = Request.UserHostAddress,
                    };

                    barrierList.Add(barrier);
                }
                result3 = objcfobal.InsertCFOFTransitBarriers(barrierList);

            }

            
        }

        private void LoadTransitData()
        {
            DataSet ds = objcfobal.GetForestTransitData(hdnUserID.Value, Unitid);

            if (ds != null && ds.Tables.Count > 0)
            {
                // **Bind First Table to Textboxes**
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];

                    txtpermitno.Text = row["CFOFT_PERMITNO"].ToString();
                    txtName.Text = row["CFOFT_OWNERNAME"].ToString();
                    txtIdentity.Text = row["CFOFT_OWNERIDENTITYNO"].ToString();
                    txtemail.Text = row["CFOFT_OWNEREMAIL"].ToString();
                    txtowneraddress.Text = row["CFOFT_OWNERADDRESS"].ToString();
                    txtmobile.Text = row["CFOFT_OWNERMOBILE"].ToString();
                    txtproduce.Text = row["CFOFT_OWNERPRODUCE"].ToString();
                    txtVehicleType.Text = row["CFOFT_VEHICLETYPE"].ToString();
                    txtDriverLicense.Text = row["CFOFT_DRIVERLICENSE"].ToString();
                    txtDriverName.Text = row["CFOFT_DRIVERNAME"].ToString();
                    txtCompartmentNo.Text = row["CFOFT_COMPARTMENTNOOBTAINED"].ToString();
                    txtRangeWhereObtained.Text = row["CFOFT_RANGEWHEREOBTAINED"].ToString();
                    txtCircleWhereObtained.Text = row["CFOFT_CIRCLEWHEREOBTAINED"].ToString();
                    txtAddressWhereObtained.Text = row["CFOFT_ADDRESSWHEREOBTAINED"].ToString();
                    txtDivisionWhereObtained.Text = row["CFOFT_DIVISIONWHEREOBTAINED"].ToString();
                    txtstateDestination.Text = row["CFOFT_STATEDESTINATION"].ToString();
                    txtdestRange.Text = row["CFOFT_DESTRANGE"].ToString();
                    txtdestAddress.Text = row["CFOFT_DESTADDRESS"].ToString();
                    txtdestCircle.Text = row["CFOFT_DESTCIRCLE"].ToString();
                    txtdestDivision.Text = row["CFOFT_DESTDIVISION"].ToString();
                    txtImprintOfTransitMark.Text = row["CFOFT_IMPRINTOFTRANSITMARK"].ToString();
                    txtDesignationOfOfficial.Text = row["CFOFT_DESIGNATIONOFOFFICER"].ToString();
                    txtOfficialTelephoneMobile.Text = row["CFOFT_OFFICERTELEPHONEMOBILE"].ToString();
                    txtOfficialEmail.Text = row["CFOFT_OFFICEREMAIL"].ToString();
                    txtOfficeAddress.Text = row["CFOFT_OFFICEADDRESS"].ToString();
                    if (!string.IsNullOrWhiteSpace(row["CFOFT_DATEOFISSUE"].ToString()))
                    {
                        txtDateOfIssue.Text = Convert.ToDateTime(row["CFOFT_DATEOFISSUE"]).ToString("yyyy-MM-dd");
                    }

                    if (!string.IsNullOrWhiteSpace(row["CFOFT_DATEOFEXPIRYOFPERMIT"].ToString()))
                    {
                        txtDateOfExpiryOfPermit.Text = Convert.ToDateTime(row["CFOFT_DATEOFEXPIRYOFPERMIT"]).ToString("yyyy-MM-dd");
                    }
                }

                // **Bind Second Table to GridView (Logs)**
                if (ds.Tables.Count > 1)
                {
                    gvLogs.DataSource = ds.Tables[1];
                    gvLogs.DataBind();
                }

                // **Bind Third Table to GridView (Barriers)**
                if (ds.Tables.Count > 2)
                {
                    gvBarriers.DataSource = ds.Tables[2];
                    gvBarriers.DataBind();
                }
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave_Click(sender, e);

                if (Errormsg == "")
                Response.Redirect("~/User/CFO/CFOUploadEnclosures.aspx?next=N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        public string Validations()
        {
            try
            {
                int slno = 1;
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                
                string errormsg = "";
                if (gvLogs.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please enter Logs Details \\n";
                    slno = slno + 1;
                }
                if (gvBarriers.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please enter Barrier Details \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtpermitno.Text) || txtpermitno.Text == "" || txtpermitno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Permit No \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "" || txtName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Owner Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIdentity.Text) || txtIdentity.Text == "" || txtIdentity.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Owner Identity No \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtemail.Text) || txtemail.Text == "" || txtemail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Owner Email \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtowneraddress.Text) || txtowneraddress.Text == "" || txtowneraddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Owner Address \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtmobile.Text) || txtmobile.Text == "" || txtmobile.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Owner Mobile No \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtproduce.Text) || txtproduce.Text == "" || txtproduce.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Owner Produce \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtVehicleType.Text) || txtVehicleType.Text == "" || txtVehicleType.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Vehicle Type \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDriverLicense.Text) || txtDriverLicense.Text == "" || txtDriverLicense.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Driver License No \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDriverName.Text) || txtDriverName.Text == "" || txtDriverName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Driver Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCompartmentNo.Text) || txtCompartmentNo.Text == "" || txtCompartmentNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Compartment No Obtained \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRangeWhereObtained.Text) || txtRangeWhereObtained.Text == "" || txtRangeWhereObtained.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Range Where Obtained \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCircleWhereObtained.Text) || txtCircleWhereObtained.Text == "" || txtCircleWhereObtained.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Circle Where Obtained \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAddressWhereObtained.Text) || txtAddressWhereObtained.Text == "" || txtAddressWhereObtained.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Address Where Obtained \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDivisionWhereObtained.Text) || txtDivisionWhereObtained.Text == "" || txtDivisionWhereObtained.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Division Where Obtained \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtstateDestination.Text) || txtstateDestination.Text == "" || txtstateDestination.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter State Destination \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdestRange.Text) || txtdestRange.Text == "" || txtdestRange.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Destination Range \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdestAddress.Text) || txtdestAddress.Text == "" || txtdestAddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Destination Address \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdestCircle.Text) || txtdestCircle.Text == "" || txtdestCircle.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Destination Circle \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdestDivision.Text) || txtdestDivision.Text == "" || txtdestDivision.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Destination Division \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtImprintOfTransitMark.Text) || txtImprintOfTransitMark.Text == "" || txtImprintOfTransitMark.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Imprint Of Transit Mark \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDesignationOfOfficial.Text) || txtDesignationOfOfficial.Text == "" || txtDesignationOfOfficial.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Designation Of Officer \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtOfficialTelephoneMobile.Text) || txtOfficialTelephoneMobile.Text == "" || txtOfficialTelephoneMobile.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Officer Telephone/Mobile \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtOfficialEmail.Text) || txtOfficialEmail.Text == "" || txtOfficialEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Officer Email \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtOfficeAddress.Text) || txtOfficeAddress.Text == "" || txtOfficeAddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Office Address \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDateOfIssue.Text) || txtDateOfIssue.Text == "" || txtDateOfIssue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Office Address \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDateOfExpiryOfPermit.Text) || txtDateOfExpiryOfPermit.Text == "" || txtDateOfExpiryOfPermit.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Office Address \\n";
                    slno = slno + 1;
                }


                return errormsg;

            }
            catch (Exception ex)
            {
                throw ex;
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