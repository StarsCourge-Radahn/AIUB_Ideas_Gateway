using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AIUB_Ideas_Gateway.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("api/home")]
        [Route("api/aig")]
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
        [Route("api/home/search/{query}")]
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
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Nothing found related to the query :( !" });
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Invalid search petameter");
        }
    }
}
