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
            var comments = DataAccessFactory.CommentDataAccess().GetAll();

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
            var comment = DataAccessFactory.CommentDataAccess().GetByID(id);
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
    }
}
