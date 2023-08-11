using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class CommentRepo : DataRepository, IRepo<Comment, int, bool, string>
    {
        public bool Create(Comment obj)
        {
            _context.Comments.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll(bool isAdmin = false)
        {
            throw new NotImplementedException();
        }

        public Comment GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Comment GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Comment obj)
        {
            throw new NotImplementedException();
        }
    }
}
