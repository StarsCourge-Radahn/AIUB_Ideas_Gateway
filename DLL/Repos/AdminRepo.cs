using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class AdminRepo : DataRepository, IRepo<Admin, int, bool, string>, IAuth
    {
        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Create(Admin obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetAll()
        {
            throw new NotImplementedException();
        }

        public Admin GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Admin GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Admin obj)
        {
            throw new NotImplementedException();
        }
    }
}
