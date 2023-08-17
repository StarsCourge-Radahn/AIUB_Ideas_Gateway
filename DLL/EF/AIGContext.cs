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
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // User CV stuffs
        public DbSet<CV> CVs { get; set; }
        public DbSet<AcademicQualification> AcademicQualifications { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ThesisPaper> ThesisPapers { get; set; }
        public DbSet<Award> Awards { get; set; }

        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Define one-to-zero/one relationship between User and CV
            modelBuilder.Entity<User>()
                .HasOptional(u => u.CV) // User may or may not have a CV
                .WithRequired(cv => cv.User); // CV has a mandatory User

            modelBuilder.Entity<JobApplication>()
                .HasRequired(ja => ja.User)
                .WithMany(u => u.JobApplications)
                .HasForeignKey(ja => ja.UserId)
                .WillCascadeOnDelete(false); // Prevent cascade delete

            base.OnModelCreating(modelBuilder);
        }
    }
}
