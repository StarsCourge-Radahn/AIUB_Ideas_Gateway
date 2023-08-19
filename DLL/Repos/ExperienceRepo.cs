using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class ExperienceRepo : DataRepository, IRepo<Exception, int, bool, int>
    {
        public bool Create(Exception obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Exception> GetAll(bool isAdmin)
        {
            throw new NotImplementedException();
        }

        public Exception GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Exception> GetByName(int name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Exception obj)
        {
            throw new NotImplementedException();
        }
    }
}
