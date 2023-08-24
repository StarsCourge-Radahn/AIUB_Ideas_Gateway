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
            var jobs = DataAccessFactory.JobDataAccess().GetAll(false);
            if (jobs != null)
            {
                var mapper = MappingService<Job, JobDTO>.GetMapper();
                var rtn = mapper.Map<List<JobDTO>>(jobs);

                return rtn;
            }
            return null;
        }

        public static List<JobDTO> AllJobsPostForAdmin()
        {
            var jobs = DataAccessFactory.JobDataAccess().GetAll(true);
            if (jobs != null)
            {
                var mapper = MappingService<Job, JobDTO>.GetMapper();
                var rtn = mapper.Map<List<JobDTO>>(jobs);

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

            var mapper = MappingService<Job, JobDTO>.GetMapper();
            var rtn = mapper.Map<JobDTO>(job);
            return rtn;
        }

        public static bool CreateJobPost(JobDTO obj)
        {
            try
            {
                var mapper = MappingService<JobDTO, Job>.GetMapper();
                var jb = mapper.Map<Job>(obj);

                var rtn = DataAccessFactory.JobDataAccess().Create(jb);
                return rtn;
            }
            catch (Exception) { return false; }
        }

        public static bool DeleteJobPost(int id)
        {
            try
            {
                var rtn = DataAccessFactory.JobDataAccess().Delete(id);
                return rtn;
            }
            catch (Exception) { return false; }
        }

        public static bool UpdateJobPost(JobDTO obj)
        {
            try
            {
                var job = new Job();

                job.Title = obj.Title;
                job.Description = obj.Description;

                job.CreatedAt = obj.CreatedAt;
                job.UpdatedAt = DateTime.Now;
                job.UserID = obj.UserID;
                job.IsBan = obj.IsBan;

                var rtn = DataAccessFactory.JobDataAccess().Update(job);
                return rtn;
            }
            catch (Exception){ return false; }
        }

        public static List<JobDTO> JobPostSearch(string q)
        {
            var data = DataAccessFactory.JobDataAccess().GetByName(q);

            var mapper = MappingService<Job, JobDTO>.GetMapper();
            var rtn = mapper.Map<List<JobDTO>>(data);
            return rtn;
        }
        public static List<JobDTO> GetPostsInRange(DateTime today, DateTime upto)
        {
            try
            {
                var jobs = DataAccessFactory.JobStatisticalDataAccess().WithInRange(today, upto);
                var mapper = MappingService<Job, JobDTO>.GetMapper();
                var rtn = mapper.Map<List<JobDTO>>(jobs);
                return rtn;
            }
            catch (Exception){ return null; }
        }
    }
}
