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
        [Route("api/jobs")]
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

                    bool IsBan = UserServices.CheckUserBan(userId);
                    if (IsBan == false)
                    {
                        var data = JobServices.CreateJobPost(obj);
                        if (data == true)
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Job Post Created!" });
                        else
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Creation of Job post" });
                    }
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new { Msg = "User don't have permission. User temporary ban!" });
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

        // Apply for a job
        [HttpPost]
        [Route("api/job/apply/{jobid}")]
        public HttpResponseMessage ApplyAJob(int jobid)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var userId = AuthServices.GetUserID(token);
                var rtn = JobApplicationServices.JobApply(jobid, userId);
                if (rtn == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Job applied Successfully!" });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Somthing went wrong in job apply!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        // show applied users
        [HttpGet]
        [Route("api/job/applicants/{jobid}")]
        public HttpResponseMessage AppliedUsers(int jobid)
        {
            try
            {
                var job = JobServices.JobPost(jobid);
                var token = Request.Headers.Authorization.ToString();
                var userid = AuthServices.GetUserID(token);
                if (userid == job.UserID)
                {
                    var rtn = JobApplicationServices.AppliedUsers(jobid);
                    return Request.CreateResponse(HttpStatusCode.OK, rtn);
                }
                return Request.CreateResponse(HttpStatusCode.Forbidden, new { Msg = "You don't have access" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("api/job/applicants/cv/{jobid}")]
        public HttpResponseMessage ApplicantsCV(int jobid)
        {
            try
            {
                var job = JobServices.JobPost(jobid);
                var token = Request.Headers.Authorization.ToString();
                var userid = AuthServices.GetUserID(token);
                if (userid == job.UserID)
                {
                    var rtn = JobApplicationServices.ApplicantsInfo(jobid);
                    return Request.CreateResponse(HttpStatusCode.OK, rtn);
                }
                return Request.CreateResponse(HttpStatusCode.Forbidden, new { Msg = "You don't have access" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("api/job/application/update/{jobid}/{userid}/{status}")]
        public HttpResponseMessage UpdateUserApplication(int jobid, int userid, int status)
        {
            try
            {
                if (jobid > 0 && userid > 0 && status > 0)
                {
                    var token = Request.Headers.Authorization.ToString();
                    var jobpostuserid = AuthServices.GetUserID(token);
                    var job = JobServices.JobPost(jobid);
                    if (job.UserID == jobpostuserid)
                    {
                        var application = JobApplicationServices.AppliedJobByUser(jobid, userid);
                        if (application != null)
                        {
                            application.ApplicationStatus = status;
                            bool rtn = JobApplicationServices.ModifyApplication(application);
                            if (rtn == true)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "User application updated" });
                            }
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new { Msg = "You don't have access to modify" });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid Jobid or Userid or status " });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        // show user his applied job status
        [HttpGet]
        [Route("api/job/applied")]
        public HttpResponseMessage ApplicationsStatus()
        {
            try
            {
                var tk = Request.Headers.Authorization.ToString();
                int userid = AuthServices.GetUserID(tk);
                var appliations = JobApplicationServices.UserApplications(userid);
                return Request.CreateResponse(HttpStatusCode.OK, appliations);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [Admin]
        [HttpGet]
        [Route("api/job/reports/monthly_jobtpostcount")]
        public HttpResponseMessage GetMonthlyPostCountForCurrentYear()
        {
            try
            {
                var monthlyPostCounts = JobServices.GetMonthlyPostCountForCurrentYear();

                if (monthlyPostCounts != null && monthlyPostCounts.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, monthlyPostCounts);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No data available for the current year." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
