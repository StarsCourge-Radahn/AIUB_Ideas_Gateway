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
    internal class UserRepo : DataRepository, IRepo<User, int, bool, string>, IAuth
    {
        public User Authenticate(string username, string password)
        {
            var data = from u in _context.Users
                       where u.UserName.Equals(username)
                       && u.Password.Equals(password) 
                       && u.IsBan == false 
                       && u.IsDeleted == false
                       select u;

            return data.SingleOrDefault();
        }

        public User GetByEmail(string email)
        {
            var user = _context.Users.Where(u => u.IsDeleted == false).SingleOrDefault(u => u.Email.Equals(email));
            return user;
        }

        public User GetByUsername(string username)
        {
            var user = _context.Users.Where(u => u.IsDeleted == false).SingleOrDefault(u => u.UserName.Equals(username));
            return user;
        }
        public bool Create(User obj)
        {
            obj.IsBan = false; obj.IsDeleted = false; obj.TemporaryBan = false;

            _context.Users.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var userInDb = _context.Users.Find(id);
            userInDb.IsDeleted = true;

            return _context.SaveChanges() > 0;
        }

        public List<User> GetAll(bool isAdmin = true)
        {
            return _context.Users.Where(u => u.IsDeleted == false).ToList();
        }

        public User GetByID(int id)
        {
            var userInDb = _context.Users.Where(u => u.IsDeleted == false).FirstOrDefault(u => u.UserID == id);
            return userInDb;
        }

        public User GetByName(string name)
        {
            var userInDb = _context.Users
                .Where(u => u.Name.Contains(name) && u.IsDeleted == false)
                .FirstOrDefault();
            if (userInDb != null)
            {
                return userInDb;
            }
            return null;
        }

        public bool Update(User obj)
        {
            var userInDb = _context.Users.Find(obj.UserID);
            if (userInDb != null)
            {
                //_context.Entry(userInDb).State = EntityState.Modified;
                userInDb.Name = obj.Name;
                userInDb.Email = obj.Email;
                userInDb.Password = obj.Password;
                userInDb.Role = obj.Role;

                userInDb.IsBan = obj.IsBan;
                userInDb.IsDeleted = obj.IsDeleted;
                userInDb.TemporaryBan = obj.TemporaryBan;

                return _context.SaveChanges() > 0;

            }
            return false;
        }
    }
}
