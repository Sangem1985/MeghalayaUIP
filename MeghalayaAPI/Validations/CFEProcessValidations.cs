using MeghalayaAPI.Models;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeghalayaAPI.Validations
{
    public class CFEProcessValidations
    {
        public string ValidateFields(CFEDtls model)
        {
            int slno = 1;
            string ErrorMsg = "";
            if (model.Unitid == "" || model.Unitid == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Unitid should not be empty \\n";
                slno = slno + 1;
            }
            if (model.Investerid == "" || model.Investerid == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Investerid should not be empty \\n";
                slno = slno + 1;
            }
            if (model.status == null)
            {
                ErrorMsg = ErrorMsg + slno + ". status should not be null \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.UserID) || model.UserID == "" || model.UserID == null)
            {
                ErrorMsg = ErrorMsg + slno + ". UserID should not be empty \\n";
                slno = slno + 1;
            }
            if (model.deptid == null)
            {
                ErrorMsg = ErrorMsg + slno + ". deptid should not be null \\n";
                slno = slno + 1;
            }
            if (model.ApprovalId == null)
            {
                ErrorMsg = ErrorMsg + slno + ". ApprovalId should not be null \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.Questionnaireid) || model.Questionnaireid == "" || model.Questionnaireid == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Questionnaire Id should not be null \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.PrescrutinyRejectionFlag) || model.PrescrutinyRejectionFlag == "" || model.PrescrutinyRejectionFlag == null)
            {
                ErrorMsg = ErrorMsg + slno + ". PrescrutinyRejectionFlag should not be empty \\n";
                slno = slno + 1;
            }
            if (model.status == 6 && (string.IsNullOrWhiteSpace(model.Remarks) || model.Remarks == "" || model.Remarks == null))
            {
                ErrorMsg = ErrorMsg + slno + ".Remarks should not be empty \\n";
                slno = slno + 1;
            }
            if (model.status == 17 && (string.IsNullOrWhiteSpace(model.Remarks) || model.Remarks == "" || model.Remarks == null))
            {
                ErrorMsg = ErrorMsg + slno + ".Remarks should not be empty \\n";
                slno = slno + 1;
            }
            if (model.status == 11 && (string.IsNullOrWhiteSpace(model.AdditionalAmount) || model.AdditionalAmount == "" || model.AdditionalAmount == null || model.AdditionalAmount == "0"))
            {
                ErrorMsg = ErrorMsg + slno + ".AdditionalAmount should not be empty or Zero \\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        public string ValidateFeasibilityFields(CFE_FEASIBILITY model)
        {
            int slno = 1;
            string ErrorMsg = "";

            if (model.QuestionaryId.Trim() == "" || model.QuestionaryId == null || model.QuestionaryId.Trim() == "0")
            {
                ErrorMsg = ErrorMsg + slno + ".Please provide a valid QuestionaryId. \\n";
                slno = slno + 1;
            }
            if (model.Feasible == 0)
            {
                ErrorMsg = ErrorMsg + slno + ".Please provide a valid Feasible. \\n";
                slno = slno + 1;
            }
            if (model.UserId == 0)
            {
                ErrorMsg = ErrorMsg + slno + ".Please provide a valid UserId. \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.UserIp) || model.UserIp == "" || model.UserIp == "0")
            {
                ErrorMsg = ErrorMsg + slno + ".Please provide a valid UserIp address. \\n";
                slno = slno + 1;
            }
            if (model.Product.Trim() == "HT")
            {
                if (string.IsNullOrWhiteSpace(model.MeteredSide) || model.MeteredSide == "" || model.MeteredSide == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ".Please provide a valid MeteredSide. \\n";
                    slno = slno + 1;
                }
            }
            if (model.MeteredSide != null)
            {
                if (model.MeteredSide.Trim().ToUpper() == "LT SIDE")
                {
                    if (string.IsNullOrWhiteSpace(model.MeterType) || model.MeterType == "" || model.MeterType == "0")
                    {
                        ErrorMsg = ErrorMsg + slno + ".Please provide a valid MeteredSide. \\n";
                        slno = slno + 1;
                    }
                }
            }
            if (model.MeterType != null)
            {
                if (model.MeterType.Trim().ToUpper() == "KVA")
                {
                    if (model.LoadKva == 0)
                    {
                        ErrorMsg = ErrorMsg + slno + ".Please provide a valid LoadKva. \\n";
                        slno = slno + 1;
                    }
                }
            }
            if (model.MeterType != null)
            {
                if (model.MeterType.Trim().ToUpper() == "KW")
                {
                    if (model.Loadkw == 0)
                    {
                        ErrorMsg = ErrorMsg + slno + ".Please provide a valid Loadkw. \\n";
                        slno = slno + 1;
                    }
                }
            }
            return ErrorMsg;
        }
    }
}