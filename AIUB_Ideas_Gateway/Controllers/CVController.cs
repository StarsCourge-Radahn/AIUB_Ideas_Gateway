using AIUB_Ideas_Gateway.AuthFilters;
using AIUB_Ideas_Gateway.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using BLL.DTOs;

namespace AIUB_Ideas_Gateway.Controllers
{
    public class CVController : ApiController
    {

        [LoggedIn]
        [HttpPost]
        [Route("api/cv/{id}")]  // Find comment by comment id (Admin)
        public HttpResponseMessage CVById(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.GetByID(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }

        //AcademicQualification
        [LoggedIn]
        [HttpPost]
        [Route("api/cv/createacademic")]  // Create AcademicQualification
        public HttpResponseMessage CreateAcademic(AcademicQualificationDTO obj)
        {
            if (obj.Degree != null && obj.Institution != null)
            {
                try
                {
                    var token = Request.Headers.Authorization.ToString();
                    var userId = AuthServices.GetUserID(token);

                    var cv = CvServices.CVGetbyId(userId);
                    if (cv != null)
                    {
                        obj.CVId = cv.CVId;
                        obj.StartDate = DateTime.Now;
                        var data = CvServices.CreateAcademic(obj);
                        if (data == true)
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Academic Qualification Add......." });
                        else
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in adding Acadenic Qualification///" });
                    }
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in adding Acadenic Qualification" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid Academic Qualification object" });
            }
        }

        [LoggedIn]
        [HttpPost]
        [Route("api/cv/academic/{id}")] // by cv id 
        public HttpResponseMessage AcademicById(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.AcademicById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }

        [LoggedIn]
        [HttpPost]
        [Route("api/cv/academic/delete/{id}")] // DeleteAcademicQualification by id
        public HttpResponseMessage DeleteAcademic(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.DeleteAcademic(id);
                if (data == true)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete Successfully!" });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Delete." });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }
        //Award

        [LoggedIn]
        [HttpPost]
        [Route("api/cv/createaward")]  // Create Award
        public HttpResponseMessage CreateAward(AwardDTO obj)
        {
            if (obj.AwardName != null && obj.AwardingInstitution != null)// && obj.DateReceived != null)
            {
                try
                {
                    var token = Request.Headers.Authorization.ToString();
                    var userId = AuthServices.GetUserID(token);

                    var cv = CvServices.CVGetbyId(userId);
                    if (cv != null)
                    {
                        obj.CVId = cv.CVId;
                        obj.DateReceived = DateTime.Now; //
                        var data = CvServices.CreateAward(obj);
                        if (data == true)
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Award  Added" });
                        else
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in adding Award " });
                    }
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in adding Award" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid Award object" });
            }
        }

        [LoggedIn]
        [HttpPost]
        [Route("api/cv/award/{id}")] // by cv id 
        public HttpResponseMessage AwardById(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.AwardById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }


        [LoggedIn]
        [HttpPost]
        [Route("api/cv/award/delete/{id}")] // DeleteAward by id
        public HttpResponseMessage DeleteAward(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.DeleteAward(id);
                if (data == true)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete Successfully!" });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Delete." });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }




        // Experience
        [LoggedIn]
        [HttpPost]
        [Route("api/cv/createexperience")]  // Create 
        public HttpResponseMessage CreateEperience(ExperienceDTO obj)
        {
            if (obj.CompanyName != null && obj.Position != null)// && obj.DateReceived != null)
            {
                try
                {
                    var token = Request.Headers.Authorization.ToString();
                    var userId = AuthServices.GetUserID(token);

                    var cv = CvServices.CVGetbyId(userId);
                    if (cv != null)
                    {
                        obj.CVId = cv.CVId;
                        obj.StartDate = DateTime.Now;
                        var data = CvServices.CreateExperience(obj);
                        if (data == true)
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Experience  Added" });
                        else
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in adding Experience" });
                    }
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in adding Experience" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid Experience object" });
            }
        }

        [LoggedIn]
        [HttpPost]
        [Route("api/cv/experience/{id}")] // by cv id 
        public HttpResponseMessage ExperienceById(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.ExperienceById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }
        [LoggedIn]
        [HttpPost]
        [Route("api/cv/experience/delete/{id}")] // DeleteExperience by id
        public HttpResponseMessage DeleteExperience(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.DeleteExperience(id);
                if (data == true)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete Successfully!" });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Delete." });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }




        // Skill 

        [LoggedIn]
        [HttpPost]
        [Route("api/cv/createskill")]  // Create 
        public HttpResponseMessage CreateSkill(SkillDTO obj)
        {
            if (obj.SkillName != null && obj.Proficiency != null)// && obj.DateReceived != null)
            {
                try
                {
                    var token = Request.Headers.Authorization.ToString();
                    var userId = AuthServices.GetUserID(token);

                    var cv = CvServices.CVGetbyId(userId);
                    if (cv != null)
                    {
                        obj.CVId = cv.CVId;
                        var data = CvServices.CreateSkill(obj);
                        if (data == true)
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Skill  Added" });
                        else
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in adding Skill" });
                    }
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in adding Skill" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid Skill object" });
            }
        }

        [LoggedIn]
        [HttpPost]
        [Route("api/cv/skill/{id}")] // by cv id 
        public HttpResponseMessage SkillById(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.SkillById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }

        [LoggedIn]
        [HttpPost]
        [Route("api/cv/skill/delete/{id}")] // DeleteSkill by id
        public HttpResponseMessage DeleteSkill(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.DeleteSkill(id);
                if (data == true)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete Successfully!" });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Delete." });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        // Thesispaper............

        [LoggedIn]
        [HttpPost]
        [Route("api/cv/createthesis")]  // Create 
        public HttpResponseMessage CreateThesis(ThesisPaperDTO obj)
        {
            if (obj.Title != null && obj.CoAuthors!=null)//&& obj.PublicationDate != null)// && obj.DateReceived != null)
            {
                try
                {
                    var token = Request.Headers.Authorization.ToString();
                    var userId = AuthServices.GetUserID(token);

                    var cv = CvServices.CVGetbyId(userId);
                    if (cv != null)
                    {
                        obj.CVId = cv.CVId;
                        obj.PublicationDate=DateTime.Now;   
                        var data = CvServices.CreateThesis(obj);
                        if (data == true)
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Thesis  Added" });
                        else
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in adding Thesis" });
                    }
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in adding Thesis" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid Thesis object" });
            }
        }

        [LoggedIn]
        [HttpPost]
        [Route("api/cv/thesis/{id}")] // by cv id 
        public HttpResponseMessage ThesisById(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.ThesisById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }
        [LoggedIn]
        [HttpPost]
        [Route("api/cv/thesis/delete/{id}")] // DeleteThesis by id
        public HttpResponseMessage DeleteThesis(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.DeleteThesis(id);
                if (data == true)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete Successfully!" });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Delete." });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

    }
}