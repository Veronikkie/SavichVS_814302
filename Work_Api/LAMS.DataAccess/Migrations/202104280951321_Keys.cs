namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Keys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Documents", "AccepntanceOrganId", "dbo.AcceptanceOrgans");
            DropForeignKey("dbo.Documents", "ActCreatorDepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Documents", "ActKindId", "dbo.ActKinds");
            DropForeignKey("dbo.Documents", "ProviderActDepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DocumentStatuses", "ActCreatorDepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DocumentStatuses", "ProviderActDepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DocumentStatuses", "ActkindId", "dbo.ActKinds");
            DropIndex("dbo.Documents", new[] { "ActKindId" });
            DropIndex("dbo.Documents", new[] { "ActCreatorDepartmentId" });
            DropIndex("dbo.Documents", new[] { "AccepntanceOrganId" });
            DropIndex("dbo.Documents", new[] { "ProviderActDepartmentId" });
            DropIndex("dbo.DocumentStatuses", new[] { "ActkindId" });
            DropIndex("dbo.DocumentStatuses", new[] { "ProviderActDepartmentId" });
            DropIndex("dbo.DocumentStatuses", new[] { "ActCreatorDepartmentId" });
            DropPrimaryKey("dbo.AcceptanceOrgans");
            DropPrimaryKey("dbo.Departments");
            DropPrimaryKey("dbo.ActKinds");
            AddPrimaryKey("dbo.AcceptanceOrgans", new[] { "Code", "iBase" });
            AddPrimaryKey("dbo.Departments", new[] { "Code", "iBase" });
            AddPrimaryKey("dbo.ActKinds", new[] { "Code", "iBase" });
            CreateIndex("dbo.Documents", new[] { "ActKindId", "iBase" });
            CreateIndex("dbo.Documents", new[] { "ActCreatorDepartmentId", "iBase" });
            CreateIndex("dbo.Documents", new[] { "AccepntanceOrganId", "iBase" });
            CreateIndex("dbo.Documents", new[] { "ProviderActDepartmentId", "iBase" });
            CreateIndex("dbo.DocumentStatuses", new[] { "ActkindId", "iBase" });
            CreateIndex("dbo.DocumentStatuses", new[] { "ProviderActDepartmentId", "iBase" });
            CreateIndex("dbo.DocumentStatuses", new[] { "ActCreatorDepartmentId", "iBase" });
            AddForeignKey("dbo.Documents", new[] { "AccepntanceOrganId", "iBase" }, "dbo.AcceptanceOrgans", new[] { "Code", "iBase" });
            AddForeignKey("dbo.Documents", new[] { "ActCreatorDepartmentId", "iBase" }, "dbo.Departments", new[] { "Code", "iBase" });
            AddForeignKey("dbo.Documents", new[] { "ActKindId", "iBase" }, "dbo.ActKinds", new[] { "Code", "iBase" });
            AddForeignKey("dbo.Documents", new[] { "ProviderActDepartmentId", "iBase" }, "dbo.Departments", new[] { "Code", "iBase" });
            AddForeignKey("dbo.DocumentStatuses", new[] { "ActCreatorDepartmentId", "iBase" }, "dbo.Departments", new[] { "Code", "iBase" });
            AddForeignKey("dbo.DocumentStatuses", new[] { "ProviderActDepartmentId", "iBase" }, "dbo.Departments", new[] { "Code", "iBase" });
            AddForeignKey("dbo.DocumentStatuses", new[] { "ActkindId", "iBase" }, "dbo.ActKinds", new[] { "Code", "iBase" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DocumentStatuses", new[] { "ActkindId", "iBase" }, "dbo.ActKinds");
            DropForeignKey("dbo.DocumentStatuses", new[] { "ProviderActDepartmentId", "iBase" }, "dbo.Departments");
            DropForeignKey("dbo.DocumentStatuses", new[] { "ActCreatorDepartmentId", "iBase" }, "dbo.Departments");
            DropForeignKey("dbo.Documents", new[] { "ProviderActDepartmentId", "iBase" }, "dbo.Departments");
            DropForeignKey("dbo.Documents", new[] { "ActKindId", "iBase" }, "dbo.ActKinds");
            DropForeignKey("dbo.Documents", new[] { "ActCreatorDepartmentId", "iBase" }, "dbo.Departments");
            DropForeignKey("dbo.Documents", new[] { "AccepntanceOrganId", "iBase" }, "dbo.AcceptanceOrgans");
            DropIndex("dbo.DocumentStatuses", new[] { "ActCreatorDepartmentId", "iBase" });
            DropIndex("dbo.DocumentStatuses", new[] { "ProviderActDepartmentId", "iBase" });
            DropIndex("dbo.DocumentStatuses", new[] { "ActkindId", "iBase" });
            DropIndex("dbo.Documents", new[] { "ProviderActDepartmentId", "iBase" });
            DropIndex("dbo.Documents", new[] { "AccepntanceOrganId", "iBase" });
            DropIndex("dbo.Documents", new[] { "ActCreatorDepartmentId", "iBase" });
            DropIndex("dbo.Documents", new[] { "ActKindId", "iBase" });
            DropPrimaryKey("dbo.ActKinds");
            DropPrimaryKey("dbo.Departments");
            DropPrimaryKey("dbo.AcceptanceOrgans");
            AddPrimaryKey("dbo.ActKinds", "Code");
            AddPrimaryKey("dbo.Departments", "Code");
            AddPrimaryKey("dbo.AcceptanceOrgans", "Code");
            CreateIndex("dbo.DocumentStatuses", "ActCreatorDepartmentId");
            CreateIndex("dbo.DocumentStatuses", "ProviderActDepartmentId");
            CreateIndex("dbo.DocumentStatuses", "ActkindId");
            CreateIndex("dbo.Documents", "ProviderActDepartmentId");
            CreateIndex("dbo.Documents", "AccepntanceOrganId");
            CreateIndex("dbo.Documents", "ActCreatorDepartmentId");
            CreateIndex("dbo.Documents", "ActKindId");
            AddForeignKey("dbo.DocumentStatuses", "ActkindId", "dbo.ActKinds", "Code");
            AddForeignKey("dbo.DocumentStatuses", "ProviderActDepartmentId", "dbo.Departments", "Code");
            AddForeignKey("dbo.DocumentStatuses", "ActCreatorDepartmentId", "dbo.Departments", "Code");
            AddForeignKey("dbo.Documents", "ProviderActDepartmentId", "dbo.Departments", "Code");
            AddForeignKey("dbo.Documents", "ActKindId", "dbo.ActKinds", "Code");
            AddForeignKey("dbo.Documents", "ActCreatorDepartmentId", "dbo.Departments", "Code");
            AddForeignKey("dbo.Documents", "AccepntanceOrganId", "dbo.AcceptanceOrgans", "Code");
        }
    }
}
