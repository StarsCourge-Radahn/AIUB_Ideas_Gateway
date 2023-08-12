using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IRepo<MODELCLASS,NUMBER,LOGIC,OTHERS>
    {
        List<MODELCLASS> GetAll(bool isAdmin);
        MODELCLASS GetByID(NUMBER id);
        List<MODELCLASS> GetByName(OTHERS name);
        LOGIC Create(MODELCLASS obj); 
        LOGIC Delete(NUMBER id);
        LOGIC Update(MODELCLASS obj);
    }
}
