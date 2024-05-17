using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEForestDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
        string UNITID;
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
                
                UNITID = Convert.ToString(Session["UNITID"]);


                Page.MaintainScrollPositionOnPostBack = true;
                Failure.Visible = false;
                success.Visible = false;
                if (!IsPostBack)
                {
                    BindDivisionForest();
                    Binddata();

                }
            }
        }

        public string Stepvalidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtspecies.Text) || txtspecies.Text == "" || txtspecies.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Species \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTimberlength.Text) || txtTimberlength.Text == "" || txtTimberlength.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Length Of Timber (in Meters) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTimberVolume.Text) || txtTimberVolume.Text == "" || txtTimberVolume.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter  Volume Of Timber (in Meters) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtGirth.Text) || txtGirth.Text == "" || txtGirth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Girth (in Meters) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEstimated.Text) || txtEstimated.Text == "" || txtEstimated.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Firewood/Rootwood/Faggot \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtpole.Text) || txtpole.Text == "" || txtpole.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter No of Pole \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNorth.Text) || txtNorth.Text == "" || txtNorth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter North \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEast.Text) || txtEast.Text == "" || txtEast.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter East \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWest.Text) || txtWest.Text == "" || txtWest.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter West \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSouth.Text) || txtSouth.Text == "" || txtSouth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter South \\n";
                    slno = slno + 1;
                }


                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public void BINDDATA()
        {
            try
            {
                DataSet ds = new DataSet();
                //ds = objcfebal.GetCFEQuestionnaireDet(hdnUserID.Value);
                //if (ds != null)
                //{
                //    txtspecies.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                //    txtlength.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                //    txtTimber.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                //    txtGirth.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                //    txtEstimated.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                //    txtpole.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                //    txtNorth.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                //    txtEast.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                //    txtWest.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                //    txtSouth.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);

                //}
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
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetForestRetrive(hdnUserID.Value, UNITID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_UNITID"]);
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_ADDRESS"]);
                    RblLatitude.SelectedValue = ds.Tables[0].Rows[0]["CFEFD_LATTITUDE"].ToString();
                    txtLatDegrees.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_DEGREES"]);
                    txtLatMinutes.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_MINUTES"]);
                    txtLatSeconds.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_SECONDS"]);
                    rblLongitude.SelectedValue = ds.Tables[0].Rows[0]["CFEFD_LONGITUDE"].ToString();
                    txtLongDegrees.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_DEGREE"]);
                    txtLongMinutes.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_MINUTE"]);
                    txtLongSeconds.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_SECOND"]);
                    txtGPSCordinates.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_GPSCOORDINATES"]);
                    txtPurpose.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_PURPOSEAPPLICATION"]);
                    ddlForest.SelectedValue = ds.Tables[0].Rows[0]["CFEFD_FORESTDIVISION"].ToString();
                    txtInformation.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_INFORMATION"]);

                    txtspecies.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_SPECIES"]);
                    txtTimberlength.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_TIMBERLENGTH"]);
                    txtTimberVolume.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_TIMBERVOLUME"]);
                    txtGirth.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_GIRTH"]);
                    txtEstimated.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_ESTIMATED"]);
                    txtpole.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_POLES"]);

                    txtNorth.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_NORTH"]);
                    txtEast.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_EAST"]);
                    txtWest.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_WEST"]);
                    txtSouth.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_SOUTH"]);
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindDivisionForest()
        {
            try
            {
                ddlForest.Items.Clear();

                List<MasterForestDivision> objStatesModel = new List<MasterForestDivision>();

                objStatesModel = mstrBAL.GetForestDivision();
                if (objStatesModel != null)
                {
                    ddlForest.DataSource = objStatesModel;
                    ddlForest.DataValueField = "FORESTDIV_ID";
                    ddlForest.DataTextField = "FORESTDIV_NAME";
                    ddlForest.DataBind();
                }
                else
                {
                    ddlForest.DataSource = null;
                    ddlForest.DataBind();
                }
                AddSelect(ddlForest);
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


        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEPowerDetails.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            String Quesstionriids = "106";
            

            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Stepvalidations();
                if (ErrorMsg == "")
                {
                    Forest_Details objCFEQForest = new Forest_Details();
                    if (Convert.ToString(ViewState["UnitID"]) != "")
                    { objCFEQForest.UNITID = Convert.ToString(ViewState["UnitID"]); }
                    objCFEQForest.CreatedBy = hdnUserID.Value;
                    objCFEQForest.IPAddress = getclientIP();
                    objCFEQForest.Questionnariid = Quesstionriids;
                    objCFEQForest.UnitId = Convert.ToString(Session["UNITID"]);
                    objCFEQForest.Address = txtAddress.Text;
                    objCFEQForest.Lattitude = RblLatitude.SelectedValue;
                    objCFEQForest.LatDegrees = txtLatDegrees.Text;
                    objCFEQForest.LatMinutes = txtLatMinutes.Text;
                    objCFEQForest.LatSeconds = txtLatSeconds.Text;
                    objCFEQForest.Longitude = rblLongitude.SelectedValue;
                    objCFEQForest.LongDegrees = txtLongDegrees.Text;
                    objCFEQForest.LongMinutes = txtLongMinutes.Text;
                    objCFEQForest.LongSeconds = txtLongSeconds.Text;
                    objCFEQForest.GPSCoodinates = txtGPSCordinates.Text;
                    objCFEQForest.Purpose = txtPurpose.Text;
                    objCFEQForest.ForestDivision = ddlForest.SelectedValue;
                    objCFEQForest.information = txtInformation.Text;
                    //  objCFEQForest
                    objCFEQForest.Species = txtspecies.Text;
                    objCFEQForest.EstTimberLength = txtTimberlength.Text;
                    objCFEQForest.EstTimberVolume = txtTimberVolume.Text;
                    objCFEQForest.Girth = txtGirth.Text;
                    objCFEQForest.Est_Firewood = txtEstimated.Text;
                    objCFEQForest.No_Poles = txtpole.Text;
                    objCFEQForest.North = txtNorth.Text;
                    objCFEQForest.East = txtEast.Text;
                    objCFEQForest.West = txtWest.Text;
                    objCFEQForest.South = txtSouth.Text;


                    result = objcfebal.InsertCFEForestDet(objCFEQForest);
                    ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Forest Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                }
                else
                {
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
                Response.Redirect("~/User/CFE/CFEPaymentPage.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
}