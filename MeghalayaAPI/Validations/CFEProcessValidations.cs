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
            if (model.NearestConsumerId == "" || model.NearestConsumerId == null)
            {
                ErrorMsg = ErrorMsg + slno + ".NearestConsumerId should not be empty \\n";
                slno = slno + 1;;
            }
            return ErrorMsg;
        }
    }
}