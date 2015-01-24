namespace Animes.Club.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class animedescriptionandrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animes", "description", c => c.String());
            AddColumn("dbo.Animes", "rate", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animes", "rate");
            DropColumn("dbo.Animes", "description");
        }
    }
}
