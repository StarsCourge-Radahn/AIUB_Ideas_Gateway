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
            try
            {
                var jobs = JobServices.AllJobsPost();
                if (jobs.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Currently No Jobs are available!" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, jobs);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
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
                    obj.IsBan = false;
                    obj.IsDeleted = false;

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

            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid Job Post object" });
        }

        [HttpPost]
        [Route("api/job/update")]
        public HttpResponseMessage Update(JobDTO obj)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var userId = AuthServices.GetUserID(token);
                if (obj.UserID == userId)
                {
                    var res = JobServices.UpdateJobPost(obj);

                    if (res == true)
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Job updated!" });
                    else
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in job update!" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new { Msg = "You don't have the rights to update this job." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("api/job/delete")]
        public HttpResponseMessage Delete(JobDTO obj)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var userId = AuthServices.GetUserID(token);
                if (obj.UserID == userId)
                {
                    var res = JobServices.DeleteJobPost(obj.JobID);
                    if (res == true)
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Job deleted!" });
                    else
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in job delete!" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new { Msg = "You don't have the rights to delete this job!" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
    }
}
