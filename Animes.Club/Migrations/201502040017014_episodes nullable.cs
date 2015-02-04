namespace Animes.Club.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class episodesnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animes", "episodes", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animes", "episodes", c => c.Int(nullable: false));
        }
    }
}
