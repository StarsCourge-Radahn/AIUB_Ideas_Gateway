namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CvUserRelationRevised : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobApplications", "CvID", "dbo.CVs");
            DropForeignKey("dbo.JobApplications", "User_UserID", "dbo.Users");
            DropIndex("dbo.JobApplications", new[] { "CvID" });
            DropIndex("dbo.JobApplications", new[] { "User_UserID" });
            RenameColumn(table: "dbo.JobApplications", name: "User_UserID", newName: "UserId");
            AlterColumn("dbo.JobApplications", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobApplications", "UserId");
            AddForeignKey("dbo.JobApplications", "UserId", "dbo.Users", "UserID", cascadeDelete: true);
            DropColumn("dbo.JobApplications", "CvID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobApplications", "CvID", c => c.Int(nullable: false));
            DropForeignKey("dbo.JobApplications", "UserId", "dbo.Users");
            DropIndex("dbo.JobApplications", new[] { "UserId" });
            AlterColumn("dbo.JobApplications", "UserId", c => c.Int());
            RenameColumn(table: "dbo.JobApplications", name: "UserId", newName: "User_UserID");
            CreateIndex("dbo.JobApplications", "User_UserID");
            CreateIndex("dbo.JobApplications", "CvID");
            AddForeignKey("dbo.JobApplications", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.JobApplications", "CvID", "dbo.CVs", "CVId", cascadeDelete: true);
        }
    }
}
