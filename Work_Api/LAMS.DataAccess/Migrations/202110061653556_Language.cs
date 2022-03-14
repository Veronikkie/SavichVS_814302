namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Language : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LanguageDbs", newName: "Language");
            DropIndex("dbo.Language", new[] { "Users_Id" });
            DropColumn("dbo.Language", "UserId");
            RenameColumn(table: "dbo.Language", name: "Users_Id", newName: "UserId");
            AlterColumn("dbo.Language", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Language", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Language", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Language", new[] { "UserId" });
            AlterColumn("dbo.Language", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Language", "UserId", c => c.String());
            RenameColumn(table: "dbo.Language", name: "UserId", newName: "Users_Id");
            AddColumn("dbo.Language", "UserId", c => c.String());
            CreateIndex("dbo.Language", "Users_Id");
            RenameTable(name: "dbo.Language", newName: "LanguageDbs");
        }
    }
}
