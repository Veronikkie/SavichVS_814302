namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Salary : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonalInfo", "MinSalary", c => c.String());
            AlterColumn("dbo.PersonalInfo", "MaxSalary", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonalInfo", "MaxSalary", c => c.Int(nullable: false));
            AlterColumn("dbo.PersonalInfo", "MinSalary", c => c.Int(nullable: false));
        }
    }
}
