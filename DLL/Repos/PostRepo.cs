using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class PostRepo : DataRepository, IRepo<Post, int, bool, string>, IStatistical<Post, int, bool,Post, string>
    {
        public bool Create(Post obj)
        {
            obj.IsBan = false;
            obj.IsDeleted = false;

            _context.Posts.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var postInDb = _context.Posts.SingleOrDefault(p => p.PostID == id);
            if (postInDb != null)
            {
                postInDb.IsDeleted = true;

                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<Post> GetAll(bool isAdmin)
        {
            if (isAdmin == true)
                return _context.Posts.Where(p => p.IsDeleted == false).ToList();

            return _context.Posts.Where(p => p.IsDeleted == false && p.IsBan == false).ToList();
        }

        public Post GetByID(int id)
        {
            var postInDb = _context.Posts.Where(p => p.IsDeleted == false).SingleOrDefault(p => p.PostID == id);
            return postInDb;
        }

        public List<Post> GetByName(string name)
        {
            var postInDb = _context.Posts.Where(p => p.Title.Contains(name)
            && p.IsDeleted == false).ToList();

            return postInDb;
        }

        public bool Update(Post obj)
        {
            var postInDb = _context.Posts.SingleOrDefault(p => p.PostID == obj.PostID);
            if (postInDb != null)
            {
                postInDb.Title = obj.Title;
                postInDb.Content = obj.Content;
                postInDb.UpdatedAt = DateTime.Now;

                postInDb.IsBan = obj.IsBan;
                postInDb.IsDeleted = obj.IsDeleted;

                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<Post> ActiveAll()
        {
            throw new NotImplementedException();
        }

        public List<Post> AllBan()
        {
            throw new NotImplementedException();
        }

        public List<Post> AllTempBan()
        {
            throw new NotImplementedException();
        }

        public List<Post> WithInRange(DateTime today, DateTime uptoDay)
        {
            return _context.Posts
                .Where(p => p.CreatedAt >= today && p.CreatedAt <= uptoDay && p.IsDeleted == false)
                .ToList();
        }
    }
}
