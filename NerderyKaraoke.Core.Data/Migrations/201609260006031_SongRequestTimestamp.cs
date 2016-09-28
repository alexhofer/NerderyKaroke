namespace NerderyKaraoke.Core.Data.Migrations
{ 
    using System.Data.Entity.Migrations;
    
    public partial class SongRequestTimestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SongRequests", "CreateDateTime", c => c.DateTime(nullable: false, defaultValueSql:"GETDATE()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SongRequests", "CreateDateTime");
        }
    }
}
