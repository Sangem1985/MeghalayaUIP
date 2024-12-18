﻿using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Admin
{
    public partial class SMSandMAILtesting : System.Web.UI.Page
    {
        SMSandMail smsMail = new SMSandMail();
        string UnitId, InvestorId, transaction, Module;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                UnitId = txtUnitID.Text; InvestorId = txtInvestorID.Text; 
            }
        }

       
        protected void BtnReg_Click(object sender, EventArgs e)
        {
            try
            {
                transaction = "REG";
                Module = "USER REGISTRATION";
                smsMail.SendEmail(UnitId, InvestorId, transaction, Module);
                smsMail.SendSms(UnitId, InvestorId, "1407172584852269031", "REG", "USER REGISTRATION");
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnIntent_Click(object sender, EventArgs e)
        {
            transaction = "REG";

        }

        protected void btnPreRegApprove_Click(object sender, EventArgs e)
        {
            try
            {
                transaction = "REG";
                Module = "INDUSTRY REGISTRATION APPROVAL";
                smsMail.SendEmail(UnitId, InvestorId, transaction, Module);
                smsMail.SendSms(UnitId, InvestorId, "1407172584852269031", "REG", "INDUSTRY REGISTRATION APPROVAL");

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnCFEApprove_Click(object sender, EventArgs e)
        {
            try
            {
                transaction = "REG";
                Module = "CFE REGISTRATION APPROVAL";
                smsMail.SendEmail(UnitId, InvestorId, transaction, Module);
                smsMail.SendSms(UnitId, InvestorId, "1407172584852269031", "REG", "CFE REGISTRATION APPROVAL");

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnCFOApprove_Click(object sender, EventArgs e)
        {
            try
            {
                transaction = "REG";
                Module = "CFO REGISTRATION APPROVAL";
                smsMail.SendEmail(UnitId, InvestorId, transaction, Module);
                smsMail.SendSms(UnitId, InvestorId, "1407172584852269031", "REG", "CFO REGISTRATION APPROVAL");

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnQueryID_Click(object sender, EventArgs e)
        {
            try
            {
                transaction = "REG";
                Module = "INDUSTRY REGISTRATION QUERY";
                smsMail.SendEmail(UnitId, InvestorId, transaction, Module);
                smsMail.SendSms(UnitId, InvestorId, "1407172584852269031", "REG", "INDUSTRY REGISTRATION QUERY");

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnQueryCFE_Click(object sender, EventArgs e)
        {
            try
            {
                transaction = "REG";
                Module = "CFE REGISTRATION QUERY";
                smsMail.SendEmail(UnitId, InvestorId, transaction, Module);
                smsMail.SendSms(UnitId, InvestorId, "1407172584852269031", "REG", "CFE REGISTRATION QUERY");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnQueryCFO_Click(object sender, EventArgs e)
        {
            try
            {
                transaction = "REG";
                Module = "CFO REGISTRATION QUERY";
                smsMail.SendEmail(UnitId, InvestorId, transaction, Module);
                smsMail.SendSms(UnitId, InvestorId, "1407172584852269031", "REG", "CFO REGISTRATION QUERY");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnPrereg_Click(object sender, EventArgs e)
        {
            try
            {
                transaction = "REG";
                Module = "INDUSTRY REGISTRATION";
                smsMail.SendEmail(UnitId, InvestorId, transaction, Module);
                smsMail.SendSms(UnitId, InvestorId, "1407172584852269031", "REG", "INDUSTRY REGISTRATION");

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnCFE_Click(object sender, EventArgs e)
        {
            try
            {
                transaction = "REG";
                Module = "CFE REGISTRATION";
                smsMail.SendEmail(UnitId, InvestorId, transaction, Module);
                smsMail.SendSms(UnitId, InvestorId, "1407172584852269031", "REG", "CFE REGISTRATION");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnCFO_Click(object sender, EventArgs e)
        {
            try
            {
                transaction = "REG";
                Module = "CFO REGISTRATION";
                smsMail.SendEmail(UnitId, InvestorId, transaction, Module);
                smsMail.SendSms(UnitId, InvestorId, "1407172584852269031", "REG", "CFO REGISTRATION");
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