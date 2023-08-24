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
    internal class CVRepo : DataRepository, ICV<CV, int, bool, string>
    {
        public bool Create(CV obj)
        {
            try
            {
                _context.CVs.Add(obj);
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
            throw new NotImplementedException();
        }

        public List<CV> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CV> GetByCVID(int id)
        {
            //try
            //{
            //    var cv = _context.CVs
            //        .Include(c => c.AcademicQualifications)
            //        .Include(c => c.Experiences)
            //        .Include(c => c.Skills)
            //        .Include(c => c.ThesisPapers)
            //        .Include(c => c.Awards)
            //        .FirstOrDefault(c => c.CVId == id);
            //    return cv;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
            throw new NotImplementedException();
        }

        public CV GetById(int id)
        {
            try
            {
                var commentbd = _context.CVs.SingleOrDefault(c => c.UserId == id);
                return commentbd;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(CV obj)
        {
            throw new NotImplementedException();
        }
       
       

      
    }
}
