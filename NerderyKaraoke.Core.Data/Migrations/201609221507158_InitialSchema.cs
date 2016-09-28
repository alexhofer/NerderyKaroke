namespace NerderyKaraoke.Core.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SongRequests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SingerName = c.String(nullable: false, maxLength: 70),
                        SongTitle = c.String(nullable: false, maxLength: 100),
                        YouTubeUrl = c.String(maxLength: 1024),
                        RequestOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SongRequests");
        }
    }
}
