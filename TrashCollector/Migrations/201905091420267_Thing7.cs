namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thing7 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "PickUpDayIds", newName: "PickUpDayId");
            RenameIndex(table: "dbo.Customers", name: "IX_PickUpDayIds", newName: "IX_PickUpDayId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Customers", name: "IX_PickUpDayId", newName: "IX_PickUpDayIds");
            RenameColumn(table: "dbo.Customers", name: "PickUpDayId", newName: "PickUpDayIds");
        }
    }
}
