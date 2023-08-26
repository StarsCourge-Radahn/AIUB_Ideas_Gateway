using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IJobApply<MODELCLASS, NUMBER,LOGIC>
    {
        LOGIC Create(MODELCLASS obj);
        MODELCLASS GetByJobIdUserId(NUMBER jid, NUMBER uid);
        MODELCLASS GetByUserId(NUMBER id);
        List<MODELCLASS> GetByJobId(NUMBER id);
        LOGIC UpdateJobStatus(MODELCLASS obj);
    }
}
