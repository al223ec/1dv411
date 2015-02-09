namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScreenAndLayoutScreen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LayoutScreen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScreenId = c.Int(nullable: false),
                        LayoutId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Layout", t => t.LayoutId, cascadeDelete: true)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LayoutScreen", "ScreenId", "dbo.Screen");
            DropForeignKey("dbo.LayoutScreen", "LayoutId", "dbo.Layout");
            DropIndex("dbo.LayoutScreen", new[] { "LayoutId" });
            DropIndex("dbo.LayoutScreen", new[] { "ScreenId" });
            DropTable("dbo.Screen");
            DropTable("dbo.LayoutScreen");
        }
    }
}
