namespace Animes.Club.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class animerating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animes", "rating", c => c.Single());
            DropColumn("dbo.Animes", "rate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animes", "rate", c => c.Single(nullable: false));
            DropColumn("dbo.Animes", "rating");
        }
    }
}
