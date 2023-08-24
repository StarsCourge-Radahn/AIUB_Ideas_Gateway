using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public AcademicQualification GetById(int id)
        {
            var academicQualification = _context.AcademicQualifications
                .SingleOrDefault(aq => aq.QualificationId == id);
            return academicQualification;
        }


        public bool Update(AcademicQualification updatedAcademic)
        {
            try
            {
                var existingAcademicQualification = _context.AcademicQualifications.FirstOrDefault(aq => aq.QualificationId == updatedAcademic.QualificationId);

                if (existingAcademicQualification == null)
                {
                    return false; // Academic qualification not found.
                }

                // Update the properties of the existing AcademicQualification with the updated values
                existingAcademicQualification.Degree = updatedAcademic.Degree;
                existingAcademicQualification.Institution = updatedAcademic.Institution;
                existingAcademicQualification.StartDate = updatedAcademic.StartDate;
                existingAcademicQualification.EndDate = updatedAcademic.EndDate; // If nullable, you can update it this way.

                // Set the state of the entity to modified so that it will be updated in the database.
                _context.Entry(existingAcademicQualification).State = EntityState.Modified;

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
