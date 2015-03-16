namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultValueToFontSizeOnPartial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Partial", "FontSize", c => c.Int(false, false, 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Partial", "FontSize", c => c.Int());
        }
    }
}
