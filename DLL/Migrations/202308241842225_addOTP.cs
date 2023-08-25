namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOTP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OTPs",
                c => new
                    {
                        OTPId = c.Int(nullable: false, identity: true),
                        OTPName = c.String(),
                        ExpirationTime = c.DateTime(nullable: false),
                        IsUsed = c.Boolean(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OTPId)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OTPs", "UserID", "dbo.Users");
            DropIndex("dbo.OTPs", new[] { "UserID" });
            DropTable("dbo.OTPs");
        }
    }
}
