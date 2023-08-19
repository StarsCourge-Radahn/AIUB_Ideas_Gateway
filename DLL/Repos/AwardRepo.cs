using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class AwardRepo : DataRepository, IRepo<Award, int, bool, int>
    {
        public bool Create(Award obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Award> GetAll(bool isAdmin)
        {
            throw new NotImplementedException();
        }

        public Award GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Award> GetByName(int name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Award obj)
        {
            throw new NotImplementedException();
        }
    }
}
