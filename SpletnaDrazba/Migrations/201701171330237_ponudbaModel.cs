namespace SpletnaDrazba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ponudbaModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ponudbas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Znesek = c.Double(nullable: false),
                        Drazba_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drazbas", t => t.Drazba_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Drazba_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ponudbas", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ponudbas", "Drazba_Id", "dbo.Drazbas");
            DropIndex("dbo.Ponudbas", new[] { "User_Id" });
            DropIndex("dbo.Ponudbas", new[] { "Drazba_Id" });
            DropTable("dbo.Ponudbas");
        }
    }
}
