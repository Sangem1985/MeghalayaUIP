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
    public partial class CFOExcise : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL bal = new CFOBAL();
        UserInfo ObjUserInfo;
        string UnitID, Errormsg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                        UnitID = Convert.ToString(Session["CFOUNITID"]);
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
                        DataSet dsnew = new DataSet();
                        dsnew = bal.GetApprovalDataByDeptId(Session["CFOQID"].ToString(), Session["CFOUNITID"].ToString(), "7");
                        if (dsnew.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsnew.Tables[0].Rows.Count; i++)
                            {
                                if (dsnew.Tables[0].Rows[i]["CFOQA_APPROVALID"].ToString() == "45")
                                {
                                    div_45_AplicntDtls.Visible = true;
                                }
                                if (dsnew.Tables[0].Rows[i]["CFOQA_APPROVALID"].ToString() == "47")
                                {
                                    div_47_BLR.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            if (Request.QueryString[0].ToString() == "N")
                            {
                                Response.Redirect("~/User/CFO/CFOUploadEnclosures.aspx?next=N");
                            }
                            else
                            {
                                Response.Redirect("~/User/CFO/CFOBusinessLicenseDetails.aspx?Previous=P");
                            }
                        }
                        BindCountry();
                    }
                }
                //BindDetails(UnitId, Quesstionriids);

            }
        }
        public void BindDetails(int unitid, int qid)
        {
            CFOExciseDetails cFOExciseDetails = bal.GetCFOExciseData(unitid, qid);
            List<CFOExciseBrandDetails> brandDetailsList = cFOExciseDetails.brandgridlist;
            List<CFOExciseLiquorDetails> liquorDetailsList = cFOExciseDetails.liquorgridlist;
            ViewState["BrandDetails"] = brandDetailsList;
            ViewState["LiquorDetails"] = liquorDetailsList;
            // Bind brand details list to gvBrandDetails
            gvBrandDetails.DataSource = brandDetailsList;
            gvBrandDetails.DataBind();

            // Bind liquor details list to GvLiquor
            GvLiquor.DataSource = liquorDetailsList;
            GvLiquor.DataBind();

            // Bind values to RadioButtonList controls
            rblArtical5.SelectedValue = cFOExciseDetails.Artical5Selection;
            rblapplicant.SelectedValue = cFOExciseDetails.ApplicantSelection;
            rblMember.SelectedValue = cFOExciseDetails.MemberSelection;
            rblTax.SelectedValue = cFOExciseDetails.TaxSelection;
            rblsaletax.SelectedValue = cFOExciseDetails.SaleTaxSelection;
            rblprofession.SelectedValue = cFOExciseDetails.ProfessionSelection;
            rblgoverment.SelectedValue = cFOExciseDetails.GovernmentSelection;
            if (cFOExciseDetails.GovernmentSelection == "Y") { Excisedept.Visible = true; txttradeLic.Text = cFOExciseDetails.GovernmentDetails; }
            rblviolation.SelectedValue = cFOExciseDetails.ViolationSelection;
            if (cFOExciseDetails.ViolationSelection == "Y") { txtlaw.Visible = true; txtexciselaw.Text = cFOExciseDetails.ViolationDetails; }
            rblConvicted.SelectedValue = cFOExciseDetails.ConvictedSelection;
            if (cFOExciseDetails.ConvictedSelection == "Y") { convictedlaw.Visible = true; txtDetails.Text = cFOExciseDetails.ConvictedDetails; }
            rblBrand.SelectedValue = cFOExciseDetails.RenewBrand;
            if (rblBrand.SelectedValue == "Y")
            {
                TodateReg.Visible = true; Brands.Visible = true;
                txtFromDate.Text = Convert.ToDateTime(cFOExciseDetails.RegToDate).ToString("yyyy-MM-dd");// Convert.ToDateTime( cFOExciseDetails.RegFromDate).ToString("dd-MM-yyyy");
                txtTodate.Text = Convert.ToDateTime(cFOExciseDetails.RegToDate).ToString("yyyy-MM-dd");
                txtAddress.Text = cFOExciseDetails.FirmAddress;
            }
            if (brandDetailsList.Count > 0)
            {
                gvBrandDetails.Visible = true;
                gvBrandDetails.DataSource = brandDetailsList;
                gvBrandDetails.DataBind();
            }
            if (liquorDetailsList.Count > 0)
            {
                GvLiquor.Visible = true;
                GvLiquor.DataSource = liquorDetailsList;
                GvLiquor.DataBind();
            }
        }
        public void validate()
        {

            //return isValid;
        }
        protected void rblConvicted_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblConvicted.SelectedItem.Text == "Yes")
            {
                convictedlaw.Visible = true;
            }
            else
            {
                convictedlaw.Visible = false;
            }
        }

        protected void rblviolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblviolation.SelectedItem.Text == "Yes")
            {
                txtlaw.Visible = true;
            }
            else
            {
                txtlaw.Visible = false;
            }
        }

        protected void rblgoverment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblgoverment.SelectedItem.Text == "Yes")
            {
                Excisedept.Visible = true;
            }
            else
            {
                Excisedept.Visible = false;
            }
        }

        protected void rblMRPRS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblMRPRS.SelectedItem.Text == "Yes")
            {
                MRPGRID.Visible = true;
            }
            else
            {
                MRPGRID.Visible = false;
            }
        }

        protected void rblBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblBrand.SelectedItem.Text == "Yes")
            {
                Brands.Visible = true;
                TodateReg.Visible = true;
            }
            else
            {
                Brands.Visible = false;
                TodateReg.Visible = false;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
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

        public void SaveData()
        {
            if (Session["UserInfo"] != null)
            {
                ObjUserInfo = (UserInfo)Session["UserInfo"];
            }
           
            
            CFOExciseDetails objcfo = new CFOExciseDetails();
            objcfo.CFOQID = Convert.ToInt32(Convert.ToString(Session["CFOQID"]));
            objcfo.CFOunitid = Convert.ToInt32(Convert.ToString(Session["CFOQID"]));
            objcfo.Artical5Selection = rblArtical5.SelectedValue;
            objcfo.ApplicantSelection = rblapplicant.SelectedValue;
            objcfo.MemberSelection = rblMember.SelectedValue;
            objcfo.TaxSelection = rblTax.SelectedValue;
            objcfo.SaleTaxSelection = rblsaletax.SelectedValue;
            objcfo.ProfessionSelection = rblprofession.SelectedValue;
            objcfo.GovernmentSelection = rblgoverment.SelectedValue;
            objcfo.GovernmentDetails = rblgoverment.SelectedValue == "Y" ? txttradeLic.Text : "";
            objcfo.ViolationSelection = rblviolation.SelectedValue;
            objcfo.ViolationDetails = rblviolation.SelectedValue == "Y" ? txtexciselaw.Text : "";
            objcfo.ConvictedSelection = rblConvicted.SelectedValue;
            objcfo.ConvictedDetails = rblConvicted.SelectedValue == "Y" ? txtDetails.Text : "";
            objcfo.RenewBrand = rblBrand.SelectedValue;
            if (rblBrand.SelectedValue == "Y")
                objcfo.RegFromDate = Convert.ToDateTime(txtFromDate.Text);
            if (rblBrand.SelectedValue == "Y")
                objcfo.RegToDate = Convert.ToDateTime(txtTodate.Text);
            objcfo.FirmAddress = txtAddress.Text;
            objcfo.CreatedIp = getclientIP();
            objcfo.CreatedBy = hdnUserID.Value;
            objcfo.Flag = "S";
            List<CFOExciseBrandDetails> brandDetails = ViewState["BrandDetails"] as List<CFOExciseBrandDetails>;
            List<CFOExciseLiquorDetails> liquorDetails = ViewState["LiquorDetails"] as List<CFOExciseLiquorDetails>;

            string res = bal.InsertCFOExciseData(objcfo, brandDetails, liquorDetails);
            if (res == "Success")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'success', title: 'Success',text: 'Submitted', allowOutsideClick:false})", true);
                return;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'oops..',text: 'Submission failed', allowOutsideClick:false})", true);
                return;
            }
        }
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (rblArtical5.SelectedIndex == -1)
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '1.Please select Are you citizen of India', allowOutsideClick:false})", true);
                    //rblArtical5.Focus();

                    errormsg = errormsg + slno + ". Please Enter 1.Please select Are you citizen of India\\n";
                    slno = slno + 1;
                }

                // Add similar checks for other RadioButtonLists
                if (rblapplicant.SelectedIndex == -1)
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '2.Please select Has the applicant', allowOutsideClick:false})", true);
                    //rblapplicant.Focus();
                    errormsg = errormsg + slno + ". Please Enter 2.Please select Has the applicant\\n";
                    slno = slno + 1;
                }
                if (rblMember.SelectedIndex == -1)
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '3.Please select Whether applicant’s direct family member', allowOutsideClick:false})", true);
                    //rblMember.Focus();
                    errormsg = errormsg + slno + ". Please Enter 2.Please select Has the applicant\\n";
                    slno = slno + 1;
                }
                if (rblTax.SelectedIndex == -1)
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '4.Please select Are you/applicant an Income Tax Payer', allowOutsideClick:false})", true);
                    //rblTax.Focus();
                    errormsg = errormsg + slno + ". Please Enter 4.Please select Are you/applicant an Income Tax Payer\\n";
                    slno = slno + 1;
                }
                if (rblsaletax.SelectedIndex == -1)
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '5.Please select Do you/Applicant pay Sales Tax', allowOutsideClick:false})", true);
                    //rblsaletax.Focus();
                    errormsg = errormsg + slno + ". Please Enter 5.Please select Do you/Applicant pay Sales Tax\\n";
                    slno = slno + 1;
                }
                if (rblprofession.SelectedIndex == -1)
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '6.Please select Do you/Applicant pay Professional Tax', allowOutsideClick:false})", true);
                    //rblprofession.Focus();
                    errormsg = errormsg + slno + ". Please Enter 6.Please select Do you/Applicant pay Professional Tax\\n";
                    slno = slno + 1;
                }
                if (rblgoverment.SelectedIndex == -1) // Assuming this triggers more fields, handle accordingly
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '7.Please select applicant in any way related to a Government', allowOutsideClick:false})", true);
                    //rblgoverment.Focus();
                    errormsg = errormsg + slno + ". Please Enter 7.Please select applicant in any way related to a Government\\n";
                    slno = slno + 1;
                }
                else if (rblgoverment.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txttradeLic.Text) || txttradeLic.Text == "" || txttradeLic.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter 7.Please select applicant in any way related to a Government\\n";
                        slno = slno + 1;

                    }
                }
                if (rblviolation.SelectedIndex == -1)
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '8.Please select applicant been punished or penalized for Violation', allowOutsideClick:false})", true);
                    //rblviolation.Focus();

                    errormsg = errormsg + slno + ". Please Enter 8.Please select applicant been punished or penalized for Violation\\n";
                    slno = slno + 1;
                }
                else if (rblviolation.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtexciselaw.Text) || txtexciselaw.Text == "" || txtexciselaw.Text == null)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Violation Details', allowOutsideClick:false})", true);
                        //txtexciselaw.Focus();
                        errormsg = errormsg + slno + ". Please Enter Please enter Violation Details\\n";
                        slno = slno + 1;
                    }
                }
                if (rblConvicted.SelectedIndex == -1)
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '9.Please select applicant has ever been convicted by Court of Law', allowOutsideClick:false})", true);
                    //rblConvicted.Focus();
                    errormsg = errormsg + slno + ". 9.Please select applicant has ever been convicted by Court of Law\\n";
                    slno = slno + 1;
                }
                else if (rblConvicted.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtDetails.Text) || txtDetails.Text == "" || txtDetails.Text == null)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter convicted by Court of Law Details', allowOutsideClick:false})", true);
                        //txtDetails.Focus();
                        errormsg = errormsg + slno + ". Please enter convicted by Court of Law Details\\n";
                        slno = slno + 1;
                    }
                }




                if (rblBrand.SelectedIndex == -1)
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please select Renewal of BIO Brands', allowOutsideClick:false})", true);
                    //rblBrand.Focus();
                    errormsg = errormsg + slno + ". Please select Renewal of BIO Brands\\n";
                    slno = slno + 1;
                }
                if (rblBrand.SelectedValue == "Y")
                {
                    if (string.IsNullOrWhiteSpace(txtFromDate.Text) || txtFromDate.Text == "" || txtFromDate.Text == null) // Assuming this triggers more fields, handle accordingly
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Registration-From Date', allowOutsideClick:false})", true);
                        //txtFromDate.Focus();
                        errormsg = errormsg + slno + ". Please enter Registration-From Date\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrWhiteSpace(txtTodate.Text) || txtTodate.Text == "" || txtTodate.Text == null) // Assuming this triggers more fields, handle accordingly
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Registration-To Date', allowOutsideClick:false})", true);
                        //txtTodate.Focus();
                        errormsg = errormsg + slno + ". Please enter Registration-To Date\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrWhiteSpace(txtAddress.Text) || txtAddress.Text == "" || txtAddress.Text == null) // Assuming this triggers more fields, handle accordingly
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Name and address of the Firm', allowOutsideClick:false})", true);
                        //txtAddress.Focus();
                        errormsg = errormsg + slno + ". Please enter Name and address of the Firm\\n";
                        slno = slno + 1;
                    }
                }
                if (gvBrandDetails.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please enter Brand Details \\n";
                    slno = slno + 1;
                }
                if (GvLiquor.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please enter Brand Details \\n";
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
            // Check TextBoxes for required values
            if (string.IsNullOrWhiteSpace(txtName.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Name of Brand', allowOutsideClick:false})", true);
                txtName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtStrength.Text)) // Assuming strength should be a number
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Strength(Alcohol Content)', allowOutsideClick:false})", true);
                txtStrength.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSize.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Size', allowOutsideClick:false})", true);
                txtSize.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBottle.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter No. of bottles (in one case)', allowOutsideClick:false})", true);
                txtBottle.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMRP.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter MRP', allowOutsideClick:false})", true);
                txtMRP.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBulkLiter.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Bulk liter', allowOutsideClick:false})", true);
                txtBulkLiter.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLandonProof.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter London Proof liter', allowOutsideClick:false})", true);
                txtLandonProof.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBottlePlant.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Name & address of Plant', allowOutsideClick:false})", true);
                txtBottlePlant.Focus();
                return;
            }
            List<CFOExciseBrandDetails> brandDetails;
            if (ViewState["BrandDetails"] != null)
            {
                brandDetails = ViewState["BrandDetails"] as List<CFOExciseBrandDetails>;
            }
            else
            {
                brandDetails = new List<CFOExciseBrandDetails>();
            }
            CFOExciseBrandDetails newDetail = new CFOExciseBrandDetails();

            newDetail.NameOfBrand = txtName.Text.Trim();
            newDetail.Strength = txtStrength.Text;
            newDetail.Size = txtSize.Text;
            newDetail.NumberOfBottles = txtBottle.Text;
            newDetail.MRPRs = txtMRP.Text;
            newDetail.BulkLiter = txtBulkLiter.Text;
            newDetail.LandOnProof = txtLandonProof.Text;
            newDetail.BottlePlant = txtBottlePlant.Text;
            newDetail.CreatedBy = hdnUserID.Value;
            newDetail.CreatedDate = DateTime.Now;
            newDetail.CreatedIp = Request.UserHostAddress;
            newDetail.UpdatedBy = hdnUserID.Value;
            newDetail.UpdatedDate = DateTime.Now;
            newDetail.UpdatedIp = Request.UserHostAddress;
            newDetail.Flag = "A";


            brandDetails.Add(newDetail);
            gvBrandDetails.Visible = true;
            ViewState["BrandDetails"] = brandDetails;
            BindBrandGrid();

            // Clear the textboxes after adding the details
            txtName.Text = "";
            txtStrength.Text = "";
            txtSize.Text = "";
            txtBottle.Text = "";
            txtMRP.Text = "";
            txtBulkLiter.Text = "";
            txtLandonProof.Text = "";
            txtBottlePlant.Text = "";
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedIndex == 0) // Assuming index 0 is "--Select--", so anything else is invalid
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please select The Country of Origin of the Liquor', allowOutsideClick:false})", true);
                ddlCountry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(rblMRPRS.SelectedValue)) // Assuming this triggers more fields, handle accordingly
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please select MRP', allowOutsideClick:false})", true);
                rblMRPRS.Focus();
                return;
            }
            else if (rblMRPRS.SelectedValue == "Y")
            {
                if (string.IsNullOrWhiteSpace(txtBrandName.Text.Trim())) // Assuming this triggers more fields, handle accordingly
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Name of Brand', allowOutsideClick:false})", true);
                    txtBrandName.Focus();
                    return;
                }
            }

            List<CFOExciseLiquorDetails> liquorDetails;
            if (ViewState["LiquorDetails"] != null)
                liquorDetails = ViewState["LiquorDetails"] as List<CFOExciseLiquorDetails>;
            else
                liquorDetails = new List<CFOExciseLiquorDetails>();

            CFOExciseLiquorDetails newDetail = new CFOExciseLiquorDetails
            {
                CountryID = ddlCountry.SelectedValue,
                CountryName = ddlCountry.SelectedItem.Text,
                MRPSSelection = rblMRPRS.SelectedValue,
                BrandName = txtBrandName.Text.Trim(),
                CreatedBy = hdnUserID.Value,
                CreatedDate = DateTime.Now,
                CreatedIp = Request.UserHostAddress,
                UpdatedBy = hdnUserID.Value,
                UpdatedDate = DateTime.Now,
                UpdatedIp = Request.UserHostAddress,
                Flag = "A"
            };

            liquorDetails.Add(newDetail);
            ViewState["LiquorDetails"] = liquorDetails;
            GvLiquor.Visible = true;
            BindLiquorGrid();

            // Clear the textboxes after adding the details
            ddlCountry.SelectedIndex = 0;
            rblMRPRS.ClearSelection();
            txtBrandName.Text = "";
            MRPGRID.Visible = false;
        }

        protected void gvBrandDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            List<CFOExciseBrandDetails> brandDetails = ViewState["BrandDetails"] as List<CFOExciseBrandDetails>;
            brandDetails.RemoveAt(e.RowIndex);
            ViewState["BrandDetails"] = brandDetails;
            BindBrandGrid();

        }
        protected void GvLiquor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<CFOExciseLiquorDetails> liquorDetails = ViewState["LiquorDetails"] as List<CFOExciseLiquorDetails>;
            liquorDetails.RemoveAt(e.RowIndex);
            ViewState["LiquorDetails"] = liquorDetails;
            BindLiquorGrid();
        }
        public void BindCountry()
        {
            try
            {
                ddlCountry.Items.Clear();

                List<MasterCountry> objCountryModel = new List<MasterCountry>();

                objCountryModel = mstrBAL.GetCountries();
                if (objCountryModel != null)
                {
                    ddlCountry.DataSource = objCountryModel;
                    ddlCountry.DataValueField = "CountryId";
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataBind();
                }
                else
                {
                    ddlCountry.DataSource = null;
                    ddlCountry.DataBind();
                }
                ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BindBrandGrid()
        {
            List<CFOExciseBrandDetails> brandDetails = ViewState["BrandDetails"] as List<CFOExciseBrandDetails>;
            gvBrandDetails.DataSource = brandDetails;
            gvBrandDetails.DataBind();
        }
        public void BindLiquorGrid()
        {
            List<CFOExciseLiquorDetails> liquorDetails = ViewState["LiquorDetails"] as List<CFOExciseLiquorDetails>;
            GvLiquor.DataSource = liquorDetails;
            GvLiquor.DataBind();
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFO/CFOBusinessLicenseDetails.aspx?Previous=P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
          //  Response.Redirect("~/User/CFO/CFOBusinessLicenseDetails.aspx?Previous=P");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (Errormsg == "")
                    Response.Redirect("~/User/CFO/CFOUploadEnclosures.aspx?next=N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
          //  Response.Redirect("~/User/CFO/CFOUploadEnclosures.aspx?next=N");
        }
    }
}