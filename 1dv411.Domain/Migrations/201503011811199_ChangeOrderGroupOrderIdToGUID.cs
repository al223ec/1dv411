namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOrderGroupOrderIdToGUID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "OrderGroupId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "OrderGroupId", c => c.String());
        }
    }
}
