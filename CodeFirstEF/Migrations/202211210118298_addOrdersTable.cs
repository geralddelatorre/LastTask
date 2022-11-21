namespace CodeFirstEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrdersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "DocDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "DocDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "OrderDate");
        }
    }
}
