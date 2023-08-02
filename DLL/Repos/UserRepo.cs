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
    internal class UserRepo : DataRepository, IUserRepo<User, int, bool, string>
    {
        public bool Create(User obj)
        {
            _context.Users.Add(obj);
            int chk = _context.SaveChanges();
            return chk > 0;
        }

        public bool Delete(int id)
        {
            var userInDb = _context.Users.Find(id);
            _context.Users.Remove(userInDb);

            int chk = _context.SaveChanges();
            return chk > 0;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetByID(int id)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.UserID == id);
            return userInDb;
        }

        public User GetByName(string name)
        {
            var userInDb = _context.Users
                .Where(u => u.Name.Contains(name))
                .FirstOrDefault();
            if (userInDb != null)
                return userInDb;
            return new User { UserID = -1, Name = null, UserName = "", Password = "" };
        }

        public bool Update(User obj)
        {
            var userInDb = _context.Users.Find(obj.UserID);
            if (userInDb != null)
            {
                _context.Entry(userInDb).State = EntityState.Modified;
                int chk = _context.SaveChanges();
                return chk > 0;
            }
            return false;
        }
    }
}
