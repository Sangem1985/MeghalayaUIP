using MeghalayaUIP.BAL.CFEBLL;
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
    public partial class CFOPaymentReceipt : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfebal = new CFOBAL();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }

        public void BindData()
        {
            try
            {


                DataSet ds = new DataSet();
                //string ID = Request.QueryString[0].ToString();
                ds = objcfebal.GetCFOPaymentReceipt("1037", "1002", "234432", "PE1002MEG31520241037");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtUid.Text = Convert.ToString(ds.Tables[0].Rows[0]["UIDNO"]);
                    txtaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNITADDRESS"]);
                    txtEmailId.Text = Convert.ToString(ds.Tables[0].Rows[0]["REP_EMAIL"]);
                    txtrcptdt.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOPD_TRANSACTIONDATE"]);
                    txtrcptno.Text = "234432";
                    txttotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalAmount"]);
                    lblMobileNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["REP_MOBILE"]);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}