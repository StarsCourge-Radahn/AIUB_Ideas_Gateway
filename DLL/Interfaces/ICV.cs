using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface ICV
    {
        bool CreateCV(CV obj);
        List<CV>GetAllCV();

    }
}
