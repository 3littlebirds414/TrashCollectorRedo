namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thing9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "PickUpDayId", "dbo.PickUpDays");
            DropIndex("dbo.Employees", new[] { "PickUpDayId" });
            DropColumn("dbo.Employees", "TodaysPickUp");
            DropColumn("dbo.Employees", "PickUpDayId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "PickUpDayId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "TodaysPickUp", c => c.String());
            CreateIndex("dbo.Employees", "PickUpDayId");
            AddForeignKey("dbo.Employees", "PickUpDayId", "dbo.PickUpDays", "Id", cascadeDelete: true);
        }
    }
}
