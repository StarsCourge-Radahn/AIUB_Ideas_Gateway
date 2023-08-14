using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DLL.Repos
{
    internal class SessionRepo : DataRepository, IRepo<Session, int, bool, string>, IStatistical<Session, int, bool, Session, string>
    {
        public List<Session> ActiveAll()
        {
            return _context.Sessions.Where(s => s.IsActive == true).ToList();
        }

        public List<Session> AllBan()
        {
            throw new NotImplementedException();
        }

        public List<Session> AllTempBan()
        {
            throw new NotImplementedException();
        }

        public List<Session> WithInRange(DateTime today, DateTime uptoDay)
        {
            throw new NotImplementedException();
        }

        public bool Create(Session obj)
        {
            try
            {
                _context.Sessions.Add(obj);
                return _context.SaveChanges() > 0;
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

        public List<Session> GetAll(bool isAdmin = false)
        {
            return _context.Sessions.ToList();
        }

        public Session GetByID(int id)
        {
            try
            {
                var session = _context.Sessions.
                    Where(s=>s.UserID == id && s.IsActive == true && s.LogoutTime==null)
                    .FirstOrDefault();
                return session;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Session> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Session obj)
        {
            try
            {
                var sessionInDb = _context.Sessions.FirstOrDefault(s=>s.SessionID == obj.SessionID);
                if (sessionInDb != null)
                {
                    sessionInDb.LogoutTime = obj.LogoutTime;
                    sessionInDb.IsActive = obj.IsActive;
                    return _context.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
