namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCVNullallowed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "CvId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "CvId", c => c.Int(nullable: false));
        }
    }
}
