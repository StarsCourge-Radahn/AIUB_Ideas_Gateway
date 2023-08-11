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
    }
}
