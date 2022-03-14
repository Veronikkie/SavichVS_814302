namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalInfo", "CreateDate", c => c.String());
            AddColumn("dbo.PersonalInfo", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalInfo", "Status");
            DropColumn("dbo.PersonalInfo", "CreateDate");
        }
    }
}
