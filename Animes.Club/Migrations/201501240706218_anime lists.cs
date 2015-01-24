namespace Animes.Club.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class animelists : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Completeds",
                c => new
                    {
                        userId = c.Long(nullable: false),
                        animeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.userId, t.animeId })
                .ForeignKey("dbo.Animes", t => t.animeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId)
                .Index(t => t.animeId);
            
            CreateTable(
                "dbo.Droppeds",
                c => new
                    {
                        userId = c.Long(nullable: false),
                        animeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.userId, t.animeId })
                .ForeignKey("dbo.Animes", t => t.animeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId)
                .Index(t => t.animeId);
            
            CreateTable(
                "dbo.Todoes",
                c => new
                    {
                        userId = c.Long(nullable: false),
                        animeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.userId, t.animeId })
                .ForeignKey("dbo.Animes", t => t.animeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId)
                .Index(t => t.animeId);
            
            CreateTable(
                "dbo.Watchings",
                c => new
                    {
                        userId = c.Long(nullable: false),
                        animeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.userId, t.animeId })
                .ForeignKey("dbo.Animes", t => t.animeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId)
                .Index(t => t.animeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Watchings", "userId", "dbo.Users");
            DropForeignKey("dbo.Watchings", "animeId", "dbo.Animes");
            DropForeignKey("dbo.Todoes", "userId", "dbo.Users");
            DropForeignKey("dbo.Todoes", "animeId", "dbo.Animes");
            DropForeignKey("dbo.Droppeds", "userId", "dbo.Users");
            DropForeignKey("dbo.Droppeds", "animeId", "dbo.Animes");
            DropForeignKey("dbo.Completeds", "userId", "dbo.Users");
            DropForeignKey("dbo.Completeds", "animeId", "dbo.Animes");
            DropIndex("dbo.Watchings", new[] { "animeId" });
            DropIndex("dbo.Watchings", new[] { "userId" });
            DropIndex("dbo.Todoes", new[] { "animeId" });
            DropIndex("dbo.Todoes", new[] { "userId" });
            DropIndex("dbo.Droppeds", new[] { "animeId" });
            DropIndex("dbo.Droppeds", new[] { "userId" });
            DropIndex("dbo.Completeds", new[] { "animeId" });
            DropIndex("dbo.Completeds", new[] { "userId" });
            DropTable("dbo.Watchings");
            DropTable("dbo.Todoes");
            DropTable("dbo.Droppeds");
            DropTable("dbo.Completeds");
        }
    }
}
