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
            obj.IsBan = false;
            obj.IsDeleted = false;
            _context.Comments.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var commentbd = _context.Comments.SingleOrDefault(p => p.CommentID == id);
            if (commentbd != null)
            {
                commentbd.IsDeleted = true;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<Comment> GetAll(bool isAdmin = false)
        {
            return _context.Comments.Where(u => u.IsDeleted == false).ToList();
        }

        public Comment GetByID(int id)
        {
            var commentbd = _context.Comments.Where(p => p.IsDeleted == false).SingleOrDefault(p => p.CommentID == id);
            return commentbd;
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
