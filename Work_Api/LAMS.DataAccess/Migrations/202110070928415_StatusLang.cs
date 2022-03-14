namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusLang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Language", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Language", "Status");
        }
    }
}
