using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegDITProcess : System.Web.UI.Page
    {
        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
        DataTable dt = new DataTable();
        MasterBAL mstrBAL = new MasterBAL();
        List<PreRegDtls> lstPreRegDtlsVo = new List<PreRegDtls>();
        MasterBAL objmbal = new MasterBAL();
        string Queryid;
        //Label lblApplNo = new Label();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                success.Visible = false;
                Failure.Visible = false;
                MaintainScrollPositionOnPostBack = true;
                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {
                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    hdnUserID.Value = ObjUserInfo.UserID;
                    ViewState["DEPTID"] = ObjUserInfo.Deptid;
                    if (!IsPostBack)
                    {
                        BindaApplicatinDetails();
                        // BindDepartments();
                    }
                    Queryid = Convert.ToString(ViewState["COMMQID"]);

                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindaApplicatinDetails()
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

                if (Session["UNITID"] != null && Session["INVESTERID"] != null && Session["stage"] != null)
                {
                    prd.Unitid = Session["UNITID"].ToString();
                    prd.Investerid = Session["INVESTERID"].ToString();
                    prd.UserID = ObjUserInfo.UserID;
                    prd.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                    prd.Stage = Convert.ToInt32(Session["stage"]);
                    if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                    {
                        prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    }
                    DataSet ds = new DataSet();
                    ds = PreBAL.GetPreRegNodelOfficer(prd);
                    if (ds.Tables.Count > 0)
                    {
                        DataRow row = ds.Tables[0].Rows[0];
                        lblCompanyName.Text = Convert.ToString(row["COMPANYNAME"]);
                        lblCompanyPAN.Text = Convert.ToString(row["COMPANYPANNO"]);
                        lblCompanyProposal.Text = Convert.ToString(row["COMPANYPRAPOSAL"]);
                        lblregdate.Text = Convert.ToString(row["REGISTRATIONDATE"]);

                        lblGSTIN.Text = Convert.ToString(row["GSTNNO"]);

                        lblcomptype.Text = Convert.ToString(row["CONST_TYPE"]);
                        lblcatreg.Text = Convert.ToString(row["REGISTRATIONTYPENAME"]);
                        lblregcategory.Text = "7. " + lblcatreg.Text + " No.";
                        lblUdyam.Text = Convert.ToString(row["UDYAMNO"]);
                        lbldoorno_authrep.Text = Convert.ToString(row["REP_DOORNO"]);
                        lblisland.Text = Convert.ToString(row["UNIT_LANDTYPE"]);
                        if (lblisland.Text == "Own")
                        { divDrNo1.Visible = true; divDrNo2.Visible = true; }

                        lblpromotndcont.Text = Convert.ToString(row["FRD_PROMOTEREQUITY"]);
                        lblequityamount.Text = Convert.ToString(row["FRD_EQUITY"]);
                        lbltermloanworking.Text = Convert.ToString(row["FRD_LOAN"]);

                        lblunsecuredloan.Text = Convert.ToString(row["FRD_UNSECUREDLOAN"]);
                        lblinternalresources.Text = Convert.ToString(row["FRD_INTERNALRESOURCE"]);
                        lblstatescheme.Text = Convert.ToString(row["FRD_STATE"]);

                        lblcapitalsubsidy.Text = Convert.ToString(row["FRD_CAPITALSUBSIDY"]);
                        lblunnati.Text = Convert.ToString(row["FRD_UNNATI"]);
                        lblcentralscheme.Text = Convert.ToString(row["FRD_CENTRAL"]);
                        if (Convert.ToString(row["ELIGIBLE_FLAG"]).Trim() == "N")
                        {
                            lblnote.Visible = true;
                        }
                        else
                        {
                            lblnote.Visible = false;
                        }


                        lblName.Text = Convert.ToString(row["REP_NAME"]);
                        lblMobile.Text = Convert.ToString(row["REP_MOBILE"]);
                        lblEmail.Text = Convert.ToString(row["REP_EMAIL"]);
                        lblLocality.Text = Convert.ToString(row["REP_LOCALITY"]);
                        lblDistict.Text = Convert.ToString(row["REP_DISTRICT"]);
                        lblMandal.Text = Convert.ToString(row["REP_MANDAL"]);
                        lblVillage.Text = Convert.ToString(row["REP_VILLAGE"]);
                        lblPincode.Text = Convert.ToString(row["REP_PINCODE"]);
                        lblPincode.Text = Convert.ToString(row["REP_PINCODE"]);
                        //lblLandtype.Text= Convert.ToString(row["UNIT_LANDTYPE"]);
                        lbldrno.Text = Convert.ToString(row["UNIT_DOORNO"]);
                        lblPro_loc.Text = Convert.ToString(row["UNIT_LOCALITY"]);
                        lblpro_dis.Text = Convert.ToString(row["UNIT_DISTRICT"]);
                        lblPro_Man.Text = Convert.ToString(row["UNIT_MANDAL"]);
                        lblPro_vill.Text = Convert.ToString(row["UNIT_VILLAGE"]);
                        lblPro_Pin.Text = Convert.ToString(row["UNIT_PINCODE"]);

                        lblDateofcomm.Text = Convert.ToString(row["PROJECT_DCP"]);
                        lblNatureofAct.Text = Convert.ToString(row["PROJECT_NOA"]);
                        if (lblNatureofAct.Text == "Manufacturing")
                        {
                            divManf1.Visible = true;
                            divManf2.Visible = true;
                        }
                        else { divService.Visible = true; }
                        lblMainmanuf.Text = Convert.ToString(row["PROJECT_MANFACTIVITY"]);

                        lblmanufProdct.Text = Convert.ToString(row["PROJECT_MANFPRODUCT"]);
                        lblProdNo.Text = Convert.ToString(row["PROJECT_MANFPRODNO"]);
                        lblmainRM.Text = Convert.ToString(row["PROJECT_MAINRM"]);
                        lblAnnualCap.Text = Convert.ToString(row["PROJECT_ANNUALCAPACITY"]);
                        lblunitofmeasure.Text = Convert.ToString(row["PROJECT_UNITOFMEASURE"]);

                        lblMainSrvc.Text = Convert.ToString(row["PROJECT_SRVCACTIVITY"]);
                        lblSrvcProvdng.Text = Convert.ToString(row["PROJECT_SRVCNAME"]);
                        lblSrvcNo.Text = Convert.ToString(row["PROJECT_SRVCNO"]);


                        lblSector.Text = Convert.ToString(row["PROJECT_SECTORNAME"]);
                        lblLOA.Text = Convert.ToString(row["LineofActivity_Name"]);
                        lblPCBcatogry.Text = Convert.ToString(row["PROJECT_PCBCATEGORY"]);


                        lblwastedtls.Text = Convert.ToString(row["PROJECT_WASTEDETAILS"]);
                        lblhazdtls.Text = Convert.ToString(row["PROJECT_HAZWASTEDETAILS"]);
                        lblcivilConstr.Text = Convert.ToString(row["PROJECT_CIVILCONSTR"]);
                        lbllandArea.Text = Convert.ToString(row["PROJECT_LANDAREA"]);
                        lblBuildingArea.Text = Convert.ToString(row["PROJECT_BUILDINGAREA"]);

                        lblWaterReq.Text = Convert.ToString(row["PROJECT_WATERREQ"]);
                        lblPowerReq.Text = Convert.ToString(row["PROJECT_POWERRREQ"]);


                        lblEstProjcost.Text = Convert.ToString(row["PROJECT_EPCOST"]);
                        lblPMCost.Text = Convert.ToString(row["PROJECT_PMCOST"]);
                        lblIFC.Text = Convert.ToString(row["PROJECT_IFC"]);
                        lblDFA.Text = Convert.ToString(row["PROJECT_DFA"]);
                        lblBuldingValue.Text = Convert.ToString(row["PROJECT_BUILDINGVALUE"]);
                        lblLandValue.Text = Convert.ToString(row["PROJECT_LANDVALUE"]);
                        lblWaterValue.Text = Convert.ToString(row["PROJECT_WATERVALUE"]);
                        lblElectricityValue.Text = Convert.ToString(row["PROJECT_ELECTRICITYVALUE"]);
                        lblWorkingCapital.Text = Convert.ToString(row["PROJECT_WORKINGCAPITAL"]);

                        //lbl_Name1.Text = Convert.ToString(row["REP_NAME"]);
                        //lblunitname1.Text = Convert.ToString(row["COMPANYNAME"]);

                        lblApplNo.Text = Convert.ToString(row["DITREPORT_UPLOADFLAG"]);

                        //lblapplDate.Text = Convert.ToString(row["REP_MOBILE"]);
                        //lblapplDate.Text = Convert.ToString(row["CREATEDDATE"]);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                        {
                            grdRevenueProj.DataSource = ds.Tables[1];
                            grdRevenueProj.DataBind();
                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[2].Rows.Count > 0)
                        {
                            grdDirectors.DataSource = ds.Tables[2];
                            grdDirectors.DataBind();
                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
                        {
                            grdAttachments.DataSource = ds.Tables[3];
                            grdAttachments.DataBind();

                            //GVVerification.DataSource = ds.Tables[3];
                            //GVVerification.DataBind();

                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[4].Rows.Count > 0)
                        {
                            grdQueries.DataSource = ds.Tables[4];
                            grdQueries.DataBind();

                            //grdResponcse.DataSource = ds.Tables[4];
                            //grdResponcse.DataBind();
                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[5].Rows.Count > 0)
                        {
                            grdQryAttachments.DataSource = ds.Tables[5];
                            grdQryAttachments.DataBind();

                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[6].Rows.Count > 0)
                        {
                            grdApplStatus.DataSource = ds.Tables[6];
                            grdApplStatus.DataBind();
                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[7].Rows.Count > 0)
                        {
                            grdQueryRaised.DataSource = ds.Tables[7];
                            grdQueryRaised.DataBind();
                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[8].Rows.Count > 0)
                        {
                            gvDITChecklist.DataSource = ds.Tables[8];
                            gvDITChecklist.DataBind();
                        }
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[4].Rows.Count > 0)
                        {
                            grdResponcse.DataSource = ds.Tables[4];
                            grdResponcse.DataBind();
                        }
                        if (Convert.ToString(Request.QueryString["status"]) != "ApplicationTracker")
                        {

                            if (Request.QueryString["status"].ToString() == "IMATODEPTQUERY"
                           && (Convert.ToString(ds.Tables[6].Rows[0]["PRDA_STAGEID"]) == "6"
                           || Convert.ToString(ds.Tables[6].Rows[0]["PRDA_STAGEID"]) == "13") || Convert.ToString(ds.Tables[6].Rows[0]["PRDA_STAGEID"]) == "19")
                            {
                                if (ObjUserInfo.Roleid == "3")
                                {
                                    if (Convert.ToString(ds.Tables[6].Rows[0]["PRDA_STAGEID"]) == "6")
                                    {
                                        verifypanelAttachment.Visible = true;
                                        QueryResondpanel.Visible = false;
                                    }
                                    else if (Convert.ToString(ds.Tables[6].Rows[0]["PRDA_STAGEID"]) == "19")
                                    {
                                        QueryResondpanel1.Visible = true;
                                    }

                                }
                                else
                                {
                                    verifypanelAttachment.Visible = false;
                                    QueryResondpanel.Visible = true;
                                }
                            }
                            else
                            {
                                // verifypanel.Visible = false;
                            }
                            //if (Convert.ToString(ds.Tables[0].Rows[0]["STATUS"]) == "9")
                            //{
                            //    QueryResondpanel.Visible = true;
                            //}
                            //else
                            //{
                            //    QueryResondpanel.Visible = false;
                            //}
                        }
                        else if (Convert.ToString(Request.QueryString["status"]) == "ApplicationTracker")
                        {
                            QueryResondpanel.Visible = false;

                        }
                    }

                }
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
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.CssClass = "errormsg";
            }
        }

        protected void linkAttachment_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton link = (LinkButton)sender;
                GridViewRow row = (GridViewRow)link.NamingContainer;
                Label lblfilepath = (Label)row.FindControl("lblFilePath");
                //  RadioButtonList rdVerified = (RadioButtonList)row.FindControl("rblAlrdyObtained");

                //if (rdVerified != null)
                //{
                //    rdVerified.SelectedValue = "Y";
                //}

                if (lblfilepath != null || lblfilepath.Text != "")
                    Response.Redirect("~/Dept/Dashboard/DeptServePdfFile.ashx?filePath=" + objmbal.EncryptFilePath(lblfilepath.Text));
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }


        }

        //protected void linkViewQueryAttachment_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LinkButton lnkview = (LinkButton)sender;
        //        GridViewRow row = (GridViewRow)lnkview.NamingContainer;

        //        Label lblfilepath = (Label)row.FindControl("lblFilePath");
        //        if (lblfilepath != null || lblfilepath.Text != "")
        //            Response.Redirect("~/Dept/Dashboard/DeptServePdfFile.ashx?filePath=" + objmbal.EncryptFilePath(lblfilepath.Text));
        //    }
        //    catch (Exception ex)
        //    {
        //        Failure.Visible = true;
        //        lblmsg0.Text = ex.Message;
        //        MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
        //    }
        //}

        protected void btnUpldAttachment_Click(object sender, EventArgs e)
        {
            try
            {

                string newPath = "", Error = "", message = "";
                string sFileDir = ConfigurationManager.AppSettings["PreRegAttachments"];
                // string shortFileDir = "~\\PreRegAttachments";
                if (FileUploadqueryIMA.HasFile)
                {
                    Error = validations(FileUploadqueryIMA);
                    if (Error == "")
                    {
                        if ((FileUploadqueryIMA.PostedFile != null) && (FileUploadqueryIMA.PostedFile.ContentLength > 0))
                        {
                            string sFileName = System.IO.Path.GetFileName(FileUploadqueryIMA.PostedFile.FileName);
                            try
                            {
                                newPath = System.IO.Path.Combine(sFileDir, Session["INVESTERID"].ToString(), ViewState["UNITID"].ToString() + "\\RESPONSEATTACHMENTS");

                                if (!Directory.Exists(newPath))
                                    System.IO.Directory.CreateDirectory(newPath);

                                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                FileUploadqueryIMA.PostedFile.SaveAs(newPath + "\\" + sFileName);

                                //int count = dir.GetFiles().Length;
                                //if (count == 0)
                                //    FileUploadqueryIMA.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                //else
                                //{
                                //    if (count == 1)
                                //    {
                                //        string[] Files = Directory.GetFiles(newPath);

                                //        foreach (string file in Files)
                                //        {
                                //            File.Delete(file);
                                //        }
                                //        FileUploadqueryIMA.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                //    }
                                //}
                                IndustryDetails objattachments = new IndustryDetails();

                                objattachments.QueryID = ViewState["COMMQID"].ToString();
                                objattachments.UnitID = ViewState["UNITID"].ToString();
                                objattachments.InvestorId = Session["INVESTERID"].ToString();
                                objattachments.UserID = hdnUserID.Value.ToString();
                                objattachments.FileType = FileUploadqueryIMA.PostedFile.ContentType;
                                objattachments.FileName = sFileName.ToString();
                                objattachments.Filepath = newPath.ToString() + "\\" + sFileName.ToString();
                                objattachments.FileDescription = "RESPONSE ATTACHMENT";
                                objattachments.Deptid = Convert.ToString(ViewState["DEPTID"]);
                                objattachments.ApprovalId = "0";
                                objattachments.ResponseFileBy = "DEPARTMENT";

                                int result = 0;
                                result = PreBAL.InsertAttachments_PREREG_RESPONSE(objattachments);

                                if (result > 0)
                                {
                                    lblmsg.Text = "<font color='green'>Attachment Successfully Uploaded..!</font>";
                                    hplAttachment.Text = FileUploadqueryIMA.FileName;
                                    hplAttachment.NavigateUrl = "~/Dept/Dashboard/DeptServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objattachments.Filepath);

                                    //hplAttachment.NavigateUrl = shortFileDir + "/" + Session["INVESTERID"].ToString() + "/" + ViewState["UNITID"].ToString() + "/" + "RESPONSEATTACHMENTS" + "/" + sFileName;
                                    hplAttachment.Visible = true;
                                    success.Visible = true;
                                    Failure.Visible = false;
                                }
                                else
                                {
                                    lblmsg0.Text = "<font color='red'>Attachment Upload Failed..!</font>";
                                    success.Visible = false;
                                    Failure.Visible = true;
                                }
                            }
                            catch (Exception)//in case of an error
                            {
                                DeleteFile(newPath + "\\" + sFileName);
                            }
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string validations(FileUpload Attachment)
        {
            try
            {
                string filesize = Convert.ToString(ConfigurationManager.AppSettings["FileSize"].ToString());
                int slno = 1; string Error = "";
                //if (Attachment.PostedFile.ContentType != "application/pdf"
                //|| !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                //{

                if (Attachment.PostedFile.ContentType != "application/pdf")
                {
                    Error = Error + slno + ". Please Upload PDF Documents only \\n";
                    slno = slno + 1;
                }
                if (Attachment.PostedFile.ContentLength >= Convert.ToInt32(filesize))
                {
                    Error = Error + slno + ". Please Upload file size less than " + Convert.ToInt32(filesize) / 1000000 + "MB \\n";
                    slno = slno + 1;
                }
                if (!ValidateFileName(Attachment.PostedFile.FileName))
                {
                    Error = Error + slno + ". Document name should not contain symbols like  <, >, %, $, @, &,=, / \\n";
                    slno = slno + 1;
                }
                else if (!ValidateFileExtension(Attachment))
                {
                    Error = Error + slno + ". Document should not contain double extension (double . ) \\n";
                    slno = slno + 1;
                }
                //}
                return Error;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static bool ValidateFileName(string fileName)
        {
            try
            {
                string pattern = @"[<>%$@&=!:*?|]";

                if (Regex.IsMatch(fileName, pattern))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static bool ValidateFileExtension(FileUpload Attachment)
        {
            try
            {
                string Attachmentname = Attachment.PostedFile.FileName;
                string[] fileType = Attachmentname.Split('.');
                int i = fileType.Length;

                if (i == 2 && fileType[i - 1].ToUpper().Trim() == "PDF")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void DeleteFile(string strFileName)
        {
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)
                {
                    fi.Delete();
                }
            }
        }

        protected void btnSubmit2_Click(object sender, EventArgs e)
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
                }
                if (Convert.ToString(ViewState["ACTIONID"]) != "")
                {
                    if ((Convert.ToString(ViewState["ACTIONID"]) == "12") && (string.IsNullOrWhiteSpace(txtIMAResponse.Text) || txtIMAResponse.Text == "" || txtIMAResponse.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Query Response";
                        Failure.Visible = true;
                        return;
                    }
                    if ((Convert.ToString(ViewState["ACTIONID"]) == "15") && (string.IsNullOrWhiteSpace(txtComQrytoAppl.Text) || txtComQrytoAppl.Text == "" || txtComQrytoAppl.Text == null))
                    {
                        lblmsg0.Text = "Please Enter Query Description";
                        Failure.Visible = true;
                        return;
                    }
                    else
                    {
                        prd.Unitid = Session["UNITID"].ToString();
                        prd.Investerid = Session["INVESTERID"].ToString();
                        if (Convert.ToString(ViewState["ACTIONID"]) != "")
                            prd.status = Convert.ToInt32(Convert.ToString(ViewState["ACTIONID"]));
                        prd.UserID = ObjUserInfo.UserID;
                        if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                        {
                            prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                        }
                        prd.QueryResponse = txtIMAResponse.Text;
                        prd.Remarks = txtComQrytoAppl.Text;
                        prd.IPAddress = getclientIP();
                        prd.QueryID = Convert.ToString(ViewState["COMMQID"]);
                        string valid = PreBAL.PreRegUpdateQuery(prd);
                        // string valid = PreBAL.PreRegApprovals(prd);
                        // btnSubmit.Enabled = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Submitted Successfully!');  window.location.href='PreRegApplIMADashBoard.aspx'", true);
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

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Response.Redirect("~/Dept/PreReg/PreRegDITView.aspx?status=" + Convert.ToString(Request.QueryString["status"]));
                }
                catch (Exception ex)
                {
                    lblmsg0.Text = ex.Message;
                    Failure.Visible = true;
                    MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlQueryAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlqryaction = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddlqryaction.NamingContainer;
                Label lblCommQID = (Label)row.FindControl("lblDQID");
                Label lblDeptID = (Label)row.FindControl("lblDeptID");
                Label lblUNITID = (Label)row.FindControl("lblUNITID");
                ViewState["COMMQID"] = lblCommQID.Text;
                //ViewState["DEPTID"] = lblDeptID.Text;
                ViewState["UNITID"] = lblUNITID.Text;
                if (ddlqryaction.SelectedValue != "0")
                {
                    ViewState["ACTIONID"] = ddlqryaction.SelectedValue;

                    if (ddlqryaction.SelectedValue == "12") //12 IMA Replied to Committee Query
                    {
                        tblcomqury.Visible = true;
                        trIMAResponse.Visible = true;

                        //  verifypanel.Visible = false;
                        trComQrytoAppl.Visible = false; txtComQrytoAppl.Text = "";
                        //  ddldepartment.ClearSelection(); txtDeptQuery.Text = "";
                        // grdDeptQueries.DataSource = null; grdDeptQueries.DataBind(); btnQuery.Enabled = false;
                    }
                    else if (ddlqryaction.SelectedValue == "13") //13	IMA Forwarded Committee Query to Department
                    {
                        // verifypanel.Visible = true;
                        // tdDeptQuery.Visible = true;
                        //  btnQuery.Visible = true;

                        // headingSix.Visible = false;
                        //  trVrfyhdng.Visible = false;
                        // trVrfydtls.Visible = false;
                        tblcomqury.Visible = false; txtComQrytoAppl.Text = ""; txtIMAResponse.Text = ""; hplAttachment.Visible = false;
                    }
                    else if (ddlqryaction.SelectedValue == "15") //15	IMA Forwarded Committee Query to Applicant
                    {
                        tblcomqury.Visible = true;
                        trComQrytoAppl.Visible = true;

                        //  verifypanel.Visible = false;
                        trIMAResponse.Visible = false; txtIMAResponse.Text = ""; hplAttachment.Visible = false;
                        //ddldepartment.ClearSelection(); txtDeptQuery.Text = "";
                        //grdDeptQueries.DataSource = null; grdDeptQueries.DataBind(); btnQuery.Enabled = false;

                    }
                }
                else
                {

                    tblcomqury.Visible = false; txtComQrytoAppl.Text = ""; txtIMAResponse.Text = "";
                    //  verifypanel.Visible = false;
                    //  ddldepartment.ClearSelection(); txtDeptQuery.Text = "";
                    //  grdDeptQueries.DataSource = null; grdDeptQueries.DataBind(); btnQuery.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnDIT_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblApplNo.Text == "Y")
                {
                    var ObjUserInfo = new DeptUserInfo();
                    if (Session["DeptUserInfo"] != null)
                    {

                        if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                        {
                            ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                        }
                    }

                    prd.Unitid = Session["UNITID"].ToString();
                    prd.Investerid = Session["INVESTERID"].ToString();
                    prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    prd.Remark = txtRemark.Text;
                    // prd.Forward = ddlOfcr.SelectedValue;
                    prd.DPRCRETEDBY = hdnUserID.Value;
                    prd.IPAddress = getclientIP();
                    string valid = PreBAL.PreRegDITProcess(prd);


                    // BindaApplicatinDetails();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('DITProcess Successfully...!');  window.location.href='PreRegDITDashBoard.aspx'", true);
                    return;
                }
                else
                {
                    lblmsg0.Text = "Please Click here for Site Inspection Template And Fille All Details...!";
                    Failure.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnupldDCReport_Click(object sender, EventArgs e)
        {
            try
            {
                string newPath = "", Error = "", message = "";
                string sFileDir = ConfigurationManager.AppSettings["PreRegAttachments"];
                if (fupDCReport.HasFile)
                {
                    Error = validations(fupDCReport);
                    if (Error == "")
                    {
                        if ((fupDCReport.PostedFile != null) && (fupDCReport.PostedFile.ContentLength > 0))
                        {
                            string sFileName = System.IO.Path.GetFileName(fupDCReport.PostedFile.FileName);
                            try
                            {
                                newPath = System.IO.Path.Combine(sFileDir, Session["INVESTERID"].ToString(), Session["UNITID"].ToString() + "\\RESPONSEATTACHMENTS");

                                if (!Directory.Exists(newPath))
                                    System.IO.Directory.CreateDirectory(newPath);

                                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                fupDCReport.PostedFile.SaveAs(newPath + "\\" + sFileName);

                                //int count = dir.GetFiles().Length;
                                //if (count == 0)
                                //    FileUploadqueryIMA.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                //else
                                //{
                                //    if (count == 1)
                                //    {
                                //        string[] Files = Directory.GetFiles(newPath);

                                //        foreach (string file in Files)
                                //        {
                                //            File.Delete(file);
                                //        }
                                //        FileUploadqueryIMA.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                //    }
                                //}
                                IndustryDetails objattachments = new IndustryDetails();

                                objattachments.QueryID = Queryid;
                                objattachments.UnitID = Session["UNITID"].ToString();
                                objattachments.InvestorId = Session["INVESTERID"].ToString();
                                objattachments.UserID = hdnUserID.Value.ToString();
                                objattachments.FileType = fupDCReport.PostedFile.ContentType;
                                objattachments.FileName = sFileName.ToString();
                                objattachments.Filepath = newPath.ToString() + "\\" + sFileName.ToString();
                                objattachments.FileDescription = "RESPONSE ATTACHMENT";
                                objattachments.Deptid = Convert.ToString(ViewState["DEPTID"]);
                                objattachments.ApprovalId = "0";
                                objattachments.ResponseFileBy = "DEPARTMENT";

                                int result = 0;
                                result = PreBAL.InsertAttachments_PREREG_RESPONSE(objattachments);

                                if (result > 0)
                                {
                                    lblmsg.Text = "<font color='green'>Attachment Successfully Uploaded..!</font>";
                                    hplAttachment.Text = fupDCReport.FileName;
                                    hplAttachment.NavigateUrl = "~/Dept/Dashboard/DeptServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objattachments.Filepath);

                                    //hplAttachment.NavigateUrl = shortFileDir + "/" + Session["INVESTERID"].ToString() + "/" + ViewState["UNITID"].ToString() + "/" + "RESPONSEATTACHMENTS" + "/" + sFileName;
                                    hplAttachment.Visible = true;
                                    success.Visible = true;
                                    Failure.Visible = false;
                                }
                                else
                                {
                                    lblmsg0.Text = "<font color='red'>Attachment Upload Failed..!</font>";
                                    success.Visible = false;
                                    Failure.Visible = true;
                                }
                            }
                            catch (Exception)//in case of an error
                            {
                                DeleteFile(newPath + "\\" + sFileName);
                            }
                        }
                    }
                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void lnkbutton_Click(object sender, EventArgs e)
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
                }
                prd.Unitid = Session["UNITID"].ToString();
                prd.Investerid = Session["INVESTERID"].ToString();


                Response.Redirect("~/Dept/PreReg/PreRegDITSiteInspection.aspx?Status=" + Request.QueryString["status"].ToString());
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnsendresponsetoIMA_Click(object sender, EventArgs e)
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
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                TextBox txtReply = (TextBox)row.FindControl("txtIMAQueryReply");
                if (string.IsNullOrEmpty(txtReply.Text) || txtReply.Text == "" || txtReply.Text == null)
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Enter Query Response";
                    txtReply.Focus();
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", lblmsg0.Text, true);
                    return;
                }
                else
                {
                    Label UnitID = (Label)row.FindControl("lblUNITID");
                    Label DeptID = (Label)row.FindControl("lblDeptID");
                    Label QID = (Label)row.FindControl("lblDQID");
                    prd.Investerid = Session["INVESTERID"].ToString();
                    prd.UserID = ObjUserInfo.UserID.Trim();
                    prd.Unitid = UnitID.Text.Trim();
                    prd.QuerytoDeptID = DeptID.Text.Trim();
                    prd.QueryID = QID.Text.Trim();
                    prd.QueryResponse = txtReply.Text.Trim();
                    prd.IPAddress = getclientIP();
                    prd.status = 7;  ////  DEPARTMENT REPLY TO IMA QUERY
                    prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    string valid = PreBAL.PreRegUpdateQuery(prd);
                    btn.Enabled = false;
                    BindaApplicatinDetails();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Replied to IMA Query Successfully!');  window.location.href='PreRegApplDeptDashBoard.aspx'", true);
                    return;
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void btnUpldAttachment1_Click(object sender, EventArgs e)
        {
            try
            {
                string newPath = "", Error = "", message = "";
                string sFileDir = ConfigurationManager.AppSettings["PreRegAttachments"];
                //  string shortFileDir = "~\\PreRegAttachments";
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                FileUpload FileUploadquery = (FileUpload)row.FindControl("FileUploadquery");
                Label lblDQID = (Label)row.FindControl("lblDQID");
                Label lblDeptID = (Label)row.FindControl("lblDeptID");
                Label lblUNITID = (Label)row.FindControl("lblUNITID");
                HyperLink hplAttachment = (HyperLink)row.FindControl("hplAttachment");
                if (FileUploadquery.HasFile)
                {
                    Error = validations(FileUploadquery);
                    if (Error == "")
                    {
                        if ((FileUploadquery.PostedFile != null) && (FileUploadquery.PostedFile.ContentLength > 0))
                        {
                            string sFileName = System.IO.Path.GetFileName(FileUploadquery.PostedFile.FileName);
                            try
                            {

                                newPath = System.IO.Path.Combine(sFileDir, Session["INVESTERID"].ToString(), lblUNITID.Text + "\\RESPONSEATTACHMENTS");

                                if (!Directory.Exists(newPath))
                                    System.IO.Directory.CreateDirectory(newPath);

                                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                FileUploadquery.PostedFile.SaveAs(newPath + "\\" + sFileName);

                                //int count = dir.GetFiles().Length;
                                //if (count == 0)
                                //    FileUploadquery.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                //else
                                //{
                                //    if (count == 1)
                                //    {
                                //        string[] Files = Directory.GetFiles(newPath);

                                //        foreach (string file in Files)
                                //        {
                                //            File.Delete(file);
                                //        }
                                //        FileUploadquery.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                //    }
                                //}
                                IndustryDetails objattachments = new IndustryDetails();

                                objattachments.QueryID = lblDQID.Text;
                                objattachments.UnitID = lblUNITID.Text;
                                objattachments.InvestorId = Session["INVESTERID"].ToString();
                                objattachments.UserID = hdnUserID.Value.ToString();
                                objattachments.FileType = FileUploadquery.PostedFile.ContentType;
                                objattachments.FileName = sFileName.ToString();
                                objattachments.Filepath = newPath.ToString() + "\\" + sFileName.ToString();
                                objattachments.FileDescription = "RESPONSE ATTACHMENT";
                                objattachments.Deptid = lblDeptID.Text;
                                objattachments.ApprovalId = "0";
                                objattachments.ResponseFileBy = "DEPARTMENT";

                                int result = 0;
                                result = PreBAL.InsertAttachments_PREREG_RESPONSE(objattachments);

                                if (result > 0)
                                {
                                    lblmsg.Text = "<font color='green'>Attachment Successfully Uploaded..!</font>";
                                    hplAttachment.Text = FileUploadquery.FileName;
                                    hplAttachment.NavigateUrl = "~/Dept/Dashboard/DeptServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objattachments.Filepath);
                                    //hplAttachment.NavigateUrl = shortFileDir + "/" + Session["INVESTERID"].ToString() + "/" + lblUNITID.Text + "/" + "RESPONSEATTACHMENTS" + "/" + sFileName;
                                    hplAttachment.Visible = true;
                                    success.Visible = true;
                                    Failure.Visible = false;
                                }
                                else
                                {
                                    lblmsg0.Text = "<font color='red'>Attachment Upload Failed..!</font>";
                                    success.Visible = false;
                                    Failure.Visible = true;
                                }


                            }
                            catch (Exception)//in case of an error
                            {

                                DeleteFile(newPath + "\\" + sFileName);
                            }
                        }
                    }

                    else
                    {
                        message = "alert('" + Error + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void grdApplStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (lblApplNo.Text == "Y")
            {
                var ObjUserInfo = new DeptUserInfo();
                if (Session["DeptUserInfo"] != null)
                {

                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkView");
                    string[] allowedUserIDs = { "1073", "1074", "1075", "1076", "1077", "1078", "1079", "1080", "1081", "1082", "1083", "1084" };
                    if (allowedUserIDs.Contains(ObjUserInfo.UserID))
                    {
                        grdApplStatus.Columns[7].Visible = true;
                        lnkView.Visible = true;
                    }
                    else { lnkView.Visible = false; }
                }
            }
            else
            {
                lblmsg0.Text = "Please Click here for Site Inspection Template And Fille All Details...!";
                Failure.Visible = true;
            }
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblApplNo.Text == "Y")
                {
                    Response.Redirect("~/Dept/PreReg/PreRegDITSitePrintPage.aspx?status=" + Convert.ToString(Request.QueryString["status"]));
                }
                else
                {
                    lblmsg0.Text = "Please Click here for Site Inspection Template And Fille All Details...!";
                    Failure.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void grdAttachments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HyperLink hplAttachment = (HyperLink)e.Row.FindControl("linkAttachment");
                    Label lblfilepath = (Label)e.Row.FindControl("lblFilePath");

                    if (hplAttachment != null && hplAttachment.Text != "" && lblfilepath != null && lblfilepath.Text != "")
                    {
                        hplAttachment.NavigateUrl = "~/Dept/Dashboard/DeptServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(lblfilepath.Text);
                        hplAttachment.Target = "blank";
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

        protected void grdQryAttachments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HyperLink hplAttachment = (HyperLink)e.Row.FindControl("linkViewQueryAttachment");
                    Label lblfilepath = (Label)e.Row.FindControl("lblFilePath");

                    if (hplAttachment != null && hplAttachment.Text != "" && lblfilepath != null && lblfilepath.Text != "")
                    {
                        hplAttachment.NavigateUrl = "~/Dept/Dashboard/DeptServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(lblfilepath.Text);
                        hplAttachment.Target = "blank";
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
    }
}