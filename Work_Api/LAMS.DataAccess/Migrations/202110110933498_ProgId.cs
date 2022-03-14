namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProgId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProgLang", "ProgLangId", "dbo.ProgLang");
            DropIndex("dbo.UserProgLang", new[] { "ProgLangId" });
            DropPrimaryKey("dbo.ProgLang");
            AlterColumn("dbo.UserProgLang", "ProgLangId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProgLang", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProgLang", "Id");
            CreateIndex("dbo.UserProgLang", "ProgLangId");
            AddForeignKey("dbo.UserProgLang", "ProgLangId", "dbo.ProgLang", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProgLang", "ProgLangId", "dbo.ProgLang");
            DropIndex("dbo.UserProgLang", new[] { "ProgLangId" });
            DropPrimaryKey("dbo.ProgLang");
            AlterColumn("dbo.ProgLang", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserProgLang", "ProgLangId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ProgLang", "Id");
            CreateIndex("dbo.UserProgLang", "ProgLangId");
            AddForeignKey("dbo.UserProgLang", "ProgLangId", "dbo.ProgLang", "Id");
        }
    }
}
