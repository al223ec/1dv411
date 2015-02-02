namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Design",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfFields = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Layout",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignId = c.Int(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Design", t => t.DesignId, cascadeDelete: true)
                .Index(t => t.DesignId);
            
            CreateTable(
                "dbo.Diagram",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LayoutId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Layout", t => t.LayoutId, cascadeDelete: true)
                .Index(t => t.LayoutId);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LayoutId = c.Int(nullable: false),
                        Url = c.String(),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Layout", t => t.LayoutId, cascadeDelete: true)
                .Index(t => t.LayoutId);
            
            CreateTable(
                "dbo.Text",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LayoutId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Value = c.String(),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Layout", t => t.LayoutId, cascadeDelete: true)
                .Index(t => t.LayoutId);
            
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
            DropForeignKey("dbo.Text", "LayoutId", "dbo.Layout");
            DropForeignKey("dbo.Image", "LayoutId", "dbo.Layout");
            DropForeignKey("dbo.Diagram", "LayoutId", "dbo.Layout");
            DropForeignKey("dbo.Layout", "DesignId", "dbo.Design");
            DropIndex("dbo.Text", new[] { "LayoutId" });
            DropIndex("dbo.Image", new[] { "LayoutId" });
            DropIndex("dbo.Diagram", new[] { "LayoutId" });
            DropIndex("dbo.Layout", new[] { "DesignId" });
            DropTable("dbo.Order");
            DropTable("dbo.Text");
            DropTable("dbo.Image");
            DropTable("dbo.Diagram");
            DropTable("dbo.Layout");
            DropTable("dbo.Design");
        }
    }
}
