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
    public partial class SRVCTourOperatorDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string ErrorMsg = "", result = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objSrvcbal.GetSRVCTourismDetails(Convert.ToString(Session["SRVCQID"]), hdnUserID.Value);

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtNature.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtYearReg.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtNameProprietor.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtDetIntrest.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);

                        txtSqft.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtLocationArea.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtReception.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtAccessibility.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtNameBankers.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtAuditors.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtIndicate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txttourist.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtClientele.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtpromote.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtnoConferences.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GVParticulars.DataSource = ds.Tables[1];
                        GVParticulars.DataBind();
                        GVParticulars.Visible = true;
                        ViewState["ParticularsDetails"] = ds.Tables[1];
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
                ErrorMsg = stepValidations();
                if (ErrorMsg == "")
                {
                    SRVCTourism ObjTourismDet = new SRVCTourism();


                    DataTable dt = ParticularsDetails;
                    DataSet ds = new DataSet("Root");
                    ds.Tables.Add(dt.Copy());

                    string xmlData;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds.WriteXml(sw);
                        xmlData = sw.ToString();
                    }


                    {
                        ObjTourismDet.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        ObjTourismDet.Createdby = "1001"; //hdnUserID.Value;
                        ObjTourismDet.IPAddress = getclientIP();
                        ObjTourismDet.XMLData = GetParticularsXML();
                    };
                    result = objSrvcbal.InsertTourismParticularsDet(ObjTourismDet);




                    ObjTourismDet.Questionnariid = Convert.ToString(Session["SRVCQID"]);
                    ObjTourismDet.Createdby = hdnUserID.Value;
                    ObjTourismDet.IPAddress = getclientIP();

                    ObjTourismDet.NatureOrganization = txtNature.Text;
                    ObjTourismDet.YearRegComm = txtYearReg.Text;
                    ObjTourismDet.NameDirector = txtNameProprietor.Text;
                    ObjTourismDet.Interestsindicated = txtDetIntrest.Text;
                    ObjTourismDet.SpaceSqft = txtSqft.Text;
                    ObjTourismDet.LocationArea = txtLocationArea.Text;
                    ObjTourismDet.ReceptionArea = txtReception.Text;
                    ObjTourismDet.AccessibilityToilet = txtAccessibility.Text;
                    ObjTourismDet.NameBankers = txtNameBankers.Text;
                    ObjTourismDet.NameAuditors = txtAuditors.Text;
                    ObjTourismDet.indicatemembership = txtIndicate.Text;
                    ObjTourismDet.touristtraffic = txttourist.Text;
                    ObjTourismDet.Clientele = txtClientele.Text;
                    ObjTourismDet.domestictouristtraffic = txtpromote.Text;
                    ObjTourismDet.Numberconferences = txtnoConferences.Text;


                    result = objSrvcbal.InsertTourismDetails(ObjTourismDet);

                    if (result != "")
                    {
                        string message = "alert('" + "Tourism Details Saved Successfully" + "')";
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
        public string stepValidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtNature.Text) || txtNature.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Nature of the Organization...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtYearReg.Text) || txtYearReg.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Year Of Registration/Commencement of Business...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtNameProprietor.Text) || txtNameProprietor.Text.Trim() == "" || txtNameProprietor.Text == null)
                {
                    errormsg += slno + ". Please enter Name of Proprietor/Director/Partner...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtDetIntrest.Text) || txtDetIntrest.Text.Trim() == "" || txtDetIntrest.Text == null)
                {
                    errormsg += slno + ". Please enter Details of their Interests, in other business...! \\n";
                    slno++;
                }



                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnParticulars_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNameEmp.Text) || string.IsNullOrWhiteSpace(txtDesignationEmp.Text) ||
                    string.IsNullOrWhiteSpace(txtQualificationsEmp.Text) || string.IsNullOrWhiteSpace(txtExperienceEmp.Text) || string.IsNullOrWhiteSpace(txtMonthlyEmp.Text) ||
                    string.IsNullOrWhiteSpace(txtLengthEmp.Text))
                {
                    lblmsg0.Text = "Please enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = ParticularsDetails;

                DataRow dr = dt.NewRow();
                dr[""] = txtNameEmp.Text.Trim();
                dr[""] = txtDesignationEmp.Text.Trim();
                dr[""] = txtQualificationsEmp.Text.Trim();
                dr[""] = txtExperienceEmp.Text.Trim();
                dr[""] = txtMonthlyEmp.Text.Trim();
                dr[""] = txtLengthEmp.Text.Trim();
                dt.Rows.Add(dr);

                ParticularsDetails = dt;

                GVParticulars.Visible = true;
                GVParticulars.DataSource = dt;
                GVParticulars.DataBind();

                txtNameEmp.Text = "";
                txtDesignationEmp.Text = "";
                txtQualificationsEmp.Text = "";
                txtExperienceEmp.Text = "";
                txtMonthlyEmp.Text = "";
                txtLengthEmp.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private DataTable ParticularsDetails
        {
            get
            {
                if (ViewState["ParticularsDetails"] == null)
                {
                    DataTable dt = new DataTable("Table1");
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    ViewState["ParticularsDetails"] = dt;
                }
                return (DataTable)ViewState["ParticularsDetails"];
            }
            set
            {
                ViewState["ParticularsDetails"] = value;
            }
        }
        protected void GVParticulars_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GVParticulars.Rows[e.RowIndex].Cells[1].Text.Trim();

                SRVCTourism objTourism = new SRVCTourism();
                {
                    objTourism.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objTourism.NameEmp = name;
                };
                string result = objSrvcbal.DeleteParticulars(objTourism);

                DataTable dt = ParticularsDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                ParticularsDetails = dt;

                GVParticulars.DataSource = dt;
                GVParticulars.DataBind();
                GVParticulars.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        private string GetParticularsXML()
        {
            DataTable dt = ParticularsDetails;
            DataSet ds = new DataSet("Root");
            ds.Tables.Add(dt.Copy());

            using (StringWriter sw = new StringWriter())
            {
                ds.WriteXml(sw);
                return sw.ToString();
            }
        }
    }
}