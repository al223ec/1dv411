namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartialBase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Layout", "DesignId", "dbo.Design");
            DropIndex("dbo.Layout", new[] { "DesignId" });
            AddColumn("dbo.Layout", "TemplateUrl", c => c.String());
            AddColumn("dbo.Diagram", "DiagramInfo", c => c.Int(nullable: false));
            AddColumn("dbo.Diagram", "Position", c => c.Int(nullable: false));
            AddColumn("dbo.Image", "Position", c => c.Int(nullable: false));
            AddColumn("dbo.Text", "Position", c => c.Int(nullable: false));
            DropColumn("dbo.Layout", "DesignId");
            DropTable("dbo.Design");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Layout", "DesignId", c => c.Int(nullable: false));
            DropColumn("dbo.Text", "Position");
            DropColumn("dbo.Image", "Position");
            DropColumn("dbo.Diagram", "Position");
            DropColumn("dbo.Diagram", "DiagramInfo");
            DropColumn("dbo.Layout", "TemplateUrl");
            CreateIndex("dbo.Layout", "DesignId");
            AddForeignKey("dbo.Layout", "DesignId", "dbo.Design", "Id", cascadeDelete: true);
        }
    }
}
