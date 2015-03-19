namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepartials : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Partial", "Bold", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Partial", "Italic", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Partial", "FontSize", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Partial", "FontSize", c => c.Int());
            AlterColumn("dbo.Partial", "Italic", c => c.Boolean());
            AlterColumn("dbo.Partial", "Bold", c => c.Boolean());
        }
    }
}
