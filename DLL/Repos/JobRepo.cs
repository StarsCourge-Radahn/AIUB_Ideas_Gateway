using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class JobRepo : DataRepository, IRepo<Job, int, bool, string>, IStatistical<Job, int,bool,Job,string>
    {
        public List<Job> ActiveAll()
        {
            throw new NotImplementedException();
        }

        public List<Job> AllBan()
        {
            throw new NotImplementedException();
        }

        public List<Job> AllTempBan()
        {
            throw new NotImplementedException();
        }

        public bool Create(Job obj)
        {
            obj.IsBan = false;
            obj.IsDeleted = false;

            _context.Jobs.Add(obj);
            int chk = _context.SaveChanges();
            return chk > 0;
        }

        public bool Delete(int id)
        {
            var jobInDb = _context.Jobs.Where(j => j.IsDeleted == false).SingleOrDefault(p => p.JobID == id);
            if (jobInDb != null)
            {
                //_context.Jobs.Remove(postInDb);
                jobInDb.IsDeleted = true;

                int chk = _context.SaveChanges();
                return chk > 0;
            }
            return false;
        }

        public List<Job> GetAll(bool isAdmin)
        {
            if (isAdmin == true)
            {
                return _context.Jobs.Where(j => j.IsDeleted == false).ToList();
            }
            return _context.Jobs.Where(j => j.IsDeleted == false && j.IsBan == false).ToList();
        }

        public Job GetByID(int id)
        {
            var jobInDb = _context.Jobs
                .Where(j => j.IsDeleted == false)
                .SingleOrDefault(j => j.JobID == id);
            return jobInDb;
        }

        public List<Job> GetByName(string name)
        {
            var jobInDb = _context.Jobs
                .Where(j => j.Title.Contains(name) && j.IsDeleted == false)
                .ToList();

            return jobInDb;
        }

        public bool Update(Job obj)
        {
            var jobInDb = _context.Jobs.SingleOrDefault(p => p.JobID == obj.JobID);
            if (jobInDb != null)
            {
                jobInDb.Title = obj.Title;
                jobInDb.Description = obj.Description;
                jobInDb.UpdatedAt = DateTime.Now;

                jobInDb.IsDeleted = obj.IsDeleted;
                jobInDb.IsBan = obj.IsBan;

                int chk = _context.SaveChanges();
                return chk > 0;
            }
            return false;
        }

        public List<Job> WithInRange(DateTime today, DateTime uptoDay)
        {
            return _context.Jobs
                .Where(j=>j.CreatedAt >= today && j.CreatedAt <= uptoDay && j.IsDeleted==false)
                .ToList ();
        }
    }
}
