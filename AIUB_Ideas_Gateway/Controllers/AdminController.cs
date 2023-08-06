﻿using AIUB_Ideas_Gateway.AuthFilters;
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
        //Admin post create
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
    }
}