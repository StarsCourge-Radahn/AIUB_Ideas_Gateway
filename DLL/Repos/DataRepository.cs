using DLL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class DataRepository
    {
        protected AIGContext _context;
        internal DataRepository()
        {
            _context = new AIGContext();
        }
    }
}
