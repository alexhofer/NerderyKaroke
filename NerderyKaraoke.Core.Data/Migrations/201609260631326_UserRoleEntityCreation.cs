namespace NerderyKaraoke.Core.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoleEntityCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Role = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserName, t.Role });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRoles");
        }
    }
}
