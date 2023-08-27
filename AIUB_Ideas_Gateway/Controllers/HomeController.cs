using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AIUB_Ideas_Gateway.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("api/home")]
        public HttpResponseMessage AllPosts()
        {
            try
            {
                var posts = PostServices.AllPosts();
                return Request.CreateResponse(HttpStatusCode.OK, posts);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("api/home/search/post/{query}")]
        public HttpResponseMessage SearchPost(string query)
        {
            if (query != null)
            {
                var data = PostServices.PostSearch(query);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Nothing found related to this" + query + ":( !" });
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid search petameter");
        }


        [HttpGet]
        [Route("api/home/search/job/{query}")]
        public HttpResponseMessage SearchJobPost(string query)
        {
            if (query != null)
            {
                var data = JobServices.JobPostSearch(query);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Nothing found related to this" + query + ":( !" });
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid search petameter");
        }


        [HttpPost]
        [Route("api/home/forget")]
        public HttpResponseMessage Forgot(UserDTO userDTO)
        {
            if (userDTO.Email != null)
            {
                try
                {
                    var data = UserServices.GetByEmail(userDTO.Email);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, data);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Email invalid" });
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Email invalid" });


        }

        [HttpPost]
        [Route("api/home/changepassword")]
        public HttpResponseMessage ChangePasswordWithOTP(UserDTO userDTO)
        {
            try
            {
                var UserId = userDTO.UserID;
                var OTP = userDTO.Name;
                var Password = userDTO.Password;
               
                // Check if the OTP is valid and not expired
                var otp = UserServices.GetValidOTP(OTP,UserId);

                if (otp)
                {
                  
                    var res=UserServices.ChangePassword(Password, UserId);

                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Forget Password done. Go To login" });
                }


                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid or expired OTP" });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }

    
}
