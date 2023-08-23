using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class AcademicRepo : DataRepository, ICV<AcademicQualification, int, bool, String>
    {
        public bool Create(AcademicQualification obj)
        {
            try
            {
                _context.AcademicQualifications.Add(obj);
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
            var academic = _context.AcademicQualifications.SingleOrDefault(p => p.QualificationId == id);
            if (academic != null)
            {
                _context.AcademicQualifications.Remove(academic); 
                int affectedRows = _context.SaveChanges(); 
                return affectedRows > 0; 
            }
            return false;
        }

        public List<AcademicQualification> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<AcademicQualification> GetByID(int id)
        {
            var academicQualifications = _context.AcademicQualifications
            .Where(aq => aq.CVId == id)
            .ToList();

            return academicQualifications;
        }

        public AcademicQualification GetCvById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(AcademicQualification obj)
        {
            throw new NotImplementedException();
        }
    }
}
