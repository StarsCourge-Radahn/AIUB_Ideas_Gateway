using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF
{
    public class AIGContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
