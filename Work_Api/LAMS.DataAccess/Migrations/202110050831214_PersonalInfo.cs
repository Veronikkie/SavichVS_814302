namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonalInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalInfo",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        Date = c.DateTime(nullable: false),
                        Adress = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Position = c.String(),
                        MinSalary = c.Int(nullable: false),
                        MaxSalary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalInfo", "UserId", "dbo.Users");
            DropIndex("dbo.PersonalInfo", new[] { "UserId" });
            DropTable("dbo.PersonalInfo");
        }
    }
}
