using DLL.EF.Models;
using DLL.Interfaces;
using DLL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, bool, string> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IAuth AuthDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<Token, int, Token, string> TokenDataAccess()
        {
            return new TokenRepo();
        }

        public static IRepo<Post, int, bool, string> PostDataAccess()
        {
            return new PostRepo();
        }

        public static IRepo<Session, int, bool, string> SessionDataAccess()
        {
            return new SessionRepo();
        }
    }
}
