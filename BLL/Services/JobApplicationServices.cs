using BLL.DTOs;
using DLL;
using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class JobApplicationServices
    {
        public bool JobApply(int jobid, int userid)
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

        public List<JobApplicationDTO> AppliedUsers(int jobid)
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

        public List<CVInfoDTO> ApplicantsInfo(int jobid)
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
    }
}
