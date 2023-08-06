using AIUB_Ideas_Gateway.AuthFilters;
using AIUB_Ideas_Gateway.Models;
using BLL.Services;
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
        [Route("api/login/")]
        public HttpResponseMessage Login(LoginModel login)
        {
            try
            {
                var token = AuthServices.Login(login.UserName, login.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Username or password invalid" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage Register(RegisterModel obj)
        {
            try
            {
                var res = UserServices.CreateUser(obj.UserName, obj.Name, obj.Password);
                if (res == true)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Msg = "User account created. Back to login" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong!" });
        }

        [LoggedIn]
        [HttpPost]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var userId = AuthServices.GetUserID(token);
                if (userId > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Logged-Out" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
