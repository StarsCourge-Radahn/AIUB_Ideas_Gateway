namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReconstractUserProperty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionID = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        LoginTime = c.DateTime(),
                        LogoutTime = c.DateTime(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SessionID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenKey = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "UserId", "dbo.Users");
            DropForeignKey("dbo.Jobs", "UserID", "dbo.Users");
            DropForeignKey("dbo.Sessions", "UserID", "dbo.Users");
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "UserId" });
            DropIndex("dbo.Sessions", new[] { "UserID" });
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropIndex("dbo.Jobs", new[] { "UserID" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Sessions");
            DropTable("dbo.Posts");
            DropTable("dbo.Users");
            DropTable("dbo.Jobs");
        }
    }
}
