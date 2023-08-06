namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminDBAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false),
                        AdminPassword = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
            AddColumn("dbo.Jobs", "AdminID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Admin_AdminID", c => c.Int());
            AddColumn("dbo.Posts", "AdminID", c => c.Int(nullable: false));
            AddColumn("dbo.Sessions", "AdminID", c => c.Int(nullable: false));
            AddColumn("dbo.Tokens", "AdminID", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "AdminID");
            CreateIndex("dbo.Users", "Admin_AdminID");
            CreateIndex("dbo.Posts", "AdminID");
            CreateIndex("dbo.Sessions", "AdminID");
            CreateIndex("dbo.Tokens", "AdminID");
            AddForeignKey("dbo.Jobs", "AdminID", "dbo.Admins", "AdminID", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "AdminID", "dbo.Admins", "AdminID", cascadeDelete: true);
            AddForeignKey("dbo.Sessions", "AdminID", "dbo.Admins", "AdminID", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Admin_AdminID", "dbo.Admins", "AdminID");
            AddForeignKey("dbo.Tokens", "AdminID", "dbo.Admins", "AdminID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Users", "Admin_AdminID", "dbo.Admins");
            DropForeignKey("dbo.Sessions", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Posts", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Jobs", "AdminID", "dbo.Admins");
            DropIndex("dbo.Tokens", new[] { "AdminID" });
            DropIndex("dbo.Sessions", new[] { "AdminID" });
            DropIndex("dbo.Posts", new[] { "AdminID" });
            DropIndex("dbo.Users", new[] { "Admin_AdminID" });
            DropIndex("dbo.Jobs", new[] { "AdminID" });
            DropColumn("dbo.Tokens", "AdminID");
            DropColumn("dbo.Sessions", "AdminID");
            DropColumn("dbo.Posts", "AdminID");
            DropColumn("dbo.Users", "Admin_AdminID");
            DropColumn("dbo.Jobs", "AdminID");
            DropTable("dbo.Admins");
        }
    }
}
