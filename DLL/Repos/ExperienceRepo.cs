using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<Experience> GetByCVID(int id)
        {
            var experience = _context.Experiences.Where(aq => aq.CVId == id)
           .ToList();

            return experience;
        }

        public Experience GetById(int id)
        {
            var experience = _context.Experiences
                .SingleOrDefault(e => e.ExperienceId == id);
            return experience;
        }

        public bool Update(Experience updatedExperience)
        {
            try
            {
                var existingExperience = _context.Experiences
                    .FirstOrDefault(e => e.ExperienceId == updatedExperience.ExperienceId);

                if (existingExperience == null)
                {
                    return false; 
                }

                existingExperience.Position = updatedExperience.Position;
                existingExperience.CompanyName = updatedExperience.CompanyName;
                existingExperience.StartDate = updatedExperience.StartDate;
                existingExperience.EndDate = updatedExperience.EndDate; 

                int affectedRows = _context.SaveChanges();
                return affectedRows > 0; 
            }
            catch (Exception)
            {
                return false; 
            }
        }

    }
}
