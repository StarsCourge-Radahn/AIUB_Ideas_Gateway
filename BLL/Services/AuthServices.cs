using BLL.DTOs;
using DLL;
using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services
{
    public class AuthServices
    {
        public static TokenDTO Login(string username, string password)
        {
            var data = DataAccessFactory.AuthDataAccess().Authenticate(username, password);
            if (data != null)
            {
                var token = new Token();
                token.UserId = data.UserID;
                token.TokenKey = Guid.NewGuid().ToString();
                token.CreatedAt = DateTime.Now;
                token.ExpiredAt = null;
                var tk = DataAccessFactory.TokenDataAccess().Create(token);

                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Token, TokenDTO>();
                });
                var mapper = new Mapper(config);
                var rtn = mapper.Map<TokenDTO>(tk);
                return rtn;
            }
            return null;
        }

        public static bool IsTokenValid(string token)
        {
            var tk = (from t in DataAccessFactory.TokenDataAccess().GetAll()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      select t).SingleOrDefault();
            if (tk != null)
            {
                return true;
            }
            return false;
        }

        public static bool IsAdmin(string token)
        {
            var tk = (from t in DataAccessFactory.TokenDataAccess().GetAll()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      && t.User.Role.Equals("admin")
                      select t).SingleOrDefault();
            return tk != null;
        }
    }
}
