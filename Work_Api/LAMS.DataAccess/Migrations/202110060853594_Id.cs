namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Id : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PersonalInfo");
            AlterColumn("dbo.PersonalInfo", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.PersonalInfo", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PersonalInfo");
            AlterColumn("dbo.PersonalInfo", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.PersonalInfo", "Id");
        }
    }
}
