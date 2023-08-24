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

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CvDTO, CV>();
            });
            var mapper = new Mapper(config);

            var cv = mapper.Map<CV>(cvdto);
            var rtn = DataAccessFactory.CvDataAccess().Create(cv);
            return rtn;
        }

        public static CvDTO CVGetbyId(int id)
        {
            var cv = DataAccessFactory.CvDataAccess().GetById(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CV, CvDTO>();
            });
            var mapper = new Mapper(config);
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

            var acd = DataAccessFactory.AcademicDataAccess().GetByID(id);
            var award = DataAccessFactory.AwardDataAccess().GetByID(id);
            var exp = DataAccessFactory.ExperienceDataAccess().GetByID(id);
            var skill = DataAccessFactory.SkillDataAccess().GetByID(id);
            var thesis = DataAccessFactory.ThesisDataAccess().GetByID(id);

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


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AcademicQualificationDTO, AcademicQualification>();

            });
            var mapper = new Mapper(config);

            var academic = mapper.Map<AcademicQualification>(academicQualificationDTO);
            var success = DataAccessFactory.AcademicDataAccess().Create(academic);

            return success;
        }



        public static List<AcademicQualificationDTO> AcademicByCvId(int cvId)
        {
            var acd = DataAccessFactory.AcademicDataAccess().GetByID(cvId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AcademicQualification, AcademicQualificationDTO>();
            });

            var mapper = new Mapper(config);
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


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AwardDTO, Award>();

            });
            var mapper = new Mapper(config);

            var award = mapper.Map<Award>(awardDTO);
            var success = DataAccessFactory.AwardDataAccess().Create(award);

            return success;
        }

        public static List<AwardDTO> AwardByCvId(int cvId)
        {
            var acd = DataAccessFactory.AwardDataAccess().GetByID(cvId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Award, AwardDTO>();
            });

            var mapper = new Mapper(config);
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


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ExperienceDTO, Experience>();

            });
            var mapper = new Mapper(config);

            var experiences = mapper.Map<Experience>(experienceDTO);
            var success = DataAccessFactory.ExperienceDataAccess().Create(experiences);

            return success;
        }
        public static List<ExperienceDTO> ExperienceByCvId(int cvId)
        {
            var acd = DataAccessFactory.ExperienceDataAccess().GetByID(cvId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Experience, ExperienceDTO>();
            });

            var mapper = new Mapper(config);
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


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SkillDTO, Skill>();

            });
            var mapper = new Mapper(config);

            var skill = mapper.Map<Skill>(skillDTO);
            var success = DataAccessFactory.SkillDataAccess().Create(skill);

            return success;
        }
        public static List<SkillDTO> SkillByCvId(int cvId)
        {
            var acd = DataAccessFactory.SkillDataAccess().GetByID(cvId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Skill, SkillDTO>();
            });

            var mapper = new Mapper(config);
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


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ThesisPaperDTO, ThesisPaper>();

            });
            var mapper = new Mapper(config);

            var thesis = mapper.Map<ThesisPaper>(thesisPaperDTO);
            var success = DataAccessFactory.ThesisDataAccess().Create(thesis);

            return success;
        }

        public static List<ThesisPaperDTO> ThesisByCvId(int cvId)
        {
            var acd = DataAccessFactory.ThesisDataAccess().GetByID(cvId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ThesisPaper, ThesisPaperDTO>();
            });

            var mapper = new Mapper(config);
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AcademicQualification, AcademicQualificationDTO>();
            });
            var mapper = new Mapper(config);
            var rtn = mapper.Map<AcademicQualificationDTO>(academicQualification);
            return rtn;
        }
        public static AwardDTO AwardById(int id)
        {
            var award = DataAccessFactory.AwardDataAccess().GetById(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Award, AwardDTO>();
            });
            var mapper = new Mapper(config);
            var rtn = mapper.Map<AwardDTO>(award);
            return rtn;
        }

        public static ExperienceDTO ExperienceById(int id)
        {
            var experience = DataAccessFactory.ExperienceDataAccess().GetById(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Experience, ExperienceDTO>();
            });
            var mapper = new Mapper(config);
            var rtn = mapper.Map<ExperienceDTO>(experience);
            return rtn;
        }
        public static SkillDTO SkillById(int id)
        {
            var skill = DataAccessFactory.SkillDataAccess().GetById(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Skill, SkillDTO>();
            });
            var mapper = new Mapper(config);
            var rtn = mapper.Map<SkillDTO>(skill);
            return rtn;
        }

        public static ThesisPaperDTO ThesisPaperById(int id)
        {
            var thesis = DataAccessFactory.ThesisDataAccess().GetById(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ThesisPaper, ThesisPaperDTO>();
            });
            var mapper = new Mapper(config);
            var rtn = mapper.Map<ThesisPaperDTO>(thesis);
            return rtn;
        }



        // Update

        public static bool UpdateAcademicQualification(AcademicQualificationDTO academicQualification)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AcademicQualificationDTO, AcademicQualification>();
            });
            var mapper = new Mapper(config);

            var updatedAcademicQualification = mapper.Map<AcademicQualification>(academicQualification);

            bool success = DataAccessFactory.AcademicDataAccess().Update(updatedAcademicQualification);
            return success;
        }

        public static bool UpdateAward(AwardDTO award)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AwardDTO, Award>();
            });
            var mapper = new Mapper(config);

            var updatedAward = mapper.Map<Award>(award);

            bool success = DataAccessFactory.AwardDataAccess().Update(updatedAward);
            return success;
        }

        public static bool UpdateExperience(ExperienceDTO experience)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ExperienceDTO, Experience>();
            });
            var mapper = new Mapper(config);

            var updatedExperience = mapper.Map<Experience>(experience);

            bool success = DataAccessFactory.ExperienceDataAccess().Update(updatedExperience);
            return success;
        }
        public static bool UpdateSkill(SkillDTO skill)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SkillDTO, Skill>();
            });
            var mapper = new Mapper(config);

            var updatedSkill = mapper.Map<Skill>(skill);

            bool success = DataAccessFactory.SkillDataAccess().Update(updatedSkill);
            return success;
        }
        public static bool UpdateThesis(ThesisPaperDTO thesis)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ThesisPaperDTO, ThesisPaper>();
            });
            var mapper = new Mapper(config);

            var updatedThesis = mapper.Map<ThesisPaper>(thesis);

            bool success = DataAccessFactory.ThesisDataAccess().Update(updatedThesis);
            return success;
        }

    }
}
