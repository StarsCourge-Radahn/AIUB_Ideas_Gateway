using AutoMapper;
using BLL.DTOs;
using DLL;
using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class CvServices
    {
        public static bool CreateCV(int userId)
        {
            var cvdto = new CvDTO
            {
                userId = userId
            };
            
            var mapper = MappingService<CvDTO, CV>.GetMapper();
            var cv = mapper.Map<CV>(cvdto);

            var rtn = DataAccessFactory.CvDataAccess().Create(cv);
            return rtn;
        }

        public static CvDTO CVGetbyId(int id)
        {
            var cv = DataAccessFactory.CvDataAccess().GetById(id);

            var mapper = MappingService<CV, CvDTO>.GetMapper();
            var rtn = mapper.Map<CvDTO>(cv);
            return rtn;
        }

        public static CVInfoDTO GetByID(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AcademicQualification, AcademicQualificationDTO>();
                cfg.CreateMap<Award, AwardDTO>();
                cfg.CreateMap<Experience, ExperienceDTO>();
                cfg.CreateMap<Skill, SkillDTO>();
                cfg.CreateMap<ThesisPaper, ThesisPaperDTO>();

            });

            var mapper = new Mapper(config);

            var acd = DataAccessFactory.AcademicDataAccess().GetByCVID(id);
            var award = DataAccessFactory.AwardDataAccess().GetByCVID(id);
            var exp = DataAccessFactory.ExperienceDataAccess().GetByCVID(id);
            var skill = DataAccessFactory.SkillDataAccess().GetByCVID(id);
            var thesis = DataAccessFactory.ThesisDataAccess().GetByCVID(id);

            // Create a new CVInfoDTO object and populate its properties
            var cvInfo = new CVInfoDTO
            {
                // Set the user ID accordingly

                AcademicQualifications = mapper.Map<List<AcademicQualificationDTO>>(acd),
                Awards = mapper.Map<List<AwardDTO>>(award),
                Experiences = mapper.Map<List<ExperienceDTO>>(exp),
                Skills = mapper.Map<List<SkillDTO>>(skill),
                ThesisPapers = mapper.Map<List<ThesisPaperDTO>>(thesis)
            };

            return cvInfo;

        }

        // AcademicQualification
        public static bool CreateAcademic(AcademicQualificationDTO academicQualificationDTO)
        {

            var mapper = MappingService<AcademicQualificationDTO, AcademicQualification>.GetMapper();

            var academic = mapper.Map<AcademicQualification>(academicQualificationDTO);
            var success = DataAccessFactory.AcademicDataAccess().Create(academic);

            return success;
        }

        public static List<AcademicQualificationDTO> AcademicByCvId(int cvId)
        {
            var acd = DataAccessFactory.AcademicDataAccess().GetByCVID(cvId);

            var mapper = MappingService<AcademicQualification, AcademicQualificationDTO>.GetMapper();
            var result = mapper.Map<List<AcademicQualificationDTO>>(acd);
            return result;
        }
        public static bool DeleteAcademic(int id)
        {
            var result = DataAccessFactory.AcademicDataAccess().Delete(id);
            return result;
        }

        // CreateAward
        public static bool CreateAward(AwardDTO awardDTO)
        {
            var mapper = MappingService<AwardDTO, Award>.GetMapper();

            var award = mapper.Map<Award>(awardDTO);
            var success = DataAccessFactory.AwardDataAccess().Create(award);

            return success;
        }

        public static List<AwardDTO> AwardByCvId(int cvId)
        {
            var acd = DataAccessFactory.AwardDataAccess().GetByCVID(cvId);

            var mapper = MappingService<Award, AwardDTO>.GetMapper();
            var result = mapper.Map<List<AwardDTO>>(acd);
            return result;
        }

        public static bool DeleteAward(int id)
        {
            var result = DataAccessFactory.AwardDataAccess().Delete(id);
            return result;
        }

        //Experience......
        public static bool CreateExperience(ExperienceDTO experienceDTO)
        {
            var mapper = MappingService<ExperienceDTO, Experience>.GetMapper();

            var experiences = mapper.Map<Experience>(experienceDTO);
            var success = DataAccessFactory.ExperienceDataAccess().Create(experiences);

            return success;
        }
        public static List<ExperienceDTO> ExperienceByCvId(int cvId)
        {
            var acd = DataAccessFactory.ExperienceDataAccess().GetByCVID(cvId);
            var mapper = MappingService<Experience, ExperienceDTO>.GetMapper();
            var result = mapper.Map<List<ExperienceDTO>>(acd);
            return result;
        }
        public static bool DeleteExperience(int id)
        {
            var result = DataAccessFactory.ExperienceDataAccess().Delete(id);
            return result;
        }

        // Skil...................
        public static bool CreateSkill(SkillDTO skillDTO)
        {
            var mapper = MappingService<SkillDTO, Skill>.GetMapper();

            var skill = mapper.Map<Skill>(skillDTO);
            var success = DataAccessFactory.SkillDataAccess().Create(skill);

            return success;
        }
        public static List<SkillDTO> SkillByCvId(int cvId)
        {
            var acd = DataAccessFactory.SkillDataAccess().GetByCVID(cvId);

            var mapper = MappingService<Skill, SkillDTO>.GetMapper();
            var result = mapper.Map<List<SkillDTO>>(acd);
            return result;
        }
        public static bool DeleteSkill(int id)
        {
            var result = DataAccessFactory.SkillDataAccess().Delete(id);
            return result;
        }
        //ThesisPaper
        public static bool CreateThesis(ThesisPaperDTO thesisPaperDTO)
        {
            var mapper = MappingService<ThesisPaperDTO, ThesisPaper>.GetMapper();

            var thesis = mapper.Map<ThesisPaper>(thesisPaperDTO);
            var success = DataAccessFactory.ThesisDataAccess().Create(thesis);

            return success;
        }

        public static List<ThesisPaperDTO> ThesisByCvId(int cvId)
        {
            var acd = DataAccessFactory.ThesisDataAccess().GetByCVID(cvId);
            var mapper = MappingService<ThesisPaper, ThesisPaperDTO>.GetMapper();
            var result = mapper.Map<List<ThesisPaperDTO>>(acd);
            return result;
        }
        public static bool DeleteThesis(int id)
        {
            var result = DataAccessFactory.ThesisDataAccess().Delete(id);
            return result;
        }

        // Find by id

        public static AcademicQualificationDTO AcademicQualificationById(int id)
        {
            var academicQualification = DataAccessFactory.AcademicDataAccess().GetById(id);

            var mapper = MappingService<AcademicQualification, AcademicQualificationDTO>.GetMapper();
            var rtn = mapper.Map<AcademicQualificationDTO>(academicQualification);
            return rtn;
        }
        public static AwardDTO AwardById(int id)
        {
            var award = DataAccessFactory.AwardDataAccess().GetById(id);

            var mapper = MappingService<Award, AwardDTO>.GetMapper();
            var rtn = mapper.Map<AwardDTO>(award);
            return rtn;
        }

        public static ExperienceDTO ExperienceById(int id)
        {
            var experience = DataAccessFactory.ExperienceDataAccess().GetById(id);
            
            var mapper = MappingService<Experience, ExperienceDTO>.GetMapper();
            var rtn = mapper.Map<ExperienceDTO>(experience);
            return rtn;
        }
        public static SkillDTO SkillById(int id)
        {
            var skill = DataAccessFactory.SkillDataAccess().GetById(id);
            
            var mapper = MappingService<Skill, SkillDTO>.GetMapper();
            var rtn = mapper.Map<SkillDTO>(skill);
            return rtn;
        }

        public static ThesisPaperDTO ThesisPaperById(int id)
        {
            var thesis = DataAccessFactory.ThesisDataAccess().GetById(id);
            
            var mapper = MappingService<ThesisPaper, ThesisPaperDTO>.GetMapper();
            var rtn = mapper.Map<ThesisPaperDTO>(thesis);
            return rtn;
        }



        // Update

        public static bool UpdateAcademicQualification(AcademicQualificationDTO academicQualification)
        {
            var mapper = MappingService<AcademicQualificationDTO, AcademicQualification>.GetMapper();

            var updatedAcademicQualification = mapper.Map<AcademicQualification>(academicQualification);

            bool success = DataAccessFactory.AcademicDataAccess().Update(updatedAcademicQualification);
            return success;
        }

        public static bool UpdateAward(AwardDTO award)
        {
            var mapper = MappingService<AwardDTO, Award>.GetMapper();

            var updatedAward = mapper.Map<Award>(award);

            bool success = DataAccessFactory.AwardDataAccess().Update(updatedAward);
            return success;
        }

        public static bool UpdateExperience(ExperienceDTO experience)
        {
            var mapper = MappingService<ExperienceDTO, Experience>.GetMapper();

            var updatedExperience = mapper.Map<Experience>(experience);

            bool success = DataAccessFactory.ExperienceDataAccess().Update(updatedExperience);
            return success;
        }
        public static bool UpdateSkill(SkillDTO skill)
        {
            var mapper = MappingService<SkillDTO, Skill>.GetMapper();

            var updatedSkill = mapper.Map<Skill>(skill);

            bool success = DataAccessFactory.SkillDataAccess().Update(updatedSkill);
            return success;
        }
        public static bool UpdateThesis(ThesisPaperDTO thesis)
        {
            var mapper = MappingService<ThesisPaperDTO, ThesisPaper>.GetMapper();

            var updatedThesis = mapper.Map<ThesisPaper>(thesis);

            bool success = DataAccessFactory.ThesisDataAccess().Update(updatedThesis);
            return success;
        }
    }
}
