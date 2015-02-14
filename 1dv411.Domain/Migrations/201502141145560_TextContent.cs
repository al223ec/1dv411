namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TextContent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TextContent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextId = c.Int(nullable: false),
                        Content = c.String(),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Partial", t => t.TextId, cascadeDelete: true)
                .Index(t => t.TextId);
            
            DropColumn("dbo.Partial", "Heading");
            DropColumn("dbo.Partial", "Footer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Partial", "Footer", c => c.String());
            AddColumn("dbo.Partial", "Heading", c => c.String());
            DropForeignKey("dbo.TextContent", "TextId", "dbo.Partial");
            DropIndex("dbo.TextContent", new[] { "TextId" });
            DropTable("dbo.TextContent");
        }
    }
}
