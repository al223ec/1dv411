namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TextContentTextType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TextContent", "TextType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TextContent", "TextType");
        }
    }
}
