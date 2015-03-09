namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedTextContents : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TextContent", "TextId", "dbo.Partial");
            DropIndex("dbo.TextContent", new[] { "TextId" });
            AddColumn("dbo.Partial", "Content", c => c.String());
            DropColumn("dbo.Partial", "DiagramInfo");
            DropTable("dbo.TextContent");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TextContent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextId = c.Int(nullable: false),
                        Content = c.String(),
                        TextType = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Partial", "DiagramInfo", c => c.Int());
            DropColumn("dbo.Partial", "Content");
            CreateIndex("dbo.TextContent", "TextId");
            AddForeignKey("dbo.TextContent", "TextId", "dbo.Partial", "Id", cascadeDelete: true);
        }
    }
}
