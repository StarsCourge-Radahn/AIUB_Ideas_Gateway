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
            var posts = DataAccessFactory.PostDataAccess().GetAll(false);
            if (posts != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Post, PostDTO>();
                });
                var mapper = new Mapper(config);
                var rtn = mapper.Map<List<PostDTO>>(posts);
                return rtn;
            }
            return null;
        }

        public static List<PostDTO> AllPostsForAdmin()
        {
            var posts = DataAccessFactory.PostDataAccess().GetAll(true);
            if (posts != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Post, PostDTO>();
                });
                var mapper = new Mapper(config);
                var rtn = mapper.Map<List<PostDTO>>(posts);
                return rtn;
            }
            return null;
        }

        public static List<PostDTO> CountPosts()
        {
            var result = AllPosts();
            int totalCount = result.Count;
            return result;
        }

        public static PostDTO GetPost(int id)
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

        public static bool CreatePost(PostDTO postdto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostDTO, Post>();
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
                cfg.CreateMap<PostDTO, Post>();
            });
            var mapper = new Mapper(config);

            var post = mapper.Map<Post>(postdto);

            var rtn = DataAccessFactory.PostDataAccess().Update(post);
            return rtn;
        }

        public static List<PostDTO> PostSearch(string q)
        {
            var data = DataAccessFactory.PostDataAccess().GetByName(q);
            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Post, PostDTO>();
                });
                var mapper = new Mapper(config);
                var rtn = mapper.Map<List<PostDTO>>(data);
                return rtn;
            }
            return null;
        }

        public static List<PostDTO> GetPostsInRange(DateTime today, DateTime upto)
        {
            try
            {
                var data = DataAccessFactory.PostStatisticalDataAccess().WithInRange(today, upto);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Post, PostDTO>();
                });
                var mapper = new Mapper(config);
                var rtn = mapper.Map<List<PostDTO>>(data);
                return rtn;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
