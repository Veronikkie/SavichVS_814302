namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusEd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Education", "CreateDate", c => c.String());
            AddColumn("dbo.Education", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Education", "Status");
            DropColumn("dbo.Education", "CreateDate");
        }
    }
}
