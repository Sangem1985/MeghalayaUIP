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
using MeghalayaUIP.CommonClass;
using MeghalayaUIP.BAL.CFEBLL;
namespace MeghalayaUIP.Dept.CFE
{
    public partial class CFEApplDeptProcess : System.Web.UI.Page
    {
        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
        CFEBAL objcfebal = new CFEBAL();
        CFEDtls objcfeDtls = new CFEDtls();
        string userid;
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
                    BindCFEApplicatinDetails("1001", "1001");
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        public void BindCFEApplicatinDetails(string UnitID, string InvesterID)
        {
            try
            {
                if (UnitID != null && InvesterID != null)
                {
                    DataSet ds = new DataSet();
                    ds = objcfebal.GetCFEApplicationDetails(UnitID, InvesterID);

                    DataRow row = ds.Tables[0].Rows[0];
                    lblApplNo.Text = Convert.ToString(row["CFEQD_PREREGUIDNO"]);
                    lblunitname1.Text = Convert.ToString(row["CFEQD_COMPANYNAME"]);
                    lblnameUnit.Text = Convert.ToString(row["CFEQD_COMPANYNAME"]);
                    lblconstitution.Text = Convert.ToString(row["CONST_TYPE"]);
                    lblProposal.Text = Convert.ToString(row["CFEQD_PROPOSALFOR"]);
                    lblLocation.Text = Convert.ToString(row["DistrictName"]);
                    lblMandal.Text = Convert.ToString(row["Mandalname"]);
                    lblVillage.Text = Convert.ToString(row["VillageName"]);
                    lblExtentland.Text = Convert.ToString(row["CFEQD_TOTALEXTENTLAND"]);
                    lblBuilt.Text = Convert.ToString(row["CFEQD_BUILTUPAREA"]);
                    lblSectors.Text = Convert.ToString(row["CFEQD_SECTOR"]);
                    lblActivity.Text = Convert.ToString(row["LineofActivity_Name"]);
                    lblPollution.Text = Convert.ToString(row["CFEQD_PCBCATEGORY"]);
                    lblIndustry.Text = Convert.ToString(row["INDUSTRYTYPE"]);

                    lblUnitLocation.Text = Convert.ToString(row["CFEQD_UNTLOCATION"]);
                    lblMIDCL.Text = Convert.ToString(row["CFEQD_MIDCLLAND"]);
                    lblproposeEMP.Text = Convert.ToString(row["CFEQD_PROPEMP"]);
                    lblLANDINR.Text = Convert.ToString(row["CFEQD_LANDVALUE"]);
                    lblBuildingINR.Text = Convert.ToString(row["CFEQD_BUILDINGVALUE"]);
                    lblMachineryINR.Text = Convert.ToString(row["CFEQD_PMCOST"]);
                    lblExpectTurnINR.Text = Convert.ToString(row["CFEQD_EXPECTEDTURNOVER"]);
                    lblTPCost.Text = Convert.ToString(row["CFEQD_TOTALPROJCOST"]);
                    lblEnterpriseCat.Text = Convert.ToString(row["CFEQD_ENTERPRISETYPE"]);
                    lblPowerreq.Text = Convert.ToString(row["POWER_KW"]);
                    lblGenerator.Text = Convert.ToString(row["CFEQD_GENREQ"]);
                    lblHeightBuild.Text = Convert.ToString(row["CFEQD_BUILDINGHT"]);
                    lblRSDSstore.Text = Convert.ToString(row["CFEQD_STORINGRSDS"]);
                    lblExplosive.Text = Convert.ToString(row["CFEQD_MANFEXPLOSIVES"]);
                    lblPetrol.Text = Convert.ToString(row["CFEQD_MANFPETROL"]);
                    lblRoadcutting.Text = Convert.ToString(row["CFEQD_RDCTNGREQ"]);
                    lblEncumbrance.Text = Convert.ToString(row["CFEQD_NONENCMCERTREQ"]);
                    lblCommericalTax.Text = Convert.ToString(row["CFEQD_COMMTAXREQ"]);

                    //if (lblHT.Text == "CFEQD_USINGHTMETER")
                    //    divHTMeter.Visible = true;
                    //else divHTMeter.Visible = false;
                    lblHT.Text = Convert.ToString(row["CFEQD_USINGHTMETER"]);

                    if (lblHT.Text == "Yes")
                    {
                        divHTMeter.Visible = true;
                    }
                    else
                    {
                        divHTMeter.Visible = false;
                    }

                    lblVoltage.Text = Convert.ToString(row["CEIGREGVOLTAGE"]);
                    //if (lblVoltage.Text== "Y")
                    //{
                    //    divpowerplants1.Visible = true;
                    //}
                    //else
                    //{
                    //    divpowerplants1.Visible = false;
                    //}
                    lblPowerplant.Text = Convert.ToString(row["POWERPLANTNAME"]);


                    lblCapacity.Text = Convert.ToString(row["CFEQD_AGGRCAPACITY"]);

                    lblForest.Text = Convert.ToString(row["CFEQD_FORSTDISTLTRREQ"]);

                    lblNonForest.Text = Convert.ToString(row["CFEQD_NONFORSTLANDCERTREQ"]);
                    lblFelltrees.Text = Convert.ToString(row["CFEQD_TREESFELLING"]);
                    if (lblFelltrees.Text == "Yes")
                        divtrees.Visible = true;
                    else divtrees.Visible = false;

                    lblfelledtree.Text = Convert.ToString(row["CFEQD_NOOFTREES"]);
                    lblVicinity.Text = Convert.ToString(row["CFEQD_WATERBODYVICINITY"]);

                    lblborewell.Text = Convert.ToString(row["CFEQD_BOREWELLEXISTS"]);

                    lblRegulationLabour.Text = Convert.ToString(row["CFEQD_LABOURACT1970"]);
                    if (lblRegulationLabour.Text == "Yes")
                        trworkers1970.Visible = true;
                    else trworkers1970.Visible = false;
                    lblwork.Text = Convert.ToString(row["CFEQD_NOOFWORKERSCONTR1970"]);

                    lblinterstate.Text = Convert.ToString(row["CFEQD_LABOURACT1979"]);
                    if (lblinterstate.Text == "Yes")
                        interwork.Visible = true;
                    else interwork.Visible = false;
                    lblInterWorker.Text = Convert.ToString(row["CFEQD_NOOFWORKERS1979"]);

                    lblRECOS.Text = Convert.ToString(row["CFEQD_LABOURACT1996"]);
                    lblConstruction.Text = Convert.ToString(row["CFEQD_BUILDINGWORKS1996"]);
                    if (lblConstruction.Text == "Yes")
                        tr1996work.Visible = true;
                    else tr1996work.Visible = false;
                    txt1996Workers.Text = Convert.ToString(row["CFEQD_NOOFWORKERS1996"]);
                    lblcontractorLic.Text = Convert.ToString(row["CFEQD_CONTRLABOURACT"]);
                    if (lblcontractorLic.Text == "Yes")
                        trContrctworkers.Visible = true;
                    else trContrctworkers.Visible = false;
                    lblSector.Text = Convert.ToString(row["CFEQD_NOOFWORKERSCONTR"]);
                    lblAbolition.Text = Convert.ToString(row["CFEQD_CONTRLABOURACT1970"]);
                    if (lblAbolition.Text == "Yes")
                        trcontrworkers1970.Visible = true;
                    else trcontrworkers1970.Visible = false;
                    lblwork1970.Text = Convert.ToString(row["CFEQD_NOOFWORKERSCONTR1970"]);


                }
                if (Request.QueryString["status"].ToString() == "PRESCRUTINYPENDING" || Request.QueryString["status"].ToString() == "APPROVALPENDING")
                {
                    verifypanel.Visible = true;
                }
                else
                {
                    verifypanel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                if (ddlStatus.SelectedValue != "")
                {
                    if (ddlStatus.SelectedValue == "5" || ddlStatus.SelectedValue == "16")
                    {
                        if ((ddlStatus.SelectedValue == "16" || ddlStatus.SelectedValue == "5") && (string.IsNullOrWhiteSpace(txtRequest.Text) || txtRequest.Text == "" || txtRequest.Text == null))
                        {
                            if (ddlStatus.SelectedValue == "5")
                            {
                                lblmsg0.Text = "Please Enter Query Description";
                                Failure.Visible = true;
                                return;
                            }
                            else if (ddlStatus.SelectedValue == "16")
                            {
                                lblmsg0.Text = "Please Enter Rejection Reason";
                                Failure.Visible = true;
                                return;
                            }

                        }
                    }
                    else if (ddlStatus.SelectedValue == "11")
                    {
                        if (string.IsNullOrWhiteSpace(txtAdditionalAmount.Text) || txtAdditionalAmount.Text == "" || txtAdditionalAmount.Text == null)
                        {
                            lblmsg0.Text = "Please Enter Additional Amount";
                            Failure.Visible = true;
                            return;
                        }
                        else
                        {
                            if (txtAdditionalAmount.Text.Trim() == "0")
                            {
                                lblmsg0.Text = "Additional Amount should not be Zero";
                                Failure.Visible = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        objcfeDtls.Unitid = Session["UNITID"].ToString();
                        objcfeDtls.Investerid = Session["INVESTERID"].ToString();
                        if (ddlStatus != null)
                            objcfeDtls.status = Convert.ToInt32(ddlStatus.SelectedValue);
                        objcfeDtls.UserID = ObjUserInfo.UserID;
                        objcfeDtls.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                        objcfeDtls.Remarks = txtRequest.Text;
                        if(Request.QueryString["status"].ToString() == "PRESCRUTINYPENDING")
                        {
                            if(ddlStatus.SelectedValue=="16")
                            {
                                objcfeDtls.PrescrutinyRejectionFlag = "Y";
                            }
                            else
                            {
                                objcfeDtls.PrescrutinyRejectionFlag = "N";
                            }
                        }
                        var Hostname = Dns.GetHostName();
                        objcfeDtls.IPAddress = Dns.GetHostByName(Hostname).AddressList[0].ToString();

                        string valid = objcfebal.UpdateCFEDepartmentProcess(objcfeDtls);
                        btnSubmit.Enabled = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Submitted Successfully!');  window.location.href='PreRegApplDeptDashBoard.aspx'", true);
                        return;
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
                lblmsg0.Text = "Oops, You have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                string User_id = "0";
                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {
                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    User_id = ((DeptUserInfo)Session["DeptUserInfo"]).UserID;
                }
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, User_id);
            }
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ddlStatus.SelectedValue == "4" || ddlStatus.SelectedValue == "5" )
        //        {
        //            if ((string.IsNullOrWhiteSpace(txtRequest.Text) || txtRequest.Text == "" || txtRequest.Text == null))
        //            {
        //                lblmsg0.Text = "Please Enter Remarks";
        //                Failure.Visible = true;
        //                return;
        //            }
        //            else
        //            {
        //                var ObjUserInfo = new DeptUserInfo();
        //                if (Session["DeptUserInfo"] != null)
        //                {
        //                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
        //                    {
        //                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
        //                    }
        //                    // username = ObjUserInfo.UserName;
        //                }
        //                prd.Unitid = Session["UNITID"].ToString();
        //                prd.Investerid = Session["INVESTERID"].ToString();
        //                if (ddlStatus != null)
        //                    prd.status = Convert.ToInt32(ddlStatus.SelectedValue);
        //                prd.UserID = ObjUserInfo.UserID;
        //                prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
        //                var Hostname = Dns.GetHostName();
        //                prd.IPAddress = Dns.GetHostByName(Hostname).AddressList[0].ToString();
        //                prd.Remarks = txtRequest.Text;
        //                string valid = PreBAL.PreRegApprovals(prd);
        //                if (valid != "")
        //                {
        //                    verifypanel.Visible = false;
        //                    success.Visible = true;
        //                    lblmsg.Text = "Application Processed Successfully";
        //                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Application Processed Successfully!'); '", true);
        //                    return;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            lblmsg0.Text = "Please Select Action";
        //            Failure.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Failure.Visible = true;
        //        lblmsg0.Text = ex.Message;
        //    }
        //}

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
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
                if (ddlStatus.SelectedValue == "5" || ddlStatus.SelectedValue == "16" || ddlStatus.SelectedValue == "11")
                {
                    if (ddlStatus.SelectedValue == "5")
                    {
                        tdquryorrej.Visible = true;
                        tdquryorrejTxtbx.Visible = true;
                        txtRequest.Visible = true;
                        lblremarks.Text = "Please Enter Query Details";
                        //Payment.Visible = false;
                        txtAdditionalAmount.Visible = false;
                    }
                    else if (ddlStatus.SelectedValue == "16")
                    {
                        tdquryorrej.Visible = true;
                        tdquryorrejTxtbx.Visible = true;
                        txtRequest.Visible = true;
                        lblremarks.Text = "Please Enter Rejection Reason";
                        //Payment.Visible = false;
                        txtAdditionalAmount.Visible = false;
                    }
                    else if (ddlStatus.SelectedValue == "11")
                    {
                        //ayment.Visible = true;
                        txtAdditionalAmount.Visible = true;
                        lblremarks.Text = "Please Enter Additional Amount";
                        tdquryorrej.Visible = true;
                        tdquryorrejTxtbx.Visible = true;
                        txtRequest.Visible = false;
                    }
                }
                else if (ddlStatus.SelectedValue == "4")
                {
                    //tblaction.Visible = true;
                    //lblaction.Text = "Please Enter Query Description";

                }
                else
                {
                    //tblaction.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                btnSubmit_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                string User_id = "0";
                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {
                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    User_id = ((DeptUserInfo)Session["DeptUserInfo"]).UserID;
                }
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, User_id);
            }
        }
    }
}