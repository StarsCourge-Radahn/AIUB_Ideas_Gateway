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
    [Admin]
    [LoggedIn]
    public class AdminController : ApiController
    {

        [HttpPost]
        [Route("api/admin/post/{id}")]
        public HttpResponseMessage AdminPost(int id)
        {
            try
            {
                var data = PostServices.Post(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("api/admin/post/create")]
        public HttpResponseMessage AdminCreate(PostDTO obj)
        {
            try
            {
                var data = false;
                if (data == true)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Post Created!" });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Creation of post" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
        //Admin post delete
        [HttpPost]
        [Route("api/admin/post/delete/{id}")]
        public HttpResponseMessage AdminDelete(int id)
        {
            try
            {
                var data = PostServices.DeletePost(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
        //Admin see total number of posts
        [HttpGet]
        [Route("api/admin/post/totalpost")]
        public HttpResponseMessage TotalPosts()
        {
            try
            {
                var data = PostServices.CountPosts();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        //Admin see total number of jobposts
        [HttpGet]
        [Route("api/admin/post/totaljobpost")]
        public HttpResponseMessage TotaljobPosts()
        {
            try
            {
                var data = JobServices.CountJobPosts();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        //total active user

        [HttpGet]
        [Route("api/admin/active")]
        public HttpResponseMessage ActiveUsers()
        {
            try
            {
                var res = UserServices.CurrentlyActiveUsers();
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }


        //Admin Can temporary ban users can be loggedin but other activities will be disabled until the ban time expires

        [HttpGet]
        [Route("api/admin/ban/users/")]
        public HttpResponseMessage BanUsers()
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [Route("api/admin/ban/user/{userid}")]
        public HttpResponseMessage BanUser(int userid)
        {
            try
            {
                var user = user
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
        // Permanent ban cannot create account with same email and username

        [HttpPost]
        [Route("api/admin/tempban/user/{userid}")]
        public HttpResponseMessage TmeporayBanUser(int userid)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [Route("api/admin/ban/post/{postid}")]
        public HttpResponseMessage BanPost(int postid)
        {

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
        // Permanent ban cannot create account with same email and username

        [HttpPost]
        [Route("api/admin/tempban/post/{postid}")]
        public HttpResponseMessage TmeporayBanPost(int postid)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }


        [HttpPost]
        [Route("api/admin/ban/job/{jobid}")]
        public HttpResponseMessage BanJob(int jobid)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
        // Permanent ban cannot create account with same email and username

        [HttpPost]
        [Route("api/admin/tempban/job/{jobid}")]
        public HttpResponseMessage TmeporayBanJob(int postid)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        //comment
        //Complex feature: Statistic analyze of total active users their post, job post last 1 week or 3 days.  
        // for implementing this we have different search login at user / post/




        //Admin see job posts
        [HttpPost]
        [Route("api/admin/jobpost/{id}")]
        public HttpResponseMessage AdminjobPost(int id)
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
        //Admin  create job posts
        [HttpPost]
        [Route("api/admin/jobpost/create")]
        public HttpResponseMessage AdminjobpostCreate(JobDTO obj)
        {
            try
            {
                var data = false;
                if (data == true)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Job Post Created!" });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Creation of Jobpost" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
        //Admin delete job posts

        [HttpPost]
        [Route("api/admin/jobpost/delete/{id}")]
        public HttpResponseMessage AdminjobDelete(int id)
        {
            try
            {
                var data = JobServices.DeleteJobPost(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
    }
}
