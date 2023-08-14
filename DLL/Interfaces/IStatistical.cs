using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IStatistical<MODELCLASS, NUMBER, LOGIC, RTN, OTHERS>
    {
        List<MODELCLASS> ActiveAll();
        List<MODELCLASS> AllBan();
        List<MODELCLASS> AllTempBan();
        List<MODELCLASS> WithInRange(DateTime today, DateTime uptoDay);
    }
}
