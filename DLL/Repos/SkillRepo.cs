using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
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

        public Skill GetCvById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Skill obj)
        {
            throw new NotImplementedException();
        }
    }
}
