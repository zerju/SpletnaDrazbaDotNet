namespace SpletnaDrazba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedZnesek : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ponudbas", "Znesek", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ponudbas", "Znesek", c => c.Double(nullable: false));
        }
    }
}
