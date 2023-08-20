namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udpate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicQualifications",
                c => new
                    {
                        QualificationId = c.Int(nullable: false, identity: true),
                        Degree = c.String(),
                        Institution = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        CVId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QualificationId)
                .ForeignKey("dbo.CVs", t => t.CVId, cascadeDelete: true)
                .Index(t => t.CVId);
            
            CreateTable(
                "dbo.CVs",
                c => new
                    {
                        CVId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CVId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Awards",
                c => new
                    {
                        AwardId = c.Int(nullable: false, identity: true),
                        AwardName = c.String(),
                        AwardingInstitution = c.String(),
                        DateReceived = c.DateTime(nullable: false),
                        CVId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AwardId)
                .ForeignKey("dbo.CVs", t => t.CVId, cascadeDelete: true)
                .Index(t => t.CVId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Position = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        CVId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExperienceId)
                .ForeignKey("dbo.CVs", t => t.CVId, cascadeDelete: true)
                .Index(t => t.CVId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        Proficiency = c.String(),
                        CVId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId)
                .ForeignKey("dbo.CVs", t => t.CVId, cascadeDelete: true)
                .Index(t => t.CVId);
            
            CreateTable(
                "dbo.ThesisPapers",
                c => new
                    {
                        ThesisId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PublicationDate = c.DateTime(nullable: false),
                        CoAuthors = c.String(),
                        CVId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ThesisId)
                .ForeignKey("dbo.CVs", t => t.CVId, cascadeDelete: true)
                .Index(t => t.CVId);
            
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
                        IsBan = c.Boolean(nullable: false),
                        TemporaryBan = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsBan = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UserID = c.Int(),
                        PostID = c.Int(),
                        JobID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Jobs", t => t.JobID)
                .ForeignKey("dbo.Posts", t => t.PostID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.PostID)
                .Index(t => t.JobID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        IsBan = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        JobApplicationId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        AppliedOn = c.DateTime(nullable: false),
                        ApplicationStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobApplicationId)
                .ForeignKey("dbo.Jobs", t => t.JobId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsBan = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
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
            DropForeignKey("dbo.AcademicQualifications", "CVId", "dbo.CVs");
            DropForeignKey("dbo.CVs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Sessions", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Jobs", "UserID", "dbo.Users");
            DropForeignKey("dbo.JobApplications", "UserId", "dbo.Users");
            DropForeignKey("dbo.JobApplications", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Comments", "JobID", "dbo.Jobs");
            DropForeignKey("dbo.ThesisPapers", "CVId", "dbo.CVs");
            DropForeignKey("dbo.Skills", "CVId", "dbo.CVs");
            DropForeignKey("dbo.Experiences", "CVId", "dbo.CVs");
            DropForeignKey("dbo.Awards", "CVId", "dbo.CVs");
            DropIndex("dbo.Tokens", new[] { "UserId" });
            DropIndex("dbo.Sessions", new[] { "UserID" });
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropIndex("dbo.JobApplications", new[] { "JobId" });
            DropIndex("dbo.JobApplications", new[] { "UserId" });
            DropIndex("dbo.Jobs", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "JobID" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.ThesisPapers", new[] { "CVId" });
            DropIndex("dbo.Skills", new[] { "CVId" });
            DropIndex("dbo.Experiences", new[] { "CVId" });
            DropIndex("dbo.Awards", new[] { "CVId" });
            DropIndex("dbo.CVs", new[] { "UserId" });
            DropIndex("dbo.AcademicQualifications", new[] { "CVId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Sessions");
            DropTable("dbo.Posts");
            DropTable("dbo.JobApplications");
            DropTable("dbo.Jobs");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.ThesisPapers");
            DropTable("dbo.Skills");
            DropTable("dbo.Experiences");
            DropTable("dbo.Awards");
            DropTable("dbo.CVs");
            DropTable("dbo.AcademicQualifications");
        }
    }
}
