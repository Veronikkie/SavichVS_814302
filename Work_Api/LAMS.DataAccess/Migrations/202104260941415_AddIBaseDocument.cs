namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIBaseDocument : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "iBase", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "iBase");
        }
    }
}
