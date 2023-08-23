using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class ExperienceRepo : DataRepository, ICV<Experience, int, bool, String>
    {
        public bool Create(Experience obj)
        {

            try
            {
                _context.Experiences.Add(obj);
                int fnd = _context.SaveChanges();
                return fnd > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var experience = _context.Experiences.SingleOrDefault(e => e.ExperienceId == id);

            if (experience != null)
            {
                _context.Experiences.Remove(experience);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }

            return false;
        }

        public List<Experience> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Experience> GetByID(int id)
        {
            var experience = _context.Experiences.Where(aq => aq.CVId == id)
           .ToList();

            return experience;
        }

        public Experience GetCvById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Experience obj)
        {
            throw new NotImplementedException();
        }
    }
}
