namespace SpletnaDrazba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDatumOddaje : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ponudbas", "DatumOddaje", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ponudbas", "DatumOddaje");
        }
    }
}
