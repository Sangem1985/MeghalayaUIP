using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.UI;
using MeghalayaAPI.Models;
using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.CFEDAL;
using Microsoft.Ajax.Utilities;
using MeghalayaAPI.Validations;

namespace MeghalayaAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Data")]
    public class CFEProcessController : ApiController
    {
        /*private string connectionString = ConfigurationManager.ConnectionStrings["MIPASS"].ConnectionString;*/
        CFEDAL objcfeDtls = new CFEDAL();
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
        [Route("UpdateCFEDepartmentProcess")]
        public IHttpActionResult CFEDepartmentProcessUpdate([FromBody] CFEDtls model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid data.");
                }
                string errormsg = validations.ValidateFields(model);
                if (errormsg.Trim().TrimStart() != "")
                {
                    return BadRequest(errormsg);
                }
                else
                {
                    string valid = objcfeDtls.UpdateCFEDepartmentProcess(model);
                    return Ok("Application Processed Successfully.");
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
