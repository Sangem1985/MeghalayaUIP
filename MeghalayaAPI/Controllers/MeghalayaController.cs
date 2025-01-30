using MeghalayaAPI.BAL;
using MeghalayaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using MeghalayaUIP.CommonClass;
using MeghalayaUIP.Common;
using MeghalayaUIP.BAL.CommonBAL;


namespace MeghalayaAPI.Controllers
{
    [RoutePrefix("api/Meghalaya")]
    public class MeghalayaController : ApiController
    {
        NSWSBAL ObjNSWSBal = new NSWSBAL();
        // GET: Meghalaya
        [AllowAnonymous]
        [HttpPost]
        [Route("api/data/forall")]
        public IHttpActionResult Get()
        {
            return Ok("Now server time is: " + DateTime.Now.ToString());
        }
        #region Get Districts
        [BasicAuthentication]
        [HttpPost]
        [Route("GetDistrcitsOnline")]
        public async Task<List<MasterDistrcits>> GetDistrcitsOnline()
        {
            MasterBAL mstrBAL = new MasterBAL();
            List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
            #region Getting District
            try
            {
                objDistrictModel = mstrBAL.GetDistrcits();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                ErrorLog.LogData(Convert.ToString(ex), "GetDistrcitsOnline");
                ErrorLog.LogerrorDB(ex, "Service");
            }
            #endregion
            return await Task.FromResult(objDistrictModel);
        }
        #endregion

        #region insert DATA
        [BasicAuthentication]
        [HttpPost]
        [Route("InsertNSWSUser")]
        public async Task<InsertUserDetailsResponse> InsertNSWSUser(InsertNSWSUserRequest ObjNSWSUserRequest)
        {
            var identity = (ClaimsIdentity)User.Identity;
            InsertUserDetailsResponse objVerifyOtpResponceData = new InsertUserDetailsResponse();
            #region after validating request
            try
            {
                ErrorLog.LogData(ObjNSWSUserRequest.ToString(), "MeghalayaController");
                objVerifyOtpResponceData = ObjNSWSBal.NSWSINSERTUSERDetails(ObjNSWSUserRequest);
                if (objVerifyOtpResponceData.ResponseCode == Convert.ToString(ErrorLog.ErrorCodes.Success))
                {
                    #region cafresponse
                    ResponseSvc responecafdetailClass = new ResponseSvc();
                    responecafdetailClass = ObjNSWSBal.Getcafdetailsofnsws(ObjNSWSUserRequest.investorSwsId).Result;

                    //responseofredirectionurlnsws responsendredirection = new responseofredirectionurlnsws();
                    //responsendredirection = objSingleWindowBALAPI.sendrequesturltonsws(VoTermLoandtls.investorSwsId, VoTermLoandtls.username, objVerifyOtpResponceData.TSIPASSUserID);

                    #endregion



                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                ErrorLog.LogData(Convert.ToString(ex), "MeghalayaController");
                ErrorLog.LogerrorDB(ex, "Service");
            }
            finally
            {
                ObjNSWSUserRequest = null;
            }
            #endregion
            return await Task.Run(() => objVerifyOtpResponceData);
        }
        #endregion
    }

}