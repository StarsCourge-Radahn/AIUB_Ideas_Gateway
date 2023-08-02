using AIUB_Ideas_Gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AIUB_Ideas_Gateway.Controllers
{
    public class AuthenticateController : ApiController
    {
        [HttpPost]
        [Route("/")]
        public HttpResponseMessage Login(LoginModel login)
        {
            //try
            //{
            //    var token = AuthService.Login(login.Username, login.Password);
            //    if (token != null)
            //    {
            //        return Request.CreateResponse(HttpStatusCode.OK, token);
            //    }
            //    else
            //    {
            //        return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Username or password invalid" });
            //    }

            //}
            //catch (Exception ex)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            //}
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
