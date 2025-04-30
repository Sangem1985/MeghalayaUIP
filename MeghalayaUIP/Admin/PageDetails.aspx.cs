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

namespace MeghalayaUIP.Admin
{
    public partial class PageDetails : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        MasterBAL mstrBAL = new MasterBAL();
        MGCommonBAL objcommon = new MGCommonBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        public void BindPageName()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = mstrBAL.GetPageName(txtPageName.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GVPageName.DataSource = ds.Tables[0];
                    GVPageName.DataBind();
                    Failure.Visible = false;
                }
                else
                {
                    GVPageName.DataSource = null;
                    GVPageName.DataBind();
                    Failure.Visible = true;
                    lblmsg0.Text = "No records found..!";
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BindPageName();
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
}