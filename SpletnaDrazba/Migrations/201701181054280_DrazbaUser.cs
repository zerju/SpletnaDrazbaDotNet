namespace SpletnaDrazba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrazbaUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drazbas", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Drazbas", "User_Id");
            AddForeignKey("dbo.Drazbas", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drazbas", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Drazbas", new[] { "User_Id" });
            DropColumn("dbo.Drazbas", "User_Id");
        }
    }
}
