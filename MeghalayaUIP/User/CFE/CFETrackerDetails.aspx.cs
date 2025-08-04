using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFETrackerDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
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

                    if (!IsPostBack)
                    {
                        string UnitID = Request.QueryString[0].ToString();
                        string Deptid = Request.QueryString[1].ToString();
                        string APPROVALID = Request.QueryString[2].ToString();
                        string Status = Request.QueryString[3].ToString();
                        if (UnitID != "" && Deptid != "" && APPROVALID != "" && Status != "")
                        {
                            BindData(UnitID, Deptid, APPROVALID, Status);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindData(string Unitid, string Deptid, string APPROVALID, string Status)
        {
            try
            {
                DataSet ds = new DataSet();
              //  string Dept = Request.QueryString[0].ToString();
                ds = objcfebal.GetCFETrackerDetails(Unitid, Deptid, APPROVALID, Status);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (Status =="1")
                    {
                     
                    }
                    else if (Status == "2")
                    {
                        lblDept.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblQueryDate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblQuery.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblQueryResponseDate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblDaysTaken.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblQueryResponse.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);


                    }
                    else if (Status == "3")
                    {

                    }
                    else if (Status == "4")
                    {
                        lblDeptNameReject.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblRejDate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblRejRemark.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblRejAppealRemark.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblRejAppealDate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        lblRejQueryReason.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
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