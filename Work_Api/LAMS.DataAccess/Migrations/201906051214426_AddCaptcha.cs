namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCaptcha : DbMigration
    {
        public override void Up()
        {            
            CreateTable(
                "dbo.Captcha",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "ProviderActDepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DocumentTexts", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "ActKindId", "dbo.ActKinds");
            DropForeignKey("dbo.Documents", "ActCreatorDepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DocumentStatuses", "ProviderActDepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DocumentStatusTexts", "DocumentId", "dbo.DocumentStatuses");
            DropForeignKey("dbo.DocumentStatuses", "ActkindId", "dbo.ActKinds");
            DropForeignKey("dbo.DocumentStatuses", "ActCreatorDepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Documents", "AccepntanceOrganId", "dbo.AcceptanceOrgans");
            DropIndex("dbo.DocumentTexts", new[] { "DocumentId" });
            DropIndex("dbo.DocumentStatusTexts", new[] { "DocumentId" });
            DropIndex("dbo.DocumentStatuses", new[] { "ActCreatorDepartmentId" });
            DropIndex("dbo.DocumentStatuses", new[] { "ProviderActDepartmentId" });
            DropIndex("dbo.DocumentStatuses", new[] { "ActkindId" });
            DropIndex("dbo.Documents", new[] { "ProviderActDepartmentId" });
            DropIndex("dbo.Documents", new[] { "AccepntanceOrganId" });
            DropIndex("dbo.Documents", new[] { "ActCreatorDepartmentId" });
            DropIndex("dbo.Documents", new[] { "ActKindId" });
            DropTable("dbo.ThesaurusRequests");
            DropTable("dbo.Captcha");
            DropTable("dbo.DocumentTexts");
            DropTable("dbo.DocumentStatusTexts");
            DropTable("dbo.ActKinds");
            DropTable("dbo.DocumentStatuses");
            DropTable("dbo.Departments");
            DropTable("dbo.Documents");
            DropTable("dbo.AcceptanceOrgans");
        }
    }
}
