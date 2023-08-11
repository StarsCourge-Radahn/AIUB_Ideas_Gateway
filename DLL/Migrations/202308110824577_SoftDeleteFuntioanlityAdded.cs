namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoftDeleteFuntioanlityAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "IsBan", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "IsBan", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsBan", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "TemporaryBan", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "IsBan", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "IsDeleted");
            DropColumn("dbo.Posts", "IsBan");
            DropColumn("dbo.Users", "IsDeleted");
            DropColumn("dbo.Users", "TemporaryBan");
            DropColumn("dbo.Users", "IsBan");
            DropColumn("dbo.Jobs", "IsDeleted");
            DropColumn("dbo.Jobs", "IsBan");
            DropColumn("dbo.Comments", "IsDeleted");
            DropColumn("dbo.Comments", "IsBan");
        }
    }
}
