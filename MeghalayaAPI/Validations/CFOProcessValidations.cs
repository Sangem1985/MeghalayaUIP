using MeghalayaAPI.Models;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeghalayaAPI.Validations
{
    public class CFOProcessValidations
    {
        public string ValidateCFOFields(CFODtls model)
        {
            int slno = 1;
            string ErrorMsg = "";
            if (model.Unitid == "" || model.Unitid == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please provide valid Unitid \\n";
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
            if (model.deptid != 14)
            {
                if(model.Stage==13)
                {
                    if (string.IsNullOrWhiteSpace(model.ReferenceNumber) || model.ReferenceNumber == "" || model.ReferenceNumber == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please provide valid ReferenceNumber \\n";
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
                }
               
            }
            if (model.deptid != null && model.deptid != 0)
            {
                if (model.deptid == 14)
                {
                    if (string.IsNullOrWhiteSpace(model.Powersanctionletternumber) || model.Powersanctionletternumber == "" || model.Powersanctionletternumber == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please provide valid Powersanctionletternumber \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrWhiteSpace(model.Powersanctiondate) || model.Powersanctiondate == "" || model.Powersanctiondate == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please provide valid Powersanctiondate \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrWhiteSpace(model.Consumerid) || model.Consumerid == "" || model.Consumerid == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please provide valid Consumerid \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrWhiteSpace(model.Dateofservice) || model.Dateofservice == "" || model.Dateofservice == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please provide valid Dateofservice \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrWhiteSpace(model.Sanctionedload) || model.Sanctionedload == "" || model.Sanctionedload == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please provide valid Sanctionedload \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrWhiteSpace(model.Metermake) || model.Metermake == "" || model.Metermake == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please provide valid Metermake \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrWhiteSpace(model.Meterserialnumber) || model.Meterserialnumber == "" || model.Meterserialnumber == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please provide valid Meterserialnumber \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrWhiteSpace(model.Metertype) || model.Metertype == "" || model.Metertype == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please provide valid Metertype \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrWhiteSpace(model.Ctbyptratio) || model.Ctbyptratio == "" || model.Ctbyptratio == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please provide valid Ctbyptratio \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrWhiteSpace(model.Meterconstant) || model.Meterconstant == "" || model.Meterconstant == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please provide valid Meterconstant \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrWhiteSpace(model.Categoryapplicable) || model.Categoryapplicable == "" || model.Categoryapplicable == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please provide valid Categoryapplicable \\n";
                        slno = slno + 1;
                    }
                }
            }
            return ErrorMsg;
        }
    }
}