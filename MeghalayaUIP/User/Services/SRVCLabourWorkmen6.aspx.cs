using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCLabourWorkmen6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                if (rblContractor.SelectedValue=="Y")
                {
                    Details.Visible = true;
                }
                else { Details.Visible = false; }
            }
            catch(Exception ex)
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
    }
}