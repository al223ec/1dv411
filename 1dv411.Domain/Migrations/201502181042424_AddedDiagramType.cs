namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDiagramType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Partial", "DiagramType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Partial", "DiagramType");
        }
    }
}
