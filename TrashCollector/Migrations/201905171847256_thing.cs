namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thing : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomPickUp", c => c.DateTime());
            AlterColumn("dbo.Customers", "PickUpStart", c => c.DateTime());
            AlterColumn("dbo.Customers", "PickUpEnd", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PickUpEnd", c => c.String());
            AlterColumn("dbo.Customers", "PickUpStart", c => c.String());
            AlterColumn("dbo.Customers", "CustomPickUp", c => c.String());
        }
    }
}
