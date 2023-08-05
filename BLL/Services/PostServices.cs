using AutoMapper;
using BLL.DTOs;
using DLL;
using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        public static bool CreatePost(string title, string content, int userid = 1)
        {
            var postdto = new PostDTO();
            postdto.Title = title;
            postdto.Content = content;
            postdto.CreatedAt = DateTime.Now;
            postdto.UpdatedAt = null;
            postdto.UserID = userid;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(config);

            var pst = mapper.Map<Post>(postdto);
            var rtn = DataAccessFactory.PostDataAccess().Create(pst);

            return rtn;
        }

        public static bool DeletePost(int id)
        {
            var rtn = DataAccessFactory.PostDataAccess().Delete(id);
            return rtn;
        }
        public static bool UpdatePost(PostDTO obj)
        {
            var postdto = new PostDTO();
            postdto.Title = obj.Title;
            postdto.Content = obj.Content;

            postdto.UpdatedAt = DateTime.Now;
            postdto.UserID = obj.UserID;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(config);

            var post = mapper.Map<Post>(postdto);

            var rtn = DataAccessFactory.PostDataAccess().Update(post);
            return rtn;
        }
    }
}
