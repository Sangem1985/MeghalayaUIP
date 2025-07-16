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
                ErrorMsg = ErrorMsg + slno + ".Please provide valid QuestionaryId. \\n";
                slno = slno + 1;
            }
            if (model.Feasible == 0)
            {
                ErrorMsg = ErrorMsg + slno + ".Please provide valid Feasible. \\n";
                slno = slno + 1;
            }
            if (model.UserId == 0)
            {
                ErrorMsg = ErrorMsg + slno + ".Please provide valid UserId. \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.UserIp) || model.UserIp == "" || model.UserIp == "0")
            {
                ErrorMsg = ErrorMsg + slno + ".Please provide valid UserIp address. \\n";
                slno = slno + 1;
            }
            if (model.Product.Trim() == "HT")
            {
                if (string.IsNullOrWhiteSpace(model.MeteredSide) || model.MeteredSide == "" || model.MeteredSide == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ".Please provide valid MeteredSide. \\n";
                    slno = slno + 1;
                }
            }
            if (model.MeteredSide != null)
            {
                if (model.MeteredSide.Trim().ToUpper() == "LT SIDE")
                {
                    if (string.IsNullOrWhiteSpace(model.MeterType) || model.MeterType == "" || model.MeterType == "0")
                    {
                        ErrorMsg = ErrorMsg + slno + ".Please provide valid MeteredSide. \\n";
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
                        ErrorMsg = ErrorMsg + slno + ".Please provide valid LoadKva. \\n";
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
                        ErrorMsg = ErrorMsg + slno + ".Please provide valid Loadkw. \\n";
                        slno = slno + 1;
                    }
                }
            }
            return ErrorMsg;
        }

        public string ValidateCFEFields(CFEDtls model)
        {
            int slno = 1;
            string ErrorMsg = "";
            if (model.Unitid == "" || model.Unitid == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid Unitid \\n";
                slno = slno + 1;
            }
            if (model.ReferenceNo == "" || model.ReferenceNo == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid ReferenceNo \\n";
                slno = slno + 1;
            }
            if (model.Questionnaireid == "" || model.Questionnaireid == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid Questionnaireid \\n";
                slno = slno + 1;
            }
            if (model.status == null || model.status == 0)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid status \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.UserID) || model.UserID == "" || model.UserID == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid UserID \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.IPAddress) || model.IPAddress == "" || model.IPAddress == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid IPAddress \\n";
                slno = slno + 1;
            }
            if (model.deptid == null || model.deptid == 0)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid deptid \\n";
                slno = slno + 1;
            }
            if (model.ApprovalId == null || model.ApprovalId == 0)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid ApprovalId \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.Questionnaireid) || model.Questionnaireid == "" || model.Questionnaireid == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid Questionnaireid \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.FilePath) || model.FilePath == "" || model.FilePath == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid FilePath \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.FileName) || model.FileName == "" || model.FileName == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid FileName \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.FileType) || model.FileType == "" || model.FileType == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid FileType \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.FileDesc) || model.FileDesc == "" || model.FileDesc == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid FileDesc \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.ConnectionId) || model.ConnectionId == "" || model.ConnectionId == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid Connection Id \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.EstimationId) || model.EstimationId == "" || model.EstimationId == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid Estimation Id \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrWhiteSpace(model.Category) || model.Category == "" || model.Category == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid Category \\n";
                slno = slno + 1;
            }
            foreach (var doc in model.lstComponents)
            {
                if (string.IsNullOrWhiteSpace(doc.Order) || doc.Order == "" || doc.Order == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please provide valid Order \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrWhiteSpace(doc.Amount) || doc.Amount == "" || doc.Amount == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please provide valid Amount \\n";
                    slno = slno + 1;
                }
                decimal result;
                if (decimal.TryParse(doc.Amount, out result))
                {

                }
                else
                {
                    ErrorMsg = ErrorMsg + slno + ". Please provide valid Amount in Decimal or Int only \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrWhiteSpace(doc.Component) || doc.Component == "" || doc.Component == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please provide valid Component \\n";
                    slno = slno + 1;
                }
            }
                return ErrorMsg;
        }
    }
}