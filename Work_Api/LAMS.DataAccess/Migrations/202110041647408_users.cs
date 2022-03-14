namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "RoleName", "dbo.Roles");
            RenameColumn(table: "dbo.Users", name: "RoleName", newName: "RoleId");
            RenameIndex(table: "dbo.Users", name: "IX_RoleName", newName: "IX_RoleId");
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.Roles", "RoleName", c => c.String());
            AlterColumn("dbo.Roles", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Roles", "Id");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.Roles", "Id", c => c.String());
            AlterColumn("dbo.Roles", "RoleName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Roles", "RoleName");
            RenameIndex(table: "dbo.Users", name: "IX_RoleId", newName: "IX_RoleName");
            RenameColumn(table: "dbo.Users", name: "RoleId", newName: "RoleName");
            AddForeignKey("dbo.Users", "RoleName", "dbo.Roles", "RoleName");
        }
    }
}
