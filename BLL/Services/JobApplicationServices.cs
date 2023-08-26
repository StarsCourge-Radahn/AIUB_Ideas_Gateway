using BLL.DTOs;
using DLL;
using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class JobApplicationServices
    {
        public static bool JobApply(int jobid, int userid)
        {
            try
            {
                var application = new JobApplicationDTO();
                application.JobId = jobid;
                application.UserId = userid;
                application.ApplicationStatus = 0;
                application.AppliedOn = DateTime.Now;

                var mapper = MappingService<JobApplicationDTO, JobApplication>.GetMapper();
                var inp = mapper.Map<JobApplication>(application);
                bool rtn = DataAccessFactory.JobApplyDataAccess().Create(inp);
                return rtn;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //return user applications
        public static List<JobApplicationDTO> UserApplications(int userid)
        {
            try
            {
                var data = DataAccessFactory.JobApplyDataAccess().GetByUserId(userid);
                var mapper= MappingService<JobApplication, JobApplicationDTO>.GetMapper();
                var applications = mapper.Map<List<JobApplicationDTO>>(data);   
                return applications;
            }
            catch(Exception)
            {
                return null;
            }
        }

        // Return a user application in particular job
        public static JobApplicationDTO AppliedJobByUser(int jobid, int userId)
        {
            try
            {
                if(userId>0)
                {
                    var application = DataAccessFactory.JobApplyDataAccess().GetByJobIdUserId(jobid, userId);
                    var mapper = MappingService<JobApplication, JobApplicationDTO>.GetMapper();
                    var rtn = mapper.Map<JobApplicationDTO>(application);
                    return rtn;
                }
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }
        
        // return all applied users job applicaiton
        public static List<JobApplicationDTO> AppliedUsers(int jobid)
        {
            try
            {
                var data = DataAccessFactory.JobApplyDataAccess().GetByJobId(jobid);
                var mapper = MappingService<JobApplication, JobApplicationDTO>.GetMapper();
                var rtn = mapper.Map<List<JobApplicationDTO>>(data);
                return rtn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // return individual user CV
        public static CVInfoDTO IndividualApplicantInfo(int userid)
        {
            try
            {
                CVInfoDTO cv = CvServices.GetByID(userid);
                return cv;
            }catch(Exception)
            {
                return null;
            }
        }
        
        // return all applied users cv's
        public static List<CVInfoDTO> ApplicantsInfo(int jobid)
        {
            try
            {
                var applied = DataAccessFactory.JobApplyDataAccess().GetByJobId(jobid);
                List<CVInfoDTO> applicantCVs = new List<CVInfoDTO>();

                foreach (var application in applied)
                {
                    // getting user cv
                    CVInfoDTO cvInfo = CvServices.GetByID(application.UserId);
                    applicantCVs.Add(cvInfo);
                }
                return applicantCVs;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // for updating any application status 
        // 0 -> initial status
        // 1 -> received
        // 2 -> shortlisted
        // 3 -> rejected
        // 4 -> accepted
        public static bool ModifyApplication(JobApplicationDTO obj)
        {
            try
            {
                var application = DataAccessFactory.JobApplyDataAccess().GetByUserId(obj.UserId);
                application.ApplicationStatus = obj.ApplicationStatus;
                bool rtn = DataAccessFactory.JobApplyDataAccess().UpdateJobStatus(application);
                return rtn;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
