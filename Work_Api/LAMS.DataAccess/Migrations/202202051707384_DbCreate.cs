namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SavedDate = c.DateTime(),
                        PersonalInfoId = c.String(nullable: false, maxLength: 128),
                        Extension = c.String(),
                        Number = c.Int(nullable: false),
                        Text = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalInfo", t => t.PersonalInfoId)
                .Index(t => t.PersonalInfoId);
            
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
                        MinSalary = c.String(),
                        MaxSalary = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PersonalInfoId = c.String(nullable: false, maxLength: 128),
                        Education = c.String(),
                        EducationType = c.String(),
                        Institution = c.String(),
                        Faculty = c.String(),
                        Speciality = c.String(),
                        End = c.Int(nullable: false),
                        AnotherInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalInfo", t => t.PersonalInfoId)
                .Index(t => t.PersonalInfoId);
            
            CreateTable(
                "dbo.Experience",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PersonalInfoId = c.String(nullable: false, maxLength: 128),
                        Experience = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalInfo", t => t.PersonalInfoId)
                .Index(t => t.PersonalInfoId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PersonalInfoId = c.String(nullable: false, maxLength: 128),
                        English = c.String(),
                        German = c.String(),
                        French = c.String(),
                        Spanish = c.String(),
                        Chinese = c.String(),
                        Arab = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalInfo", t => t.PersonalInfoId)
                .Index(t => t.PersonalInfoId);
            
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
            
            CreateTable(
                "dbo.UserProgLang",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PersonalInfoId = c.String(nullable: false, maxLength: 128),
                        ProgLangId = c.Int(nullable: false),
                        Level = c.String(),
                        Period = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalInfo", t => t.PersonalInfoId)
                .ForeignKey("dbo.ProgLang", t => t.ProgLangId)
                .Index(t => t.PersonalInfoId)
                .Index(t => t.ProgLangId);
            
            CreateTable(
                "dbo.ProgLang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgLang = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Created = c.DateTime(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        UserName = c.String(),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "PersonalInfoId", "dbo.PersonalInfo");
            DropForeignKey("dbo.PersonalInfo", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserProgLang", "ProgLangId", "dbo.ProgLang");
            DropForeignKey("dbo.UserProgLang", "PersonalInfoId", "dbo.PersonalInfo");
            DropForeignKey("dbo.Question", "PersonalInfoId", "dbo.PersonalInfo");
            DropForeignKey("dbo.Language", "PersonalInfoId", "dbo.PersonalInfo");
            DropForeignKey("dbo.Experience", "PersonalInfoId", "dbo.PersonalInfo");
            DropForeignKey("dbo.Education", "PersonalInfoId", "dbo.PersonalInfo");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.UserProgLang", new[] { "ProgLangId" });
            DropIndex("dbo.UserProgLang", new[] { "PersonalInfoId" });
            DropIndex("dbo.Question", new[] { "PersonalInfoId" });
            DropIndex("dbo.Language", new[] { "PersonalInfoId" });
            DropIndex("dbo.Experience", new[] { "PersonalInfoId" });
            DropIndex("dbo.Education", new[] { "PersonalInfoId" });
            DropIndex("dbo.PersonalInfo", new[] { "UserId" });
            DropIndex("dbo.Documents", new[] { "PersonalInfoId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.ProgLang");
            DropTable("dbo.UserProgLang");
            DropTable("dbo.Question");
            DropTable("dbo.Language");
            DropTable("dbo.Experience");
            DropTable("dbo.Education");
            DropTable("dbo.PersonalInfo");
            DropTable("dbo.Documents");
        }
    }
}
