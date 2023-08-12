using AutoMapper;
using BLL.DTOs;
using DLL;
using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserServices
    {
        public static bool CreateUser(string name, string username, string email, string pass)
        {
            var ue = DataAccessFactory.AuthDataAccess().GetByEmail(email);
            var uu = DataAccessFactory.AuthDataAccess().GetByUsername(username);

            if (ue != null && uu != null)
            {
                return false;
            }

            var userdto = new UserDTO
            {
                Name = name,
                UserName = username,
                Email = email,
                Password = pass,
                IsBan = false,
                IsDeleted = false
            };

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
            });

            var mapper = new Mapper(config);
            var user = mapper.Map<User>(userdto);

            var userCreated = DataAccessFactory.UserDataAccess().Create(user);
            return userCreated == true;
        }


        public static List<UserDTO> GetUsers()
        {
            var users = DataAccessFactory.UserDataAccess().GetAll(true);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(config);
            var rtn = mapper.Map<List<UserDTO>>(users);

            return rtn;
        }

        public static UserDTO GetUser(int id)
        {
            var user = DataAccessFactory.UserDataAccess().GetByID(id);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserDTO>(); });
            var mapper = new Mapper(config);
            var rtn = mapper.Map<UserDTO>(user);
            return rtn;
        }

        public static bool UpdateUser(UserDTO obj)
        {
            // have to updat users. like banning user, changin user info.
            return false;
        }

        public static bool DeleteUser(int id)
        {
            var rtn = DataAccessFactory.UserDataAccess().Delete(id);
            return rtn;
        }
        public static int CurrentlyActiveUsers()
        {
            var cnt = DataAccessFactory.ActiveUsersDataAccess().ActiveAll();
            return cnt.Count();
        }

        public static int AllBanUses()
        {
            var banUsers = DataAccessFactory.UserStaticalDataAccess().AllBan();
            return banUsers.Count();
        }
    }
}
