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
    public partial class SRVCLabourWorkmen6 : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string UnitID, Questionnaire, ErrorMsg = "", result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStates();
                BindDistricts();
            }
        }

        protected void rblDateofBirth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblDateofBirth.SelectedValue == "D")
                {
                    DateBirth.Visible = true;
                    Age.Visible = false;
                }
                else
                {
                    Age.Visible = true;
                    DateBirth.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblDistricCouncil_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (rblDistricCouncil.SelectedValue == "Y")
                {
                    Licdetails.Visible = true;
                    Validdate.Visible = true;
                    Tribal.Visible = false;
                    Reasons.Visible = false;
                }
                else
                {
                    Tribal.Visible = true;
                    Reasons.Visible = true;
                    Licdetails.Visible = false;
                    Validdate.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblContractor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblContractor.SelectedValue == "Y")
                {
                    Details.Visible = true;
                }
                else { Details.Visible = false; }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblLicSuspending_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLicSuspending.SelectedValue == "Y")
                {
                    divOrder.Visible = true;
                }
                else { divOrder.Visible = false; }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblfiveyears_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLicSuspending.SelectedValue == "Y")
                {
                    divEstablishDetails.Visible = true;
                }
                else { divEstablishDetails.Visible = false; }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindStates()
        {
            try
            {
                ddlSates.Items.Clear();
                ddlStates.Items.Clear();


                List<MasterStates> objStatesModel = new List<MasterStates>();

                objStatesModel = mstrBAL.GetStates();
                if (objStatesModel != null)
                {
                    ddlSates.DataSource = objStatesModel;
                    ddlSates.DataValueField = "StateId";
                    ddlSates.DataTextField = "StateName";
                    ddlSates.DataBind();

                    ddlStates.DataSource = objStatesModel;
                    ddlStates.DataValueField = "StateId";
                    ddlStates.DataTextField = "StateName";
                    ddlStates.DataBind();
                }
                else
                {
                    ddlSates.DataSource = null;
                    ddlSates.DataBind();

                    ddlStates.DataSource = null;
                    ddlStates.DataBind();
                }
                AddSelect(ddlSates);
                AddSelect(ddlStates);

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
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                ddldist.Items.Clear();
                ddlmand.Items.Clear();
                ddlvilla.Items.Clear();

                ddlDistrictes.Items.Clear();


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

                    ddldist.DataSource = objDistrictModel;
                    ddldist.DataValueField = "DistrictId";
                    ddldist.DataTextField = "DistrictName";
                    ddldist.DataBind();

                    ddlDistrictes.DataSource = objDistrictModel;
                    ddlDistrictes.DataValueField = "DistrictId";
                    ddlDistrictes.DataTextField = "DistrictName";
                    ddlDistrictes.DataBind();

                }
                else
                {
                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();

                    ddldist.DataSource = null;
                    ddldist.DataBind();

                    ddlDistrictes.DataSource = null;
                    ddlDistrictes.DataBind();

                }
                AddSelect(ddlDistric);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

                AddSelect(ddldist);
                AddSelect(ddlmand);
                AddSelect(ddlvilla);

                AddSelect(ddlDistrictes);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlDistric_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                if (ddlDistric.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistric.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillage.ClearSelection();
                if (ddlMandal.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlVillage, ddlMandal.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlmand.ClearSelection();
                ddlvilla.ClearSelection();
                if (ddldist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlmand, ddldist.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlmand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlvilla.ClearSelection();
                if (ddlmand.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlvilla, ddlmand.SelectedValue);
                }
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

                    //DataTable dt = DirectorPartner;

                    //if (dt.Rows.Count > 0)
                    //{
                    //    objSrvcbal.SaveMigrantDataToDB(dt);

                    //    ViewState["DirectorPartner"] = null;
                    //    GVMigrant.DataSource = null;
                    //    GVMigrant.DataBind();
                    //    GVMigrant.Visible = false;
                    //}

                    if (DirectorPartner.Rows.Count > 0)
                    {
                        string ip = getclientIP();
                        int createdBy = 1001; //Convert.ToInt32(Session["UserID"]);
                        int srvcqdid = 101; //Convert.ToInt32(Session["SRVCQDID"]);

                        string result = objSrvcbal.SaveDirectorListToDB(DirectorPartner, srvcqdid, createdBy, ip);

                        if (result == "SUCCESS")
                        {
                            ViewState["DirectorPartner"] = null;
                            GVMigrant.DataSource = null;
                            GVMigrant.DataBind();
                        }
                        else
                        {
                            lblmsg0.Text = "Failed to save. " + result;
                            lblmsg0.ForeColor = System.Drawing.Color.Red;
                            Failure.Visible = true;
                        }
                    }


                    /*  Labourworkme6 ObjCDWMDet = new Labourworkme6();

                      ObjCDWMDet.Questionnariid = Convert.ToString(Session["SRVCQID"]);
                      ObjCDWMDet.Createdby = hdnUserID.Value;
                      ObjCDWMDet.IPAddress = getclientIP();

                      ObjCDWMDet.DateofBirth = rblDateofBirth.SelectedValue;
                      ObjCDWMDet.Date = txtDateBirth.Text;
                      ObjCDWMDet.Age = txtAges.Text;
                      ObjCDWMDet.State = ddlSates.SelectedValue;
                      ObjCDWMDet.Districtid = ddlDistric.SelectedValue;
                      ObjCDWMDet.Mandaleid = ddlMandal.SelectedValue;
                      ObjCDWMDet.Villageid = ddlVillage.SelectedValue;
                      ObjCDWMDet.District = txtDistricted.Text;
                      ObjCDWMDet.Mandal = txtMandaled.Text;
                      ObjCDWMDet.Village = txtVillagede.Text;
                      ObjCDWMDet.Locality = txtLocal.Text;
                      ObjCDWMDet.Landmark = txtNearMark.Text;
                      ObjCDWMDet.Pincode = txtPin.Text;
                      ObjCDWMDet.Artical5 = rblArtical5.SelectedValue;
                      ObjCDWMDet.Criminalcase = rblMakeApplicationCrime.SelectedValue;
                      ObjCDWMDet.ConvictedCrimecase = rblCriminalCase.SelectedValue;
                      ObjCDWMDet.DistrictCouncil = rblDistricCouncil.SelectedValue;
                      ObjCDWMDet.License = ddlLic.Text;
                      ObjCDWMDet.Licenseno = txtLicNo.Text;
                      ObjCDWMDet.DateofLicense = txtDateLic.Text;
                      ObjCDWMDet.ValidDate = txtValidDate.Text;
                      ObjCDWMDet.Trible = rblTribal.SelectedValue;
                      ObjCDWMDet.Reason = txtReasons.Text;
                      ObjCDWMDet.NameEst = txtNameofEstablish.Text;
                      ObjCDWMDet.TypeofBusiness = txtbusiness.Text;
                      ObjCDWMDet.RegNoEst = txtRegNoEst.Text;
                      ObjCDWMDet.DateofReg = txtDateRegCert.Text;
                      ObjCDWMDet.DistrictEst = ddldist.SelectedValue;
                      ObjCDWMDet.MandalEst = ddlmand.SelectedValue;
                      ObjCDWMDet.VillageEst = ddlvilla.SelectedValue;
                      ObjCDWMDet.LocalityEst = txtLocality.Text;
                      ObjCDWMDet.LandMarkEst = txtLandmark.Text;
                      ObjCDWMDet.PincodeEst = txtPincode.Text;
                      ObjCDWMDet.TitleEmpDet = ddlTitles.SelectedValue;
                      ObjCDWMDet.NameEmpPrincipal = txtNameEmp.Text;
                      ObjCDWMDet.NameLocationNature = txtNameMigrantEmp.Text;
                      ObjCDWMDet.DurationWorkDay = txtContractorMin.Text;
                      ObjCDWMDet.CommencingDate = txtCommencingDate.Text;
                      ObjCDWMDet.EndingDate = txtEnding.Text;
                      ObjCDWMDet.NameAgent = txtSiteManager.Text;
                      ObjCDWMDet.MaxMigrantWorkmenNo = txtMaxEstEmp.Text;
                      ObjCDWMDet.MigrantState = ddlStates.SelectedValue;
                      ObjCDWMDet.MigrantDistrict = ddlDistrictes.SelectedValue;
                      ObjCDWMDet.MigrantNameAddress = txtMigrantWorkmen.Text;
                      ObjCDWMDet.Convicted5Year = rblContractor.SelectedValue;
                      ObjCDWMDet.Details = txtDetail.Text;
                      ObjCDWMDet.suspendinglicense = rblLicSuspending.Text;
                      ObjCDWMDet.OrderNo = txtOrderNo.Text;
                      ObjCDWMDet.OrderDate = txtOrderDate.Text;
                      ObjCDWMDet.ContractEst5Year = rblfiveyears.SelectedValue;
                      ObjCDWMDet.Establishment = txtEstablishDetails.Text;
                      ObjCDWMDet.PrincipalEmp = txtEmpDetails.Text;
                      ObjCDWMDet.NatureWork = txtNature.Text;
                      ObjCDWMDet.PrincipalEmployer = rblEmpClosed.Text;


                      result = objSrvcbal.InsertLabourWorkmenDetails(ObjCDWMDet);*/

                    if (result != "")
                    {
                        string message = "alert('" + "Labour Details Saved Successfully" + "')";
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

                /*  if (rblDateofBirth.SelectedIndex == -1 || rblDateofBirth.SelectedItem.Text == "--Select--")
                  {
                      errormsg = errormsg + slno + ". Please Select Date of Birth or Age..! \\n";
                      slno = slno + 1;
                  }
                  if (string.IsNullOrEmpty(txtDateBirth.Text) || txtDateBirth.Text.Trim() == "")
                  {
                      errormsg += slno + ". Please enter Date of Birth...! \\n";
                      slno++;
                  }
                  if (string.IsNullOrEmpty(txtAges.Text) || txtAges.Text.Trim() == "")
                  {
                      errormsg += slno + ". Please enter Age...! \\n";
                      slno++;
                  }

                  if (ddlSates.SelectedValue == "0" || ddlSates.SelectedItem.Text == "--Select--")
                  {
                      errormsg = errormsg + slno + ". Please Select State \\n";
                      slno = slno + 1;
                  }
                  if (ddlSates.SelectedValue == "23")
                  {
                      if (ddlDistric.SelectedIndex == -1 || ddlDistric.SelectedItem.Text == "--Select--")
                      {
                          errormsg = errormsg + slno + ". Please Select District \\n";
                          slno = slno + 1;
                      }
                      if (ddlMandal.SelectedIndex == -1 || ddlMandal.SelectedItem.Text == "--Select--")
                      {
                          errormsg = errormsg + slno + ". Please Select Mandal \\n";
                          slno = slno + 1;
                      }
                      if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                      {
                          errormsg = errormsg + slno + ". Please Select Village \\n";
                          slno = slno + 1;
                      }
                  }
                  else if (ddlSates.SelectedValue != "23" && ddlSates.SelectedValue != "0")
                  {
                      if (string.IsNullOrEmpty(txtDistricted.Text) || txtDistricted.Text == "" || txtDistricted.Text == null)
                      {
                          errormsg = errormsg + slno + ". Please Enter District...! \\n";
                          slno = slno + 1;
                      }
                      if (string.IsNullOrEmpty(txtMandaled.Text) || txtMandaled.Text == "" || txtMandaled.Text == null)
                      {
                          errormsg = errormsg + slno + ". Please Enter Mandal...! \\n";
                          slno = slno + 1;
                      }
                      if (string.IsNullOrEmpty(txtVillagede.Text) || txtVillagede.Text == "" || txtVillagede.Text == null)
                      {
                          errormsg = errormsg + slno + ". Please Enter Village...! \\n";
                          slno = slno + 1;
                      }
                  }
                  if (string.IsNullOrEmpty(txtLocal.Text) || txtLocal.Text.Trim() == "" || txtLocal.Text == null)
                  {
                      errormsg += slno + ". Please enter Locality...! \\n";
                      slno++;
                  }
                  if (string.IsNullOrEmpty(txtNearMark.Text) || txtNearMark.Text.Trim() == "" || txtNearMark.Text == null)
                  {
                      errormsg += slno + ". Please enter Land Mark...! \\n";
                      slno++;
                  }
                  if (string.IsNullOrEmpty(txtPin.Text) || txtPin.Text.Trim() == "" || txtPin.Text == null)
                  {
                      errormsg += slno + ". Please enter Pincode...! \\n";
                      slno++;
                  }
                */


                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlSates_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSates.SelectedValue != "23")
                {
                    divdistrict.Visible = true;
                    divMandal.Visible = true;
                    divVillage.Visible = true;

                    divdistrict1.Visible = false;
                    divMandal1.Visible = false;
                    divVillage1.Visible = false;

                    ddlDistric.ClearSelection();
                    ddlMandal.ClearSelection();
                    ddlVillage.ClearSelection();
                }
                else if (ddlSates.SelectedValue == "23")
                {
                    divdistrict1.Visible = true;
                    divMandal1.Visible = true;
                    divVillage1.Visible = true;

                    divdistrict.Visible = false;
                    divMandal.Visible = false;
                    divVillage.Visible = false;
                    txtDistricted.Text = "";
                    txtMandaled.Text = "";
                    txtVillagede.Text = "";

                }
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
        protected void BindMandal(DropDownList ddlmndl, string DistrictID)
        {
            try
            {
                List<MasterMandals> objMandal = mstrBAL.GetMandals(DistrictID);

                if (objMandal != null && objMandal.Count > 0)
                {
                    ddlmndl.DataSource = objMandal;
                    ddlmndl.DataValueField = "MandalId";
                    ddlmndl.DataTextField = "MandalName";
                    ddlmndl.DataBind();
                }
                else
                {

                    ddlmndl.DataSource = null;
                    ddlmndl.DataBind();
                }

                AddSelect(ddlmndl);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void BindVillages(DropDownList ddlvlg, string MandalID)
        {
            try
            {
                List<MasterVillages> objVillage = new List<MasterVillages>();
                string strmode = string.Empty;

                objVillage = mstrBAL.GetVillages(MandalID);

                if (objVillage != null)
                {
                    ddlvlg.DataSource = objVillage;
                    ddlvlg.DataValueField = "VillageId";
                    ddlvlg.DataTextField = "VillageName";
                    ddlvlg.DataBind();
                }
                else
                {
                    ddlvlg.DataSource = null;
                    ddlvlg.DataBind();
                }
                AddSelect(ddlvlg);
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

        protected void GVMigrant_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = DirectorPartner;
            dt.Rows.RemoveAt(e.RowIndex);
            DirectorPartner = dt;

            GVMigrant.DataSource = dt;
            GVMigrant.DataBind();
        }

        private DataTable DirectorPartner
        {
            get
            {
                if (ViewState["DirectorPartner"] == null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Title");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Address");
                    ViewState["DirectorPartner"] = dt;
                }
                return (DataTable)ViewState["DirectorPartner"];
            }
            set { ViewState["DirectorPartner"] = value; }
        }

        protected void btnMigrant_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DirectorPartner;

                dt.Rows.Add(
                    ddlTitle.SelectedItem.Text,
                    txtName.Text.Trim(),
                    txtAddress.Text.Trim()
                );

                DirectorPartner = dt;

                GVMigrant.DataSource = dt;
                GVMigrant.DataBind();
                GVMigrant.Visible = true;

                ddlTitle.ClearSelection();
                txtName.Text = "";
                txtAddress.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string ConvertDataTableToXML(DataTable dt)
        {
            using (StringWriter sw = new StringWriter())
            {
                dt.WriteXml(sw, XmlWriteMode.WriteSchema);
                return sw.ToString();
            }
        }



    }
}