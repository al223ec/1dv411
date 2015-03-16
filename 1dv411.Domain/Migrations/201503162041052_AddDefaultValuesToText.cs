namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultValuesToText : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Partial", "Bold", c => c.Boolean(false, false));
            AlterColumn("dbo.Partial", "Italic", c => c.Boolean(false, false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Partial", "Bold", c => c.Boolean());
            AlterColumn("dbo.Partial", "Italic", c => c.Boolean());
        }
    }
}
