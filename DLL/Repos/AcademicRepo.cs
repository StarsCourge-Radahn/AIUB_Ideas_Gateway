using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class AcademicRepo : DataRepository, IRepo<AcademicQualification, int, bool, int>
    {
        public bool Create(AcademicQualification obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AcademicQualification> GetAll(bool isAdmin)
        {
            throw new NotImplementedException();
        }

        public AcademicQualification GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<AcademicQualification> GetByName(int name)
        {
            throw new NotImplementedException();
        }

        public bool Update(AcademicQualification obj)
        {
            throw new NotImplementedException();
        }
    }
}
