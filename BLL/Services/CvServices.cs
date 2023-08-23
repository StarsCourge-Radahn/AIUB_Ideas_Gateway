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
            var cv = DataAccessFactory.CvDataAccess().GetCvById(id);
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



        public static List<AcademicQualificationDTO> AcademicById(int cvId)
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

        public static List<AwardDTO> AwardById(int cvId)
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
        public static List<ExperienceDTO> ExperienceById(int cvId)
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
        public static List<SkillDTO> SkillById(int cvId)
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

        public static List<ThesisPaperDTO> ThesisById(int cvId)
        {
            var acd = DataAccessFactory.ThesisDataAccess().GetByID(cvId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ThesisPaper,ThesisPaperDTO>();
            });

            var mapper = new Mapper(config);
            var result = mapper.Map<List<ThesisPaperDTO>>(acd);
            return result;
        }

    }
}
