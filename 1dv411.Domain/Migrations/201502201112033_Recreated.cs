namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Partial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DiagramInfo = c.Int(),
                        DiagramType = c.Int(),
                        Url = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Page", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Page",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TemplateId = c.Int(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Template", t => t.TemplateId, cascadeDelete: true)
                .Index(t => t.TemplateId);
            
            CreateTable(
                "dbo.PageScreen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScreenId = c.Int(nullable: false),
                        LayoutId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Page", t => t.LayoutId, cascadeDelete: true)
                .ForeignKey("dbo.Screen", t => t.ScreenId, cascadeDelete: true)
                .Index(t => t.ScreenId)
                .Index(t => t.LayoutId);
            
            CreateTable(
                "dbo.Screen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Timer = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Partial", t => t.TextId, cascadeDelete: true)
                .Index(t => t.TextId);
            
            CreateTable(
                "dbo.Template",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FileName = c.String(),
                        NumberOfPartials = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderGroupId = c.String(),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Page", "TemplateId", "dbo.Template");
            DropForeignKey("dbo.TextContent", "TextId", "dbo.Partial");
            DropForeignKey("dbo.Partial", "PageId", "dbo.Page");
            DropForeignKey("dbo.PageScreen", "ScreenId", "dbo.Screen");
            DropForeignKey("dbo.PageScreen", "LayoutId", "dbo.Page");
            DropIndex("dbo.TextContent", new[] { "TextId" });
            DropIndex("dbo.PageScreen", new[] { "LayoutId" });
            DropIndex("dbo.PageScreen", new[] { "ScreenId" });
            DropIndex("dbo.Page", new[] { "TemplateId" });
            DropIndex("dbo.Partial", new[] { "PageId" });
            DropTable("dbo.Order");
            DropTable("dbo.Template");
            DropTable("dbo.TextContent");
            DropTable("dbo.Screen");
            DropTable("dbo.PageScreen");
            DropTable("dbo.Page");
            DropTable("dbo.Partial");
        }
    }
}
