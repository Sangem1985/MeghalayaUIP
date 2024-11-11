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

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegDITSitePrintPage : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        MGCommonBAL objcomBal = new MGCommonBAL();
        PreRegBAL PreBAL = new PreRegBAL();
        int reportId;
        string createdDate, loc, unitName;
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
                    // username = ObjUserInfo.UserName;

                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.UserID;
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    // Failure.Visible = false;
                    //success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindData();
                    }
                }
                else
                {
                    Response.Redirect("~/DeptLogin.aspx");
                }
            }
            catch (Exception ex)
            {
                //   lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                // Failure.Visible = true;
                throw ex;
            }
        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                //string ID = Request.QueryString[0].ToString();
                ds = PreBAL.GetDitSiteReport(0, 1004);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    reportId = Convert.ToInt32(ds.Tables[0].Rows[0]["REPORTID"]);
                    unitName = Convert.ToString(ds.Tables[0].Rows[0]["UNITNAME"]);
                    nmeunitlbl.Text = unitName;
                    unitNamelbl.Text = unitName;
                    loc = Convert.ToString(ds.Tables[0].Rows[0]["UNITLOCATION"]);
                    locationlbl.Text = loc;
                    placelbl.Text = loc;
                    datelbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["CREATEDDATE"]);
                    coordinateslbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["GPSCOORDINATES"]);
                    sitearealbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["SITEAREA"]);
                    ownrshplbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["OWNERSHIP"]);
                    undrpossesionunitlbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNDERPOSSESSION"]);
                    distmainrdlbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["DISTANCEFROMMAINROAD"]);
                    typroadlbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["ROADTYPE"]);
                    constcommenclbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["CONSTRUCTIONCOMMENCEMENT"]);
                    naturalbodieslbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["ANYNATURALBODIES"]);
                    envvulnerbleloclbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["ENVVULNERABLELOC"]);
                    avalpwrlbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["AVAILABILITYOFPOWER"]);
                    avalwaterlbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["AVAILABILITYOFWATER"]);
                    observationslbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["OTHEROBSERVATIONS"]);
                    cmntslbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["COMMENTS"]);

                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    inspectionTeam.DataSource = ds.Tables[1];
                    inspectionTeam.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}