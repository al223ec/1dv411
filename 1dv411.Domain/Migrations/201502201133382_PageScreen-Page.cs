namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageScreenPage : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PageScreen", name: "LayoutId", newName: "PageId");
            RenameIndex(table: "dbo.PageScreen", name: "IX_LayoutId", newName: "IX_PageId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PageScreen", name: "IX_PageId", newName: "IX_LayoutId");
            RenameColumn(table: "dbo.PageScreen", name: "PageId", newName: "LayoutId");
        }
    }
}
