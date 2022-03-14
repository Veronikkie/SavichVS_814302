namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        PersonalInfoId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalInfo", t => t.PersonalInfoId)
                .Index(t => t.PersonalInfoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "PersonalInfoId", "dbo.PersonalInfo");
            DropIndex("dbo.Question", new[] { "PersonalInfoId" });
            DropTable("dbo.Question");
        }
    }
}
