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
    [LoggedIn]
    public class CVController : ApiController
    {
        [HttpPost]
        [Route("api/cv/{id}")]
        public HttpResponseMessage CVById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var token = Request.Headers.Authorization.ToString();
                    var data = CvServices.GetByID(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid cv id!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }

        //AcademicQualification
        [HttpPost]
        [Route("api/cv/createacademic")]  // Create Academic Qualification
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

        [HttpPost]
        [Route("api/cv/academic/{id}")] // by cv id 
        public HttpResponseMessage AcademicByCvId(int id)
        {
            try
            {
                if (id > 0)
                {
                    var token = Request.Headers.Authorization.ToString();
                    var data = CvServices.AcademicByCvId(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid id!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }

        [HttpPost]
        [Route("api/cv/academic/delete/{id}")] // DeleteAcademicQualification by id
        public HttpResponseMessage DeleteAcademic(int id)
        {
            try
            {
                if (id > 0)
                {
                    var data = CvServices.DeleteAcademic(id);
                    if (data == true)
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete Successfully!" });
                    else
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Delete." });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid id!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }


        //Award

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

        [HttpPost]
        [Route("api/cv/award/{id}")] // by cv id 
        public HttpResponseMessage AwardByCvId(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.AwardByCvId(id);
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
        [HttpPost]
        [Route("api/cv/createexperience")]  // Create 
        public HttpResponseMessage CreateExperience(ExperienceDTO obj)
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

        [HttpPost]
        [Route("api/cv/experience/{id}")] // by cv id 
        public HttpResponseMessage ExperienceByCvId(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.ExperienceByCvId(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }

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


        [HttpPost]
        [Route("api/cv/skill/{id}")] // by cv id 
        public HttpResponseMessage SkillByCvId(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.SkillByCvId(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }


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


        [HttpPost]
        [Route("api/cv/createthesis")]  // Create 
        public HttpResponseMessage CreateThesis(ThesisPaperDTO obj)
        {
            if (obj.Title != null && obj.CoAuthors != null)//&& obj.PublicationDate != null)// && obj.DateReceived != null)
            {
                try
                {
                    var token = Request.Headers.Authorization.ToString();
                    var userId = AuthServices.GetUserID(token);

                    var cv = CvServices.CVGetbyId(userId);
                    if (cv != null)
                    {
                        obj.CVId = cv.CVId;
                        obj.PublicationDate = DateTime.Now;
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


        [HttpPost]
        [Route("api/cv/thesis/{id}")] // by cv id 
        public HttpResponseMessage ThesisByCvId(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.ThesisByCvId(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }


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
        // Find by id................

        [HttpPost]
        [Route("api/academicqualification/{id}")]  // Find AcademicQualification by ID
        public HttpResponseMessage AcademicQualificationById(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.AcademicQualificationById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }


        [HttpPost]
        [Route("api/award/{id}")]  // Find Award by ID
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


        [HttpPost]
        [Route("api/experience/{id}")]  // Find Experience by ID
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


        [HttpPost]
        [Route("api/skill/{id}")]  // Find Skill by ID
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


        [HttpPost]
        [Route("api/thesis/{id}")]  // Find Thesis by ID
        public HttpResponseMessage ThesisById(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var data = CvServices.ThesisPaperById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }




        // Update All...............
        [HttpPost]
        [Route("api/academic/update/{id}")] // Update AcademicQualification by ID
        public HttpResponseMessage UpdateAcademicQualification(int id, AcademicQualificationDTO updatedAcademic)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var userId = AuthServices.GetUserID(token);

                var existingAcademic = CvServices.AcademicQualificationById(id);

                if (existingAcademic == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Academic qualification not found or you don't have permission to update." });
                }

                // Update the properties of the existing AcademicQualification with the updated values

                updatedAcademic.QualificationId = id;
                bool success = CvServices.UpdateAcademicQualification(updatedAcademic);

                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Academic qualification updated successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Failed to update academic qualification." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }


        [HttpPost]
        [Route("api/award/update/{id}")] // Update Award by ID
        public HttpResponseMessage UpdateAward(int id, AwardDTO updatedAward)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var userId = AuthServices.GetUserID(token);

                var existingAward = CvServices.AwardById(id);

                if (existingAward == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Award not found or you don't have permission to update." });
                }

                // Update other properties as needed
                updatedAward.AwardId = id;
                bool success = CvServices.UpdateAward(updatedAward);

                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Award updated successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Failed to update award." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }


        [HttpPost]
        [Route("api/experience/update/{id}")] // Update Experience by ID
        public HttpResponseMessage UpdateExperience(int id, ExperienceDTO updatedExperience)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var userId = AuthServices.GetUserID(token);

                var existingExperience = CvServices.ExperienceById(id);

                if (existingExperience == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Experience not found or you don't have permission to update." });
                }
                updatedExperience.ExperienceId = id;
                bool success = CvServices.UpdateExperience(updatedExperience);

                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Experience updated successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Failed to update experience." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }


        [HttpPost]
        [Route("api/skill/update/{id}")] // Update Skill by ID
        public HttpResponseMessage UpdateSkill(int id, SkillDTO updatedSkill)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var userId = AuthServices.GetUserID(token);

                var existingSkill = CvServices.SkillById(id);

                if (existingSkill == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Skill not found or you don't have permission to update." });
                }

                // Update the properties of the existing Skill with the updated values
                updatedSkill.SkillId = id;
                bool success = CvServices.UpdateSkill(updatedSkill);

                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Skill updated successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Failed to update skill." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }


        [HttpPost]
        [Route("api/thesis/update/{id}")] // Update Thesis by ID
        public HttpResponseMessage UpdateThesis(int id, ThesisPaperDTO updatedThesis)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var userId = AuthServices.GetUserID(token);

                var existingThesis = CvServices.ThesisPaperById(id);

                if (existingThesis == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Thesis not found or you don't have permission to update." });
                }

                // Update the properties of the existing Thesis with the updated values
                updatedThesis.ThesisId = id;
                bool success = CvServices.UpdateThesis(updatedThesis);

                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Thesis updated successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Failed to update thesis." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
    }
}