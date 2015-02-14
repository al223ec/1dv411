namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTextProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Partial", "Heading", c => c.String());
            AddColumn("dbo.Partial", "Footer", c => c.String());
            DropColumn("dbo.Partial", "Type");
            DropColumn("dbo.Partial", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Partial", "Value", c => c.String());
            AddColumn("dbo.Partial", "Type", c => c.Int());
            DropColumn("dbo.Partial", "Footer");
            DropColumn("dbo.Partial", "Heading");
        }
    }
}
