using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class CommentRepo : DataRepository, IComment<Comment, int, bool, string>
    {
        public bool Create(Comment obj)
        {
            try
            {
                obj.IsBan = false;
                obj.IsDeleted = false;

                _context.Comments.Add(obj);
                int fnd = _context.SaveChanges();
                return fnd > 0;
            }
            catch (Exception)
            {
                return false;
            }


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

        public List<Comment> GetAll(bool isAdmin)
        {
            if (isAdmin == true)
                return _context.Comments.Where(u => u.IsDeleted == false).ToList();
            return _context.Comments.Where(c => c.IsDeleted == false && c.IsBan == false).ToList();
        }

        public Comment GetByCommentID(int id)
        {
            var commentbd = _context.Comments
                 .Where(c => c.IsDeleted == false)
                 .SingleOrDefault(c => c.CommentID == id);
            return commentbd;
        }

        public List<Comment> GetByJobID(int id)
        {
            var comments = _context.Comments
                .Where(c => c.IsDeleted == false && c.JobID == id)
                .ToList();

            return comments;
        }
        public Comment GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetByPostID(int id)
        {
            var comments = _context.Comments
                .Where(c => c.IsDeleted == false && c.PostID == id)
                .ToList();

            return comments;
        }
        public List<Comment> GetByUserID(int id)
        {
            var comments = _context.Comments
                .Where(c => c.IsDeleted == false && c.UserID == id)
                .ToList();

            return comments;
        }
        public int CountByPost(int postId)
        {
            var count = _context.Comments
                .Where(c => c.PostID == postId)
                .Count();

            return count;
        }

        public int CountByJob(int jobId)
        {
            var count = _context.Comments
                .Where(c => c.JobID == jobId)
                .Count();

            return count;
        }
        public bool Update(Comment obj)
        {
            try
            {
                var existingComment = _context.Comments.FirstOrDefault(c => c.CommentID == obj.CommentID);

                if (existingComment == null)
                {
                    return false;
                }
                existingComment.Text = obj.Text;


                _context.Entry(existingComment).State = EntityState.Modified;
                int affectedRows = _context.SaveChanges();

                return affectedRows > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}