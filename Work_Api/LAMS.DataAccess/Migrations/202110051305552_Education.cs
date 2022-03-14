namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Education : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Education = c.String(),
                        EducationType = c.String(),
                        Institution = c.String(),
                        Faculty = c.String(),
                        Speciality = c.String(),
                        End = c.Int(nullable: false),
                        AnotherInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Education", "UserId", "dbo.Users");
            DropIndex("dbo.Education", new[] { "UserId" });
            DropTable("dbo.Education");
        }
    }
}
