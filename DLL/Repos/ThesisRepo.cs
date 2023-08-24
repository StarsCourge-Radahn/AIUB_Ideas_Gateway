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

        public List<ThesisPaper> GetByCVID(int id)
        {
            var thesis = _context.ThesisPapers.Where(aq => aq.CVId == id).ToList();

            return thesis;
        }
        public ThesisPaper GetById(int id)
        {
            var thesis = _context.ThesisPapers
                .SingleOrDefault(t => t.ThesisId == id);
            return thesis;
        }

        public bool Update(ThesisPaper updatedThesis)
        {
            try
            {
                var existingThesis = _context.ThesisPapers.FirstOrDefault(t => t.ThesisId == updatedThesis.ThesisId);

                if (existingThesis == null)
                {
                    return false; // Thesis not found.
                }

                // Update the properties of the existing Thesis with the updated values
                existingThesis.Title = updatedThesis.Title;
                existingThesis.PublicationDate = updatedThesis.PublicationDate;
                existingThesis.CoAuthors = updatedThesis.CoAuthors;

                // saving the updated infromations
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
