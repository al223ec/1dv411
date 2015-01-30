namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Design", "NumberOfFields", c => c.Int(nullable: false));
            AddColumn("dbo.Text", "Value", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Text", "Value");
            DropColumn("dbo.Design", "NumberOfFields");
        }
    }
}
