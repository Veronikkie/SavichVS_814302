namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Documents", new[] { "AccepntanceOrganId", "iBase" }, "dbo.AcceptanceOrgans");
            DropForeignKey("dbo.DocumentStatuses", new[] { "ActCreatorDepartmentId", "iBase" }, "dbo.Departments");
            DropForeignKey("dbo.DocumentStatuses", new[] { "ActkindId", "iBase" }, "dbo.ActKinds");
            DropForeignKey("dbo.DocumentStatusTexts", "DocumentId", "dbo.DocumentStatuses");
            DropForeignKey("dbo.DocumentStatuses", new[] { "ProviderActDepartmentId", "iBase" }, "dbo.Departments");
            DropForeignKey("dbo.Documents", new[] { "ActCreatorDepartmentId", "iBase" }, "dbo.Departments");
            DropForeignKey("dbo.Documents", new[] { "ActKindId", "iBase" }, "dbo.ActKinds");
            DropForeignKey("dbo.DocumentTexts", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", new[] { "ProviderActDepartmentId", "iBase" }, "dbo.Departments");
            DropIndex("dbo.Documents", new[] { "ActKindId", "iBase" });
            DropIndex("dbo.Documents", new[] { "ActCreatorDepartmentId", "iBase" });
            DropIndex("dbo.Documents", new[] { "AccepntanceOrganId", "iBase" });
            DropIndex("dbo.Documents", new[] { "ProviderActDepartmentId", "iBase" });
            DropIndex("dbo.DocumentStatuses", new[] { "ActkindId", "iBase" });
            DropIndex("dbo.DocumentStatuses", new[] { "ProviderActDepartmentId", "iBase" });
            DropIndex("dbo.DocumentStatuses", new[] { "ActCreatorDepartmentId", "iBase" });
            DropIndex("dbo.DocumentStatusTexts", new[] { "DocumentId" });
            DropIndex("dbo.DocumentTexts", new[] { "DocumentId" });
            DropTable("dbo.AcceptanceOrgans");
            DropTable("dbo.Documents");
            DropTable("dbo.Departments");
            DropTable("dbo.DocumentStatuses");
            DropTable("dbo.ActKinds");
            DropTable("dbo.DocumentStatusTexts");
            DropTable("dbo.DocumentTexts");
            DropTable("dbo.Captcha");
            DropTable("dbo.ThesaurusRequests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ThesaurusRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThesType = c.Int(nullable: false),
                        BankCode = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        NCPICode = c.Int(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Captcha",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentTexts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        SavedDate = c.DateTime(),
                        Extension = c.String(),
                        Order = c.Int(nullable: false),
                        Text = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentStatusTexts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        SavedDate = c.DateTime(),
                        Extension = c.String(),
                        Order = c.Int(nullable: false),
                        Text = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActKinds",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        iBase = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.Code, t.iBase });
            
            CreateTable(
                "dbo.DocumentStatuses",
                c => new
                    {
                        DocumentId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                        ArrivedToNCPIDate = c.DateTime(),
                        IsChecked = c.Boolean(nullable: false),
                        CheckedDate = c.DateTime(),
                        IsApproved = c.Boolean(nullable: false),
                        ApprovedDate = c.DateTime(),
                        ReadyNCPI = c.Boolean(nullable: false),
                        ReadyNCPIDate = c.DateTime(),
                        ReadyBank = c.Boolean(nullable: false),
                        ReadyBankDate = c.DateTime(),
                        CommentNCPI = c.String(),
                        CommentBank = c.String(),
                        ActkindId = c.Int(nullable: false),
                        ActNumber = c.String(),
                        ActName = c.String(),
                        ActDate = c.DateTime(),
                        NumPages = c.Int(nullable: false),
                        ProviderActDepartmentId = c.Int(nullable: false),
                        ActCreatorDepartmentId = c.Int(nullable: false),
                        iBase = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        iBase = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.Code, t.iBase });
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SentToNCLI = c.DateTime(nullable: false),
                        ActNumber = c.String(),
                        AcceptanceActNumber = c.String(),
                        ActKindId = c.Int(nullable: false),
                        ActDate = c.DateTime(),
                        AcceptanceActDate = c.DateTime(),
                        ActName = c.String(),
                        ActCreatorDepartmentId = c.Int(nullable: false),
                        AccepntanceOrganId = c.Int(nullable: false),
                        OtherImportantInformation = c.String(),
                        ProviderFullName = c.String(),
                        ProviderPhoneNumber = c.String(),
                        ProviderActdate = c.DateTime(),
                        ProviderActDepartmentId = c.Int(nullable: false),
                        NumPages = c.Int(nullable: false),
                        ActDateTakeEffect = c.DateTime(),
                        ActDateLost = c.DateTime(),
                        ActNumberLost = c.String(),
                        NeedToDoFast = c.Boolean(nullable: false),
                        iBase = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AcceptanceOrgans",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        iBase = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.Code, t.iBase });
            
            CreateIndex("dbo.DocumentTexts", "DocumentId");
            CreateIndex("dbo.DocumentStatusTexts", "DocumentId");
            CreateIndex("dbo.DocumentStatuses", new[] { "ActCreatorDepartmentId", "iBase" });
            CreateIndex("dbo.DocumentStatuses", new[] { "ProviderActDepartmentId", "iBase" });
            CreateIndex("dbo.DocumentStatuses", new[] { "ActkindId", "iBase" });
            CreateIndex("dbo.Documents", new[] { "ProviderActDepartmentId", "iBase" });
            CreateIndex("dbo.Documents", new[] { "AccepntanceOrganId", "iBase" });
            CreateIndex("dbo.Documents", new[] { "ActCreatorDepartmentId", "iBase" });
            CreateIndex("dbo.Documents", new[] { "ActKindId", "iBase" });
            AddForeignKey("dbo.Documents", new[] { "ProviderActDepartmentId", "iBase" }, "dbo.Departments", new[] { "Code", "iBase" });
            AddForeignKey("dbo.DocumentTexts", "DocumentId", "dbo.Documents", "Id");
            AddForeignKey("dbo.Documents", new[] { "ActKindId", "iBase" }, "dbo.ActKinds", new[] { "Code", "iBase" });
            AddForeignKey("dbo.Documents", new[] { "ActCreatorDepartmentId", "iBase" }, "dbo.Departments", new[] { "Code", "iBase" });
            AddForeignKey("dbo.DocumentStatuses", new[] { "ProviderActDepartmentId", "iBase" }, "dbo.Departments", new[] { "Code", "iBase" });
            AddForeignKey("dbo.DocumentStatusTexts", "DocumentId", "dbo.DocumentStatuses", "DocumentId");
            AddForeignKey("dbo.DocumentStatuses", new[] { "ActkindId", "iBase" }, "dbo.ActKinds", new[] { "Code", "iBase" });
            AddForeignKey("dbo.DocumentStatuses", new[] { "ActCreatorDepartmentId", "iBase" }, "dbo.Departments", new[] { "Code", "iBase" });
            AddForeignKey("dbo.Documents", new[] { "AccepntanceOrganId", "iBase" }, "dbo.AcceptanceOrgans", new[] { "Code", "iBase" });
        }
    }
}
