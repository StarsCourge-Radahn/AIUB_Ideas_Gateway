using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class PostRepo : DataRepository, IRepo<Post, int, bool, string>
    {
        public bool Create(Post obj)
        {
            _context.Posts.Add(obj);
            int chk = _context.SaveChanges();
            return chk > 0;
        }

        public bool Delete(int id)
        {
            var postInDb = _context.Posts.SingleOrDefault(p => p.PostID == id);
            if (postInDb != null)
            {
                _context.Posts.Remove(postInDb);
                int chk = _context.SaveChanges();
                if (chk > 0)
                    return true; 
                else return false;
            }
            return false;
        }

        public List<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public Post GetByID(int id)
        {
            var postInDb = _context.Posts.SingleOrDefault(p => p.PostID == id);
            return postInDb;
        }

        public Post GetByName(string name)
        {
            var postInDb = _context.Posts.Where(p => p.Title.Contains(name)).FirstOrDefault();
            if (postInDb != null)
            {
                return postInDb;
            }
            return null;
        }

        public bool Update(Post obj)
        {
            var postInDb = _context.Posts.SingleOrDefault(p => p.PostID == obj.PostID);
            if (postInDb != null)
            {
                postInDb.Title = obj.Title;
                postInDb.Content = obj.Content;
                postInDb.UpdatedAt = DateTime.Now;

                int chk = _context.SaveChanges();
                if (chk > 0)
                    return true;
                else return false;
            }
            return false;
        }
    }
}
