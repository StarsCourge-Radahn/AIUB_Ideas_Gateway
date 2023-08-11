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
    public class CommentController : ApiController
    {
       // [LoggedIn]
        [HttpGet]
        [Route("api/comment/all")]
        public HttpResponseMessage All()
        {
            try
            {
               // var token = Request.Headers.Authorization.ToString();
                var commments = CommentServices.AllComments();
                return Request.CreateResponse(HttpStatusCode.OK, commments);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

        }


       // [LoggedIn]
        [HttpPost]
        [Route("api/comment/create")]
        public HttpResponseMessage Create(CommentDTO obj)
        {
            if (obj.Text != null)
            {
                try
                {
                    // var token = Request.Headers.Authorization.ToString();
                    var userId = 1;//AuthServices.GetUserID(token);
                    obj.CreatedAt = DateTime.Now;
                    obj.UserID = userId;

                    var data = CommentServices.CreateComment(obj);
                    if (data == true)
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Comment Created!" });
                    else
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Creation of Comment" });
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid Comment object" });
            }
        }
       // [LoggedIn]
        [HttpPost]
        [Route("api/comment/{id}")]
        public HttpResponseMessage CommentById(int id)
        {
            try
            {
                //var token = Request.Headers.Authorization.ToString();
                var data = CommentServices.CommentById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }

        // [LoggedIn]
        [HttpPost]
        [Route("api/comment/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                //var token = Request.Headers.Authorization.ToString();
                var data = CommentServices.DeleteComment(id);
                if (data == true)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete Successfully!" });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Delete of Comment" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }
    }
}
