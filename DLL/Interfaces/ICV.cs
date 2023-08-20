using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface ICV<MODELCLASS, NUMBER, LOGIC, OTHERS>
    {
        bool CreateCV(CV obj);
        CV GetCv(int id);
        List<CV> GetAllCV();
        bool UpdateCV(CV obj);

    }
}
