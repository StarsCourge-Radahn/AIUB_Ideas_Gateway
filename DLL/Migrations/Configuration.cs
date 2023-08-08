namespace DLL.Migrations
{
    using DLL.EF.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DLL.EF.AIGContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DLL.EF.AIGContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Seeding 5 users
            //for (int i = 1; i <= 5; i++)
            //{
            //    var user = new User
            //    {
            //        Name = $"User {i}",
            //        UserName = $"username{i}",
            //        Email = $"user{i}@example.com",
            //        Password = $"password{i}", // Note: Store hashed passwords, not plain text
            //        Role = "user"
            //    };
            //    context.Users.Add(user);
            //    context.SaveChanges(); // Save changes to get the generated UserID

            //    // Seeding posts for the user
            //    var post = new Post
            //    {
            //        Title = $"Post by {user.Name}",
            //        Content = $"This is a post by {user.Name}.",
            //        CreatedAt = DateTime.Now,
            //        UserID = user.UserID
            //    };
            //    context.Posts.Add(post);
            //    context.SaveChanges();

            //    // Seeding jobs for the user
            //    var job = new Job
            //    {
            //        Title = $"Job for {user.Name}",
            //        Description = $"This is a job description for {user.Name}.",
            //        CreatedAt = DateTime.Now,
            //        UserID = user.UserID
            //    };
            //    context.Jobs.Add(job);
            //    context.SaveChanges();
            //}
        }
    }
}
