using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IComment<MODELCLASS, NUMBER, LOGIC, OTHERS>
    {
        List<MODELCLASS> GetAll(bool isAdmin);
        MODELCLASS GetByCommentID(NUMBER id);
        List<MODELCLASS> GetByPostID(NUMBER id);
        List<MODELCLASS> GetByJobID(NUMBER id);
        List<MODELCLASS> GetByUserID(NUMBER id);
        NUMBER CountByPost(NUMBER id);
        NUMBER CountByJob(NUMBER id);
        MODELCLASS GetByName(OTHERS name);
        LOGIC Create(MODELCLASS obj);
        LOGIC Delete(NUMBER id);
        LOGIC Update(MODELCLASS obj);
    }
}