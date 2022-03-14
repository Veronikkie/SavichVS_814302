namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdEd : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Education");
            AlterColumn("dbo.Education", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Education", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Education");
            AlterColumn("dbo.Education", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Education", "Id");
        }
    }
}
