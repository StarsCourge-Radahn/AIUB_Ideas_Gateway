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

        public Award GetById(int id)
        {
            var award = _context.Awards
                .SingleOrDefault(a => a.AwardId == id);
            return award;
        }

        public bool Update(Award updatedAward)
        {
            try
            {
                var existingAward = _context.Awards.FirstOrDefault(a => a.AwardId == updatedAward.AwardId);

                if (existingAward == null)
                {
                    return false; // Award not found.
                }

                // Update the properties of the existing Award with the updated values
                existingAward.AwardName= updatedAward.AwardName;
                existingAward.AwardingInstitution = updatedAward.AwardingInstitution;
                existingAward.DateReceived = updatedAward.DateReceived;

                // Set the state of the entity to modified so that it will be updated in the database.
                _context.Entry(existingAward).State = EntityState.Modified;

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
