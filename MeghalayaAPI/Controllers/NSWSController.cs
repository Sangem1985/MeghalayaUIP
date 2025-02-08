using MeghalayaAPI.BAL;
using MeghalayaAPI.Models;
using MeghalayaAPI.Services;
using MeghalayaUIP.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MeghalayaAPI.Controllers
{
    [RoutePrefix("api/NSWS")]
    public class NSWSController : ApiController
    {
        
        private readonly HttpClient _httpClient;
        NSWSBAL ObjNSWSBal = new NSWSBAL();
        
        private readonly CommonServices _getSRVC = new CommonServices();
        
        #region Get Districts
        [BasicAuthentication]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetCompanyDetails")]
        public async Task<IHttpActionResult>getcompanydetails()
        {
            // Assuming stateId is 24, you can adjust it as per your requirement
            try
            {
                var apiResponse = await _getSRVC.GetPanDetailsAsync("24");
                if (apiResponse != null && apiResponse.Status)
                {
                    // Save the fetched data into the database

                    var resultMessage = ObjNSWSBal.InsertNSWSDETAILS(apiResponse.Data);

                    return (IHttpActionResult)Ok(resultMessage);

                }
                else
                {
                    return (IHttpActionResult)BadRequest();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                ErrorLog.LogData(Convert.ToString(ex), "GetCompanyDetails");
                ErrorLog.LogerrorDB(ex, "Service");
                return (IHttpActionResult)BadRequest();
            }
        }
        #endregion

        #region Get Districts
        [BasicAuthentication]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Get")]
        [System.Web.Http.Route("UpdateToNSWS")]

        public async Task<IHttpActionResult> Update_DetailsNSWS()
        {
            
            try
            {
                var apiResponse = await _getSRVC.UpdateToNSWSAsync();
                if (apiResponse != null && apiResponse.Status)
                {
                    
                    return (IHttpActionResult)Ok(apiResponse);

                }
                else
                {
                    return (IHttpActionResult)BadRequest();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                ErrorLog.LogData(Convert.ToString(ex), "GetCompanyDetails");
                ErrorLog.LogerrorDB(ex, "Service");
                return (IHttpActionResult)BadRequest();
            }


        }
        #endregion


    }
}
