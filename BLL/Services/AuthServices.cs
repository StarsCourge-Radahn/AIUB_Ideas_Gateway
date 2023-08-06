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

                var userSession = new Session();
                userSession.UserID = data.UserID;
                userSession.LoginTime = DateTime.Now;
                userSession.IsActive = true;

                var tk = DataAccessFactory.TokenDataAccess().Create(token);
                var checkSession = DataAccessFactory.SessionDataAccess().Create(userSession);

                if (checkSession == true)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(config);
                    var rtn = mapper.Map<TokenDTO>(tk);
                    return rtn;
                }
                return null;
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

        public static int GetUserID(string token)
        {
            var id = (from t in DataAccessFactory.TokenDataAccess().GetAll()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      select t.UserId).SingleOrDefault();
            return id;
        }

        public static SessionDTO GetUserActiveSession(int userid)
        {
            var data = DataAccessFactory.SessionDataAccess().GetByID(userid);
            if(data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Session, SessionDTO>();
                });
                var mapper = new Mapper(config);
                var rtn = mapper.Map<SessionDTO>(data);
                return rtn;
            }
            return null;
        }

        public static bool ChangeSession(SessionDTO obj)
        {
            var data = new Session();
            data.UserID = obj.UserID;
            data.LogoutTime = obj.LogoutTime;
            data.IsActive = false;

            var rtn = DataAccessFactory.SessionDataAccess().Update(data);

            return rtn == true;
        }
    }
}
