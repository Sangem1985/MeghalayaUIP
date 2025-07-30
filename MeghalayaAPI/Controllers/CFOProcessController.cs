using MeghalayaAPI.BAL;
using MeghalayaAPI.DAL;
using MeghalayaAPI.Models;
using MeghalayaAPI.Validations;
using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.CFEDAL;
using MeghalayaUIP.DAL.CFODAL;
using MeghalayaUIP.Dept;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MeghalayaAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Data")]
    public class CFOProcessController : ApiController
    {
        CFODAL objcfoDtls = new CFODAL();
        CFOProcessBAL _cfoprocessbal = new CFOProcessBAL();
        CFOProcessValidations validations = new CFOProcessValidations();

        [HttpPost]
        [Route("UpdateCFODepartmentProcess")]
        public IHttpActionResult CFODepartmentProcessUpdate([FromBody] CFODtls model)
        {
            try
            {
                string errormsg = "";
                if (model == null)
                {
                    errormsg = "Invalid Data";
                    return Content(HttpStatusCode.BadRequest, new { status = 400, desc = "failed", errors = errormsg });
                }
                else
                {
                    if (model.Questionnaireid != "")
                    {
                        //model.status = 13;
                        DataSet ds = GetCFOUnitIDBasedonQDID(Convert.ToInt32(model.Questionnaireid));

                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["CFODA_UNITID"].ToString() != "" && ds.Tables[0].Rows[0]["CFODA_UNITID"] != null)
                            {
                                model.Unitid = ds.Tables[0].Rows[0]["CFODA_UNITID"].ToString();
                            }
                             
                            if (ds.Tables[0].Rows[0]["CFODA_CFOQDID"].ToString() != "" && ds.Tables[0].Rows[0]["CFODA_CFOQDID"] != null)
                            {
                                model.Questionnaireid = ds.Tables[0].Rows[0]["CFODA_CFOQDID"].ToString();
                            }
                           
                            if (ds.Tables[0].Rows[0]["CFODA_DEPTID"].ToString() != "" && ds.Tables[0].Rows[0]["CFODA_DEPTID"] != null)
                            {
                                model.deptid =Convert.ToInt32(ds.Tables[0].Rows[0]["CFODA_DEPTID"].ToString());
                            }
                            if (ds.Tables[0].Rows[0]["CFODA_APPROVALID"].ToString() != "" && ds.Tables[0].Rows[0]["CFODA_APPROVALID"] != null)
                            {
                                model.ApprovalId = Convert.ToInt32(ds.Tables[0].Rows[0]["CFODA_APPROVALID"].ToString());
                            }
                            if(model.deptid == 14)
                            {
                                model.status = model.Stage;
                            }

                        }
                           
                        else
                        {
                            errormsg = "Invalid Questionnaireid";
                            return Content(HttpStatusCode.BadRequest, new { status = 400, desc = "failed", errors = errormsg });
                        }
                    }
                }
                errormsg = validations.ValidateCFOFields(model);
                if (errormsg.Trim().TrimStart() != "")
                {
                    return Content(HttpStatusCode.BadRequest, new { status = 400, desc = "failed", errors = errormsg });
                }
                else
                {

                    string Cfevalid = objcfoDtls.UpdateCFODepartmentProcess(model);
                    if (Convert.ToInt32(Cfevalid) > 0)
                    {
                        if (Convert.ToInt32(Cfevalid) == 2)
                        {
                            return Ok(new
                            {
                                status = 400,
                                desc = "failed",
                                message = "Duplicate Request"
                            });
                        }
                        else
                        {
                            string valid = _cfoprocessbal.InsertCRCertificateDetails(model);
                            if (Convert.ToInt32(valid) > 0)
                            {
                                return Ok(new
                                {
                                    status = 200,
                                    desc = "success",
                                    message = valid
                                });
                            }
                            else
                            {
                                return Ok(new
                                {
                                    status = 400,
                                    desc = "failed",
                                    message = valid
                                });
                            }
                        }
                    }
                    else
                    {
                        return Ok(new
                        {
                            status = 400,
                            desc = "failed",
                            message = "failed"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                ErrorLog.LogData(Convert.ToString(ex), "UpdateCFODepartmentProcess");
                ErrorLog.LogerrorDB(ex, "UpdateCFODepartmentProcess");
                return InternalServerError(ex);
            }
        }

        public DataSet GetCFOUnitIDBasedonQDID(int CFEQDID)
        {
            try
            {
                string UnitID = "";
                DataSet ds = new DataSet();
                ds = _cfoprocessbal.GetCFOUnitIDBasedonQDID(CFEQDID);
                
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}