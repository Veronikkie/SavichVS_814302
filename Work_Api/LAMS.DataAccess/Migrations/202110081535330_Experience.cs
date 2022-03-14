namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Experience : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ExperienceDbs", newName: "Experience");
            DropIndex("dbo.Experience", new[] { "Users_Id" });
            DropColumn("dbo.Experience", "UserId");
            RenameColumn(table: "dbo.Experience", name: "Users_Id", newName: "UserId");
            AlterColumn("dbo.Experience", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Experience", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Experience", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Experience", new[] { "UserId" });
            AlterColumn("dbo.Experience", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Experience", "UserId", c => c.String());
            RenameColumn(table: "dbo.Experience", name: "UserId", newName: "Users_Id");
            AddColumn("dbo.Experience", "UserId", c => c.String());
            CreateIndex("dbo.Experience", "Users_Id");
            RenameTable(name: "dbo.Experience", newName: "ExperienceDbs");
        }
    }
}
