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
        public static bool CreateUser(string username, string name, string pass)
        {
            var userdto = new UserDTO { Name = name, UserName = username ,Password=pass};

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, User>();
            });

            var mapper = new Mapper(config);
            var user = mapper.Map<User>(userdto);

            var userCreate = DataAccessFactory.UserDataAccess().Create(user);
            if(userCreate==true)
            {
                return true;
            }
            return false;
        }
    }
}
