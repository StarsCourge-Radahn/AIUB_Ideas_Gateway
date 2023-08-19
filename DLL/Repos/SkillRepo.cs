using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class SkillRepo : DataRepository, IRepo<Skill, int, bool, int>
    {
        public bool Create(Skill obj)
        {
            _context.Skills.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetAll(bool isAdmin)
        {
            throw new NotImplementedException();
        }

        public Skill GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetByName(int cvid)
        {
            var skills = _context.Skills.Where(s=>s.CVId == cvid).ToList();
            return skills;
        }

        public bool Update(Skill obj)
        {
            var ex = _context.Skills.FirstOrDefault(s => s.SkillId == obj.SkillId);
            if (ex != null)
            {
                ex.SkillName = obj.SkillName;
                ex.Proficiency = obj.Proficiency;

                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
