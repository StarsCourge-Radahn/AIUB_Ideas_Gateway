using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class JobRepo : DataRepository, IRepo<Job, int, bool, string>
    {
         public bool Create(Job obj)
        {
            _context.Jobs.Add(obj);
            int chk = _context.SaveChanges();
            return chk > 0;
        }

        public bool Delete(int id)
        {
            var postInDb = _context.Jobs.SingleOrDefault(p => p.JobID == id);
            if (postInDb != null)
            {
                _context.Jobs.Remove(postInDb);
                int chk = _context.SaveChanges();
                if (chk > 0)
                    return true;
                else return false;
            }
            return false;
        }

        public List<Job> GetAll()
        {
            return _context.Jobs.ToList();
        }

        public List<Job> GetAll(bool isAdmin = false)
        {
            throw new NotImplementedException();
        }

        public Job GetByID(int id)
        {
            var jobInDb = _context.Jobs.SingleOrDefault(p => p.JobID == id);
            return jobInDb;
        }

        public Job GetByName(string name)
        {
            var jobInDb = _context.Jobs.Where(p => p.Title.Contains(name)).FirstOrDefault();
            if (jobInDb != null)
            {
                return jobInDb;
            }
            return null;
        }

        public bool Update(Job obj)
        {
            var jobInDb = _context.Jobs.SingleOrDefault(p => p.JobID == obj.JobID);
            if (jobInDb != null)
            {
                jobInDb.Title = obj.Title;
                jobInDb.Description = obj.Description;
                jobInDb.UpdatedAt = DateTime.Now;

                int chk = _context.SaveChanges();
                if (chk > 0)
                    return true;
                else return false;
            }
            return false;
        }
    }
}
