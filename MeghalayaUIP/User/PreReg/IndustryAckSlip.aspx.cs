using MeghalayaUIP.BAL.CFEBLL;
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
    public partial class IndustryAckSlip : System.Web.UI.Page
    {
        PreRegBAL preBAL = new PreRegBAL();

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
                        hdnUserID.Value = ObjUserInfo.Userid;
                    }

                    if (!IsPostBack)
                    {
                        BindaApplicatinDetails();

                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void BindaApplicatinDetails()
        {
            try
            {

                if (Request.QueryString.Count > 0)
                {
                    string UnitID = Request.QueryString[0].ToString();
                    string InvesterID = hdnUserID.Value;
                    if (UnitID != null && InvesterID != null)
                    {
                        DataSet ds = new DataSet();
                        ds = preBAL.GetIndRegUserApplDetails(UnitID, InvesterID);

                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblUIDNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["PREREGUIDNO"]);

                            }
                            if (ds.Tables[3].Rows.Count > 0)
                            {
                                lblApplDate.Text = Convert.ToString(ds.Tables[3].Rows[0]["APPLICATIONDATE"]);

                            }

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect("~/User/Dashboard/MainDashboard.aspx");

            }
            catch (Exception ex)
            {

            }
        }


    }
}