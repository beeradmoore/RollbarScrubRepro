using System;
using Microsoft.AspNetCore.Mvc;
using Rollbar;
using Rollbar.NetCore.AspNet;
using RollbarScrubRepro.Data;

namespace RollbarScrubRepro.Controllers
{
    public class TestController : ControllerBase
    {
        [Route("api/test")]
        [HttpPost]
        public ActionResult Get([FromBody] LoginData loginData)
        {
            try
            {
                throw new Exception("Some error happened.");
            }
            catch (Exception err)
            {
                var rollbarPackage = new ExceptionPackage(err);
                var packageDecorator = new HttpRequestPackageDecorator(rollbarPackage, HttpContext.Request, true);
                RollbarLocator.RollbarInstance.Log(ErrorLevel.Error, packageDecorator);
            }

            return Ok();
        }
    }
}
