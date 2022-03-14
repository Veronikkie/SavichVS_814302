namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clear : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AcceptanceOrgans", "iBase");
            DropColumn("dbo.Departments", "iBase");
            DropColumn("dbo.ActKinds", "iBase");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActKinds", "iBase", c => c.Int(nullable: false));
            AddColumn("dbo.Departments", "iBase", c => c.Int(nullable: false));
            AddColumn("dbo.AcceptanceOrgans", "iBase", c => c.Int(nullable: false));
        }
    }
}
