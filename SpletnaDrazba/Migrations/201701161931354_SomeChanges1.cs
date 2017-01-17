namespace SpletnaDrazba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChanges1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drazbas", "Slike", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drazbas", "Slike");
        }
    }
}
