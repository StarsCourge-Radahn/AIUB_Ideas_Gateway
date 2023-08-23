using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class ThesisRepo : DataRepository, ICV<ThesisPaper, int, bool, String>
    {
        public bool Create(ThesisPaper obj)
        {

            try
            {
                _context.ThesisPapers.Add(obj);
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
            var thesis = _context.ThesisPapers.SingleOrDefault(t => t.ThesisId == id);

            if (thesis != null)
            {
                _context.ThesisPapers.Remove(thesis);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }

            return false;
        }

        public List<ThesisPaper> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ThesisPaper> GetByID(int id)
        {
            var thesis = _context.ThesisPapers.Where(aq => aq.CVId == id)
           .ToList();

            return thesis;
        }

        public ThesisPaper GetCvById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ThesisPaper obj)
        {
            throw new NotImplementedException();
        }
    }
}
