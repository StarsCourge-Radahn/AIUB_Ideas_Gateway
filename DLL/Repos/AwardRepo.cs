using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class AwardRepo : DataRepository, ICV<Award, int, bool, String>
    {
        public bool Create(Award obj)
        {
            try
            {
                _context.Awards.Add(obj);
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
            var award = _context.Awards.SingleOrDefault(a => a.AwardId == id);

            if (award != null)
            {
                _context.Awards.Remove(award);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }

            return false;
        }

        public List<Award> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Award> GetByID(int id)
        {
            var award = _context.Awards
           .Where(aq => aq.CVId == id)
           .ToList();

            return award;
        }

        public Award GetCvById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Award obj)
        {
            throw new NotImplementedException();
        }
    }
}
