namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTextOptionsToText : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Partial", "Align", c => c.String());
            AddColumn("dbo.Partial", "Valign", c => c.String());
            AddColumn("dbo.Partial", "Bold", c => c.Boolean());
            AddColumn("dbo.Partial", "Italic", c => c.Boolean());
            AddColumn("dbo.Partial", "FontSize", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Partial", "FontSize");
            DropColumn("dbo.Partial", "Italic");
            DropColumn("dbo.Partial", "Bold");
            DropColumn("dbo.Partial", "Valign");
            DropColumn("dbo.Partial", "Align");
        }
    }
}
