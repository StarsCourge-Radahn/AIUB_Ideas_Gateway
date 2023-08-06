using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class SessionRepo : DataRepository, IRepo<Session, int, bool, string>
    {
        public bool Create(Session obj)
        {
            _context.Sessions.Add(obj);
            int chk = _context.SaveChanges();
            return chk > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Session> GetAll()
        {
            return _context.Sessions.ToList();
        }

        public Session GetByID(int id)
        {
            return _context.Sessions
                .Where(s => s.UserID == id && s.IsActive == true)
                .SingleOrDefault();
        }

        public Session GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Session obj)
        {
            var InDb = _context.Sessions.Find(obj.SessionID);
            InDb.LogoutTime = obj.LogoutTime;
            InDb.IsActive = obj.IsActive;

            int chk = _context.SaveChanges();
            return chk > 0;
        }
    }
}
