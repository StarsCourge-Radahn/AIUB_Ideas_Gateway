using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IOTP<MODELCLASS, NUMBER, LOGIC, OTHERS >
    {
        LOGIC Create(MODELCLASS obj);
        LOGIC Check(MODELCLASS obj);
        LOGIC Update(OTHERS obj);

    }
}
