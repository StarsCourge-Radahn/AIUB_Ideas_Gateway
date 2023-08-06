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
    public class PostController : ApiController
    {
        [HttpPost]
        [Route("api/post/{id}")]
        public HttpResponseMessage Post(int id)
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
        [Route("api/post/create")]
        public HttpResponseMessage Create(PostModel obj)
        {
            try
            {
                //var data = PostServices.CreatePost();
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
        //Admin post by id
        [HttpPost]
        [Route("api/admin/post/{id}")]
        public HttpResponseMessage AdminPost(int id) 
        {
            try
            {
                var data = PostServices.Post(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
        //Admin post create
        [HttpPost]
        [Route("api/admin/post/create")]
        public HttpResponseMessage AdminCreate(PostModel obj) 
        {
            try
            {
                var data = false;
                if (data == true)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Post Created!" });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Creation of post" });
            }
            catch( Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
        //Admin post delete
        [HttpPost]
        [Route("api/admin/post/delete")]
        public HttpResponseMessage AdminDelete(int id) 
        {
            try
            {
                var data = PostServices.DeletePost(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
        //Admin see total number of posts
        [HttpPost]
        [Route("api/admin/post/totalpost")]
        public HttpResponseMessage AdminGet(PostModel obj)
        {
            try
            {
                var data = PostServices.CountPosts();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message.ToString());
            }
        }
    }
}
