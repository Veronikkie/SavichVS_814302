namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIBaseDocumentStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocumentStatuses", "iBase", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DocumentStatuses", "iBase");
        }
    }
}
