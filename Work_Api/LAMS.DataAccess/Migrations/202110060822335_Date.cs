namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Date : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Education", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PersonalInfo", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonalInfo", "CreateDate", c => c.String());
            AlterColumn("dbo.Education", "CreateDate", c => c.String());
        }
    }
}
