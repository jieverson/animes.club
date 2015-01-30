namespace Animes.Club.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class animelistdatastructurechange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Completed", "animeId", "dbo.Animes");
            DropForeignKey("dbo.Completed", "userId", "dbo.Users");
            DropForeignKey("dbo.Dropped", "animeId", "dbo.Animes");
            DropForeignKey("dbo.Dropped", "userId", "dbo.Users");
            DropForeignKey("dbo.Todo", "animeId", "dbo.Animes");
            DropForeignKey("dbo.Todo", "userId", "dbo.Users");
            DropForeignKey("dbo.Watching", "animeId", "dbo.Animes");
            DropForeignKey("dbo.Watching", "userId", "dbo.Users");
            DropIndex("dbo.Completed", new[] { "userId" });
            DropIndex("dbo.Completed", new[] { "animeId" });
            DropIndex("dbo.Dropped", new[] { "userId" });
            DropIndex("dbo.Dropped", new[] { "animeId" });
            DropIndex("dbo.Todo", new[] { "userId" });
            DropIndex("dbo.Todo", new[] { "animeId" });
            DropIndex("dbo.Watching", new[] { "userId" });
            DropIndex("dbo.Watching", new[] { "animeId" });
            CreateTable(
                "dbo.AnimeLists",
                c => new
                    {
                        userId = c.Long(nullable: false),
                        animeId = c.Long(nullable: false),
                        status = c.Int(nullable: false),
                        rating = c.Single(),
                    })
                .PrimaryKey(t => new { t.userId, t.animeId })
                .ForeignKey("dbo.Animes", t => t.animeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId)
                .Index(t => t.animeId);
            
            DropTable("dbo.Completed");
            DropTable("dbo.Dropped");
            DropTable("dbo.Todo");
            DropTable("dbo.Watching");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Watching",
                c => new
                    {
                        userId = c.Long(nullable: false),
                        animeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.userId, t.animeId });
            
            CreateTable(
                "dbo.Todo",
                c => new
                    {
                        userId = c.Long(nullable: false),
                        animeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.userId, t.animeId });
            
            CreateTable(
                "dbo.Dropped",
                c => new
                    {
                        userId = c.Long(nullable: false),
                        animeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.userId, t.animeId });
            
            CreateTable(
                "dbo.Completed",
                c => new
                    {
                        userId = c.Long(nullable: false),
                        animeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.userId, t.animeId });
            
            DropForeignKey("dbo.AnimeLists", "userId", "dbo.Users");
            DropForeignKey("dbo.AnimeLists", "animeId", "dbo.Animes");
            DropIndex("dbo.AnimeLists", new[] { "animeId" });
            DropIndex("dbo.AnimeLists", new[] { "userId" });
            DropTable("dbo.AnimeLists");
            CreateIndex("dbo.Watching", "animeId");
            CreateIndex("dbo.Watching", "userId");
            CreateIndex("dbo.Todo", "animeId");
            CreateIndex("dbo.Todo", "userId");
            CreateIndex("dbo.Dropped", "animeId");
            CreateIndex("dbo.Dropped", "userId");
            CreateIndex("dbo.Completed", "animeId");
            CreateIndex("dbo.Completed", "userId");
            AddForeignKey("dbo.Watching", "userId", "dbo.Users", "id", cascadeDelete: true);
            AddForeignKey("dbo.Watching", "animeId", "dbo.Animes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Todo", "userId", "dbo.Users", "id", cascadeDelete: true);
            AddForeignKey("dbo.Todo", "animeId", "dbo.Animes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Dropped", "userId", "dbo.Users", "id", cascadeDelete: true);
            AddForeignKey("dbo.Dropped", "animeId", "dbo.Animes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Completed", "userId", "dbo.Users", "id", cascadeDelete: true);
            AddForeignKey("dbo.Completed", "animeId", "dbo.Animes", "id", cascadeDelete: true);
        }
    }
}
