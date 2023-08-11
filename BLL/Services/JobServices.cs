using AutoMapper;
using BLL.DTOs;
using DLL.EF.Models;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class JobServices
    {
        public static List<JobDTO> AllJobsPost()
        {
            var Jobs = DataAccessFactory.JobDataAccess().GetAll();
            if (Jobs != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Job, JobDTO>();
                });

                var mapper = new Mapper(config);
                var rtn = mapper.Map<List<JobDTO>>(Jobs);

                return rtn;
            }
            return null;
        }

        public static int CountJobPosts()
        {
            var result = AllJobsPost();
            return result.Count;
        }

        public static JobDTO JobPost(int id)
        {
            var job = DataAccessFactory.JobDataAccess().GetByID(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Job,JobDTO>();
            });
            var mapper = new Mapper(config);
            var rtn = mapper.Map<JobDTO>(job);

            return rtn;
        }

        public static bool CreateJobPost(JobDTO jobdto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JobDTO, Job>();
            });
            var mapper = new Mapper(config);

            var jb = mapper.Map<Job>(jobdto);

            var rtn = DataAccessFactory.JobDataAccess().Create(jb);
            return rtn;
        }

        public static bool DeleteJobPost(int id)
        {
            var rtn = DataAccessFactory.JobDataAccess().Delete(id);
            return rtn;
        }

        public static bool UpdateJobPost(JobDTO obj)
        {
            var jobdto = new JobDTO();

            jobdto.Title = obj.Title;
            jobdto.Description = obj.Description;

            jobdto.CreatedAt = obj.CreatedAt;
            jobdto.UpdatedAt = DateTime.Now;
            jobdto.UserID = obj.UserID;
            jobdto.IsBan = obj.IsBan;
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JobDTO, Job>();
            });
            var mapper = new Mapper(config);

            var job = mapper.Map<Job>(jobdto);

            var rtn = DataAccessFactory.JobDataAccess().Update(job);
            return rtn;
        }

        public static List<JobDTO> JobPostSearch(string q)
        {
            var data = DataAccessFactory.JobDataAccess().GetByName(q);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Job, JobDTO>();
            });
            var mapper = new Mapper(config);
            var rtn = mapper.Map<List<JobDTO>>(data);
            return rtn;
        }

    }
}
