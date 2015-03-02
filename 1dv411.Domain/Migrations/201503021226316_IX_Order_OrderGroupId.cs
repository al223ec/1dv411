namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IX_Order_OrderGroupId : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Order", "OrderGroupId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Order", new[] { "OrderGroupId" });
        }
    }
}
