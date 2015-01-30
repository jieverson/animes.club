namespace Animes.Club.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimeTags",
                c => new
                    {
                        animeId = c.Long(nullable: false),
                        tagId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.animeId, t.tagId })
                .ForeignKey("dbo.Animes", t => t.animeId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.tagId, cascadeDelete: true)
                .Index(t => t.animeId)
                .Index(t => t.tagId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        value = c.String(nullable: false, maxLength: 50),
                        color = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.value, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnimeTags", "tagId", "dbo.Tags");
            DropForeignKey("dbo.AnimeTags", "animeId", "dbo.Animes");
            DropIndex("dbo.Tags", new[] { "value" });
            DropIndex("dbo.AnimeTags", new[] { "tagId" });
            DropIndex("dbo.AnimeTags", new[] { "animeId" });
            DropTable("dbo.Tags");
            DropTable("dbo.AnimeTags");
        }
    }
}
