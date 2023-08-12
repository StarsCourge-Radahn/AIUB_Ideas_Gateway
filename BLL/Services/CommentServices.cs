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
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Comment, CommentDTO>();
                });
                var mapper = new Mapper(config);
                var success = mapper.Map<List<CommentDTO>>(comments);

                return success;
            }
            return null;
        }
        public static bool CreateComment(CommentDTO commentDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentDTO, Comment>();
                cfg.CreateMap<Comment, CommentDTO>().ReverseMap();
            });
            var mapper = new Mapper(config);

            var comment = mapper.Map<Comment>(commentDTO);
            var success = DataAccessFactory.CommentDataAccess().Create(comment);

            return success;
        }

        public static CommentDTO CommentById(int id)
        {
            var comment = DataAccessFactory.CommentDataAccess().GetByCommentID(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(config);
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(config);
            var result = mapper.Map<List<CommentDTO>>(comment);
            return result;
        }

        public static List<CommentDTO> JobId(int id)
        {
            var comment = DataAccessFactory.CommentDataAccess().GetByJobID(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(config);
            var result = mapper.Map<List<CommentDTO>>(comment);
            return result;
        }
        public static List<CommentDTO> UserId(int id)
        {
            var comment = DataAccessFactory.CommentDataAccess().GetByUserID(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(config);
            var result = mapper.Map<List<CommentDTO>>(comment);
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentDTO, Comment>();
            });
            var mapper = new Mapper(config);

            var updatedComment = mapper.Map<Comment>(comment);

            bool success = DataAccessFactory.CommentDataAccess().Update(updatedComment);
            return success;
        }


    }


}