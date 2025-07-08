using MeghalayaAPI.BAL;
using MeghalayaAPI.Models;
using MeghalayaAPI.Validations;
using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.CFEDAL;
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

namespace MeghalayaAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Data")]
    public class CFEProcessController : ApiController
    {
        /*private string connectionString = ConfigurationManager.ConnectionStrings["MIPASS"].ConnectionString;*/
        CFEDAL objcfeDtls = new CFEDAL();
        CFEProcessBAL _cfeprocessbal = new CFEProcessBAL();
        CFEProcessValidations validations = new CFEProcessValidations();

        /* [HttpGet]
         [Route("get")]
         public IHttpActionResult GetData([FromUri] string param)
         {
             List<string> results = new List<string>();
             using (SqlConnection conn = new SqlConnection(connectionString))
             {
                 string query = "SELECT Info FROM SampleTable WHERE ParamValue = @param";
                 SqlCommand cmd = new SqlCommand(query, conn);
                 cmd.Parameters.AddWithValue("@param", param);
                 conn.Open();
                 SqlDataReader reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     results.Add(reader["Info"].ToString());
                 }
             }
             return Ok(results);
         }*/

        [HttpPost]
        [Route("UpdateCFEDepartmentProcessDup")]
        public IHttpActionResult CFEDepartmentProcessUpdateDup([FromBody] CFEDtls model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data.");
                }
                else
                {
                    string UnitID = GetUnitID(Convert.ToInt32(model.Questionnaireid));
                    if (Convert.ToInt32(UnitID) > 0)
                    {
                        model.Unitid = Convert.ToString(UnitID);
                    }
                }
                string errormsg = validations.ValidateFields(model);
                if (errormsg.Trim().TrimStart() != "")
                {
                    return BadRequest(errormsg);
                }
                else
                {

                    string valid = objcfeDtls.UpdateCFEDepartmentProcess(model);
                    /*return Ok("Application Processed Successfully.");*/
                    return Ok(new
                    {
                        status = 200,
                        desc = "success",
                        message = valid
                    });
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                ErrorLog.LogData(Convert.ToString(ex), "UpdateCFEDepartmentProcess");
                ErrorLog.LogerrorDB(ex, "UpdateCFEDepartmentProcess");
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("PostCFEFeasibilityReport")]
        public IHttpActionResult InsertCFEFeasibilityReport([FromBody] CFE_FEASIBILITY model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data.");
                }
               /*if (!ModelState.IsValid)
                {
                    var customErrors = ModelState
                   .Where(ms => ms.Value.Errors.Count > 0)
                   .SelectMany(ms => ms.Value.Errors)
                   .Select(err =>
                   !string.IsNullOrWhiteSpace(err.ErrorMessage)
                       ? err.ErrorMessage
                       : err.Exception?.Message
                       )
                       .Where(msg => !string.IsNullOrWhiteSpace(msg))
                       .ToList();

                    return Content(HttpStatusCode.BadRequest, new { status = "failed", errors = customErrors });
                }*/
                string errormsg = validations.ValidateFeasibilityFields(model);
                if (errormsg.Trim().TrimStart() != "")
                {
                    return Content(HttpStatusCode.BadRequest, new {status=400, desc = "failed", errors = errormsg });
                }
                else
                {

                    string valid = _cfeprocessbal.CFEFeasibilityReportInsert(model);
                    if (Convert.ToInt32(valid) > 0)
                    {
                        if (Convert.ToInt32(valid) == 25)
                        {
                            return Ok(new
                            {
                                status = 400,
                                desc = "Already Exists",
                                message = valid
                            });
                        }
                        if (Convert.ToInt32(valid) == 26)
                        {
                            return Ok(new
                            {
                                status = 400,
                                desc = "Invalid QuestionaryId",
                                message = valid
                            });
                        }
                        else
                        {
                            return Ok(new
                            {
                                status = 200,
                                desc = "success",
                                message = valid
                            });
                        }
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
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                ErrorLog.LogData(Convert.ToString(ex), "InsertCFEFeasibilityReport");
                ErrorLog.LogerrorDB(ex, "InsertCFEFeasibilityReport");
                return InternalServerError(ex);
            }
        }
        public string GetUnitID(int CFEQDID)
        {
            try
            {
                string UnitID = "";
                DataSet ds = new DataSet();
                ds = _cfeprocessbal.GetUnitIDBasedonQDID(CFEQDID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    UnitID = Convert.ToString(ds.Tables[0].Rows[0]["CFEDA_UNITID"]);
                }
                return UnitID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetDataPower()
        {
            try
            {
                DataSet ds = new DataSet();
                //ds = objcfebal.GetPowerDetailsAPI(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string SendCFEAppStatus(DataSet ds)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            using (var client = new HttpClient())
            {
                var url = "https://uat.mepdcl.trm.ieasybill.com/api/registration/new";

                var requestBody = new
                {
                    Subdivisonname = Convert.ToString(ds.Tables[0].Rows[0]["SUBDIVISIONNAME"]),
                    Subdivison = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_SUBDIVISION"]),
                    District = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_DISTRICT"]),
                    DistrictName = Convert.ToString(ds.Tables[0].Rows[0]["DistName"]),
                    //  Applicationfor = Convert.ToString(ds.Tables[0].Rows[0]["Applicationfor"]),
                    //Applicationtype = Convert.ToString(ds.Tables[0].Rows[0]["Applicationtype"]),
                    Applicationtype = Convert.ToInt32(ds.Tables[0].Rows[0]["Applicationtype"]),
                    Applicationfor = Convert.ToInt32(ds.Tables[0].Rows[0]["Applicationfor"]),
                    PinCode = Convert.ToInt32(ds.Tables[0].Rows[0]["CFEID_REPPINCODE"]),
                    state = Convert.ToInt32(ds.Tables[0].Rows[0]["CFEID_STATEID"]),
                    Address_of_inst = Convert.ToString(ds.Tables[0].Rows[0]["ADDRESS"]),
                    Owner_type = Convert.ToInt32(ds.Tables[0].Rows[0]["CFEQD_COMPANYTYPE"]),
                    Purpose = Convert.ToInt32(ds.Tables[0].Rows[0]["PROPOSALFOR"]),
                    AppliedLoad = Convert.ToInt32(ds.Tables[0].Rows[0]["AppliedLoad"]),
                    Applicatent_Name = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPNAME"]),
                    Father_name = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPSoWoDo"]),
                    MotherName = Convert.ToString(ds.Tables[0].Rows[0]["MOTHERNAME"]),
                    Mobile_number = Convert.ToString(ds.Tables[0].Rows[0]["Mobile_number"]),
                    Phone = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]),
                    Email = Convert.ToString(ds.Tables[0].Rows[0]["Email"]),
                    Door_no = Convert.ToInt32(ds.Tables[0].Rows[0]["DOORNO"]),
                    Perm_Address = Convert.ToString(ds.Tables[0].Rows[0]["ADDRESSED"]),
                    Cast = Convert.ToString(ds.Tables[0].Rows[0]["CATEGORY"]),
                    IdentityProof = Convert.ToString(ds.Tables[0].Rows[0]["PROOF"]),
                    CreatedBy = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_CREATEDBY"]),
                    /*    lstDocuments = new[]
                    {
                    new {
                        documantId = 2,
                        documentName = "Proof of ownership/occupancy",
                        document_path = "doc1.pdf"
                    },
                    new {
                        documantId = 3,
                        documentName = "Proof of Identification",
                        document_path = "doc2.pdf"
                    }
                    }*/
                };
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var resultContent = response.Content.ReadAsStringAsync().Result;
                    dynamic Response = JsonConvert.DeserializeObject(resultContent);
                    string application_Reg_no = Response["application_Reg_no"]?.ToString();
                    string message = Response["message"]?.ToString();
                    //hdnapiReg.Value = application_Reg_no;
                    return application_Reg_no + "," + message;
                }

                throw new Exception("Failed  " + response.StatusCode);
            }
        }
        [HttpPost]
        [Route("UpdateCFEDepartmentProcess")]
        public IHttpActionResult CFEDepartmentProcessUpdate([FromBody] CFEDtls model)
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
                        model.status = 13;
                        string UnitID = GetUnitID(Convert.ToInt32(model.Questionnaireid));

                        if (UnitID != "" && UnitID != null)
                        {
                            model.Unitid = UnitID;
                        }
                        else
                        {
                            errormsg = "Invalid Questionnaireid";
                            return Content(HttpStatusCode.BadRequest, new { status = 400, desc = "failed", errors = errormsg });
                        }
                    }
                }
                errormsg = validations.ValidateCFEFields(model);
                if (errormsg.Trim().TrimStart() != "")
                {
                    return Content(HttpStatusCode.BadRequest, new { status = 400, desc = "failed", errors = errormsg });
                }
                else
                {
                    
                    string Cfevalid = objcfeDtls.UpdateCFEDepartmentProcess(model);
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
                            string valid = _cfeprocessbal.UpdateEstimationDetails(model);
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
                ErrorLog.LogData(Convert.ToString(ex), "UpdateCFEDepartmentProcess");
                ErrorLog.LogerrorDB(ex, "UpdateCFEDepartmentProcess");
                return InternalServerError(ex);
            }
        }
    }
}
