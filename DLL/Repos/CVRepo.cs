using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class CVRepo : DataRepository, ICV<CV, bool, int, string>
    {
        public bool CreateCV(CV obj)
        {
            try
            {
                _context.CVs.Add(obj);
                int fnd = _context.SaveChanges();
                return fnd > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CV> GetAllCV()
        {
            throw new NotImplementedException();
        }

        public CV GetCv(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCV(CV obj)
        {
            throw new NotImplementedException();
        }
    }
}
