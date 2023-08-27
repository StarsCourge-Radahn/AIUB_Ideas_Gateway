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
        //                                ####### User centric operations #########
        // Admin can see all users
        [HttpGet]
        [Route("api/admin/user/all")]
        public HttpResponseMessage Allusers()
        {
            try
            {
                var users = UserServices.GetUsers();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        // Admin has access to individual user
        [HttpPost]
        [Route("api/admin/user/{id}")]
        public HttpResponseMessage ByUserId(int id)
        {
            try
            {
                var user = UserServices.GetUser(id);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        //total active user

        [HttpGet]
        [Route("api/admin/user/active")]
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

        //                                ####### Post centric operations #########

        // Admin can access any individual post
        [HttpPost]
        [Route("api/admin/post/{id}")]
        public HttpResponseMessage AdminPost(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var adminID = AuthServices.IsAdmin(token);
                var data = PostServices.GetPost(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        // Admin can create post [redandent]
        [HttpPost]
        [Route("api/admin/post/create")]
        public HttpResponseMessage AdminCreate(PostDTO obj)
        {
            if (obj.Title != null && obj.Content != null)
            {
                try
                {
                    var token = Request.Headers.Authorization.ToString();
                    var adminID = AuthServices.GetUserID(token);
                    obj.CreatedAt = DateTime.Now;
                    obj.UpdatedAt = null;
                    obj.UserID = adminID;

                    var data = PostServices.CreatePost(obj);
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
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid Post object" });
            }
        }

        // Admin can update any post
        [HttpPost]
        [Route("api/admin/post/update")]
        public HttpResponseMessage AdminPostUpdate(PostDTO obj)
        {
            try
            {
                if (obj != null && obj.PostID > 0)
                {
                    var post = PostServices.GetPost(obj.PostID);
                    if (post != null)
                    {
                        post.Title = obj.Title;
                        post.Content = obj.Content;
                        post.UpdatedAt = DateTime.Now;
                        post.IsBan = obj.IsBan;
                        post.IsDeleted = obj.IsDeleted;

                        var res = PostServices.UpdatePost(post);
                        if (res == true)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Post Updated" });
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in post update" });
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Post not found!" });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid post id or post object" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }

        //Admin post delete
        [HttpPost]
        [Route("api/admin/post/delete/{id}")]
        public HttpResponseMessage AdminDeletePost(int id)
        {
            try
            {
                if (id > 0)
                {
                    var post = PostServices.GetPost(id);
                    if (post != null)
                    {
                        var res = PostServices.DeletePost(post.PostID);
                        if (res == true)
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Post deleted" });
                        else
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in post delete" });
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Post not found with this 'ID'." });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid post id" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        //                                ####### Job centric operations #########

        //Admin can see job post
        [HttpPost]
        [Route("api/admin/jobpost/{id}")]
        public HttpResponseMessage AdminJobPost(int id)
        {
            try
            {
                var data = JobServices.JobPost(id);
                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Job post not found!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }



        //Admin  create job posts
        [HttpPost]
        [Route("api/admin/jobpost/create")]
        public HttpResponseMessage AdminJobPostCreate(JobDTO obj)
        {
            if (obj.Title != null && obj.Description != null)
            {
                try
                {
                    var token = Request.Headers.Authorization.ToString();
                    var adminID = AuthServices.GetUserID(token);
                    obj.CreatedAt = DateTime.Now;
                    obj.UpdatedAt = null;
                    obj.UserID = adminID;

                    var data = JobServices.CreateJobPost(obj);
                    if (data == true)
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Job Created!" });
                    else
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Creation of job" });
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid job object" });
        }

        //Admin can update any job post
        [HttpPost]
        [Route("api/admin/jobpost/update")]
        public HttpResponseMessage AdminJobUpdate(JobDTO obj)
        {
            try
            {
                if (obj != null && obj.JobID > 0)
                {
                    var job = JobServices.JobPost(obj.JobID);
                    if (job != null)
                    {
                        job.Title = obj.Title;
                        job.Description = obj.Description;
                        job.UpdatedAt = DateTime.Now;
                        job.IsBan = obj.IsBan;
                        job.IsDeleted = obj.IsDeleted;

                        var res = JobServices.UpdateJobPost(job);
                        if (res == true)
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Job Updated" });
                        else
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in job update" });
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No job found with this id!" });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid post object" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }


        //Admin delete job posts
        [HttpPost]
        [Route("api/admin/jobpost/delete/{id}")]
        public HttpResponseMessage AdminJobDelete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var job = JobServices.JobPost(id);
                    if (job != null)
                    {
                        var res = JobServices.DeleteJobPost(id);
                        if (res == true)
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Job Deleted" });
                        else
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Job delete" });
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No job found with this id!" });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid job id!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }


        //                                ####### Statistical operations #########

        [HttpGet]
        [Route("api/admin/totalcount/users")]
        public HttpResponseMessage TotalUser()
        {
            try
            {
                var cnt = UserServices.CountUsers();
                return Request.CreateResponse(HttpStatusCode.OK, cnt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message.ToString());
            }
        }


        //Admin can see total number of posts available
        [HttpGet]
        [Route("api/admin/totalcount/post")]
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

        //Admin see total number of job posts
        [HttpGet]
        [Route("api/admin/totalcount/job")]
        public HttpResponseMessage TotalJobPosts()
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


        //Getting posts with in a date range
        [HttpGet]
        [Route("api/admin/post/within/{today}/{uptoDay}")]
        public HttpResponseMessage GetPostsWithinRange(string today, string uptoDay)
        {
            DateTime parsedToday;
            DateTime parsedUptoDay;

            if (DateTime.TryParse(today, out parsedToday) && DateTime.TryParse(uptoDay, out parsedUptoDay))
            {
                try
                {
                    var posts = PostServices.GetPostsInRange(parsedToday, parsedUptoDay);
                    if (posts != null)
                        return Request.CreateResponse(HttpStatusCode.OK, posts);
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No post found!" });
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid date value. Please pass dates as 'YYYY-MM-DD' format!" });
        }


        // Getting job post with in a rang
        [HttpGet]
        [Route("api/admin/job/within/{today}/{uptoDay}")]
        public HttpResponseMessage JobsWithinRange(string today, string uptoDay)
        {
            DateTime parsedToday;
            DateTime parsedUptoDay;

            if (DateTime.TryParse(today, out parsedToday) && DateTime.TryParse(uptoDay, out parsedUptoDay))
            {
                try
                {
                    var jobs = JobServices.GetPostsInRange(parsedToday, parsedUptoDay);
                    if (jobs != null)
                        return Request.CreateResponse(HttpStatusCode.OK, jobs);
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No job found!" });
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid date value. Please pass dates as 'YYYY-MM-DD' format!" });
        }


        //                                #######  Access revoke operations #########


        //Admin Can temporary ban users can be login but other activities will be disabled until the ban time expires
        [HttpPost]
        [Route("api/admin/ban/user/{uid}")]
        public HttpResponseMessage BanUser(int uid)
        {
            try
            {
                if (uid > 0)
                {
                    var user = UserServices.GetUser(uid);
                    if (user != null)
                    {
                        user.IsBan = true;
                        bool rtn = UserServices.UpdateUser(user);
                        if (rtn == true)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "User information update & user is ban now!" });
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in user ban!" });
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "User doesn't exists. Please check the user id!" });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid user id" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        // Permanent ban cannot create account with same email and username

        [HttpPost]
        [Route("api/admin/tempban/user/{uid}")]
        public HttpResponseMessage TemporaryBanUser(int uid)
        {
            try
            {
                if (uid > 0)
                {
                    var user = UserServices.GetUser(uid);
                    if (user != null)
                    {
                        user.TemporaryBan = true;
                        bool rtn = UserServices.UpdateUser(user);
                        if (rtn == true)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "User information update & user is temporary ban now!" });
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in user temporary ban!" });
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "User doesn't exists. Please check the user id!" });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid user id!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("api/admin/unban/user/{uid}")]
        public HttpResponseMessage UnbanUser(int uid)
        {
            try
            {
                if (uid > 0)
                {
                    var user = UserServices.GetUser(uid);
                    if (user != null)
                    {
                        user.IsBan = false;
                        bool rtn = UserServices.UpdateUser(user);
                        if (rtn == true)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "User information update & user is unbanned now!" });
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in user un ban!" });
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "User not found!" });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid user id" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("api/admin/tempunban/user/{uid}")]
        public HttpResponseMessage TemporaryUnBanUser(int uid)
        {
            try
            {
                if (uid > 0)
                {
                    var user = UserServices.GetUser(uid);
                    if (user != null)
                    {
                        user.TemporaryBan = false;
                        bool rtn = UserServices.UpdateUser(user);
                        if (rtn == true)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "User information update & removed temporary ban now!" });
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in temporary unban!" });
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "User doesn't exists. Please check the user id!" });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid user id!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message.ToString());
            }

        }

        [HttpPost]
        [Route("api/admin/ban/post/{postid}")]
        public HttpResponseMessage BanPost(int postid)
        {
            try
            {
                if (postid > 0)
                {
                    var post = PostServices.GetPost(postid);
                    if (post != null)
                    {
                        post.IsBan = true;
                        bool rtn = PostServices.UpdatePost(post);
                        if (rtn == true)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Post info updated and post is ban now!" });
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in post ban" });
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Post not found" });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid post id" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }


        [HttpPost]
        [Route("api/admin/unban/post/postid")]
        public HttpResponseMessage UnbanPost(int postid)
        {
            if (postid > 0)
            {
                try
                {
                    var post = PostServices.GetPost(postid);
                    if (post != null)
                    {
                        post.IsBan = false;
                        bool rtn = PostServices.UpdatePost(post);
                        if (rtn == true)
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Post is unbanned!" });
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Something went wrong in unban post!" });
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Post not found" });
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        [HttpPost]
        [Route("api/admin/ban/job/{jobid}")]
        public HttpResponseMessage BanJob(int jobid)
        {

            try
            {
                if (jobid > 0)
                {
                    var job = JobServices.JobPost(jobid);
                    if (job != null)
                    {
                        job.IsBan = true;
                        bool rtn = JobServices.UpdateJobPost(job);
                        if (rtn == true)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Job is banned now!" });
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Something went wrong in job ban!" });
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No job found with this id!" });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid Job id!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }

        // Unban a job post
        [HttpPost]
        [Route("api/admin/unban/job/{jobid}")]
        public HttpResponseMessage UnbanJob(int jobid)
        {
            try
            {
                if (jobid > 0)
                {
                    var job = JobServices.JobPost(jobid);
                    if (job != null)
                    {
                        job.IsBan = false;
                        bool rtn = JobServices.UpdateJobPost(job);
                        if (rtn == true)
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Job is unbanned now!" });
                        else
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in job unban!" }); ;

                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Job not found!" });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

    }
}
