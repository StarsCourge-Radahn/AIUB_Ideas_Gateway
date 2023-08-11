using AIUB_Ideas_Gateway.AuthFilters;
using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AIUB_Ideas_Gateway.Controllers
{
    [LoggedIn]

    public class JobController : ApiController
    {
        [HttpGet]
        [Route("/api/jobs")]
        public HttpResponseMessage Jobs()
        {


            return new HttpResponseMessage();
        }


        // Only login user can access individual job post
        [HttpPost]
        [Route("api/job/{id}")]
        public HttpResponseMessage Job(int id)
        {
            try
            {
                var data = JobServices.JobPost(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        // Only login user can create a job-post
        [HttpPost]
        [Route("api/job/create")]
        public HttpResponseMessage Create(JobDTO obj)
        {
            if (obj.Title != null && obj.Description != null)
            {
                try
                {
                    var token = Request.Headers.Authorization.ToString();
                    var userId = AuthServices.GetUserID(token);
                    obj.CreatedAt = DateTime.Now;
                    obj.UpdatedAt = null;
                    obj.UserID = userId;

                    var data = JobServices.CreateJobPost(obj);
                    if (data == true)
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Job Post Created!" });
                    else
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Creation of Job post" });
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid Job Post object" });
            }
        }
    }
}
