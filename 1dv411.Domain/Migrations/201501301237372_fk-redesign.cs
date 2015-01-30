namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkredesign : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Layout", "Id", "dbo.Design");
            DropForeignKey("dbo.Diagram", "Id", "dbo.Layout");
            DropForeignKey("dbo.Image", "Id", "dbo.Layout");
            DropForeignKey("dbo.Text", "Id", "dbo.Layout");
            DropIndex("dbo.Layout", new[] { "Id" });
            DropIndex("dbo.Diagram", new[] { "Id" });
            DropIndex("dbo.Image", new[] { "Id" });
            DropIndex("dbo.Text", new[] { "Id" });
            DropPrimaryKey("dbo.Layout");
            DropPrimaryKey("dbo.Diagram");
            DropPrimaryKey("dbo.Image");
            DropPrimaryKey("dbo.Text");
            AddColumn("dbo.Layout", "DesignId", c => c.Int(nullable: false));
            AddColumn("dbo.Diagram", "LayoutId", c => c.Int(nullable: false));
            AddColumn("dbo.Image", "LayoutId", c => c.Int(nullable: false));
            AddColumn("dbo.Text", "LayoutId", c => c.Int(nullable: false));
            AlterColumn("dbo.Layout", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Diagram", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Image", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Text", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Layout", "Id");
            AddPrimaryKey("dbo.Diagram", "Id");
            AddPrimaryKey("dbo.Image", "Id");
            AddPrimaryKey("dbo.Text", "Id");
            CreateIndex("dbo.Layout", "DesignId");
            CreateIndex("dbo.Diagram", "LayoutId");
            CreateIndex("dbo.Image", "LayoutId");
            CreateIndex("dbo.Text", "LayoutId");
            AddForeignKey("dbo.Layout", "DesignId", "dbo.Design", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Diagram", "LayoutId", "dbo.Layout", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Image", "LayoutId", "dbo.Layout", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Text", "LayoutId", "dbo.Layout", "Id", cascadeDelete: true);
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
            DropPrimaryKey("dbo.Text");
            DropPrimaryKey("dbo.Image");
            DropPrimaryKey("dbo.Diagram");
            DropPrimaryKey("dbo.Layout");
            AlterColumn("dbo.Text", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Image", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Diagram", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Layout", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Text", "LayoutId");
            DropColumn("dbo.Image", "LayoutId");
            DropColumn("dbo.Diagram", "LayoutId");
            DropColumn("dbo.Layout", "DesignId");
            AddPrimaryKey("dbo.Text", "Id");
            AddPrimaryKey("dbo.Image", "Id");
            AddPrimaryKey("dbo.Diagram", "Id");
            AddPrimaryKey("dbo.Layout", "Id");
            CreateIndex("dbo.Text", "Id");
            CreateIndex("dbo.Image", "Id");
            CreateIndex("dbo.Diagram", "Id");
            CreateIndex("dbo.Layout", "Id");
            AddForeignKey("dbo.Text", "Id", "dbo.Layout", "Id");
            AddForeignKey("dbo.Image", "Id", "dbo.Layout", "Id");
            AddForeignKey("dbo.Diagram", "Id", "dbo.Layout", "Id");
            AddForeignKey("dbo.Layout", "Id", "dbo.Design", "Id");
        }
    }
}
