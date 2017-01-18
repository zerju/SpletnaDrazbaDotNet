namespace SpletnaDrazba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedUserNameAndLast : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ponudbas", "Ime");
            DropColumn("dbo.Ponudbas", "Priimek");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ponudbas", "Priimek", c => c.String());
            AddColumn("dbo.Ponudbas", "Ime", c => c.String());
        }
    }
}
