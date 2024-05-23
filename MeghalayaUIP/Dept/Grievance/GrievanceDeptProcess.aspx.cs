using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Grievance
{
    public partial class GrievanceDeptProcess : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        MGCommonBAL objcomBal = new MGCommonBAL();
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

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindData(ObjUserInfo.Deptid);

                    }
                }
                else
                {
                    Response.Redirect("~/DeptLogin.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                throw ex;
            }
        }
        public void BindData(string DeptID)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objcomBal.GetDepGrievanceList(DeptID, Request.QueryString[0]);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblindustry.Text= Convert.ToString(ds.Tables[0].Rows[0]["UNITNAME"]);
                    lblEmail.Text= Convert.ToString(ds.Tables[0].Rows[0]["EMAIL"]);
                    lblUID.Text= Convert.ToString(ds.Tables[0].Rows[0]["UID_NO"]);
                    lblName.Text= Convert.ToString(ds.Tables[0].Rows[0]["APPLICANTNAME"]);
                    lblNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["MOBILE"]);
                    lblSubject.Text= Convert.ToString(ds.Tables[0].Rows[0]["SUBJECT"]);
                    lblDate.Text= Convert.ToString(ds.Tables[0].Rows[0]["REGDATE"]);
                    lblDistric.Text= Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
                    lblDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["DESCRIPTION"]);
                    hplAttach.NavigateUrl = Convert.ToString(ds.Tables[0].Rows[0]["GRIEVANCE_FILEPATH"]);
                    hplAttach.Text = Convert.ToString(ds.Tables[0].Rows[0]["GRIEVNACE_FILENAME"]);

                    //  gvGrievanceDtls.DataSource = ds.Tables[0];
                    // gvGrievanceDtls.DataBind();
                }
                else
                {
                   // gvGrievanceDtls.DataSource = null;
                    //gvGrievanceDtls.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        } 
    }
}