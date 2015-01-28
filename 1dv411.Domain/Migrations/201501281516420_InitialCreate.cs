namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderGroupId = c.String(),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Screen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        Layout_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Layout", t => t.Layout_Id)
                .Index(t => t.Layout_Id);
            
            CreateTable(
                "dbo.Layout",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LayoutPartial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Value = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        Layout_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Layout", t => t.Layout_Id)
                .Index(t => t.Layout_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Screen", "Layout_Id", "dbo.Layout");
            DropForeignKey("dbo.LayoutPartial", "Layout_Id", "dbo.Layout");
            DropIndex("dbo.LayoutPartial", new[] { "Layout_Id" });
            DropIndex("dbo.Screen", new[] { "Layout_Id" });
            DropTable("dbo.LayoutPartial");
            DropTable("dbo.Layout");
            DropTable("dbo.Screen");
            DropTable("dbo.Order");
        }
    }
}
