namespace Animes.Club.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreNotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animes", "name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Users", "username", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "email", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Animes", "name", unique: true);
            CreateIndex("dbo.Users", "username", unique: true);
            CreateIndex("dbo.Users", "email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "email" });
            DropIndex("dbo.Users", new[] { "username" });
            DropIndex("dbo.Animes", new[] { "name" });
            AlterColumn("dbo.Users", "email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "username", c => c.String(nullable: false));
            AlterColumn("dbo.Animes", "name", c => c.String(nullable: false));
        }
    }
}
