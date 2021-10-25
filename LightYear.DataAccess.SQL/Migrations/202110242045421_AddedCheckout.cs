namespace LightYear.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddCheckout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ResidentialAddress", c => c.String());
            AddColumn("dbo.Orders", "CellNumber", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Orders", "Street");
            DropColumn("dbo.Orders", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "City", c => c.String());
            AddColumn("dbo.Orders", "Street", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Orders", "CellNumber");
            DropColumn("dbo.Orders", "ResidentialAddress");
        }
    }
}
