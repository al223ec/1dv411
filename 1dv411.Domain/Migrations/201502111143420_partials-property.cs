namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partialsproperty : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Diagram", newName: "Partial");
            DropIndex("dbo.Image", new[] { "LayoutId" });
            DropIndex("dbo.Text", new[] { "LayoutId" });
            AddColumn("dbo.Partial", "Url", c => c.String());
            AddColumn("dbo.Partial", "Type", c => c.Int());
            AddColumn("dbo.Partial", "Value", c => c.String());
            AddColumn("dbo.Partial", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Partial", "DiagramInfo", c => c.Int());
            DropTable("dbo.Image");
            DropTable("dbo.Text");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Text",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LayoutId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Value = c.String(),
                        Position = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LayoutId = c.Int(nullable: false),
                        Url = c.String(),
                        Position = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Partial", "DiagramInfo", c => c.Int(nullable: false));
            DropColumn("dbo.Partial", "Discriminator");
            DropColumn("dbo.Partial", "Value");
            DropColumn("dbo.Partial", "Type");
            DropColumn("dbo.Partial", "Url");
            CreateIndex("dbo.Text", "LayoutId");
            CreateIndex("dbo.Image", "LayoutId");
            RenameTable(name: "dbo.Partial", newName: "Diagram");
        }
    }
}
