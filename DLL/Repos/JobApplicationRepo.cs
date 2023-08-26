using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class JobApplicationRepo : DataRepository, IJobApply<JobApplication, int, bool>
    {
        public bool Create(JobApplication obj)
        {
            try
            {
                _context.JobApplications.Add(obj);
                int chk = _context.SaveChanges();
                return chk > 0;
            }
            catch (Exception) { return false; }
        }

        public List<JobApplication> GetByJobId(int id)
        {
            try
            {
                var applicants = _context.JobApplications.Where(ja => ja.JobId == id).ToList();
                return applicants;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public JobApplication GetByJobIdUserId(int jid, int uid)
        {
            try
            {
                var rtn = _context.JobApplications
                    .Where(ja => ja.JobId == jid && ja.UserId == uid).FirstOrDefault();
                return rtn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public JobApplication GetByUserId(int id)
        {
            try
            {
                var rtn = _context.JobApplications.Where(ja => ja.UserId == id).FirstOrDefault();
                return rtn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateJobStatus(JobApplication obj)
        {
            try
            {
                var exist = _context.JobApplications.Find(obj.JobApplicationId);
                if (exist != null)
                {
                    exist.ApplicationStatus = obj.ApplicationStatus;
                    int chk = _context.SaveChanges();
                    return chk > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
