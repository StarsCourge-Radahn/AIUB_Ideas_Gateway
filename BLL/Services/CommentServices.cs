using AutoMapper;
using BLL.DTOs;
using DLL.EF.Models;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<CommentDTO> GetUserPostComments(int userId, int postId)
        {
            var comments = DataAccessFactory.CommentDataAccess().GetUserPostComments(userId, postId);

            var mapper = MappingService<Comment, CommentDTO>.GetMapper();
            var result = mapper.Map<List<CommentDTO>>(comments);
            return result;
        }

        public List<CommentDTO> GetUserJobComments(int userId, int postId)
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
    }
}