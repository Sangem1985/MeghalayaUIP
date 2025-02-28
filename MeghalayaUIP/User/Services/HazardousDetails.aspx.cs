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
using static AjaxControlToolkit.AsyncFileUpload.Constants;

namespace MeghalayaUIP.User.Services
{
    public partial class HazardousDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string UnitID, ErrorMsg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }


        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                //ds = objSrvcbal.GetSRVCHAZARDOUSDETAILS(hdnUserID.Value, UnitID);
                ds = objSrvcbal.GetSRVCHAZARDOUSDETAILS("116","1001");

                if (ds.Tables[0].Rows.Count > 0)
                {                 
                    txtname.Text = ds.Tables[0].Rows[0]["SRVCHZD_FIRMNAME"].ToString();
                    txtfirmlocation.Text = ds.Tables[0].Rows[0]["SRVCHZD_FIRMLOCATION"].ToString();
                    txtoccupiername.Text = ds.Tables[0].Rows[0]["SRVCHZD_OCCUPIERNAME"].ToString();
                    txtEmailId.Text = ds.Tables[0].Rows[0]["SRVCHZD_EMAILID"].ToString();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["SRVCHZD_MOBILENO"].ToString();
                    txtfax.Text = ds.Tables[0].Rows[0]["SRVCHZD_FAX"].ToString();
                    txtwstntrqtyanum.Text = ds.Tables[0].Rows[0]["SRVCHZD_WSTNTRQTYANUM"].ToString();
                    txtwstntrqtyatm.Text = ds.Tables[0].Rows[0]["SRVCHZD_WSTNTRQTYATM"].ToString();
                    txtyrcmsng.Text = ds.Tables[0].Rows[0]["SRVCHZD_YEARCMSNG"].ToString();
                    rblShifts.Text = ds.Tables[0].Rows[0]["SRVCHZD_SHIFTS"].ToString();
                    // Handle Activities CheckBoxList
                    string activities = ds.Tables[0].Rows[0]["SRVCHZD_ACTIVITIES"].ToString();
                    if (!string.IsNullOrEmpty(activities))
                    {
                        string[] selectedActivities = activities.Split(',');

                        foreach (string activity in selectedActivities)
                        {
                            foreach (ListItem item in chkActivities.Items)
                            {
                                if (item.Text.Trim().Equals(activity.Trim(), StringComparison.OrdinalIgnoreCase))
                                {
                                    item.Selected = true;
                                    break;
                                }
                            }
                        }
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                string result = "";
                ErrorMsg = Validations(); 

                if (ErrorMsg == "")
                {
                   
                    SRVCHAZZARDOUSDETAILS ObjSrvHazardous = new SRVCHAZZARDOUSDETAILS();

                    // Fetching selected values from checkboxes
                    var selectedActivities = chkActivities.Items.Cast<ListItem>()
                                .Where(li => li.Selected)
                                .Select(li => li.Text);
                    string selectedActivityList = string.Join(", ", selectedActivities);

                    // Fetching selected industry work details
                    var selectedIndustryWork = rblShifts.Items.Cast<ListItem>()
                                .Where(li => li.Selected)
                                .Select(li => li.Text);
                    string selectedIndustryList = string.Join(", ", selectedIndustryWork);

                    
                    ObjSrvHazardous.SRVCQDID = "116";//Convert.ToInt32(Session["SRVCQDID"]);
                    ObjSrvHazardous.UNITID = "1001";//Convert.ToInt32(Session["UNITID"]);
                    ObjSrvHazardous.UIDNO = "116";//txtUIDNo.Text.Trim();
                    ObjSrvHazardous.FIRMNAME = txtname.Text.Trim();
                    ObjSrvHazardous.FIRMLOCATION = txtfirmlocation.Text.Trim();
                    ObjSrvHazardous.OCCUPIERNAME = txtoccupiername.Text.Trim();
                    ObjSrvHazardous.EMAILID = txtEmailId.Text.Trim();
                    ObjSrvHazardous.MOBILENO = txtMobileNo.Text.Trim();
                    ObjSrvHazardous.FAX = txtfax.Text.Trim();
                    ObjSrvHazardous.ACTIVITIES = selectedActivityList;
                    ObjSrvHazardous.WSTNTRQTYANUM = Convert.ToDecimal(txtwstntrqtyanum.Text);
                    ObjSrvHazardous.WSTNTRQTYATM = Convert.ToDecimal(txtwstntrqtyatm.Text);
                    ObjSrvHazardous.YEARCMSNG = txtyrcmsng.Text.Trim();

                    ObjSrvHazardous.SHIFTS = rblShifts.Text.Trim();
                    ObjSrvHazardous.CREATEDBY = hdnUserID.Value;
                    ObjSrvHazardous.CREATEDIP = getclientIP(); // Fetching client IP

                    // Call the Business Layer to insert data
                    result = objSrvcbal.InsertSrvHazardous(ObjSrvHazardous);

                    if (!string.IsNullOrEmpty(result))
                    {
                        success.Visible = true;
                        lblmsg.Text = "Hazardous Waste Details Submitted Successfully";
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

        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                // Check if Firm Name is empty
                if (string.IsNullOrEmpty(txtname.Text.Trim()))
                {
                    errormsg += slno + ". Please enter the Firm Name. \\n";
                    slno++;
                }

                // Check if Firm Location is empty
                if (string.IsNullOrEmpty(txtfirmlocation.Text.Trim()))
                {
                    errormsg += slno + ". Please enter the Firm Location. \\n";
                    slno++;
                }

                // Check if Occupier Name is empty
                if (string.IsNullOrEmpty(txtoccupiername.Text.Trim()))
                {
                    errormsg += slno + ". Please enter the Occupier Name. \\n";
                    slno++;
                }

                // Validate Email ID format
                if (string.IsNullOrEmpty(txtEmailId.Text.Trim()) ||
                    !System.Text.RegularExpressions.Regex.IsMatch(txtEmailId.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    errormsg += slno + ". Please enter a valid Email ID. \\n";
                    slno++;
                }

                // Validate Mobile Number (should be 10 digits)
                if (string.IsNullOrEmpty(txtMobileNo.Text.Trim()) ||
                    !System.Text.RegularExpressions.Regex.IsMatch(txtMobileNo.Text, @"^[6-9]\d{9}$"))
                {
                    errormsg += slno + ". Please enter a valid 10-digit Mobile Number. \\n";
                    slno++;
                }

                // Validate Fax (optional, but if entered, should be numeric)
                if (!string.IsNullOrEmpty(txtfax.Text.Trim()) &&
                    !System.Text.RegularExpressions.Regex.IsMatch(txtfax.Text, @"^\d+$"))
                {
                    errormsg += slno + ". Fax number should contain only numbers. \\n";
                    slno++;
                }

                // Validate Activities selection
                if (chkActivities.SelectedIndex == -1)
                {
                    errormsg += slno + ". Please select at least one activity. \\n";
                    slno++;
                }

                // Validate Waste Handled Per Annum (Numeric check)
                if (string.IsNullOrEmpty(txtwstntrqtyanum.Text.Trim()) || txtwstntrqtyanum.Text.All(c => c == '0') ||
                    System.Text.RegularExpressions.Regex.IsMatch(txtwstntrqtyanum.Text, @"^0+(\.0+)?$"))
                {
                    errormsg += slno + ". Please enter a valid Waste Handled per Annum (in Metric Tons). \\n";
                    slno++;
                }

                // Validate Waste Stored at Any Time (Numeric check)
                if (string.IsNullOrEmpty(txtwstntrqtyatm.Text.Trim()) || txtwstntrqtyatm.Text.All(c => c == '0') ||
                    System.Text.RegularExpressions.Regex.IsMatch(txtwstntrqtyatm.Text, @"^0+(\.0+)?$"))
                {
                    errormsg += slno + ". Please enter a valid Waste Stored at Any Time (in Metric Tons). \\n";
                    slno++;
                }

                // Validate Year of Commissioning (should be a valid year)
                if (string.IsNullOrEmpty(txtyrcmsng.Text.Trim()) ||
                    !System.Text.RegularExpressions.Regex.IsMatch(txtyrcmsng.Text, @"^\d{4}$"))
                {
                    errormsg += slno + ". Please enter a valid Year of Commissioning (YYYY format). \\n";
                    slno++;
                }

                // Validate Shift selection
                if (rblShifts.SelectedIndex == -1)
                {
                    errormsg += slno + ". Please select the number of shifts. \\n";
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