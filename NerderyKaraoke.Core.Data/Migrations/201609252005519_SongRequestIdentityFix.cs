namespace NerderyKaraoke.Core.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SongRequestIdentityFix : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SongRequests");
            AlterColumn("dbo.SongRequests", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql:"newid()"));
            AddPrimaryKey("dbo.SongRequests", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SongRequests");
            AlterColumn("dbo.SongRequests", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.SongRequests", "Id");
        }
    }
}
