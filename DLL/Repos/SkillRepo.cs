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
    internal class SkillRepo : DataRepository, ICV<Skill, int, bool, String>
    {
        public bool Create(Skill obj)
        {

            try
            {
                _context.Skills.Add(obj);
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
            var skill = _context.Skills.SingleOrDefault(s => s.SkillId == id);

            if (skill != null)
            {
                _context.Skills.Remove(skill);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }

            return false;
        }

        public List<Skill> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetByID(int id)
        {
            var skill = _context.Skills.Where(aq => aq.CVId == id)
          .ToList();

            return skill;
        }

        public Skill GetById(int id)
        {
            var skill = _context.Skills
                .SingleOrDefault(s => s.SkillId == id);
            return skill;
        }

        public bool Update(Skill updatedSkill)
        {
            try
            {
                var existingSkill = _context.Skills.FirstOrDefault(s => s.SkillId == updatedSkill.SkillId);

                if (existingSkill == null)
                {
                    return false; // Skill not found.
                }

                // Update the properties of the existing Skill with the updated values
                existingSkill.SkillName = updatedSkill.SkillName;
                existingSkill.Proficiency = updatedSkill.Proficiency;

                // Set the state of the entity to modified so that it will be updated in the database.
                _context.Entry(existingSkill).State = EntityState.Modified;

                int affectedRows = _context.SaveChanges();

                return affectedRows > 0; // Returns true if at least one row was affected.
            }
            catch (Exception)
            {
                return false; // An error occurred during the update.
            }
        }

    }
}
