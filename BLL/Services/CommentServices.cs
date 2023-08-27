using AutoMapper;
using BLL.DTOs;
using DLL.EF.Models;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace BLL.Services
{
    public class CommentServices
    {
        public static List<CommentDTO> AllComments()
        {
            var comments = DataAccessFactory.CommentDataAccess().GetAll(false);

            if (comments != null)
            {
                var mapper = MappingService<Comment, CommentDTO>.GetMapper();
                var success = mapper.Map<List<CommentDTO>>(comments);

                return success;
            }
            return null;
        }

        public static List<CommentCountDTO> AllComment_Count_Post()
        {
            var comments = DataAccessFactory.CommentDataAccess().GetAll(false);

            // Group comments by Post ID and count the number of comments for each group
            var commentCounts = comments
                .Where(c => c.JobID == null) // Filter comments where JobID is NULL
                .GroupBy(c => c.PostID)
                .Select(group => new CommentCountDTO
                {
                    PostId = (int)group.Key,                   // Post ID
                    PostContent = group.First().Post.Title, // Get the post content correctly
                    CommentCount = group.Count()          // Number of comments for the post
                })
                .ToList();

            return commentCounts;
        }
        public static double AverageCommentCountPost()
        {
            var comments = DataAccessFactory.CommentDataAccess().GetAll(true);

            var commentCounts = comments
                .Where(c => c.JobID == null)
                .GroupBy(c => c.PostID)
                .Select(group => group.Count())
                .ToList();

            // Calculate the average comment count
            double averageCommentCount = commentCounts.Count > 0
                ? commentCounts.Average()
                : 0;

            return averageCommentCount;
        }

        public static double AverageCommentCountJob()
        {
            var comments = DataAccessFactory.CommentDataAccess().GetAll(true);
            var commentCounts = comments
                .Where(c => c.PostID == null)
                .GroupBy(c => c.JobID)
                .Select(group => group.Count())
                .ToList();

            // Calculate the average comment count
            double averageCommentCount = commentCounts.Count > 0
                ? commentCounts.Average()
                : 0;

            return averageCommentCount;
        }


        public static List<CommentCountJobDTO> AllComment_Count_JobPost()
        {
            var comments = DataAccessFactory.CommentDataAccess().GetAll(false);

            // Group comments by Post ID and count the number of comments for each group
            var commentCounts = comments
                .Where(c => c.PostID == null) // Filter comments where JobID is not NULL (i.e., job posts)
                .GroupBy(c => c.JobID)       // Group by JobId for job posts
                .Select(group => new CommentCountJobDTO
                {
                    JobId =(int) group.Key,                      // Job ID
                    JobContent = group.First().Job.Title, // Get the job content correctly
                    CommentCount = group.Count()              // Number of comments for the job post
                })
            .ToList();
            return commentCounts;
        }
      








        public static bool CreateComment(CommentDTO commentDTO)
    {
        var mapper = MappingService<CommentDTO,Comment>.GetMapper();
        var comment = mapper.Map<Comment>(commentDTO);
        var success = DataAccessFactory.CommentDataAccess().Create(comment);
        return success;
    }
    public static CommentDTO CommentById(int id)
    {
        var comment = DataAccessFactory.CommentDataAccess().GetByCommentID(id);
        var mapper = MappingService<Comment, CommentDTO>.GetMapper();
        var rtn = mapper.Map<CommentDTO>(comment);
        return rtn;
    }
    public static bool DeleteComment(int id)
        {
            var result = DataAccessFactory.CommentDataAccess().Delete(id);
            return result;
        }

        public static List<CommentDTO> PostId(int id)
        {
            var comment = DataAccessFactory.CommentDataAccess().GetByPostID(id);

            var mapper = MappingService<Comment, CommentDTO>.GetMapper();
            var result = mapper.Map<List<CommentDTO>>(comment);
            return result;
        }

        public static List<CommentDTO> JobId(int id)
        {
            var comment = DataAccessFactory.CommentDataAccess().GetByJobID(id);

            var mapper = MappingService<Comment, CommentDTO>.GetMapper();
            var result = mapper.Map<List<CommentDTO>>(comment);
            return result;
        }
        public static List<CommentDTO> UserId(int id)
        {
            var comment = DataAccessFactory.CommentDataAccess().GetByUserID(id);
            var mapper = MappingService<Comment, CommentDTO>.GetMapper();
            var result = mapper.Map<List<CommentDTO>>(comment);
            return result;
        }

        public static List<CommentDTO> GetUserPostComments(int userId, int postId)
        {
            var comments = DataAccessFactory.CommentDataAccess().GetUserPostComments(userId, postId);

            var mapper = MappingService<Comment, CommentDTO>.GetMapper();

            var result = mapper.Map<List<CommentDTO>>(comments);
            return result;
        }

        public static List<CommentDTO> GetUserJobComments(int userId, int postId)
        {
            var comments = DataAccessFactory.CommentDataAccess().GetUserJobComments(userId, postId);

            var mapper = MappingService<Comment, CommentDTO>.GetMapper();
            var result = mapper.Map<List<CommentDTO>>(comments);
            return result;
        }


        public static int CountByPost(int postId)
        {
            var count = DataAccessFactory.CommentDataAccess().CountByPost(postId);
            return count;
        }
        public static int CountByJob(int jobId)
        {
            var count = DataAccessFactory.CommentDataAccess().CountByJob(jobId);
            return count;
        }

        public static bool UpdateComment(CommentDTO comment)
        {
            try
            {
                var mapper = MappingService<CommentDTO, Comment>.GetMapper();
                var updatedComment = mapper.Map<Comment>(comment);

                bool success = DataAccessFactory.CommentDataAccess().Update(updatedComment);
                return success;
            }
            catch(Exception) { return false; }
        }

        public static List<CommentCountDTO> GetCommentCountForPostsToday()
        {
            DateTime todayStart = DateTime.Today;
            DateTime todayEnd = todayStart.AddDays(1);

            // Query the database to get the comment counts for each post created today
            var comments = DataAccessFactory.CommentDataAccess().GetAll(false);

            var commentCounts = comments
                .Where(comment => comment.CreatedAt >= todayStart && comment.CreatedAt < todayEnd)
                .GroupBy(comment => comment.PostID)
                .Select(group => new CommentCountDTO
                {
                    PostId = (int)group.Key,                   // Post ID
                    PostContent = group.First().Post.Title, // Get the post content correctly
                    CommentCount = group.Count()          // Number of comments for the post
                })
                .ToList();

            // Load the post content for each PostId
            //foreach (var commentCount in commentCounts)
            //{
            //    var post = DataAccessFactory.PostDataAccess().GetByID(commentCount.PostId);
            //    if (post != null)
            //    {
            //        commentCount.PostContent = post.Title;
            //    }
            //}

            return commentCounts;
        }


    }
}