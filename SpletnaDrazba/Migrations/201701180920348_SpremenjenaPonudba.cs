namespace SpletnaDrazba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpremenjenaPonudba : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ponudbas", "Ime", c => c.String());
            AddColumn("dbo.Ponudbas", "Priimek", c => c.String());
            AlterColumn("dbo.Ponudbas", "Znesek", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ponudbas", "Znesek", c => c.Double(nullable: false));
            DropColumn("dbo.Ponudbas", "Priimek");
            DropColumn("dbo.Ponudbas", "Ime");
        }
    }
}
