namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcceptanceOrgans", "iBase", c => c.Int(nullable: false));
            AddColumn("dbo.Departments", "iBase", c => c.Int(nullable: false));
            AddColumn("dbo.ActKinds", "iBase", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActKinds", "iBase");
            DropColumn("dbo.Departments", "iBase");
            DropColumn("dbo.AcceptanceOrgans", "iBase");
        }
    }
}
