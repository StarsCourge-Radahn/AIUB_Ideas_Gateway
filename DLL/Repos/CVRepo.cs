using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class CVRepo : DataRepository, ICV
    {
        public bool CreateCV(CV obj)
        {
            throw new NotImplementedException();
        }

        public List<CV> GetAllCV()
        {
            throw new NotImplementedException();
        }
    }
}
