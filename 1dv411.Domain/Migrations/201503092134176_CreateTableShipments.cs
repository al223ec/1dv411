namespace _1dv411.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableShipments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shipment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        No_ = c.String(),
                        PostingDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shipment");
        }
    }
}
