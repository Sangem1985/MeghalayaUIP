using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.PreReg
{
    public partial class IndustryRegistrationViewDetails : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL preBAL = new PreRegBAL();
        string userid;
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
                        userid = ObjUserInfo.Userid;
                    }

                    if (!IsPostBack)
                    {
                        if (Request.QueryString.Count > 0)
                        {
                            BindaApplicatinDetails(Request.QueryString[0], ObjUserInfo.Userid);
                        }

                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
            }

        }

        public void BindaApplicatinDetails(string UnitID, string InvesterID)
        {
            try
            {

                if (UnitID != null && InvesterID != null)
                {

                    DataSet ds = new DataSet();
                    ds = preBAL.GetIndRegUserApplDetails(UnitID, InvesterID);


                    DataRow row = ds.Tables[0].Rows[0];
                    lblregdate.Text = Convert.ToString(row["Udyamno"]);
                    lblUdyam.Text = Convert.ToString(row["GSTNNO"]);
                    lblGSTIN.Text = Convert.ToString(row["Udyamno"]);
                    lblName.Text = Convert.ToString(row["REP_NAME"]);
                    lblMobile.Text = Convert.ToString(row["REP_MOBILE"]);
                    lblEmail.Text = Convert.ToString(row["REP_EMAIL"]);
                    lblLocality.Text = Convert.ToString(row["REP_LOCALITY"]);
                    lblDistict.Text = Convert.ToString(row["REP_DISTRICT"]);
                    lblMandal.Text = Convert.ToString(row["REP_MANDAL"]);
                    lblVillage.Text = Convert.ToString(row["REP_VILLAGE"]);
                    lblPincode.Text = Convert.ToString(row["REP_PINCODE"]);
                    lblPincode.Text = Convert.ToString(row["REP_PINCODE"]);
                    lbldrno.Text = Convert.ToString(row["UNIT_DOORNO"]);
                    lblPro_loc.Text = Convert.ToString(row["UNIT_LOCALITY"]);
                    lblpro_dis.Text = Convert.ToString(row["UNIT_DISTRICT"]);
                    lblPro_Man.Text = Convert.ToString(row["UNIT_MANDAL"]);
                    lblPro_vill.Text = Convert.ToString(row["UNIT_VILLAGE"]);
                    lblPro_Pin.Text = Convert.ToString(row["UNIT_PICODE"]);
                    lblNatureofAct.Text = Convert.ToString(row["PROJECT_NOA"]);
                    lblMainmanu.Text = Convert.ToString(row["PROJECT_MMSA"]);
                    lblpro_manu.Text = Convert.ToString(row["PROJECT_PMSP"]);
                    lblDateofcomm.Text = Convert.ToString(row["PROJECT_DCP"]);
                    lblexisting.Text = Convert.ToString(row["PROJECT_PROD_NO"]);
                    lblannual.Text = Convert.ToString(row["PROJECT_AC"]);
                    lblestimatedcost.Text = Convert.ToString(row["PROJECT_EPC"]);
                    lblland.Text = Convert.ToString(row["PROJECT_LAND"]);
                    lblcivil.Text = Convert.ToString(row["PROJECT_CIVIL_CONSTRCTION"]);
                    lblplant.Text = Convert.ToString(row["PROJECT_PM"]);
                    lblmain_raw.Text = Convert.ToString(row["PROJECT_MMPP"]);
                    lblbuilding.Text = Convert.ToString(row["PROJECT_BUILDING"]);
                    lbldet_hazar.Text = Convert.ToString(row["PROJECT_hazardous"]);
                    lblinvestment.Text = Convert.ToString(row["PROJECT_IFC"]);
                    lbldurable.Text = Convert.ToString(row["PROJECT_DFA"]);
                    lblunitofmeasure.Text = Convert.ToString(row["PROJECT_UM"]);
                    lblbuildingshed.Text = Convert.ToString(row["PROJECT_BS"]);
                    lblwaterinr.Text = Convert.ToString(row["PROJECT_WATER"]);
                    lblelectricity.Text = Convert.ToString(row["PROJECT_ELECTRIC"]);
                    lblworking.Text = Convert.ToString(row["PROJECT_WC"]);
                    lblcapital.Text = Convert.ToString(row["FRD_CS"]);
                    lblpromoter.Text = Convert.ToString(row["FRD_PE"]);
                    lblloan.Text = Convert.ToString(row["FRD_LOAN"]);
                    lblDateofcomm.Text = Convert.ToDateTime(lblDateofcomm.Text).ToString("dd-MM-yyyy");

                    grdRevenueProj.DataSource = ds.Tables[1];
                    grdRevenueProj.DataBind();

                    grdDirectors.DataSource = ds.Tables[2];
                    grdDirectors.DataBind();

                    grdApplStatus.DataSource = ds.Tables[3];
                    grdApplStatus.DataBind();

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        grdQueries.DataSource = ds.Tables[4];
                        grdQueries.DataBind();
                    }
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        QueryResondpanel.Visible = true;
                        grdQueryRaised.DataSource = ds.Tables[5];
                        grdQueryRaised.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void btnRespond_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                TextBox txtReply = (TextBox)row.FindControl("txtResponse");
                if (string.IsNullOrEmpty(txtReply.Text) || txtReply.Text == "" || txtReply.Text == null)
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Enter Query Response";
                    return;
                }
                else
                {
                    Label UnitID = (Label)row.FindControl("lblUNITID");
                    Label DeptID = (Label)row.FindControl("lblDeptID");
                    Label QID = (Label)row.FindControl("lblDQID");
                    IndustryDetails ID = new IndustryDetails();
                    ID.UserID = userid;
                    ID.UnitID = UnitID.Text;
                    ID.Deptid = DeptID.Text;
                    ID.QueryID = QID.Text;
                    ID.QueryResponse = txtReply.Text;
                    ID.IPAddress = getclientIP();

                    string result = preBAL.UpdateIndRegApplQueryRespose(ID);
                    if(result !=""||result!=null) 
                    {
                        lblmsg.Text = "Query Response Submitted Sussfully";
                        success.Visible=true;
                        BindaApplicatinDetails(UnitID.Text, userid);

                    }
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
    }
}