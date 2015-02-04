namespace Animes.Club.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addepisodestoAnime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animes", "episodes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animes", "episodes");
        }
    }
}
