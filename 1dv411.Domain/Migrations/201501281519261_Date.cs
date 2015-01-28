namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Date : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "CreatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Order", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Screen", "CreatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Screen", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Layout", "CreatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Layout", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.LayoutPartial", "CreatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.LayoutPartial", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LayoutPartial", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LayoutPartial", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Layout", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Layout", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Screen", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Screen", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
