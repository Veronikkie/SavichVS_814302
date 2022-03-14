namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProgLang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProgLang",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ProgLangId = c.String(nullable: false, maxLength: 128),
                        Level = c.String(),
                        Period = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProgLang", t => t.ProgLangId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProgLangId);
            
            CreateTable(
                "dbo.ProgLang",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProgLang = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProgLang", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserProgLang", "ProgLangId", "dbo.ProgLang");
            DropIndex("dbo.UserProgLang", new[] { "ProgLangId" });
            DropIndex("dbo.UserProgLang", new[] { "UserId" });
            DropTable("dbo.ProgLang");
            DropTable("dbo.UserProgLang");
        }
    }
}
