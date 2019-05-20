namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBillToCurrency : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomerBill", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CustomerBill", c => c.Int(nullable: false));
        }
    }
}
