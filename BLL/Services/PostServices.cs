using AutoMapper;
using BLL.DTOs;
using DLL;
using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PostServices
    {
        public static List<PostDTO> AllPosts()
        {
            var posts = DataAccessFactory.PostDataAccess().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(config);
            var rtn = mapper.Map<List<PostDTO>>(posts);
            return rtn;
        }
        public static PostDTO Post(int id)
        {
            var post = DataAccessFactory.PostDataAccess().GetByID(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(config);
            var rtn = mapper.Map<PostDTO>(post);
            return rtn;
        }

        public static bool CreatePost(PostDTO post)
        {
            // have care full here....
            return false;
        }
    }
}
